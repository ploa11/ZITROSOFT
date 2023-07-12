Imports System.ComponentModel
Imports System.Threading
Imports System.Data.OleDb 'Importacion necesaria para trabajar con ficheros excel



Public Class Amortizacion
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
    'Public ReadOnly Property IsBusy As Boolean
    Dim FECHA As DateTime '= Now
    Dim fecha_cambio As DateTime
    Dim fechaf As DateTime '= Now
    Dim f_final, f_comp As DateTime
    Dim fe_reg, accion, fechamo As String, nc As String, sql As String, sql2 As String, area As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader, dr2 As SqlClient.SqlDataAdapter
    Dim dias_c, dias_d, res, i_tens As Integer
    Dim cuo_int_igv2 As Single
    Dim cuotaobjetivo As Decimal
    Dim pendienteobjetivo As Decimal
    Dim cuotafinal As Decimal
    Dim pendientef, cuotaf As Decimal
    Dim close_for As Decimal
    Public tinteres As Decimal

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub cuotas_manuales()
        ListView1.Items.Clear()
        Try
            'Dim preg As String
            Dim PRESTAMO As Decimal = diasnumero.VCRONOG.Text
            'Dim TIPO As Single = ((1 + (TextBoxINTERES.Text / 100) / 30) ^ DIAS.Text - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            Dim TIPO As Single '= ((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            'Dim TIPO As Single '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1)
            'Dim DIAS_PERIODO As Integer
            Dim igv As Decimal
            Dim PERIODOS As Integer = 1
            Dim TPERIODOS As Integer
            Dim CUOTA As Single '= Pmt(TIPO, PERIODOS, -PRESTAMO, 0, 0) 'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
            Dim cuo_int_igv As Single
            Dim INTERESES As Single = Nothing
            Dim TIGV As Single = Nothing
            Dim TINTERESES As Single = Nothing
            Dim AMORTIZACION As Single = Nothing
            Dim TAMORTIZACION As Single = Nothing
            Dim TCUOTAS As Single = Nothing
            Dim TCAPINI As Single = Nothing
            Dim PENDIENTE As Single = PRESTAMO
            Dim CAPINI As Single = PRESTAMO
            Dim pergracia As Single = pgracia.Text
            Dim I As Integer = 0
            'preg = MsgBox("Desea agregar cuota manual", vbYesNo)
            'For I = 1 To PERIODOS
            For Each Row As DataGridViewRow In diasnumero.dgv.Rows
                TPERIODOS = PERIODOS - pgracia.Text
                If CAPINI = PENDIENTE Then
                    CAPINI = PRESTAMO
                Else
                    CAPINI = PENDIENTE
                End If
                'If CAPINI = PENDIENTE Then
                'CAPINI = PRESTAMO
                'Else
                'CAPINI = PENDIENTE
                'End If
                Dim datTim1 As Date = diasnumero.DateTimePicker1.Value '#01/01/2018#
                Dim datTim2 As Date = Row.Cells("FECHA DE VENCIMIENTO").Value
                Dim wD As Long = DateDiff(DateInterval.DayOfYear, datTim1, datTim2)
                dias_d = wD
                FECHA = diasnumero.DateTimePicker1.Value

                fechaf = Row.Cells("FECHA DE VENCIMIENTO").Value
                dias_c = dias_d
                '-------------------------------------------------------
                'LINEA.SubItems.Add(FECHA.ToShortDateString)
                'fechaf = DateAdd("D", dias_c, FECHA)
                'fechaf = DateAdd("D", dias_c, FECHA)
                'Label8.Text = DateTimePicker2.Value.ToString("yyyyMMdd")
                '---------------------------------------------
                'feriados()
                'fechaf = DateAdd("D", dias_c, FECHA)
                'dtp3.Value = DateAdd("D", dias_c, FECHA)
                '-------------------------------------------------
                'feriados2()
                'dtp3.Value = DateAdd("D", dias_c, FECHA)
                'If dtp3.Value = dtp4.Value Then
                'fechaf = DateAdd("D", dias_c + 1, FECHA)
                'Else
                'fechaf = DateAdd("D", dias_c, FECHA)
                'End If
                'fechaf = DateAdd("D", dias_c, FECHA)
                Label1.Text = fechaf
                'If Weekday(fechaf) = vbSaturday Then
                'dias_c = dias_d + 2
                'f_final = diasnumero.DateTimePicker1.Value
                'Else
                'If Weekday(fechaf) = vbSunday Then
                'dias_c = dias_d + 1
                'f_final = diasnumero.DateTimePicker1.Value
                'Else
                'f_final = diasnumero.DateTimePicker1.Value
                'End If
                'End If
                'feriados()
                'feriados2()

                '-------------------------------------------------------
                If pergracia = 0 Then
                    TIPO = ((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1)
                    'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
                    'Label1.Text = CUOTA.ToString("#.00")
                    INTERESES = Math.Round(PENDIENTE * TIPO, 2) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                    'INTERESES = INTEREST.Text
                    TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                    'CUOTA = Pmt(TIPO, DIAS.Text - PRESTAMO, 0, 0)
                    igv = Math.Round(INTERESES * (IGVINT.Text / 100), 2)
                    'CUOTA = Pmt(TIPO, TPERIODOS, -PRESTAMO, 0, 0)
                    'CUOTA = CUOTAT.Text
                    TIGV += igv

                    'AMORTIZACION = Math.Round(CUOTA - (INTERESES + igv), 2) 'DIFERENCIA ENTRE CUOTA Y LOS INTERESES DEL MES
                    AMORTIZACION = Row.Cells("AMORTIZACION").Value
                    CUOTA = Row.Cells("AMORTIZACION").Value
                    cuo_int_igv = CUOTA + INTERESES + igv
                    TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                    PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                    'CAPINI = PRESTAMO
                    TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                Else
                    TIPO = ((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1)
                    'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
                    Label1.Text = CUOTA.ToString("#.00")
                    INTERESES = Math.Round(PENDIENTE * TIPO, 2) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                    TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                    'CUOTA = Pmt(TIPO, DIAS.Text - PRESTAMO, 0, 0)
                    igv = Math.Round(INTERESES * (IGVINT.Text / 100), 2)
                    CUOTA = 0.00
                    TIGV += igv
                    cuo_int_igv = CUOTA + igv + INTERESES
                    'AMORTIZACION = Math.Round(CUOTA - (INTERESES + igv), 2) 'DIFERENCIA ENTRE CUOTA Y LOS INTERESES DEL MES
                    AMORTIZACION = Math.Round(0, 2)
                    TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                    PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                    'CAPINI = PRESTAMO
                    TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                    pergracia = pergracia - 1
                End If
                'LINEA MENSUAL EN EL LISTVIEW
                Dim LINEA As New ListViewItem(I)
                'LINEA.SubItems.Add(FECHA.AddMonths(I - 1).ToShortDateString) '(I-1) PARA QUE EMPIECE A CONTAR EN EL MISMO MES
                'feriados(FECHA)

                'fechaf = DateAdd("D", dias_c, FECHA)
                'dtp3.Value = DateAdd("D", dias_c, FECHA)
                'Label8.Text = DateTimePicker2.Value.ToString("yyyyMMdd")
                '---------------------------------------------
                'feriados()
                'fechaf = DateAdd("D", dias_c, FECHA)
                ' dtp3.Value = DateAdd("D", dias_c, FECHA)
                '-------------------------------------------------
                'feriados2()
                'fechaf = DateAdd("D", dias_c, FECHA)
                'If Weekday(fechaf) = vbSaturday Then
                'dias_c = DIAS.Text + 2
                'f_final = DateTimePicker1.Value
                ' Else
                'If Weekday(fechaf) = vbSunday Then
                'dias_c = DIAS.Text + 1
                'f_final = DateTimePicker1.Value
                'Else
                'f_final = DateTimePicker1.Value
                'End If
                'End If
                LINEA.SubItems.Add(CAPINI.ToString("#.00"))
                LINEA.SubItems.Add(AMORTIZACION.ToString("#.00"))
                LINEA.SubItems.Add(PENDIENTE.ToString("#.00"))
                LINEA.SubItems.Add(INTERESES.ToString("#.00"))
                LINEA.SubItems.Add(igv.ToString("#.00"))
                LINEA.SubItems.Add(cuo_int_igv.ToString("#.00"))
                LINEA.SubItems.Add(dias_c.ToString)
                LINEA.SubItems.Add(FECHA.ToShortDateString)
                LINEA.SubItems.Add(fechaf.ToShortDateString)
                'LINEA.SubItems.Add(fechaf.AddDays(DIAS.Text).ToShortDateString)
                ListView1.Items.Add(LINEA)
                diasnumero.DateTimePicker1.Value = fechaf
                'FECHA = DateTimePicker1.Value
                'fechaf = DateTimePicker1.Value
                'dias_d = DIAS.Text

            Next
            'LINEA DE TOTALES EN EL LISTVIEW
            Dim TOTALES As New ListViewItem("TOTALES")
            TOTALES.SubItems.Add("")
            TOTALES.SubItems.Add(TAMORTIZACION.ToString("#.00"))
            TOTALES.SubItems.Add(PENDIENTE.ToString("#.00"))
            TOTALES.SubItems.Add(TINTERESES.ToString("#.00"))
            TOTALES.SubItems.Add(TIGV.ToString("#.00"))
            TOTALES.SubItems.Add(TCUOTAS.ToString("#.00"))
            TOTALES.SubItems.Add("")
            TOTALES.SubItems.Add("")
            'TOTALES.SubItems.Add("")
            'TOTALES.SubItems.Add(TCAPINI.tostring("#.00"))
            ListView1.Items.Add(TOTALES)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ':::Declaramos nuestra variable Sql que almacenara nuestra consuta
        'Dim nuevafila As DataRow
        Dim i As Integer
        sql = ""
        sql2 = ""
        'ListView1.Items.Clear()
        Try
            For i = 0 To ListView1.Items.Count - 1
                Dim mont_ini As String = ListView1.Items(i).SubItems(1).Text
                Dim amorti As String = ListView1.Items(i).SubItems(2).Text
                Dim mont_final As String = ListView1.Items(i).SubItems(3).Text
                Dim int As String = ListView1.Items(i).SubItems(4).Text
                Dim igv As String = ListView1.Items(i).SubItems(5).Text
                Dim cuota As String = ListView1.Items(i).SubItems(6).Text
                Dim F_inicio As Date = ListView1.Items(i).SubItems(8).Text
                Dim FechaExportar As String = F_inicio.ToString("yyyyMMdd")
                Dim f_final As Date = ListView1.Items(i).SubItems(9).Text
                Dim fecha_f_exportar As String = f_final.ToString("yyyyMMdd")
                Dim dias As String = ListView1.Items(i).SubItems(7).Text
                Dim cod_op As String = Anex_Cronog.t1.Text
                Dim esta As String = Anex_Cronog.cb4.Text
                Dim gest As String = Anex_Cronog.gestion
                Dim mora As String = 0
                Dim d_mora As String = 0
                Dim fec_mora As String = f_final.ToString("yyyyMMdd")


                sql = "exec alta_cuota_ope '" + cod_op + "','" + mont_ini + "','" + amorti + "','" + mont_final + "','" + int + "','" + igv + "','" + cuota + "','" + dias + "','" + fecha_f_exportar + "','" + FechaExportar + "','" + gest + "','" + esta + "','" + mora + "','" + d_mora + "','" + fec_mora + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                dr.Close()
                conexion.conexion2.Close()

                Anex_Cronog.dtp2.Value = f_final
                tinteres += int
                Anex_Cronog.t12.Text = tinteres
                'Close()
            Next

            MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: Optima Inversiones:::")
            'lb1.Text = "Total registros exportados: " & dgv.RowCount
            Cuotas_Operacion.buscar()
            'Cuotas_Operacion.dias_int_cuota()
            Anex_Cronog.Button2_Click(sender, e)
            Anex_Cronog.Button7_Click(sender, e)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            If ComboBox1.Text = "CALCULO AUTOMATICO" Then
                TextBoxIMPORTE.Enabled = False
                TextBoxINTERES.Enabled = True
                IGVINT.Enabled = True
                TextBoxMESES.Enabled = True
                DIAS.Enabled = True
                pgracia.Enabled = True
                Button1.Enabled = True
                Button5.Enabled = True
                Button8.Enabled = True
                DateTimePicker1.Enabled = True

            Else
                If ComboBox1.Text = "CALCULO MANUAL" Then
                    TextBoxIMPORTE.Enabled = True
                    TextBoxINTERES.Enabled = True
                    IGVINT.Enabled = True
                    TextBoxMESES.Enabled = True
                    DIAS.Enabled = True
                    pgracia.Enabled = True
                    Button1.Enabled = False
                    Button5.Enabled = True
                    DateTimePicker1.Enabled = True
                    diasnumero.Show()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AMORTI_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub INTEREST_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        feriados()
    End Sub

    Private Sub IGV_INTERET_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Dim fe_modi, f_com_fer As DateTime

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        'CUOTA MENSUAL

        Try
            dias_d = DIAS.Text
            Dim PRESTAMO As Decimal = TextBoxIMPORTE.Text
            'Dim TIPO As Single = ((1 + (TextBoxINTERES.Text / 100) / 30) ^ DIAS.Text - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            Dim TIPO As Decimal = 0.0D '= ((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            'Dim TIPO As Single '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1)
            'Dim DIAS_PERIODO As Integer
            Dim TIPO2 As Single
            Dim igv As Decimal = 0.0D

            ' Dim compara As Decimal
            'Dim sum_amorti As Decimal
            Dim PERIODOS As Integer = TextBoxMESES.Text '* 12
            Dim TPERIODOS As Integer
            Dim CUOTA As Decimal = 0.00000 '= Pmt(TIPO, PERIODOS, -PRESTAMO, 0, 0) 'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
            'Dim CUOTA2 As Decimal
            'Dim cuotaf As Decimal
            'Dim cuo_comp As Decimal
            ' Dim cuomas As Decimal
            Dim cuo_int_igv As Decimal = 0.00000
            'Dim cuo_int_igv2 As Single
            Dim INTERESES As Decimal = 0.00000

            Dim TIGV As Decimal = 0.00000
            Dim TINTERESES As Decimal = 0.00000
            Dim AMORTIZACION As Decimal = 0.00000
            Dim TAMORTIZACION As Decimal = 0.00000
            Dim TCUOTAS As Decimal = 0.00000
            Dim TCAPINI As Decimal = 0.00000
            Dim PENDIENTE As Decimal = PRESTAMO
            Dim comp_pendiente As Decimal = PRESTAMO
            Dim CAPINI As Decimal = PRESTAMO
            Dim pergracia As Decimal = pgracia.Text
            Dim FACT As Decimal
            Dim comp_final As Decimal = 1
            'Dim p As Integer
            'Dim comp_pendient As Decimal

            '------------------------------------------------------------
            TIPO2 = Math.Round((((1 + (TextBoxINTERES.Text / 100) / 30) ^ 30 - 1)), 5) ' + (TIPO * (IGVINT.Text / 100)),5)

            cuo_int_igv = Math.Round((((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1))))), 5)
            'cuo_int_igv = PRESTAMO / (PERIODOS - pgracia.Text) 'Fix(Pmt(TIPO2, (PERIODOS - pgracia.Text), -PRESTAMO, 0, 0))
            '------------------------------------------------------------
            'Do
            While comp_final >= 0.00000
                PENDIENTE = PRESTAMO
                CAPINI = PRESTAMO
                TAMORTIZACION = 0.00000
                TINTERESES = 0.00000
                TIGV = 0.00000
                TCUOTAS = 0.00000
                Label11.Text = cuo_int_igv.ToString("#.00000")
                Me.Refresh()
                ListView1.Items.Clear()
                For I = 1 To PERIODOS
                    TPERIODOS = PERIODOS - pgracia.Text
                    If CAPINI = PENDIENTE Then
                        CAPINI = PRESTAMO
                    Else
                        CAPINI = PENDIENTE
                    End If

                    FECHA = DateTimePicker1.Value

                    dias_c = dias_d
                    '-------------------------------------------------------

                    fechaf = DateAdd("D", dias_c, FECHA)

                    '---------------------------------------------

                    Label1.Text = fechaf
                    If Weekday(fechaf) = vbSaturday Then
                        dias_c = dias_d + 2
                        f_final = DateTimePicker1.Value
                    Else
                        If Weekday(fechaf) = vbSunday Then
                            dias_c = dias_d + 1
                            f_final = DateTimePicker1.Value
                        Else
                            f_final = DateTimePicker1.Value
                        End If
                    End If
                    feriados()
                    feriados2()

                    '-------------------------------------------------------
                    If pergracia = 0 Then

                        TIPO = Math.Round(((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1), 5) ' + (TIPO * (IGVINT.Text / 100))
                        INTERESES = Math.Round((PENDIENTE * TIPO), 5) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                        TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                        igv = Math.Round((INTERESES * (IGVINT.Text / 100)), 5)
                        TIGV += igv
                        'cuo_int_igv = PRESTAMO * ((TIPO * (1 + TIPO) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO) ^ (PERIODOS - pgracia.Text) - 1))
                        CUOTA = cuo_int_igv 'CUOTA '+ igv
                        AMORTIZACION = Math.Round((CUOTA - (INTERESES + igv)), 5)
                        TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                        PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                        TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS

                    Else
                        TIPO = Math.Round(((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1), 5)
                        'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
                        INTERESES = Math.Round(PENDIENTE * TIPO, 5) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                        TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                        igv = Math.Round(INTERESES * (IGVINT.Text / 100), 5)
                        CUOTA = 0.00000
                        TIGV += igv
                        cuo_int_igv = CUOTA + igv + INTERESES
                        AMORTIZACION = 0.0000
                        TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                        PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                        TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                        pergracia = pergracia - 1
                    End If

                    Dim LINEA As New ListViewItem(I)
                    LINEA.SubItems.Add(CAPINI.ToString("#.00000"))
                    LINEA.SubItems.Add(AMORTIZACION.ToString("#.00000"))
                    LINEA.SubItems.Add(PENDIENTE.ToString("#.00000"))
                    LINEA.SubItems.Add(INTERESES.ToString("#.00000"))
                    LINEA.SubItems.Add(igv.ToString("#.00000"))
                    LINEA.SubItems.Add(cuo_int_igv.ToString("#.00000"))
                    LINEA.SubItems.Add(dias_c.ToString)
                    LINEA.SubItems.Add(FECHA.ToShortDateString)
                    LINEA.SubItems.Add(f_final.AddDays(dias_c).ToShortDateString)
                    LINEA.SubItems.Add(FACT.ToString("#.00000"))
                    ListView1.Items.Add(LINEA)
                    DateTimePicker1.Value = f_final.AddDays(dias_c)
                    dias_d = DIAS.Text

                Next
                DateTimePicker1.Value = DateTimePicker3.Value
                cuo_int_igv += cambio.Text '1.33134 'cambio.Text

                'comp_pendiente = PENDIENTE
                comp_final = PENDIENTE
                If TAMORTIZACION = PRESTAMO Then
                    Exit While
                End If
            End While
            'Loop Until TAMORTIZACION >= PRESTAMO

            '------------------------------------------------------------


            Dim TOTALES As New ListViewItem("TOTALES")
            TOTALES.SubItems.Add("")
            TOTALES.SubItems.Add(TAMORTIZACION.ToString("#.00000"))
            TOTALES.SubItems.Add(PENDIENTE.ToString("#.00000"))
            TOTALES.SubItems.Add(TINTERESES.ToString("#.00000"))
            TOTALES.SubItems.Add(TIGV.ToString("#.00000"))
            TOTALES.SubItems.Add(TCUOTAS.ToString("#.00000"))
            TOTALES.SubItems.Add("")
            TOTALES.SubItems.Add("")
            ListView1.Items.Add(TOTALES)

            cuo_int_igv2 = cuo_int_igv
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DateTimePicker3_ValueChanged_1(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'CUOTA MENSUAL

        Try
            dias_d = DIAS.Text
            Dim PRESTAMO As Decimal = TextBoxIMPORTE.Text
            'Dim TIPO As Single = ((1 + (TextBoxINTERES.Text / 100) / 30) ^ DIAS.Text - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            Dim TIPO As Single '= ((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            'Dim TIPO As Single '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1)
            'Dim DIAS_PERIODO As Integer
            Dim TIPO2 As Single
            Dim igv As Decimal
            ' Dim compara As Decimal
            'Dim sum_amorti As Decimal
            Dim PERIODOS As Integer = TextBoxMESES.Text '* 12
            Dim TPERIODOS As Integer
            Dim CUOTA As Decimal  '= Pmt(TIPO, PERIODOS, -PRESTAMO, 0, 0) 'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
            'Dim CUOTA2 As Decimal
            'Dim cuotaf As Decimal
            'Dim cuo_comp As Decimal
            ' Dim cuomas As Decimal
            Dim cuo_int_igv As Single
            'Dim cuo_int_igv2 As Single
            Dim INTERESES As Single = Nothing
            Dim TIGV As Single = Nothing
            Dim TINTERESES As Single = Nothing
            Dim AMORTIZACION As Single = Nothing
            Dim TAMORTIZACION As Single = Nothing
            Dim TCUOTAS As Single = Nothing
            Dim TCAPINI As Single = Nothing
            Dim PENDIENTE As Single = PRESTAMO
            Dim comp_pendiente As Single = PRESTAMO
            Dim CAPINI As Single = PRESTAMO
            Dim pergracia As Single = pgracia.Text
            Dim FACT As Decimal
            'Dim p As Integer
            'Dim comp_pendient As Decimal

            '------------------------------------------------------------
            TIPO2 = (((1 + (TextBoxINTERES.Text / 100) / 30) ^ 30 - 1)) ' + (TIPO * (IGVINT.Text / 100))
            cuo_int_igv2 = Math.Round((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1))), 1)
            '------------------------------------------------------------
            While comp_pendiente >= 0
                PENDIENTE = PRESTAMO
                CAPINI = PRESTAMO
                TAMORTIZACION = 0
                TINTERESES = 0
                TIGV = 0
                TCUOTAS = 0
                Label11.Text = cuo_int_igv.ToString("#.00")
                ListView1.Items.Clear()
                For I = 1 To PERIODOS
                    TPERIODOS = PERIODOS - pgracia.Text
                    If CAPINI = PENDIENTE Then
                        CAPINI = PRESTAMO
                    Else
                        CAPINI = PENDIENTE
                    End If

                    FECHA = DateTimePicker1.Value

                    dias_c = dias_d
                    '-------------------------------------------------------

                    fechaf = DateAdd("D", dias_c, FECHA)

                    '---------------------------------------------

                    Label1.Text = fechaf
                    If Weekday(fechaf) = vbSaturday Then
                        dias_c = dias_d + 2
                        f_final = DateTimePicker1.Value
                    Else
                        If Weekday(fechaf) = vbSunday Then
                            dias_c = dias_d + 1
                            f_final = DateTimePicker1.Value
                        Else
                            f_final = DateTimePicker1.Value
                        End If
                    End If
                    feriados()
                    feriados2()

                    '-------------------------------------------------------
                    If pergracia = 0 Then

                        TIPO = (((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1)) ' + (TIPO * (IGVINT.Text / 100))
                        INTERESES = Math.Round((PENDIENTE * TIPO), 1) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                        TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                        igv = Math.Round(INTERESES * (IGVINT.Text / 100), 1)
                        TIGV += igv
                        'cuo_int_igv = PRESTAMO * ((TIPO * (1 + TIPO) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO) ^ (PERIODOS - pgracia.Text) - 1))
                        CUOTA = Math.Round(cuo_int_igv, 2) 'CUOTA '+ igv
                        AMORTIZACION = Math.Round((CUOTA - (INTERESES + igv)), 1)
                        TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                        PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                        TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS

                    Else
                        TIPO = ((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1)
                        'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
                        INTERESES = Math.Round(PENDIENTE * TIPO, 2) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                        TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                        igv = Math.Round(INTERESES * (IGVINT.Text / 100), 2)
                        CUOTA = 0
                        TIGV += igv
                        cuo_int_igv = CUOTA + igv + INTERESES
                        AMORTIZACION = 0
                        TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                        PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                        TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                        pergracia = pergracia - 1
                    End If

                    Dim LINEA As New ListViewItem(I)
                    LINEA.SubItems.Add(CAPINI.ToString("#.00"))
                    LINEA.SubItems.Add(AMORTIZACION.ToString("#.00"))
                    LINEA.SubItems.Add(PENDIENTE.ToString("#.00"))
                    LINEA.SubItems.Add(INTERESES.ToString("#.00"))
                    LINEA.SubItems.Add(igv.ToString("#.00"))
                    LINEA.SubItems.Add(cuo_int_igv.ToString("#.00"))
                    LINEA.SubItems.Add(dias_c.ToString)
                    LINEA.SubItems.Add(FECHA.ToShortDateString)
                    LINEA.SubItems.Add(f_final.AddDays(dias_c).ToShortDateString)
                    LINEA.SubItems.Add(FACT.ToString("#.00"))
                    ListView1.Items.Add(LINEA)
                    DateTimePicker1.Value = f_final.AddDays(dias_c)
                    dias_d = DIAS.Text

                Next
                DateTimePicker1.Value = DateTimePicker3.Value
                cuo_int_igv += 1.0
                comp_pendiente = PENDIENTE
            End While
            Dim TOTALES As New ListViewItem("TOTALES")
            TOTALES.SubItems.Add("")
            TOTALES.SubItems.Add(TAMORTIZACION.ToString("#.00"))
            TOTALES.SubItems.Add(PENDIENTE.ToString("#.00"))
            TOTALES.SubItems.Add(TINTERESES.ToString("#.00"))
            TOTALES.SubItems.Add(TIGV.ToString("#.00"))
            TOTALES.SubItems.Add(TCUOTAS.ToString("#.00"))
            TOTALES.SubItems.Add("")
            TOTALES.SubItems.Add("")
            ListView1.Items.Add(TOTALES)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            dias_d = DIAS.Text
            Dim PRESTAMO As Decimal = TextBoxIMPORTE.Text
            'Dim TIPO As Single = ((1 + (TextBoxINTERES.Text / 100) / 30) ^ DIAS.Text - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            Dim TIPO As Decimal = 0.0D '= ((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            'Dim TIPO As Single '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1)
            'Dim DIAS_PERIODO As Integer
            Dim TIPO2 As Single
            Dim igv As Decimal = 0.0D

            ' Dim compara As Decimal
            'Dim sum_amorti As Decimal
            Dim PERIODOS As Integer = TextBoxMESES.Text '* 12
            Dim TPERIODOS As Integer
            Dim CUOTA As Decimal = 0.0D '= Pmt(TIPO, PERIODOS, -PRESTAMO, 0, 0) 'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
            'Dim CUOTA2 As Decimal
            'Dim cuotaf As Decimal
            'Dim cuo_comp As Decimal
            ' Dim cuomas As Decimal
            Dim cuo_int_igv As Decimal = 0.0D

            Dim INTERESES As Decimal = 0.0D

            Dim TIGV As Decimal = 0.0D
            Dim TINTERESES As Decimal = 0.0D
            Dim AMORTIZACION As Decimal = 0.0D
            Dim TAMORTIZACION As Decimal = 0.0D
            Dim prest_tamor As Decimal = 0.0D
            Dim TCUOTAS As Decimal = 0.0D
            Dim TCAPINI As Decimal = 0.0D
            Dim PENDIENTE As Decimal = PRESTAMO
            Dim comp_pendiente As Decimal = PRESTAMO
            Dim CAPINI As Decimal = PRESTAMO
            Dim pergracia As Decimal = pgracia.Text
            Dim FACT As Decimal
            'Dim p As Integer
            'Dim comp_pendient As Decimal

            '------------------------------------------------------------
            TIPO2 = Math.Round((((1 + (TextBoxINTERES.Text / 100) / 30) ^ 30 - 1)), 5) ' + (TIPO * (IGVINT.Text / 100))

            'cuo_int_igv = (((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1)))))
            'cuo_int_igv = Pmt(TIPO2, (PERIODOS - pgracia.Text), -PRESTAMO, 0, 0)
            '------------------------------------------------------------


            PENDIENTE = PRESTAMO
            CAPINI = PRESTAMO
            TAMORTIZACION = 0.0D
            TINTERESES = 0.0D
            TIGV = 0.0D
            TCUOTAS = 0.0D
            Label11.Text = cuo_int_igv.ToString("#.00000")
            ListView1.Items.Clear()
            For I = 1 To PERIODOS
                TPERIODOS = PERIODOS - pgracia.Text
                If CAPINI = PENDIENTE Then
                    CAPINI = PRESTAMO
                Else
                    CAPINI = PENDIENTE
                End If

                FECHA = DateTimePicker1.Value

                dias_c = dias_d
                '-------------------------------------------------------

                fechaf = DateAdd("D", dias_c, FECHA)

                '---------------------------------------------

                Label1.Text = fechaf
                If Weekday(fechaf) = vbSaturday Then
                    dias_c = dias_d + 2
                    f_final = DateTimePicker1.Value
                Else
                    If Weekday(fechaf) = vbSunday Then
                        dias_c = dias_d + 1
                        f_final = DateTimePicker1.Value
                    Else
                        f_final = DateTimePicker1.Value
                    End If
                End If
                feriados()
                feriados2()

                '-------------------------------------------------------
                If pergracia = 0 Then

                    TIPO = Math.Round(((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1), 5) ' + (TIPO * (IGVINT.Text / 100))
                    INTERESES = Math.Round((PENDIENTE * TIPO), 5) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                    TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                    igv = Math.Round((INTERESES * (IGVINT.Text / 100)), 5)
                    TIGV += igv
                    'cuo_int_igv = PRESTAMO * ((TIPO * (1 + TIPO) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO) ^ (PERIODOS - pgracia.Text) - 1))
                    CUOTA = TextBox1.Text 'cuo_int_igv2 'CUOTA '+ igv
                    cuo_int_igv = Math.Round(CUOTA, 9)
                    AMORTIZACION = Math.Round((CUOTA - (INTERESES + igv)), 5)
                    TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                    PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                    TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                    prest_tamor = +TAMORTIZACION - PRESTAMO

                Else
                    TIPO = Math.Round(((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1), 5)
                    'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
                    INTERESES = Math.Round(PENDIENTE * TIPO, 5) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                    TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                    igv = Math.Round(INTERESES * (IGVINT.Text / 100), 5)
                    CUOTA = 0
                    TIGV += igv
                    cuo_int_igv = Math.Round((CUOTA + igv + INTERESES), 5)
                    AMORTIZACION = 0
                    TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                    PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                    TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                    pergracia = pergracia - 1
                End If

                Dim LINEA As New ListViewItem(I)
                LINEA.SubItems.Add(CAPINI.ToString("#.00000"))
                LINEA.SubItems.Add(AMORTIZACION.ToString("#.00000"))
                LINEA.SubItems.Add(PENDIENTE.ToString("#.00000"))
                LINEA.SubItems.Add(INTERESES.ToString("#.00000"))
                LINEA.SubItems.Add(igv.ToString("#.00000"))
                LINEA.SubItems.Add(cuo_int_igv.ToString("#.00000"))
                LINEA.SubItems.Add(dias_c.ToString)
                LINEA.SubItems.Add(FECHA.ToShortDateString)
                LINEA.SubItems.Add(f_final.AddDays(dias_c).ToShortDateString)
                LINEA.SubItems.Add(FACT.ToString("#.00000"))
                ListView1.Items.Add(LINEA)
                DateTimePicker1.Value = f_final.AddDays(dias_c)
                dias_d = DIAS.Text

            Next
            DateTimePicker1.Value = DateTimePicker3.Value
            cuo_int_igv -= 0.001

            comp_pendiente = PENDIENTE
            Dim ressum As Decimal = PENDIENTE / (TextBoxMESES.Text - pgracia.Text)

            TextBox1.Text = CUOTA + ressum
            '------------------------------------------------------------


            'Dim TOTALES As New ListViewItem("TOTALES")
            'TOTALES.SubItems.Add("")
            'TOTALES.SubItems.Add(TAMORTIZACION.ToString("#.000"))
            'TOTALES.SubItems.Add(PENDIENTE.ToString("#.000"))
            'TOTALES.SubItems.Add(TINTERESES.ToString("#.000"))
            'TOTALES.SubItems.Add(TIGV.ToString("#.000"))
            'TOTALES.SubItems.Add(TCUOTAS.ToString("#.000"))
            'TOTALES.SubItems.Add("")
            'TOTALES.SubItems.Add("")
            'ListView1.Items.Add(TOTALES)

            'Dim suma_preamor As New ListViewItem("SUMA PER")
            ' suma_preamor.SubItems.Add(prest_tamor.ToString("#.000"))
            'ListView1.Items.Add(suma_preamor)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            dias_d = DIAS.Text
            'Dim O As String
            Dim incremento As Decimal = 1D
            Dim PRESTAMO As Decimal = TextBoxIMPORTE.Text
            'Dim TIPO As Single = ((1 + (TextBoxINTERES.Text / 100) / 30) ^ DIAS.Text - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            Dim TIPO As Decimal = 0.0D '= ((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            'Dim TIPO As Single '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1)
            'Dim DIAS_PERIODO As Integer
            Dim TIPO2 As Single
            Dim igv As Decimal = 0.0D

            ' Dim compara As Decimal
            'Dim sum_amorti As Decimal
            Dim PERIODOS As Integer = TextBoxMESES.Text '* 12
            'Dim TPERIODOS As Integer
            Dim CUOTA As Decimal = 0.0D '= Pmt(TIPO, PERIODOS, -PRESTAMO, 0, 0) 'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
            Dim CUOTA2 As Decimal
            'Dim cuotaf As Decimal
            'Dim cuo_comp As Decimal
            ' Dim cuomas As Decimal
            Dim cuo_int_igv As Decimal = 0.0D
            'Dim cuo_int_igv2 As Single
            Dim INTERESES As Decimal = 0.0D

            Dim TIGV As Decimal = 0.0D
            Dim TINTERESES As Decimal = 0.0D
            Dim AMORTIZACION As Decimal = 0.0D
            Dim TAMORTIZACION As Decimal = 0.0D
            Dim TCUOTAS As Decimal = 0.0D
            Dim TCAPINI As Decimal = 0.0D
            Dim PENDIENTE As Decimal '= PRESTAMO
            Dim comp_pendiente As Decimal = PRESTAMO
            Dim CAPINI As Decimal '= PRESTAMO
            Dim pergracia As Integer = pgracia.Text
            Dim FACT As Decimal
            Dim comp_final As Decimal = 0.0D
            Dim recorre As Double = Math.Round(PRESTAMO, 0)
            'Dim p As Integer
            'Dim comp_pendient As Decimal

            '------------------------------------------------------------
            'TIPO2 = Math.Round((((1 + (TextBoxINTERES.Text / 100) / 30) ^ DIAS.Text - 1)), 5) ' + (TIPO * (IGVINT.Text / 100)),5)
            ' CUOTA = Math.Round((((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1))))), 5)
            'CUOTA = 0 'Math.Round((((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1))))), 0)
            'CUOTA = PRESTAMO / (PERIODOS - pgracia.Text)
            'cuo_int_igv = Math.Round((((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1))))), 5)
            'cuo_int_igv = PRESTAMO / (PERIODOS - pgracia.Text) 'Fix(Pmt(TIPO2, (PERIODOS - pgracia.Text), -PRESTAMO, 0, 0))
            '------------------------------------------------------------
            'Do
            'cuo_int_igv = 1

            '---------------------------------------------------------
            '---------------------------------------------------------
            FECHA = DateTimePicker1.Value

            dias_c = dias_d
            '-------------------------------------------------------

            fechaf = DateAdd("D", dias_c, FECHA)

            '---------------------------------------------

            Label1.Text = fechaf
            If Weekday(fechaf) = vbSaturday Then
                dias_c = dias_d + 2
                f_final = DateTimePicker1.Value
            Else
                If Weekday(fechaf) = vbSunday Then
                    dias_c = dias_d + 1
                    f_final = DateTimePicker1.Value
                Else
                    f_final = DateTimePicker1.Value
                End If
            End If
            feriados()
            feriados2()
            TIPO2 = Math.Round((((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1)), 9) ' + (TIPO * (IGVINT.Text / 100)),5)
            CUOTA = Math.Round((((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1))))), 9)
            '------------------------------------------------------------------------------
            '------------------------------------------------------------------------------

            For TAMORTIZACION = 1 To PRESTAMO
                'cuo_int_igv = Math.Round((((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1))))), 5) + incremento
                PENDIENTE = PRESTAMO
                CAPINI = PRESTAMO
                TAMORTIZACION = 0.0D
                TINTERESES = 0.0D
                TIGV = 0.0D
                TCUOTAS = 0.0D
                Label11.Text = cuo_int_igv
                'BackgroundWorker1.ReportProgress(O)
                ' System.Threading.Thread.Sleep(200)
                ListView1.Items.Clear()
                'Refresh()
                For i = 1 To PERIODOS
                    'TPERIODOS = PERIODOS - pgracia.Text
                    'cuo_int_igv = Math.Round((((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (TPERIODOS)) / ((1 + TIPO2) ^ (TPERIODOS) - 1))))), 5) + incremento
                    If CAPINI = PENDIENTE Then
                        CAPINI = PRESTAMO
                    Else
                        CAPINI = PENDIENTE
                    End If

                    FECHA = DateTimePicker1.Value

                    dias_c = dias_d
                    '-------------------------------------------------------

                    fechaf = DateAdd("D", dias_c, FECHA)

                    '---------------------------------------------

                    Label1.Text = fechaf
                    If Weekday(fechaf) = vbSaturday Then
                        dias_c = dias_d + 2
                        f_final = DateTimePicker1.Value
                    Else
                        If Weekday(fechaf) = vbSunday Then
                            dias_c = dias_d + 1
                            f_final = DateTimePicker1.Value
                        Else
                            f_final = DateTimePicker1.Value
                        End If
                    End If
                    feriados()
                    feriados2()

                    ''cuo_int_igv = (PRESTAMO * ((TIPO * (1 + TIPO) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO) ^ (PERIODOS - pgracia.Text) - 1)) + incremento)
                    '-------------------------------------------------------
                    If pergracia = 0 Then
                        TIPO = Math.Round(((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1), 9) ' + (TIPO * (IGVINT.Text / 100))
                        INTERESES = Math.Round((PENDIENTE * TIPO), 9) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                        TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                        igv = Math.Round((INTERESES * (IGVINT.Text / 100)), 9)
                        TIGV += igv
                        'CUOTA += incremento
                        'CUOTA = ((PRESTAMO * ((TIPO * (1 + TIPO) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO) ^ (PERIODOS - pgracia.Text) - 1)))) ' + incremento
                        'cuo_int_igv = (PRESTAMO * ((TIPO * (1 + TIPO) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO) ^ (PERIODOS - pgracia.Text) - 1)) + incremento)
                        cuo_int_igv = CUOTA + incremento 'CUOTA '+ igv
                        'cuo_int_igv = 0 'incremento + CUOTA '+ igv
                        AMORTIZACION = Math.Round((cuo_int_igv - (INTERESES + igv)), 9)
                        TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                        PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                        TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS

                    Else

                        TIPO = Math.Round(((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1), 9)
                        'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
                        INTERESES = Math.Round(PENDIENTE * TIPO, 9) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                        TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                        igv = Math.Round(INTERESES * (IGVINT.Text / 100), 9)
                        CUOTA2 = 0.0D
                        TIGV += igv
                        cuo_int_igv = CUOTA2 + igv + INTERESES
                        'CUOTA = igv + INTERESES
                        AMORTIZACION = 0.0D
                        TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                        PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                        TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                        'TCUOTAS += CUOTA 'ACUMULA TODAS LAS CUOTAS
                        pergracia = pergracia - 1
                        ' cuo_int_igv = Math.Round((((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1))))), 5)
                        'End If
                        'cuo_int_igv = Math.Round((((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1))))), 5)

                    End If



                    'Else



                    Dim LINEA As New ListViewItem(i)
                    LINEA.SubItems.Add(CAPINI.ToString("#.00000"))
                    LINEA.SubItems.Add(AMORTIZACION.ToString("#.00000"))
                    LINEA.SubItems.Add(PENDIENTE.ToString("#.00000"))
                    LINEA.SubItems.Add(INTERESES.ToString("#.00000"))
                    LINEA.SubItems.Add(igv.ToString("#.00000"))
                    LINEA.SubItems.Add(cuo_int_igv.ToString("#.00000"))
                    LINEA.SubItems.Add(dias_c.ToString)
                    LINEA.SubItems.Add(FECHA.ToShortDateString)
                    LINEA.SubItems.Add(f_final.AddDays(dias_c).ToShortDateString)
                    LINEA.SubItems.Add(FACT.ToString("#.00000"))
                    ListView1.Items.Add(LINEA)
                    DateTimePicker1.Value = f_final.AddDays(dias_c)
                    dias_d = DIAS.Text
                    'Thread.Sleep(200)
                    ' O = +1
                    'BackgroundWorker1.ReportProgress(O)

                Next
                'cuo_int_igv = 0.00000
                DateTimePicker1.Value = DateTimePicker3.Value
                'cuo_int_igv += cambio.Text '1.33134 'cambio.Text
                pergracia = pgracia.Text

                'comp_pendiente = PENDIENTE
                comp_final = PENDIENTE
                incremento += cambio.Text
                'If Math.Round(TAMORTIZACION, 0) = re Then
                'Exit For
                'End If
                If BackgroundWorker1.CancellationPending Then
                    e.Cancel = True
                    BackgroundWorker1.ReportProgress(0)
                    Return
                End If


                'cuo_int_igv = (PRESTAMO * ((TIPO * (1 + TIPO) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO) ^ (PERIODOS - pgracia.Text) - 1)) + incremento)
                'Thread.Sleep(200)
                ' O = +1
                ' BackgroundWorker1.ReportProgress(O)

            Next
            'cuotafinal = cuo_int_igv
            'pendientef = PENDIENTE
            'cuotafinal = cuo_int_igv
            'bojetivo()

            'Loop Until TAMORTIZACION >= PRESTAMO
            TextBox1.Text = cuo_int_igv
            bobjetivo2()
            'BackgroundWorker3.RunWorkerAsync()
            Button8.Enabled = True
            '------------------------------------------------------------

            'Dim TOTALES As New ListViewItem("TOTALES")
            ' TOTALES.SubItems.Add("")
            'TOTALES.SubItems.Add(TAMORTIZACION.ToString("#.000000000"))
            'TOTALES.SubItems.Add(PENDIENTE.ToString("#.000000000"))
            'TOTALES.SubItems.Add(TINTERESES.ToString("#.000000000"))
            'TOTALES.SubItems.Add(TIGV.ToString("#.000000000"))
            'TOTALES.SubItems.Add(TCUOTAS.ToString("#.000000000"))
            'TOTALES.SubItems.Add("")
            'TOTALES.SubItems.Add("")
            'ListView1.Items.Add(TOTALES)
            Button5.Enabled = True
            Button1.Enabled = True
            'cuo_int_igv2 = cuo_int_igv
        Catch ex As Exception
            MsgBox("REVISAR LOS CAMPOS, ALGUNO ESTA VACIO", MsgBoxStyle.Information, "Optima")
            Button8.Enabled = True
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'CUOTA MENSUAL
        ListView1.Items.Clear()
        Try
            dias_d = DIAS.Text
            Dim PRESTAMO As Decimal = TextBoxIMPORTE.Text
            'Dim TIPO As Single = ((1 + (TextBoxINTERES.Text / 100) / 30) ^ DIAS.Text - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            Dim TIPO As Single '= ((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            'Dim TIPO As Single '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1)
            'Dim DIAS_PERIODO As Integer
            Dim igv As Decimal
            Dim compara As Decimal = 0.0
            Dim sum_amorti As Decimal = 0.0
            Dim PERIODOS As Integer = TextBoxMESES.Text '* 12
            Dim TPERIODOS As Integer
            Dim CUOTA As Single '= Pmt(TIPO, PERIODOS, -PRESTAMO, 0, 0) 'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
            Dim cuo_int_igv As Single
            Dim INTERESES As Single = Nothing
            Dim TIGV As Single = Nothing
            Dim TINTERESES As Single = Nothing
            Dim AMORTIZACION As Single = Nothing
            Dim TAMORTIZACION As Single = Nothing
            Dim TCUOTAS As Single = Nothing
            Dim TCAPINI As Single = Nothing
            Dim PENDIENTE As Single = PRESTAMO
            Dim CAPINI As Single = PRESTAMO
            Dim pergracia As Single = pgracia.Text
            Dim FACT As Decimal = 0.000
            For I = 1 To PERIODOS
                TPERIODOS = PERIODOS - pgracia.Text
                If CAPINI = PENDIENTE Then
                    CAPINI = PRESTAMO
                Else
                    CAPINI = PENDIENTE
                End If
                'If CAPINI = PENDIENTE Then
                'CAPINI = PRESTAMO
                'Else
                'CAPINI = PENDIENTE
                'End If
                FECHA = DateTimePicker1.Value
                'fechaf = DateTimePicker1.Value
                dias_c = dias_d
                '-------------------------------------------------------
                'LINEA.SubItems.Add(FECHA.ToShortDateString)
                'fechaf = DateAdd("D", dias_c, FECHA)
                fechaf = DateAdd("D", dias_c, FECHA)
                'Label8.Text = DateTimePicker2.Value.ToString("yyyyMMdd")
                '---------------------------------------------
                'feriados()
                'fechaf = DateAdd("D", dias_c, FECHA)
                'dtp3.Value = DateAdd("D", dias_c, FECHA)
                '-------------------------------------------------
                'feriados2()
                'dtp3.Value = DateAdd("D", dias_c, FECHA)
                'If dtp3.Value = dtp4.Value Then
                'fechaf = DateAdd("D", dias_c + 1, FECHA)
                'Else
                'fechaf = DateAdd("D", dias_c, FECHA)
                'End If
                'fechaf = DateAdd("D", dias_c, FECHA)
                Label1.Text = fechaf
                If Weekday(fechaf) = vbSaturday Then
                    dias_c = dias_d + 2
                    f_final = DateTimePicker1.Value
                Else
                    If Weekday(fechaf) = vbSunday Then
                        dias_c = dias_d + 1
                        f_final = DateTimePicker1.Value
                    Else
                        f_final = DateTimePicker1.Value
                    End If
                End If
                feriados()
                feriados2()

                '-------------------------------------------------------
                If pergracia = 0 Then

                    TIPO = Math.Round((((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1)), 5) ' + (TIPO * (IGVINT.Text / 100))
                    'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
                    Label1.Text = CUOTA.ToString("#.00000")
                    INTERESES = Math.Round(PENDIENTE * TIPO, 5) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                    TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                    'CUOTA = Pmt(TIPO, TPERIODOS, -PRESTAMO, 0, 0)
                    CUOTA = PRESTAMO * ((TIPO * (1 + TIPO) ^ TPERIODOS) / ((1 + TIPO) ^ TPERIODOS - 1))
                    'CUOTA = Pmt(TIPO, DIAS.Text - PRESTAMO, 0, 0)
                    igv = Math.Round(INTERESES * (IGVINT.Text / 100), 5)
                    TIGV += igv
                    cuo_int_igv = CUOTA + igv
                    'AMORTIZACION = Math.Round(CUOTA - (INTERESES + igv), 2) 'DIFERENCIA ENTRE CUOTA Y LOS INTERESES DEL MES
                    AMORTIZACION = Math.Round(cuo_int_igv - (INTERESES + igv), 5)
                    TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                    PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                    'CAPINI = PRESTAMO
                    TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                    TPERIODOS -= 1

                Else
                    TIPO = Math.Round(((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1), 5)
                    'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
                    Label1.Text = CUOTA.ToString("#.00000")
                    INTERESES = Math.Round(PENDIENTE * TIPO, 5) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                    TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                    'CUOTA = Pmt(TIPO, DIAS.Text - PRESTAMO, 0, 0)
                    igv = Math.Round(INTERESES * (IGVINT.Text / 100), 5)
                    CUOTA = 0.00
                    TIGV += igv
                    cuo_int_igv = CUOTA + igv + INTERESES
                    'AMORTIZACION = Math.Round(CUOTA - (INTERESES + igv), 2) 'DIFERENCIA ENTRE CUOTA Y LOS INTERESES DEL MES
                    AMORTIZACION = Math.Round(0, 5)
                    TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                    PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                    'CAPINI = PRESTAMO
                    TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                    pergracia = pergracia - 1
                End If
                'LINEA MENSUAL EN EL LISTVIEW
                Dim LINEA As New ListViewItem(I)
                'LINEA.SubItems.Add(FECHA.AddMonths(I - 1).ToShortDateString) '(I-1) PARA QUE EMPIECE A CONTAR EN EL MISMO MES
                'feriados(FECHA)

                'fechaf = DateAdd("D", dias_c, FECHA)
                'dtp3.Value = DateAdd("D", dias_c, FECHA)
                'Label8.Text = DateTimePicker2.Value.ToString("yyyyMMdd")
                '---------------------------------------------
                'feriados()
                'fechaf = DateAdd("D", dias_c, FECHA)
                ' dtp3.Value = DateAdd("D", dias_c, FECHA)
                '-------------------------------------------------
                'feriados2()
                'fechaf = DateAdd("D", dias_c, FECHA)
                'If Weekday(fechaf) = vbSaturday Then
                'dias_c = DIAS.Text + 2
                'f_final = DateTimePicker1.Value
                ' Else
                'If Weekday(fechaf) = vbSunday Then
                'dias_c = DIAS.Text + 1
                'f_final = DateTimePicker1.Value
                'Else
                'f_final = DateTimePicker1.Value
                'End If
                'End If
                LINEA.SubItems.Add(CAPINI.ToString("#.00000"))
                LINEA.SubItems.Add(AMORTIZACION.ToString("#.00000"))
                LINEA.SubItems.Add(PENDIENTE.ToString("#.00000"))
                LINEA.SubItems.Add(INTERESES.ToString("#.00000"))
                LINEA.SubItems.Add(igv.ToString("#.00000"))
                LINEA.SubItems.Add(cuo_int_igv.ToString("#.00000"))
                LINEA.SubItems.Add(dias_c.ToString)
                LINEA.SubItems.Add(FECHA.ToShortDateString)
                LINEA.SubItems.Add(f_final.AddDays(dias_c).ToShortDateString)
                LINEA.SubItems.Add(FACT.ToString("#.00000"))
                'LINEA.SubItems.Add(fechaf.AddDays(DIAS.Text).ToShortDateString)
                ListView1.Items.Add(LINEA)
                DateTimePicker1.Value = f_final.AddDays(dias_c)
                'FECHA = DateTimePicker1.Value
                'fechaf = DateTimePicker1.Value
                dias_d = DIAS.Text
                compara = CUOTA
            Next
            'LINEA DE TOTALES EN EL LISTVIEW
            Dim TOTALES As New ListViewItem("TOTALES")
            TOTALES.SubItems.Add("")
            TOTALES.SubItems.Add(TAMORTIZACION.ToString("#.00000"))
            TOTALES.SubItems.Add(PENDIENTE.ToString("#.00000"))
            TOTALES.SubItems.Add(TINTERESES.ToString("#.00000"))
            TOTALES.SubItems.Add(TIGV.ToString("#.00000"))
            TOTALES.SubItems.Add(TCUOTAS.ToString("#.00000"))
            TOTALES.SubItems.Add("")
            TOTALES.SubItems.Add("")
            'TOTALES.SubItems.Add("")
            'TOTALES.SubItems.Add(TCAPINI.tostring("#.00"))
            ListView1.Items.Add(TOTALES)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'FECHA = DateTimePicker1.Value
        'fechaf = DateTimePicker1.Value
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        BackgroundWorker1.RunWorkerAsync()
        'Refresh()
        Button8.Enabled = False
        Button5.Enabled = False
        Button1.Enabled = False



    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If BackgroundWorker1.IsBusy Then
            BackgroundWorker1.CancelAsync()
            Button8.Enabled = True
        Else
            Label15.Text = "No hay operacion en proceso para cancelar"
        End If
        Me.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'Dim a As Decimal = 0.0D
        'Dim b As Decimal = 0.0D

        ''' For a = 1 To 11000.5
        'a += 0.00001D

        'Label11.Text = a
        'Refresh()
        'Next
        BackgroundWorker2.RunWorkerAsync()
        Refresh()


    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork


    End Sub




    Private Sub BackgroundWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork


    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        'BackgroundWorker3.RunWorkerAsync()
        'Refresh()
        bobjetivo2()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim i As Integer
        Dim prest As Decimal = TextBoxIMPORTE.Text
        Dim mont_ini As Decimal
        Dim amorti As Decimal
        Dim tamortizacion As Decimal
        Dim tipo As Double
        Dim comp As Decimal = 0.00000
        Dim mont_final As Decimal
        Dim int As Decimal
        Dim igv As Decimal
        Dim cuota As Decimal
        Dim F_inicio As Date
        Dim FechaExportar As String
        Dim f_final As Date
        Dim fecha_f_exportar As String
        Dim cod_op As String
        Dim esta As String
        Dim gest As String
        i_tens = TextBoxMESES.Text
        Dim dias(0 To i_tens) As Integer
        For o = 0 To ListView1.Items.Count - 1
            dias(o) = ListView1.Items(i).SubItems(7).Text
        Next
        Try

            cuota = 4801.34824 'cuota + 1
            mont_ini = prest

            For i = 0 To ListView1.Items.Count - 1
                'cuota = 4801.34824
                'dias(i) = ListView1.Items(i).SubItems(7).Text
                tipo = Math.Round(((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias(i) - 1), 2)
                'tipo = ((1 + (1.7 / 100) / 30) ^ 32 - 1)
                int = Math.Round((+mont_ini * tipo), 2)
                igv = Math.Round(+int * (IGVINT.Text / 100), 2)
                amorti = Math.Round((+cuota - (int + igv)), 5)
                mont_final = mont_ini - amorti
                'mont_ini = ListView1.Items(i).SubItems(1).Text
                ListView1.Items(i).SubItems(1).Text = mont_ini
                'amorti = ListView1.Items(i).SubItems(2).Text
                ListView1.Items(i).SubItems(2).Text = amorti
                'mont_final = ListView1.Items(i).SubItems(3).Text
                ListView1.Items(i).SubItems(3).Text = mont_final
                'int = ListView1.Items(i).SubItems(4).Text
                ListView1.Items(i).SubItems(4).Text = int
                'igv = ListView1.Items(i).SubItems(5).Text
                ListView1.Items(i).SubItems(5).Text = igv
                'cuota = ListView1.Items(i).SubItems(6).Text
                ListView1.Items(i).SubItems(6).Text = cuota
                ' F_inicio = ListView1.Items(i).SubItems(8).Text
                ' FechaExportar = F_inicio.ToString("yyyyMMdd")
                'f_final = ListView1.Items(i).SubItems(9).Text
                'fecha_f_exportar = f_final.ToString("yyyyMMdd")
                mont_ini = mont_final

                'cod_op = Anex_Cronog.t1.Text
                ' esta = Anex_Cronog.cb4.Text
                'gest = Anex_Cronog.gestion
                '---------------------------------------------------------------------------


                'sql = "exec alta_cuota_ope '" + cod_op + "','" + mont_ini + "','" + amorti + "','" + mont_final + "','" + int + "','" + igv + "','" + cuota + "','" + dias + "','" + fecha_f_exportar + "','" + FechaExportar + "','" + gest + "','" + esta + "'"
                ' conexion.conectarfondo()
                ' com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                ' dr = com.ExecuteReader
                ' dr.Close()
                'conexion.conexion2.Close()

                'Anex_Cronog.dtp2.Value = f_final
                'Close()

                tamortizacion += amorti

            Next
            comp += tamortizacion
            'Amortizacion = ListView1.Items(i_tens).SubItems(2).Text
            'tamortizacion += amorti
            Refresh()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        limpiaexcel()
        cargaexcel()
    End Sub

    Private Sub limpiaexcel()
        Try

            Dim oExcel As Object
            Dim oBook As Object
            Dim oSheet As Object
            Dim i As Integer
            Dim k As Integer
            Dim c As Integer = 0

            'Start a new workbook in Excel.
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.open("E:\orca\PROGRAMACION\OPTIMA_INVERSIONES\ofactoring\ofactoring\ofactoring\bin\Debug\SIMULACION_CUOTAS.xlsx")

            ' Se hace un contador para saber  cuantas  filas  tiene agregado el listBox
            For i = 0 To ListView1.Items.Count - 1
                c = c + 1
            Next
            ' Una vez El contador  cargue a la variable la cantidad le restamos 1 porque el indice empieza en 0
            c = c - 1

            oSheet = oBook.Worksheets(1)
            'Creamos una variable para que empieze a cargar datos en determinada fila de excel y le asignamos un valor
            Dim X As Integer
            oSheet.Range("D7").Value = ""
            oSheet.Range("D8").Value = ""
            oSheet.Range("D9").Value = ""
            oSheet.Range("D10").Value = ""
            oSheet.Range("D11").Value = ""
            X = 14
            ' se hace un for para cargar los datos en excel y ya depende del numero de columnas que tenga se coloca
            ' Abajo las expresiones
            For k = 0 To 100
                oSheet.Range("A" & X).Value = ""
                oSheet.Range("B" & X).Value = ""
                oSheet.Range("C" & X).Value = ""
                oSheet.Range("D" & X).Value = ""
                oSheet.Range("E" & X).Value = ""
                oSheet.Range("F" & X).Value = ""
                oSheet.Range("G" & X).Value = ""
                oSheet.Range("H" & X).Value = ""
                oSheet.Range("I" & X).Value = ""
                oSheet.Range("J" & X).Value = ""
                X = X + 1

            Next

            oBook.Application.DisplayAlerts = False
            oBook.Save()
            oBook.Application.DisplayAlerts = False
            oSheet = Nothing
            oBook = Nothing
            oExcel.Quit()
        Catch EX As Exception
            MsgBox("Error")
        End Try
    End Sub

    Private Sub cargaexcel()
        Try
            My.Computer.FileSystem.CopyFile(
    "E:\orca\PROGRAMACION\OPTIMA_INVERSIONES\ofactoring\ofactoring\ofactoring\bin\Debug\SIMULACION_CUOTAS.xlsx",
    "E:\SIMULACIONES_CUOTAS\SIMULACION " + TextBox3.Text + ".xlsx",
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            Dim oExcel As Object
            Dim oBook As Object
            Dim oSheet As Object
            Dim i As Integer
            Dim k As Integer
            Dim c As Integer = 0

            'Start a new workbook in Excel.
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.open("E:\SIMULACIONES_CUOTAS\SIMULACION " + TextBox3.Text + ".xlsx")

            ' Se hace un contador para saber  cuantas  filas  tiene agregado el listBox
            For i = 0 To ListView1.Items.Count - 1
                c = c + 1
            Next
            ' Una vez El contador  cargue a la variable la cantidad le restamos 1 porque el indice empieza en 0
            c = c - 1

            oSheet = oBook.Worksheets(1)
            'Creamos una variable para que empieze a cargar datos en determinada fila de excel y le asignamos un valor
            Dim X As Integer
            oSheet.Range("D7").Value = TextBox3.Text
            oSheet.Range("D8").Value = TextBox5.Text
            oSheet.Range("D9").Value = TextBox4.Text
            oSheet.Range("D10").Value = TextBox6.Text
            oSheet.Range("D11").Value = TextBoxIMPORTE.Text
            X = 14
            ' se hace un for para cargar los datos en excel y ya depende del numero de columnas que tenga se coloca
            ' Abajo las expresiones

            For k = 0 To c
                oSheet.Range("A" & X).Value = ListView1.Items(k).SubItems.Item(0).Text.ToString
                oSheet.Range("B" & X).Value = ListView1.Items(k).SubItems.Item(1).Text.ToString
                oSheet.Range("C" & X).Value = ListView1.Items(k).SubItems.Item(2).Text.ToString
                oSheet.Range("D" & X).Value = ListView1.Items(k).SubItems.Item(3).Text.ToString
                oSheet.Range("E" & X).Value = ListView1.Items(k).SubItems.Item(4).Text.ToString
                oSheet.Range("F" & X).Value = ListView1.Items(k).SubItems.Item(5).Text.ToString
                oSheet.Range("G" & X).Value = ListView1.Items(k).SubItems.Item(6).Text.ToString
                oSheet.Range("H" & X).Value = ListView1.Items(k).SubItems.Item(7).Text.ToString
                oSheet.Range("I" & X).Value = ListView1.Items(k).SubItems.Item(8).Text.ToString
                oSheet.Range("J" & X).Value = ListView1.Items(k).SubItems.Item(9).Text.ToString
                X = X + 1

            Next
            oBook.Application.DisplayAlerts = False
            oBook.Save()
            oBook.Application.DisplayAlerts = False
            oSheet = Nothing
            oBook = Nothing
            oExcel.Quit()
            System.Diagnostics.Process.Start("E:\SIMULACIONES_CUOTAS\SIMULACION " + TextBox3.Text + ".xlsx")
        Catch EX As Exception
            MsgBox("Error")
        End Try
    End Sub

    Private Sub TextBox3_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Amortizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker2.Visible = False
        dtp3.Visible = False
        dtp4.Visible = False
        Button2.Visible = False
        Button3.Visible = False
        TextBoxIMPORTE.Text = Anex_Cronog.t10.Text
        IGVINT.Text = Anex_Cronog.t8.Text
        TextBoxINTERES.Text = Anex_Cronog.t11.Text
        Label1.Visible = False
        Label5.Visible = False
        Label1.Visible = False
        pgracia.Text = 0
        TextBoxINTERES.Enabled = False
        IGVINT.Enabled = False
        TextBoxMESES.Enabled = False
        DIAS.Enabled = False
        pgracia.Enabled = False
        Button1.Enabled = False
        Button5.Enabled = False
        DateTimePicker1.Enabled = False
        cambio.Text = 1000
        Label11.Text = ""
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Try
            Dim igv As Decimal = TextBox6.Text / 100
            Dim pcdd As Decimal = ((TextBox5.Text * TextBox4.Text) / 100)
            Dim migvcd As Decimal = pcdd * igv
            TextBoxIMPORTE.Text = TextBox5.Text + pcdd + migvcd

        Catch ex As Exception
            MessageBox.Show("Ingresa el Porcentaje de Comision de desembolso", "Optima")
        End Try
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        PrintPreviewDialog1.Show()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim i As Integer
        Dim k As Integer
        Dim c As Integer = 0
        Try
            ' La fuente a usar
            Dim prFont As New Font("Arial", 12, FontStyle.Bold)
            ' la posición superior

            'imprimimos la fecha y hora
            prFont = New Font("Arial", 10, FontStyle.Regular)
            e.Graphics.DrawString(Date.Now.ToShortDateString.ToString & " " &
                                Date.Now.ToShortTimeString.ToString, prFont, Brushes.Black, 700, 20)

            'NOMBRE DE CRONOGRAMA
            prFont = New Font("Arial", 20, FontStyle.Bold)
            e.Graphics.DrawString("SIMULACION DE CUOTAS", prFont, Brushes.Black, 250, 70)
            '-----------------------------------------------------------------------------------------------------
            'imprimimos el nombre del cliente
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString(Label8.Text, prFont, Brushes.Black, 80, 120)

            'imprimimos el nombre del cliente
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString(TextBox3.Text, prFont, Brushes.Black, 360, 120)
            '------------------------------------------------------------------------------------------
            'imprimimos el monto
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString(Label18.Text, prFont, Brushes.Black, 80, 150)

            'imprimimos el monto
            prFont = New Font("Arial", 10, FontStyle.Bold)
            Dim minipres As Decimal = TextBox5.Text
            e.Graphics.DrawString(minipres.ToString("#,#.00"), prFont, Brushes.Black, 360, 150)

            '-----------------------------------------------------------------------------

            'imprimimos el % CDD
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString(Label17.Text, prFont, Brushes.Black, 80, 180)

            'imprimimos el %/CDD
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString(TextBox4.Text, prFont, Brushes.Black, 360, 180)

            '----------------------------------------------------------------------------------
            'imprimimos el % IGV CDD
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString(Label19.Text, prFont, Brushes.Black, 80, 210)

            'imprimimos el % IGV CDD
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString(TextBox6.Text, prFont, Brushes.Black, 360, 210)

            '----------------------------------------------------------------------------------
            'imprimimos el  IMPORTE A FINANCIAR
            prFont = New Font("Arial", 8, FontStyle.Bold)
            e.Graphics.DrawString(Label2.Text, prFont, Brushes.Black, 80, 240)

            'imprimimos el  IMPORTE A FINANCIAR
            prFont = New Font("Arial", 8, FontStyle.Bold)
            Dim importe As Decimal = TextBoxIMPORTE.Text
            e.Graphics.DrawString(importe.ToString("#,#.00"), prFont, Brushes.Black, 360, 240)

            For i = 0 To ListView1.Items.Count - 1
                c = c + 1
            Next
            c = c - 1
            Dim X As Integer
            Dim reglon As Integer = 320
            prFont = New Font("Arial", 7, FontStyle.Bold)
            e.Graphics.DrawString("PER", prFont, Brushes.Black, 15, 290)
            e.Graphics.DrawString(ListView1.Columns.Item(1).Text, prFont, Brushes.Black, 50, 290)
            e.Graphics.DrawString(ListView1.Columns.Item(2).Text, prFont, Brushes.Black, 150, 290)
            e.Graphics.DrawString(ListView1.Columns.Item(3).Text, prFont, Brushes.Black, 250, 290)
            e.Graphics.DrawString(ListView1.Columns.Item(4).Text, prFont, Brushes.Black, 350, 290)
            e.Graphics.DrawString(ListView1.Columns.Item(5).Text, prFont, Brushes.Black, 450, 290)
            e.Graphics.DrawString(ListView1.Columns.Item(6).Text, prFont, Brushes.Black, 550, 290)
            e.Graphics.DrawString(ListView1.Columns.Item(7).Text, prFont, Brushes.Black, 640, 290)
            e.Graphics.DrawString(ListView1.Columns.Item(8).Text, prFont, Brushes.Black, 670, 290)
            e.Graphics.DrawString(ListView1.Columns.Item(9).Text, prFont, Brushes.Black, 770, 290)

            For k = 0 To c
                prFont = New Font("Arial", 7, FontStyle.Bold)
                Dim colum0 As Decimal = ListView1.Items(k).SubItems.Item(0).Text.ToString
                Dim colum1 As Decimal = ListView1.Items(k).SubItems.Item(1).Text.ToString
                Dim colum2 As Decimal = ListView1.Items(k).SubItems.Item(2).Text.ToString
                Dim colum3 As Decimal = ListView1.Items(k).SubItems.Item(3).Text.ToString
                Dim colum4 As Decimal = ListView1.Items(k).SubItems.Item(4).Text.ToString
                Dim colum5 As Decimal = ListView1.Items(k).SubItems.Item(5).Text.ToString
                Dim colum6 As Decimal = ListView1.Items(k).SubItems.Item(6).Text.ToString
                Dim colum7 As Decimal = ListView1.Items(k).SubItems.Item(7).Text.ToString
                Dim colum8 As Date = ListView1.Items(k).SubItems.Item(8).Text.ToString
                Dim colum9 As Date = ListView1.Items(k).SubItems.Item(9).Text.ToString
                e.Graphics.DrawString(colum0.ToString("#"), prFont, Brushes.Black, 15, reglon)
                e.Graphics.DrawString(colum1.ToString("#,#.00"), prFont, Brushes.Black, 50, reglon)
                e.Graphics.DrawString(colum2.ToString("#,#.00"), prFont, Brushes.Black, 150, reglon)
                e.Graphics.DrawString(colum3.ToString("#,#.00"), prFont, Brushes.Black, 250, reglon)
                e.Graphics.DrawString(colum4.ToString("#,#.00"), prFont, Brushes.Black, 350, reglon)
                e.Graphics.DrawString(colum5.ToString("#,#.00"), prFont, Brushes.Black, 450, reglon)
                e.Graphics.DrawString(colum6.ToString("#,#.00"), prFont, Brushes.Black, 550, reglon)
                e.Graphics.DrawString(colum7.ToString("#"), prFont, Brushes.Black, 640, reglon)
                e.Graphics.DrawString(colum8.ToString("dd/MM/yyyy"), prFont, Brushes.Black, 670, reglon)
                e.Graphics.DrawString(colum9.ToString("dd/MM/yyyy"), prFont, Brushes.Black, 770, reglon)

                'oSheet.Range("B" & X).Value = ListView1.Items(k).SubItems.Item(1).Text.ToString
                'oSheet.Range("C" & X).Value = ListView1.Items(k).SubItems.Item(2).Text.ToString
                ' oSheet.Range("D" & X).Value = ListView1.Items(k).SubItems.Item(3).Text.ToString
                'oSheet.Range("E" & X).Value = ListView1.Items(k).SubItems.Item(4).Text.ToString
                'oSheet.Range("F" & X).Value = ListView1.Items(k).SubItems.Item(5).Text.ToString
                ' oSheet.Range("G" & X).Value = ListView1.Items(k).SubItems.Item(6).Text.ToString
                ' oSheet.Range("H" & X).Value = ListView1.Items(k).SubItems.Item(7).Text.ToString
                'oSheet.Range("I" & X).Value = ListView1.Items(k).SubItems.Item(8).Text.ToString
                ' oSheet.Range("J" & X).Value = ListView1.Items(k).SubItems.Item(9).Text.ToString
                X = X + 1
                reglon = reglon + 30

            Next
            ''imprimimos la referencia del pedido
            ' e.Graphics.DrawString("Referencia", prFont, Brushes.Black, 48, 520)
            'prFont = New Font("Arial", 12, FontStyle.Bold)
            ' e.Graphics.DrawString("Nombre de la Referencia", prFont, Brushes.Black, 12, 555)
            'imprimimos Pedido Ondupack y Pedido del cliente
            'prFont = New Font("Arial", 12, FontStyle.Regular)
            'e.Graphics.DrawString("Pedido", prFont, Brushes.Black, 62, 660)
            'e.Graphics.DrawString("Palets", prFont, Brushes.Black, 62, 660)

            ' prFont = New Font("Arial", 12, FontStyle.Regular)
            ' e.Graphics.DrawString("19875", prFont, Brushes.Black, 50, 700)
            ' e.Graphics.DrawString("44", prFont, Brushes.Black, 250, 700)

            'imprimimos Cajas X Palet y Cajas x Paquete
            ' prFont = New Font("Arial", 12, FontStyle.Regular)
            ' e.Graphics.DrawString("Cajas x Palet", prFont, Brushes.Black, 50, 760)
            ' e.Graphics.DrawString("Cajas x Paquete", prFont, Brushes.Black, 250, 760)

            ' prFont = New Font("Arial", 12, FontStyle.Regular)
            'e.Graphics.DrawString("500", prFont, Brushes.Black, 50, 800)
            ' e.Graphics.DrawString("32", prFont, Brushes.Black, 250, 800)

            'imprimimos el numero del Palet
            ' prFont = New Font("Arial", 12, FontStyle.Regular)
            'e.Graphics.DrawString("Número del Palet     45", prFont, Brushes.Black, 50, 880)
            'indicamos que hemos llegado al final de la pagina
            'e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message, "Administrador",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Public Sub n_dias()
        Try
            Dim x, y As Date
            Dim d As Integer
            d = DIAS.Text
            x = DateTimePicker2.Value
            y = DateAdd("D", d, x)
            MsgBox("la nueva fecha es: " & Format$(y, "ddMMyyyy"))
            Select Case Weekday(y)
                Case vbSunday
                Case vbMonday
                Case vbTuesday
                Case vbWednesday
                Case vbThursday
                Case vbFriday
                Case vbSaturday
            End Select
            MsgBox("el dia es:" & Format(y, "dddd"))
            If Weekday(y) = vbSunday Then
                y = DateAdd("D", d + 1, x)
                MsgBox("la nueva fecha es:" & Format$(y, "ddMMyyyy"))
                MsgBox("el dia es:" & Format(y, "dddd"))
            Else
                MsgBox("el dia no cambia:" & Format(y, "dddd"))
            End If
            'MsgBox("el dia es:" & Format(y, "dddd"))
            'y = DateAdd("D", d + 1, x)
            'MsgBox("la nueva fecha es:" & Format$(y, "ddMMyyyy"))
            'MsgBox("el dia es:" & Format(y, "dddd"))
            'fechaf =
            'x = DateAdd("d", pNumDays, pInitDate)
            'If Weekday(x, vbUseSystemDayOfWeek) = 6 Then x = x + 2 'Sábado
            'If Weekday(x, vbUseSystemDayOfWeek) = 7 Then x = x + 1 'Domingo
            'CalcNewDate = x
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        n_dias()

    End Sub
    Private Sub feriados()
        Try
            fe_modi = fechaf
            fe_reg = fe_modi.ToString("yyyyMMdd")
            sql = "select *from feriados where feriado='" + fe_reg + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                f_com_fer = dr(0)
                dtp4.Value = dr(0)
                dias_c = dias_d + 1
                'MessageBox.Show("el feriado existe")
                fechaf = DateAdd("D", dias_c, FECHA)

                If Weekday(fechaf) = vbSaturday Then
                    dias_c = dias_d + 3
                    f_final = DateTimePicker1.Value
                Else
                    If Weekday(fechaf) = vbSunday Then
                        dias_c = dias_d + 2
                        f_final = DateTimePicker1.Value
                    Else
                        f_final = DateTimePicker1.Value
                    End If
                End If
                'fechaf = DateAdd("D", dias_c, FECHA)
            Else
                'MessageBox.Show("el feriado no existe")
                'dias_c = dias_d
                'fechaf = DateAdd("D", dias_c, FECHA)
            End If

            dr.Close()
            conexion.conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub feriados2()
        Try
            fe_modi = fechaf
            fe_reg = fe_modi.ToString("yyyyMMdd")
            sql = "select *from feriados where feriado='" + fe_reg + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                f_com_fer = dr(0)
                dtp4.Value = dr(0)
                dias_c = dias_d + 2
                'MessageBox.Show("el feriado existe")
                fechaf = DateAdd("D", dias_c, FECHA)
                If Weekday(fechaf) = vbSaturday Then
                    dias_c = dias_d + 4
                    f_final = DateTimePicker1.Value
                Else
                    If Weekday(fechaf) = vbSunday Then
                        dias_c = dias_d + 3
                        f_final = DateTimePicker1.Value
                    Else
                        f_final = DateTimePicker1.Value
                    End If
                End If
                fechaf = DateAdd("D", dias_c, FECHA)

            Else
                'MessageBox.Show("el feriado no existe")
                'dias_c = dias_d
                'fechaf = DateAdd("D", dias_c, FECHA)
            End If

            dr.Close()
            conexion.conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Exportar_SQLite(ByVal Sql As String)
        Try
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(Sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
        Catch ex As Exception
            MsgBox("No se pueden guardar los registro por: " & ex.Message, MsgBoxStyle.Critical, ":::OPTIMA:::")
        End Try


    End Sub

    Private Sub AMORTI_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub INTEREST_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub IGV_INTERET_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub CAPFIN_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled Then
            Label15.Text = "Proceso Cancelado"
        ElseIf e.Error IsNot Nothing Then
            Label15.Text = e.Error.Message


        End If

        'Label14.Text = "PERFECTO"
    End Sub

    Private Sub bojetivo()
        Try
            dias_d = DIAS.Text
            Dim PRESTAMO As Decimal = TextBoxIMPORTE.Text
            'Dim TIPO As Single = ((1 + (TextBoxINTERES.Text / 100) / 30) ^ DIAS.Text - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            Dim TIPO As Decimal = 0.0D '= ((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1) '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1) '/ 12 'INTERES MENSUAL
            'Dim TIPO As Single '= (1 + (TextBoxINTERES.Text / 30) ^ DIAS.Text - 1)
            'Dim DIAS_PERIODO As Integer
            Dim TIPO2 As Single
            Dim igv As Decimal = 0.0D

            ' Dim compara As Decimal
            'Dim sum_amorti As Decimal
            Dim PERIODOS As Integer = TextBoxMESES.Text '* 12
            Dim TPERIODOS As Integer
            Dim CUOTA As Decimal = 0.0D '= Pmt(TIPO, PERIODOS, -PRESTAMO, 0, 0) 'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
            'Dim CUOTA2 As Decimal
            'Dim cuotaf As Decimal
            'Dim cuo_comp As Decimal
            ' Dim cuomas As Decimal
            Dim cuo_int_igv As Decimal = 0.0D

            Dim INTERESES As Decimal = 0.0D

            Dim TIGV As Decimal = 0.0D
            Dim TINTERESES As Decimal = 0.0D
            Dim AMORTIZACION As Decimal = 0.0D
            Dim TAMORTIZACION As Decimal = 0.0D
            Dim prest_tamor As Decimal = 0.0D
            Dim TCUOTAS As Decimal = 0.0D
            Dim TCAPINI As Decimal = 0.0D
            Dim PENDIENTE As Decimal = PRESTAMO
            Dim comp_pendiente As Decimal = PRESTAMO
            Dim CAPINI As Decimal = PRESTAMO
            Dim pergracia As Decimal = pgracia.Text
            Dim FACT As Decimal
            'Dim p As Integer
            'Dim comp_pendient As Decimal

            '------------------------------------------------------------
            TIPO2 = Math.Round((((1 + (TextBoxINTERES.Text / 100) / 30) ^ 30 - 1)), 9) ' + (TIPO * (IGVINT.Text / 100))

            'cuo_int_igv = (((PRESTAMO * ((TIPO2 * (1 + TIPO2) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO2) ^ (PERIODOS - pgracia.Text) - 1)))))
            'cuo_int_igv = Pmt(TIPO2, (PERIODOS - pgracia.Text), -PRESTAMO, 0, 0)
            '------------------------------------------------------------


            PENDIENTE = PRESTAMO
            CAPINI = PRESTAMO
            TAMORTIZACION = 0.0D
            TINTERESES = 0.0D
            TIGV = 0.0D
            TCUOTAS = 0.0D
            Label11.Text = cuo_int_igv.ToString("#.000000000")
            ListView1.Items.Clear()
            For I = 1 To PERIODOS
                TPERIODOS = PERIODOS - pgracia.Text
                If CAPINI = PENDIENTE Then
                    CAPINI = PRESTAMO
                Else
                    CAPINI = PENDIENTE
                End If

                FECHA = DateTimePicker1.Value

                dias_c = dias_d
                '-------------------------------------------------------

                fechaf = DateAdd("D", dias_c, FECHA)

                '---------------------------------------------

                Label1.Text = fechaf
                If Weekday(fechaf) = vbSaturday Then
                    dias_c = dias_d + 2
                    f_final = DateTimePicker1.Value
                Else
                    If Weekday(fechaf) = vbSunday Then
                        dias_c = dias_d + 1
                        f_final = DateTimePicker1.Value
                    Else
                        f_final = DateTimePicker1.Value
                    End If
                End If
                feriados()
                feriados2()

                '-------------------------------------------------------
                If pergracia = 0 Then

                    TIPO = Math.Round(((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1), 9) ' + (TIPO * (IGVINT.Text / 100))
                    INTERESES = Math.Round((PENDIENTE * TIPO), 9) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                    TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                    igv = Math.Round((INTERESES * (IGVINT.Text / 100)), 9)
                    TIGV += igv
                    'cuo_int_igv = PRESTAMO * ((TIPO * (1 + TIPO) ^ (PERIODOS - pgracia.Text)) / ((1 + TIPO) ^ (PERIODOS - pgracia.Text) - 1))
                    CUOTA = TextBox1.Text 'cuo_int_igv2 'CUOTA '+ igv
                    cuo_int_igv = Math.Round(CUOTA, 9)
                    AMORTIZACION = Math.Round((CUOTA - (INTERESES + igv)), 9)
                    TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                    PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                    TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                    prest_tamor = +TAMORTIZACION - PRESTAMO

                Else
                    TIPO = Math.Round(((1 + (TextBoxINTERES.Text / 100) / 30) ^ dias_c - 1), 9)
                    'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
                    INTERESES = Math.Round(PENDIENTE * TIPO, 9) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                    TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                    igv = Math.Round(INTERESES * (IGVINT.Text / 100), 9)
                    CUOTA = 0
                    TIGV += igv
                    cuo_int_igv = Math.Round((CUOTA + igv + INTERESES), 9)
                    AMORTIZACION = 0
                    TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                    PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                    TCUOTAS += cuo_int_igv 'ACUMULA TODAS LAS CUOTAS
                    pergracia = pergracia - 1
                End If

                Dim LINEA As New ListViewItem(I)
                LINEA.SubItems.Add(CAPINI.ToString("#.00000"))
                LINEA.SubItems.Add(AMORTIZACION.ToString("#.00000"))
                LINEA.SubItems.Add(PENDIENTE.ToString("#.00000"))
                LINEA.SubItems.Add(INTERESES.ToString("#.00000"))
                LINEA.SubItems.Add(igv.ToString("#.00000"))
                LINEA.SubItems.Add(cuo_int_igv.ToString("#.00000"))
                LINEA.SubItems.Add(dias_c.ToString)
                LINEA.SubItems.Add(FECHA.ToShortDateString)
                LINEA.SubItems.Add(f_final.AddDays(dias_c).ToShortDateString)
                LINEA.SubItems.Add(FACT.ToString("#.00000"))
                ListView1.Items.Add(LINEA)
                DateTimePicker1.Value = f_final.AddDays(dias_c)
                dias_d = DIAS.Text

            Next
            DateTimePicker1.Value = DateTimePicker3.Value
            cuo_int_igv -= 0.001

            comp_pendiente = PENDIENTE

            close_for = PENDIENTE
            Dim ressum As Decimal = PENDIENTE / (TextBoxMESES.Text - pgracia.Text)

            TextBox1.Text = CUOTA + ressum
            Label11.Text = CUOTA + ressum

            '------------------------------------------------------------


            'Dim TOTALES As New ListViewItem("TOTALES")
            'TOTALES.SubItems.Add("")
            'TOTALES.SubItems.Add(TAMORTIZACION.ToString("#.00000"))
            'TOTALES.SubItems.Add(PENDIENTE.ToString("#.00000"))
            'TOTALES.SubItems.Add(TINTERESES.ToString("#.00000"))
            'TOTALES.SubItems.Add(TIGV.ToString("#.00000"))
            'TOTALES.SubItems.Add(TCUOTAS.ToString("#.00000"))
            'TOTALES.SubItems.Add("")
            'TOTALES.SubItems.Add("")
            'ListView1.Items.Add(TOTALES)

            'Dim suma_preamor As New ListViewItem("SUMA PER")
            'suma_preamor.SubItems.Add(prest_tamor.ToString("#.000"))
            'ListView1.Items.Add(suma_preamor)
            Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub bobjetivo2()
        'bojetivo()
        Dim crece, per As Integer
        per = TextBoxMESES.Text - pgracia.Text
        crece = 1000


        For i = 0 To crece
            ' cuotaobjetivo = cuotaf
            'pendienteobjetivo = pendientef
            bojetivo()
            Refresh()
            If Math.Round(close_for, 5) = 0.00000 Then
                Exit For

            End If
            i += 1
            TextBox2.Text = i
        Next

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        registro_clientes.activar = 4
        registro_clientes.Show()

    End Sub
End Class