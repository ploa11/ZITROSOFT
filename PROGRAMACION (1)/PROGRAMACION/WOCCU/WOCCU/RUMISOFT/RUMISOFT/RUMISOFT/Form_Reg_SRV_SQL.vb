Imports System.Data.SqlClient

Public Class Form_Reg_SRV_SQL
    Public conexion As SqlClient.SqlConnection
    Public conexion2 As SqlClient.SqlConnection
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim nomsql, nc, bdp, bd, usql, clasql, sql As String
    Private Sub Form_Reg_SRV_SQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub conectar()
        Try
            conexion = New SqlClient.SqlConnection
            'conexion.ConnectionString = ("server=" & nomsql & ";database=" & bdp & ";integrated security=true")
            'conexion.ConnectionString = ("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=" & bdp)
            'conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
            'conexion.ConnectionString = ("Data source = NLIM010PDOM\BDOPTIMA,1433; initial catalog =bdopfac; user id = sa; password = 0pt1m4$2015")
            'conexion.ConnectionString = ("Data source = orcasoluciones; initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = orcasoluciones; initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = DESKTOP-TVP9105\SQLEXPRESS; initial catalog = BDRUMISOFT; user id = sa; password = Orca2015")
            'conexion.ConnectionString = ("Data source = SBDRUMI\SQLEXPRESS,1433; initial catalog = BDRUMISOFT; user id = sa; password = Admin2020")
            'conexion.ConnectionString = ("Data source = 35.237.120.205\SQLEXPRESS,1433; initial catalog = BDRUMISOFT; user id = sa; password = Rumi2018")
            'conexion.ConnectionString = ("Data source = 35.237.28.75\SQLBD,1433; initial catalog = BDRUMISOFT; user id = sa; password = Orca2018**")
            'conexion.ConnectionString = ("Data source = 192.168.2.24\SQLEXPRESS; initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = 192.168.2.24; initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("server=NLIM010PDOM\BDOPTIMA; database = bdopfac; user id = sa; password = 0pt1m4$2015")
            'conexion.ConnectionString = ("server=orcasoluciones\SQLEXPRESS; database = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("server=orcasoluciones\SQLEXPRESS,1433; database = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("server=1923.168.2.24\SQLEXPRESS,1433; database = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source=orcasoluciones\SQLEXPRESS,1433;initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = 161.132.107.4\BDOPTIMA,1433; initial catalog = bdopfac; user id = sa; password = 0pt1m4$2015")
            'conexion.ConnectionString = ("Data source = WIN10\SQLEXPRESS; initial catalog = reghoras; user id = sa; password = Orca2015")
            conexion.ConnectionString = ("Data source = orcasoluciones\SQLEXPRESS; initial catalog = BDRUMISOFT; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = docan\docan; initial catalog = BDRUMISOFT; user id = Lenovo; password = 123456789")
            conexion.Open()
        Catch ex As Exception
            MsgBox("ERROR DE USUARIO O PASSWORD DE BASE DE DATOS")
        End Try

    End Sub
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


End Class