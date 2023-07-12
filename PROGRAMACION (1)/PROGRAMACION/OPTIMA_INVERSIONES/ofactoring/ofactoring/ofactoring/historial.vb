Public Class historial

    Dim accion As String
    Dim res, res2 As Integer
    Dim diafac1, diafac2 As String
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim sql, sql2, sql3, nc As String
    Dim d_fac, cod, cod_ope, cod_cuanxdi, ref, coment, fec, fec_ini, fec_fin, n_fec_ini, n_fec_fin As String
    Dim igv_int, comi, igv_comi, mont_ini, mont_fin, int_dia, int As String
    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim cod_op As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "select *from v_historial where [CODIGO]='" + cod_op + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            dtp1.Value = dr(3)
            dtp2.Value = dr(4)
            dtp3.Value = dr(5)
            t10.Text = dr(6)
            t15.Text = dr(7)
            t16.Text = dr(8)
            t11.Text = dr(9)
            t12.Text = dr(10)
            t18.Text = dr(12)
            t19.Text = dr(13)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub t17_TextChanged(sender As Object, e As EventArgs) Handles t17.TextChanged
        If cb1.Text = "CODIGO HISTORIAL" Then
            filtro_codigo()
        Else
            If cb1.Text = "CODIGO DE OPERACION" Then
                filtro_operacion()
            Else
                If cb1.Text = "CODIGO DE CUOTA/FACTURA/DIAS" Then
                    filtro_cuota_fac()

                End If
            End If
            End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim f_emi, f_ven As Date
        Dim mnt_ope As String
        Dim tdias As Long
        f_emi = dtp4.Value
        f_ven = dtp5.Value

        Dim wD As Long = DateDiff(DateInterval.DayOfYear, f_emi, f_ven)
        'Dim wY As Long = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
        tdias = wD
        't11.Text = tdias * fac_operacion_anx.t26.Text
        'mnt_ope = fac_operacion_anx.T17.Text - t11.Text
        't9.Text = fac_operacion_anx.T16.Text - mnt_ope
    End Sub

    Private Sub dtp5_ValueChanged(sender As Object, e As EventArgs) Handles dtp5.ValueChanged
        'Dim f_emi, f_ven As Date
        'Dim mnt_ope As String
        'Dim tdias As Long
        'f_emi = dtp4.Value
        'f_ven = dtp5.Value

        'Dim wD As Long = DateDiff(DateInterval.DayOfYear, f_emi, f_ven)
        'Dim wY As Long = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
        'tdias = wD
        't11.Text = tdias * fac_operacion_anx.t26.Text
        'mnt_ope = fac_operacion_anx.T17.Text - t11.Text
        't9.Text = fac_operacion_anx.T16.Text - mnt_ope
    End Sub

    Private Sub cb1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged
        If cb1.Text = "CODIGO HISTORIAL" Then
            dtp6.Enabled = False
            t17.Enabled = True
        Else
            If cb1.Text = "CODIGO DE OPERACION" Then
                dtp6.Enabled = False
                t17.Enabled = True
            Else
                If cb1.Text = "CODIGO DE CUOTA/FACTURA/DIAS" Then
                    dtp6.Enabled = False
                    t17.Enabled = True
                Else
                    If cb1.Text = "FECHA DE CREACION" Then
                        dtp6.Enabled = True
                        t17.Enabled = False
                    End If

                End If
            End If


        End If
    End Sub

    Private Sub dtp6_ValueChanged(sender As Object, e As EventArgs) Handles dtp6.ValueChanged
        filtro_fec_crea()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim save As New SaveFileDialog
        Dim ruta As String
        Dim xlapp As Object = CreateObject("Excel.Application")
        Dim pth As String = ""
        'crea nueva hoja
        Dim xlwb As Object = xlapp.workbooks.add
        Dim xlws As Object = xlwb.worksheets(1)
        Try
            'exportamos los carateres de la columna

            For c As Integer = 0 To dgv.Columns.Count - 1
                xlws.cells(1, c + 1).value = dgv.Columns(c).HeaderText

            Next
            'exporatmaos las cabeceras de las columnas
            For r As Integer = 0 To dgv.RowCount - 1
                'xlws.cells(1, r + 1).value = dgv.Columns(r).HeaderText
                For c As Integer = 0 To dgv.Columns.Count - 1
                    xlws.cells(r + 2, c + 1).value = Convert.ToString(dgv.Item(c, r).Value)

                Next
            Next
            'guardamos la hoja
            Dim savefiledialog1 As SaveFileDialog = New SaveFileDialog
            savefiledialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            savefiledialog1.Filter = "Archivo Excel| *.xlsx"
            savefiledialog1.FilterIndex = 2
            If savefiledialog1.ShowDialog = DialogResult.OK Then
                ruta = savefiledialog1.FileName
                xlwb.saveas(ruta)
                xlws = Nothing
                xlwb = Nothing
                xlapp.quit()
                MsgBox("EXPORTADO CORRECTAMENTE", MsgBoxStyle.Information, "Optima")

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        devoluciones.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
    End Sub

    Private Sub t13_TextChanged(sender As Object, e As EventArgs) Handles t13.TextChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim f_emi, f_ven As Date
        Dim mnt_ope As String
        Dim tdias As Long
        dtp4.Value = dtp2.Value
        f_emi = dtp4.Value
        f_ven = dtp5.Value

        Dim wD As Long = DateDiff(DateInterval.DayOfYear, f_emi, f_ven)
        'Dim wY As Long = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
        tdias = wD
        diafac2 = wD
        t19.Text = tdias
        guardar()

        't11.Text = tdias * fac_operacion_anx.t26.Text
        'mnt_ope = fac_operacion_anx.T17.Text - t11.Text
        't9.Text = fac_operacion_anx.T16.Text - mnt_ope
        'If t3.Text = fac_operacion_anx.t1.Text Then


        'End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim bus As String = InputBox("Ingrese el Codigo de Anexo", "Optima Inversiones")
        sql = "exec ver_historial '" + bus + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            dtp1.Value = dr(3)
            dtp2.Value = dr(4)
            dtp3.Value = dr(5)
            t10.Text = dr(6)
            t15.Text = dr(7)
            t16.Text = dr(8)
            t11.Text = dr(9)
            t12.Text = dr(10)
            t18.Text = dr(12)
            t19.Text = dr(13)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub historial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Historial de Operaciones" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        llenar_grid()
        accion = "guardar"
        'dtp4.Value = dtp2.Value
        dgv.AllowUserToAddRows = False
    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cb1.Text = "CODIGO" Then
            t17.Enabled = True
        Else
            If cb1.Text = "CODIGO DE OPERACION" Then
                t17.Enabled = True
            Else
                If cb1.Text = "CODIGO DE CUOTA/FACTURA/DIAS " Then
                    t17.Enabled = True
                Else
                    If cb1.Text = "FECHA DE CREACION" Then
                        t17.Enabled = False
                        dtp6.Enabled = True

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cb1.Enabled = True

    End Sub

    Dim fecha, f_ini, f_fin, nfini, nffin As Date

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        t1.Text = ""
        accion = "guardar"
        Button6.Enabled = True
        diafac1 = t19.Text
        dtp5.Enabled = True
        guardar()
    End Sub
    Private Sub guardar()
        cod = t1.Text
        cod_ope = UCase(t2.Text)
        cod_cuanxdi = UCase(t3.Text)
        fecha = dtp1.Value
        f_ini = dtp2.Value
        f_fin = dtp3.Value
        nfini = dtp4.Value
        nffin = dtp5.Value
        fec = fecha.ToString("yyyyMMdd")
        fec_ini = f_ini.ToString("yyyyMMdd")
        fec_fin = f_fin.ToString("yyyyMMdd")
        n_fec_ini = nfini.ToString("yyyyMMdd")
        n_fec_fin = nffin.ToString("yyyyMMdd")
        mont_ini = t10.Text
        'mont_fin = t10.Text
        int = t11.Text
        igv_int = t12.Text
        'comi = t11.Text
        'igv_comi = t12.Text
        ref = t15.Text
        coment = t16.Text
        int_dia = t18.Text
        d_fac = t19.Text
        sql = ""
        If accion = "guardar" Then
            'sql = "exec ver_historial'" + cod + "'"
            'conexion.conectarfondo()
            ' com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            'dr = com.ExecuteReader
            'If dr.Read Then
            'MessageBox.Show("Los Datos ya Existen", "Datos Existentes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'dr.Close()
            'conexion.conexion2.Close()
            'Else
            sql = "exec alta_historial '" + cod_ope + "','" + cod_cuanxdi + "','" + fec + "','" + fec_ini + "','" + fec_fin + "','" + mont_ini + "','" + ref + "','" + coment + "','" + int + "','" + igv_int + "','" + int_dia + "','" + d_fac + "'"
            conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")
                history()
            'llenar_grid()
            'buscar_copiar()
            'End If
        ElseIf accion = "editar" Then
            sql = "exec edita_historial'" + cod + "','" + cod_ope + "','" + cod_cuanxdi + "','" + fec + "','" + fec_ini + "','" + fec_fin + "','" + mont_ini + "','" + ref + "','" + coment + "','" + int + "','" + igv_int + "','" + int_dia + "','" + d_fac + "'"
            conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Modificado")
                history()
                'buscar_copiar()
                'llenar_grid()
            End If


    End Sub

    Public Sub buscar_copiar()

        'sql = "select *from v_historial where id in (select max(id) from historial)"
        sql = "select *from v_historial where [CODIGO DE CUOTA / FACTURA]='" + t3.Text + "'and [CODIGO OPERACION]='" + t2.Text + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            dtp1.Value = dr(3)
            dtp2.Value = dr(4)
            dtp3.Value = dr(5)
            dtp4.Value = dr(6)
            dtp5.Value = dr(7)
            t9.Text = dr(8)
            t10.Text = dr(9)
            t15.Text = dr(10)
            t16.Text = dr(11)
            t11.Text = dr(12)
            t12.Text = dr(13)
            t13.Text = dr(14)
            t14.Text = dr(15)
            t18.Text = dr(16)
            t19.Text = dr(17)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Public Sub buscar_h_anexo()
        'BUSCA EL HISTORIAL DE LAS OPERACIONES DE ANEXO
        nc = Anexo.t2.Text
        sql = "select *from v_historial where [CODIGO OPERACION] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_historial where [CODIGO OPERACION] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_historial where [CODIGO OPERACION] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Public Sub buscar_h_cronograma()
        'BUSCA EL HISTORIAL DE LAS OPERACIONES DE CRONOGRAMA
        nc = Anex_Cronog.t1.Text
        sql = "select *from v_historial where [CODIGO OPERACION] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_historial where [CODIGO OPERACION] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_historial where [CODIGO OPERACION] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Public Sub buscar_h_fac_anx()
        'BUSCA EL HISTORIAL DE LAS OPERACIONES
        nc = fac_operacion_anx.t1.Text
        sql = "select *from v_historial where [CODIGO DE CUOTA / FACTURA] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_historial where [CODIGO DE CUOTA / FACTURA] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_historial where [CODIGO DE CUOTA / FACTURA] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Public Sub buscar_h_cuo_crn()
        'BUSCA EL HISTORIAL DE LAS OPERACIONES
        nc = Cuotas_Operacion.t1.Text
        sql = "select *from v_historial where [CODIGO DE CUOTA / FACTURA] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_historial where [CODIGO DE CUOTA / FACTURA] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_historial where [CODIGO DE CUOTA / FACTURA] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub llenar_grid()
        sql = "select * from v_historial"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_historial")
        dgv.DataSource = ds
        dgv.DataMember = "v_historial"
        conexion.conexion2.Close()
    End Sub

    Private Sub history()
        sql = "select *from v_historial where [CODIGO DE CUOTA / FACTURA]='" + t3.Text + "'and [CODIGO OPERACION]='" + t2.Text + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, sql = "select *from v_historial where [CODIGO DE CUOTA / FACTURA]='" + t3.Text + "'and [CODIGO OPERACION]='" + t2.Text + "'")
        dgv.DataSource = ds
        dgv.DataMember = sql = "select *from v_historial where [CODIGO DE CUOTA / FACTURA]='" + t3.Text + "'and [CODIGO OPERACION]='" + t2.Text + "'"
        conexion.conexion2.Close()
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles t2.TextChanged

    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles dtp3.ValueChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        dtp4.Enabled = True
        dtp5.Enabled = True
        t10.Enabled = False
        't10.Text = 0
        t15.Enabled = True
        t16.Enabled = True
        't13.Enabled = True
        't2.Enabled = True
        't3.Enabled = True
        ' dtp1.Enabled = True
        'dtp2.Enabled = True
        'd'tp3.Enabled = True
        'dtp4.Enabled = True
        'dtp5.Enabled = True
        't9.Enabled = True
        't11.Enabled = True
        't12.Enabled = True
        't13.Enabled = True
        't14.Enabled = True


    End Sub

    Private Sub edita_dias_int_fac()
        Dim dat_Tim1 As Date '= #01/01/2018#
        Dim dat_Tim2 As Date
        Dim dat_Tim3 As Date
        Dim dat_Tim4 As Date
        Dim z, x, h, y, j As Integer
        Dim dinteres(0 To 367) As String
        Dim dia1, dia2 As String
        Dim gestion As String

        ':::Declaramos nuestra variable Sql que almacenara nuestra consuta
        gestion = fac_operacion_anx.t23.Text
        sql2 = ""
        '---------------------------------------
        'procedimiento para tener la apertura de año
        nc = gestion
        sql3 = "exec ver_gestionbdp '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql3, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            dat_Tim1 = dr(2)
        Else
            MessageBox.Show("La gestion no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()

        '-----------------------------------------------
        ':::Usamos un ciclo For Each para recorrer nuestro DataGridView llamado DGTabla
        For Each Row As DataGridViewRow In dgv.Rows
            Dim cod_doc As String = Row.Cells("CODIGO DE DOCUMENTO").Value
            Dim int As String = Row.Cells("MONTO DE INTERES").Value
            Dim cuota As String = Row.Cells("MONTO DESCUENTO").Value
            Dim F_inicio As Date = Row.Cells("FECHA DE RECEPCION DE DOCUMENTO").Value
            Dim FechaExportar As String = F_inicio.ToString("yyyyMMdd")
            Dim f_final As Date = Row.Cells("FECHA DE VENCIMIENTO DE DOCUMENTO").Value
            Dim fecha_f_exportar As String = f_final.ToString("yyyyMMdd")
            Dim dias As String = Row.Cells("NUMERO DE DIAS DE FACTURA").Value
            Dim cod_op As String = Row.Cells("CODIGO DE ANEXO").Value
            Dim estado As String = Row.Cells("ESTADO").Value
            Dim int_d As String = Row.Cells("INTERES DIARIO").Value
            nc = Row.Cells("CODIGO DE DOCUMENTO").Value
            dat_Tim2 = F_inicio
            dat_Tim3 = F_inicio
            dat_Tim4 = f_final
            Dim wD As Long = DateDiff(DateInterval.DayOfYear, dat_Tim1, dat_Tim2)
            Dim wY As Long = DateDiff(DateInterval.DayOfYear, dat_Tim3, dat_Tim4)
            dia1 = wD + 1 'TextBox1.Text
            dia2 = wY + 1 'TextBox2.Text
            z = (wD + 1) + (wY + 1)
            h = 1
            j = 367
            For x = 1 To j
                If x = dia1 Then
                    For y = x To (z - 2)
                        dinteres(y) = int_d
                    Next
                    x = y
                End If
                dinteres(x) = "0"
            Next
            'sql2 = "exec ver_numdias_cranx'" + nc + "'"
            'conexion.conectarfondo()
            ' com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
            ' dr = com.ExecuteReader
            ' If dr.Read Then
            ' MessageBox.Show("Los Datos ya Existen", "Datos existen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'dr.Close()
            'conexion.conexion2.Close()
            'Else

            sql2 = "exec edita_cuo_cranx '" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + dinteres(366) + "','" + gestion + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_doc + "','" + estado + "','" + int_d + "'"
            'sql2 = "exec alta_dias_cranx '" + dinteres(0) + "','" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + Anex_Cronog.cb2.Text + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "'"

            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
            res2 = com.ExecuteNonQuery
            conexion.conexion2.Close()
            'End If

            'Exportar_SQLite2(sql2)
            'For x = 1 To 366
            'MsgBox("dias:" & dias(x) & "contador:" & h)
            'h = h + 1
            ' Next
        Next


        MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        'Close()
    End Sub


    Private Sub filtro_codigo()
        nc = t17.Text
        sql = "select *from v_historial where [CODIGO] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_historial where [CODIGO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_historial where [CODIGO] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_operacion()
        nc = t17.Text
        sql = "select *from v_historial where [CODIGO DE OPERACION] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_historial where [CODIGO DE OPERACION] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_historial where [CODIGO DE OPERACION] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_cuota_fac()
        nc = t17.Text
        sql = "select *from v_historial where [CODIGO DE CUOTA / FACTURA] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_historial where [CODIGO DE CUOTA / FACTURA] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_historial where [CODIGO DE CUOTA / FACTURA] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub
    Private Sub filtro_fec_crea()
        Dim f_recp As Date
        Dim ferecp As String
        f_recp = dtp6.Value
        ferecp = f_recp.ToString("yyyyMMdd")
        nc = ferecp
        sql = "select *from v_historial where [FECHA] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_historial where [FECHA] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_historial where [FECHA] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

End Class