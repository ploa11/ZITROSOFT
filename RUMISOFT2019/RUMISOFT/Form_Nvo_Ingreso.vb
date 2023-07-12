Public Class Form_Nvo_Ingreso
    Public codigo, nom, ap_pa, ap_ma, dni, cargo, pase1, pase2, STOKACTUAL, COD_INGRESO, cod_almacen, NCANTIDAD As String
    Public CONT As Integer
    'variables sql
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim res, o As Integer

    Private Sub Form_Nvo_Ingreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = Form_control_alamacen.C_INGRESO
        TextBox2.Text = Form_control_alamacen.cant
        TextBox5.Text = inicio.SEDE
        Label12.Text = Form_control_alamacen.detalle_prod
        llenar_combo1()
        llenar_combo2()
        llenar_combo3()
        ListView1.Visible = False
        dgv.Visible = True
        llenar_grid()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim cant1, cant2, tot As Double

        Try
            cant1 = TextBox2.Text
            cant2 = TextBox3.Text
            tot = cant1 + cant2
            TextBox4.Text = tot
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "guardar"
        guardar()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dgv.Visible = False
        ListView1.Visible = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        TextBox6.Enabled = True
        TextBox3.Enabled = True
        TextBox7.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form_Tipo_Operacion.ShowDialog()
        Form_Tipo_Operacion.pase1 = "1"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'Form_control_alamacen.Show()
        llenar_grid()
        b_salida()
        'Form_control_alamacen.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Public cod As Double

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Form_Busca_Empresa.pase1 = "proveedor"
        'Form_Busca_Empresa.ComboBox2.Text = ""
        'Form_Busca_Empresa.llenar_grid()
        'Form_Busca_Empresa.ShowDialog()
        Form_Reg_Prov_Clie.Show()
        Form_Reg_Prov_Clie.pase1 = "ingreso"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form_Tipo_Operacion.ShowDialog()
        Form_Tipo_Operacion.pase1 = "1"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    'variables locales
    Dim preg, sql, accion, SEDE, MICARGO As String

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        form_ingreso_salida.item()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim cod As String = ComboBox4.Text
        TextBox1.Text = Microsoft.VisualBasic.Left(cod, 11)
    End Sub

    Dim a As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        item()
    End Sub
    Private Sub item()
        preg = MsgBox("Desea agregar Cantidad de Productos", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            'linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(TextBox2.Text))
            linea.SubItems.Add(UCase(TextBox3.Text))
            linea.SubItems.Add(UCase(TextBox4.Text))
            linea.SubItems.Add(UCase(DateTimePicker1.Value))
            linea.SubItems.Add(UCase(TextBox5.Text))
            'linea.SubItems.Add(UCase(TextBox6.Text))
            linea.SubItems.Add(UCase(ComboBox1.Text))
            linea.SubItems.Add(UCase(ComboBox2.Text))
            linea.SubItems.Add(UCase(TextBox6.Text))
            linea.SubItems.Add(UCase(TextBox7.Text))
            ListView1.Items.Add(linea)
            MessageBox.Show("Datos Agregados", "ZITRO")
            Button2.Enabled = True
            Button1.Enabled = False
        Else

            ' MessageBox.Show("No hay que registrar", "ZITRO")

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
            Dim COD_ALAMCEN As String = ListView1.Items(o).SubItems(1).Text
            Dim STOK As String = ListView1.Items(o).SubItems(2).Text
            Dim N_IG As String = ListView1.Items(o).SubItems(3).Text
            Dim STOK_ACTUAL As String = ListView1.Items(o).SubItems(4).Text
            Dim tip_ope As String = ListView1.Items(0).SubItems(7).Text
            Dim com_pago As String = ListView1.Items(o).SubItems(8).Text
            Dim n_doc As String = ListView1.Items(o).SubItems(9).Text
            Dim proveedor As String = ListView1.Items(o).SubItems(10).Text


            'Dim SEDE As String = SEDE

            Try
                If accion = "guardar" Then

                    sql = "select *from T_ALMACEN_INGRESO where cod='" + TextBox1.Text + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader

                    If dr.Read Then
                        'cod = dr(0)
                        MessageBox.Show("Los Datos ya Existen", "ZITRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        sql = "INSERT INTO T_ALMACEN_INGRESO  VALUES ('" & codigo & "','" & COD_ALAMCEN & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & inicio.DNI & "','" & STOK & "','" & N_IG & "','" & STOK_ACTUAL & "','" & inicio.SEDE & "','" & tip_ope & "','" & com_pago & "','" & n_doc & "','" & proveedor & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        Res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()
                        MessageBox.Show("Registro Guardado", "ZITRO")
                    End If


                    'buscar_copiar()


                    'fac_operacion_anx.Show()
                End If

            Catch ex As Exception

            End Try
        Next
        llenar_grid()
        ListView1.Items.Clear()
        ListView1.Visible = False
        dgv.Visible = True
        dgv.Enabled = True
        act_almacen()
        buscar_ultimo_ingreso_COLADA()
        'Label3.Visible = False
        'Label4.Visible = False
        'TextBox2.Visible = False
        'TextBox3.Visible = False
        'TextBox4.Visible = False
        'TextBox2.Text = ""
        'TextBox3.Text = ""
        'TextBox4.Text = ""
        'DateTimePicker1.Visible = False
        If ComboBox3.Text = "LOTE" Or ComboBox3.Text = "SERIE" Or ComboBox3.Text = "OTROS" Then
            CONT = TextBox3.Text
            Form_Colada.TextBox1.Text = TextBox1.Text
            Form_Colada.TextBox2.Text = COD_INGRESO
            Form_Colada.ShowDialog()
        End If
        TextBox6.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox7.Text = ""
        'Me.Close()
        'Me.Dispose()

    End Sub

    Private Sub act_almacen()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")
        buscar_ultimo_ingreso()
        'Dim SEDE As String = SEDE

        Try
            sql = "UPDATE T_ALMACEN SET CANT='" + STOKACTUAL + "' WHERE COD='" + TextBox1.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            res = com.ExecuteNonQuery
            Form_Reg_SRV_SQL.conexion.Close()
            MessageBox.Show("Registro de Almacen " & inicio.SEDE & " actualizado", "ZITRO")

        Catch ex As Exception

            End Try

        'Label3.Visible = False
        'Label4.Visible = False
        'TextBox2.Visible = False
        'TextBox3.Visible = False
        'TextBox4.Visible = False
        'TextBox2.Text = ""
        'TextBox3.Text = ""
        'TextBox4.Text = ""
        'DateTimePicker1.Visible = False
        Form_control_alamacen.llenar_grid()
        Form_control_alamacen.coloini()

    End Sub
    Private Sub buscar_ultimo_ingreso()
        'Dim aum_cod As String
        ' Dim dat As String = "RQ"
        'Dim cod, serie As String
        sql = "Select *from T_ALMACEN_INGRESO where id in (select max(id) from T_ALMACEN_INGRESO) and sede='" & inicio.SEDE & "' AND CP_ALMACEN='" + TextBox1.Text + "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            STOKACTUAL = dr(7)
            NCANTIDAD = dr(6)
            'TextBox1.Text = dr(0)
            'dtp1.Value = dr(1)
            'cb1.Text = dr(2)
            't1.Text = dr(4)
            't2.Text = dr(7)
            't4.Text = dr(8)
            't5.Text = dr(9)
        Else
            MessageBox.Show("ERROR EN MOSTRAR DATOS", "ZITRO")
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
    End Sub
    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "ING"
        'Dim cod, serie As String
        sql = "select *from T_ALMACEN_INGRESO where id in (select max(id) from T_ALMACEN_INGRESO)"
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
            MessageBox.Show("Se generara Codigo", "ZITRO")
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
    Private Sub buscar_ultimo_ingreso_COLADA()
        'Dim aum_cod As String
        ' Dim dat As String = "RQ"
        'Dim cod, serie As String
        sql = "Select *from T_ALMACEN_INGRESO where id in (select max(id) from T_ALMACEN_INGRESO)"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            COD_INGRESO = dr(0)
            'TextBox1.Text = dr(0)
            'dtp1.Value = dr(1)
            'cb1.Text = dr(2)
            't1.Text = dr(4)
            't2.Text = dr(7)
            't4.Text = dr(8)
            't5.Text = dr(9)
        Else
            MessageBox.Show("Error EN MOSTRAR DATOS", "ZITRO")
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
    End Sub

    Private Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],CP_ALMACEN AS [CODIGO ALMACEN], STOK, N_ING AS [NUEVO INGRESO] , STOK_ACTUAL AS [STOK ACTUAL], F_INGRESO AS [FECHA DE INGRESO], SEDE from T_ALMACEN_INGRESO WHERE CP_ALMACEN='" + TextBox1.Text + "' and SEDE='" + inicio.SEDE + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_ALMACEN_INGRESO")
            dgv.DataSource = ds
            dgv.DataMember = "T_ALMACEN_INGRESO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Public Sub llenar_combo1()
        sql = "select *from T_TIPO_OPERACION"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "DESCRIP"
        ComboBox1.ValueMember = "DESCRIP"
    End Sub
    Public Sub llenar_combo2()
        sql = "select *from T_COMP_PAG"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "DESCRIP"
        ComboBox2.ValueMember = "DESCRIP"
    End Sub


    Public Sub llenar_combo3()
        'sql = "select *from T_ALMACEN"
        sql = "select COD,COD  +' ' + NOM_PRODUC AS COL FROM T_ALMACEN where sede='" + inicio.SEDE + "'"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox4.DataSource = dt
        ComboBox4.DisplayMember = "COL"
        ComboBox4.ValueMember = "COD"
    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        ultimo_ingreso()
        nom_produc()
        Me.Close()
    End Sub
    Private Sub b_salida()
        Try
            sql = "select *from T_ALMACEN where COD='" + TextBox1.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                'C_INGRESO = dr(0)
                TextBox2.Text = dr(8)
                Label12.Text = dr(3)
                'dtp1.Value = dr(1)
                'cb1.Text = dr(2)
                't1.Text = dr(4)
                't2.Text = dr(7)
                't4.Text = dr(8)
                't5.Text = dr(9)
            Else
                MessageBox.Show("Error en la busqueda", "RUMISOFT")
            End If
            dr.Close()
            Form_Reg_SRV_SQL.conexion.Close()
            'form_ingreso_salida.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ultimo_ingreso()
        Try
            Button3.Enabled = True
            Button4.Enabled = True

            Dim COD As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
            'NUEVO_REGISTRO()
            sql = "select *from T_ALMACEN_INGRESO where COD='" + COD + "'"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                form_ingreso_salida.TextBox3.Text = dr(1)
                form_ingreso_salida.TextBox4.Text = dr(6)
                form_ingreso_salida.TextBox2.Text = Label12.Text
                cod_almacen = dr(1)

                'detalle_prod = dr(3)
                'dtp1.Value = dr(1)
                'cb1.Text = dr(2)
                't1.Text = dr(4)
                't2.Text = dr(7)
                't4.Text = dr(8)
                't5.Text = dr(9)
            Else
                MessageBox.Show("Error en la busqueda", "ZITRO")
            End If
            dr.Close()
            Form_Reg_SRV_SQL.conexion.Close()
            'form_ingreso_salida.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub nom_produc()
        Try
            Button3.Enabled = True
            Button4.Enabled = True

            ' Dim COD As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
            'NUEVO_REGISTRO()
            sql = "select *from T_ALMACEN where COD='" + cod_almacen + "'"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                form_ingreso_salida.TextBox2.Text = dr(3)
                'detalle_prod = dr(3)
                'dtp1.Value = dr(1)
                'cb1.Text = dr(2)
                't1.Text = dr(4)
                't2.Text = dr(7)
                't4.Text = dr(8)
                't5.Text = dr(9)
            Else
                MessageBox.Show("Error en la busqueda", "ZITRO")
            End If
            dr.Close()
            Form_Reg_SRV_SQL.conexion.Close()
            'form_ingreso_salida.Show()
        Catch ex As Exception

        End Try
    End Sub
End Class