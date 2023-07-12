Public Class Form_reg_Banco
    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer

    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable
    Dim res, o As Integer
    Private Sub Form_reg_Banco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        Button6.Enabled = False
        ListView1.Visible = False
        dgv.AllowUserToAddRows = False
        'LLENAR EL DATAGRIG DGV
        llenar_grid()
        'llenalistview()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            preg = MsgBox("Desea Generar un nuevo Registro", vbYesNo)
            If preg = vbYes Then
                TextBox2.Enabled = True
                TextBox3.Enabled = True
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox1.Text = ""
                dgv.Visible = False
                ListView1.Visible = True
                Button6.Enabled = True
                Button2.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button5.Enabled = False
            Else
                MessageBox.Show("No se a Generado ningun Registro", "RUMISOFT")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            preg = MsgBox("Desea Modificar un  Registro", vbYesNo)
            If preg = vbYes Then
                TextBox2.Enabled = True
                TextBox3.Enabled = True
            Else
                MessageBox.Show("No se a Modificado ningun Registro", "RUMISOFT")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        item()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "guardar"
        guardar()
        ListView1.Items.Clear()
        ListView1.Visible = False
        dgv.Visible = True
        llenar_grid()
        Form_Mov_Banc.llenar_combo1()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            preg = MsgBox("Desea Buscar un  Registro", vbYesNo)
            If preg = vbYes Then
                TextBox4.Enabled = True
                TextBox4.Text = ""

            Else
                MessageBox.Show("No se Realizo Busquedas", "RUMISOFT")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO], N_BANCO AS [NOMBRE DE BANCO], RUC AS [R.U.C] from t_banco"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "t_banco")
            dgv.DataSource = ds
            dgv.DataMember = "t_banco"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Private Sub item()
        preg = MsgBox("Desea agregar datos de Banco", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            linea.SubItems.Add(UCase(TextBox2.Text))
            linea.SubItems.Add(UCase(TextBox3.Text))
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
            If accion = "guardar" Then
                sql = "select *from t_banco where cod = '" + TextBox1.Text + "' and ruc='" + TextBox3.Text + "'"
                Form_Reg_SRV_SQL.conectar()
                com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                Else
                    For o = 0 To ListView1.Items.Count - 1
                        Dim N_BANCO As String = ListView1.Items(o).SubItems(1).Text
                        Dim RUC As String = ListView1.Items(0).SubItems(2).Text
                        sql = "exec alta_banco '" + N_BANCO + "','" + RUC + "'"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()

                    Next
                    MessageBox.Show("Registro Guardado", "RUMISOFT")
                    'buscar_copiar()
                    'llenar_grid()
                    'facturas()
                    'fac_operacion_anx.Show()
                End If


            End If
        Catch ex As Exception

        End Try


    End Sub

    ' Private Sub llenalistview()
    'Dim x As Integer = 0
    'For Each Row As DataGridViewRow In dgv.Rows
    'ListView1.Items(x).SubItems(1).Text = Row.Cells("NOMBRE DE BANCO").Value
    'ListView1.Items(0).SubItems(2).Text = Row.Cells("R.U.C").Value
    'x += 1
    'Next

    'ListView1.Enabled = True
    'Dim item As New ListViewItem
    'Dim i, j As Integer
    'With item
    'ListView1.Items.Clear()
    'i = ListView1.CurrentRow.Index.ToString
    ' item = lstLicense.Items.Add(dgv.Item(0, i).Value.ToString, 0)
    ' item.SubItems.Add(dgv.Item(1, i).Value.ToString)
    ' item.SubItems.Add(dgv.Item(2, i).Value.ToString)
    'item.SubItems.Add(dgv.Item(3, i).Value.ToString)

    ' End With

    'End Sub
End Class