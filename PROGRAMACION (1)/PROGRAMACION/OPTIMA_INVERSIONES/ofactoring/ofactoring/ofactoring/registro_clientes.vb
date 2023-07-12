Public Class registro_clientes
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
    'variables publicas
    Public cod_clie_bdp, nom_cliente, appat_clie, apmat_clie, tipodoc_clie, numdoc_clie, cali_finan As String
    Public activar As String
    'variable locales
    Dim sql, nc As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar El Cliente", "CLIENTES", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_reg_cliente '" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
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
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

        t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_reg_cliente '" + t1.Text + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
            t8.Text = dr(8)
            t9.Text = dr(9)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
        Button3.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button8.Enabled = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        nc = InputBox("Ingrese Datos de cliente")
        sql = "select *from v_reg_cliente where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTO]='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_reg_cliente where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTO]='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_reg_cliente where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTO]='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "editar"
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        Button8.Enabled = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        nc = TextBox1.Text
        sql = "select *from v_reg_cliente where NOMBRE like'" + nc + "%' or [APELLIDO PATERNO] like'" + nc + "%' or [NUMERO DE DOCUMENTO] like '" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_reg_cliente where NOMBRE like'" + nc + "%' or [APELLIDO PATERNO] like'" + nc + "%' or [NUMERO DE DOCUMENTO] like '" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_reg_cliente where NOMBRE like'" + nc + "%' or [APELLIDO PATERNO] like'" + nc + "%' or [NUMERO DE DOCUMENTO] like '" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Public Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Calificacion_de_Cliente.Show()
        Calificacion_de_Cliente.t2.Text = t1.Text
        Calificacion_de_Cliente.t3.Text = t3.Text
        Calificacion_de_Cliente.t4.Text = t4.Text
        Calificacion_de_Cliente.t5.Text = t5.Text
        Calificacion_de_Cliente.buscar_calificacion()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
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

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        registro_de_cuentas_bancos.Show()
    End Sub

    Private Sub registro_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Registro de Clientes de Fondo" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        dgv.AllowUserToAddRows = False
        llenar_grid()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'clientes.Show()
        'clientes.activ = 1
        clientes.Button8_Click(sender, e)
        cod_clie_bdp = clientes.t1.Text
        tipodoc_clie = clientes.cb2.Text
        numdoc_clie = clientes.t2.Text
        nom_cliente = clientes.t7.Text
        appat_clie = clientes.t8.Text
        apmat_clie = clientes.t9.Text
        cali_finan = clientes.ComboBox1.Text

        If cali_finan = "APROBADO" Then
            t2.Text = cod_clie_bdp
            t3.Text = nom_cliente
            t4.Text = appat_clie
            t5.Text = apmat_clie
            t6.Text = tipodoc_clie
            t7.Text = numdoc_clie
        Else
            MessageBox.Show("No se puede registrar como cliente por no tener un buen estado financiero")
        End If


    End Sub

    'variables locales
    Dim accion As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "guardar"
        t1.Text = ""
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        t9.Enabled = True
        Button1.Enabled = True
        Button3.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try
            Button8.Enabled = True
            sql = ""
            If accion = "guardar" Then
                sql = "exec ver_reg_cliente_guardar'" + t2.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("El  Cliente ya existe", "cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    conexion.conexion2.Close()
                Else
                    sql = "exec alta_reg_clientes '" + t2.Text + "','" + t3.Text + "','" + t4.Text + "','" + t5.Text + "','" + t6.Text + "','" + t7.Text + "','" + t8.Text + "','" + t9.Text + "'"
                    conexion.conectarfondo()
                    com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                    res = com.ExecuteNonQuery
                    conexion.conexion2.Close()
                    MessageBox.Show("Registro Guardado")
                    buscar_id()

                End If
            ElseIf accion = "editar" Then
                sql = "exec edita_reg_cliente '" + t1.Text + "','" + t2.Text + "','" + t3.Text + "','" + t4.Text + "','" + t5.Text + "','" + t6.Text + "','" + t7.Text + "','" + t8.Text + "','" + t9.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Modificado")

            End If
            dr.Close()
            conexion.conexion2.Close()
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
        Catch ex As Exception

        End Try


    End Sub

    Public Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button3.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        nc = InputBox("Ingrese el Codigo de cliente", "Optima Inversiones")
        sql = "exec ver_reg_cliente '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            Anex_Cronog.t2.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub llenar_grid()
        sql = "select * from v_reg_cliente"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_reg_cliente")
        dgv.DataSource = ds
        dgv.DataMember = "v_reg_cliente"
        conexion.conexion2.Close()
    End Sub

    Public Sub busq_cr()
        Dim cod_cr_ax As String
        cod_cr_ax = Anex_Cronog.t2.Text
        sql = "exec ver_reg_cliente '" + cod_cr_ax + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
        Button3.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Select Case activar
            Case 1
                t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                sql = "exec ver_reg_cliente '" + t1.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    G_Asientos.cod_cliente.Text = dr(0)
                    G_Asientos.datos_cliente.Text = dr(2) & "  " & dr(3) & "  " & dr(4)
                    G_Asientos.ruc_dni.Text = dr(6)
                Else
                    MessageBox.Show("El Cliente no Existe")
                End If
                dr.Close()
                conexion.conexion2.Close()
                Me.Close()
                Button3.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button8.Enabled = True
            Case 2
                t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                sql = "exec ver_reg_cliente '" + t1.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    Anex_Cronog.t2.Text = dr(0)
                    Anex_Cronog.ruc = dr(6)


                Else
                    MessageBox.Show("El Cliente no Existe")
                End If
                dr.Close()
                conexion.conexion2.Close()
                Me.Close()
                Button3.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button8.Enabled = True

            Case 3

                t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                sql = "exec ver_reg_cliente '" + t1.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    facturacion_fondos.t1.Text = dr(0)
                    facturacion_fondos.ruc = dr(6)
                    facturacion_fondos.direc = dr(8)
                    facturacion_fondos.nom = dr(2) & "  " & dr(3) & "  " & dr(4)
                    facturacion_fondos.dis_dep_prov = dr(9)
                Else
                    MessageBox.Show("El Cliente no Existe")
                End If
                dr.Close()
                conexion.conexion2.Close()
                Me.Close()
                Button3.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button8.Enabled = True
            Case 4
                t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                sql = "exec ver_reg_cliente '" + t1.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    Amortizacion.TextBox3.Text = dr(2) & "  " & dr(3) & "  " & dr(4)
                Else
                    MessageBox.Show("El Cliente no Existe")
                End If
                dr.Close()
                conexion.conexion2.Close()
                Me.Close()
                Button3.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                Button8.Enabled = True
        End Select

    End Sub

    Private Sub buscar_id()

        sql = "select *from d_clientes where id in (select max(id) from d_clientes)"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            Anex_Cronog.t2.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
            t8.Text = dr(8)
            t8.Text = dr(9)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub
End Class