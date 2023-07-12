Public Class opciones
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim prin = principal
        prin.Close()
        Close()
    End Sub

    Private Sub RegistarDistritoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistarDistritoToolStripMenuItem.Click, ToolStripMenuItem1.Click
        Dim dist = disitrito
        dist.Show()
    End Sub

    Private Sub RegistrarDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarDepartamentoToolStripMenuItem.Click, ToolStripMenuItem2.Click, ToolStripMenuItem10.Click
        Dim depa = departamento
        depa.Show()
    End Sub

    Private Sub RegistrarProvinciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarProvinciaToolStripMenuItem.Click, ToolStripMenuItem3.Click, ToolStripMenuItem11.Click
        Dim pvi = provincia
        pvi.Show()
    End Sub

    Private Sub RegistrarTipoDeDocumentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarTipoDeDocumentosToolStripMenuItem.Click, ToolStripMenuItem4.Click
        Dim tdocu = tdoc
        tdocu.Show()
    End Sub

    Private Sub RegistrarTipoDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarTipoDeClientesToolStripMenuItem.Click, ToolStripMenuItem5.Click
        Dim tcli = tcliente
        tcli.Show()
    End Sub

    Private Sub RegistrarClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarClientesToolStripMenuItem.Click, ToolStripMenuItem6.Click
        Dim clie = clientes
        clie.Show()
    End Sub








    Private Sub opciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlBox = True
    End Sub

    Private Sub ListarVentasRegistradasToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ConsultaDeProductosYStokToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RegristroDeProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegristroDeProveedoresToolStripMenuItem.Click, ToolStripMenuItem7.Click
        Dim regprov = rproveedores
        regprov.Show()
    End Sub

    Private Sub RegistroDeBancosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeBancosToolStripMenuItem.Click, ToolStripMenuItem8.Click
        Dim regbanc = reg_bancos
        regbanc.Show()
    End Sub

    Private Sub RegistroDeUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeUsuarioToolStripMenuItem.Click, ToolStripMenuItem9.Click
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
        tcambio.Show()
    End Sub

    Private Sub AccederAFondosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccederAFondosToolStripMenuItem.Click
        conexion.Show()

    End Sub

    Private Sub CrearNuevoFondoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearNuevoFondoToolStripMenuItem.Click
        cfondo.Show()

    End Sub

    Private Sub RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem.Click
        servidorsql.Show()

    End Sub

    Private Sub GestionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GestionToolStripMenuItem.Click
        gestion.Show()

    End Sub
End Class