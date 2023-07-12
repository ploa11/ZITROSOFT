Imports System.Data.OleDb 'Importacion necesaria para trabajar con ficheros excel

Public Class Form_Import_Excel
    Dim sql, sql2, dia1, dia2, nc, codigo As String
    Dim cod As Double
    Dim res, z, x, h, y, j As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        selecciona_archivo()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            For Each Row As DataGridViewRow In dgv.Rows
                buscar_copiar()
                Dim TIENDA As String = Row.Cells("TIENDA").Value
                Dim UBICA1 As String = Row.Cells("UBICACION1").Value
                Dim UBICA2 As String = Row.Cells("UBICACION2").Value
                Dim UBICA3 As String = Row.Cells("UBICACION3").Value
                Dim DIRECC As String = Row.Cells("DIRECCION").Value
                'Dim sede As String = "CALLAO"
                'Dim clave As String = ""
                'Dim eqp As String = ""
                'Dim tipo_colabo As String = "CAMPO"
                'Dim obra As String = "MALL AVENTURA PLAZA"
                'Dim fecha As String = DateTime.Today.ToString("yyyyMMdd")



                sql = "INSERT INTO T_LOCAL (COD_LOCAL,TIENDA,UBICACION1,UBICACION2,UBICACION3,DIRECCION) VALUES('" & codigo & "','" & TIENDA & "','" & UBICA1 & "','" & UBICA2 & "','" & UBICA3 & "','" & DIRECC & "')"
                Exportar_SQLite(sql)
                'Anex_Cronog.dtp2.Value = f_final

            Next

            MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: ZITRO SOLUCIONES :::")
            Label1.Text = "Total registros exportados: " & dgv.RowCount
            ' Cuotas_Operacion.buscar()
            'Cuotas_Operacion.dias_int_cuota()
            'Anex_Cronog.Button2_Click(sender, e)
            'Anex_Cronog.Button7_Click(sender, e)
            Close()
        Catch ex As Exception
            MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: ZITRO SOLUCIONES :::")
        End Try


    End Sub

    Dim dinteres(366) As Decimal
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub Form_Import_Excel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
    End Sub

    Private Sub selecciona_archivo()
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xlsm;*.xlsx)|*.xlsm;*xlsx|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = DialogResult.OK Then
                stRuta = .FileName
            End If
        End With
        Try
            Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (stRuta & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";"))) 'este es el codigo que funciona para office 2007 y 2010 
            'Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & ("E:\orca\Formato_cro_anx3.xlsm" & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";"))) 'este es el codigo que funciona para office 2007 y 2010 
            Dim cnConex As New OleDbConnection(stConexion)
            Dim Cmd As New OleDbCommand("Select * From [Hoja1$]")
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable
            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)
            Me.dgv.Columns.Clear()
            Me.dgv.DataSource = Dt
            cnConex.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub pasar_listvi()
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xlsm;*.xlsx)|*.xlsm;*xlsx|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = DialogResult.OK Then
                stRuta = .FileName
            End If
        End With
        Try
            Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (stRuta & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";"))) 'este es el codigo que funciona para office 2007 y 2010 
            'Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & ("E:\orca\Formato_cro_anx3.xlsm" & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";"))) 'este es el codigo que funciona para office 2007 y 2010 
            Dim cnConex As New OleDbConnection(stConexion)
            Dim Cmd As New OleDbCommand("Select * From [Hoja1$]")
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable
            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)
            Me.dgv.Columns.Clear()
            Me.dgv.DataSource = Dt
            cnConex.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Sub Exportar_SQLite(ByVal Sql As String)
        Try
            Form_Reg_SRV_SQL.conectar()
            com = New SqlClient.SqlCommand(Sql, Form_Reg_SRV_SQL.conexion)
            res = com.ExecuteNonQuery
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MsgBox("No se pueden guardar los registro por: " & ex.Message, MsgBoxStyle.Critical, ":::Aprendamos de Programación:::")
        End Try


    End Sub
    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "TDA"
        'Dim cod, serie As String
        sql = "select *from T_local where id in (select max(id) from T_local)"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            cod = Microsoft.VisualBasic.Right(dr(0), 3)
            'TextBox1.Text = dr(0)
            'dtp1.Value = dr(1)
            'cb1.Text = dr(2)
            't1.Text = dr(4)
            't2.Text = dr(7)
            't4.Text = dr(8)
            't5.Text = dr(9)
        Else
            ' MessageBox.Show("Se generara Codigo", "ZITRO")
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        If cod = 0 Then
            cod = 0
            aum_cod = cod.ToString("00000000")
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            CODIGO = dat & (cod + 1).ToString("00000000")
        Else
            aum_cod = Microsoft.VisualBasic.Right(cod, 8)
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            CODIGO = dat & (cod + 1).ToString("00000000")
            't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
        End If


    End Sub

End Class