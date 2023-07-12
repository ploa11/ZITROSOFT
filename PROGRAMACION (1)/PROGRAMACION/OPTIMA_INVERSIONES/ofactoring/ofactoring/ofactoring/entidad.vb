Public Class Entidad

    Dim _enabledCerrar As Boolean = False
    <System.ComponentModel.DefaultValue(False), System.ComponentModel.Description("Define si se habilita el botón cerrar en el formulario")>
    Public Property EnabledCerrar() As Boolean
        Get
            Return _enabledCerrar
        End Get
        Set(ByVal Value As Boolean)
            If _enabledCerrar <> Value Then
                _enabledCerrar = Value
            End If
        End Set
    End Property
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            If _enabledCerrar = False Then
                Const CS_NOCLOSE As Integer = &H200
                cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            End If
            Return cp
        End Get
    End Property
    ' Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String, sql2 As String, area As String
    Dim res As Integer, det As String, sa As String

    'Public Sub conectar()
    'conexion = New SqlClient.SqlConnection
    'conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    'conexion.Open()
    'End Sub
    Private Sub llenar_grid()
        sql = "select * from v_entidad"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_entidad")
        dgv.DataSource = ds
        dgv.DataMember = "v_entidad"
        conexion.conexion.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = t1.Text
        area = UCase(t2.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_entidad'" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo area ya existe", "entidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion.Close()
            Else
                sql = "exec alta_entidad '" + area + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_entidad'" + nc + "','" + area + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar la Entidad?", "entidad", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_entidad '" + nc + "'"
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

    Private Sub Entidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = InputBox("Ingrese el Codigo Entidad a buscar")
        sql = "exec ver_entidad '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
        Else
            MessageBox.Show("La entidad no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t2.Enabled = True
    End Sub

    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader, dr2 As SqlClient.SqlDataAdapter
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t1.Enabled = False
        t2.Enabled = True
        t2.Text = ""
    End Sub
End Class