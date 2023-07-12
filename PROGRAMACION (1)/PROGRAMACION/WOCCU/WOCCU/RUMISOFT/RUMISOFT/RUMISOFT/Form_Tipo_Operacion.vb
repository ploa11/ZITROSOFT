Public Class Form_Tipo_Operacion

    Public codigo, nom, ap_pa, ap_ma, dni, cargo, pase1, pase2, STOKACTUAL As String

    'variables sql
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "guardar"
        guardar()
        TextBox1.Text = ""
        TextBox1.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        ComboBox1.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        If Form_List_Product.pase1 = "1" Then
            Me.Close()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button3.Enabled = True
        Button4.Enabled = True
        TextBox1.Enabled = True
        TextBox1.Text = ""
        ComboBox1.Enabled = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Button1.Enabled = True
        Button2.Enabled = True
        llenado_dgv()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim res, o As Integer
    'variables locales
    Dim preg, sql, accion, SEDE, MICARGO As String
    Dim a As Integer
    Private Sub Form_Tipo_Operacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub llenado_dgv()
        Select Case ComboBox1.Text
            Case "Tipo de Operacion"
                Try
                    sql = "select ID AS [CODIGO],DESCRIP AS [DESCRIPCION] from T_TIPO_OPERACION"
                    Form_reg_srv_sql.conectar()
                    da = New SqlClient.SqlDataAdapter(sql, Form_reg_srv_sql.conexion)
                    cb = New SqlClient.SqlCommandBuilder(da)
                    ds = New DataSet
                    da.Fill(ds, "T_TIPO_OPERACION")
                    dgv.DataSource = ds
                    dgv.DataMember = "T_TIPO_OPERACION"
                    Form_reg_srv_sql.conexion.Close()
                Catch ex As Exception
                    MessageBox.Show("Error al mostrar los datos")
                End Try
            Case "Tipo de Comprobante de Pago o Documento"
                Try
                    sql = "select ID AS [CODIGO],DESCRIP AS [DESCRIPCION] from T_COMP_PAG"
                    Form_reg_srv_sql.conectar()
                    da = New SqlClient.SqlDataAdapter(sql, Form_reg_srv_sql.conexion)
                    cb = New SqlClient.SqlCommandBuilder(da)
                    ds = New DataSet
                    da.Fill(ds, "T_COMP_PAG")
                    dgv.DataSource = ds
                    dgv.DataMember = "T_COMP_PAG"
                    Form_reg_srv_sql.conexion.Close()
                Catch ex As Exception
                    MessageBox.Show("Error al mostrar los datos")
                End Try
            Case "Codigo de la Unidad de Medida"
                Try
                    sql = "select ID AS [CODIGO],DESCRIP AS [DESCRIPCION] from T_COD_UNID_MED"
                    Form_reg_srv_sql.conectar()
                    da = New SqlClient.SqlDataAdapter(sql, Form_reg_srv_sql.conexion)
                    cb = New SqlClient.SqlCommandBuilder(da)
                    ds = New DataSet
                    da.Fill(ds, "T_COD_UNID_MED")
                    dgv.DataSource = ds
                    dgv.DataMember = "T_COD_UNID_MED"
                    Form_reg_srv_sql.conexion.Close()
                Catch ex As Exception
                    MessageBox.Show("Error al mostrar los datos")
                End Try
            Case "Tipo de Existencia"
                Try
                    sql = "select ID AS [CODIGO],DESCRIP AS [DESCRIPCION] from T_TIPO_EXISTENCIA"
                    Form_reg_srv_sql.conectar()
                    da = New SqlClient.SqlDataAdapter(sql, Form_reg_srv_sql.conexion)
                    cb = New SqlClient.SqlCommandBuilder(da)
                    ds = New DataSet
                    da.Fill(ds, "T_TIPO_EXISTENCIA")
                    dgv.DataSource = ds
                    dgv.DataMember = "T_TIPO_EXISTENCIA"
                    Form_reg_srv_sql.conexion.Close()
                Catch ex As Exception
                    MessageBox.Show("Error al mostrar los datos")
                End Try

        End Select
        Form_List_Product.llenar_combo1()
        Form_List_Product.llenar_combo2()
        Form_Nvo_Ingreso.llenar_combo1()
        Form_Nvo_Ingreso.llenar_combo2()
    End Sub
    ' Private Sub llenar_grid()
    'Try
    ' sql = "Select COD As [CODIGO],CP_ALMACEN As [CODIGO ALMACEN], STOK, N_ING As [NUEVO INGRESO] , STOK_ACTUAL As [STOK ACTUAL], F_INGRESO As [FECHA DE INGRESO], SEDE from T_ALMACEN_INGRESO WHERE CP_ALMACEN='" + TextBox1.Text + "' and SEDE='LIMA'"
    ' Form_reg_srv_sql.conectar()
    ' da = New SqlClient.SqlDataAdapter(sql, Form_reg_srv_sql.conexion)
    ' cb = New SqlClient.SqlCommandBuilder(da)
    ' ds = New DataSet
    ' da.Fill(ds, "T_ALMACEN_INGRESO")
    'dgv.DataSource = ds
    'dgv.DataMember = "T_ALMACEN_INGRESO"
    ' Form_reg_srv_sql.conexion.Close()
    'Catch ex As Exception
    ' MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
    'End Try

    'End Sub

    Private Sub guardar()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")


        ' buscar_copiar()
        'codigo = "USU0000001"
        Dim descrip As String = TextBox1.Text



        'Dim SEDE As String = SEDE

        Select Case ComboBox1.Text
            Case "Tipo de Operacion"
                Try
                    If accion = "guardar" Then

                        sql = "select *from T_TIPO_OPERACION where  DESCRIP='" +TextBox1.Text +"'"
                        Form_reg_srv_sql.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
                        dr = com.ExecuteReader

                        If dr.Read Then
                            'cod = dr(0)
                            MessageBox.Show("Los Datos ya Existen", "EMP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dr.Close()
                            Form_reg_srv_sql.conexion.Close()
                        Else
                            sql = "INSERT INTO T_TIPO_OPERACION  VALUES ('" & UCase(TextBox1.Text) & "')"
                            Form_reg_srv_sql.conectar()
                            com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
                            res = com.ExecuteNonQuery
                            Form_reg_srv_sql.conexion.Close()
                            MessageBox.Show("Registro Guardado", "EMP")
                        End If

                        llenado_dgv()
                        'buscar_copiar()


                        'fac_operacion_anx.Show()
                    End If

                Catch ex As Exception

                End Try

            Case "Tipo de Comprobante de Pago o Documento"
                Try
                    If accion = "guardar" Then

                        sql = "select *from T_COMP_PAG where  DESCRIP='" + TextBox1.Text + "'"
                        Form_reg_srv_sql.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
                        dr = com.ExecuteReader

                        If dr.Read Then
                            'cod = dr(0)
                            MessageBox.Show("Los Datos ya Existen", "EMP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dr.Close()
                            Form_reg_srv_sql.conexion.Close()
                        Else
                            sql = "INSERT INTO T_COMP_PAG  VALUES ('" & UCase(TextBox1.Text) & "')"
                            Form_reg_srv_sql.conectar()
                            com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
                            res = com.ExecuteNonQuery
                            Form_reg_srv_sql.conexion.Close()
                            MessageBox.Show("Registro Guardado", "EMP")
                        End If

                        llenado_dgv()
                        'buscar_copiar()


                        'fac_operacion_anx.Show()
                    End If

                Catch ex As Exception

                End Try
            Case "Codigo de la Unidad de Medida"
                Try
                    If accion = "guardar" Then

                        sql = "select *from T_COD_UNID_MED where  DESCRIP='" + TextBox1.Text + "'"
                        Form_reg_srv_sql.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
                        dr = com.ExecuteReader

                        If dr.Read Then
                            'cod = dr(0)
                            MessageBox.Show("Los Datos ya Existen", "EMP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dr.Close()
                            Form_reg_srv_sql.conexion.Close()
                        Else
                            sql = "INSERT INTO T_COD_UNID_MED  VALUES ('" & UCase(TextBox1.Text) & "')"
                            Form_reg_srv_sql.conectar()
                            com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
                            res = com.ExecuteNonQuery
                            Form_reg_srv_sql.conexion.Close()
                            MessageBox.Show("Registro Guardado", "EMP")
                        End If

                        llenado_dgv()
                        'buscar_copiar()


                        'fac_operacion_anx.Show()
                    End If

                Catch ex As Exception

                End Try
            Case "Tipo de Existencia"
                Try
                    If accion = "guardar" Then

                        sql = "select *from T_TIPO_EXISTENCIA where  DESCRIP='" + TextBox1.Text + "'"
                        Form_reg_srv_sql.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
                        dr = com.ExecuteReader

                        If dr.Read Then
                            'cod = dr(0)
                            MessageBox.Show("Los Datos ya Existen", "EMP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dr.Close()
                            Form_reg_srv_sql.conexion.Close()
                        Else
                            sql = "INSERT INTO T_TIPO_EXISTENCIA  VALUES ('" & UCase(TextBox1.Text) & "')"
                            Form_reg_srv_sql.conectar()
                            com = New SqlClient.SqlCommand(sql, Form_reg_srv_sql.conexion)
                            res = com.ExecuteNonQuery
                            Form_reg_srv_sql.conexion.Close()
                            MessageBox.Show("Registro Guardado", "EMP")
                        End If

                        llenado_dgv()
                        'buscar_copiar()


                        'fac_operacion_anx.Show()
                    End If

                Catch ex As Exception

                End Try
        End Select



        'llenar_grid()
        ' ListView1.Items.Clear()
        'ListView1.Visible = False
        dgv.Visible = True
        ' act_almacen()
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

End Class