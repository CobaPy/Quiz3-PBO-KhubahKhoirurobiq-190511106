Public Class AddUser
    Private Sub cekUsername()
        oUser.Cariusers(txtUsername.Text)
        If (users_baru = False) Then
            txtUsername.Clear()
            MessageBox.Show("Username telah digunakan. Silahkan ganti dengan username yang lain.")
        Else
            MessageBox.Show("Silahkan Lanjutkan proser Pendaftaran")
        End If
    End Sub
    Private Sub DaftarUser()
        oUser.username = txtUsername.Text
        oUser.nama_lengkap = txtNamaLengkap.Text
        oUser.passwd = getMD5Hash(txtPasswd.Text)
        If (users_baru = True) Then
            oUser.Simpan()
        Else
            MessageBox.Show("Silahkan Cek Ulang Username anda!")
        End If

        If (oUser.InsertState = True) Then
            MessageBox.Show("Pendaftaran Berhasil!")
            Login.Show()
            Me.Hide()
        Else
            MessageBox.Show("Pendaftaran Gagal!")
        End If
    End Sub
    Private Sub btnAddUser_Click(sender As System.Object, e As System.EventArgs) Handles btnAddUser.Click
        If (txtUsername.Text <> "" And txtNamaLengkap.Text <> "" And txtPasswd.Text <> "") Then
            DaftarUser()
        End If
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            cekUsername()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class