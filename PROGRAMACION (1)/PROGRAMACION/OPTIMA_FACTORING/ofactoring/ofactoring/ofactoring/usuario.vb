Public Class usuario
    Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String, nom As String, clv As String, nv As String
    Dim res As Integer, det As String
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t4.Enabled = False
        t1.Enabled = True
        t1.Text = ""
        t2.Enabled = True
        t2.Text = ""
        cb1.Enabled = True
        cb1.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t1.Enabled = True
        t2.Enabled = True
        cb1.Enabled = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged

    End Sub
    Private Sub llenar_combo1()
        sql = "select *from areas"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "areas"
        cb1.ValueMember = "area"
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = InputBox("Ingrese el Codigo De Tipo Usuario de Sistema")
        sql = "exec ver_usuario '" + nc + "'"
        conectar()
        com = New SqlClient.SqlCommand(sql, conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t4.Text = dr(0)
            t1.Text = dr(1)
            t2.Text = dr(2)
            cb1.Text = dr(3)
        Else
            MessageBox.Show("El Usuario no Existe")
        End If
        dr.Close()
        conexion.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t4.Text
        res = MessageBox.Show("¿Desea Borrar el Usuario?", "usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_usuario '" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        cb1.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t2.Text = ""

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = t4.Text
        nom = UCase(t1.Text)
        clv = UCase(t2.Text)
        nv = UCase(cb1.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_usuario'" + nom + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo usuario ya existe", "usuario", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.Close()
            Else
                sql = "exec alta_usuario '" + nom + "','" + clv + "','" + nv + "'"
                conectar()
                com = New SqlClient.SqlCommand(sql, conexion)
                res = com.ExecuteNonQuery
                conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_usuario'" + nc + "','" + nom + "','" + clv + "','" + nv + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        cb1.Enabled = False

    End Sub




    Public Sub conectar()
        conexion = New SqlClient.SqlConnection
        conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
        conexion.Open()
    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_usuario"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_usuario")
        dgv.DataSource = ds
        dgv.DataMember = "v_usuario"
        conexion.Close()
    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        llenar_combo1()
        cb1.Text = ""
    End Sub
End Class