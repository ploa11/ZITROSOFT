Public Class rev_cro_anx
    Dim _enabledCerrar As Boolean = False
    <System.ComponentModel.DefaultValue(False), System.ComponentModel.Description("Define si se habilita el botón cerrar en el formulario")>
    Public Property EnabledCerrar() As Boolean
        Get
            Return _enabledCerrar
        End Get
        Set(ByVal Value As Boolean)
            If _enabledCerrar <> Value Then
                _enabledCerrar = Value
            End If
        End Set
    End Property
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            If _enabledCerrar = False Then
                Const CS_NOCLOSE As Integer = &H200
                cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            End If
            Return cp
        End Get
    End Property
    Dim i As Integer = 0
    Dim res, res2 As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Public cod_clie, cod_anx, igv_comi_tran, mont_t_trans, suma_interes, igv_suma_int, mont_tot_interes, total_abono, total_anexo, gest, fec_expo, int_d, cod_cronograma As String

    Private Sub cb2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb2.SelectedIndexChanged
        Select Case cb2.Text
            Case "Codigo de Cliente"
                t24.Enabled = True
                dtp4.Enabled = False
                cb3.Enabled = False
                Label6.Visible = False
                Label7.Visible = False
                dtp5.Visible = False
                dtp6.Visible = False
                Button1.Visible = False
            Case "Codigo de Operacion"
                t24.Enabled = True
                dtp4.Enabled = False
                cb3.Enabled = False
                Label6.Visible = False
                Label7.Visible = False
                dtp5.Visible = False
                dtp6.Visible = False
                Button1.Visible = False
            Case "Fecha de Inicio"
                t24.Enabled = False
                dtp4.Enabled = True
                cb3.Enabled = False
                Label6.Visible = False
                Label7.Visible = False
                dtp5.Visible = False
                dtp6.Visible = False
                Button1.Visible = False
            Case "Fecha de Termino"
                t24.Enabled = False
                dtp4.Enabled = True
                cb3.Enabled = False
                Label6.Visible = False
                Label7.Visible = False
                dtp5.Visible = False
                dtp6.Visible = False
                Button1.Visible = False
            Case "Estado"
                t24.Enabled = False
                dtp4.Enabled = False
                cb3.Enabled = True
                Label6.Visible = False
                Label7.Visible = False
                dtp5.Visible = False
                dtp6.Visible = False
                Button1.Visible = False
            Case "Rangos de Fechas"
                t24.Enabled = False
                dtp4.Enabled = False
                cb3.Enabled = False
                Label6.Visible = True
                Label7.Visible = True
                dtp5.Visible = True
                dtp6.Visible = True
                Button1.Visible = True
                Label6.Enabled = True
                Label7.Enabled = True
                dtp5.Enabled = True
                dtp6.Enabled = True

        End Select
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged
        Select Case cb1.Text
            Case "Cronogramas"
                Crono()
                coloini()
                cb2.Enabled = True
            Case "Anexos"
                anexos()
                coloini()
                cb2.Enabled = True
            Case "Cuotas Cronogramas"
                cuotas_cronogramas()
                coloini()
                cb2.Enabled = True
            Case "Facturas Anexos"
                fac_anexos()
                coloini()
                cb2.Enabled = True
            Case "Ambos Cronogramas y Anexos"
                cro_anx()
                cb2.Enabled = True
            Case "Ambos Cuotas y Facturas"
                cuot_fact()
                cb2.Enabled = True
        End Select
    End Sub

    Dim ref, est, mont_comi, p_det, p_des, p_int_cob, p_igv, n_doc, fec_ven_exp, fec_rec_exp, n_dias, cliente, acep, mont_fac, mont_detr, mon_net, mont_des, mont_int_cob, mont_igv, abono, por_comi As String

    Private Sub cb3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb3.SelectedIndexChanged
        Select Case cb1.Text
            Case "Cronogramas"
                Select Case cb2.Text
                    Case "Estado"
                        fil_estado_crono()
                End Select
            Case "Anexos"
                Select Case cb2.Text
                    Case "Estado"
                        fil_estado_ANX()
                End Select
            Case "Cuotas Cronogramas"
                Select Case cb2.Text
                    Case "Estado"
                        fil_estado_cuota()
                End Select
            Case "Facturas Anexos"
                Select Case cb2.Text
                    Case "Estado"
                        fil_estado_fact()
                End Select
            Case "Ambos Cronogramas y Anexos"
                Select Case cb2.Text
                    Case "Estado"
                        fil_cro_anx_estado()
                End Select
            Case "Ambos Cuotas y Facturas"
                Select Case cb2.Text
                    Case "Estado"
                        fil_cuot_fact_estado()

                End Select
        End Select
    End Sub

    Private Sub t24_TextChanged(sender As Object, e As EventArgs) Handles t24.TextChanged
        Select Case cb1.Text
            Case "Cronogramas"
                Select Case cb2.Text
                    Case "Codigo de Cliente"
                        fil_COD_CLIE_CR()
                    Case "Codigo de Operacion"
                        fil_COD_OPE_CR()
                End Select
            Case "Anexos"
                Select Case cb2.Text
                    Case "Codigo de Cliente"
                        fil_COD_CLIE_ANX()
                    Case "Codigo de Operacion"
                        fil_COD_OPE_ANX()
                End Select
            Case "Cuotas Cronogramas"
                Select Case cb2.Text
                    Case "Codigo de Operacion"
                        fil_cod_op_crono()
                    Case "Codigo de Cuota o Factura"
                        fil_cod_doc_ccrono()
                End Select
            Case "Facturas Anexos"
                Select Case cb2.Text
                    Case "Codigo de Operacion"
                        fil_fac_codop_ANEXO()
                    Case "Codigo de Cuota o Factura"
                        fil_cod_doc_anexo()
                End Select
            Case "Ambos Cronogramas y Anexos"
                Select Case cb2.Text
                    Case "Codigo de Cliente"
                        fil_cro_anx_cod_clie()
                    Case "Codigo de Operacion"
                        fil_cro_anx_cod_op()
                End Select
            Case "Ambos Cuotas y Facturas"
                Select Case cb2.Text
                    Case "Codigo de Operacion"
                        fil_cuot_fact_cod_op()
                    Case "Codigo de Cuota o Factura"
                        fil_cuot_fact_cod_doc()
                End Select
        End Select
    End Sub

    Dim sql, sql2, sql3, nc As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fec_ran_ini, fec_ran_fin As Date
        Dim franini, franfin As String

        fec_ran_ini = dtp5.Value
        fec_ran_fin = dtp6.Value
        franini = fec_ran_ini.ToString("yyyyMMdd")
        franfin = fec_ran_fin.ToString("yyyyMMdd")

        Select Case cb1.Text
            Case "Cuotas Cronogramas"
                ran_fec_crono(franini, franfin)
            Case "Facturas Anexos"
                ran_fec_anexo(franini, franfin)
        End Select



    End Sub

    Private Sub ran_fec_crono(fec1, fec2)
        sql = "select  *from v_couta_op where [FECHA DE VENCIMIENTO]>='" + fec1 + "' and [FECHA DE VENCIMIENTO]<='" + fec2 + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select  *from v_couta_op where [FECHA DE VENCIMIENTO]>='" + fec1 + "' and [FECHA DE VENCIMIENTO]<='" + fec2 + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select  *from v_couta_op where [FECHA DE VENCIMIENTO]>='" + fec1 + "' and [FECHA DE VENCIMIENTO]<='" + fec2 + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim save As New SaveFileDialog
        Dim ruta As String
        Dim xlapp As Object = CreateObject("Excel.Application")
        Dim pth As String = ""
        'crea nueva hoja
        Dim xlwb As Object = xlapp.workbooks.add
        Dim xlws As Object = xlwb.worksheets(1)
        Try
            'exportamos los carateres de la columna

            For c As Integer = 0 To dgv.Columns.Count - 1
                xlws.cells(1, c + 1).value = dgv.Columns(c).HeaderText

            Next
            'exporatmaos las cabeceras de las columnas
            For r As Integer = 0 To dgv.RowCount - 1
                'xlws.cells(1, r + 1).value = dgv.Columns(r).HeaderText
                For c As Integer = 0 To dgv.Columns.Count - 1
                    xlws.cells(r + 2, c + 1).value = Convert.ToString(dgv.Item(c, r).Value)

                Next
            Next
            'guardamos la hoja
            Dim savefiledialog1 As SaveFileDialog = New SaveFileDialog
            savefiledialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            savefiledialog1.Filter = "Archivo Excel| *.xlsx"
            savefiledialog1.FilterIndex = 2
            If savefiledialog1.ShowDialog = DialogResult.OK Then
                ruta = savefiledialog1.FileName
                xlwb.saveas(ruta)
                xlws = Nothing
                xlwb = Nothing
                xlapp.quit()
                MsgBox("EXPORTADO CORRECTAMENTE", MsgBoxStyle.Information, "Optima")

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub ran_fec_anexo(fec1, fec2)
        sql = "select  *from v_fac_operacion_anx where [FECHA DE VENCIMIENTO DE DOCUMENTO]>='" + fec1 + "' and [FECHA DE VENCIMIENTO DE DOCUMENTO]<='" + fec2 + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select  *from v_fac_operacion_anx where [FECHA DE VENCIMIENTO DE DOCUMENTO]>='" + fec1 + "' and [FECHA DE VENCIMIENTO DE DOCUMENTO]<='" + fec2 + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select  *from v_fac_operacion_anx where [FECHA DE VENCIMIENTO DE DOCUMENTO]>='" + fec1 + "' and [FECHA DE VENCIMIENTO DE DOCUMENTO]<='" + fec2 + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        'coloini()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Definimos la fuente que vamos a usar para imprimir
        ' en este caso Arial de 10
        Dim printFont As System.Drawing.Font = New Font("Arial", 10)
        Dim topMargin As Double = e.MarginBounds.Top
        Dim yPos As Double = 0
        Dim linesPerPage As Double = 0
        Dim count As Integer = 0
        Dim texto As String = ""
        Dim row As System.Windows.Forms.DataGridViewRow

        ' Calculamos el número de líneas que caben en cada página
        linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics)

        ' Imprimimos las cabeceras
        Dim header As DataGridViewHeaderCell
        For Each column As DataGridViewColumn In dgv.Columns
            header = column.HeaderCell
            texto += vbTab + header.FormattedValue.ToString()
        Next

        yPos = topMargin + (count * printFont.GetHeight(e.Graphics))
        e.Graphics.DrawString(texto, printFont, System.Drawing.Brushes.Black, 10, yPos)
        ' Dejamos una línea de separación
        count += 2

        ' Recorremos las filas del DataGridView hasta que llegemos
        ' a las líneas que nos caben en cada página o al final del grid.
        While count < linesPerPage AndAlso i < dgv.Rows.Count
            row = dgv.Rows(i)
            texto = ""
            For Each celda As System.Windows.Forms.DataGridViewCell In row.Cells
                'Comprobamos que la celda tenga algún valor, en caso de 
                'permitir añadir filas esto es muy importante
                If celda.Value IsNot Nothing Then
                    texto += vbTab + celda.Value.ToString()
                End If
            Next

            ' Calculamos la posición en la que se escribe la línea
            yPos = topMargin + (count * printFont.GetHeight(e.Graphics))

            ' Escribimos la línea con el objeto Graphics
            e.Graphics.DrawString(texto, printFont, System.Drawing.Brushes.Black, 10, yPos)
            ' Incrementamos los contadores
            count += 1
            i += 1
        End While

        ' Una vez fuera del bucle comprobamos si nos quedan más filas
        ' por imprimir, si quedan saldrán en la siguente página
        If i < dgv.Rows.Count Then
            e.HasMorePages = True
        Else
            ' si llegamos al final, se establece HasMorePages a
            ' false para que se acabe la impresión
            e.HasMorePages = False
            ' Es necesario poner el contador a 0 porque, por ejemplo si se hace
            ' una impresión desde PrintPreviewDialog, se vuelve disparar este
            ' evento como si fuese la primera vez, y si i está con el valor de la
            ' última fila del grid no se imprime nada
            i = 0
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.PrintDocument1.Print()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PrintDocument2.Print()

    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        Try
            ' La fuente a usar
            Dim prFont As New Font("Arial", 12, FontStyle.Bold)
            ' la posición superior

            'imprimimos la fecha y hora
            prFont = New Font("Arial", 10, FontStyle.Regular)
            e.Graphics.DrawString(Date.Now.ToShortDateString.ToString & " " &
                                Date.Now.ToShortTimeString.ToString, prFont, Brushes.Black, 700, 20)

            'NOMBRE DE CRONOGRAMA

            'imprimimos el nombre del cliente
            prFont = New Font("Arial", 12, FontStyle.Bold)
            e.Graphics.DrawString("Nombre del Cliente", prFont, Brushes.Black, 24, 250)

            'imprimimos la referencia del pedido
            e.Graphics.DrawString("Referencia", prFont, Brushes.Black, 48, 520)
            prFont = New Font("Arial", 12, FontStyle.Bold)
            e.Graphics.DrawString("Nombre de la Referencia", prFont, Brushes.Black, 12, 555)
            'imprimimos Pedido Ondupack y Pedido del cliente
            prFont = New Font("Arial", 12, FontStyle.Regular)
            e.Graphics.DrawString("Pedido", prFont, Brushes.Black, 62, 660)
            e.Graphics.DrawString("Palets", prFont, Brushes.Black, 62, 660)

            prFont = New Font("Arial", 12, FontStyle.Regular)
            e.Graphics.DrawString("19875", prFont, Brushes.Black, 50, 700)
            e.Graphics.DrawString("44", prFont, Brushes.Black, 250, 700)

            'imprimimos Cajas X Palet y Cajas x Paquete
            prFont = New Font("Arial", 12, FontStyle.Regular)
            e.Graphics.DrawString("Cajas x Palet", prFont, Brushes.Black, 50, 760)
            e.Graphics.DrawString("Cajas x Paquete", prFont, Brushes.Black, 250, 760)

            prFont = New Font("Arial", 12, FontStyle.Regular)
            e.Graphics.DrawString("500", prFont, Brushes.Black, 50, 800)
            e.Graphics.DrawString("32", prFont, Brushes.Black, 250, 800)

            'imprimimos el numero del Palet
            prFont = New Font("Arial", 12, FontStyle.Regular)
            e.Graphics.DrawString("Número del Palet     45", prFont, Brushes.Black, 50, 880)
            'indicamos que hemos llegado al final de la pagina
            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Administrador",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PrintPreviewDialog1.Show()

    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub dtp4_ValueChanged(sender As Object, e As EventArgs) Handles dtp4.ValueChanged
        Select Case cb1.Text
            Case "Cronogramas"
                Select Case cb2.Text
                    Case "Fecha de Inicio"
                        filtro_fec_ini_cro()
                    Case "Fecha de Termino"
                        filtro_fec_fin_cro()
                End Select
            Case "Anexos"
                Select Case cb2.Text
                    Case "Fecha de Inicio"
                        filtro_fec_rep_anx()
                End Select
            Case "Cuotas Cronogramas"
                Select Case cb2.Text
                    Case "Fecha de Inicio"
                        filtro_fec_ini_cuota()
                    Case "Fecha de Termino"
                        filtro_fec_fin_cuota()
                End Select
            Case "Facturas Anexos"
                Select Case cb2.Text
                    Case "Fecha de Inicio"
                        filtro_fec_recp_fact()
                    Case "Fecha de Termino"
                        filtro_fec_ven_fac()
                End Select
            Case "Ambos Cronogramas y Anexos"
                Select Case cb2.Text
                    Case "Fecha de Inicio"
                        fil_fecini_cro_anx()
                End Select
            Case "Ambos Cuotas y Facturas"
                Select Case cb2.Text
                    Case "Fecha de Termino"
                        fil_fecvenc_cuo_fac()
                End Select

        End Select
    End Sub

    Private Sub rev_cro_anx_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False

        Me.Text = "Revision de Cronogramas y Anexos" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text

    End Sub

    Private Sub fac_anexos()
        Try
            sql = "select * from v_fac_operacion_anx"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_fac_operacion_anx")
            dgv.DataSource = ds
            dgv.DataMember = "v_fac_operacion_anx"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub cro_anx()
        Try
            sql = "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx")
            dgv.DataSource = ds
            dgv.DataMember = "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub fil_cro_anx_cod_op()
        Try
            nc = t24.Text
            sql = "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion where cod_op like'" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where cod_anx like'" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion where cod_op like'" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where cod_anx like'" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion where cod_op like'" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where cod_anx like'" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub fil_cro_anx_cod_clie()
        Try
            nc = t24.Text
            sql = "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion where cod_clie like'" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where cod_clie like'" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion where cod_clie like'" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where cod_clie like'" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion where cod_clie like'" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where cod_clie like'" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub fil_cro_anx_estado()
        Try
            nc = cb3.Text
            sql = "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion where estado like'" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where estado like'" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion where estado like'" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where estado like'" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select cod_op AS [CODIGO DE OPERACION], cod_clie AS [CODIGO DE CLIENTE], tip_op AS [TIPO DE OPERACION], mont_prestamo AS [MONTO DE PRESTAMO], f_inicio_pres AS [INICIO DE OPERACION], estado AS [ESTADO] from d_operacion where estado like'" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where estado like'" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub cuot_fact()
        Try
            sql = "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx")
            dgv.DataSource = ds
            dgv.DataMember = "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub fil_cuot_fact_cod_op()
        Try
            nc = t24.Text
            sql = "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where cod_op like '" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where cod_anexo like '" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where cod_op like '" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where cod_anexo like '" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where cod_op like '" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where cod_anexo like '" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub fil_cuot_fact_cod_doc()
        Try
            nc = t24.Text
            sql = "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where cod_cuota like '" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where cod_fac_anx like '" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where cod_cuota like '" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where cod_fac_anx like '" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where cod_cuota like '" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where cod_fac_anx like '" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub fil_cuot_fact_estado()
        Try
            nc = cb3.Text
            sql = "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where estado like '" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where estado like '" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where estado like '" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where estado like '" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where estado like '" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where estado like '" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub filtro_fec_ini_cro()
        Dim f_recp As Date
        Dim ferecp As String
        f_recp = dtp4.Value
        ferecp = f_recp.ToString("yyyyMMdd")
        nc = ferecp
        sql = "select *from v_d_operacion where [FECHA INICIO DE PRESTAMO] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_d_operacion where [FECHA INICIO DE PRESTAMO] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_d_operacion where [FECHA INICIO DE PRESTAMO] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_fec_fin_cro()
        Dim f_recp As Date
        Dim ferecp As String
        f_recp = dtp4.Value
        ferecp = f_recp.ToString("yyyyMMdd")
        nc = ferecp
        sql = "select *from v_d_operacion where [FECHA TERMINO PRESTAMO] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_d_operacion where [FECHA TERMINO PRESTAMO] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_d_operacion where [FECHA TERMINO PRESTAMO] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_fec_rep_anx()
        Dim f_recp As Date
        Dim ferecp As String
        f_recp = dtp4.Value
        ferecp = f_recp.ToString("yyyyMMdd")
        nc = ferecp
        sql = "select *from v_d_operacion_anx where [FECHA DE RECEPCION] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_d_operacion_anx where [FECHA DE RECEPCION] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_d_operacion_anx where [FECHA DE RECEPCION] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_fec_ini_cuota()
        Dim f_recp As Date
        Dim ferecp As String
        f_recp = dtp4.Value
        ferecp = f_recp.ToString("yyyyMMdd")
        nc = ferecp
        sql = "select *from v_couta_op where [FECHA DE INICIO] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [FECHA DE INICIO] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [FECHA DE INICIO] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_fec_fin_cuota()
        Dim f_recp As Date
        Dim ferecp As String
        f_recp = dtp4.Value
        ferecp = f_recp.ToString("yyyyMMdd")
        nc = ferecp
        sql = "select *from v_couta_op where [FECHA DE VENCIMIENTO] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [FECHA DE VENCIMIENTO] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [FECHA DE VENCIMIENTO] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_fec_recp_fact()
        Dim f_recp As Date
        Dim ferecp As String
        f_recp = dtp4.Value
        ferecp = f_recp.ToString("yyyyMMdd")
        nc = ferecp
        sql = "select *from v_fac_operacion_anx where [FECHA DE RECEPCION DE DOCUMENTO] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_fac_operacion_anx where [FECHA DE RECEPCION DE DOCUMENTO] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_fac_operacion_anx where [FECHA DE RECEPCION DE DOCUMENTO] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub


    Private Sub filtro_fec_ven_fac()
        Dim f_recp2 As Date
        Dim ferecp2 As String
        f_recp2 = dtp4.Value
        ferecp2 = f_recp2.ToString("yyyyMMdd")
        nc = ferecp2
        sql = "select *from v_fac_operacion_anx where [FECHA DE VENCIMIENTO DE DOCUMENTO] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_fac_operacion_anx where [FECHA DE VENCIMIENTO DE DOCUMENTO] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_fac_operacion_anx where [FECHA DE VENCIMIENTO DE DOCUMENTO] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub


    Private Sub fil_fac_codop_ANEXO()
        nc = t24.Text
        sql = "select *from v_fac_operacion_anx where [CODIGO DE ANEXO] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_fac_operacion_anx where [CODIGO DE ANEXO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_fac_operacion_anx where [CODIGO DE ANEXO] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub
    Private Sub fil_cod_doc_anexo()
        nc = t24.Text
        sql = "select *from v_fac_operacion_anx where [CODIGO DE DOCUMENTO] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_fac_operacion_anx where [CODIGO DE DOCUMENTO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_fac_operacion_anx where [CODIGO DE DOCUMENTO] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub


    Private Sub fil_cod_op_crono()
        nc = t24.Text
        sql = "select *from v_couta_op where [CODIGO DE OPERACION] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [CODIGO DE OPERACION] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub
    Private Sub fil_cod_doc_ccrono()
        nc = t24.Text
        sql = "select *from v_couta_op where [CODIGO DE CUOTA] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [CODIGO DE CUOTA] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [CODIGO DE CUOTA] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub fil_estado_crono()
        nc = cb3.Text
        sql = "select *from v_d_operacion where [ESTADO] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_d_operacion where [ESTADO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_d_operacion where [ESTADO] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub fil_estado_cuota()
        nc = cb3.Text
        sql = "select *from v_couta_op where [ESTADO] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [ESTADO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [ESTADO] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub fil_estado_ANX()
        nc = cb3.Text
        sql = "select *from v_d_operacion_anx where [ESTADO] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_d_operacion_anx where [ESTADO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_d_operacion_anx where [ESTADO] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub fil_estado_fact()
        nc = cb3.Text
        sql = "select *from v_fac_operacion_anx where [ESTADO] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_fac_operacion_anx where [ESTADO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_fac_operacion_anx where [ESTADO] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub Crono()
        Try
            sql = "select * from v_d_operacion"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_d_operacion")
            dgv.DataSource = ds
            dgv.DataMember = "v_d_operacion"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("No hay conexion con la lista", "Optima")
        End Try

    End Sub

    Private Sub anexos()
        Try
            sql = "select * from v_d_operacion_anx"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_d_operacion_anx")
            dgv.DataSource = ds
            dgv.DataMember = "v_d_operacion_anx"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub cuotas_cronogramas()
        Try
            sql = "select * from v_couta_op"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_couta_op")
            dgv.DataSource = ds
            dgv.DataMember = "v_couta_op"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub


    Private Sub fil_COD_CLIE_CR()
        Try
            nc = t24.Text
            sql = "select *from v_d_operacion where [CODIGO DE CLIENTE] like '" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [CODIGO DE CLIENTE] like '" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [CODIGO DE CLIENTE] like '" + nc + "%'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub

    Private Sub fil_COD_OPE_CR()
        Try
            nc = t24.Text
            sql = "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub

    Private Sub fil_COD_OPE_ANX()
        Try
            nc = t24.Text
            sql = "select *from v_d_operacion_anx where [CODIGO DE ANEXO] like'" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [CODIGO DE OPERACION] like'" + nc + "%'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub

    Private Sub fil_COD_CLIE_ANX()
        Try
            nc = t24.Text
            sql = "select *from v_d_operacion_anx where [CODIGO DE CLIENTE] like'" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [CODIGO DE CLIENTE] like'" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [CODIGO DE CLIENTE] like'" + nc + "%'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub
    Private Sub filtro_fecha()
        Try
            Dim fecha As Date
            Dim fech As String

            fecha = dtp4.Value
            fech = fecha.ToString("yyyyMMdd")
            nc = fech
            sql = "select *from v_d_operacion where [FECHA INICIO DE PRESTAMO] ='" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion where [FECHA INICIO DE PRESTAMO] ='" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion where [FECHA INICIO DE PRESTAMO] ='" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub
    Private Sub fil_fecini_cro_anx()
        Dim fecha2 As Date
        Dim fech2 As String
        Try
            fecha2 = dtp4.Value
            fech2 = fecha2.ToString("yyyyMMdd")
            nc = fech2
            sql = "Select cod_op As [CODIGO DE OPERACION], cod_clie As [CODIGO DE CLIENTE], tip_op As [TIPO DE OPERACION], mont_prestamo As [MONTO DE PRESTAMO], f_inicio_pres As [INICIO DE OPERACION], estado As [ESTADO] from d_operacion where f_inicio_pres='" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where fecha='" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "Select cod_op As [CODIGO DE OPERACION], cod_clie As [CODIGO DE CLIENTE], tip_op As [TIPO DE OPERACION], mont_prestamo As [MONTO DE PRESTAMO], f_inicio_pres As [INICIO DE OPERACION], estado As [ESTADO] from d_operacion where f_inicio_pres='" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where fecha='" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "Select cod_op As [CODIGO DE OPERACION], cod_clie As [CODIGO DE CLIENTE], tip_op As [TIPO DE OPERACION], mont_prestamo As [MONTO DE PRESTAMO], f_inicio_pres As [INICIO DE OPERACION], estado As [ESTADO] from d_operacion where f_inicio_pres='" + nc + "' union all select cod_anx,cod_clie,tip_ope,total,fecha,estado from d_operacion_anx where fecha='" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas")
        End Try

    End Sub

    Private Sub fil_fecvenc_cuo_fac()
        Dim fecha2 As Date
        Dim fech2 As String
        Try
            fecha2 = dtp4.Value
            fech2 = fecha2.ToString("yyyyMMdd")
            nc = fech2
            sql = "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where fecha='" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where fec_venc_doc='" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where fecha='" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where fec_venc_doc='" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select cod_cuota as[CODIGO], COD_OP AS [CODIGO DE OPERACION], T_CUOTA as [MONTO], DIAS, FECHA AS [FECHA DE VENCIMIENTO], estado AS [ESTADO] from CUOTAS_OPERACION where fecha='" + nc + "'union all select cod_fac_anx,cod_anexo,abono,num_dias_fact,fec_venc_doc,estado from fac_operacion_anx where fec_venc_doc='" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas")
        End Try

    End Sub

    Public Sub coloini()

        For Each Row As DataGridViewRow In dgv.Rows
            Select Case cb1.Text
                Case "Cronogramas"
                    Select Case Row.Cells("FECHA TERMINO PRESTAMO").Value
                        Case > Today
                            Row.DefaultCellStyle.BackColor = Color.OliveDrab
                            Row.DefaultCellStyle.ForeColor = Color.Black
                        Case <= Today
                            Row.DefaultCellStyle.BackColor = Color.Maroon
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select

                Case "Anexos"
                    Select Case Row.Cells("FECHA DE RECEPCION").Value
                        Case > Today
                            Row.DefaultCellStyle.BackColor = Color.OliveDrab
                            Row.DefaultCellStyle.ForeColor = Color.Black
                        Case <= Today
                            Row.DefaultCellStyle.BackColor = Color.Maroon
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select

                Case "Cuotas Cronogramas"
                    Select Case Row.Cells("FECHA DE VENCIMIENTO").Value
                        Case > Today
                            Row.DefaultCellStyle.BackColor = Color.OliveDrab
                            Row.DefaultCellStyle.ForeColor = Color.Black
                        Case <= Today
                            Row.DefaultCellStyle.BackColor = Color.Maroon
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select

                Case "Facturas Anexos"
                    Select Case Row.Cells("FECHA DE VENCIMIENTO DE DOCUMENTO").Value
                        Case > Today
                            Row.DefaultCellStyle.BackColor = Color.OliveDrab
                            Row.DefaultCellStyle.ForeColor = Color.Black
                        Case <= Today
                            Row.DefaultCellStyle.BackColor = Color.Maroon
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select

                Case ""
                    If Row.Cells("FECHA DE ADELANTO Y MORA").Value > Row.Cells("FECHA DE VENCIMIENTO").Value Then
                        Row.DefaultCellStyle.BackColor = Color.Red
                        Row.DefaultCellStyle.ForeColor = Color.White
                    Else
                        'If Row.Cells("ESTADO").Value = "VIGENTE" Then
                        'Row.DefaultCellStyle.BackColor = Color.Blue
                        'Row.DefaultCellStyle.ForeColor = Color.White
                        'Else
                        If Row.Cells("FECHA DE VENCIMIENTO").Value < Today Then
                            Row.DefaultCellStyle.BackColor = Color.Maroon
                            Row.DefaultCellStyle.ForeColor = Color.White
                        Else
                            If Row.Cells("FECHA DE VENCIMIENTO").Value >= Today Then
                                Row.DefaultCellStyle.BackColor = Color.OliveDrab
                                Row.DefaultCellStyle.ForeColor = Color.Black
                            End If
                        End If
                        End If
                    'End If

            End Select


            'If Today = Row.Cells("FECHA INICIO DE PRESTAMO").Value Then
            'Row.DefaultCellStyle.BackColor = Color.Blue
            'Row.DefaultCellStyle.ForeColor = Color.White
            'End If


        Next

    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Select Case cb1.Text
            Case ""
                Cuotas_Operacion.rev_cro_anx = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                Cuotas_Operacion.verifi = 2
                Cuotas_Operacion.buscar_cambiar_estado()
                Cuotas_Operacion.Show()
                Cuotas_Operacion.BUSCA_MORA()
                Cuotas_Operacion.dgv.Visible = False
                Cuotas_Operacion.GroupBox1.Visible = False
                Cuotas_Operacion.Button13.Visible = False

            Case "Cronogramas"
                cod_cronograma = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                Anex_Cronog.buscar_rev_cro_anx()
                Anex_Cronog.dgv.Visible = False
                Anex_Cronog.Show()

            Case "Anexos"

            Case "Cuotas Cronogramas"
                Cuotas_Operacion.rev_cro_anx = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                Cuotas_Operacion.verifi = 2
                Cuotas_Operacion.buscar_cambiar_estado()
                Cuotas_Operacion.Show()
                Cuotas_Operacion.BUSCA_MORA()
                Cuotas_Operacion.dgv.Visible = False
                Cuotas_Operacion.GroupBox1.Visible = False
                Cuotas_Operacion.Button13.Visible = False
        End Select




    End Sub

    Private Sub dgv_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.CellMouseClick

    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        coloini()
    End Sub

    Private Sub dgv_CellErrorTextNeeded(sender As Object, e As DataGridViewCellErrorTextNeededEventArgs) Handles dgv.CellErrorTextNeeded

    End Sub

    Private Sub dgv_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.ColumnHeaderMouseClick
        coloini()
    End Sub
End Class