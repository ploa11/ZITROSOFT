Public Class accautodistribene
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
    Public user, pass As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        user = TextBox1.Text
        pass = TextBox2.Text
        If user = "admin" And pass = "OP2018" Then
            reparticion_beneficio.Button10.Enabled = True
            reparticion_beneficio.Button9.Enabled = True
            reparticion_beneficio.Button10.Visible = True
            reparticion_beneficio.Button9.Visible = True
            reparticion_beneficio.Enabled = True
            Me.Close()

        Else
            MsgBox("Usuario y Clave no son correctos", MsgBoxStyle.Information, ":: Optima Inversiones:::")
            Me.Show()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub accautodistribene_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Acceso a Distribucion de Beneficios y Rescates" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
    End Sub
End Class