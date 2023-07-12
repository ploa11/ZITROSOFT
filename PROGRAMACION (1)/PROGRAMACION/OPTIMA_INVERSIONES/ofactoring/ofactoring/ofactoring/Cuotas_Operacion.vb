Imports System.Data.OleDb 'Importacion necesaria para trabajar con ficheros excel


Public Class Cuotas_Operacion
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

    Dim accion, gestion As String
    Dim comparamora As String
    'variables publicas
    Public cod_clie, cod_comi_desem, cod_cuop, tip_op, tipodoc_clie, numdoc_clie, cali_finan, cod2, rev_cro_anx, verifi, diasmora, mmorad As String
    Public igv_g, montocuotam As Decimal
    'variable de fecha
    Dim d1, m1, a1, d2, m2, a2, d3, m3, a3, dia1, mes1, dia2, mes2, dia3, mes3, f_ini, f_term, f_filt As String

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        t14.Enabled = True
        cb2.Enabled = True
        filtro_ope()
    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged



        If accion = "editar" Then

            If MsgBox("SE VA A ACTUALIZAR EL ESTADO DE LA CUOTA", MsgBoxStyle.YesNo, "ESTA SEGURO ?") = vbYes Then
                sql = "update CUOTAS_OPERACION set estado='" + cb1.Text + "' where COD_CUOTA='" + t1.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("ESTADO DE CUOTA MODIFICADO")
                Select Case cb1.Text
                    Case "MORA"
                        bh_activar_opciones_mora()
                        BUSCA_MORA()
                        busca_taza()
                    Case "ADELANTADO"
                        bh_activar_opciones_mora()
                        busca_taza()
                    Case "VIGENTE"
                        dtp2.Enabled = False
                        Label19.Visible = False
                        Label20.Visible = False
                        Label21.Visible = False
                        TextBox3.Visible = False
                        TextBox1.Visible = False
                        TextBox2.Visible = False
                        TextBox4.Visible = False
                        t13.Visible = False
                        TextBox5.Visible = False
                        Label23.Visible = False
                        Button8.Visible = False
                        Label15.Visible = False
                        Label22.Visible = False
                        Label24.Visible = False
                        TextBox6.Visible = False
                        Button14.Visible = False
                        TextBox7.Visible = False
                        Label25.Visible = False
                    Case "CANCELADO"
                        dtp2.Enabled = False
                        Label19.Visible = False
                        Label20.Visible = False
                        Label21.Visible = False
                        TextBox3.Visible = False
                        TextBox1.Visible = False
                        TextBox2.Visible = False
                        TextBox4.Visible = False
                        t13.Visible = False
                        TextBox5.Visible = False
                        Label23.Visible = False
                        Button8.Visible = False
                        Label15.Visible = False
                        Label22.Visible = False
                        Label24.Visible = False
                        TextBox6.Visible = False
                        Button14.Visible = False
                        TextBox7.Visible = False
                        Label25.Visible = False
                    Case "REPROGRAMADO"
                        dtp2.Enabled = False
                        Label19.Visible = False
                        Label20.Visible = False
                        Label21.Visible = False
                        TextBox3.Visible = False
                        TextBox1.Visible = False
                        TextBox2.Visible = False
                        TextBox4.Visible = False
                        TextBox5.Visible = False
                        Label23.Visible = False
                        t13.Visible = False
                        Button8.Visible = False
                        Label15.Visible = False
                        Label22.Visible = False
                        Label24.Visible = False
                        TextBox6.Visible = False
                        Button14.Visible = False
                        TextBox7.Visible = False
                        Label25.Visible = False

                End Select
            End If
        End If



    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Select Case cb1.Text
                Case "ADELANTADO"
                    Dim interes, resdias, t, tecu As Decimal
                    interes = t6.Text / t11.Text
                    resdias = t11.Text - t13.Text
                    t = interes * resdias
                    tecu = t8.Text
                    Dim igv As Decimal = (t6.Text - t) * (igv_g / 100)
                    Dim igv_r As Decimal = t * (igv_g / 100)
                    TextBox4.Text = t6.Text - t
                    TextBox7.Text = igv
                    TextBox5.Text = tecu - (t + igv_r)
                    dgv.Visible = True
                    Button15.Visible = True
                    Button7.Visible = False
                    accion = "editar"
                    ' Case "MORA"
                    ' Dim interes2, resdias2, t2, tecu2 As Decimal
                    '  interes2 = t6.Text / t11.Text
                    '  resdias2 = t13.Text - t11.Text
                    '  t2 = interes2 * resdias2
                    ' tecu2 = t8.Text
                    ' t8.Text = tecu2 + t2
            End Select

            'If cb1.Text = "ADELANTADO" Then
            'Dim interes, resdias, t, tecu As Decimal
            'interes = t6.Text / t11.Text
            'resdias = t11.Text - t13.Text
            't = interes * resdias
            'tecu = t8.Text
            't8.Text = tecu - t
            ' Else
            'If cb1.Text = "MORA" Then
            'Dim interes2, resdias2, t2, tecu2 As Decimal
            'interes2 = t6.Text / t11.Text
            'resdias2 = t13.Text - t11.Text
            't2 = interes2 * resdias2
            'tecu2 = t8.Text
            't8.Text = tecu2 + t2
            'End If
            'End If
        Catch ex As Exception

        End Try


    End Sub


    Private Sub busca_taza()
        nc = t2.Text
        sql = "exec ver_d_operacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            TextBox3.Text = dr(11)
            igv_g = dr(8)
            TextBox2.Visible = True
            TextBox1.Visible = True
            TextBox6.Visible = True
            TextBox3.Visible = True

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
        Button6.Enabled = True
    End Sub
    Public Sub BUSCA_MORA()

        nc = t1.Text
        sql = "select *from CUOTAS_OPERACION where cod_cuota= '" + nc + "'and estado='MORA'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            TextBox2.Text = dr(14)
            mmorad = dr(14)
            diasmora = dr(15)
            TextBox6.Text = dr(7)
            montocuotam = dr(7)
            TextBox2.Visible = True
            TextBox1.Visible = True
            TextBox6.Visible = True
            TextBox3.Visible = True
            If dr(15) = 0 Then
                comparamora = 2
            Else
                comparamora = 1
            End If
            'comparamora = "1"
            'MessageBox.Show("Los Datos no Existen")
        Else
            TextBox2.Visible = False
            TextBox1.Visible = False
            TextBox6.Visible = False
            TextBox3.Visible = False
            'comparamora = "2"
        End If

        dr.Close()
        conexion.conexion2.Close()
        '        Button6.Enabled = True
    End Sub
    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles t14.TextChanged
        If cb2.Text = "Codigo de Cuota" Then
            filtro()
        Else
            If cb2.Text = "Codigo de Operacion" Then
                filtro_ope()
            End If
        End If
    End Sub

    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        Dim dia1, dia2 As Date
        dia1 = dtp1.Value
        dia2 = dtp2.Value
        'Dim wD As Long = DateDiff(DateInterval.DayOfYear, datTim1, datTim2)
        Dim wY As Long = DateDiff(DateInterval.DayOfYear, dia1, dia2)
        t13.Text = wY

    End Sub

    Private Sub Button7_Click_2(sender As Object, e As EventArgs) Handles Button7.Click
        Dim cod, cod_op, cap_ini, amor, cap_fina, int, igv, t_cuota, f_ini, f_fin, dcuo, ges, est, mora, d_mora As String
        Dim fec_ini, fec_fin As Date
        cod = t1.Text
        cod_op = t2.Text
        cap_ini = t3.Text
        amor = t4.Text
        cap_fina = t5.Text
        int = t6.Text
        igv = t7.Text
        t_cuota = t8.Text
        fec_ini = dtp1.Value
        f_ini = fec_ini.ToString("yyyyMMdd")
        fec_fin = dtp2.Value
        f_fin = fec_fin.ToString("yyyyMMdd")
        dcuo = t13.Text
        ges = T12.Text
        est = cb1.Text
        mora = "0"
        d_mora = "0"
        Dim fec_mora As String = fec_fin.ToString("yyyyMMdd")
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_couta_ope'" + cod + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de cuota ya existe", "Cuotas de Operacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_cuota_ope '" + cod_op + "','" + cap_ini + "','" + amor + "','" + cap_fina + "','" + int + "','" + igv + "','" + t_cuota + "','" + dcuo + "','" + f_fin + "','" + f_ini + "','" + ges + "','" + est + "','" + mora + "','" + d_mora + "','" + fec_mora + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")
                buscar()


            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_cuota_ope '" + cod + "','" + cod_op + "','" + cap_ini + "','" + amor + "','" + cap_fina + "','" + int + "','" + igv + "','" + t_cuota + "','" + dcuo + "','" + f_fin + "','" + f_ini + "','" + ges + "','" + est + "','" + mora + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")
            t14.Text = t1.Text
            filtro()
            If cb1.Text = "CANCELADO" Then
                MessageBox.Show("Cuota Cancelada")
            Else
                edita_dias_int_cuota()
            End If


        End If
    End Sub

    Private Sub GUARDA_ADELANTO()

        Dim cod, cod_op, cap_ini, amor, cap_fina, int, igv, t_cuota, f_ini, f_fin, dcuo, ges, est, mora, d_mora As String
        Dim fec_ini, fec_fin As Date
        cod = t1.Text
        cod_op = t2.Text
        cap_ini = t3.Text
        amor = t4.Text
        cap_fina = t5.Text
        int = TextBox4.Text
        igv = TextBox7.Text
        t_cuota = TextBox5.Text
        fec_ini = dtp1.Value
        f_ini = fec_ini.ToString("yyyyMMdd")
        fec_fin = dtp2.Value
        f_fin = fec_fin.ToString("yyyyMMdd")
        dcuo = t13.Text
        ges = T12.Text
        est = cb1.Text
        mora = "0"
        d_mora = "0"
        sql = ""
        Dim fec_adela_mora As String = DateTimePicker1.Value.ToString("yyyyMMdd")
        If accion = "guardar" Then
            sql = "exec ver_couta_ope'" + cod + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de cuota ya existe", "Cuotas de Operacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_cuota_ope '" + cod_op + "','" + cap_ini + "','" + amor + "','" + cap_fina + "','" + int + "','" + igv + "','" + t_cuota + "','" + dcuo + "','" + f_fin + "','" + f_ini + "','" + ges + "','" + est + "','" + mora + "','" + d_mora + "','" + fec_adela_mora + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")
                buscar()


            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_cuota_ope '" + cod + "','" + cod_op + "','" + cap_ini + "','" + amor + "','" + cap_fina + "','" + int + "','" + igv + "','" + t_cuota + "','" + dcuo + "','" + f_fin + "','" + f_ini + "','" + ges + "','" + est + "','" + mora + "','" + d_mora + "','" + fec_adela_mora + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")
            t14.Text = t1.Text
            filtro()
            If cb1.Text = "CANCELADO" Then
                MessageBox.Show("Cuota Cancelada")
            Else
                edita_dias_int_cuota()
            End If


        End If
    End Sub

    Private Sub guarda_mora()
        Dim cod, cod_op, cap_ini, amor, cap_fina, int, igv, t_cuota, f_ini, f_fin, dcuo, ges, est, mora, d_mora As String
        Dim fec_ini, fec_fin As Date
        cod = t1.Text
        cod_op = t2.Text
        'cap_ini = "9500"
        amor = t4.Text
        cap_fina = t5.Text
        int = t6.Text
        igv = t7.Text
        t_cuota = TextBox6.Text
        fec_ini = dtp1.Value
        f_ini = fec_ini.ToString("yyyyMMdd")
        fec_fin = dtp5.Value
        f_fin = fec_fin.ToString("yyyyMMdd")
        dcuo = t11.Text
        ges = T12.Text
        est = cb1.Text
        mora = TextBox2.Text

        Select Case comparamora
            Case = "2"
                d_mora = TextBox1.Text
            Case = "1"
                d_mora = diasmora
        End Select
        'If comparamora = 1 Then
        'd_mora = TextBox1.Text
        '  Else
        'd_mora = diasmora
        'End If
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_couta_ope'" + cod + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de cuota ya existe", "Cuotas de Operacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_cuota_ope '" + cod_op + "','" + t3.Text + "','" + amor + "','" + cap_fina + "','" + int + "','" + igv + "','" + t_cuota + "','" + dcuo + "','" + f_fin + "','" + f_ini + "','" + ges + "','" + est + "','" + mora + "','" + d_mora + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")
                buscar()


            End If
        ElseIf accion = "editar" Then
            ' sql = "exec edita_cuota_ope '" + cod + "','" + cod_op + "','" + t3.Text + "','" + amor + "','" + cap_fina + "','" + int + "','" + igv + "','" + t_cuota + "','" + dcuo + "','" + f_fin + "','" + f_ini + "','" + ges + "','" + est + "','" + mora + "','" + d_mora + "'"
            sql = "update cuotas_operacion set T_CUOTA='" + TextBox6.Text + "',fec_mora_adelanto='" + dtp5.Value.ToString("yyyyMMdd") + "', MORA='" + mora + "',dias_mora='" + d_mora + "' where cod_cuota='" + t1.Text + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")
            t14.Text = t1.Text
            dgv.Visible = True
            filtro()
            If cb1.Text = "CANCELADO" Then
                MessageBox.Show("Cuota Cancelada")
            Else
                buscar_reprogramado()
            End If


        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb2.SelectedIndexChanged
        If cb2.Text = "Codigo de Cuota" Then
            t14.Enabled = True
            dtp3.Enabled = False
            dtp4.Enabled = False
        Else
            If cb2.Text = "Codigo de Operacion" Then
                t14.Enabled = True
                dtp3.Enabled = False
                dtp4.Enabled = False
            Else
                If cb2.Text = "Fecha de inicio" Then
                    t14.Enabled = False
                    dtp3.Enabled = True
                    dtp4.Enabled = False
                Else
                    If cb2.Text = "Fecha de Termino" Then
                        t14.Enabled = False
                        dtp3.Enabled = False
                        dtp4.Enabled = True
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        'dtp2.Enabled = True
        cb1.Enabled = True

    End Sub

    Private Sub dtp3_ValueChanged(sender As Object, e As EventArgs) Handles dtp3.ValueChanged
        filtro_feci_cuot()
    End Sub

    Private Sub dtp4_ValueChanged(sender As Object, e As EventArgs) Handles dtp4.ValueChanged
        filtro_fecf_cuot()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Fondos.cuota_opera.Hide()
        monitoreovencimientos.llenar_grigsegui()
        Me.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        historial.t2.Text = t2.Text
        historial.t3.Text = t1.Text
        historial.dtp2.Value = dtp1.Value
        historial.dtp3.Value = dtp2.Value
        historial.t10.Text = t8.Text
        historial.t11.Text = t6.Text
        historial.t12.Text = t7.Text
        historial.t18.Text = t6.Text / t11.Text
        historial.t19.Text = t11.Text
        historial.Show()
        historial.buscar_h_cuo_crn()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        dias_int_cuota()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
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

    Private Sub Button12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button12_Click_1(sender As Object, e As EventArgs) Handles Button12.Click
        reporte_cuotas.buscar()
        reporte_cuotas.b_cliente()
        reporte_cuotas.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t2.Text
        res = MessageBox.Show("¿Desea Borrar las cuotas", "CLIENTES", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_cuota '" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Borrado")
        End If
        sql = ""
        res = MessageBox.Show("¿Desea las distribucion diaria", "CLIENTES", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_dias_crax '" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Borrado")
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Form4.Show()
        'Me.Close()
    End Sub

    Private Sub dtp5_ValueChanged(sender As Object, e As EventArgs) Handles dtp5.ValueChanged
        Dim dia1, dia2 As Date
        dia1 = DateTimePicker1.Value
        dia2 = dtp5.Value
        'Dim wD As Long = DateDiff(DateInterval.DayOfYear, datTim1, datTim2)
        Dim wY As Long = DateDiff(DateInterval.DayOfYear, dia1, dia2)
        TextBox1.Text = wY
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs)
        ' dias_int_cuota()

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Select Case comparamora
            Case "1"
                mora_s()
                accion = "editar"
                Button7.Visible = False
                Button16.Visible = True

            Case "2"
                mora()
                accion = "editar"
                Button7.Visible = False
                Button16.Visible = True
        End Select

        'If comparamora = 1 Then
        'mora()
        'accion = "editar"
        'Button7.Visible = False
        'Button16.Visible = True
        '  Else
        'mora_s()
        'accion = "editar"
        'Button7.Visible = False
        'Button16.Visible = True
        ' End If



    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        GUARDA_ADELANTO()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        guarda_mora()
        res = MessageBox.Show("¿Desea Actualizar Estado de Cuotas", "CLIENTES", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        mora_dias_int_cuota()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Amortizacion.Show()
        'Process.Start("Excel.exe", "E:\DatosPedro\Desktop\Formato_cro_anx3.xlsm")
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        nc = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_couta_ope '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
            t8.Text = dr(7)
            t9.Text = dr(10)
            dtp1.Value = dr(10)
            t10.Text = dr(9)
            dtp2.Value = dr(9)
            t11.Text = dr(8)
            T12.Text = dr(12)
            cb1.Text = dr(13)
            DateTimePicker1.Value = dr(16)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Cuotas.Show()
        'Dim fileDialog As New OpenFileDialog()
        'If fileDialog.ShowDialog() = DialogResult.OK Then
        ' Assign the file name to a string.
        'Dim filename As String = fileDialog.FileName
        ' Open the file and use the contents. 
        'System.Diagnostics.Process.Start(filename)
        'End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = InputBox("Ingrese el Codigo de Operacion")
        sql = "exec ver_couta_ope '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
            t8.Text = dr(7)
            t9.Text = dr(10)
            dtp1.Text = dr(10)
            t10.Text = dr(9)
            dtp2.Text = dr(9)
            t11.Text = dr(8)
            T12.Text = dr(12)
            cb1.Text = dr(13)
            DateTimePicker1.Value = dr(16)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub
    Public Sub buscar_cambiar_estado()

        sql = "select *from CUOTAS_OPERACION where cod_cuota= '" + rev_cro_anx + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
            t8.Text = dr(7)
            t9.Text = dr(10)
            dtp1.Text = dr(10)
            t10.Text = dr(9)
            dtp2.Text = dr(9)
            t11.Text = dr(8)
            T12.Text = dr(12)
            cb1.Text = dr(13)
            DateTimePicker1.Value = dr(16)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub
    Private Sub Cuotas_Operacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        Me.Text = "Cuotas de Cronograma" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        Select Case verifi
            Case 1
                buscar()
            Case 2
                Button12.Visible = False
            Case 3


        End Select


        'filtro_ope()
        'llenar_grid()

    End Sub

    Private Sub mora()
        Try
            Dim taza As Decimal = TextBox3.Text
            Dim dias As Integer = TextBox1.Text
            Dim monto As Decimal = t8.Text
            TextBox2.Text = monto * ((1 + (taza / 100) / 30) ^ dias - 1)
            Dim ntaza As Decimal = TextBox2.Text
            TextBox6.Text = monto + ntaza
        Catch ex As Exception

        End Try

    End Sub

    Private Sub mora_s()
        Dim dmoracalc As Integer = TextBox1.Text
        Try
            diasmora = diasmora + dmoracalc
            TextBox6.Text = montocuotam + mmorad
        Catch ex As Exception

        End Try





    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub


    'variable locales
    Dim sql, sql2, sql3, nc As String
    Dim res, res2 As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Cuotas.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)


    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_couta_op"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_couta_op")
        dgv.DataSource = ds
        dgv.DataMember = "v_couta_op"
        conexion.conexion2.Close()
    End Sub

    Public Sub buscar()
        t2.Text = Anex_Cronog.t1.Text
        nc = t2.Text
        sql = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub
    Public Sub buscar_reprogramado()
        't2.Text = Anex_Cronog.t1.Text
        nc = t2.Text
        sql = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA','REPROGRAMADO')"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA','REPROGRAMADO')")
        'dgv.DataSource = ds
        'dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA')"
        Form4.dgv.DataSource = ds
        Form4.dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA','REPROGRAMADO')"
        conexion.conexion2.Close()
    End Sub
    Public Sub dias_int_cuota()
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
        gestion = Anex_Cronog.cb2.Text
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
            Dim cod_cuota As String = Row.Cells("codigo de cuota").Value
            Dim int As String = Row.Cells("interes").Value
            Dim cuota As String = Row.Cells("cuota total").Value
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
            Dim f_final As Date = Row.Cells("fecha de vencimiento").Value
            If f_final > f_cierre Then
                f_final = f_cierre
            End If
            Dim fecha_f_exportar As String = f_final.ToString("yyyyMMdd")
            Dim dias As String = Row.Cells("dias de cuota").Value
            Dim cod_op As String = Row.Cells("codigo de operacion").Value
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
            sql2 = "exec alta_dias_cranx '" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + dinteres(366) + "','" + gestion + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "','" + esta + "','" + int_dia + "'"
            'sql2 = "exec alta_dias_cranx '" + dinteres(0) + "','" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + Anex_Cronog.cb2.Text + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "'"

            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
            res2 = com.ExecuteNonQuery
            conexion.conexion2.Close()
            Dim f_comp As Date = Row.Cells("fecha de vencimiento").Value
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
                cod_cuota = Row.Cells("codigo de cuota").Value
                int = Row.Cells("interes").Value
                cuota = Row.Cells("cuota total").Value
                F_inicio = datTim1
                FechaExportar = F_inicio.ToString("yyyyMMdd")
                f_final = Row.Cells("fecha de vencimiento").Value
                fecha_f_exportar = f_final.ToString("yyyyMMdd")
                dias = Row.Cells("dias de cuota").Value
                cod_op = Row.Cells("codigo de operacion").Value
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
                sql2 = "exec alta_dias_cranx '" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + dinteres(366) + "','" + gestion + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "','" + esta + "','" + int_dia + "'"
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

    Public Sub edita_dias_int_cuota()
        Dim dat_Tim1 As Date '= #01/01/2018#
        Dim dat_Tim2 As Date
        Dim dat_Tim3 As Date
        Dim dat_Tim4 As Date
        Dim z, x, h, y, j As Integer
        Dim dinteres(0 To 367) As String
        Dim dia1, dia2 As String
        Dim gestion As String
        Dim int_dia As String

        ':::Declaramos nuestra variable Sql que almacenara nuestra consuta
        gestion = T12.Text
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
            Dim cod_cuota As String = Row.Cells("codigo de cuota").Value
            Dim int As String = Row.Cells("interes").Value
            Dim cuota As String = Row.Cells("cuota total").Value
            Dim F_inicio As Date = Row.Cells("fecha de inicio").Value
            Dim FechaExportar As String = F_inicio.ToString("yyyyMMdd")
            Dim f_final As Date = Row.Cells("fecha de vencimiento").Value
            Dim fecha_f_exportar As String = f_final.ToString("yyyyMMdd")
            Dim dias As String = Row.Cells("dias de cuota").Value
            Dim cod_op As String = Row.Cells("codigo de operacion").Value
            Dim esta As String = Row.Cells("estado").Value
            Dim fec_adela_mora As Date = Row.Cells("FECHA DE ADELANTO /  MORA").Value
            dat_Tim2 = F_inicio
            dat_Tim3 = F_inicio
            dat_Tim4 = fec_adela_mora
            Dim wD As Long = DateDiff(DateInterval.DayOfYear, dat_Tim1, dat_Tim2)
            Dim wY As Long = DateDiff(DateInterval.DayOfYear, dat_Tim3, dat_Tim4)
            dia1 = wD + 1 'TextBox1.Text
            dia2 = wY + 1 'TextBox2.Text
            z = (wD + 1) + (wY + 1)
            h = 1
            j = 367
            int_dia = t6.Text / t11.Text
            For x = 1 To j
                If x = dia1 Then
                    For y = x To (z - 2)
                        dinteres(y) = t6.Text / t11.Text
                    Next
                    x = y
                End If
                dinteres(x) = "0"
            Next
            sql2 = "exec edita_cuo_cranx '" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + dinteres(366) + "','" + gestion + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "','" + esta + "','" + int_dia + "'"
            'sql2 = "exec alta_dias_cranx '" + dinteres(0) + "','" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + Anex_Cronog.cb2.Text + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "'"

            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
            res2 = com.ExecuteNonQuery
            conexion.conexion2.Close()

            'Exportar_SQLite2(sql2)
            'For x = 1 To 366
            'MsgBox("dias:" & dias(x) & "contador:" & h)
            'h = h + 1
            ' Next
        Next


        MsgBox("Resgistros Modificados exitosamente", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        'Close()
    End Sub


    Public Sub mora_dias_int_cuota()
        Dim dat_Tim1 As Date '= #01/01/2018#
        Dim dat_Tim2 As Date
        Dim dat_Tim3 As Date
        Dim dat_Tim4 As Date
        Dim z, x, h, y, j As Integer
        Dim dinteres(0 To 367) As String
        Dim dia1, dia2 As String
        Dim gestion As String
        Dim int_dia As String

        ':::Declaramos nuestra variable Sql que almacenara nuestra consuta
        gestion = T12.Text
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
            Dim cod_cuota As String = Row.Cells("codigo de cuota").Value
            Dim int As String = Row.Cells("interes").Value
            Dim cuota As String = Row.Cells("cuota total").Value
            Dim F_inicio As Date = Row.Cells("fecha de inicio").Value
            Dim FechaExportar As String = F_inicio.ToString("yyyyMMdd")
            Dim f_final As Date = Row.Cells("fecha de vencimiento").Value
            Dim fecha_f_exportar As String = f_final.ToString("yyyyMMdd")
            Dim dias As String = Row.Cells("dias de cuota").Value
            Dim cod_op As String = Row.Cells("codigo de operacion").Value
            Dim esta As String = Row.Cells("estado").Value
            Dim FEC_mora As Date = Row.Cells("FECHA DE ADELANTO /  MORA").Value
            dat_Tim2 = FEC_mora
            dat_Tim3 = FEC_mora
            dat_Tim4 = dtp5.Value
            Dim wD As Long = DateDiff(DateInterval.DayOfYear, dat_Tim1, dat_Tim2)
            Dim wY As Long = DateDiff(DateInterval.DayOfYear, dat_Tim3, dat_Tim4)
            dia1 = wD + 1 'TextBox1.Text
            dia2 = wY + 1 'TextBox2.Text
            z = (wD + 1) + (wY + 1)
            TextBox8.Text = z
            TextBox9.Text = dia1
            TextBox10.Text = dia2
            h = 1
            j = 367
            int_dia = t6.Text / t11.Text
            'For x = 1 To j
            'If x = dia1 Then
            'For y = x To (z - 2)
            'dinteres(y) = TextBox2.Text
            'Next
            'x = y
            'End If
            'dinteres(x) = "0"
            'Next
            'sql2 = "exec edita_cuo_cranx '" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + dinteres(366) + "','" + gestion + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "','" + esta + "','" + int_dia + "'"
            sql2 = "update NUM_DIAS_CRANX set DIA" & (z - 2) & " ='" + TextBox2.Text + "'where cod_cuota='" + t1.Text + "'"

            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
            res2 = com.ExecuteNonQuery
            conexion.conexion2.Close()

            'Exportar_SQLite2(sql2)
            'For x = 1 To 366
            'MsgBox("dias:" & dias(x) & "contador:" & h)
            'h = h + 1
            ' Next
        Next


        MsgBox("Resgistros Modificados exitosamente", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        'Close()
    End Sub

    Sub Exportar_SQLite2(ByVal Sql2 As String)
        Try
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(Sql2, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
        Catch ex As Exception
            MsgBox("No se pueden guardar los registro por: " & ex.Message, MsgBoxStyle.Critical, ":::Optima Inversion:::")
        End Try


    End Sub

    Private Sub filtro()
        nc = t14.Text
        sql = "select *from v_couta_op where [CODIGO DE CUOTA] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [CODIGO DE CUOTA] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [CODIGO DE CUOTA] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_ope()
        nc = t14.Text
        sql = "select *from v_couta_op where [CODIGO DE OPERACION] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [CODIGO DE OPERACION] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_feci_cuot()
        Dim feci As Date
        Dim f_ini As String
        feci = dtp3.Value
        f_ini = feci.ToString("yyyyMMdd")
        nc = f_ini
        sql = "select *from v_couta_op where [FECHA DE INICIO]='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [FECHA DE INICIO]='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [FECHA DE INICIO]='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_fecf_cuot()
        Dim feci2 As Date
        Dim f_ini2 As String
        feci2 = dtp4.Value
        f_ini2 = feci2.ToString("yyyyMMdd")
        nc = f_ini2
        sql = "select *from v_couta_op where [FECHA DE VENCIMIENTO]='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [FECHA DE VENCIMIENTO]='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [FECHA DE VENCIMIENTO]='" + nc + "'"
        conexion.conexion2.Close()
    End Sub
    Private Sub dtp2_MouseClick(sender As Object, e As MouseEventArgs) Handles dtp2.MouseClick

    End Sub

    Private Sub bh_activar_opciones_mora()
        ' busca si tiene historial de tener activa opciones para generarl historial
        sql = "select *from historial  where cod_cufacdia='" + t1.Text + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            Select Case cb1.Text
                Case "MORA"
                    Label19.Visible = True
                    Label20.Visible = True
                    Label21.Visible = True
                    TextBox3.Visible = True
                    TextBox1.Visible = True
                    TextBox2.Visible = True
                    TextBox4.Visible = False
                    t13.Visible = False
                    TextBox5.Visible = False
                    Label23.Visible = False
                    Button8.Visible = False
                    Label15.Visible = False
                    Label22.Visible = False
                    Label24.Visible = True
                    TextBox6.Visible = True
                    Button14.Visible = True
                    dtp5.Enabled = True
                    DateTimePicker1.Visible = True
                    Label26.Visible = True
                    TextBox7.Visible = False
                    Label25.Visible = False
                Case "ADELANTADO"
                    dtp2.Enabled = False
                    Label19.Visible = False
                    Label20.Visible = False
                    Label21.Visible = False
                    TextBox3.Visible = False
                    TextBox1.Visible = False
                    TextBox2.Visible = False
                    TextBox4.Visible = True
                    TextBox5.Visible = True
                    Label23.Visible = True
                    t13.Visible = True
                    Button8.Visible = True
                    Label15.Visible = True
                    Label22.Visible = True
                    Label24.Visible = False
                    TextBox6.Visible = False
                    Button14.Visible = False
                    TextBox7.Visible = True
                    Label25.Visible = True
                    Button16.Visible = False
                    Label20.Visible = False
                    Label21.Visible = False
                    Label24.Visible = False
                    Label19.Visible = False
                    DateTimePicker1.Visible = True
                    Label26.Visible = True
            End Select
            dr.Close()
            conexion.conexion2.Close()
        Else
            MessageBox.Show("Generar el historial", "Cuotas de Operacion", MessageBoxButtons.OK, MessageBoxIcon.Error)

            historial.Show()
        End If


    End Sub
End Class