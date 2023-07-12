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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DATOS_SERVER_SISTEMA()

        inicio.Show()
    End Sub

    Public NOM_SERVER, NOM_BD_SQL, USU_SQL, CLAVE_SQL, NOM_CARP_OC, NOM_CARP_COTI, NOM_CARP_REPORT, NOM_CARP_RQ, ID, CARP_SERV, NOMBRE_SERVER As String
    Private Sub Form_Reg_SRV_SQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectarserver()
        llenar_combo1()
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
            'conexion.ConnectionString = ("Data source = orcasoluciones\SQLEXPRESS; initial catalog = BDRUMISOFT; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = SBDRUMI\SQLEXPRESS,1433; initial catalog = BDRUMISOFT; user id = sa; password = Admin2020")
            'conexion.ConnectionString = ("Data source = 35.237.120.205\SQLEXPRESS,1433; initial catalog = BDRUMISOFT; user id = sa; password = Rumi2018")
            'conexion.ConnectionString = ("Data source = EXPLORER\SQLEXPRESS,1433; initial catalog = BDRUMISOFT; user id = sa; password = CaMa1414@@")
            'conexion.ConnectionString = ("Data source = SERVER\SQLEXPRESS,1433; initial catalog = BDRUMISOFT; user id = sa; password = sa123456CC")
            'conexion.ConnectionString = ("Data source = 190.117.77.70\SQLEXPRESS,1433; initial catalog = BDZSISOFT; user id = sa; password = sa123456CC")
            'conexion.ConnectionString = ("Data source = 190.117.77.70\SQLEXPRESS,1433; initial catalog = BDZSCY; user id = sa; password = sa123456CC")
            'conexion.ConnectionString = ("Data source = 35.237.28.75\SQLBD,1433; initial catalog = BDRUMISOFT; user id = sa; password = Orca2018**")
            'conexion.ConnectionString = ("Data source = 192.168.2.24\SQLEXPRESS; initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = 192.168.2.24; initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("server=NLIM010PDOM\BDOPTIMA; database = bdopfac; user id = sa; password = 0pt1m4$2015")
            'conexion.ConnectionString = ("server=orcasoluciones\SQLEXPRESS; database = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("server=orcasoluciones\SQLEXPRESS,1433; database = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("server=1923.168.2.24\SQLEXPRESS,1433; database = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source=orcasoluciones\SQLEXPRESS,1433;initial catalog = bdopfac; user id = sa; password = Orca2016")
            'conexion.ConnectionString = ("Data source = 161.132.107.4\BDOPTIMA,1433; initial catalog = bdopfac; user id = sa; password = 0pt1m4$2015")
            'conexion.ConnectionString = ("Data source = orcasoluciones\SQLEXPRESS; initial catalog = reghoras; user id = sa; password = Orca2016")
            conexion.ConnectionString = ("Data source =" & NOM_SERVER & "; initial catalog =" & NOM_BD_SQL & "; user id = " & USU_SQL & "; password = " & CLAVE_SQL & "")
            conexion.Open()
        Catch ex As Exception
            MsgBox("ERROR DE USUARIO O PASSWORD DE BASE DE DATOS")
        End Try

    End Sub
    Public Sub conectarserver()
        Try
            conexion2 = New SqlClient.SqlConnection
            'conexion2.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
            'conexion2.ConnectionString = ("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=" & bd)
            conexion2.ConnectionString = ("Data source = 190.117.77.70\SQLEXPRESS,1433; initial catalog = DCSERVER; user id = sa; password = sa123456CC")
            conexion2.Open()
        Catch ex As Exception
            MessageBox.Show("El Servidor BD no se encuentra")
        End Try
    End Sub

    Private Sub llenar_combo1()
        sql = "select *from DATOS_SERVER"
        conectarserver()
        da = New SqlClient.SqlDataAdapter(sql, conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "DATOS_SERVER"
        cb1.ValueMember = "NOMBRE_SERVER"
    End Sub
    Public Sub DATOS_SERVER_SISTEMA()
        'Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "select *from DATOS_SERVER where NOMBRE_SERVER='" + cb1.Text + "'"
        conectarserver()
        com = New SqlClient.SqlCommand(sql, conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            NOM_SERVER = dr(0)
            NOM_BD_SQL = dr(1)
            USU_SQL = dr(2)
            CLAVE_SQL = dr(3)
            NOM_CARP_OC = dr(4)
            NOM_CARP_COTI = dr(5)
            NOM_CARP_RQ = dr(6)
            NOM_CARP_REPORT = dr(7)
            ID = dr(8)
            CARP_SERV = dr(10)
            NOMBRE_SERVER = dr(11)
            't2.Text = NOM_SERVER '+ NOM_BD_SQL + NOM_CARP_COTI + NOM_CARP_OC + NOM_CARP_REPORT + NOM_CARP_RQ + NOM_SERVER + USU_SQL + CLAVE_SQL + ID + NOMBRE_SERVER
            ' Form_Orden_Compra.TextBox13.Text = dr(9)
            'Form_Orden_Compra.TextBox12.Text = dr(10)
            ' Form_Orden_Compra.TextBox11.Text = dr(11)
            ' Form_Orden_Compra.TextBox17.Text = dr(12)
            ' Form_Orden_Compra.ComboBox2.Text = dr(13)
            ' Form_Orden_Compra.TextBox1.Text = dr(15)
            ' Form_Orden_Compra.TextBox7.Text = dr(16)
            ' Form_Orden_Compra.TextBox8.Text = dr(17)

        End If
        dr.Close()
        conexion2.Close()
        'Form_Orden_Compra.llenar_PRO()
        'Form_Orden_Compra.llenar_PRO_OC()
        ' Form_Orden_Compra.ListView1.Visible = False
        ' Form_Orden_Compra.DataGridView1.Visible = True
        ' Form_Orden_Compra.GroupBox5.Enabled = True
        ' Form_Orden_Compra.Button13.Enabled = True
        ' Form_Orden_Compra.Button9.Enabled = False
        ' Form_Orden_Compra.Button11.Enabled = False
        ' Form_Orden_Compra.Button12.Enabled = False
        'Me.Close()
        Me.Hide()
    End Sub

End Class