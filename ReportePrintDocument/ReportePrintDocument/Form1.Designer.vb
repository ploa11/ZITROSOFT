<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.btnImprimirEncabezado = New System.Windows.Forms.Button()
        Me.btnImprimirNormal = New System.Windows.Forms.Button()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.btnImprimirDatagrid = New System.Windows.Forms.Button()
        Me.PrintDocument3 = New System.Drawing.Printing.PrintDocument()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 59)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(775, 281)
        Me.DataGridView1.TabIndex = 0
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(12, 12)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(278, 31)
        Me.txtBuscar.TabIndex = 1
        '
        'btnImprimirEncabezado
        '
        Me.btnImprimirEncabezado.Location = New System.Drawing.Point(13, 364)
        Me.btnImprimirEncabezado.Name = "btnImprimirEncabezado"
        Me.btnImprimirEncabezado.Size = New System.Drawing.Size(195, 45)
        Me.btnImprimirEncabezado.TabIndex = 2
        Me.btnImprimirEncabezado.Text = "Imprimir con encabezado"
        Me.btnImprimirEncabezado.UseVisualStyleBackColor = True
        '
        'btnImprimirNormal
        '
        Me.btnImprimirNormal.Location = New System.Drawing.Point(214, 364)
        Me.btnImprimirNormal.Name = "btnImprimirNormal"
        Me.btnImprimirNormal.Size = New System.Drawing.Size(195, 45)
        Me.btnImprimirNormal.TabIndex = 3
        Me.btnImprimirNormal.Text = "Imprimir sin encabezado"
        Me.btnImprimirNormal.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument2
        '
        '
        'btnImprimirDatagrid
        '
        Me.btnImprimirDatagrid.Location = New System.Drawing.Point(415, 364)
        Me.btnImprimirDatagrid.Name = "btnImprimirDatagrid"
        Me.btnImprimirDatagrid.Size = New System.Drawing.Size(230, 45)
        Me.btnImprimirDatagrid.TabIndex = 40
        Me.btnImprimirDatagrid.Text = "Imprimir Datagrid"
        Me.btnImprimirDatagrid.UseVisualStyleBackColor = True
        '
        'PrintDocument3
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 430)
        Me.Controls.Add(Me.btnImprimirDatagrid)
        Me.Controls.Add(Me.btnImprimirNormal)
        Me.Controls.Add(Me.btnImprimirEncabezado)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents btnImprimirEncabezado As Button
    Friend WithEvents btnImprimirNormal As Button
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDocument2 As Printing.PrintDocument
    Friend WithEvents btnImprimirDatagrid As Button
    Friend WithEvents PrintDocument3 As Printing.PrintDocument
End Class
