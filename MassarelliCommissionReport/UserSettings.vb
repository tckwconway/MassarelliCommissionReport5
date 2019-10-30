
Imports System.Drawing
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Environment
Imports System.Collections.Specialized
Imports System.Xml.Serialization
Public NotInheritable Class UserSettings
    Inherits System.Configuration.ApplicationSettingsBase

#Region "   Methods   "
    Public Sub New()

    End Sub
    Public Sub New(ByVal ColRepGroup As Boolean, ByVal ColSalesPersonNumber As Boolean, ByVal ColSalesPersonName As Boolean, _
                   ByVal ColInvoiceNumber As Boolean, ByVal ColShipToName As Boolean, ByVal ColShipToState As Boolean, _
                   ByVal ColBillToState As Boolean, ByVal ColOrderDate As Boolean, ByVal ColShipDate As Boolean, _
                   ByVal ColPaymentDate As Boolean, ByVal ColFreightAmount As Boolean, ByVal ColFreightPercent As Boolean, _
                   ByVal ColNetSalesAmount As Boolean, ByVal ColDiscountAmount As Boolean, ByVal ColPickupAllowanceAmount As Boolean, _
                   ByVal ColAmountPaid As Boolean, ByVal ColCommissionPercent As Boolean, ByVal ColSS12 As Boolean, _
                   ByVal ColCommissionAmount As Boolean, ByVal ColReference As Boolean, ByVal ColCommID As Boolean, _
                   ByVal ColCusNo As Boolean, ByVal ColCusNo_Stripped As Boolean, ByVal ColTotalSalesAmt As Boolean, _
                   ByVal ColBatchID As Boolean, ByVal ColBatchID_Stripped As Boolean)

        mColRepGroup = ColRepGroup
        mColSalesPersonNumber = ColSalesPersonNumber
        mColSalesPersonName = ColSalesPersonName
        mColInvoiceNumber = ColInvoiceNumber
        mColShipToName = ColShipToName
        mColShipToState = ColShipToState
        mColBillToState = ColBillToState
        mColOrderDate = ColOrderDate
        mColShipDate = ColShipDate
        mColPaymentDate = ColPaymentDate
        mColFreightAmount = ColFreightAmount
        mColFreightPercent = ColFreightPercent
        mColNetSalesAmount = ColNetSalesAmount
        mColDiscountAmount = ColDiscountAmount
        mColPickupAllowanceAmount = ColPickupAllowanceAmount
        mColAmountPaid = ColAmountPaid
        mColCommissionPercent = ColCommissionPercent
        mColSS12 = ColSS12
        mColCommissionAmount = ColCommissionAmount
        mColReference = ColReference
        mColCommID = ColCommID
        mColCusNo = ColCusNo
        mColCusNo_Stripped = ColCusNo_Stripped
        mColTotalSalesAmt = ColTotalSalesAmt
        mColBatchID = ColBatchID
        mColBatchID_Stripped = ColBatchID_Stripped
    End Sub
