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


Public Class SELECCION_COTIZACION
    'Dim POR
    Dim printLine As Integer = 0
    Dim Contador As Integer = 0
    Dim PosicionSinEncabezado As Integer = Form_Imprimir_Coti.P1.Top
    Private Sub SELECCION_COTIZACION_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        printLine = 0
        Contador = 0
        Form_Imprimir_Coti.lbNumeroPagina.Text = 0
        Form_Cotizacion.llenar_form_imprimir()
        PrintPreviewDialog1.Document = PrintDocument4
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument4_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument4.PrintPage
        Dim FuenteTitulo As New Font("Microsoft Sans Serif", 7)
        Dim FuenteSubtitulo As New Font("Microsoft Sans Serif", 7)
        Dim FuenteNegrita As New Font("Microsoft Sans Serif", 7, FontStyle.Bold)
        Dim FuenteDetalles As New Font("Microsoft Sans Serif", 7)
        Dim SUBTOTAL_COTI, IGV_COTI, TOTAL_COTI As Decimal
        Dim CONSIDERACIONES As String
        'Si deseamos poner un contador de páginas
        'Esta parte siempre va a salir en todas las paginas
        '---------------------------------------------------------------------------------------------
        Form_Imprimir_Coti.lbNumeroPagina.Text = CInt(Form_Imprimir_Coti.lbNumeroPagina.Text) + 1
        'Form_Impresion_OC.lbNumeroPagina.Text = 1
        e.Graphics.DrawString(Form_Imprimir_Coti.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.Pag_N.Left, e.MarginBounds.Bottom)
        e.Graphics.DrawString(Form_Imprimir_Coti.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.lbNumeroPagina.Left, e.MarginBounds.Bottom)

        If CInt(Form_Imprimir_Coti.lbNumeroPagina.Text) <= 1 Then
            Dim newImage As Image = Form_Imprimir_Coti.logo.Image : e.Graphics.DrawImage(newImage, Form_Imprimir_Coti.logo.Left, Form_Imprimir_Coti.logo.Top, Form_Imprimir_Coti.logo.Width, Form_Imprimir_Coti.logo.Height)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_oc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_oc.Left, Form_Imprimir_Coti.Label_oc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.oc.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.oc.Left, Form_Imprimir_Coti.oc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label1.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label1.Left, Form_Imprimir_Coti.Label1.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label2.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label2.Left, Form_Imprimir_Coti.Label2.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_sres.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_sres.Left, Form_Imprimir_Coti.Label_sres.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.sres.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.sres.Left, Form_Imprimir_Coti.sres.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_direcc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_direcc.Left, Form_Imprimir_Coti.Label_direcc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.direcc.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.direcc.Left, Form_Imprimir_Coti.direcc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_telef.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_telef.Left, Form_Imprimir_Coti.Label_telef.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.telefono.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.telefono.Left, Form_Imprimir_Coti.telefono.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_ruc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_ruc.Left, Form_Imprimir_Coti.Label_ruc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.ruc.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.ruc.Left, Form_Imprimir_Coti.ruc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_fe.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_fe.Left, Form_Imprimir_Coti.Label_fe.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.fec_emision.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.fec_emision.Left, Form_Imprimir_Coti.fec_emision.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_fec_ven.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_fec_ven.Left, Form_Imprimir_Coti.Label_fec_ven.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.f_venc.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.f_venc.Left, Form_Imprimir_Coti.f_venc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_CONTACTO.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_CONTACTO.Left, Form_Imprimir_Coti.Label_CONTACTO.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.CONTACTO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.CONTACTO.Left, Form_Imprimir_Coti.CONTACTO.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_USU.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_USU.Left, Form_Imprimir_Coti.Label_USU.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.USUARIO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.USUARIO.Left, Form_Imprimir_Coti.USUARIO.Top)
            'e.Graphics.DrawString(Form_Imprimir_Coti.Label_UTILIDAD.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_UTILIDAD.Left, Form_Imprimir_Coti.Label_UTILIDAD.Top)
            ' e.Graphics.DrawString(Form_Imprimir_Coti.UTIL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.UTIL.Left, Form_Imprimir_Coti.UTIL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_OT.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_OT.Left, Form_Imprimir_Coti.LABEL_OT.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.OT.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.OT.Left, Form_Imprimir_Coti.OT.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_LOCAL.Left, Form_Imprimir_Coti.LABEL_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.LOCAL.Left, Form_Imprimir_Coti.LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Left, Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.UBI_LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.UBI_LOCAL.Left, Form_Imprimir_Coti.UBI_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Left, Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.DIR_LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.DIR_LOCAL.Left, Form_Imprimir_Coti.DIR_LOCAL.Top)
            '
            PosicionSinEncabezado = Form_Imprimir_Coti.P1.Top 'Reseteo el valor de esta variable si entra en esta condicion para evitar que el encabezado se posicione mal
        End If
        'Imprimimos el encabezado o titulo de la lista de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        e.Graphics.DrawString("ITEM", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P1.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("DESCRIPCION", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P2.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("UND", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P3.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("CANTIDAD", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P4.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("P.UNTIARIO", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P5.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("SUB TOTAL", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P6.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString(Form_Imprimir_Coti.lineatop.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.lineatop.Left, PosicionSinEncabezado - 20)

        'Imprimimos los detalles del reporte, es decir el listado de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim startX As Integer = Form_Imprimir_Coti.P1.Left 'Tomamos la posicion horinzontal de la letra 'Punto1'
        Dim startY As Integer = Form_Imprimir_Coti.P1.Top 'Tomamos la posicion vertical de la letra 'Punto1'
        Dim item As Integer = 1
        Do While printLine < Form_Imprimir_Coti.DataGridView1.Rows.Count
            If startY + Form_Imprimir_Coti.P1.Height > e.MarginBounds.Bottom Then
                'Esta parte se activa solo si 'startY' que es la posicion vertical almacenada supera el borde inferior de la pagina
                'Este se reinicia con cada pagina necesitada
                'Form_Impresion_OC.lbNumeroPagina.Text = CInt(Form_Impresion_OC.lbNumeroPagina.Text) + 1
                e.HasMorePages = True
                Exit Do

            End If

            e.Graphics.DrawString(item, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P1.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(3).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P2.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(4).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P3.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(2).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P4.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(12).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P5.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(14).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P6.Left, startY)
            Dim val_sub As Decimal = Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(14).Value
            'Aqui estoy usando un tipo de letras mas grande 'LabelCodigo' mas grande que 'Punto1' para crear mas espacio entre filas
            '----------------------------------------------------------------------------------
            startY += Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Height

            printLine += 1
            Contador += 1
            item += 1
            SUBTOTAL_COTI += val_sub


        Loop

        IGV_COTI = SUBTOTAL_COTI * Form_Cotizacion.porc_igv
        TOTAL_COTI = SUBTOTAL_COTI + IGV_COTI

        Form_Imprimir_Coti.SUBTOTAL.Text = Format("0.00", SUBTOTAL_COTI)
        Form_Imprimir_Coti.IGV.Text = Format("0.00", IGV_COTI)
        Form_Imprimir_Coti.TOTAL.Text = Format("0.00", TOTAL_COTI)
        CONSIDERACIONES = " PLAZO DE ENTREGA 90 DIAS.
