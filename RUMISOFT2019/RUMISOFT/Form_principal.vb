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

    Private Sub ConfServSQLToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form_Reg_SRV_SQL.Show()
    End Sub

    Private Sub MovimientosBancariosToolStripMenuItem_Click(sender As Object, e As EventArgs) 

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

    Private Sub RegstroDeEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Form_Reg_Emp.Show()
    End Sub

    Private Sub SubCentroDeCostoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubCentroDeCostoToolStripMenuItem.Click
        Form_Reg_SCCOS.Show()
    End Sub

    Private Sub RegistroDeUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeUsuariosToolStripMenuItem.Click
        Form_Reg_Usuario.Show()
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SALIRToolStripMenuItem.Click
        Form_Reg_SRV_SQL.Close()
    End Sub

    Private Sub RequerimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequerimientosToolStripMenuItem.Click
        Form_Reg_RQ.Show()
    End Sub

    Private Sub PrioridadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrioridadesToolStripMenuItem.Click
        prioridad.Show()
    End Sub

    Private Sub SeguimientoDeRequerimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguimientoDeRequerimientosToolStripMenuItem.Click

        Try

            If inicio.CARGO = "SISTEMAS" Then
                Form_rev_rq.busq = ""
                Form_rev_rq.Show()
                MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
            Else
                If inicio.CARGO = "ADMINISTRACION" Then
                    Form_rev_rq.busq = ""
                    Form_rev_rq.Show()
                    MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
                Else
                    If inicio.CARGO = "GERENCIA" Then
                        Form_rev_rq.busq = ""
                        Form_rev_rq.Show()
                        MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
                    Else

                        MessageBox.Show("NO TIENE PERMISO PARA VER ESTE FORMULARIO", "ZITRO")
                    End If
                End If

            End If
            'Select Case inicio.CARGO
            'Case "ADMINISTRACION"
            'Form_rev_rq.busq = ""
            'Form_rev_rq.Show()
            'MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
            'Case "SISTEMAS"
            ' Form_rev_rq.busq = ""
            '    Form_rev_rq.Show()
            ' MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
            'Case "GERENCIA"
            'Form_rev_rq.busq = ""
            'Form_rev_rq.Show()
            'MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
            ' End Select

        Catch ex As Exception
            MessageBox.Show("ERROR", "ZITRO")
        End Try
        ' MessageBox.Show("NO TIENE PERMISO PARA VER ESTE FORMULARIO", "ZITRO")

    End Sub

    Private Sub ControlDeAlmacenesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDeAlmacenesToolStripMenuItem.Click
        Form_control_alamacen.Show()
    End Sub

    Private Sub ListaDeProductosToolStripMenuItem1_Click(sender As Object, e As EventArgs) 
        Form_List_Product.Show()
    End Sub

    Private Sub RegistroDeEquiposToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RegistroDeCTAYCCIBancosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeCTAYCCIBancosToolStripMenuItem.Click
        Form_Mov_Banc.Show()
    End Sub

    Private Sub RegistroDeContactoDeProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeContactoDeProveedoresToolStripMenuItem.Click
        Form_Contacto_Proveedor.Show()
    End Sub

    Private Sub OrdenDeCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenDeCompraToolStripMenuItem.Click
        Form_Orden_Compra.Show()
    End Sub

    Private Sub CotizacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CotizacionToolStripMenuItem.Click
        Form_Cotizacion.Show()
    End Sub

    Private Sub ImportadorDeExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportadorDeExcelToolStripMenuItem.Click
        Form_Import_Excel.Show()
    End Sub

    Private Sub ProgramarPagosOCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgramarPagosOCToolStripMenuItem.Click

        Try

            If inicio.CARGO = "SISTEMAS" Then
                ' Form_rev_rq.busq = ""
                Form_Prog_Pagos.Show()
                MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
            Else
                If inicio.CARGO = "ADMINISTRACION" Then
                    'Form_rev_rq.busq = ""
                    Form_Prog_Pagos.Show()
                    MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
                Else
                    If inicio.CARGO = "GERENCIA" Then
                        'Form_rev_rq.busq = ""
                        Form_Prog_Pagos.Show()
                        MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
                    Else

                        MessageBox.Show("NO TIENE PERMISO PARA VER ESTE FORMULARIO", "ZITRO")
                    End If
                End If

            End If
            'Select Case inicio.CARGO
            'Case "ADMINISTRACION"
            'Form_rev_rq.busq = ""
            'Form_rev_rq.Show()
            'MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
            'Case "SISTEMAS"
            ' Form_rev_rq.busq = ""
            '    Form_rev_rq.Show()
            ' MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
            'Case "GERENCIA"
            'Form_rev_rq.busq = ""
            'Form_rev_rq.Show()
            'MessageBox.Show("ACCESO PERMITIDO", "ZITRO")
            ' End Select

        Catch ex As Exception
            MessageBox.Show("ERROR", "ZITRO")
        End Try
        ' MessageBox.Show("NO TIENE PERMISO PARA VER ESTE FORMULARIO", "ZITRO")


    End Sub
End Class
