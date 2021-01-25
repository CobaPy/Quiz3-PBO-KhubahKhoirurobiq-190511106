Public Class Login
    Private Sub btnLogin_Click_1(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        login_valid = oUser.Login(txtUsername.Text, txtPasswd.Text)
        If (login_valid = True) Then
            MessageBox.Show("Selamat Datang " & txtUsername.Text)
            Dashboard.Show()
            Me.Hide()
        Else
            MessageBox.Show("Login Not Valid")
        End If
    End Sub
End Class