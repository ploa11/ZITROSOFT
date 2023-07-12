Public Class disitrito
    Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String
    Dim res As Integer, det As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "editar"
        t2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nc = InputBox("Ingrese el Codigo De Distrito")
        sql = "exec ver_dist '" + nc + "'"
        conectar()
        com = New SqlClient.SqlCommand(sql, conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
        Else
            MessageBox.Show("El Distrito no Existe")
        End If
        dr.Close()
        conexion.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        det = UCase(t2.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_dist'" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de Distrito ya existe", "distrito", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.Close()
            Else
                sql = "exec alta_dist '" + det + "'"
                conectar()
                com = New SqlClient.SqlCommand(sql, conexion)
                res = com.ExecuteNonQuery
                conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_dist'" + nc + "','" + det + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        clientes.llenar_combo3()
        t1.Enabled = False
        t2.Enabled = False

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar El Distrito", "distrito", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_dist '" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        clientes.llenar_combo3()
        t1.Enabled = False
        t2.Enabled = False
        t1.Text = ""
        t2.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t1.Enabled = False
        t1.Text = ""
        t2.Enabled = True
        t2.Text = ""
    End Sub

    Dim ds As DataSet

    Public Sub conectar()
        conexion = New SqlClient.SqlConnection
        conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
        conexion.Open()
    End Sub

    Private Sub llenar_grid()
        sql = "select * from v_distrito"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_distrito")
        dgv.DataSource = ds
        dgv.DataMember = "v_distrito"
        conexion.Close()
    End Sub
    Private Sub tcliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        clientes.llenar_combo3()

    End Sub
End Class