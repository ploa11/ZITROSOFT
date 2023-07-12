Public Class Actualizacion_de_datos
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

    'variables publicas
    Dim dist_bene, moneda, nom_parti, cod_parti, nom_manco, cod_manco, nom_fondo, cod_fondo, unida_nego, gestion As String
    Dim mont_minimo, mont_maxi, v_cuota_nominal, v_cuota_actual, patrimonio, patri_ini As String
    Dim n_ruc As String
    Dim fecha, dat_tim1, dat_tim2 As Date
    Dim fecha_S As String



    'variable locales
    Dim accion, sql, nc, gest, tip_partic As String

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        nc = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_datos_fondosc '" + nc + "'"
        'sql = "exec ver_d_participacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            cfondo.accion = "editar"
            cfondo.nc = dr(0)
            TextBox1.Text = dr(0)
            cfondo.nfon = dr(2)
            TextBox2.Text = dr(2)
            cfondo.mon = dr(3)
            TextBox3.Text = dr(3)
            cfondo.m_minimo = dr(4)
            TextBox4.Text = dr(4)
            cfondo.m_maximo = dr(5)
            TextBox5.Text = dr(5)
            cfondo.cap_actual = dr(18)
            TextBox6.Text = dr(18)
            cfondo.u_neg = dr(7)
            TextBox7.Text = dr(7)
            cfondo.DTP1.Value = dr(8)
            cfondo.fecha = cfondo.DTP1.Value.ToString("yyyyMMdd")
            TextBox8.Text = dr(8)
            cfondo.DTP2.Value = dr(9)
            cfondo.fecha2 = cfondo.DTP2.Value.ToString("yyyyMMdd")
            TextBox9.Text = dr(9)
            cfondo.n_ruc = dr(10)
            TextBox10.Text = dr(10)
            cfondo.DTP3.Value = dr(11)
            cfondo.fecha3 = cfondo.DTP3.Value.ToString("yyyyMMdd")
            TextBox11.Text = dr(11)
            cfondo.DTP4.Value = dr(12)
            cfondo.fecha4 = cfondo.DTP4.Value.ToString("yyyyMMdd")
            TextBox12.Text = dr(12)
            cfondo.v_cuo_nominal = dr(13)
            TextBox13.Text = dr(13)
            cfondo.v_cuo_act = dr(14)
            TextBox14.Text = dr(14)
            cfondo.gest = dr(15)
            TextBox15.Text = dr(15)
            cfondo.nro_cuotas = dr(19)
            TextBox16.Text = dr(19)
            'dtp1.Value = dr(1)
            'cb1.Text = dr(4)
            't6.Text = dr(6)

            If MsgBox("SE VA EL CIERRE DEL DIA ", MsgBoxStyle.YesNo, "ESTA SEGURO ?") = vbYes Then
                Button9.Enabled = True
            End If

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Dim vc_act, mont_parti, num_parti As String
    'varivlae de fecha
    Dim fec_crea, fec_ini_sunat, fec_ini_opera, fec_ter_opera, fec_actu As String

    Private Sub t10_TextChanged(sender As Object, e As EventArgs) Handles t10.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        'TOTAL_EGRESOS()
        suma_parti()
        retiro_parti()
        reinversion_participe()
        retiro_reparticiones()
        r_numero_parti()
        t22.Text = ((TextBox18.Text - TextBox17.Text) - TextBox20.Text) + TextBox19.Text
        suma_cranx()
        int_diario()
        egreso_diario()
        patri_actual()
        nro_cuotas()


    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        fecha = dtp1.Value
        fecha_S = fecha.ToString("yyyyMMdd")
    End Sub
    'variable de conexion sql
    Dim ds As DataSet
    Dim dt As DataTable

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        If t6.Text = 0.000 And t10.Text = t9.Text Then
            ingreso_participaciones()
            retiro_participaciones()
            reinversion()
            reti_reparticiones()
            reti_n_participaciones()
            suma_parti()
            retiro_parti()
            reinversion_participe()
            retiro_reparticiones()
            r_numero_parti()
            t22.Text = ((TextBox18.Text - TextBox17.Text) - TextBox20.Text) + TextBox19.Text
            gast_adm_fomdo.dtp1.Value = dtp1.Value
            gast_adm_fomdo.t3.Text = t22.Text
            gast_adm_fomdo.t6.Text = t15.Text
        Else
            gast_adm_fomdo.dtp1.Value = dtp1.Value
            gast_adm_fomdo.t3.Text = t6.Text
            gast_adm_fomdo.t6.Text = t15.Text
        End If
        gast_adm_fomdo.Show()
    End Sub

    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        'cfondo.Button5_Click(sender, e)
        If cfondo.accion = "editar" Then
            sql = "exec edita_nfondo'" + cfondo.nc + "','" + cfondo.nfon + "','" + cfondo.nomsql + "','" + cfondo.mon + "','" + cfondo.m_minimo + "','" + cfondo.m_maximo + "','" + cfondo.cap_actual + "','" + cfondo.v_cuo_nominal + "','" + cfondo.v_cuo_act + "','" + cfondo.u_neg + "','" + cfondo.fecha + "','" + cfondo.fecha2 + "','" + cfondo.gest + "','" + cfondo.fecha3 + "','" + cfondo.fecha4 + "','" + cfondo.n_ruc + "','" + cfondo.nro_cuotas + "','" + TextBox21.Text + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            MessageBox.Show("Datos de Fondo Actualizados")
        End If


    End Sub

    Private Sub nro_cuotasi_TextChanged(sender As Object, e As EventArgs) Handles nro_cuotasi.TextChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        vcf()
        Button5.Enabled = True
    End Sub

    Dim res As Integer

    Private Sub t11_TextChanged(sender As Object, e As EventArgs) Handles t11.TextChanged

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form2.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Me.Close()
    End Sub

    Private Sub t12_TextChanged(sender As Object, e As EventArgs) Handles t12.TextChanged

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        dgv2.Visible = True
        llenar_grid()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        egresos()
        ingresos_de_interes()
        ingreso_participaciones()
        retiro_participaciones()
        reinversion()
        reti_reparticiones()
        reti_n_participaciones()
        ingreso_cranx()
        EGRESOS_DIARIOS()

        MsgBox("CALCULOS REALIZADOS")
        'suma_interes_fila()
        'TOTAL_EGRESOS()

        'Datos_Generales_del_Fondo.Button3_Click(sender, e)
        'suma_grid2()
        'accion = "guardar"
        'dtp1.Enabled = True

    End Sub

    Private Sub ingreso_participaciones()
        fecha_S = dtp1.Value.ToString("yyyyMMdd")
        sql = "select 'INGRESOS DE PARTICIPACION' AS [TIPO DE INGRESO], sum(mont_part) as
                [INGRESO] from d_participacion where  f_ingreso='" + fecha_S + "' and estado='VIGENTE'"
        'sql = "select sum(mont_PART) as [MONTO DE PARTICIPACION] from d_participacion where  f_ingreso='" + fecha_S + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select 'INGRESOS DE PARTICIPACION' AS [TIPO DE INGRESO], sum(mont_part) as
                [INGRESO] from d_participacion where  f_ingreso='" + fecha_S + "' and estado='VIGENTE'")
        dgv6.DataSource = ds
        dgv6.DataMember = "select 'INGRESOS DE PARTICIPACION' AS [TIPO DE INGRESO], sum(mont_part) as
                [INGRESO] from d_participacion where  f_ingreso='" + fecha_S + "' and estado='VIGENTE'"
        conexion.conexion2.Close()
    End Sub
    Private Sub retiro_participaciones()
        fecha_S = dtp1.Value.ToString("yyyyMMdd")
        sql = "select 'RETIRO DE PARTICIPACION' AS [RETIRO DE INGRESO], sum(mont_part) as
                [INGRESO] from d_participacion where  fec_rescate='" + fecha_S + "' and estado='RESCATE'"
        'sql = "select sum(mont_PART) as [MONTO DE PARTICIPACION] from d_participacion where  f_ingreso='" + fecha_S + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select 'RETIRO DE PARTICIPACION' AS [RETIRO DE INGRESO], sum(mont_part) as
                [INGRESO] from d_participacion where  fec_rescate='" + fecha_S + "' and estado='RESCATE'")
        dgv8.DataSource = ds
        dgv8.DataMember = "select 'RETIRO DE PARTICIPACION' AS [RETIRO DE INGRESO], sum(mont_part) as
                [INGRESO] from d_participacion where  fec_rescate='" + fecha_S + "' and estado='RESCATE'"
        conexion.conexion2.Close()
    End Sub
    Private Sub reinversion()
        fecha_S = dtp1.Value.ToString("yyyyMMdd")
        sql = "select 'INGRESOS DE REINVERSION' AS [TIPO DE INGRESO], sum(beneficiot) as
                [INGRESO] from repart_bene_resc where  fec_repat='" + fecha_S + "' and tip_distri='REINVIERTE'"
        'sql = "select sum(mont_PART) as [MONTO DE PARTICIPACION] from d_participacion where  f_ingreso='" + fecha_S + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select 'INGRESOS DE REINVERSION' AS [TIPO DE INGRESO], sum(beneficiot) as
                [INGRESO] from repart_bene_resc where  fec_repat='" + fecha_S + "' and tip_distri='REINVIERTE'")
        dgv9.DataSource = ds
        dgv9.DataMember = "select 'INGRESOS DE REINVERSION' AS [TIPO DE INGRESO], sum(beneficiot) as
                [INGRESO] from repart_bene_resc where  fec_repat='" + fecha_S + "' and tip_distri='REINVIERTE'"
        conexion.conexion2.Close()
    End Sub

    Private Sub reti_reparticiones()
        fecha_S = dtp1.Value.ToString("yyyyMMdd")
        sql = "select 'INGRESOS DE REINVERSION' AS [TIPO DE INGRESO], sum(beneficiot) as
                [INGRESO] from repart_bene_resc where  fec_repat='" + fecha_S + "' and tip_distri='REPARTIR'"
        'sql = "select sum(mont_PART) as [MONTO DE PARTICIPACION] from d_participacion where  f_ingreso='" + fecha_S + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select 'INGRESOS DE REINVERSION' AS [TIPO DE INGRESO], sum(beneficiot) as
                [INGRESO] from repart_bene_resc where  fec_repat='" + fecha_S + "' and tip_distri='REPARTIR'")
        dgv10.DataSource = ds
        dgv10.DataMember = "select 'INGRESOS DE REINVERSION' AS [TIPO DE INGRESO], sum(beneficiot) as
                [INGRESO] from repart_bene_resc where  fec_repat='" + fecha_S + "' and tip_distri='REPARTIR'"
        conexion.conexion2.Close()
    End Sub

    Private Sub reti_n_participaciones()
        fecha_S = dtp1.Value.ToString("yyyyMMdd")
        sql = "select 'RETIRO DE PARTICIPACIONES' AS [TIPO DE RETIRO], sum(n_parti) as
                [INGRESO] from d_participacion where  fec_rescate='" + fecha_S + "' and estado='RESCATE'"
        'sql = "select sum(mont_PART) as [MONTO DE PARTICIPACION] from d_participacion where  f_ingreso='" + fecha_S + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select 'RETIRO DE PARTICIPACIONES' AS [TIPO DE RETIRO], sum(n_parti) as
                [INGRESO] from d_participacion where  fec_rescate='" + fecha_S + "' and estado='RESCATE'")
        dgv11.DataSource = ds
        dgv11.DataMember = "select 'RETIRO DE PARTICIPACIONES' AS [TIPO DE RETIRO], sum(n_parti) as
                [INGRESO] from d_participacion where  fec_rescate='" + fecha_S + "' and estado='RESCATE'"
        conexion.conexion2.Close()
    End Sub




    Private Sub OTROSGASTOS()
        fecha_S = dtp1.Value.ToString("yyyyMMdd")
        sql = "select sum(monto) as [MONTO OTROS GASTOS DEL DIA] from OTROS_GASTOS where  fecha='" + fecha_S + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select sum(monto) as [MONTO OTROS GASTOS DEL DIA] from OTROS_GASTOS where  fecha='" + fecha_S + "'")
        dgv3.DataSource = ds
        dgv3.DataMember = "select sum(monto) as [MONTO OTROS GASTOS DEL DIA] from OTROS_GASTOS where  fecha='" + fecha_S + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub ADMINISTRACIONFONDO()
        fecha_S = dtp1.Value.ToString("yyyyMMdd")
        sql = "select sum(monto) as [MONTO ADMINISTRACION DE FONDO] from GAST_ADM_FONDO where  F_GASTO='" + fecha_S + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select sum(monto) as [MONTO ADMINISTRACION DE FONDO] from GAST_ADM_FONDO where  F_GASTO='" + fecha_S + "'")
        dgv4.DataSource = ds
        dgv4.DataMember = "select sum(monto) as [MONTO ADMINISTRACION DE FONDO] from GAST_ADM_FONDO where  F_GASTO='" + fecha_S + "'"
        conexion.conexion2.Close()
    End Sub


    Private Sub egresos()
        fecha_S = dtp1.Value.ToString("yyyyMMdd")
        sql = "select 'GASTOS BANCARIOS' as [TIPO DE GASTO], 
                sum(MONTO) AS [GASTOS] from GAST_BANC where  FECHA='" + fecha_S + "' UNION 
                ALL select 
                'GASTO POR CAPTACION DE CLIENTE', sum(MONTO)  from GAST_POR_CAP_CLIE 
                where  F_GAS_CAP_CLIE='" + fecha_S + "' UNION ALL select 'GASTO POR 
                INVESTIGACION DE MERCADO', sum(MONTO) from GAST_POR_INVES_MERC where  
                FECHA='" + fecha_S + "' UNION ALL select 
                'OTROS GASTOS', sum(MONTO) from OTROS_GASTOS where  FECHA='" + fecha_S + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select 'GASTOS BANCARIOS' as [TIPO DE GASTO], 
                sum(MONTO) As [GASTOS] from GAST_BANC where  FECHA='" + fecha_S + "' UNION 
                ALL select 
                'GASTO POR CAPTACION DE CLIENTE', sum(MONTO)  from GAST_POR_CAP_CLIE 
                where  F_GAS_CAP_CLIE='" + fecha_S + "' UNION ALL select 'GASTO POR 
                INVESTIGACION DE MERCADO', sum(MONTO) from GAST_POR_INVES_MERC where  
                FECHA='" + fecha_S + "' UNION ALL select 
                'OTROS GASTOS', sum(MONTO) from OTROS_GASTOS where  FECHA='" + fecha_S + "'")
        dgv12.DataSource = ds
        dgv12.DataMember = "select 'GASTOS BANCARIOS' as [TIPO DE GASTO], 
                sum(MONTO) AS [GASTOS] from GAST_BANC where  FECHA='" + fecha_S + "' UNION 
                ALL select 
                'GASTO POR CAPTACION DE CLIENTE', sum(MONTO)  from GAST_POR_CAP_CLIE 
                where  F_GAS_CAP_CLIE='" + fecha_S + "' UNION ALL select 'GASTO POR 
                INVESTIGACION DE MERCADO', sum(MONTO) from GAST_POR_INVES_MERC where  
                FECHA='" + fecha_S + "' UNION ALL select 
                'OTROS GASTOS', sum(MONTO) from OTROS_GASTOS where  FECHA='" + fecha_S + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub ingresos_de_interes()
        dat_tim2 = dtp1.Value
        Dim wD As Long = DateDiff(DateInterval.DayOfYear, dat_tim1, dat_tim2)
        sql = "select 'INGRESOS DIARIOS DE INTERES' AS [TIPO DE INGRESO], sum(DIA" & wD + 1 & ") as 
                [INGRESO] from NUM_DIAS_CRANX where  GESTION='" + t15.Text + "' and estado in( 'VIGENTE','MORA','ADELANTADO')"

        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select 'INGRESOS DIARIOS DE INTERES' AS [TIPO DE INGRESO], sum(DIA" & wD + 1 & ") as 
                [INGRESO] from NUM_DIAS_CRANX where  GESTION='" + t15.Text + "' and estado in( 'VIGENTE','MORA','ADELANTADO')")
        dgv4.DataSource = ds
        dgv4.DataMember = "select 'INGRESOS DIARIOS DE INTERES' AS [TIPO DE INGRESO], sum(DIA" & wD + 1 & ") as 
                [INGRESO] from NUM_DIAS_CRANX where  GESTION='" + t15.Text + "' and estado in( 'VIGENTE','MORA','ADELANTADO')"

        conexion.conexion2.Close()
    End Sub
    Private Sub EGRESOS_DIARIOS()
        dat_tim2 = dtp1.Value
        Dim wD As Long = DateDiff(DateInterval.DayOfYear, dat_tim1, dat_tim2)
        sql = "select 'EGRESOS DIARIOS' AS [TIPO DE INGRESO], sum(DIA" & wD + 1 & ") as 
                [EGRESO] from NUM_gastos where  GESTION='" + t15.Text + "' "

        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select 'EGRESOS DIARIOS' AS [TIPO DE INGRESO], sum(DIA" & wD + 1 & ") as 
                [EGRESO] from NUM_gastos where  GESTION='" + t15.Text + "' ")
        dgv5.DataSource = ds
        dgv5.DataMember = "select 'EGRESOS DIARIOS' AS [TIPO DE INGRESO], sum(DIA" & wD + 1 & ") as 
                [EGRESO] from NUM_gastos where  GESTION='" + t15.Text + "' "

        conexion.conexion2.Close()
    End Sub

    Private Sub ingreso_cranx()
        fecha_S = dtp1.Value.ToString("yyyyMMdd")
        sql = "select 'INGRESOS DE CUOTAS CRONOGRAMA' as [TIPO DE INGRESO], sum(amortizacion)  as [INGRESOS]
                from cuotas_operacion where  f_venci='" + fecha_S + "' and estado='CANCELADO' UNION 
                ALL select 'INGRESO POR FACTURAS DE ANEXO', sum(mont_descu) from fac_operacion_anx where  fec_venc_doc='" + fecha_S + "' and estado='CANCELADO'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select 'INGRESOS DE CUOTAS CRONOGRAMA' as [TIPO DE INGRESO], sum(amortizacion)  as [INGRESOS]
                from cuotas_operacion where  f_venci='" + fecha_S + "' and estado='CANCELADO' UNION
                ALL select 'INGRESO POR FACTURAS DE ANEXO', sum(mont_descu) from fac_operacion_anx where  fec_venc_doc='" + fecha_S + "' and estado='CANCELADO'")
        dgv3.DataSource = ds
        dgv3.DataMember = "select 'INGRESOS DE CUOTAS CRONOGRAMA' as [TIPO DE INGRESO], sum(amortizacion)  as [INGRESOS]
                from cuotas_operacion where  f_venci='" + fecha_S + "' and estado='CANCELADO' UNION
                ALL select 'INGRESO POR FACTURAS DE ANEXO', sum(mont_descu) from fac_operacion_anx where  fec_venc_doc='" + fecha_S + "' and estado='CANCELADO'"

        conexion.conexion2.Close()
        'Dim su_mm As Decimal
        'Fo'r Each Row As DataGridViewRow In dgv3.Rows
        ' If Row.Cells("ingresos").Value Then
        '     Row.Cells("ingresos").Value = 0
        'su_mm = Row.Cells("ingresos").Value
        'Else
        'su_mm = Row.Cells("ingresos").Value

        'End If

        'T19.Text = su_mm
        '  Next
        'T19.Text = su_mm

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        dgv2.Visible = False
        dgv.Visible = True
        'd1 = dtp1.Value.Date
        'm1 = dtp1.Value.Date
        'a1 = dtp1.Value.Year
        'd2 = dtp2.Value.Date
        ' m2 = dtp2.Value.Date
        ' a2 = dtp2.Value.Year
        'd3 = dtp3.Value.Date
        ' m3 = dtp3.Value.Date
        ' a3 = dtp3.Value.Year
        ' d4 = dtp4.Value.Date
        'm4 = dtp4.Value.Date
        'a4 = dtp4.Value.Year
        'd5 = dtp5.Value.Date
        ' m5 = dtp5.Value.Date
        'a5 = dtp5.Value.Year
        'dia1 = d1.Substring(0, d1.IndexOf(" /"))
        'mes1 = m1.Substring(3, m1.IndexOf("/"))
        ' dia2 = d2.Substring(0, d2.IndexOf("/"))
        'mes2 = m2.Substring(3, m2.IndexOf("/"))
        'dia3 = d3.Substring(0, d3.IndexOf("/"))
        'mes3 = m3.Substring(3, m3.IndexOf("/"))
        'dia4 = d4.Substring(0, d4.IndexOf("/"))
        'mes4 = m4.Substring(3, m4.IndexOf("/"))
        ' dia5 = d5.Substring(0, d5.IndexOf("/"))
        'mes5 = m5.Substring(3, m5.IndexOf("/"))
        'fec_actu = a1 + mes1 + dia1 'concatenar fecha para actualizar
        'fec_crea = a2 + mes2 + dia2 'concatenar fecha creacion
        ' fec_ini_sunat = a3 + mes3 + dia3 ' concatenar fecha de inscripcion sunat
        'fec_ini_opera = a4 + mes4 + dia4 'concatenar fecha de inicio de operaciones
        'fec_ter_opera = a5 + mes5 + dia5 ' concatenar fecha de termino de operacion
        Dim fecha_crea As Date = dtp2.Value
        Dim fecha_ins_sunat As Date = dtp3.Value
        Dim fecha_ini_opera As Date = dtp4.Value
        Dim fecha_term_opera As Date = dtp5.Value
        Dim fechahoy As Date = dtp1.Value
        Dim nrocuotasf As String

        '-----------------------------------------------------
        fec_crea = fecha_crea.ToString("yyyyMMdd")
        fec_ini_sunat = fecha_ins_sunat.ToString("yyyyMMdd")
        fec_ini_opera = fecha_ini_opera.ToString("yyyyMMdd")
        fec_ter_opera = fecha_term_opera.ToString("yyyyMMdd")
        fec_actu = fechahoy.ToString("yyyyMMdd")
        cod_fondo = t1.Text
        dist_bene = t2.Text
        moneda = t3.Text
        mont_minimo = t4.Text
        mont_maxi = t5.Text
        nom_fondo = t13.Text
        unida_nego = t7.Text
        n_ruc = t8.Text
        v_cuota_nominal = t9.Text
        v_cuota_actual = vca.Text
        nrocuotasf = nro_cuotasf.Text
        gestion = t15.Text
        nom_fondo = t13.Text
        patri_ini = t6.Text
        patrimonio = t11.Text
        't11.Text = 0.0000


        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_datos_fondos'" + fec_actu + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Datos ya existen", "DATOS DE FONDOS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_DATOS_FONDO '" + cod_fondo + "','" + dist_bene + "','" + nom_fondo + "','" + moneda + "','" + mont_minimo + "','" + mont_maxi + "','" + patri_ini + "','" + unida_nego + "','" + fec_crea + "','" + fec_ini_sunat + "','" + n_ruc + "','" + fec_ini_opera + "','" + fec_ter_opera + "','" + v_cuota_nominal + "','" + v_cuota_actual + "','" + gestion + "','" + fec_actu + "','" + patrimonio + "','" + nrocuotasf + "','" + TextBox25.Text + "','" + TextBox26.Text + "','" + t10.Text + "'"
                'sql = "exec alta_DATOS_FONDO 'fo001','bimestral','Fondos nuevo ',' soles ','10000.222','20000.3333','construccion','20151010','20151111','1234567890','20171111','20221010','1000.00000','100.00000','2015','20171218'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")


            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_datos_fondo '" + cod_fondo + "','" + dist_bene + "','" + nom_fondo + "','" + moneda + "','" + mont_minimo + "','" + mont_maxi + "','" + patri_ini + "','" + unida_nego + "','" + fec_crea + "','" + fec_ini_sunat + "','" + n_ruc + "','" + fec_ini_opera + "','" + fec_ter_opera + "','" + v_cuota_nominal + "','" + v_cuota_actual + "','" + gestion + "','" + fec_actu + "','" + patrimonio + "','" + nrocuotasf + "','" + TextBox25.Text + "','" + TextBox26.Text + "','" + t10.Text + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If

        llenar_grid_fecha()
        'llenar_grid()
        'suma_grid2()
        'actualiza_datos()
    End Sub

    Private Sub actualiza_datos()

        'sql = ""
        sql = "exec edita_datos_fondos'" + cod_fondo + "','" + nom_fondo + "','" + v_cuota_nominal + "','" + v_cuota_actual + "','" + t6.Text + "','" + t11.Text + "','" + fec_actu + "','" + moneda + "'"
        'sql = "exec alta_DATOS_FONDO 'fo001','bimestral','Fondos nuevo ',' soles ','10000.222','20000.3333','construccion','20151010','20151111','1234567890','20171111','20221010','1000.00000','100.00000','2015','20171218'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        res = com.ExecuteNonQuery
        conexion.conexion.Close()
        MessageBox.Show("Datos de Fondo actualizado")



    End Sub


    Private Sub Actualizacion_de_datos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fecha = dtp1.Value
        'fecha_S = fecha.ToString("yyyyMMdd")
        dgv.AllowUserToAddRows = False
        dgv3.AllowUserToAddRows = False
        dgv4.AllowUserToAddRows = False
        dgv5.AllowUserToAddRows = False
        dgv6.AllowUserToAddRows = False
        dgv7.AllowUserToAddRows = False
        Me.Text = "Actualizacion de Ingreso de Participaciones" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        llenar_grid_fecha()
        'llenar_grid()
        dgv.Sort(dgv.Columns(0), System.ComponentModel.ListSortDirection.Descending)
        ano_gestion()
        'suma_grid2()
    End Sub

    Private Sub llenar_grid()
        sql = "select *from v_datos_fondo order by [FECHA ACTUAL] desc"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_datos_fondo")
        dgv2.DataSource = ds
        dgv2.DataMember = "v_datos_fondo"
        conexion.conexion2.Close()
    End Sub

    Private Sub llenar_grid_fecha()
        Dim fec_fil As String = dtp1.Value.ToString("yyyyMMdd")
        sql = "select *from v_datos_fondo where [FECHA ACTUAL]='" + fec_fil + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_datos_fondo")
        dgv.DataSource = ds
        dgv.DataMember = "v_datos_fondo"
        conexion.conexion2.Close()
    End Sub

    Private Sub suma_interes_fila()
        Dim c_t As Decimal
        fecha_S = dtp1.Value.ToString("yyyyMMdd")
        sql = "select * from num_dias_cranx where f_termino='" + fecha_S + "' AND ESTADO='CANCELADO'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "num_dias_cranx")
        dgv7.DataSource = ds
        dgv7.DataMember = "num_dias_cranx"
        conexion.conexion2.Close()

        For Each Row As DataGridViewRow In dgv7.Rows
            Dim x As Integer = 0
            Dim j As Integer = 366
            Dim y As Integer

            For y = x To j
                'c_t = Row.Cells("dia" & y).Value + c_t
                c_t += Val(Row.Cells(y).Value)
            Next

        Next
        t20.Text = c_t
    End Sub

    Private Sub suma_parti()

        Dim total As Double = 0
        Dim itotal As Integer = dgv6.Rows.Count
        ' Dim i As Integer

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        'For i = 0 To itotal - 1
        't'otal = total + Double.Parse(dgv6(7, i).Value)

        ' Next
        Try
            For Each row As DataGridViewRow In dgv6.Rows
                total += Val(row.Cells("ingreso").Value)
                'mt_desc += Val(row.Cells(mont_des).Value)
                ' mt_int += Val(row.Cells(mont_int).Value)
                ' mt_igv += Val(row.Cells(mont_igv).Value)
                'abono += Val(row.Cells(mont_abono).Value)
                'igv_comisi += Val(row.Cells(igv_com).Value)

            Next
            TextBox18.Text = Format(total, " #,##0.00000")
        Catch ex As Exception
            MsgBox("No hay Ingreso de  Pariticpaciones", MsgBoxStyle.Question, "Optima Inversiones")
            TextBox18.Text = "0.0000"
        End Try

    End Sub

    Private Sub retiro_parti()

        Dim total As Double = 0
        Dim itotal As Integer = dgv8.Rows.Count
        ' Dim i As Integer

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        'For i = 0 To itotal - 1
        't'otal = total + Double.Parse(dgv6(7, i).Value)

        ' Next
        Try
            For Each row As DataGridViewRow In dgv8.Rows
                total += Val(row.Cells("ingreso").Value)
                'mt_desc += Val(row.Cells(mont_des).Value)
                ' mt_int += Val(row.Cells(mont_int).Value)
                ' mt_igv += Val(row.Cells(mont_igv).Value)
                'abono += Val(row.Cells(mont_abono).Value)
                'igv_comisi += Val(row.Cells(igv_com).Value)

            Next
            TextBox17.Text = Format(total, " #,##0.00000")
        Catch ex As Exception
            MsgBox("No hay retiro Pariticpaciones", MsgBoxStyle.Question, "Optima Inversiones")
            TextBox17.Text = "0.0000"
        End Try

    End Sub

    Private Sub r_numero_parti()

        Dim total As Double = 0
        Dim itotal As Integer = dgv11.Rows.Count
        ' Dim i As Integer

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        'For i = 0 To itotal - 1
        't'otal = total + Double.Parse(dgv6(7, i).Value)

        ' Next
        Try
            For Each row As DataGridViewRow In dgv11.Rows
                total += Val(row.Cells("ingreso").Value)
                'mt_desc += Val(row.Cells(mont_des).Value)
                ' mt_int += Val(row.Cells(mont_int).Value)
                ' mt_igv += Val(row.Cells(mont_igv).Value)
                'abono += Val(row.Cells(mont_abono).Value)
                'igv_comisi += Val(row.Cells(igv_com).Value)

            Next
            TextBox22.Text = Format(total, " #,##0.00000")
        Catch ex As Exception
            MsgBox("No hay retiro de Numero de  Pariticpaciones", MsgBoxStyle.Question, "Optima Inversiones")
            TextBox22.Text = "0.0000"
        End Try

    End Sub

    Private Sub reinversion_participe()

        Dim total As Double = 0
        Dim itotal As Integer = dgv9.Rows.Count
        ' Dim i As Integer

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        'For i = 0 To itotal - 1
        't'otal = total + Double.Parse(dgv6(7, i).Value)

        ' Next
        Try
            For Each row As DataGridViewRow In dgv9.Rows
                total += Val(row.Cells("ingreso").Value)
                'mt_desc += Val(row.Cells(mont_des).Value)
                ' mt_int += Val(row.Cells(mont_int).Value)
                ' mt_igv += Val(row.Cells(mont_igv).Value)
                'abono += Val(row.Cells(mont_abono).Value)
                'igv_comisi += Val(row.Cells(igv_com).Value)

            Next
            TextBox19.Text = Format(total, " #,##0.00000")
        Catch ex As Exception
            MsgBox("No hay Ingreso de Reinversiones", MsgBoxStyle.Question, "Optima Inversiones")
            TextBox19.Text = "0.0000"
        End Try

    End Sub

    Private Sub retiro_reparticiones()

        Dim total As Double = 0
        Dim itotal As Integer = dgv10.Rows.Count
        ' Dim i As Integer

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        'For i = 0 To itotal - 1
        't'otal = total + Double.Parse(dgv6(7, i).Value)

        ' Next
        Try
            For Each row As DataGridViewRow In dgv10.Rows
                total += Val(row.Cells("ingreso").Value)
                'mt_desc += Val(row.Cells(mont_des).Value)
                ' mt_int += Val(row.Cells(mont_int).Value)
                ' mt_igv += Val(row.Cells(mont_igv).Value)
                'abono += Val(row.Cells(mont_abono).Value)
                'igv_comisi += Val(row.Cells(igv_com).Value)

            Next
            TextBox20.Text = Format(total, " #,##0.00000")
        Catch ex As Exception
            MsgBox("No hay Retiro de Reparticiones", MsgBoxStyle.Question, "Optima Inversiones")
            TextBox20.Text = "0.0000"
        End Try

    End Sub
    Private Sub int_diario()

        Dim total As Double = 0
        Dim itotal As Integer = dgv4.Rows.Count
        ' Dim i As Integer

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        'For i = 0 To itotal - 1
        't'otal = total + Double.Parse(dgv6(7, i).Value)

        ' Next
        Try
            For Each row As DataGridViewRow In dgv4.Rows
                total += Val(row.Cells("ingreso").Value)
                'mt_desc += Val(row.Cells(mont_des).Value)
                ' mt_int += Val(row.Cells(mont_int).Value)
                ' mt_igv += Val(row.Cells(mont_igv).Value)
                'abono += Val(row.Cells(mont_abono).Value)
                'igv_comisi += Val(row.Cells(igv_com).Value)

            Next

            t21.Text = Format(total, " #,##0.00000")


        Catch ex As Exception
            MsgBox("No hay Ingresos", MsgBoxStyle.Question, "Optima Inversiones")
            t21.Text = "0.00000"
        End Try

    End Sub
    Private Sub egreso_diario()

        Dim total As Double = 0
        Dim total2 As Double = 0
        'Dim itotal As Integer = dgv6.Rows.Count
        ' Dim i As Integer

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        'For i = 0 To itotal - 1
        't'otal = total + Double.Parse(dgv6(7, i).Value)

        ' Next
        Try
            For Each row As DataGridViewRow In dgv5.Rows
                total += Val(row.Cells("egreso").Value)
                'mt_desc += Val(row.Cells(mont_des).Value)
                ' mt_int += Val(row.Cells(mont_int).Value)
                ' mt_igv += Val(row.Cells(mont_igv).Value)
                'abono += Val(row.Cells(mont_abono).Value)
                'igv_comisi += Val(row.Cells(igv_com).Value)

            Next

            TextBox24.Text = Format(total, " #,##0.00000")



        Catch ex As Exception
            MsgBox("No hay Egresos", MsgBoxStyle.Question, "Optima Inversiones")
            TextBox24.Text = "0.00000"

        End Try
        Try
            For Each row As DataGridViewRow In dgv12.Rows
                total2 += Val(row.Cells("GASTOS").Value)
                'mt_desc += Val(row.Cells(mont_des).Value)
                ' mt_int += Val(row.Cells(mont_int).Value)
                ' mt_igv += Val(row.Cells(mont_igv).Value)
                'abono += Val(row.Cells(mont_abono).Value)
                'igv_comisi += Val(row.Cells(igv_com).Value)

            Next
            TextBox23.Text = Format(total2, " #,##0.00000")
        Catch ex As Exception
            MsgBox("No hay Egresos de Gastos Bancarios y Otros", MsgBoxStyle.Question, "Optima Inversiones")
            TextBox23.Text = "0.00000"
        End Try

        T18.Text = total + total2

    End Sub

    Private Sub suma_cranx()

        Dim total As Double = 0
        'Dim itotal As Integer = dgv6.Rows.Count
        ' Dim i As Integer

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        'For i = 0 To itotal - 1
        't'otal = total + Double.Parse(dgv6(7, i).Value)

        ' Next
        Try
            For Each row As DataGridViewRow In dgv3.Rows
                total += Val(row.Cells("ingreso").Value)
                'mt_desc += Val(row.Cells(mont_des).Value)
                ' mt_int += Val(row.Cells(mont_int).Value)
                ' mt_igv += Val(row.Cells(mont_igv).Value)
                'abono += Val(row.Cells(mont_abono).Value)
                'igv_comisi += Val(row.Cells(igv_com).Value)

            Next

            T19.Text = Format(total, " #,##0.00000")

        Catch ex As Exception
            MsgBox("No hay Cronogramas ni Anexos", MsgBoxStyle.Question, "Optima Inversiones")
            T19.Text = "0.00000"
        End Try

    End Sub

    'Public Sub suma_grid2()
    'Dim total As Decimal
    'Dim col As Integer = 6

    't1.Text = Datos_Generales_del_Fondo.t1.Text
    'For Each row As DataGridViewRow In dgv.Rows
    ' total += Val(row.Cells(col).Value)

    'Next
    't6.Text = total
    'End Sub
    Public Sub ano_gestion()
        Dim sql3, ges, fec As String
        Dim fec1 As Date
        fec1 = dtp1.Value
        fec = fec1.ToString("yyyy")
        'procedimiento para tener la apertura de año
        ges = fec
        sql3 = "exec ver_gestionbdp '" + ges + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql3, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            dat_tim1 = dr(2)
            t15.Text = dr(1)
        Else
            MessageBox.Show("La gestion no Existe", "Optima Inversiones")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Private Sub TOTAL_EGRESOS()
        Dim total, t1 As Decimal
        For Each Row As DataGridViewRow In dgv4.Rows
            Dim t_por_gasto As Decimal
            t_por_gasto += Val(Row.Cells(2).Value)
            t1 = t_por_gasto + 0
            total = total + t1
        Next


        'For Each row As DataGridViewRow In dgv4.Rows
        'total += Val(row.Cells(2).Value)
        '
        '' Next
        T18.Text = total
    End Sub

    Private Sub TOTAL_INGRESOS()

    End Sub

    Private Sub patri_actual()
        Try
            Dim i_d_i, e_d_e, gadmfon, patri, patrini, t_patri As Double
            i_d_i = t21.Text
            e_d_e = T18.Text
            patri = t22.Text
            patrini = t6.Text
            gadmfon = admf.Text
            t_patri = patrini + patri + (i_d_i - (e_d_e + gadmfon))
            t11.Text = t_patri
        Catch ex As Exception
            MsgBox("Problemas al Calcular")
        End Try

    End Sub
    Private Sub vcf()
        Dim vcf, patrimoniofinal, nroparticipaciones As String
        patrimoniofinal = t11.Text
        nroparticipaciones = nro_cuotasf.Text
        vcf = patrimoniofinal / nroparticipaciones
        vca.Text = vcf
        TextBox25.Text = vcf - t10.Text
        TextBox26.Text = +vca.Text / t9.Text - 1

    End Sub
    Private Sub nro_cuotas()
        Try
            Dim ncf, nci, vci, vcn, rncuotas, npart As Double
            nci = nro_cuotasi.Text
            vci = t10.Text
            vcn = t9.Text
            rncuotas = TextBox22.Text
            npart = TextBox18.Text
            If t6.Text = 0 And t10.Text = 0 Then
                ncf = npart / vcn
            Else
                ncf = (nci + (npart / vci)) - rncuotas
            End If
            nro_cuotasf.Text = ncf
        Catch ex As Exception
            MsgBox("Problemas al Calcular")
        End Try

    End Sub



End Class