1. Los precios están expresados en dólares americanos y no incluyen el Impuesto General a las Ventas.
2. El plazo de entrega cuenta a partir de la confirmación de la recepción y conformidad de su Orden de Compra.
3. ZITRO SOLUCIONES INTEGRALES SAC no se hará responsable por incumplimientos en sus obligaciones cuando éstas 
se vean afectadas por causas de fuerza mayor o ajenas a su voluntad, tales como guerras, hurto, vandalismo, conmoción civil, huelgas,
insurrección, escasez de insumos, reprogramación de fábrica, dumping, bloqueos, trasbordos, cancelación de vuelos o naves, 
inconsistencia de carga, proceso aduanero, epidemias, siniestros, desastres naturales.
4. Las condiciones y precios de esta Proforma están sujetos a las cantidades solicitadas. Cualquier variación de estas
cantidades podrá variar las condiciones ofrecidas.
5. El CLIENTE aceptará entregas y facturación parciales, así como el pago de las mismas en las fechas de vencimiento.
6. Los precios no incluyen ningún trabajo de ingeniería, instalación, mantenimiento, pruebas y certificaciones de los materiales. 
De acuerdo con lo expresado por cada fabricante, las especificaciones técnicas de sus productos están sujetas a cambio
sin previo aviso.
7. Los diseños y configuraciones son sugerencias que deberán ser validadas por el personal calificado del Cliente."

        Form_Imprimir_Coti.CONSIDERACIONES.Text = CONSIDERACIONES
        'Con el contador solamente imprimimos la parte final del reporte si ha alcanzado el total de registros
        'Si deseamos repetir la parte final del reporte en cada pagina, debemos quitar en contador
        ''Imprimimos los valores que salen despues del datagridview al final del reporte

        If Contador >= Form_Imprimir_Coti.DataGridView1.Rows.Count Then
            e.Graphics.DrawString(Form_Imprimir_Coti.LINEAFONDO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.LINEAFONDO.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_SUBTOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_SUBTOTAL.Left, startY + 20)
            e.Graphics.DrawString(Form_Imprimir_Coti.SUBTOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.SUBTOTAL.Left, startY + 20)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_IGV.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_IGV.Left, startY + 40)
            e.Graphics.DrawString(Form_Imprimir_Coti.IGV.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.IGV.Left, startY + 40)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_TOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_TOTAL.Left, startY + 60)
            e.Graphics.DrawString(Form_Imprimir_Coti.TOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.TOTAL.Left, startY + 60)
            'Dim newImage2 As Image = Form_Imprimir_Coti.PictureBox2.Image : e.Graphics.DrawImage(newImage2, Form_Imprimir_Coti.P5.Left, startY + 90, Form_Imprimir_Coti.PictureBox2.Width, Form_Imprimir_Coti.PictureBox2.Height)
            e.Graphics.DrawString(Form_Imprimir_Coti.CONSIDERACIONES.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P1.Left, startY + 90)
        End If
        ' Form_Impresion_OC.lbNumeroPagina.Text = CInt(Form_Impresion_OC.lbNumeroPagina.Text) + 1
        'Form_Impresion_OC.lbNumeroPagina.Text = 1
        ' e.Graphics.DrawString(Form_Impresion_OC.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.Pag_N.Left, e.MarginBounds.Bottom)
        'e.Graphics.DrawString(Form_Impresion_OC.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.lbNumeroPagina.Left, e.MarginBounds.Bottom)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        printLine = 0
        Contador = 0
        Form_Impresion_OC.lbNumeroPagina.Text = 0
        Form_Cotizacion.llenar_form_imprimir()
        PrintDialog1.Document = PrintDocument3
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument3.PrinterSettings.PrintToFile = True
            PrintDocument3.Print()
        End If
    End Sub

    Private Sub PrintDocument3_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument3.PrintPage
        Dim FuenteTitulo As New Font("Microsoft Sans Serif", 7)
        Dim FuenteSubtitulo As New Font("Microsoft Sans Serif", 7)
        Dim FuenteNegrita As New Font("Microsoft Sans Serif", 7, FontStyle.Bold)
        Dim FuenteDetalles As New Font("Microsoft Sans Serif", 7)
        Dim SUBTOTAL_COTI, IGV_COTI, TOTAL_COTI As Decimal
        Dim CONSIDERACIONES As String
        'Si deseamos poner un contador de páginas
        'Esta parte siempre va a salir en todas las paginas
        '---------------------------------------------------------------------------------------------
        ' Form_Imprimir_Coti.lbNumeroPagina.Text = CInt(Form_Imprimir_Coti.lbNumeroPagina.Text) + 1
        'Form_Impresion_OC.lbNumeroPagina.Text = 1
        ' e.Graphics.DrawString(Form_Imprimir_Coti.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.Pag_N.Left, e.MarginBounds.Bottom)
        ' e.Graphics.DrawString(Form_Imprimir_Coti.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.lbNumeroPagina.Left, e.MarginBounds.Bottom)

        '  If CInt(Form_Imprimir_Coti.lbNumeroPagina.Text) <= 1 Then
        Dim newImage As Image = Form_Imprimir_Coti.logo.Image : e.Graphics.DrawImage(newImage, Form_Imprimir_Coti.logo.Left, Form_Imprimir_Coti.logo.Top, Form_Imprimir_Coti.logo.Width, Form_Imprimir_Coti.logo.Height)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_oc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_oc.Left, Form_Imprimir_Coti.Label_oc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.oc.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.oc.Left, Form_Imprimir_Coti.oc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label1.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label1.Left, Form_Imprimir_Coti.Label1.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label2.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label2.Left, Form_Imprimir_Coti.Label2.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_sres.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_sres.Left, Form_Imprimir_Coti.Label_sres.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.sres.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.sres.Left, Form_Imprimir_Coti.sres.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_direcc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_direcc.Left, Form_Imprimir_Coti.Label_direcc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.direcc.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.direcc.Left, Form_Imprimir_Coti.direcc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_telef.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_telef.Left, Form_Imprimir_Coti.Label_telef.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.telefono.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.telefono.Left, Form_Imprimir_Coti.telefono.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_ruc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_ruc.Left, Form_Imprimir_Coti.Label_ruc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.ruc.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.ruc.Left, Form_Imprimir_Coti.ruc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_fe.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_fe.Left, Form_Imprimir_Coti.Label_fe.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.fec_emision.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.fec_emision.Left, Form_Imprimir_Coti.fec_emision.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_fec_ven.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_fec_ven.Left, Form_Imprimir_Coti.Label_fec_ven.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.f_venc.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.f_venc.Left, Form_Imprimir_Coti.f_venc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_CONTACTO.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_CONTACTO.Left, Form_Imprimir_Coti.Label_CONTACTO.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.CONTACTO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.CONTACTO.Left, Form_Imprimir_Coti.CONTACTO.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_USU.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_USU.Left, Form_Imprimir_Coti.Label_USU.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.USUARIO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.USUARIO.Left, Form_Imprimir_Coti.USUARIO.Top)
        'e.Graphics.DrawString(Form_Imprimir_Coti.Label_UTILIDAD.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_UTILIDAD.Left, Form_Imprimir_Coti.Label_UTILIDAD.Top)
        'e.Graphics.DrawString(Form_Imprimir_Coti.UTIL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.UTIL.Left, Form_Imprimir_Coti.UTIL.Top)
        e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_OT.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_OT.Left, Form_Imprimir_Coti.LABEL_OT.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.OT.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.OT.Left, Form_Imprimir_Coti.OT.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_LOCAL.Left, Form_Imprimir_Coti.LABEL_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.LOCAL.Left, Form_Imprimir_Coti.LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Left, Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.UBI_LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.UBI_LOCAL.Left, Form_Imprimir_Coti.UBI_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Left, Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.DIR_LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.DIR_LOCAL.Left, Form_Imprimir_Coti.DIR_LOCAL.Top)
        '
        ' PosicionSinEncabezado = Form_Imprimir_Coti.P1.Top 'Reseteo el valor de esta variable si entra en esta condicion para evitar que el encabezado se posicione mal
        ' End If
        'Imprimimos el encabezado o titulo de la lista de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        e.Graphics.DrawString("ITEM", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P1.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("DESCRIPCION", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P2.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("UND", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P3.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("CANTIDAD", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P4.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("P.UNTIARIO", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P5.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("SUB TOTAL", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P6.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString(Form_Imprimir_Coti.lineatop.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.lineatop.Left, PosicionSinEncabezado - 20)

        'Imprimimos los detalles del reporte, es decir el listado de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim startX As Integer = Form_Imprimir_Coti.P1.Left 'Tomamos la posicion horinzontal de la letra 'Punto1'
        Dim startY As Integer = Form_Imprimir_Coti.P1.Top 'Tomamos la posicion vertical de la letra 'Punto1'
        Dim item As Integer = 1
        Do While printLine < Form_Imprimir_Coti.DataGridView1.Rows.Count
            If startY + Form_Imprimir_Coti.P1.Height > e.MarginBounds.Bottom Then
                'Esta parte se activa solo si 'startY' que es la posicion vertical almacenada supera el borde inferior de la pagina
                'Este se reinicia con cada pagina necesitada
                'Form_Impresion_OC.lbNumeroPagina.Text = CInt(Form_Impresion_OC.lbNumeroPagina.Text) + 1
                e.HasMorePages = True
                Exit Do

            End If

            e.Graphics.DrawString(item, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P1.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(3).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P2.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(4).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P3.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(2).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P4.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(12).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P5.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(14).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P6.Left, startY)
            Dim val_sub As Decimal = Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(14).Value
            'Aqui estoy usando un tipo de letras mas grande 'LabelCodigo' mas grande que 'Punto1' para crear mas espacio entre filas
            '----------------------------------------------------------------------------------
            startY += Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Height

            printLine += 1
            Contador += 1
            item += 1
            SUBTOTAL_COTI += val_sub


        Loop

        IGV_COTI = SUBTOTAL_COTI * Form_Cotizacion.porc_igv
        TOTAL_COTI = SUBTOTAL_COTI + IGV_COTI

        Form_Imprimir_Coti.SUBTOTAL.Text = Format("0.00", SUBTOTAL_COTI)
        Form_Imprimir_Coti.IGV.Text = Format("0.00", IGV_COTI)
        Form_Imprimir_Coti.TOTAL.Text = Format("0.00", TOTAL_COTI)
        CONSIDERACIONES = "1. Los precios están expresados en dólares americanos y no incluyen el Impuesto General a las Ventas.
