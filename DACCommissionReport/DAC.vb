Imports System.Data.SqlClient
''' <summary>
''' Data Access for PAS System
''' </summary>
''' <remarks></remarks>


Public Class DAC

    Public Shared Function ExecuteSP_RetVal(ByVal storedprocedure As String, _
    ByVal cn As SqlConnection, ByVal ParamArray arrParam() As SqlParameter) As Integer
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = storedprocedure
        cmd.Parameters.Clear()
        Dim i As Integer = 0
        If arrParam IsNot Nothing Then
            For Each param As SqlParameter In arrParam
                Debug.Print(CStr(arrParam(i).Value))
                cmd.Parameters.Add(param)
                i = i + 1
            Next
        End If

        cmd.ExecuteNonQuery()
        Dim ReturnValue As String
        Dim retval As String = "oNewKey"
        ReturnValue = cmd.Parameters(retval).Value
        Return ReturnValue


    End Function

    Public Shared Function ExecuteSP(ByVal storedprocedure As String, _
    ByVal cn As SqlConnection, ByVal ParamArray arrParam() As SqlParameter) As Integer
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = storedprocedure
        cmd.Parameters.Clear()
        Dim i As Integer = 0
        If arrParam IsNot Nothing Then
            For Each param As SqlParameter In arrParam
                Debug.Print(CStr(arrParam(i).Value))
                cmd.Parameters.Add(param)
                i = i + 1
            Next
        End If

        cmd.ExecuteNonQuery()
        'Dim ReturnValue As String
        'Dim retval As String = "oNewKey"
        'ReturnValue = cmd.Parameters(retval).Value
        'Return ReturnValue


    End Function
    Public Shared Function ExecuteSaveSP(ByVal storedprocedure As String, _
       ByVal cn As SqlConnection, ByVal ParamArray arrParam() As SqlParameter) As Integer
        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = storedprocedure
        cmd.Parameters.Clear()
        Dim i As Integer = 0
        If arrParam IsNot Nothing Then
            For Each param As SqlParameter In arrParam
                Debug.Print(CStr(arrParam(i).Value))
                cmd.Parameters.Add(param)
                i = i + 1
            Next
        End If
        'MsgBox(storedprocedure, MsgBoxStyle.Information)
        'i = 0
        'If arrParam IsNot Nothing Then
        '    Dim prms As String = ""
        '    For Each param As SqlParameter In arrParam
        '        prms = prms + (CStr(arrParam(i).ParameterName)) & " - " & (CStr(arrParam(i).Value)) & vbCrLf
        '        'cmd.Parameters.Add(param)
        '        i = i + 1
        '    Next
        '    MsgBox(prms, MsgBoxStyle.Information)
        'End If

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            MsgBox(storedprocedure, MsgBoxStyle.Information)
            i = 0
            If arrParam IsNot Nothing Then
                Dim prms As String = ""
                For Each param As SqlParameter In arrParam
                    prms = prms + (CStr(arrParam(i).ParameterName)) & " - " & (CStr(arrParam(i).Value)) & vbCrLf
                    'cmd.Parameters.Add(param)
                    i = i + 1
                Next
                MsgBox(prms, MsgBoxStyle.Information)
            End If
        End Try
        ' cmd.ExecuteNonQuery()
        'Dim ReturnValue As Boolean = True
        'Dim retval As String = "oNewKey"
        'ReturnValue = cmd.Parameters(retval).Value
        'Return ReturnValue
        For Each param As SqlParameter In arrParam
            If param.Direction = ParameterDirection.InputOutput Or param.Direction = ParameterDirection.Output Then
                Return param.Value
            End If
        Next

    End Function
    Public Shared Function ExecuteSP_Reader(ByVal storedprocedure As String, _
    ByVal cn As SqlConnection, ByVal ParamArray arrParam() As SqlParameter) As SqlDataReader
        Dim cmd As New SqlCommand

        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = storedprocedure
        cmd.Parameters.Clear()
        Dim i As Integer = 0
        If arrParam IsNot Nothing Then
            For Each param As SqlParameter In arrParam
                Debug.Print(CStr(arrParam(i).Value))
                cmd.Parameters.Add(param)
                i = i + 1
            Next
        End If
        Dim rd As SqlDataReader
        Try
            rd = cmd.ExecuteReader
        Catch ex As Exception

        End Try

        'Dim ReturnValue As String
        'Dim retval As String = "oNewKey"
        'ReturnValue = cmd.Parameters(retval).Value
        'Return ReturnValue
        cmd.Dispose()
        Return rd

    End Function
    Public Shared Sub Execute_NonSQL(ByVal sSQL As String, ByVal cn As SqlConnection)

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sSQL
        cmd.ExecuteNonQuery()

    End Sub

    Public Shared Function Execute_SQL(ByVal sSQL As String, ByVal cn As SqlConnection) As DataTable

        Return Nothing

    End Function
    Public Shared Function Execute_Scalar(ByVal sSQL As String, ByVal cn As SqlConnection) As Object

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sSQL
        Dim retval As Object
        retval = cmd.ExecuteScalar()
        Return retval

    End Function
    Public Shared Function ExecuteSQL_DataSet(ByVal sSQL As String, ByVal cn As SqlConnection, ByVal tableName As String) As DataTable
        Dim dt As DataTable
        Dim ds As New DataSet
        Dim da As SqlDataAdapter = New SqlDataAdapter(sSQL, cn)
        da.Fill(ds)
        dt = ds.Tables(0)
        dt.TableName = tableName
        Return dt

    End Function


    Public Shared Function ExecuteSQL_Reader(ByVal sSQL As String, ByVal cn As SqlConnection) As SqlDataReader
        Dim reader As SqlDataReader

        'If reader.IsClosed = False Then reader.Close()
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sSQL
        cmd.Connection = cn
        reader = cmd.ExecuteReader()

        Return reader
        reader.Close()
    End Function

    Public Shared Function Parameter(ByVal parameterName As String, ByVal parameterValue As Object, _
                                     ByVal parameterDirection As Integer) As SqlParameter

        Dim param As New SqlParameter
        param.ParameterName = parameterName
        param.Value = parameterValue
        param.Direction = parameterDirection
        Return param

    End Function

End Class
