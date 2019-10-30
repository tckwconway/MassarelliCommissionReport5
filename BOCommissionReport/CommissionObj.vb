Imports System.ComponentModel
Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System
Public Class CommissionObj
    Implements INotifyPropertyChanged
    Implements IEditableObject
    Const sHeavyMultiplicationX As Char = ChrW(&H2716) 'Heavy multiplication x
    Const sMultiplicationX As Char = ChrW(&H2715) 'Heavy multiplication x

    Public Enum EntityStateEnum
        Unchanged
        Added
        Deleted
        Modified
    End Enum
#Region "   Methods   "

    Public Shared Function NewCommissionObj(ByVal RepGroup As String, ByVal SalesPersonNumber As String, ByVal SalesPersonName As String, _
    ByVal InvoiceNumber As Integer, ByVal ShipToName As String, ByVal ShipToState As String, ByVal BillToState As String, ByVal OrderDate As Date, _
    ByVal ShipDate As Date, ByVal PaymentDate As Date, ByVal FreightAmount As String, ByVal FreightPercent As String, ByVal NetSalesAmount As String, _
    ByVal DiscountAmount As String, ByVal PickupAllowanceAmount As String, ByVal AmountPaid As String, ByVal CommissionPercent As String, _
    ByVal SS12 As String, ByVal CommissionAmount As String, ByVal Reference As String, ByVal CommID As Integer, ByVal CusNo As String, _
    ByVal TotalSalesAmt As String, ByVal BatchID As String, ByVal MiscAmt As String, ByVal OrderNumber As Integer, ByVal Modified As Integer, _
    ByVal ValidComm As Integer) As CommissionObj

        Dim comm As New CommissionObj
        comm.RepGroup = RepGroup
        comm.SalesPersonNumber = SalesPersonNumber
        comm.SalesPersonName = SalesPersonName
        comm.InvoiceNumber = InvoiceNumber
        comm.ShipToName = ShipToName
        comm.ShipToState = ShipToState
        comm.BillToState = BillToState
        comm.OrderDate = OrderDate
        comm.ShipDate = ShipDate
        comm.PaymentDate = PaymentDate
        comm.FreightAmount = FreightAmount
        comm.FreightPercent = FreightPercent
        comm.NetSalesAmount = NetSalesAmount
        comm.DiscountAmount = DiscountAmount
        comm.PickupAllowanceAmount = PickupAllowanceAmount
        comm.AmountPaid = AmountPaid
        comm.CommissionPercent = CommissionPercent
        comm.SS12 = SS12
        comm.CommissionAmount = CommissionAmount
        comm.Reference = Reference
        comm.CommID = CommID
        comm.CusNo = CusNo
        comm.TotalSalesAmt = TotalSalesAmt
        comm.BatchID = BatchID
        comm.MiscAmt = MiscAmt
        comm.OrderNo = OrderNumber
        comm.Modified = IIf(Modified = 0, "", sMultiplicationX)
        comm.ValidatedComm = IIf(ValidComm = 0, "", sMultiplicationX)

        Return comm

    End Function

    Public Shared Function GetCommissionObj(ByVal RepGroup As String, ByVal SalesPersonNumber As String, ByVal SalesPersonName As String, _
        ByVal InvoiceNumber As Integer, ByVal ShipToName As String, ByVal ShipToState As String, ByVal BillToState As String, ByVal OrderDate As Date, _
        ByVal ShipDate As Date, ByVal PaymentDate As Date, ByVal FreightAmount As String, ByVal FreightPercent As String, ByVal NetSalesAmount As String, _
        ByVal DiscountAmount As String, ByVal PickupAllowanceAmount As String, ByVal AmountPaid As String, ByVal CommissionPercent As String, _
        ByVal SS12 As String, ByVal CommissionAmount As String, ByVal Reference As String, ByVal CommID As Integer, ByVal CusNo As String, _
        ByVal TotalSalesAmt As String, ByVal BatchID As String, ByVal MiscAmt As String, ByVal OrderNumber As Integer, ByVal Modified As Integer, _
        ByVal ValidComm As Integer) As CommissionObj

        Dim comm As New CommissionObj
        comm.RepGroup = RepGroup
        comm.SalesPersonNumber = SalesPersonNumber
        comm.SalesPersonName = SalesPersonName
        comm.InvoiceNumber = InvoiceNumber
        comm.ShipToName = ShipToName
        comm.ShipToState = ShipToState
        comm.BillToState = BillToState
        comm.OrderDate = OrderDate
        comm.ShipDate = ShipDate
        comm.PaymentDate = PaymentDate
        comm.FreightAmount = FreightAmount
        comm.FreightPercent = FreightPercent
        comm.NetSalesAmount = NetSalesAmount
        comm.DiscountAmount = DiscountAmount
        comm.PickupAllowanceAmount = PickupAllowanceAmount
        comm.AmountPaid = AmountPaid
        comm.CommissionPercent = CommissionPercent
        comm.SS12 = SS12
        comm.CommissionAmount = CommissionAmount
        comm.Reference = Reference
        comm.CommID = CommID
        comm.CusNo = CusNo
        comm.TotalSalesAmt = TotalSalesAmt
        comm.BatchID = BatchID
        comm.MiscAmt = MiscAmt
        comm.OrderNo = OrderNumber
        comm.Modified = Modified
        comm.ValidatedComm = ValidComm
        Return comm
    End Function

    Public Shared Function NewCommissionSavedObj(ByVal FileName As String, ByVal RepGroup As String, ByVal SalesPersonNumber As String, ByVal SalesPersonName As String, _
    ByVal InvoiceNumber As Integer, ByVal ShipToName As String, ByVal ShipToState As String, ByVal BillToState As String, ByVal OrderDate As Date, _
    ByVal ShipDate As Date, ByVal PaymentDate As Date, ByVal FreightAmount As String, ByVal FreightPercent As String, ByVal NetSalesAmount As String, _
    ByVal DiscountAmount As String, ByVal PickupAllowanceAmount As String, ByVal AmountPaid As String, ByVal CommissionPercent As String, _
    ByVal SS12 As String, ByVal CommissionAmount As String, ByVal Reference As String, ByVal CommID As Integer, ByVal CusNo As String, _
    ByVal TotalSalesAmt As String, ByVal BatchID As String, ByVal MiscAmt As String, ByVal OrderNumber As Integer, ByVal Modified As Integer, _
    ByVal ValidComm As Integer) As CommissionObj

        Dim comm As New CommissionSavedObj
        comm.DraftName = FileName
        comm.RepGroup = RepGroup
        comm.SalesPersonNumber = SalesPersonNumber
        comm.SalesPersonName = SalesPersonName
        comm.InvoiceNumber = InvoiceNumber
        comm.ShipToName = ShipToName
        comm.ShipToState = ShipToState
        comm.BillToState = BillToState
        comm.OrderDate = OrderDate
        comm.ShipDate = ShipDate
        comm.PaymentDate = PaymentDate
        comm.FreightAmount = FreightAmount
        comm.FreightPercent = FreightPercent
        comm.NetSalesAmount = NetSalesAmount
        comm.DiscountAmount = DiscountAmount
        comm.PickupAllowanceAmount = PickupAllowanceAmount
        comm.AmountPaid = AmountPaid
        comm.CommissionPercent = CommissionPercent
        comm.SS12 = SS12
        comm.CommissionAmount = CommissionAmount
        comm.Reference = Reference
        comm.CommID = CommID
        comm.CusNo = CusNo
        comm.TotalSalesAmt = TotalSalesAmt
        comm.BatchID = BatchID
        comm.MiscAmt = MiscAmt
        comm.OrderNo = OrderNumber
        comm.Modified = Modified.ToString
        comm.ValidatedComm = ValidComm.ToString

        Return comm

    End Function


    Public Shared Function GetSavedCommissionObj(ByVal FileName As String, ByVal RepGroup As String, ByVal SalesPersonNumber As String, ByVal SalesPersonName As String, _
        ByVal InvoiceNumber As Integer, ByVal ShipToName As String, ByVal ShipToState As String, ByVal BillToState As String, ByVal OrderDate As Date, _
        ByVal ShipDate As Date, ByVal PaymentDate As Date, ByVal FreightAmount As String, ByVal FreightPercent As String, ByVal NetSalesAmount As String, _
        ByVal DiscountAmount As String, ByVal PickupAllowanceAmount As String, ByVal AmountPaid As String, ByVal CommissionPercent As String, _
        ByVal SS12 As String, ByVal CommissionAmount As String, ByVal Reference As String, ByVal CommID As Integer, ByVal CusNo As String, _
        ByVal TotalSalesAmt As String, ByVal BatchID As String, ByVal MiscAmt As String, ByVal OrderNumber As Integer, ByVal Modified As Integer, _
        ByVal ValidComm As Integer) As CommissionObj

        Dim comm As New CommissionObj
        comm.RepGroup = RepGroup
        comm.SalesPersonNumber = SalesPersonNumber
        comm.SalesPersonName = SalesPersonName
        comm.InvoiceNumber = InvoiceNumber
        comm.ShipToName = ShipToName
        comm.ShipToState = ShipToState
        comm.BillToState = BillToState
        comm.OrderDate = OrderDate
        comm.ShipDate = ShipDate
        comm.PaymentDate = PaymentDate
        comm.FreightAmount = FreightAmount
        comm.FreightPercent = FreightPercent
        comm.NetSalesAmount = NetSalesAmount
        comm.DiscountAmount = DiscountAmount
        comm.PickupAllowanceAmount = PickupAllowanceAmount
        comm.AmountPaid = AmountPaid
        comm.CommissionPercent = CommissionPercent
        comm.SS12 = SS12
        comm.CommissionAmount = CommissionAmount
        comm.Reference = Reference
        comm.CommID = CommID
        comm.CusNo = CusNo
        comm.TotalSalesAmt = TotalSalesAmt
        comm.BatchID = BatchID
        comm.MiscAmt = MiscAmt
        comm.OrderNo = OrderNumber
        comm.Modified = Modified.ToString
        comm.ValidatedComm = ValidComm.ToString

        Return comm
    End Function

    Public Shared Function NewDraftCommissionHdrObj(ByVal DraftID As Integer, ByVal DraftName As String, _
                                                    ByVal PaymentDate As Date, ByVal UserDate As Date) As DraftCommissionHdrObj

        Dim draftcommhdr As New DraftCommissionHdrObj
        draftcommhdr.DraftID = DraftID
        draftcommhdr.DraftName = DraftName
        draftcommhdr.PaymentDate = PaymentDate
        draftcommhdr.UserDate = UserDate
        Return draftcommhdr

    End Function
    Public Shared Function GetDraftCommissionHdrObj(ByVal DraftID As Integer, ByVal DraftName As String, _
                                                    ByVal PaymentDate As Date, ByVal UserDate As Date) As DraftCommissionHdrObj

        Dim draftcommhdr As New DraftCommissionHdrObj
        draftcommhdr.DraftID = DraftID
        draftcommhdr.DraftName = DraftName
        draftcommhdr.PaymentDate = PaymentDate
        draftcommhdr.UserDate = UserDate
        Return draftcommhdr

    End Function

    Private Sub DataStateChanged(ByVal dataState As  _
    EntityStateEnum, ByVal propertyName As String)
        ' Raise the event
        If Not String.IsNullOrEmpty(propertyName) Then
            RaiseEvent PropertyChanged(Me, _
            New PropertyChangedEventArgs(propertyName))
        End If

        ' If the state is deleted, mark it as deleted
        If dataState = EntityStateEnum.Deleted Then
            Me.EntityState = dataState
        End If

        If Me.EntityState = EntityStateEnum.Unchanged Then
            Me.EntityState = dataState
        ElseIf Me.EntityState = EntityStateEnum.Modified Then
            Me.Modified = True
        End If
    End Sub
