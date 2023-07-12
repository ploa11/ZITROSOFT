Public Class Form_principal
    Private Sub Form_principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = inicio.NOM
        Label5.Text = inicio.APE
        Label6.Text = inicio.DNI
        Label8.Text = inicio.CARGO
        Label9.Text = inicio.SEDE
    End Sub

    Private Sub RegistroDeBancosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeBancosToolStripMenuItem.Click
        Form_reg_Banco.Show()
    End Sub

    Private Sub ConfServSQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfServSQLToolStripMenuItem.Click
        Form_Reg_SRV_SQL.Show()
    End Sub

    Private Sub MovimientosBancariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosBancariosToolStripMenuItem.Click
        Form_Mov_Banc.Show()
    End Sub

    Private Sub CentroDeCostoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CentroDeCostoToolStripMenuItem.Click
        Form_Reg_Cent_Costo.Show()
    End Sub

    Private Sub SedeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SedeToolStripMenuItem.Click
        Form_Reg_Sede.Show()
    End Sub

    Private Sub RegistroDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeClientesToolStripMenuItem.Click
        Form_Reg_Cliente.Show()
    End Sub

    Private Sub MonedaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonedaToolStripMenuItem.Click
        Form_Reg_Moneda.Show()
    End Sub

    Private Sub ListaDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeProductosToolStripMenuItem.Click
        Form_List_Product.Show()
    End Sub

    Private Sub ModuloClasificacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModuloClasificacionToolStripMenuItem.Click
        Form_Reg_Clasificacion.Show()
    End Sub

    Private Sub REGISTROPROVEEDORESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REGISTROPROVEEDORESToolStripMenuItem.Click
        Form_Reg_Prov_Clie.Show()
    End Sub

    Private Sub RegstroDeEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegstroDeEmpresaToolStripMenuItem.Click
        Form_Reg_Emp.Show()
    End Sub

    Private Sub SubCentroDeCostoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubCentroDeCostoToolStripMenuItem.Click
        Form_Reg_SCCOS.Show()
    End Sub

    Private Sub RegistroDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeUsuariosToolStripMenuItem.Click
        Form_Reg_Usuario.Show()
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SALIRToolStripMenuItem.Click
        inicio.Close()

    End Sub

    Private Sub RequerimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequerimientosToolStripMenuItem.Click
        Form_Reg_RQ.Show()
    End Sub

    Private Sub PrioridadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrioridadesToolStripMenuItem.Click
        prioridad.Show()
    End Sub

    Private Sub SeguimientoDeRequerimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguimientoDeRequerimientosToolStripMenuItem.Click
        Form_rev_rq.Show()
    End Sub

    Private Sub ControlDeAlmacenesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDeAlmacenesToolStripMenuItem.Click
        Form_control_alamacen.Show()
    End Sub

    Private Sub ListaDeProductosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ListaDeProductosToolStripMenuItem1.Click
        Form_List_Product.Show()
    End Sub

    Private Sub OrdenDeCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenDeCompraToolStripMenuItem.Click
        Form_Orden_Compra.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("www.rumi-ingenieros.com")
    End Sub

    Private Sub TesoreriaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub
End Class
