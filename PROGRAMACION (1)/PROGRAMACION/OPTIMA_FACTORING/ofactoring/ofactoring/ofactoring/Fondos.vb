Public Class Fondos
    Private Sub ListarComprobantesPagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListarComprobantesPagoToolStripMenuItem.Click

    End Sub

    Private Sub RegistrarParticipesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarParticipesToolStripMenuItem.Click
        registro_participes.Show()

    End Sub

    Private Sub RegistroDeCuentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeCuentaToolStripMenuItem.Click
        registro_de_cuentas_bancos.Show()

    End Sub

    Private Sub RegestroDeMancomunadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegestroDeMancomunadosToolStripMenuItem.Click
        Regristro_mancomunado.Show()

    End Sub

    Private Sub RegistroDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeClientesToolStripMenuItem.Click
        registro_clientes.Show()

    End Sub

    Private Sub Fondos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RegistroDistribucionDeBeneficioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDistribucionDeBeneficioToolStripMenuItem.Click
        distribu_benefi.Show()

    End Sub

    Private Sub RegistroDeParticipacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeParticipacionesToolStripMenuItem.Click
        reg_participaciones.Show()

    End Sub

    Private Sub ActualizarDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarDatosToolStripMenuItem.Click
        Datos_Generales_del_Fondo.Button3_Click(sender, e)
        Actualizacion_de_datos.suma_grid2()
        Actualizacion_de_datos.Show()

    End Sub

    Private Sub ListarVentasRegistradasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListarVentasRegistradasToolStripMenuItem.Click

    End Sub

    Private Sub AnexoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnexoToolStripMenuItem.Click
        Anexo.Show()
    End Sub

    Private Sub CronogramaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CronogramaToolStripMenuItem.Click
        Anex_Cronog.Show()
    End Sub
End Class