2. El plazo de entrega cuenta a partir de la confirmación de la recepción y conformidad de su Orden de Compra.
3. ZITRO SOLUCIONES INTEGRALES SAC no se hará responsable por incumplimientos en sus obligaciones cuando éstas 
se vean afectadas por causas de fuerza mayor o ajenas a su voluntad, tales como guerras, hurto, vandalismo, conmoción civil, huelgas,
insurrección, escasez de insumos, reprogramación de fábrica, dumping, bloqueos, trasbordos, cancelación de vuelos o naves, 
inconsistencia de carga, proceso aduanero, epidemias, siniestros, desastres naturales.
4. Las condiciones y precios de esta Proforma están sujetos a las cantidades solicitadas. Cualquier variación de estas
cantidades podrá variar las condiciones ofrecidas.
5. El CLIENTE aceptará entregas y facturación parciales, así como el pago de las mismas en las fechas de vencimiento.
6. Los precios no incluyen ningún trabajo de ingeniería, instalación, mantenimiento, pruebas y certificaciones de los materiales. 
De acuerdo con lo expresado por cada fabricante, las especificaciones técnicas de sus productos están sujetas a cambio
sin previo aviso.
7. Los diseños y configuraciones son sugerencias que deberán ser validadas por el personal calificado del Cliente."
        Form_Imprimir_Coti.CONSIDERACIONES.Text = CONSIDERACIONES
        'Con el contador solamente imprimimos la parte final del reporte si ha alcanzado el total de registros
        'Si deseamos repetir la parte final del reporte en cada pagina, debemos quitar en contador
        ''Imprimimos los valores que salen despues del datagridview al final del reporte

        If Contador >= Form_Imprimir_Coti.DataGridView1.Rows.Count Then
            e.Graphics.DrawString(Form_Imprimir_Coti.LINEAFONDO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.LINEAFONDO.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_SUBTOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_SUBTOTAL.Left, startY + 20)
            e.Graphics.DrawString(Form_Imprimir_Coti.SUBTOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.SUBTOTAL.Left, startY + 20)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_IGV.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_IGV.Left, startY + 40)
            e.Graphics.DrawString(Form_Imprimir_Coti.IGV.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.IGV.Left, startY + 40)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_TOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_TOTAL.Left, startY + 60)
            e.Graphics.DrawString(Form_Imprimir_Coti.TOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.TOTAL.Left, startY + 60)
            'Dim newImage2 As Image = Form_Imprimir_Coti.PictureBox2.Image : e.Graphics.DrawImage(newImage2, Form_Imprimir_Coti.P5.Left, startY + 90, Form_Imprimir_Coti.PictureBox2.Width, Form_Imprimir_Coti.PictureBox2.Height)
            e.Graphics.DrawString(Form_Imprimir_Coti.CONSIDERACIONES.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P1.Left, startY + 90)
        End If
        Form_Imprimir_Coti.lbNumeroPagina.Text = CInt(Form_Imprimir_Coti.lbNumeroPagina.Text) + 1
        'Form_Impresion_OC.lbNumeroPagina.Text = 1
        e.Graphics.DrawString(Form_Imprimir_Coti.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.Pag_N.Left, e.MarginBounds.Bottom)
        e.Graphics.DrawString(Form_Imprimir_Coti.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.lbNumeroPagina.Left, e.MarginBounds.Bottom)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        printLine = 0
        Contador = 0
        Form_Imprimir_Coti.lbNumeroPagina.Text = 0
        Form_Cotizacion.llenar_form_imprimir()
        PrintPreviewDialog1.Document = PrintDocument2
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument2.PrintPage
        Dim FuenteTitulo As New Font("Microsoft Sans Serif", 7)
        Dim FuenteSubtitulo As New Font("Microsoft Sans Serif", 7)
        Dim FuenteNegrita As New Font("Microsoft Sans Serif", 7, FontStyle.Bold)
        Dim FuenteDetalles As New Font("Microsoft Sans Serif", 7)
        Dim SUBTOTAL_COTI, IGV_COTI, TOTAL_COTI, UTIL_TOTAL As Decimal
        Dim CONSIDERACIONES As String
        'Si deseamos poner un contador de páginas
        'Esta parte siempre va a salir en todas las paginas
        '---------------------------------------------------------------------------------------------
        'Form_Imprimir_Coti.lbNumeroPagina.Text = CInt(Form_Imprimir_Coti.lbNumeroPagina.Text) + 1
        'Form_Impresion_OC.lbNumeroPagina.Text = 1
        ' e.Graphics.DrawString(Form_Imprimir_Coti.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.Pag_N.Left, e.MarginBounds.Bottom)
        ' e.Graphics.DrawString(Form_Imprimir_Coti.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.lbNumeroPagina.Left, e.MarginBounds.Bottom)

        'If CInt(Form_Imprimir_Coti.lbNumeroPagina.Text) <= 1 Then
        Dim newImage As Image = Form_Imprimir_Coti.logo.Image : e.Graphics.DrawImage(newImage, Form_Imprimir_Coti.logo.Left, Form_Imprimir_Coti.logo.Top, Form_Imprimir_Coti.logo.Width, Form_Imprimir_Coti.logo.Height)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_oc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_oc.Left, Form_Imprimir_Coti.Label_oc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.oc.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.oc.Left, Form_Imprimir_Coti.oc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label1.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label1.Left, Form_Imprimir_Coti.Label1.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label2.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label2.Left, Form_Imprimir_Coti.Label2.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_sres.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_sres.Left, Form_Imprimir_Coti.Label_sres.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.sres.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.sres.Left, Form_Imprimir_Coti.sres.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_direcc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_direcc.Left, Form_Imprimir_Coti.Label_direcc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.direcc.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.direcc.Left, Form_Imprimir_Coti.direcc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_telef.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_telef.Left, Form_Imprimir_Coti.Label_telef.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.telefono.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.telefono.Left, Form_Imprimir_Coti.telefono.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_ruc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_ruc.Left, Form_Imprimir_Coti.Label_ruc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.ruc.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.ruc.Left, Form_Imprimir_Coti.ruc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_fe.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_fe.Left, Form_Imprimir_Coti.Label_fe.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.fec_emision.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.fec_emision.Left, Form_Imprimir_Coti.fec_emision.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_fec_ven.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_fec_ven.Left, Form_Imprimir_Coti.Label_fec_ven.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.f_venc.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.f_venc.Left, Form_Imprimir_Coti.f_venc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_CONTACTO.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_CONTACTO.Left, Form_Imprimir_Coti.Label_CONTACTO.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.CONTACTO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.CONTACTO.Left, Form_Imprimir_Coti.CONTACTO.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_USU.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_USU.Left, Form_Imprimir_Coti.Label_USU.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.USUARIO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.USUARIO.Left, Form_Imprimir_Coti.USUARIO.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_UTILIDAD.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_UTILIDAD.Left, Form_Imprimir_Coti.Label_UTILIDAD.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.UTIL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.UTIL.Left, Form_Imprimir_Coti.UTIL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_OT.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_OT.Left, Form_Imprimir_Coti.LABEL_OT.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.OT.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.OT.Left, Form_Imprimir_Coti.OT.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_LOCAL.Left, Form_Imprimir_Coti.LABEL_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.LOCAL.Left, Form_Imprimir_Coti.LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Left, Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.UBI_LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.UBI_LOCAL.Left, Form_Imprimir_Coti.UBI_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Left, Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.DIR_LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.DIR_LOCAL.Left, Form_Imprimir_Coti.DIR_LOCAL.Top)
        '
        'PosicionSinEncabezado = Form_Imprimir_Coti.P1.Top 'Reseteo el valor de esta variable si entra en esta condicion para evitar que el encabezado se posicione mal
        ' End If
        'Imprimimos el encabezado o titulo de la lista de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        e.Graphics.DrawString("ITEM", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P1.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("DESCRIPCION", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P2.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("UND", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P3.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("CANTIDAD", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P4.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("P.UNTIARIO", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P5.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("SUB TOTAL", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P6.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString(Form_Imprimir_Coti.lineatop.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.lineatop.Left, PosicionSinEncabezado - 20)

        'Imprimimos los detalles del reporte, es decir el listado de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim startX As Integer = Form_Imprimir_Coti.P1.Left 'Tomamos la posicion horinzontal de la letra 'Punto1'
        Dim startY As Integer = Form_Imprimir_Coti.P1.Top 'Tomamos la posicion vertical de la letra 'Punto1'
        Dim item As Integer = 1
        Do While printLine < Form_Imprimir_Coti.DataGridView1.Rows.Count
            If startY + Form_Imprimir_Coti.P1.Height > e.MarginBounds.Bottom Then
                'Esta parte se activa solo si 'startY' que es la posicion vertical almacenada supera el borde inferior de la pagina
                'Este se reinicia con cada pagina necesitada
                'Form_Impresion_OC.lbNumeroPagina.Text = CInt(Form_Impresion_OC.lbNumeroPagina.Text) + 1
                e.HasMorePages = True
                Exit Do

            End If

            e.Graphics.DrawString(item, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P1.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(3).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P2.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(4).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P3.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(2).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P4.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(5).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P5.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(7).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P6.Left, startY)
            Dim val_sub As Decimal = Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(7).Value
            Dim val_util As Decimal = Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(11).Value
            'Aqui estoy usando un tipo de letras mas grande 'LabelCodigo' mas grande que 'Punto1' para crear mas espacio entre filas
            '----------------------------------------------------------------------------------
            startY += Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Height

            printLine += 1
            Contador += 1
            item += 1
            SUBTOTAL_COTI += val_sub
            UTIL_TOTAL += val_util

        Loop

        IGV_COTI = (SUBTOTAL_COTI + UTIL_TOTAL) * Form_Cotizacion.porc_igv
        TOTAL_COTI = SUBTOTAL_COTI + UTIL_TOTAL + IGV_COTI
        Form_Imprimir_Coti.MONT_UTIL.Text = Format("0.00", UTIL_TOTAL)
        Form_Imprimir_Coti.SUBTOTAL.Text = Format("0.00", SUBTOTAL_COTI)
        Form_Imprimir_Coti.IGV.Text = Format("0.00", IGV_COTI)
        Form_Imprimir_Coti.TOTAL.Text = Format("0.00", TOTAL_COTI)
        CONSIDERACIONES = "1. Los precios están expresados en dólares americanos y no incluyen el Impuesto General a las Ventas.
