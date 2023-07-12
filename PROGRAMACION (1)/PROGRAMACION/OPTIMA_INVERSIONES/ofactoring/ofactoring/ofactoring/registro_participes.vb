Public Class registro_participes
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
    'variable publicas
    Public c_parti, nom_parti, apellidop, apellidom, tipo_docu, numero_doc As String

    '---------------------------------------------------------------
    'variable de busqueda bd genearl y bd fondo
    Dim nc, sql As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    '---------------------------------------------------------------
    'variables de conexion a sql
    'Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    '----------------------------------------------------------------
    'variables de alta, edicion bsuqueda y elminacion de registro
    Dim accion As String

    'variables de fecha
    Dim d1, dia1, mes1, dia2, mes2, d2, m1, m2, a1, a2, f_ini, f_sali As String

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Me.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
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

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        nc = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_da_participe '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(1)
            t2.Text = dr(2)
            t3.Text = dr(3)
            t4.Text = dr(4)
            t5.Text = dr(5)
            t6.Text = dr(6)
            t7.Text = dr(7)
            t8.Text = dr(0)
            t9.Text = dr(8)
            dtp.Text = dr(9)
            dtp2.Text = dr(10)
            c_parti = dr(0)
            nom_parti = dr(2)
            apellidop = dr(3)
            apellidom = dr(4)
            tipo_docu = dr(5)
            numero_doc = dr(6)
        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        nc = InputBox("Ingrese Apellido a Buscar")
        sql = "select *from v_da_participe where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTO]='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_da_participe where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTO]='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_da_participe where [APELLIDO PATERNO]='" + nc + "'or [NUMERO DE DOCUMENTO]='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Public Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = InputBox("Ingrese el Codigo, Nombre o Documento de identidad del Participe")
        sql = "exec ver_da_participe '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(1)
            t2.Text = dr(2)
            t3.Text = dr(3)
            t4.Text = dr(4)
            t5.Text = dr(5)
            t6.Text = dr(6)
            t7.Text = dr(7)
            t8.Text = dr(0)
            t9.Text = dr(8)
            dtp.Text = dr(9)
            dtp2.Text = dr(10)
            c_parti = dr(0)
            nom_parti = dr(2)
            apellidop = dr(3)
            apellidom = dr(4)
            tipo_docu = dr(5)
            numero_doc = dr(6)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        nc = t8.Text
        res = MessageBox.Show("¿Desea borrar al Participe?", "Registro de Participes", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_participe '" + nc + "'"
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
        t8.Enabled = False
        dtp.Enabled = False
        dtp2.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""
        t9.Text = ""
        dtp.Text = ""
        dtp2.Text = ""

    End Sub

    'variables guardar datos
    Dim codbdp, nom, appa, apma, tdoc, ndoc, direcc, correo As String



    Private Sub registro_particpes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Registro de Participes" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        dgv.AllowUserToAddRows = False
        llenar_grid()

    End Sub

    Private Sub t5_TextChanged(sender As Object, e As EventArgs) Handles t5.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "guardar"
        t1.Enabled = True
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t9.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        dtp.Enabled = True
        dtp2.Enabled = True
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        t7.Text = ""
        t8.Text = ""
        t9.Text = ""
        dtp.Text = ""
        dtp2.Text = Datos_Generales_del_Fondo.t15.Text
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        nc = InputBox("Ingrese el Documento de Identidad o Nombre ")
        sql = "exec ver_clientes '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t5.Text = dr(2)
            t6.Text = dr(3)
            t2.Text = dr(8)
            t3.Text = dr(9)
            t4.Text = dr(10)
            t7.Text = dr(11)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        clientes.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        registro_de_cuentas_bancos.Show()
        registro_de_cuentas_bancos.t2.Text = t2.Text & " " & t3.Text & " " & t4.Text
        registro_de_cuentas_bancos.cod_parti = t8.Text
        registro_de_cuentas_bancos.nom_part = t2.Text
        registro_de_cuentas_bancos.t2.Enabled = True
        registro_de_cuentas_bancos.t3.Enabled = False
        registro_de_cuentas_bancos.t4.Enabled = False
        registro_de_cuentas_bancos.t5.Enabled = False
        registro_de_cuentas_bancos.cb1.Enabled = True
        registro_de_cuentas_bancos.t6.Enabled = True
        registro_de_cuentas_bancos.t7.Enabled = True
        registro_de_cuentas_bancos.cb2.Enabled = True
        registro_de_cuentas_bancos.cb3.Enabled = True
        registro_de_cuentas_bancos.Button4.Enabled = True
        registro_de_cuentas_bancos.Button5.Enabled = True


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'guardar fechas sql
        dia1 = dtp.Value.Date
        mes1 = dtp.Value.Date
        a1 = dtp.Value.Year
        dia2 = dtp2.Value.Date
        mes2 = dtp2.Value.Date
        a2 = dtp2.Value.Year
        d1 = dia1.Substring(0, dia1.IndexOf("/"))
        m1 = mes1.Substring(3, mes1.IndexOf("/"))
        d2 = dia2.Substring(0, dia2.IndexOf("/"))
        m2 = mes2.Substring(3, mes2.IndexOf("/"))
        f_ini = a1 + m1 + d1 'concatenar fecha inicia
        f_sali = a2 + m2 + d2 'concatenar fecha salida
        'fin de fechas sql
        Button1.Enabled = True
        '---------------------------------------------------------
        '-registro de los datos
        nc = UCase(t8.Text)
        codbdp = UCase(t1.Text)
        nom = UCase(t2.Text)
        appa = UCase(t3.Text)
        apma = UCase(t4.Text)
        tdoc = UCase(t5.Text)
        ndoc = UCase(t6.Text)
        direcc = UCase(t7.Text)
        correo = UCase(t9.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_da_participe'" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "Datos Participes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_d_participe '" + codbdp + "','" + nom + "','" + appa + "','" + apma + "','" + tdoc + "','" + ndoc + "','" + direcc + "','" + correo + "','" + f_ini + "','" + f_sali + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_d_participe'" + nc + "','" + codbdp + "','" + nom + "','" + appa + "','" + apma + "','" + tdoc + "','" + ndoc + "','" + direcc + "','" + correo + "','" + f_ini + "','" + f_sali + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
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
        t8.Enabled = False
        dtp.Enabled = False
        dtp2.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False

        '-------------------------------------------------------
        'llenar codigido de participe
        nc = t6.Text
        sql = "exec ver_da_participe '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(1)
            t2.Text = dr(2)
            t3.Text = dr(3)
            t4.Text = dr(4)
            t5.Text = dr(5)
            t6.Text = dr(6)
            t7.Text = dr(7)
            t8.Text = dr(0)
            t9.Text = dr(8)
            dtp.Text = dr(9)
            dtp2.Text = dr(10)
            c_parti = dr(0)
            nom_parti = dr(2)
            apellidop = dr(3)
            apellidom = dr(4)
            tipo_docu = dr(5)
            numero_doc = dr(6)
        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "editar"
        t1.Enabled = True
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t9.Enabled = True
        dtp.Enabled = True
        dtp2.Enabled = True
        Button1.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        clientes.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        nc = InputBox("Ingrese el Documento de Indetidad o Nombre ")
        sql = "exec ver_clientes '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t5.Text = dr(2)
            t6.Text = dr(3)
            t2.Text = dr(8)
            t3.Text = dr(9)
            t4.Text = dr(10)
            t7.Text = dr(11)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_da_participe"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_da_participe")
        dgv.DataSource = ds
        dgv.DataMember = "v_da_participe"
        conexion.conexion2.Close()
    End Sub
End Class