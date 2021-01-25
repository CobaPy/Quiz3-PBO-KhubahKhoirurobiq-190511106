Public Class Laporan


    Private Sub btnHome_Click(sender As System.Object, e As System.EventArgs) Handles btnHome.Click
        Dashboard.Show()
        Me.Hide()
    End Sub

    Private Sub btnUsers_Click(sender As System.Object, e As System.EventArgs) Handles btnUsers.Click
        AddUser.ShowDialog()
    End Sub

    Private Sub btnMobil_Click(sender As System.Object, e As System.EventArgs) Handles btnMobil.Click
        DataMobil.ShowDialog()
    End Sub

    Private Sub btnJenisMobil_Click(sender As System.Object, e As System.EventArgs) Handles btnJenisMobil.Click
        TambahJenisMobil.ShowDialog()
    End Sub

    Private Sub btnMerk_Click(sender As System.Object, e As System.EventArgs) Handles btnMerk.Click
        TambahMerk.ShowDialog()
    End Sub

    Private Sub btnControlSewa_Click(sender As System.Object, e As System.EventArgs) Handles btnControlSewa.Click
        Transaksi.Show()
        Me.Hide()
    End Sub

    Private Sub btnControlPengembalian_Click(sender As System.Object, e As System.EventArgs) Handles btnControlPengembalian.Click
        Pengembalian.ShowDialog()
    End Sub

    Private Sub Laporan_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'rentalmobilDataSet.transaksi' table. You can move, or remove it, as needed.
        Me.transaksiTableAdapter.Fill(Me.rentalmobilDataSet.transaksi)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnReload_Click(sender As System.Object, e As System.EventArgs) Handles btnReload.Click
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class