#End Region
#Region "   Properties   "

    Public Property FormSize() As System.Drawing.Size
        Get
            Return CType(Me("FormSize"), System.Drawing.Size)
        End Get
        Set(ByVal value As System.Drawing.Size)
            Me("FormSize") = value
        End Set
    End Property

    Private mColRepGroup As Boolean
    Public Property ColRepGroup() As Boolean
        Get
            Return CType(Me("RepGroup"), Boolean)
        End Get
        Set(ByVal value As Boolean)
            Me("RepGroup") = value
            'mColRepGroup = Trim(value)
        End Set
    End Property

    Private mColSalesPersonNumber As Boolean
    Public Property ColSalesPersonNumber() As Boolean
        Get
            Return mColSalesPersonNumber
        End Get
        Set(ByVal value As Boolean)
            mColSalesPersonNumber = Trim(value)
        End Set
    End Property

    Private mColSalesPersonName As Boolean
    Public Property ColSalesPersonName() As Boolean
        Get
            Return mColSalesPersonName
        End Get
        Set(ByVal value As Boolean)
            mColSalesPersonName = Trim(value)
        End Set
    End Property

    Private mColInvoiceNumber As Boolean
    Public Property ColInvoiceNumber() As Boolean
        Get
            Return mColInvoiceNumber
        End Get
        Set(ByVal value As Boolean)
            mColInvoiceNumber = value
        End Set
    End Property

    Private mColShipToName As Boolean
    Public Property ColShipToName() As Boolean
        Get
            Return mColShipToName
        End Get
        Set(ByVal value As Boolean)
            mColShipToName = Trim(value)
        End Set
    End Property

    Private mColShipToState As Boolean
    Public Property ColShipToState() As Boolean
        Get
            Return mColShipToState
        End Get
        Set(ByVal value As Boolean)
            mColShipToState = Trim(value)
        End Set
    End Property

    Private mColBillToState As Boolean
    Public Property ColBillToState() As Boolean
        Get
            Return mColBillToState
        End Get
        Set(ByVal value As Boolean)
            mColBillToState = Trim(value)
        End Set
    End Property

    Private mColOrderDate As Boolean
    Public Property ColOrderDate() As Boolean
        Get
            Return mColOrderDate
        End Get
        Set(ByVal value As Boolean)
            mColOrderDate = value
        End Set
    End Property

    Private mColShipDate As Boolean
    Public Property ColShipDate() As Boolean
        Get
            Return mColShipDate
        End Get
        Set(ByVal value As Boolean)
            mColShipDate = value
        End Set
    End Property

    Private mColPaymentDate As Boolean
    Public Property ColPaymentDate() As Boolean
        Get
            Return mColPaymentDate
        End Get
        Set(ByVal value As Boolean)
            mColPaymentDate = value
        End Set
    End Property

    Private mColFreightAmount As Boolean
    Public Property ColFreightAmount() As Boolean
        Get
            Return mColFreightAmount
        End Get
        Set(ByVal value As Boolean)
            mColFreightAmount = value
        End Set
    End Property

    Private mColFreightPercent As Boolean
    Public Property ColFreightPercent() As Boolean
        Get
            Return mColFreightPercent
        End Get
        Set(ByVal value As Boolean)
            mColFreightPercent = value
        End Set
    End Property

    Private mColNetSalesAmount As Boolean
    Public Property ColNetSalesAmount() As Boolean
        Get
            Return mColNetSalesAmount
        End Get
        Set(ByVal value As Boolean)
            mColNetSalesAmount = value
        End Set
    End Property

    Private mColDiscountAmount As Boolean
    Public Property ColDiscountAmount() As Boolean
        Get
            Return mColDiscountAmount
        End Get
        Set(ByVal value As Boolean)
            mColDiscountAmount = value
        End Set
    End Property

    Private mColPickupAllowanceAmount As Boolean
    Public Property ColPickupAllowanceAmount() As Boolean
        Get
            Return mColPickupAllowanceAmount
        End Get
        Set(ByVal value As Boolean)
            mColPickupAllowanceAmount = value
        End Set
    End Property

    Private mColAmountPaid As Boolean
    Public Property ColAmountPaid() As Boolean
        Get
            Return mColAmountPaid
        End Get
        Set(ByVal value As Boolean)
            mColAmountPaid = value
        End Set
    End Property

    Private mColCommissionPercent As Boolean
    Public Property ColCommissionPercent() As Boolean
        Get
            Return mColCommissionPercent
        End Get
        Set(ByVal value As Boolean)
            mColCommissionPercent = value
        End Set
    End Property

    Private mColSS12 As Boolean
    Public Property ColSS12() As Boolean
        Get
            Return mColSS12
        End Get
        Set(ByVal value As Boolean)
            mColSS12 = value
        End Set
    End Property

    Private mColCommissionAmount As Boolean
    Public Property ColCommissionAmount() As Boolean
        Get
            Return mColCommissionAmount
        End Get
        Set(ByVal value As Boolean)
            mColCommissionAmount = value
        End Set
    End Property

    Private mColReference As Boolean
    Public Property ColReference() As Boolean
        Get
            Return mColReference
        End Get
        Set(ByVal value As Boolean)
            mColReference = Trim(value)
        End Set
    End Property


    Private mColCommID As Boolean
    Public Property ColCommID() As Boolean
        Get
            Return mColCommID
        End Get
        Set(ByVal value As Boolean)
            mColCommID = value
        End Set
    End Property

    Private mColCusNo As Boolean
    Public Property ColCusNo() As Boolean
        Get
            Return mColCusNo
        End Get
        Set(ByVal value As Boolean)
            mColCusNo = value
            Try
                ColCusNo_Stripped = CInt(ColCusNo)
            Catch ex As Exception

            End Try

        End Set
    End Property

    Private mColCusNo_Stripped As Boolean
    Public Property ColCusNo_Stripped() As Boolean
        Get
            Return mColCusNo_Stripped
        End Get
        Set(ByVal value As Boolean)
            mColCusNo_Stripped = value
        End Set
    End Property

    Private mColTotalSalesAmt As Boolean
    Public Property ColTotalSalesAmt() As Boolean
        Get
            Return mColTotalSalesAmt
        End Get
        Set(ByVal value As Boolean)
            mColTotalSalesAmt = value
        End Set
    End Property

    Private mColBatchID As Boolean
    Public Property ColBatchID() As Boolean
        Get
            Return mColBatchID
        End Get
        Set(ByVal value As Boolean)
            mColBatchID = value
            Try
                ColBatchID_Stripped = CInt(ColBatchID)
            Catch ex As Exception

            End Try

        End Set
    End Property

    Private mColBatchID_Stripped As Boolean
    Public Property ColBatchID_Stripped() As Boolean
        Get
            Return mColBatchID_Stripped
        End Get
        Set(ByVal value As Boolean)
            mColBatchID_Stripped = value
        End Set
    End Property
#End Region

End Class
