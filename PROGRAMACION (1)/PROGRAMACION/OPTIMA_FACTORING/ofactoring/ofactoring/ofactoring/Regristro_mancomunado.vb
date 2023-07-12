Public Class Regristro_mancomunado

    'variable publica
    Public n_manc, cod_manc As String
    'variable locales
    Dim accion, accion2, parti, cod_mac As String
    Dim nom, nom_manc, cod_parti, appat, appam, t_doc, n_doc, f_ingreso, f_salida, codigo As String

    'variable de busqueda bd genearl y bd fondo
    Dim nc, sql As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub dgv2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellContentClick
        t1.Text = dgv2.Rows(dgv2.CurrentRow.Index).Cells(0).Value
        t4.Text = dgv2.Rows(dgv2.CurrentRow.Index).Cells(1).Value
        t5.Text = dgv2.Rows(dgv2.CurrentRow.Index).Cells(2).Value
        t6.Text = dgv2.Rows(dgv2.CurrentRow.Index).Cells(3).Value
        t7.Text = dgv2.Rows(dgv2.CurrentRow.Index).Cells(4).Value
        t8.Text = dgv2.Rows(dgv2.CurrentRow.Index).Cells(5).Value
        dtp1.Value = dgv2.Rows(dgv2.CurrentRow.Index).Cells(6).Value
        dtp2.Value = dgv2.Rows(dgv2.CurrentRow.Index).Cells(7).Value
        t3.Text = dgv2.Rows(dgv2.CurrentRow.Index).Cells(8).Value
        Button11.Enabled = True
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        accion2 = "guardar"
        t3.Enabled = False
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True

        Button1.Enabled = True
        dtp1.Enabled = True
        dtp2.Enabled = True
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""


    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        t2.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(1).Value
        dtp1.Value = dgv.Rows(dgv.CurrentRow.Index).Cells(2).Value
        dtp2.Value = dgv.Rows(dgv.CurrentRow.Index).Cells(3).Value
        Button5.Enabled = True
        llenar_grid2()


    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        registro_de_cuentas_bancos.t8.Text = t2.Text
        registro_de_cuentas_bancos.cod_manc = t1.Text
        registro_de_cuentas_bancos.Show()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        accion2 = "editar"
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        dtp3.Enabled = True
        dtp4.Enabled = True
        Button3.Enabled = True
        Button9.Enabled = True





    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea borrar el Mancomunado?", "Registro de Mancomunados", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_mancomunado '" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        llenar_grid2()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t8.Enabled = False
        dtp1.Enabled = False
        dtp2.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""
        dtp1.Text = ""
        dtp2.Text = ""

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        nc = t1.Text
        n_doc = t8.Text
        cod_parti = t3.Text
        res = MessageBox.Show("¿Desea borrar al Participe de Mancomunado?", "Registro de Participes en Mancomunado", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_parti_mancomunado '" + nc + "','" + n_doc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid2()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t8.Enabled = False
        dtp1.Enabled = False
        dtp2.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""
        dtp1.Text = ""
        dtp2.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'guardar fechas sql
        diap1 = dtp3.Value.Date
        mesp1 = dtp3.Value.Date
        ap1 = dtp3.Value.Year
        diap2 = dtp4.Value.Date
        mesp2 = dtp4.Value.Date
        ap2 = dtp4.Value.Year
        dp1 = diap1.Substring(0, diap1.IndexOf("/"))
        mp1 = mesp1.Substring(3, mesp1.IndexOf("/"))
        dp2 = diap2.Substring(0, diap2.IndexOf("/"))
        mp2 = mesp2.Substring(3, mesp2.IndexOf("/"))
        f_inip = ap1 + mp1 + dp1 'concatenar fecha inicia
        f_salp = ap2 + mp2 + dp2 'concatenar fecha salida
        'fin de fechas sql
        Button1.Enabled = True
        Button3.Enabled = True
        '---------------------------------------------------------
        '-registro de los datos
        cod_mac = UCase(t1.Text)
        nom = UCase(t4.Text)
        appat = UCase(t5.Text)
        appam = UCase(t6.Text)
        t_doc = UCase(t7.Text)
        n_doc = UCase(t8.Text)
        cod_parti = UCase(t3.Text)
        sql = ""

        If accion2 = "guardar" Then
            sql = "exec ver_parti_mancumunado'" + cod_mac + "','" + n_doc + "','" + cod_parti + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "Datos Participes Mancomunados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_part_mancumunados '" + cod_mac + "','" + nom + "','" + appat + "','" + appam + "','" + t_doc + "','" + n_doc + "','" + f_inip + "','" + f_salp + "','" + cod_parti + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion2 = "editar" Then
            sql = "exec edita_part_mancumunados'" + nc + "','" + cod_mac + "','" + nom + "','" + appat + "','" + appam + "','" + t_doc + "','" + n_doc + "','" + f_inip + "','" + f_salp + "','" + cod_parti + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid2()
        t1.Enabled = False
        t2.Enabled = False
        dtp1.Enabled = False
        dtp2.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t8.Enabled = False
        dtp3.Enabled = False
        dtp4.Enabled = False
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""
        dtp3.Text = ""
        dtp4.Text = ""




    End Sub

    Private Sub Regristro_mancomunado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        llenar_grid2()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'guardar fechas sql
        dia1 = dtp1.Value.Date
        mes1 = dtp1.Value.Date
        a1 = dtp1.Value.Year
        dia2 = dtp2.Value.Date
        mes2 = dtp2.Value.Date
        a2 = dtp2.Value.Year
        d1 = dia1.Substring(0, dia1.IndexOf("/"))
        m1 = mes1.Substring(3, mes1.IndexOf("/"))
        d2 = dia2.Substring(0, dia2.IndexOf("/"))
        m2 = mes2.Substring(3, mes2.IndexOf("/"))
        f_ini = a1 + m1 + d1 'concatenar fecha inicia
        f_sali = a2 + m2 + d2 'concatenar fecha salida
        'fin de fechas sql
        Button10.Enabled = True
        '---------------------------------------------------------
        '-registro de los datos
        nc = UCase(t1.Text)
        nom_manc = UCase(t2.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_d_mancumunado'" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "Datos Mancomunados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_d_mancumunado '" + nom_manc + "','" + f_ini + "','" + f_sali + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_d_mancumunado'" + nc + "','" + nom_manc + "','" + f_ini + "','" + f_sali + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        dtp1.Enabled = True
        dtp2.Enabled = True

        nc = UCase(t2.Text)
        sql = "exec ver_d_mancumunado '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            'cod_manc = dr(0)
            ' n_manc = dr(1)
            dtp1.Value = dr(2)
            dtp2.Value = dr(3)


        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        llenar_grid2()
        dr.Close()
        conexion.conexion2.Close()


    End Sub

    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    'variables de fecha
    Dim d1, dia1, mes1, dia2, mes2, d2, m1, m2, a1, a2, f_ini, f_sali, diap1, diap2, mesp1, mesp2, anp1, anp2, dp1, dp2, mp1, mp2, ap1, ap2, f_inip, f_salp As String

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "guardar"
        t2.Enabled = True

        Button2.Enabled = True

        Button7.Enabled = True
        dtp1.Enabled = True
        dtp2.Enabled = True
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""
        dtp2.Text = Datos_Generales_del_Fondo.t15.Text
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        accion = "editar"
        t2.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        dtp1.Enabled = True
        dtp2.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button3.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button11.Enabled = True
        If t4.Enabled = True Then

            registro_participes.Button5_Click(sender, e)
            t3.Text = registro_participes.c_parti
            t4.Text = registro_participes.nom_parti
            t5.Text = registro_participes.apellidop
            t6.Text = registro_participes.apellidom
            t7.Text = registro_participes.tipo_docu
            t8.Text = registro_participes.numero_doc
        Else
            nc = InputBox("Ingrese el Codigo de datos de Participe Mancomunado")
                sql = "exec ver_part_mancumunado '" + nc + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
            If dr.Read Then
                t1.Text = dr(1)
                t3.Text = dr(9)
                t4.Text = dr(2)
                t5.Text = dr(3)
                t6.Text = dr(4)
                t7.Text = dr(5)
                t8.Text = dr(6)
                dtp3.Value = dr(7)
                dtp4.Value = dr(8)


            Else
                MessageBox.Show("Los Datos no Existen")
                End If
                llenar_grid2()
                dr.Close()
                conexion.conexion2.Close()

            End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        registro_participes.Show()

    End Sub

    Public Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button1.Enabled = True
        Button5.Enabled = True
        Button2.Enabled = True
        Button7.Enabled = True


        nc = InputBox("Ingrese el Codigo de Mancomunado")
        sql = "exec ver_d_mancumunado '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            reg_participaciones.cod_manco = dr(0)
            t2.Text = dr(1)
            reg_participaciones.nom_manco = dr(1)
            dtp1.Value = dr(2)
            dtp2.Value = dr(3)


        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        llenar_grid2()
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub llenar_grid()
        sql = "select * from v_d_mancumunado"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_d_mancumunado")
        dgv.DataSource = ds
        dgv.DataMember = "v_d_mancumunado"
        conexion.conexion2.Close()
    End Sub
    Private Sub llenar_grid2()
        sql = "select * from v_part_mancumunado where [CODIGO DE MANCOMUNADO]='" + t1.Text + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_part_mancumunado where [CODIGO DE MANCOMUNADO]='" + t1.Text + "'")
        dgv2.DataSource = ds
        dgv2.DataMember = "v_part_mancumunado where [CODIGO DE MANCOMUNADO]='" + t1.Text + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub llenar_grid3()
        sql = "select * from v_part_mancumunado"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_part_mancumunado")
        dgv2.DataSource = ds
        dgv2.DataMember = "v_part_mancumunado"
        conexion.conexion2.Close()
    End Sub

    Private Sub buscar()
        nc = "MA001"
        sql = "exec veri_mancumunado '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(10)
            't3.Text = dr(1)
            ' t4.Text = dr(2)
            't5.Text = dr(3)
            't6.Text = dr(4)
            't7.Text = dr(5)
            't8.Text = dr(6)
            dtp1.Value = dr(7)
            dtp2.Value = dr(8)
            t2.Text = dr(9)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub
End Class