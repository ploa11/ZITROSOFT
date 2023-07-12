Public Class registro_de_cuentas_bancos
    'recibe dato de codigo de mancumunado
    Public cod_manc, nom_manc As String
    'variables conecion sql
    Dim accion, nc As String, sql As String
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim res As Integer


    'recibir varible global de codigo de reg_participe
    Public cod_parti, nom_part, cod_fondo, nom_fondo, cod_clie, nom_clie, cod_prov, nom_prov As String

    'variables locales
    Dim cod_banc, n_cuenta, cci, n_moneda, t_cuenta As String

    '------------------------------------------------------
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        accion = "guardar"
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        cb3.Enabled = True
        cb4.Enabled = True
        cb4.Text = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button13.Enabled = True
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        cb1.Text = ""
        cb2.Text = ""
        cb3.Text = ""


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        registro_bancos_fondo.Show()

    End Sub

    Private Sub cb3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb3.SelectedIndexChanged

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Regristro_mancomunado.Show()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar la cuenta de Banco?", "Cuenta de Banco", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_datos_cuenta '" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        cb4.Enabled = False
        cb3.Enabled = False
        cb2.Enabled = False
        cb1.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t8.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""
        cb1.Text = ""
        cb2.Text = ""
        cb3.Text = ""
        cb4.Text = ""
    End Sub

    Private Sub t8_TextChanged(sender As Object, e As EventArgs) Handles t8.TextChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        nc = InputBox("Ingrese el Codigo o Numero de Cuenta")
        sql = "exec ver_datos_cuenta '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            cb1.Text = dr(1)
            cb4.Text = dr(2)
            t6.Text = dr(3)
            t7.Text = dr(4)
            cb2.Text = dr(5)
            t2.Text = dr(10)
            t3.Text = dr(11)
            t4.Text = dr(12)
            t5.Text = dr(13)
            t8.Text = dr(15)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        llenar_grid()
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Button10.Enabled = True
        '---------------------------------------------------------
        '-registro de los datos
        nc = UCase(t1.Text)
        nom_part = UCase(t2.Text)
        nom_clie = UCase(t3.Text)
        nom_prov = UCase(t4.Text)
        nom_fondo = UCase(t5.Text)
        cod_banc = UCase(Mid(cb1.Text, 1, (Str(InStrRev(cb1.Text, ("|")))) - 1))
        n_cuenta = UCase(t6.Text)
        cci = UCase(t7.Text)
        n_moneda = UCase(Mid(cb2.Text, 1, (Str(InStrRev(cb2.Text, ("|")))) - 1))
        nom_manc = UCase(t8.Text)
        t_cuenta = UCase(cb4.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_datos_cuenta'" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "Datos de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_datos_cuenta '" + cod_banc + "','" + t_cuenta + "','" + n_cuenta + "','" + cci + "','" + n_moneda + "','" + cod_parti + "','" + cod_clie + "','" + cod_prov + "','" + cod_fondo + "','" + nom_part + "','" + nom_clie + "','" + nom_prov + "','" + nom_fondo + "','" + cod_manc + "','" + nom_manc + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                Res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_datos_cuenta'" + nc + "','" + cod_banc + "','" + t_cuenta + "','" + n_cuenta + "','" + cci + "','" + n_moneda + "','" + cod_parti + "','" + cod_clie + "','" + cod_prov + "','" + cod_fondo + "','" + nom_part + "','" + nom_clie + "','" + nom_prov + "','" + nom_fondo + "','" + cod_manc + "','" + nom_manc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            Res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
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
        cb3.Enabled = False
        cb4.Enabled = False


        nc = UCase(t6.Text)
        sql = "exec ver_datos_cuenta '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            't2.Text = dr(1)
            ''cod_manc = dr(0)
            '' n_manc = dr(1)
            ' dtp1.Value = dr(2)
            ' dtp2.Value = dr(3)


        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        llenar_grid()
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub cb3_Click(sender As Object, e As EventArgs) Handles cb3.Click


    End Sub

    Private Sub cb3_MouseClick(sender As Object, e As MouseEventArgs) Handles cb3.MouseClick

    End Sub

    Private Sub cb3_DockChanged(sender As Object, e As EventArgs) Handles cb3.DockChanged

    End Sub

    Private Sub cb3_DisplayMemberChanged(sender As Object, e As EventArgs) Handles cb3.DisplayMemberChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        moneda.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        accion = "editar"
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        cb3.Enabled = True
        cb4.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button13.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button12.Enabled = True


    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Regristro_mancomunado.Button6_Click(sender, e)
        t8.Text = Regristro_mancomunado.cod_manc + " " + "|" + " " + Regristro_mancomunado.n_manc

        cod_manc = Regristro_mancomunado.cod_manc

    End Sub

    Private Sub cb3_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb3.SelectedValueChanged
        If cb3.Text = "SI" Then
            t8.Enabled = True
            Button12.Enabled = True
            Button14.Enabled = True

        Else
            t8.Enabled = False
            Button12.Enabled = False
            Button14.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        registro_participes.Button5_Click(sender, e)
        t2.Text = registro_participes.nom_parti + " " + registro_participes.apellidop + " " + registro_participes.apellidom
        nom_part = t2.Text
        cod_parti = registro_participes.c_parti
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        Button13.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        registro_clientes.Button4_Click(sender, e)
        t3.Text = registro_clientes.t3.Text & " " & registro_clientes.t4.Text & " " & registro_clientes.t5.Text
        nom_clie = t3.Text
        cod_clie = registro_clientes.t1.Text
        t2.Enabled = False
        t4.Enabled = False
        t5.Enabled = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        t2.Enabled = False
        t3.Enabled = False
        t5.Enabled = False
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Text = Datos_Generales_del_Fondo.t2.Text
        nom_fondo = t5.Text
        cod_fondo = Datos_Generales_del_Fondo.t1.Text
    End Sub

    Private Sub registro_de_cuentas_bancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combo1()
        llenar_combo2()
        llenar_grid()

    End Sub

    Public Sub llenar_combo1()
        sql = "select cod_ban,(cod_ban+'  |  '+ n_banco) as dtos from reg_banco"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "dtos"
        cb1.ValueMember = "cod_ban"
    End Sub
    Public Sub llenar_combo2()
        sql = "select nocontrol,(nocontrol+'  |  '+ tmoneda) as dtos from moneda"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "dtos"
        cb2.ValueMember = "nocontrol"
    End Sub

    Private Sub llenar_grid()
        sql = "select * from v_datos_cuenta"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_datos_cuenta")
        dgv.DataSource = ds
        dgv.DataMember = "v_datos_cuenta"
        conexion.conexion2.Close()
    End Sub
End Class