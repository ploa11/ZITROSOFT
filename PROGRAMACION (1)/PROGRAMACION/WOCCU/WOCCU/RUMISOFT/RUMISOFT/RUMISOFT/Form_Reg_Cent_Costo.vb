Public Class Form_Reg_Cent_Costo

    'variables publicas
    Public pase1, pase2, pase3, pase4, cod_clie, cod_sede, cod_cc As String

    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer

    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable

    Private Sub Form_Reg_Cent_Costo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Visible = False
        dgv.AllowUserToAddRows = False
        'LLENAR EL DATAGRIG DGV
        llenar_grid()
        'llenalistview()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        item()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "guardar"
        guardar()
        ListView1.Visible = False
        ListView1.Clear()
        dgv.Visible = True
        llenar_grid()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        FILTRO()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.Text
            Case "CLIENTE"
                Button8.Enabled = True
                Button9.Enabled = False
            Case "SEDE"
                Button8.Enabled = False
                Button9.Enabled = True

        End Select
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click
        Form_Reg_Cliente.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form_Reg_Sede.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form_Reg_Sede.pase1 = "centro costo"
        Form_Reg_Sede.Show()
    End Sub

    Dim res, o As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        DateTimePicker1.Enabled = True
        Button7.Enabled = True
        Button10.Enabled = True
        'Button8.Enabled = True
        TextBox2.Text = ""
        TextBox3.Text = ""
        Button6.Enabled = True
        ListView1.Visible = True
        dgv.Visible = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form_Reg_Cliente.pase1 = "centro costo"
        Form_Reg_Cliente.Button3.Enabled = True
        Form_Reg_Cliente.Button6.Enabled = True
        Form_Reg_Cliente.TextBox6.Enabled = True
        Form_Reg_Cliente.TextBox6.Text = ""
        Form_Reg_Cliente.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Form_Reg_Sede.pase1 = "centro costo"
        Form_Reg_Sede.ComboBox1.Enabled = True
        Form_Reg_Sede.TextBox6.Enabled = True
        Form_Reg_Sede.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        TextBox4.Enabled = True
    End Sub

    Private Sub FILTRO()
        Select Case ComboBox1.Text
            Case "CLIENTE"
                sql = "select COD AS [CODIGO], COD_CLIE  AS [CODIGO DE CLIENTE], COD_SEDE AS [CODIGO DE SEDE], FEC_REG AS [FECHA DE REGISTRO] from T_CENTRO_COSTO where COD_CLIE  like'" + TextBox4.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *from T_CENTRO_COSTO")
                dgv.DataSource = ds
                dgv.DataMember = "select *from T_CENTRO_COSTO"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "SEDE"
                sql = "select COD AS [CODIGO], COD_CLIE  AS [CODIGO DE CLIENTE], COD_SEDE AS [CODIGO DE SEDE], FEC_REG AS [FECHA DE REGISTRO] from T_CENTRO_COSTO where COD_SEDE  like'" + TextBox4.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *from T_REG_CLIENTE")
                dgv.DataSource = ds
                dgv.DataMember = "select *from T_REG_CLIENTE"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "RUC"
                sql = "select COD AS [CODIGO], COD_CLIE  AS [CODIGO DE CLIENTE], COD_SEDE AS [CODIGO DE SEDE], FEC_REG AS [FECHA DE REGISTRO] from T_CENTRO_COSTO where COD  like'" + TextBox4.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *from T_REG_CLIENTE")
                dgv.DataSource = ds
                dgv.DataMember = "select *from T_REG_CLIENTE"
                Form_Reg_SRV_SQL.conexion.Close()
        End Select


    End Sub

    Private Sub item()
        preg = MsgBox("Desea agregar datos de Centro de Costo", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            linea.SubItems.Add(UCase(cod_clie))
            linea.SubItems.Add(UCase(cod_sede))
            linea.SubItems.Add(UCase(DateTimePicker1.Value.ToString("dd/MM/yyyy")))
            ListView1.Items.Add(linea)
            MessageBox.Show("Datos Agregados", "RUMISOFT")

        Else

            MessageBox.Show("No hay que registrar", "RUMISOFT")
            Button4.Enabled = True
            Button6.Enabled = False
        End If

    End Sub

    Private Sub guardar()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")
        Try
            For o = 0 To ListView1.Items.Count - 1
                If accion = "guardar" Then
                    sql = "select *from T_CENTRO_COSTO where  COD ='" + TextBox3.Text + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else

                        ' Dim n_product As String = ListView1.Items(o).SubItems(1).Text
                        ''Dim unid As String = ListView1.Items(0).SubItems(2).Text
                        'Dim medida As String = ListView1.Items(0).SubItems(3).Text
                        'Dim marca As String = ListView1.Items(0).SubItems(4).Text
                        'Dim color As String = ListView1.Items(0).SubItems(5).Text

                        sql = "exec alta_centrocosto '" + UCase(ListView1.Items(o).SubItems(1).Text) + "','" + UCase(ListView1.Items(o).SubItems(2).Text) + "','" + DateTimePicker1.Value.ToString("yyyyMMdd") + "'"
                            Form_Reg_SRV_SQL.conectar()
                            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                            res = com.ExecuteNonQuery
                            Form_Reg_SRV_SQL.conexion.Close()


                        MessageBox.Show("Registro Guardado", "RUMISOFT")
                        'buscar_copiar()
                        'llenar_grid()
                        'facturas()
                        'fac_operacion_anx.Show()
                    End If


                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],COD_CLIE AS [CODIGO DE CLIENTE], COD_SEDE AS [CODIGO DE SEDE] , FEC_REG AS [FECHA DE REGISTRO] from T_CENTRO_COSTO"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_CENTRO_COSTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_CENTRO_COSTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Try
            Select Case pase1
                Case "subcc"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_CENTRO_COSTO where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Reg_SCCOS.TextBox2.Text = dr(0)
                        Form_Reg_SCCOS.cod_cc = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class