Public Class registro_clientes
    'variables publicas
    Public cod_clie_bdp, nom_cliente, appat_clie, apmat_clie, tipodoc_clie, numdoc_clie, cali_finan As String

    'variable locales
    Dim sql, nc As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar El Cliente", "CLIENTES", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_reg_cliente '" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_reg_cliente '" + t1.Text + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
        Button3.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        nc = InputBox("Ingrese Datos de cliente")
        sql = "select *from v_reg_cliente where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTO]='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_reg_cliente where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTO]='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_reg_cliente where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTO]='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "editar"
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        Button8.Enabled = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        nc = TextBox1.Text
        sql = "select *from v_reg_cliente where NOMBRE like'" + nc + "%' or [APELLIDO PATERNO] like'" + nc + "%' or [NUMERO DE DOCUMENTO] like '" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_reg_cliente where NOMBRE like'" + nc + "%' or [APELLIDO PATERNO] like'" + nc + "%' or [NUMERO DE DOCUMENTO] like '" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_reg_cliente where NOMBRE like'" + nc + "%' or [APELLIDO PATERNO] like'" + nc + "%' or [NUMERO DE DOCUMENTO] like '" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Calificacion_de_Cliente.Show()
        Calificacion_de_Cliente.t2.Text = t1.Text
        Calificacion_de_Cliente.t3.Text = t3.Text
        Calificacion_de_Cliente.t4.Text = t4.Text
        Calificacion_de_Cliente.t5.Text = t5.Text
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        registro_de_cuentas_bancos.Show()
    End Sub

    Private Sub registro_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clientes.Button8_Click(sender, e)
        If cali_finan = "APROBADO" Then
            t2.Text = cod_clie_bdp
            t3.Text = nom_cliente
            t4.Text = appat_clie
            t5.Text = apmat_clie
            t6.Text = tipodoc_clie
            t7.Text = numdoc_clie
        Else
            MessageBox.Show("No se puede registrar como cliente por no tener un buen estado financiero")
        End If


    End Sub

    'variables locales
    Dim accion As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "guardar"
        t1.Text = ""
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        Button1.Enabled = True
        Button3.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button8.Enabled = True
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_reg_cliente'" + t1.Text + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de Cliente ya existe", "cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_reg_clientes '" + t2.Text + "','" + t3.Text + "','" + t4.Text + "','" + t5.Text + "','" + t6.Text + "','" + t7.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                Res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")


            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_reg_cliente '" + t1.Text + "','" + t2.Text + "','" + t3.Text + "','" + t4.Text + "','" + t5.Text + "','" + t6.Text + "','" + t7.Text + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If
        nc = t7.Text
        sql = "exec ver_reg_cliente '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
        llenar_grid()

    End Sub

    Public Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button3.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        nc = InputBox("Ingrese el Codigo de cliente", "Optima Inversiones")
        sql = "exec ver_reg_cliente '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            Anex_Cronog.t2.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub llenar_grid()
        sql = "select * from v_reg_cliente"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_reg_cliente")
        dgv.DataSource = ds
        dgv.DataMember = "v_reg_cliente"
        conexion.conexion2.Close()
    End Sub
End Class