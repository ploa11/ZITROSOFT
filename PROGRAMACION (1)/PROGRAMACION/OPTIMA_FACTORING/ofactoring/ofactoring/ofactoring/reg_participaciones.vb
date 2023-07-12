Public Class reg_participaciones
    'variables publicas
    Public nom_parti, cod_parti, nom_manco, cod_manco, nom_fondo, cod_fondo, cod_certi As String

    'variable locales
    Dim accion, sql, nc, gest, tip_partic As String
    Dim vc_act, mont_parti, num_parti As String
    Dim d1, m1, a1, d2, m2, a2, d3, m3, a3, dia1, mes1, dia2, mes2, dia3, mes3, fec_ini_b, fec_ini, fec_sal As String

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click, Button14.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea borrar al Participe?", "Registro de Participaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_d_participacion '" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
    End Sub

    Private Sub dtp3_ValueChanged(sender As Object, e As EventArgs) Handles dtp3.ValueChanged
        If cb3.Text = "FECHA DE INGRESO" Then
            dtp3.Enabled = True
            d3 = dtp3.Value.Date
            m3 = dtp3.Value.Date
            a3 = dtp3.Value.Year
            dia3 = d3.Substring(0, d3.IndexOf("/"))
            mes3 = m3.Substring(3, m3.IndexOf("/"))
            fec_ini_b = a3 + "-" + mes3 + "-" + dia3 'concatenar fecha inicia
            nc = fec_ini_b
            sql = "select *from v_d_participacion where [FECHA DE INGRESO] like'" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_participacion where [FECHA DE INGRESO] like'" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_participacion where [FECHA DE INGRESO] like'" + nc + "%'"
            conexion.conexion2.Close()
        End If
    End Sub

    Private Sub cb3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb3.SelectedIndexChanged

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        nc = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_d_participacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(12)
            t3.Text = dr(13)
            t4.Text = dr(3)
            t5.Text = dr(14)
            cb1.Text = dr(7)
            dtp1.Value = dr(5)
            dtp2.Value = dr(11)
            cb2.Text = dr(6)
            t6.Text = dr(10)
            t7.Text = dr(8)
            t8.Text = dr(9)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If cb3.Text = "NOMBRE Y APELLIDOS" Then
            nc = TextBox1.Text
            sql = "select *from v_d_participacion where [NOMBRE DE PARTICIPE] like'" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_participacion where [NOMBRE DE PARTICIPE] like'" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_participacion where [NOMBRE DE PARTICIPE] like'" + nc + "%'"
            conexion.conexion2.Close()
        Else
            If cb3.Text = "MANCOMUNADO" Then
                nc = TextBox1.Text
                sql = "select *from v_d_participacion where [NOMBRE DE MANCOMUNADO] like'" + nc + "%'"
                conexion.conectarfondo()
                da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *from v_d_participacion where [NOMBRE DE MANCOMUNADO] like'" + nc + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select *from v_d_participacion where [NOMBRE DE MANCOMUNADO] like'" + nc + "%'"
                conexion.conexion2.Close()

            End If
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        cb1.Text = ""
        If cb1.SelectedItem = "INDIVIDUAL" Then
            t1.Enabled = True
            t2.Enabled = False
            t2.Text = "NO APLICA"
            Button6.Enabled = True
            Button7.Enabled = False
        Else
            If cb1.SelectedItem = "MANCOMUNADO" Then
                t3.Enabled = True
                t2.Enabled = False
                t2.Text = "NO APLICA"
                Button7.Enabled = True
                Button6.Enabled = False
            End If
        End If
        '-----------------------------------
    End Sub

    'variable de conexion sql
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim res As Integer


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button13.Click
        '---------------------------
        'fechas
        '---------------------------
        d1 = dtp1.Value.Date
        m1 = dtp1.Value.Date
        a1 = dtp1.Value.Year
        d2 = dtp2.Value.Date
        m2 = dtp2.Value.Date
        a2 = dtp2.Value.Year
        dia1 = d1.Substring(0, d1.IndexOf("/"))
        mes1 = m1.Substring(3, m1.IndexOf("/"))
        dia2 = d2.Substring(0, d2.IndexOf("/"))
        mes2 = m2.Substring(3, m2.IndexOf("/"))
        fec_ini = a1 + mes1 + dia1 'concatenar fecha inicia
        fec_sal = a2 + mes2 + dia2 'concatenar fecha salida
        '-----------------------------------------------------

        nc = t1.Text
        tip_partic = cb1.Text
        nom_parti = t2.Text
        nom_manco = t3.Text
        cod_certi = t4.Text
        nom_fondo = t5.Text
        gest = cb2.Text
        vc_act = t6.Text
        mont_parti = t7.Text
        num_parti = t8.Text


        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_d_participacion'" + t1.Text + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de Participacion ya existe", "Registro de Participacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_d_participacion '" + cod_parti + "','" + cod_manco + "','" + cod_certi + "','" + cod_fondo + "','" + fec_ini + "','" + gest + "','" + tip_partic + "','" + mont_parti + "','" + num_parti + "','" + vc_act + "','" + fec_sal + "','" + nom_parti + "','" + nom_manco + "','" + nom_fondo + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")


            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_d_participacion '" + nc + "','" + cod_parti + "','" + cod_manco + "','" + cod_certi + "','" + cod_fondo + "','" + fec_ini + "','" + gest + "','" + tip_partic + "','" + mont_parti + "','" + num_parti + "','" + vc_act + "','" + fec_sal + "','" + nom_parti + "','" + nom_manco + "','" + nom_fondo + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If

        llenar_grid()
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t8.Enabled = False
        cb1.Enabled = False
        cb2.Enabled = False
        dtp1.Enabled = False
        dtp2.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = Datos_Generales_del_Fondo.t2.Text
        cod_fondo = Datos_Generales_del_Fondo.t1.Text
        t6.Text = Datos_Generales_del_Fondo.t8.Text
        t7.Text = 0.00000
        t8.Text = 0.00000
        cb1.Text = ""
        cb2.Text = ""
        dtp1.Text = ""
        dtp2.Text = Datos_Generales_del_Fondo.t15.Text
        Button6.Enabled = False
        Button7.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        vc_act = t6.Text
        mont_parti = t7.Text
        t8.Text = vc_act * mont_parti
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Regristro_mancomunado.Button6_Click(sender, e)
        t3.Text = nom_manco



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button12.Click
        nc = InputBox("Ingrese el Codigo de Participacion")
        sql = "exec ver_d_participacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(12)
            t3.Text = dr(13)
            t4.Text = dr(3)
            t5.Text = dr(14)
            cb1.Text = dr(7)
            dtp1.Value = dr(5)
            dtp2.Value = dr(11)
            cb2.Text = dr(6)
            t6.Text = dr(10)
            t7.Text = dr(8)
            t8.Text = dr(9)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dtp3.Enabled = True
        cb3.Enabled = True
        TextBox1.Enabled = True
        llenar_grid()
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        registro_participes.Button5_Click(sender, e)
        t2.Text = nom_parti
        cod_parti = registro_participes.t8.Text

    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged
        ' activar t2 y t3 con sus botones
        'cb1.Text = ""
        ' If cb1.SelectedItem = "Individual" Then
        't2.Enabled = True
        't3.Enabled = False
        '    t3.Text = "NO APLICA"
        ' Button6.Enabled = True
        'Button7.Enabled = False
        'Else
        'If cb1.SelectedItem = "Mancomunado" Then
        '  t3.Enabled = True
        '      t2.Enabled = False
        't2.Text = "NO APLICA"
        '  Button7.Enabled = True
        '       Button6.Enabled = False
        ' End If
        ' End If
        '-----------------------------------
    End Sub

    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub reg_participaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        llenar_combo1()
        llenar_grid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button10.Click
        accion = "guardar"
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        dtp1.Enabled = True
        dtp2.Enabled = True
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = Datos_Generales_del_Fondo.t2.Text
        cod_fondo = Datos_Generales_del_Fondo.t1.Text
        t6.Text = Datos_Generales_del_Fondo.t8.Text
        t7.Text = 0.00000
        t8.Text = 0.00000
        cb1.Text = ""
        cb2.Text = ""
        dtp1.Text = ""
        dtp2.Text = Datos_Generales_del_Fondo.t15.Text

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click, Button11.Click
        accion = "editar"
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        dtp1.Enabled = True
        dtp2.Enabled = True
    End Sub

    Public Sub llenar_combo1()
        sql = "select *from gestio_bdp"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "gestio_bdp"
        cb2.ValueMember = "gestion"
    End Sub

    Private Sub llenar_grid()
        sql = "select * from v_d_participacion"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_d_participacion")
        dgv.DataSource = ds
        dgv.DataMember = "v_d_participacion"
        conexion.conexion2.Close()
    End Sub


End Class