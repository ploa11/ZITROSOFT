Imports System.Drawing.Printing
'Imports System.IO
'Imports Microsoft.Office.Interop.Excel
'Imports Finisar.SQLite
Imports System.IO
'mports Microsoft.Office.Interop.Excel
'Imports System.Windows.FontCapitals
Imports Finisar.SQLite
Imports System.Runtime.InteropServices.ComTypes
'Imports System.Windows
'Imports System.Windows.Media
'Imports System.Windows.Controls
'Imports System.Windows.Controls
'Imports System.Windows.Controls
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form_Orden_Compra
    Dim res, o As Integer
    Dim cod_p_rq, cod_p_rq2 As String
    Dim cod_fac, num_fac As String
    Public nom, nom_fondo, ruc_fondo, ruc, direc, dis_dep_prov, debe, haber, fecha, cod_crono, acciones, glosa, analitica, cuenta, nom_cuenta, moneda, obs, t_venta, f_pago As String
    Public comi_des, igv_comides, sub_total, igv_total, total, porc_igv As Decimal
    Dim compara As String
    Dim nc, UND As String
    Dim rest, rest_util As String
    Public porc_util, utilidad, util_list As Decimal
    'variables publicas
    Public pase1, pase2, codigo, pase3, pase4, cod_sbc As String
    Dim n_carp As String
    Dim j As Integer
    Dim grafo1, grafo2 As Graphics
    Dim grafoprint As Bitmap
    Dim printLine As Integer = 0
    Dim Contador As Integer = 0
    Dim PosicionSinEncabezado As Integer = Form_Impresion_OC.P1.Top

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Label1.Visible = False
        Form1.Label2.Visible = True
        Form1.llenar_grid_SISTEMAS()
        Form1.pase1 = "OC"
        Form1.RQ_SCC = "BUSCAR OC"
        Form1.Show()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form_rev_rq.busq = "OC"
        Form_rev_rq.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        accion = "guardar"
        crea_itens_oc()
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ' item()

        'crea_itens_oc()
        item2()
        'Button8.Enabled = False
        GroupBox5.Enabled = True
    End Sub

    Public cod As Double
    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer

    Private Sub TextBox22_TextChanged(sender As Object, e As EventArgs) Handles TextBox22.TextChanged

    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        copiar_ruta1()
        GENERA_OC()
    End Sub

    Dim usu_gen, usu_rev, usu_aprob As String

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        crear_carpeta()
        copiar2()
        borrar()
    End Sub
    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            n_carp = UCase(TextBox23.Text)
            Process.Start("explorer.exe", (Form_Reg_SRV_SQL.NOM_CARP_OC & n_carp))
        Catch ex As Exception
            'MessageBox.Show("BUSQUE UN RQ PARA ABRIR SU CARPETA")
        End Try
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        GroupBox2.Enabled = True
        ' GroupBox3.Enabled = False
        LIMPIAR()
        GroupBox1.Enabled = True
        TextBox25.Enabled = False
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Button2.Enabled = True
        GroupBox3.Enabled = True
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        DataGridView1.Enabled = True
        Button17.Enabled = True
        GroupBox1.Enabled = True
        GroupBox5.Enabled = True
        GroupBox2.Enabled = True
        'TextBox23.Text = ""
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
        Button19.Visible = False
        Button19.Enabled = False
        Button23.Enabled = True
        TextBox25.Enabled = True
        ComboBox1.Enabled = True
        ComboBox3.Enabled = True

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Form_rev_rq.RQ_SCC = "BUSCAR SCC"
        Form_rev_rq.busq = "SCC"
        Form_rev_rq.Show()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        actualizar()
        totales()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Try
            If ListView1.SelectedItems.Count > 0 Then

                Dim item As ListViewItem = ListView1.SelectedItems(0)

                rest = item.SubItems(5).Text
                'rest_util = item.SubItems(6).Text
                Me.ListView1.Items.Remove(item)
                ' ListView1.Items.Remove(ListView1.Items.Item(j))
            End If

            sub_total = sub_total - rest
            ' utilidad = utilidad - rest_util
            igv_total = sub_total * porc_igv
            total = sub_total + igv_total
            TextBox19.Text = sub_total
            'TextBox25.Text = utilidad
            TextBox20.Text = igv_total
            TextBox21.Text = total
            If total < 0 Then
                MessageBox.Show("Montos en Cero", "ZITRO")
                sub_total = 0
                'utilidad = 0
                igv_total = 0
                total = 0
                TextBox19.Text = sub_total
                'TextBox25.Text = utilidad
                TextBox20.Text = igv_total
                TextBox21.Text = total
            End If
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
            sub_total = 0
            'utilidad = 0
            igv_total = 0
            total = 0
            TextBox19.Text = sub_total
            'TextBox25.Text = utilidad
            TextBox20.Text = igv_total
            TextBox21.Text = total
        End Try
        'ListView1.Items.Remove(ListView1.Items.Item(j))

    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        DataGridView1.Enabled = True
        Button17.Enabled = True
        GroupBox1.Enabled = True
        GroupBox5.Enabled = True
        GroupBox2.Enabled = True
        TextBox23.Text = ""
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
        Button19.Visible = True
        Button19.Enabled = True
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click

        accion = "guardar"
        crea_oc()
        buscar_oc()
        Try
            'Dim cod_editar, cod_oc_editar, cod_rq_editar, cod_cc_editar, cod_scc_editar, descrip_editar As String
            ' Dim cant_EDITAR, prec_unit_editar, prec_total_editar, igv_editar As Integer
            'accion = "guardar"
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                'cod_editar = Trim(DataGridView1.Rows(i).Cells(0).Value)
                ' cod_oc_editar = Trim(DataGridView1.Rows(i).Cells(1).Value)
                'cod_rq_editar = Trim(DataGridView1.Rows(i).Cells(2).Value)
                'cod_cc_editar = Trim(DataGridView1.Rows(i).Cells(3).Value)
                ' cod_scc_editar = Trim(DataGridView1.Rows(i).Cells(4).Value)
                ' cant_EDITAR = (DataGridView1.Rows(i).Cells(5).Value)
                ' descrip_editar = Trim(DataGridView1.Rows(i).Cells(6).Value)
                ' prec_unit_editar = (DataGridView1.Rows(i).Cells(7).Value)
                ' prec_total_editar = (DataGridView1.Rows(i).Cells(8).Value)
                ' igv_editar = (DataGridView1.Rows(i).Cells(9).Value)
                ''

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
                If accion = "guardar" Then
                    sql = "select *from T_OC_ITEMS where  COD='" + (DataGridView1.Rows(i).Cells(1).Value) + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        MessageBox.Show("Los Datos ya Existen", "ZITRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        buscar_copiarIOC()
                        Dim COD As String = codigo
                        Dim COD_OC As String = TextBox23.Text
                        Dim COD_RQ As String = TextBox1.Text
                        Dim COD_CC As String = TextBox7.Text
                        Dim COD_SCC As String = TextBox8.Text
                        Dim CANTIDAD As String = (DataGridView1.Rows(i).Cells(5).Value)
                        Dim DESCRIP As String = Trim(DataGridView1.Rows(i).Cells(6).Value)
                        Dim PREC_UNIT As String = (DataGridView1.Rows(i).Cells(7).Value)
                        Dim PREC_TOTAL As String = (DataGridView1.Rows(i).Cells(8).Value)
                        Dim IGV As String = (DataGridView1.Rows(i).Cells(9).Value)
                        Dim UNIDAD As String = Trim(DataGridView1.Rows(i).Cells(10).Value)
                        'Dim PIO As String = ListView1.Items(o).SubItems(10).Text
                        'Dim OBS As String = ListView1.Items(o).SubItems(11).Text
                        ' Dim FEC As String = DateTimePicker5.Value.ToString("yyyyMMdd")
                        ' Dim EST As String = ListView1.Items(o).SubItems(13).Text

                        sql = "INSERT INTO T_OC_ITEMS (COD,COD_OC,COD_RQ,COD_CC,COD_SCC,CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV,UND) VALUES('" & COD & "','" & COD_OC & "','" & COD_RQ & "','" & COD_CC & "','" & COD_SCC & "','" & CANTIDAD & "','" & DESCRIP & "','" & PREC_UNIT & "','" & PREC_TOTAL & "','" & IGV & "','" & UNIDAD & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()


                        MessageBox.Show("Registro Guardado", "ZITRO")
                        'buscar_copiar()
                        ListView1.Visible = False
                        DataGridView1.Visible = True

                        'llenar_grid()
                        'facturas()
                        'fac_operacion_anx.Show()
                    End If
                    ' MsgBox("DATOS NO GRABADOS", MsgBoxStyle.Information, "ORDEN REFERENTE")

                End If
            Next
            'DataGridView1.Enabled = False
            ' MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")
            ' Button17.Enabled = False
            llenar_PRO_OC()
            Button9.Enabled = False
            Button11.Enabled = True
            Button12.Enabled = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        LIMPIAR()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button4.Enabled = True
        accion = "guardar"
        crea_oc()
        buscar_oc()
        GroupBox3.Enabled = True
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Try
            ELEMINAR_OC()
            ELIMINAR_ITEMS_OC()
            MessageBox.Show("OC Y ITEMS ELIMINADO", "ZITRO")
            LIMPIAR()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Try
            ELIMINAR_ITEM_OC()
            MessageBox.Show("ITEM DE OC ELIMINADO", "ZITRO")
            llenar_PRO_OC()
            totales()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
        Try
            If CheckBox2.Checked = True Then
                moneda = "DOLARES"
            Else
                moneda = "SOLES"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim PU, CANT, TOT, TOT_SI As Double
        Try
            If CheckBox1.Checked = True Then
                PU = Val(TextBox14.Text) / 1.18
                CANT = Val(TextBox15.Text)
                TOT_SI = CANT * PU
                TextBox16.Text = TOT_SI
                'Button8.Enabled = True
            Else
                PU = Val(TextBox14.Text)
                CANT = Val(TextBox15.Text)
                TOT = CANT * PU
                TextBox16.Text = TOT
                'Button8.Enabled = True
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub dgv2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv2.CellContentClick

    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged

    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs)
        Dim MYPRINTER
        MYPRINTER = "PRUEBA DE IMPRESION"
        Debug.Print(MYPRINTER)
    End Sub

    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged

    End Sub

    Private Sub Button24_Click_1(sender As Object, e As EventArgs) Handles Button24.Click
        printLine = 0
        Contador = 0
        Form_Impresion_OC.lbNumeroPagina.Text = "0"
        llenar_form_imprimir()
        ' Form_Impresion_OC.Show()
        'llenar_PRO_OC_imprimir()
        'grafo1 = CreateGraphics()
        ' grafoprint = New Bitmap(Size.Width, Size.Height, grafo1)
        ' grafo2 = Graphics.FromImage(grafoprint)
        ' grafo2.CopyFromScreen(Location.X, Location.Y, 0, 0, Size)
        ' PrintPreviewDialog1.Show()
        'llenar_PRO_OC_imprimir()
        'Form_Impresion_OC.Show()
        PrintPreviewDialog1.Document = PrintDocument4
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintPreviewDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(grafoprint, 0, 0)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        pase2 = "oc"
        llenar_PRO()
    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument2.PrintPage
        'Cualquier variable que desees que conserve su valor debes declararla fuera del Printdocument
        'Todas las variable declaradas dentro de printdocument pierden su valor al cambiar de pagina



        'Definimos los tipos de letras a utilizar en el reporte
        '--------------------------------------------------------------------------------------------------------------------
        Dim FuenteTitulo As New Font("Microsoft Sans Serif", 9)
        Dim FuenteSubtitulo As New Font("Microsoft Sans Serif", 9)
        Dim FuenteNegrita As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        Dim FuenteDetalles As New Font("Microsoft Sans Serif", 9)
        Dim SUBTOTAL_OC, IGV_OC, TOTAL_OC As Integer
        Dim CONSIDERACIONES As String

        'Si deseamos poner un contador de páginas
        'Esta parte siempre va a salir en todas las paginas
        '---------------------------------------------------------------------------------------------
        Form_Impresion_OC.lbNumeroPagina.Text = CInt(Form_Impresion_OC.lbNumeroPagina.Text) + 1
        ' e.Graphics.DrawString(Form_Impresion_OC.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.Pag_N.Left, e.MarginBounds.Bottom)
        'e.Graphics.DrawString(Form_Impresion_OC.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.lbNumeroPagina.Left, e.MarginBounds.Bottom)
        e.Graphics.DrawString(Form_Impresion_OC.Pag_N.Text, FuenteDetalles, Brushes.Black, 700, 1050)
        e.Graphics.DrawString(Form_Impresion_OC.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, 750, 1050)
        'INSERTAMOS LINES DESPUES DE DATOS DE CLIENTE
        Dim blackPen As New Pen(Color.Black, 2) : e.Graphics.DrawLine(blackPen, 50, 465, 790, 465)


        'Este encabezado no aparecera en la segunda pagina

        If CInt(Form_Impresion_OC.lbNumeroPagina.Text) <= 1 Then
            'Imprimimos el encabezado junto con el logo y los datos del estudiante que están antes del datagridview
            '----------------------------------------------------------------------------------------------------------------------
            Dim newImage As Image = Form_Impresion_OC.PictureBox1.Image : e.Graphics.DrawImage(newImage, Form_Impresion_OC.PictureBox1.Left, Form_Impresion_OC.PictureBox1.Top, Form_Impresion_OC.PictureBox1.Width, Form_Impresion_OC.PictureBox1.Height)
            e.Graphics.DrawString(Form_Impresion_OC.Label_oc.Text, FuenteNegrita, Brushes.Black, 600, 50)
            e.Graphics.DrawString(Form_Impresion_OC.oc.Text, FuenteDetalles, Brushes.Black, 630, 65)
            e.Graphics.DrawString(Form_Impresion_OC.Label1.Text, FuenteNegrita, Brushes.Black, 20, 120)
            e.Graphics.DrawString(Form_Impresion_OC.Label2.Text, FuenteNegrita, Brushes.Black, 20, 140)
            e.Graphics.DrawString(Form_Impresion_OC.Label_sres.Text, FuenteNegrita, Brushes.Black, 50, 170)
            e.Graphics.DrawString(Form_Impresion_OC.sres.Text, FuenteTitulo, Brushes.Black, 250, 170)
            e.Graphics.DrawString(Form_Impresion_OC.Label_direcc.Text, FuenteNegrita, Brushes.Black, 50, 190)
            e.Graphics.DrawString(Form_Impresion_OC.direcc.Text, FuenteTitulo, Brushes.Black, 250, 190)
            e.Graphics.DrawString(Form_Impresion_OC.Label_telef.Text, FuenteNegrita, Brushes.Black, 50, 210)
            e.Graphics.DrawString(Form_Impresion_OC.telefono.Text, FuenteTitulo, Brushes.Black, 250, 210)
            e.Graphics.DrawString(Form_Impresion_OC.Label_ruc.Text, FuenteNegrita, Brushes.Black, 50, 230)
            e.Graphics.DrawString(Form_Impresion_OC.ruc.Text, FuenteTitulo, Brushes.Black, 250, 230)
            e.Graphics.DrawString(Form_Impresion_OC.Label_fe.Text, FuenteNegrita, Brushes.Black, 50, 250)
            e.Graphics.DrawString(Form_Impresion_OC.fec_emision.Text, FuenteDetalles, Brushes.Black, 250, 250)
            e.Graphics.DrawString(Form_Impresion_OC.Label_f_pago.Text, FuenteNegrita, Brushes.Black, 50, 270)
            e.Graphics.DrawString(Form_Impresion_OC.f_pago.Text, FuenteDetalles, Brushes.Black, 250, 270)
            e.Graphics.DrawString(Form_Impresion_OC.Label_pers.Text, FuenteNegrita, Brushes.Black, 50, 290)
            e.Graphics.DrawString(Form_Impresion_OC.personal.Text, FuenteDetalles, Brushes.Black, 250, 290)
            e.Graphics.DrawString(Form_Impresion_OC.Label_t_venta.Text, FuenteNegrita, Brushes.Black, 50, 310)
            e.Graphics.DrawString(Form_Impresion_OC.t_venta.Text, FuenteDetalles, Brushes.Black, 250, 310)
            e.Graphics.DrawString(Form_Impresion_OC.Label_fp.Text, FuenteNegrita, Brushes.Black, 50, 330)
            e.Graphics.DrawString(Form_Impresion_OC.forma_pago.Text, FuenteDetalles, Brushes.Black, 250, 330)
            e.Graphics.DrawString(Form_Impresion_OC.Label_CC.Text, FuenteNegrita, Brushes.Black, 50, 350)
            e.Graphics.DrawString(Form_Impresion_OC.CCOSTO.Text, FuenteDetalles, Brushes.Black, 250, 350)
            e.Graphics.DrawString(Form_Impresion_OC.SUBCC.Text, FuenteNegrita, Brushes.Black, 50, 370)
            e.Graphics.DrawString(Form_Impresion_OC.SBCC.Text, FuenteDetalles, Brushes.Black, 250, 370)
            e.Graphics.DrawString(Form_Impresion_OC.RQ.Text, FuenteNegrita, Brushes.Black, 50, 390)
            e.Graphics.DrawString(Form_Impresion_OC.REQUE.Text, FuenteDetalles, Brushes.Black, 250, 390)
            e.Graphics.DrawString(Form_Impresion_OC.Label_OB.Text, FuenteNegrita, Brushes.Black, 50, 410)
            e.Graphics.DrawString(Form_Impresion_OC.OBS.Text, FuenteDetalles, Brushes.Black, 250, 410)
            '
            PosicionSinEncabezado = Form_Impresion_OC.P1.Top 'Reseteo el valor de esta variable si entra en esta condicion para evitar que el encabezado se posicione mal
        End If

        'Imprimimos el encabezado o titulo de la lista de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        e.Graphics.DrawString("ITEM", FuenteNegrita, Brushes.Black, 50, 450)
        e.Graphics.DrawString("DESCRIPCION", FuenteNegrita, Brushes.Black, 100, 450)
        e.Graphics.DrawString("UND", FuenteNegrita, Brushes.Black, 400, 450)
        e.Graphics.DrawString("CANTIDAD", FuenteNegrita, Brushes.Black, 500, 450)
        e.Graphics.DrawString("P.UNTIARIO", FuenteNegrita, Brushes.Black, 600, 450)
        e.Graphics.DrawString("SUB TOTAL", FuenteNegrita, Brushes.Black, 700, 450)


        'Imprimimos los detalles del reporte, es decir el listado de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim startX As Integer = 50 'Tomamos la posicion horinzontal de la letra 'Punto1'
        Dim startY As Integer = 475 'Tomamos la posicion vertical de la letra 'Punto1'
        Dim item As Integer = 1

        For i As Integer = 0 To Form_Impresion_OC.DataGridView1.Rows.Count - 1
            e.Graphics.DrawString(item, FuenteDetalles, Brushes.Black, 50, startY)
            e.Graphics.DrawString(Form_Impresion_OC.DataGridView1.Rows(i).Cells(1).Value.ToString, FuenteDetalles, Brushes.Black, 100, startY)
            e.Graphics.DrawString(Form_Impresion_OC.DataGridView1.Rows(i).Cells(2).Value.ToString, FuenteDetalles, Brushes.Black, 400, startY)
            e.Graphics.DrawString(Form_Impresion_OC.DataGridView1.Rows(i).Cells(3).Value.ToString, FuenteDetalles, Brushes.Black, 500, startY)
            e.Graphics.DrawString(Form_Impresion_OC.DataGridView1.Rows(i).Cells(4).Value.ToString, FuenteDetalles, Brushes.Black, 600, startY)
            e.Graphics.DrawString(Form_Impresion_OC.DataGridView1.Rows(i).Cells(5).Value.ToString, FuenteDetalles, Brushes.Black, 700, startY)
            startY += 15
            item += 1
            Contador += 1
            SUBTOTAL_OC += Form_Impresion_OC.DataGridView1.Rows(i).Cells(5).Value

        Next
        IGV_OC = SUBTOTAL_OC * porc_igv
        TOTAL_OC = SUBTOTAL_OC + IGV_OC

        Form_Impresion_OC.SUBTOTAL.Text = SUBTOTAL_OC
        Form_Impresion_OC.IGV.Text = IGV_OC
        Form_Impresion_OC.TOTAL.Text = TOTAL_OC

        CONSIDERACIONES = "*El proveedor esta oblidado a contar con los seguros contra todo riesgo SCTR de Salud 
