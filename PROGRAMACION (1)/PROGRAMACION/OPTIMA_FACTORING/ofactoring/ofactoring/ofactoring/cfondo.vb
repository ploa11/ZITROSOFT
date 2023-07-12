Imports System.Data.SqlClient
Public Class cfondo
    'Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String
    Dim res As Integer, tc As String, td As String, nd As String, ce As String
    Dim usql, clasql, nomsql, nfon, str, str2, str3 As String
    'variables de fecha
    Dim dia, mes, ano, dia2, mes2, ano2, dia3, mes3, ano3, dia4, mes4, ano4, fecha, fecha2, fecha3, fecha4 As String
    Dim fo_dia, fo_mes, fo_dia2, fo_mes2, fo_dia3, fo_mes3, fo_dia4, fo_mes4 As String
    Dim f_creacion, f_ins_sunat, f_ini_op, f_final_op As String
    '-------------------
    'variables de insercion alta
    Dim m_minimo, m_maximo, cap_actual, v_cuo_nominal, v_cuo_act As String
    Dim u_neg, n_ruc, gest, mon As String


    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        dia = DTP1.Value.Date
        mes = DTP1.Value.Date
        ano = DTP1.Value.Year
        dia2 = DTP2.Value.Date
        mes2 = DTP2.Value.Date
        ano2 = DTP2.Value.Year
        dia3 = DTP3.Value.Date
        mes3 = DTP3.Value.Date
        ano3 = DTP3.Value.Year
        dia4 = DTP4.Value.Date
        mes4 = DTP4.Value.Date
        ano4 = DTP4.Value.Year
        'declaramos estraemos el dia y mes
        fo_dia = dia.Substring(0, dia.IndexOf("/"))
        fo_mes = mes.Substring(3, mes.IndexOf("/"))
        fo_dia2 = dia2.Substring(0, dia2.IndexOf("/"))
        fo_mes2 = mes2.Substring(3, mes2.IndexOf("/"))
        fo_dia3 = dia3.Substring(0, dia3.IndexOf("/"))
        fo_mes3 = mes3.Substring(3, mes3.IndexOf("/"))
        fo_dia4 = dia4.Substring(0, dia4.IndexOf("/"))
        fo_mes4 = mes4.Substring(3, mes4.IndexOf("/"))
        '-------------------------------------------------
        'd.Text = fo_dia
        'm.Text = fo_mes
        'a.Text = ano
        'd2.Text = fo_dia2
        'm2.Text = fo_mes2
        'a2.Text = ano2
        'd3.Text = fo_dia3
        'm3.Text = fo_mes3
        'a3.Text = ano3
        'd4.Text = fo_dia4
        'm4.Text = fo_mes4
        'a4.Text = ano4



        '-------------------------------------------------
        'concatenar la fecha
        'TextBox1.Text = a.Text + m.Text + d.Text
        'TextBox2.Text = a2.Text + m2.Text + d2.Text
        'TextBox3.Text = a3.Text + m3.Text + d3.Text
        'TextBox4.Text = a4.Text + m4.Text + d4.Text
        fecha = ano + fo_mes + fo_dia
        fecha2 = ano2 + fo_mes2 + fo_dia2
        fecha3 = ano3 + fo_mes3 + fo_dia3
        fecha4 = ano4 + fo_mes4 + fo_dia4
        '--------------------------------------------------
        'igualar variables de insercion

        nc = t2.Text
        nomsql = UCase(cb1.Text)
        nfon = UCase(t1.Text)
        mon = UCase(cb2.Text)
        m_minimo = t3.Text
        m_maximo = t4.Text
        cap_actual = t5.Text
        v_cuo_nominal = t6.Text
        v_cuo_act = t7.Text
        u_neg = UCase(CB3.Text)
        f_creacion = fecha
        f_ins_sunat = fecha2
        n_ruc = t8.Text
        gest = cb4.Text
        f_ini_op = fecha3
        f_final_op = fecha4
        '-----------------------
        sql = "" 'variable sql
        If accion = "guardar" Then
            sql = "exec ver_nfondo'" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "nfondo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion.Close()
            Else
                sql = "exec alta_nfondo '" + nfon + "','" + nomsql + "','" + mon + "','" + m_minimo + "','" + m_maximo + "','" + cap_actual + "','" + v_cuo_nominal + "','" + v_cuo_act + "','" + u_neg + "','" + f_creacion + "','" + f_ins_sunat + "','" + gest + "','" + f_ini_op + "','" + f_final_op + "','" + n_ruc + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_nfondo'" + nc + "','" + nfon + "','" + nomsql + "','" + mon + "','" + m_minimo + "','" + m_maximo + "','" + cap_actual + "','" + v_cuo_nominal + "','" + v_cuo_act + "','" + u_neg + "','" + f_creacion + "','" + f_ins_sunat + "','" + gest + "','" + f_ini_op + "','" + f_final_op + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        cb1.Enabled = False
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t8.Enabled = False
        cb1.Enabled = False
        cb2.Enabled = False
        CB3.Enabled = False
        cb4.Enabled = False
        DTP1.Enabled = False
        DTP2.Enabled = False
        DTP3.Enabled = False
        DTP4.Enabled = False

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim opcion As String
        nc = cb1.Text
        sql = "exec ver_servsql '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            nomsql = dr(1)
            usql = dr(2)
            clasql = dr(3)

        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        opcion = InputBox("Ingrese Codigo de Fondo que se muestra en la ventana anterior")

        sql = "exec ver_nfondo '" + opcion + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t1.Text = dr(1)
            cb1.Text = dr(2)
        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()


        Dim myConn As SqlConnection = New SqlConnection("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=master")

        str = "create database " & t2.Text
        'str2 = "use" & t2.Text
        'str3 = "create table usuario (
        'noControl varchar (10) not null,
        'nombre varchar (50),
        'apellido varchar (50),
        'dni varchar (50),
        'sede varchar (50)
        ' Constraint pk_usuario primary key (nocontrol)) 

        'create table sede(
        ' noControl varchar	(10) Not null,
        '   ciudad varchar (50),
        ' provincia varchar (50),
        'departamento varchar (50),
        '  direccion varchar (50)
        ' Constraint pk_sede primary key (nocontrol))

        'create table marcacion(
        'noControl varchar	(10) not null,
        'codusu varchar (50),
        'hora time,
        'fecha date,
        'estado varchar (50)
        'Constraint pk_marcacion primary key (nocontrol))"

        Dim myCommand As SqlCommand = New SqlCommand(str, myConn)
        'Dim myCommand2 As SqlCommand = New SqlCommand(str2, myConn)
        'Dim myCommand3 As SqlCommand = New SqlCommand(str3, myConn)
        Try
            myConn.Open()
            myCommand.ExecuteNonQuery()
            'myCommand2.ExecuteNonQuery()
            'myCommand3.ExecuteNonQuery()
            MessageBox.Show("BASE DE DATOS DE FONDO CREADA",
                             "CREACION DE FONDO", MessageBoxButtons.OK,
                             MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql2 As String
        Dim borra = "drop database " & t2.Text
        nc = t2.Text
        res = MessageBox.Show("¿Desea borrar los Datos?", "nfondo", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql2 = "exec ver_servsql '" + cb1.Text + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql2, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                nomsql = dr(1)
                usql = dr(2)
                clasql = dr(3)

            Else
                MessageBox.Show("Los datos Buscados no Existe")
            End If
            sql = "exec borra_nfondo '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            Dim myConn As SqlConnection = New SqlConnection("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=master")
            Dim myCommand As SqlCommand = New SqlCommand(borra, myConn)
            myConn.Open()
            myCommand.ExecuteNonQuery()
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        cb1.Enabled = False
        t1.Text = ""
        t2.Text = ""
        cb1.Text = ""
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Button5_Click(sender, e)
        Button4_Click(sender, e)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        nc = InputBox("Ingrese Codigo o Nombre del Fondo")
        sql = "exec ver_nfondo '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t1.Text = dr(1)
            cb1.Text = dr(2)
            cb2.Text = dr(3)
            t3.Text = dr(4)
            t4.Text = dr(5)
            t5.Text = dr(6)
            t6.Text = dr(7)
            t7.Text = dr(8)
            CB3.Text = dr(9)
            DTP1.Value = dr(10)
            DTP2.Value = dr(11)
            t8.Text = dr(12)
            DTP3.Text = dr(13)
            DTP4.Text = dr(14)
            t8.Text = dr(15)
        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        gestion.Show()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        moneda.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        cb1.Enabled = True
        t1.Enabled = True
        t2.Enabled = False
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        DTP1.Enabled = True
        DTP2.Enabled = True
        DTP3.Enabled = True
        DTP4.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        CB3.Enabled = True
        cb4.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True



    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        uni_negocio.Show()
    End Sub

    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    'Public Sub conectar()
    'conexion = New SqlClient.SqlConnection
    'conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    'conexion.Open()
    ' End Sub
    Private Sub llenar_grid()
        sql = "select * from v_nfondo"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_nfondo")
        dgv.DataSource = ds
        dgv.DataMember = "v_nfondo"
        conexion.conexion.Close()
    End Sub

    Private Sub llenar_combo1()
        sql = "select *from servsql"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "servsql"
        cb1.ValueMember = "noserver"
    End Sub

    Public Sub llenar_combo4()
        sql = "select *from gestio_bdp"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb4.DataSource = dt
        cb4.DisplayMember = "gestio_bdp"
        cb4.ValueMember = "gestion"
    End Sub

    Public Sub llenar_combo3()
        sql = "select *from moneda"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "moneda"
        cb2.ValueMember = "tmoneda"
    End Sub

    Public Sub llenar_combo2()
        sql = "select *from uni_negocio"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        CB3.DataSource = dt
        CB3.DisplayMember = "uni_negocio"
        CB3.ValueMember = "uni_negocio"
    End Sub


    Private Sub btnCrearBase_Click(sender As Object, e As EventArgs) Handles btnCrearBase.Click
        accion = "guardar"
        cb1.Enabled = True
        cb1.Text = ""
        t1.Enabled = True
        t1.Text = ""
        t2.Enabled = False
        t2.Text = ""
        t3.Enabled = True
        t3.Text = 0.0
        t4.Enabled = True
        t4.Text = 0.0
        t5.Enabled = True
        t5.Text = 0.0
        t6.Enabled = True
        t6.Text = 0.0
        t7.Enabled = True
        t7.Text = 0.0
        t8.Enabled = True
        t8.Text = ""
        cb2.Enabled = True
        cb2.Text = ""
        CB3.Enabled = True
        CB3.Text = ""
        DTP1.Enabled = True
        DTP1.Text = ""
        DTP2.Enabled = True
        DTP2.Text = ""
        DTP3.Enabled = True
        DTP3.Text = ""
        DTP4.Enabled = True
        DTP4.Text = ""
        cb4.Enabled = True
        cb4.Text = ""
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True






    End Sub

    Private Sub cfondo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combo1()
        llenar_combo4()
        llenar_combo3()
        llenar_combo2()
        llenar_grid()
        'Button4.Hide()
        'Button5.Hide()


    End Sub
End Class