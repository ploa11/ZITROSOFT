Imports System.Data.SqlClient

Public Class conexion
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
    Public conexion As SqlClient.SqlConnection
    Public conexion2 As SqlClient.SqlConnection
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim nomsql, nc, bdp, bd, usql, clasql, sql As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged

    End Sub
    'modulo para conectar a base de datos general
    Public Sub conectar()
        Try
            conexion = New SqlClient.SqlConnection
            'conexion.ConnectionString = ("server=" & nomsql & ";database=" & bdp & ";integrated security=true")
            'conexion.ConnectionString = ("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=" & bdp)
            'conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
            'conexion.ConnectionString = ("Data source = NLIM010PDOM\BDOPTIMA,1433; initial catalog =bdopfac; user id = sa; password = 0pt1m4$2015")
            'conexion.ConnectionString = ("Data source = orcasoluciones; initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = orcasoluciones; initial catalog = bdopfac; user id = sa; password = Orca2016")
            conexion.ConnectionString = ("Data source = orcasoluciones\SQLEXPRESS; initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = 35.237.28.75\SQLBD,1433; initial catalog = bdopfac; user id = sa; password = Orca2018**")
            'conexion.ConnectionString = ("Data source = 192.168.2.24\SQLEXPRESS; initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = 192.168.2.24; initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("server=NLIM010PDOM\BDOPTIMA; database = bdopfac; user id = sa; password = 0pt1m4$2015")
            'conexion.ConnectionString = ("server=orcasoluciones\SQLEXPRESS; database = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("server=orcasoluciones\SQLEXPRESS,1433; database = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("server=1923.168.2.24\SQLEXPRESS,1433; database = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source=orcasoluciones\SQLEXPRESS,1433;initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = 161.132.107.4\BDOPTIMA,1433; initial catalog = bdopfac; user id = sa; password = 0pt1m4$2015")
            'conexion.ConnectionString = ("Data source = orcasoluciones\SQLEXPRESS; initial catalog = reghoras; user id = sa; password = Orca2016")
            conexion.Open()
        Catch ex As Exception
            MsgBox("ERROR DE USUARIO O PASSWORD DE BASE DE DATOS")
        End Try

    End Sub
    '---------------------------------------------------------------------------------------------------------
    'boton  para conectar con los fondos
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        nomsql = cb1.Text
        bdp = t1.Text
        usql = t2.Text
        clasql = t3.Text
        bd = cb2.Text
        Me.Hide()
        Datos_Generales_del_Fondo.Show()



    End Sub
    '-----------------------------------------------------------------------------------------------------------
    'modulo para conectar  a base de datos de fondos
    Public Sub conectarfondo()
        Try
            conexion2 = New SqlClient.SqlConnection
            'conexion2.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
            conexion2.ConnectionString = ("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=" & bd)
            conexion2.Open()
        Catch ex As Exception
            MessageBox.Show("El Servidor BD no se encuentra")
        End Try
    End Sub
    Private Sub llenar_combo1()
        sql = "select *from servsql"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
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
        da = New SqlClient.SqlDataAdapter(sql, conexion)
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

    Private Sub cb1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb1.SelectedValueChanged
        nc = cb1.Text
        sql = "exec ver_servsql '" + nc + "'"
        conectar()
        com = New SqlClient.SqlCommand(sql, conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(4)
            t2.Text = dr(2)
            t3.Text = dr(3)

        Else
            MessageBox.Show("Seleccione un servidor de BD y Fondo")
        End If
        dr.Close()
        conexion.Close()
    End Sub
End Class
