<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tcambio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tcambio))
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.t1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.t2 = New System.Windows.Forms.TextBox()
        Me.t3 = New System.Windows.Forms.TextBox()
        Me.t4 = New System.Windows.Forms.TextBox()
        Me.t6 = New System.Windows.Forms.TextBox()
        Me.t5 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.t7 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.cb2 = New System.Windows.Forms.ComboBox()
        Me.cb3 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.gb1 = New System.Windows.Forms.GroupBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.sbs = New System.Windows.Forms.LinkLabel()
        Me.sunat = New System.Windows.Forms.LinkLabel()
        Me.Button7 = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp1
        '
        Me.dtp1.Enabled = False
        Me.dtp1.Location = New System.Drawing.Point(298, 22)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(200, 20)
        Me.dtp1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(605, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "SUNAT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        't1
        '
        Me.t1.Enabled = False
        Me.t1.Location = New System.Drawing.Point(97, 25)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(121, 20)
        Me.t1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Codigo:"
        '
        't2
        '
        Me.t2.Enabled = False
        Me.t2.Location = New System.Drawing.Point(97, 154)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(121, 20)
        Me.t2.TabIndex = 6
        '
        't3
        '
        Me.t3.Enabled = False
        Me.t3.Location = New System.Drawing.Point(97, 201)
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(121, 20)
        Me.t3.TabIndex = 7
        '
        't4
        '
        Me.t4.Enabled = False
        Me.t4.Location = New System.Drawing.Point(407, 158)
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(121, 20)
        Me.t4.TabIndex = 8
        '
        't6
        '
        Me.t6.Enabled = False
        Me.t6.Location = New System.Drawing.Point(298, 48)
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(100, 20)
        Me.t6.TabIndex = 10
        '
        't5
        '
        Me.t5.Enabled = False
        Me.t5.Location = New System.Drawing.Point(407, 201)
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(121, 20)
        Me.t5.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Moneda Origen:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Moneda Destino:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "TC Sunat:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "TV Sunat:"
        '
        't7
        '
        Me.t7.Enabled = False
        Me.t7.Location = New System.Drawing.Point(404, 48)
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(94, 20)
        Me.t7.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(353, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "TC SBS:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(353, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "TV SBS:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(252, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Fecha:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(304, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Entidad:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(253, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 21
        '
        'dgv
        '
        Me.dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(13, 249)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(701, 297)
        Me.dgv.TabIndex = 22
        '
        'cb1
        '
        Me.cb1.Enabled = False
        Me.cb1.FormattingEnabled = True
        Me.cb1.Location = New System.Drawing.Point(97, 70)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(121, 21)
        Me.cb1.TabIndex = 23
        '
        'cb2
        '
        Me.cb2.Enabled = False
        Me.cb2.FormattingEnabled = True
        Me.cb2.Location = New System.Drawing.Point(97, 109)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(121, 21)
        Me.cb2.TabIndex = 24
        '
        'cb3
        '
        Me.cb3.Enabled = False
        Me.cb3.FormattingEnabled = True
        Me.cb3.Location = New System.Drawing.Point(356, 88)
        Me.cb3.Name = "cb3"
        Me.cb3.Size = New System.Drawing.Size(121, 21)
        Me.cb3.TabIndex = 25
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(605, 85)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "Editar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(605, 53)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 27
        Me.Button3.Text = "SBS"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(605, 117)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 28
        Me.Button4.Text = "Buscar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(605, 149)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 29
        Me.Button5.Text = "Guardar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(605, 180)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 30
        Me.Button6.Text = "Exportar"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'gb1
        '
        Me.gb1.BackColor = System.Drawing.Color.White
        Me.gb1.BackgroundImage = Global.ofactoring.My.Resources.Resources.hoja
        Me.gb1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.gb1.Controls.Add(Me.Button9)
        Me.gb1.Controls.Add(Me.Button8)
        Me.gb1.Controls.Add(Me.sbs)
        Me.gb1.Controls.Add(Me.sunat)
        Me.gb1.Controls.Add(Me.cb3)
        Me.gb1.Controls.Add(Me.cb2)
        Me.gb1.Controls.Add(Me.cb1)
        Me.gb1.Controls.Add(Me.Label10)
        Me.gb1.Controls.Add(Me.Label9)
        Me.gb1.Controls.Add(Me.Label8)
        Me.gb1.Controls.Add(Me.Label7)
        Me.gb1.Controls.Add(Me.Label6)
        Me.gb1.Controls.Add(Me.t7)
        Me.gb1.Controls.Add(Me.Label5)
        Me.gb1.Controls.Add(Me.Label4)
        Me.gb1.Controls.Add(Me.Label3)
        Me.gb1.Controls.Add(Me.Label2)
        Me.gb1.Controls.Add(Me.t5)
        Me.gb1.Controls.Add(Me.t6)
        Me.gb1.Controls.Add(Me.t4)
        Me.gb1.Controls.Add(Me.t3)
        Me.gb1.Controls.Add(Me.t2)
        Me.gb1.Controls.Add(Me.Label1)
        Me.gb1.Controls.Add(Me.t1)
        Me.gb1.Controls.Add(Me.dtp1)
        Me.gb1.ForeColor = System.Drawing.Color.Blue
        Me.gb1.Location = New System.Drawing.Point(13, 10)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(541, 233)
        Me.gb1.TabIndex = 31
        Me.gb1.TabStop = False
        Me.gb1.Text = "Registro de Tipo de Cambio"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(483, 86)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(18, 23)
        Me.Button9.TabIndex = 29
        Me.Button9.Text = "R"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(224, 86)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(18, 23)
        Me.Button8.TabIndex = 28
        Me.Button8.Text = "R"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'sbs
        '
        Me.sbs.AutoSize = True
        Me.sbs.ImageKey = "(ninguno)"
        Me.sbs.Location = New System.Drawing.Point(414, 183)
        Me.sbs.Name = "sbs"
        Me.sbs.Size = New System.Drawing.Size(98, 13)
        Me.sbs.TabIndex = 27
        Me.sbs.TabStop = True
        Me.sbs.Text = "Consulta Web SBS"
        '
        'sunat
        '
        Me.sunat.AutoSize = True
        Me.sunat.Location = New System.Drawing.Point(104, 181)
        Me.sunat.Name = "sunat"
        Me.sunat.Size = New System.Drawing.Size(105, 13)
        Me.sunat.TabIndex = 26
        Me.sunat.TabStop = True
        Me.sunat.Text = "Consulta Web Sunat"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(605, 213)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 32
        Me.Button7.Text = "Eliminar"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'tcambio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(727, 558)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Button1)
        Me.ForeColor = System.Drawing.Color.Blue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "tcambio"
        Me.Text = "Tipo De Cambio"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents t1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents t2 As TextBox
    Friend WithEvents t3 As TextBox
    Friend WithEvents t4 As TextBox
    Friend WithEvents t6 As TextBox
    Friend WithEvents t5 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents t7 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dgv As DataGridView
    Friend WithEvents cb1 As ComboBox
    Friend WithEvents cb2 As ComboBox
    Friend WithEvents cb3 As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents Button7 As Button
    Friend WithEvents sbs As LinkLabel
    Friend WithEvents sunat As LinkLabel
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
End Class
