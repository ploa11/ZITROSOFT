Imports System.ComponentModel

Public Class Anex_Cronog
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

    Public accion As String
    Public gestion, fecha_f As String
    'variables publicas
    Public esta, cod_clie, cod_comi_desem, cod_cuop, tip_op, tipodoc_clie, numdoc_clie, cali_finan, cod2 As String
    Dim con As Integer
    Dim acciones As String = "guardar"
    Dim cod As Integer
    Dim cuenta, nom_cuenta, glosa, analitica As String
    Dim debe, haber As String
    'variable de fecha
    Public d1, m1, a1, d2, m2, a2, d3, m3, a3, dia1, mes1, dia2, mes2, dia3, mes3, f_ini, f_term, f_filt, ruc, fecha As String
    Dim fec As Date

    Private Sub t8_TextChanged(sender As Object, e As EventArgs) Handles t8.TextChanged

    End Sub

    Private Sub t9_TextChanged(sender As Object, e As EventArgs) Handles t9.TextChanged

    End Sub

    Private Sub t11_TextChanged(sender As Object, e As EventArgs) Handles t11.TextChanged

    End Sub

    Private Sub t6_TextChanged(sender As Object, e As EventArgs) Handles t6.TextChanged

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        '-------------------------------------------------------
        'llenar codigido de participe
        Dim cod1 As String
        ' Dim nfila, ncolu As Integer
        'detalle = ""
        'nfila = dgv.CurrentCell.RowIndex
        'ncolu = dgv.CurrentCell.ColumnIndex
        Try
            cod1 = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
            sql = "exec ver_d_operacion '" + cod1 + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                t1.Text = dr(0)
                'cod2 = dr(0)
                t2.Text = dr(1)
                cb1.Text = dr(4)
                t5.Text = dr(5)
                t6.Text = dr(6)
                t7.Text = dr(7)
                mgcd = dr(7)
                t8.Text = dr(8)
                t9.Text = dr(9)
                t10.Text = dr(10)
                t11.Text = dr(11)
                t12.Text = dr(12)
                dtp1.Value = dr(13)
                dtp2.Value = dr(14)
                cb2.Text = dr(15)
                gestion = dr(15)
                cb4.Text = dr(17)
                CB5.Text = dr(18)

            Else
                MessageBox.Show("Los Datos no Existen")
            End If
            dr.Close()
            conexion.conexion2.Close()
            Button6.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error al filtrar datos")
        End Try

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        comisiones_por_desembolso.Show()
        comisiones_por_desembolso.llenar_grid()
        comisiones_por_desembolso.suma_grid2()
        comisiones_por_desembolso.suma_grid_igv()
        comisiones_por_desembolso.dcb = comisiones_por_desembolso.t1.Text
        comisiones_por_desembolso.igvdcb = comisiones_por_desembolso.t2.Text
        comisiones_por_desembolso.t3.Text = comisiones_por_desembolso.dcb + comisiones_por_desembolso.igvdcb


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '-------------------------------------------------------
        'llenar codigido de participe
        nc = InputBox("Ingrese el Codigo de Operacion")
        sql = "exec ver_d_operacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            cb1.Text = dr(4)
            t5.Text = dr(5)
            t6.Text = dr(6)
            t7.Text = dr(7)
            t8.Text = dr(8)
            t9.Text = dr(9)
            t10.Text = dr(10)
            t11.Text = dr(11)
            t12.Text = dr(12)
            dtp1.Value = dr(13)
            dtp2.Value = dr(14)
            cb2.Text = dr(15)
            cb4.Text = dr(17)
            CB5.Text = dr(18)
        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
        Button6.Enabled = True

    End Sub
    Public Sub buscar_rev_cro_anx()
        nc = rev_cro_anx.cod_cronograma
        sql = "exec ver_d_operacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            cb1.Text = dr(4)
            t5.Text = dr(5)
            t6.Text = dr(6)
            t7.Text = dr(7)
            t8.Text = dr(8)
            t9.Text = dr(9)
            t10.Text = dr(10)
            t11.Text = dr(11)
            t12.Text = dr(12)
            dtp1.Value = dr(13)
            dtp2.Value = dr(14)
            cb2.Text = dr(15)
            cb4.Text = dr(17)
            CB5.Text = dr(18)
        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
        Button6.Enabled = True
    End Sub
    Private Sub t13_TextChanged(sender As Object, e As EventArgs) Handles t13.TextChanged
        Select Case cb3.Text
            Case "Codigo de Cronograma"
                filtro_text()
            Case "Codigo de Cliente"
                filtro_text()

        End Select
        'filtro_text()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        registro_clientes.activar = 2
        registro_clientes.Show()
    End Sub

    Private Sub t12_TextChanged(sender As Object, e As EventArgs) Handles t12.TextChanged

    End Sub

    Private Sub cb3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb3.SelectedIndexChanged
        If cb3.Text = "Cronograma" Then
            t13.Enabled = True
            dtp3.Enabled = False
            Label14.Enabled = True
            Label21.Enabled = False
            estadof.Enabled = False
        Else
            If cb3.Text = "Fecha de inicio" Then
                t13.Enabled = False
                dtp3.Enabled = True
                Label14.Enabled = False
                Label21.Enabled = True
                dtp4.Enabled = False
                Label22.Enabled = False
                estadof.Enabled = False
            Else
                If cb3.Text = "Fecha de termino" Then
                    t13.Enabled = False
                    dtp3.Enabled = False
                    Label14.Enabled = False
                    Label21.Enabled = False
                    dtp4.Enabled = True
                    Label22.Enabled = True
                    estadof.Enabled = False
                Else
                    If cb3.Text = "Estado" Then
                        estadof.Enabled = True
                        t13.Enabled = False
                        dtp3.Enabled = False
                        Label14.Enabled = False
                        Label21.Enabled = False
                        dtp4.Enabled = False
                        Label22.Enabled = False
                    Else
                        If cb3.Text = "Codigo de Cliente" Then
                            t13.Enabled = True
                            dtp3.Enabled = False
                            Label14.Enabled = True
                            Label21.Enabled = False
                            estadof.Enabled = False
                        End If
                    End If
                    End If
            End If

        End If
    End Sub

    'procentajes y montos de porcentajes
    Dim pgcd, pigv, pint, mgcd, migv, mint As String

    Private Sub dtp3_ValueChanged(sender As Object, e As EventArgs) Handles dtp3.ValueChanged
        If cb3.Text = "Fecha de inicio" Then
            filtro_fecha()
        End If

    End Sub

    'montos prestamos
    Dim mont_soli, mont_prest As String



    'variable locales
    Dim sql, nc As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        gasto_comi_desembolso()
        Cuotas_Operacion.verifi = 1
        Cuotas_Operacion.Button13.Visible = False
        Cuotas_Operacion.Show()



    End Sub

    Private Sub gasto_comi_desembolso()

        Dim comi, detalle, IGV As String
        Dim f_i As Date = dtp1.Value
        Dim f_v As Date = dtp2.Value
        ''Dim nfila, ncolu As Integer
        comi = "guardar"
        detalle = ""
        Try
            'nfila = dgv.CurrentCell.RowIndex
            ' ncolu = dgv.CurrentCell.ColumnIndex

            'cod = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
            'dgv.FirstDisplayedScrollingRowIndex = dgv.RowCount - 1
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
            f_ini = f_i.ToString("yyyyMMdd")
            f_term = f_v.ToString("yyyyMMdd")
            cod2 = t1.Text
            esta = cb3.Text
            IGV = t9.Text
            If comi = "guardar" Then
                sql = "exec ver_comi_desem'" + cod2 + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    'MessageBox.Show("Los Datos ya Existen", "Datos Comision Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MsgBox("DATOS DE COMISION DE DESEMBOLSO YA SE AN GENERADO", MsgBoxStyle.Information, "Optima")
                    dr.Close()
                    conexion.conexion2.Close()
                Else
                    sql = "exec alta_comi_desembolso '" + f_ini + "','" + detalle + "','" + mgcd + "','" + cod2 + "','" + gestion + "','" + IGV + "'"
                    conexion.conectarfondo()
                    com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                    res = com.ExecuteNonQuery
                    conexion.conexion2.Close()
                    MessageBox.Show("Registro Guardado", "Comision de Desembolso")

                End If
                'ElseIf accion = "editar" Then
                'sql = "exec edita_comi_desem'" + f_ini + "','" + detalle + "','" + mgcd + "','" + cod + "','" + gestion + "'"
                'conexion.conectarfondo()
                'com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                ' res = com.ExecuteNonQuery
                ' conexion.conexion2.Close()
                'MessageBox.Show("Registro Modificado")

            End If
            '---------------------------------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show("Problemas al Guardar datos")

        End Try

    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t2.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        t9.Enabled = True
        t10.Enabled = True
        t11.Enabled = True
        t12.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        cb3.Enabled = True
        cb4.Enabled = True
        CB5.Enabled = True
        dtp1.Enabled = True
        dtp2.Enabled = False
        Button8.Enabled = True
        Button11.Enabled = True
        TextBox2.Text = ""
        TextBox2.Enabled = True
        t1.Text = ""
        t2.Text = ""
        t5.Text = ""
        t6.Text = 1
        t7.Text = ""
        t8.Text = 18
        t9.Text = ""
        t10.Text = ""
        t11.Text = 2
        t12.Text = 0
        cb1.Text = ""
        cb2.Text = ""
        cb3.Text = ""
        cb4.Text = ""
        CB5.Text = ""
        TextBox2.Text = ""
        dgv.Enabled = False

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub dtp4_ValueChanged(sender As Object, e As EventArgs) Handles dtp4.ValueChanged
        If cb3.Text = "Fecha de termino" Then
            filtro_fechaf()
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        historial.Show()
        historial.buscar_h_cronograma()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        registro_clientes.Show()
        registro_clientes.Button8.Enabled = True
    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged

    End Sub

    Private Sub Anex_Cronog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        Me.Text = "Creacion de Cronograma" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        llenar_grid()
        llenar_combo1()
        t12.Text = 0
    End Sub
    Public Sub buscar_reprogramado()

        nc = t1.Text
        sql = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA')"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA')")
        'dgv.DataSource = ds
        'dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA')"
        Form4.dgv.DataSource = ds
        Form4.dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA')"
        conexion.conexion2.Close()
    End Sub
    Private Sub estadof_SelectedIndexChanged(sender As Object, e As EventArgs) Handles estadof.SelectedIndexChanged
        estadofil()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
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

    Private Sub cb2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb2.SelectedIndexChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Me.Close()
    End Sub

    Private Sub cb4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb4.SelectedIndexChanged

        If cb4.Text = "REPROGRAMADO" Then
            ' buscar_reprogramado()
            ' Form4.Show()
        End If

    End Sub

    Private Sub CB5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB5.SelectedIndexChanged

    End Sub

    Private Sub t7_TextChanged(sender As Object, e As EventArgs) Handles t7.TextChanged

    End Sub

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t1.Enabled = True
        t2.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        t9.Enabled = True
        t10.Enabled = True
        t11.Enabled = True
        t12.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        dtp1.Enabled = True
        dtp2.Enabled = True
        cb4.Enabled = True
        CB5.Enabled = True
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        gen_asiento()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        cb3.Enabled = True
        't13.Enabled = True
        'dtp3.Enabled = True
    End Sub

    Public Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim fe_ini As Date = dtp1.Value 'guardar fechas sql
        Dim fe_fin As Date = dtp2.Value

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

        'f_ini = a1 + m1 + d1 'concatenar fecha inicia
        'f_term = a2 + m2 + d2 'concatenar fecha termino
        'fin de fechas sql
        f_ini = fe_ini.ToString("yyyyMMdd")
        f_term = fe_fin.ToString("yyyyMMdd")
        Button1.Enabled = True
        '---------------------------------------------------------
        '-registro de los datos
        nc = UCase(t1.Text)
        cod_clie = UCase(t2.Text)
        cod_comi_desem = TextBox2.Text
        cod_cuop = ""
        tip_op = UCase(cb1.Text)
        mont_soli = UCase(t5.Text)
        pgcd = UCase(t6.Text)
        mgcd = UCase(t7.Text)
        pigv = UCase(t8.Text)
        migv = UCase(t9.Text)
        mont_prest = UCase(t10.Text)
        pint = UCase(t11.Text)
        mint = UCase(t12.Text)
        gestion = UCase(cb2.Text)
        esta = cb4.Text
        Dim est_teso As String = CB5.Text
        Dim BANC_FONDO As String = ""
        Dim BANC_CLIE As String = ""
        sql = ""
        Try
            If accion = "guardar" Then
                sql = "exec ver_d_operacion'" + nc + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("Los Datos ya Existen", "Datos oepracion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    conexion.conexion2.Close()
                Else
                    sql = "exec alta_d_operacion '" + cod_clie + "','" + cod_comi_desem + "','" + cod_cuop + "','" + tip_op + "','" + mont_soli + "','" + pgcd + "','" + mgcd + "','" + pigv + "','" + migv + "','" + mont_prest + "','" + pint + "','" + mint + "','" + f_ini + "','" + f_term + "','" + gestion + "','" + esta + "','" + est_teso + "','" + BANC_FONDO + "','" + BANC_CLIE + "'"
                    conexion.conectarfondo()
                    com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                    res = com.ExecuteNonQuery
                    conexion.conexion2.Close()
                    MessageBox.Show("Registro Guardado")
                    buscar_copiar()

                End If
            ElseIf accion = "editar" Then
                sql = "exec edita_d_operacion'" + nc + "','" + cod_clie + "','" + cod_comi_desem + "','" + cod_cuop + "','" + tip_op + "','" + mont_soli + "','" + pgcd + "','" + mgcd + "','" + pigv + "','" + migv + "','" + mont_prest + "','" + pint + "','" + mint + "','" + f_ini + "','" + f_term + "','" + gestion + "','" + esta + "','" + est_teso + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Modificado")
                Select Case cb4.Text
                    Case "REPROGRAMADO"
                        'Cuotas_Operacion.buscar_reprogramado()
                        'Cuotas_Operacion.Show()
                        buscar_reprogramado()
                        Form4.Show()
                End Select

            End If
            Button6.Enabled = True
            llenar_grid()

            t1.Enabled = False
            t2.Enabled = False
            t5.Enabled = False
            t6.Enabled = False
            t7.Enabled = False
            t8.Enabled = False
            t9.Enabled = False
            t10.Enabled = False
            t11.Enabled = False
            t12.Enabled = False
            dtp1.Enabled = False
            dtp2.Enabled = False
            Button8.Enabled = False
            Button9.Enabled = True
            cb1.Enabled = False
            cb2.Enabled = False
            cb3.Enabled = False
            cb4.Enabled = False
            CB5.Enabled = False

        Catch ex As Exception
            MessageBox.Show("No se pudo guardar los datos", "Optima")
        End Try

    End Sub
    Private Sub llenar_grid()
        Try
            sql = "select * from v_d_operacion"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_d_operacion")
            dgv.DataSource = ds
            dgv.DataMember = "v_d_operacion"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("No hay conexion con la lista", "Optima")
        End Try

    End Sub

    Private Sub gen_asiento()
        acciones = "guardar"
        sql = ""
        glosa = "POR LA APROBACION DEL" + " " + t1.Text + " " + "DESCUENTO DE FLUJO DINERARIOS"
        TextBox1.Text = glosa
        fec = dtp1.Value
        fecha = fec.ToString("yyyyMMdd")
        analitica = t1.Text
        Dim mont1, mont2 As Double
        Try
            For con = 1 To 6
                Select Case con
                    Case = 1
                        cuenta = "121111"
                        buscar_cuenta()
                        mont1 = t10.Text
                        debe = mont1
                        haber = 0.0
                        guardar_asiento()
                    Case = 2
                        cuenta = "121121"
                        buscar_cuenta()
                        mont2 = t12.Text
                        debe = mont2
                        haber = 0.0
                        guardar_asiento()
                    Case = 3
                        cuenta = "496111"
                        buscar_cuenta()
                        mont1 = t12.Text
                        debe = 0.0
                        haber = mont1
                        guardar_asiento()
                    Case = 4
                        cuenta = "421111"
                        buscar_cuenta()
                        mont2 = t10.Text
                        debe = 0.0
                        haber = mont2
                        guardar_asiento()
                    Case = 5
                        cuenta = "001111"
                        buscar_cuenta()
                        mont1 = t10.Text
                        mont2 = t12.Text
                        debe = mont1 + mont2
                        haber = 0.0
                        guardar_asiento()
                    Case = 6
                        cuenta = "002111"
                        buscar_cuenta()
                        mont1 = t10.Text
                        mont2 = t12.Text
                        debe = 0.0
                        haber = mont1 + mont2
                        guardar_asiento()
                End Select

            Next
            MessageBox.Show("Asientos Contables Generados")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub buscar_cuenta()
        sql = "Select *from plan_contable where cuenta Like'" + cuenta + "%'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            nom_cuenta = dr(1)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        Button3.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub
    Private Sub guardar_asiento()
        sql = ""
        If acciones = "guardar" Then

            'sql = "exec ver_asiento_contable'" + cod + "'"
            'conexion.conectarfondo()
            'com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            'dr = com.ExecuteReader
            'If dr.Read Then
            'MessageBox.Show("Los Datos ya Existen", "Datos de Asientos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'dr.Close()
            'conexion.conexion2.Close()
            'Else
            sql = "exec alta_asiento_contable '" + glosa + "','" + ruc + "','" + analitica + "','" + cuenta + "','" + nom_cuenta + "','" + debe + "','" + haber + "','" + fecha + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            'MessageBox.Show("Registro Guardado")
            buscar_copiar()

        Else


            sql = "exec edita_asiento_contable'" + cod + "','" + glosa + "','" + ruc + "','" + analitica + "','" + cuenta + "','" + nom_cuenta + "','" + debe + "','" + haber + "','" + fecha + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            'MessageBox.Show("Registro Modificado")

        End If
    End Sub

    Private Sub t6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t6.KeyPress

        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                t7.Text = (t5.Text * t6.Text) / 100
            End If
        Catch ex As Exception
            MessageBox.Show("Ingresa el Porcentaje de Comision de desembolso", "Optima")
        End Try


    End Sub

    Private Sub t9_Move(sender As Object, e As EventArgs) Handles t9.Move

    End Sub

    Private Sub t9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t9.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim a As Decimal = t5.Text
                Dim b As Decimal = t7.Text
                Dim c As Decimal = t9.Text
                t10.Text = a + b + c
            End If
        Catch ex As Exception
            MessageBox.Show("El calculo presente problemas", "Optima")
        End Try

    End Sub

    Private Sub t8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t8.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                t9.Text = ((t7.Text * t8.Text) / 100)
            End If
        Catch ex As Exception
            MessageBox.Show("Ingresa Porcentaje de Igv", "Optima")
        End Try

    End Sub

    Private Sub t11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t11.KeyPress

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
    Private Sub buscar_copiar()
        Try
            sql = "select *from d_operacion where id in (select max(id) from d_operacion)"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                t1.Text = dr(0)
                t2.Text = dr(1)
                cb1.Text = dr(4)
                t5.Text = dr(5)
                t6.Text = dr(6)
                t7.Text = dr(7)
                t8.Text = dr(8)
                t9.Text = dr(9)
                t10.Text = dr(10)
                dtp1.Text = dr(13)
                dtp2.Text = dr(14)
                cb2.Text = dr(15)
                cb4.Text = dr(17)
            Else
                MessageBox.Show("Los Datos no Existen", "Optima")
            End If
            dr.Close()
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Problemas en la bsuqueda", "Optima")
        End Try

    End Sub
    Public Sub filtro_text()
        Try
            nc = t13.Text
            sql = "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%' or [CODIGO DE CLIENTE] like '" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%' or [CODIGO DE CLIENTE] like '" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%' or [CODIGO DE CLIENTE] like '" + nc + "%'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub
    Public Sub filtro_cod_clie_fecha()
        Try
            nc = t13.Text
            sql = "select *from v_d_operacion where [CODIGO DE CLIENTE] like'" + nc + "%' and [FECHA INICIO DE PRESTAMO] ='" + fecha_f + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [CODIGO DE CLIENTE] like'" + nc + "%' and [FECHA INICIO DE PRESTAMO] ='" + fecha_f + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [CODIGO DE CLIENTE] like'" + nc + "%' and [FECHA INICIO DE PRESTAMO] ='" + fecha_f + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub

    Public Sub filtro_text2()
        Try
            nc = G_Asientos.cod_cliente.Text
            sql = "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%' or [CODIGO DE CLIENTE] like '" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%' or [CODIGO DE CLIENTE] like '" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%' or [CODIGO DE CLIENTE] like '" + nc + "%'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub
    Private Sub filtro_fecha()
        Try
            Dim fecha As Date
            Dim fech As String

            fecha = dtp3.Value
            fech = fecha.ToString("yyyyMMdd")
            nc = fech
            sql = "select *from v_d_operacion where [FECHA INICIO DE PRESTAMO] ='" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [FECHA INICIO DE PRESTAMO] ='" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [FECHA INICIO DE PRESTAMO] ='" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub
    Private Sub filtro_fechaf()
        Dim fecha2 As Date
        Dim fech2 As String
        Try
            fecha2 = dtp4.Value
            fech2 = fecha2.ToString("yyyyMMdd")
            nc = fech2
            sql = "select *from v_d_operacion where [FECHA TERMINO PRESTAMO] ='" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [FECHA TERMINO PRESTAMO] ='" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [FECHA TERMINO PRESTAMO] ='" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas")
        End Try

    End Sub
    Private Sub estadofil()
        Try
            Dim fech As String
            fech = estadof.Text
            nc = fech
            sql = "select *from v_d_operacion where [ESTADO] ='" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [ESTADO] ='" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [ESTADO] ='" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub
    Private Sub dtp3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp3.KeyPress
        'filtro_fecha()
    End Sub

    Private Sub dtp3_Click(sender As Object, e As EventArgs) Handles dtp3.Click
        'filtro_fecha()
    End Sub

    Private Sub dtp3_MouseEnter(sender As Object, e As EventArgs) Handles dtp3.MouseEnter
        'filtro_fecha()
    End Sub

    Private Sub dtp3_VisibleChanged(sender As Object, e As EventArgs) Handles dtp3.VisibleChanged
        ' filtro_fecha()
    End Sub

    Private Sub dtp3_Validated(sender As Object, e As EventArgs) Handles dtp3.Validated
        ' filtro_fecha()
    End Sub

    Private Sub dtp3_TabIndexChanged(sender As Object, e As EventArgs) Handles dtp3.TabIndexChanged
        'filtro_fecha()

    End Sub

    Private Sub dtp3_ParentChanged(sender As Object, e As EventArgs) Handles dtp3.ParentChanged

    End Sub

    Private Sub dtp3_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles dtp3.ContextMenuStripChanged

    End Sub

    Private Sub dtp3_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles dtp3.ChangeUICues
        'filtro_fecha()
    End Sub

    Private Sub dtp3_CursorChanged(sender As Object, e As EventArgs) Handles dtp3.CursorChanged
        'filtro_fecha()
    End Sub

    Private Sub dtp3_CausesValidationChanged(sender As Object, e As EventArgs) Handles dtp3.CausesValidationChanged
        'filtro_fecha()
    End Sub

    Private Sub dtp3_Validating(sender As Object, e As CancelEventArgs) Handles dtp3.Validating
        'filtro_fecha()
    End Sub

    Private Sub dtp3_TextChanged(sender As Object, e As EventArgs) Handles dtp3.TextChanged
        'filtro_fecha()
    End Sub

    Private Sub dtp3_PaddingChanged(sender As Object, e As EventArgs) Handles dtp3.PaddingChanged
        'filtro_fecha()
    End Sub

    Private Sub dtp3_MouseHover(sender As Object, e As EventArgs) Handles dtp3.MouseHover
        'filtro_fecha()
    End Sub

    Private Sub dtp3_MouseCaptureChanged(sender As Object, e As EventArgs) Handles dtp3.MouseCaptureChanged
        'filtro_fecha()
    End Sub

    Private Sub dtp3_MouseClick(sender As Object, e As MouseEventArgs) Handles dtp3.MouseClick
        'filtro_fecha()
    End Sub

    Private Sub dtp3_MouseLeave(sender As Object, e As EventArgs) Handles dtp3.MouseLeave
        'filtro_fecha()
    End Sub

    Private Sub dtp3_MouseMove(sender As Object, e As MouseEventArgs) Handles dtp3.MouseMove
        'filtro_fecha()

    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Dim cod1 As String
        ' Dim nfila, ncolu As Integer
        'detalle = ""
        'nfila = dgv.CurrentCell.RowIndex
        'ncolu = dgv.CurrentCell.ColumnIndex
        Try
            cod1 = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
            sql = "exec ver_d_operacion '" + cod1 + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                facturacion_fondos.cod_crono = dr(0)
                facturacion_fondos.t2.Text = dr(0)
                'cod2 = dr(0)
                't2.Text = dr(1)
                'cb1.Text = dr(4)
                ' t5.Text = dr(5)
                't6.Text = dr(6)
                't7.Text = dr(7)
                'mgcd = dr(7)
                't8.Text = dr(8)
                't9.Text = dr(9)
                't10.Text = dr(10)
                't11.Text = dr(11)
                ' t12.Text = dr(12)
                'dtp1.Value = dr(13)
                'dtp2.Value = dr(14)
                'cb2.Text = dr(15)
                'gestion = dr(15)
                'cb4.Text = dr(17)
                'CB5.Text = dr(18)

            Else
                MessageBox.Show("Los Datos no Existen")
            End If
            dr.Close()
            conexion.conexion2.Close()
            facturacion_fondos.Button6.Visible = True
            Me.Close()
            Button6.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error al filtrar datos")
        End Try
    End Sub
End Class