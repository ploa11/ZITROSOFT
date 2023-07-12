Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Form_Reg_SCCOS

    'variables publicas
    Public pase1, pase2, pase3, pase4, cod_clie, cod_sede, cod_cc As String

    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer

    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox8.Enabled = True
        TextBox9.Enabled = True
        TextBox10.Enabled = True
        TextBox12.Enabled = True
        TextBox13.Enabled = True
        TextBox14.Enabled = True

        DateTimePicker1.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        'Button6.Enabled = True
        ListView1.Visible = True
        ListView1.Items.Clear()
        dgv.Visible = False
        Button1.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "guardar"
        guardar()
        ListView1.Visible = False
        dgv.Visible = True
        llenar_grid()
        Button4.Enabled = False
        Button1.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        item()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        FILTRO()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Dim t8 As Double = TextBox8.Text
            Dim t9 As Double = TextBox9.Text
            Dim t10 As Double = TextBox10.Text
            Dim t7 As Double
            Dim t6 As Double = TextBox6.Text
            TextBox7.Text = t8 + t9 + t10
            t7 = TextBox7.Text
            TextBox11.Text = t6 - t7
            Button6.Enabled = True
            Button7.Enabled = True
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ListView1.Items.Remove(ListView1.Items.Item(a))
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click


        Form1.Show()
        Form1.pase1 = "COTI_SSC"
        Form1.Label1.Visible = True
        Form1.Label2.Visible = False
        Form1.llenar_grid_LOGISTICA_SCC()
        Form1.RQ_SCC = "BUSCAR COTI"
        'llenar_PRO_COTI_SCCO()



    End Sub

    Dim ds As DataSet
    Dim dt As DataTable

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        llenar_PRO_COTI_SCCO()
        CALCULAR_MONTO_VENTA()
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Dim res, o As Integer

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form_Reg_Cent_Costo.pase1 = "subcc"
        Form_Reg_Cent_Costo.Show()
        Form_Reg_Cent_Costo.ComboBox1.Enabled = True
        Form_Reg_Cent_Costo.TextBox4.Enabled = True

    End Sub

    Private Sub Form_Reg_SCCOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Visible = False
        dgv.AllowUserToAddRows = False
        ListView1.GridLines = True
        'LLENAR EL DATAGRIG DGV
        llenar_grid()

        'llenalistview()
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub item()
        preg = MsgBox("Desea agregar datos de Centro de Costo", vbYesNo)
        'a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            linea.SubItems.Add(UCase(TextBox2.Text))
            linea.SubItems.Add(UCase(TextBox3.Text))
            linea.SubItems.Add(UCase(DateTimePicker1.Value.ToString("dd/MM/yyyy")))
            linea.SubItems.Add(UCase(TextBox5.Text))
            linea.SubItems.Add(UCase(TextBox6.Text))
            linea.SubItems.Add(UCase(TextBox7.Text))
            linea.SubItems.Add(UCase(TextBox8.Text))
            linea.SubItems.Add(UCase(TextBox9.Text))
            linea.SubItems.Add(UCase(TextBox10.Text))
            linea.SubItems.Add(UCase(DateTimePicker2.Value.ToString("dd/MM/yyyy")))
            linea.SubItems.Add(UCase(TextBox11.Text))
            linea.SubItems.Add(UCase(TextBox12.Text))
            linea.SubItems.Add(UCase(TextBox13.Text))
            linea.SubItems.Add(UCase(TextBox14.Text))
            ListView1.Items.Add(linea)
            'MessageBox.Show("Datos Agregados Para guardar", "ZITRO")
            ' preg = MsgBox("Desea seguir agregando proyectos", vbYesNo)

            'If preg = vbYes Then
            'TextBox2.Text = ""
            'TextBox3.Text = ""
            'DateTimePicker1.Text = ""
            'TEXBox5.Text = ""
            'TextBox6.Text = ""
            'TextBox7.Text = ""
            'TextBox8.Text = ""
            'TextBox9.Text = ""
            'TextBox10.Text = ""
            'DateTimePicker2.Text = ""
            'TextBox11.Text = ""
            'TextBox12.Text = ""
            'TextBox13.Text = ""



        End If

        MessageBox.Show("REGISTRE EN BASE DE DATOS", "ZITRO")

        TextBox2.Text = ""
        TextBox3.Text = ""
        DateTimePicker1.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        DateTimePicker2.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        Button4.Enabled = True
        Button6.Enabled = False


    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub FILTRO()
        Select Case ComboBox1.Text
            Case "CENTRO DE COSTO"
                sql = "SELECT COD AS [CODIGO],COD_CEN_COST AS [CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO] , FEC_REG AS [FECHA DE REGISTRO],DET_SERV AS [DETALLE DE SERVICIO],MONTO  from T_SUB_C_COS_OS where COD_CEN_COST  like'" + TextBox4.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "T_SUB_C_COS_OS")
                dgv.DataSource = ds
                dgv.DataMember = "T_SUB_C_COS_OS"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "ORDEN DE SERVICIO"
                sql = "SELECT COD AS [CODIGO], COD_CEN_COST AS [CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO] , FEC_REG AS [FECHA DE REGISTRO], DET_SERV AS [DETALLE DE SERVICIO], MONTO  from T_SUB_C_COS_OS where ORD_SERV  like'" + TextBox4.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "T_SUB_C_COS_OS")
                dgv.DataSource = ds
                dgv.DataMember = "T_SUB_C_COS_OS"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "DETALLE DE SERVICIO"
                sql = "SELECT COD AS [CODIGO],COD_CEN_COST AS [CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO] , FEC_REG AS [FECHA DE REGISTRO],DET_SERV AS [DETALLE DE SERVICIO],MONTO  from T_SUB_C_COS_OS where DET_SERV  like'" + TextBox4.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "T_SUB_C_COS_OS")
                dgv.DataSource = ds
                dgv.DataMember = "T_SUB_C_COS_OS"
                Form_Reg_SRV_SQL.conexion.Close()
        End Select


    End Sub

    Private Sub guardar()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")
        Try
            For o = 0 To ListView1.Items.Count - 1
                If accion = "guardar" Then
                    sql = "select *from T_SUB_C_COS_OS where  ORD_SERV ='" + TextBox3.Text + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        MessageBox.Show("Los Datos ya Existen", "ZITRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else

                        Dim cod_cto As String = ListView1.Items(o).SubItems(1).Text
                        Dim or_srv As String = ListView1.Items(o).SubItems(2).Text
                        Dim fec As String = DateTimePicker1.Value.ToString("yyyyMMdd") 'ListView1.Items(0).SubItems(3).Text
                        Dim det_serv As String = ListView1.Items(o).SubItems(4).Text
                        Dim monto As String = ListView1.Items(o).SubItems(5).Text
                        Dim monto_real As String = ListView1.Items(o).SubItems(6).Text
                        Dim monto_real_mat As String = ListView1.Items(o).SubItems(7).Text
                        Dim monto_real_eqp As String = ListView1.Items(o).SubItems(8).Text
                        Dim monto_real_gasgen As String = ListView1.Items(o).SubItems(9).Text
                        Dim fec_actu As String = DateTimePicker2.Value.ToString("yyyyMMdd") 'ListView1.Items(o).SubItems(10).ToString("yyyyMMdd")
                        Dim util As String = ListView1.Items(o).SubItems(11).Text
                        Dim estado As String = ListView1.Items(0).SubItems(12).Text
                        Dim dias_proyecto As String = ListView1.Items(0).SubItems(13).Text
                        Dim COD_COTIZACION As String = ListView1.Items(0).SubItems(14).Text
                        sql = "exec alta_sub_cc '" + cod_cto + "','" + or_srv + "','" + fec + "','" + det_serv + "','" + monto + "','" + monto_real + "','" + monto_real_mat + "','" + monto_real_eqp + "','" + monto_real_gasgen + "','" + util + "','" + fec_actu + "' ,'" + estado + "' , '" + dias_proyecto + "','" + COD_COTIZACION + "'"
                        'sql = "INSERT INTO T_SUB_C_COS_OS  VALUES ('" & cod_cto & "','" & or_srv & "','" & fec & "','" & det_serv & "','" & monto & "','" & monto_real & "','" & monto_real_mat & "','" & monto_real_eqp & "','" & monto_real_gasgen & "','" & util & "','" & fec_actu & "','" & estado & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()


                        MessageBox.Show("Registro Guardado", "ZITRO")

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
            sql = "Select COD As [CODIGO],COD_CEN_COST As [CODIGO DE CENTRO DE COSTO], ORD_SERV As [ORDEN DE SERVICIO] , FEC_REG As [FECHA DE REGISTRO],DET_SERV As [DETALLE DE SERVICIO], MONTO As [MONOT DE SERVICIO], MONTO_REAL As [MONTO REAL],MONTO_REAL_MAT As [MONTO REAL MATERIALES], MONTO_REAL_EQP As [MONTO REAL DE EQUIPOS], MONTO_REAL_GASTGEN As [MONTO REAL GASTO GENERAL], UTILIDAD , fec_actual As [FECHA ACTUAL] , ESTADO AS [ESTADO], DIAS_PROYECTO AS [DIAS DE PROYECTO], COD_COTI AS [CODIGO COTIZACION] from T_SUB_C_COS_OS"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_SUB_C_COS_OS")
            dgv.DataSource = ds
            dgv.DataMember = "T_SUB_C_COS_OS"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Try
            Select Case pase1
                Case "ccosto"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "Select *from T_SUB_C_COS_OS where  cod='" + selec + "'"
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
                Case "rq"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_SUB_C_COS_OS where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Reg_RQ.TextBox5.Text = dr(0)
                        Form_Reg_RQ.TextBox7.Text = dr(1)
                        Form_Reg_RQ.TextBox3.Text = dr(2)
                        Form_Reg_RQ.TextBox8.Text = dr(5)
                        Form_Reg_RQ.cod_sbc = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()

                Case "guia"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_SUB_C_COS_OS where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        form_ingreso_salida.TextBox8.Text = dr(0)
                        'Form_Reg_RQ.TextBox7.Text = dr(1)
                        'Form_Reg_RQ.TextBox3.Text = dr(2)
                        'Form_Reg_RQ.TextBox8.Text = dr(5)
                        'Form_Reg_RQ.cod_sbc = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
                Case "rq"
                    Dim nc As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_SUB_C_COS_OS where  ORD_SERV='" + nc + "'or cod ='" + nc + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Reg_RQ.TextBox5.Text = dr(0)
                        Form_Reg_RQ.TextBox7.Text = dr(1)
                        Form_Reg_RQ.TextBox3.Text = dr(2)
                        Form_Reg_RQ.TextBox8.Text = dr(5)
                        Form_Reg_RQ.cod_sbc = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
                    'Form_Reg_SCCOS.pase1 = "rq"
                    ' Form_Reg_SCCOS.ComboBox1.Enabled = True
                    'Form_Reg_SCCOS.TextBox4.Enabled = True
                    'Form_Reg_SCCOS.Show()
                    'Button9.Enabled = True
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CALCULAR_MONTO_VENTA()
        Dim cod_editar, cod_coti_editar, descrip_editar As String
        Dim cant_EDITAR, prec_SUBT_editar, prec_total_editar, T_UTIL, T_SUB_TOT, UTIL As Integer
        Try
            For I As Integer = 0 To DataGridView1.Rows.Count - 1
                prec_SUBT_editar = (DataGridView1.Rows(I).Cells(5).Value)
                UTIL = (DataGridView1.Rows(I).Cells(9).Value)
                'igv_editar = (DataGridView1.Rows(i).Cells(6).Value)
                T_SUB_TOT += prec_SUBT_editar
                T_UTIL += UTIL
            Next
            prec_total_editar = T_SUB_TOT + T_UTIL
            TextBox6.Text = prec_total_editar
        Catch ex As Exception

        End Try
    End Sub

    Public Sub llenar_PRO_COTI_SCCO()
        Try
            sql = "select *from T_COTI_ITEMS WHERE COD_COTI='" + TextBox14.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_COTI_ITEMS")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "T_COTI_ITEMS"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Private Sub TextBox8_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox8.MouseClick

    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
        ' MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
        Try
            If Len(cadena) = 0 Then
                filtro += "-"
            End If
            If Len(cadena) > 0 Then
                filtro += "."
            End If


            For Each caracter In filtro
                If e.KeyChar = caracter Then
                    e.Handled = False

                    Exit For
                Else
                    e.Handled = True
                    'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
                End If
            Next

            If e.KeyChar = "0" And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""
            ElseIf e.KeyChar <> "0" And e.KeyChar <> "." And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""


            End If





            If Char.IsControl(e.KeyChar) Then
                e.Handled = False

            End If


            If e.KeyChar = "." And Not cadena.IndexOf(".") Then
                e.Handled = True
                'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
        ' MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
        Try
            If Len(cadena) = 0 Then
                filtro += "-"
            End If
            If Len(cadena) > 0 Then
                filtro += "."
            End If


            For Each caracter In filtro
                If e.KeyChar = caracter Then
                    e.Handled = False

                    Exit For
                Else
                    e.Handled = True
                    'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
                End If
            Next

            If e.KeyChar = "0" And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""
            ElseIf e.KeyChar <> "0" And e.KeyChar <> "." And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""


            End If





            If Char.IsControl(e.KeyChar) Then
                e.Handled = False

            End If


            If e.KeyChar = "." And Not cadena.IndexOf(".") Then
                e.Handled = True
                'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
        ' MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
        Try
            If Len(cadena) = 0 Then
                filtro += "-"
            End If
            If Len(cadena) > 0 Then
                filtro += "."
            End If


            For Each caracter In filtro
                If e.KeyChar = caracter Then
                    e.Handled = False

                    Exit For
                Else
                    e.Handled = True
                    'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
                End If
            Next

            If e.KeyChar = "0" And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""
            ElseIf e.KeyChar <> "0" And e.KeyChar <> "." And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""


            End If





            If Char.IsControl(e.KeyChar) Then
                e.Handled = False

            End If


            If e.KeyChar = "." And Not cadena.IndexOf(".") Then
                e.Handled = True
                'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
        ' MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
        Try
            If Len(cadena) = 0 Then
                filtro += "-"
            End If
            If Len(cadena) > 0 Then
                filtro += "."
            End If


            For Each caracter In filtro
                If e.KeyChar = caracter Then
                    e.Handled = False

                    Exit For
                Else
                    e.Handled = True
                    'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
                End If
            Next

            If e.KeyChar = "0" And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""
            ElseIf e.KeyChar <> "0" And e.KeyChar <> "." And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""


            End If





            If Char.IsControl(e.KeyChar) Then
                e.Handled = False

            End If


            If e.KeyChar = "." And Not cadena.IndexOf(".") Then
                e.Handled = True
                'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
        ' MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
        Try
            If Len(cadena) = 0 Then
                filtro += "-"
            End If
            If Len(cadena) > 0 Then
                filtro += "."
            End If


            For Each caracter In filtro
                If e.KeyChar = caracter Then
                    e.Handled = False

                    Exit For
                Else
                    e.Handled = True
                    'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
                End If
            Next

            If e.KeyChar = "0" And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""
            ElseIf e.KeyChar <> "0" And e.KeyChar <> "." And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""


            End If





            If Char.IsControl(e.KeyChar) Then
                e.Handled = False

            End If


            If e.KeyChar = "." And Not cadena.IndexOf(".") Then
                e.Handled = True
                'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class