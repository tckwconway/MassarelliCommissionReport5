Imports System.ComponentModel
Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System
Public Class CommissionSavedObj
    Inherits CommissionObj
    'Implements INotifyPropertyChanged
    'Implements IEditableObject\
    Private mDraftName As String
    Public Property DraftName() As String
        Get
            Return mDraftName
        End Get
        Set(ByVal value As String)
            mDraftName = value
        End Set
    End Property
End Class
