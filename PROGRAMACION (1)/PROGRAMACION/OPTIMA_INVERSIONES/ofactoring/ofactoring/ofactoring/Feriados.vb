Public Class Feriados
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
    Dim accion, fecha, fechamo As String, nc As String, sql As String, sql2 As String, area As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader, dr2 As SqlClient.SqlDataAdapter

    Private Sub Feriados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        fe_reg = dtp1.Value
        fe_modi = dtp2.Value
        fecha = fe_reg.ToString("yyyyMMdd")
        fechamo = fe_modi.ToString("yyyyMMdd")
        sql = "select *from feriados where feriado='" + fecha + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            dtp2.Value = dr(0)
        Else
            MessageBox.Show("el feriado no existe")
        End If
        dr.Close()
        conexion.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        dtp2.Enabled = True
    End Sub

    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim fe_reg, fe_modi As DateTime

    Dim res As Integer, det As String, sa As String
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        fe_reg = dtp1.Value
        fe_modi = dtp2.Value
        fecha = fe_reg.ToString("yyyyMMdd")
        fechamo = fe_modi.ToString("yyyyMMdd")
        If accion = "guardar" Then
            sql = "select *from feriados where feriado='" + fecha + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El feriado existe", "Feriados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.Close()
            Else
                sql = "insert  into feriados (feriado) values ( '" + fecha + "')"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "update feriados set feriado='" + fechamo + "'where feriado='" + fecha + "'" + nc + "','" + area + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        dtp1.Enabled = True

    End Sub

    Private Sub llenar_grid()
        sql = "select * from v_feriados"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_feriados")
        dgv.DataSource = ds
        dgv.DataMember = "v_feriados"
        conexion.Close()
    End Sub
End Class