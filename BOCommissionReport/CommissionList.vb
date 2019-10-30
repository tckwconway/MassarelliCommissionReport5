Imports System.Collections.Generic
Imports System.Collections
Imports System.ComponentModel
Public Class CommissionList
    'NOTE: BindingListView is sortable with the BindingListView Class and SortComparer
    '      BindingList is NOT sortable, you must Inherit BindingListView
    Inherits BindingListView(Of CommissionObj)
    Protected Overrides Function AddNewCore() As Object

        Dim comm As CommissionObj = CommissionObj.NewCommissionObj _
        ("", "", "", 0, "", "", "", #1/1/1900#, #1/1/1900#, #1/1/1900#, _
        0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, "", 0, "", 0, 0, 0, 0)
        comm.SetParent(Me)
        Add(comm)
        Return comm

    End Function
End Class
