Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.FontStyle
Imports System.Drawing.Font
Imports System.Linq


Public Class OpenComm

    Private DraftOrFinal As String
    Private draftcommobj As DraftCommissionHdrObj
    Private draftcommlst As DraftCommissionHdrList
    Private finalcommobj As DraftCommissionHdrObj
    Private finalcommlst As DraftCommissionHdrList
    Private bo As BusObj
    Private pymtdate As String
    Private pymtYYYYMMDD As String
    Private isLoading As Boolean = True
    Const sCheckMark1 As Char = ChrW(&H2611)  'Check with box
    Const sCheckMark2 As Char = ChrW(&H2713)  'Light check mark
    Const sCheckMark3 As Char = ChrW(&H2714)  'Heavy check mark
    Const sGlyphDown As Char = ChrW(&H25BC) 'Glyph (down pointing triangle)
    Const sGlyphUp As Char = ChrW(&H25B2) 'Glyph (up pointing triangle)
    Const sElipsis As Char = ChrW(&H2026) 'Elipsis Horizontal
    Const sArrowTriangleLeft As Char = ChrW(&H25C0) 'Triangle Arrow Pointing Left
    Const sArrowTriangleRight As Char = ChrW(&H25B6) 'Triangle Arrow Pointing Left
    Private Sub GridSetup()
        Dim ctl As Control
        Dim col As DataGridViewColumn
        Dim dgv As DataGridView
        For Each ctl In Me.GroupBox1.Controls
            If (TypeOf ctl Is DataGridView) Then
                dgv = ctl
                With dgv
                    For Each col In .Columns
                        Select Case col.Name
                            Case "DraftID", "FinalID"
                                'If dgv.Name = "DataGridViewFinalCommission" Then
                                '    col.HeaderText = "Comm ID"
                                'Else
                                '    col.HeaderText = "Draft ID"
                                'End If
                                col.HeaderText = IIf(col.Name = "DraftID", "Draft ID", "Final ID")
                                col.Visible = True

                            Case "DraftName", "FinalName"
                                'If dgv.Name = "DataGridViewFinalCommission" Then
                                '    col.HeaderText = "Comm Name"
                                'Else
                                '    col.HeaderText = "Draft Name"
                                'End If
                                col.HeaderText = IIf(col.Name = "DraftName", "Draft Name", "Final Name")
                                col.Visible = True
                            Case "DraftPaymentDate", "FinalPaymentDate"
                                col.HeaderText = "Payment Date"
                                col.Visible = True
                            Case "DraftUserDate", "FinalUserDate"
                                col.HeaderText = "Create Date"
                                col.Visible = True
                            Case "SelectedFinal", "SelectedDraft"
                                col.HeaderText = sCheckMark3
                                col.Visible = True
                                col.Width = 30
                                col.DisplayIndex = 0
                            Case Else
                                col.Visible = False
                        End Select
                    Next
                End With
            End If
        Next
    End Sub

    Private Sub OpenComm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bo = CommissionRpt.bo
        GridSetup()
        'Me.TextBoxPaymentDate.Focus()
        Me.TextBoxPaymentDate.Select()
        Me.USAorCAN = Trim(optUSA.Text)
        isLoading = False
        lblCommisionsExistNotice.Text = ""
    End Sub

    Private Sub LoadGrid()
        Dim bnew As Boolean = True
        bo.SearchPaymentDate = Me.TextBoxPaymentDate.Text
        Dim rd As SqlDataReader
        Dim drftorfnl As String = "Final"
        rd = BusObj.GetDraftCommissionHeaderList(drftorfnl, bo.SearchPaymentDateDT, cn)
        Dim bfinal As Boolean = rd.HasRows
        finalcommlst = BusObj.PopulateDraftCommissionHdrList(rd)
        Me.BindingSourceFinalCommission.DataSource = finalcommlst


        drftorfnl = "Draft"
        rd = BusObj.GetDraftCommissionHeaderList(drftorfnl, CommissionRpt.bo.SearchPaymentDateDT, cn)
        Dim bdraft As Boolean = rd.HasRows
        draftcommlst = BusObj.PopulateDraftCommissionHdrList(rd)
        Me.BindingSourceDraftCommission.DataSource = draftcommlst

        Me.RadioButtonDraftCommission.Enabled = bdraft
        Me.RadioButtonFinalCommission.Enabled = bfinal
        'If finalcommlst.Count + draftcommlst.Count > 0 Then bnew = False
        Me.RadioButtonNewCommission.Checked = bnew

        Dim cell As DataGridViewCell
        For Each cell In Me.DataGridViewDraftCommission.SelectedCells
            cell.Selected = False
        Next
        For Each cell In Me.DataGridViewFinalCommission.SelectedCells
            cell.Selected = False
        Next


    End Sub



    Private Sub ButtonFillGrids_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFillGrids.Click
        LoadGrid()
        Me.RadioButtonNewCommission.Enabled = True
        Me.ButtonOpenCommission.Enabled = True
    End Sub

    Private Sub TextBoxPaymentDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxPaymentDate.KeyDown
        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim txtlen As Integer = txt.Text.Length
        If e.KeyCode = Keys.Enter Then
            If txtlen = 8 Then
                Me.TextBoxPaymentDate.BackColor = Color.FromKnownColor(KnownColor.ButtonFace)
                Me.Cursor = Cursors.WaitCursor
            End If
        End If
    End Sub

    Private Sub TextBoxPaymentDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxPaymentDate.KeyUp
        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim txtlen As Integer = txt.Text.Length
        If e.KeyCode = Keys.Enter Then
            If txtlen = 8 Then
                pymtdate = ValidateText(txt.Text)
                If IsDate(pymtdate) = True Then
                    OpenCommission()
                End If
            End If

        End If
        Me.Cursor = Cursors.Default
        Me.TextBoxPaymentDate.BackColor = Color.FromKnownColor(KnownColor.White)
    End Sub

    Private Sub TextBoxPaymentDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxPaymentDate.TextChanged
        Dim txt As TextBox = CType(sender, TextBox)
        Dim txtlen As Integer = txt.Text.Length
        Me.TextBoxCommDraftName.Clear()
        pymtYYYYMMDD = txt.Text
        If txtlen = 8 Then
            pymtdate = ValidateText(txt.Text)
            If IsDate(pymtdate) = True Then
                CommissionRpt.PaymentDateDateTimePicker.Enabled = True
                Me.RadioButtonNewCommission.Enabled = True
                Me.ButtonOpenCommission.Enabled = True

                LoadGrid()
            Else
                Me.RadioButtonNewCommission.Enabled = False
                Me.RadioButtonDraftCommission.Enabled = False
                Me.RadioButtonFinalCommission.Enabled = False
                Me.ButtonOpenCommission.Enabled = False
                MessageBox.Show("Not a valid date", "Invalid Date", MessageBoxButtons.OK)
            End If
        Else
            Me.RadioButtonNewCommission.Enabled = False
            Me.RadioButtonDraftCommission.Enabled = False
            Me.RadioButtonFinalCommission.Enabled = False
            Me.ButtonOpenCommission.Enabled = False
        End If
        If Me.DataGridViewFinalCommission.Rows.Count > 0 Then
            Dim sNotice As String = "Select a Commission from the list" & vbCrLf & "                  - OR - " & vbCrLf & "Choose Open New Commission"

            With Me.optExistingCommission
                .Enabled = True
                .Checked = True
            End With
            lblCommisionsExistNotice.Text = sNotice

        End If
    End Sub

    Private Function ValidateText(ByVal dt As String) As String
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

    Private Sub ButtonOpenCommission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpenCommission.Click
        OpenCommission()
    End Sub
    Private Sub OpenCommission()
        Me.Cursor = Cursors.WaitCursor

        CommissionRpt.ClearGrid()

        If Me.RadioButtonNewCommission.Checked = True Then
            CommissionRpt.GetCommissionData(CInt(pymtYYYYMMDD), Me.USAorCAN, 0, 0)
            CommissionRpt.PaymentDate_Status = ""
            CommissionRpt.CommissionType = "New commission"
            CommissionRpt.CommDraftName = ""

        ElseIf Me.RadioButtonDraftCommission.Checked = True Then
            If Me.CommDraftID Is Nothing Then
                MsgBox("Select an existing Commission or open a new one.", MsgBoxStyle.OkOnly, "Commission Not Selected")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            CommissionRpt.GetCommissionData(CInt(pymtYYYYMMDD), Me.USAorCAN, CInt(Me.CommDraftID), 1)
            CommissionRpt.PaymentDate_Status = pymtdate
            CommissionRpt.CommissionType = "Draft"
            CommissionRpt.CommDraftName = "Draft Name: " & CommDraftName
            ElseIf Me.RadioButtonFinalCommission.Checked = True Then
                If Me.CommDraftID Is Nothing Then
                MsgBox("Select an existing Commission or open a new one.", MsgBoxStyle.OkOnly, "Commission Not Selected")
                Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                CommissionRpt.GetCommissionData(CInt(pymtYYYYMMDD), Me.USAorCAN, CInt(Me.CommDraftID), 2)
                CommissionRpt.PaymentDate_Status = pymtdate
                CommissionRpt.CommissionType = "Final"
                CommissionRpt.CommDraftName = "Final Commission Name: " & CommDraftName
            End If
            CommissionRpt.SetModifiedRowBackground()
            If Me.USAorCAN = "USA" Then
                CommissionRpt.StatusLabelUSAorCAN.Image = My.Resources.USFlag4
            Else
                CommissionRpt.StatusLabelUSAorCAN.Image = My.Resources.CAFlag4
            End If
            CommissionRpt.StatusLabelUSAorCAN.Text = USAorCAN
            CommissionRpt.ToolStripStatusPaymentDate.Text = pymtYYYYMMDD

            Me.Cursor = Cursors.Default
            Me.Close()

    End Sub
    Private Sub RadioButtonNewCommission_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonNewCommission.CheckedChanged
        Dim rb As RadioButton = DirectCast(sender, RadioButton)
        Dim fntbld As New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold)
        Dim fntreg As New Font("Microsoft Sans Serif", 8.5, FontStyle.Regular)

        With rb
            If .Checked = True Then
                .Font = fntbld
                .BackColor = Color.FromKnownColor(KnownColor.ScrollBar)
                If rb.Name = "RadioButtonNewCommission" Then
                    Me.TextBoxCommDraftName.Enabled = False
                End If
            Else
                .Font = fntreg
                .BackColor = Color.FromKnownColor(KnownColor.ButtonFace)
                If rb.Name = "RadioButtonNewCommission" Then
                    Me.TextBoxCommDraftName.Enabled = True
                End If
            End If

        End With
        Select Case rb.Name
            Case RadioButtonNewCommission.Name
                lblDraftCommission.Text = ""
                lblFinalCommission.Text = ""
            Case optExistingCommission.Name

        End Select

    End Sub


    Private mCommDraftID As String
    Public Property CommDraftID() As String
        Get
            Return mCommDraftID
        End Get
        Set(ByVal value As String)
            mCommDraftID = value
        End Set
    End Property

    Private mCommDraftName As String
    Public Property CommDraftName() As String
        Get
            Return mCommDraftName
        End Get
        Set(ByVal value As String)
            mCommDraftName = value
        End Set
    End Property

    Private mUSAorCAN As String
    Public Property USAorCAN() As String
        Get
            Return mUSAorCAN
        End Get
        Set(ByVal value As String)
            mUSAorCAN = value
        End Set
    End Property

    Private Sub DataGridViewDraftCommission_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
                                                           Handles DataGridViewDraftCommission.CellMouseClick, DataGridViewFinalCommission.CellMouseClick
        Dim dgv As DataGridView = CType(sender, DataGridView)

        CommDraftID = dgv(dgv.Columns(0).Index, e.RowIndex).Value
        CommDraftName = dgv(dgv.Columns(1).Index, e.RowIndex).Value
        If InStr(CommDraftName, "USA", CompareMethod.Text) > 0 Then
            USAorCAN = "USA"
            'lblFinalCommission.Text = ""
            'lblDraftCommission.Text = CommDraftName
            optUSA.Checked = True
        Else
            USAorCAN = "CAD"
            'lblDraftCommission.Text = ""
            'lblFinalCommission.Text = CommDraftName
            optCanada.Checked = True
        End If

        If dgv.Name = Me.DataGridViewDraftCommission.Name Then
            lblFinalCommission.Text = ""
            lblDraftCommission.Text = CommDraftName
        Else
            lblDraftCommission.Text = ""
            lblFinalCommission.Text = CommDraftName
        End If
        lblCommisionsExistNotice.Text = ""
        Me.optExistingCommission.Checked = True
    End Sub

    Private Sub DataGridViewDraftCommission_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewDraftCommission.Leave, DataGridViewFinalCommission.Leave
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        dgv.ClearSelection()
    End Sub

    Private CheckColIndex As Integer = 0
    Private Sub DataGridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
                                               Handles DataGridViewDraftCommission.CellValueChanged, DataGridViewFinalCommission.CellValueChanged
        If Not isLoading Then
            'Check the column index and if the check box is checked.
            Dim dgv As DataGridView = CType(sender, DataGridView)
            Dim col As DataGridViewColumn = dgv.Columns(e.ColumnIndex) ' the checkbox column may not be at columnIndex 0, so make sure 
            CheckColIndex = col.Index


            If e.ColumnIndex = CheckColIndex Then
                Dim isChecked As Boolean = CType(dgv(e.ColumnIndex, e.RowIndex).Value, Boolean)
                If isChecked Then
                    'If check box is checked, uncheck all the rows, the current row would be checked later.
                    For Each row As DataGridViewRow In dgv.Rows
                        row.Cells(e.ColumnIndex).Value = False
                    Next
                End If
            End If

            If InStr(CommDraftName, "USA", CompareMethod.Text) > 0 Then
                USAorCAN = "USA"
                'lblFinalCommission.Text = ""
                'lblDraftCommission.Text = CommDraftName
                optUSA.Checked = True
            Else
                USAorCAN = "CAD"
                'lblDraftCommission.Text = ""
                'lblFinalCommission.Text = CommDraftName
                optCanada.Checked = True
            End If

        End If

    End Sub


    Private Sub DataGridViewDraftCommission_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewDraftCommission.RowEnter, DataGridViewFinalCommission.RowEnter
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
     
        If dgv.Name = "DataGridViewDraftCommission" Then
            Me.RadioButtonDraftCommission.Checked = True
        ElseIf dgv.Name = "DataGridViewFinalCommission" Then
            Me.RadioButtonFinalCommission.Checked = True
        End If

    End Sub


    Private Sub DataGridViewDraftCommission_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridViewDraftCommission.RowHeaderMouseDoubleClick, DataGridViewFinalCommission.RowHeaderMouseDoubleClick
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        CommDraftID = dgv(dgv.Columns(0).Index, e.RowIndex).Value

    End Sub

    Private Sub DataGridViewDraftCommission_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridViewDraftCommission.RowHeaderMouseClick, DataGridViewFinalCommission.RowHeaderMouseClick
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        CommDraftID = dgv(dgv.Columns(0).Index, e.RowIndex).Value
        CommDraftName = dgv(dgv.Columns(1).Index, e.RowIndex).Value
        Me.TextBoxCommDraftName.Text = CommDraftName
        If dgv.Name = "DataGridViewDraftCommission" Then
            Me.RadioButtonDraftCommission.Checked = True
        ElseIf dgv.Name = "DataGridViewFinalCommission" Then
            Me.RadioButtonFinalCommission.Checked = True
        End If
    End Sub

    Private Sub optUSA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUSA.CheckedChanged, optCanada.CheckedChanged
        Dim opt As RadioButton = DirectCast(sender, RadioButton)
        Me.USAorCAN = Trim(opt.Text)
    End Sub

    Private Sub DataGridViewFinalCommission_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewFinalCommission.CellContentClick
        pymtYYYYMMDD = TextBoxPaymentDate.Text
        OpenCommission()
    End Sub
End Class