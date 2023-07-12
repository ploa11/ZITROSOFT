Module Conexiones
    Public Conexion As OleDb.OleDbConnection

    Public Sub AbrirConexion()
        Conexion = New OleDb.OleDbConnection
        Conexion.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=basedatos.accdb;"
        Conexion.Open()

    End Sub

End Module
