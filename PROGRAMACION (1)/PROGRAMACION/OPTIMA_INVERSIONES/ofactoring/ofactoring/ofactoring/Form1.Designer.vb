<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class param_asientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(param_asientos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.t1 = New System.Windows.Forms.TextBox()
        Me.t3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.t2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.t4 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.COD_ASIENTO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TIP_OPERACION = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CUENTA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NOM_CUENTA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GLOSA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.t5 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccionar Tipo de Operacion"
        '
        'cb1
        '
        Me.cb1.Enabled = False
        Me.cb1.FormattingEnabled = True
        Me.cb1.Items.AddRange(New Object() {"CRONOGRAMA", "ANEXO", "FACTURACION", "NOTA DE DEBITO", "NOTA DE CREDITO"})
        Me.cb1.Location = New System.Drawing.Point(185, 52)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(121, 22)
        Me.cb1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Seleccionar cuenta Contable:"
        '
        't1
        '
        Me.t1.Enabled = False
        Me.t1.Location = New System.Drawing.Point(185, 84)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(121, 20)
        Me.t1.TabIndex = 3
        '
        't3
        '
        Me.t3.Enabled = False
        Me.t3.Location = New System.Drawing.Point(185, 140)
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(322, 20)
        Me.t3.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Glosa:"
        '
        't2
        '
        Me.t2.Enabled = False
        Me.t2.Location = New System.Drawing.Point(185, 112)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(322, 20)
        Me.t2.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Nombre cuenta Contable:"
        '
        't4
        '
        Me.t4.Enabled = False
        Me.t4.Location = New System.Drawing.Point(185, 24)
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(121, 20)
        Me.t4.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Codigo de Asiento:"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.COD_ASIENTO, Me.TIP_OPERACION, Me.CUENTA, Me.NOM_CUENTA, Me.GLOSA})
        Me.ListView1.Enabled = False
        Me.ListView1.Location = New System.Drawing.Point(12, 233)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(735, 236)
        Me.ListView1.TabIndex = 13
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'COD_ASIENTO
        '
        Me.COD_ASIENTO.Text = "CODIGO DE ASIENTO"
        Me.COD_ASIENTO.Width = 121
        '
        'TIP_OPERACION
        '
        Me.TIP_OPERACION.Text = "TIPO DE OPERACION"
        Me.TIP_OPERACION.Width = 122
        '
        'CUENTA
        '
        Me.CUENTA.Text = "CUENTA CONTABLE"
        Me.CUENTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CUENTA.Width = 129
        '
        'NOM_CUENTA
        '
        Me.NOM_CUENTA.Text = "NOMBRE DE CUENTA"
        Me.NOM_CUENTA.Width = 129
        '
        'GLOSA
        '
        Me.GLOSA.Text = "GLOSA DE CUENTA"
        Me.GLOSA.Width = 229
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(672, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Nuevo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(672, 59)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Editar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(672, 88)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Buscar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Enabled = False
        Me.dgv.Location = New System.Drawing.Point(12, 264)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(735, 236)
        Me.dgv.TabIndex = 17
        '
        't5
        '
        Me.t5.Enabled = False
        Me.t5.Location = New System.Drawing.Point(199, 207)
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(322, 20)
        Me.t5.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 14)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Filtrar con Cod Asiento:"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(672, 119)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "Guardar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(672, 148)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 21
        Me.Button5.Text = "Eliminar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.t4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.t2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.t3)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.t1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cb1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(529, 186)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'param_asientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(759, 481)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.t5)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "param_asientos"
        Me.Text = "Form1"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cb1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents t1 As TextBox
    Friend WithEvents t3 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents t2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents t4 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents COD_ASIENTO As ColumnHeader
    Friend WithEvents TIP_OPERACION As ColumnHeader
    Friend WithEvents CUENTA As ColumnHeader
    Friend WithEvents NOM_CUENTA As ColumnHeader
    Friend WithEvents GLOSA As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents t5 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
