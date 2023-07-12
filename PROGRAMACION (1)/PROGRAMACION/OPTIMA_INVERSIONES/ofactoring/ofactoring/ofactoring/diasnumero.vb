Public Class diasnumero
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
    Dim sql As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader, dr2 As SqlClient.SqlDataAdapter
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim SUMA As Decimal
    Dim peri As Integer

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            sql = "delete from ndias DBCC CHECKIDENT (ndias, RESEED, 0)"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            llenar_grid()
            SUMA = 0
            TOTAL.Text = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Dim res As Integer, det As String, sa As String

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub diasnumero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        VCRONOG.Enabled = False
        VCRONOG.Text = Amortizacion.TextBoxIMPORTE.Text
        Label5.Text = Amortizacion.TextBoxIMPORTE.Text
        dgv.AllowUserToAddRows = False

    End Sub

    Private Sub CB1_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If CB1.Text = "CUOTAS NUMERO DIAS IGUALES" Then
        'NCUOTAS.Enabled = True
        ' Else
        'NCUOTAS.Enabled = False
        ' End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        ' Dim a As Integer
        Dim b As Date
        'Dim dia1, dia2, dia3, dia4, dia5, dia6, dia7, dia8, dia9, dia10, dia11, dia12, dia13, dia14, dia15, dia16 As String
        'Dim x, z, h, j, y As Integer
        Dim dias(366) As Decimal
        Try
            b = DateTimePicker1.Value
            'If (a Mod 4 = 0 And a Mod 100 <> 0 Or a Mod 400 = 0) Then
            'TextBox2.Text = "el año " + Trim(a) + " Si es bisiesto"
            'Else
            'TextBox2.Text = "el año " + Trim(a) + " No es bisiesto"
            'End If
            Dim datTim1 As Date = DateTimePicker1.Value '#01/01/2018#
            Dim datTim2 As Date = DateTimePicker2.Value
            Dim datTim3 As Date = DateTimePicker1.Value
            Dim datTim4 As Date = DateTimePicker2.Value
            ' Assume Sunday is specified as first day of the week.
            Dim wD As Long = DateDiff(DateInterval.DayOfYear, datTim1, datTim2)
            Dim wY As Long = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
            TextBox1.Text = wD + 1
            TextBox2.Text = wY
            'z = (wD + 1) + (wY)

            'h = 1
            'j = 366
            'For x = 1 To j
            ' If x = TextBox1.Text Then
            ''       For y = x To (z - 1)
            'dias(y) = 30
            'Next
            'x = y
            '
            ' End If
            '
            ' dias(x) = 0

            ' Next

            'For x = 1 To 366
            'MsgBox("dias:" & dias(x) & "contador:" & h)
            'h = h + 1
            ' Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Amortizacion.cuotas_manuales()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        'Dim int, intt As Double
        ''Dim tdia As Double
        ' Dim tot As Double
        'Dim capi As Double

        ' Int = TextBox3.Text / 100
        ' tdia = dias.Text

        'tot = ((1 + int / 30) ^ tdia - 1)
        'TextBox4.Text = tot
        'capi = TextBox6.Text
        'intt = capi * tot

        ' TextBox5.Text = intt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            ' Dim a As Integer
            Dim b As Date
            'Dim dia1, dia2, dia3, dia4, dia5, dia6, dia7, dia8, dia9, dia10, dia11, dia12, dia13, dia14, dia15, dia16 As String
            'Dim x, z, h, j, y As Integer
            Dim dias(366) As Decimal

            b = DateTimePicker1.Value
            'If (a Mod 4 = 0 And a Mod 100 <> 0 Or a Mod 400 = 0) Then
            'TextBox2.Text = "el año " + Trim(a) + " Si es bisiesto"
            'Else
            'TextBox2.Text = "el año " + Trim(a) + " No es bisiesto"
            'End If
            Dim datTim1 As Date = #01/01/2018#
            Dim datTim2 As Date = DateTimePicker1.Value
            Dim datTim3 As Date = DateTimePicker1.Value
            Dim datTim4 As Date = DateTimePicker2.Value
            ' Assume Sunday is specified as first day of the week.
            Dim wD As Long = DateDiff(DateInterval.DayOfYear, datTim1, datTim2)
            Dim wY As Long = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
            TextBox1.Text = wD + 1
            TextBox2.Text = wY
            'z = (wD + 1) + (wY)

            'h = 1
            'j = 366
            'For x = 1 To j
            ' If x = TextBox1.Text Then
            ''       For y = x To (z - 1)
            'dias(y) = 30
            'Next
            'x = y
            '
            ' End If
            '
            ' dias(x) = 0

            ' Next

            'For x = 1 To 366
            'MsgBox("dias:" & dias(x) & "contador:" & h)
            'h = h + 1
            ' Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub INSERTEAR_DIAS_MANUAL()
        Try
            Dim FEC_VEN As Date
            Dim FEC_VENC As String
            FEC_VEN = DateTimePicker2.Value
            FEC_VENC = FEC_VEN.ToString("yyyyMMdd")
            sql = "exec alta_dias '" + FEC_VENC + "','" + AMORTI.Text + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            llenar_grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub INSERTAR_DIAS_AUTOMATICO()
    'Dim X As Integer
    'For X = 0 To NCUOTAS.Text - 1
    '   sql = "exec alta_dias '" + dias.Text + "','" + PORC.Text + "'"
    '   conexion.conectar()
    '  com = New SqlClient.SqlCommand(sql, conexion.conexion)
    '  res = com.ExecuteNonQuery
    '  conexion.Close()
    'Next
    'llenar_grid()

    'End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            INSERTEAR_DIAS_MANUAL()
            peri = peri + 1
            SUMA = AMORTI.Text + SUMA
            TOTAL.Text = SUMA
            Label7.Text = SUMA
            TextBox3.Text = peri
            MsgBox("Cambie la fecha venciomiento de la siguiente cuota, el monto ingresado al momento" + " " & SUMA & " ", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub llenar_grid()
        Try
            sql = "select * from v_ndias order by id"
            conexion.conectar()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_ndias")
            dgv.DataSource = ds
            dgv.DataMember = "v_ndias"
            conexion.conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class