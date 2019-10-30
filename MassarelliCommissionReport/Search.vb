Imports System.String
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class Search
    Dim sAnd As String = ""
    Private Function BuildWhere() As String
        Dim rep As New StringBuilder
        Dim repgrp As New StringBuilder
        Dim shipto As New StringBuilder
        Dim cust As New StringBuilder
        Dim ord As New StringBuilder
        Dim inv As New StringBuilder
        Dim pymtdt As New StringBuilder
        Dim where As New StringBuilder
        Dim sWhere As String = ""

        'Rep Number
        'get count of reps selected
        Dim repcount As Integer = Me.ListViewRep2.Items.Count

        If repcount = 1 Then
            sWhere = " Where "
            rep.Append(sWhere)
            rep.Append(" slspsn_number = '" & Me.ListViewRep2.Items(0).Text & "' ")
        ElseIf repcount > 1 Then
            sWhere = " Where "
            Dim lvi As New ListViewItem
            Dim iItms As Integer = 0
            rep.Append(sWhere)
            rep.Append(" slspsn_number in (")
            For Each lvi In Me.ListViewRep2.Items
                iItms = iItms + 1
                rep.Append("'" & lvi.Text & "'")
                If iItms = repcount Then Exit For
                rep.Append(",")
            Next
            rep.Append(")")
        Else
            rep.Append("")
        End If

        'Rep Group
        'get count of rep_group selected
        Dim repgrpcount As Integer = Me.ListViewRepGroup2.Items.Count
        If repgrpcount = 1 Then
            If sWhere.Length = 0 Then
                sWhere = " Where "
                repgrp.Append(sWhere)
            End If
            Dim _itm As String = Me.ListViewRepGroup2.Items(0).Text.Trim
            _itm = _itm.Replace("'", "''")
            repgrp.Append(" rep_group = '" & _itm & "' ")
        ElseIf repgrpcount > 1 Then
            If sWhere.Length = 0 Then
                sWhere = " Where "
                repgrp.Append(sWhere)
            End If
            Dim lvi As New ListViewItem
            Dim iItms As Integer = 0
            repgrp.Append(" rep_group in (")
            For Each lvi In Me.ListViewRepGroup2.Items
                iItms = iItms + 1
                Dim _itm As String = lvi.Text.Trim
                _itm = _itm.Replace("'", "''")
                repgrp.Append("'" & _itm & "'")
                If iItms = repgrpcount Then Exit For
                repgrp.Append(",")
            Next
            repgrp.Append(")")
        Else
            repgrp.Append("")
        End If

        'payment date 
        Dim datecount As Integer = 0
        If Me.DateTimePickerFrom.Text.Trim.Length + Me.DateTimePickerTo.Text.Trim.Length = 0 Then
            datecount = 0
        ElseIf Me.DateTimePickerTo.Text.Trim.Length = 0 Then
            datecount = 1
        Else
            datecount = 2
        End If

        If datecount = 0 Then
            pymtdt.Append("")
        ElseIf datecount = 1 Then
            If sWhere.Length = 0 Then
                sWhere = " Where "
                pymtdt.Append(sWhere)
            End If
            pymtdt.Append(" ARCOMFHDR_MAZ.pymt_dt = '")
            pymtdt.Append(Me.DateTimePickerFrom.Value.Year.ToString)
            pymtdt.Append("-")
            pymtdt.Append(Me.DateTimePickerFrom.Value.Month.ToString("0#"))
            pymtdt.Append("-")
            pymtdt.Append(Me.DateTimePickerFrom.Value.Day.ToString("0#"))
            pymtdt.Append("' ")
        Else
            If sWhere.Length = 0 Then
                sWhere = " Where "
                pymtdt.Append(sWhere)
            End If
            pymtdt.Append(" ARCOMFHDR_MAZ.pymt_dt between '")
            pymtdt.Append(Me.DateTimePickerFrom.Value.Year.ToString)
            pymtdt.Append("-")
            pymtdt.Append(Me.DateTimePickerFrom.Value.Month.ToString("0#"))
            pymtdt.Append("-")
            pymtdt.Append(Me.DateTimePickerFrom.Value.Day.ToString("0#"))
            pymtdt.Append("' ")
            pymtdt.Append(" and '")
            pymtdt.Append(Me.DateTimePickerTo.Value.Year.ToString)
            pymtdt.Append("-")
            pymtdt.Append(Me.DateTimePickerTo.Value.Month.ToString("0#"))
            pymtdt.Append("-")
            pymtdt.Append(Me.DateTimePickerTo.Value.Day.ToString("0#"))
            pymtdt.Append("' ")
        End If

        If Me.TextBoxShipToNo.Text.Length = 0 Then
            shipto.Append("")
        Else
            If sWhere.Length = 0 Then
                sWhere = " Where "
                shipto.Append(sWhere)
            End If
            Dim _shipto As String = Me.TextBoxShipToNo.Text.Replace("'", "''")
            shipto.Append(" ship_to_name = '" & _shipto & "' ")
        End If

        If Me.TextBoxCustomerNo.Text.Length = 0 Then
            cust.Append("")
        Else
            If sWhere.Length = 0 Then
                sWhere = " Where "
                cust.Append(sWhere)
            End If
            cust.Append(" cus_no = '" & Me.Labelcust.Text & "' ")
        End If

        If Me.TextBoxInvoiceNo.Text.Length = 0 Then
            inv.Append("")
        Else
            If sWhere.Length = 0 Then
                sWhere = " Where "
                inv.Append(sWhere)
            End If
            inv.Append(" inv_no = '" & Me.TextBoxInvoiceNo.Text & "' ")
        End If

        With where
            .Append(rep.ToString)
            sAnd = WhereAddTo(where.ToString)
            If repgrp.ToString.Length > 0 Then .Append(sAnd)
            .Append(repgrp.ToString)
            sAnd = WhereAddTo(where.ToString)
            If pymtdt.ToString.Length > 0 Then .Append(sAnd)
            .Append(pymtdt.ToString)
            sAnd = WhereAddTo(where.ToString)
            If shipto.ToString.Length > 0 Then .Append(sAnd)
            .Append(shipto.ToString)
            sAnd = WhereAddTo(where.ToString)
            If cust.ToString.Length > 0 Then .Append(sAnd)
            .Append(cust.ToString)
            sAnd = WhereAddTo(where.ToString)
            If inv.ToString.Length > 0 Then .Append(sAnd)
            .Append(inv.ToString)
        End With
        Return where.ToString
    End Function

    Private Sub GetSearch(ByVal where As String)
        CommissionRpt.GetSearchData(where)
        Me.Close()
    End Sub
    Private Function WhereAddTo(ByVal where As String) As String
        Dim sAnd As String = ""
        If where.StartsWith(" Where ") Then
            sAnd = " and "
        Else
            sAnd = ""
        End If
        Return sAnd
    End Function
    Private Sub Search_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.DateTimePickerFrom.CustomFormat = " "
        Me.DateTimePickerTo.CustomFormat = " "

        FillListBoxes()
    End Sub
    Private Sub FillListBoxes()
        Dim sSQL As String
        'Fill Rep No 
        sSQL = "Select slspsn_no from arslmfil_sql Where Sls_last_yr > 0 and (CharIndex('LAST ', slspsn_name ) = 0 AND CharIndex('LAST SALE', slspsn_name ) = 0 AND CharIndex('RETIRED', slspsn_name ) = 0)"
        Me.FillListView(Me.ListViewRep1, "Rep #", sSQL)
        'Fill Rep Group
        sSQL = "Select Distinct user_def_fld_1 from arslmfil_sql Where Sls_last_yr > 0 and (CharIndex('LAST ', slspsn_name ) = 0 AND CharIndex('LAST SALE', slspsn_name ) = 0 AND CharIndex('RETIRED', slspsn_name ) = 0) and user_def_fld_1 is not null"
        Me.FillListView(Me.ListViewRepGroup1, "Rep Grp", sSQL)
        'Fill ShipToName
        sSQL = "Select Distinct ship_to_name from OEHDRHST_SQL " & _
               "where Cast(Left(Cast(entered_dt as varchar(8)),4) + '-' + Substring(Cast(entered_dt as varchar(8)), 5, 2) + '-' +  Substring(Cast(entered_dt as varchar(8)),7, 2) as Datetime) " & _
               " > (Select DateAdd(day, -730, getdate())) Order by ship_to_name "
    End Sub

    Private Function GetList(ByVal sSql As String) As SqlDataReader

        Dim rd As SqlDataReader
        'Get Rep List
        rd = BusObj.GetList(sSql, cn)
        Return rd
    End Function
    Private Sub FillListView(ByVal lv As ListView, ByVal colHeader As String, ByVal sSql As String)
        Dim rd As SqlDataReader = Me.GetList(sSql)

        lv.View = View.Details
        lv.Columns.Add(New ColumnHeader)
        lv.Columns(0).Text = colHeader
        lv.Columns(0).Width = 200


        While rd.Read
            Dim itm As New ListViewItem(New String() {rd.GetString(0)})
            lv.Items.Add(itm)
        End While
        rd.Close()
        rd = Nothing

    End Sub

    Private Sub LVDragDrop(ByVal LV As ListView, ByVal DragText() As String)
        'Retrieve the data in the string array format.
        Dim myText() As String = DragText
        Dim i As Integer
        For i = 0 To myText.Length - 1
            'Add the dragged items to the ListView control.
            LV.Items.Add(myText(i))
        Next
    End Sub

    Private Sub LVItemDrag(ByVal LV1 As ListView, ByVal LV2 As ListView)
        Dim myItem As ListViewItem
        'Create an array of strings. 
        Dim myItems(LV1.SelectedItems.Count - 1) As String
        Dim i As Integer = 0
        'Loop though the SelectedItems collection of the ListView control.
        For Each myItem In LV1.SelectedItems
            'Add the Text of the ListViewItem to the array. 
            myItems(i) = myItem.Text
            i = i + 1
        Next
        'DoDragDrop begins the drag-and-drop operation.
        'The data to be dragged is the array of strings.
        LV1.DoDragDrop(myItems, DragDropEffects.Move)
        Dim j As ListViewItem
        Dim k As ListViewItem

        For Each j In LV1.SelectedItems
            For Each k In LV2.Items
                If k.ToString = j.ToString Then
                    LV1.Items.Remove(j)
                End If
            Next
        Next
    End Sub
    Private Sub LVKeyUp(ByVal LV1 As ListView, ByVal LV2 As ListView, ByVal LVKeyCode As Integer)
        Dim myItem As ListViewItem
        Dim myItems(LV1.SelectedItems.Count - 1) As String
        Dim i As Integer = 0

        If LVKeyCode = Keys.Delete Then
            For Each myItem In LV1.SelectedItems
                LV1.Items.Remove(myItem)
                LV2.Items.Add(myItem.Text)
            Next
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonResetForm.Click
        Me.Panel1.Height = 154
        Me.Panel2.Height = 88
        Me.Panel3.Height = 163
        Me.Panel4.Height = 176
        Me.Height = 701
        Me.Width = 508
    End Sub

    Private Sub ListViewRepGroup1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListViewRepGroup1.DragDrop
        Me.LVDragDrop(Me.ListViewRepGroup1, e.Data.GetData("System.String[]"))
    End Sub

    Private Sub ListViewRepGroup1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles ListViewRepGroup1.ItemDrag
        Me.LVItemDrag(Me.ListViewRepGroup1, Me.ListViewRepGroup2)
    End Sub

    Private Sub ListViewRep1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListViewRep1.DragDrop
        Me.LVDragDrop(Me.ListViewRep1, e.Data.GetData("System.String[]"))
    End Sub

    Private Sub ListViewRep1_DragEnter1(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListViewRep1.DragEnter, ListViewRepGroup2.DragEnter, ListViewRepGroup1.DragEnter, ListViewRep2.DragEnter
        'Check for the DataFormat string array.
        If e.Data.GetDataPresent("System.String[]") Then
            'If the data stored is a string array,
            'set the Effect of drag-and-drop operation to Move.
            e.Effect = DragDropEffects.Move
        Else
            'Else set the Effect of drag-and-drop operation to None.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListViewRep1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles ListViewRep1.ItemDrag
        Me.LVItemDrag(Me.ListViewRep1, Me.ListViewRep2)
    End Sub

    Private Sub ListViewRep2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListViewRep2.DragDrop
        LVDragDrop(ListViewRep2, e.Data.GetData("System.String[]"))
    End Sub

    Private Sub ListViewRep2_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles ListViewRep2.ItemDrag
        Me.LVItemDrag(Me.ListViewRep2, Me.ListViewRep1)
    End Sub

    Private Sub ListViewRep2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListViewRep2.KeyUp
        Me.LVKeyUp(Me.ListViewRep2, Me.ListViewRep1, e.KeyCode)
    End Sub

    Private Sub ListViewRepGroup2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListViewRepGroup2.DragDrop
        Me.LVDragDrop(ListViewRepGroup2, e.Data.GetData("System.String[]"))
    End Sub

    Private Sub ListViewRepGroup2_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles ListViewRepGroup2.ItemDrag
        Me.LVItemDrag(Me.ListViewRepGroup2, Me.ListViewRepGroup1)
    End Sub

    Private Sub ListViewRepGroup2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListViewRepGroup2.KeyUp
        Me.LVKeyUp(Me.ListViewRepGroup2, Me.ListViewRepGroup1, e.KeyCode)
    End Sub

    Private Sub DateTimePickerFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerFrom.ValueChanged, DateTimePickerTo.ValueChanged
        Dim dtp As DateTimePicker = DirectCast(sender, DateTimePicker)
        dtp.CustomFormat = "MM/dd/yyyy"
    End Sub

    Private Sub ButtonDelete1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete1.Click
        Me.DateTimePickerFrom.CustomFormat = " "
        Me.DateTimePickerFrom.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub ButtonDelete2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete2.Click
        Me.DateTimePickerTo.CustomFormat = " "
        Me.DateTimePickerTo.Format = DateTimePickerFormat.Custom
    End Sub

    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        Dim where As String
        where = BuildWhere()
        Me.GetSearch(where)
    End Sub

    Private Sub TextBoxCustomerNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxCustomerNo.TextChanged
        Dim cust As String = ("000000000000" & TextBoxCustomerNo.Text)
        Labelcust.Text = cust.Substring(cust.Length - 12)
    End Sub

 
    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        Clear()
    End Sub
    Private Sub Clear()
        Me.TextBoxCustomerNo.Text = ""
        Me.Labelcust.Text = ""
        Me.TextBoxInvoiceNo.Text = ""
        Me.TextBoxShipToNo.Text = ""
        Me.ListViewRep2.Clear()
        Me.ListViewRep1.Clear()
        Me.ListViewRepGroup2.Clear()
        Me.ListViewRepGroup1.Clear()
        Me.DateTimePickerFrom.CustomFormat = " "
        Me.DateTimePickerTo.CustomFormat = " "
        FillListBoxes()
    End Sub


    Private Sub ButtonSalesGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalesGroup.Click
        Dim j As ListViewItem

        For Each j In Me.ListViewRepGroup1.SelectedItems
            
            ListViewRepGroup1.Items.Remove(j)
            ListViewRepGroup2.Items.Add(j)

        Next
    End Sub

    Private Sub ButtonSalesRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSalesRep.Click
        Dim j As ListViewItem

        For Each j In Me.ListViewRep1.SelectedItems
           
            ListViewRep1.Items.Remove(j)
            ListViewRep2.Items.Add(j)
        Next
    End Sub


End Class