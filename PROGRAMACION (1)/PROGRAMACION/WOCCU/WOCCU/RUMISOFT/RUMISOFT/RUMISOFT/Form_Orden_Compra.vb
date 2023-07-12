'Imports System.IO
'Imports Microsoft.Office.Interop.Excel
'Imports Finisar.SQLite
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports Finisar.SQLite
Public Class Form_Orden_Compra
    Dim res, o As Integer
    Dim cod_p_rq, cod_p_rq2 As String
    Dim cod_fac, num_fac As String
    Public nom, nom_fondo, ruc_fondo, ruc, direc, dis_dep_prov, debe, haber, fecha, cod_crono, acciones, glosa, analitica, cuenta, nom_cuenta As String
    Public comi_des, igv_comides, sub_total, igv_total, total, porc_igv As Decimal
    Dim compara As String
    'variables publicas
    Public pase1, pase2, codigo, pase3, pase4, cod_sbc As String

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ' item()

        veri_itens_oc()
        item2()
        Button8.Enabled = False
    End Sub

    Public cod As Double
    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer
    Dim usu_gen, usu_rev, usu_aprob As String
    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button4.Enabled = True

    End Sub

    Private Sub dgv2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        pase2 = "oc"
        llenar_PRO()
    End Sub
    Dim xlibro As Microsoft.Office.Interop.Excel.Application
    Dim strRutaExcel As String
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable
    '-----------------------------------

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form_Reg_Prov_Clie.pase1 = "oc"
        Form_Reg_Prov_Clie.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form_Contacto_Proveedor.pase1 = "oc"
        Form_Contacto_Proveedor.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form_Reg_Usuario.pase1 = "oc"
        Form_Reg_Usuario.Show()
    End Sub

    Private Sub Form_Orden_Compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox14.Text = 0
        TextBox15.Text = 0
        TextBox16.Text = 0
        TextBox22.Text = 18
        accion = "guardar"
        porc_igv = TextBox22.Text / 100
    End Sub

    Private Sub llenar_PRO()
        Try
            sql = "select COD AS [CODIGO],ITEM, COD_RQ AS [CODIGO RQ] , NOM_PROD AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [MEDIDA], MARCA, COLOR, A_LIMA AS [ATENCION LIMA],CANT AS [CANTIDAD],STROK AS [STOCK],PRIORI AS [PRIORIDAD],OBS AS [OBSERVACION],FEC_REG AS [FECHA DE REGISTRO],ESTADO from P_REQUERIMIENTO WHERE COD_RQ='" + TextBox1.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "P_REQUERIMIENTO")
            dgv2.DataSource = ds
            dgv2.DataMember = "P_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Private Sub dgv2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellContentDoubleClick
        Try

            Select Case pase2
                Case "centro costo"
                    Dim selec As String = dgv2.Rows(dgv2.CurrentRow.Index).Cells(0).Value
                    sql = "select *from USUARIOS where  cod='" + selec + "'"
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
                    Dim selec As String = dgv2.Rows(dgv2.CurrentRow.Index).Cells(0).Value
                    sql = "select *from USUARIOS where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Nva_Salida.TextBox7.Text = dr(3)
                        form_ingreso_salida.TextBox7.Text = dr(3)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()

                Case "ingreso"
                    Dim selec As String = dgv2.Rows(dgv2.CurrentRow.Index).Cells(0).Value
                    sql = "select *from USUARIOS where  cod='" + selec + "'"
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
                Case "oc"
                    Dim selec As String = dgv2.Rows(dgv2.CurrentRow.Index).Cells(0).Value
                    If selec = cod_p_rq2 Then
                        MessageBox.Show("Item ya agregado a la lista", "WOCCU")
                    Else
                        Button8.Enabled = True
                        sql = "select *from P_REQUERIMIENTO where  cod='" + selec + "'"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        dr = com.ExecuteReader
                        If dr.Read Then
                            cod_p_rq = dr(0)
                            cod_p_rq2 = dr(0)
                            TextBox18.Text = dr(3)
                            TextBox15.Text = dr(9)
                        End If
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                        ' Me.Close()
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub
    Private Sub item()
        Dim j As Integer

        For j = 0 To 1000
            Dim linea As New ListViewItem(j)
            preg = MsgBox("Desea agregar el item en OC", vbYesNo)
            If preg = vbYes Then
                linea.SubItems.Add(TextBox15.Text)
                linea.SubItems.Add(TextBox18.Text)
                linea.SubItems.Add(TextBox14.Text)
                linea.SubItems.Add(TextBox16.Text)
                linea.SubItems.Add("PPPP")
                'linea.SubItems.Add(comi_des.ToString("#,#.00"))
                comi_des = TextBox16.Text
                sub_total += comi_des
                igv_total = (sub_total * 0.18)

                ListView1.Items.Add(linea)
                MessageBox.Show("Item Agregados", "")
                TextBox19.Text = sub_total
                TextBox20.Text = igv_total
                ' Dim st001 As Decimal = st.Text
                'Dim igv001 As Decimal = igv.Text
                total = sub_total + igv_total
                TextBox21.Text = total
            Else

                MessageBox.Show("No hay mas item, generar factura o cancelar factura", "Optima")
                'i = 0
                ' g = 0
                Exit For
            End If
        Next
        ' preg = MsgBox("Desea agregar el item para facturar", vbYesNo)
        ' If preg = vbYes Then
        'item()
        'MessageBox.Show("Item Agregados", "Optima")
        '
        ' st.Text = sub_total
        'igv.Text = igv_total
        'Dim st001 As Decimal = st.Text
        'Dim igv001 As Decimal = igv.Text
        '  total = st001 + igv001
        't.Text = total
        'Else
        'MessageBox.Show("Item no Agregados", "Optima")
        'i = 0
        'g = 0
        'End If

    End Sub

    Private Sub item2()
        Dim j As Integer


        Dim linea As New ListViewItem(j)
            preg = MsgBox("Desea agregar el item en OC", vbYesNo)
        If preg = vbYes Then

            linea.SubItems.Add(TextBox15.Text)
            linea.SubItems.Add(TextBox18.Text)
            linea.SubItems.Add(TextBox14.Text)
            linea.SubItems.Add(TextBox16.Text)
            linea.SubItems.Add("PPPP")

            'linea.SubItems.Add(comi_des.ToString("#,#.00"))
            comi_des = TextBox16.Text
            igv_comides = TextBox16.Text * porc_igv
            sub_total += comi_des
            igv_total = (sub_total * porc_igv)
            linea.SubItems.Add(igv_comides)
            ListView1.Items.Add(linea)
            MessageBox.Show("Item Agregados", "")
            TextBox19.Text = sub_total
            TextBox20.Text = igv_total
            ' Dim st001 As Decimal = st.Text
            'Dim igv001 As Decimal = igv.Text
            total = sub_total + igv_total
            TextBox21.Text = total
        Else

            MessageBox.Show("No hay mas item, generar factura o cancelar factura", "Optima")
            'i = 0
            ' g = 0

        End If

        ' preg = MsgBox("Desea agregar el item para facturar", vbYesNo)
        ' If preg = vbYes Then
        'item()
        'MessageBox.Show("Item Agregados", "Optima")
        '
        ' st.Text = sub_total
        'igv.Text = igv_total
        'Dim st001 As Decimal = st.Text
        'Dim igv001 As Decimal = igv.Text
        '  total = st001 + igv001
        't.Text = total
        'Else
        'MessageBox.Show("Item no Agregados", "Optima")
        'i = 0
        'g = 0
        'End If

    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress

    End Sub

    Private Sub TextBox14_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox14.KeyDown
        'Dim PU, CANT, TOT As Double
        'PU = TextBox14.Text
        'CANT = TextBox15.Text
        ' TOT = CANT * PU
        ' TextBox16.Text = TOT
        ' Button8.Enabled = True
    End Sub

    Private Sub TextBox14_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox14.KeyUp
        Dim PU, CANT, TOT As Double
        Try
            PU = TextBox14.Text
            CANT = TextBox15.Text
            TOT = CANT * PU
            TextBox16.Text = TOT
            'Button8.Enabled = True
        Catch ex As Exception

        End Try


    End Sub

    Private Sub veri_itens_oc()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")

        ' For o = 0 To ListView1.Items.Count - 1
        'buscar_copiar()
        'codigo = "USU0000001"
        'Dim NOM As String = ListView1.Items(o).SubItems(1).Text
        'Dim APE As String = ListView1.Items(o).SubItems(2).Text
        'Dim DNI As String = ListView1.Items(o).SubItems(3).Text
        'Dim CARGO As String = ListView1.Items(o).SubItems(4).Text
        'Dim FEC As Date = ListView1.Items(0).SubItems(5).Text
        'Dim CLAVE As String = ListView1.Items(o).SubItems(5).Text
        'Dim SEDE As String = ListView1.Items(o).SubItems(6).Text

        Try
                If accion = "guardar" Then

                sql = "select *from T_ORDEN_COMPRA_ITEMS where  COD_RQ_ITEM='" + cod_p_rq + "'"
                Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader

                    If dr.Read Then
                    'cod = dr(0)
                    MessageBox.Show("Los Datos ya Existen", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                    'sql = "INSERT INTO USUARIOS  VALUES ('" & codigo & "','" & NOM & "','" & APE & "','" & DNI & "','" & CARGO & "','" & CLAVE & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & SEDE & "')"
                    'Form_Reg_SRV_SQL.conectar()
                    'com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    'res = com.ExecuteNonQuery
                    'Form_Reg_SRV_SQL.conexion.Close()
                    MessageBox.Show(" Item puede ingresarse ", "")
                End If


                    'buscar_copiar()
                    'llenar_grid()
                    'facturas()
                    'fac_operacion_anx.Show()
                End If





            Catch ex As Exception

            End Try
        'Next
        '

    End Sub
End Class