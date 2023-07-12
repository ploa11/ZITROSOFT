Public Class combos
    Dim sql, sql2, sql3, nc As String
    Dim res, res2 As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim dt2 As DataTable
    Dim nom_clie, ruc_clie As String

    'Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    '---------------------------
    'variables publicas
    Public pase1, pase2, codigo, pase3, pase4, cod_sbc As String
    Public cod As Double
    'variables locales
    Dim preg, accion As String
    Dim a As Integer
    Dim usu_gen, usu_rev, usu_aprob As String
    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder, da2 As SqlClient.SqlDataAdapter

    Private Sub combos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub llenar_combo1_reg_rq()
        sql = "select *from T_CLASIFICACION"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        Form_Reg_RQ.ComboBox2.DataSource = dt
        Form_Reg_RQ.ComboBox2.DisplayMember = "DETALLE"
        Form_Reg_RQ.ComboBox2.ValueMember = "DETALLE"
    End Sub
    Public Sub llenar_combo2_reg_rq()
        sql = "select *from prioridad"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        Form_Reg_RQ.ComboBox4.DataSource = dt
        Form_Reg_RQ.ComboBox4.DisplayMember = "DETALLE"
        Form_Reg_RQ.ComboBox4.ValueMember = "DETALLE"
    End Sub

    Public Sub llenar_combo3_reg_rq()
        sql = "select *from prioridad"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        Form_Reg_RQ.ComboBox3.DataSource = dt
        Form_Reg_RQ.ComboBox3.DisplayMember = "DETALLE"
        Form_Reg_RQ.ComboBox3.ValueMember = "DETALLE"
    End Sub
End Class