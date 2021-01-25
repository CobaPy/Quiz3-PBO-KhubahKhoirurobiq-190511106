Public Class JenisMobil
    Dim strsql As String
    Dim info As String
    Private _idjenis As Integer
    Private _jenis As String
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
    Public Sub getJenis()
        dbConnect()
        dataJenis.Clear()
        strsql = "Select jenis From jenis_mobil"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(dataJenis)
        dbDisconnect()
    End Sub
    Public Sub Simpan()
        Dim info As String
        dbConnect()
        If (jenis_mobil_baru = True) Then
            strsql = "Insert into jenis_mobil(jenis) values ('" & _jenis & "')"
            info = "INSERT"
        Else
            strsql = "update jenis_mobil set jenis='" & _jenis & "' where jenis='" & _jenis & "'"
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
    Public Sub Carijenis_mobil(ByVal sjenis As String)
        dbConnect()
        strsql = "SELECT * FROM jenis_mobil WHERE jenis='" & sjenis & "'"
        myCommand.Connection = conn
        myCommand.CommandText = strsql
        DR = myCommand.ExecuteReader
        If (DR.HasRows = True) Then
            jenis_mobil_baru = False
            DR.Read()
            jenis = Convert.ToString((DR("jenis")))
        Else
            MessageBox.Show("Data Tidak Ditemukan.")
            jenis_mobil_baru = True
        End If
        dbDisconnect()
    End Sub
    Public Sub Hapus(ByVal sjenis As String)
        Dim info As String
        dbConnect()
        strsql = "DELETE FROM jenis_mobil WHERE jenis='" & sjenis & "'"
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
            dbConnect()
            strsql = "SELECT * FROM jenis_mobil"
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
            dbDisconnect()
        End Try
    End Sub
End Class
