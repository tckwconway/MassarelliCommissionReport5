Imports System.Environment
Imports System.Data.SqlClient
Imports System.Data.OleDb

Module MacolaStartup
    Friend cn As SqlConnection
    Friend cno As OleDbConnection
    Public Sub MacStartup(ByVal db As String)
        '        cn = New SqlConnection(My.Settings.DATA999ConnectionString)
        'cn = New SqlConnection(My.Settings.DATA999ConnectionString)
        'cn = New SqlConnection(My.Settings.DATAMASSConnection)
        Try
            cn.Close()
        Catch ex As Exception

        End Try

        Dim ConnStr As String = "Data Source=" & My.Settings.DefaultServer & ";Initial Catalog=" & db & ";Persist Security Info=True;User ID=sa;Password=STMARTIN"
        cn = New SqlConnection
        cn.ConnectionString = ConnStr
        cn.Open()

        'If Company = "001 - MASSARELLI" Then
        '    cn = New SqlConnection(My.Settings.DATA_MASSSQL2)
        '    'cn = New SqlConnection(My.Settings.DATA03_TCOptiPlex)
        '    'cn = New SqlConnection(My.Settings.DATAMASSConnection)
        'ElseIf Company = "200 - IMPORTS" Then
        '    cn = New SqlConnection(My.Settings.DATA200ConnectionString)
        'ElseIf Company = "999 - TEST COMPANY" Then
        '    cn = New SqlConnection(My.Settings.DATAConnectionString)
        'End If


        'cn = New SqlConnection(My.Settings.DATA_TCOPTIPLEX)
        Try
            cn.Open()
        Catch ex As Exception
            'MsgBox("Unable to open Company " & Company & ".")
        End Try

    End Sub
End Module
