Public Class TambahMerk
    Private Sub Simpan()
        oMerk.Carimerk(txtMerk.Text)
        If (merk_baru = False) Then
            txtMerk.Clear()
            MessageBox.Show("Merk Mobil Sudah ada!")
        Else
            oMerk.merk = txtMerk.Text
            oMerk.Simpan()
            If (oMerk.InsertState = True) Then
                MessageBox.Show("Data Berhasil Disimpan")
            End If
            txtMerk.Clear()
        End If
    End Sub
    Private Sub btnSimpan_Click(sender As System.Object, e As System.EventArgs) Handles btnSimpan.Click
        Simpan()
    End Sub

    Private Sub txtMerk_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMerk.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Simpan()
        End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub
End Class