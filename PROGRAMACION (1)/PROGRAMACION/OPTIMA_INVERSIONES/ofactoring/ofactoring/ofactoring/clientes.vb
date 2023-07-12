Public Class clientes

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
    Dim pass, estado As String, telef As String, anx As String, nom As String, app As String, apm As String
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Public activ As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        cb1.Enabled = True
        t2.Enabled = True
        cb2.Enabled = True
        t3.Enabled = True
        cb3.Enabled = True
        t4.Enabled = True
        cb4.Enabled = True
        t5.Enabled = True
        cb5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        t9.Enabled = True
        t10.Enabled = True
        Button5.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cb3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb3.SelectedIndexChanged

    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        regcuentabanco.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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
            MsgBox("ERROR AL HACER LA EXPORTACION", MsgBoxStyle.Information, "Optima")
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        tcliente.Show()

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        tdoc.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        disitrito.Show()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        departamento.Show()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        provincia.Show()

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        nc = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        nd = dgv.Rows(dgv.CurrentRow.Index).Cells(3).Value
        sql = "exec ver_clientes_guardar'" + nc + "','" + nd + "'"
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
            t6.Text = dr(7)
            t7.Text = dr(8)
            t8.Text = dr(9)
            t9.Text = dr(10)
            t10.Text = dr(11)
            cb3.Text = dr(12)
            cb4.Text = dr(13)
            cb5.Text = dr(14)
            ComboBox1.Text = dr(15)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        nc = InputBox("Ingrese Datos de cliente")
        sql = "select *from v_clientes where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTOS]='" + nc + "'"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_clientes where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTOS]='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_clientes where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTOS]='" + nc + "'"
        conexion.conexion.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Aprobado" Then
            l1.Text = ""
        Else

            l1.Text = "Los Datos se Guardaran para tenerlo como Contacto"
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        nc = t1.Text
        tc = UCase(cb1.Text)
        td = UCase(cb2.Text)
        nd = UCase(t2.Text)
        ce = UCase(t3.Text)
        pass = UCase(t4.Text)
        telef = UCase(t5.Text)
        anx = UCase(t6.Text)
        nom = UCase(t7.Text)
        app = UCase(t8.Text)
        apm = UCase(t9.Text)
        drc = UCase(t10.Text)
        dto = UCase(cb3.Text)
        dpo = UCase(cb4.Text)
        pvc = UCase(cb5.Text)
        estado = UCase(ComboBox1.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_clientes_guardar'" + nc + "','" + nd + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El DNI o el Codigo de Contacto ya existe", "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion.Close()
            Else
                sql = "exec alta_clientes '" + tc + "','" + td + "','" + nd + "','" + ce + "','" + pass + "','" + telef + "','" + anx + "','" + nom + "','" + app + "','" + apm + "','" + drc + "','" + dto + "','" + dpo + "','" + pvc + "','" + estado + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_cliente'" + nc + "','" + tc + "','" + td + "','" + nd + "','" + ce + "','" + pass + "','" + telef + "','" + anx + "','" + nom + "','" + app + "','" + apm + "','" + drc + "','" + dto + "','" + dpo + "','" + pvc + "','" + estado + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        buscar_copiar()
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t8.Enabled = False
        t9.Enabled = False
        t10.Enabled = False
        cb1.Enabled = False
        cb2.Enabled = False
        cb3.Enabled = False
        cb4.Enabled = False
        cb5.Enabled = False
        ComboBox1.Enabled = False

    End Sub

    Public Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        nc = InputBox("Ingrese el Documento de Identidad, RUC o Codigo de cliente", "Optima Inversiones")
        sql = "exec ver_clientes '" + nc + "'"
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
            t6.Text = dr(7)
            t7.Text = dr(8)
            t8.Text = dr(9)
            t9.Text = dr(10)
            t10.Text = dr(11)
            cb3.Text = dr(12)
            cb4.Text = dr(13)
            cb5.Text = dr(14)
            ComboBox1.Text = dr(15)
            registro_clientes.t2.Text = dr(0)
            registro_clientes.t3.Text = dr(8)
            registro_clientes.t4.Text = dr(9)
            registro_clientes.t5.Text = dr(10)
            registro_clientes.t6.Text = dr(2)
            registro_clientes.t7.Text = dr(3)
            registro_clientes.t8.Text = dr(11)
            registro_clientes.t9.Text = dr(12) & " / " & dr(13) & " / " & dr(14)

        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        'registro_clientes.cod_clie_bdp = t1.Text
        'registro_clientes.tipodoc_clie = cb2.Text
        'registro_clientes.numdoc_clie = t2.Text
        'registro_clientes.nom_cliente = t7.Text
        'registro_clientes.appat_clie = t8.Text
        'registro_clientes.apmat_clie = t9.Text
        'registro_clientes.cali_finan = ComboBox1.Text
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar El Cliente", "CLIENTES", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_clientes '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t8.Enabled = False
        t9.Enabled = False
        t10.Enabled = False
        cb1.Enabled = False
        cb2.Enabled = False
        cb3.Enabled = False
        cb4.Enabled = False
        cb5.Enabled = False
        ComboBox1.Enabled = False
        t1.Text = ""
        cb1.Text = ""
        t2.Text = ""
        cb2.Text = ""
        t3.Text = ""
        cb3.Text = ""
        t4.Text = ""
        cb4.Text = ""
        t5.Text = ""
        cb5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""
        t9.Text = ""
        t10.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub t11_TextChanged(sender As Object, e As EventArgs) Handles t11.TextChanged
        If cb7.Text = "CODIGO" Then
            filtro1()
        Else
            If cb7.Text = "NUMERO DE DOCUMENTOS" Then
                filtro2()
            Else
                If cb7.Text = "NOMBRES" Then
                    filtro3()
                Else
                    If cb7.Text = "APELLIDO PATERNO" Then
                        filtro4()
                    Else
                        If cb7.Text = "APELLIDO MATERNO" Then
                            filtro5()

                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cb7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb7.SelectedIndexChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles t2.TextChanged

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t1.Enabled = False
        t1.Text = ""
        cb1.Enabled = True
        cb1.Text = ""
        t2.Enabled = True
        t2.Text = ""
        cb2.Enabled = True
        cb2.Text = ""
        t3.Enabled = True
        t3.Text = ""
        cb3.Enabled = True
        cb3.Text = ""
        t4.Enabled = True
        t4.Text = ""
        cb4.Enabled = True
        cb4.Text = ""
        t5.Enabled = True
        t5.Text = ""
        cb5.Enabled = True
        cb5.Text = ""
        t6.Enabled = True
        t6.Text = ""
        t7.Enabled = True
        t7.Text = ""
        t8.Enabled = True
        t8.Text = ""
        t9.Enabled = True
        t9.Text = ""
        t10.Enabled = True
        t10.Text = ""
        Button5.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
        ComboBox1.Enabled = True
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    'Public Sub conectar()
    'conexion = New SqlClient.SqlConnection
    'conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    'conexion.Open()
    'End Sub
    Private Sub llenar_grid()
        sql = "select * from v_clientes"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_clientes")
        dgv.DataSource = ds
        dgv.DataMember = "v_clientes"
        conexion.conexion.Close()
    End Sub
    Public Sub llenar_combo1()
        sql = "select *from tipcliente"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "tipcliente"
        cb1.ValueMember = "detalle"
    End Sub
    Public Sub llenar_combo2()
        sql = "select *from tipdoc"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "tipdoc"
        cb2.ValueMember = "detalle"
    End Sub
    Public Sub llenar_combo3()
        sql = "select *from distrito"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb3.DataSource = dt
        cb3.DisplayMember = "distrito"
        cb3.ValueMember = "distrito"
    End Sub
    Public Sub llenar_combo4()
        sql = "select *from departamento"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb4.DataSource = dt
        cb4.DisplayMember = "departamento"
        cb4.ValueMember = "departamento"
    End Sub
    Public Sub llenar_combo5()
        sql = "select *from provincia"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb5.DataSource = dt
        cb5.DisplayMember = "provincia"
        cb5.ValueMember = "provincia"
    End Sub
    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged

    End Sub

    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        llenar_grid()
        llenar_combo1()
        llenar_combo2()
        llenar_combo3()
        llenar_combo4()
        llenar_combo5()
        cb1.Text = ""
        cb2.Text = ""
        cb3.Text = ""
        cb4.Text = ""
        cb5.Text = ""
        t3.Hide()
        t4.Hide()
        Label5.Hide()
        Label6.Hide()


    End Sub
    Private Sub buscar_copiar()
        sql = "select *from clientes where id in (select max(id) from clientes)"
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
            t6.Text = dr(7)
            t7.Text = dr(8)
            t8.Text = dr(9)
            t9.Text = dr(10)
            t10.Text = dr(11)
            cb3.Text = dr(12)
            cb4.Text = dr(13)
            cb5.Text = dr(14)
            ComboBox1.Text = dr(15)

        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        'registro_clientes.cod_clie_bdp = t1.Text
        'registro_clientes.tipodoc_clie = cb2.Text
        'registro_clientes.numdoc_clie = t2.Text
        'registro_clientes.nom_cliente = t7.Text
        'registro_clientes.appat_clie = t8.Text
        'registro_clientes.apmat_clie = t9.Text
        'registro_clientes.cali_finan = ComboBox1.Text
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Private Sub filtro1()
        nc = t11.Text
        sql = "select *from v_clientes where [CODIGO] like'" + nc + "%'"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_clientes where [CODIGO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_clientes where [CODIGO] like'" + nc + "%'"
        conexion.conexion.Close()
    End Sub

    Private Sub filtro2()
        nc = t11.Text
        sql = "select *from v_clientes where [NUMERO DE DOCUMENTOS] like'" + nc + "%'"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_clientes where [NUMERO DE DOCUMENTOS] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_clientes where [NUMERO DE DOCUMENTOS] like'" + nc + "%'"
        conexion.conexion.Close()
    End Sub

    Private Sub filtro3()
        nc = t11.Text
        sql = "select *from v_clientes where [NOMBRES] like'" + nc + "%'"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_clientes where [NOMBRES] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_clientes where [NOMBRES] like'" + nc + "%'"
        conexion.conexion.Close()
    End Sub

    Private Sub filtro4()
        nc = t11.Text
        sql = "select *from v_clientes where [APELLIDO PATERNO] like'" + nc + "%'"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_clientes where [APELLIDO PATERNO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_clientes where [APELLIDO PATERNO] like'" + nc + "%'"
        conexion.conexion.Close()
    End Sub
    Private Sub filtro5()
        nc = t11.Text
        sql = "select *from v_clientes where [APELLIDO MATERNO] like'" + nc + "%'"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_clientes where [APELLIDO MATERNO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_clientes where [APELLIDO MATERNO] like'" + nc + "%'"
        conexion.conexion.Close()
    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        nc = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        ' nd = dgv.Rows(dgv.CurrentRow.Index).Cells(3).Value
        sql = "exec ver_clientes'" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            registro_clientes.t2.Text = dr(0)
            registro_clientes.t3.Text = dr(8)
            registro_clientes.t4.Text = dr(9)
            registro_clientes.t5.Text = dr(10)
            registro_clientes.t6.Text = dr(2)
            registro_clientes.t7.Text = dr(3)
            registro_clientes.t8.Text = dr(11)
            registro_clientes.t9.Text = dr(12) & " / " & dr(13) & " / " & dr(14)

        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        Me.Close()
    End Sub

    Private Sub dgv_CellContextMenuStripChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContextMenuStripChanged

    End Sub
End Class
