Public Class tcambio
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
    'Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String
    Dim res As Integer, tc As String, td As String, nd As String, ce As String
    Dim pass As String, telef As String, anx As String, nom As String, app As String, apm As String
    Dim m1, m2, ent, fecha, hora As String
    Dim tvsu, tcsu, tvsbs, tcsbs As String
    Dim fe As Date

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar El Tipo de Cambio", "tcambio", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_tc '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Tipo de Cambio Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False

        cb1.Enabled = False
        cb2.Enabled = False
        cb3.Enabled = False

        t1.Text = ""
        cb1.Text = ""
        t2.Text = ""
        cb2.Text = ""
        t3.Text = ""
        cb3.Text = ""
        t4.Text = ""

        t5.Text = ""

        t6.Text = ""
        t7.Text = ""

    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        filtrofecha()
        filtar_fecha()
        t6.Text = Convert.ToString(dtp1.Value.ToShortDateString)
        t7.Text = Convert.ToString(dtp1.Value.ToShortTimeString)

    End Sub

    Dim hr As TimeSpan
    Dim hrr As Date

    Private Sub sunat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles sunat.LinkClicked

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "sbs"
        't6.Text = Convert.ToString(dtp1.Value.ToShortDateString)
        't7.Text = Convert.ToString(dtp1.Value.ToShortTimeString)
        t1.Enabled = False
        cb1.Enabled = False
        cb2.Enabled = False
        dtp1.Enabled = False
        cb3.Enabled = True

        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = True
        t5.Enabled = True
        t4.Text = 0
        t5.Text = 0
        t7.Text = DateTime.Now.ToShortTimeString()
        llenar_combo3()



    End Sub

    Private Sub sbs_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles sbs.LinkClicked

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"

        t1.Enabled = False
        cb1.Enabled = True
        cb2.Enabled = True
        cb3.Enabled = True
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        dtp1.Enabled = True

        't6.Text = Convert.ToString(dtp1.Value.ToShortDateString)

        't7.Text = Convert.ToString(dtp1.Value.ToShortTimeString)
        llenar_combo1()
        llenar_combo2()
        llenar_combo3()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        moneda.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Entidad.Show()
    End Sub

    Private Sub gb1_Enter(sender As Object, e As EventArgs) Handles gb1.Enter

    End Sub

    Dim ds As DataSet
    Dim dt As DataTable

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim fecha1, dia2, mes1, dia1, mes, ano As String
        dia2 = dtp1.Value.Date
        mes1 = dtp1.Value.Date
        ano = dtp1.Value.Year
        mes = mes1.Substring(3, mes1.IndexOf("/"))
        dia1 = dia2.Substring(0, dia2.IndexOf("/"))
        fecha1 = ano + mes + dia1
        t6.Text = Convert.ToString(dtp1.Value.ToShortDateString)

        t7.Text = Convert.ToString(DateTime.Now.ToShortTimeString())
        nc = t1.Text
        m1 = UCase(cb1.Text)
        m2 = UCase(cb2.Text)
        tvsu = t2.Text
        tcsu = t3.Text
        tvsbs = t4.Text
        tcsbs = t5.Text
        fecha = fecha1
        ent = UCase(cb3.Text)
        hora = t7.Text

        sql = ""
        If accion = "sunat" Then
            sql = "exec ver_tc'" + fecha + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("La Fecha de TIPO DE CAMBIO ya Existe", "tcambio", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion.Close()
            Else
                sql = "exec alta_tc '" + m1 + "','" + m2 + "','" + tvsu + "','" + tcsu + "','" + tvsbs + "','" + tcsbs + "','" + fecha + "','" + ent + "','" + hora + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "sbs" Then

            sql = "exec edita_tc'" + nc + "','" + m1 + "','" + m2 + "','" + tvsu + "','" + tcsu + "','" + tvsbs + "','" + tcsbs + "','" + fecha + "','" + ent + "','" + hora + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            MessageBox.Show("Registro Modificado")
        Else
            accion = "editar"
            sql = "exec edita_tc'" + nc + "','" + m1 + "','" + m2 + "','" + tvsu + "','" + tcsu + "','" + tvsbs + "','" + tcsbs + "','" + fecha + "','" + ent + "','" + hora + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False

        cb1.Enabled = False
        cb2.Enabled = False
        cb3.Enabled = False

    End Sub

    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder


    ' Public Sub conectar()
    ' conexion = New SqlClient.SqlConnection
    ' conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    ' conexion.Open()
    'End Sub
    Private Sub llenar_grid()
        sql = "select * from v_tc"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_tc")
        dgv.DataSource = ds
        dgv.DataMember = "v_tc"
        conexion.conexion.Close()
    End Sub
    Private Sub llenar_combo1()
        sql = "select *from moneda"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "moneda"
        cb1.ValueMember = "tmoneda"
    End Sub
    Private Sub llenar_combo2()
        sql = "select *from moneda"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "moneda"
        cb2.ValueMember = "tmoneda"
    End Sub
    Private Sub llenar_combo3()
        sql = "select *from entidad"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb3.DataSource = dt
        cb3.DisplayMember = "entidad"
        cb3.ValueMember = "enti"
    End Sub


    Private Sub tcambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        Me.Text = "INgreso de Tipo de Cambio" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        llenar_grid()
        't6.Hide()
        't7.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "sunat"
        t4.Enabled = False
        t5.Enabled = False
        t1.Enabled = False
        t2.Enabled = True
        t3.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        cb3.Enabled = True
        dtp1.Enabled = True
        cb1.Text = ""
        cb2.Text = ""
        cb3.Text = ""
        t2.Text = 0
        t3.Text = 0
        t4.Text = 0
        t5.Text = 0
        dtp1.Text = ""
        llenar_combo1()
        llenar_combo2()
        llenar_combo3()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        dtp1.Enabled = True
        'filtar_fecha()

    End Sub

    Private Sub dtp1_MouseClick(sender As Object, e As MouseEventArgs) Handles dtp1.MouseClick

    End Sub

    Private Sub dtp1_Click(sender As Object, e As EventArgs) Handles dtp1.Click

    End Sub

    Private Sub sunat_Click(sender As Object, e As EventArgs) Handles sunat.Click
        Process.Start("http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias")
    End Sub

    Private Sub sbs_Click(sender As Object, e As EventArgs) Handles sbs.Click
        Process.Start("https://www.sbs.gob.pe/app/stats/tc-cv.asp")
    End Sub

    Private Sub filtar_fecha()
        Dim f_tc As Date
        Dim fetipcam As String
        f_tc = dtp1.Value
        fetipcam = f_tc.ToString("yyyyMMdd")
        nc = fetipcam
        sql = "exec ver_tc '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            cb1.Text = dr(1)
            cb2.Text = dr(2)
            t2.Text = dr(3)
            t3.Text = dr(4)
            t4.Text = dr(5)
            t5.Text = dr(6)
            fe = dr(7)
            cb3.Text = dr(8)
            hr = dr(9)
            t6.Text = Convert.ToString(fe.ToShortDateString)
            t7.Text = Convert.ToString(hr)
            dtp1.Value = fe

        Else
            MessageBox.Show("El tipo de cambio  no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Private Sub filtrofecha()
        Dim f_tc As Date
        Dim fetipcam As String
        f_tc = dtp1.Value
        fetipcam = f_tc.ToString("yyyyMMdd")
        nc = fetipcam
        sql = "select *from v_tc where [FECHA] ='" + nc + "'"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_fac_operacion_anx where [FECHA] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_fac_operacion_anx where [FECHA] ='" + nc + "'"
        conexion.conexion.Close()
    End Sub

    Private Sub filtrar_fecha1()
        nc = InputBox("Ingrese fecha de tipo de cambio")
        sql = "exec ver_tc '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            cb1.Text = dr(1)
            cb2.Text = dr(2)
            t2.Text = dr(3)
            t3.Text = dr(4)
            t4.Text = dr(5)
            t5.Text = dr(6)
            fe = dr(7)
            cb3.Text = dr(8)
            hr = dr(9)
            t6.Text = Convert.ToString(fe.ToShortDateString)
            t7.Text = Convert.ToString(hr)
            dtp1.Value = fe

        Else
            MessageBox.Show("El tipo de cambio  no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub

End Class