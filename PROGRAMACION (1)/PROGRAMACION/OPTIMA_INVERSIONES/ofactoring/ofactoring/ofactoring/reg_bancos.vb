Public Class reg_bancos
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
    Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String
    Dim res As Integer, tc As String, td As String, nd As String, ce As String
    Dim ncome, rsoc, tipdoc, ndoc As String
    Dim pass As String, telef As String, anx As String, nom As String, app As String, apm As String
    Dim m1, m2, ent, fecha, hora As String

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea borrar los Datos?", "reg_bancos", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_rbancos '" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        cb1.Enabled = False
        t4.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        cb1.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
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

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        cb1.Enabled = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = InputBox("Ingrese Codigo, Ruc o Razon Social de Banco")


        sql = "exec ver_rbancoa '" + nc + "'"
        conectar()
        com = New SqlClient.SqlCommand(sql, conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            cb1.Text = dr(3)
            t4.Text = dr(4)


        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        conexion.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = t1.Text
        ncome = UCase(t2.Text)
        rsoc = UCase(t3.Text)
        tipdoc = UCase(cb1.Text)
        ndoc = UCase(t4.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_rbancoa'" + nc + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "reg_bancos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.Close()
            Else
                sql = "exec alta_rbancos '" + ncome + "','" + rsoc + "','" + tipdoc + "','" + ndoc + "','" + sunat.Text + "'"
                conectar()
                com = New SqlClient.SqlCommand(sql, conexion)
                res = com.ExecuteNonQuery
                conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_rbancos'" + nc + "','" + ncome + "','" + rsoc + "','" + tipdoc + "','" + ndoc + "','" + sunat.Text + "'"
            conectar()
            com = New SqlClient.SqlCommand(sql, conexion)
            res = com.ExecuteNonQuery
            conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        plancontable.llenar_combo1()
        regcuentabanco.llenar_combo2()
        t1.Enabled = False
        t2.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t1.Enabled = False
        t1.Text = ""
        t2.Enabled = True
        t2.Text = ""
        t3.Enabled = True
        t3.Text = ""
        t4.Enabled = True
        t4.Text = ""
        cb1.Enabled = True
        cb1.Text = ""
        sunat.Enabled = True
        sunat.Text = ""

    End Sub

    Dim tvsu, tcsu, tvsbs, tcsbs As String
    Dim fe As Date
    Dim hr As TimeSpan
    Dim hrr As Date
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Public Sub conectar()
        conexion = New SqlClient.SqlConnection
        conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
        conexion.Open()
    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_reg_bancos"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_reg_bancos")
        dgv.DataSource = ds
        dgv.DataMember = "v_reg_bancos"
        conexion.Close()
    End Sub
    Private Sub llenar_combo1()
        sql = "select *from tipdoc"
        conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "tipdoc"
        cb1.ValueMember = "detalle"
    End Sub

    Private Sub reg_bancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        llenar_combo1()
        llenar_grid()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class