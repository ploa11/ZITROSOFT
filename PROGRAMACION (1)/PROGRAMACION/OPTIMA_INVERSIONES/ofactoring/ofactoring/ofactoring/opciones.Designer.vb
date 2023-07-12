<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class opciones
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(opciones))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreacionDeFondoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearNuevoFondoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccederAFondosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContabilidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroTipoDeCambioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanContableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistarDistritoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarDepartamentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarTipoDeDocumentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarTipoDeClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegristroDeProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeAreasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarDocumentosDeComprasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GestionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeriadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeriodosDeDistribucionDeBeneficioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportesToolStripMenuItem, Me.CreacionDeFondoToolStripMenuItem, Me.ContabilidadToolStripMenuItem, Me.HerramientasToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(901, 24)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(131, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes de Fondos"
        '
        'CreacionDeFondoToolStripMenuItem
        '
        Me.CreacionDeFondoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrearNuevoFondoToolStripMenuItem, Me.AccederAFondosToolStripMenuItem})
        Me.CreacionDeFondoToolStripMenuItem.Name = "CreacionDeFondoToolStripMenuItem"
        Me.CreacionDeFondoToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.CreacionDeFondoToolStripMenuItem.Text = "Fondo"
        '
        'CrearNuevoFondoToolStripMenuItem
        '
        Me.CrearNuevoFondoToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.CrearNuevoFondoToolStripMenuItem.Name = "CrearNuevoFondoToolStripMenuItem"
        Me.CrearNuevoFondoToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CrearNuevoFondoToolStripMenuItem.Text = "Crear Nuevo Fondo"
        '
        'AccederAFondosToolStripMenuItem
        '
        Me.AccederAFondosToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.AccederAFondosToolStripMenuItem.Name = "AccederAFondosToolStripMenuItem"
        Me.AccederAFondosToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AccederAFondosToolStripMenuItem.Text = "Acceder a fondos"
        '
        'ContabilidadToolStripMenuItem
        '
        Me.ContabilidadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistroTipoDeCambioToolStripMenuItem, Me.PlanContableToolStripMenuItem})
        Me.ContabilidadToolStripMenuItem.Name = "ContabilidadToolStripMenuItem"
        Me.ContabilidadToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.ContabilidadToolStripMenuItem.Text = "Contabilidad"
        '
        'RegistroTipoDeCambioToolStripMenuItem
        '
        Me.RegistroTipoDeCambioToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistroTipoDeCambioToolStripMenuItem.Name = "RegistroTipoDeCambioToolStripMenuItem"
        Me.RegistroTipoDeCambioToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.RegistroTipoDeCambioToolStripMenuItem.Text = "Registro Tipo de Cambio"
        '
        'PlanContableToolStripMenuItem
        '
        Me.PlanContableToolStripMenuItem.Name = "PlanContableToolStripMenuItem"
        Me.PlanContableToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.PlanContableToolStripMenuItem.Text = "Plan Contable"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarClientesToolStripMenuItem, Me.RegistarDistritoToolStripMenuItem, Me.RegistrarDepartamentoToolStripMenuItem, Me.ToolStripMenuItem11, Me.RegistrarTipoDeDocumentosToolStripMenuItem, Me.RegistrarTipoDeClientesToolStripMenuItem, Me.RegristroDeProveedoresToolStripMenuItem, Me.ToolStripMenuItem5, Me.RegistroDeAreasToolStripMenuItem, Me.RegistrarDocumentosDeComprasToolStripMenuItem, Me.RegistroDeUsuarioToolStripMenuItem, Me.RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem, Me.GestionToolStripMenuItem, Me.FeriadosToolStripMenuItem, Me.PeriodosDeDistribucionDeBeneficioToolStripMenuItem})
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.HerramientasToolStripMenuItem.Text = "Utilidades"
        '
        'RegistrarClientesToolStripMenuItem
        '
        Me.RegistrarClientesToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistrarClientesToolStripMenuItem.Name = "RegistrarClientesToolStripMenuItem"
        Me.RegistrarClientesToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.RegistrarClientesToolStripMenuItem.Text = "Registro de Contactos"
        '
        'RegistarDistritoToolStripMenuItem
        '
        Me.RegistarDistritoToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistarDistritoToolStripMenuItem.Name = "RegistarDistritoToolStripMenuItem"
        Me.RegistarDistritoToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.RegistarDistritoToolStripMenuItem.Text = "Registar Distrito"
        '
        'RegistrarDepartamentoToolStripMenuItem
        '
        Me.RegistrarDepartamentoToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistrarDepartamentoToolStripMenuItem.Name = "RegistrarDepartamentoToolStripMenuItem"
        Me.RegistrarDepartamentoToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.RegistrarDepartamentoToolStripMenuItem.Text = "Registrar Departamento"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(330, 22)
        Me.ToolStripMenuItem11.Text = "Registrar Provincia"
        '
        'RegistrarTipoDeDocumentosToolStripMenuItem
        '
        Me.RegistrarTipoDeDocumentosToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistrarTipoDeDocumentosToolStripMenuItem.Name = "RegistrarTipoDeDocumentosToolStripMenuItem"
        Me.RegistrarTipoDeDocumentosToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.RegistrarTipoDeDocumentosToolStripMenuItem.Text = "Registrar Tipo de Documentos"
        '
        'RegistrarTipoDeClientesToolStripMenuItem
        '
        Me.RegistrarTipoDeClientesToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistrarTipoDeClientesToolStripMenuItem.Name = "RegistrarTipoDeClientesToolStripMenuItem"
        Me.RegistrarTipoDeClientesToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.RegistrarTipoDeClientesToolStripMenuItem.Text = "Registrar Tipo de Clientes"
        '
        'RegristroDeProveedoresToolStripMenuItem
        '
        Me.RegristroDeProveedoresToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegristroDeProveedoresToolStripMenuItem.Name = "RegristroDeProveedoresToolStripMenuItem"
        Me.RegristroDeProveedoresToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.RegristroDeProveedoresToolStripMenuItem.Text = "Regristro de Proveedores"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(330, 22)
        Me.ToolStripMenuItem5.Text = "Registrar Tipo de Clientes"
        '
        'RegistroDeAreasToolStripMenuItem
        '
        Me.RegistroDeAreasToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistroDeAreasToolStripMenuItem.Name = "RegistroDeAreasToolStripMenuItem"
        Me.RegistroDeAreasToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.RegistroDeAreasToolStripMenuItem.Text = "Registro de Areas"
        '
        'RegistrarDocumentosDeComprasToolStripMenuItem
        '
        Me.RegistrarDocumentosDeComprasToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistrarDocumentosDeComprasToolStripMenuItem.Name = "RegistrarDocumentosDeComprasToolStripMenuItem"
        Me.RegistrarDocumentosDeComprasToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.RegistrarDocumentosDeComprasToolStripMenuItem.Text = "Registrar Documentos de Compras"
        '
        'RegistroDeUsuarioToolStripMenuItem
        '
        Me.RegistroDeUsuarioToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistroDeUsuarioToolStripMenuItem.Name = "RegistroDeUsuarioToolStripMenuItem"
        Me.RegistroDeUsuarioToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.RegistroDeUsuarioToolStripMenuItem.Text = "Registro de Usuario"
        '
        'RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem
        '
        Me.RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem.Name = "RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem"
        Me.RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem.Text = "Registrar Nombre Servidor, Usuario, Clave SQL"
        '
        'GestionToolStripMenuItem
        '
        Me.GestionToolStripMenuItem.ForeColor = System.Drawing.Color.Blue
        Me.GestionToolStripMenuItem.Name = "GestionToolStripMenuItem"
        Me.GestionToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.GestionToolStripMenuItem.Text = "Gestion"
        '
        'FeriadosToolStripMenuItem
        '
        Me.FeriadosToolStripMenuItem.Name = "FeriadosToolStripMenuItem"
        Me.FeriadosToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.FeriadosToolStripMenuItem.Text = "Feriados"
        '
        'PeriodosDeDistribucionDeBeneficioToolStripMenuItem
        '
        Me.PeriodosDeDistribucionDeBeneficioToolStripMenuItem.Name = "PeriodosDeDistribucionDeBeneficioToolStripMenuItem"
        Me.PeriodosDeDistribucionDeBeneficioToolStripMenuItem.Size = New System.Drawing.Size(330, 22)
        Me.PeriodosDeDistribucionDeBeneficioToolStripMenuItem.Text = "Periodos de Distribucion de Beneficio"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'opciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.ofactoring.My.Resources.Resources.Logo_Optima_Invversiones
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(901, 692)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Blue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "opciones"
        Me.Text = "Opciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents HerramientasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistarDistritoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarDepartamentoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarTipoDeDocumentosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarTipoDeClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegristroDeProveedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDeUsuarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContabilidadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDeAreasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarDocumentosDeComprasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreacionDeFondoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrearNuevoFondoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroTipoDeCambioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AccederAFondosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistrarNombreServidorUsuarioClaveSQLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GestionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents FeriadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlanContableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PeriodosDeDistribucionDeBeneficioToolStripMenuItem As ToolStripMenuItem
End Class
