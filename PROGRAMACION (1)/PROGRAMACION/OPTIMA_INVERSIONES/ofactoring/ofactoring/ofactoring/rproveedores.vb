Public Class rproveedores

    ' Public conexion As SqlClient.SqlConnection
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim accion As String, nc As String, sql As String
    Dim np, tdinden, ndociden, direc, dist, prov, depar As String

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim borra As Integer
        nc = t3.Text
        borra = MessageBox.Show(" ¿Para eliminar un Proveedor debe buscarlo primero,  ¿Ya Busco al Proveedor? ", "PROVEEDORES", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        'res = MessageBox.Show("¿Desea Borrar el Proveedor", "PROVEEDORES", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If borra = vbNo Then
            Button3.PerformClick()
            nc = t3.Text
        End If

        res = MessageBox.Show("¿Desea Borrar el Proveedor", "PROVEEDORES", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_proveedor '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        For F = 0 To Me.Controls.Count - 1
            If TypeOf Me.Controls(F) Is TextBox Then
                Me.Controls(F).Text = ""
            End If
            If TypeOf Me.Controls(F) Is ComboBox Then
                Me.Controls(F).Text = ""
            End If

        Next F
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

    Private Sub rproveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Registro de Proveedores" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        dgv.AllowUserToAddRows = False
        Dim F As Integer
        llenar_combo1()
        llenar_combo2()
        llenar_combo3()
        llenar_combo4()
        llenar_grid()
        For F = 0 To Me.Controls.Count - 1
            If TypeOf Me.Controls(F) Is TextBox Then
                Me.Controls(F).Text = ""
            End If
            If TypeOf Me.Controls(F) Is ComboBox Then
                Me.Controls(F).Text = ""
            End If

        Next F

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        Dim F As Integer
        For F = 0 To Me.Controls.Count - 1
            If TypeOf Me.Controls(F) Is TextBox Then
                Me.Controls(F).Enabled = True
            End If
            If TypeOf Me.Controls(F) Is ComboBox Then
                Me.Controls(F).Enabled = True
            End If
            If TypeOf Me.Controls(F) Is TextBox Then
                Me.Controls(F).Text = ""
            End If
        Next F

        t1.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = InputBox("Ingrese el DNI / RUC / CODIGO del PROVEEDOR")
        sql = "exec ver_proveedores '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            cb1.Text = dr(2)
            t3.Text = dr(3)
            t4.Text = dr(4)
            cb2.Text = dr(5)
            cb3.Text = dr(6)
            cb4.Text = dr(7)

        Else
            MessageBox.Show("El PROVEEDOR no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim F As Integer
        nc = t1.Text
        np = UCase(t2.Text)
        tdinden = UCase(cb1.Text)
        ndociden = UCase(t3.Text)
        direc = UCase(t4.Text)
        dist = UCase(cb2.Text)
        prov = UCase(cb3.Text)
        depar = UCase(cb4.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_proveedores'" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El Proveedor ya existe", "proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion.Close()
            Else
                sql = "exec alta_provee '" + np + "','" + tdinden + "','" + ndociden + "','" + direc + "','" + dist + "','" + prov + "','" + depar + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_proveed'" + nc + "','" + np + "','" + tdinden + "','" + ndociden + "','" + direc + "','" + dist + "','" + prov + "','" + depar + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()

        For F = 0 To Me.Controls.Count - 1
            If TypeOf Me.Controls(F) Is TextBox Then
                Me.Controls(F).Enabled = False
            End If
            If TypeOf Me.Controls(F) Is ComboBox Then
                Me.Controls(F).Enabled = False
            End If
        Next F
    End Sub

    Dim res As Integer
    Dim cdcli, cdcu, bn, ncu As String, tc As String, td As String, nd As String, ce As String
    Dim pass As String, telef As String, anx As String, nom As String, app As String, apm As String
    Dim cusu As String, h As DateTime, d As DateTime, mc As String, cn As String, comen As String, dni, dnru As String, sede As String, clv As String
    'Public Sub conectar()
    'conexion = New SqlClient.SqlConnection
    ' conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    'conexion.ConnectionString = ("Data source = NLIM010PDOM; initial catalog = reghoras; user id = sa; password = 0pt1m4$2015")
    'conexion.Open()
    'End Sub

    Public Sub llenar_grid()
        Dim cu = t1.Text
        sql = "select *from proveedores" '+ cu + "'"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "proveedores") ' + cu + "'")
        dgv.DataSource = ds
        dgv.DataMember = "proveedores" '+ cu + "'"
        conexion.conexion.Close()
    End Sub
    Private Sub llenar_combo1()
        sql = "select *from tipdoc"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "tipdoc"
        cb1.ValueMember = "detalle"
    End Sub
    Private Sub llenar_combo2()
        sql = "select *from distrito"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "distrito"
        cb2.ValueMember = "distrito"
    End Sub
    Private Sub llenar_combo3()
        sql = "select *from provincia"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb3.DataSource = dt
        cb3.DisplayMember = "provincia"
        cb3.ValueMember = "provincia"
    End Sub
    Private Sub llenar_combo4()
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        Dim F As Integer
        For F = 0 To Me.Controls.Count - 1
            If TypeOf Me.Controls(F) Is TextBox Then
                Me.Controls(F).Enabled = True
            End If
            If TypeOf Me.Controls(F) Is ComboBox Then
                Me.Controls(F).Enabled = True
            End If
        Next F
        t1.Enabled = False
    End Sub
End Class