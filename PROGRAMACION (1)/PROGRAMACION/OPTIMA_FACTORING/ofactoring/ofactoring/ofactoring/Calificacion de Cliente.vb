Imports System.IO


Public Class Calificacion_de_Cliente

    'variables locales
    Dim accion As String

    'variable para la creacion de carpetas
    Dim n_carp As String

    'variable locales
    Dim sql, nc As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Calificacion_de_Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        registro_clientes.Button4_Click(sender, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        cb3.Enabled = True
        Button6.Enabled = True
        Button4.Enabled = True

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        n_carp = Mid(UCase(t3.Text), 1, 2) + Mid(UCase(t4.Text), 1, 2) + Mid(UCase(t5.Text), 1, 2)
        Directory.CreateDirectory("E:\clientes\" + n_carp)
        t6.Text = "E:\clientes\" + n_carp
        Button8.Enabled = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        OpenFileDialog1.Title = "Selecciones los Documentos del Cliente"
        OpenFileDialog1.Filter = "JPG|*.jpg; *.jpeg|PNG|*.png|GIF|*.gif|PDF|*.pdf|DOC|*.doc|XLS|*.xls|PPT|*.ppt|DOCX|*.docx|XLSX|*.xlsx|XLSM|*.xlsm|PPTX|*.pptx"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim extension As String = Path.GetExtension(OpenFileDialog1.FileName)
            If extension = ".jpg" Or extension = ".png" Or extension = ".gif" Or extension = ".pdf" Or extension = ".doc" Or extension = ".xls" Or extension = ".ppt" Or extension = ".docx" Or extension = ".xlsx" Or extension = ".xlsm" Or extension = ".pptx" Then
                Dim nombreoriginal As String = Path.GetFileName(OpenFileDialog1.FileName)
                Dim fecha As String = Date.Today()
                fecha = fecha.Replace("/", "")
                Dim aleatorio As Integer = CInt(Int((999999 * Rnd()) + 1))
                Dim nombrefinal As String = fecha & "_" & aleatorio & "_" & nombreoriginal
                File.Copy(OpenFileDialog1.FileName, "e:\clientes\" & n_carp & "\" & nombrefinal)
            Else
                MsgBox("El Formato de archivo no es el correcto")
            End If

        Else
            MessageBox.Show("No Seleccionaste Ningun Archivo")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_reg_califcliente'" + t1.Text + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo de  Calificacion de Cliente ya existe", "cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_reg_caliclie '" + t2.Text + "','" + cb1.Text + "','" + cb2.Text + "','" + cb3.Text + "','" + t6.Text + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")


            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_reg_califcliente'" + nc + t2.Text + "','" + cb1.Text + "','" + cb2.Text + "','" + cb3.Text + "','" + t6.Text + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")



        Else
            MessageBox.Show("El Cliente no Existe")
        End If

        dr.Close()
        conexion.conexion2.Close()
        llenar_grid()
        If cb2.Text = "Aprobado" Then
            Button7.Enabled = True
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar la Calificacion del Cliente", "Calificacion de Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_reg_califcliente '" + nc + "'"
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
        cb1.Enabled = False
        cb2.Enabled = False
        cb3.Enabled = False
        t1.Text = ""
        t2.Text = ""
        t3.Text = ""
        t4.Text = ""
        t5.Text = ""
        t6.Text = ""
        cb1.Text = ""
        cb2.Text = ""
        cb3.Text = ""


    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        registro_de_cuentas_bancos.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        cb3.Enabled = True
        Button8.Enabled = True
        Button4.Enabled = True
        If cb2.Text = "Aprobado" Then
            Button7.Enabled = True
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button2.Enabled = True
        Button5.Enabled = True
        nc = InputBox("Ingrese el Codigo de Calificacion o de Cliente", "Optima Inversiones")
        sql = "exec ver_reg_califcliente '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(Sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            cb1.Text = dr(2)
            cb2.Text = dr(3)
            cb3.Text = dr(4)
            t6.Text = dr(5)

        Else
            MessageBox.Show("El Cliente no Existe")
        End If

        dr.Close()
        conexion.conexion2.Close()

    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_reg_calif_cliente"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_reg_calif_cliente")
        dgv.DataSource = ds
        dgv.DataMember = "v_reg_calif_cliente"
        conexion.conexion2.Close()
    End Sub
End Class