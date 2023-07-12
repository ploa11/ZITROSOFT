Public Class Form_Colada
    Public codigo, nom, ap_pa, ap_ma, dni, cargo, pase1, pase2, STOKACTUAL, com_ser_lot As String

    'variables sql
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Public cod As Double
    Dim preg, sql, accion, SEDE, MICARGO As String

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        FILTRO()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim cod1 As String
        ' Dim nfila, ncolu As Integer
        'detalle = ""
        'nfila = dgv.CurrentCell.RowIndex
        'ncolu = dgv.CurrentCell.ColumnIndex
        Try
            cod1 = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
            sql = "select *from T_COLADA WHERE SER_LOTE='" + cod1 + "'"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox2.Text = dr(5)
                TextBox3.Text = dr(2)
                TextBox4.Text = dr(3)
                ComboBox1.Text = dr(6)
            Else
                MessageBox.Show("Los Datos no Existen")
            End If
            dr.Close()
            Form_Reg_SRV_SQL.conexion.Close()
            'Button6.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error al filtrar datos")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        ComboBox1.Enabled = True
        guardar()
    End Sub

    Private Sub Form_Colada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlBox = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "guardar"
        guardar()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        item()
        'If ListView1.SelectedItems(a).SubItems(4).Text = com_ser_lot Then
        'MessageBox.Show("La Serie o Lote ya esta ingresado", "PROSERTEC")
        'End If
    End Sub

    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim res, o As Integer
    Dim a As Integer
    'Dim preg, sql, accion, SEDE, MICARGO As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListView1.Visible = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True

    End Sub

    Private Sub item()
        preg = MsgBox("Desea agregar Cantidad de Productos", vbYesNo)

        a += 1
        If a <= Form_Nvo_Ingreso.CONT Then

            Dim linea As New ListViewItem(a)
            com_ser_lot = TextBox3.Text

            If preg = vbYes Then
                    'linea.SubItems.Add(UCase(TextBox1.Text))
                    linea.SubItems.Add(UCase(TextBox1.Text))
                    linea.SubItems.Add(UCase(TextBox2.Text))
                    linea.SubItems.Add(UCase(TextBox3.Text))
                    linea.SubItems.Add(UCase(TextBox4.Text))
                    linea.SubItems.Add(UCase(ComboBox1.Text))
                    ListView1.Items.Add(linea)
                MessageBox.Show("Datos Agregados", "PROSERTEC")
                'Button2.Enabled = True
            Else

                    MessageBox.Show("No hay que registrar", "PROSERTEC")
                    'Button2.Enabled = True
                    'Button6.Enabled = False
                End If
            Else
                MessageBox.Show("La Cantidad Agregada es la requerida", "PROSERTEC")
            Button4.Enabled = True
            'Button6.Enabled = False

        End If
        ' If ListView1.SelectedItems(a).SubItems(4).Text = com_ser_lot Then
        'MessageBox.Show("La Serie o Lote ya esta ingresado", "PROSERTEC")
        ' End If


    End Sub

    Private Sub guardar()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")

        For o = 0 To ListView1.Items.Count - 1
            'buscar_copiar()
            'codigo = "USU0000001"
            Dim COD_PRO As String = ListView1.Items(o).SubItems(1).Text
            Dim COD_INGR As String = ListView1.Items(o).SubItems(2).Text
            Dim SER_LOT As String = ListView1.Items(o).SubItems(3).Text
            Dim COD_CERT As String = ListView1.Items(o).SubItems(4).Text
            Dim ESTA As String = ListView1.Items(o).SubItems(5).Text
            Dim tip_colada As String = Form_Nvo_Ingreso.ComboBox3.Text
            'Dim com_pago As String = ListView1.Items(o).SubItems(8).Text
            'Dim n_doc As String = ListView1.Items(o).SubItems(9).Text
            ' Dim proveedor As String = ListView1.Items(o).SubItems(10).Text


            'Dim SEDE As String = SEDE

            Try
                If accion = "guardar" Then

                    sql = "select *from T_COLADA where ID= 0 "
                    Form_reg_srv_sql.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
                    dr = com.ExecuteReader

                    If dr.Read Then
                        'cod = dr(0)
                        MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_reg_srv_sql.conexion.Close()
                    Else
                        sql = "INSERT INTO T_COLADA  VALUES ('" & COD_PRO & "','" & SER_LOT & "','" & COD_CERT & "','" & tip_colada & "','" & COD_INGR & "','" & ESTA & "','" & COD_INGR & "','" & inicio.SEDE & "' )"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
                        res = com.ExecuteNonQuery
                        Form_reg_srv_sql.conexion.Close()

                    End If
                    'buscar_copiar()
                    'fac_operacion_anx.Show()

                ElseIf accion = "editar" Then
                    sql = "UPDATE T_COLADA SET COD_SALIDA='" + TextBox6.Text + "', ESTADO='" + ComboBox1.Text + "' WHERE SER_LOTE='" + TextBox3.Text + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    res = com.ExecuteNonQuery
                    Form_Reg_SRV_SQL.conexion.Close()
                    MessageBox.Show("Registro Modificado", "RUMI")

                End If

            Catch ex As Exception
            End Try

        Next

        llenar_grid()
        ListView1.Items.Clear()
        ListView1.Visible = False
        dgv.Visible = True
        'act_almacen()
        'buscar_ultimo_ingreso_COLADA()
        'Label3.Visible = False
        'Label4.Visible = False
        'TextBox2.Visible = False
        'TextBox3.Visible = False
        'TextBox4.Visible = False
        'DateTimePicker1.Visible = False
        ' If ComboBox3.Text = "LOTE" Or ComboBox3.Text = "SERIE" Then
        'CONT = TextBox3.Text
        'Form_Colada.TextBox1.Text = TextBox1.Text
        'Form_Colada.TextBox2.Text = COD_INGRESO
        'Form_Colada.ShowDialog()
        ' End If
        ' TextBox6.Text = ""
        'TextBox3.Text = ""
        'TextBox4.Text = ""
        'TextBox7.Text = ""
        MessageBox.Show("Registro Guardado", "RUMISOFT")
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "ING"
        'Dim cod, serie As String
        sql = "select *from T_COLADA where id in (select max(id) from T_COLADA)"
        Form_reg_srv_sql.conectar()
        com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
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
            MessageBox.Show("Se generara Codigo", "PROSERTEC")
        End If
        dr.Close()
        Form_reg_srv_sql.conexion.Close()
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
            sql = "select * from T_ALMACEN_INGRESO WHERE CP_ALMACEN='" + TextBox1.Text + "' and SEDE='LIMA'"
            Form_reg_srv_sql.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_reg_srv_sql.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_ALMACEN_INGRESO")
            dgv.DataSource = ds
            dgv.DataMember = "T_ALMACEN_INGRESO"
            Form_reg_srv_sql.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "PROSERTEC")
        End Try

    End Sub

    Private Sub FILTRO()

        sql = "select *FROM  T_COLADA where SER_LOTE like'" + TextBox5.Text + "%'"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *FROM  T_COLADA where SER_LOTE  like'" + TextBox5.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select *FROM  T_COLADA where SER_LOTE  like'" + TextBox5.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

    End Sub
End Class