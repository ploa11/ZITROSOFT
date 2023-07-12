Public Class Form_List_Product
    'variables publicas
    Public pase1, pase2, pase3, pase4 As String

    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer

    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable
    Dim res, o As Integer

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
        TextBox5.Enabled = True
        TextBox7.Enabled = True
        Button6.Enabled = True
        Button4.Enabled = False
        Button7.Enabled = True
        Button8.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        ListView1.Visible = True
        dgv.Visible = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        ComboBox1.Enabled = True
        TextBox6.Enabled = True

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        FILTRO()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form_Tipo_Operacion.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form_Tipo_Operacion.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ListView1.Items.Remove(ListView1.Items.Item(a))
    End Sub

    Private Sub Form_List_Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.GridLines = True
        ListView1.Visible = False
        dgv.AllowUserToAddRows = False
        'LLENAR EL DATAGRIG DGV
        llenar_grid()
        'llenalistview()
    End Sub

    Private Sub item()
        preg = MsgBox("Desea agregar datos de Productos", vbYesNo)
        'a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            'linea.SubItems.Add(UCase(TextBox1.Text))
            'linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(ComboBox2.Text))
            linea.SubItems.Add(UCase(TextBox2.Text))
            linea.SubItems.Add(UCase(ComboBox3.Text))
            linea.SubItems.Add(UCase(TextBox4.Text))
            linea.SubItems.Add(UCase(TextBox5.Text))
            linea.SubItems.Add(UCase(TextBox7.Text))
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
                sql = "select *from T_LIST_PRODUCTOS where  NOM_PRODUC='" + TextBox2.Text + "'"
                Form_Reg_SRV_SQL.conectar()
                com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                Else
                    For o = 0 To ListView1.Items.Count - 1
                        Dim n_product As String = ListView1.Items(o).SubItems(2).Text
                        Dim unid As String = ListView1.Items(o).SubItems(3).Text
                        Dim T_EXIS As String = ListView1.Items(o).SubItems(1).Text
                        Dim marca As String = ListView1.Items(o).SubItems(4).Text
                        Dim color As String = ListView1.Items(o).SubItems(5).Text
                        Dim CALIBRE As String = ListView1.Items(o).SubItems(6).Text
                        Dim tallA As String = "NO APLICA"

                        sql = "exec alta_list_product '" + n_product + "','" + unid + "','" + unid + "','" + marca + "','" + color + "','" + CALIBRE + "','" + tallA + "','" + T_EXIS + "'"
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

    Public Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , T_EXIST AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR] from T_LIST_PRODUCTOS"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_LIST_PRODUCTOS")
            dgv.DataSource = ds
            dgv.DataMember = "T_LIST_PRODUCTOS"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Public Sub FILTRO()
        Select Case ComboBox1.Text
            Case "CODIGO"
                sql = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where COD  like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS  where COD  like'" + TextBox6.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS  where COD  like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "NOMBRE DE PRODUCTO"
                sql = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC  like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC like'" + TextBox6.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "MARCA"
                sql = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [MEDIDA], MARCA, COLOR from T_LIST_PRODUCTOS where MARCA like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where MARCA like'" + TextBox6.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where MARCA like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()
        End Select


    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Try
            Select Case pase1
                Case "rq"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_LIST_PRODUCTOS where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Reg_RQ.TextBox2.Text = dr(1)
                        Form_Reg_RQ.TextBox4.Text = dr(2)
                        Form_Reg_RQ.TextBox12.Text = dr(3)
                        Form_Reg_RQ.TextBox13.Text = dr(4)
                        Form_Reg_RQ.TextBox14.Text = dr(5)

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
                        Form_control_alamacen.TextBox2.Text = dr(1)
                        Form_control_alamacen.TextBox3.Text = dr(2)
                        Form_control_alamacen.TextBox4.Text = dr(3)
                        Form_control_alamacen.TextBox5.Text = dr(4)
                        Form_control_alamacen.TextBox6.Text = dr(5)
                        Form_control_alamacen.TextBox7.Text = dr(0)
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

    Public Sub llenar_combo1()
        sql = "select *from T_TIPO_EXISTENCIA"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "DESCRIP"
        ComboBox2.ValueMember = "DESCRIP"
    End Sub
    Public Sub llenar_combo2()
        sql = "select *from T_COD_UNID_MED"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox3.DataSource = dt
        ComboBox3.DisplayMember = "DESCRIP"
        ComboBox3.ValueMember = "DESCRIP"
    End Sub
End Class