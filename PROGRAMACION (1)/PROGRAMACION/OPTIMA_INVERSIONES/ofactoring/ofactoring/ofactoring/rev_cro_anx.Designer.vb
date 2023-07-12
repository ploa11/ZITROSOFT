<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rev_cro_anx
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rev_cro_anx))
        Me.dtp4 = New System.Windows.Forms.DateTimePicker()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.cb2 = New System.Windows.Forms.ComboBox()
        Me.t24 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb3 = New System.Windows.Forms.ComboBox()
        Me.dtp5 = New System.Windows.Forms.DateTimePicker()
        Me.dtp6 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Button6 = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp4
        '
        Me.dtp4.Enabled = False
        Me.dtp4.Location = New System.Drawing.Point(660, 58)
        Me.dtp4.Name = "dtp4"
        Me.dtp4.Size = New System.Drawing.Size(233, 21)
        Me.dtp4.TabIndex = 0
        '
        'dgv
        '
        Me.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(11, 347)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(1216, 355)
        Me.dgv.TabIndex = 1
        '
        'cb1
        '
        Me.cb1.FormattingEnabled = True
        Me.cb1.Items.AddRange(New Object() {"Cronogramas", "Anexos", "Cuotas Cronogramas", "Facturas Anexos", "Ambos Cronogramas y Anexos", "Ambos Cuotas y Facturas"})
        Me.cb1.Location = New System.Drawing.Point(100, 18)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(170, 23)
        Me.cb1.TabIndex = 2
        '
        'cb2
        '
        Me.cb2.Enabled = False
        Me.cb2.FormattingEnabled = True
        Me.cb2.Items.AddRange(New Object() {"Codigo de Cliente", "Codigo de Operacion", "Codigo de Cuota o Factura", "Fecha de Inicio", "Fecha de Termino", "Rangos de Fechas", "Estado"})
        Me.cb2.Location = New System.Drawing.Point(100, 57)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(170, 23)
        Me.cb2.TabIndex = 3
        '
        't24
        '
        Me.t24.Enabled = False
        Me.t24.Location = New System.Drawing.Point(278, 58)
        Me.t24.Name = "t24"
        Me.t24.Size = New System.Drawing.Size(368, 21)
        Me.t24.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Filtrar por:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Filtrar por:"
        '
        'cb3
        '
        Me.cb3.Enabled = False
        Me.cb3.FormattingEnabled = True
        Me.cb3.Items.AddRange(New Object() {"VIGENTE", "CANCELADO", "REPROGRAMADO", "ADELANTADO", "VENCIDO", "PARCIAL VENCIDO", "PARCIAL ADELANTADO"})
        Me.cb3.Location = New System.Drawing.Point(911, 58)
        Me.cb3.Name = "cb3"
        Me.cb3.Size = New System.Drawing.Size(152, 23)
        Me.cb3.TabIndex = 9
        '
        'dtp5
        '
        Me.dtp5.Enabled = False
        Me.dtp5.Location = New System.Drawing.Point(36, 44)
        Me.dtp5.Name = "dtp5"
        Me.dtp5.Size = New System.Drawing.Size(233, 21)
        Me.dtp5.TabIndex = 10
        Me.dtp5.Visible = False
        '
        'dtp6
        '
        Me.dtp6.Enabled = False
        Me.dtp6.Location = New System.Drawing.Point(307, 44)
        Me.dtp6.Name = "dtp6"
        Me.dtp6.Size = New System.Drawing.Size(233, 21)
        Me.dtp6.TabIndex = 11
        Me.dtp6.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(278, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(364, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Codigo Cliente / Codigo de Operacion / Codigo de Cuota/Factura:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(658, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Fecha de Inicio o Termino:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(909, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Estado:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(99, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Fecha de Inicio:"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(360, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 15)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Fecha de Termino:"
        Me.Label7.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(558, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 27)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Consultar"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.dtp6)
        Me.GroupBox1.Controls.Add(Me.dtp5)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 106)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(680, 102)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consulta fechas de Vencimiento:"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1079, 50)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 40)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Export. Excel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ofactoring.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(1112, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(116, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1154, 304)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 30
        Me.Button3.Text = "Salir"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(932, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 162)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Descripcion de Colores:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(32, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 15)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "MORA"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.Red
        Me.TextBox4.Location = New System.Drawing.Point(138, 111)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 21)
        Me.TextBox4.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 15)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "VENCIDO"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Maroon
        Me.TextBox3.Location = New System.Drawing.Point(138, 84)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 21)
        Me.TextBox3.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(32, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 15)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "CANCELADO"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.RoyalBlue
        Me.TextBox2.Location = New System.Drawing.Point(138, 57)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 21)
        Me.TextBox2.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.OliveDrab
        Me.TextBox1.Location = New System.Drawing.Point(138, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 21)
        Me.TextBox1.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "VIGENTE"
        '
        'PrintDocument1
        '
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(932, 303)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "IMPRIMIR"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(932, 278)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 48)
        Me.Button5.TabIndex = 33
        Me.Button5.Text = "Vista Previa"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'PrintDocument2
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument2
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(912, 291)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 34
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'rev_cro_anx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1240, 714)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cb3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.t24)
        Me.Controls.Add(Me.cb2)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.dtp4)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rev_cro_anx"
        Me.Text = "rev_cro_anx"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtp4 As DateTimePicker
    Friend WithEvents dgv As DataGridView
    Friend WithEvents cb1 As ComboBox
    Friend WithEvents cb2 As ComboBox
    Friend WithEvents t24 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cb3 As ComboBox
    Friend WithEvents dtp5 As DateTimePicker
    Friend WithEvents dtp6 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents PrintDocument2 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Button6 As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox3 As TextBox
End Class
