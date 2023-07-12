Public Class Form_Mov_Banc

    'variables publicas
    Public pase1, pase2, codigo, pase3, pase4, cod_clie, cod_sede, codbanccontac As String
    Public cod As Double

    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer

    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet

    Private Sub Form_Mov_Banc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combo1()
        llenar_combo2()
        llenar_grid()
    End Sub

    Dim dt As DataTable
    Dim res, o As Integer
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        accion = "guardar"
        guardar()
        llenar_grid()
        dgv.Visible = True
        ListView1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Form_Import_Excel.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Form_Reg_Moneda.Show()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form_reg_Banco.Show()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GroupBox1.Enabled = True
        dgv.Visible = False
        ListView1.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        item()
    End Sub

    Private Sub item()
        preg = MsgBox("REVISAR INFORMACION, POR REGISTRAR EN BD", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            linea.SubItems.Add(UCase(ComboBox1.Text))
            linea.SubItems.Add(UCase(TextBox6.Text))
            linea.SubItems.Add(UCase(ComboBox2.Text))
            linea.SubItems.Add(UCase(TextBox4.Text))
            linea.SubItems.Add(UCase(TextBox5.Text))
            linea.SubItems.Add(UCase(DateTimePicker1.Value.ToString("dd/MM/yyyy")))
            ListView1.Items.Add(linea)
            MessageBox.Show("Datos Agregados", "RUMISOFT")

        Else

            MessageBox.Show("No hay que registrar", "RUMISOFT")
            Button2.Enabled = True
            Button6.Enabled = True
        End If

    End Sub

    Public Sub llenar_combo1()
        sql = "select *from T_BANCO"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "T_BANCO"
        ComboBox1.ValueMember = "N_BANCO"
    End Sub

    Public Sub llenar_combo2()
        sql = "select *from T_MONEDA"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "T_MONEDA"
        ComboBox2.ValueMember = "DESCRIP"
    End Sub

    Private Sub guardar()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")
        Try
            For o = 0 To ListView1.Items.Count - 1
                If accion = "guardar" Then
                    sql = "select *from T_CUENTA_EMPRESA where  N_CTA ='" + UCase(ListView1.Items(o).SubItems(4).Text) + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        buscar_copiar()
                        ' Dim n_product As String = ListView1.Items(o).SubItems(1).Text
                        ''Dim unid As String = ListView1.Items(0).SubItems(2).Text
                        'Dim medida As String = ListView1.Items(0).SubItems(3).Text
                        'Dim marca As String = ListView1.Items(0).SubItems(4).Text
                        'Dim color As String = ListView1.Items(0).SubItems(5).Text

                        sql = "INSERT INTO T_CUENTA_EMPRESA VALUES ( '" & codigo & "','" & UCase(ListView1.Items(o).SubItems(1).Text) & "','" & UCase(ListView1.Items(o).SubItems(2).Text) & "','" & UCase(ListView1.Items(o).SubItems(4).Text) & "','" & UCase(ListView1.Items(o).SubItems(5).Text) & "','" & UCase(ListView1.Items(o).SubItems(3).Text) & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()


                        MessageBox.Show("Registro Guardado", "RUMISOFT")

                        'llenar_grid()
                        'facturas()
                        'fac_operacion_anx.Show()
                    End If


                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "NCB"
        'Dim cod, serie As String
        sql = "select *from T_CUENTA_EMPRESA where id in (select max(id) from T_CUENTA_EMPRESA)"
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

    Private Sub buscar_ULTIMO()
        ' Dim aum_cod As String
        Dim dat As String = "PR"
        'Dim cod, serie As String
        sql = "select *from T_CUENTA_EMPRESA where id in (select max(id) from T_CUENTA_EMPRESA)"
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
            MessageBox.Show("RUMISOFT")
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
            sql = "select COD AS [CODIGO],COD_BANC AS [BANCO], COD_EMP AS [PROVEEDOR], N_CTA ,N_CCI, MONEDA,FEC_REG AS [FECHA DE REGISTRO] from T_CUENTA_EMPRESA"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_CUENTA_EMPRESA")
            dgv.DataSource = ds
            dgv.DataMember = "T_CUENTA_EMPRESA"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub
End Class