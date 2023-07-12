'modulo realizado por: Pedro Ortiz A.
'modulo para la creacion de tipo de clientes
'las variables a usar son accion, nc,sql,res, det, com,dr, da, cb
Public Class tcliente
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
        nc = InputBox("Ingrese el Codigo De Tipo de Cliente")
        sql = "exec ver_tipcliente '" + nc + "'"
        conectar()
        com = New SqlClient.SqlCommand(sql, conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
        Else
            MessageBox.Show("El Tipo de cliente no Existe")
        End If
        dr.Close()
        conexion.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        det = UCase(t2.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_tipcliente'" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo tipo de cliente ya existe", "tipcliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.Close()
            Else
                sql = "exec alta_tipcliente '" + det + "'"
                conectar()
                com = New SqlClient.SqlCommand(sql, conexion)
                res = com.ExecuteNonQuery
                conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_tipcliente'" + nc + "','" + det + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        clientes.llenar_combo1()
        t1.Enabled = False
        t2.Enabled = False

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar el Tipo de cliente?", "tip_cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_tipcliente '" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        clientes.llenar_combo1()
        t1.Enabled = False
        t2.Enabled = False
        t1.Text = ""
        t2.Text = ""
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

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
        sql = "select * from v_tipcliente"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_tipcliente")
        dgv.DataSource = ds
        dgv.DataMember = "v_tipcliente"
        conexion.Close()
    End Sub
    Private Sub tcliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        clientes.llenar_combo1()

    End Sub
End Class