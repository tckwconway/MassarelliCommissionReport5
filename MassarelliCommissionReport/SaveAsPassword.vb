Imports System.Data.SqlClient
Public Class SaveAsPassword

    Private Sub ButtonSavePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSavePassword.Click
        Dim des As New TripleDES
        Dim sql As String
        Dim rd As SqlDataReader
        Dim sDelimiter As String
        Dim sValue As String
        Dim i As Integer

        'Check for Username first
        Dim user As String
        Dim pwd() As Byte

        user = Me.TextBoxUserName.Text
        pwd = des.Encrypt(Me.TextBoxPassword.Text)

        Dim ipwd As Int32 = UBound(pwd)

        Dim spwd(pwd.Length - 1) As String


        sDelimiter = ","

        For i = LBound(pwd) To UBound(pwd)
            spwd(i) = CStr(pwd(i))
        Next i

        sValue = Join(spwd, sDelimiter)

        REM Later, you can Load array from field
        'sArray = Split(<your_array_field>, sDelimiter)


        sql = "Select * from ARCOMPWD_MAZ where username = '" & Me.TextBoxUserName.Text & "'"
        rd = BusObj.CheckForUserName(sql, cn)
        If rd.HasRows Then
            sql = "Update ARCOMPWD_MAZ Set password = '" & sValue & "'"
        Else
            sql = "Insert Into ARCOMPWD_MAZ (username, password) Values('" & user & "', '" & sValue & "')"
        End If
        rd.Close()

        BusObj.SavePassword(sql, cn)
        MsgBox("Password Saved Successfully.", MsgBoxStyle.OkOnly, "Save User/Password")
        Me.Close()
    End Sub

    Private Sub ButtonOpenPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpenPassword.Click
        Dim sql As String
        Dim rd As SqlDataReader
        Dim des As New TripleDES
        Dim sDelimiter As String = ","
        'Dim sValue As String
        Dim i As Integer
        Dim user As String
        Dim sTestPwd As String
        Dim ipwd As Integer
        Dim spwd As String = ""
        Dim sArray() As String
        user = Me.TextBoxUserName.Text

        sql = "Select username, password from ARCOMPWD_MAZ Where username = '" & user & "'"
        rd = BusObj.OpenPassword(sql, cn)
        If rd.HasRows = False Then
            MsgBox("Invalid username", vbOK, "Username")
            Exit Sub
        End If
        While (rd.Read)
            spwd = rd(1).ToString
        End While
        rd.Close()
        sArray = Split(spwd, sDelimiter)
        ipwd = UBound(sArray)
        Dim pwd(ipwd) As Byte
        For i = LBound(sArray) To UBound(sArray)
            pwd(i) = CByte(sArray(i))
        Next

        sTestPwd = des.Decrypt(pwd)
        If sTestPwd = Me.TextBoxPassword.Text Then
            CommissionRpt.OverwriteFinal = True
            Me.Close()
        Else
            MsgBox("Invalid Password", MsgBoxStyle.OkOnly, "Overwrite Final Commission")
        End If
        '

    End Sub
End Class