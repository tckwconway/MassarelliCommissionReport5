Imports System.ComponentModel
Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Public Class BusObj

#Region "  Methods  "

    Public Shared Function GetCommissionStatus(ByVal DraftName As String, ByVal cn As SqlConnection) As Integer
        Dim res As Integer = DAC.Execute_Scalar("Select Count(*) from ARCOMDHDR_MAZ where draft_nam = '" & DraftName & "'", cn)
        Return res
    End Function
    Public Shared Function GetCommissionID(ByVal DraftName As String, ByVal DraftofFinal As String, ByVal cn As SqlConnection) As Integer
        Dim res As Integer
        If DraftofFinal = "Draft" Then
            res = DAC.Execute_Scalar("Select draft_id from ARCOMDHDR_MAZ where draft_nam = '" & DraftName & "'", cn)
        Else
            res = DAC.Execute_Scalar("Select comm_id from ARCOMFHDR_MAZ where comm_nam = '" & DraftName & "'", cn)
        End If
        Return res
    End Function
    Public Shared Function GetDraftCommissionHeaderList(ByVal DraftOrFinal As String, ByVal paymentdate As Date, _
                                                        ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader
        Dim sp As String
        'If DraftOrFinal = "Draft" Then
        sp = My.Resources.SP_spARGetCommHeaderList
        'Else
        '    sp = My.Resources.SP_spARGetCommissionReport_MAZ
        'End If
        rd = DAC.ExecuteSP_Reader(sp, cn, _
        DAC.Parameter(My.Resources.Param_iPymt_dt, paymentdate, ParameterDirection.Input), _
        DAC.Parameter(My.Resources.Param_iDraftOrFinal, DraftOrFinal, ParameterDirection.Input))

        Return rd
    End Function
    Public Shared Sub GetCommissionData(ByVal CommDate As Integer, ByVal cn As SqlConnection)
        DAC.ExecuteSP(My.Resources.SP_spARGetCommissionReport_MAZ, cn, _
        DAC.Parameter(My.Resources.Param_iCommDate, CommDate, ParameterDirection.Input))
    End Sub
    Public Shared Function GetCommissionDataReader(ByVal CommDate As Integer, ByVal USAorCAN As String, ByVal datasource As Integer, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader
        rd = DAC.ExecuteSP_Reader(My.Resources.SP_spARGetCommissionReport_MAZ, cn, _
        DAC.Parameter(My.Resources.Param_iCommDate, CommDate, ParameterDirection.Input), _
        DAC.Parameter(My.Resources.Param_iUSAorCAN, USAorCAN, ParameterDirection.Input), _
        DAC.Parameter(My.Resources.Param_idatasource, datasource, ParameterDirection.Input))
        Return rd
    End Function
    Public Shared Function GetCommissionDataReader(ByVal CommDate As Integer, ByVal USAorCAN As String, ByVal commdraftid As Integer, ByVal datasource As Integer, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader

        rd = DAC.ExecuteSP_Reader(My.Resources.SP_spARGetCommissionReport_MAZ, cn, _
        DAC.Parameter(My.Resources.Param_iCommDate, CommDate, ParameterDirection.Input), _
        DAC.Parameter(My.Resources.Param_iUSAorCAN, USAorCAN, ParameterDirection.Input), _
        DAC.Parameter(My.Resources.Param_icommdraftid, commdraftid, ParameterDirection.Input), _
        DAC.Parameter(My.Resources.Param_idatasource, datasource, ParameterDirection.Input))
        Return rd
    End Function

    Public Shared Function GetCommissionDataReader(ByVal CommDate As Integer, ByVal USAorCAN As String, ByVal datasource As Integer, _
                                                    ByVal OrderNo As String, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader
        rd = DAC.ExecuteSP_Reader(My.Resources.SP_spARGetCommissionReport_MAZ, cn, _
        DAC.Parameter(My.Resources.Param_iCommDate, CommDate, ParameterDirection.Input), _
        DAC.Parameter(My.Resources.Param_iUSAorCAN, USAorCAN, ParameterDirection.Input), _
        DAC.Parameter(My.Resources.Param_idatasource, datasource, ParameterDirection.Input))
        Return rd
    End Function
    Public Shared Function GetScalarValue(ByVal OrdNo As Integer, ByVal PymtDt As String, ByVal DraftOrFinal As String, ByVal cn As SqlConnection) As Boolean
        Dim sSQL As String = ""
        Dim _ordNo As Object
        Dim ord As Integer
        If DraftOrFinal = "Draft" Then
            'sSQL = "Select Distinct ord_no from ARCOMDRFT_MAZ where ord_no = " & OrdNo
        ElseIf DraftOrFinal = "Final" Then
            sSQL = "Select Count(ord_no) from ARCOMFINL_MAZ where ord_no = " & OrdNo & " and pymt_dt <> '" & PymtDt & "'"
        End If
        _ordNo = DAC.Execute_Scalar(sSQL, cn)
        ord = CInt(_ordNo)
        If ord > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function GetScalarValue(ByVal OrdNo As Integer, ByVal PymtDt As String, ByVal cn As SqlConnection) As Boolean
        Dim sSQL As String = ""
        Dim _ordNo As Object
        Dim ord As Integer
        sSQL = "Select Count(ord_no) from ARCOMFINL_MAZ where ord_no = " & OrdNo & " and pymt_dt <> '" & PymtDt & "'"
        _ordNo = DAC.Execute_Scalar(sSQL, cn)
        ord = CInt(_ordNo)
        If ord > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function GetScalarValue(ByVal OrdNo As Integer, ByVal cn As SqlConnection) As Boolean
        Dim sSQL As String = ""
        Dim _ordNo As Object
        Dim ord As Integer
        sSQL = "Select Count(ord_no) from ARCOMFINL_MAZ where ord_no = " & OrdNo '& "'"
        _ordNo = DAC.Execute_Scalar(sSQL, cn)
        ord = CInt(_ordNo)
        If ord > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function GetSQLDataReader(ByVal OrdNo As Integer, ByVal PmtDt As String, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader
        Dim sSQL As String
        sSQL = "Select * from ARCOMFINL_MAZ where ord_no = " & OrdNo & " and pymt_dt <> '" & PmtDt & "'"
        rd = DAC.ExecuteSQL_Reader(sSQL, cn)
        Return rd
    End Function
    Public Shared Function GetSQLDataReader(ByVal OrdNo As Integer, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader
        Dim sSQL As String
        sSQL = "Select * from ARCOMFINL_MAZ where ord_no = " & OrdNo '& " and pymt_dt <> '" & PmtDt & "'"
        rd = DAC.ExecuteSQL_Reader(sSQL, cn)
        Return rd
    End Function
    Public Shared Function GetCommissionDataByOrder(ByVal OrderNo As String, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader
        rd = DAC.ExecuteSP_Reader(My.Resources.SP_spOEGetOrderCommissionReport_MAZ, cn, _
        DAC.Parameter(My.Resources.Param_iorderno, OrderNo, ParameterDirection.Input))
        Return rd
    End Function

    Public Shared Function GetSearchDateReader(ByVal where As String, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader
        Dim sSQL As String
        sSQL = "Select rep_group,slspsn_number,slspsn_name,inv_no,ship_to_name,ship_to_state,bill_to_state " & _
                ",order_dt,ship_dt,ARCOMFINL_MAZ.pymt_dt,frt_amt,frt_prcnt,net_sls_amt,disc_amt,pickup_allow_amt,amt_paid " & _
                ",comm_prct,ss12,comm_amt,reference,ARCOMFINL_MAZ.comm_id,cus_no,total_sls_amt,batch_id,misc_amt, ord_no, modified ,valid_comm " & _
                "From ARCOMFINL_MAZ " & _
                "Join ARCOMFHDR_MAZ on ARCOMFINL_MAZ.comm_id = ARCOMFHDR_MAZ.comm_id " & where & " Order by batch_id	,cus_no	,inv_no "
        rd = DAC.ExecuteSQL_Reader(sSQL, cn)
        Return rd

    End Function
    Public Shared Function CheckForSavedCommission(ByVal CommDate As String, ByVal cn As SqlConnection) As Object
        Dim obj As Object
        obj = DAC.Execute_Scalar("Select pymt_dt from ARCOMMSN_MAZ Where pymt_dt = " & CommDate, cn)
        Return obj
    End Function
    Public Shared Sub DeleteCommByDate(ByVal CommDate As String, ByVal cn As SqlConnection)
        DAC.Execute_NonSQL("Delete from ARCOMMSN_MAZ where pymt_dt = " & CommDate, cn)
    End Sub

    Public Shared Function PopulateDraftCommissionHdrList(ByVal rd As SqlDataReader) As DraftCommissionHdrList
        Dim oDraftCommList(3) As Object
        Dim drftlst As New DraftCommissionHdrList
        While rd.Read
            If rd(0).Equals(DBNull.Value) Then oDraftCommList(0) = 0 Else oDraftCommList(0) = CInt(rd(0))
            If rd(1).Equals(DBNull.Value) Then oDraftCommList(1) = "" Else oDraftCommList(1) = CStr(rd(1))
            If rd(2).Equals(DBNull.Value) Then oDraftCommList(2) = CDate("01/01/1900") Else oDraftCommList(2) = CDate(rd(2))
            If rd(3).Equals(DBNull.Value) Then oDraftCommList(3) = CDate("01/01/1900") Else oDraftCommList(3) = CDate(rd(3))

            drftlst.Add(DraftCommissionHdrObj.GetDraftCommissionHdrObj(CInt(oDraftCommList(0)), CStr(oDraftCommList(1)), _
                                                                       CDate(oDraftCommList(2)), CDate(oDraftCommList(3))))
        End While

        rd.Close()
        Return drftlst

    End Function
    Public Shared Function PopulateCommission(ByVal rd As SqlDataReader) As CommissionList
        Dim oCommList(27) As Object
        Dim commlst As New CommissionList
        Try
            While rd.Read
                If rd(0).Equals(DBNull.Value) Then oCommList(0) = "" Else oCommList(0) = CStr(rd(0))
                If rd(1).Equals(DBNull.Value) Then oCommList(1) = "" Else oCommList(1) = CStr(rd(1))
                If rd(2).Equals(DBNull.Value) Then oCommList(2) = "" Else oCommList(2) = CStr(rd(2))
                If rd(3).Equals(DBNull.Value) Then oCommList(3) = 0 Else oCommList(3) = CInt(rd(3))
                If rd(4).Equals(DBNull.Value) Then oCommList(4) = "" Else oCommList(4) = CStr(rd(4))
                If rd(5).Equals(DBNull.Value) Then oCommList(5) = "" Else oCommList(5) = CStr(rd(5))
                If rd(6).Equals(DBNull.Value) Then oCommList(6) = "" Else oCommList(6) = CStr(rd(6))
                If rd(7).Equals(DBNull.Value) Then oCommList(7) = CDate("01/01/1900") Else oCommList(7) = CDate(rd(7))
                If rd(8).Equals(DBNull.Value) Then oCommList(8) = CDate("01/01/1900") Else oCommList(8) = CDate(rd(8))
                If rd(9).Equals(DBNull.Value) Then oCommList(9) = CDate("01/01/1900") Else oCommList(9) = CDate(rd(9))
                If rd(10).Equals(DBNull.Value) Then oCommList(10) = 0 Else oCommList(10) = CDec(rd(10))
                If rd(11).Equals(DBNull.Value) Then oCommList(11) = 0 Else oCommList(11) = CDec(rd(11))
                If rd(12).Equals(DBNull.Value) Then oCommList(12) = 0 Else oCommList(12) = CDec(rd(12))
                If rd(13).Equals(DBNull.Value) Then oCommList(13) = 0 Else oCommList(13) = CDec(rd(13))
                If rd(14).Equals(DBNull.Value) Then oCommList(14) = 0 Else oCommList(14) = CDec(rd(14))
                If rd(15).Equals(DBNull.Value) Then oCommList(15) = 0 Else oCommList(15) = CDec(rd(15))
                If rd(16).Equals(DBNull.Value) Then oCommList(16) = 0 Else oCommList(16) = CDec(rd(16))
                If rd(17).Equals(DBNull.Value) Then oCommList(17) = 0 Else oCommList(17) = CDec(rd(17))
                If rd(18).Equals(DBNull.Value) Then oCommList(18) = 0 Else oCommList(18) = CDec(rd(18))
                If rd(19).Equals(DBNull.Value) Then oCommList(19) = "" Else oCommList(19) = CStr(rd(19))
                If rd(20).Equals(DBNull.Value) Then oCommList(20) = 0 Else oCommList(20) = CInt(rd(20))
                If rd(21).Equals(DBNull.Value) Then oCommList(21) = "" Else oCommList(21) = CStr(rd(21))
                If rd(22).Equals(DBNull.Value) Then oCommList(22) = 0 Else oCommList(22) = CDec(rd(22))
                If rd(23).Equals(DBNull.Value) Then oCommList(23) = "" Else oCommList(23) = CStr(rd(23))
                If rd(24).Equals(DBNull.Value) Then oCommList(24) = 0 Else oCommList(24) = CInt(rd(24))
                If rd(25).Equals(DBNull.Value) Then oCommList(25) = 0 Else oCommList(25) = CInt(rd(25))
                If rd(26).Equals(DBNull.Value) Then oCommList(26) = 0 Else oCommList(26) = CInt(rd(26))
                If rd(27).Equals(DBNull.Value) Then oCommList(27) = 0 Else oCommList(27) = CInt(rd(27))

                commlst.Add(CommissionObj.GetCommissionObj(CStr(oCommList(0)), CStr(oCommList(1)), CStr(oCommList(2)), _
                CInt(oCommList(3)), CStr(oCommList(4)), CStr(oCommList(5)), CStr(oCommList(6)), CDate(oCommList(7)), _
                CDate(oCommList(8)), CDate(oCommList(9)), CDec(oCommList(10)), CDec(oCommList(11)), CDec(oCommList(12)), _
                CDec(oCommList(13)), CDec(oCommList(14)), CDec(oCommList(15)), CDec(oCommList(16)), CDec(oCommList(17)), _
                CDec(oCommList(18)), CStr(oCommList(19)), CInt(oCommList(20)), CStr(oCommList(21)), CDec(oCommList(22)), _
                CStr(oCommList(23)), CInt(oCommList(24)), CInt(oCommList(25)), CInt(oCommList(26)), CInt(oCommList(27))))

            End While
            rd.Close()
            Return commlst
        Catch ex As Exception
            'MsgBox("oops")
        End Try

    End Function
    Public Shared Function PopulateCommissionObj(ByVal rd As SqlDataReader) As CommissionObj
        Dim oCommObj(25) As Object
        Dim commobj As New CommissionObj
        Try
            While rd.Read
                If rd(0).Equals(DBNull.Value) Then oCommObj(0) = "" Else oCommObj(0) = CStr(rd(0))
                If rd(1).Equals(DBNull.Value) Then oCommObj(1) = "" Else oCommObj(1) = CStr(rd(1))
                If rd(2).Equals(DBNull.Value) Then oCommObj(2) = "" Else oCommObj(2) = CStr(rd(2))
                If rd(3).Equals(DBNull.Value) Then oCommObj(3) = 0 Else oCommObj(3) = CInt(rd(3))
                If rd(4).Equals(DBNull.Value) Then oCommObj(4) = "" Else oCommObj(4) = CStr(rd(4))
                If rd(5).Equals(DBNull.Value) Then oCommObj(5) = "" Else oCommObj(5) = CStr(rd(5))
                If rd(6).Equals(DBNull.Value) Then oCommObj(6) = "" Else oCommObj(6) = CStr(rd(6))
                If rd(7).Equals(DBNull.Value) Then oCommObj(7) = CDate("01/01/1900") Else oCommObj(7) = CDate(rd(7))
                If rd(8).Equals(DBNull.Value) Then oCommObj(8) = CDate("01/01/1900") Else oCommObj(8) = CDate(rd(8))
                If rd(9).Equals(DBNull.Value) Then oCommObj(9) = CDate("01/01/1900") Else oCommObj(9) = CDate(rd(9))
                If rd(10).Equals(DBNull.Value) Then oCommObj(10) = 0 Else oCommObj(10) = CDec(rd(10))
                If rd(11).Equals(DBNull.Value) Then oCommObj(11) = 0 Else oCommObj(11) = CDec(rd(11))
                If rd(12).Equals(DBNull.Value) Then oCommObj(12) = 0 Else oCommObj(12) = CDec(rd(12))
                If rd(13).Equals(DBNull.Value) Then oCommObj(13) = 0 Else oCommObj(13) = CDec(rd(13))
                If rd(14).Equals(DBNull.Value) Then oCommObj(14) = 0 Else oCommObj(14) = CDec(rd(14))
                If rd(15).Equals(DBNull.Value) Then oCommObj(15) = 0 Else oCommObj(15) = CDec(rd(15))
                If rd(16).Equals(DBNull.Value) Then oCommObj(16) = 0 Else oCommObj(16) = CDec(rd(16))
                If rd(17).Equals(DBNull.Value) Then oCommObj(17) = 0 Else oCommObj(17) = CDec(rd(17))
                If rd(18).Equals(DBNull.Value) Then oCommObj(18) = 0 Else oCommObj(18) = CDec(rd(18))
                If rd(19).Equals(DBNull.Value) Then oCommObj(19) = "" Else oCommObj(19) = CStr(rd(19))
                If rd(20).Equals(DBNull.Value) Then oCommObj(20) = 0 Else oCommObj(20) = CInt(rd(20))
                If rd(21).Equals(DBNull.Value) Then oCommObj(21) = "" Else oCommObj(21) = CStr(rd(21))
                If rd(22).Equals(DBNull.Value) Then oCommObj(22) = 0 Else oCommObj(22) = CDec(rd(22))
                If rd(23).Equals(DBNull.Value) Then oCommObj(23) = "" Else oCommObj(23) = CStr(rd(23))
                If rd(24).Equals(DBNull.Value) Then oCommObj(24) = 0 Else oCommObj(24) = CInt(rd(24))
                If rd(25).Equals(DBNull.Value) Then oCommObj(25) = 0 Else oCommObj(25) = CInt(rd(25))

                commobj.RepGroup = CStr(oCommObj(0))
                commobj.SalesPersonNumber = CStr(oCommObj(1))
                commobj.SalesPersonName = CStr(oCommObj(2))
                commobj.InvoiceNumber = CInt(oCommObj(3))
                commobj.ShipToName = CStr(oCommObj(4))
                commobj.ShipToState = CStr(oCommObj(5))
                commobj.BillToState = CStr(oCommObj(6))
                commobj.OrderDate = CDate(oCommObj(7))
                commobj.ShipDate = CDate(oCommObj(8))
                commobj.PaymentDate = CDate(oCommObj(9))
                commobj.FreightAmount = CDec(oCommObj(10))
                commobj.FreightPercent = CDec(oCommObj(11))
                commobj.NetSalesAmount = CDec(oCommObj(12))
                commobj.DiscountAmount = CDec(oCommObj(13))
                commobj.PickupAllowanceAmount = CDec(oCommObj(14))
                commobj.AmountPaid = CDec(oCommObj(15))
                commobj.CommissionPercent = CDec(oCommObj(16))
                commobj.SS12 = CDec(oCommObj(17))
                commobj.CommissionAmount = CDec(oCommObj(18))
                commobj.Reference = CStr(oCommObj(19))
                commobj.CommID = CInt(oCommObj(20))
                commobj.CusNo = (oCommObj(21))
                commobj.TotalSalesAmt = CStr(oCommObj(22))
                commobj.BatchID = CStr(oCommObj(23))
                commobj.MiscAmt = CInt(oCommObj(24))
                commobj.OrderNo = CInt(oCommObj(25))

            End While
            rd.Close()
            Return commobj
        Catch ex As Exception

        End Try

    End Function

    'Public Shared Function PopulateSavedCommission(ByVal rd As SqlDataReader, ByVal CommList As CommissionList) As CommissionSavedList
    '    Dim oCommList(25) As Object
    '    Dim commsavedlst As New CommissionSavedList
    '    While rd.Read
    '        If rd(0).Equals(DBNull.Value) Then oCommList(0) = "" Else oCommList(0) = CStr(rd(0))
    '        If rd(1).Equals(DBNull.Value) Then oCommList(1) = "" Else oCommList(1) = CStr(rd(1))
    '        If rd(2).Equals(DBNull.Value) Then oCommList(2) = "" Else oCommList(2) = CStr(rd(2))
    '        If rd(3).Equals(DBNull.Value) Then oCommList(3) = 0 Else oCommList(3) = CInt(rd(3))
    '        If rd(4).Equals(DBNull.Value) Then oCommList(4) = "" Else oCommList(4) = CStr(rd(4))
    '        If rd(5).Equals(DBNull.Value) Then oCommList(5) = "" Else oCommList(5) = CStr(rd(5))
    '        If rd(6).Equals(DBNull.Value) Then oCommList(6) = "" Else oCommList(6) = CStr(rd(6))
    '        If rd(7).Equals(DBNull.Value) Then oCommList(7) = CDate("01/01/1900") Else oCommList(7) = CDate(rd(7))
    '        If rd(8).Equals(DBNull.Value) Then oCommList(8) = CDate("01/01/1900") Else oCommList(8) = CDate(rd(8))
    '        If rd(9).Equals(DBNull.Value) Then oCommList(9) = CDate("01/01/1900") Else oCommList(9) = CDate(rd(9))
    '        If rd(10).Equals(DBNull.Value) Then oCommList(10) = 0 Else oCommList(10) = CDec(rd(10))
    '        If rd(11).Equals(DBNull.Value) Then oCommList(11) = 0 Else oCommList(11) = CDec(rd(11))
    '        If rd(12).Equals(DBNull.Value) Then oCommList(12) = 0 Else oCommList(12) = CDec(rd(12))
    '        If rd(13).Equals(DBNull.Value) Then oCommList(13) = 0 Else oCommList(13) = CDec(rd(13))
    '        If rd(14).Equals(DBNull.Value) Then oCommList(14) = 0 Else oCommList(14) = CDec(rd(14))
    '        If rd(15).Equals(DBNull.Value) Then oCommList(15) = 0 Else oCommList(15) = CDec(rd(15))
    '        If rd(16).Equals(DBNull.Value) Then oCommList(16) = 0 Else oCommList(16) = CDec(rd(16))
    '        If rd(17).Equals(DBNull.Value) Then oCommList(17) = 0 Else oCommList(17) = CDec(rd(17))
    '        If rd(18).Equals(DBNull.Value) Then oCommList(18) = 0 Else oCommList(18) = CDec(rd(18))
    '        If rd(19).Equals(DBNull.Value) Then oCommList(19) = "" Else oCommList(19) = CStr(rd(19))
    '        If rd(20).Equals(DBNull.Value) Then oCommList(20) = 0 Else oCommList(20) = CInt(rd(20))
    '        If rd(21).Equals(DBNull.Value) Then oCommList(21) = "" Else oCommList(21) = CStr(rd(21))
    '        If rd(22).Equals(DBNull.Value) Then oCommList(22) = 0 Else oCommList(22) = CDec(rd(22))
    '        If rd(23).Equals(DBNull.Value) Then oCommList(23) = "" Else oCommList(23) = CStr(rd(23))
    '        If rd(24).Equals(DBNull.Value) Then oCommList(24) = 0 Else oCommList(24) = CInt(rd(24))
    '        If rd(25).Equals(DBNull.Value) Then oCommList(25) = 0 Else oCommList(25) = CInt(rd(25))
    '        If rd(26).Equals(DBNull.Value) Then oCommList(26) = 0 Else oCommList(26) = CInt(rd(26))

    '        commsavedlst.Add(CommissionObj.GetCommissionObj(CStr(oCommList(0)), CStr(oCommList(1)), CStr(oCommList(2)), _
    '        CInt(oCommList(3)), CStr(oCommList(4)), CStr(oCommList(5)), CStr(oCommList(6)), CDate(oCommList(7)), _
    '        CDate(oCommList(8)), CDate(oCommList(9)), CDec(oCommList(10)), CDec(oCommList(11)), CDec(oCommList(12)), _
    '        CDec(oCommList(13)), CDec(oCommList(14)), CDec(oCommList(15)), CDec(oCommList(16)), CDec(oCommList(17)), _
    '        CDec(oCommList(18)), CStr(oCommList(19)), CInt(oCommList(20)), CStr(oCommList(21)), CDec(oCommList(22)), _
    '        CStr(oCommList(23)), CInt(oCommList(24)), CInt(oCommList(25)), CInt(oCommList(26))))


    '    End While
    '    rd.Close()
    '    Return commsavedlst
    'End Function

    Public Shared Function SaveCommissionReport(ByVal rep_group As String, ByVal slspsn_number As String, ByVal slspsn_name As String, _
                                         ByVal inv_no As Integer, ByVal ship_to_name As String, ByVal ship_to_state As String, _
                                         ByVal bill_to_state As String, ByVal order_dt As Date, ByVal ship_dt As Date, _
                                         ByVal pymt_dt As Date, ByVal frt_amt As Decimal, ByVal frt_prcnt As Decimal, _
                                         ByVal net_sls_amt As Decimal, ByVal disc_amt As Decimal, ByVal pickup_allow_amt As Decimal, _
                                         ByVal amt_paid As Decimal, ByVal comm_prct As Decimal, ByVal ss12 As Decimal, _
                                         ByVal comm_amt As Decimal, ByVal reference As String, ByVal comm_id As Integer, _
                                         ByVal cus_no As String, ByVal tot_sls_amt As Decimal, ByVal batch_id As String, _
                                         ByVal miscamt As Decimal, ByVal ordno As Integer, ByVal RowState As String, ByVal cn As SqlConnection) As Boolean

        Dim Success As Boolean = False
        Dim Result As Integer = 0

        Result = DAC.ExecuteSP(My.Resources.SP_spARSaveCommission_MAZ, cn, _
            DAC.Parameter(My.Resources.Param_iRep_group, rep_group, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iSlspsn_number, slspsn_number, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iSlspsn_name, slspsn_name, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iInv_no, inv_no, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iShip_to_name, ship_to_name, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iShip_to_state, ship_to_state, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iBill_to_state, bill_to_state, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iOrder_dt, order_dt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iShip_dt, ship_dt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iPymt_dt, pymt_dt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iFrt_amt, frt_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iFrt_prcnt, frt_prcnt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iNet_sls_amt, net_sls_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iDisc_amt, disc_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iPickup_allow_amt, pickup_allow_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iAmt_paid, amt_paid, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iComm_prct, comm_prct, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iSs12, ss12, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iComm_amt, comm_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iReference, reference, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iCommID, comm_id, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iRowState, RowState, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iCusNo, cus_no, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iTotalSalesAmt, tot_sls_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iBatchID, batch_id, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iMisc_amt, miscamt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iord_no, ordno, ParameterDirection.Input))

    End Function
    Public Shared Function SaveAsCommissionReport(ByVal draftid As Integer, ByVal rep_group As String, ByVal slspsn_number As String, ByVal slspsn_name As String, _
                                             ByVal inv_no As Integer, ByVal ship_to_name As String, ByVal ship_to_state As String, _
                                             ByVal bill_to_state As String, ByVal order_dt As Date, ByVal ship_dt As Date, _
                                             ByVal pymt_dt As Date, ByVal frt_amt As Decimal, ByVal frt_prcnt As Decimal, _
                                             ByVal net_sls_amt As Decimal, ByVal disc_amt As Decimal, ByVal pickup_allow_amt As Decimal, _
                                             ByVal amt_paid As Decimal, ByVal comm_prct As Decimal, ByVal ss12 As Decimal, _
                                             ByVal comm_amt As Decimal, ByVal reference As String, _
                                             ByVal comm_id As Integer, ByVal cus_no As String, ByVal tot_sls_amt As Decimal, _
                                             ByVal batch_id As String, ByVal miscamt As Decimal, ByVal ordno As Integer, _
                                             ByVal modified As Integer, ByVal validcomm As Integer, ByVal draftorfinal As String, _
                                             ByVal commdraftid_deleted As Integer, ByVal RowState As String, _
                                             ByVal cn As SqlConnection) As Boolean

        Dim Success As Boolean = False
        Dim Result As Integer = 0

        Result = DAC.ExecuteSaveSP(My.Resources.SP_spARSaveFinalDraftCommission_MAZ, cn, _
            DAC.Parameter(My.Resources.Param_iDraftID, draftid, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iRep_group, rep_group, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iSlspsn_number, slspsn_number, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iSlspsn_name, slspsn_name, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iInv_no, inv_no, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iShip_to_name, ship_to_name, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iShip_to_state, ship_to_state, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iBill_to_state, bill_to_state, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iOrder_dt, order_dt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iShip_dt, ship_dt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iPymt_dt, pymt_dt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iFrt_amt, frt_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iFrt_prcnt, frt_prcnt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iNet_sls_amt, net_sls_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iDisc_amt, disc_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iPickup_allow_amt, pickup_allow_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iAmt_paid, amt_paid, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iComm_prct, comm_prct, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iSs12, ss12, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iComm_amt, comm_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iReference, reference, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iCommID, comm_id, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iDraftOrFinal, draftorfinal, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iRowState, RowState, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iCusNo, cus_no, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iTotalSalesAmt, tot_sls_amt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iBatchID, batch_id, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iMisc_amt, miscamt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iord_no, ordno, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_icommdraftid_deleted, commdraftid_deleted, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_imodified, modified, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_ivalid_comm, validcomm, ParameterDirection.Input))

    End Function
    Public Shared Function SaveCommissionHeader(ByVal draftid As Integer, ByVal draftname As String, _
                                                ByVal pymt_dt As String, ByVal userdate As Date, _
                                                ByVal draftorfinal As String, ByVal rowstate As String, _
                                                ByVal odraftid As Integer, ByVal cn As SqlConnection) As Integer

        Dim Success As Boolean = False
        Dim Result As Integer = 0

        Result = DAC.ExecuteSaveSP(My.Resources.SP_spARSaveFinalDraftHdr_MAZ, cn, _
            DAC.Parameter(My.Resources.Param_iDraftID, draftid, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iDraftName, draftname, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iPymt_dt, pymt_dt, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iUserDate, userdate, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iDraftOrFinal, draftorfinal, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_iRowState, rowstate, ParameterDirection.Input), _
            DAC.Parameter(My.Resources.Param_odraftid, odraftid, ParameterDirection.InputOutput))
        Return Result
    End Function
    Public Shared Function GetRowState(ByVal comm_id As Integer, ByVal SaveOrPost As String, ByVal cn As SqlConnection) As String
        Dim RowState As String
        Dim commid As Integer
        Dim sSQL As String
        If SaveOrPost = "Post" Then
            sSQL = "Select id from ARCOMMSN_MAZ where id = " & comm_id
        Else
            sSQL = "Select id from ARCOMSVAS_MAZ where id = " & comm_id
        End If

        commid = DAC.Execute_Scalar(sSQL, cn)
        If commid = Nothing Then
            RowState = "Added"
        Else
            RowState = "Modified"
        End If
        Return RowState
    End Function

    Public Shared Function GetList(ByVal sSql As String, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader

        rd = DAC.ExecuteSQL_Reader(sSql, cn)
        Return rd

    End Function
    Public Shared Function CheckForUserName(ByVal sql As String, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader

        rd = DAC.ExecuteSQL_Reader(sql, cn)
        Return rd

    End Function
    Public Shared Sub SavePassword(ByVal SQL As String, ByVal cn As SqlConnection)
        DAC.Execute_NonSQL(SQL, cn)
    End Sub

    Public Shared Function OpenPassword(ByVal SQL As String, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader = DAC.ExecuteSQL_Reader(SQL, cn)
        Return rd
    End Function
#End Region
#Region "   Properties   "

    Private mMinProgBar As Integer
    Public Property MinProgBar() As Integer
        Get
            Return mMinProgBar
        End Get
        Set(ByVal value As Integer)
            mMinProgBar = value
        End Set
    End Property

    Private mMaxProgBar As Integer
    Public Property MaxProgBar() As Integer
        Get
            Return mMaxProgBar
        End Get
        Set(ByVal value As Integer)
            mMaxProgBar = value
        End Set
    End Property


    Private mSearchPaymentDate As String
    Public Property SearchPaymentDate() As String
        Get
            Return mSearchPaymentDate
        End Get
        Set(ByVal value As String)
            mSearchPaymentDate = value
            Try
                SearchPaymentDateDT = Date.Parse(SearchPaymentDate.Substring(4, 2) & "/" & _
                                             SearchPaymentDate.Substring(6, 2) & "/" & _
                                             SearchPaymentDate.Substring(0, 4))
            Catch ex As Exception

            End Try

        End Set
    End Property

    Private mSearchPaymentDateDT As Date
    Public Property SearchPaymentDateDT() As Date
        Get
            Return mSearchPaymentDateDT
        End Get
        Set(ByVal value As Date)
            mSearchPaymentDateDT = value
        End Set
    End Property

#End Region

End Class
