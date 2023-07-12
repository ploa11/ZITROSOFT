<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class desembolsos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(desembolsos))
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.cb2 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.t1 = New System.Windows.Forms.TextBox()
        Me.t2 = New System.Windows.Forms.TextBox()
        Me.t3 = New System.Windows.Forms.TextBox()
        Me.t4 = New System.Windows.Forms.TextBox()
        Me.t5 = New System.Windows.Forms.TextBox()
        Me.t6 = New System.Windows.Forms.TextBox()
        Me.t7 = New System.Windows.Forms.TextBox()
        Me.t8 = New System.Windows.Forms.TextBox()
        Me.t9 = New System.Windows.Forms.TextBox()
        Me.t10 = New System.Windows.Forms.TextBox()
        Me.t11 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.t12 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cb3 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.t13 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(14, 55)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(1309, 296)
        Me.dgv.TabIndex = 0
        '
        'cb1
        '
        Me.cb1.FormattingEnabled = True
        Me.cb1.Items.AddRange(New Object() {"PENDIENTE DESEMBOLSO", "DESEMBOLSADO"})
        Me.cb1.Location = New System.Drawing.Point(467, 13)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(174, 22)
        Me.cb1.TabIndex = 1
        '
        'cb2
        '
        Me.cb2.FormattingEnabled = True
        Me.cb2.Items.AddRange(New Object() {"CRONOGRAMAS", "ANEXOS"})
        Me.cb2.Location = New System.Drawing.Point(147, 13)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(140, 22)
        Me.cb2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo de Operacion:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(318, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Estado de la Operacion:"
        '
        't1
        '
        Me.t1.Enabled = False
        Me.t1.Location = New System.Drawing.Point(194, 29)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(215, 20)
        Me.t1.TabIndex = 5
        '
        't2
        '
        Me.t2.Enabled = False
        Me.t2.Location = New System.Drawing.Point(194, 56)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(215, 20)
        Me.t2.TabIndex = 6
        '
        't3
        '
        Me.t3.Enabled = False
        Me.t3.Location = New System.Drawing.Point(194, 84)
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(215, 20)
        Me.t3.TabIndex = 7
        '
        't4
        '
        Me.t4.Enabled = False
        Me.t4.Location = New System.Drawing.Point(194, 112)
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(215, 20)
        Me.t4.TabIndex = 8
        '
        't5
        '
        Me.t5.Enabled = False
        Me.t5.Location = New System.Drawing.Point(194, 140)
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(215, 20)
        Me.t5.TabIndex = 9
        '
        't6
        '
        Me.t6.Enabled = False
        Me.t6.Location = New System.Drawing.Point(194, 168)
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(215, 20)
        Me.t6.TabIndex = 10
        '
        't7
        '
        Me.t7.Enabled = False
        Me.t7.Location = New System.Drawing.Point(194, 196)
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(215, 20)
        Me.t7.TabIndex = 11
        '
        't8
        '
        Me.t8.Enabled = False
        Me.t8.Location = New System.Drawing.Point(780, 29)
        Me.t8.Name = "t8"
        Me.t8.Size = New System.Drawing.Size(254, 20)
        Me.t8.TabIndex = 12
        '
        't9
        '
        Me.t9.Enabled = False
        Me.t9.Location = New System.Drawing.Point(780, 57)
        Me.t9.Name = "t9"
        Me.t9.Size = New System.Drawing.Size(254, 20)
        Me.t9.TabIndex = 13
        '
        't10
        '
        Me.t10.Enabled = False
        Me.t10.Location = New System.Drawing.Point(780, 85)
        Me.t10.Name = "t10"
        Me.t10.Size = New System.Drawing.Size(254, 20)
        Me.t10.TabIndex = 14
        '
        't11
        '
        Me.t11.Enabled = False
        Me.t11.Location = New System.Drawing.Point(780, 113)
        Me.t11.Name = "t11"
        Me.t11.Size = New System.Drawing.Size(254, 20)
        Me.t11.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 14)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Codigo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 14)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Codigo de Cliente:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 14)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Monto Solicitado:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 14)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "% Comision Desembolso:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(174, 14)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Monto Comision Desembolso:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 171)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 14)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "% IGV:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 14)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Monto de IGV:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(589, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 14)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Monto de Prestamo:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(589, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 14)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "% de Interes:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(589, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 14)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Monto de Interes:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(589, 116)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(165, 14)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Fecha de Inicio de Prestamo:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(589, 144)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(182, 14)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Fecha de Termino de Prestamo:"
        '
        't12
        '
        Me.t12.Enabled = False
        Me.t12.Location = New System.Drawing.Point(780, 141)
        Me.t12.Name = "t12"
        Me.t12.Size = New System.Drawing.Size(254, 20)
        Me.t12.TabIndex = 28
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(589, 172)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 14)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Estado de Tesoreria:"
        '
        'cb3
        '
        Me.cb3.Enabled = False
        Me.cb3.FormattingEnabled = True
        Me.cb3.Items.AddRange(New Object() {"PENDIENTE DESEMBOLSO", "DESEMBOLSADO"})
        Me.cb3.Location = New System.Drawing.Point(780, 168)
        Me.cb3.Name = "cb3"
        Me.cb3.Size = New System.Drawing.Size(254, 22)
        Me.cb3.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.t13)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cb3)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.t12)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.t11)
        Me.GroupBox1.Controls.Add(Me.t10)
        Me.GroupBox1.Controls.Add(Me.t9)
        Me.GroupBox1.Controls.Add(Me.t8)
        Me.GroupBox1.Controls.Add(Me.t7)
        Me.GroupBox1.Controls.Add(Me.t6)
        Me.GroupBox1.Controls.Add(Me.t5)
        Me.GroupBox1.Controls.Add(Me.t4)
        Me.GroupBox1.Controls.Add(Me.t3)
        Me.GroupBox1.Controls.Add(Me.t2)
        Me.GroupBox1.Controls.Add(Me.t1)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 377)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1067, 269)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cronogramas"
        '
        't13
        '
        Me.t13.Enabled = False
        Me.t13.Location = New System.Drawing.Point(780, 197)
        Me.t13.Name = "t13"
        Me.t13.Size = New System.Drawing.Size(254, 20)
        Me.t13.TabIndex = 32
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(589, 201)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 14)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Banco Fondo:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(1172, 377)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 66)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "Actualizar Estado Desembolso"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(1172, 559)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 57)
        Me.Button2.TabIndex = 33
        Me.Button2.Text = "Generar Asientos Contables"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(1172, 449)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(87, 42)
        Me.Button3.TabIndex = 34
        Me.Button3.Text = "Saldos de Bancos"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(1172, 497)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(87, 56)
        Me.Button4.TabIndex = 35
        Me.Button4.Text = "Seleccionar Bancos Cliente"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(1172, 620)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(87, 25)
        Me.Button5.TabIndex = 36
        Me.Button5.Text = "Salir"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ofactoring.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(1223, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 37
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(780, 223)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(254, 20)
        Me.TextBox1.TabIndex = 34
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(589, 226)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 14)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Banco Cliente:"
        '
        'desembolsos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1337, 659)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cb2)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.dgv)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "desembolsos"
        Me.Text = "desembolsos"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents cb1 As ComboBox
    Friend WithEvents cb2 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents t1 As TextBox
    Friend WithEvents t2 As TextBox
    Friend WithEvents t3 As TextBox
    Friend WithEvents t4 As TextBox
    Friend WithEvents t5 As TextBox
    Friend WithEvents t6 As TextBox
    Friend WithEvents t7 As TextBox
    Friend WithEvents t8 As TextBox
    Friend WithEvents t9 As TextBox
    Friend WithEvents t10 As TextBox
    Friend WithEvents t11 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents t12 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cb3 As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents t13 As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label17 As Label
End Class
