Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Public Class SaveAs
    Private draftcommobj As DraftCommissionHdrObj
    Private draftcommlst As DraftCommissionHdrList
    'Private finalmodi As DraftCommissionHdrObj
    Private DraftOrFinal As String
    'Dim FinalExists As Boolean = False
    Private DES As TripleDES

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        If Me.TextBoxFileName.Text = "" Then
            MessageBox.Show("Must enter a file name before saving.", "File Name Required", MessageBoxButtons.OK)
            Exit Sub
        End If

        Dim res As Boolean = True
        CommissionRpt.CommDraftID_Delete = 0
        CommissionRpt.CommDraftName = ""
        CommissionRpt.PaymentDate_Status = CommissionRpt.bo.SearchPaymentDate
        'Validate the ordernumbers, no duplicates allowed.  If duplicates, end.  
        If DraftOrFinal = "Final" Then
            res = CommissionRpt.ValidateOrderNumbersBeforeSave(DraftOrFinal)
            If res = True Then
                MsgBox("Dulicate Order Numbers Found in Save.  Duplicate must be removed before proceeding.", MsgBoxStyle.OkOnly, "Duplicate Order Number Found")
                Exit Sub
            End If
        End If
        If DraftOrFinal = "Draft" Then
            CommissionRpt.AddedModified = "Added"
            res = ValidateDraftName()
        ElseIf DraftOrFinal = "Final" Then
            res = ValidateDraftName()
        End If

        If res = False Then Exit Sub

        CommissionRpt.draftName = Me.TextBoxFileName.Text
        CommissionRpt.SaveDraftHeader(CommID_Delete, CommissionRpt.draftName, DraftOrFinal)

        LoadGrid(DraftOrFinal)

        Me.ButtonCancel.Text = "Close"
        MessageBox.Show("Done", "Save Commision List", MessageBoxButtons.OK)

    End Sub
    Private Function ValidateDraftName() As Boolean
        Dim drftobj As DraftCommissionHdrObj
        Dim result As Integer
        If DraftOrFinal = "Draft" Then
            For Each drftobj In draftcommlst
                If drftobj.DraftName = Me.TextBoxFileName.Text Then
                    result = (MessageBox.Show("Overwrite existing draft,  " & Me.TextBoxFileName.Text & "?", "Overwrite Draft Commission", MessageBoxButtons.YesNo))
                    If result = 6 Then
                        CommissionRpt.AddedModified = "Modified"
                        CommID_Delete = CommissionRpt.GetCommissionID(Me.TextBoxFileName.Text, DraftOrFinal)
                        'CommissionRpt.CommDraftID_Delete = Me.SavedCommFileDateObjDataGridView(0, Me.SavedCommFileDateObjDataGridView.CurrentRow.Index).Value
                        Return True
                    Else
                        Return False
                        Exit Function
                    End If
                Else
                    'Return True
                End If
            Next
        ElseIf DraftOrFinal = "Final" And CommissionRpt.AddedModified = "Modified" Then
            For Each drftobj In draftcommlst
                If drftobj.DraftName = Me.TextBoxFileName.Text Then
                    result = (MessageBox.Show("Overwrite existing Final Commission,  " & Me.TextBoxFileName.Text & "?", "Overwrite Final Commission", MessageBoxButtons.YesNo))
                    If result = 6 Then
                        CommissionRpt.AddedModified = "Modified"
                        CommID_Delete = CommissionRpt.GetCommissionID(Me.TextBoxFileName.Text, DraftOrFinal)
                        Return True
                    Else
                        Return False
                        Exit Function
                    End If
                Else
                    'Return True
                End If
            Next
        End If
        Return True
    End Function

    Private Sub SaveAs_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CommissionRpt.OverwriteFinal = False
    End Sub

   
    Private Sub SaveAs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Text = "Save Final Commission" Then
            DraftOrFinal = "Final"
            If CommissionRpt.StatusLabelUSAorCAN.Text = "USA" Then
                Me.picUSAorCAN.Image = My.Resources.USFlag4
                Me.lblUSAorCAN.Text = "USA"
            Else
                Me.picUSAorCAN.Image = My.Resources.CAFlag4
                Me.lblUSAorCAN.Text = "CAD"
            End If

            'DES = New TripleDES
        Else
            DraftOrFinal = "Draft"
            If CommissionRpt.StatusLabelUSAorCAN.Text = "USA" Then
                Me.picUSAorCAN.Image = My.Resources.USFlag4
                Me.lblUSAorCAN.Text = "USA"
            Else
                Me.picUSAorCAN.Image = My.Resources.CAFlag4
                Me.lblUSAorCAN.Text = "CAD"
            End If
        End If
        LoadGrid(DraftOrFinal)
        'If FinalExists = True Then
        '    ' MessageBox.Show("A final commission exists already.  Final commissions are read-only and cannot be overwritten.", "Existing Final Commission", MessageBoxButtons.OK)
        '    Dim frm As New SaveAsPassword
        '    frm.ButtonOpenPassword.Visible = True
        '    frm.ButtonSavePassword.Visible = False
        '    frm.ShowDialog()

        '    frm.Focus()
        'End If


    End Sub
    Private Sub LoadGrid(ByVal drftorfnl As String)
        Dim rd As SqlDataReader
        If drftorfnl = "Final" Then
            Me.Label1.Text = "Final Commission Name"
            Me.Label3.Text = "Existing Final Commission"
            'GridSetup()
            Me.TextBoxFileName.Text = CommissionRpt.bo.SearchPaymentDate & "_FinalCommission" & "_" & Me.lblUSAorCAN.Text
        Else
            drftorfnl = "Draft"
        End If
        rd = BusObj.GetDraftCommissionHeaderList(drftorfnl, CommissionRpt.bo.SearchPaymentDateDT, cn)

        'If drftorfnl = "Final" Then FinalExists = rd.HasRows

        draftcommlst = BusObj.PopulateDraftCommissionHdrList(rd)
        Me.SavedCommFileDateObjBindingSource.DataSource = draftcommlst
        Me.TextBoxPaymentDate.Text = CommissionRpt.bo.SearchPaymentDateDT.ToString("MM/dd/yyyy")
        If drftorfnl = "Final" Then
            Me.TextBoxFileName.ReadOnly = True
            Me.ButtonAddPaymentDatePrefix.Visible = False
            Me.Label4.Visible = False
            'If draftcommlst.Count > 0 Then
            '    Me.ButtonSave.Enabled = False
            'End If
        End If
        GridSetup()
    End Sub
    Private Sub GridSetup()
        Dim col As DataGridViewColumn
        With Me.SavedCommFileDateObjDataGridView
            For Each col In .Columns
                Select Case col.Name
                    Case "DraftID"
                        If DraftOrFinal = "Final" Then
                            col.HeaderText = "Comm ID"
                        Else
                            col.HeaderText = "Draft ID"
                        End If
                        col.Visible = False
                    Case "DraftName"
                        If DraftOrFinal = "Final" Then
                            col.HeaderText = "Comm Name"
                        Else
                            col.HeaderText = "Draft Name"
                        End If
                        col.Visible = True
                    Case "PaymentDate"
                        col.Visible = True
                    Case "UserDate"
                        col.Visible = True
                    Case Else
                        col.Visible = False
                End Select
            Next
        End With
    End Sub
    Private Sub ButtonAddPaymentDatePrefix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddPaymentDatePrefix.Click
        Me.TextBoxFileName.Text = CommissionRpt.bo.SearchPaymentDate & "_" & Me.lblUSAorCAN.Text & "_"
        Me.TextBoxFileName.Focus()
        Me.TextBoxFileName.SelectionStart = Me.TextBoxFileName.Text.Length
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub SavedCommFileDateObjDataGridView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SavedCommFileDateObjDataGridView.RowEnter
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        'If e.Button = Windows.Forms.MouseButtons.Left Then
        'Me.TextBoxFileName.Text = Me.SavedCommFileDateObjDataGridView(1, e.RowIndex).Value
        'End If
        'Me.SavedCommFileDateObjDataGridView.CurrentRow.Index
    End Sub

    Private Sub SavedCommFileDateObjDataGridView_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles SavedCommFileDateObjDataGridView.RowHeaderMouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.TextBoxFileName.Text = Me.SavedCommFileDateObjDataGridView(1, Me.SavedCommFileDateObjDataGridView.CurrentRow.Index).Value
        End If
    End Sub
    Private mCommID_Delete As Integer
    Public Property CommID_Delete() As Integer
        Get
            Return mCommID_Delete
        End Get
        Set(ByVal value As Integer)
            mCommID_Delete = value
        End Set
    End Property


    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class