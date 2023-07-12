Public Class Form_Reg_Cliente
    'variables publicas
    Public pase1, pase2, codigo, pase3, pase4 As String
    Public cod As Double
    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer

    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable
    Dim res, o As Integer

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        ComboBox1.Enabled = True
        TextBox6.Enabled = True
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        FILTRO()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        item()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "guardar"
        guardar()
        ListView1.Visible = False
        dgv.Visible = True
        llenar_grid()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        Button6.Enabled = True
        DateTimePicker1.Enabled = True
        Button4.Enabled = False
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ListView1.Visible = True
        dgv.Visible = False
    End Sub

    Private Sub Form_Reg_Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Visible = False
        dgv.AllowUserToAddRows = False
        'LLENAR EL DATAGRIG DGV
        llenar_grid()
        'llenalistview()
    End Sub

    Private Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],RZ_SOCIAL AS [RAZON SOCIAL], RUC AS [R.U.C] , DIREC AS [DIRECCION], FEC_REG AS [FECHA DE REGISTRO] from T_REG_CLIENTE"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REG_CLIENTE")
            dgv.DataSource = ds
            dgv.DataMember = "T_REG_CLIENTE"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Private Sub item()
        preg = MsgBox("Desea agregar datos de Cliente", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            'linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(TextBox2.Text))
            linea.SubItems.Add(UCase(TextBox3.Text))
            linea.SubItems.Add(UCase(TextBox4.Text))
            linea.SubItems.Add(DateTimePicker1.Value.ToString("dd/MM/yyyy"))
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
                    sql = "select *from T_REG_CLIENTE where  ruc='" + TextBox3.Text + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        buscar_copiar()
                        Dim rz_social As String = ListView1.Items(o).SubItems(1).Text
                        Dim RUC As String = ListView1.Items(o).SubItems(2).Text
                        Dim DIRECC As String = ListView1.Items(o).SubItems(3).Text

                        sql = "INSERT INTO T_REG_CLIENTE VALUES ( '" & codigo & "','" & rz_social & "','" & RUC & "','" & DIRECC & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "')"
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

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Try
            Select Case pase1
                Case "centro costo"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_REG_CLIENTE where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Reg_Cent_Costo.TextBox2.Text = dr(1)
                        Form_Reg_Cent_Costo.cod_clie = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FILTRO()
        Select Case ComboBox1.Text
            Case "CODIGO"
                sql = "select COD AS [CODIGO], RZ_SOCIAL AS [RAZON SOCIAL], RUC AS [R.U.C] , DIREC AS [DIRECCION], FEC_REG AS [FECHA DE REGISTRO] from T_REG_CLIENTE where COD  like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *from T_REG_CLIENTE")
                dgv.DataSource = ds
                dgv.DataMember = "select *from T_REG_CLIENTE"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "RAZON SOCIAL"
                sql = "select COD AS [CODIGO],RZ_SOCIAL AS [RAZON SOCIAL], RUC AS [R.U.C] , DIREC AS [DIRECCION], FEC_REG AS [FECHA DE REGISTRO] from T_REG_CLIENTE where RZ_SOCIAL  like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select *from T_REG_CLIENTE")
                dgv.DataSource = ds
                dgv.DataMember = "select *from T_REG_CLIENTE"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "RUC"
                sql = "select COD AS [CODIGO],RZ_SOCIAL AS [RAZON SOCIAL], RUC AS [R.U.C] , DIREC AS [DIRECCION], FEC_REG AS [FECHA DE REGISTRO] from T_REG_CLIENTE where RUC like'" + TextBox6.Text + "%'"
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
    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "CL"
        'Dim cod, serie As String
        sql = "select *from T_REG_CLIENTE where id in (select max(id) from T_REG_CLIENTE)"
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
End Class