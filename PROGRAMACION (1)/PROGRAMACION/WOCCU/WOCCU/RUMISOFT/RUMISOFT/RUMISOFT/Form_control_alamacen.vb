Public Class Form_control_alamacen
    Public codigo, nom, ap_pa, ap_ma, dni, cargo, pase1, pase2, C_INGRESO, cant, t_colada, detalle_prod As String
    Public cod As Double

    'variables locales
    Dim preg, sql, accion, SEDE, MICARGO As String
    Dim a As Integer
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        dgv.Visible = False
        ListView1.Visible = True
        Button8.Visible = True
        TextBox2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label7.Visible = True
        Label8.Visible = True
        Label11.Visible = True
        Label12.Visible = True
        TextBox3.Visible = True
        TextBox4.Visible = True
        TextBox5.Visible = True
        TextBox6.Visible = True
        TextBox7.Visible = True
        TextBox8.Visible = True
        TextBox9.Visible = True
        Button9.Visible = True
        Button9.Enabled = True
        ComboBox3.Visible = True
        ComboBox3.Enabled = True
        DateTimePicker1.Visible = True
        Label9.Visible = True
        Label10.Visible = True
        TextBox1.Visible = False
        ComboBox1.Visible = False
        Label2.Visible = False
        TextBox9.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form_List_Product.pase1 = "al"
        Form_List_Product.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        item()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NUEVO_REGISTRO()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        mostrar()
        coloini()
    End Sub
    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form_Nvo_Ingreso.Show()
        Form_Nvo_Ingreso.Button3.Enabled = False

        'Form_Nvo_Ingreso.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        accion = "guardar"
        guardar()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        FILTRO()
        coloini()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        'Try
        'Button3.Enabled = True
        'Button4.Enabled = True

        'Dim COD As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        ' 'NUEVO_REGISTRO()
        'sql = "select *from T_ALMACEN where COD='" + COD + "'"
        ' Form_Reg_SRV_SQL.conectar()
        ' com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        'dr = com.ExecuteReader
        'If dr.Read Then
        'C_INGRESO = dr(0)
        'cant = dr(8)
        'detalle_prod = dr(3)
        'dtp1.Value = dr(1)
        'cb1.Text = dr(2)
        't1.Text = dr(4)
        't2.Text = dr(7)
        't4.Text = dr(8)
        't5.Text = dr(9)
        ' Else
        'MessageBox.Show("Error en la busqueda", "RUMISOFT")
        'End If
        'dr.Close()
        ' Form_Reg_SRV_SQL.conexion.Close()
        'form_ingreso_salida.Show()
        'Catch ex As Exception

        ' End Try
    End Sub

    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        form_ingreso_salida.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        dgv.Visible = True
        ListView1.Visible = False
        Button8.Visible = False
        TextBox2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        TextBox6.Visible = False
        TextBox7.Visible = False
        TextBox8.Visible = False
        TextBox9.Visible = False
        Button9.Visible = False
        Button9.Enabled = False
        ComboBox3.Visible = False
        ComboBox3.Enabled = False
        DateTimePicker1.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        TextBox1.Visible = False
        ComboBox1.Visible = False
        Label2.Visible = True
        TextBox9.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form_Nva_Salida.Show()
        Form_Nva_Salida.Button3.Enabled = False
        'Form_Nva_Salida.ShowDialog()
    End Sub

    Dim ds As DataSet
    Dim dt As DataTable
    Dim res, o As Integer
    Private Sub Form_control_alamacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        llenar_combo1()
        SEDE = inicio.SEDE
        MICARGO = inicio.CARGO
        cargo = "ALMACEN"
        llenar_grid()
        coloini()
        TextBox8.Text = 0
    End Sub
    Public Sub llenar_combo1()
        Sql = "select *from T_SEDE"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(Sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "SEDE"
        ComboBox1.ValueMember = "SEDE"
    End Sub

    Private Sub mostrar()
        Try
            If ComboBox1.Text = SEDE Then
                Label2.Visible = True
                dgv.Visible = True
                TextBox1.Visible = True
                Button2.Visible = True
                ComboBox2.Visible = True
                MessageBox.Show("USTED ESTA AUTORIZADO PARA EL ALMACEN " & ComboBox1.Text & "", "RUMISOFT")
            Else
                MessageBox.Show("USTED NO ESTA AUTORIZADO PARA EL ALMACEN " & ComboBox1.Text & "", "RUMISOFT")
                Label2.Visible = False
                dgv.Visible = False
                TextBox1.Visible = False
                Button2.Visible = False
                ComboBox2.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub item()
        preg = MsgBox("Desea agregar datos de Productos", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            'linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(TextBox2.Text))
            linea.SubItems.Add(UCase(TextBox3.Text))
            linea.SubItems.Add(UCase(TextBox4.Text))
            linea.SubItems.Add(UCase(TextBox5.Text))
            linea.SubItems.Add(UCase(TextBox6.Text))
            linea.SubItems.Add(UCase(TextBox7.Text))
            linea.SubItems.Add(UCase(TextBox8.Text))
            linea.SubItems.Add(UCase(TextBox9.Text))
            linea.SubItems.Add(UCase(ComboBox3.Text))
            ListView1.Items.Add(linea)
            MessageBox.Show("Datos Agregados", "RUMISOFT")

        Else

            MessageBox.Show("No hay que registrar", "RUMISOFT")
            'Button4.Enabled = True
            'Button6.Enabled = False
        End If


    End Sub

    Private Sub guardar()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")

        For o = 0 To ListView1.Items.Count - 1
            buscar_copiar()
            'codigo = "USU0000001"
            Dim NOM_P As String = ListView1.Items(o).SubItems(1).Text
            Dim UNI As String = ListView1.Items(o).SubItems(2).Text
            Dim MED As String = ListView1.Items(o).SubItems(3).Text
            Dim MARC As String = ListView1.Items(o).SubItems(4).Text
            'Dim FEC As Date = ListView1.Items(0).SubItems(5).Text
            Dim COLOR As String = ListView1.Items(o).SubItems(5).Text
            Dim COD_LP As String = ListView1.Items(o).SubItems(6).Text
            Dim CANT As Integer = ListView1.Items(o).SubItems(7).Text
            Dim T_EXIST As String = ListView1.Items(o).SubItems(8).Text
            Dim t_colada As String = ListView1.Items(o).SubItems(9).Text
            'Dim SEDE As String = SEDE

            Try
                If accion = "guardar" Then

                    sql = "select *from T_ALMACEN where  cod_lp='" + COD_LP + "' and sede ='" + SEDE + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader

                    If dr.Read Then
                        'cod = dr(0)
                        MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        sql = "INSERT INTO T_ALMACEN  VALUES ('" & codigo & "','" & SEDE & "','DNI','" & NOM_P & "','" & UNI & "','" & MED & "','" & MARC & "','" & COLOR & "','" & CANT & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & COD_LP & "','" & T_EXIST & "','" & t_colada & "')"
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
        Next
        llenar_grid()
        coloini()
        ListView1.Items.Clear()
        ListView1.Visible = False
        dgv.Visible = True
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        ComboBox3.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        TextBox6.Visible = False
        TextBox7.Visible = False
        TextBox8.Visible = False
        TextBox9.Visible = False
        Button8.Visible = False
        Button9.Visible = False
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        DateTimePicker1.Visible = False
        Label2.Visible = True
        ComboBox2.Visible = True
        TextBox1.Visible = True


    End Sub

    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "ALM"
        'Dim cod, serie As String
        sql = "select *from T_ALMACEN where id in (select max(id) from T_ALMACEN)"
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

    Public Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],SEDE, NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , MEDID AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR], CANT AS [CANTIDAD] from T_ALMACEN WHERE SEDE='" + SEDE + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select COD AS [CODIGO],SEDE, NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , MEDID AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR], CANT AS [CANTIDAD] from T_ALMACEN WHERE SEDE='" + SEDE + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select COD AS [CODIGO],SEDE, NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , MEDID AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR], CANT AS [CANTIDAD] from T_ALMACEN WHERE SEDE='" + SEDE + "'"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Private Sub FILTRO()
        Select Case ComboBox2.Text
            Case "CODIGO"
                sql = "select COD AS [CODIGO],SEDE, NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , MEDID AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR], CANT AS [CANTIDAD] from T_ALMACEN WHERE  COD like'" + TextBox1.Text + "%' and sede='" + inicio.SEDE + "'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO],SEDE, NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , MEDID AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR], CANT AS [CANTIDAD] from T_ALMACEN WHERE COD like'" + TextBox1.Text + "%'and sede='" + inicio.SEDE + "'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO],SEDE, NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , MEDID AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR], CANT AS [CANTIDAD] from T_ALMACEN WHERE COD like'" + TextBox1.Text + "%'and sede='" + inicio.SEDE + "'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "NOMBRE"
                sql = "select COD AS [CODIGO],SEDE, NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , MEDID AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR], CANT AS [CANTIDAD] from T_ALMACEN WHERE  NOM_PRODUC like'" + TextBox1.Text + "%'and sede='" + inicio.SEDE + "'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO],SEDE, NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , MEDID AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR], CANT AS [CANTIDAD] from T_ALMACEN WHERE  NOM_PRODUC like'" + TextBox1.Text + "%'and sede='" + inicio.SEDE + "'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO],SEDE, NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , MEDID AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR], CANT AS [CANTIDAD] from T_ALMACEN WHERE  NOM_PRODUC like'" + TextBox1.Text + "%'and sede='" + inicio.SEDE + "'"
                Form_Reg_SRV_SQL.conexion.Close()

        End Select


    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        'Dim COD As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        ' NUEVO_REGISTRO()
        ' sql = "select *from T_ALMACEN where COD='" + COD + "'"
        ' Form_Reg_SRV_SQL.conectar()
        ' com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        ' dr = com.ExecuteReader
        'If dr.Read Then
        'C_INGRESO = dr(0)
        'cant = dr(8)
        't_colada = dr(13)
        'dtp1.Value = dr(1)
        'cb1.Text = dr(2)
        't1.Text = dr(4)
        't2.Text = dr(7)
        't4.Text = dr(8)
        't5.Text = dr(9)
        'Else
        'MessageBox.Show("Error en la busqueda", "RUMISOFT")
        'End If
        ' dr.Close()
        ' Form_Reg_SRV_SQL.conexion.Close()
        'form_ingreso_salida.Show()
        Try
            Select Case pase1
                Case "rq"
                    Dim COD As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_ALMACEN where COD='" + COD + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Reg_RQ.TextBox2.Text = dr(3)
                        Form_Reg_RQ.TextBox4.Text = dr(4)
                        Form_Reg_RQ.TextBox12.Text = dr(5)
                        Form_Reg_RQ.TextBox13.Text = dr(6)
                        Form_Reg_RQ.TextBox14.Text = dr(7)
                        Form_Reg_RQ.TextBox10.Text = dr(8)

                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
                    Me.Dispose()

                Case "al"
                    Dim almacen As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_LIST_PRODUCTOS where  cod='" + almacen + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        'Form_control_alamacen.TextBox2.Text = dr(1)
                        ' Form_control_alamacen.TextBox3.Text = dr(2)
                        ' Form_control_alamacen.TextBox4.Text = dr(3)
                        '' Form_control_alamacen.TextBox5.Text = dr(4)
                        ' Form_control_alamacen.TextBox6.Text = dr(5)
                        ' Form_control_alamacen.TextBox7.Text = dr(0)
                        'Form_control_alamacen.TextBox9.Text = dr(12)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
                    Me.Dispose()
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub NUEVO_REGISTRO()
        Try
            If cargo = MICARGO Then
                MessageBox.Show("USTED ESTA AUTORIZADO PARA INGRESO Y ACTUALIZACIONES EN EL ALAMCEN DE " & ComboBox1.Text & "", "RUMISOFT")
                Button3.Visible = True
                Button4.Visible = True
                Button5.Visible = True
                Button6.Visible = True
                Button3.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
            Else
                MessageBox.Show("USTED NO ESTA AUTORIZADO PARA INGRESO Y ACTUALIZACIONES EN ESTE ALMACEN " & ComboBox1.Text & "", "RUMISOFT")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub coloini()

        For Each Row As DataGridViewRow In dgv.Rows
            Select Case Row.Cells("CANTIDAD").Value
                Case <= 10
                    Row.DefaultCellStyle.BackColor = Color.Red
                    Row.DefaultCellStyle.ForeColor = Color.White


                Case >= 50
                    Row.DefaultCellStyle.BackColor = Color.Blue
                    Row.DefaultCellStyle.ForeColor = Color.White

            End Select


            'If Today = Row.Cells("FECHA INICIO DE PRESTAMO").Value Then
            'Row.DefaultCellStyle.BackColor = Color.Blue
            'Row.DefaultCellStyle.ForeColor = Color.White
            'End If


        Next

    End Sub
End Class