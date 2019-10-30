Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.ComponentModel
Imports excel = Microsoft.Office.Interop.Excel
Imports System.Drawing
Imports System.Configuration
Imports System.Windows.Forms.ContextMenu

Public Class CommissionRpt

    Private intA As Integer
    Private intB As Integer
    Private intRow As Integer
    Private intCol As Integer
    Private iPreviousCheckedRow As Integer
    Private iCurrentCheckedRow As Integer
    Private rowToPaint As Integer
    Private iStartValidatedRow As Integer
    Private iEndValidatedRow As Integer
    Private booFirstClick As Boolean
    Private bIsLoading As Boolean = True
    Private strSelectedText As String
    Private commobj As CommissionObj = New CommissionObj
    Private commlst As CommissionList = New CommissionList
    Private commsaveobj As New CommissionSavedObj
    Private commsavelist As New CommissionSavedList
    Public savefldtobj As New DraftCommissionHdrObj
    Public savefldtlst As New DraftCommissionHdrList
    Private progcount As Integer
    Public bo As BusObj = New BusObj
    Public draftnumber As Integer
    Public draftName As String
    Private ColName As String
    Private mCommissionType As String
    Private colindex As Integer
    Private cellValue As Object
    Private cellText As String
    Private cellType As Type
    Private iGridSourceName As String

    Const sCheckMark1 As Char = ChrW(&H2611)  'Check with box
    Const sCheckMark2 As Char = ChrW(&H2713)  'Light check mark
    Const sCheckMark3 As Char = ChrW(&H2714)  'Heavy check mark
    Const sGlyphDown As Char = ChrW(&H25BC) 'Glyph (down pointing triangle)
    Const sGlyphUp As Char = ChrW(&H25B2) 'Glyph (up pointing triangle)
    Const sHeavyMultiplicationX As Char = ChrW(&H2716) 'Heavy multiplication x
    Const sMultiplicationX As Char = ChrW(&H2715) 'Heavy multiplication x

#Region "   Load Form   "

    Private Sub CommissionRpt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.startup = True
        'Me.ToolStripCompanyComboBox.SelectedIndex = 0

        MacStartup(My.Settings.DefaultDB)
        Me.StatusStrip1.Items("ToolStripStatusDatabase").Text = cn.Database
        LoadDataGrid()
        Me.startup = False
        With CommissionObjDataGridView
            .Columns("Selected").HeaderText = sCheckMark3
        End With
        bIsLoading = False
        ToolTipOrderNo.SetToolTip(btnToggleValidatedComm, "Click to Toggle " & sMultiplicationX & " ON or OFF for the OK " & sMultiplicationX & " Column")
    End Sub

#End Region

