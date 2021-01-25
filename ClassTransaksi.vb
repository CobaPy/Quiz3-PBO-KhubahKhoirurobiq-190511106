Public Class ClassTransaksi
    Dim strsql As String
    Dim info As String
    Private _idtransaksi As Integer
    Private _no_transaksi As String
    Private _no_ktp As String
    Private _nama_lengkap As String
    Private _jk As String
    Private _no_telp As String
    Private _alamat As String
    Private _jenis_mobil As String
    Private _merk As String
    Private _nopol As String
    Private _nama_mobil As String
    Private _harga_sewa As System.Double
    Private _tgl_ambil As String
    Private _tgl_kembali As String
    Private _tgl_pengembalian As String
    Private _total_biaya As System.Double
    Private _pengembalian As String
    Private _denda As System.Double
    Public transaksiAktif As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property no_transaksi()
        Get
            Return _no_transaksi
        End Get
        Set(ByVal value)
            _no_transaksi = value
        End Set
    End Property
    Public Property no_ktp()
        Get
            Return _no_ktp
        End Get
        Set(ByVal value)
            _no_ktp = value
        End Set
    End Property
    Public Property nama_lengkap()
        Get
            Return _nama_lengkap
        End Get
        Set(ByVal value)
            _nama_lengkap = value
        End Set
    End Property
    Public Property jk()
        Get
            Return _jk
        End Get
        Set(ByVal value)
            _jk = value
        End Set
    End Property
    Public Property no_telp()
        Get
            Return _no_telp
        End Get
        Set(ByVal value)
            _no_telp = value
        End Set
    End Property
    Public Property alamat()
        Get
            Return _alamat
        End Get
        Set(ByVal value)
            _alamat = value
        End Set
    End Property
    Public Property jenis_mobil()
        Get
            Return _jenis_mobil
        End Get
        Set(ByVal value)
            _jenis_mobil = value
        End Set
    End Property
    Public Property merk()
        Get
            Return _merk
        End Get
        Set(ByVal value)
            _merk = value
        End Set
    End Property
    Public Property nopol()
        Get
            Return _nopol
        End Get
        Set(ByVal value)
            _nopol = value
        End Set
    End Property
    Public Property nama_mobil()
        Get
            Return _nama_mobil
        End Get
        Set(ByVal value)
            _nama_mobil = value
        End Set
    End Property
    Public Property harga_sewa()
        Get
            Return _harga_sewa
        End Get
        Set(ByVal value)
            _harga_sewa = value
        End Set
    End Property
    Public Property tgl_ambil()
        Get
            Return _tgl_ambil
        End Get
        Set(ByVal value)
            _tgl_ambil = value
        End Set
    End Property
    Public Property tgl_kembali()
        Get
            Return _tgl_kembali
        End Get
        Set(ByVal value)
            _tgl_kembali = value
        End Set
    End Property
    Public Property tgl_pengembalian()
        Get
            Return _tgl_pengembalian
        End Get
        Set(ByVal value)
            _tgl_pengembalian = value
        End Set
    End Property
    Public Property total_biaya()
        Get
            Return _total_biaya
        End Get
        Set(ByVal value)
            _total_biaya = value
        End Set
    End Property
    Public Property pengembalian()
        Get
            Return _pengembalian
        End Get
        Set(ByVal value)
            _pengembalian = value
        End Set
    End Property
    Public Property denda()
        Get
            Return _denda
        End Get
        Set(ByVal value)
            _denda = value
        End Set
    End Property
    Public Sub CekTransaksiAktif()
        dbConnect()
        strsql = "SELECT COUNT(pengembalian) FROM transaksi WHERE pengembalian = '" & "BELUM" & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        transaksiAktif = myCommand.ExecuteScalar().ToString()
        dbDisconnect()
    End Sub
    Public Sub UpdatePengembalian(ByVal uNoTrans As String, ByVal tgl_pengembalian As String, ByVal denda As Double, ByVal status As String)
        dbConnect()
        strsql = "update transaksi set pengembalian='" & status & "', tgl_pengembalian='" & tgl_pengembalian & "', denda='" & denda & "' where no_transaksi='" & uNoTrans & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        myCommand.ExecuteNonQuery()
        dbDisconnect()
    End Sub
        Public Sub Simpan()
        Dim info As String
            DBConnect()
        If (transaksi_baru = True) Then
            strsql = "Insert into transaksi(no_transaksi,no_ktp,nama_lengkap,jk,no_telp,alamat,jenis_mobil,merk,nopol,nama_mobil,harga_sewa,tgl_ambil,tgl_kembali,tgl_pengembalian,total_biaya,pengembalian,denda) values ('" & _no_transaksi & "','" & _no_ktp & "','" & _nama_lengkap & "','" & _jk & "','" & _no_telp & "','" & _alamat & "','" & _jenis_mobil & "','" & _merk & "','" & _nopol & "','" & _nama_mobil & "','" & _harga_sewa & "','" & _tgl_ambil & "','" & _tgl_kembali & "','" & _tgl_pengembalian & "','" & _total_biaya & "','" & _pengembalian & "','" & _denda & "')"
            info = "INSERT"
        Else
            strsql = "update transaksi set no_transaksi='" & _no_transaksi & "', no_ktp='" & _no_ktp & "', nama_lengkap='" & _nama_lengkap & "', jk='" & _jk & "', no_telp='" & _no_telp & "', alamat='" & _alamat & "', jenis_mobil='" & _jenis_mobil & "', merk='" & _merk & "', nopol='" & _nopol & "', nama_mobil='" & _nama_mobil & "', harga_sewa='" & _harga_sewa & "', tgl_ambil='" & _tgl_ambil & "', tgl_kembali='" & _tgl_kembali & "', tgl_pengembalian='" & _tgl_pengembalian & "', total_biaya='" & _total_biaya & "', pengembalian='" & _pengembalian & "', denda='" & _denda & "' where no_transaksi='" & _no_transaksi & "'"
            info = "UPDATE"
        End If
        myCommand.Connection = conn
        myCommand.CommandText = strsql
            Try
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                If (info = "INSERT") Then
                    InsertState = False
                ElseIf (info = "UPDATE") Then
                    UpdateState = False
                Else
                End If
            Finally
                If (info = "INSERT") Then
                    InsertState = True
                ElseIf (info = "UPDATE") Then
                    UpdateState = True
                Else
                End If
            End Try
            DBDisconnect()
        End Sub
        Public Sub Caritransaksi(ByVal sno_transaksi As String)
            DBConnect()
            strsql = "SELECT * FROM transaksi WHERE no_transaksi='" & sno_transaksi & "'"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            DR = myCommand.ExecuteReader
            If (DR.HasRows = True) Then
                transaksi_baru = False
                DR.Read()
                no_transaksi = Convert.ToString((DR("no_transaksi")))
                no_ktp = Convert.ToString((DR("no_ktp")))
                nama_lengkap = Convert.ToString((DR("nama_lengkap")))
                jk = Convert.ToString((DR("jk")))
                no_telp = Convert.ToString((DR("no_telp")))
                alamat = Convert.ToString((DR("alamat")))
                jenis_mobil = Convert.ToString((DR("jenis_mobil")))
                merk = Convert.ToString((DR("merk")))
                nopol = Convert.ToString((DR("nopol")))
                nama_mobil = Convert.ToString((DR("nama_mobil")))
                harga_sewa = Convert.ToString((DR("harga_sewa")))
                tgl_ambil = Convert.ToString((DR("tgl_ambil")))
                tgl_kembali = Convert.ToString((DR("tgl_kembali")))
                total_biaya = Convert.ToString((DR("total_biaya")))
                pengembalian = Convert.ToString((DR("pengembalian")))
            Else
                MessageBox.Show("Data Tidak Ditemukan.")
                transaksi_baru = True
            End If
            DBDisconnect()
        End Sub
        Public Sub Hapus(ByVal sno_transaksi As String)
            Dim info As String
            DBConnect()
            strsql = "DELETE FROM transaksi WHERE no_transaksi='" & sno_transaksi & "'"
            info = "DELETE"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            Try
                myCommand.ExecuteNonQuery()
                DeleteState = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            DBDisconnect()
    End Sub
    Public Sub getDashboardData(ByVal dg As DataGridView)
        Try
            dbConnect()
            strsql = "SELECT no_transaksi, nama_lengkap, nopol, tgl_ambil, tgl_kembali, pengembalian FROM transaksi"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .Columns("no_transaksi").HeaderText = "Nomor Transaksi"
                .Columns("nama_lengkap").HeaderText = "Nama Penyewa"
                .Columns("nopol").HeaderText = "Nomor TNKB"
                .Columns("tgl_ambil").HeaderText = "Tanggal Ambil"
                .Columns("tgl_kembali").HeaderText = "Perkiraan Kembali"
                .Columns("pengembalian").HeaderText = "Status Pengembalian"
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            dbDisconnect()
        End Try
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM transaksi"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            myData.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)
            With dg
                .DataSource = myData
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class
