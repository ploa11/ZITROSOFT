Public Class Fondos
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

    Public cuotas As New Cuotas
    'cuotas.MdiParent = Me
    Public cuota_opera As New Cuotas_Operacion
    'cuota_opera.MdiParent = Me
    Public fac_opera_anx As New fac_operacion_anx
    'fac_opera_anx.MdiParent = Me

    Private Sub ListarComprobantesPagoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RegistrarParticipesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarParticipesToolStripMenuItem.Click
        Dim reg_parti As New registro_participes
        'reg_parti.MdiParent = Me
        reg_parti.Show()


    End Sub

    Private Sub RegistroDeCuentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeCuentaToolStripMenuItem.Click
        'registro_de_cuentas_bancos.Show()
        Dim reg_cue_banc As New registro_de_cuentas_bancos
        'reg_cue_banc.MdiParent = Me
        reg_cue_banc.Show()

    End Sub

    Private Sub RegestroDeMancomunadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegestroDeMancomunadosToolStripMenuItem.Click
        'Regristro_mancomunado.Show()
        Dim reg_manco As New Regristro_mancomunado
        'reg_manco.MdiParent = Me
        reg_manco.Show()

    End Sub

    Private Sub RegistroDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        ' registro_clientes.Show()
        Dim reg_clie As New registro_clientes
        'reg_clie.MdiParent = Me
        reg_clie.Show()


    End Sub

    Private Sub Fondos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RegistroDistribucionDeBeneficioToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'distribu_benefi.Show()
        Dim dist_beni As New distribu_benefi
        'dist_beni.MdiParent = Me
        dist_beni.Show()

    End Sub

    Private Sub RegistroDeParticipacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeParticipacionesToolStripMenuItem.Click
        'reg_participaciones.Show()
        Dim reg_participa As New reg_participaciones
        'reg_participa.MdiParent = Me
        reg_participa.Show()
    End Sub

    Private Sub ActualizarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarDatosToolStripMenuItem.Click
        Datos_Generales_del_Fondo.Button3_Click(sender, e)
        monitoreovencimientos.Close()
        'Actualizacion_de_datos.suma_grid2()
        Actualizacion_de_datos.Show()

    End Sub

    Private Sub ListarVentasRegistradasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListarVentasRegistradasToolStripMenuItem.Click

    End Sub

    Private Sub AnexoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnexoToolStripMenuItem.Click
        'Anexo.Show()
        Dim anexo As New Anexo
        'anexo.MdiParent = Me
        anexo.Show()

    End Sub

    Private Sub CronogramaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CronogramaToolStripMenuItem.Click
        'Anex_Cronog.Show()
        Dim anexo_cronog As New Anex_Cronog
        'Anex_Cronog.MdiParent = Me
        Anex_Cronog.Show()
    End Sub

    Private Sub SalirDeFondoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirDeFondoToolStripMenuItem.Click

        cuotas.Close()
        cuota_opera.Close()
        Cuotas_Operacion.Close()
        Anexo.Close()
        Anex_Cronog.Close()
        Datos_Generales_del_Fondo.Close()
        distribu_benefi.Close()
        fac_operacion_anx.Close()
        regcuentabanco.Close()
        reg_participaciones.Close()
        registro_participes.Close()
        registro_bancos_fondo.Close()
        registro_clientes.Close()
        registro_de_cuentas_bancos.Close()
        Regristro_mancomunado.Close()
        historial.Close()
        comisiones_por_desembolso.Close()


        Me.Close()



    End Sub

    Private Sub CalcularNumeroDeDiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcularNumeroDeDiaToolStripMenuItem.Click
        otros_gastos.Show()
    End Sub

    Private Sub ComprobanteDePagoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ComprobanteDePagoToolStripMenuItem1.Click
        rev_cro_anx.Show()
    End Sub

    Private Sub AsientosContablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsientosContablesToolStripMenuItem.Click
        G_Asientos.Show()
    End Sub

    Private Sub FacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturasToolStripMenuItem.Click
        facturacion_fondos.Show()
    End Sub

    Private Sub CuentasPorPagarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasPorPagarToolStripMenuItem.Click

    End Sub

    Private Sub DesembolsosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesembolsosToolStripMenuItem.Click
        desembolsos.Show()
    End Sub

    Private Sub EstadoBancosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoBancosToolStripMenuItem.Click
        Mov_bancos.Show()
    End Sub

    Private Sub ComisionPorDesembolsoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComisionPorDesembolsoToolStripMenuItem.Click
        comisiones_por_desembolso.Show()
    End Sub

    Private Sub ParametrizarAsientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParametrizarAsientosToolStripMenuItem.Click
        param_asientos.Show()
    End Sub

    Private Sub ReparticionDeBeneficiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReparticionDeBeneficiosToolStripMenuItem.Click
        reparticion_beneficio.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub SimulacionDeCuotasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimulacionDeCuotasToolStripMenuItem.Click
        Amortizacion.Show()
        Amortizacion.ComboBox1.Enabled = False
        Amortizacion.TextBoxIMPORTE.Enabled = True
        Amortizacion.TextBoxINTERES.Enabled = True
        Amortizacion.IGVINT.Enabled = True
        Amortizacion.TextBoxMESES.Enabled = True
        Amortizacion.DIAS.Enabled = True
        Amortizacion.pgracia.Enabled = True
        Amortizacion.Button1.Enabled = True
        Amortizacion.Button5.Enabled = False
        Amortizacion.Button5.Visible = False
        Amortizacion.Button8.Enabled = True
        Amortizacion.DateTimePicker1.Enabled = True
        Amortizacion.Button13.Visible = True
        Amortizacion.TextBox5.Visible = True
        Amortizacion.TextBox3.Visible = True
        Amortizacion.TextBox4.Visible = True
        Amortizacion.TextBox6.Visible = True
        Amortizacion.Label8.Visible = True
        Amortizacion.Label18.Visible = True
        Amortizacion.Label19.Visible = True
        Amortizacion.Label17.Visible = True
        Amortizacion.Button14.Visible = True
    End Sub

    Private Sub MonitoreoDeVencimientosDeCuotasYFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonitoreoDeVencimientosDeCuotasYFacturasToolStripMenuItem.Click
        monitoreovencimientos.Show()
    End Sub

    Private Sub DatosDeFondoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatosDeFondoToolStripMenuItem.Click

    End Sub
End Class