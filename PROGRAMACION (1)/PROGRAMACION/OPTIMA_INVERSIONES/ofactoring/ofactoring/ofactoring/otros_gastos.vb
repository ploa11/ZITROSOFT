Public Class otros_gastos
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
    Dim accion, sql, sql2, sql3, nc, gest, tip_partic As String
    Dim vc_act, mont_parti, num_parti As String
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String

    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        tdiasprovision()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        diarioprovision()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Dim res, res2, res3 As Integer
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim igv As String = (t4.Text + 100) / 100
            Dim mont As String = t3.Text / igv
            t5.Text = mont
        Catch ex As Exception
            MessageBox.Show("Ingrese Monto y porcentaje de IGV")
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Dim feini As Date = dtp1.Value
        'Dim fechai As String = feini.ToString("yyyyMMdd")
        'Dim fefin As Date = dtp2.Value
        'Dim fechaf As String = fefin.ToString("yyyyMMdd")
        Dim fec_comp As Date = dtp2.Value
        Dim cod_parti As String = t2.Text
        Dim mont_c As String = t5.Text
        Dim dias_c As String = t6.Text
        Dim est As String = cb1.Text
        Dim gest As String = cb2.Text
        sql = ""
        Dim gest1, gest2 As String
        gest1 = dtp1.Value.ToString("yyyy")
        gest2 = dtp2.Value.ToString("yyyy")
        '------------------------------------------------------------------------
        nc = gest1
        sql3 = "exec ver_gestionbdp '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql3, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            'dtp1.Value = dr(2)
            dtp2.Value = dr(4)
        Else
            MessageBox.Show("La gestion no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        '------------------------------------------------------------------------------
        While gest1 <= gest2


            Dim feini As Date = dtp1.Value
            Dim fechai As String = feini.ToString("yyyyMMdd")
            Dim fefin As Date = dtp2.Value
            Dim fechaf As String = fefin.ToString("yyyyMMdd")
            If accion = "guardar" Then
                sql = "exec ver_otros_gastos'" + t1.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("El codigo de Gasto ya existe", "Otros Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    conexion.conexion2.Close()
                Else
                    sql = "exec alta_otros_gastos'" + fechai + "','" + cod_parti + "','" + mont_c + "','" + dias_c + "','" + gest + "','" + fechaf + "','" + est + "'"
                    conexion.conectarfondo()
                    com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                    res = com.ExecuteNonQuery
                    conexion.conexion2.Close()
                    MessageBox.Show("Registro Guardado")
                    ' buscar_copiar()

                End If
            ElseIf accion = "editar" Then
                sql = "exec edita_gast_cap_parti '" + fechai + "','" + cod_parti + "','" + mont_c + "','" + dias_c + "','" + gest + "','" + fechaf + "','" + est + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Modificado")

            End If
            '-------------------------------------------------------------
            Dim gest_1 As Integer = gest1
            gest_1 += 1
            nc = gest_1
            sql3 = "exec ver_gestionbdp '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql3, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                dtp1.Value = dr(2)
                dtp2.Value = dr(4)
            Else
                MessageBox.Show("La gestion no Existe")
            End If
            dr.Close()
            conexion.conexion.Close()
            gest1 = dtp2.Value.ToString("yyyy")
            gest = dtp1.Value.ToString("yyyy")
            If dtp2.Value > fec_comp Then
                dtp2.Value = fec_comp
            End If
            'buscar_copiar()
        End While
        llenar_grid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t2.Enabled = True
        t3.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        Button7.Enabled = True
        t6.Enabled = True


    End Sub

    Private Sub otros_gastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        Me.Text = "Otros Gastos" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        t4.Text = 18
        llenar_grid()
        llenar_combo1()
        dtp2.Value = Datos_Generales_del_Fondo.t15.Text
    End Sub
    'variable de fecha

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb2.SelectedIndexChanged

    End Sub
    Public Sub llenar_combo1()
        Try
            sql = "select *from gestio_bdp"
            conexion.conectar()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            dt = New DataTable
            da.Fill(dt)
            cb2.DataSource = dt
            cb2.DisplayMember = "gestio_bdp"
            cb2.ValueMember = "gestion"
        Catch ex As Exception
            MessageBox.Show("No hay conexion con los datos")
        End Try

    End Sub
    Private Sub llenar_grid()
        Try
            sql = "select * from v_otros_gastos"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_otros_gastos")
            dgv.DataSource = ds
            dgv.DataMember = "v_otros_gastos"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("No hay conexion con la lista", "Optima")
        End Try

    End Sub
    Public Sub tdiasprovision()
        Dim datTim1 As Date '= #01/01/2018#
        Dim datTim2 As Date
        Dim datTim3 As Date
        Dim datTim4 As Date
        Dim gestion2 As String
        Dim f_cierre As Date
        Dim d1, d2, d As String

        ':::Declaramos nuestra variable Sql que almacenara nuestra consuta
        gestion2 = cb2.Text
        sql2 = ""
        '---------------------------------------
        'procedimiento para tener la apertura de año
        nc = gestion2
        sql3 = "exec ver_gestionbdp '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql3, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            datTim1 = dr(2)
            f_cierre = dr(4)
            'Else
            ' MessageBox.Show("La gestion no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        datTim2 = dtp1.Value
        datTim3 = dtp1.Value
        datTim4 = dtp2.Value
        Dim wD As Long = DateDiff(DateInterval.DayOfYear, datTim1, datTim2)
        Dim wY As Long = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
        d1 = wD
        d2 = wY
        d = (d1 + 1) + (d2 + 1)
        t6.Text = d2
    End Sub

    Public Sub diarioprovision()
        Dim datTim1 As Date '= #01/01/2018#
        Dim datTim2 As Date
        Dim datTim3 As Date
        Dim datTim4 As Date
        Dim f_cierre As Date
        Dim z, x, h, y, j As Integer
        Dim dinteres(0 To 367) As String
        Dim dia1, dia2 As String
        Dim gestion As String

        ':::Declaramos nuestra variable Sql que almacenara nuestra consuta
        gestion = cb2.Text
        sql2 = ""
        '---------------------------------------
        'procedimiento para tener la apertura de año
        nc = gestion
        sql3 = "exec ver_gestionbdp '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql3, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            datTim1 = dr(2)
            f_cierre = dr(4)
        Else
            MessageBox.Show("La gestion no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()

        '-----------------------------------------------
        ':::Usamos un ciclo For Each para recorrer nuestro DataGridView llamado DGTabla
        For Each Row As DataGridViewRow In dgv.Rows
            Dim cod_cuota As String = Row.Cells("codigo").Value
            Dim int As String = Row.Cells("MONTO DE gasto").Value
            Dim cuota As String = Row.Cells("MONTO DE gasto").Value
            Dim F_inicio As Date = Row.Cells("fecha de inicio").Value
            If F_inicio > f_cierre Then
                gestion = F_inicio.ToString("yyyy")
                'proceso para cambio de gestion y fecha de apertura
                nc = gestion
                sql3 = "exec ver_gestionbdp '" + nc + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql3, conexion.conexion)
                dr = com.ExecuteReader
                If dr.Read Then
                    datTim1 = dr(2)
                    f_cierre = dr(4)
                Else
                    MessageBox.Show("La gestion no Existe")
                End If
                dr.Close()
                conexion.conexion.Close()
            End If
            Dim FechaExportar As String = F_inicio.ToString("yyyyMMdd")
            Dim f_final As Date = Row.Cells("fecha de termino").Value
            If f_final > f_cierre Then
                f_final = f_cierre
            End If
            Dim fecha_f_exportar As String = f_final.ToString("yyyyMMdd")
            Dim dias As String = Row.Cells("dias").Value
            Dim cod_op As String = Row.Cells("detalle").Value
            Dim esta As String = Row.Cells("estado").Value
            Dim int_dia As String
            datTim2 = F_inicio
            datTim3 = F_inicio
            datTim4 = f_final
            Dim wD As Long = DateDiff(DateInterval.DayOfYear, datTim1, datTim2)
            Dim wY As Long = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
            If f_final = f_cierre Then
                dia1 = wD + 1 'TextBox1.Text
                dia2 = wY + 1 'TextBox2.Text
                z = (wD + 1) + (wY + 1)
            Else
                dia1 = wD + 1 'TextBox1.Text
                dia2 = wY  'TextBox2.Text
                z = (wD + 1) + (wY)
            End If

            h = 1
            j = 367
            int_dia = int / dias
            For x = 1 To j
                If x = dia1 Then
                    For y = x To (z - 1)
                        dinteres(y) = int / dias
                    Next
                    x = y
                End If
                dinteres(x) = "0"
            Next
            sql2 = "exec alta_dias_gasto '" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + dinteres(366) + "','" + gestion + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int_dia + "','" + esta + "'"
            'sql2 = "exec alta_dias_cranx '" + dinteres(0) + "','" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + Anex_Cronog.cb2.Text + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "'"

            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
            res2 = com.ExecuteNonQuery
            conexion.conexion2.Close()
            Dim f_comp As Date = Row.Cells("fecha de termino").Value
            If f_comp > f_cierre Then
                gestion = f_comp.ToString("yyyy")
                'proceso para cambio de gestion y fecha de apertura para agregar en una nueva gestion cuota
                nc = gestion
                sql3 = "exec ver_gestionbdp '" + nc + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql3, conexion.conexion)
                dr = com.ExecuteReader
                If dr.Read Then
                    datTim1 = dr(2)
                    f_cierre = dr(4)
                Else
                    MessageBox.Show("La gestion no Existe")
                End If
                dr.Close()
                conexion.conexion.Close()
                '----------------------------------------------------
                cod_cuota = Row.Cells("codigo").Value
                int = Row.Cells("MONTO DE gasto").Value
                cuota = Row.Cells("MONTO DE gasto").Value
                F_inicio = datTim1
                FechaExportar = F_inicio.ToString("yyyyMMdd")
                f_final = Row.Cells("fecha de termino").Value
                fecha_f_exportar = f_final.ToString("yyyyMMdd")
                dias = Row.Cells("dias").Value
                cod_op = Row.Cells("detalle").Value
                esta = Row.Cells("estado").Value
                datTim2 = F_inicio
                datTim3 = F_inicio
                datTim4 = f_final
                wD = DateDiff(DateInterval.DayOfYear, datTim1, datTim2)
                wY = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
                dia1 = wD + 1 'TextBox1.Text
                dia2 = wY  'TextBox2.Text
                z = (wD + 1) + (wY)
                h = 1
                j = 367
                int_dia = int / dias
                For x = 1 To j
                    If x = dia1 Then
                        For y = x To (z - 1)
                            dinteres(y) = int / dias
                        Next
                        x = y
                    End If
                    dinteres(x) = "0"
                Next
                sql2 = "exec alta_dias_gasto '" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + dinteres(366) + "','" + gestion + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int_dia + "','" + esta + "'"
                'sql2 = "exec alta_dias_cranx '" + dinteres(0) + "','" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + Anex_Cronog.cb2.Text + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "'"

                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
                res2 = com.ExecuteNonQuery
                conexion.conexion2.Close()

            End If


            'Exportar_SQLite2(sql2)
            'For x = 1 To 366
            'MsgBox("dias:" & dias(x) & "contador:" & h)
            'h = h + 1
            ' Next
        Next


        MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        Close()

    End Sub
End Class