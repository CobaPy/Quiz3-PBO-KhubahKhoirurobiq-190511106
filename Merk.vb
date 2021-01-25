Public Class Merk
    Dim strsql As String
    Dim info As String
    Private _idmerk As Integer
    Private _merk As String
    Public dataMerk As New DataTable
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False
    Public Property merk()
        Get
            Return _merk
        End Get
        Set(ByVal value)
            _merk = value
        End Set
    End Property
    Public Sub getMerk()
        dbConnect()
        dataMerk.Clear()
        strsql = "Select merk From merk"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(dataMerk)
        dbDisconnect()
    End Sub
    Public Sub Simpan()
        Dim info As String
        DBConnect()
        If (merk_baru = True) Then
            strsql = "Insert into merk(merk) values ('" & _merk & "')"
            info = "INSERT"
        Else
            strsql = "update merk set merk='" & _merk & "' where merk='" & _merk & "'"
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
    Public Sub Carimerk(ByVal smerk As String)
        DBConnect()
        strsql = "SELECT * FROM merk WHERE merk='" & smerk & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            merk_baru = False
            DR.Read()
            merk = Convert.ToString((DR("merk")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            merk_baru = True
        End If
        DBDisconnect()
    End Sub
    Public Sub Hapus(ByVal smerk As String)
        Dim info As String
        DBConnect()
        strsql = "DELETE FROM merk WHERE merk='" & smerk & "'"
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
    Public Sub getAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "SELECT * FROM merk"
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
