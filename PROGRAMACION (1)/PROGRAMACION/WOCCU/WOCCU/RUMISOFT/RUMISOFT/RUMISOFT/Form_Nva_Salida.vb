Public Class Form_Nva_Salida
    Public codigo, nom, ap_pa, ap_ma, dni, cargo, pase1, pase2, STOKACTUAL, NINGRESO, CODIGO_SALIDA As String

    'variables sql
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim res, o As Integer

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox3.Enabled = True
        DateTimePicker1.Enabled = True
        TextBox8.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        dgv.Visible = False
        ListView1.Visible = True



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        item()
        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "guardar"
        guardar()
        Button2.Enabled = False
        Button7.Enabled = True

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form_Reg_Sede.Show()
        Form_Reg_Sede.pase1 = "salida"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form_Reg_Usuario.Show()
        Form_Reg_Usuario.pase1 = "salida"
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim cant1, cant2, tot As Double

        Try
            cant1 = TextBox2.Text
            cant2 = TextBox3.Text
            tot = cant1 - cant2
            TextBox4.Text = tot
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cod As String = ComboBox1.Text
        TextBox1.Text = Microsoft.VisualBasic.Left(cod, 11)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        llenar_grid()
        dgv.Visible = True
        ListView1.Visible = False
        b_salida()

    End Sub
    'variables locales
    Dim preg, sql, accion, SEDE, MICARGO As String

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        form_ingreso_salida.item2()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Dim a As Integer

    Public cod As Double
    Private Sub Form_Nva_Salida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        TextBox1.Text = Form_control_alamacen.C_INGRESO
        TextBox2.Text = Form_control_alamacen.cant
        TextBox5.Text = inicio.SEDE
        llenar_combo3()
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
            linea.SubItems.Add(UCase(TextBox7.Text))
            linea.SubItems.Add(UCase(TextBox6.Text))
            'linea.SubItems.Add(UCase(TextBox7.Text))
            linea.SubItems.Add(UCase(TextBox8.Text))
            ListView1.Items.Add(linea)
            MessageBox.Show("Datos Agregados", "RUMISOFT")

        Else

            MessageBox.Show("No hay que registrar", "ROMISOFT")
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
            Dim COD_ALAMCEN As String = ListView1.Items(o).SubItems(1).Text
            Dim STOK As String = ListView1.Items(o).SubItems(2).Text
            Dim N_SAL As String = ListView1.Items(o).SubItems(3).Text
            Dim STOK_ACTUAL As String = ListView1.Items(o).SubItems(4).Text
            Dim sed_dest As String = ListView1.Items(o).SubItems(8).Text
            Dim usuario As String = ListView1.Items(o).SubItems(7).Text
            Dim coment As String = ListView1.Items(0).SubItems(9).Text
            'Dim SEDE As String = SEDE

            Try
                If accion = "guardar" Then

                    sql = "select *from T_ALMACEN_SALIDA where  COD='" + TextBox1.Text + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader

                    If dr.Read Then
                        'cod = dr(0)
                        MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        sql = "INSERT INTO T_ALMACEN_SALIDA  VALUES ('" & codigo & "','" & COD_ALAMCEN & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & Form_principal.Label6.Text & "','" & STOK & "','" & N_SAL & "','" & STOK_ACTUAL & "','" & Form_principal.Label9.Text & "','" & sed_dest & "','" & usuario & "','" & coment & "','" & Form_principal.Label5.Text & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()
                        MessageBox.Show("Registro Guardado", "RUMISOFT")
                        buscar_ultimo_ingreso()
                        Form_Colada.TextBox6.Text = CODIGO_SALIDA
                        Form_Colada.TextBox5.Text = TextBox1.Text
                        Form_Colada.ShowDialog()
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
        act_almacen()
        'Me.Close()
        'Label3.Visible = False
        'Label4.Visible = False
        'TextBox2.Visible = False
        'TextBox3.Visible = False
        'TextBox4.Visible = False
        'TextBox2.Text = ""
        'TextBox3.Text = ""
        'TextBox4.Text = ""
        'DateTimePicker1.Visible = False

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
            MessageBox.Show("Registro de Almacen " & inicio.SEDE & " actualizado", "RUMISOFT")

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
        'sql = "Select *from T_ALMACEN_SALIDA where CP_ALMACEN='" + TextBox1.Text + "' AND F_SALIDA='" + DateTimePicker1.Value.ToString("yyyyMMdd") + "' and SEDE='" + inicio.SEDE + "'"
        sql = "Select *from T_ALMACEN_SALIDA where id in (select max(id) from T_ALMACEN_SALIDA) and sede='" & inicio.SEDE & "' AND CP_ALMACEN='" + TextBox1.Text + "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            STOKACTUAL = dr(7)
            NINGRESO = dr(6)
            CODIGO_SALIDA = dr(0)
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
    End Sub
    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "SAL"
        'Dim cod, serie As String
        sql = "select *from T_ALMACEN_SALIDA where id in (select max(id) from T_ALMACEN_SALIDA)"
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

    Private Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],CP_ALMACEN AS [CODIGO ALMACEN], STOK, N_SAL AS [NUEVO INGRESO] , STOK_ACTUAL AS [STOK ACTUAL], F_SALIDA AS [FECHA DE SALIDA], SEDE from T_ALMACEN_SALIDA WHERE CP_ALMACEN='" + TextBox1.Text + "' and SEDE='" + inicio.SEDE + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_ALMACEN_SALIDA")
            dgv.DataSource = ds
            dgv.DataMember = "T_ALMACEN_SALIDA"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Public Sub llenar_combo3()
        Try
            'sql = "select *from T_ALMACEN"
            sql = "select COD,COD  +' ' + NOM_PRODUC AS COL FROM T_ALMACEN where sede='" + inicio.SEDE + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            dt = New DataTable
            da.Fill(dt)
            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "COL"
            ComboBox1.ValueMember = "COD"
        Catch ex As Exception

        End Try

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
                Label11.Text = dr(3)
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

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Try
            Select Case pase1
                Case "salida"
                    form_ingreso_salida.item2()
                    'Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    'sql = "select *from T_ALMACEN_SALIDA where  cod='" + selec + "'"
                    'Form_Reg_SRV_SQL.conectar()
                    'com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    'dr = com.ExecuteReader
                    'If dr.Read Then
                    'Form_Reg_Cent_Costo.TextBox3.Text = dr(4)
                    'Form_Reg_Cent_Costo.cod_sede = dr(0)
                    'preg = MsgBox("Desea agregar", vbYesNo)
                    'a += 1
                    'Dim linea As New ListViewItem(a)

                    'If preg = vbYes Then
                    'linea.SubItems.Add(UCase(TextBox1.Text))
                    'linea.SubItems.Add(UCase(form_ingreso_salida.TextBox1.Text))
                    'linea.SubItems.Add(UCase(Label11.Text))
                    'linea.SubItems.Add(UCase(TextBox1.Text))
                    'linea.SubItems.Add(UCase(dr(6)))
                    'linea.SubItems.Add(UCase(DateTimePicker1.Value))
                    'form_ingreso_salida.ListView1.Items.Add(linea)
                    'MessageBox.Show("Datos Agregados", "RUMISOFT")

                    'Else

                    'MessageBox.Show("No hay que registrar", "ROMISOFT")
                    ''Button4.Enabled = True
                    'Button6.Enabled = False
                    'End If


                    'End If
                    'dr.Close()
                    'Form_Reg_SRV_SQL.conexion.Close()
                    'Me.Close()
                    'Case "salida"
                    'Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    ' sql = "select *from USUARIOS where  cod='" + selec + "'"
                    'Form_Reg_SRV_SQL.conectar()
                    'com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    ' dr = com.ExecuteReader
                    ' If dr.Read Then
                    'Form_Nva_Salida.TextBox7.Text = dr(3)
                    'form_ingreso_salida.TextBox7.Text = dr(3)
                    'End If
                    ' dr.Close()
                    'Form_Reg_SRV_SQL.conexion.Close()
                    'Me.Close()

                    ' Case "ingreso"
                    ' Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    'sql = "select *from USUARIOS where  cod='" + selec + "'"
                    'Form_Reg_SRV_SQL.conectar()
                    'com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    ' dr = com.ExecuteReader
                    'If dr.Read Then
                    'Form_Reg_Cent_Costo.TextBox3.Text = dr(4)
                    'Form_Reg_Cent_Costo.cod_sede = dr(0)
                    'End If
                    ' dr.Close()
                    'Form_Reg_SRV_SQL.conexion.Close()
                    'Me.Close()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class