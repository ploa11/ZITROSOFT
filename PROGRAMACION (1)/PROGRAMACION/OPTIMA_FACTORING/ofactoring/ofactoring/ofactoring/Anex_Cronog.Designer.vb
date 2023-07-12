<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Anex_Cronog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Anex_Cronog))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.t1 = New System.Windows.Forms.TextBox()
        Me.t2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.t5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.t6 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.t7 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.t8 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.t9 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.t10 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.t11 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.t12 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cb2 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cb3 = New System.Windows.Forms.ComboBox()
        Me.t13 = New System.Windows.Forms.TextBox()
        Me.dtp3 = New System.Windows.Forms.DateTimePicker()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(25, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo:"
        '
        't1
        '
        Me.t1.Enabled = False
        Me.t1.Location = New System.Drawing.Point(261, 88)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(121, 20)
        Me.t1.TabIndex = 1
        '
        't2
        '
        Me.t2.Enabled = False
        Me.t2.Location = New System.Drawing.Point(261, 116)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(121, 20)
        Me.t2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(25, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Codigo de Cliente:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(25, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tipo de Operacion:"
        '
        'cb1
        '
        Me.cb1.Enabled = False
        Me.cb1.FormattingEnabled = True
        Me.cb1.Items.AddRange(New Object() {"Cronograma", "Anexo"})
        Me.cb1.Location = New System.Drawing.Point(261, 146)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(121, 21)
        Me.cb1.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(25, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Monto Solicitado:"
        '
        't5
        '
        Me.t5.Enabled = False
        Me.t5.Location = New System.Drawing.Point(261, 174)
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(121, 20)
        Me.t5.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(25, 203)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(234, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Procentaje de Comision de Desembolso:"
        '
        't6
        '
        Me.t6.Enabled = False
        Me.t6.Location = New System.Drawing.Point(261, 200)
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(37, 20)
        Me.t6.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(304, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(25, 229)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(190, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Monto Comision de Desembolso:"
        '
        't7
        '
        Me.t7.Enabled = False
        Me.t7.Location = New System.Drawing.Point(261, 226)
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(121, 20)
        Me.t7.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(442, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(217, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Impuesto General a las Ventas (IGV):"
        '
        't8
        '
        Me.t8.Enabled = False
        Me.t8.Location = New System.Drawing.Point(703, 84)
        Me.t8.Name = "t8"
        Me.t8.Size = New System.Drawing.Size(37, 20)
        Me.t8.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(442, 112)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(256, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Monto Impuesto General a las Ventas (IGV):"
        '
        't9
        '
        Me.t9.Enabled = False
        Me.t9.Location = New System.Drawing.Point(703, 112)
        Me.t9.Name = "t9"
        Me.t9.Size = New System.Drawing.Size(121, 20)
        Me.t9.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(746, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "%"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(442, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Monto a Financiar:"
        '
        't10
        '
        Me.t10.Enabled = False
        Me.t10.Location = New System.Drawing.Point(703, 138)
        Me.t10.Name = "t10"
        Me.t10.Size = New System.Drawing.Size(121, 20)
        Me.t10.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(746, 170)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "%"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(442, 167)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(133, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Porcentaje de Interes:"
        '
        't11
        '
        Me.t11.Enabled = False
        Me.t11.Location = New System.Drawing.Point(703, 167)
        Me.t11.Name = "t11"
        Me.t11.Size = New System.Drawing.Size(37, 20)
        Me.t11.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(442, 193)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(103, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Monto de Interes"
        '
        't12
        '
        Me.t12.Enabled = False
        Me.t12.Location = New System.Drawing.Point(703, 193)
        Me.t12.Name = "t12"
        Me.t12.Size = New System.Drawing.Size(121, 20)
        Me.t12.TabIndex = 27
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(442, 222)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(173, 13)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "Fecha de Inicio de Prestamo:"
        '
        'dtp1
        '
        Me.dtp1.Enabled = False
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(703, 222)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(121, 20)
        Me.dtp1.TabIndex = 30
        '
        'dtp2
        '
        Me.dtp2.Enabled = False
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(703, 248)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(121, 20)
        Me.dtp2.TabIndex = 32
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(442, 248)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(159, 13)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "Fecha de Fin de Prestamo:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(442, 278)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 13)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "Gestion:"
        '
        'cb2
        '
        Me.cb2.Enabled = False
        Me.cb2.FormattingEnabled = True
        Me.cb2.Items.AddRange(New Object() {"Cronograma", "Anexo"})
        Me.cb2.Location = New System.Drawing.Point(703, 274)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(121, 21)
        Me.cb2.TabIndex = 34
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Location = New System.Drawing.Point(851, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Nuevo"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.ForeColor = System.Drawing.Color.Blue
        Me.Button2.Location = New System.Drawing.Point(851, 94)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "Editar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.ForeColor = System.Drawing.Color.Blue
        Me.Button3.Location = New System.Drawing.Point(851, 123)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 37
        Me.Button3.Text = "Buscar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.ForeColor = System.Drawing.Color.Blue
        Me.Button4.Location = New System.Drawing.Point(851, 154)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 38
        Me.Button4.Text = "Filtrar"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.ForeColor = System.Drawing.Color.Blue
        Me.Button5.Location = New System.Drawing.Point(851, 301)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 39
        Me.Button5.Text = "Eliminar"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'dgv
        '
        Me.dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 330)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(914, 337)
        Me.dgv.TabIndex = 40
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(26, 266)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 13)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Filtrar por:"
        '
        'cb3
        '
        Me.cb3.Enabled = False
        Me.cb3.FormattingEnabled = True
        Me.cb3.Items.AddRange(New Object() {"Cronograma", "Anexo"})
        Me.cb3.Location = New System.Drawing.Point(93, 264)
        Me.cb3.Name = "cb3"
        Me.cb3.Size = New System.Drawing.Size(88, 21)
        Me.cb3.TabIndex = 42
        '
        't13
        '
        Me.t13.Enabled = False
        Me.t13.Location = New System.Drawing.Point(93, 291)
        Me.t13.Name = "t13"
        Me.t13.Size = New System.Drawing.Size(284, 20)
        Me.t13.TabIndex = 43
        '
        'dtp3
        '
        Me.dtp3.Enabled = False
        Me.dtp3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp3.Location = New System.Drawing.Point(187, 264)
        Me.dtp3.Name = "dtp3"
        Me.dtp3.Size = New System.Drawing.Size(121, 20)
        Me.dtp3.TabIndex = 44
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Enabled = False
        Me.Button6.ForeColor = System.Drawing.Color.Blue
        Me.Button6.Location = New System.Drawing.Point(851, 212)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 45
        Me.Button6.Text = "Cuotas"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.ForeColor = System.Drawing.Color.Blue
        Me.Button7.Location = New System.Drawing.Point(851, 183)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 46
        Me.Button7.Text = "Guardar"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.ForeColor = System.Drawing.Color.Blue
        Me.Button8.Location = New System.Drawing.Point(388, 116)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(21, 20)
        Me.Button8.TabIndex = 47
        Me.Button8.Text = "B"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.White
        Me.Button9.ForeColor = System.Drawing.Color.Blue
        Me.Button9.Location = New System.Drawing.Point(851, 241)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 54)
        Me.Button9.TabIndex = 48
        Me.Button9.Text = "Revision de Comision de Desembolso"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Anex_Cronog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.ofactoring.My.Resources.Resources.icono_programa
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(938, 679)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.dtp3)
        Me.Controls.Add(Me.t13)
        Me.Controls.Add(Me.cb3)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cb2)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.dtp2)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.t12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.t11)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.t10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.t9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.t8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.t7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.t6)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.t5)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.t2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.t1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Anex_Cronog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Creacion de Cronograma:"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents t1 As TextBox
    Friend WithEvents t2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cb1 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents t5 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents t6 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents t7 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents t8 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents t9 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents t10 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents t11 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents t12 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents cb2 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents Label20 As Label
    Friend WithEvents cb3 As ComboBox
    Friend WithEvents t13 As TextBox
    Friend WithEvents dtp3 As DateTimePicker
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
End Class
