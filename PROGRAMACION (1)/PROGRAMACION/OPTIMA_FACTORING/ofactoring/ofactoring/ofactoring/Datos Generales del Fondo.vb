Public Class Datos_Generales_del_Fondo
    Dim sql, nc, nomserv As String
    Dim ruc As Integer

    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cb1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Dim res As Integer

    Public Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Fondos.Show()
        Actualizacion_de_datos.t2.Text = cb1.Text
        Actualizacion_de_datos.t1.Text = t1.Text
        Actualizacion_de_datos.t3.Text = t3.Text
        Actualizacion_de_datos.t4.Text = t4.Text
        Actualizacion_de_datos.t5.Text = t5.Text
        Actualizacion_de_datos.t6.Text = t6.Text
        Actualizacion_de_datos.t7.Text = t9.Text
        Actualizacion_de_datos.t10.Text = t8.Text
        Actualizacion_de_datos.t8.Text = t13.Text
        Actualizacion_de_datos.t9.Text = t7.Text
        Actualizacion_de_datos.t12.Text = t12.Text
        Actualizacion_de_datos.dtp2.Text = t10.Text
        Actualizacion_de_datos.dtp3.Text = t11.Text
        Actualizacion_de_datos.dtp4.Text = t14.Text
        Actualizacion_de_datos.dtp5.Text = t15.Text
        Actualizacion_de_datos.t13.Text = t2.Text



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        registro_de_cuentas_bancos.t5.Text = t2.Text
        registro_de_cuentas_bancos.cod_fondo = t1.Text
        registro_de_cuentas_bancos.nom_fondo = t2.Text
        registro_de_cuentas_bancos.t2.Enabled = False
        registro_de_cuentas_bancos.t3.Enabled = False
        registro_de_cuentas_bancos.t4.Enabled = False
        registro_de_cuentas_bancos.t5.Enabled = True
        registro_de_cuentas_bancos.cb1.Enabled = True
        registro_de_cuentas_bancos.t6.Enabled = True
        registro_de_cuentas_bancos.t7.Enabled = True
        registro_de_cuentas_bancos.cb2.Enabled = True
        registro_de_cuentas_bancos.cb3.Enabled = True
        registro_de_cuentas_bancos.t8.Enabled = True
        registro_de_cuentas_bancos.Button4.Enabled = True
        registro_de_cuentas_bancos.Button5.Enabled = True
        registro_de_cuentas_bancos.cb3.Text = "No"
        registro_de_cuentas_bancos.Show()

    End Sub

    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Private Sub Datos_Generales_del_Fondo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nc = conexion.cb2.Text
        sql = "exec ver_nfondo '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(3)
            t4.Text = dr(4)
            t5.Text = dr(5)
            t6.Text = dr(6)
            t7.Text = dr(7)
            t8.Text = dr(8)
            t9.Text = dr(9)
            t10.Text = dr(10)
            t11.Text = dr(11)
            t12.Text = dr(12)
            t14.Text = dr(13)
            t15.Text = dr(14)
            t13.Text = dr(15)

        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        'conexion.Close()
        llenar_combo1()
    End Sub

    Public Sub llenar_combo1()
        sql = "select *from dist_beneficio"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "distribucion"
        cb1.ValueMember = "distribucion"
    End Sub
End Class