2. El plazo de entrega cuenta a partir de la confirmación de la recepción y conformidad de su Orden de Compra.
3. ZITRO SOLUCIONES INTEGRALES SAC no se hará responsable por incumplimientos en sus obligaciones cuando éstas 
se vean afectadas por causas de fuerza mayor o ajenas a su voluntad, tales como guerras, hurto, vandalismo, conmoción civil, huelgas,
insurrección, escasez de insumos, reprogramación de fábrica, dumping, bloqueos, trasbordos, cancelación de vuelos o naves, 
inconsistencia de carga, proceso aduanero, epidemias, siniestros, desastres naturales.
4. Las condiciones y precios de esta Proforma están sujetos a las cantidades solicitadas. Cualquier variación de estas
cantidades podrá variar las condiciones ofrecidas.
5. El CLIENTE aceptará entregas y facturación parciales, así como el pago de las mismas en las fechas de vencimiento.
6. Los precios no incluyen ningún trabajo de ingeniería, instalación, mantenimiento, pruebas y certificaciones de los materiales. 
De acuerdo con lo expresado por cada fabricante, las especificaciones técnicas de sus productos están sujetas a cambio
sin previo aviso.
7. Los diseños y configuraciones son sugerencias que deberán ser validadas por el personal calificado del Cliente."
        Form_Imprimir_Coti.CONSIDERACIONES.Text = CONSIDERACIONES
        'Con el contador solamente imprimimos la parte final del reporte si ha alcanzado el total de registros
        'Si deseamos repetir la parte final del reporte en cada pagina, debemos quitar en contador
        ''Imprimimos los valores que salen despues del datagridview al final del reporte

        If Contador >= Form_Imprimir_Coti.DataGridView1.Rows.Count Then
            e.Graphics.DrawString(Form_Imprimir_Coti.LINEAFONDO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.LINEAFONDO.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_UTIL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_UTIL.Left, startY + 20)
            e.Graphics.DrawString(Form_Imprimir_Coti.MONT_UTIL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.MONT_UTIL.Left, startY + 20)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_SUBTOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_SUBTOTAL.Left, startY + 40)
            e.Graphics.DrawString(Form_Imprimir_Coti.SUBTOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.SUBTOTAL.Left, startY + 40)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_IGV.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_IGV.Left, startY + 60)
            e.Graphics.DrawString(Form_Imprimir_Coti.IGV.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.IGV.Left, startY + 60)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_TOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_TOTAL.Left, startY + 80)
            e.Graphics.DrawString(Form_Imprimir_Coti.TOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.TOTAL.Left, startY + 80)
            'Dim newImage2 As Image = Form_Imprimir_Coti.PictureBox2.Image : e.Graphics.DrawImage(newImage2, Form_Imprimir_Coti.P5.Left, startY + 90, Form_Imprimir_Coti.PictureBox2.Width, Form_Imprimir_Coti.PictureBox2.Height)
            e.Graphics.DrawString(Form_Imprimir_Coti.CONSIDERACIONES.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P1.Left, startY + 100)
        End If
        ' Form_Impresion_OC.lbNumeroPagina.Text = CInt(Form_Impresion_OC.lbNumeroPagina.Text) + 1
        'Form_Impresion_OC.lbNumeroPagina.Text = 1
        ' e.Graphics.DrawString(Form_Impresion_OC.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.Pag_N.Left, e.MarginBounds.Bottom)
        'e.Graphics.DrawString(Form_Impresion_OC.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.lbNumeroPagina.Left, e.MarginBounds.Bottom)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        printLine = 0
        Contador = 0
        Form_Impresion_OC.lbNumeroPagina.Text = 0
        Form_Cotizacion.llenar_form_imprimir()
        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.PrinterSettings.PrintToFile = True
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim FuenteTitulo As New Font("Microsoft Sans Serif", 7)
        Dim FuenteSubtitulo As New Font("Microsoft Sans Serif", 7)
        Dim FuenteNegrita As New Font("Microsoft Sans Serif", 7, FontStyle.Bold)
        Dim FuenteDetalles As New Font("Microsoft Sans Serif", 7)
        Dim SUBTOTAL_COTI, IGV_COTI, TOTAL_COTI, UTIL_TOTAL As Decimal
        Dim CONSIDERACIONES As String
        'Si deseamos poner un contador de páginas
        'Esta parte siempre va a salir en todas las paginas
        '---------------------------------------------------------------------------------------------
        Form_Imprimir_Coti.lbNumeroPagina.Text = CInt(Form_Imprimir_Coti.lbNumeroPagina.Text) + 1
        'Form_Impresion_OC.lbNumeroPagina.Text = 1
        e.Graphics.DrawString(Form_Imprimir_Coti.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.Pag_N.Left, e.MarginBounds.Bottom)
        e.Graphics.DrawString(Form_Imprimir_Coti.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.lbNumeroPagina.Left, e.MarginBounds.Bottom)

        If CInt(Form_Imprimir_Coti.lbNumeroPagina.Text) <= 1 Then
            Dim newImage As Image = Form_Imprimir_Coti.logo.Image : e.Graphics.DrawImage(newImage, Form_Imprimir_Coti.logo.Left, Form_Imprimir_Coti.logo.Top, Form_Imprimir_Coti.logo.Width, Form_Imprimir_Coti.logo.Height)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_oc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_oc.Left, Form_Imprimir_Coti.Label_oc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.oc.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.oc.Left, Form_Imprimir_Coti.oc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label1.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label1.Left, Form_Imprimir_Coti.Label1.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label2.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label2.Left, Form_Imprimir_Coti.Label2.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_sres.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_sres.Left, Form_Imprimir_Coti.Label_sres.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.sres.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.sres.Left, Form_Imprimir_Coti.sres.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_direcc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_direcc.Left, Form_Imprimir_Coti.Label_direcc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.direcc.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.direcc.Left, Form_Imprimir_Coti.direcc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_telef.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_telef.Left, Form_Imprimir_Coti.Label_telef.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.telefono.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.telefono.Left, Form_Imprimir_Coti.telefono.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_ruc.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_ruc.Left, Form_Imprimir_Coti.Label_ruc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.ruc.Text, FuenteTitulo, Brushes.Black, Form_Imprimir_Coti.ruc.Left, Form_Imprimir_Coti.ruc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_fe.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_fe.Left, Form_Imprimir_Coti.Label_fe.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.fec_emision.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.fec_emision.Left, Form_Imprimir_Coti.fec_emision.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_fec_ven.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_fec_ven.Left, Form_Imprimir_Coti.Label_fec_ven.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.f_venc.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.f_venc.Left, Form_Imprimir_Coti.f_venc.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_CONTACTO.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_CONTACTO.Left, Form_Imprimir_Coti.Label_CONTACTO.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.CONTACTO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.CONTACTO.Left, Form_Imprimir_Coti.CONTACTO.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_USU.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_USU.Left, Form_Imprimir_Coti.Label_USU.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.USUARIO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.USUARIO.Left, Form_Imprimir_Coti.USUARIO.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_UTILIDAD.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_UTILIDAD.Left, Form_Imprimir_Coti.Label_UTILIDAD.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.UTIL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.UTIL.Left, Form_Imprimir_Coti.UTIL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_OT.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_OT.Left, Form_Imprimir_Coti.LABEL_OT.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.OT.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.OT.Left, Form_Imprimir_Coti.OT.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_LOCAL.Left, Form_Imprimir_Coti.LABEL_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.LOCAL.Left, Form_Imprimir_Coti.LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Left, Form_Imprimir_Coti.LABEL_UBICA_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.UBI_LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.UBI_LOCAL.Left, Form_Imprimir_Coti.UBI_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Left, Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Top)
            e.Graphics.DrawString(Form_Imprimir_Coti.DIR_LOCAL.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.DIR_LOCAL.Left, Form_Imprimir_Coti.DIR_LOCAL.Top)
            '
            PosicionSinEncabezado = Form_Imprimir_Coti.P1.Top 'Reseteo el valor de esta variable si entra en esta condicion para evitar que el encabezado se posicione mal
        End If
        'Imprimimos el encabezado o titulo de la lista de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        e.Graphics.DrawString("ITEM", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P1.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("DESCRIPCION", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P2.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("UND", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P3.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("CANTIDAD", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P4.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("P.UNTIARIO", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P5.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString("SUB TOTAL", FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P6.Left, PosicionSinEncabezado - 30)
        e.Graphics.DrawString(Form_Imprimir_Coti.lineatop.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.lineatop.Left, PosicionSinEncabezado - 20)

        'Imprimimos los detalles del reporte, es decir el listado de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim startX As Integer = Form_Imprimir_Coti.P1.Left 'Tomamos la posicion horinzontal de la letra 'Punto1'
        Dim startY As Integer = Form_Imprimir_Coti.P1.Top 'Tomamos la posicion vertical de la letra 'Punto1'
        Dim item As Integer = 1
        Do While printLine < Form_Imprimir_Coti.DataGridView1.Rows.Count
            If startY + Form_Imprimir_Coti.P1.Height > e.MarginBounds.Bottom Then
                'Esta parte se activa solo si 'startY' que es la posicion vertical almacenada supera el borde inferior de la pagina
                'Este se reinicia con cada pagina necesitada
                'Form_Impresion_OC.lbNumeroPagina.Text = CInt(Form_Impresion_OC.lbNumeroPagina.Text) + 1
                e.HasMorePages = True
                Exit Do

            End If

            e.Graphics.DrawString(item, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P1.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(3).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P2.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(4).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P3.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(2).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P4.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(5).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P5.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(7).Value.ToString, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.P6.Left, startY)
            Dim val_sub As Decimal = Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(7).Value
            Dim val_util As Decimal = Form_Imprimir_Coti.DataGridView1.Rows(printLine).Cells(11).Value
            'Aqui estoy usando un tipo de letras mas grande 'LabelCodigo' mas grande que 'Punto1' para crear mas espacio entre filas
            '----------------------------------------------------------------------------------
            startY += Form_Imprimir_Coti.LABEL_DIREC_LOCAL.Height

            printLine += 1
            Contador += 1
            item += 1
            SUBTOTAL_COTI += val_sub
            UTIL_TOTAL += val_util

        Loop

        IGV_COTI = (SUBTOTAL_COTI + UTIL_TOTAL) * Form_Cotizacion.porc_igv
        TOTAL_COTI = SUBTOTAL_COTI + UTIL_TOTAL + IGV_COTI
        Form_Imprimir_Coti.MONT_UTIL.Text = Format("0.00", UTIL_TOTAL)
        Form_Imprimir_Coti.SUBTOTAL.Text = Format("0.00", SUBTOTAL_COTI)
        Form_Imprimir_Coti.IGV.Text = Format("0.00", IGV_COTI)
        Form_Imprimir_Coti.TOTAL.Text = Format("0.00", TOTAL_COTI)
        CONSIDERACIONES = "1. Los precios están expresados en dólares americanos y no incluyen el Impuesto General a las Ventas.
