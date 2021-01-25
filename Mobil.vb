Public Class Mobil
    Dim strsql As String
    Dim info As String
    Private _idmobil As Integer
    Private _jenis As String
    Private _nopol As String
    Private _nama_mobil As String
    Private _merk As String
    Private _harga As System.Double
    Private _ketersediaan As String
    Public dataKetersediaan As String
    Public dataMerk As New DataTable
    Public dataNopol As New DataTable
    Public dataJenis As New DataTable
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property jenis()
        Get
            Return _jenis
        End Get
        Set(ByVal value)
            _jenis = value
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
    Public Property merk()
        Get
            Return _merk
        End Get
        Set(ByVal value)
            _merk = value
        End Set
    End Property
    Public Property harga()
        Get
            Return _harga
        End Get
        Set(ByVal value)
            _harga = value
        End Set
    End Property
    Public Property ketersediaan()
        Get
            Return _ketersediaan
        End Get
        Set(ByVal value)
            _ketersediaan = value
        End Set
    End Property
    Public Sub CekKetersediaan()
        dbConnect()
        strsql = "SELECT COUNT(ketersediaan) FROM mobil WHERE ketersediaan = '" & "Tersedia" & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        dataKetersediaan = myCommand.ExecuteScalar().ToString()
        dbDisconnect()
    End Sub
    Public Sub CariJenis()
        dbConnect()
        dataJenis.Clear()
        strsql = "SELECT Distinct jenis from mobil WHERE ketersediaan ='" & "Tersedia" & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(dataJenis)
        dbDisconnect()
    End Sub
    Public Sub CariMerk(ByVal sjenis As String)
        dbConnect()
        dataMerk.Clear()
        strsql = "SELECT Distinct merk from mobil WHERE jenis ='" & sjenis & "'" & " And ketersediaan = '" & "tersedia" & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(dataMerk)
        dbDisconnect()
    End Sub
    Public Sub CariNopol(ByVal sjenis As String, ByVal smerk As String)
        dbConnect()
        dataNopol.Clear()
        strsql = "SELECT nopol from mobil WHERE jenis = '" & sjenis & "'" & " And merk = '" & smerk & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(dataNopol)
        dbDisconnect()
    End Sub
    Public Sub UpdateStok(ByVal snopol As String, ByVal ketersediaan As String)
        dbConnect()
        strsql = "update mobil set ketersediaan='" & ketersediaan & "' where nopol='" & snopol & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        myCommand.ExecuteNonQuery()
        dbDisconnect()
    End Sub
    Public Sub Simpan()
        Dim info As String
        dbConnect()
        If (mobil_baru = True) Then
            strsql = "Insert into mobil(jenis,nopol,nama_mobil,merk,harga,ketersediaan) values ('" & _jenis & "','" & _nopol & "','" & _nama_mobil & "','" & _merk & "','" & _harga & "','" & _ketersediaan & "')"
            info = "INSERT"
        Else
            strsql = "update mobil set jenis='" & _jenis & "', nopol='" & _nopol & "', nama_mobil='" & _nama_mobil & "', merk='" & _merk & "', harga='" & _harga & "', ketersediaan='" & _ketersediaan & "' where jenis='" & _jenis & "'"
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
        dbDisconnect()
    End Sub
    Public Sub Carimobil(ByVal snopol As String)
        dbConnect()
        strsql = "SELECT * FROM mobil WHERE nopol='" & snopol & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            mobil_baru = False
            DR.Read()
            jenis = Convert.ToString((DR("jenis")))
            nopol = Convert.ToString((DR("nopol")))
            nama_mobil = Convert.ToString((DR("nama_mobil")))
            merk = Convert.ToString((DR("merk")))
            harga = Convert.ToString((DR("harga")))
            ketersediaan = Convert.ToString((DR("ketersediaan")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            mobil_baru = True
        End If
        dbDisconnect()
    End Sub
    Public Sub Hapus(ByVal snopol As String)
        Dim info As String
        dbConnect()
        strsql = "DELETE FROM mobil WHERE nopol='" & snopol & "'"
        info = "DELETE"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        Try
            myCommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        dbDisconnect()
    End Sub
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM mobil"
            myCommand.Connection = conn
            myCommand.CommandText = strsql
            Dim dataMobil As New DataTable
            dataMobil.Clear()
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(dataMobil)
            With dg
                .DataSource = dataMobil
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub
End Class
