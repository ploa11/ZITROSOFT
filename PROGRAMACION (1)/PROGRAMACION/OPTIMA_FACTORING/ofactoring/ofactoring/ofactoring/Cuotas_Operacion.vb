Imports System.Data.OleDb 'Importacion necesaria para trabajar con ficheros excel


Public Class Cuotas_Operacion


    Dim accion, gestion As String
    'variables publicas
    Public cod_clie, cod_comi_desem, cod_cuop, tip_op, tipodoc_clie, numdoc_clie, cali_finan, cod2 As String

    'variable de fecha
    Dim d1, m1, a1, d2, m2, a2, d3, m3, a3, dia1, mes1, dia2, mes2, dia3, mes3, f_ini, f_term, f_filt As String

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click



        Process.Start("Excel.exe", "E:\DatosPedro\Desktop\Formato_cro_anx3.xlsm")

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        nc = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_couta_ope '" + nc + "'"
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
            t8.Text = dr(7)
            t9.Text = dr(10)
            t10.Text = dr(9)
            t11.Text = dr(8)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cuotas.Show()
        'Dim fileDialog As New OpenFileDialog()
        'If fileDialog.ShowDialog() = DialogResult.OK Then
        ' Assign the file name to a string.
        'Dim filename As String = fileDialog.FileName
        ' Open the file and use the contents. 
        'System.Diagnostics.Process.Start(filename)
        'End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = InputBox("Ingrese el Codigo de Operacion")
        sql = "exec ver_couta_ope '" + nc + "'"
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
            t8.Text = dr(7)
            t9.Text = dr(10)
            t10.Text = dr(9)
            t11.Text = dr(8)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub Cuotas_Operacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        buscar()
        'llenar_grid()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub


    'variable locales
    Dim sql, nc As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Cuotas.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)


    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_couta_op"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_couta_op")
        dgv.DataSource = ds
        dgv.DataMember = "v_couta_op"
        conexion.conexion2.Close()
    End Sub

    Public Sub buscar()
        t2.Text = Anex_Cronog.t1.Text
        nc = t2.Text
        sql = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub
End Class