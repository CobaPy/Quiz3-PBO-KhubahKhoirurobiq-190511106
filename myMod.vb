Imports MySql.Data.MySqlClient
Module myMod
    Public myCommand As New MySqlCommand
    Public myAdapter As New MySqlDataAdapter
    Public myData As New DataTable
    Public DR As MySqlDataReader
    Public conn As New MySqlConnection
    

    'login
    Public oUser As New Users
    Public login_valid As Boolean = False
    Public users_baru As Boolean

    'mobil
    Public oMobil As New Mobil
    Public mobil_baru As Boolean

    'merk
    Public oMerk As New Merk
    Public merk_baru As Boolean
    'jenis mobil
    Public oJenis As New JenisMobil
    Public jenis_mobil_baru As Boolean

    'transaksi
    Public oTransaksi As New ClassTransaksi
    Public transaksi_baru As Boolean
    Public noTransaksi As Double
    Public R As Random = New Random


    Public Sub dbConnect()
        conn.ConnectionString = "server=localhost;" & "user id=root;" & "password='';" & "database=rentalmobil"
        Try
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If (conn.State = ConnectionState.Open) Then
            Else
                MessageBox.Show("Sorry not connected.")
            End If
        End Try
    End Sub
    Public Sub dbDisconnect()
        If (conn.State = ConnectionState.Open) Then
            conn.Close()
            conn.Dispose()
        End If
    End Sub
    Public Function getMD5Hash(ByVal strToHash As String) As String
        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        Dim b As Byte
        For Each b In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function
    Public Function getNomorTransaksi()
        Dim res As Double
        res = R.Next(1000000, 9999999)
        Return res
    End Function
End Module
