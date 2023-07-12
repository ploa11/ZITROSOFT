﻿Public Class gestion
    'Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String
    Dim res As Integer, tc As String, td As String, nd As String, ce As String
    Dim usql, clasql, nomsql, nfon, str, str2, str3, gest As String

    Private Sub gestion_bdp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        cfondo.llenar_combo4()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar Gestion?", "Gestion BDP", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_gestionbdp '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        cfondo.llenar_combo4()
        t1.Enabled = False
        t2.Enabled = False

        t1.Text = ""
        t2.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        nc = t1.Text
        gest = UCase(t2.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_gestionbdp'" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El codigo gestion ya existe", "Gestion BDP", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.Close()
            Else
                sql = "exec alta_gestionbdp '" + gest + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_gestionbdp'" + nc + "','" + gest + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        cfondo.llenar_combo4()
        t1.Enabled = False
        t2.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nc = InputBox("Ingrese el Codigo de Gestion a buscar")
        sql = "exec ver_gestionbdp '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
        Else
            MessageBox.Show("La gestion no Existe")
        End If
        dr.Close()
        conexion.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t1.Enabled = False
        t2.Enabled = True
    End Sub

    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader, dr2 As SqlClient.SqlDataAdapter
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Public Sub llenar_grid()
        sql = "select * from v_gestio_bdp"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_gestio_bdp")
        dgv.DataSource = ds
        dgv.DataMember = "v_gestio_bdp"
        conexion.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t1.Enabled = False
        t1.Text = ""
        t2.Enabled = True
        t2.Text = ""
    End Sub
End Class