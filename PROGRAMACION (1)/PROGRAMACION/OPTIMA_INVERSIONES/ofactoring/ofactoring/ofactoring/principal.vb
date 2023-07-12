﻿Public Class principal
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
    'Public conexion As SqlClient.SqlConnection
    Dim accion As String, nc As String, sql As String, sql2 As String, nom As String, clv As String, nv As String, area As String
    Dim res As Integer, det As String, sa As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader, dr2 As SqlClient.SqlDataAdapter
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    'Public Sub conectar()
    ' conexion = New SqlClient.SqlConnection
    ' conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    'conexion.Open()
    ' End Sub

    Private Sub principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlBox = False

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            nom = usu.Text
            sql = "exec login2 '" + nom + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                nc = dr(0)
                nom = dr(1)
                clv = dr(2)
                area = dr(3)
                If clave.Text = clv Then
                    MessageBox.Show("Bienvenido al SISTEMA", "Optima")
                    opciones.Show()
                    Hide()
                Else
                    MessageBox.Show("Usuario Correcto, Clave incorrecta", "Optima")
                    usu.Enabled = False
                End If
            Else
                MessageBox.Show("El Usuario no Existe", "Optima")
            End If
            dr.Close()
            conexion.conexion.Close()
        Catch ex As Exception
            MsgBox("ERROR AL CONECTAR CON BD DE USUARIOS")
        End Try


        'nom = usu.Text
        'clv = clave.Text
        'sql = "exec login2 '" + nom + "'"
        'conectar()
        'com = New SqlClient.SqlCommand(sql, conexion)
        'dr = com.ExecuteReader
        'If dr.Read Then
        'MessageBox.Show("Usuario Correcto")
        'dr.Close()
        'conexion.Close()
        'clv = InputBox("Igrese su clave de sistema")
        'sql = "exec login '" + clv + "'"
        'conectar()
        'com = New SqlClient.SqlCommand(sql, conexion)
        'dr = com.ExecuteReader
        'If dr.Read Then
        'MessageBox.Show("su clave es correcta Bienvenido al sistema")
        'opciones.Show()
        'Hide()
        'Else
        'MessageBox.Show("clave no existe")
        'End If


        'Else
        'MessageBox.Show("El Usuario no Existe")
        'End If
        'dr.Close()
        'conexion.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim men As MsgBoxResult
        'Dim men2 = "desea salir del sistema o ingresar otro usuario"
        men = MsgBox("Desea Salir o Ingresar otro Usuario", MsgBoxStyle.YesNo, "")
        If men = MsgBoxResult.Yes Then
            Close()
        Else
            usu.Enabled = True

        End If

    End Sub
End Class