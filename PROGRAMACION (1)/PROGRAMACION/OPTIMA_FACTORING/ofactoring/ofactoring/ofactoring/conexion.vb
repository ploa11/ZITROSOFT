Imports System.Data.SqlClient

Public Class conexion
    Public conexion As SqlClient.SqlConnection
    Public conexion2 As SqlClient.SqlConnection
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim nomsql, bd, usql, clasql, sql As String
    'modulo para conectar a base de datos general
    Public Sub conectar()
        conexion = New SqlClient.SqlConnection
        conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
        conexion.Open()
    End Sub
    '---------------------------------------------------------------------------------------------------------
    'boton  para conectar con los fondos
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        nomsql = cb1.Text
        usql = cb3.Text
        clasql = cb4.Text
        bd = cb2.Text
        Me.Hide()
        Datos_Generales_del_Fondo.Show()


    End Sub
    '-----------------------------------------------------------------------------------------------------------
    'modulo para conectar  a base de datos de fondos
    Public Sub conectarfondo()
        conexion2 = New SqlClient.SqlConnection
        'conexion2.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
        conexion2.ConnectionString = ("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=" & bd)
        conexion2.Open()
    End Sub
    Private Sub llenar_combo1()
        Sql = "select *from servsql"
        conectar()
        da = New SqlClient.SqlDataAdapter(Sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "servsql"
        cb1.ValueMember = "noserver"
    End Sub

    Private Sub llenar_combo2()
        sql = "select *from nfondo"
        conectar()
        da = New SqlClient.SqlDataAdapter(Sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "nfondo"
        cb2.ValueMember = "nocontrol"
    End Sub

    Private Sub llenar_combo3()
        sql = "select *from servsql"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb3.DataSource = dt
        cb3.DisplayMember = "servsql"
        cb3.ValueMember = "ususql"
    End Sub

    Private Sub llenar_combo4()
        sql = "select *from servsql"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb4.DataSource = dt
        cb4.DisplayMember = "servsql"
        cb4.ValueMember = "clavesql"
    End Sub

    'Dim myConn As SqlConnection = New SqlConnection("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=master")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combo1()
        llenar_combo2()
        llenar_combo3()
        llenar_combo4()
        cb1.Text = ""
        cb2.Text = ""
        cb3.Text = ""
        cb4.Text = ""


    End Sub
End Class
