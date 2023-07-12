Public Class distribu_benefi
    'varibales locales
    Dim accion, nc, distr, n_dist, gest, sql As String
    'variable para llenar combos y dgv
    Dim res As Integer, det As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim dt As DataTable
    Dim ds As DataSet


    Private Sub distribu_benefi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        llenar_combo1()

    End Sub

    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t2.Enabled = True
        t3.Enabled = True
        cb1.Enabled = True
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        cb1.Text = ""


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = UCase(t1.Text)
        distr = UCase(t2.Text)
        n_dist = t3.Text
        gest = cb1.Text
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_dist_beneficio'" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de Distribucion de Beneficio ya existe", "dist_beneficio", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_dist_beneficio '" + distr + "','" + n_dist + "','" + gest + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_dest_beneficio'" + nc + "','" + distr + "','" + n_dist + "','" + gest + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        cb1.Text = ""
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        cb1.Enabled = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = InputBox("Ingrese el Codigo ")
        sql = "exec ver_dist_beneficio '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            cb1.Text = dr(3)

        Else
            MessageBox.Show("El codigo no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t2.Enabled = True
        t3.Enabled = True
        cb1.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar los datos", "Distribucion de Beneficios", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_dist_beneficio '" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        cb1.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        cb1.Text = ""
    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_dist_beneficio"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_dist_beneficio")
        dgv.DataSource = ds
        dgv.DataMember = "v_dist_beneficio"
        conexion.conexion2.Close()
    End Sub

    Public Sub llenar_combo1()
        sql = "select *from gestio_bdp"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "gestio_bdp"
        cb1.ValueMember = "gestion"
    End Sub

End Class