#End Region


#Region "   Properties   "

    Private _EntityState As EntityStateEnum
    Public Property EntityState() As EntityStateEnum
        Get
            Return _EntityState
        End Get
        Private Set(ByVal value As EntityStateEnum)
            _EntityState = value
        End Set
    End Property

    Public ReadOnly Property IsDirty() As Boolean
        Get
            Return Me.EntityState <> _
                            EntityStateEnum.Unchanged
        End Get
    End Property

    Private _LastName As String

    Public Property LastName() As String
        Get
            Return _LastName
        End Get
        Set(ByVal value As String)
            If String.IsNullOrEmpty(value) Then
                Throw New Exception( _
                     "The Last Name cannot be empty")
            End If
            If value <> _LastName Then
                Me.DataStateChanged( _
                EntityStateEnum.Modified, _
                "LastName")
            End If
            _LastName = value
        End Set
    End Property

    Private mRepGroup As String
    Public Property RepGroup() As String
        Get
            Return mRepGroup
        End Get
        Set(ByVal value As String)
            If Trim(value) <> RepGroup Then
                Me.DataStateChanged(EntityStateEnum.Modified, "RepGroup")
            End If
            mRepGroup = Trim(value)
        End Set
    End Property

    Private mSalesPersonNumber As String
    Public Property SalesPersonNumber() As String
        Get
            Return mSalesPersonNumber
        End Get
        Set(ByVal value As String)
            If Trim(value) <> SalesPersonNumber Then
                Me.DataStateChanged(EntityStateEnum.Modified, "SalesPersonNumber")
            End If
            mSalesPersonNumber = Trim(value)
        End Set
    End Property

    Private mSalesPersonName As String
    Public Property SalesPersonName() As String
        Get
            Return mSalesPersonName
        End Get
        Set(ByVal value As String)
            If Trim(value) <> SalesPersonName Then
                Me.DataStateChanged(EntityStateEnum.Modified, "SalesPersonName")
            End If
            mSalesPersonName = Trim(value)
        End Set
    End Property

    Private mInvoiceNumber As Integer
    Public Property InvoiceNumber() As Integer
        Get
            Return mInvoiceNumber
        End Get
        Set(ByVal value As Integer)
            If Trim(value) <> InvoiceNumber Then
                Me.DataStateChanged(EntityStateEnum.Modified, "InvoiceNumber")
            End If
            mInvoiceNumber = value
        End Set
    End Property

    Private mShipToName As String
    Public Property ShipToName() As String
        Get
            Return mShipToName
        End Get
        Set(ByVal value As String)
            If Trim(value) <> ShipToName Then
                Me.DataStateChanged(EntityStateEnum.Modified, "ShipToName")
            End If
            mShipToName = Trim(value)
        End Set
    End Property

    Private mShipToState As String
    Public Property ShipToState() As String
        Get
            Return mShipToState
        End Get
        Set(ByVal value As String)
            If Trim(value) <> ShipToState Then
                Me.DataStateChanged(EntityStateEnum.Modified, "ShipToState")
            End If
            mShipToState = Trim(value)
        End Set
    End Property

    Private mBillToState As String
    Public Property BillToState() As String
        Get
            Return mBillToState
        End Get
        Set(ByVal value As String)
            If Trim(value) <> BillToState Then
                Me.DataStateChanged(EntityStateEnum.Modified, "BillToState")
            End If
            mBillToState = Trim(value)
        End Set
    End Property

    Private mOrderDate As Date
    Public Property OrderDate() As Date
        Get
            Return mOrderDate
        End Get
        Set(ByVal value As Date)
            If Trim(value) <> OrderDate Then
                Me.DataStateChanged(EntityStateEnum.Modified, "OrderDate")
            End If
            mOrderDate = value
        End Set
    End Property

    Private mShipDate As Date
    Public Property ShipDate() As Date
        Get
            Return mShipDate
        End Get
        Set(ByVal value As Date)
            If Trim(value) <> ShipDate Then
                Me.DataStateChanged(EntityStateEnum.Modified, "ShipDate")
            End If
            mShipDate = value
        End Set
    End Property

    Private mPaymentDate As Date
    Public Property PaymentDate() As Date
        Get
            Return mPaymentDate
        End Get
        Set(ByVal value As Date)
            If Trim(value) <> PaymentDate Then
                Me.DataStateChanged(EntityStateEnum.Modified, "PaymentDate")
            End If
            mPaymentDate = value
        End Set
    End Property

    Private mFreightAmount As String
    Public Property FreightAmount() As String
        Get
            Return mFreightAmount
        End Get
        Set(ByVal value As String)
            If Trim(value) <> FreightAmount Then
                Me.DataStateChanged(EntityStateEnum.Modified, "FreightAmount")
            End If
            mFreightAmount = String.Format("{0:n2}", CDbl(value))
        End Set
    End Property

    Private mFreightPercent As String
    Public Property FreightPercent() As String
        Get
            Return mFreightPercent
        End Get
        Set(ByVal value As String)
            'If Trim(value) <> FreightPercent Then
            '    Me.DataStateChanged(EntityStateEnum.Modified, "FreightPercent")
            'End If
            mFreightPercent = String.Format("{0:n2}", CDbl(value))
        End Set
    End Property

    Private mNetSalesAmount As String
    Public Property NetSalesAmount() As String
        Get
            Return mNetSalesAmount
        End Get
        Set(ByVal value As String)
            If Trim(value) <> NetSalesAmount Then
                Me.DataStateChanged(EntityStateEnum.Modified, "NetSalesAmount")
            End If
            mNetSalesAmount = String.Format("{0:n2}", CDbl(value))
        End Set
    End Property

    Private mDiscountAmount As String
    Public Property DiscountAmount() As String
        Get
            Return mDiscountAmount
        End Get
        Set(ByVal value As String)
            If Trim(value) <> DiscountAmount Then
                Me.DataStateChanged(EntityStateEnum.Modified, "DiscountAmount")
            End If
            mDiscountAmount = String.Format("{0:n2}", CDbl(value))
        End Set
    End Property

    Private mPickupAllowanceAmount As String
    Public Property PickupAllowanceAmount() As String
        Get
            Return mPickupAllowanceAmount
        End Get
        Set(ByVal value As String)
            If Trim(value) <> PickupAllowanceAmount Then
                Me.DataStateChanged(EntityStateEnum.Modified, "PickupAllowanceAmount")
            End If
            mPickupAllowanceAmount = String.Format("{0:n2}", CDbl(value))
        End Set
    End Property

    Private mAmountPaid As String
    Public Property AmountPaid() As String
        Get
            Return mAmountPaid
        End Get
        Set(ByVal value As String)
            If Trim(value) <> AmountPaid Then
                Me.DataStateChanged(EntityStateEnum.Modified, "AmountPaid")
            End If
            mAmountPaid = String.Format("{0:n2}", CDbl(value))
        End Set
    End Property

    Private mCommissionPercent As String
    Public Property CommissionPercent() As String
        Get
            Return mCommissionPercent
        End Get
        Set(ByVal value As String)
            'If Trim(value) <> CommissionPercent Then
            '    Me.DataStateChanged(EntityStateEnum.Modified, "CommissionPercent")
            'End If
            mCommissionPercent = String.Format("{0:n2}", CDbl(value))
        End Set
    End Property

    Private mSS12 As String
    Public Property SS12() As String
        Get
            Return mSS12
        End Get
        Set(ByVal value As String)
            If Trim(value) <> SS12 Then
                Me.DataStateChanged(EntityStateEnum.Modified, "SS12")
            End If
            mSS12 = String.Format("{0:n2}", CDbl(value))
        End Set
    End Property

    Private mCommissionAmount As String
    Public Property CommissionAmount() As String
        Get
            Return mCommissionAmount
        End Get
        Set(ByVal value As String)
            If Trim(value) <> CommissionAmount Then
                Me.DataStateChanged(EntityStateEnum.Modified, "CommissionAmount")
            End If
            mCommissionAmount = String.Format("{0:n2}", CDbl(value))
        End Set
    End Property

    Private mReference As String
    Public Property Reference() As String
        Get
            Return mReference
        End Get
        Set(ByVal value As String)
            If Trim(value) <> Reference Then
                Me.DataStateChanged(EntityStateEnum.Modified, "Reference")
            End If
            mReference = Trim(value)
        End Set
    End Property


    Private mCommID As Integer
    Public Property CommID() As Integer
        Get
            Return mCommID
        End Get
        Set(ByVal value As Integer)
            If Trim(value) <> CommID Then
                Me.DataStateChanged(EntityStateEnum.Modified, "CommID")
            End If
            mCommID = value
        End Set
    End Property

    Private mCusNo As String
    Public Property CusNo() As String
        Get
            Return mCusNo
        End Get
        Set(ByVal value As String)
            If Trim(value) <> CusNo Then
                Me.DataStateChanged(EntityStateEnum.Modified, "CusNo")
            End If
            mCusNo = value
            Try
                CusNo_Stripped = CInt(CusNo)
            Catch ex As Exception

            End Try

        End Set
    End Property

    Private mCusNo_Stripped As Integer
    Public Property CusNo_Stripped() As Integer
        Get
            Return mCusNo_Stripped
        End Get
        Set(ByVal value As Integer)
            If Trim(value) <> CusNo_Stripped Then
                Me.DataStateChanged(EntityStateEnum.Modified, "CusNo_Stripped")
            End If
            mCusNo_Stripped = value
        End Set
    End Property

    Private mTotalSalesAmt As String
    Public Property TotalSalesAmt() As String
        Get
            Return mTotalSalesAmt
        End Get
        Set(ByVal value As String)
            If Trim(value) <> TotalSalesAmt Then
                Me.DataStateChanged(EntityStateEnum.Modified, "TotalSalesAmt")
            End If
            mTotalSalesAmt = (String.Format("{0:n2}", CDbl(value))).Trim
        End Set
    End Property

    Private mBatchID As String
    Public Property BatchID() As String
        Get
            Return mBatchID
        End Get
        Set(ByVal value As String)
            If Trim(value) <> BatchID Then
                Me.DataStateChanged(EntityStateEnum.Modified, "BatchID")
            End If
            mBatchID = value
            Try
                BatchID_Stripped = CInt(BatchID)
            Catch ex As Exception

            End Try

        End Set
    End Property

    Private mBatchID_Stripped As Integer
    Public Property BatchID_Stripped() As Integer
        Get
            Return mBatchID_Stripped
        End Get
        Set(ByVal value As Integer)
            If Trim(value) <> BatchID_Stripped Then
                Me.DataStateChanged(EntityStateEnum.Modified, "BatchID_Stripped")
            End If
            mBatchID_Stripped = value
        End Set
    End Property

    Private mMiscAmt As String
    Public Property MiscAmt() As String
        Get
            Return mMiscAmt
        End Get
        Set(ByVal value As String)
            If Trim(value) <> MiscAmt Then
                Me.DataStateChanged(EntityStateEnum.Modified, "MiscAmt")
            End If
            mMiscAmt = String.Format("{0:n2}", CDbl(value))
        End Set
    End Property

    Private mOrderNo As Integer
    Public Property OrderNo() As Integer
        Get
            Return mOrderNo
        End Get
        Set(ByVal value As Integer)
            If Trim(value) <> OrderNo Then
                Me.DataStateChanged(EntityStateEnum.Modified, "OrderNo")
            End If
            mOrderNo = value
        End Set
    End Property

    Private mModified As String
    Public Property Modified() As String
        Get
            Return mModified
        End Get
        Set(ByVal value As String)
            If value = "0" Then
                mModified = ""
            ElseIf value = "" Then
                mModified = ""
            Else
                mModified = sMultiplicationX
            End If
            'mModified = value
        End Set
    End Property

    Private mValidatedComm As String
    Public Property ValidatedComm() As String
        Get
            Return mValidatedComm
        End Get
        Set(ByVal value As String)
            If value = "0" Then
                mValidatedComm = ""
            ElseIf value = "" Then
                mValidatedComm = ""
            Else
                mValidatedComm = sMultiplicationX
            End If
            'mValidatedComm = value
        End Set
    End Property

    Private mAddedColumn As Boolean
    Public Property AddedColumn() As Boolean
        Get
            Return mAddedColumn
        End Get
        Set(ByVal value As Boolean)
            mAddedColumn = value
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

#End Region

#Region "  IEditableObject   "
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    Private mParent As CommissionList
    Private mParentSaved As CommissionSavedList
    Private mParentSavedCommFileDate As DraftCommissionHdrList

    Friend Sub SetParent(ByVal parent As CommissionList)
        mParent = parent
    End Sub
    Friend Sub SetParentSavedCommFileDate(ByVal ParentSavedCommFileDate As DraftCommissionHdrList)
        mParentSavedCommFileDate = ParentSavedCommFileDate
    End Sub
    Friend Sub SetParentSaved(ByVal parentSaved As CommissionSavedList)
        mParentSaved = parentSaved
    End Sub
    Public Sub BeginEdit() Implements System.ComponentModel.IEditableObject.BeginEdit

    End Sub

    Public Sub CancelEdit() Implements System.ComponentModel.IEditableObject.CancelEdit

    End Sub

    Public Sub EndEdit() Implements System.ComponentModel.IEditableObject.EndEdit

    End Sub
#End Region
    
End Class
