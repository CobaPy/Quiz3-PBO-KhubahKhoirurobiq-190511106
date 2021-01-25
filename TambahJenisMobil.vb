Public Class TambahJenisMobil
    Private Sub Simpan()
        oJenis.Carijenis_mobil(txtJenisMobil.Text)
        If (jenis_mobil_baru = False) Then
            txtJenisMobil.Clear()
            MessageBox.Show("Jenis Mobil Sudah ada!")
        Else
            oJenis.jenis = txtJenisMobil.Text
            oJenis.Simpan()
            If (oJenis.InsertState = True) Then
                MessageBox.Show("Data Berhasil Disimpan")
            End If
            txtJenisMobil.Clear()
        End If
    End Sub
    Private Sub btnSimpan_Click(sender As System.Object, e As System.EventArgs) Handles btnSimpan.Click
        Simpan()
    End Sub

    Private Sub txtJenisMobil_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtJenisMobil.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Simpan()
        End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub
End Class