Imports System.Data.OleDb 'Importacion necesaria para trabajar con ficheros excel
Public Class Cuotas
    Dim sql, sql2, dia1, dia2, nc As String
    Dim res, z, x, h, y, j As Integer
    Dim dinteres(366) As Decimal
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ':::Declaramos nuestra variable Sql que almacenara nuestra consuta

        sql = ""
        sql2 = ""
        ':::Usamos un ciclo For Each para recorrer nuestro DataGridView llamado DGTabla
        For Each Row As DataGridViewRow In dgv.Rows
            Dim nom_ape As String = Row.Cells("Nombre y Apellidos").Value
            Dim dni As String = Row.Cells("DNI").Value
            Dim especial As String = Row.Cells("Especialidad").Value
            Dim categoria As String = Row.Cells("Categoria").Value
            Dim apell As String = ""
            Dim sede As String = "CALLAO"
            Dim clave As String = ""
            Dim eqp As String = ""
            Dim tipo_colabo As String = "CAMPO"
            Dim obra As String = "MALL AVENTURA PLAZA"
            Dim fecha As String = DateTime.Today.ToString("yyyyMMdd")



            sql = "exec alta_usuario '" + nom_ape + "','" + apell + "','" + dni + "','" + sede + "','" + clave + "','" + eqp + "','" + tipo_colabo + "','" + obra + "','" + fecha + "','" + especial + "','" + categoria + "'"
            Exportar_SQLite(sql)
            'Anex_Cronog.dtp2.Value = f_final

        Next

        MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        lb1.Text = "Total registros exportados: " & dgv.RowCount
        ' Cuotas_Operacion.buscar()
        'Cuotas_Operacion.dias_int_cuota()
        'Anex_Cronog.Button2_Click(sender, e)
        'Anex_Cronog.Button7_Click(sender, e)
        Close()
    End Sub

    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim datTim1 As Date = #01/01/2018#
    Dim datTim2 As Date
    Dim datTim3 As Date
    Dim datTim4 As Date
    Private Sub Cuotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        Me.Text = "Importacion de Cuotas" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
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
            Dim Cmd As New OleDbCommand("Select * From [ENVIO$]")
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ':::Declaramos nuestra variable Sql que almacenara nuestra consuta

        sql = ""
        sql2 = ""
        ':::Usamos un ciclo For Each para recorrer nuestro DataGridView llamado DGTabla
        For Each Row As DataGridViewRow In dgv.Rows
            Dim mont_ini As String = Row.Cells("Monto Inicio").Value
            Dim amorti As String = Row.Cells("amortizacion").Value
            Dim mont_final As String = Row.Cells("Monto Final").Value
            Dim int As String = Row.Cells("Interes").Value
            Dim igv As String = Row.Cells("IGV Interes").Value
            Dim cuota As String = Row.Cells("Cuota").Value
            Dim F_inicio As Date = Row.Cells("inicio").Value
            Dim FechaExportar As String = F_inicio.ToString("yyyyMMdd")
            Dim f_final As Date = Row.Cells("Termino").Value
            Dim fecha_f_exportar As String = f_final.ToString("yyyyMMdd")
            Dim dias As String = Row.Cells("Dias").Value
            Dim cod_op As String = Anex_Cronog.t1.Text
            Dim esta As String = Anex_Cronog.cb4.Text
            Dim gest As String = Anex_Cronog.gestion

            sql = "exec alta_cuota_ope '" + cod_op + "','" + mont_ini + "','" + amorti + "','" + mont_final + "','" + int + "','" + igv + "','" + cuota + "','" + dias + "','" + fecha_f_exportar + "','" + FechaExportar + "','" + gest + "','" + esta + "'"
            Exportar_SQLite(sql)
            Anex_Cronog.dtp2.Value = f_final

        Next

        MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        lb1.Text = "Total registros exportados: " & dgv.RowCount
        Cuotas_Operacion.buscar()
        'Cuotas_Operacion.dias_int_cuota()
        Anex_Cronog.Button2_Click(sender, e)
        Anex_Cronog.Button7_Click(sender, e)
        Close()
    End Sub
    Sub Exportar_SQLite(ByVal Sql As String)
        Try
            conexion.conectar()
            com = New SqlClient.SqlCommand(Sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
        Catch ex As Exception
            MsgBox("No se pueden guardar los registro por: " & ex.Message, MsgBoxStyle.Critical, ":::Aprendamos de Programación:::")
        End Try


    End Sub
    'Sub Exportar_SQLite2(ByVal Sql2 As String)
    'Try
    'conexion.conectarfondo()
    ' com = New SqlClient.SqlCommand(Sql2, conexion.conexion2)
    ' res = com.ExecuteNonQuery
    'conexion.conexion2.Close()
    'Catch ex As Exception
    ' MsgBox("No se pueden guardar los registro por: " & ex.Message, MsgBoxStyle.Critical, ":::Aprendamos de Programación:::")
    'End Try


    'End Sub

End Class