﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tcliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tcliente))
        Me.Button4 = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.t1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.t2 = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(270, 223)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(87, 23)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Eliminar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(10, 263)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(347, 168)
        Me.dgv.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(124, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(202, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "REGISTRO DE TIPO DE CLIENTE"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(270, 136)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(87, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Modificar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(270, 165)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Buscar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(270, 103)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Nuevo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        't1
        '
        Me.t1.Enabled = False
        Me.t1.Location = New System.Drawing.Point(127, 145)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(124, 20)
        Me.t1.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Codigo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Tipo de Cliente:"
        '
        't2
        '
        Me.t2.Enabled = False
        Me.t2.Location = New System.Drawing.Point(127, 178)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(124, 20)
        Me.t2.TabIndex = 17
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(270, 194)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(87, 23)
        Me.Button5.TabIndex = 18
        Me.Button5.Text = "Guardar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'tcliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.ofactoring.My.Resources.Resources.icono_programa
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(369, 443)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.t2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.t1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Blue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "tcliente"
        Me.Text = "TIPO DE CLIENTE"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button4 As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents t1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents t2 As TextBox
    Friend WithEvents Button5 As Button
End Class
