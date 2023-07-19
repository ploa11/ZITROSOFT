Imports System.Drawing.Printing
'Imports System.Windows.Controls
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO
'Imports Microsoft.Office.Interop.Excel
Imports Finisar.SQLite
Imports System.Text
Imports System.Windows.Controls
Imports System.Windows.Documents

'Imports System.Windows.Controls

Public Class Form_Cotizacion
    'variables publicas
    Public pase1, pase2, pase3, pase4, CODIGO, NOM_ARCHIVO, moneda As String
    Dim res, o As Integer
    Dim cod_p_rq, cod_p_rq2 As String
    Dim cod_fac, num_fac, rest, rest_util As String
    Public nom, nom_fondo, ruc_fondo, ruc, direc, dis_dep_prov, debe, haber, fecha, cod_crono, acciones, glosa, analitica, cuenta, nom_cuenta As String
    Public comi_des, igv_comides, P_U, sub_total, igv_total, total, porc_igv, porc_util, utilidad, util_list, S, ST, U, UT, IG, IT As Decimal
    Dim compara As String
    Public cod As Double
    Dim nc As String
    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer
    'variables publicas
    Public cod_sbc As String

    'variables locales
    Dim COD_EQ_SERV, COD_EQ_SERV2 As String
    Dim xlibro As Microsoft.Office.Interop.Excel.Application
    Dim strRutaExcel As String

    Public COD_CLIENTE As String
    Dim usu_gen, usu_rev, usu_aprob As String
    Dim n_carp As String
    Dim j As Integer
    Dim printLine As Integer = 0
    Dim Contador As Integer = 0
    Dim PosicionSinEncabezado As Integer = Form_Imprimir_Coti.P1.Top

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "guardar"

        crea_coti()
        buscar_coti()
        GroupBox3.Enabled = True
        GroupBox5.Enabled = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        accion = "guardar"
        crea_itens_COTI()
        Button20.Enabled = True
        TOTALES()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox23.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        TextBox21.Text = ""
        'TextBox22.Text = ""
        LIMPIAR()
        GroupBox1.Enabled = True
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        'GroupBox4.Enabled = True
        Button2.Enabled = True
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        utilidad = 0
        igv_comides = 0
        'P_U = TextBox14.Text
        item3()
        'Button8.Enabled = False
        GroupBox5.Enabled = True
        CheckBox1.Checked = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form_Reg_Cliente.pase1 = "coti"
        Form_Reg_Cliente.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form_Reg_Usuario.pase1 = "COTI"
        Form_Reg_Usuario.Show()
        GroupBox2.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form_Contacto_Proveedor.pase1 = "COTI"
        Form_Contacto_Proveedor.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        NOM_ARCHIVO = "INTERNA"
        Try
            copiar_ruta1()
            GENERA_RQ()
            MessageBox.Show("COTIZACION " & TextBox23.Text & " CREADA ")
            MENSAJE()
            borrar()
        Catch ex As Exception

        End Try
        'copiar_ruta1()
        ' GENERA_RQ()
        ' copiar2()
        ' borrar()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            n_carp = UCase(TextBox23.Text)
            Process.Start("explorer.exe", (Form_Reg_SRV_SQL.NOM_CARP_COTI & n_carp))
        Catch ex As Exception
            MessageBox.Show("BUSQUE UN RQ PARA ABRIR SU CARPETA")
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        crear_carpeta()
        ' copiar2()
        'borrar()
        ' Button20.Enabled = False
        'Button11.Enabled = False
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        LIMPIAR()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Show()
        Form1.pase1 = "COTI"
        Form1.Label1.Visible = True
        Form1.Label2.Visible = False
        Form1.llenar_grid_LOGISTICA()
        Form1.RQ_SCC = "BUSCAR COTI"
    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        ACTUALIZAR()
        llenar_PRO_COTI()
        TOTALES()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        DataGridView1.Visible = False
        DataGridView1.Columns.Clear()
        ListView1.Visible = True
        ListView1.Items.Clear()
        GroupBox3.Enabled = True
        GroupBox1.Enabled = True
        GroupBox5.Enabled = True
        Button9.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        j = 0

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        NOM_ARCHIVO = "VENTA"
        copiar_ruta2()
        generar_cot_venta()
        MessageBox.Show("COTIZACION " & n_carp)
        'copiar2()
        'MessageBox.Show("BUSQUE LA COTIZACION EN LA CARPETA" & "  " & n_carp)
        MENSAJE()
        borrar()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Form1.Show()
        Form1.pase1 = "LOCAL"
        Form1.Label1.Visible = False
        Form1.Label2.Visible = False
        Form1.Label4.Visible = True
        Form1.llenar_grid_LOCAL()
        Form1.RQ_SCC = "LOCAL"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        DataGridView1.Enabled = True
        GroupBox5.Enabled = True
        Button15.Enabled = True
    End Sub



    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        ELEMINAR_COTI()
        ELIMINAR_ITEMS_COTI()
        MsgBox("COTIZACION Y ITEMS ELIMINADOS CORRECTAMENTE", MsgBoxStyle.Information, "COTIZACION")
        LIMPIAR()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim ITEM As System.Windows.Forms.ListViewItem
        Try
            If ListView1.SelectedItems.Count > 0 Then

                'Dim item As ListViewItem = ListView1.SelectedItems(0)
                ITEM = ListView1.SelectedItems(0)
                rest = ITEM.SubItems(14).Text
                rest_util = ITEM.SubItems(6).Text
                Me.ListView1.Items.Remove(ITEM)
                j -= 1
                ListView1.Items.Remove(ListView1.Items.Item(j))
            End If

            sub_total = sub_total - rest
            utilidad = utilidad - rest_util
            igv_total = (sub_total + utilidad) * porc_igv
            total = sub_total + utilidad + igv_total
            TextBox19.Text = sub_total
            TextBox25.Text = utilidad
            TextBox20.Text = igv_total
            TextBox21.Text = total
            If total < 0 Then
                MessageBox.Show("Montos en Cero", "ZITRO")
                sub_total = 0
                utilidad = 0
                igv_total = 0
                total = 0
                TextBox19.Text = sub_total
                TextBox25.Text = utilidad
                TextBox20.Text = igv_total
                TextBox21.Text = total
            End If

        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
            sub_total = 0
            utilidad = 0
            igv_total = 0
            total = 0
            TextBox19.Text = sub_total
            TextBox25.Text = utilidad
            TextBox20.Text = igv_total
            TextBox21.Text = total
        End Try

    End Sub

    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        ELIMINAR_ITEM_COTI()
        llenar_PRO_COTI()
        ACTUALIZAR()
        TOTALES()
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Try
            If CheckBox2.Checked = True Then
                moneda = "DOLARES"
            Else
                moneda = "SOLES"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles TextBox22.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        'Dim PU, CANT, TOT, TOT_SI As Double
        Dim CANT As Double
        Dim PU, UTIL, TOTAL, TOT, TOT_SI As Decimal
        Try
            If CheckBox1.Checked = True Then
                'PU = Val(TextBox14.Text)
                P_U = Val(TextBox14.Text) / 1.18
                CANT = Val(TextBox15.Text)
                porc_util = Val(TextBox26.Text) / 100
                UTIL = P_U * porc_util
                TOT_SI = CANT * (P_U + UTIL)
                TextBox16.Text = TOT_SI

                'Button8.Enabled = True
            Else
                P_U = Val(TextBox14.Text)
                CANT = Val(TextBox15.Text)
                porc_util = Val(TextBox26.Text) / 100
                UTIL = P_U * porc_util
                TOT = CANT * (P_U + UTIL)
                TextBox16.Text = Format("0.00", TOT)
                'Button8.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox26_TextChanged(sender As Object, e As EventArgs) Handles TextBox26.TextChanged

    End Sub

    Dim ds As DataSet

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        FILTRO()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        llenar_grid()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Form_List_Product.pase1 = "COTI"
        Form_List_Product.Show()
    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged

    End Sub

    Private Sub dgv2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellContentClick

    End Sub

    Private Sub PrintDocument4_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument4.PrintPage

    End Sub

    Dim dt As DataTable
    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click

    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        'printLine = 0
        ' Contador = 0
        'Form_Imprimir_Coti.lbNumeroPagina.Text = "0"
        SELECCION_COTIZACION.Show()
    End Sub

    Private Sub Form_Cotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' llenar_grid()
        j = 0
        TextBox22.Text = 18
        TextBox26.Text = 8
        TextBox27.Text = "UND"
        accion = "guardar"
        moneda = "SOLES"
        porc_igv = TextBox22.Text / 100
        porc_util = TextBox26.Text / 100
        'GroupBox1.Enabled = False
        'GroupBox2.Enabled = False
        'GroupBox3.Enabled = False
        'GroupBox5.Enabled = False
        'TextBox19.Enabled = False
        'TextBox20.Enabled = False
        ' TextBox21.Enabled = False
        ' Button9.Enabled = True
        'Button2.Enabled = False
        'DataGridView1.Enabled = False
        ' ListView1.Enabled = True
        ' Button15.Enabled = False
        'ListView1.View = View.Details
        ' ListView1.LabelEdit = True
        ' ListView1.AllowColumnReorder = True
        ListView1.GridLines = True
        DataGridView1.AllowUserToAddRows = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Form_List_Product.Show()
    End Sub

    Public Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],NOM_PRODUC  AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD] , T_EXIST AS [TIPO DE EXISTENCIA], MARCA AS [MARCA], COLOR AS [COLOR] from T_LIST_PRODUCTOS WHERE T_EXIST='" + ComboBox1.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_LIST_PRODUCTOS")
            dgv2.DataSource = ds
            dgv2.DataMember = "T_LIST_PRODUCTOS"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
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
                dgv2.DataSource = ds
                dgv2.DataMember = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS  where COD  like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "NOMBRE DE PRODUCTO"
                sql = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC  like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC like'" + TextBox6.Text + "%'")
                dgv2.DataSource = ds
                dgv2.DataMember = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "MARCA"
                sql = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [MEDIDA], MARCA, COLOR from T_LIST_PRODUCTOS where MARCA like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where MARCA like'" + TextBox6.Text + "%'")
                dgv2.DataSource = ds
                dgv2.DataMember = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where MARCA like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()
            Case "SERVICIO"
                sql = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [MEDIDA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC like'" + TextBox6.Text + "%'")
                dgv2.DataSource = ds
                dgv2.DataMember = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()
            Case "EQUIPO"
                sql = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [MEDIDA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC like'" + TextBox6.Text + "%'")
                dgv2.DataSource = ds
                dgv2.DataMember = "select  COD AS [CODIGO], NOM_PRODUC AS [NOMBRE DE PRODUCTO], UNID AS [UNIDAD], MEDID AS [TIPO DE EXISTENCIA], MARCA, COLOR from T_LIST_PRODUCTOS where NOM_PRODUC like'" + TextBox6.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()
        End Select


    End Sub




    Private Sub item2()

        j += 1



    End Sub

    Private Sub dgv2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellContentDoubleClick
        Try
            pase2 = "COTI"
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
                Case "COTI"
                    Dim selec As String = dgv2.Rows(dgv2.CurrentRow.Index).Cells(0).Value
                    If selec = COD_EQ_SERV Then
                        MessageBox.Show("Item ya agregado a la lista", "ZITRO")
                    Else
                        Button8.Enabled = True
                        sql = "select *from T_LIST_PRODUCTOS where  cod='" + selec + "'"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        dr = com.ExecuteReader
                        If dr.Read Then
                            COD_EQ_SERV2 = dr(0)
                            COD_EQ_SERV = dr(0)
                            TextBox18.Text = dr(1)
                            'TextBox15.Text = dr(9)
                        End If
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                        ' Me.Close()
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox14_StyleChanged(sender As Object, e As EventArgs) Handles TextBox14.StyleChanged

    End Sub

    Private Sub TextBox14_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox14.KeyUp
        Dim CANT As Double
        Dim PU, UTIL, TOTAL As Decimal
        Try
            P_U = Val(TextBox14.Text)
            'UTIL = P_U * porc_util
            CANT = Val(TextBox15.Text)
            porc_util = Val(TextBox26.Text) / 100
            UTIL = P_U * porc_util
            TOTAL = CANT * (P_U + UTIL)
            TextBox16.Text = Format("0.00", TOTAL)
            'Button8.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub crea_coti()
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

                sql = "select *from T_COTIZACION where  COD='" & TextBox23.Text & "'"
                Form_Reg_SRV_SQL.conectar()
                com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                dr = com.ExecuteReader

                If dr.Read Then
                    'cod = dr(0)
                    MessageBox.Show("Los Datos ya Existen", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                Else
                    buscar_copiar()
                    sql = "INSERT INTO T_COTIZACION  (COD,FEC_REG_COTI,RUC_CLIE,RAZ_SOC_CLIE,DIREC,NOM_CONT_CLIE,APE_CONT_CLIE,MAIL,NOM_US_SIS,APE_US_SIS,CARGO,MOTIVO,JUST_SELEC_CLIE,FEC_VENC_COTI,TIENDA,ubicacion,direccion,ot,moneda) VALUES('" & CODIGO & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox1.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox13.Text & "','" & TextBox12.Text & "','" & TextBox11.Text & "','" & TextBox17.Text & "','" & ComboBox2.Text & "','" & DateTimePicker2.Value.ToString("yyyyMMdd") & "','" & TextBox24.Text & "','" & TextBox8.Text & "','" & TextBox7.Text & "','" & TextBox5.Text & "','" & moneda & "')"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    res = com.ExecuteNonQuery
                    Form_Reg_SRV_SQL.conexion.Close()
                    MessageBox.Show(" COTIZACION  CREADA ", " ZITRO ")
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
    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "COTI"
        'Dim cod, serie As String
        sql = "select *from T_COTIZACION where id in (select max(id) from T_COTIZACION)"
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
            MessageBox.Show("Se generara Codigo", "ZITRO")
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        If cod = 0 Then
            cod = 0
            aum_cod = cod.ToString("00000000")
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            CODIGO = dat & (cod + 1).ToString("00000000")
        Else
            aum_cod = Microsoft.VisualBasic.Right(cod, 8)
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            CODIGO = dat & (cod + 1).ToString("00000000")
            't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
        End If


    End Sub

    Private Sub buscar_copiarCOTI()

        Dim aum_cod As String
        Dim dat As String = "ICOTI"
        'Dim cod, serie As String
        sql = "select *from T_COTI_ITEMS_NEW where id in (select max(id) from T_COTI_ITEMS_NEW)"
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
            'MessageBox.Show("Se generara Codigo", "ZITRO")
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        If cod = 0 Then
            cod = 0
            aum_cod = cod.ToString("00000000")
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            CODIGO = dat & (cod + 1).ToString("00000000")
        Else
            aum_cod = Microsoft.VisualBasic.Right(cod, 8)
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            CODIGO = dat & (cod + 1).ToString("00000000")
            't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
        End If


    End Sub
    Private Sub buscar_coti()
        'Dim aum_cod As String
        ' Dim dat As String = "RQ"
        'Dim cod, serie As String
        sql = "Select *from T_COTIZACION where id In (Select max(id) from T_COTIZACION)"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            TextBox23.Text = dr(0)
            DateTimePicker1.Value = dr(1)
            TextBox2.Text = dr(2)
            TextBox3.Text = dr(3)
            TextBox4.Text = dr(4)
            'TextBox5.Text = dr(5)
            'TextBox6.Text = dr(5)
            TextBox9.Text = dr(6)
            TextBox10.Text = dr(7)
            TextBox13.Text = dr(8)
            TextBox12.Text = dr(9)
            TextBox11.Text = dr(10)
            TextBox17.Text = dr(11)
            ComboBox2.Text = dr(12)
            DateTimePicker2.Value = dr(13)
            TextBox24.Text = dr(15)
            TextBox8.Text = dr(16)
            TextBox7.Text = dr(17)
            TextBox5.Text = dr(18)
            moneda = dr(19)
            ' TextBox1.Text = dr(15)


            'ComboBox4.Text = dr(13)
            '  Label18.Text = dr(14)
            ' Label19.Text = dr(15)
            ' Label20.Text = dr(16)
            ' ComboBox1.Text = dr(17)
            ' ComboBox5.Text = dr(18)
            ' ComboBox6.Text = dr(19)
            ' DateTimePicker2.Value = dr(21)
            ' DateTimePicker3.Value = dr(22)
            '   DateTimePicker4.Value = dr(23)

            'TextBox1.Text = dr(0)
            'dtp1.Value = dr(1)
            'cb1.Text = dr(2)
            't1.Text = dr(4)
            't2.Text = dr(7)
            't4.Text = dr(8)
            't5.Text = dr(9)
        Else
            MessageBox.Show("Error EN MOSTRAR DATOS", "ZITRO")
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        'If cod = 0 Then
        'cod = 0
        'aum_cod = cod.ToString("00000000")
        ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
        'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
        'serie = Microsoft.VisualBasic.Left(num_fac, 4)
        ' codigo = dat & (cod + 1).ToString("00000000")
        ' Else
        'aum_cod = Microsoft.VisualBasic.Right(cod, 8)
        ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
        'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
        'serie = Microsoft.VisualBasic.Left(num_fac, 4)
        'codigo = dat & (cod + 1).ToString("00000000")
        't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
        'End If
        If moneda = "DOLARES" Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

    End Sub

    Public Sub crea_itens_COTI()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")
        Try
            For o = 0 To ListView1.Items.Count - 1
                If accion = "guardar" Then
                    sql = "select *from T_COTI_ITEMS_NEW where  COD='" + ListView1.Items(o).SubItems(1).Text + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader


                    If dr.Read Then
                        MessageBox.Show("Los Datos ya Existen", "ZITRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        'MessageBox.Show("Los Datos ya Existen para variar", "ZITRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        buscar_copiarCOTI()
                        ' MessageBox.Show("Los Datos ya Existen para variar", CODIGO, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Dim COD As String = CODIGO
                        'MessageBox.Show("Los Datos ya Existen para variar", COD, MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Dim CANTIDAD As String = ListView1.Items(o).SubItems(1).Text
                        Dim DESCRIP As String = ListView1.Items(o).SubItems(2).Text
                        Dim UNDIDAD As String = ListView1.Items(o).SubItems(3).Text
                        Dim P_U As String = ListView1.Items(o).SubItems(4).Text
                        Dim IGV As String = ListView1.Items(o).SubItems(5).Text
                        Dim SUBTOTAL As String = ListView1.Items(o).SubItems(6).Text
                        Dim IGVTOTAL As String = ListView1.Items(o).SubItems(7).Text
                        Dim TOTAL As String = ListView1.Items(o).SubItems(8).Text
                        Dim POR_UTIL As String = ListView1.Items(o).SubItems(9).Text
                        Dim UTILIDAD As String = ListView1.Items(o).SubItems(10).Text
                        Dim PU_UTIL As String = ListView1.Items(o).SubItems(11).Text
                        Dim IGV_PU_UTIL As String = ListView1.Items(o).SubItems(12).Text
                        Dim SUB_TOTAL_UTIL As String = ListView1.Items(o).SubItems(13).Text
                        Dim IGV_TOTAL_UTIL As String = ListView1.Items(o).SubItems(14).Text
                        Dim TOTAL_UTIL As String = ListView1.Items(o).SubItems(15).Text
                        ' MessageBox.Show("Los Datos ya Existen para variar", TOTAL_UTIL, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'Dim PIO As String = ListView1.Items(o).SubItems(10).Text
                        'Dim OBS As String = ListView1.Items(o).SubItems(11).Text
                        ' Dim FEC As String = DateTimePicker5.Value.ToString("yyyyMMdd")
                        ' Dim EST As String = ListView1.Items(o).SubItems(13).Text

                        sql = "INSERT INTO T_COTI_ITEMS_NEW (COD,COD_COTI,CANTIDAD,DESCRIPCION,UND,P_U,IGV,SUB_TOTAL,IGV_TOTAL, TOTAL,POR_UTIL, UTILIDAD, PU_UTIL, IGV_PU_UTIL,SUBTOTAL_UTIL, IGV_TOTAL_UTIL, TOTOAL_UTIL, MONEDA, FEC_REG) VALUES('" & COD & "','" & UCase(TextBox23.Text) & "','" & CANTIDAD & "','" & UCase(DESCRIP) & "','" & UNDIDAD & "','" & P_U & "','" & IGV & "','" & SUBTOTAL & "','" & IGVTOTAL & "','" & TOTAL & "','" & POR_UTIL & "','" & UTILIDAD & "',' " & PU_UTIL & "','" & IGV_PU_UTIL & "','" & SUB_TOTAL_UTIL & "','" & IGV_TOTAL_UTIL & "','" & TOTAL_UTIL & "','" & moneda & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()


                        'MessageBox.Show("Registro Guardado", "ZITRO")
                        'buscar_copiar()
                        ' ListView1.Visible = False
                        'DataGridView1.Visible = True

                        'llenar_grid()
                        'facturas()
                        'fac_operacion_anx.Show()
                    End If


                End If
            Next
            llenar_PRO_COTI()
            ListView1.Visible = False
            DataGridView1.Visible = True
            MessageBox.Show("Registro Guardado", "ZITRO")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub buscar_copiarICOTI()
        Dim aum_cod As String
        Dim dat As String = "ICOTI"
        'Dim cod, serie As String
        sql = "select *from T_COTI_ITEMS where id in (select max(id) from T_COTI_ITEMS)"
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
            MessageBox.Show("Se generara Codigo", "ZITRO")
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        If cod = 0 Then
            cod = 0
            aum_cod = cod.ToString("00000000")
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            CODIGO = dat & (cod + 1).ToString("00000000")
        Else
            aum_cod = Microsoft.VisualBasic.Right(cod, 8)
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            CODIGO = dat & (cod + 1).ToString("00000000")
            't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
        End If
    End Sub
    Public Sub llenar_PRO_COTI()
        Try
            sql = "select *from T_COTI_ITEMS_NEW WHERE COD_COTI='" + TextBox23.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_COTI_ITEMS_NEW")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "T_COTI_ITEMS_NEW"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub
    Public Sub llenar_PRO_COTI_SCCO()
        Try
            sql = "select *from T_COTI_ITEMS_NEW WHERE COD_COTI='" + Form1.COD_COTI_SSC + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_COTI_ITEMS_NEW")
            Form_Reg_SCCOS.DataGridView1.DataSource = ds
            Form_Reg_SCCOS.DataGridView1.DataMember = "T_COTI_ITEMS_NEW"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Private Sub DateTimePicker2_Click(sender As Object, e As EventArgs) Handles DateTimePicker2.Click

    End Sub
    Private Sub copiar_ruta1()

        Try
            Dim ruta As String
            Dim copia As String

            'ruta = "\\server\SISTEMA\RUMISOFT2019\RUMISOFT\bin\Debug\formato\COTIZACION.xlsx"
            'copia = "\\server\SISTEMA\RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACION.xlsx"
            'ruta = "C:\SISTEMA ZITRO\RUMISOFT2019\RUMISOFT\bin\Debug\formato\COTIZACION.xlsx"
            'copia = "C:\SISTEMA ZITRO\RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACION.xlsx"
            ruta = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\formato\COTIZACION.xlsx"
            copia = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACION.xlsx"
            IO.File.Copy(ruta, copia)
            'MessageBox.Show("ARCHIVO CREADO")
        Catch ex As Exception
            'MessageBox.Show("Archivo ya Existe")
        End Try


    End Sub

    Public Sub GENERA_RQ()
        'El siguiente codigo es para crear la ruta,entre comillas se pone la ruta donde esta el libro
        Dim Ruta As String = Path.Combine(Directory.GetCurrentDirectory(), "COTIZACION.xlsx")
        Dim TotalCOTI As Double = 0
        Dim SUBTOTAL As Double = 0
        Dim IGV As Double = 0
        Dim UTIL_DOC_COTI As Double = 0
        strRutaExcel = Ruta
        Form_Reg_SRV_SQL.conectar()
        'El siguiente codigo es para abrir el libro y hacerlo visible, si se quiere dejar el libro oculto, se cambia la palabra True por False
        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)
        xlibro.Visible = True

        xlibro.Sheets("COTIZACION").Select() 'Nombre del libro
        'esta es la instruccion para modificar la celda con el contenido de un textbox llamado textbox1, ustedes le pueden poner el nombre que deseen al textbox
        xlibro.Range("K4").Value = TextBox23.Text
        xlibro.Range("C7").Value = UCase(DateTimePicker1.Text)
        xlibro.Range("C8").Value = UCase(TextBox3.Text)
        xlibro.Range("C9").Value = TextBox2.Text
        xlibro.Range("C10").Value = UCase(TextBox24.Text)
        xlibro.Range("C11").Value = UCase(TextBox8.Text)
        xlibro.Range("C12").Value = UCase(TextBox7.Text)
        xlibro.Range("C13").Value = UCase(TextBox5.Text)
        xlibro.Range("C14").Value = UCase(TextBox1.Text + " " + TextBox9.Text)
        xlibro.Range("C15").Value = UCase(TextBox17.Text)
        xlibro.Range("C16").Value = UCase(TextBox26.Text)
        xlibro.Range("B58").Value = UCase(TextBox13.Text + " " + TextBox12.Text)
        xlibro.Range("B59").Value = UCase(TextBox11.Text)
        xlibro.Range("B60").Value = UCase(DateTimePicker2.Text)
        ' xlibro.Range("E22").Value = t7.Text
        'xlibro.Range("E23").Value = t10.Text
        'xlibro.Range("H56").Value = nom_clie


        ''Cargamos las celdas con los datos de la base de datos
        'Dim Conexion As Finisar.SQLite.SQLiteConnection
        'Dim Adaptador As Finisar.SQLite.SQLiteDataAdapter

        'conexion = New Finisar.SQLite.SQLiteConnection
        'conexion.ConnectionString = "Data Source=abarrotes.db3;Version=3;"

        ' conexion.Open()

        'Dim ds As New DataSet
        'Adaptador = New Finisar.SQLite.SQLiteDataAdapter("select * from productos", Conexion)
        'Adaptador.Fill(ds)
        'Dim Conexion As SqlClient.SqlConnection
        Dim Adaptador As SqlClient.SqlDataAdapter

        'conexion = New SqlClient.SqlConnection
        'conexion.ConnectionString = "Data source = orcasoluciones; initial catalog = FO001; user id = sa; password = Orca2016"

        'conexion.Open()
        nc = TextBox23.Text
        Dim ds As New DataSet
        Adaptador = New SqlClient.SqlDataAdapter("select *from T_COTI_ITEMS where COD_COTI ='" + nc + "'", Form_Reg_SRV_SQL.conexion)
        Adaptador.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim fila As DataRow
            Dim ValorInicial As Integer = 24 ''Celda donde empezamos a insertar los articulos


            For Each fila In ds.Tables(0).Rows
                xlibro.Range("A" & ValorInicial).Value = fila("CANTIDAD")
                xlibro.Range("B" & ValorInicial).Value = fila("DESCRIP")
                xlibro.Range("G" & ValorInicial).Value = fila("PREC_UNIT")
                xlibro.Range("H" & ValorInicial).Value = fila("PREC_TOTAL")
                xlibro.Range("K" & ValorInicial).Value = fila("IGV")
                xlibro.Range("I" & ValorInicial).Value = fila("PORCEN_UTIL")
                xlibro.Range("J" & ValorInicial).Value = fila("UTILIDAD")
                xlibro.Range("F" & ValorInicial).Value = fila("UND")
                xlibro.Range("L" & ValorInicial).Value = fila("PREC_TOTAL") + fila("UTILIDAD") + fila("IGV")

                ' xlibro.Range("G" & ValorInicial).Value = fila("CUOTA TOTAL")
                ' xlibro.Range("H" & ValorInicial).Value = fila("FECHA DE INICIO")
                ' xlibro.Range("I" & ValorInicial).Value = fila("FECHA DE VENCIMIENTO")
                'xlibro.Range("J" & ValorInicial).Value = fila("DIAS DE CUOTA")


                SUBTOTAL = SUBTOTAL + (fila("PREC_TOTAL"))
                IGV = IGV + (fila("IGV"))
                UTIL_DOC_COTI = UTIL_DOC_COTI + (fila("UTILIDAD"))

                ' sql = "select COD AS [CODIGO],COD_COTI AS [CODIGO COTIZACION], CANTIDAD , DESCRIP AS [DESCRIPCION DE ITEM], PREC_UNIT AS [PRECIO UNITARIO], PREC_TOTAL AS [PRECIO TOTAL],IGV from T_COTI_ITEMS WHERE COD_COTI='" + TextBox23.Text + "'"

                ValorInicial += 1

            Next


        End If
        TotalCOTI = SUBTOTAL + IGV + UTIL_DOC_COTI
        xlibro.Range("L44").Value = SUBTOTAL
        xlibro.Range("L45").Value = UTIL_DOC_COTI
        xlibro.Range("L46").Value = IGV
        xlibro.Range("L47").Value = TotalCOTI
        Form_Reg_SRV_SQL.conexion.Close()
        xlibro.Workbooks.Close()
    End Sub

    Private Sub crear_carpeta()
        Try
            'n_carp = UCase(t2.Text) & UCase(t3.Text) & UCase(t4.Text) & UCase(t5.Text)
            'Directory.CreateDirectory("\\Nlim010pdom\SOFTFONDOINVERSION\CLIENTES\" & n_carp)
            't6.Text = "\\Nlim010pdom\SOFTFONDOINVERSION\CLIENTES\" & n_carp
            'Button8.Enabled = True
            n_carp = UCase(TextBox23.Text)
            '  Directory.CreateDirectory("e:\ORCA\PROGRAMACION\WOCCU\WOCCU\RQ\" & n_carp)
            'Directory.CreateDirectory("\\srvcoray\CORAY\SISTEMA ZITRO\COTI\" & n_carp)
            'Directory.CreateDirectory("\\srvcoray\CORAY\SISTEMA ZITRO\COTI\" & n_carp)
            Directory.CreateDirectory(Form_Reg_SRV_SQL.NOM_CARP_COTI & n_carp)
            't6.Text = "\\orcasoluciones\instalador_opinv\clientes\" & n_carp
            'Button8.Enabled = True
            MessageBox.Show("CARPETA CREADA" & " " & n_carp)
        Catch ex As Exception
            MessageBox.Show("No pudo crear carpeta")
        End Try

    End Sub
    Private Sub copiar2()
        Try
            Dim ruta As String
            Dim copia As String
            n_carp = UCase(TextBox23.Text)

            Select Case NOM_ARCHIVO
                Case "INTERNA"
                    ruta = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACION.xlsx"
                    copia = Form_Reg_SRV_SQL.NOM_CARP_COTI & n_carp & "\" & n_carp & ".xlsx"
                    IO.File.Copy(ruta, copia)
                    MessageBox.Show("COTIZACION INTERNA CREADA")
                Case "VENTA"
                    ruta = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACIONVENTA.xlsx"
                    copia = Form_Reg_SRV_SQL.NOM_CARP_COTI & n_carp & "\" & n_carp & "VENTA.xlsx"
                    IO.File.Copy(ruta, copia)
                    MessageBox.Show("COTIZACION DE VENTA CREADA")
            End Select


            'If NOM_ARCHIVO = "INTERNO" Then
            'ruta = "\\srvcoray\CORAY\SISTEMA ZITRO\RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACION.xlsx"
            'copia = "\\srvcoray\CORAY\SISTEMA ZITRO\COTI\" & n_carp & "\" & n_carp & ".xlsx"
            'IO.File.Copy(ruta, copia)
            'MessageBox.Show("CARPETA CREADA")
            ' Else
            'ruta = "\\srvcoray\CORAY\SISTEMA ZITRO\RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACIONVENTA.xlsx"
            'copia = "\\srvcoray\CORAY\SISTEMA ZITRO\COTI\" & n_carp & "\" & n_carp + "VENTA" & ".xlsx"
            'IO.File.Copy(ruta, copia)
            'sageBox.Show("CARPETA CREADA")
            'End If


        Catch ex As Exception
            MessageBox.Show("Carpeta ya Existe")
        End Try

    End Sub
    Private Sub borrar()
        Try
            Dim ArchivoBorrar As String
            Select Case NOM_ARCHIVO
                Case "INTERNA"
                    ArchivoBorrar = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACION.xlsx"
                    System.IO.File.Delete(ArchivoBorrar)
                Case "VENTA"
                    ArchivoBorrar = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACIONVENTA.xlsx"
                    System.IO.File.Delete(ArchivoBorrar)
            End Select
            ' If NOM_ARCHIVO = "INTERNA" Then
            'ArchivoBorrar = "\\srvcoray\CORAY\SISTEMA ZITRO\RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACION.xlsx"
            'System.IO.File.Delete(ArchivoBorrar)
            'Else
            'ArchivoBorrar = "\\srvcoray\CORAY\SISTEMA ZITRO\RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACIONVENTA.xlsx"
            'System.IO.File.Delete(ArchivoBorrar)
            ' End If

        Catch ex As Exception
            MessageBox.Show("Archivo no pudo ser borrado")
        End Try

    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs)

    End Sub
    Private Sub generar_cot_venta()
        'El siguiente codigo es para crear la ruta,entre comillas se pone la ruta donde esta el libro
        Dim Ruta As String = Path.Combine(Directory.GetCurrentDirectory(), "COTIZACIONVENTA.xlsx")
        Dim TotalCOTI As Double = 0
        Dim SUBTOTAL As Double = 0
        Dim IGV As Double = 0
        Dim UTIL_DOC_COTI As Double = 0
        strRutaExcel = Ruta
        Form_Reg_SRV_SQL.conectar()
        'El siguiente codigo es para abrir el libro y hacerlo visible, si se quiere dejar el libro oculto, se cambia la palabra True por False
        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)
        xlibro.Visible = True

        xlibro.Sheets("COTIZACION").Select() 'Nombre del libro
        'esta es la instruccion para modificar la celda con el contenido de un textbox llamado textbox1, ustedes le pueden poner el nombre que deseen al textbox
        xlibro.Range("K4").Value = TextBox23.Text
        xlibro.Range("C7").Value = UCase(DateTimePicker1.Text)
        xlibro.Range("C8").Value = UCase(TextBox3.Text)
        xlibro.Range("C9").Value = TextBox2.Text
        xlibro.Range("C10").Value = UCase(TextBox24.Text)
        xlibro.Range("C11").Value = UCase(TextBox8.Text)
        xlibro.Range("C12").Value = UCase(TextBox7.Text)
        xlibro.Range("C13").Value = UCase(TextBox5.Text)
        xlibro.Range("C14").Value = UCase(TextBox1.Text + " " + TextBox9.Text)
        xlibro.Range("C15").Value = UCase(TextBox17.Text)
        'xlibro.Range("C16").Value = UCase(TextBox26.Text)
        xlibro.Range("B58").Value = UCase(TextBox13.Text + " " + TextBox12.Text)
        xlibro.Range("B59").Value = UCase(TextBox11.Text)
        xlibro.Range("B60").Value = UCase(DateTimePicker2.Text)
        ' xlibro.Range("E22").Value = t7.Text
        'xlibro.Range("E23").Value = t10.Text
        'xlibro.Range("H56").Value = nom_clie


        ''Cargamos las celdas con los datos de la base de datos
        'Dim Conexion As Finisar.SQLite.SQLiteConnection
        'Dim Adaptador As Finisar.SQLite.SQLiteDataAdapter

        'conexion = New Finisar.SQLite.SQLiteConnection
        'conexion.ConnectionString = "Data Source=abarrotes.db3;Version=3;"

        ' conexion.Open()

        'Dim ds As New DataSet
        'Adaptador = New Finisar.SQLite.SQLiteDataAdapter("Select * from productos", Conexion)
        'Adaptador.Fill(ds)
        'Dim Conexion As SqlClient.SqlConnection
        Dim Adaptador As SqlClient.SqlDataAdapter

        'conexion = New SqlClient.SqlConnection
        'conexion.ConnectionString = "Data source = orcasoluciones; initial catalog = FO001; user id = sa; password = Orca2016"

        'conexion.Open()
        nc = TextBox23.Text
        Dim ds As New DataSet
        Adaptador = New SqlClient.SqlDataAdapter("Select *from T_COTI_ITEMS where COD_COTI ='" + nc + "'", Form_Reg_SRV_SQL.conexion)
        Adaptador.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim fila As DataRow
            Dim ValorInicial As Integer = 24 ''Celda donde empezamos a insertar los articulos


            For Each fila In ds.Tables(0).Rows
                xlibro.Range("A" & ValorInicial).Value = fila("CANTIDAD")
                xlibro.Range("B" & ValorInicial).Value = fila("DESCRIP")
                Dim UTIL As Double = (fila("PORCEN_UTIL") / 100)
                Dim UTIL_PUNIT As Double = (fila("PREC_UNIT") * UTIL)
                Dim P_UNIT_UTIL As Double = fila("PREC_UNIT") + UTIL_PUNIT
                xlibro.Range("G" & ValorInicial).Value = P_UNIT_UTIL 'fila("PREC_UNIT") + (fila("PREC_UNIT") * (fila("PORCEN_UTIL") * 100))
                Dim total As Double = P_UNIT_UTIL * fila("CANTIDAD")
                xlibro.Range("H" & ValorInicial).Value = total 'fila("PREC_TOTAL")
                Dim por_igv As Double = 18 / 100
                xlibro.Range("K" & ValorInicial).Value = total * por_igv 'fila("IGV")
                Dim igv_cot As Double = total * por_igv
                xlibro.Range("I" & ValorInicial).Value = 0 'fila("PORCEN_UTIL")
                xlibro.Range("J" & ValorInicial).Value = 0 'fila("UTILIDAD")
                xlibro.Range("F" & ValorInicial).Value = fila("UND")
                xlibro.Range("L" & ValorInicial).Value = total + igv_cot 'fila("PREC_TOTAL") + fila("UTILIDAD") + fila("IGV")

                ' xlibro.Range("G" & ValorInicial).Value = fila("CUOTA TOTAL")
                ' xlibro.Range("H" & ValorInicial).Value = fila("FECHA DE INICIO")
                ' xlibro.Range("I" & ValorInicial).Value = fila("FECHA DE VENCIMIENTO")
                'xlibro.Range("J" & ValorInicial).Value = fila("DIAS DE CUOTA")


                SUBTOTAL = SUBTOTAL + total '(fila("PREC_TOTAL"))
                IGV = IGV + igv_cot '(fila("IGV"))
                UTIL_DOC_COTI = 0 'UTIL_DOC_COTI + (fila("UTILIDAD"))

                ' sql = "select COD AS [CODIGO],COD_COTI AS [CODIGO COTIZACION], CANTIDAD , DESCRIP AS [DESCRIPCION DE ITEM], PREC_UNIT AS [PRECIO UNITARIO], PREC_TOTAL AS [PRECIO TOTAL],IGV from T_COTI_ITEMS WHERE COD_COTI='" + TextBox23.Text + "'"

                ValorInicial += 1

            Next


        End If
        TotalCOTI = SUBTOTAL + IGV '+ UTIL_DOC_COTI
        xlibro.Range("L44").Value = SUBTOTAL
        xlibro.Range("L45").Value = 0 '0UTIL_DOC_COTI
        xlibro.Range("L46").Value = IGV
        xlibro.Range("L47").Value = TotalCOTI
        Form_Reg_SRV_SQL.conexion.Close()
        xlibro.Workbooks.Close()
    End Sub
    Private Sub copiar_ruta2()

        Try
            Dim ruta As String
            Dim copia As String

            'ruta = "\\server\SISTEMA\RUMISOFT2019\RUMISOFT\bin\Debug\formato\COTIZACION.xlsx"
            'copia = "\\server\SISTEMA\RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACION.xlsx"
            ruta = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\formato\COTIZACIONVENTA.xlsx"
            copia = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACIONVENTA.xlsx"
            IO.File.Copy(ruta, copia)
            'MessageBox.Show("ARCHIVO CREADO")
        Catch ex As Exception
            'MessageBox.Show("Archivo ya Existe")
        End Try


    End Sub
    Sub MENSAJE()
        copiar2()
        MessageBox.Show("BUSQUE LA COTIZACION EN LA CARPETA   " & n_carp)
    End Sub
    Sub TOTALES()
        Dim cod_editar, cod_coti_editar, descrip_editar As String
        Dim st_local, util_local, igv_local, t_local, st_local2, util_local2, igv_local2, t_local2, st_venta, igv_venta, t_venta, st_venta2, igv_venta2, t_venta2 As Decimal
        accion = "guardar"
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            'cod_editar = Trim(DataGridView1.Rows(i).Cells(0).Value)
            'cod_coti_editar = Trim(DataGridView1.Rows(i).Cells(1).Value)
            'cant_EDITAR = (DataGridView1.Rows(i).Cells(2).Value)
            'descrip_editar = Trim(DataGridView1.Rows(i).Cells(3).Value)
            st_local = (DataGridView1.Rows(i).Cells(7).Value)
            igv_local = (DataGridView1.Rows(i).Cells(8).Value)
            util_local = (DataGridView1.Rows(i).Cells(11).Value)
            t_local = (DataGridView1.Rows(i).Cells(9).Value)
            st_venta = (DataGridView1.Rows(i).Cells(14).Value)
            igv_venta = (DataGridView1.Rows(i).Cells(15).Value)
            t_venta = (DataGridView1.Rows(i).Cells(16).Value)
            st_local2 += st_local
            igv_local2 += igv_local
            util_local2 += util_local
            t_local2 += t_local
            st_venta2 += st_venta
            igv_venta2 += igv_venta
            t_venta2 += t_venta

            'auxi_editar = MsgBox("¿ESTA SEGURO DE ACTUALIZAR ESTE REGISTRO?", MsgBoxStyle.YesNo, "ACTUALIZAR")


            'sql = "INSERT INTO T_COTI_ITEMS (COD, COD_COTI, CANTIDAD, DESCRIP, PREC_UNIT, PREC_TOTAL, IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
            ' sql = "UPDATE  T_COTI_ITEMS SET(CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
            ' sql = "UPDATE T_COTI_ITEMS SET CANTIDAD='" & UCase(cant_EDITAR) & "', DESCRIP= '" & UCase(descrip_editar) & "', PREC_UNIT='" & prec_unit_editar & "', PREC_TOTAL='" & prec_total_editar & "', IGV= '" & igv_editar & "' WHERE COD='" & cod_editar & "'"
            'Form_Reg_SRV_SQL.conectar()
            ' com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            ' res = com.ExecuteNonQuery
            ' Form_Reg_SRV_SQL.conexion.Close()
            ' Reg_SRV_SQL.conexion.Close()
            'Dim guardar As New MySQLDriverCS.MySQLCommand
            'guardar.Connection = cnn
            'guardar.CommandType = CommandType.StoredProcedure
            'guardar.CommandText = "UPDATE detalle_menu SET cod_comp='" & comp & "',ingredientes = '" & ingr & "', medida = '" & medi & "',cantidad='" & cant & "',precio = '" & prec & "' WHERE cod_comp='" & comp & "'"
            ' guardar.ExecuteNonQuery()

            ' MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")

            'Else
            'MsgBox("DATOS NO ACTUALIZADOS", MsgBoxStyle.Information, "ACTUALIZACION")
            'End If
        Next
        TextBox19.Text = Format("0.00", util_local2)
        TextBox25.Text = Format("0.00", st_local2)
        TextBox20.Text = Format("0.00", igv_venta2)
        TextBox21.Text = Format("0.00", t_venta2)
        TextBox28.Text = Format("0.00", st_venta2)
        TextBox29.Text = Format("0.00", igv_venta2)
        TextBox30.Text = Format("0.00", t_venta2)

        ' DataGridView1.Enabled = False
        ' MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")
        ' Button15.Enabled = False
    End Sub
    Sub ACTUALIZAR()
        'Dim auxi_editar As String
        Dim cod_editar, cod_coti_editar, descrip_editar, unidad As String
        Dim cant_editar, por_util, por_igv As Integer
        Dim st_local, util_local, igv_local, t_local, st_local2, util_local2, igv_local2, t_local2, st_venta, igv_venta, t_venta, st_venta2, igv_venta2, t_venta2, p_u_editar, p_u_util_editar, igv_pu_util_edit, igv_total_util_pu, util_total As Decimal
        accion = "guardar"
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            cod_editar = Trim(DataGridView1.Rows(i).Cells(0).Value)
            cod_coti_editar = Trim(DataGridView1.Rows(i).Cells(1).Value)
            cant_editar = (DataGridView1.Rows(i).Cells(2).Value)
            descrip_editar = Trim(DataGridView1.Rows(i).Cells(3).Value)
            p_u_editar = (DataGridView1.Rows(i).Cells(5).Value)
            por_util = (DataGridView1.Rows(i).Cells(10).Value)
            ' por_igv = (DataGridView1.Rows(i).Cells(6).Value)
            unidad = (DataGridView1.Rows(i).Cells(4).Value)
            'por_igv = 18 / 100
            st_local = p_u_editar * cant_editar '(DataGridView1.Rows(i).Cells(5).Value)
            igv_local = p_u_editar * porc_igv
            igv_total = igv_local * cant_editar
            t_local = st_local + igv_total
            util_local = (p_u_editar * (por_util / 100))
            util_total = util_local * cant_editar
            p_u_util_editar = (p_u_editar + util_local)
            st_venta = p_u_util_editar * cant_editar
            igv_pu_util_edit = p_u_util_editar * porc_igv
            igv_total_util_pu = igv_pu_util_edit * cant_editar
            t_venta = st_venta + igv_total_util_pu

            'POR_UTIL_VALOR = prec_total_editar * (POR_UTIL / 100)
            ' UTIL_ACT = prec_total_editar * (POR_UTIL / 100)
            'igv_editar = (prec_total_editar + UTIL_ACT) * 0.18 '(DataGridView1.Rows(i).Cells(6).Value)
            ' UND = (DataGridView1.Rows(i).Cells(9).Value)

            'auxi_editar = MsgBox("¿ESTA SEGURO DE ACTUALIZAR ESTE REGISTRO?", MsgBoxStyle.YesNo, "ACTUALIZAR")


            'sql = "INSERT INTO T_COTI_ITEMS (COD, COD_COTI, CANTIDAD, DESCRIP, PREC_UNIT, PREC_TOTAL, IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
            ' sql = "UPDATE  T_COTI_ITEMS SET(CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
            sql = "UPDATE T_COTI_ITEMS_NEW SET CANTIDAD='" & UCase(cant_editar) & "', DESCRIPCION='" & descrip_editar & "',  UND='" & unidad & "', P_U='" & p_u_editar & "', IGV= '" & igv_local & "', SUB_TOTAL='" & st_local & "', IGV_TOTAL='" & igv_total & "', TOTAL='" & t_local & "', POR_UTIL='" & por_util & "' , UTILIDAD='" & util_total & "' , PU_UTIL='" & p_u_util_editar & "' , IGV_PU_UTIL='" & igv_pu_util_edit & "', SUBTOTAL_UTIL='" & st_venta & "' , IGV_TOTAL_UTIL='" & igv_total_util_pu & "', TOTOAL_UTIL='" & t_venta & "' WHERE COD='" & cod_editar & "'"
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            res = com.ExecuteNonQuery
            Form_Reg_SRV_SQL.conexion.Close()
            ' Reg_SRV_SQL.conexion.Close()
            'Dim guardar As New MySQLDriverCS.MySQLCommand
            'guardar.Connection = cnn
            'guardar.CommandType = CommandType.StoredProcedure
            'guardar.CommandText = "UPDATE detalle_menu SET cod_comp='" & comp & "',ingredientes = '" & ingr & "', medida = '" & medi & "',cantidad='" & cant & "',precio = '" & prec & "' WHERE cod_comp='" & comp & "'"
            ' guardar.ExecuteNonQuery()

            ' MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")

            'Else
            'MsgBox("DATOS NO ACTUALIZADOS", MsgBoxStyle.Information, "ACTUALIZACION")
            'End If
        Next
        'DataGridView1.Enabled = False
        MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")
        ' Button15.Enabled = False
    End Sub
    Sub ELEMINAR_COTI()
        Dim selec As String = TextBox23.Text
        sql = "DELETE from T_COTIZACION where  COD='" + selec + "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader

        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
    End Sub
    Sub ELIMINAR_ITEMS_COTI()
        Dim selec As String = TextBox23.Text
        sql = "DELETE from T_COTI_ITEMS_NEW where  COD_COTI='" + selec + "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader

        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
    End Sub
    Sub ELIMINAR_ITEM_COTI()
        Dim selec As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        sql = "DELETE from T_COTI_ITEMS_NEW where  COD='" + selec + "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader

        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
    End Sub
    Sub LIMPIAR()
        DataGridView1.Visible = False
        ListView1.Visible = True
        ListView1.Items.Clear()
        DataGridView1.Columns.Clear()
        dgv2.Columns.Clear()
        ' dgv2.ClearSelection()
        ' DataGridView1.ClearSelection()
        TextBox23.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = 0
        TextBox15.Text = 0
        TextBox16.Text = 0
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        TextBox21.Text = ""
        'TextBox22.Text = ""
        Button2.Enabled = False
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        GroupBox5.Enabled = False
        'sub_total = 0
        'igv_total = 0
        'total = 0
    End Sub

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged

    End Sub

    Private Sub TextBox22_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox22.KeyPress
        '  e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
        'If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
        ' MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
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

    Private Sub TextBox26_TabIndexChanged(sender As Object, e As EventArgs) Handles TextBox26.TabIndexChanged

    End Sub

    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
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

    Private Sub TextBox26_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox26.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
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

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
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

    Private Sub TextBox16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox16.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
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

    Public Sub condicion(sender As TextBox, e As KeyPressEventArgs)

        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"

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
        End If


    End Sub

    Private Sub TextBox15_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox15.KeyUp

    End Sub

    Sub llenar_form_imprimir()
        Dim cod_editar, cod_oc_editar, cod_rq_editar, cod_cc_editar, cod_scc_editar, descrip_editar As String
        Dim cant_EDITAR, prec_unit_editar, prec_total_editar, igv_editar As Integer
        accion = "guardar"
        Form_Imprimir_Coti.sres.Text = TextBox3.Text
        Form_Imprimir_Coti.ruc.Text = TextBox2.Text
        Form_Imprimir_Coti.direcc.Text = TextBox4.Text
        Form_Imprimir_Coti.telefono.Text = ""
        Form_Imprimir_Coti.fec_emision.Text = UCase(DateTimePicker1.Text)
        Form_Imprimir_Coti.CONTACTO.Text = TextBox1.Text + " " + TextBox9.Text
        Form_Imprimir_Coti.USUARIO.Text = TextBox13.Text + " " + TextBox12.Text
        Form_Imprimir_Coti.UTIL.Text = TextBox26.Text
        Form_Imprimir_Coti.f_venc.Text = UCase(DateTimePicker2.Text)
        Form_Imprimir_Coti.oc.Text = TextBox23.Text
        Form_Imprimir_Coti.OT.Text = TextBox7.Text
        Form_Imprimir_Coti.LOCAL.Text = TextBox24.Text
        Form_Imprimir_Coti.UBI_LOCAL.Text = TextBox8.Text
        Form_Imprimir_Coti.DIR_LOCAL.Text = TextBox7.Text
        Try
            sql = "select *from T_COTI_ITEMS_NEW WHERE COD_COTI='" + TextBox23.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_COTI_ITEMS_NEW")
            Form_Imprimir_Coti.DataGridView1.DataSource = ds
            Form_Imprimir_Coti.DataGridView1.DataMember = "T_COTI_ITEMS_NEW"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try
        ' For i As Integer = 0 To DataGridView1.Rows.Count - 1
        'cod_editar = Trim(DataGridView1.Rows(i).Cells(0).Value)
        'cod_oc_editar = Trim(DataGridView1.Rows(i).Cells(1).Value)
        'cod_rq_editar = Trim(DataGridView1.Rows(i).Cells(2).Value)
        'cod_cc_editar = Trim(DataGridView1.Rows(i).Cells(3).Value)
        'cod_scc_editar = Trim(DataGridView1.Rows(i).Cells(4).Value)
        'cant_EDITAR = (DataGridView1.Rows(i).Cells(5).Value)
        'descrip_editar = Trim(DataGridView1.Rows(i).Cells(6).Value)
        'prec_unit_editar = (DataGridView1.Rows(i).Cells(7).Value)
        'prec_total_editar = prec_unit_editar * cant_EDITAR
        'igv_editar = prec_total_editar * 0.18


        'auxi_editar = MsgBox("¿ESTA SEGURO DE ACTUALIZAR ESTE REGISTRO?", MsgBoxStyle.YesNo, "ACTUALIZAR")


        'sql = "INSERT INTO T_COTI_ITEMS (COD,COD_COTI,CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
        ' sql = "UPDATE  T_COTI_ITEMS SET(CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
        'sql = "UPDATE T_OC_ITEMS SET CANTIDAD='" & UCase(cant_EDITAR) & "', DESCRIP= '" & UCase(descrip_editar) & "', PREC_UNIT='" & prec_unit_editar & "', PREC_TOTAL='" & prec_total_editar & "', IGV= '" & igv_editar & "' WHERE COD='" & cod_editar & "'"
        ' Form_Reg_SRV_SQL.conectar()
        ' com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        ' res = com.ExecuteNonQuery
        ' Form_Reg_SRV_SQL.conexion.Close()
        ' Reg_SRV_SQL.conexion.Close()
        'Dim guardar As New MySQLDriverCS.MySQLCommand
        'guardar.Connection = cnn
        'guardar.CommandType = CommandType.StoredProcedure
        'guardar.CommandText = "UPDATE detalle_menu SET cod_comp='" & comp & "',ingredientes = '" & ingr & "', medida = '" & medi & "',cantidad='" & cant & "',precio = '" & prec & "' WHERE cod_comp='" & comp & "'"
        ' guardar.ExecuteNonQuery()

        ' MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")

        'Else
        'MsgBox("DATOS NO ACTUALIZADOS", MsgBoxStyle.Information, "ACTUALIZACION")
        'End If
        'Next
        ' DataGridView1.Enabled = False
        ' MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")
        'Button17.Enabled = False
        ' llenar_PRO_OC()
        'Form_Imprimir_Coti.Show()
    End Sub
    Private Sub item3()
        Dim IGV_ITEM, IGV_TOTAL_ITEM, SUBTOTAL_ITEM, TOTAL_ITEM, UTIL_TOTAL, MONT_UTIL, IGV_UTIL, SUB_TOTAL_UTIL, IGV_TOT_UTIL, TOTAL_UTIL_ITEM As Decimal
        Dim CANT_ITEM As Integer
        j += 1
        Dim ITEM_I As String
        ITEM_I = j
        CANT_ITEM = TextBox15.Text
        Dim linea As System.Windows.Forms.ListViewItem

        preg = MsgBox("Desea agregar el item en COTIZACION", vbYesNo)
        Try
            If preg = vbYes Then

                linea = ListView1.Items.Add(ITEM_I, j)
                linea.SubItems.Add(TextBox15.Text)
                linea.SubItems.Add(TextBox18.Text)
                linea.SubItems.Add(TextBox27.Text)
                linea.SubItems.Add(Format(P_U, "0.00"))
                IGV_ITEM = P_U * porc_igv
                SUBTOTAL_ITEM = P_U * CANT_ITEM
                IGV_TOTAL_ITEM = IGV_ITEM * CANT_ITEM
                TOTAL_ITEM = SUBTOTAL_ITEM + IGV_TOTAL_ITEM
                linea.SubItems.Add(Format(IGV_ITEM, "0.00"))
                linea.SubItems.Add(Format(SUBTOTAL_ITEM, "0.00"))
                linea.SubItems.Add(Format(IGV_TOTAL_ITEM, "0.00"))
                linea.SubItems.Add(Format(TOTAL_ITEM, "0.00"))
                linea.SubItems.Add(TextBox26.Text)
                MONT_UTIL = (SUBTOTAL_ITEM * porc_util)
                'UTIL_TOTAL = MONT_UTIL * CANT_ITEM
                linea.SubItems.Add(Format(MONT_UTIL, "0.00"))
                linea.SubItems.Add(Format(P_U + (P_U * porc_util), "0.00"))
                IGV_UTIL = (P_U + (P_U * porc_util)) * porc_igv
                linea.SubItems.Add(Format(IGV_UTIL, "0.00"))
                SUB_TOTAL_UTIL = (P_U + (P_U * porc_util)) * CANT_ITEM
                linea.SubItems.Add(Format(SUB_TOTAL_UTIL, "0.00"))
                IGV_TOT_UTIL = IGV_UTIL * CANT_ITEM
                linea.SubItems.Add(Format(IGV_TOT_UTIL, "0.00"))
                TOTAL_UTIL_ITEM = SUB_TOTAL_UTIL + IGV_TOT_UTIL
                linea.SubItems.Add(Format(TOTAL_UTIL_ITEM, "0.00"))
                linea.SubItems.Add(moneda)
                S = SUBTOTAL_ITEM
                U = MONT_UTIL
                IG = IGV_UTIL * CANT_ITEM

                ' ListView1.Items.Add(j)

                ' TextBox25.Text += (MONT_UTIL * CANT_ITEM)
                ' TextBox20.Text += IGV_TOT_UTIL
                ' TextBox21.Text += TOTAL_UTIL_ITEM
                'comi_des = TextBox16.Text
                ' igv_comides = TextBox16.Text * porc_igv
                'sub_total += comi_des
                'util_list = TextBox16.Text * porc_util
                ' utilidad += sub_total * porc_util
                ' igv_comides = (TextBox16.Text + util_list) * porc_igv
                ' igv_total = ((sub_total + utilidad) * porc_igv)
                ' igv_total += igv_comides
            Else

                MessageBox.Show("No hay mas item, generar factura o cancelar factura", "ZITRO")

            End If
            ST += S
            UT += U
            IT += IG
            TextBox19.Text = Format("0.00", UT)
            TextBox25.Text = Format("0.00", ST)
            TextBox20.Text = Format("0.00", IT)
            TextBox21.Text = Format("0.00", ST + UT + IT)
        Catch ex As Exception

        End Try

    End Sub
End Class