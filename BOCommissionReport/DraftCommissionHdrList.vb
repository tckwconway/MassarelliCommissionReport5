Imports System.Collections.Generic
Imports System.Collections
Imports System.ComponentModel

Public Class DraftCommissionHdrList
    Inherits BindingListView(Of DraftCommissionHdrObj)
    Protected Overrides Function AddNewCore() As Object

        'Dim savedcomm As SavedCommFileDateObj = CommissionSavedObj.NewCommissionSavedObj _
        '("", "", "", "", 0, "", "", "", #1/1/1900#, #1/1/1900#, #1/1/1900#, _
        '0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, "", 0, "")
        'comm.SetParentSaved(Me)
        'Add(comm)
        'Return comm

    End Function
End Class
