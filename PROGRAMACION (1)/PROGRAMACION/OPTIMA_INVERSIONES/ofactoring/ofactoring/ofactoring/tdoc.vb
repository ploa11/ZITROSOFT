Public Class tdoc
    ' Public conexion As SqlClient.SqlConnection
    'Dim auto As Integer = 0
    'Dim cdgo As String = "TDOC"
    'Dim codigo As String
    Dim cod As String
    Dim accion As String, nc As String, sql As String
    Dim res As Integer, det As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "editar"
        t2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nc = InputBox("Ingrese el Codigo De Documento")
        sql = "exec ver_tipdoc '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
        Else
            MessageBox.Show("El Tipo de Documento no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        det = UCase(t2.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_tipdoc'" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de Tipo de Documento ya existe", "tipdoc", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion.Close()
            Else
                sql = "exec alta_tipdoc '" + det + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_tipdoc'" + nc + "','" + det + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If

        llenar_grid()
        clientes.llenar_combo2()
        t1.Enabled = False
        t2.Enabled = False

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar el tipo de Documento", "tipdoc", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_tipdoc '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        clientes.llenar_combo2()
        t1.Enabled = False
        t2.Enabled = False
        t1.Text = ""
        t2.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t1.Enabled = False
        t1.Text = ""
        t1.Text = " "
        t2.Enabled = True
        t2.Text = ""
    End Sub

    Dim ds As DataSet

    'Public Sub conectar()
    ' conexion = New SqlClient.SqlConnection
    ' conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    ' conexion.Open()
    ' End Sub

    Private Sub llenar_grid()
        sql = "select * from tipdoc"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "tipdoc")
        dgv.DataSource = ds
        dgv.DataMember = "tipdoc"
        conexion.conexion.Close()
    End Sub
    Private Sub tcliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        clientes.llenar_combo2()

    End Sub
End Class