Public Class Form_Contacto_Proveedor

    'variables publicas
    Public pase1, pase2, codigo, pase3, pase4, cod_clie, cod_sede, codbanccontac As String
    Public cod As Double

    'variables locales
    Dim preg, sql, accion As String

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox6.Enabled = True
        ComboBox1.Enabled = True
        dgv.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DateTimePicker1.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        'TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        ListView1.Visible = True
        dgv.Visible = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        item()
    End Sub

    Dim a As Integer

    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Dim ds As DataSet

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        FILTRO()
    End Sub

    Dim dt As DataTable
    Dim res, o As Integer

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "guardar"
        guardar()
        llenar_grid()
        dgv.Visible = True
        ListView1.Visible = False
        ListView1.Clear()
    End Sub

    Private Sub Form_Contacto_Proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        ComboBox1.Enabled = False
        DateTimePicker1.Enabled = False
        ListView1.Visible = False
        dgv.Enabled = False
        llenar_grid()
    End Sub

    Private Sub item()
        preg = MsgBox("REVISAR DATOS", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(TextBox2.Text))
            linea.SubItems.Add(UCase(TextBox3.Text))
            linea.SubItems.Add(UCase(TextBox4.Text))
            linea.SubItems.Add(UCase(TextBox5.Text))
            linea.SubItems.Add(UCase(DateTimePicker1.Value.ToString("dd/MM/yyyy")))
            ListView1.Items.Add(linea)
            MessageBox.Show("Datos Agregados", "")

        Else

            MessageBox.Show("No hay que registrar", "")
            Button4.Enabled = True
            'Button6.Enabled = True
        End If

    End Sub
    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "CTP"
        'Dim cod, serie As String
        sql = "select *from T_PROVEEDOR_CONTACTO where id in (select max(id) from T_PROVEEDOR_CONTACTO)"
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
            MessageBox.Show("Se generara Codigo", "")
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

    Private Sub buscar_ULTIMO()
        ' Dim aum_cod As String
        Dim dat As String = "CTP"
        'Dim cod, serie As String
        sql = "select *from T_PROVEEDOR_CONTACTO where id in (select max(id) from T_PROVEEDOR_CONTACTO)"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            codbanccontac = dr(0)
            'TextBox1.Text = dr(0)
            ' TextBox3.Text = dr(1)
            'TextBox2.Text = dr(2)
            'TextBox6.Text = dr(5)
            'TextBox5.Text = dr(6)
            'dtp1.Value = dr(1)
            'cb1.Text = dr(2)
            't1.Text = dr(4)
            't2.Text = dr(7)
            't4.Text = dr(8)
            't5.Text = dr(9)
        Else
            MessageBox.Show("")
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        'If cod = 0 Then
        'cod = 0
        'aum_cod = cod.ToString("00000000")
        '' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
        'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
        'serie = Microsoft.VisualBasic.Left(num_fac, 4)
        'codigo = dat & (cod + 1).ToString("00000000")
        'Else
        'aum_cod = Microsoft.VisualBasic.Right(cod, 8)
        ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
        'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
        'serie = Microsoft.VisualBasic.Left(num_fac, 4)
        ' codigo = dat & (cod + 1).ToString("00000000")
        't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
        'End If


    End Sub

    Private Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],NOM AS [NOMBRES], APE AS [APELLIDOS], EMP AS [EMPRESA], DNI, FEC_REGISTRO AS [FECHA DE REGISTRO], MAIL from T_PROVEEDOR_CONTACTO"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_PROVEEDOR_CONTACTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_PROVEEDOR_CONTACTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "")
        End Try

    End Sub

    Private Sub guardar()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")
        Try
            For o = 0 To ListView1.Items.Count - 1
                If accion = "guardar" Then
                    sql = "Select *from T_PROVEEDOR_CONTACTO where  DNI ='" & UCase(ListView1.Items(o).SubItems(5).Text) & "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        MessageBox.Show("Los Datos ya Existen", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        buscar_copiar()
                        ' Dim n_product As String = ListView1.Items(o).SubItems(1).Text
                        ''Dim unid As String = ListView1.Items(0).SubItems(2).Text
                        'Dim medida As String = ListView1.Items(0).SubItems(3).Text
                        'Dim marca As String = ListView1.Items(0).SubItems(4).Text
                        'Dim color As String = ListView1.Items(0).SubItems(5).Text

                        sql = "INSERT INTO T_PROVEEDOR_CONTACTO VALUES ( '" & codigo & "','" & UCase(ListView1.Items(o).SubItems(1).Text) & "','" & UCase(ListView1.Items(o).SubItems(2).Text) & "','" & UCase(ListView1.Items(o).SubItems(3).Text) & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & UCase(ListView1.Items(o).SubItems(5).Text) & "','" & UCase(ListView1.Items(o).SubItems(4).Text) & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()


                        MessageBox.Show("Registro Guardado", "")

                        'llenar_grid()
                        'facturas()
                        'fac_operacion_anx.Show()
                    End If


                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub FILTRO()
        Select Case ComboBox1.Text
            Case "EMPRESA"
                sql = "select *from T_PROVEEDOR_CONTACTO where EMP  like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *from T_PROVEEDOR_CONTACTO")
                dgv.DataSource = ds
                dgv.DataMember = "select *from T_PROVEEDOR_CONTACTO"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "DNI"
                sql = "select *from T_PROVEEDOR_CONTACTO where DNI  like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *from T_PROVEEDOR_CONTACTO")
                dgv.DataSource = ds
                dgv.DataMember = "select *from T_PROVEEDOR_CONTACTO"
                Form_Reg_SRV_SQL.conexion.Close()

        End Select


    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Try
            Select Case pase1
                Case "oc"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_PROVEEDOR_CONTACTO where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Orden_Compra.TextBox6.Text = dr(1)
                        Form_Orden_Compra.TextBox9.Text = dr(2)
                        Form_Orden_Compra.TextBox10.Text = dr(7)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
                Case "salida"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_PROVEEDOR_CONTACTO where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Nva_Salida.TextBox6.Text = dr(4)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()

                Case "ingreso"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_PROVEEDOR_CONTACTO where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Nvo_Ingreso.TextBox7.Text = dr(2)
                        ' Form_Reg_Cent_Costo.cod_sede = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
                Case "oc"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_PROVEEDOR_CONTACTO where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Orden_Compra.TextBox2.Text = dr(2)
                        Form_Orden_Compra.TextBox3.Text = dr(1)
                        Form_Orden_Compra.TextBox4.Text = dr(5)
                        Form_Orden_Compra.TextBox5.Text = dr(6)


                        ' Form_Reg_Cent_Costo.cod_sede = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class
