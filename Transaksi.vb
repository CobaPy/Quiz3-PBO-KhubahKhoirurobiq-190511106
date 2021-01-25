Public Class Transaksi

    Private Sub getJenisMobil()
        oMobil.CariJenis()
        cbxJenisMobil.DataSource = Nothing
        cbxJenisMobil.Items.Clear()
        Dim Dj As DataTable = oMobil.dataJenis
        
        With cbxJenisMobil
            .DataSource = Dj
            .DisplayMember = "jenis"
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub getMerk(sjenis As String)
        oMobil.CariMerk(sjenis)
        cbxMerk.DataSource = Nothing
        cbxMerk.Items.Clear()
        Dim DM As DataTable = oMobil.dataMerk
        
        With cbxMerk
            .DataSource = DM
            .DisplayMember = "merk"
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub getNopol(sjenis As String, smerk As String)
        oMobil.CariNopol(sjenis, smerk)
        cbxNoPol.DataSource = Nothing
        cbxNoPol.Items.Clear()
        Dim DN As DataTable = oMobil.dataNopol

        With cbxNoPol
            .DataSource = DN
            .DisplayMember = "nopol"
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub UpdateStokMobil(ByVal ketersediaan As String)
        oMobil.UpdateStok(cbxNoPol.Text, ketersediaan)
    End Sub
    Private Sub cekTransaksi()
        oTransaksi.Caritransaksi(txtNoTransaksi.Text)
        If (transaksi_baru = False) Then
            txtNoKTP.Text = oTransaksi.no_ktp
            txtNamaLengkap.Text = oTransaksi.nama_lengkap
            txtNoTelpon.Text = oTransaksi.no_telp
            txtAlamat.Text = oTransaksi.alamat
            getJenisMobil()
            cbxJenisMobil.SelectedText = oTransaksi.jenis_mobil
            getMerk(cbxJenisMobil.Text)
            cbxMerk.SelectedText = oTransaksi.merk
            getNopol(cbxJenisMobil.Text, cbxMerk.Text)
            cbxNoPol.SelectedText = oTransaksi.nopol
            txtNamaMobil.Text = oTransaksi.nama_mobil
            txtSewa.Text = FormatCurrency(oTransaksi.harga_sewa)
            dtpAmbil.Value = oTransaksi.tgl_ambil
            dtpKembali.Value = oTransaksi.tgl_kembali
            txtTotalBiaya.Text = FormatCurrency(oTransaksi.total_biaya)
            If (oTransaksi.jk = "L") Then
                rbLakiLaki.Checked = True
            Else
                rbPerempuan.Checked = True
            End If

        Else
            MessageBox.Show("Data tidak ditemukan!")
        End If
    End Sub
    Private Sub Proses()
        If (txtNoTransaksi.Text <> "" And txtNoKTP.Text <> "" And txtNamaLengkap.Text <> "" And txtNoTelpon.Text <> "" And txtAlamat.Text <> "" And txtTotalBiaya.Text <> "" And (rbLakiLaki.Checked = True Or rbPerempuan.Checked = True)) Then
            oTransaksi.no_transaksi = txtNoTransaksi.Text
            oTransaksi.no_ktp = txtNoKTP.Text
            oTransaksi.nama_lengkap = txtNamaLengkap.Text
            oTransaksi.no_telp = txtNoTelpon.Text
            oTransaksi.alamat = txtAlamat.Text
            oTransaksi.jenis_mobil = cbxJenisMobil.Text
            oTransaksi.merk = cbxMerk.Text
            oTransaksi.nopol = cbxNoPol.Text
            oTransaksi.nama_mobil = txtNamaMobil.Text
            oTransaksi.harga_sewa = CDbl(txtSewa.Text)
            oTransaksi.tgl_ambil = dtpAmbil.Text
            oTransaksi.tgl_kembali = dtpKembali.Text
            oTransaksi.total_biaya = CDbl(txtTotalBiaya.Text)
            oTransaksi.pengembalian = "BELUM"
            If (rbLakiLaki.Checked) Then
                oTransaksi.jk = "L"
            ElseIf (rbPerempuan.Checked) Then
                oTransaksi.jk = "P"
            End If
            oTransaksi.Simpan()
            If (oTransaksi.InsertState = True) Then
                MessageBox.Show("Transaksi berhasil di proses!")
            ElseIf (oTransaksi.UpdateState = True) Then
                MessageBox.Show("Transaksi berhasil di Update!")
            End If
        Else
            MessageBox.Show("Lengkapi data dengan benar!")
        End If

    End Sub
    Private Sub ClearData()
        txtNoKTP.Clear()
        txtNamaLengkap.Clear()
        txtNoTelpon.Clear()
        txtAlamat.Clear()
        rbLakiLaki.Checked = False
        rbPerempuan.Checked = False
        cbxMerk.DataSource = Nothing
        cbxMerk.Items.Clear()
        cbxNoPol.DataSource = Nothing
        cbxNoPol.Items.Clear()
        getJenisMobil()
        LoadDashboardData()
        txtNamaMobil.Clear()
        txtSewa.Clear()
        dtpAmbil.Value = Now
        dtpKembali.Value = Now
        txtTotalBiaya.Clear()
        txtNoTransaksi.Text = getNomorTransaksi()
    End Sub
    Private Sub LoadDashboardData()
        oTransaksi.getDashboardData(DataGridView1)
    End Sub

    Private Sub btnHitung_Click(sender As System.Object, e As System.EventArgs) Handles btnHitung.Click
        Dim t As TimeSpan = dtpKembali.Value.Subtract(dtpAmbil.Value)
        Dim lamaSewa As String = t.Days + 1
        If (txtSewa.Text <> "") Then
            Dim totalBiaya As String = CDbl(lamaSewa) * CDbl(txtSewa.Text)
            txtTotalBiaya.Text = FormatCurrency(totalBiaya)
        End If
    End Sub

    Private Sub txtNoTransaksi_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNoTransaksi.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            cekTransaksi()
        End If
    End Sub

    Private Sub Transaksi_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("id-ID")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("id-ID")
        noTransaksi = getNomorTransaksi()
        txtNoTransaksi.Text = noTransaksi
        getJenisMobil()
        LoadDashboardData()
    End Sub

    Private Sub cbxJenisMobil_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxJenisMobil.SelectedIndexChanged
        cbxMerk.DataSource = Nothing
        cbxMerk.Items.Clear()
        cbxNoPol.DataSource = Nothing
        cbxNoPol.Items.Clear()
        txtNamaMobil.Clear()
        txtSewa.Clear()
        If (cbxJenisMobil.SelectedIndex = -1) Then

        Else
            getMerk(cbxJenisMobil.Text)
        End If
    End Sub

    Private Sub cbxMerk_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxMerk.SelectedIndexChanged
        cbxNoPol.DataSource = Nothing
        cbxNoPol.Items.Clear()
        txtNamaMobil.Clear()
        txtSewa.Clear()
        If (cbxMerk.SelectedIndex = -1) Then

        Else
            getNopol(cbxJenisMobil.Text, cbxMerk.Text)
        End If

    End Sub

    Private Sub cbxNoPol_SelectionChangeCommitted(sender As System.Object, e As System.EventArgs) Handles cbxNoPol.SelectionChangeCommitted
        oMobil.Carimobil(cbxNoPol.GetItemText(cbxNoPol.SelectedItem))
        txtNamaMobil.Text = oMobil.nama_mobil
        txtSewa.Text = FormatCurrency(oMobil.harga)
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        ClearData()

    End Sub

    Private Sub btnProses_Click(sender As System.Object, e As System.EventArgs) Handles btnProses.Click
        Proses()
        LoadDashboardData()
        UpdateStokMobil("Tidak Tersedia")
    End Sub

    Private Sub btnBatal_Click(sender As System.Object, e As System.EventArgs) Handles btnBatal.Click
        If (transaksi_baru = False) Then
            Dim result As DialogResult = MessageBox.Show("Apakah anda yakin ingin membatalkan transaksi ini?", "Perhatian!!!", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                MessageBox.Show("Transaksi dilanjutkan!")
            ElseIf result = DialogResult.Yes Then
                oTransaksi.Hapus(txtNoTransaksi.Text)
                UpdateStokMobil("Tersedia")
                If (oTransaksi.DeleteState = True) Then
                    MessageBox.Show("Transaksi telah dibatalkan.")
                    ClearData()
                End If
                LoadDashboardData()
            End If
        End If
    End Sub

    Private Sub btnPengembalian_Click(sender As System.Object, e As System.EventArgs) Handles btnPengembalian.Click
        noTransaksi = txtNoTransaksi.Text
        oTransaksi.Caritransaksi(txtNoTransaksi.Text)
        If (transaksi_baru = False) Then
            Pengembalian.ShowDialog()
        Else
            MessageBox.Show("Nomor transaksi tidak ditemukan!")
        End If

    End Sub


    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        DataGridView1.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

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

    Private Sub btnControlPengembalian_Click(sender As System.Object, e As System.EventArgs) Handles btnControlPengembalian.Click
        Pengembalian.ShowDialog()
    End Sub

    Private Sub ButtonItem8_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem8.Click
        Laporan.Show()
        Me.Hide()
    End Sub
End Class