Public Class doc_compra

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
    'Public conexion As SqlClient.SqlConnection
    Dim cod As String
    Dim accion As String, nc As String, sql As String
    Dim res As Integer, det As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t2.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = InputBox("Ingrese el Codigo De Documento de Compra")
        sql = "exec ver_d_com '" + nc + "'"
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar el tipo de Documento de compra", "d_compra", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_dcom '" + nc + "'"
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        det = UCase(t2.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_d_com'" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de Tipo de Documento ya existe", "d_compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion.Close()
            Else
                sql = "exec alta_dcom '" + det + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_dcom'" + nc + "','" + det + "'"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t1.Enabled = False
        t1.Text = ""
        t2.Enabled = True
        t2.Text = ""
    End Sub

    Dim ds As DataSet
    'Public Sub conectar()
    'conexion = New SqlClient.SqlConnection
    ' conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    'conexion.Open()
    'End Sub

    Private Sub llenar_grid()
        sql = "select * from v_d_compra"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_d_compra")
        dgv.DataSource = ds
        dgv.DataMember = "v_d_compra"
        conexion.conexion.Close()
    End Sub
    Private Sub doc_compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class