Imports System.Data.OleDb 'Importacion necesaria para trabajar con ficheros excel

Public Class Form_Import_Excel
    Dim sql, sql2, dia1, dia2, nc As String
    Dim res, z, x, h, y, j As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        selecciona_archivo()
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
End Class