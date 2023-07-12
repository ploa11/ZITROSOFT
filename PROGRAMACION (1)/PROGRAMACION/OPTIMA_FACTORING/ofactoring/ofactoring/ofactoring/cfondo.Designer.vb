<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cfondo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cfondo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.btnCrearBase = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.t1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.t2 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.t3 = New System.Windows.Forms.TextBox()
        Me.t4 = New System.Windows.Forms.TextBox()
        Me.t5 = New System.Windows.Forms.TextBox()
        Me.CB3 = New System.Windows.Forms.ComboBox()
        Me.DTP1 = New System.Windows.Forms.DateTimePicker()
        Me.DTP2 = New System.Windows.Forms.DateTimePicker()
        Me.t8 = New System.Windows.Forms.TextBox()
        Me.DTP3 = New System.Windows.Forms.DateTimePicker()
        Me.DTP4 = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.t6 = New System.Windows.Forms.TextBox()
        Me.t7 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cb4 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(17, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre de Servidor:"
        '
        'cb1
        '
        Me.cb1.Enabled = False
        Me.cb1.FormattingEnabled = True
        Me.cb1.Location = New System.Drawing.Point(144, 21)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(155, 21)
        Me.cb1.TabIndex = 1
        '
        'btnCrearBase
        '
        Me.btnCrearBase.BackColor = System.Drawing.Color.White
        Me.btnCrearBase.ForeColor = System.Drawing.Color.Blue
        Me.btnCrearBase.Location = New System.Drawing.Point(703, 10)
        Me.btnCrearBase.Name = "btnCrearBase"
        Me.btnCrearBase.Size = New System.Drawing.Size(75, 35)
        Me.btnCrearBase.TabIndex = 13
        Me.btnCrearBase.Text = "NUEVO FONDO"
        Me.btnCrearBase.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(17, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Nombre del Fondo:"
        '
        't1
        '
        Me.t1.Enabled = False
        Me.t1.Location = New System.Drawing.Point(144, 57)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(155, 20)
        Me.t1.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Location = New System.Drawing.Point(703, 93)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 35)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "BUSCAR FONDO"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(17, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Codigo de Fondo:"
        '
        't2
        '
        Me.t2.Enabled = False
        Me.t2.Location = New System.Drawing.Point(144, 96)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(155, 20)
        Me.t2.TabIndex = 18
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.ForeColor = System.Drawing.Color.Blue
        Me.Button2.Location = New System.Drawing.Point(703, 54)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 35)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "EDITAR FONDO"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.ForeColor = System.Drawing.Color.Blue
        Me.Button3.Location = New System.Drawing.Point(703, 240)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 41)
        Me.Button3.TabIndex = 20
        Me.Button3.Text = "ELIMINAR FONDO"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.ForeColor = System.Drawing.Color.Blue
        Me.Button4.Location = New System.Drawing.Point(703, 193)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 41)
        Me.Button4.TabIndex = 21
        Me.Button4.Text = "CREAR BD FONDO"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.ForeColor = System.Drawing.Color.Blue
        Me.Button5.Location = New System.Drawing.Point(703, 134)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 53)
        Me.Button5.TabIndex = 22
        Me.Button5.Text = "GUARDAR  DATOS DE FONDO"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'dgv
        '
        Me.dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 312)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(766, 233)
        Me.dgv.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(17, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Moneda:"
        '
        'cb2
        '
        Me.cb2.Enabled = False
        Me.cb2.FormattingEnabled = True
        Me.cb2.Location = New System.Drawing.Point(144, 128)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(127, 21)
        Me.cb2.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(17, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Monto Minimo: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(17, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Monto Maximo: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(17, 220)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Patrimonio Actual:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(308, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Unidad de Negocio:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(308, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Fecha de Creacion:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(308, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(189, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Fecha de Inscripcion  de Sunat:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(308, 133)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Numero de Ruc:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(308, 193)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(192, 13)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Fecha de Inicio de Operaciones:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(308, 223)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(202, 13)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Fecha de termino de Operaciones:"
        '
        't3
        '
        Me.t3.Enabled = False
        Me.t3.Location = New System.Drawing.Point(144, 159)
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(155, 20)
        Me.t3.TabIndex = 36
        '
        't4
        '
        Me.t4.Enabled = False
        Me.t4.Location = New System.Drawing.Point(144, 188)
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(155, 20)
        Me.t4.TabIndex = 37
        '
        't5
        '
        Me.t5.Enabled = False
        Me.t5.Location = New System.Drawing.Point(144, 216)
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(155, 20)
        Me.t5.TabIndex = 38
        '
        'CB3
        '
        Me.CB3.Enabled = False
        Me.CB3.FormattingEnabled = True
        Me.CB3.Location = New System.Drawing.Point(513, 18)
        Me.CB3.Name = "CB3"
        Me.CB3.Size = New System.Drawing.Size(134, 21)
        Me.CB3.TabIndex = 39
        '
        'DTP1
        '
        Me.DTP1.Enabled = False
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP1.Location = New System.Drawing.Point(513, 55)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(95, 20)
        Me.DTP1.TabIndex = 40
        '
        'DTP2
        '
        Me.DTP2.Enabled = False
        Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP2.Location = New System.Drawing.Point(513, 94)
        Me.DTP2.Name = "DTP2"
        Me.DTP2.Size = New System.Drawing.Size(95, 20)
        Me.DTP2.TabIndex = 41
        '
        't8
        '
        Me.t8.Enabled = False
        Me.t8.Location = New System.Drawing.Point(513, 125)
        Me.t8.Name = "t8"
        Me.t8.Size = New System.Drawing.Size(164, 20)
        Me.t8.TabIndex = 42
        '
        'DTP3
        '
        Me.DTP3.Enabled = False
        Me.DTP3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP3.Location = New System.Drawing.Point(513, 187)
        Me.DTP3.Name = "DTP3"
        Me.DTP3.Size = New System.Drawing.Size(95, 20)
        Me.DTP3.TabIndex = 43
        '
        'DTP4
        '
        Me.DTP4.Enabled = False
        Me.DTP4.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP4.Location = New System.Drawing.Point(513, 217)
        Me.DTP4.Name = "DTP4"
        Me.DTP4.Size = New System.Drawing.Size(95, 20)
        Me.DTP4.TabIndex = 44
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(17, 254)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 13)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Valor Cuota Nominal:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(17, 281)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 13)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Valor Cuota Actual:"
        '
        't6
        '
        Me.t6.Enabled = False
        Me.t6.Location = New System.Drawing.Point(144, 250)
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(155, 20)
        Me.t6.TabIndex = 47
        '
        't7
        '
        Me.t7.Enabled = False
        Me.t7.Location = New System.Drawing.Point(144, 277)
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(155, 20)
        Me.t7.TabIndex = 48
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(308, 163)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Gestion:"
        '
        'cb4
        '
        Me.cb4.Enabled = False
        Me.cb4.FormattingEnabled = True
        Me.cb4.Location = New System.Drawing.Point(513, 155)
        Me.cb4.Name = "cb4"
        Me.cb4.Size = New System.Drawing.Size(121, 21)
        Me.cb4.TabIndex = 50
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Enabled = False
        Me.Button6.ForeColor = System.Drawing.Color.Blue
        Me.Button6.Location = New System.Drawing.Point(639, 154)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(24, 23)
        Me.Button6.TabIndex = 51
        Me.Button6.Text = "R"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.Enabled = False
        Me.Button7.Location = New System.Drawing.Point(277, 128)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(20, 21)
        Me.Button7.TabIndex = 52
        Me.Button7.Text = "R"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.Enabled = False
        Me.Button8.ForeColor = System.Drawing.Color.Blue
        Me.Button8.Location = New System.Drawing.Point(653, 16)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(24, 23)
        Me.Button8.TabIndex = 53
        Me.Button8.Text = "R"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'cfondo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(790, 557)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.cb4)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.t7)
        Me.Controls.Add(Me.t6)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DTP4)
        Me.Controls.Add(Me.DTP3)
        Me.Controls.Add(Me.t8)
        Me.Controls.Add(Me.DTP2)
        Me.Controls.Add(Me.DTP1)
        Me.Controls.Add(Me.CB3)
        Me.Controls.Add(Me.t5)
        Me.Controls.Add(Me.t4)
        Me.Controls.Add(Me.t3)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cb2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.t2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.t1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCrearBase)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "cfondo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Creacion de Fondo"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cb1 As ComboBox
    Friend WithEvents btnCrearBase As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents t1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents t2 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents cb2 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents t3 As TextBox
    Friend WithEvents t4 As TextBox
    Friend WithEvents t5 As TextBox
    Friend WithEvents CB3 As ComboBox
    Friend WithEvents DTP1 As DateTimePicker
    Friend WithEvents DTP2 As DateTimePicker
    Friend WithEvents t8 As TextBox
    Friend WithEvents DTP3 As DateTimePicker
    Friend WithEvents DTP4 As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents t6 As TextBox
    Friend WithEvents t7 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cb4 As ComboBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
End Class
