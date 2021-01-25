Public Class DataMobil
    
    Private Sub cekNopol()
        oMobil.Carimobil(txtNopol.Text)
        If (mobil_baru = False) Then
            cbxJenisMobil.SelectedIndex = cbxJenisMobil.FindString(oMobil.jenis)
            cbxMerk.SelectedIndex = cbxMerk.FindString(oMobil.merk)
            txtNamaMobil.Text = oMobil.nama_mobil
            txtHargaSewa.Text = oMobil.harga
            cbxKetersediaan.SelectedItem = oMobil.ketersediaan
        Else
            MessageBox.Show("Data tidak ditemukan!")
        End If
    End Sub
    Private Sub Simpan()
        oMobil.nopol = txtNopol.Text
        oMobil.jenis = cbxJenisMobil.Text
        oMobil.merk = cbxMerk.Text
        oMobil.nama_mobil = txtNamaMobil.Text
        oMobil.harga = txtHargaSewa.Text
        oMobil.ketersediaan = cbxKetersediaan.Text
        oMobil.Simpan()
    End Sub
    Private Sub getMerk()
        oMerk.getMerk()
        cbxMerk.DataSource = Nothing
        cbxMerk.Items.Clear()
        Dim DM As DataTable = oMerk.dataMerk
        Dim dr As DataRow = DM.NewRow
        dr(0) = "  "
        DM.Rows.InsertAt(dr, 0)
        Dim ds As DataRow = DM.NewRow
        ds(0) = "<Tambah Merk>"
        DM.Rows.Add(ds)
        With cbxMerk
            .DataSource = DM
            .DisplayMember = "merk"
            .SelectedIndex = 0
        End With

    End Sub

    Private Sub getJenisMobil()
        oJenis.getJenis()
        cbxJenisMobil.DataSource = Nothing
        cbxJenisMobil.Items.Clear()
        Dim Dj As DataTable = oJenis.dataJenis
        Dim dr As DataRow = Dj.NewRow
        dr(0) = "  "
        Dj.Rows.InsertAt(dr, 0)
        Dim ds As DataRow = Dj.NewRow
        ds(0) = "<Tambah Jenis Mobil>"
        Dj.Rows.Add(ds)
        With cbxJenisMobil
            .DataSource = Dj
            .DisplayMember = "jenis"
            .SelectedIndex = 0
        End With
    End Sub
    Private Sub clearData()
        txtNopol.Clear()
        cbxJenisMobil.SelectedIndex = 0
        cbxMerk.SelectedIndex = 0
        txtNamaMobil.Clear()
        txtHargaSewa.Clear()
        cbxKetersediaan.SelectedIndex = -1
    End Sub
    Private Sub Reload()
        oMobil.getAllData(DataGridView1)
    End Sub

    Private Sub DataMobil_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        getMerk()
        getJenisMobil()
        Reload()
    End Sub

    Private Sub txtNopol_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNopol.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            cekNopol()
        End If
    End Sub


    Private Sub btnSimpan_Click(sender As System.Object, e As System.EventArgs) Handles btnSimpan.Click
        Simpan()
        Reload()
    End Sub

    Private Sub btnHapus_Click(sender As System.Object, e As System.EventArgs) Handles btnHapus.Click
        oMobil.Hapus(txtNopol.Text)
        Reload()
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        clearData()
        Refresh()
    End Sub

    Private Sub cbxJenisMobil_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxJenisMobil.SelectedIndexChanged
        If (cbxJenisMobil.Text = "<Tambah Jenis Mobil>") Then
            TambahJenisMobil.ShowDialog()
            If (DialogResult.OK) Then
                getJenisMobil()
            End If
        End If

        
    End Sub

    Private Sub cbxMerk_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbxMerk.SelectedIndexChanged
        If (cbxMerk.Text = "<Tambah Merk>") Then
            TambahMerk.ShowDialog()
            If (DialogResult.OK) Then
                getMerk()
            End If
        End If
    End Sub

    Private Sub btnJenisMobil_Click(sender As System.Object, e As System.EventArgs) Handles btnJenisMobil.Click
        TambahJenisMobil.ShowDialog()
        If (DialogResult.OK) Then
            getJenisMobil()
        End If
    End Sub

    Private Sub btnMerk_Click(sender As System.Object, e As System.EventArgs) Handles btnMerk.Click
        TambahMerk.ShowDialog()
        If (DialogResult.OK) Then
            getMerk()
        End If
    End Sub
End Class