y Pension de su personal encargado de visiar y realizar trabajos correspondientes a esta Orden de Compra.
*El proveedor debera contar con personal especializado en la actividad asignada, cualquier incidente por 
falta de conocimiento o capacitacion sera responsabilidad del proveedor.
*El proveedor debera contar con las respectivas herramientas de trabajo necesarias para la actividad al
cual se les asigna esta Orden de Compra.
*Los desechos generados por la actividad asignada sera responsabilidad del proveedor, de no eliminarse
sera asignado un costo de eliminacion, el cual sera descontado de la presente orden de compra.
*La presente Orden de Compra estara sujeto a modificacion si el proveedor no cumple con los 
estandares de calidad Solicitados."
        Form_Impresion_OC.CONSIDERACIONES.Text = CONSIDERACIONES
        If Contador >= Form_Impresion_OC.DataGridView1.Rows.Count Then
            Dim blackPen2 As New Pen(Color.Black, 2) : e.Graphics.DrawLine(blackPen2, 50, startY + 5, 790, startY + 5)
            e.Graphics.DrawString(Form_Impresion_OC.Label_SUBTOTAL.Text, FuenteNegrita, Brushes.Black, 585, startY + 15)
            e.Graphics.DrawString(Form_Impresion_OC.SUBTOTAL.Text, FuenteNegrita, Brushes.Black, 700, startY + 15)
            e.Graphics.DrawString(Form_Impresion_OC.Label_IGV.Text, FuenteNegrita, Brushes.Black, 585, startY + 35)
            e.Graphics.DrawString(Form_Impresion_OC.IGV.Text, FuenteNegrita, Brushes.Black, 700, startY + 35)
            e.Graphics.DrawString(Form_Impresion_OC.Label_TOTAL.Text, FuenteNegrita, Brushes.Black, 585, startY + 55)
            e.Graphics.DrawString(Form_Impresion_OC.TOTAL.Text, FuenteNegrita, Brushes.Black, 700, startY + 55)
            Dim newImage2 As Image = Form_Impresion_OC.PictureBox2.Image : e.Graphics.DrawImage(newImage2, 650, 780, Form_Impresion_OC.PictureBox2.Width, Form_Impresion_OC.PictureBox2.Height)
            e.Graphics.DrawString(Form_Impresion_OC.CONSIDERACIONES.Text, FuenteNegrita, Brushes.Black, 50, 900)
        End If

    End Sub

    Private Sub PrintDocument4_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument4.PrintPage
        Dim FuenteTitulo As New Font("Microsoft Sans Serif", 7)
        Dim FuenteSubtitulo As New Font("Microsoft Sans Serif", 7)
        Dim FuenteNegrita As New Font("Microsoft Sans Serif", 7, FontStyle.Bold)
        Dim FuenteDetalles As New Font("Microsoft Sans Serif", 7)
        Dim SUBTOTAL_OC, IGV_OC, TOTAL_OC As Decimal
        Dim CONSIDERACIONES As String
        'Si deseamos poner un contador de páginas
        'Esta parte siempre va a salir en todas las paginas
        '---------------------------------------------------------------------------------------------
        Form_Impresion_OC.lbNumeroPagina.Text = CInt(Form_Impresion_OC.lbNumeroPagina.Text) + 1
        'Form_Impresion_OC.lbNumeroPagina.Text = 1
        e.Graphics.DrawString(Form_Impresion_OC.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.Pag_N.Left, e.MarginBounds.Bottom)
        e.Graphics.DrawString(Form_Impresion_OC.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.lbNumeroPagina.Left, e.MarginBounds.Bottom)

        'e.Graphics.DrawString(Form_Impresion_OC.Pag_N.Text, FuenteDetalles, Brushes.Black, 700, 1050)
        'e.Graphics.DrawString(Form_Impresion_OC.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, 750, 1050)
        'INSERTAMOS LINES DESPUES DE DATOS DE CLIENTE
        'Dim blackPen As New Pen(Color.Black, 2) : e.Graphics.DrawLine(blackPen, 50, 465, 790, 465)

        If CInt(Form_Impresion_OC.lbNumeroPagina.Text) <= 1 Then
            Dim newImage As Image = Form_Impresion_OC.PictureBox1.Image : e.Graphics.DrawImage(newImage, Form_Impresion_OC.PictureBox1.Left, Form_Impresion_OC.PictureBox1.Top, Form_Impresion_OC.PictureBox1.Width, Form_Impresion_OC.PictureBox1.Height)
            e.Graphics.DrawString(Form_Impresion_OC.Label_oc.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_oc.Left, Form_Impresion_OC.Label_oc.Top)
            e.Graphics.DrawString(Form_Impresion_OC.oc.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.oc.Left, Form_Impresion_OC.oc.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label1.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label1.Left, Form_Impresion_OC.Label1.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label2.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label2.Left, Form_Impresion_OC.Label2.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_sres.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_sres.Left, Form_Impresion_OC.Label_sres.Top)
            e.Graphics.DrawString(Form_Impresion_OC.sres.Text, FuenteTitulo, Brushes.Black, Form_Impresion_OC.sres.Left, Form_Impresion_OC.sres.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_direcc.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_direcc.Left, Form_Impresion_OC.Label_direcc.Top)
            e.Graphics.DrawString(Form_Impresion_OC.direcc.Text, FuenteTitulo, Brushes.Black, Form_Impresion_OC.direcc.Left, Form_Impresion_OC.direcc.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_telef.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_telef.Left, Form_Impresion_OC.Label_telef.Top)
            e.Graphics.DrawString(Form_Impresion_OC.telefono.Text, FuenteTitulo, Brushes.Black, Form_Impresion_OC.telefono.Left, Form_Impresion_OC.telefono.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_ruc.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_ruc.Left, Form_Impresion_OC.Label_ruc.Top)
            e.Graphics.DrawString(Form_Impresion_OC.ruc.Text, FuenteTitulo, Brushes.Black, Form_Impresion_OC.ruc.Left, Form_Impresion_OC.ruc.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_fe.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_fe.Left, Form_Impresion_OC.Label_fe.Top)
            e.Graphics.DrawString(Form_Impresion_OC.fec_emision.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.fec_emision.Left, Form_Impresion_OC.fec_emision.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_f_pago.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_f_pago.Left, Form_Impresion_OC.Label_f_pago.Top)
            e.Graphics.DrawString(Form_Impresion_OC.f_pago.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.f_pago.Left, Form_Impresion_OC.f_pago.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_pers.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_pers.Left, Form_Impresion_OC.Label_pers.Top)
            e.Graphics.DrawString(Form_Impresion_OC.personal.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.personal.Left, Form_Impresion_OC.personal.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_t_venta.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_t_venta.Left, Form_Impresion_OC.Label_t_venta.Top)
            e.Graphics.DrawString(Form_Impresion_OC.t_venta.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.t_venta.Left, Form_Impresion_OC.t_venta.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_fp.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_fp.Left, Form_Impresion_OC.Label_fp.Top)
            e.Graphics.DrawString(Form_Impresion_OC.forma_pago.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.forma_pago.Left, Form_Impresion_OC.forma_pago.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_CC.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_CC.Left, Form_Impresion_OC.Label_CC.Top)
            e.Graphics.DrawString(Form_Impresion_OC.CCOSTO.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.CCOSTO.Left, Form_Impresion_OC.CCOSTO.Top)
            e.Graphics.DrawString(Form_Impresion_OC.SUBCC.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.SUBCC.Left, Form_Impresion_OC.SUBCC.Top)
            e.Graphics.DrawString(Form_Impresion_OC.SBCC.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.SBCC.Left, Form_Impresion_OC.SBCC.Top)
            e.Graphics.DrawString(Form_Impresion_OC.RQ.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.RQ.Left, Form_Impresion_OC.RQ.Top)
            e.Graphics.DrawString(Form_Impresion_OC.REQUE.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.REQUE.Left, Form_Impresion_OC.REQUE.Top)
            e.Graphics.DrawString(Form_Impresion_OC.Label_OB.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_OB.Left, Form_Impresion_OC.Label_OB.Top)
            e.Graphics.DrawString(Form_Impresion_OC.OBS.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.OBS.Left, Form_Impresion_OC.OBS.Top)
            '
            PosicionSinEncabezado = Form_Impresion_OC.P1.Top 'Reseteo el valor de esta variable si entra en esta condicion para evitar que el encabezado se posicione mal
        End If
        'Imprimimos el encabezado o titulo de la lista de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        e.Graphics.DrawString("ITEM", FuenteNegrita, Brushes.Black, Form_Impresion_OC.P1.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("DESCRIPCION", FuenteNegrita, Brushes.Black, Form_Impresion_OC.P2.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("UND", FuenteNegrita, Brushes.Black, Form_Impresion_OC.P3.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("CANTIDAD", FuenteNegrita, Brushes.Black, Form_Impresion_OC.P4.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("P.UNTIARIO", FuenteNegrita, Brushes.Black, Form_Impresion_OC.P5.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("SUB TOTAL", FuenteNegrita, Brushes.Black, Form_Impresion_OC.P6.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString(Form_Impresion_OC.lineatop.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.lineatop.Left, PosicionSinEncabezado - 20)

        'Imprimimos los detalles del reporte, es decir el listado de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim startX As Integer = Form_Impresion_OC.P1.Left 'Tomamos la posicion horinzontal de la letra 'Punto1'
        Dim startY As Integer = PosicionSinEncabezado 'Tomamos la posicion vertical de la letra 'Punto1'
        Dim item As Integer = 1
        Do While printLine < Form_Impresion_OC.DataGridView1.Rows.Count


            e.Graphics.DrawString(item, FuenteDetalles, Brushes.Black, Form_Impresion_OC.P1.Left, startY)
            e.Graphics.DrawString(Form_Impresion_OC.DataGridView1.Rows(printLine).Cells(1).Value.ToString, FuenteDetalles, Brushes.Black, Form_Impresion_OC.P2.Left, startY)
            e.Graphics.DrawString(Form_Impresion_OC.DataGridView1.Rows(printLine).Cells(2).Value.ToString, FuenteDetalles, Brushes.Black, Form_Impresion_OC.P3.Left, startY)
            e.Graphics.DrawString(Form_Impresion_OC.DataGridView1.Rows(printLine).Cells(3).Value.ToString, FuenteDetalles, Brushes.Black, Form_Impresion_OC.P4.Left, startY)
            e.Graphics.DrawString(Form_Impresion_OC.DataGridView1.Rows(printLine).Cells(4).Value.ToString, FuenteDetalles, Brushes.Black, Form_Impresion_OC.P5.Left, startY)
            e.Graphics.DrawString(Form_Impresion_OC.DataGridView1.Rows(printLine).Cells(5).Value.ToString, FuenteDetalles, Brushes.Black, Form_Impresion_OC.P6.Left, startY)
            Dim val_sub As Decimal = Form_Impresion_OC.DataGridView1.Rows(printLine).Cells(5).Value
            'Aqui estoy usando un tipo de letras mas grande 'LabelCodigo' mas grande que 'Punto1' para crear mas espacio entre filas
            '----------------------------------------------------------------------------------
            startY += Form_Impresion_OC.Label_OB.Height

            printLine += 1
            Contador += 1
            item += 1
            SUBTOTAL_OC += val_sub
            If startY + Form_Impresion_OC.Pag_N.Height > e.MarginBounds.Bottom Then
                'Esta parte se activa solo si 'startY' que es la posicion vertical almacenada supera el borde inferior de la pagina
                'Este se reinicia con cada pagina necesitada
                'Form_Impresion_OC.lbNumeroPagina.Text = CInt(Form_Impresion_OC.lbNumeroPagina.Text) + 1
                e.HasMorePages = True
                Exit Do

            End If

        Loop

        IGV_OC = SUBTOTAL_OC * porc_igv
        TOTAL_OC = SUBTOTAL_OC + IGV_OC

        Form_Impresion_OC.SUBTOTAL.Text = SUBTOTAL_OC
        Form_Impresion_OC.IGV.Text = IGV_OC
        Form_Impresion_OC.TOTAL.Text = TOTAL_OC
        CONSIDERACIONES = "*El proveedor esta oblidado a contar con los seguros contra todo riesgo SCTR de Salud 
