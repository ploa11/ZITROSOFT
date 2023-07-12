Public Class Anexo

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
    'variable prublicas
    Public cod_clie, comi_tra, igv_comi_tran, mont_t_trans, suma_interes, igv_suma_int, mont_tot_interes, total_abono, total_anexo, gest, fec_expo As String
    Dim fec_recep As Date
    Dim accion, nom, appa, apma, tip_ope, est As String
    Dim sql, nc As String

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        nc = InputBox("Ingrese el Codigo de Anexo", "Optima Inversiones")
        sql = "exec ver_anx_ope '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t3.Text = dr(12)
            t5.Text = dr(1)
            t6.Text = dr(2)
            t7.Text = dr(3)
            t9.Text = dr(4)
            t10.Text = dr(5)
            t11.Text = dr(6)
            t12.Text = dr(7)
            t13.Text = dr(8)
            dtp2.Text = dr(9)
            cb2.Text = dr(10)
            t22.Text = dr(13)
            cb4.Text = dr(14)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
        cb3.Enabled = True
    End Sub

    Public Sub buscar_desde_fac()
        nc = fac_operacion_anx.t2.Text
        sql = "exec ver_anx_ope '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t3.Text = dr(12)
            't5.Text = dr(1)
            't6.Text = dr(2)
            't7.Text = dr(3)
            't9.Text = dr(4)
            't10.Text = dr(5)
            't11.Text = dr(6)
            't12.Text = dr(7)
            't13.Text = dr(8)
            dtp2.Text = dr(9)
            cb2.Text = dr(10)
            t22.Text = dr(13)
            cb4.Text = dr(14)
            ComboBox1.Text = dr(15)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        historial.Show()
        historial.buscar_h_anexo()
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        registro_clientes.Show()


    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
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

    Private Sub t14_TextChanged(sender As Object, e As EventArgs) Handles t14.TextChanged
        Select Case cb3.Text
            Case "Anexo"
                filtro_text()
            Case "Codigo de Cliente"
                filtro_text()

        End Select





    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim bus As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        Button6.Enabled = True
        sql = "exec ver_anx_ope '" + bus + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t3.Text = dr(12)
            t5.Text = dr(1)
            t6.Text = dr(2)
            t7.Text = dr(3)
            t9.Text = dr(4)
            t10.Text = dr(5)
            t11.Text = dr(6)
            t12.Text = dr(7)
            t13.Text = dr(8)
            dtp2.Text = dr(9)
            cb2.Text = dr(10)
            t22.Text = dr(13)
            cb4.Text = dr(14)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Public Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "editar"
        Button6.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        facturas()
        fac_operacion_anx.Show()
        Me.Visible = False
        'Me.ShowDialog()
        'Me.Hide()

    End Sub

    Private Sub dtp3_ValueChanged(sender As Object, e As EventArgs) Handles dtp3.ValueChanged
        Select Case cb3.Text
            Case "Fecha de inicio"
                filtro_fecha()
        End Select
    End Sub

    Private Sub estadof_SelectedIndexChanged(sender As Object, e As EventArgs) Handles estadof.SelectedIndexChanged
        Select Case cb3.Text
            Case "Estado"
                estadofil()
        End Select
    End Sub

    Private Sub cb3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb3.SelectedIndexChanged
        Select Case cb3.Text
            Case "Anexo"
                t14.Enabled = True
                estadof.Enabled = False
                dtp3.Enabled = False
            Case " Codigo de Cliente"
                t14.Enabled = True
                estadof.Enabled = False
                dtp3.Enabled = False
            Case "Estado"
                estadof.Enabled = True
                t14.Enabled = False
                dtp3.Enabled = False
            Case "Fecha de inicio"
                dtp3.Enabled = True
                estadof.Enabled = False
                t14.Enabled = False
        End Select
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Me.Close()
    End Sub

    Public Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim cmt, igvct, mti, mtt, igvsi, tlanx, sint As String
        fec_recep = dtp2.Value
        nc = UCase(t2.Text)
        cod_clie = UCase(t3.Text)
        fec_expo = fec_recep.ToString("yyyyMMdd")
        gest = cb2.Text
        cmt = t5.Text.ToString
        comi_tra = cmt
        igvct = t6.Text.ToString
        igv_comi_tran = igvct
        mti = t11.Text.ToString
        mont_tot_interes = mti
        mtt = t7.Text.ToString
        mont_t_trans = mtt
        igvsi = t10.Text.ToString
        igv_suma_int = igvsi
        total_abono = 0
        tlanx = t13.Text.ToString
        total_anexo = tlanx
        sint = t9.Text
        suma_interes = sint
        tip_ope = UCase(t22.Text)
        est = cb4.Text
        sql = ""
        Try
            If accion = "guardar" Then
                sql = "exec ver_anx_ope'" + nc + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("Los Datos ya Existen", "Optima", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    conexion.conexion2.Close()
                Else
                    sql = "exec alta_anx_ope '" + comi_tra + "','" + igv_comi_tran + "','" + mont_t_trans + "','" + suma_interes + "','" + igv_suma_int + "','" + mont_tot_interes + "','" + total_abono + "','" + total_anexo + "','" + fec_expo + "','" + gest + "','" + cod_clie + "','" + tip_ope + "','" + est + "','" + ComboBox1.Text + "'"
                    conexion.conectarfondo()
                    com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                    res = com.ExecuteNonQuery
                    conexion.conexion2.Close()
                    MessageBox.Show("Registro Guardado", "Optima")
                    buscar_copiar()
                    llenar_grid()
                    facturas()
                    fac_operacion_anx.Show()
                End If
            ElseIf accion = "editar" Then
                sql = "exec edita_anx_ope'" + nc + "','" + comi_tra + "','" + igv_comi_tran + "','" + mont_t_trans + "','" + suma_interes + "','" + igv_suma_int + "','" + mont_tot_interes + "','" + total_abono + "','" + total_anexo + "','" + fec_expo + "','" + gest + "','" + cod_clie + "','" + tip_ope + "','" + est + "','" + ComboBox1.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Modificado", "Optima")

            End If
            llenar_grid()
            cb2.Enabled = False
            t2.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos", "Optima")
        End Try

    End Sub

    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Anexo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            dgv.AllowUserToAddRows = False
            Me.Text = "Creacion De Anexo" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
            t22.Text = "Anexo"
            llenar_combo1()
            llenar_grid()
            Label17.Hide()
            t12.Hide()
        Catch ex As Exception
            MessageBox.Show("No se pueder mostrar los datos", "Optima")
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "guardar"
        't2.Enabled = True
        t3.Enabled = True
        dtp2.Enabled = True
        cb2.Enabled = True
        Button6.Enabled = True
        t3.Text = ""
        t2.Text = ""
        dtp2.Text = ""
        cb2.Text = ""
        cb4.Enabled = True
        cb4.Text = ""
        ComboBox1.Enabled = True
        't5.Text = ""
        't6.Text = ""
        't7.Text = ""
        't9.Text = ""
        't10.Text = ""
        't11.Text = ""
        't13.Text = ""

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        registro_clientes.Button4_Click(sender, e)
        cod_clie = registro_clientes.t1.Text
        t3.Text = cod_clie


    End Sub

    Public Sub llenar_combo1()
        Try
            sql = "select *from gestio_bdp"
            conexion.conectar()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            dt = New DataTable
            da.Fill(dt)
            cb2.DataSource = dt
            cb2.DisplayMember = "gestio_bdp"
            cb2.ValueMember = "gestion"
        Catch ex As Exception
            MessageBox.Show("No se pueder mostrar los datos", "Optima")
        End Try

    End Sub

    Public Sub buscar_copiar()
        Try
            sql = "select *from d_operacion_anx where id in (select max(id) from d_operacion_anx)"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                t2.Text = dr(0)
                t3.Text = dr(12)
                dtp2.Text = dr(9)
                cb2.Text = dr(10)
                t5.Text = dr(1)
                t6.Text = dr(2)
                t7.Text = dr(3)
                t9.Text = dr(4)
                t10.Text = dr(5)
                t11.Text = dr(6)
                t12.Text = dr(7)
                t13.Text = dr(8)
                t22.Text = dr(13)
                cb4.Text = dr(14)

            Else
                MessageBox.Show("Los Datos no Existen", "Optima")
            End If
            dr.Close()
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub
    Private Sub llenar_grid()
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
    Private Sub facturas()
        fac_operacion_anx.t2.Text = t2.Text
        fac_operacion_anx.t3.Text = t3.Text
        fac_operacion_anx.t4.Text = 150.0
        fac_operacion_anx.t5.Text = 0
        fac_operacion_anx.t6.Text = 85
        fac_operacion_anx.TextBox2.Text = 1
        fac_operacion_anx.t7.Text = 2
        fac_operacion_anx.t8.Text = 18
        fac_operacion_anx.dtp1.Text = dtp2.Text
        fac_operacion_anx.t23.Text = cb2.Text
        fac_operacion_anx.cb2.Text = cb4.Text
        nc = t3.Text
        sql = "exec ver_reg_cliente '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        Try
            If dr.Read Then
                nom = dr(2)
                appa = dr(3)
                apma = dr(4)
            Else
                MessageBox.Show("El Cliente no Existe", "Optima")
            End If
            dr.Close()
            conexion.conexion2.Close()
            fac_operacion_anx.T11.Text = nom & " " & appa & " " & apma
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try




    End Sub

    Private Sub filtro_text()
        Try
            nc = t14.Text
            sql = "select *from v_d_operacion_anx where [CODIGO DE ANEXO] like '" + nc + "%' or [CODIGO DE CLIENTE] like '" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion_anx where [CODIGO DE ANEXO] like '" + nc + "%' or [CODIGO DE CLIENTE] like '" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion_anx where [CODIGO DE ANEXO] like '" + nc + "%' or [CODIGO DE CLIENTE] like '" + nc + "%'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub

    Private Sub filtro_fecha()
        Try
            Dim fecha As Date
            Dim fech As String

            fecha = dtp3.Value
            fech = fecha.ToString("yyyyMMdd")
            nc = fech
            sql = "select *from v_d_operacion_anx where [FECHA DE RECEPCION] ='" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion_anx where [FECHA DE RECEPCION] ='" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion_anx where [FECHA DE RECEPCION] ='" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try
    End Sub
    Private Sub estadofil()
        Try
            Dim fech As String
            fech = estadof.Text
            nc = fech
            sql = "select *from v_d_operacion_anx where [ESTADO] ='" + nc + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_operacion_anx where [ESTADO] ='" + nc + "'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_operacion_anx where [ESTADO] ='" + nc + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub
End Class