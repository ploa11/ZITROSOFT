'-------------------------------------------
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports Finisar.SQLite

'-------------------------------------------


Public Class Form_Reg_RQ
    '---------------------------
    Dim xlibro As Microsoft.Office.Interop.Excel.Application
    Dim strRutaExcel As String

    Dim sql, sql2, sql3, nc As String
    Dim res, res2 As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim dt2 As DataTable
    Dim nom_clie, ruc_clie As String

    'variable para la creacion de carpetas
    Dim n_carp As String

    'Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    '---------------------------
    'variables publicas
    Public pase1, pase2, codigo, pase3, pase4, cod_sbc As String
    Public cod As Double
    'variables locales
    Dim preg, accion As String
    Dim a As Integer
    Dim usu_gen, usu_rev, usu_aprob As String
    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim nc = InputBox("Ingrese el Orden de Servicio o Centro de costo", "RUMI")
        sql = "select *from T_SUB_C_COS_OS where  ORD_SERV='" + nc + "'or cod ='" + nc + "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            TextBox5.Text = dr(0)
            TextBox7.Text = dr(1)
            TextBox3.Text = dr(2)
            TextBox8.Text = dr(5)
            cod_sbc = dr(0)
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        'Me.Close()
        'Form_Reg_SCCOS.pase1 = "rq"
        ' Form_Reg_SCCOS.ComboBox1.Enabled = True
        'Form_Reg_SCCOS.TextBox4.Enabled = True
        'Form_Reg_SCCOS.Show()
        Button9.Enabled = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            accion = "guardar"
            guardar_rq()
            MsgBox("INGRESE PRODUCTOS O SERVICIOS")
            GroupBox2.Enabled = False
            GroupBox3.Enabled = True
            ListView1.Visible = True
            dgv.Visible = False
        Catch ex As Exception

        End Try


        ' buscar_rq()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            GroupBox2.Enabled = True
            DateTimePicker1.Enabled = True
            TextBox1.Text = ""
            TextBox5.Text = ""
            TextBox7.Text = ""
            TextBox3.Text = ""
            TextBox8.Text = ""
            DateTimePicker1.Text = ""
            ComboBox2.Text = ""
            ComboBox3.Text = ""



        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder, da2 As SqlClient.SqlDataAdapter

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Form_List_Product.pase1 = "rq"
        ' Form_List_Product.Show()

        Form_control_alamacen.pase1 = "rq"
        Form_control_alamacen.Show()

        TextBox9.Enabled = True
        TextBox6.Enabled = True
        TextBox10.Enabled = True
        TextBox11.Enabled = True
        ComboBox3.Enabled = True
        ComboBox7.Enabled = True
        Button6.Enabled = True


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            ListView1.Visible = True
            dgv.Visible = False
            item()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            EDITA_RQ_G_OPERACIONES()
            MessageBox.Show("REVISADO")
        Catch ex As Exception

        End Try

        'buscar_rq2()
        'llenar_PRO()
        'Button9.Enabled = True
        ' If ComboBox6.Text = "Aprobado" Then
        'Button11.Enabled = True
        ' End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "guardar"
        guardar()
    End Sub

    'Dim ds As DataSet
    'Dim dt As DataTable

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    'Dim res, o As Integer

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            EDITA_RQ_GERENCIA()
            MessageBox.Show("REVISADO Y/O ACTUALIZADO")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        copiar_ruta1()
        GENERA_RQ()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        buscar_rq2()
        llenar_PRO()
        If ComboBox6.Text = "Aprobado" Then
            Button11.Enabled = True
        End If
    End Sub

    Private Sub Form_Reg_RQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        combos.llenar_combo1_reg_rq()
        combos.llenar_combo2_reg_rq()
        combos.llenar_combo3_reg_rq()

        Select Case inicio.CARGO
            Case "SISTEMAS"
                ComboBox1.Enabled = True
                ComboBox5.Enabled = True
                ComboBox6.Enabled = True
                Button11.Enabled = True
                'usu_gen = ""
                'usu_rev = ""
                usu_aprob = inicio.DNI
                Label20.Text = inicio.DNI
            Case "ADMINISTRACION"
                ComboBox1.Enabled = True
                ComboBox5.Enabled = True
                ComboBox6.Enabled = True
                'usu_gen = ""
                'usu_rev = ""
                usu_aprob = inicio.DNI
                Label20.Text = inicio.DNI
            Case "SUPERVISOR"
                ComboBox1.Enabled = False
                ComboBox5.Enabled = True
                ComboBox6.Enabled = False
                'usu_gen = ""
                'usu_aprob = ""
                usu_rev = inicio.DNI
                Label19.Text = inicio.DNI
            Case "GERENCIA"
                ComboBox1.Enabled = False
                ComboBox5.Enabled = True
                ComboBox6.Enabled = False
                Button11.Enabled = True
                'usu_gen = ""
                'usu_rev = ""
                usu_aprob = inicio.DNI
                Label20.Text = inicio.DNI
            Case "TECNICO"
                ComboBox1.Enabled = False
                ComboBox5.Enabled = True
                ComboBox6.Enabled = False
                ComboBox5.Text = "Por Revisar"
                ComboBox6.Text = "Por Aprobacion"
                usu_gen = inicio.DNI
                'usu_rev = ""
                'usu_aprob = ""
                Label18.Text = inicio.DNI
            Case "LOGISTICA"
                ComboBox1.Enabled = False
                ComboBox5.Enabled = False
                ComboBox6.Enabled = False
                ComboBox5.Text = "Por Revisar"
                ComboBox6.Text = "Por Aprobacion"
                GroupBox1.Enabled = False
                DateTimePicker1.Enabled = False
                DateTimePicker2.Enabled = False
                DateTimePicker3.Enabled = False
                DateTimePicker4.Enabled = False
                Button11.Enabled = False
                ' usu_gen = inicio.DNI
                'usu_rev = ""
                'usu_aprob = ""
                Label18.Text = inicio.DNI
            Case "CONTABILIDAD"
                ComboBox1.Enabled = False
                ComboBox5.Enabled = False
                ComboBox6.Enabled = False
                ComboBox5.Text = "Por Revisar"
                ComboBox6.Text = "Por Aprobacion"
                GroupBox1.Enabled = False
                DateTimePicker1.Enabled = False
                DateTimePicker2.Enabled = False
                DateTimePicker3.Enabled = False
                DateTimePicker4.Enabled = False
                Button11.Enabled = False
                ' usu_gen = inicio.DNI
                'usu_rev = ""
                'usu_aprob = ""
                Label18.Text = inicio.DNI

        End Select



        'Select Case inicio.CARGO
        'Case "GERENCIA"
        'usu_gen = ""
        '   usu_rev = ""
        ' usu_aprob = inicio.DNI

        'Case "TECNICO"
        'usu_gen = inicio.DNI
        'usu_rev = ""
        'usu_aprob = ""
        'Case "SUPERVISOR"
        'usu_gen = ""
        'usu_aprob = ""
        'usu_rev = inicio.DNI
        'Case "SISTEMAS"
        'usu_gen = ""
        'usu_rev = ""
        'usu_aprob = inicio.DNI
        'End Select

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        crear_carpeta()
        copiar2()
        borrar()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click


        sub_archivos()
    End Sub

    'Public Sub llenar_combo1()
    'sql = "select *from T_CLASIFICACION"
    'Form_Reg_SRV_SQL.conectar()
    'da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
    'cb = New SqlClient.SqlCommandBuilder(da)
    ' dt = New DataTable
    ' da.Fill(dt)
    ' ComboBox2.DataSource = dt
    ' ComboBox2.DisplayMember = "DETALLE"
    ' ComboBox2.ValueMember = "DETALLE"
    'End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        Form_Orden_Compra.TextBox1.Text = TextBox1.Text
        Form_Orden_Compra.TextBox7.Text = TextBox5.Text
        Form_Orden_Compra.TextBox8.Text = TextBox7.Text
        Form_Orden_Compra.Show()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Close()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
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
        GroupBox3.Enabled = True
        GroupBox2.Enabled = True
        Button8.Enabled = True
        TextBox6.Enabled = True
        ComboBox3.Enabled = True
        TextBox11.Enabled = True
        Button4.Enabled = True
        Button6.Enabled = True
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        TextBox15.Text = ComboBox6.Text
    End Sub

    'Public Sub llenar_combo2()
    'sql = "select *from prioridad"
    'Form_Reg_SRV_SQL.conectar()
    'da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
    'cb = New SqlClient.SqlCommandBuilder(da)
    ' dt = New DataTable
    'da.Fill(dt)
    ' ComboBox4.DataSource = dt
    'ComboBox4.DisplayMember = "DETALLE"
    'ComboBox4.ValueMember = "DETALLE"
    ' End Sub

    'Public Sub llenar_combo3()
    ' sql = "select *from prioridad"
    ' Form_Reg_SRV_SQL.conectar()
    'da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
    ' cb = New SqlClient.SqlCommandBuilder(da)
    'dt = New DataTable
    ' da.Fill(dt)
    ' ComboBox3.DataSource = dt
    ' ComboBox3.DisplayMember = "DETALLE"
    ' ComboBox3.ValueMember = "DETALLE"
    ' End Sub

    Private Sub guardar()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")
        Try
            For o = 0 To ListView1.Items.Count - 1
                If accion = "guardar" Then
                    sql = "select *from P_REQUERIMIENTO where  COD='" + TextBox1.Text + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        buscar_copiarpqr()
                        Dim ITEM As String = ListView1.Items(o).SubItems(0).Text
                        Dim COD_RQ As String = ListView1.Items(o).SubItems(1).Text
                        Dim NP As String = ListView1.Items(o).SubItems(2).Text
                        Dim UND As String = ListView1.Items(o).SubItems(3).Text
                        Dim MD As String = ListView1.Items(o).SubItems(4).Text
                        Dim MC As String = ListView1.Items(o).SubItems(5).Text
                        Dim COLO As String = ListView1.Items(o).SubItems(6).Text
                        Dim AL As String = ListView1.Items(o).SubItems(7).Text
                        Dim CD As String = ListView1.Items(o).SubItems(8).Text
                        Dim ST As String = ListView1.Items(o).SubItems(9).Text
                        Dim PIO As String = ListView1.Items(o).SubItems(10).Text
                        Dim OBS As String = ListView1.Items(o).SubItems(11).Text
                        Dim FEC As String = DateTimePicker5.Value.ToString("yyyyMMdd")
                        Dim EST As String = ListView1.Items(o).SubItems(13).Text

                        sql = "INSERT INTO P_REQUERIMIENTO VALUES ( '" & codigo & "','" & ITEM & "','" & COD_RQ & "','" & NP & "','" & UND & "','" & MD & "','" & MC & "','" & COLO & "','" & AL & "','" & CD & "','" & ST & "','" & PIO & "','" & OBS & "','" & DateTimePicker5.Value.ToString("yyyyMMdd") & "','" & EST & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()


                        MessageBox.Show("Registro Guardado", "RUMISOFT")
                        'buscar_copiar()
                        ListView1.Visible = False
                        dgv.Visible = True
                        llenar_PRO()
                        'llenar_grid()
                        'facturas()
                        'fac_operacion_anx.Show()
                    End If


                End If
            Next

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Try
            n_carp = UCase(TextBox1.Text)
            Process.Start("explorer.exe", ("e:\ORCA\PROGRAMACION\WOCCU\WOCCU\RQ\" & n_carp))
        Catch ex As Exception
            MessageBox.Show("BUSQUE UN RQ PARA ABRIR SU CARPETA")
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub buscar_copiar()
        Try
            Dim aum_cod As String
            Dim dat As String = "RQ"
            'Dim cod, serie As String
            sql = "select *from T_REQUERIMIENTO where id in (select max(id) from T_REQUERIMIENTO)"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                cod = Microsoft.VisualBasic.Right(dr(0), 3)
                'TextBox1.Text = dr(0)
                'dtp1.Value = dr(1)
                'cb1.Text = dr(2)
                't1.Text = dr(4)
                't2.Text = dr(7)
                't4.Text = dr(8)
                't5.Text = dr(9)
            Else
                MessageBox.Show("Se generara Codigo", "RUMISOFT")
            End If
            dr.Close()
            Form_Reg_SRV_SQL.conexion.Close()
            If cod = 0 Then
                cod = 0
                aum_cod = cod.ToString("00000000")
                ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
                'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
                'serie = Microsoft.VisualBasic.Left(num_fac, 4)
                codigo = dat & (cod + 1).ToString("00000000")
            Else
                aum_cod = Microsoft.VisualBasic.Right(cod, 8)
                ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
                'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
                'serie = Microsoft.VisualBasic.Left(num_fac, 4)
                codigo = dat & (cod + 1).ToString("00000000")
                't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub buscar_copiarpqr()
        Try
            Dim aum_cod As String
            Dim dat As String = "PR"
            'Dim cod, serie As String
            sql = "select *from P_REQUERIMIENTO where id in (select max(id) from P_REQUERIMIENTO)"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                cod = Microsoft.VisualBasic.Right(dr(0), 3)
                'TextBox1.Text = dr(0)
                'dtp1.Value = dr(1)
                'cb1.Text = dr(2)
                't1.Text = dr(4)
                't2.Text = dr(7)
                't4.Text = dr(8)
                't5.Text = dr(9)
            Else
                MessageBox.Show("Se generara Codigo", "RUMISOFT")
            End If
            dr.Close()
            Form_Reg_SRV_SQL.conexion.Close()
            If cod = 0 Then
                cod = 0
                aum_cod = cod.ToString("00000000")
                ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
                'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
                'serie = Microsoft.VisualBasic.Left(num_fac, 4)
                codigo = dat & (cod + 1).ToString("00000000")
            Else
                aum_cod = Microsoft.VisualBasic.Right(cod, 8)
                ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
                'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
                'serie = Microsoft.VisualBasic.Left(num_fac, 4)
                codigo = dat & (cod + 1).ToString("00000000")
                't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
            End If

        Catch ex As Exception

        End Try


    End Sub
    Private Sub guardar_rq()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")
        Try

            If accion = "guardar" Then
                sql = "select *from T_REQUERIMIENTO where  COD='" + TextBox1.Text + "'"
                Form_Reg_SRV_SQL.conectar()
                com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                Else
                    buscar_copiar()
                    'sql = "INSERT INTO T_REQUERIMIENTO (COD,SEDE,CLASIFIC,SERVICIO,CEN_COST,SUB_CC_OS,FEC_REG,ITEM,NOM_PROD,UNID,MEDID,CANT,MARCA,PRIORI,GENE_USU,REV_USU,APROB_USU,DETA_GEN_USU,DETA_REV_USU,DETA_APROB_USU,F_GEN,F_REV,F_APROB) VALUES ( '" & codigo & "','" & UCase(TextBox5.Text) & "','" & UCase(ComboBox2.Text) & "','" & UCase(TextBox8.Text) & "','" & UCase(TextBox7.Text) & "','" & UCase(TextBox3.Text) & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & ComboBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox4.Text & "',""','" & ComboBox4.Text & "','" & usu_gen & "','" & usu_rev & "','" & usu_aprob & "','" & ComboBox1.Text & "','" & ComboBox5.Text & "','" & ComboBox6.Text & "','" & DateTimePicker2.Value.ToString("yyyyMMdd") & "','" & DateTimePicker3.Value.ToString("yyyyMMdd") & "','" & DateTimePicker4.Value.ToString("yyyyMMdd") & "')"t/

                    sql = "INSERT INTO T_REQUERIMIENTO (COD,SEDE,CLASIFIC,SERVICIO,CEN_COST,SUB_CC_OS,FEC_REG,PRIORI,GENE_USU,REV_USU,APROB_USU,DETA_GEN_USU,DETA_REV_USU,DETA_APROB_USU,F_GEN,F_REV,F_APROB, ESTADO, COMENT_USU,COMENT_SUP,COMENT_GEREN) VALUES ( '" & codigo & "','" & UCase(TextBox5.Text) & "','" & UCase(ComboBox2.Text) & "','" & UCase(TextBox8.Text) & "','" & UCase(TextBox7.Text) & "','" & UCase(TextBox3.Text) & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & ComboBox4.Text & "','" & usu_gen & "','" & usu_rev & "','" & usu_aprob & "','" & ComboBox1.Text & "','" & ComboBox5.Text & "','" & ComboBox6.Text & "','" & DateTimePicker2.Value.ToString("yyyyMMdd") & "','" & DateTimePicker3.Value.ToString("yyyyMMdd") & "','" & DateTimePicker4.Value.ToString("yyyyMMdd") & "','" & TextBox15.Text & "','" & TextBox16.Text & "','" & TextBox17.Text & "','" & TextBox18.Text & "')"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    res = com.ExecuteNonQuery
                    Form_Reg_SRV_SQL.conexion.Close()


                    MessageBox.Show("Registro Guardado", "RUMISOFT")
                    buscar_rq()
                    'buscar_copiar()
                    'llenar_grid()
                    'facturas()
                    'fac_operacion_anx.Show()
                End If


            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub EDITA_RQ_GERENCIA()
        Try
            sql = "UPDATE T_REQUERIMIENTO SET DETA_APROB_USU='" + UCase(ComboBox6.Text) + "', ESTADO= '" + UCase(ComboBox6.Text) + "', F_APROB='" + DateTimePicker4.Value.ToString("yyyyMMdd") + "', COMENT_GEREN='" + TextBox18.Text + "' WHERE COD='" + TextBox1.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            res = com.ExecuteNonQuery
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EDITA_RQ_G_OPERACIONES()
        Try
            sql = "UPDATE T_REQUERIMIENTO SET DETA_REV_USU='" + UCase(ComboBox5.Text) + "', ESTADO= '" + UCase(TextBox15.Text) + "', F_APROB='" + DateTimePicker3.Value.ToString("yyyyMMdd") + "', COMENT_SUP='" + TextBox17.Text + "' WHERE COD='" + TextBox1.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            res = com.ExecuteNonQuery
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub buscar_rq()
        Try
            'Dim aum_cod As String
            ' Dim dat As String = "RQ"
            'Dim cod, serie As String
            sql = "Select *from T_REQUERIMIENTO where id In (Select max(id) from T_REQUERIMIENTO)"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox5.Text = dr(1)
                TextBox7.Text = dr(4)
                TextBox3.Text = dr(5)
                TextBox8.Text = dr(3)
                DateTimePicker1.Value = dr(6)
                ComboBox2.Text = dr(2)
                ComboBox4.Text = dr(13)
                Label18.Text = dr(14)
                Label19.Text = dr(15)
                Label20.Text = dr(16)
                ComboBox1.Text = dr(17)
                ComboBox5.Text = dr(18)
                ComboBox6.Text = dr(19)
                DateTimePicker2.Value = dr(21)
                DateTimePicker3.Value = dr(22)
                DateTimePicker4.Value = dr(23)

                'TextBox1.Text = dr(0)
                'dtp1.Value = dr(1)
                'cb1.Text = dr(2)
                't1.Text = dr(4)
                't2.Text = dr(7)
                't4.Text = dr(8)
                't5.Text = dr(9)
            Else
                MessageBox.Show("Error EN MOSTRAR DATOS", "RUMISOFT")
            End If
            dr.Close()
            Form_Reg_SRV_SQL.conexion.Close()
            'If cod = 0 Then
            'cod = 0
            'aum_cod = cod.ToString("00000000")
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            ' codigo = dat & (cod + 1).ToString("00000000")
            ' Else
            'aum_cod = Microsoft.VisualBasic.Right(cod, 8)
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            'codigo = dat & (cod + 1).ToString("00000000")
            't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
            'End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub buscar_rq2()
        Try
            'Dim aum_cod As String
            ' Dim dat As String = "RQ"
            Dim nc As String = InputBox("Ingrese el Codigo De Requerimiento a buscar")
            sql = "Select *from T_REQUERIMIENTO where cod='" + nc + "'"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox5.Text = dr(1)
                TextBox7.Text = dr(4)
                TextBox3.Text = dr(5)
                TextBox8.Text = dr(3)
                DateTimePicker1.Value = dr(6)
                ComboBox2.Text = dr(2)
                ComboBox4.Text = dr(13)
                Label18.Text = dr(14)
                Label19.Text = dr(15)
                Label20.Text = dr(16)
                ComboBox1.Text = dr(17)
                ComboBox5.Text = dr(18)
                ComboBox6.Text = dr(19)
                DateTimePicker2.Value = dr(21)
                DateTimePicker3.Value = dr(22)
                DateTimePicker4.Value = dr(23)
                TextBox15.Text = dr(24)
                TextBox16.Text = dr(25)
                TextBox17.Text = dr(26)
                TextBox18.Text = dr(27)

                'TextBox1.Text = dr(0)
                'dtp1.Value = dr(1)
                'cb1.Text = dr(2)
                't1.Text = dr(4)
                't2.Text = dr(7)
                't4.Text = dr(8)
                't5.Text = dr(9)
            Else
                MessageBox.Show("ERROR EN MOSTRAR DATOS", "RUMISOFT")
            End If
            dr.Close()
            Form_Reg_SRV_SQL.conexion.Close()
            'If cod = 0 Then
            'cod = 0
            'aum_cod = cod.ToString("00000000")
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            ' codigo = dat & (cod + 1).ToString("00000000")
            ' Else
            'aum_cod = Microsoft.VisualBasic.Right(cod, 8)
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            'codigo = dat & (cod + 1).ToString("00000000")
            't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
            'End If
        Catch ex As Exception

        End Try



    End Sub
    Private Sub item()
        Try
            preg = MsgBox("Desea agregar datos de Productos", vbYesNo)
            a += 1
            Dim linea As New ListViewItem(a)

            If preg = vbYes Then
                linea.SubItems.Add(UCase(TextBox1.Text))
                linea.SubItems.Add(UCase(TextBox2.Text))
                linea.SubItems.Add(UCase(TextBox4.Text))
                linea.SubItems.Add(UCase(TextBox12.Text))
                linea.SubItems.Add(UCase(TextBox13.Text))
                linea.SubItems.Add(UCase(TextBox14.Text))
                linea.SubItems.Add(UCase(TextBox9.Text))
                linea.SubItems.Add(UCase(TextBox6.Text))
                linea.SubItems.Add(UCase(TextBox10.Text))
                linea.SubItems.Add(UCase(ComboBox3.Text))
                linea.SubItems.Add(UCase(TextBox11.Text))
                linea.SubItems.Add(DateTimePicker5.Value.ToString("dd/MM/yyyy"))
                linea.SubItems.Add(UCase(ComboBox7.Text))
                ListView1.Items.Add(linea)
                MessageBox.Show("Datos Agregados", "RUMISOFT")

            Else

                MessageBox.Show("No hay que registrar", "RUMISOFT")
                Button4.Enabled = True
                Button6.Enabled = False
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],ITEM, COD_RQ AS [CODIGO RQ] , NOM_PROD AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [MEDIDA], MARCA, COLOR, A_LIMA AS [ATENCION LIMA],CANT AS [CANTIDAD],STROK AS [STOCK],PRIORI AS [PRIORIDAD],OBS AS [OBSERVACION],FEC_REG AS [FECHA DE REGISTRO],ESTADO from P_REQUERIMIENTO "
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "P_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "P_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Private Sub llenar_PRO()

        Try
            sql = "select COD AS [CODIGO],ITEM, COD_RQ AS [CODIGO RQ] , NOM_PROD AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [MEDIDA], MARCA, COLOR, A_LIMA AS [ATENCION LIMA],CANT AS [CANTIDAD],STROK AS [STOCK],PRIORI AS [PRIORIDAD],OBS AS [OBSERVACION],FEC_REG AS [FECHA DE REGISTRO],ESTADO from P_REQUERIMIENTO WHERE COD_RQ='" + TextBox1.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "P_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "P_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub
    Public Sub GENERA_RQ()
        'El siguiente codigo es para crear la ruta,entre comillas se pone la ruta donde esta el libro
        Dim Ruta As String = Path.Combine(Directory.GetCurrentDirectory(), "REQUERIMIENTO.xlsx")
        strRutaExcel = Ruta
        Form_Reg_SRV_SQL.conectar()
        'El siguiente codigo es para abrir el libro y hacerlo visible, si se quiere dejar el libro oculto, se cambia la palabra True por False
        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)
        xlibro.Visible = True

        xlibro.Sheets("RQ").Select() 'Nombre del libro
        'esta es la instruccion para modificar la celda con el contenido de un textbox llamado textbox1, ustedes le pueden poner el nombre que deseen al textbox
        xlibro.Range("H4").Value = TextBox1.Text
        xlibro.Range("C7").Value = DateTimePicker1.Text
        xlibro.Range("C8").Value = Label18.Text
        xlibro.Range("C9").Value = TextBox7.Text
        xlibro.Range("G13").Value = "LIMA"
        xlibro.Range("B48").Value = Label18.Text
        ' xlibro.Range("E20").Value = t5.Text
        ' xlibro.Range("E21").Value = t6.Text
        ' xlibro.Range("E22").Value = t7.Text
        'xlibro.Range("E23").Value = t10.Text
        'xlibro.Range("H56").Value = nom_clie


        ''Cargamos las celdas con los datos de la base de datos
        'Dim Conexion As Finisar.SQLite.SQLiteConnection
        'Dim Adaptador As Finisar.SQLite.SQLiteDataAdapter

        'conexion = New Finisar.SQLite.SQLiteConnection
        'conexion.ConnectionString = "Data Source=abarrotes.db3;Version=3;"

        ' conexion.Open()

        'Dim ds As New DataSet
        'Adaptador = New Finisar.SQLite.SQLiteDataAdapter("select * from productos", Conexion)
        'Adaptador.Fill(ds)
        'Dim Conexion As SqlClient.SqlConnection
        Dim Adaptador As SqlClient.SqlDataAdapter

        'conexion = New SqlClient.SqlConnection
        'conexion.ConnectionString = "Data source = orcasoluciones; initial catalog = FO001; user id = sa; password = Orca2016"

        'conexion.Open()
        nc = TextBox1.Text
        Dim ds As New DataSet
        Adaptador = New SqlClient.SqlDataAdapter("select *from V_P_RQ where COD_RQ ='" + nc + "'", Form_Reg_SRV_SQL.conexion)
        Adaptador.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim fila As DataRow
            Dim ValorInicial As Integer = 19 ''Celda donde empezamos a insertar los articulos
            Dim Total As Double = 0
            For Each fila In ds.Tables(0).Rows
                xlibro.Range("A" & ValorInicial).Value = fila("CANTIDAD")
                xlibro.Range("B" & ValorInicial).Value = fila("NOMBRE DE PRODUCTO")
                'xlibro.Range("C" & ValorInicial).Value = fila("AMORTIZACION")
                'xlibro.Range("D" & ValorInicial).Value = fila("CAPITAL FINAL")
                ' xlibro.Range("E" & ValorInicial).Value = fila("INTERES")
                ' xlibro.Range("F" & ValorInicial).Value = fila("IGV")
                ' xlibro.Range("G" & ValorInicial).Value = fila("CUOTA TOTAL")
                ' xlibro.Range("H" & ValorInicial).Value = fila("FECHA DE INICIO")
                ' xlibro.Range("I" & ValorInicial).Value = fila("FECHA DE VENCIMIENTO")
                'xlibro.Range("J" & ValorInicial).Value = fila("DIAS DE CUOTA")

                'Total = Total + (fila("cantidad") * fila("precio"))

                ValorInicial += 1

            Next


        End If
        Form_Reg_SRV_SQL.conexion.Close()
    End Sub

    Private Sub crear_carpeta()
        Try
            'n_carp = UCase(t2.Text) & UCase(t3.Text) & UCase(t4.Text) & UCase(t5.Text)
            'Directory.CreateDirectory("\\Nlim010pdom\SOFTFONDOINVERSION\CLIENTES\" & n_carp)
            't6.Text = "\\Nlim010pdom\SOFTFONDOINVERSION\CLIENTES\" & n_carp
            'Button8.Enabled = True
            n_carp = UCase(TextBox1.Text)
            Directory.CreateDirectory("e:\ORCA\PROGRAMACION\WOCCU\WOCCU\RQ\" & n_carp)
            't6.Text = "\\orcasoluciones\instalador_opinv\clientes\" & n_carp
            'Button8.Enabled = True
        Catch ex As Exception
            MessageBox.Show("No pudo crear carpeta")
        End Try

    End Sub

    Private Sub sub_archivos()
        Try
            n_carp = UCase(TextBox1.Text)
            OpenFileDialog1.Title = "Selecciones los Documentos del Cliente"
            OpenFileDialog1.Filter = "JPG|*.jpg; *.jpeg|PNG|*.png|GIF|*.gif|PDF|*.pdf|DOC|*.doc|XLS|*.xls|PPT|*.ppt|DOCX|*.docx|XLSX|*.xlsx|XLSM|*.xlsm|PPTX|*.pptx"
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim extension As String = Path.GetExtension(OpenFileDialog1.FileName)
                If extension = ".jpg" Or extension = ".png" Or extension = ".gif" Or extension = ".pdf" Or extension = ".doc" Or extension = ".xls" Or extension = ".ppt" Or extension = ".docx" Or extension = ".xlsx" Or extension = ".xlsm" Or extension = ".pptx" Then
                    Dim nombreoriginal As String = Path.GetFileName(OpenFileDialog1.FileName)
                    Dim fecha As String = Date.Today()
                    fecha = fecha.Replace("/", "")
                    'Dim aleatorio As Integer = CInt(Int((999999 * Rnd()) + 1))
                    Dim nombrefinal As String = fecha & "_" & nombreoriginal
                    File.Copy(OpenFileDialog1.FileName, "E:\ORCA\PROGRAMACION\WOCCU\WOCCU\RQ\" & n_carp & "\" & nombrefinal)
                    'File.Copy(OpenFileDialog1.FileName, "\\Desktop-tvp9105\rq" & n_carp & "\")
                Else
                    MsgBox("El Formato de archivo no es el correcto")
                End If

            Else
                MessageBox.Show("No Seleccionaste Ningun Archivo")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub copiar_ruta1()

        Try
            Dim ruta As String
            Dim copia As String

            ruta = "E:\ORCA\PROGRAMACION\WOCCU\WOCCU\RUMISOFT\RUMISOFT\RUMISOFT\bin\Debug\formato\REQUERIMIENTO.xlsx"
            copia = "E:\ORCA\PROGRAMACION\WOCCU\WOCCU\RUMISOFT\RUMISOFT\RUMISOFT\bin\Debug\REQUERIMIENTO.xlsx"
            IO.File.Copy(ruta, copia)
            MessageBox.Show("ARCHIVO CREADO")
        Catch ex As Exception
            MessageBox.Show("Archivo ya Existe")
        End Try


    End Sub

    Private Sub borrar()
        Try
            Dim ArchivoBorrar As String
            ArchivoBorrar = "E:\ORCA\PROGRAMACION\WOCCU\WOCCU\RUMISOFT\RUMISOFT\RUMISOFT\bin\Debug\REQUERIMIENTO.xlsx"
            System.IO.File.Delete(ArchivoBorrar)
        Catch ex As Exception
            MessageBox.Show("Archivo no pudo ser borrado")
        End Try

    End Sub

    Private Sub copiar2()
        Try
            Dim ruta As String
            Dim copia As String
            n_carp = UCase(TextBox1.Text)
            ruta = "E:\ORCA\PROGRAMACION\WOCCU\WOCCU\RUMISOFT\RUMISOFT\RUMISOFT\bin\Debug\REQUERIMIENTO.xlsx"
            copia = "E:\ORCA\PROGRAMACION\WOCCU\WOCCU\RQ\" & n_carp & "\" & n_carp & ".xlsx"
            IO.File.Copy(ruta, copia)
            MessageBox.Show("CARPETA CREADA")
        Catch ex As Exception
            MessageBox.Show("Carpeta ya Existe")
        End Try

    End Sub
End Class