y Pension de su personal encargado de visiar y realizar trabajos correspondientes a esta Orden de Compra.
*El proveedor debera contar con personal especializado en la actividad asignada, cualquier incidente por 
falta de conocimiento o capacitacion sera responsabilidad del proveedor.
*El proveedor debera contar con las respectivas herramientas de trabajo necesarias para la actividad al
cual se les asigna esta Orden de Compra.
*Los desechos generados por la actividad asignada sera responsabilidad del proveedor, de no eliminarse
sera asignado un costo de eliminacion, el cual sera descontado de la presente orden de compra.
*La presente Orden de Compra estara sujeto a modificacion si el proveedor no cumple con los 
estandares de calidad Solicitados."
        Form_Impresion_OC.CONSIDERACIONES.Text = CONSIDERACIONES
        'Con el contador solamente imprimimos la parte final del reporte si ha alcanzado el total de registros
        'Si deseamos repetir la parte final del reporte en cada pagina, debemos quitar en contador
        ''Imprimimos los valores que salen despues del datagridview al final del reporte

        If Contador >= Form_Impresion_OC.DataGridView1.Rows.Count Then
            e.Graphics.DrawString(Form_Impresion_OC.LINEAFONDO.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.LINEAFONDO.Left, startY)
            e.Graphics.DrawString(Form_Impresion_OC.Label_SUBTOTAL.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_SUBTOTAL.Left, startY + 40)
            e.Graphics.DrawString(Form_Impresion_OC.SUBTOTAL.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.SUBTOTAL.Left, startY + 40)
            e.Graphics.DrawString(Form_Impresion_OC.Label_IGV.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_IGV.Left, startY + 60)
            e.Graphics.DrawString(Form_Impresion_OC.IGV.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.IGV.Left, startY + 60)
            e.Graphics.DrawString(Form_Impresion_OC.Label_TOTAL.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.Label_TOTAL.Left, startY + 80)
            e.Graphics.DrawString(Form_Impresion_OC.TOTAL.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.TOTAL.Left, startY + 80)
            Dim newImage2 As Image = Form_Impresion_OC.PictureBox2.Image : e.Graphics.DrawImage(newImage2, Form_Impresion_OC.P3.Left, startY + 100, Form_Impresion_OC.PictureBox2.Width, Form_Impresion_OC.PictureBox2.Height)
            e.Graphics.DrawString(Form_Impresion_OC.CONSIDERACIONES.Text, FuenteNegrita, Brushes.Black, Form_Impresion_OC.P1.Left, startY + 300)
        End If

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
        GroupBox2.Enabled = True
        TextBox25.Enabled = True
        ComboBox1.Enabled = True
        ComboBox3.Enabled = True
        CheckBox2.Enabled = True
    End Sub

    Private Sub Form_Orden_Compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox14.Text = 0
        TextBox15.Text = 0
        TextBox16.Text = 0
        TextBox22.Text = 18
        Button2.Enabled = False
        accion = "guardar"
        moneda = "SOLES"
        porc_igv = TextBox22.Text / 100
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        GroupBox5.Enabled = False
        TextBox25.Enabled = False
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False
        DataGridView1.Enabled = True
        ListView1.View = View.Details
        ' ListView1.LabelEdit = True
        'ListView1.AllowColumnReorder = True
        ListView1.GridLines = True
        DataGridView1.AllowUserToAddRows = False
        Dim printLine As Integer = 0
        Dim Contador As Integer = 0
        Dim PosicionSinEncabezado As Integer = Form_Impresion_OC.P1.Top

    End Sub

    Public Sub llenar_PRO()
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
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Public Sub llenar_PRO_OC()
        Try
            sql = "select COD AS [CODIGO],COD_OC AS [CODIGO OC], COD_RQ AS [CODIGO RQ] , COD_CC AS [CODIGO CENTRO DE COSTO], COD_SCC AS [CODIGO SUBCENTRO COSTO], CANTIDAD, DESCRIP AS [DESCRIPCION], PREC_UNIT AS [PRECIO UNITORIO], PREC_TOTAL AS [PRECIO TOTAL],IGV,UND AS [UNIDAD], MONEDA from T_OC_ITEMS WHERE COD_OC='" + TextBox23.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_OC_ITEMS")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "T_OC_ITEMS"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
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
                        MessageBox.Show("Item ya agregado a la lista", "ZITRO")
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
                            TextBox24.Text = dr(4)
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
                'linea.SubItems.Add("PPPP")
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

        Dim linea As New ListViewItem(j)
        preg = MsgBox("Desea agregar el item en OC", vbYesNo)
        If preg = vbYes Then

            linea.SubItems.Add(TextBox15.Text)
            linea.SubItems.Add(TextBox18.Text)
            linea.SubItems.Add(TextBox24.Text)
            linea.SubItems.Add(TextBox14.Text)
            linea.SubItems.Add(TextBox16.Text)
            'linea.SubItems.Add("PPPP")

            'linea.SubItems.Add(comi_des.ToString("#,#.00"))
            comi_des = TextBox16.Text
            igv_comides = TextBox16.Text * porc_igv
            sub_total += comi_des
            igv_total = (sub_total * porc_igv)
            linea.SubItems.Add(igv_comides)
            linea.SubItems.Add(moneda)
            ListView1.Items.Add(linea)
            MessageBox.Show("Item Agregados", "")
            TextBox19.Text = sub_total
            TextBox20.Text = igv_total
            ' Dim st001 As Decimal = st.Text
            'Dim igv001 As Decimal = igv.Text
            total = sub_total + igv_total
            TextBox21.Text = total
        Else

            MessageBox.Show("No hay mas item, generar factura o cancelar factura", "ZITRO")
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

    Private Sub crea_itens_oc()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")
        Try
            For o = 0 To ListView1.Items.Count - 1
                If accion = "guardar" Then
                    sql = "select *from T_OC_ITEMS where  COD='" + ListView1.Items(o).SubItems(0).Text + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        MessageBox.Show("Los Datos ya Existen", "ZITRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        buscar_copiarIOC()
                        Dim COD As String = codigo
                        Dim COD_OC As String = TextBox23.Text
                        Dim COD_RQ As String = TextBox1.Text
                        Dim COD_CC As String = TextBox7.Text
                        Dim COD_SCC As String = TextBox8.Text
                        Dim CANTIDAD As String = ListView1.Items(o).SubItems(1).Text
                        Dim DESCRIP As String = ListView1.Items(o).SubItems(2).Text
                        Dim UNIDAD As String = ListView1.Items(o).SubItems(3).Text
                        Dim PREC_UNIT As String = ListView1.Items(o).SubItems(4).Text
                        Dim PREC_TOTAL As String = ListView1.Items(o).SubItems(5).Text
                        Dim IGV As String = ListView1.Items(o).SubItems(6).Text
                        'Dim PIO As String = ListView1.Items(o).SubItems(10).Text
                        'Dim OBS As String = ListView1.Items(o).SubItems(11).Text
                        ' Dim FEC As String = DateTimePicker5.Value.ToString("yyyyMMdd")
                        ' Dim EST As String = ListView1.Items(o).SubItems(13).Text

                        sql = "INSERT INTO T_OC_ITEMS (COD,COD_OC,COD_RQ,COD_CC,COD_SCC,CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV,UND, MONEDA) VALUES('" & COD & "','" & COD_OC & "','" & COD_RQ & "','" & COD_CC & "','" & COD_SCC & "','" & CANTIDAD & "','" & DESCRIP & "','" & PREC_UNIT & "','" & PREC_TOTAL & "','" & IGV & "','" & UNIDAD & "','" & moneda & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()



                        'buscar_copiar()


                        'llenar_grid()
                        'facturas()
                        'fac_operacion_anx.Show()
                    End If


                End If
            Next
            MessageBox.Show("Registro Guardado", "ZITRO")
            llenar_PRO_OC()
            ListView1.Visible = False
            DataGridView1.Visible = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub crea_oc()
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

                sql = "select *from T_ORDEN_COMPRA where  COD='" & TextBox23.Text & "'"
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
                    sql = "INSERT INTO T_ORDEN_COMPRA  (COD,FEC_REG_OC,RUC_PRO,RAZ_SOCIAL,DIRECC,TELF,NOM_C_P,APE_C_P,MAIL,NOM_U_S,APE_U_S,CARGO_U_S,MOT_COMP,JUS_ELEC_PROV,FEC_VEN_PAGO,COD_RQ,COD_CC,COD_SCC,OBS,T_VENTA,F_PAGO,MONEDA)   VALUES('" & codigo & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox13.Text & "','" & TextBox12.Text & "','" & TextBox11.Text & "','" & TextBox17.Text & "','" & ComboBox2.Text & "','" & DateTimePicker2.Value.ToString("yyyyMMdd") & "','" & TextBox1.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox25.Text & "','" & ComboBox1.Text & "','" & ComboBox3.Text & "','" & moneda & "')"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    res = com.ExecuteNonQuery
                    Form_Reg_SRV_SQL.conexion.Close()
                    MessageBox.Show(" ORDEN DE COMPRA CREADA ", " ZITRO ")
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
        Dim dat As String = "OC"
        'Dim cod, serie As String
        sql = "select *from T_ORDEN_COMPRA where id in (select max(id) from T_ORDEN_COMPRA)"
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

    Private Sub buscar_copiarIOC()
        Dim aum_cod As String
        Dim dat As String = "IOC"
        'Dim cod, serie As String
        sql = "select *from T_OC_ITEMS where id in (select max(id) from T_OC_ITEMS)"
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

    Private Sub guardar_rq()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")
        Try

            If accion = "guardar" Then
                sql = "select *from T_REQUERIMIENTO where  COD='" + TextBox1.Text + "'"
                Form_Reg_SRV_SQL.conectar()
                com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("Los Datos ya Existen", "ZITRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                Else
                    buscar_copiar()
                    'sql = "INSERT INTO T_REQUERIMIENTO (COD,SEDE,CLASIFIC,SERVICIO,CEN_COST,SUB_CC_OS,FEC_REG,ITEM,NOM_PROD,UNID,MEDID,CANT,MARCA,PRIORI,GENE_USU,REV_USU,APROB_USU,DETA_GEN_USU,DETA_REV_USU,DETA_APROB_USU,F_GEN,F_REV,F_APROB) VALUES ( '" & codigo & "','" & UCase(TextBox5.Text) & "','" & UCase(ComboBox2.Text) & "','" & UCase(TextBox8.Text) & "','" & UCase(TextBox7.Text) & "','" & UCase(TextBox3.Text) & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & ComboBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox4.Text & "','" & ComboBox4.Text & "',""','" & ComboBox4.Text & "','" & usu_gen & "','" & usu_rev & "','" & usu_aprob & "','" & ComboBox1.Text & "','" & ComboBox5.Text & "','" & ComboBox6.Text & "','" & DateTimePicker2.Value.ToString("yyyyMMdd") & "','" & DateTimePicker3.Value.ToString("yyyyMMdd") & "','" & DateTimePicker4.Value.ToString("yyyyMMdd") & "')"t/

                    'sql = "INSERT INTO T_REQUERIMIENTO (COD,SEDE,CLASIFIC,SERVICIO,CEN_COST,SUB_CC_OS,FEC_REG,PRIORI,GENE_USU,REV_USU,APROB_USU,DETA_GEN_USU,DETA_REV_USU,DETA_APROB_USU,F_GEN,F_REV,F_APROB, ESTADO, COMENT_USU,COMENT_SUP,COMENT_GEREN) VALUES ( '" & codigo & "','" & UCase(TextBox5.Text) & "','" & UCase(ComboBox2.Text) & "','" & UCase(TextBox8.Text) & "','" & UCase(TextBox7.Text) & "','" & UCase(TextBox3.Text) & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & ComboBox4.Text & "','" & usu_gen & "','" & usu_rev & "','" & usu_aprob & "','" & ComboBox1.Text & "','" & ComboBox5.Text & "','" & ComboBox6.Text & "','" & DateTimePicker2.Value.ToString("yyyyMMdd") & "','" & DateTimePicker3.Value.ToString("yyyyMMdd") & "','" & DateTimePicker4.Value.ToString("yyyyMMdd") & "','" & TextBox15.Text & "','" & TextBox16.Text & "','" & TextBox17.Text & "','" & TextBox18.Text & "')"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    res = com.ExecuteNonQuery
                    Form_Reg_SRV_SQL.conexion.Close()
                    MessageBox.Show("Registro Guardado", "ZITRO")
                    'buscar_rq()
                    'buscar_copiar()
                    'llenar_grid()
                    'facturas()
                    'fac_operacion_anx.Show()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub buscar_oc()
        'Dim aum_cod As String
        ' Dim dat As String = "RQ"
        'Dim cod, serie As String
        sql = "Select *from T_ORDEN_COMPRA where id In (Select max(id) from T_ORDEN_COMPRA)"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            TextBox23.Text = dr(0)
            DateTimePicker1.Value = dr(1)
            TextBox2.Text = dr(2)
            TextBox3.Text = dr(3)
            TextBox4.Text = dr(4)
            TextBox5.Text = dr(5)
            TextBox6.Text = dr(6)
            TextBox9.Text = dr(7)
            TextBox10.Text = dr(8)
            TextBox13.Text = dr(9)
            TextBox12.Text = dr(10)
            TextBox11.Text = dr(11)
            TextBox17.Text = dr(12)
            ComboBox2.Text = dr(13)
            DateTimePicker2.Value = dr(14)
            TextBox1.Text = dr(15)
            TextBox7.Text = dr(16)
            TextBox8.Text = dr(17)

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


    End Sub

    Private Sub copiar_ruta1()

        Try
            Dim ruta As String
            Dim copia As String

            'ruta = "\\server\SISTEMA\RUMISOFT2019\RUMISOFT\bin\Debug\formato\COTIZACION.xlsx"
            'copia = "\\server\SISTEMA\RUMISOFT2019\RUMISOFT\bin\Debug\COTIZACION.xlsx"
            ruta = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\formato\ORDENDECOMPRA.xlsx"
            copia = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\ORDENDECOMPRA.xlsx"
            IO.File.Copy(ruta, copia)
            MessageBox.Show("ARCHIVO CREADO")
        Catch ex As Exception
            MessageBox.Show("Archivo ya Existe")
        End Try


    End Sub
    Public Sub GENERA_OC()
        'El siguiente codigo es para crear la ruta,entre comillas se pone la ruta donde esta el libro
        Dim Ruta As String = Path.Combine(Directory.GetCurrentDirectory(), "ORDENDECOMPRA.xlsx")
        Dim TotalCOTI As Double = 0
        Dim SUBTOTAL As Double = 0
        Dim IGV As Double = 0
        strRutaExcel = Ruta
        Form_Reg_SRV_SQL.conectar()
        'El siguiente codigo es para abrir el libro y hacerlo visible, si se quiere dejar el libro oculto, se cambia la palabra True por False
        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)
        xlibro.Visible = True

        xlibro.Sheets("ORDENDECOMPRA").Select() 'Nombre del libro
        'esta es la instruccion para modificar la celda con el contenido de un textbox llamado textbox1, ustedes le pueden poner el nombre que deseen al textbox
        xlibro.Range("H4").Value = (TextBox23.Text)
        xlibro.Range("C7").Value = UCase(DateTimePicker1.Text)
        xlibro.Range("C8").Value = TextBox3.Text
        xlibro.Range("C9").Value = TextBox7.Text + " " + TextBox8.Text
        xlibro.Range("C10").Value = TextBox1.Text
        xlibro.Range("B48").Value = TextBox13.Text + " " + TextBox12.Text
        xlibro.Range("B49").Value = TextBox11.Text
        xlibro.Range("B50").Value = UCase(DateTimePicker2.Text)
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
        Adaptador = New SqlClient.SqlDataAdapter("select *from T_OC_ITEMS where COD_OC ='" + nc + "'", Form_Reg_SRV_SQL.conexion)
        Adaptador.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim fila As DataRow
            Dim ValorInicial As Integer = 19 ''Celda donde empezamos a insertar los articulos


            For Each fila In ds.Tables(0).Rows
                xlibro.Range("A" & ValorInicial).Value = fila("CANTIDAD")
                xlibro.Range("B" & ValorInicial).Value = fila("DESCRIP")
                xlibro.Range("F" & ValorInicial).Value = fila("UND")
                xlibro.Range("G" & ValorInicial).Value = fila("PREC_UNIT")
                'xlibro.Range("H" & ValorInicial).Value = fila("IGV")
                'xlibro.Range("I" & ValorInicial).Value = fila("PREC_TOTAL") + fila("IGV")
                ' xlibro.Range("G" & ValorInicial).Value = fila("CUOTA TOTAL")
                ' xlibro.Range("H" & ValorInicial).Value = fila("FECHA DE INICIO")
                ' xlibro.Range("I" & ValorInicial).Value = fila("FECHA DE VENCIMIENTO")
                'xlibro.Range("J" & ValorInicial).Value = fila("DIAS DE CUOTA")


                SUBTOTAL = SUBTOTAL + (fila("PREC_TOTAL"))
                IGV = IGV + (fila("IGV"))


                ' sql = "select COD AS [CODIGO],COD_COTI AS [CODIGO COTIZACION], CANTIDAD , DESCRIP AS [DESCRIPCION DE ITEM], PREC_UNIT AS [PRECIO UNITARIO], PREC_TOTAL AS [PRECIO TOTAL],IGV from T_COTI_ITEMS WHERE COD_COTI='" + TextBox23.Text + "'"

                ValorInicial += 1

            Next


        End If
        TotalCOTI = SUBTOTAL + IGV
        xlibro.Range("C39").Value = TextBox17.Text
        ' xlibro.Range("I40").Value = IGV
        'xlibro.Range("I41").Value = TotalCOTI
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
            Directory.CreateDirectory(Form_Reg_SRV_SQL.NOM_CARP_OC & n_carp)
            't6.Text = "\\orcasoluciones\instalador_opinv\clientes\" & n_carp
            'Button8.Enabled = True
        Catch ex As Exception
            MessageBox.Show("No pudo crear carpeta")
        End Try

    End Sub

    Private Sub copiar2()
        Try
            Dim ruta As String
            Dim copia As String
            n_carp = UCase(TextBox23.Text)
            ruta = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\ORDENDECOMPRA.xlsx"
            copia = Form_Reg_SRV_SQL.NOM_CARP_OC & n_carp & "\" & n_carp & ".xlsx"
            IO.File.Copy(ruta, copia)
            MessageBox.Show("CARPETA CREADA")
        Catch ex As Exception
            MessageBox.Show("Carpeta ya Existe")
        End Try

    End Sub

    Private Sub borrar()
        Try
            Dim ArchivoBorrar As String
            ArchivoBorrar = Form_Reg_SRV_SQL.CARP_SERV & "RUMISOFT2019\RUMISOFT\bin\Debug\ORDENDECOMPRA.xlsx"
            System.IO.File.Delete(ArchivoBorrar)
        Catch ex As Exception
            MessageBox.Show("Archivo no pudo ser borrado")
        End Try

    End Sub
    Sub totales()
        Dim cod_editar, cod_coti_editar, descrip_editar As String
        Dim cant_EDITAR, prec_unit_editar, prec_total_editar, igv_editar, util_bus, t_stotal, t_util, t_igv, tt As Integer
        accion = "guardar"
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            cod_editar = Trim(DataGridView1.Rows(i).Cells(0).Value)
            cod_coti_editar = Trim(DataGridView1.Rows(i).Cells(1).Value)
            cant_EDITAR = (DataGridView1.Rows(i).Cells(5).Value)
            descrip_editar = Trim(DataGridView1.Rows(i).Cells(6).Value)
            prec_unit_editar = (DataGridView1.Rows(i).Cells(7).Value)
            prec_total_editar = (DataGridView1.Rows(i).Cells(8).Value)
            igv_editar = (DataGridView1.Rows(i).Cells(9).Value)
            'util_bus = (DataGridView1.Rows(i).Cells(8).Value)
            t_stotal += prec_total_editar
            't_util += util_bus
            t_igv += igv_editar
            tt += (prec_total_editar + igv_editar)
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
        TextBox19.Text = t_stotal
        'TextBox25.Text = t_util
        TextBox20.Text = t_igv
        TextBox21.Text = tt

        ' DataGridView1.Enabled = False
        ' MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")
        ' Button15.Enabled = False
    End Sub
    Sub actualizar()
        Dim cod_editar, cod_oc_editar, cod_rq_editar, cod_cc_editar, cod_scc_editar, descrip_editar As String
        Dim cant_EDITAR, prec_unit_editar, prec_total_editar, igv_editar As Integer
        accion = "guardar"
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            cod_editar = Trim(DataGridView1.Rows(i).Cells(0).Value)
            cod_oc_editar = Trim(DataGridView1.Rows(i).Cells(1).Value)
            cod_rq_editar = Trim(DataGridView1.Rows(i).Cells(2).Value)
            cod_cc_editar = Trim(DataGridView1.Rows(i).Cells(3).Value)
            cod_scc_editar = Trim(DataGridView1.Rows(i).Cells(4).Value)
            cant_EDITAR = (DataGridView1.Rows(i).Cells(5).Value)
            descrip_editar = Trim(DataGridView1.Rows(i).Cells(6).Value)
            prec_unit_editar = (DataGridView1.Rows(i).Cells(7).Value)
            prec_total_editar = prec_unit_editar * cant_EDITAR
            igv_editar = prec_total_editar * 0.18


            'auxi_editar = MsgBox("¿ESTA SEGURO DE ACTUALIZAR ESTE REGISTRO?", MsgBoxStyle.YesNo, "ACTUALIZAR")


            'sql = "INSERT INTO T_COTI_ITEMS (COD,COD_COTI,CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
            ' sql = "UPDATE  T_COTI_ITEMS SET(CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
            sql = "UPDATE T_OC_ITEMS SET CANTIDAD='" & UCase(cant_EDITAR) & "', DESCRIP= '" & UCase(descrip_editar) & "', PREC_UNIT='" & prec_unit_editar & "', PREC_TOTAL='" & prec_total_editar & "', IGV= '" & igv_editar & "' WHERE COD='" & cod_editar & "'"
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
        DataGridView1.Enabled = False
        MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")
        Button17.Enabled = False
        llenar_PRO_OC()
    End Sub
    Sub ELEMINAR_OC()
        Dim selec As String = TextBox23.Text
        sql = "DELETE from T_ORDEN_COMPRA where  COD='" + selec + "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader

        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
    End Sub
    Sub ELIMINAR_ITEMS_OC()
        Dim selec As String = TextBox23.Text
        sql = "DELETE from T_OC_ITEMS where  COD_OC='" + selec + "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader

        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
    End Sub
    Sub ELIMINAR_ITEM_OC()
        Dim selec As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        sql = "DELETE from T_OC_ITEMS where  COD='" + selec + "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader

        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
    End Sub
    Sub LIMPIAR()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
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
        TextBox23.Text = ""
        TextBox25.Text = ""
        ComboBox1.Text = ""
        ComboBox3.Text = ""
        DataGridView1.Visible = False
        ListView1.Visible = True
        ListView1.Items.Clear()
        DataGridView1.Columns.Clear()
        dgv2.Columns.Clear()
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        Button2.Enabled = False
        'sub_total = 0
        'igv_total = 0
        'total = 0
    End Sub

    Private Sub DataGridView1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DataGridView1.KeyPress
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

    Private Sub TextBox22_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox22.KeyPress
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

    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
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

    Private Sub TextBox16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox16.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
        MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
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

    Public Sub llenar_PRO_OC_imprimir()
        Try
            sql = "select COD AS [CODIGO],COD_OC AS [CODIGO OC], COD_RQ AS [CODIGO RQ] , COD_CC AS [CODIGO CENTRO DE COSTO], COD_SCC AS [CODIGO SUBCENTRO COSTO], CANTIDAD, DESCRIP AS [DESCRIPCION], PREC_UNIT AS [PRECIO UNITORIO], PREC_TOTAL AS [PRECIO TOTAL],IGV,UND AS [UNIDAD], MONEDA from T_OC_ITEMS WHERE COD_OC='" + TextBox23.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_OC_ITEMS")
            Form_Impresion_OC.DataGridView1.DataSource = ds
            Form_Impresion_OC.DataGridView1.DataMember = "T_OC_ITEMS"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Sub llenar_form_imprimir()
        Dim cod_editar, cod_oc_editar, cod_rq_editar, cod_cc_editar, cod_scc_editar, descrip_editar As String
        Dim cant_EDITAR, prec_unit_editar, prec_total_editar, igv_editar As Integer
        accion = "guardar"
        Form_Impresion_OC.sres.Text = TextBox3.Text
        Form_Impresion_OC.ruc.Text = TextBox2.Text
        Form_Impresion_OC.direcc.Text = TextBox4.Text
        Form_Impresion_OC.telefono.Text = TextBox5.Text
        Form_Impresion_OC.fec_emision.Text = UCase(DateTimePicker1.Text)
        Form_Impresion_OC.personal.Text = TextBox13.Text
        Form_Impresion_OC.t_venta.Text = ComboBox1.Text
        Form_Impresion_OC.forma_pago.Text = ComboBox3.Text
        Form_Impresion_OC.f_pago.Text = UCase(DateTimePicker2.Text)
        Form_Impresion_OC.oc.Text = TextBox23.Text
        Form_Impresion_OC.CCOSTO.Text = TextBox7.Text
        Form_Impresion_OC.SBCC.Text = TextBox8.Text
        Form_Impresion_OC.REQUE.Text = TextBox1.Text
        Form_Impresion_OC.OBS.Text = TextBox25.Text
        Try
            sql = "select COD AS [ITEM], DESCRIP AS [DESCRIPCION], UND, CANTIDAD, PREC_UNIT AS [P.UNITARIO], PREC_TOTAL AS [SUBTOTAL] from T_OC_ITEMS WHERE COD_OC='" + TextBox23.Text + "'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_OC_ITEMS")
            Form_Impresion_OC.DataGridView1.DataSource = ds
            Form_Impresion_OC.DataGridView1.DataMember = "T_OC_ITEMS"
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
    End Sub
End Class