Imports System.ComponentModel
Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System
Public Class DraftCommissionHdrObj
    Inherits CommissionSavedObj

    Private mDraftID As Integer
    Public Property DraftID() As Integer
        Get
            Return mDraftID
        End Get
        Set(ByVal value As Integer)
            mDraftID = value
        End Set
    End Property

    Private mUserDate As Date
    Public Property UserDate() As Date
        Get
            Return mUserDate
        End Get
        Set(ByVal value As Date)
            mUserDate = value
        End Set
    End Property

End Class
