Public Class Form_Reg_Emp
    'variables publicas
    Public pase1, pase2, pase3, pase4, cod_clie, cod_sede As String

    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer

    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        item()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Dim ds As DataSet
    Dim dt As DataTable
    Dim res, o As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        TextBox3.Enabled = True
        TextBox2.Enabled = True
        DateTimePicker1.Enabled = True
        TextBox3.Text = ""
        TextBox2.Text = ""
        Button6.Enabled = True
        ListView1.Visible = True
        dgv.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "guardar"
        guardar()
        ListView1.Visible = False
        dgv.Visible = True
        llenar_grid()
    End Sub

    Private Sub Form_Reg_Emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Visible = False
        dgv.AllowUserToAddRows = False
        'LLENAR EL DATAGRIG DGV
        llenar_grid()
        'llenalistview()
    End Sub
    Private Sub item()
        preg = MsgBox("Desea agregar datos de Clasificacion", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            linea.SubItems.Add(UCase(TextBox3.Text))
            linea.SubItems.Add(UCase(TextBox2.Text))
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
            If accion = "guardar" Then
                sql = "select *from T_EMPRESA where  COD ='" + TextBox1.Text + "'"
                Form_Reg_SRV_SQL.conectar()
                com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                Else
                    For o = 0 To ListView1.Items.Count - 1
                        ' Dim n_product As String = ListView1.Items(o).SubItems(1).Text
                        ''Dim unid As String = ListView1.Items(0).SubItems(2).Text
                        'Dim medida As String = ListView1.Items(0).SubItems(3).Text
                        'Dim marca As String = ListView1.Items(0).SubItems(4).Text
                        'Dim color As String = ListView1.Items(0).SubItems(5).Text

                        sql = "exec alta_empresa '" + UCase(ListView1.Items(o).SubItems(1).Text) + "','" + UCase(ListView1.Items(0).SubItems(2).Text) + "','" + DateTimePicker1.Value.ToString("yyyyMMdd") + "'"
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
    Private Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],N_RS AS [EMPRESA],RUC_DNI AS [RUC], F_REG AS [FECHA DE REGISTRO] from T_EMPRESA"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_EMPRESA")
            dgv.DataSource = ds
            dgv.DataMember = "T_EMPRESA"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Try
            Select Case pase1
                Case "centro costo"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_SEDE where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Reg_Cent_Costo.TextBox3.Text = dr(4)
                        Form_Reg_Cent_Costo.cod_sede = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
                Case "salida"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_SEDE where  cod='" + selec + "'"
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
                    sql = "select *from T_SEDE where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Reg_Cent_Costo.TextBox3.Text = dr(4)
                        Form_Reg_Cent_Costo.cod_sede = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class