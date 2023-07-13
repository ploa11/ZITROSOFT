Imports System.Drawing.Printing

Public Class Form1
    Dim AdaptadorReporte As OleDb.OleDbDataAdapter
    Dim printLine As Integer = 0
    Dim Contador As Integer = 0
    Dim PosicionSinEncabezado As Integer = ImprimirForm.Punto1.Top

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AbrirConexion()

        LlenarConsulta()
    End Sub

    Private Sub LlenarConsulta()
        Dim MateriasCursadas As Integer = 0
        Dim Promedio As Double = 0

        'ImprimirForm.Show()

        Dim da As New OleDb.OleDbDataAdapter("select estudiante.codigo,estudiante.nombre,calificaciones.materia,calificaciones.primer_parcial,calificaciones.segundo_parcial,calificaciones.examen_final,calificaciones.calificacion_final from calificaciones inner join estudiante on calificaciones.codigo=estudiante.codigo where estudiante.nombre like'%" & txtBuscar.Text & "%'", Conexion)

        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            ImprimirForm.DataGridView1.DataSource = ds.Tables(0)
            ImprimirForm.lbEstudiante.Text = ds.Tables(0).Rows(0).Item("nombre").ToString
            ImprimirForm.lbCodigo.Text = ds.Tables(0).Rows(0).Item("codigo").ToString
            ImprimirForm.lbFecha.Text = Date.Today.ToString

            Dim fila As DataRow
            For Each fila In ds.Tables(0).Rows

                Promedio = Promedio + fila("calificacion_final")
            Next

            MateriasCursadas = ds.Tables(0).Rows.Count

            ImprimirForm.lbPromedio.Text = Promedio / MateriasCursadas
            ImprimirForm.lbCursadas.Text = MateriasCursadas

            DataGridView1.DataSource = ds.Tables(0)
        Else
            DataGridView1.DataSource = Nothing
        End If
    End Sub

    Private Sub btnImprimirEncabezado_Click(sender As Object, e As EventArgs) Handles btnImprimirEncabezado.Click
        printLine = 0
        Contador = 0
        ImprimirForm.lbNumeroPagina.Text = "0"

        LlenarConsulta()

        PrintDialog1.Document = PrintDocument1

        'Te deja elegir la impresora
        '----------------------------------------------------------------------
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.Print()
        End If

        ''Imprime en la impresora por defecto
        ''----------------------------------------------------------------------
        'PrintDocument1.Print()

        'Te deja ver un preview del reporte antes de imprimir
        '-----------------------------------------------------------------------
        'PrintPreviewDialog1.Document = PrintDocument1
        'PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        'PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Cualquier variable que desees que conserve su valor debes declararla fuera del Printdocument
        'Todas las variable declaradas dentro de printdocument pierden su valor al cambiar de pagina

        'Definimos los tipos de letras a utilizar en el reporte
        '--------------------------------------------------------------------------------------------------------------------
        Dim FuenteTitulo As New Font("Microsoft Sans Serif", 22)
        Dim FuenteSubtitulo As New Font("Microsoft Sans Serif", 16)
        Dim FuenteNegrita As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        Dim FuenteDetalles As New Font("Microsoft Sans Serif", 9)


        'Imprimimos el encabezado junto con el logo y los datos del estudiante que están antes del datagridview
        '----------------------------------------------------------------------------------------------------------------------
        e.Graphics.DrawString(ImprimirForm.LabelEmpresa.Text, FuenteTitulo, Brushes.Black, ImprimirForm.LabelEmpresa.Left, ImprimirForm.LabelEmpresa.Top)
        e.Graphics.DrawString(ImprimirForm.LabelDireccion.Text, FuenteSubtitulo, Brushes.Black, ImprimirForm.LabelDireccion.Left, ImprimirForm.LabelDireccion.Top)
        e.Graphics.DrawString(ImprimirForm.LabelTelefono.Text, FuenteSubtitulo, Brushes.Black, ImprimirForm.LabelTelefono.Left, ImprimirForm.LabelTelefono.Top)
        Dim newImage As Image = ImprimirForm.PictureBox1.Image : e.Graphics.DrawImage(newImage, ImprimirForm.PictureBox1.Left, ImprimirForm.PictureBox1.Top, ImprimirForm.PictureBox1.Width, ImprimirForm.PictureBox1.Height)

        e.Graphics.DrawString(ImprimirForm.LabelFecha.Text, FuenteNegrita, Brushes.Black, ImprimirForm.LabelFecha.Left, ImprimirForm.LabelFecha.Top)
        e.Graphics.DrawString(ImprimirForm.lbFecha.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbFecha.Left, ImprimirForm.lbFecha.Top)
        e.Graphics.DrawString(ImprimirForm.LabelEstudiante.Text, FuenteNegrita, Brushes.Black, ImprimirForm.LabelEstudiante.Left, ImprimirForm.LabelEstudiante.Top)
        e.Graphics.DrawString(ImprimirForm.lbEstudiante.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbEstudiante.Left, ImprimirForm.lbEstudiante.Top)
        e.Graphics.DrawString(ImprimirForm.LabelCodigo.Text, FuenteNegrita, Brushes.Black, ImprimirForm.LabelCodigo.Left, ImprimirForm.LabelCodigo.Top)
        e.Graphics.DrawString(ImprimirForm.lbCodigo.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbCodigo.Left, ImprimirForm.lbCodigo.Top)

        'Imprimimos el encabezado o titulo de la lista de materias por encima de los puntos definidos
        '-----------------------------------------------------------------------------------------------------------------------------
        e.Graphics.DrawString("Materia", FuenteDetalles, Brushes.Black, ImprimirForm.Punto1.Left, ImprimirForm.Punto1.Top - 30)
        e.Graphics.DrawString("Primer parcial", FuenteDetalles, Brushes.Black, ImprimirForm.Punto2.Left, ImprimirForm.Punto1.Top - 30)
        e.Graphics.DrawString("Segundo parcial", FuenteDetalles, Brushes.Black, ImprimirForm.Punto3.Left, ImprimirForm.Punto1.Top - 30)
        e.Graphics.DrawString("Examen final", FuenteDetalles, Brushes.Black, ImprimirForm.Punto4.Left, ImprimirForm.Punto1.Top - 30)
        e.Graphics.DrawString("Calificacion", FuenteDetalles, Brushes.Black, ImprimirForm.Punto5.Left, ImprimirForm.Punto1.Top - 30)
        e.Graphics.DrawString(ImprimirForm.LineaTop.Text, FuenteDetalles, Brushes.Black, ImprimirForm.LineaTop.Left, ImprimirForm.LineaTop.Top) 'imprimimos la linea debajo de los encabezados


        'Imprimimos los detalles del reporte, es decir el listado de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim startX As Integer = ImprimirForm.Punto1.Left 'Tomamos la posicion horinzontal de la letra 'Punto1'
        Dim startY As Integer = ImprimirForm.Punto1.Top 'Tomamos la posicion vertical de la letra 'Punto1'

        Do While printLine < ImprimirForm.DataGridView1.Rows.Count
            If startY + ImprimirForm.Punto1.Height > e.MarginBounds.Bottom Then
                'Esta parte se activa solo si 'startY' que es la posicion vertical almacenada supera el borde inferior de la pagina
                'Este se reinicia con cada pagina necesitada
                e.HasMorePages = True
                Exit Do
            End If
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("materia").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto1.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("primer_parcial").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto2.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("segundo_parcial").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto3.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("examen_final").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto4.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("calificacion").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto5.Left, startY)

            'Aqui estoy usando un tipo de letras mas grande 'LabelCodigo' mas grande que 'Punto1' para crear mas espacio entre filas
            '----------------------------------------------------------------------------------
            startY += ImprimirForm.LabelCodigo.Height

            printLine += 1
            Contador += 1
        Loop

        'Con el contador solamente imprimimos la parte final del reporte si ha alcanzado el total de registros
        'Si deseamos repetir la parte final del reporte en cada pagina, debemos quitar en contador
        ''Imprimimos los valores que salen despues del datagridview al final del reporte
        ''-----------------------------------------------------------------------------------------------------------------------------
        If Contador >= ImprimirForm.DataGridView1.Rows.Count Then
            e.Graphics.DrawString(ImprimirForm.LineaFondo.Text, FuenteDetalles, Brushes.Black, ImprimirForm.LineaFondo.Left, startY)
            e.Graphics.DrawString(ImprimirForm.LabelCursadas.Text, FuenteNegrita, Brushes.Black, ImprimirForm.LabelCursadas.Left, startY + 15)
            e.Graphics.DrawString(ImprimirForm.LabelPromedio.Text, FuenteNegrita, Brushes.Black, ImprimirForm.LabelPromedio.Left, startY + 30)
            e.Graphics.DrawString(ImprimirForm.lbCursadas.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbCursadas.Left, startY + 15)
            e.Graphics.DrawString(ImprimirForm.lbPromedio.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbPromedio.Left, startY + 30)

        End If

        'Si deseamos poner un contador de páginas
        'Esta parte siempre va a salir en todas las paginas
        '---------------------------------------------------------------------------------------------
        ImprimirForm.lbNumeroPagina.Text = CInt(ImprimirForm.lbNumeroPagina.Text) + 1
        e.Graphics.DrawString(ImprimirForm.LabelPagina.Text, FuenteDetalles, Brushes.Black, ImprimirForm.LabelPagina.Left, e.MarginBounds.Bottom)
        e.Graphics.DrawString(ImprimirForm.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbNumeroPagina.Left, e.MarginBounds.Bottom)


    End Sub

    Private Sub btnImprimirNormal_Click(sender As Object, e As EventArgs) Handles btnImprimirNormal.Click
        printLine = 0
        Contador = 0
        ImprimirForm.lbNumeroPagina.Text = "0"

        LlenarConsulta()

        'Te deja ver un preview del reporte antes de imprimir
        '-----------------------------------------------------------------------
        PrintPreviewDialog1.Document = PrintDocument2
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()

    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument2.PrintPage
        'Cualquier variable que desees que conserve su valor debes declararla fuera del Printdocument
        'Todas las variable declaradas dentro de printdocument pierden su valor al cambiar de pagina



        'Definimos los tipos de letras a utilizar en el reporte
        '--------------------------------------------------------------------------------------------------------------------
        Dim FuenteTitulo As New Font("Microsoft Sans Serif", 22)
        Dim FuenteSubtitulo As New Font("Microsoft Sans Serif", 16)
        Dim FuenteNegrita As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        Dim FuenteDetalles As New Font("Microsoft Sans Serif", 9)

        'Si deseamos poner un contador de páginas
        'Esta parte siempre va a salir en todas las paginas
        '---------------------------------------------------------------------------------------------
        ImprimirForm.lbNumeroPagina.Text = CInt(ImprimirForm.lbNumeroPagina.Text) + 1
        e.Graphics.DrawString(ImprimirForm.LabelPagina.Text, FuenteDetalles, Brushes.Black, ImprimirForm.LabelPagina.Left, e.MarginBounds.Bottom)
        e.Graphics.DrawString(ImprimirForm.lbNumeroPagina.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbNumeroPagina.Left, e.MarginBounds.Bottom)



        'Este encabezado no aparecera en la segunda pagina

        If CInt(ImprimirForm.lbNumeroPagina.Text) <= 1 Then
            'Imprimimos el encabezado junto con el logo y los datos del estudiante que están antes del datagridview
            '----------------------------------------------------------------------------------------------------------------------
            e.Graphics.DrawString(ImprimirForm.LabelEmpresa.Text, FuenteTitulo, Brushes.Black, ImprimirForm.LabelEmpresa.Left, ImprimirForm.LabelEmpresa.Top)
            e.Graphics.DrawString(ImprimirForm.LabelDireccion.Text, FuenteSubtitulo, Brushes.Black, ImprimirForm.LabelDireccion.Left, ImprimirForm.LabelDireccion.Top)
            e.Graphics.DrawString(ImprimirForm.LabelTelefono.Text, FuenteSubtitulo, Brushes.Black, ImprimirForm.LabelTelefono.Left, ImprimirForm.LabelTelefono.Top)
            Dim newImage As Image = ImprimirForm.PictureBox1.Image : e.Graphics.DrawImage(newImage, ImprimirForm.PictureBox1.Left, ImprimirForm.PictureBox1.Top, ImprimirForm.PictureBox1.Width, ImprimirForm.PictureBox1.Height)

            e.Graphics.DrawString(ImprimirForm.LabelFecha.Text, FuenteNegrita, Brushes.Black, ImprimirForm.LabelFecha.Left, ImprimirForm.LabelFecha.Top)
            e.Graphics.DrawString(ImprimirForm.lbFecha.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbFecha.Left, ImprimirForm.lbFecha.Top)
            e.Graphics.DrawString(ImprimirForm.LabelEstudiante.Text, FuenteNegrita, Brushes.Black, ImprimirForm.LabelEstudiante.Left, ImprimirForm.LabelEstudiante.Top)
            e.Graphics.DrawString(ImprimirForm.lbEstudiante.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbEstudiante.Left, ImprimirForm.lbEstudiante.Top)
            e.Graphics.DrawString(ImprimirForm.LabelCodigo.Text, FuenteNegrita, Brushes.Black, ImprimirForm.LabelCodigo.Left, ImprimirForm.LabelCodigo.Top)
            e.Graphics.DrawString(ImprimirForm.lbCodigo.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbCodigo.Left, ImprimirForm.lbCodigo.Top)

            PosicionSinEncabezado = ImprimirForm.Punto1.Top 'Reseteo el valor de esta variable si entra en esta condicion para evitar que el encabezado se posicione mal
        End If


        'Imprimimos el encabezado o titulo de la lista de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        e.Graphics.DrawString("Materia", FuenteDetalles, Brushes.Black, ImprimirForm.Punto1.Left, PosicionSinEncabezado - 35)
        e.Graphics.DrawString("Primer parcial", FuenteDetalles, Brushes.Black, ImprimirForm.Punto2.Left, PosicionSinEncabezado - 35)
        e.Graphics.DrawString("Segundo parcial", FuenteDetalles, Brushes.Black, ImprimirForm.Punto3.Left, PosicionSinEncabezado - 35)
        e.Graphics.DrawString("Examen final", FuenteDetalles, Brushes.Black, ImprimirForm.Punto4.Left, PosicionSinEncabezado - 35)
        e.Graphics.DrawString("Calificacion", FuenteDetalles, Brushes.Black, ImprimirForm.Punto5.Left, PosicionSinEncabezado - 35)
        e.Graphics.DrawString(ImprimirForm.LineaTop.Text, FuenteDetalles, Brushes.Black, ImprimirForm.LineaTop.Left, PosicionSinEncabezado - 25)



        'Imprimimos los detalles del reporte, es decir el listado de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        Dim startX As Integer = ImprimirForm.Punto1.Left 'Tomamos la posicion horinzontal de la letra 'Punto1'
        Dim startY As Integer = PosicionSinEncabezado 'Tomamos la posicion vertical de la letra 'Punto1'

        Do While printLine < ImprimirForm.DataGridView1.Rows.Count
            If startY + ImprimirForm.Punto1.Height > e.MarginBounds.Bottom Then
                'Esta parte se activa solo si 'startY' que es la posicion vertical almacenada supera el borde inferior de la pagina
                'Este se reinicia con cada pagina necesitada
                e.HasMorePages = True
                PosicionSinEncabezado = e.MarginBounds.Top 'A partir de la segunda pagina empieza la lista desde arriba
                Exit Do
            End If
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("materia").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto1.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("primer_parcial").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto2.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("segundo_parcial").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto3.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("examen_final").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto4.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("calificacion").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto5.Left, startY)

            'Aqui estoy usando un tipo de letras mas grande 'LabelCodigo' mas grande que 'Punto1' para crear mas espacio entre filas
            '----------------------------------------------------------------------------------
            startY += ImprimirForm.LabelCodigo.Height

            printLine += 1
            Contador += 1
        Loop

        'Con el contador solamente imprimimos la parte final del reporte si ha alcanzado el total de registros
        'Si deseamos repetir la parte final del reporte en cada pagina, debemos quitar en contador
        ''Imprimimos los valores que salen despues del datagridview al final del reporte
        ''-----------------------------------------------------------------------------------------------------------------------------
        If Contador >= ImprimirForm.DataGridView1.Rows.Count Then
            e.Graphics.DrawString(ImprimirForm.LineaFondo.Text, FuenteDetalles, Brushes.Black, ImprimirForm.LineaFondo.Left, startY)
            e.Graphics.DrawString(ImprimirForm.LabelCursadas.Text, FuenteNegrita, Brushes.Black, ImprimirForm.LabelCursadas.Left, startY + 15)
            e.Graphics.DrawString(ImprimirForm.LabelPromedio.Text, FuenteNegrita, Brushes.Black, ImprimirForm.LabelPromedio.Left, startY + 30)
            e.Graphics.DrawString(ImprimirForm.lbCursadas.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbCursadas.Left, startY + 15)
            e.Graphics.DrawString(ImprimirForm.lbPromedio.Text, FuenteDetalles, Brushes.Black, ImprimirForm.lbPromedio.Left, startY + 30)

        End If


        'Para dibujar una linea
        'Dim blackPen As New Pen(Color.Black, 2) : e.Graphics.DrawLine(blackPen, e.MarginBounds.Left, 15, e.MarginBounds.Right, 15)
        'Para dibujar una circulo
        'Dim blackcircle As New Pen(Color.Black, 2) : e.Graphics.DrawEllipse(blackPen, 20, 40, 120, 120)
    End Sub

    Private Sub btnImprimirDatagrid_Click(sender As Object, e As EventArgs) Handles btnImprimirDatagrid.Click
        'Te deja ver un preview del reporte antes de imprimir
        '-----------------------------------------------------------------------
        PrintPreviewDialog1.Document = PrintDocument3
        PrintPreviewDialog1.WindowState = FormWindowState.Maximized
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument3_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument3.PrintPage
        'Definimos los tipos de letras a utilizar en el reporte
        '--------------------------------------------------------------------------------------------------------------------
        Dim FuenteDetalles As New Font("Microsoft Sans Serif", 9)

        Dim startY As Integer = e.MarginBounds.Top  'Tomamos como referencia vertical la distancia minima permitida por los márgenes de la página

        'Imprimimos el encabezado o titulo de la lista de materias
        '-----------------------------------------------------------------------------------------------------------------------------
        e.Graphics.DrawString("Materia", FuenteDetalles, Brushes.Black, ImprimirForm.Punto1.Left, startY - 30)
        e.Graphics.DrawString("Primer parcial", FuenteDetalles, Brushes.Black, ImprimirForm.Punto2.Left, startY - 30)
        e.Graphics.DrawString("Segundo parcial", FuenteDetalles, Brushes.Black, ImprimirForm.Punto3.Left, startY - 30)
        e.Graphics.DrawString("Examen final", FuenteDetalles, Brushes.Black, ImprimirForm.Punto4.Left, startY - 30)
        e.Graphics.DrawString("Calificacion", FuenteDetalles, Brushes.Black, ImprimirForm.Punto5.Left, startY - 30)
        e.Graphics.DrawString(ImprimirForm.LineaTop.Text, FuenteDetalles, Brushes.Black, ImprimirForm.LineaTop.Left, startY - 15)


        Do While printLine < ImprimirForm.DataGridView1.Rows.Count
            If startY + ImprimirForm.Punto1.Height > e.MarginBounds.Bottom Then
                'Esta parte se activa solo si 'startY' que es la posicion vertical almacenada supera el borde inferior de la pagina
                'Este se reinicia con cada pagina necesitada
                e.HasMorePages = True
                'PosicionSinEncabezado = e.MarginBounds.Top 'A partir de la segunda pagina empieza la lista desde arriba
                Exit Do
            End If
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("materia").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto1.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("primer_parcial").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto2.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("segundo_parcial").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto3.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("examen_final").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto4.Left, startY)
            e.Graphics.DrawString(ImprimirForm.DataGridView1.Rows(printLine).Cells("calificacion").Value.ToString, FuenteDetalles, Brushes.Black, ImprimirForm.Punto5.Left, startY)

            'Aqui estoy usando un tipo de letras mas grande 'LabelCodigo' mas grande que 'Punto1' para crear mas espacio entre filas
            '----------------------------------------------------------------------------------
            startY += ImprimirForm.LabelCodigo.Height

            printLine += 1
            Contador += 1
        Loop
    End Sub
End Class
