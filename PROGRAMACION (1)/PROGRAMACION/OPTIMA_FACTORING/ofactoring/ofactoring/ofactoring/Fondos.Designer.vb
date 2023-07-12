<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fondos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fondos))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CobranzaRegistradaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarCobranzaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentasPorPagarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientosBancariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoBancosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentaRegistradaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListarVentasRegistradasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CronogramaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnexoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprobanteDePagoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListarComprobantesPagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpresionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotaDeCreditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContabilidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegsitrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarParticipesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegestroDeMancomunadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDistribucionDeBeneficioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeCuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeParticipacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatosDeFondoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizarDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CobranzaRegistradaToolStripMenuItem, Me.VentaRegistradaToolStripMenuItem, Me.ContabilidadToolStripMenuItem, Me.RegsitrosToolStripMenuItem, Me.DatosDeFondoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(793, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CobranzaRegistradaToolStripMenuItem
        '
        Me.CobranzaRegistradaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarCobranzaToolStripMenuItem, Me.CuentasPorPagarToolStripMenuItem, Me.MovimientosBancariosToolStripMenuItem})
        Me.CobranzaRegistradaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CobranzaRegistradaToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.CobranzaRegistradaToolStripMenuItem.Image = CType(resources.GetObject("CobranzaRegistradaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CobranzaRegistradaToolStripMenuItem.Name = "CobranzaRegistradaToolStripMenuItem"
        Me.CobranzaRegistradaToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.CobranzaRegistradaToolStripMenuItem.Text = "Tesoreria"
        '
        'RegistrarCobranzaToolStripMenuItem
        '
        Me.RegistrarCobranzaToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistrarCobranzaToolStripMenuItem.Image = CType(resources.GetObject("RegistrarCobranzaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RegistrarCobranzaToolStripMenuItem.Name = "RegistrarCobranzaToolStripMenuItem"
        Me.RegistrarCobranzaToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.RegistrarCobranzaToolStripMenuItem.Text = "Cuentas Por Cobrar"
        '
        'CuentasPorPagarToolStripMenuItem
        '
        Me.CuentasPorPagarToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.CuentasPorPagarToolStripMenuItem.Image = CType(resources.GetObject("CuentasPorPagarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CuentasPorPagarToolStripMenuItem.Name = "CuentasPorPagarToolStripMenuItem"
        Me.CuentasPorPagarToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.CuentasPorPagarToolStripMenuItem.Text = "Cuentas Por Pagar"
        '
        'MovimientosBancariosToolStripMenuItem
        '
        Me.MovimientosBancariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EstadoBancosToolStripMenuItem})
        Me.MovimientosBancariosToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.MovimientosBancariosToolStripMenuItem.Image = CType(resources.GetObject("MovimientosBancariosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MovimientosBancariosToolStripMenuItem.Name = "MovimientosBancariosToolStripMenuItem"
        Me.MovimientosBancariosToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.MovimientosBancariosToolStripMenuItem.Text = "Movimientos Bancarios"
        '
        'EstadoBancosToolStripMenuItem
        '
        Me.EstadoBancosToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.EstadoBancosToolStripMenuItem.Image = Global.ofactoring.My.Resources.Resources.hoja
        Me.EstadoBancosToolStripMenuItem.Name = "EstadoBancosToolStripMenuItem"
        Me.EstadoBancosToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.EstadoBancosToolStripMenuItem.Text = "Estado Bancos"
        '
        'VentaRegistradaToolStripMenuItem
        '
        Me.VentaRegistradaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListarVentasRegistradasToolStripMenuItem, Me.RegistrarVentasToolStripMenuItem, Me.ImpresionesToolStripMenuItem})
        Me.VentaRegistradaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VentaRegistradaToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.VentaRegistradaToolStripMenuItem.Image = CType(resources.GetObject("VentaRegistradaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VentaRegistradaToolStripMenuItem.Name = "VentaRegistradaToolStripMenuItem"
        Me.VentaRegistradaToolStripMenuItem.Size = New System.Drawing.Size(101, 20)
        Me.VentaRegistradaToolStripMenuItem.Text = "Operaciones"
        '
        'ListarVentasRegistradasToolStripMenuItem
        '
        Me.ListarVentasRegistradasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CronogramaToolStripMenuItem, Me.AnexoToolStripMenuItem})
        Me.ListarVentasRegistradasToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListarVentasRegistradasToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.ListarVentasRegistradasToolStripMenuItem.Image = CType(resources.GetObject("ListarVentasRegistradasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ListarVentasRegistradasToolStripMenuItem.Name = "ListarVentasRegistradasToolStripMenuItem"
        Me.ListarVentasRegistradasToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.ListarVentasRegistradasToolStripMenuItem.Text = "Registro de Cronograma / Anexo"
        '
        'CronogramaToolStripMenuItem
        '
        Me.CronogramaToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.CronogramaToolStripMenuItem.Image = CType(resources.GetObject("CronogramaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CronogramaToolStripMenuItem.Name = "CronogramaToolStripMenuItem"
        Me.CronogramaToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.CronogramaToolStripMenuItem.Text = "Cronograma"
        '
        'AnexoToolStripMenuItem
        '
        Me.AnexoToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.AnexoToolStripMenuItem.Image = CType(resources.GetObject("AnexoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AnexoToolStripMenuItem.Name = "AnexoToolStripMenuItem"
        Me.AnexoToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.AnexoToolStripMenuItem.Text = "Anexo"
        '
        'RegistrarVentasToolStripMenuItem
        '
        Me.RegistrarVentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComprobanteDePagoToolStripMenuItem1, Me.ListarComprobantesPagoToolStripMenuItem})
        Me.RegistrarVentasToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegistrarVentasToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistrarVentasToolStripMenuItem.Image = CType(resources.GetObject("RegistrarVentasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RegistrarVentasToolStripMenuItem.Name = "RegistrarVentasToolStripMenuItem"
        Me.RegistrarVentasToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.RegistrarVentasToolStripMenuItem.Text = "Seguimiento de Operaciones"
        '
        'ComprobanteDePagoToolStripMenuItem1
        '
        Me.ComprobanteDePagoToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComprobanteDePagoToolStripMenuItem1.ForeColor = System.Drawing.Color.Blue
        Me.ComprobanteDePagoToolStripMenuItem1.Image = CType(resources.GetObject("ComprobanteDePagoToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ComprobanteDePagoToolStripMenuItem1.Name = "ComprobanteDePagoToolStripMenuItem1"
        Me.ComprobanteDePagoToolStripMenuItem1.Size = New System.Drawing.Size(339, 22)
        Me.ComprobanteDePagoToolStripMenuItem1.Text = "Listado de Anexos y Cronogramas"
        '
        'ListarComprobantesPagoToolStripMenuItem
        '
        Me.ListarComprobantesPagoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListarComprobantesPagoToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.ListarComprobantesPagoToolStripMenuItem.Image = CType(resources.GetObject("ListarComprobantesPagoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ListarComprobantesPagoToolStripMenuItem.Name = "ListarComprobantesPagoToolStripMenuItem"
        Me.ListarComprobantesPagoToolStripMenuItem.Size = New System.Drawing.Size(339, 22)
        Me.ListarComprobantesPagoToolStripMenuItem.Text = "Seguimiento de Cobros de Anexos y Cronogramas"
        '
        'ImpresionesToolStripMenuItem
        '
        Me.ImpresionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturasToolStripMenuItem, Me.NotaDeCreditoToolStripMenuItem})
        Me.ImpresionesToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImpresionesToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.ImpresionesToolStripMenuItem.Image = CType(resources.GetObject("ImpresionesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImpresionesToolStripMenuItem.Name = "ImpresionesToolStripMenuItem"
        Me.ImpresionesToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.ImpresionesToolStripMenuItem.Text = "Impresiones"
        '
        'FacturasToolStripMenuItem
        '
        Me.FacturasToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.FacturasToolStripMenuItem.Image = CType(resources.GetObject("FacturasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FacturasToolStripMenuItem.Name = "FacturasToolStripMenuItem"
        Me.FacturasToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.FacturasToolStripMenuItem.Text = "Facturas"
        '
        'NotaDeCreditoToolStripMenuItem
        '
        Me.NotaDeCreditoToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.NotaDeCreditoToolStripMenuItem.Image = CType(resources.GetObject("NotaDeCreditoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NotaDeCreditoToolStripMenuItem.Name = "NotaDeCreditoToolStripMenuItem"
        Me.NotaDeCreditoToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.NotaDeCreditoToolStripMenuItem.Text = "Nota de Credito"
        '
        'ContabilidadToolStripMenuItem
        '
        Me.ContabilidadToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContabilidadToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.ContabilidadToolStripMenuItem.Image = CType(resources.GetObject("ContabilidadToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ContabilidadToolStripMenuItem.Name = "ContabilidadToolStripMenuItem"
        Me.ContabilidadToolStripMenuItem.Size = New System.Drawing.Size(103, 20)
        Me.ContabilidadToolStripMenuItem.Text = "Contabilidad"
        '
        'RegsitrosToolStripMenuItem
        '
        Me.RegsitrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarParticipesToolStripMenuItem, Me.RegestroDeMancomunadosToolStripMenuItem, Me.RegistroDeClientesToolStripMenuItem, Me.RegistroDistribucionDeBeneficioToolStripMenuItem, Me.RegistroDeCuentaToolStripMenuItem, Me.RegistroDeParticipacionesToolStripMenuItem})
        Me.RegsitrosToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegsitrosToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegsitrosToolStripMenuItem.Image = CType(resources.GetObject("RegsitrosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RegsitrosToolStripMenuItem.Name = "RegsitrosToolStripMenuItem"
        Me.RegsitrosToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.RegsitrosToolStripMenuItem.Text = "Regisitros"
        '
        'RegistrarParticipesToolStripMenuItem
        '
        Me.RegistrarParticipesToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistrarParticipesToolStripMenuItem.Image = CType(resources.GetObject("RegistrarParticipesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RegistrarParticipesToolStripMenuItem.Name = "RegistrarParticipesToolStripMenuItem"
        Me.RegistrarParticipesToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.RegistrarParticipesToolStripMenuItem.Text = "Registrar Participes"
        '
        'RegestroDeMancomunadosToolStripMenuItem
        '
        Me.RegestroDeMancomunadosToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegestroDeMancomunadosToolStripMenuItem.Image = CType(resources.GetObject("RegestroDeMancomunadosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RegestroDeMancomunadosToolStripMenuItem.Name = "RegestroDeMancomunadosToolStripMenuItem"
        Me.RegestroDeMancomunadosToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.RegestroDeMancomunadosToolStripMenuItem.Text = "Registro de Mancomunados"
        '
        'RegistroDeClientesToolStripMenuItem
        '
        Me.RegistroDeClientesToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistroDeClientesToolStripMenuItem.Image = CType(resources.GetObject("RegistroDeClientesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RegistroDeClientesToolStripMenuItem.Name = "RegistroDeClientesToolStripMenuItem"
        Me.RegistroDeClientesToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.RegistroDeClientesToolStripMenuItem.Text = "Registro de Clientes"
        '
        'RegistroDistribucionDeBeneficioToolStripMenuItem
        '
        Me.RegistroDistribucionDeBeneficioToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistroDistribucionDeBeneficioToolStripMenuItem.Image = CType(resources.GetObject("RegistroDistribucionDeBeneficioToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RegistroDistribucionDeBeneficioToolStripMenuItem.Name = "RegistroDistribucionDeBeneficioToolStripMenuItem"
        Me.RegistroDistribucionDeBeneficioToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.RegistroDistribucionDeBeneficioToolStripMenuItem.Text = "Registro Distribucion de Beneficio"
        '
        'RegistroDeCuentaToolStripMenuItem
        '
        Me.RegistroDeCuentaToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistroDeCuentaToolStripMenuItem.Image = CType(resources.GetObject("RegistroDeCuentaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RegistroDeCuentaToolStripMenuItem.Name = "RegistroDeCuentaToolStripMenuItem"
        Me.RegistroDeCuentaToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.RegistroDeCuentaToolStripMenuItem.Text = "Registro de Cuenta Bancaria"
        '
        'RegistroDeParticipacionesToolStripMenuItem
        '
        Me.RegistroDeParticipacionesToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistroDeParticipacionesToolStripMenuItem.Image = CType(resources.GetObject("RegistroDeParticipacionesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RegistroDeParticipacionesToolStripMenuItem.Name = "RegistroDeParticipacionesToolStripMenuItem"
        Me.RegistroDeParticipacionesToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.RegistroDeParticipacionesToolStripMenuItem.Text = "Registro de Participaciones"
        '
        'DatosDeFondoToolStripMenuItem
        '
        Me.DatosDeFondoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarDatosToolStripMenuItem})
        Me.DatosDeFondoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatosDeFondoToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.DatosDeFondoToolStripMenuItem.Image = CType(resources.GetObject("DatosDeFondoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DatosDeFondoToolStripMenuItem.Name = "DatosDeFondoToolStripMenuItem"
        Me.DatosDeFondoToolStripMenuItem.Size = New System.Drawing.Size(118, 20)
        Me.DatosDeFondoToolStripMenuItem.Text = "Datos de Fondo"
        '
        'ActualizarDatosToolStripMenuItem
        '
        Me.ActualizarDatosToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.ActualizarDatosToolStripMenuItem.Image = Global.ofactoring.My.Resources.Resources.hoja
        Me.ActualizarDatosToolStripMenuItem.Name = "ActualizarDatosToolStripMenuItem"
        Me.ActualizarDatosToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ActualizarDatosToolStripMenuItem.Text = "Actualizar Datos"
        '
        'Fondos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.ofactoring.My.Resources.Resources.op2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(793, 343)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.Blue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Fondos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fondos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CobranzaRegistradaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarCobranzaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CuentasPorPagarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MovimientosBancariosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoBancosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentaRegistradaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListarVentasRegistradasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComprobanteDePagoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ListarComprobantesPagoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImpresionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotaDeCreditoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContabilidadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegsitrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarParticipesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDeClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegestroDeMancomunadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDeParticipacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDeCuentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatosDeFondoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDistribucionDeBeneficioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActualizarDatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CronogramaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnexoToolStripMenuItem As ToolStripMenuItem
End Class
