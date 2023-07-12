Public Class form_ingreso_salida

    Public codigo, nom, ap_pa, ap_ma, dni, cargo, pase1, pase2, STOKACTUAL, COD_INGRESO As String
    Public linea2 As ListViewItem
    Public CONT As Integer
    'variables sql
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Select Case ComboBox1.Text
                Case "GUIA DE INGRESO"
                    buscar_copiar_INGRESO()
                    TextBox1.Text = codigo
                    'Button3.Enabled = True
                    'Button4.Enabled = False
                Case "GUIA DE SALIDA"
                    buscar_copiar_SALIDA()
                    TextBox1.Text = codigo
                    'Button3.Enabled = False
                    'Button4.Enabled = True
            End Select

        Catch ex As Exception

        End Try
        Try
            Select Case ComboBox1.Text
                Case "GUIA DE INGRESO"
                    Button3.Enabled = True
                    Button4.Enabled = False
                Case "GUIA DE SALIDA"
                    Button3.Enabled = False
                    Button4.Enabled = True
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            Select Case ComboBox1.Text
                Case "GUIA DE SALIDA"
                    item2()

                Case "GUIA DE INGRESO"
                    item()

            End Select
        Catch ex As Exception

        End Try
        'item()
        'item2()
    End Sub

    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Select Case ComboBox1.Text
            Case "GUIA DE INGRESO"
                preg = MsgBox("Desea Generar el Numero de Guia de Ingreso y Agregar Porductos", vbYesNo)
                accion = "guardar"
                If preg = vbYes Then
                    guardarguiaINGRESO()
                    guardarguiaINGRESOPRODUC()
                    llenar_grid_gingresop()
                Else
                    MessageBox.Show("No se genera Guia de Ingreso", "RUMISOFT")
                End If

            Case "GUIA DE SALIDA"
                preg = MsgBox("Desea Generar el Numero de Guia de Salida y Agregar Porductos", vbYesNo)
                accion = "guardar"
                If preg = vbYes Then
                    guardarguiaSALIDA()
                    guardarguiaSALIDAPRODUC()
                    llenar_grid_gsalidap()
                Else
                    MessageBox.Show("No se genera Guia de Salida", "RUMISOFT")
                End If
        End Select
    End Sub

    Dim res, o As Integer
    Public cod As Double
    'variables locales
    Dim preg, sql, accion, SEDE, MICARGO As String
    Dim a As Integer

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Select Case ComboBox3.Text
            Case "GUIA DE INGRESO"
                llenar_comboguia_i()
                ComboBox2.Enabled = True
                TextBox3.Enabled = True
                Button6.Enabled = True
                dgv.Visible = True
                llenar_grid_gingresop()
            Case "GUIA DE SALIDA"
                llenar_comboguia_s()
                ComboBox2.Enabled = True
                TextBox3.Enabled = True
                Button6.Enabled = True
                dgv.Visible = True
                llenar_grid_gsalidap()
        End Select
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form_Nvo_Ingreso.Show()
        ListView1.Visible = True
        ListView2.Visible = False
        dgv.Visible = False

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form_Nva_Salida.Show()
        ListView2.Visible = True
        ListView1.Visible = False
        dgv.Visible = False
        TextBox5.Text = inicio.SEDE
        Form_Nva_Salida.pase1 = "SALIDA"
    End Sub

    Private Sub form_ingreso_salida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combo1()
        TextBox5.Text = inicio.SEDE
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form_Reg_Usuario.Show()
        Form_Reg_Usuario.pase1 = "salida"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form_Reg_Sede.Show()
        Form_Reg_Sede.pase1 = "salida"
    End Sub

    Private Sub buscar_copiar_INGRESO()
        Dim aum_cod As String
        Dim dat As String = "GI"
        'Dim cod, serie As String
        sql = "select *from GUIA_INGRESO where id in (select max(id) from GUIA_INGRESO)"
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
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form_Reg_SCCOS.Show()
        Form_Reg_SCCOS.pase1 = "guia"
    End Sub

    Private Sub buscar_copiar_SALIDA()
        Dim aum_cod As String
        Dim dat As String = "GS"
        'Dim cod, serie As String
        sql = "select *from GUIA_SALIDA where id in (select max(id) from GUIA_SALIDA)"
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

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        dgv.Visible = True
        llenar_grid_salida()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        FILTRO()
    End Sub

    Public Sub item()
        preg = MsgBox("Desea agregar Cantidad de Productos", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            'linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(Form_Nvo_Ingreso.Label12.Text))
            linea.SubItems.Add(UCase(Form_Nvo_Ingreso.TextBox1.Text))
            linea.SubItems.Add(UCase(Form_Nvo_Ingreso.NCANTIDAD))
            linea.SubItems.Add(UCase(DateTimePicker1.Value))
            'linea.SubItems.Add(UCase(TextBox5.Text))
            'linea.SubItems.Add(UCase(TextBox6.Text))
            'linea.SubItems.Add(UCase(ComboBox1.Text))
            'linea.SubItems.Add(UCase(ComboBox2.Text))
            'linea.SubItems.Add(UCase(TextBox6.Text))
            'linea.SubItems.Add(UCase(TextBox7.Text))
            ListView1.Items.Add(linea)
            MessageBox.Show("Datos Agregados", "RUMISOFT")
            Button2.Enabled = True
            Button1.Enabled = False
        Else

            ' MessageBox.Show("No hay que registrar", "PROSERTEC")

            'Button6.Enabled = False
        End If

    End Sub

    Public Sub item2()
        preg = MsgBox("Desea agregar Cantidad de Productos", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            'linea.SubItems.Add(UCase(TextBox1.Text))
            'linea.SubItems.Add(UCase(TextBox1.Text))
            'linea.SubItems.Add(UCase(TextBox2.Text))
            'linea.SubItems.Add(UCase(TextBox3.Text))
            'linea.SubItems.Add(UCase(TextBox4.Text))
            'linea.SubItems.Add(UCase(DateTimePicker1.Value))
            'linea.SubItems.Add(UCase(TextBox5.Text))
            'linea.SubItems.Add(UCase(TextBox6.Text))
            'linea.SubItems.Add(UCase(ComboBox1.Text))
            'linea.SubItems.Add(UCase(ComboBox2.Text))
            'linea.SubItems.Add(UCase(TextBox6.Text))
            'linea.SubItems.Add(UCase(TextBox7.Text))
            'linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(Form_Nva_Salida.Label11.Text))
            linea.SubItems.Add(UCase(Form_Nva_Salida.TextBox1.Text))
            linea.SubItems.Add(UCase(Form_Nva_Salida.NINGRESO))
            linea.SubItems.Add(UCase(DateTimePicker1.Value))
            ListView2.Items.Add(linea)
            MessageBox.Show("Datos Agregados", "RUMISOFT")
            Button2.Enabled = True
            Button1.Enabled = False
        Else

            ' MessageBox.Show("No hay que registrar", "PROSERTEC")

            'Button6.Enabled = False
        End If

    End Sub

    Private Sub guardarguiaINGRESO()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")


        'buscar_copiar()
        'codigo = "USU0000001"
        Dim COD As String = TextBox1.Text
        Dim DET As String = "GUIA DE INGRESO"
        Dim SED As String = inicio.SEDE
        'Dim FEC As String = DateTimePicker1.Value.ToString("yyyyMMdd")
        'Dim SEDE As String = SEDE

        Try
            If accion = "guardar" Then

                sql = "select *from GUIA_INGRESO where  COD='" + COD + "'"
                Form_Reg_SRV_SQL.conectar()
                com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                dr = com.ExecuteReader

                If dr.Read Then
                    'cod = dr(0)
                    MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                Else
                    sql = "INSERT INTO GUIA_INGRESO  VALUES ('" & COD & "','" & DET & "','" & SED & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "')"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    res = com.ExecuteNonQuery
                    Form_Reg_SRV_SQL.conexion.Close()
                    MessageBox.Show("Registro Guardado", "RUMISOFT")
                End If


                'buscar_copiar()


                'fac_operacion_anx.Show()
            End If

        Catch ex As Exception

        End Try

        'Select Case ComboBox1.Text
        'Case "GUIA DE INGRESO"
        ' llenar_grid_gingreso()
        ' Case "GUIA DE SALIDA"
        'llenar_grid_gsalida()

        'End Select
        'coloini()
        'ListView1.Items.Clear()
        'ListView1.Visible = False
        'dgv.Visible = True

        'DateTimePicker1.Visible = False


    End Sub

    Private Sub guardarguiaSALIDA()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")


        'buscar_copiar()
        'codigo = "USU0000001"
        Dim COD As String = TextBox1.Text
        Dim DET As String = "GUIA DE SALIDA"
        Dim SED As String = inicio.SEDE
        Dim FEC As String = DateTimePicker1.Value.ToString("yyyyMMdd")
        'Dim SEDE As String = SEDE

        Try
            If accion = "guardar" Then

                sql = "select *from GUIA_SALIDA where  COD='" + COD + "'"
                Form_Reg_SRV_SQL.conectar()
                com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                dr = com.ExecuteReader

                If dr.Read Then
                    'cod = dr(0)
                    MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                Else
                    sql = "INSERT INTO GUIA_SALIDA  VALUES ('" & COD & "','" & DET & "','" & SED & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "')"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    res = com.ExecuteNonQuery
                    Form_Reg_SRV_SQL.conexion.Close()
                    MessageBox.Show("Registro Guardado", "RUMISOFT")
                End If


                'buscar_copiar()


                'fac_operacion_anx.Show()
            End If

        Catch ex As Exception

        End Try

        'Select Case ComboBox1.Text
        'Case "GUIA DE INGRESO"
        ' llenar_grid_gingreso()
        ' Case "GUIA DE SALIDA"
        'llenar_grid_gsalida()

        'End Select
        'coloini()
        'ListView1.Items.Clear()
        'ListView1.Visible = False
        'dgv.Visible = True

        'DateTimePicker1.Visible = False


    End Sub
    Public Sub llenar_grid_gingreso()
        Try
            sql = "select *from GUIA_INGRESO_PRODUC WHERE GUIA_ING='" + TextBox1.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from GUIA_INGRESO_PRODUC WHERE GUIA_ING='" + TextBox1.Text + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from GUIA_INGRESO_PRODUC WHERE GUIA_ING='" + TextBox1.Text + "'"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub
    Public Sub llenar_grid_gingresop()
        Try
            sql = "select *from GUIA_INGRESO_PRODUC"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from GUIA_INGRESO_PRODUC")
            dgv.DataSource = ds
            dgv.DataMember = "select *from GUIA_INGRESO_PRODUC"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Public Sub llenar_grid_gsalida()
        Try
            sql = "select *from GUIA_SALIDA_PRODUC WHERE GUIA_SAL='" + TextBox1.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from GUIA_SALIDA_PRODUC WHERE GUIA_SAL='" + TextBox1.Text + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from GUIA_SALIDA_PRODUC WHERE GUIA_SAL='" + TextBox1.Text + "'"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Public Sub llenar_grid_gsalidap()
        Try
            sql = "select *from GUIA_SALIDA_PRODUC"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from GUIA_SALIDA_PRODUC")
            dgv.DataSource = ds
            dgv.DataMember = "select *from GUIA_SALIDA_PRODUC"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Public Sub llenar_grid_salida()
        Try
            sql = "select *from T_ALMACEN_SALIDA  WHERE SEDE='" + TextBox5.Text + "' and dni='" + TextBox7.Text + "' and f_salida='" + DateTimePicker2.Value.ToString("yyyyMMdd") + "'"
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from T_ALMACEN_SALIDA  WHERE SEDE='" + TextBox5.Text + "' and dni='" + TextBox7.Text + "' and f_salida='" + DateTimePicker2.Value.ToString("yyyyMMdd") + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from T_ALMACEN_SALIDA  WHERE SEDE='" + TextBox5.Text + "' and dni='" + TextBox7.Text + "' and f_salida='" + DateTimePicker2.Value.ToString("yyyyMMdd") + "'"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub


    Public Sub llenar_comboguia_s()
        sql = "select *from GUIA_SALIDA"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "COD"
        ComboBox3.ValueMember = "COD"
    End Sub

    Public Sub llenar_comboguias_p()
        sql = "select *from T_SEDE"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "SEDE"
        ComboBox2.ValueMember = "SEDE"
    End Sub

    Public Sub llenar_comboguia_i()
        sql = "select *from GUIA_INGRESO"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "COD"
        ComboBox2.ValueMember = "COD"
    End Sub

    Public Sub llenar_comboguia_i_p()
        sql = "select *from T_SEDE"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "SEDE"
        ComboBox1.ValueMember = "SEDE"
    End Sub

    Private Sub guardarguiaINGRESOPRODUC()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")


        'buscar_copiar()
        'codigo = "USU0000001"
        For o = 0 To ListView1.Items.Count - 1
            Dim GUIA_INGRESO As String = ListView1.Items(o).SubItems(1).Text
            Dim DET As String = ListView1.Items(o).SubItems(2).Text
            Dim COD_PRO As String = ListView1.Items(o).SubItems(3).Text
            Dim CANT As String = ListView1.Items(o).SubItems(4).Text
            Dim SEDE As String = inicio.SEDE
            ' Dim FEC As String = DateTimePicker1.Value.ToString("yyyyMMdd")
            'Dim SEDE As String = SEDE

            Try
                If accion = "guardar" Then

                    'sql = "select *from GUIA_INGRESO_PRODUC where  GUIA_ING='" + cod + "'"
                    'Form_Reg_SRV_SQL.conectar()
                    'com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    'dr = com.ExecuteReader

                    'If dr.Read Then
                    'cod = dr(0)
                    'MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'dr.Close()
                    'Form_Reg_SRV_SQL.conexion.Close()
                    'Else
                    sql = "INSERT INTO GUIA_INGRESO_PRODUC  VALUES ('" & GUIA_INGRESO & "','" & DET & "','" & CANT & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & SEDE & "','" & COD_PRO & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()
                        MessageBox.Show("Registro Guardado", "RUMISOFT")
                    '   End If


                    'buscar_copiar()


                    'fac_operacion_anx.Show()
                End If

            Catch ex As Exception

            End Try

            'Select Case ComboBox1.Text
            'Case "GUIA DE INGRESO"

            ' Case "GUIA DE SALIDA"
            'llenar_grid_gsalida()

            'End Select
            'coloini()
            'DateTimePicker1.Visible = False

        Next
        ' ListView1.Items.Clear()
        ListView1.Visible = False

        dgv.Visible = True
        llenar_grid_gingresop()

    End Sub

    Private Sub guardarguiaSALIDAPRODUC()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")


        'buscar_copiar()
        'codigo = "USU0000001"
        For o = 0 To ListView2.Items.Count - 1
            Dim GUIA_SALIDA As String = ListView2.Items(o).SubItems(1).Text
            Dim DET As String = ListView2.Items(o).SubItems(2).Text
            Dim COD_PRO As String = ListView2.Items(o).SubItems(3).Text
            Dim CANT As String = ListView2.Items(o).SubItems(4).Text
            Dim SEDE As String = inicio.SEDE
            Dim FEC As String = DateTimePicker1.Value.ToString("yyyyMMdd")
            'Dim SEDE As String = SEDE

            Try
                If accion = "guardar" Then

                    sql = "select *from GUIA_SALIDA_PRODUC where  GUIA_SAL='" + GUIA_SALIDA + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader

                    If dr.Read Then
                        'cod = dr(0)
                        MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        sql = "INSERT INTO GUIA_SALIDA_PRODUC  VALUES ('" & GUIA_SALIDA & "','" & DET & "','" & CANT & "','" & FEC & "','" & SEDE & "','" & COD_PRO & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()
                        MessageBox.Show("Registro Guardado", "RUMISOFT")
                    End If


                    'buscar_copiar()


                    'fac_operacion_anx.Show()
                End If

            Catch ex As Exception

            End Try

            'Select Case ComboBox1.Text
            'Case "GUIA DE INGRESO"
            llenar_grid_gsalidap()
            ' Case "GUIA DE SALIDA"
            'llenar_grid_gsalida()

            'End Select
            'coloini()
            ListView2.Items.Clear()
            ListView2.Visible = False
            dgv.Visible = True

            'DateTimePicker1.Visible = False

        Next


    End Sub

    Public Sub llenar_combo1()
        sql = "select *from USUARIOS"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox4.DataSource = dt
        ComboBox4.DisplayMember = "DNI"
        ComboBox4.ValueMember = "DNI"
    End Sub

    Private Sub FILTRO()
        Select Case ComboBox3.Text
            Case "GUIA DE INGRESO"
                sql = "select *FROM  GUIA_INGRESO_PRODUC where GUIA_ING like'" + TextBox3.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *FROM  GUIA_INGRESO_PRODUC where GUIA_ING  like'" + TextBox3.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select *FROM  GUIA_INGRESO_PRODUC where GUIA_ING  like'" + TextBox3.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "GUIA DE SALIDA"
                sql = "select *FROM  GUIA_SALIDA_PRODUC where GUIA_SAL like'" + TextBox3.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *FROM  GUIA_SALIDA_PRODUC where GUIA_SAL  like'" + TextBox3.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select *FROM  GUIA_SALIDA_PRODUC where GUIA_SAL  like'" + TextBox3.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()


        End Select


    End Sub

End Class