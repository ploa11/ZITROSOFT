Public Class reg_bancos
    Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String
    Dim res As Integer, tc As String, td As String, nd As String, ce As String
    Dim ncome, rsoc, tipdoc, ndoc As String
    Dim pass As String, telef As String, anx As String, nom As String, app As String, apm As String
    Dim m1, m2, ent, fecha, hora As String

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea borrar los Datos?", "reg_bancos", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_rbancos '" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        cb1.Enabled = False
        t4.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        cb1.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        cb1.Enabled = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = InputBox("Ingrese Codigo, Ruc o Razon Social de Banco")


        sql = "exec ver_rbancoa '" + nc + "'"
        conectar()
        com = New SqlClient.SqlCommand(sql, conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            cb1.Text = dr(3)
            t4.Text = dr(4)


        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        conexion.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = t1.Text
        ncome = UCase(t2.Text)
        rsoc = UCase(t3.Text)
        tipdoc = UCase(cb1.Text)
        ndoc = UCase(t4.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_rbancoa'" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "reg_bancos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.Close()
            Else
                sql = "exec alta_rbancos '" + ncome + "','" + rsoc + "','" + tipdoc + "','" + ndoc + "'"
                conectar()
                com = New SqlClient.SqlCommand(sql, conexion)
                res = com.ExecuteNonQuery
                conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_rbancos'" + nc + "','" + ncome + "','" + rsoc + "','" + tipdoc + "','" + ndoc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        regcuentabanco.llenar_combo2()
        t1.Enabled = False
        t2.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t1.Enabled = False
        t1.Text = ""
        t2.Enabled = True
        t2.Text = ""
        t3.Enabled = True
        t3.Text = ""
        t4.Enabled = True
        t4.Text = ""
        cb1.Enabled = True
        cb1.Text = ""

    End Sub

    Dim tvsu, tcsu, tvsbs, tcsbs As String
    Dim fe As Date
    Dim hr As TimeSpan
    Dim hrr As Date
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Public Sub conectar()
        conexion = New SqlClient.SqlConnection
        conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
        conexion.Open()
    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_reg_bancos"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_reg_bancos")
        dgv.DataSource = ds
        dgv.DataMember = "v_reg_bancos"
        conexion.Close()
    End Sub
    Private Sub llenar_combo1()
        sql = "select *from tipdoc"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "tipdoc"
        cb1.ValueMember = "detalle"
    End Sub

    Private Sub reg_bancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combo1()
        llenar_grid()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class