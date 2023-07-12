Public Class opciones
    'Public conexion As New conexion
    'Public cfondo As New cfondo
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
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim prin = principal
        prin.Close()
        Close()
    End Sub

    Private Sub RegistarDistritoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistarDistritoToolStripMenuItem.Click
        Dim dist As New disitrito
        'dist.MdiParent = Me
        dist.Show()
    End Sub

    Private Sub RegistrarDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarDepartamentoToolStripMenuItem.Click
        Dim depa = departamento
        depa.Show()
    End Sub

    Private Sub RegistrarProvinciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        Dim pvi = provincia
        pvi.Show()
    End Sub

    Private Sub RegistrarTipoDeDocumentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarTipoDeDocumentosToolStripMenuItem.Click
        Dim tdocu = tdoc
        tdocu.Show()
    End Sub

    Private Sub RegistrarTipoDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarTipoDeClientesToolStripMenuItem.Click, ToolStripMenuItem5.Click
        Dim tcli = tcliente
        tcli.Show()
    End Sub

    Private Sub RegistrarClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarClientesToolStripMenuItem.Click
        Dim clie As New clientes
        'clie.MdiParent = Me
        clie.Show()
    End Sub








    Private Sub opciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ControlBox = True
    End Sub

    Private Sub ListarVentasRegistradasToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ConsultaDeProductosYStokToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RegristroDeProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegristroDeProveedoresToolStripMenuItem.Click
        Dim regprov = rproveedores
        regprov.Show()
    End Sub

    Private Sub RegistroDeBancosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim regbanc = reg_bancos
        regbanc.Show()
    End Sub

    Private Sub RegistroDeUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeUsuarioToolStripMenuItem.Click
        Dim usu = usuario
        usu.Show()
    End Sub

    Private Sub CobranzaRegistradaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub RegistroDeAreasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeAreasToolStripMenuItem.Click
        area.Show()
    End Sub

    Private Sub RegistrarDocumentosDeComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarDocumentosDeComprasToolStripMenuItem.Click
        doc_compra.Show()
    End Sub

    Private Sub RegistroTipoDeCambioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroTipoDeCambioToolStripMenuItem.Click
        'tcambio.Show()
        Dim tcambio As New tcambio
        'tcambio.MdiParent = Me
        tcambio.Show()
    End Sub

    Private Sub AccederAFondosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccederAFondosToolStripMenuItem.Click
        conexion.Show()
        conexion.t1.Text = ""
        conexion.t2.Text = ""
        conexion.t3.Text = ""

        'conexion.MdiParent = Me
        'conexion.Show()
    End Sub

    Private Sub CrearNuevoFondoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearNuevoFondoToolStripMenuItem.Click
        'cfondo.Show()
        Dim cfondo As New cfondo
        'cfondo.MdiParent = Me
        cfondo.Show()

    End Sub

    Private Sub RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem.Click
        servidorsql.Show()

    End Sub

    Private Sub GestionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionToolStripMenuItem.Click
        gestion.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)
        conexion.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        ' Dim conexion As New conexion
        ' conexion.TopLevel = False
        'conexion.WindowState = FormWindowState.Maximized
        'conexion.Visible = True
        'conexion.Show()
        'Panel1.Controls.Add(conexion)
        ''conexion.TopLevel.show()

    End Sub

    Private Sub FeriadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FeriadosToolStripMenuItem.Click
        Feriados.Show()

    End Sub

    Private Sub CalulosDeDiasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        diasnumero.Show()

    End Sub

    Private Sub PlanContableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanContableToolStripMenuItem.Click
        plancontable.Show()
    End Sub

    Private Sub RegToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        regcuentabanco.Show()
    End Sub

    Private Sub PeriodosDeDistribucionDeBeneficioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeriodosDeDistribucionDeBeneficioToolStripMenuItem.Click
        distribu_benefi.Show()

    End Sub
End Class