Public Class area
    'Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String, sql2 As String, area As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t2.Enabled = True

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = InputBox("Ingrese el Codigo Area a buscar")
        sql = "exec ver_area '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
        Else
            MessageBox.Show("El Area no Existe")
        End If
        dr.Close()
        conexion.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar el Area?", "areas", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_area '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False

        t1.Text = ""
        t2.Text = ""

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = t1.Text
        area = UCase(t2.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_area'" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo area ya existe", "areas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.Close()
            Else
                sql = "exec alta_area '" + area + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_area'" + nc + "','" + area + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False


    End Sub

    Dim res As Integer, det As String, sa As String

    Private Sub area_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
    End Sub

    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader, dr2 As SqlClient.SqlDataAdapter
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet

    'Public Sub conectar()
    '   conexion = New SqlClient.SqlConnection
    '   conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    '   conexion.Open()
    ' End Sub
    Private Sub llenar_grid()
        sql = "select * from v_area"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_area")
        dgv.DataSource = ds
        dgv.DataMember = "v_area"
        conexion.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t1.Enabled = False
        t2.Enabled = True
        t2.Text = ""

    End Sub
End Class