2. El plazo de entrega cuenta a partir de la confirmación de la recepción y conformidad de su Orden de Compra.
3. ZITRO SOLUCIONES INTEGRALES SAC no se hará responsable por incumplimientos en sus obligaciones cuando éstas 
se vean afectadas por causas de fuerza mayor o ajenas a su voluntad, tales como guerras, hurto, vandalismo, conmoción civil, huelgas,
insurrección, escasez de insumos, reprogramación de fábrica, dumping, bloqueos, trasbordos, cancelación de vuelos o naves, 
inconsistencia de carga, proceso aduanero, epidemias, siniestros, desastres naturales.
4. Las condiciones y precios de esta Proforma están sujetos a las cantidades solicitadas. Cualquier variación de estas
cantidades podrá variar las condiciones ofrecidas.
5. El CLIENTE aceptará entregas y facturación parciales, así como el pago de las mismas en las fechas de vencimiento.
6. Los precios no incluyen ningún trabajo de ingeniería, instalación, mantenimiento, pruebas y certificaciones de los materiales. 
De acuerdo con lo expresado por cada fabricante, las especificaciones técnicas de sus productos están sujetas a cambio
sin previo aviso.
7. Los diseños y configuraciones son sugerencias que deberán ser validadas por el personal calificado del Cliente."
        Form_Imprimir_Coti.CONSIDERACIONES.Text = CONSIDERACIONES
        'Con el contador solamente imprimimos la parte final del reporte si ha alcanzado el total de registros
        'Si deseamos repetir la parte final del reporte en cada pagina, debemos quitar en contador
        ''Imprimimos los valores que salen despues del datagridview al final del reporte

        If Contador >= Form_Imprimir_Coti.DataGridView1.Rows.Count Then
            e.Graphics.DrawString(Form_Imprimir_Coti.LINEAFONDO.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.LINEAFONDO.Left, startY)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_UTIL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_UTIL.Left, startY + 20)
            e.Graphics.DrawString(Form_Imprimir_Coti.MONT_UTIL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.MONT_UTIL.Left, startY + 20)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_SUBTOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_SUBTOTAL.Left, startY + 40)
            e.Graphics.DrawString(Form_Imprimir_Coti.SUBTOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.SUBTOTAL.Left, startY + 40)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_IGV.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_IGV.Left, startY + 60)
            e.Graphics.DrawString(Form_Imprimir_Coti.IGV.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.IGV.Left, startY + 60)
            e.Graphics.DrawString(Form_Imprimir_Coti.Label_TOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.Label_TOTAL.Left, startY + 80)
            e.Graphics.DrawString(Form_Imprimir_Coti.TOTAL.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.TOTAL.Left, startY + 80)
            'Dim newImage2 As Image = Form_Imprimir_Coti.PictureBox2.Image : e.Graphics.DrawImage(newImage2, Form_Imprimir_Coti.P5.Left, startY + 90, Form_Imprimir_Coti.PictureBox2.Width, Form_Imprimir_Coti.PictureBox2.Height)
            e.Graphics.DrawString(Form_Imprimir_Coti.CONSIDERACIONES.Text, FuenteNegrita, Brushes.Black, Form_Imprimir_Coti.P1.Left, startY + 100)
        End If
        ' Form_Impresion_OC.lbNumeroPagina.Text = CInt(Form_Impresion_OC.lbNumeroPagina.Text) + 1
        'Form_Impresion_OC.lbNumeroPagina.Text = 1
        ' e.Graphics.DrawString(Form_Impresion_OC.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.Pag_N.Left, e.MarginBounds.Bottom)
        'e.Graphics.DrawString(Form_Impresion_OC.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Impresion_OC.lbNumeroPagina.Left, e.MarginBounds.Bottom)
        Form_Imprimir_Coti.lbNumeroPagina.Text = CInt(Form_Imprimir_Coti.lbNumeroPagina.Text) + 1
        'Form_Impresion_OC.lbNumeroPagina.Text = 1
        e.Graphics.DrawString(Form_Imprimir_Coti.Pag_N.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.Pag_N.Left, e.MarginBounds.Bottom)
        e.Graphics.DrawString(Form_Imprimir_Coti.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, Form_Imprimir_Coti.lbNumeroPagina.Left, e.MarginBounds.Bottom)
    End Sub
End Class