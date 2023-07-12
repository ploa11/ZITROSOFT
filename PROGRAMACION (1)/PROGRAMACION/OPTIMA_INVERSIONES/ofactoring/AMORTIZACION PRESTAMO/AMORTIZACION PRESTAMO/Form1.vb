Public Class Form1

    Dim FECHA As DateTime = Now

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        FECHA = DateTimePicker1.Value
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'CUOTA MENSUAL
        ListView1.Items.Clear()
        Try
            Dim PRESTAMO As Integer = TextBoxIMPORTE.Text
            Dim TIPO As Single = 0.01 * TextBoxINTERES.Text / 12 'INTERES MENSUAL
            Dim MESES As Integer = TextBoxMESES.Text * 12
            Dim CUOTA As Single = Pmt(TIPO, MESES, -PRESTAMO, 0, 0) 'VER SNIPPET MATEMATICAS PAGO MENSUAL PRESTAMO
            Label1.Text = CUOTA.ToString("#.00")

            Dim INTERESES As Single = Nothing
            Dim TINTERESES As Single = Nothing
            Dim AMORTIZACION As Single = Nothing
            Dim TAMORTIZACION As Single = Nothing
            Dim TCUOTAS As Single = Nothing
            Dim PENDIENTE As Single = PRESTAMO

            For I = 1 To MESES
                INTERESES = Math.Round(PENDIENTE * TIPO, 2) 'INTERES A APLICAR CADA MES EN FUNCION DEL SALDO PENDIENTE
                TINTERESES += INTERESES 'ACUMULA LOS INTERESES DE TODAS LAS CUOTAS
                AMORTIZACION = Math.Round(CUOTA - INTERESES, 2) 'DIFERENCIA ENTRE CUOTA Y LOS INTERESES DEL MES
                TAMORTIZACION += AMORTIZACION 'ACUMULA LA AMORTIZACION DE TODAS LAS CUOTAS
                PENDIENTE -= AMORTIZACION 'VA REBAJANDO LA PARTE DE AMORTIZACION DE CADA CUOTA
                TCUOTAS += CUOTA 'ACUMULA TODAS LAS CUOTAS

                'LINEA MENSUAL EN EL LISTVIEW
                Dim LINEA As New ListViewItem(I)
                LINEA.SubItems.Add(FECHA.AddMonths(I - 1).ToShortDateString) '(I-1) PARA QUE EMPIECE A CONTAR EN EL MISMO MES
                LINEA.SubItems.Add(CUOTA.ToString("#.00"))
                LINEA.SubItems.Add(AMORTIZACION.ToString("#.00"))
                LINEA.SubItems.Add(INTERESES.ToString("#.00"))
                LINEA.SubItems.Add(PENDIENTE.ToString("#.00"))
                ListView1.Items.Add(LINEA)
            Next
            'LINEA DE TOTALES EN EL LISTVIEW
            Dim TOTALES As New ListViewItem("TOTALES")
            TOTALES.SubItems.Add("")
            TOTALES.SubItems.Add(TCUOTAS.ToString("#.00"))
            TOTALES.SubItems.Add(TAMORTIZACION.ToString("#.00"))
            TOTALES.SubItems.Add(TINTERESES.ToString("#.00"))
            TOTALES.SubItems.Add(PENDIENTE.ToString("#.00"))
            ListView1.Items.Add(TOTALES)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBoxIMPORTE_TextChanged(sender As Object, e As EventArgs) Handles TextBoxIMPORTE.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
