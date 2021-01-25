Public Class Dashboard
    Private Sub LoadDashboardData()
        oTransaksi.getDashboardData(DataGridView1)
    End Sub

    Private Sub btnUsers_Click(sender As System.Object, e As System.EventArgs) Handles btnUsers.Click
        AddUser.ShowDialog()
    End Sub

    Private Sub btnMobil_Click(sender As System.Object, e As System.EventArgs) Handles btnMobil.Click
        DataMobil.ShowDialog()
    End Sub

    Private Sub Dashboard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadDashboardData()
        oMobil.CekKetersediaan()
        lblKetersediaan.Text = oMobil.dataKetersediaan
        oTransaksi.CekTransaksiAktif()
        lblTransaksiAktif.Text = oTransaksi.transaksiAktif
    End Sub

    Private Sub bntSewa_Click(sender As System.Object, e As System.EventArgs) Handles bntSewa.Click
        Transaksi.Show()
        Me.Hide()
    End Sub

    Private Sub btnPengembalian_Click(sender As System.Object, e As System.EventArgs) Handles btnPengembalian.Click
        Pengembalian.ShowDialog()
    End Sub

    Private Sub btnJenisMobil_Click(sender As System.Object, e As System.EventArgs) Handles btnJenisMobil.Click
        TambahJenisMobil.ShowDialog()
    End Sub

    Private Sub btnMerk_Click(sender As System.Object, e As System.EventArgs) Handles btnMerk.Click
        TambahMerk.ShowDialog()
    End Sub

    Private Sub ButtonItem8_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem8.Click
        Laporan.Show()
        Me.Hide()
    End Sub

    Private Sub btnControlSewa_Click(sender As System.Object, e As System.EventArgs) Handles btnControlSewa.Click
        Transaksi.Show()
        Me.Hide()
    End Sub

    Private Sub btnControlPengembalian_Click(sender As System.Object, e As System.EventArgs) Handles btnControlPengembalian.Click
        Pengembalian.ShowDialog()
    End Sub
End Class