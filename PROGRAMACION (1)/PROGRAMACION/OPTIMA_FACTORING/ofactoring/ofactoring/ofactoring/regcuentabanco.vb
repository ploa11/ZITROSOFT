Public Class regcuentabanco
    Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String
    Dim res As Integer

    Dim cdcli, cdcu, bn, ncu As String, tc As String, td As String, nd As String, ce As String
    Dim pass As String, telef As String, anx As String, nom As String, app As String, apm As String
    Dim cusu As String, h As DateTime, d As DateTime, mc As String, cn As String, comen As String, dni, dnru As String, sede As String, clv As String

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t3.Text
        res = MessageBox.Show("¿Desea Borrar el numero de cuenta", "reg_cuentabanco", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_rcbancos '" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False

        cb1.Enabled = False
        cb2.Enabled = False

        t1.Text = ""
        cb1.Text = ""
        t2.Text = ""
        cb2.Text = ""
        t3.Text = ""

        t4.Text = ""


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim res3 As String
        res3 = MessageBox.Show("¿Desea Editar los Datos de Cliente de la cuenta", "EDICION DE DATOS DE CLIENTES Y CUENTA", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

        If res3 = 6 Then
            accion = "editar"
            t3.Enabled = False
            cb2.Enabled = True
            t4.Enabled = True
            cb1.Enabled = True
            t1.Enabled = True
            t2.Enabled = True
            Button1.Enabled = True
        Else
            MessageBox.Show("Registro No Modificado")
        End If

    End Sub

    Private Sub R_Click(sender As Object, e As EventArgs) Handles R.Click
        reg_bancos.Show()

    End Sub

    Dim clave As String
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim dia As Date
    Dim hora As Date
    Dim ipe As String
    Dim cname As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "guardar"
        t3.Enabled = False
        t3.Text = ""
        cb2.Enabled = True
        cb2.Text = ""
        t4.Enabled = True
        t4.Text = ""
        cb1.Enabled = True
        cb1.Text = ""
        t1.Enabled = True
        t1.Text = ""
        t2.Enabled = True
        t2.Text = ""
        Button1.Enabled = True
        R.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim res1 As String
        res1 = MessageBox.Show("¿PARA EDITAR, BUSQUE LA CUENTA POR SU CODIGO, DESEA MODIFICAR LA CUENTA", "CUENTA DE BANCO", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

        If res1 = 6 Then
            accion = "editar"
            t3.Enabled = False
            cb2.Enabled = True
            t4.Enabled = True
            R.Enabled = True
        Else
            MessageBox.Show("Registro no Modificado")
        End If


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = InputBox("Ingrese el Codigo de Cuenta")
        sql = "exec ver_rcbanco '" + nc + "'"
        conectar()
        com = New SqlClient.SqlCommand(sql, conexion)
        dr = com.ExecuteReader
        If dr.Read Then

            cb1.Text = dr(0)
            t1.Text = dr(1)
            t2.Text = dr(2)
            t3.Text = dr(3)
            cb2.Text = dr(4)
            t4.Text = dr(5)

        Else
            MessageBox.Show("La cuenta no Existe")
        End If
        dr.Close()
        conexion.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim posi2 As Integer = cb1.Text.IndexOf(" ")

        cdcu = UCase(t3.Text)
        cdcli = UCase(t1.Text)
        nom = UCase(t2.Text)
        ncu = UCase(t4.Text)
        bn = UCase(cb2.Text)
        sql = ""
        If accion = "guardar" Then
            dni = cb1.Text.Substring(0, posi2)
            dnru = UCase(dni)
            sql = "exec ver_rcbanco'" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de cuenta ya existe", "regcuentabanco", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.Close()
            Else
                sql = "exec alta_rcbanco '" + dnru + "','" + cdcli + "','" + nom + "','" + bn + "','" + ncu + "'"
                conectar()
                com = New SqlClient.SqlCommand(sql, conexion)
                res = com.ExecuteNonQuery
                conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            dnru = cb1.Text
            sql = "exec edita_rcbancos'" + dnru + "','" + cdcli + "','" + nom + "','" + cdcu + "','" + bn + "','" + ncu + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False

        cb1.Enabled = False
        cb2.Enabled = False

    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged

    End Sub


    Private Sub regcuentabanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combo1()
        llenar_combo2()
        llenar_grid()
        cb1.Text = ""
        t1.Text = ""
        t2.Text = ""
        Button1.Enabled = False
    End Sub


    Public Sub conectar()
        conexion = New SqlClient.SqlConnection
        conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
        'conexion.ConnectionString = ("Data source = NLIM010PDOM; initial catalog = reghoras; user id = sa; password = 0pt1m4$2015")
        conexion.Open()
    End Sub

    Public Sub llenar_grid()
        Dim cu = t1.Text
        sql = "select *from reg_cuentabanco" '+ cu + "'"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "reg_cuentabanco") ' + cu + "'")
        dgv.DataSource = ds
        dgv.DataMember = "reg_cuentabanco" '+ cu + "'"
        conexion.Close()
    End Sub
    Public Sub llenar_grid2()
        sql = "select * from usu_c4"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "usu_c4")
        dgv.DataSource = ds
        dgv.DataMember = "usu_c4"
        conexion.Close()
    End Sub
    Public Sub llenar_combo2()
        sql = "select *from reg_bancos"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "reg_bancos"
        cb2.ValueMember = "rsocial"

        'Dim dtipouso As SqlClient.SqlDataAdapter
        'Dim dsdatos As DataSet
        'dtipouso = New SqlClient.SqlDataAdapter("select dni,(nombre +' '+apellido) as dtos from usuario ", conexion|)
        'dsdatos = New DataSet
        'dtipouso.Fill(dsdatos, "usuario")
        'cb1.DataSource = dsdatos.Tables("usuario")
        'cb1.DisplayMember = dsdatos.Tables("usuario").Columns("dtos").ToString
        'cb1.ValueMember = dsdatos.Tables("usuario").Columns("dni").ToString
    End Sub
    Public Sub llenar_combo1()
        sql = "select nudocumento,(nudocumento+'  | '+nombre +' '+apmaterno+' '+apmaterno) as dtos from clientes"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "dtos"
        cb1.ValueMember = "nudocumento"

        'Dim dtipouso As SqlClient.SqlDataAdapter
        'Dim dsdatos As DataSet
        'dtipouso = New SqlClient.SqlDataAdapter("select dni,(nombre +' '+apellido) as dtos from usuario ", conexion|)
        'dsdatos = New DataSet
        'dtipouso.Fill(dsdatos, "usuario")
        'cb1.DataSource = dsdatos.Tables("usuario")
        'cb1.DisplayMember = dsdatos.Tables("usuario").Columns("dtos").ToString
        'cb1.ValueMember = dsdatos.Tables("usuario").Columns("dni").ToString
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim posi As Integer = cb1.Text.IndexOf(" ")
        nc = cb1.Text.Substring(0, posi)
        sql = "exec ver_clientes '" + nc + "'"
        conectar()
        com = New SqlClient.SqlCommand(sql, conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(8)
            'cb2.Text = dr(2)
            't2.Text = dr(3)
            't3.Text = dr(4)
            ' 't4.Text = dr(5)
            't5.Text = dr(6)
            't6.Text = dr(7)
            ''t7.Text = dr(8)
            't8.Text = dr(9)
            't9.Text = dr(10)
            't10.Text = dr(11)
            ''cb3.Text = dr(12)
            'cb4.Text = dr(13)
            'cb5.Text = dr(14)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.Close()
    End Sub

    Private Sub cb1_Click(sender As Object, e As EventArgs) Handles cb1.Click

    End Sub
End Class