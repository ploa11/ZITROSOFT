'Imports System.IO
'Imports Microsoft.Office.Interop.Excel
'Imports Finisar.SQLite
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports Finisar.SQLite
Imports System.Runtime.InteropServices.ComTypes
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
'Imports System.Windows.Controls
'Imports System.Windows.Controls
'Imports System.Windows.Controls
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement


Public Class Form_Prog_Pagos
    Dim res, o As Integer
    Dim cod_p_rq, cod_p_rq2 As String
    Dim cod_fac, num_fac As String
    Public nom, nom_fondo, ruc_fondo, ruc, direc, dis_dep_prov, debe, haber, fecha, cod_crono, acciones, glosa, analitica, cuenta, nom_cuenta, moneda, obs, t_venta, f_pago As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GroupBox2.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Label1.Visible = False
        Form1.Label2.Visible = True
        Form1.llenar_grid_SISTEMAS()
        Form1.pase1 = "OC_PAGO"
        Form1.RQ_SCC = "BUSCAR OC"
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "guardar"
        FACT_OC()
        buscar_oc()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Label1.Visible = False
        Form1.Label2.Visible = True
        Form1.LLENAR_FAC_OC()
        Form1.pase1 = "FACTURA"
        Form1.RQ_SCC = "BUSCAR FAC"
        Form1.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Public comi_des, igv_comides, sub_total, igv_total, total, porc_igv As Decimal

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox18_TextChanged(sender As Object, e As EventArgs) Handles TextBox18.TextChanged

    End Sub

    Private Sub TextBox19_TextChanged(sender As Object, e As EventArgs) Handles TextBox19.TextChanged

    End Sub

    Dim compara As String
    Dim nc, UND As String
    Dim rest, rest_util As String
    Public porc_util, utilidad, util_list As Decimal
    'variables publicas
    Public pase1, pase2, codigo, pase3, pase4, cod_sbc As String
    Dim n_carp As String
    Dim j As Integer
    Dim xlibro As Microsoft.Office.Interop.Excel.Application
    Dim strRutaExcel As String
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable

    Public cod As Double
    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer
    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader

    Private Sub Form_Prog_Pagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
    End Sub

    Private Sub FACT_OC()
        Try
            If accion = "guardar" Then

                sql = "select *from T_FAC_OC where  COD='" & TextBox17.Text & "'"
                Form_Reg_SRV_SQL.conectar()
                com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                dr = com.ExecuteReader

                If dr.Read Then
                    'cod = dr(0)
                    MessageBox.Show("Los Datos ya Existen", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                Else
                    buscar_copiar()
                    sql = "INSERT INTO T_FAC_OC  (COD,COD_OC,N_FAC,FEC_FAC,FEC_PAGO,MONT_FACT,MONT_PAGO,POR_PA_OC,MONEDA,ESTADO,FEC_ING)   VALUES('" & codigo & "','" & TextBox1.Text & "','" & TextBox20.Text & "','" & DateTimePicker3.Value.ToString("yyyyMMdd") & "','" & DateTimePicker4.Value.ToString("yyyyMMdd") & "','" & TextBox19.Text & "','" & TextBox18.Text & "','" & TextBox7.Text & "','" & TextBox21.Text & "','" & ComboBox1.Text & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "')"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    res = com.ExecuteNonQuery
                    Form_Reg_SRV_SQL.conexion.Close()
                    MessageBox.Show(" FACTURA PROGRAMADA ", " ZITRO ")
                End If


                'buscar_copiar()
                'llenar_grid()
                'facturas()
                'fac_operacion_anx.Show()
            End If
        Catch ex As Exception
        End Try
        'Next
    End Sub
    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "FACOC"
        'Dim cod, serie As String
        sql = "select *from T_FAC_OC where id in (select max(id) from T_FAC_OC)"
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
            MessageBox.Show("Se generara Codigo", "ZITRO")
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        If cod = 0 Then
            cod = 0
            aum_cod = cod.ToString("00000000")
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            codigo = dat & (cod + 1).ToString("00000000")
        Else
            aum_cod = Microsoft.VisualBasic.Right(cod, 8)
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            codigo = dat & (cod + 1).ToString("00000000")
            't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
        End If


    End Sub
    Private Sub buscar_oc()
        'Dim aum_cod As String
        ' Dim dat As String = "RQ"
        'Dim cod, serie As String
        sql = "Select *from T_FAC_OC where id In (Select max(id) from T_FAC_OC)"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            TextBox17.Text = dr(0)
            'DateTimePicker1.Value = dr(1)
            TextBox20.Text = dr(2)
            DateTimePicker3.Value = dr(3)
            DateTimePicker4.Value = dr(4)
            TextBox19.Text = dr(5)
            TextBox18.Text = dr(6)
            TextBox7.Text = dr(7)
            TextBox21.Text = dr(8)
            ComboBox1.Text = dr(10)
            DateTimePicker1.Value = dr(11)

            'ComboBox4.Text = dr(13)
            '  Label18.Text = dr(14)
            ' Label19.Text = dr(15)
            ' Label20.Text = dr(16)
            ' ComboBox1.Text = dr(17)
            ' ComboBox5.Text = dr(18)
            ' ComboBox6.Text = dr(19)
            ' DateTimePicker2.Value = dr(21)
            ' DateTimePicker3.Value = dr(22)
            '   DateTimePicker4.Value = dr(23)

            'TextBox1.Text = dr(0)
            'dtp1.Value = dr(1)
            'cb1.Text = dr(2)
            't1.Text = dr(4)
            't2.Text = dr(7)
            't4.Text = dr(8)
            't5.Text = dr(9)
        Else
            MessageBox.Show("Error EN MOSTRAR DATOS", "ZITRO")
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        'If cod = 0 Then
        'cod = 0
        'aum_cod = cod.ToString("00000000")
        ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
        'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
        'serie = Microsoft.VisualBasic.Left(num_fac, 4)
        ' codigo = dat & (cod + 1).ToString("00000000")
        ' Else
        'aum_cod = Microsoft.VisualBasic.Right(cod, 8)
        ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
        'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
        'serie = Microsoft.VisualBasic.Left(num_fac, 4)
        'codigo = dat & (cod + 1).ToString("00000000")
        't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
        'End If


    End Sub
    Private Sub actualizar_ESTADO()
        'sql = "INSERT INTO T_COTI_ITEMS (COD,COD_COTI,CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
        ' sql = "UPDATE  T_COTI_ITEMS SET(CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
        sql = "UPDATE T_FAC_OC SET ESTADO='" & UCase(ComboBox1.Text) & "', WHERE COD='" & TextBox17.Text & "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        res = com.ExecuteNonQuery
        Form_Reg_SRV_SQL.conexion.Close()
        ' Reg_SRV_SQL.conexion.Close()
        'Dim guardar As New MySQLDriverCS.MySQLCommand
        'guardar.Connection = cnn
        'guardar.CommandType = CommandType.StoredProcedure
        'guardar.CommandText = "UPDATE detalle_menu SET cod_comp='" & comp & "',ingredientes = '" & ingr & "', medida = '" & medi & "',cantidad='" & cant & "',precio = '" & prec & "' WHERE cod_comp='" & comp & "'"
        ' guardar.ExecuteNonQuery()

        ' MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")

        'Else
        'MsgBox("DATOS NO ACTUALIZADOS", MsgBoxStyle.Information, "ACTUALIZACION")
        'End If
    End Sub

    Private Sub ACTUALIZAR_DATOS()
        'sql = "INSERT INTO T_COTI_ITEMS (COD,COD_COTI,CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
        ' sql = "UPDATE  T_COTI_ITEMS SET(CANTIDAD,DESCRIP,PREC_UNIT,PREC_TOTAL,IGV) VALUES('" & cod & "','" & TextBox23.Text & "','" & CANTIDAD & "','" & descrip & "','" & prec_unit & "','" & prec_total & "','" & igv & "')"
        sql = "UPDATE T_FAC_OC SET ESTADO='" & UCase(ComboBox1.Text) & "', WHERE COD='" & TextBox17.Text & "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        res = com.ExecuteNonQuery
        Form_Reg_SRV_SQL.conexion.Close()
        ' Reg_SRV_SQL.conexion.Close()
        'Dim guardar As New MySQLDriverCS.MySQLCommand
        'guardar.Connection = cnn
        'guardar.CommandType = CommandType.StoredProcedure
        'guardar.CommandText = "UPDATE detalle_menu SET cod_comp='" & comp & "',ingredientes = '" & ingr & "', medida = '" & medi & "',cantidad='" & cant & "',precio = '" & prec & "' WHERE cod_comp='" & comp & "'"
        ' guardar.ExecuteNonQuery()

        ' MsgBox("DATOS ACTUALIZADOS CORRECTAMENTE", MsgBoxStyle.Information, "ACTUALIZACION")

        'Else
        'MsgBox("DATOS NO ACTUALIZADOS", MsgBoxStyle.Information, "ACTUALIZACION")
        'End If
    End Sub

    Private Sub TextBox19_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox19.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
        Try
            If Len(cadena) = 0 Then
                filtro += "-"
            End If
            If Len(cadena) > 0 Then
                filtro += "."
            End If


            For Each caracter In filtro
                If e.KeyChar = caracter Then
                    e.Handled = False

                    Exit For
                Else
                    e.Handled = True
                    'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
                End If
            Next

            If e.KeyChar = "0" And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""
            ElseIf e.KeyChar <> "0" And e.KeyChar <> "." And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""


            End If





            If Char.IsControl(e.KeyChar) Then
                e.Handled = False

            End If


            If e.KeyChar = "." And Not cadena.IndexOf(".") Then
                e.Handled = True
                'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox18_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox18.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
        Try
            If Len(cadena) = 0 Then
                filtro += "-"
            End If
            If Len(cadena) > 0 Then
                filtro += "."
            End If


            For Each caracter In filtro
                If e.KeyChar = caracter Then
                    e.Handled = False

                    Exit For
                Else
                    e.Handled = True
                    'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
                End If
            Next

            If e.KeyChar = "0" And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""
            ElseIf e.KeyChar <> "0" And e.KeyChar <> "." And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""


            End If





            If Char.IsControl(e.KeyChar) Then
                e.Handled = False

            End If


            If e.KeyChar = "." And Not cadena.IndexOf(".") Then
                e.Handled = True
                'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        Dim cadena As String = sender.Text
        Dim filtro As String = "1234567890"
        ' End If
        'Call condicion(TextBox22, e)
        Try
            If Len(cadena) = 0 Then
                filtro += "-"
            End If
            If Len(cadena) > 0 Then
                filtro += "."
            End If


            For Each caracter In filtro
                If e.KeyChar = caracter Then
                    e.Handled = False

                    Exit For
                Else
                    e.Handled = True
                    'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
                End If
            Next

            If e.KeyChar = "0" And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""
            ElseIf e.KeyChar <> "0" And e.KeyChar <> "." And Mid(cadena, 1, 1) = "0" And Len(cadena) = 1 Then
                sender.Text = ""


            End If





            If Char.IsControl(e.KeyChar) Then
                e.Handled = False

            End If


            If e.KeyChar = "." And Not cadena.IndexOf(".") Then
                e.Handled = True
                'MsgBox("Solo Puede digitar numeros", MsgBoxStyle.Information, "ZITRO")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class