#Region "   Methods   "


    Public Sub GetCommissionData(ByVal pymtdate As Integer, ByVal USAorCAN As String, ByVal commdraftid As Integer, ByVal datasource As Integer)

        Dim rd As SqlDataReader

        rd = BusObj.GetCommissionDataReader(pymtdate, USAorCAN, commdraftid, datasource, cn)
        If rd.HasRows = True Then
            Me.PaymentDateDateTimePicker.Enabled = False
            Me.btnAddRow.Enabled = True
            Me.btnRemoveRow.Enabled = True
        Else
            Me.PaymentDateDateTimePicker.Enabled = True
        End If
        commlst = BusObj.PopulateCommission(rd)

        rd.Close()
        Me.CommissionObjBindingSource.DataSource = commlst
        'GetProgBarValues()

    End Sub

    Public Function GetCommissionID(ByVal CommName As String, ByVal DraftorFinal As String) As Integer
        Dim commid As Integer
        commid = BusObj.GetCommissionID(CommName, DraftorFinal, cn)
        Return commid
    End Function

    Public Sub GetSearchData(ByVal where As String)
        ClearGrid()
        Dim rd As SqlDataReader
        rd = BusObj.GetSearchDateReader(where, cn)
        commlst = BusObj.PopulateCommission(rd)
        Try
            rd.Close()
            Me.CommissionObjBindingSource.DataSource = commlst
        Catch ex As Exception

        End Try


        'GetProgBarValues()
        SetModifiedRowBackground()
    End Sub

    Public Sub GetCommissionDataByOrder(ByVal OrderNo As String)

        Dim rd As SqlDataReader
        Dim rw As Integer = commlst.Count - 1
        If commlst(rw).InvoiceNumber > 0 Then
            If Not (MsgBox("NOT A BLANK ROW!  You are about to overwrite the data in this row?" & vbCrLf & vbCrLf & _
                           "Row contains data: Customer " & commlst(rw).ShipToName & ", Invoice No " & commlst(rw).InvoiceNumber & vbCrLf & vbCrLf & _
                           "Press NO to Cancel", MsgBoxStyle.YesNo, "Overwrite Data Warning")) Then
            End If
        End If
        rd = BusObj.GetCommissionDataByOrder(OrderNo, cn)
        If rd.HasRows = False Then
            rd.Close()
            If MsgBox("The Order Number " & OrderNo & ", was not found.  " & vbCrLf & vbCrLf & _
                      " - Press Retry to try another Order No" & vbCrLf & vbCrLf & _
                      " - Press Cancel to Remove the Empty Row and Cancel Search" & vbCrLf & vbCrLf _
                      , MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel Then
                With txtOrderNoSearch
                    .Text = ""
                    .Enabled = False
                End With
                btnOrderLookup.Enabled = False
                With CommissionObjDataGridView
                    .Rows.RemoveAt(.Rows.Count - 1)
                End With
            End If

            Exit Sub

        End If
        commobj = BusObj.PopulateCommissionObj(rd)
        commlst(rw).RepGroup = commobj.RepGroup
        commlst(rw).SalesPersonNumber = commobj.SalesPersonNumber
        commlst(rw).SalesPersonName = commobj.SalesPersonName
        commlst(rw).InvoiceNumber = commobj.InvoiceNumber
        commlst(rw).ShipToName = commobj.ShipToName
        commlst(rw).ShipToState = commobj.ShipToState
        commlst(rw).BillToState = commobj.BillToState
        commlst(rw).OrderDate = commobj.OrderDate
        commlst(rw).ShipDate = commobj.ShipDate
        commlst(rw).PaymentDate = commlst(0).PaymentDate

        commlst(rw).FreightAmount = commobj.FreightAmount
        commlst(rw).FreightPercent = commobj.FreightPercent
        commlst(rw).NetSalesAmount = commobj.NetSalesAmount
        commlst(rw).DiscountAmount = commobj.DiscountAmount
        commlst(rw).PickupAllowanceAmount = commobj.PickupAllowanceAmount
        commlst(rw).AmountPaid = commobj.AmountPaid
        commlst(rw).CommissionPercent = commobj.CommissionPercent
        commlst(rw).SS12 = commobj.SS12
        commlst(rw).CommissionAmount = commobj.CommissionAmount
        commlst(rw).Reference = commobj.Reference

        commlst(rw).CommID = commobj.CommID
        commlst(rw).CusNo = commobj.CusNo
        commlst(rw).TotalSalesAmt = commobj.TotalSalesAmt
        commlst(rw).BatchID = commobj.BatchID
        commlst(rw).MiscAmt = commobj.MiscAmt
        commlst(rw).OrderNo = commobj.OrderNo

        rd.Close()

        Me.RepGroupTextBox.DataBindings("Text").ReadValue()
        Me.SalesPersonNumberTextBox.DataBindings("Text").ReadValue()
        Me.SalesPersonNumberTextBox.DataBindings("Text").ReadValue()
        Me.InvoiceNumberTextBox.DataBindings("Text").ReadValue()
        Me.ShipToNameTextBox.DataBindings("Text").ReadValue()
        Me.ShipToStateTextBox.DataBindings("Text").ReadValue()
        Me.BillToStateTextBox.DataBindings("Text").ReadValue()
        Me.OrderNoTextBox.DataBindings("Text").ReadValue()
        Me.OrderDateDateTimePicker.DataBindings("Value").ReadValue()
        Me.ShipDateDateTimePicker.DataBindings("Value").ReadValue()
        Me.PaymentDateDateTimePicker.DataBindings("Value").ReadValue()
        Me.FreightAmountTextBox.DataBindings("Text").ReadValue()
        Me.FreightPercentTextBox.DataBindings("Text").ReadValue()
        Me.NetSalesAmountTextBox.DataBindings("Text").ReadValue()
        Me.DiscountAmountTextBox.DataBindings("Text").ReadValue()
        Me.PickupAllowanceAmountTextBox.DataBindings("Text").ReadValue()
        Me.AmountPaidTextBox.DataBindings("Text").ReadValue()
        Me.CommissionPercentTextBox.DataBindings("Text").ReadValue()
        Me.SS12TextBox.DataBindings("Text").ReadValue()
        Me.CommissionAmountTextBox.DataBindings("Text").ReadValue()
        Me.ReferenceTextBox.DataBindings("Text").ReadValue()
        Me.CusNoTextBox.DataBindings("Text").ReadValue()
        Me.TotalSalesAmtTextBox.DataBindings("Text").ReadValue()
        Me.BatchIDTextBox.DataBindings("Text").ReadValue()
        Me.MiscAmtTextBox.DataBindings("Text").ReadValue()
        Me.OrderNoTextBox.DataBindings("Text").ReadValue()

        Me.Validate()
        Me.CommissionObjDataGridView.Rows.GetPreviousRow(rw, DataGridViewElementStates.Selected)
        Me.CommissionObjBindingSource.MoveFirst()
        Me.CommissionObjBindingSource.MoveLast()
    End Sub

    Private Sub LoadDataGrid()
        Dim col As DataGridViewColumn
        Dim itms As System.Windows.Forms.ToolStripItemCollection = Me.ContextMenuStripColumns.Items
        Dim itm As New ToolStripMenuItem
        For Each col In Me.CommissionObjDataGridView.Columns
            With Me.ContextMenuStripColumns
                .Items.Add(col.Name.ToString)
                Try
                    col.Visible = CBool(My.Settings(col.Name).ToString)
                Catch ex As Exception

                End Try

            End With
        Next

        With CommissionObjDataGridView.Columns("ValidatedComm")

        End With

        With CommissionObjDataGridView
            With .Columns("ValidatedComm")
                .Width = 35
                .ReadOnly = False
                .HeaderText = "OK" & vbCrLf & sHeavyMultiplicationX
                '.ToolTipText "Click Once for Sort.  
                '.SortMode = DataGridViewColumnSortMode.NotSortable
            End With
            With .Columns("Selected")
                .HeaderText = sCheckMark3
            End With
            With .Columns("Modified")
                .HeaderText = "Mod" & vbCrLf & sHeavyMultiplicationX
                .Width = 40
            End With
            With .Columns("OrderNo")
                .HeaderText = "Order No"
                .Width = 60
            End With
            With .Columns("InvoiceNumber")
                .HeaderText = "Invoice No"
                .Width = 60
            End With
            With .Columns("ShipToState")
                .HeaderText = "Ship To"
                .Width = 35
            End With
            With .Columns("OrderDate")
                .HeaderText = "Order Date"
                .Width = 80
            End With
            With .Columns("SalesPersonNumber")
                .HeaderText = "Rep#"
                .Width = 40
            End With
            With .Columns("CusNo")
                .HeaderText = "Cust No"
                .Width = 105
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            With .Columns("CommissionAmount")
                .HeaderText = "Comm Amt"
                .Width = 70
            End With
            With .Columns("CommissionPercent")
                .HeaderText = "Comm %"
                .Width = 55
            End With
            With .Columns("TotalSalesAmt")
                .HeaderText = "Net Sale"
                .Width = 75
            End With
            With .Columns("FreightAmount")
                .HeaderText = "Frt Amt"
                .Width = 65
            End With
            With .Columns("FreightPercent")
                .HeaderText = "Frt %"
                .Width = 45
            End With
           
        End With

    End Sub

    Public Sub SaveDraftHeader(ByVal CommID_Delete As Integer, ByVal filename As String, ByVal DraftOrFinal As String)
        Dim userdate As Date = Now
        Dim draftid As Integer

        draftid = BusObj.SaveCommissionHeader(CommID_Delete, filename, PaymentDate_Status, userdate, DraftOrFinal, AddedModified, 0, cn)
        SaveDraftCommission(draftid, DraftOrFinal, CommID_Delete)
        CommissionType = DraftOrFinal
        CommDraftName = "Draft Name: " & filename
    End Sub

    Public Sub SaveDraftCommission(ByVal draftID As String, ByVal draftorfinal As String, ByVal commdraftid_deleted As Integer)
        Dim RowState As String = AddedModified
        Dim co As CommissionObj
        Dim result As Boolean
        Dim i As Integer = 0
        Me.ValidateChildren()
        For Each co In commlst
            'TODO: RowState here may need to be moved to the Open commission 
            result = BusObj.SaveAsCommissionReport(draftID, co.RepGroup, co.SalesPersonNumber, co.SalesPersonName, co.InvoiceNumber, _
            co.ShipToName, co.ShipToState, co.BillToState, co.OrderDate, co.ShipDate, co.PaymentDate, CDec(co.FreightAmount), _
            CDec(co.FreightPercent), CDec(co.NetSalesAmount), CDec(co.DiscountAmount), CDec(co.PickupAllowanceAmount), CDec(co.AmountPaid), CDec(co.CommissionPercent), _
            CDec(co.SS12), CDec(co.CommissionAmount), co.Reference, co.CommID, ("000000000000" & co.CusNo.ToString).Substring(("000000000000" & co.CusNo.ToString).Length - 12), _
            CDec(co.TotalSalesAmt), co.BatchID, CDec(co.MiscAmt), co.OrderNo, IIf(co.Modified = sMultiplicationX, 1, 0), IIf(co.ValidatedComm = sMultiplicationX, 1, 0), draftorfinal, commdraftid_deleted, RowState, cn)
             i = i + 1
            If i <= Me.ToolStripProgressBarCommRpt.Maximum Then
                Me.ToolStripProgressBarCommRpt.Value = i
            End If

        Next
        Me.ToolStripProgressBarCommRpt.Value = 0
    End Sub

    Private Sub AddEmptyRow()
        Try
            commlst.AddNew()
            CommissionObjDataGridView.Rows(CommissionObjDataGridView.Rows.Count - 1).Selected = True
            CommissionObjBindingSource.MoveLast()
            Me.CommIDTextBox.Text = commlst(0).CommID
            Me.PaymentDateDateTimePicker.Value = commlst(0).PaymentDate
            Me.PaymentDateDateTimePicker.Text = commlst(0).PaymentDate

            commlst(commlst.Count - 1).PaymentDate = commlst(0).PaymentDate
            commlst(commlst.Count - 1).CommID = commlst(0).CommID
            commlst(commlst.Count - 1).AddedColumn = True
            Me.ButtonGetOrder.Enabled = True
            Me.btnOrderLookup.Enabled = True

        Catch ex As Exception

        End Try
        Me.CommissionObjBindingSource.EndEdit()
        Me.CommissionObjBindingSource.MoveFirst()
        Me.CommissionObjBindingSource.MoveLast()

    End Sub

    Private Sub RemoveRow()
        Dim msg As String = "Are you sure you want to delete the current record? "

        If MessageBox.Show(msg, "Confirm Delete", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'Delete the Current Record
            'Me.CommissionObjBindingSource.RemoveCurrent()
            Dim currentrow As Integer = CInt(Me.CommissionObjBindingSource.Position)
            Try
                Me.CommissionObjBindingSource.RemoveAt(currentrow)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub SaveAsDraft()
        Dim doSave As Boolean
        Dim dupOrderNo As Boolean
        Dim doneNotChecked As String = ""
        Dim sShipDateList As String = ""
        Dim res As Integer
        Dim pdt As String
        Me.CommissionObjDataGridView.EndEdit()
        Me.Validate()
        Dim dgv As DataGridView = CType(Me.CommissionObjDataGridView, DataGridView)
        If CommissionObjDataGridView.Rows.Count = 0 Then Exit Sub

        doSave = Me.ValidatePaymentDatesBeforeSave()
        If doSave = False Then
            pdt = Me.ToolStripStatusPaymentDate.Text

            res = MessageBox.Show("Incorrect Payment Dates." & vbCrLf & vbCrLf & "Payment Dates for each line must be " & pdt.Substring(4, 2) & "/" & pdt.Substring(6, 2) & "/" & pdt.Substring(0, 4) & ".  " & vbCrLf & vbCrLf & _
                            "To automatically fill in the Payment Dates, press Yes (you will still be able to edit the commission).  Press No to cancel.", "Save Failed: Payment Dates not all the same.", MessageBoxButtons.YesNo)
            If res = vbNo Then
                Exit Sub
            Else
                PopulatePaymentDatesBeforeSave()
                res = MsgBox("Payment Dates have been corrrected." & vbCrLf & vbCrLf & "Check for invalid or over 1 year old ShippedOn dates?", MsgBoxStyle.YesNo, "Payment Dates Corrected.")
                If res = vbNo Then
                    Exit Sub
                Else
                    sShipDateList = ValidateShippedOnDatesBeforeSave()
                    If sShipDateList = "" Then
                        res = MsgBox("ShippedOn Dates are all within 1 year.  Proceed to Save?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                        If res = vbNo Then Exit Sub
                    Else
                        res = MsgBox("These ShippedOn Dates may need correcting." & vbCrLf & vbCrLf & sShipDateList & vbCrLf & vbCrLf & " Save anyway?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                        If res = vbNo Then Exit Sub
                    End If
                End If
            End If
        Else
            res = MsgBox("Payment Dates Validated" & vbCrLf & vbCrLf & "Check for invalid or over 1 year old ShippedOn dates?", MsgBoxStyle.YesNo, "Payment Dates Corrected.")
            If res = vbNo Then
                Exit Sub
            Else
                sShipDateList = ValidateShippedOnDatesBeforeSave()
                If sShipDateList = "" Then
                    res = MsgBox("ShippedOn Dates are all within 1 year.  Proceed to Save?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                    If res = vbNo Then Exit Sub
                Else
                    res = MsgBox("These ShippedOn Dates may need correcting.  All are more than 1 year old." & vbCrLf & vbCrLf & sShipDateList & vbCrLf & vbCrLf & " Save anyway?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                    If res = vbNo Then Exit Sub
                End If
            End If
        End If
        dupOrderNo = Me.ValidateOrderNumbersOnGrid()
        If dupOrderNo = True Then
            Exit Sub
        End If

        'Finally, check to be sure all the DONE cells have been checked.  
        doneNotChecked = Me.ValidateDoneCheckedOnGrid(dgv)
        If doneNotChecked > "" Then
            Dim iResult As Integer
            iResult = MsgBox("The Lines below have not been marked " & sMultiplicationX & " in the DONE column." & vbCrLf & vbCrLf & _
                             "Do you want to check all?" & vbCrLf & _
                             " - Press YES to Check All and Save" & vbCrLf & " - NO to Save and Leave Unckecked as is" & vbCrLf & " - CANCEL to Stop Processing." & vbCrLf & vbCrLf & _
                             doneNotChecked,
                             MsgBoxStyle.YesNoCancel, _
                             "Marked Done Validation")
            If iResult = MsgBoxResult.Cancel Then
                Exit Sub
            ElseIf iResult = MsgBoxResult.Yes Then
                For Each rw As DataGridViewRow In dgv.Rows
                    rw.Cells("ValidatedComm").Value = sMultiplicationX
                Next
            Else
                'No selected, keep it as is, Go ahead an process
            End If
        End If

        Dim savefiledate As New SaveAs
        savefiledate.Show()
    End Sub

    Private Sub SaveAsFinal()
        Dim FinalExists As Boolean = False
        Dim res As Integer
        Dim pdt As String
        Dim doneNotChecked As String
        Dim rd As SqlDataReader
        Dim type As String = "Final"
        Dim doSave As Boolean
        Dim sShipDateList
        Dim sUSorCAD As String = ""
        Dim dgv As DataGridView = CType(CommissionObjDataGridView, DataGridView)
        If CommissionObjDataGridView.Rows.Count = 0 Then Exit Sub

        'Finally, check to be sure all the DONE cells have been checked.  
        doneNotChecked = Me.ValidateDoneCheckedOnGrid(dgv)
        If doneNotChecked > "" Then
            Dim iResult As Integer
            iResult = MsgBox("The Lines below have not been marked " & sMultiplicationX & " in the DONE column." & vbCrLf & vbCrLf & _
                             "Do you want to check all?" & vbCrLf & _
                             " - Press YES to Check All and Save" & vbCrLf & " - NO to Save and Leave Unckecked as is" & vbCrLf & " - CANCEL to Stop Processing." & vbCrLf & vbCrLf & _
                             doneNotChecked,
                             MsgBoxStyle.YesNoCancel, _
                             "Marked Done Validation")
            If iResult = MsgBoxResult.Cancel Then
                Exit Sub
            ElseIf iResult = MsgBoxResult.Yes Then
                For Each rw As DataGridViewRow In dgv.Rows
                    rw.Cells("ValidatedComm").Value = sMultiplicationX
                Next
            Else
                'No selected, keep it as is, Go ahead an process
            End If
        End If

        doSave = Me.ValidatePaymentDatesBeforeSave()
        If doSave = False Then
            pdt = Me.ToolStripStatusPaymentDate.Text

            res = MessageBox.Show("Incorrect Payment Dates." & vbCrLf & vbCrLf & "Payment Dates for each order must be " & pdt.Substring(4, 2) & "/" & pdt.Substring(6, 2) & "/" & pdt.Substring(0, 4) & ".  " & vbCrLf & vbCrLf & _
                                  "To automatically fill in the Payment Dates, press Yes (you will still be able to edit the commission).  Press No to cancel.", "Save Failed: Payment Dates not all the same.", MessageBoxButtons.YesNo)
            If res = vbNo Then
                Exit Sub
            Else
                PopulatePaymentDatesBeforeSave()
                res = MsgBox("Payment Dates have been corrrected." & vbCrLf & vbCrLf & "Check for invalid or over 1 year old ShippedOn dates?", MsgBoxStyle.YesNo, "Payment Dates Corrected.")
                If res = vbNo Then
                    Exit Sub
                Else
                    sShipDateList = ValidateShippedOnDatesBeforeSave()
                    If sShipDateList = "" Then
                        res = MsgBox("ShippedOn Dates are all within 1 year.  Proceed to Save?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                        If res = vbNo Then Exit Sub
                    Else
                        res = MsgBox("These ShippedOn Dates may need correcting.  All are more than 1 year old." & vbCrLf & vbCrLf & sShipDateList & vbCrLf & vbCrLf & " Save anyway?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                        If res = vbNo Then Exit Sub
                    End If
                End If

            End If
        Else
            res = MsgBox("Payment Dates Validated" & vbCrLf & vbCrLf & "Check for invalid or over 1 year old ShippedOn dates?", MsgBoxStyle.YesNo, "Payment Dates Corrected.")
            If res = vbNo Then
                Exit Sub
            Else
                sShipDateList = ValidateShippedOnDatesBeforeSave()
                If sShipDateList = "" Then
                    res = MsgBox("ShippedOn Dates are all within 1 year.  Proceed to Save?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                    If res = vbNo Then Exit Sub
                Else
                    res = MsgBox("These ShippedOn Dates may need correcting.  All are more than 1 year old." & vbCrLf & vbCrLf & sShipDateList & vbCrLf & vbCrLf & " Save anyway?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                    If res = vbNo Then Exit Sub
                End If
            End If

        End If

        rd = BusObj.GetDraftCommissionHeaderList(type, bo.SearchPaymentDateDT, cn)
        If rd Is Nothing Then Exit Sub
        While rd.Read
            sUSorCAD = rd("comm_nam")

            If sUSorCAD.IndexOf("CAD") > 0 Then
                sUSorCAD = "CAD"
                'Exit While
            Else
                sUSorCAD = "USA"
                'Exit While
            End If

        End While
        If sUSorCAD > "" Then
            FinalExists = True
        Else
            FinalExists = False
        End If


        'FinalExists = rd.HasRows
        If FinalExists = True Then
            Me.AddedModified = "Modified"
            Me.CommDraftID_Delete = 1
        Else
            Me.AddedModified = "Added"
            Me.CommDraftID_Delete = 0
        End If
        rd.Close()
        If FinalExists = True Then
            ' MessageBox.Show("A final commission exists already.  Final commissions are read-only and cannot be overwritten.", "Existing Final Commission", MessageBoxButtons.OK)
            Dim frm As New SaveAsPassword
            frm.ButtonOpenPassword.Visible = True
            frm.ButtonSavePassword.Visible = False
            frm.ShowDialog()
            Dim savefinal As New SaveAs
            savefinal.Text = "Save Final Commission"
            savefinal.ButtonSave.Enabled = OverwriteFinal
            savefinal.Show()
        Else
            Dim savefinal As New SaveAs
            savefinal.Text = "Save Final Commission"
            savefinal.ButtonSave.Enabled = True
            savefinal.Show()

        End If
    End Sub

    'Private Sub GetProgBarValues()
    '    Dim invcount As Integer
    '    Try
    '        invcount = commlst.Count
    '        bo.MinProgBar = 0
    '        bo.MaxProgBar = invcount
    '        Me.ToolStripProgressBarCommRpt.Minimum = bo.MinProgBar
    '        Me.ToolStripProgressBarCommRpt.Maximum = bo.MaxProgBar
    '        Me.ToolStripProgressBarCommRpt.Step = 100 / bo.MaxProgBar
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub ExportToExcel()
        Dim FldNames() As String = GetSelectedFieldNames()
        Dim colsCounter As Int32 = 0
        Dim colsVisible As Int32 = 0
        'Dim rowsCounter As Int32 = 0
        Dim rows As Int32 = Me.CommissionObjDataGridView.Rows.Count - 1
        Dim cols As Int32 = UBound(FldNames)
        Dim DataArr(rows, cols) As Object
        'Me.CommissionObjDataGridView.SelectAll()
        For rowsCounter As Int32 = 0 To rows
            For Each cell As DataGridViewCell In Me.CommissionObjDataGridView.Rows(rows - rowsCounter).Cells
                If Me.CommissionObjDataGridView.Columns(colsCounter).Visible = True Then
                    DataArr(rowsCounter, colsVisible) = cell.Value
                    colsVisible = colsVisible + 1
                End If
                colsCounter = colsCounter + 1
            Next
            colsVisible = 0
            colsCounter = 0
        Next

        'Excel Variables
        Dim xlapp As New excel.Application
        Dim xlwbook As excel.Workbook = xlapp.Workbooks.Add(excel.XlWBATemplate.xlWBATWorksheet)
        Dim xlwsheet As excel.Worksheet = CType(xlwbook.Worksheets(1), excel.Worksheet)
        Dim xlcalc As excel.XlCalculation

        With xlapp
            xlcalc = .Calculation
            .Calculation = excel.XlCalculation.xlCalculationManual
        End With

        With xlwsheet
            .Range(.Cells(1, 1), .Cells(1, cols + 1)).Value = FldNames
            .Range(.Cells(2, 1), .Cells(rows + 2, cols + 1)).Value = DataArr
            .UsedRange.Columns.AutoFit()
        End With

        With xlapp
            .Visible = True
            .UserControl = True
            .Calculation = xlcalc
        End With

        xlwsheet = Nothing
        xlwbook = Nothing
        xlapp = Nothing
        GC.Collect()


    End Sub

    Private Function GetSelectedFieldNames() As String()
        Dim fieldnames() As String
        Dim fldnms As New StringBuilder
        'Dim chk As ToolStripMenuItem
        Dim col As DataGridViewColumn
        'Dim itms As System.Windows.Forms.ToolStripItemCollection = Me.ContextMenuStripColumns.Items
        'Dim itm As New ToolStripMenuItem
        For Each col In Me.CommissionObjDataGridView.Columns
            With Me.ContextMenuStripColumns
                Try
                    If CBool(My.Settings(col.Name)) = True Then
                        If fldnms.ToString.Length = 0 Then
                            fldnms.Append(col.Name.ToString)
                        Else
                            fldnms.Append(",")
                            If col.Name.ToString = "NetSalesAmount" Then
                                fldnms.Append("TotalSalesAmt")
                            ElseIf col.Name.ToString = "TotalSalesAmt" Then
                                fldnms.Append("NetSalesAmount")
                            Else
                                fldnms.Append(col.Name.ToString)
                            End If
                        End If

                    End If



                Catch ex As Exception

                End Try

            End With
        Next

        fieldnames = Split(fldnms.ToString, ",")
        Return fieldnames

    End Function

    Public Sub ClearGrid()
        Try
            Me.commlst.Clear()
            Me.CommissionType = ""
            Me.CommDraftName = ""
            Me.PaymentDate_Status = ""
            Me.PaymentDateDateTimePicker.Enabled = True
        Catch ex As Exception

        End Try

    End Sub

#Region "   Context Menu: Grid Column Selection and Copy Paste  "

    Private Sub ContextMenuStripColumns_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStripColumns.ItemClicked
        Dim chk As ToolStripMenuItem
        chk = e.ClickedItem
        If chk.Text = "-Apply Column Settings && Close-" Then
            Me.ContextMenuStripColumns.Close()
            LoadDataGrid()
            Exit Sub
        End If

        If chk.Checked = False Then
            chk.Checked = True
        Else
            chk.Checked = False
        End If
        Try
            My.Settings(e.ClickedItem.Name) = chk.Checked

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStripColumns_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuStripColumns.Opened
        Dim mnu As ContextMenuStrip = CType(sender, ContextMenuStrip)
        Dim col As DataGridViewColumn
        mnu.Items.Clear()
        Dim closeitm As New ToolStripMenuItem("-Apply Column Settings && Close-")
        closeitm.ForeColor = Color.Blue

        closeitm.Font = New Font(closeitm.Font.Name, closeitm.Font.Size, FontStyle.Bold)
        Me.ContextMenuStripColumns.Items.Add(closeitm)

        For Each col In Me.CommissionObjDataGridView.Columns
            With Me.ContextMenuStripColumns
                Dim chkitm As New ToolStripMenuItem(col.Name)
                If col.HeaderText > "" Then chkitm.Text = col.HeaderText
                chkitm.Name = col.Name
                Try
                    chkitm.Checked = My.Settings(col.Name)
                    .Items.Add(chkitm)
                Catch ex As Exception

                End Try
                Debug.Print(col.Name)
            End With
        Next

    End Sub

    Private Sub ToolStripMenuItemCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemCopy.Click
        strSelectedText = CommissionObjDataGridView.Item(intCol, intRow).Value
    End Sub

    Private Sub ToolStripMenuItemPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemPaste.Click
        CommissionObjDataGridView.Item(intCol, intRow).Value = strSelectedText
    End Sub

#End Region

#Region "   Tool Strip Buttons   "

    Private Sub ToolStripButtonGetCommisonData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonGetCommisonData.Click
        OpenComm.Show()

        With CommissionObjDataGridView
            Dim fnt As New FontFamily("Segoe UI")
            For Each col As DataGridViewColumn In .Columns
                col.CellTemplate.Style.Font = New Font("Segoe UI Semibold", 10, FontStyle.Regular)
            Next
        End With

    End Sub

    Private Sub ToolStripMenuItemOpenCommission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemOpenCommission.Click
        Dim frmOpen As New OpenComm
        frmOpen.Show()

    End Sub

    Private Sub ToolStripButtonExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonExcel.Click
        ExportToExcel()
    End Sub

    Private Sub ToolStripButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonClear.Click
        'Me.commlst.Clear()
        ClearGrid()

    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSaveAsDraft.Click
        Dim doSave As Boolean
        Dim dupOrderNo As Boolean
        Dim sShipDateList As String = ""
        Dim res As Integer
        Dim pdt As String
        Me.CommissionObjDataGridView.EndEdit()
        Me.Validate()

        If CommissionObjDataGridView.Rows.Count = 0 Then Exit Sub

        doSave = Me.ValidatePaymentDatesBeforeSave()
        If doSave = False Then
            pdt = Me.ToolStripStatusPaymentDate.Text

            res = MessageBox.Show("Incorrect Payment Dates." & vbCrLf & vbCrLf & "Payment Dates for each line must be " & pdt.Substring(4, 2) & "/" & pdt.Substring(6, 2) & "/" & pdt.Substring(0, 4) & ".  " & vbCrLf & vbCrLf & _
                            "To automatically fill in the Payment Dates, press Yes (you will still be able to edit the commission).  Press No to cancel.", "Save Failed: Payment Dates not all the same.", MessageBoxButtons.YesNo)
            If res = vbNo Then
                Exit Sub
            Else
                PopulatePaymentDatesBeforeSave()
                res = MsgBox("Payment Dates have been corrrected." & vbCrLf & vbCrLf & "Check for invalid or over 1 year old ShippedOn dates?", MsgBoxStyle.YesNo, "Payment Dates Corrected.")
                If res = vbNo Then
                    Exit Sub
                Else
                    sShipDateList = ValidateShippedOnDatesBeforeSave()
                    If sShipDateList = "" Then
                        res = MsgBox("ShippedOn Dates are all within 1 year.  Proceed to Save?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                        If res = vbNo Then Exit Sub
                    Else
                        res = MsgBox("These ShippedOn Dates may need correcting." & vbCrLf & vbCrLf & sShipDateList & vbCrLf & vbCrLf & " Save anyway?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                        If res = vbNo Then Exit Sub
                    End If
                End If
            End If
        Else
            res = MsgBox("Payment Dates Validated" & vbCrLf & vbCrLf & "Check for invalid or over 1 year old ShippedOn dates?", MsgBoxStyle.YesNo, "Payment Dates Corrected.")
            If res = vbNo Then
                Exit Sub
            Else
                sShipDateList = ValidateShippedOnDatesBeforeSave()
                If sShipDateList = "" Then
                    res = MsgBox("ShippedOn Dates are all within 1 year.  Proceed to Save?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                    If res = vbNo Then Exit Sub
                Else
                    res = MsgBox("These ShippedOn Dates may need correcting.  All are more than 1 year old." & vbCrLf & vbCrLf & sShipDateList & vbCrLf & vbCrLf & " Save anyway?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                    If res = vbNo Then Exit Sub
                End If
            End If
        End If
        dupOrderNo = Me.ValidateOrderNumbersOnGrid()
        If dupOrderNo = True Then
            Exit Sub
        End If
        Dim savefiledate As New SaveAs
        savefiledate.Show()
    End Sub

    Private Sub ToolStripMenuItemSaveFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSaveFinal.Click
        Dim FinalExists As Boolean = False
        Dim res As Integer
        Dim pdt As String
        Dim rd As SqlDataReader
        Dim type As String = "Final"
        Dim doSave As Boolean
        Dim sShipDateList
        Dim sUSorCAD As String = ""

        If CommissionObjDataGridView.Rows.Count = 0 Then Exit Sub

        doSave = Me.ValidatePaymentDatesBeforeSave()
        If doSave = False Then
            pdt = Me.ToolStripStatusPaymentDate.Text

            res = MessageBox.Show("Incorrect Payment Dates." & vbCrLf & vbCrLf & "Payment Dates for each order must be " & pdt.Substring(4, 2) & "/" & pdt.Substring(6, 2) & "/" & pdt.Substring(0, 4) & ".  " & vbCrLf & vbCrLf & _
                                  "To automatically fill in the Payment Dates, press Yes (you will still be able to edit the commission).  Press No to cancel.", "Save Failed: Payment Dates not all the same.", MessageBoxButtons.YesNo)
            If res = vbNo Then
                Exit Sub
            Else
                PopulatePaymentDatesBeforeSave()
                res = MsgBox("Payment Dates have been corrrected." & vbCrLf & vbCrLf & "Check for invalid or over 1 year old ShippedOn dates?", MsgBoxStyle.YesNo, "Payment Dates Corrected.")
                If res = vbNo Then
                    Exit Sub
                Else
                    sShipDateList = ValidateShippedOnDatesBeforeSave()
                    If sShipDateList = "" Then
                        res = MsgBox("ShippedOn Dates are all within 1 year.  Proceed to Save?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                        If res = vbNo Then Exit Sub
                    Else
                        res = MsgBox("These ShippedOn Dates may need correcting.  All are more than 1 year old." & vbCrLf & vbCrLf & sShipDateList & vbCrLf & vbCrLf & " Save anyway?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                        If res = vbNo Then Exit Sub
                    End If
                End If

            End If
        Else
            res = MsgBox("Payment Dates Validated" & vbCrLf & vbCrLf & "Check for invalid or over 1 year old ShippedOn dates?", MsgBoxStyle.YesNo, "Payment Dates Corrected.")
            If res = vbNo Then
                Exit Sub
            Else
                sShipDateList = ValidateShippedOnDatesBeforeSave()
                If sShipDateList = "" Then
                    res = MsgBox("ShippedOn Dates are all within 1 year.  Proceed to Save?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                    If res = vbNo Then Exit Sub
                Else
                    res = MsgBox("These ShippedOn Dates may need correcting.  All are more than 1 year old." & vbCrLf & vbCrLf & sShipDateList & vbCrLf & vbCrLf & " Save anyway?", MsgBoxStyle.YesNo, "ShippedOn Date Check")
                    If res = vbNo Then Exit Sub
                End If
            End If

        End If

        rd = BusObj.GetDraftCommissionHeaderList(type, bo.SearchPaymentDateDT, cn)
        If rd Is Nothing Then Exit Sub
        While rd.Read
            sUSorCAD = rd("comm_nam")

            If sUSorCAD.IndexOf("CAD") > 0 Then
                sUSorCAD = "CAD"
            Else
                sUSorCAD = "USA"
            End If

        End While
        If StatusLabelUSAorCAN.Text = sUSorCAD Then
            FinalExists = True
        Else
            FinalExists = False
        End If


        'FinalExists = rd.HasRows
        If FinalExists = True Then
            Me.AddedModified = "Modified"
            Me.CommDraftID_Delete = 1
        Else
            Me.AddedModified = "Added"
            Me.CommDraftID_Delete = 0
        End If
        rd.Close()
        If FinalExists = True Then
            ' MessageBox.Show("A final commission exists already.  Final commissions are read-only and cannot be overwritten.", "Existing Final Commission", MessageBoxButtons.OK)
            Dim frm As New SaveAsPassword
            frm.ButtonOpenPassword.Visible = True
            frm.ButtonSavePassword.Visible = False
            frm.ShowDialog()
            Dim savefinal As New SaveAs
            savefinal.Text = "Save Final Commission"
            savefinal.ButtonSave.Enabled = OverwriteFinal
            savefinal.Show()
        Else
            Dim savefinal As New SaveAs
            savefinal.Text = "Save Final Commission"
            savefinal.ButtonSave.Enabled = True
            savefinal.Show()

        End If
    End Sub

    Private Sub ToolStripButtonAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAddItem.Click

        Try
            commlst.AddNew()
            CommissionObjDataGridView.Rows(CommissionObjDataGridView.Rows.Count - 1).Selected = True
            CommissionObjBindingSource.MoveLast()
            Me.CommIDTextBox.Text = commlst(0).CommID
            Me.PaymentDateDateTimePicker.Value = commlst(0).PaymentDate
            Me.PaymentDateDateTimePicker.Text = commlst(0).PaymentDate

            commlst(commlst.Count - 1).PaymentDate = commlst(0).PaymentDate
            commlst(commlst.Count - 1).CommID = commlst(0).CommID
            commlst(commlst.Count - 1).AddedColumn = True
            Me.ButtonGetOrder.Enabled = True
            Me.btnOrderLookup.Enabled = True
        Catch ex As Exception

        End Try
        Me.CommissionObjBindingSource.EndEdit()
        Me.CommissionObjBindingSource.MoveFirst()
        Me.CommissionObjBindingSource.MoveLast()

    End Sub

    Private Sub ToolStripButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSearch.Click
        Search.Show()
    End Sub

    Private Sub ToolStripCompanyComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripCompanyComboBox.SelectedIndexChanged

        If startup = False Then
            Dim res As Integer
            res = MessageBox.Show("Would you like to open Company " & Me.ToolStripCompanyComboBox.Text & "?", "Open Company", MessageBoxButtons.YesNo)
            If res = 6 Then
                MacStartup(Me.ToolStripCompanyComboBox.Text)
                Me.StatusStrip1.Items("ToolStripStatusDatabase").Text = cn.Database
            Else
                Exit Sub
            End If
        End If

    End Sub

    Private Sub ToolStripButtonAddItem_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStripButtonAddItem.MouseUp

        With Me.OrderNoTextBox
            .Clear()
            .BackColor = Color.Yellow
            '.Focus()
        End With
    End Sub

    Private Sub ToolStripButtonCheckDupesOnGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCheckDupesOnGrid.Click
        If Me.commlst.Count = 0 Then
            Exit Sub
        End If
        ValidateOrderNumbersOnGrid()
        MsgBox("Grid duplicate check complete.", MsgBoxStyle.OkOnly, "Grid Duplicate Order Number Check")
        ValidateGridOrderNumbersAgainstTable()
        MsgBox("Database Final Commision table duplicate check complete.", MsgBoxStyle.OkOnly, "Database Final Duplicate Order Number Check")
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        ExportToExcel()
    End Sub

#End Region

#Region "   Utilities   "

    Private Function GetUSDateFormat(ByVal dt As String) As String
        Dim sqldt As New StringBuilder
        With sqldt
            .Append(dt.Substring(4, 2))
            .Append("/")
            .Append(dt.Substring(6, 2))
            .Append("/")
            .Append(dt.Substring(0, 4))
        End With
        Return sqldt.ToString
    End Function

    Private Sub UnselectDataGridViewRows(ByVal dgv As DataGridView)
        For Each rw As DataGridViewRow In dgv.Rows
            rw.Selected = False
        Next
    End Sub

    Private Sub NumericTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim txt As TextBox = DirectCast(sender, TextBox)
        If txt.Text = "" Then txt.Text = "0"
    End Sub

    Friend Sub SetModifiedRowBackground()
        Dim rw As Integer = 0

        For Each band As DataGridViewBand In Me.CommissionObjDataGridView.Rows
            If Me.CommissionObjDataGridView.Rows(band.Index).Cells("Modified").Value = sMultiplicationX Then
                band.DefaultCellStyle.BackColor = Color.Yellow
            Else
                band.DefaultCellStyle.BackColor = Color.White
            End If
        Next

    End Sub

    Private Function ValidatePaymentDatesBeforeSave() As Boolean
        Dim pdt As String = Me.ToolStripStatusPaymentDate.Text
        Dim rgx As New RegularExpressions.Regex(pdt)
        Dim pattern As String = "[a-zA-Z \s \:]"
        Dim pymtdt As String = System.Text.RegularExpressions.Regex.Replace(pdt, pattern, "")

        Dim dtPaymentDate As Date
        dtPaymentDate = pymtdt.Substring(4, 2) & "/" & pymtdt.Substring(6, 2) & "/" & pymtdt.Substring(0, 4)
        Dim doSave As Boolean = True
        Dim oCommDt As Date
        Dim oComm As CommissionObj
        For Each oComm In commlst
            oCommDt = oComm.PaymentDate
            If oCommDt <> dtPaymentDate Then
                doSave = False
                Return doSave
                Exit Function
            End If
        Next
        Return doSave
    End Function

    Private Function ValidateShippedOnDatesBeforeSave() As String
        Dim sShipDateList As String = ""
        Dim dtTodaysDate As Date = Now.Date.ToString("MM/dd/yyyy")
        Dim oShipDt As Date
        Dim oComm As CommissionObj
        For Each oComm In commlst
            oShipDt = oComm.ShipDate
            If Convert.ToDateTime(dtTodaysDate).Year - Convert.ToDateTime(oShipDt).Year >= 1 Then
                sShipDateList = sShipDateList & "Order# " & oComm.OrderNo & "  - - -  ShipDate " & oShipDt.ToString("MM/dd/yyyy") & "" & vbCrLf
            End If
        Next
        Return sShipDateList
    End Function

    Private Sub PopulatePaymentDatesBeforeSave()

        Dim pdt As String = Me.ToolStripStatusPaymentDate.Text
        Dim rgx As New RegularExpressions.Regex(pdt)
        Dim pattern As String = "[a-zA-Z \s \:]"
        Dim pymtdt As String = System.Text.RegularExpressions.Regex.Replace(pdt, pattern, "")

        Dim dtPaymentDate As Date
        dtPaymentDate = pymtdt.Substring(4, 2) & "/" & pymtdt.Substring(6, 2) & "/" & pymtdt.Substring(0, 4)

        Dim doSave As Boolean = True
        Dim oComm As CommissionObj
        For Each oComm In commlst

            oComm.PaymentDate = dtPaymentDate

        Next

        For Each rw As DataGridViewRow In CommissionObjDataGridView.Rows
            PaymentDateDateTimePicker.DataBindings("Value").ReadValue()
            PaymentDateDateTimePicker.Refresh()
            rw.Cells("PaymentDate").Value = dtPaymentDate
        Next

    End Sub

    Public Function ValidateOrderNumbersBeforeSave(ByVal Draftorfinal As String) As Boolean
        Dim co As CommissionObj
        Dim result As Boolean
        Dim rd As SqlDataReader
        'Dim CommOrdNo As Integer
        Dim i As Integer = 0
        Me.ValidateChildren()

        For Each co In commlst
            result = BusObj.GetScalarValue(co.OrderNo, ConvertDateToString(co.PaymentDate), Draftorfinal, cn)
            If result = True Then
                Dim sb As StringBuilder = New StringBuilder
                rd = BusObj.GetSQLDataReader(co.OrderNo, co.PaymentDate, cn)
                While rd.Read
                    With sb
                        .Append("This Order Number " & rd(26).ToString & " already exists on a Commission and cannot be saved twice.  " & vbCrLf & "Below is the information on the Order Number that already exists in the database" & vbCrLf & vbCrLf)
                        .Append("Rep Group: " & rd(1).ToString & vbCrLf)
                        .Append("Sales Person No: " & rd(2).ToString & vbCrLf)
                        .Append("Sales Person Name: " & rd(3).ToString & vbCrLf)
                        .Append("Invoice No: " & rd(4).ToString & vbCrLf)
                        .Append("Order No: " & rd(26).ToString & vbCrLf)
                        .Append("Customer No: " & rd(5).ToString & vbCrLf)
                        .Append("ShipTo Name: " & rd(6).ToString & vbCrLf)
                        .Append("Payment Date: " & rd(11).ToString & vbCrLf)
                        .Append("Commission Net: " & rd(18).ToString & vbCrLf)
                        .Append("Commission Paid: " & rd(21).ToString & vbCrLf & vbCrLf)
                        .Append("To Save the new commission, the duplicate order must be removed or order number changed/corrected.  " & vbCrLf & "Commission Payments on Order Numbers are only permitted once." & vbCrLf & "The Final Commission did not save.  Make corrections and try saving again")
                        MsgBox(sb.ToString, MsgBoxStyle.OkOnly, "Final Commission has duplicate order number")
                    End With
                End While
                rd.Close()
                rd = Nothing
                Return True

                Exit For
            End If
        Next
        Return False
        Me.ToolStripProgressBarCommRpt.Value = 0
    End Function

    Public Function ValidateGridOrderNumbersAgainstTable() As Boolean
        Dim result As Boolean
        Dim rd As SqlDataReader
        Dim co As CommissionObj
        'Dim oComm2 As CommissionObj
        'Dim oCommOrdNo As Integer
        'Dim i As Integer = 0
        'For Each oComm In commlst
        'oCommOrdNo = co.OrderNo

        'Dim i As Integer = 0
        Me.ValidateChildren()
        For Each co In commlst
            result = BusObj.GetScalarValue(co.OrderNo, ConvertDateToString(co.PaymentDate), cn)
            'result = BusObj.GetScalarValue(co.OrderNo, cn)
            If result = True Then
                Dim sb As StringBuilder = New StringBuilder
                rd = BusObj.GetSQLDataReader(co.OrderNo, co.PaymentDate, cn)
                'rd = BusObj.GetSQLDataReader(co.OrderNo, cn)
                While rd.Read
                    With sb
                        .Append("This Order Number " & rd(26).ToString & " already exists on a Commission and cannot be saved twice.  " & vbCrLf & "Below is the information on the Order Number that already exists in the database" & vbCrLf & vbCrLf)
                        .Append("Rep Group: " & rd(1).ToString & vbCrLf)
                        .Append("Sales Person No: " & rd(2).ToString & vbCrLf)
                        .Append("Sales Person Name: " & rd(3).ToString & vbCrLf)
                        .Append("Invoice No: " & rd(4).ToString & vbCrLf)
                        .Append("Order No: " & rd(26).ToString & vbCrLf)
                        .Append("Customer No: " & rd(5).ToString & vbCrLf)
                        .Append("ShipTo Name: " & rd(6).ToString & vbCrLf)
                        .Append("Payment Date: " & rd(11).ToString & vbCrLf)
                        .Append("Commission Net: " & rd(18).ToString & vbCrLf)
                        .Append("Commission Paid: " & rd(21).ToString & vbCrLf & vbCrLf)
                        .Append("To Save the new commission, the duplicate order must be removed or order number changed/corrected.  " & vbCrLf & "Commission Payments on Order Numbers are only permitted once." & vbCrLf & "The Final Commission did not save.  Make corrections and try saving again")
                        MsgBox(sb.ToString, MsgBoxStyle.OkOnly, "Final Commission has duplicate order number")
                    End With
                End While
                rd.Close()
                rd = Nothing
                Return True

                Exit For
            End If
        Next
        Return False
        Me.ToolStripProgressBarCommRpt.Value = 0
    End Function

    Private Function ConvertDateToString(ByVal dDate As Date) As String
        Dim sb As StringBuilder = New StringBuilder

        With sb
            .Append(dDate.Year.ToString)
            .Append("-")
            .Append(dDate.Month.ToString("0#"))
            .Append("-")
            .Append(dDate.Day.ToString("0#"))
        End With

        Return sb.ToString

    End Function

    Private Function ValidateOrderNumbersOnGrid() As Boolean
        Dim oComm As CommissionObj
        Dim oComm2 As CommissionObj
        Dim oCommOrdNo As Integer
        Dim i As Integer = 0
        For Each oComm In commlst
            oCommOrdNo = oComm.OrderNo
            For Each oComm2 In commlst
                If oCommOrdNo = oComm2.OrderNo Then
                    i = i + 1
                    If i = 2 Then
                        Dim sb As StringBuilder = New StringBuilder
                        With sb
                            .Append("A duplicate Order Number has been found in the grid." & vbCrLf & vbCrLf)
                            .Append("Dupelicate Order Number is:  " & oCommOrdNo.ToString & "." & vbCrLf & vbCrLf)
                            .Append("If you were saving, the save has been halted.  Remove or correct duplicate order number before continuing" & vbCrLf & vbCrLf)
                            .Append("Commission has not been saved")
                        End With
                        MsgBox(sb.ToString, MsgBoxStyle.OkOnly, "Duplicate Order Number Found")
                        Return True
                    End If

                End If
            Next
            i = 0

        Next
        Return False
    End Function

    Private Function ValidateDoneCheckedOnGrid(dgv As DataGridView) As String
        Dim sDoneNotChecked As String = ""
        For Each rw As DataGridViewRow In dgv.Rows
            If rw.Cells("ValidatedComm").Value = sMultiplicationX Then
                Continue For
            Else
                If sDoneNotChecked = "" Then
                    sDoneNotChecked = rw.Cells("OrderNo").Value & " - " & rw.Cells("ShipToName").Value
                Else
                    sDoneNotChecked = sDoneNotChecked & vbCrLf & rw.Cells("OrderNo").Value & " - " & rw.Cells("ShipToName").Value
                End If
            End If

        Next
        Return sDoneNotChecked
    End Function
#End Region

#End Region


    Private Sub CommissionObjDataGridView_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CommissionObjDataGridView.CellMouseEnter
        'Try
        '    rowToPaint = e.RowIndex
        '    bIsLoading = False
        '    Dim dgv As DataGridView = CType(sender, DataGridView)
        '    dgv.SuspendLayout()
        '    dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption
        '    dgv.ResumeLayout()
        '    'bIsLoading = True
        'Catch ex As Exception
        'End Try
    End Sub
    Private Sub CommissionObjDataGridView_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CommissionObjDataGridView.CellMouseLeave
        'Try
        '    rowToPaint = e.RowIndex
        '    bIsLoading = False
        '    Dim dgv As DataGridView = CType(sender, DataGridView)
        '    With dgv
        '        .SuspendLayout()
        '        If .Rows(e.RowIndex).Cells("Modified").Value = sMultiplicationX Then
        '            dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
        '        Else
        '            dgv.Rows(e.RowIndex).DefaultCellStyle.BackColor = SystemColors.Window
        '        End If
        '        .ResumeLayout()
        '    End With
        'Catch ex As Exception
        'End Try
        ''bIsLoading = True
    End Sub
    'Private Sub CommissionObjDataGridView_RowPrePaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles CommissionObjDataGridView.RowPrePaint
    '    'If bIsLoading = False Then
    '    '    If rowToPaint <> e.RowIndex Then
    '    '        e.Handled = True
    '    '    End If
    '    'End If
    '    ''e.Handled = True
    '    'bIsLoading = True
    'End Sub


    Private Sub CommissionObjDataGridView_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles CommissionObjDataGridView.ColumnHeaderMouseClick
        Dim dgv As DataGridView = CType(sender, DataGridView)
        Dim chk As Boolean
        Dim ichk As Integer
        Dim sXMark As String = ""
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ContextMenuStripColumns.Show(sender, New Point(e.X, e.Y))
            Me.ContextMenuStripColumns.Show(sender, New Point(e.X, e.Y))
        End If
        'If e.Button = Windows.Forms.MouseButtons.Left Then
        '    With dgv
        '        If e.ColumnIndex = 0 Then
        '            If dgv.Rows.Count = 0 Then Exit Sub 'check for empty datagrid, if so, exit...
        '            If .Rows(0).Cells(0).Value Is DBNull.Value Then chk = False Else chk = (.Rows(0).Cells("Selected").Value)
        '            ichk = IIf(chk = True, 0, 1)
        '            For Each rw As DataGridViewRow In dgv.Rows
        '                rw.Cells("Selected").Value = ichk
        '            Next
        '            dgv.RefreshEdit()
        '        End If
        '    End With

        'End If

        If e.Button = Windows.Forms.MouseButtons.Left Then
            UnselectDataGridViewRows(dgv)

            With dgv
                If dgv.Rows.Count = 0 Then Exit Sub 'check for empty datagrid, if so, exit...
                If e.ColumnIndex = 0 Then
                    If .Rows(0).Cells(0).Value Is DBNull.Value Then chk = False Else chk = (.Rows(1).Cells("Selected").Value)
                    ichk = IIf(chk = True, 0, 1)
                    For Each rw As DataGridViewRow In dgv.Rows
                        rw.Cells("Selected").Value = ichk
                    Next
                    'ElseIf e.ColumnIndex = 2 Then
                    '    If .Rows(0).Cells(2).Value Is DBNull.Value Then sXMark = "" Else sXMark = (.Rows(1).Cells("ValidatedComm").Value)
                    '    .Columns("ValidatedComm").SortMode = DataGridViewColumnSortMode.NotSortable
                    '    sXMark = IIf(sXMark = "", sMultiplicationX, "")
                    '    For Each rw As DataGridViewRow In dgv.Rows
                    '        rw.Cells("ValidatedComm").Value = sXMark
                    '    Next

                End If
                dgv.RefreshEdit()
            End With
        End If
    End Sub

    Private Sub CommissionObjDataGridView_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CommissionObjDataGridView.MouseClick

        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim hti As DataGridView.HitTestInfo = dgv.HitTest(e.X, e.Y)
        If hti.Type.ToString = "ColumnHeader" Then Exit Sub
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If hti.Type = DataGridViewHitTestType.RowHeader Then
                Me.ContextMenuStripCopyPasteData.Show(sender, New Point(e.X, e.Y))
                Me.ContextMenuStripCopyPasteData.Show(sender, New Point(e.X, e.Y))
            End If

        End If
    End Sub

    Private Sub CommissionObjDataGridView_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles CommissionObjDataGridView.CellMouseClick
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim hti As DataGridView.HitTestInfo = dgv.HitTest(e.X, e.Y)
        'Dim chk As Boolean
        Dim ichk As Integer

        If e.RowIndex = -1 Then
            'If hti.Type.ToString = "ColumnHeader" Then
            Me.ContextMenuStripCopyPasteData.Hide()
            Exit Sub
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.ContextMenuStripCopyPasteData.Show(sender, New Point(e.X, e.Y))
            Dim MousePosition As Point
            MousePosition = Cursor.Position
            Me.ContextMenuStripCopyPasteData.Show(MousePosition.X, MousePosition.Y)
            intRow = e.RowIndex
            intCol = e.ColumnIndex
        End If
        If e.Button = Windows.Forms.MouseButtons.Left And My.Computer.Keyboard.ShiftKeyDown = True Then
            With dgv
                If e.ColumnIndex = 0 Then
                    If dgv.Rows.Count = 0 Then Exit Sub 'check for empty datagrid, if so, exit...
                    Dim cellEnd As DataGridViewCell = dgv.CurrentCell
                    Dim cellStart As DataGridViewCell

                    'If .Rows(0).Cells(0).Value Is DBNull.Value Then chk = False Else chk = (.Rows(0).Cells("Selected").Value)
                    'ichk = IIf(chk = True, 1, 0)
                    For Each row As DataGridViewRow In dgv.Rows
                        If row.Cells("Selected").Selected = True Then
                            'If .Rows(0).Cells(0).Value Is DBNull.Value Then chk = False Else chk = (.Rows(0).Cells("Selected").Value)
                            'ichk = IIf(chk = True, 1, 0)
                            ichk = 1
                            cellStart = dgv.Rows(row.Index).Cells("Selected")
                            For i As Integer = cellStart.RowIndex To cellEnd.RowIndex
                                If row.Cells("Selected").Selected = True Then
                                    row.Cells("Selected").Value = ichk
                                    dgv.EndEdit()
                                End If
                            Next
                        End If


                    Next
                    dgv.RefreshEdit()
                ElseIf e.ColumnIndex = 2 Then
                    Dim iStartRow As Integer = Nothing
                    Dim iEndRow As Integer = e.RowIndex

                    For i As Integer = iEndRow To dgv.Rows.Count Step -1
                        If dgv.Rows(i).Cells("ValidatedComm").Value = True Then
                            iStartRow = i
                            Exit For
                        End If
                    Next

                    For i As Integer = iStartRow To iEndRow
                        dgv.Rows(i).Cells("Validatedcomm").Value = True
                        dgv.EndEdit()
                    Next


                    'iPreviousCheckedRow = iCurrentCheckedRow
                    'iCurrentCheckedRow = e.RowIndex ' dgv.Rows(e.RowIndex).Cells("ValidatedComm").Value

                    'If iStartValidatedRow = Nothing And My.Computer.Keyboard.ShiftKeyDown = True Then
                    '    iStartValidatedRow = e.RowIndex
                    '    Exit Sub
                    'ElseIf iStartValidatedRow <> Nothing And My.Computer.Keyboard.ShiftKeyDown = True Then
                    '    iEndValidatedRow = e.RowIndex
                    '    For Each row As DataGridViewRow In dgv.Rows
                    '        row.Cells("ValidatedComm").Value = True
                    '    Next
                    '    iStartValidatedRow = Nothing
                    '    iEndValidatedRow = Nothing
                    'End If
                    'For Each row As DataGridViewRow In dgv.Rows
                    '    If row.Cells("ValidatedComm").Selected = True Then
                    '        'If .Rows(0).Cells(0).Value Is DBNull.Value Then chk = False Else chk = (.Rows(0).Cells("Selected").Value)
                    '        'ichk = IIf(chk = True, 1, 0)
                    '        ichk = 1
                    '        cellStart = dgv.Rows(row.Index).Cells("ValidatedComm")
                    '        For i As Integer = cellStart.RowIndex To cellEnd.RowIndex
                    '            If row.Cells("Selected").Selected = True Then
                    '                row.Cells("Selected").Value = ichk
                    '                dgv.EndEdit()
                    '            End If
                    '        Next
                    '    End If


                    'Next

                End If
            End With
        ElseIf e.Button = Windows.Forms.MouseButtons.Left And My.Computer.Keyboard.CtrlKeyDown = True Then
            ichk = IIf(dgv.Rows(e.RowIndex).Cells("Selected").Value = 1, 0, 1)
            dgv.Rows(e.RowIndex).Cells("Selected").Value = ichk
        Else
            'ValidatedComm Cell Toggle X
            Try
                If e.ColumnIndex = 2 Then
                    Dim commobj As CommissionObj = CommissionObjBindingSource.Current
                    With dgv.Rows(e.RowIndex).Cells("ValidatedComm")
                        If .Value = "" Then
                            .Value = sMultiplicationX
                        Else
                            .Value = ""
                        End If
                    End With

                    dgv.EndEdit()
                    UnselectDataGridViewRows(dgv)
                End If
            Catch ex As Exception

            End Try

            'If e.ColumnIndex = 0 Then
            'Dim dgv As DataGridView = CType(sender, DataGridView)
            Try
                Dim row As DataGridViewRow = dgv.CurrentRow
                If dgv.Columns(e.ColumnIndex).Name <> "ValidatedComm" Then 'This is the 'Done' checkbox column
                    For Each rw As DataGridViewRow In dgv.Rows
                        rw.Cells("Selected").Value = 0
                    Next
                    row.Cells("Selected").Value = 1
                    'End If
                End If
            Catch ex As Exception

            End Try

        End If
        'UnselectDataGridViewRows(dgv)


        'If bIsLoading = True Then Exit Sub
        'If e.ColumnIndex = 0 And My.Computer.Keyboard.ShiftKeyDown = True Then Exit Sub

    End Sub

    Private Sub SetFinalOverwritePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetFinalOverwritePasswordToolStripMenuItem.Click
        Dim frm As New SaveAsPassword
        frm.ButtonSavePassword.Visible = True
        frm.ButtonOpenPassword.Visible = False
        frm.Show()
        frm.StartPosition = FormStartPosition.WindowsDefaultLocation
        frm.Focus()
    End Sub

    Private Sub ButtonGetOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetOrder.Click
        If Me.OrderNoTextBox.Text = "0" Or Me.OrderNoTextBox.Text = "" Then Exit Sub
        GetCommissionDataByOrder(Me.OrderNoTextBox.Text)
    End Sub

    Private Sub ButtonGetOrder_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGetOrder.MouseHover
        Me.ToolTipOrderNo.SetToolTip(Me.ButtonGetOrder, "Fill new row with Order# information")
    End Sub

    Private Sub CommissionObjDataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles CommissionObjDataGridView.RowEnter

        Me.OrderNoTextBox.BackColor = Color.White
        SetModifiedRowBackground()

    End Sub

    Private Sub OrderLookup()
        If Me.CommissionObjDataGridView.RowCount = 0 Or txtOrderNoSearch.Text = "" Then Exit Sub
        GetCommissionDataByOrder(txtOrderNoSearch.Text)
        RecalculateCommission()
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        Dim msg As String = "Are you sure you want to delete the current record? "

        If MessageBox.Show(msg, "Confirm Delete", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'Delete the Current Record
            'Me.CommissionObjBindingSource.RemoveCurrent()
            Dim currentrow As Integer = CInt(Me.CommissionObjBindingSource.Position)
            Try
                Me.CommissionObjBindingSource.RemoveAt(currentrow)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RepGroupTextBox.Leave, ShipToStateTextBox.Leave, _
                            ShipToNameTextBox.Leave, SalesPersonNumberTextBox.Leave, SalesPersonNameTextBox.Leave, CusNoTextBox.Leave, _
                            BillToStateTextBox.Leave, BatchIDTextBox.Layout, OrderNoTextBox.Layout, TotalSalesAmtTextBox.Leave, _
                            TextBox1.Leave, SS12TextBox.Leave, PickupAllowanceAmountTextBox.Leave, NetSalesAmountTextBox.Leave, _
                             InvoiceNumberTextBox.Leave, FreightPercentTextBox.Leave, _
                            DiscountAmountTextBox.Leave, CommissionPercentTextBox.Leave, CommissionAmountTextBox.Leave, _
                            CommIDTextBox.Leave, AmountPaidTextBox.Leave

        Dim txt As TextBox = DirectCast(sender, TextBox)
        If txt.Name = "" Then Exit Sub
        
        'CheckForModifications()
        Select Case txt.Name
            Case FreightPercentTextBox.Name, CommissionPercentTextBox.Name

            Case Else
                Me.SetModifiedRowBackground()
        End Select

    End Sub
    Private Sub CheckForModifications()
        If bIsLoading Then Exit Sub
        Dim rd As SqlDataReader

    End Sub
    Private Sub btnRecalculateCommission_Click(sender As Object, e As System.EventArgs) Handles btnRecalculateCommission.Click

        RecalculateCommission()

        'Empty the check boxes 
        Dim dgv As DataGridView = CType(Me.CommissionObjDataGridView, DataGridView)
        For Each row As DataGridViewRow In dgv.Rows
            row.Cells("Selected").Value = 0
        Next

        AmountPaidTextBox.DataBindings.Item("Text").ReadValue()
        FreightAmountTextBox.DataBindings.Item("Text").ReadValue()
        CommissionAmountTextBox.DataBindings.Item("Text").ReadValue()
        CommissionPercentTextBox.DataBindings.Item("Text").ReadValue()


    End Sub

    Private Sub RecalculateCommission()

        'HOW THE COMMISSION CALCULATION IS DONE
        '1.  .DiscountAmount.  This is deducted from Commlst(i).TotalSalesAmount to arrive at Comm_net (actual amt paid that commission is based on)  
        '2.  Commlst(i).NetSalesAmount (this is TotalSalesAmountTextBox on the Form) is the amount AFTER .FreightAmount and .DiscountAmount are taken out
        '3.  Commlst(i).TotalSalesAmount (this is NetSalesAmountTextBox on the Form) is the amount that .FreightPct and .CommisionPct is calculated against


        Dim FreightPct As Decimal = 0
        Dim AmountCommissionPaidOn As Decimal = 0
        Dim dMiscAmt As Decimal = 0
        Dim dPickupAllowanceAmt As Decimal = 0
       
        If PickupAllowanceAmountTextBox.Text = "" Then dPickupAllowanceAmt = 0 Else dPickupAllowanceAmt = Convert.ToDecimal(PickupAllowanceAmountTextBox.Text)

        FreightPct = Convert.ToDecimal(Me.FreightPercentTextBox.Text)
        'CommissionPct = Convert.ToDecimal(CommissionPercentTextBox.Text)

        With CommissionObjDataGridView
            For i As Integer = 0 To .Rows.Count - 1
                If Convert.ToBoolean(.Rows(i).Cells("Selected").Value) = True Then

                    With commlst(i)
                        AmountCommissionPaidOn = (Convert.ToDecimal(.TotalSalesAmt) + Convert.ToDecimal(.DiscountAmount)) / (1 + FreightPct)
                        .FreightPercent = FreightPct
                        ' = CommissionPct
                        .AmountPaid = AmountCommissionPaidOn
                        .CommissionAmount = AmountCommissionPaidOn * .CommissionPercent
                    End With

                End If
            Next
        End With

        SetModifiedRowBackground()
        CommissionObjDataGridView.RefreshEdit()
        CommissionObjDataGridView.Refresh()

    End Sub

    Private Sub ButtonTotalCommission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTotalCommission.Click
        TotalCommission()
    End Sub
    Private Sub TotalCommission()
        Dim CommNet As Decimal = CDec(Me.AmountPaidTextBox.Text)
        Dim CommPct As Decimal = CDec(Me.CommissionPercentTextBox.Text)
        'Me.CommissionAmountTextBox.Text = Format((CommNet * CommPct), "0.00").ToString
        'Me.CommissionAmountTextBox.DataBindings("Text").WriteValue()
        'Me.CommissionAmountTextBox.DataBindings("Text").ReadValue()
    End Sub
    Private Sub OrderNoTextBox_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles OrderNoTextBox.MouseClick
        Dim txt As TextBox = CType(sender, TextBox)
        txt.SelectAll()
    End Sub

    Private Sub btnOpenCommission_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenCommission.Click
        bIsLoading = True
        OpenComm.Show()
        With CommissionObjDataGridView
            Dim fnt As New FontFamily("Segoe UI")
            For Each col As DataGridViewColumn In .Columns
                col.CellTemplate.Style.Font = New Font("Segoe UI Semibold", 10, FontStyle.Regular)
            Next
        End With

    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        ClearGrid()
        Me.btnAddRow.Enabled = False
        Me.btnRemoveRow.Enabled = False
        Me.btnOrderLookup.Enabled = False
    End Sub

    Private Sub btnSaveAsDraft_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAsDraft.Click
        SaveAsDraft()
    End Sub

    Private Sub btnSaveAsFinal_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAsFinal.Click
        SaveAsFinal()
    End Sub

    Private Sub btnAddRow_Click(sender As System.Object, e As System.EventArgs) Handles btnAddRow.Click
        AddEmptyRow()
        With Me.txtOrderNoSearch
            .Enabled = True
            .Clear()
            .BackColor = Color.Yellow
            .Focus()
        End With
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveRow.Click
        RemoveRow()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles btnFind.Click
        Search.Show()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportToExcel()
    End Sub

#Region "   Properties   "

    Public Property CommissionType() As String
        Get
            Return mCommissionType
        End Get
        Set(ByVal value As String)
            mCommissionType = value
            Try
                If value = "Draft" Then
                    Me.ToolStripLabelCommissionType.Text = value & " (editable)"
                ElseIf value = "Final" Then
                    Me.ToolStripLabelCommissionType.Text = value & " (read-only)"
                Else
                    Me.ToolStripLabelCommissionType.Text = value
                End If

            Catch ex As Exception

            End Try

        End Set
    End Property

    Private mCommDraftID As Integer
    Public Property CommDraftID() As Integer
        Get
            Return mCommDraftID
        End Get
        Set(ByVal value As Integer)
            mCommDraftID = value
        End Set
    End Property

    Private mCommDraftID_Delete As Integer
    Public Property CommDraftID_Delete() As Integer
        Get
            Return mCommDraftID_Delete
        End Get
        Set(ByVal value As Integer)
            mCommDraftID_Delete = value
        End Set
    End Property

    Private mCommDraftName As String
    Public Property CommDraftName() As String
        Get
            Return mCommDraftName
        End Get
        Set(ByVal value As String)
            mCommDraftName = value
            Me.ToolStripStatusLabelCommDraftName.Text = value
        End Set
    End Property

    Private mPaymentDate As String
    Public Property PaymentDate_Status() As String
        Get
            Return mPaymentDate
        End Get
        Set(ByVal value As String)
            mPaymentDate = value
            Me.ToolStripStatusPaymentDate.Text = "  Payment Date: " & value
        End Set
    End Property

    Private mAddedModified As String
    Public Property AddedModified() As String
        Get
            Return mAddedModified
        End Get
        Set(ByVal value As String)
            mAddedModified = value
        End Set
    End Property


    Private mOverwriteFinal As Boolean
    Public Property OverwriteFinal() As Boolean
        Get
            Return mOverwriteFinal
        End Get
        Set(ByVal value As Boolean)
            mOverwriteFinal = value
        End Set
    End Property


    Private mstartup As Boolean
    Public Property startup() As Boolean
        Get
            Return mstartup
        End Get
        Set(ByVal value As Boolean)
            mstartup = value
        End Set
    End Property

    Private mRowAdded As String
    Public Property NewProperty() As String
        Get
            Return mRowAdded
        End Get
        Set(ByVal value As String)
            mRowAdded = value
        End Set
    End Property

#End Region

    Private Sub Panel2_MouseEnter(sender As Object, e As System.EventArgs) Handles Panel2.MouseEnter
        Dim sTip As String
        sTip = "Create an empty row by pressing +Row" & vbCrLf & _
                       "Enter an order number and press the Order" & vbCrLf & _
                       "button to populate the newly added empty row."
        Me.ToolTipOrderNo.SetToolTip(Me.Panel2, sTip)
    End Sub


    Private Sub Button_MouseEnter(sender As Object, e As System.EventArgs) Handles btnRecalculateCommission.MouseEnter, _
                                  btnOrderLookup.MouseEnter, btnOpenCommission.MouseEnter, btnRemoveRow.MouseEnter, _
                                  btnAddRow.MouseEnter, btnExportExcel.MouseEnter, btnFind.MouseEnter, btnSaveAsFinal.MouseEnter, _
                                  btnSaveAsDraft.MouseEnter, btnClear.MouseEnter
        Dim btn As Button = CType(sender, Button)
        Dim sTip As String = ""
        Select Case btn.Name
            Case Me.btnRecalculateCommission.Name
                sTip = "Press to re-calculate the commission amount"
            Case Me.btnOrderLookup.Name
                sTip = "Press to lookup an order number and populate an empty row.  You must first add an empty row with +Row to populate."
            Case Me.btnOpenCommission.Name
                sTip = "Opens the Open Commission dialog"
            Case Me.btnRemoveRow.Name
                sTip = "Removes the selected row"
            Case Me.btnAddRow.Name
                sTip = "Adds and emtpy row.  Use with Lookup Order Number to populate the row."
            Case Me.btnExportExcel.Name
                sTip = "Exports the contents of the grid to an Excel spreadsheet."
            Case Me.btnFind.Name
                sTip = "Populate the grid with criteria other than the Order Number."
            Case Me.btnSaveAsFinal.Name
                sTip = "Save the grid as a Final Commission"
            Case Me.btnSaveAsDraft.Name
                sTip = "Save the grid as a Draft Commission, any number of drafts can be saved and converted to a Final Commission later"
            Case Me.btnClear.Name
                sTip = "Clears the Grid"
            Case Me.btnDupeCheck.Name
                sTip = "Checks for duplicate order numbers in the grid."
        End Select

        Me.ToolTipOrderNo.SetToolTip(btn, sTip)
    End Sub

    Private Sub btnOrderLookup_Click(sender As System.Object, e As System.EventArgs) Handles btnOrderLookup.Click
        OrderLookup()
    End Sub

    
    Private Sub TextBox_Leave(sender As System.Object, e As System.Windows.Forms.LayoutEventArgs)

    End Sub

    Private Sub btnToggleValidatedComm_Click(sender As System.Object, e As System.EventArgs) Handles btnToggleValidatedComm.Click
        Dim dgv As DataGridView = CType(CommissionObjDataGridView, DataGridView)
        Dim sXMark As String

        With dgv
            If .Rows.Count = 0 Then Exit Sub
            If .Rows(0).Cells(2).Value Is DBNull.Value Then sXMark = "" Else sXMark = (.Rows(1).Cells("ValidatedComm").Value)
            .Columns("ValidatedComm").SortMode = DataGridViewColumnSortMode.NotSortable
            sXMark = IIf(sXMark = "", sMultiplicationX, "")
            For Each rw As DataGridViewRow In dgv.Rows
                rw.Cells("ValidatedComm").Value = sXMark
            Next
            .Columns("ValidatedComm").SortMode = DataGridViewColumnSortMode.Automatic
        End With
    End Sub
End Class
