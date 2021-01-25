Public Class Pengembalian
    Private Sub CekTransaksi()

        oTransaksi.Caritransaksi(txtNoTransaksi.Text)
        txtNamaPenyewa.Text = oTransaksi.nama_lengkap
        dtpRencanaKembali.Value = oTransaksi.tgl_kembali
        cbxStatusPengembalian.SelectedIndex = cbxStatusPengembalian.FindString(oTransaksi.pengembalian)
    End Sub
    Private Sub Pengembalian_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtNoTransaksi.Text = noTransaksi
    End Sub

    Private Sub txtNoTransaksi_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNoTransaksi.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            cekTransaksi()
        End If
    End Sub

    Private Sub dtpPengembalian_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpPengembalian.ValueChanged
        Dim t As TimeSpan = dtpPengembalian.Value.Subtract(dtpRencanaKembali.Value)
        txtTerlambat.Text = t.Days
        txtDenda.Text = CDbl(txtTerlambat.Text) * CDbl(oTransaksi.harga_sewa)
    End Sub

    Private Sub btnSelesai_Click(sender As System.Object, e As System.EventArgs) Handles btnSelesai.Click
        Dim result As DialogResult = MessageBox.Show("Apakah transaksi sudah Lunas dan Mobil telah dikembalikan?", "Perhatian!!!", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("Lunasi tagihan dan kembalikan mobil!")
        ElseIf result = DialogResult.Yes Then
            If (cbxStatusPengembalian.Text <> "") Then
                oTransaksi.UpdatePengembalian(txtNoTransaksi.Text, dtpPengembalian.Text, txtDenda.Text, cbxStatusPengembalian.Text)
                oMobil.UpdateStok(oTransaksi.nopol, "Tersedia")
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Me.Dispose()
    End Sub
End Class