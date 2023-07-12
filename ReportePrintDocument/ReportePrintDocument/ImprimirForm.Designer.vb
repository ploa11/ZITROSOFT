<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImprimirForm))
        Me.lbCodigo = New System.Windows.Forms.Label()
        Me.lbEstudiante = New System.Windows.Forms.Label()
        Me.lbFecha = New System.Windows.Forms.Label()
        Me.LabelCodigo = New System.Windows.Forms.Label()
        Me.LabelEstudiante = New System.Windows.Forms.Label()
        Me.LabelFecha = New System.Windows.Forms.Label()
        Me.LabelTelefono = New System.Windows.Forms.Label()
        Me.LabelDireccion = New System.Windows.Forms.Label()
        Me.LabelEmpresa = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.materia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.primer_parcial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.segundo_parcial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.examen_final = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.calificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbNumeroPagina = New System.Windows.Forms.Label()
        Me.LabelPagina = New System.Windows.Forms.Label()
        Me.lbPromedio = New System.Windows.Forms.Label()
        Me.lbCursadas = New System.Windows.Forms.Label()
        Me.LabelPromedio = New System.Windows.Forms.Label()
        Me.LabelCursadas = New System.Windows.Forms.Label()
        Me.Punto5 = New System.Windows.Forms.Label()
        Me.Punto4 = New System.Windows.Forms.Label()
        Me.Punto3 = New System.Windows.Forms.Label()
        Me.Punto2 = New System.Windows.Forms.Label()
        Me.Punto1 = New System.Windows.Forms.Label()
        Me.LineaTop = New System.Windows.Forms.Label()
        Me.LineaFondo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbCodigo
        '
        Me.lbCodigo.AutoSize = True
        Me.lbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCodigo.Location = New System.Drawing.Point(159, 232)
        Me.lbCodigo.Name = "lbCodigo"
        Me.lbCodigo.Size = New System.Drawing.Size(18, 20)
        Me.lbCodigo.TabIndex = 26
        Me.lbCodigo.Text = "0"
        '
        'lbEstudiante
        '
        Me.lbEstudiante.AutoSize = True
        Me.lbEstudiante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEstudiante.Location = New System.Drawing.Point(159, 207)
        Me.lbEstudiante.Name = "lbEstudiante"
        Me.lbEstudiante.Size = New System.Drawing.Size(18, 20)
        Me.lbEstudiante.TabIndex = 25
        Me.lbEstudiante.Text = "0"
        '
        'lbFecha
        '
        Me.lbFecha.AutoSize = True
        Me.lbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFecha.Location = New System.Drawing.Point(159, 182)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(18, 20)
        Me.lbFecha.TabIndex = 24
        Me.lbFecha.Text = "0"
        '
        'LabelCodigo
        '
        Me.LabelCodigo.AutoSize = True
        Me.LabelCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCodigo.Location = New System.Drawing.Point(48, 232)
        Me.LabelCodigo.Name = "LabelCodigo"
        Me.LabelCodigo.Size = New System.Drawing.Size(63, 20)
        Me.LabelCodigo.TabIndex = 23
        Me.LabelCodigo.Text = "Codigo:"
        '
        'LabelEstudiante
        '
        Me.LabelEstudiante.AutoSize = True
        Me.LabelEstudiante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEstudiante.Location = New System.Drawing.Point(48, 207)
        Me.LabelEstudiante.Name = "LabelEstudiante"
        Me.LabelEstudiante.Size = New System.Drawing.Size(90, 20)
        Me.LabelEstudiante.TabIndex = 22
        Me.LabelEstudiante.Text = "Estudiante:"
        '
        'LabelFecha
        '
        Me.LabelFecha.AutoSize = True
        Me.LabelFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFecha.Location = New System.Drawing.Point(48, 182)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(58, 20)
        Me.LabelFecha.TabIndex = 21
        Me.LabelFecha.Text = "Fecha:"
        '
        'LabelTelefono
        '
        Me.LabelTelefono.AutoSize = True
        Me.LabelTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTelefono.Location = New System.Drawing.Point(314, 102)
        Me.LabelTelefono.Name = "LabelTelefono"
        Me.LabelTelefono.Size = New System.Drawing.Size(255, 25)
        Me.LabelTelefono.TabIndex = 20
        Me.LabelTelefono.Text = "Teléfono: (879) 558-9966"
        '
        'LabelDireccion
        '
        Me.LabelDireccion.AutoSize = True
        Me.LabelDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDireccion.Location = New System.Drawing.Point(301, 77)
        Me.LabelDireccion.Name = "LabelDireccion"
        Me.LabelDireccion.Size = New System.Drawing.Size(281, 25)
        Me.LabelDireccion.TabIndex = 19
        Me.LabelDireccion.Text = "Avenida Los Martires #8765"
        '
        'LabelEmpresa
        '
        Me.LabelEmpresa.AutoSize = True
        Me.LabelEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEmpresa.Location = New System.Drawing.Point(193, 44)
        Me.LabelEmpresa.Name = "LabelEmpresa"
        Me.LabelEmpresa.Size = New System.Drawing.Size(525, 33)
        Me.LabelEmpresa.TabIndex = 18
        Me.LabelEmpresa.Text = "ESCUELA SECUNDARIA LA CAOBA"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.nombre, Me.materia, Me.primer_parcial, Me.segundo_parcial, Me.examen_final, Me.calificacion})
        Me.DataGridView1.Location = New System.Drawing.Point(35, 324)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(715, 128)
        Me.DataGridView1.TabIndex = 27
        '
        'codigo
        '
        Me.codigo.DataPropertyName = "codigo"
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Visible = False
        '
        'nombre
        '
        Me.nombre.DataPropertyName = "nombre"
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Visible = False
        '
        'materia
        '
        Me.materia.DataPropertyName = "materia"
        Me.materia.FillWeight = 203.0457!
        Me.materia.HeaderText = "Materia"
        Me.materia.Name = "materia"
        Me.materia.ReadOnly = True
        '
        'primer_parcial
        '
        Me.primer_parcial.DataPropertyName = "primer_parcial"
        Me.primer_parcial.FillWeight = 74.23858!
        Me.primer_parcial.HeaderText = "Primer_parcial"
        Me.primer_parcial.Name = "primer_parcial"
        Me.primer_parcial.ReadOnly = True
        '
        'segundo_parcial
        '
        Me.segundo_parcial.DataPropertyName = "segundo_parcial"
        Me.segundo_parcial.FillWeight = 74.23858!
        Me.segundo_parcial.HeaderText = "Segundo_parcial"
        Me.segundo_parcial.Name = "segundo_parcial"
        Me.segundo_parcial.ReadOnly = True
        '
        'examen_final
        '
        Me.examen_final.DataPropertyName = "examen_final"
        Me.examen_final.FillWeight = 74.23858!
        Me.examen_final.HeaderText = "Examen_final"
        Me.examen_final.Name = "examen_final"
        Me.examen_final.ReadOnly = True
        '
        'calificacion
        '
        Me.calificacion.DataPropertyName = "calificacion_final"
        Me.calificacion.FillWeight = 74.23858!
        Me.calificacion.HeaderText = "Calificacion_final"
        Me.calificacion.Name = "calificacion"
        Me.calificacion.ReadOnly = True
        '
        'lbNumeroPagina
        '
        Me.lbNumeroPagina.AutoSize = True
        Me.lbNumeroPagina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNumeroPagina.Location = New System.Drawing.Point(727, 570)
        Me.lbNumeroPagina.Name = "lbNumeroPagina"
        Me.lbNumeroPagina.Size = New System.Drawing.Size(18, 20)
        Me.lbNumeroPagina.TabIndex = 33
        Me.lbNumeroPagina.Text = "0"
        '
        'LabelPagina
        '
        Me.LabelPagina.AutoSize = True
        Me.LabelPagina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPagina.Location = New System.Drawing.Point(667, 570)
        Me.LabelPagina.Name = "LabelPagina"
        Me.LabelPagina.Size = New System.Drawing.Size(54, 20)
        Me.LabelPagina.TabIndex = 32
        Me.LabelPagina.Text = "Pág. #"
        '
        'lbPromedio
        '
        Me.lbPromedio.AutoSize = True
        Me.lbPromedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPromedio.Location = New System.Drawing.Point(611, 503)
        Me.lbPromedio.Name = "lbPromedio"
        Me.lbPromedio.Size = New System.Drawing.Size(18, 20)
        Me.lbPromedio.TabIndex = 31
        Me.lbPromedio.Text = "0"
        '
        'lbCursadas
        '
        Me.lbCursadas.AutoSize = True
        Me.lbCursadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCursadas.Location = New System.Drawing.Point(611, 478)
        Me.lbCursadas.Name = "lbCursadas"
        Me.lbCursadas.Size = New System.Drawing.Size(18, 20)
        Me.lbCursadas.TabIndex = 30
        Me.lbCursadas.Text = "0"
        '
        'LabelPromedio
        '
        Me.LabelPromedio.AutoSize = True
        Me.LabelPromedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPromedio.Location = New System.Drawing.Point(461, 503)
        Me.LabelPromedio.Name = "LabelPromedio"
        Me.LabelPromedio.Size = New System.Drawing.Size(80, 20)
        Me.LabelPromedio.TabIndex = 29
        Me.LabelPromedio.Text = "Promedio:"
        '
        'LabelCursadas
        '
        Me.LabelCursadas.AutoSize = True
        Me.LabelCursadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCursadas.Location = New System.Drawing.Point(461, 478)
        Me.LabelCursadas.Name = "LabelCursadas"
        Me.LabelCursadas.Size = New System.Drawing.Size(143, 20)
        Me.LabelCursadas.TabIndex = 28
        Me.LabelCursadas.Text = "Materias cursadas:"
        '
        'Punto5
        '
        Me.Punto5.AutoSize = True
        Me.Punto5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Punto5.ForeColor = System.Drawing.Color.Blue
        Me.Punto5.Location = New System.Drawing.Point(638, 295)
        Me.Punto5.Name = "Punto5"
        Me.Punto5.Size = New System.Drawing.Size(23, 16)
        Me.Punto5.TabIndex = 38
        Me.Punto5.Text = "P5"
        '
        'Punto4
        '
        Me.Punto4.AutoSize = True
        Me.Punto4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Punto4.ForeColor = System.Drawing.Color.Blue
        Me.Punto4.Location = New System.Drawing.Point(531, 295)
        Me.Punto4.Name = "Punto4"
        Me.Punto4.Size = New System.Drawing.Size(23, 16)
        Me.Punto4.TabIndex = 37
        Me.Punto4.Text = "P4"
        '
        'Punto3
        '
        Me.Punto3.AutoSize = True
        Me.Punto3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Punto3.ForeColor = System.Drawing.Color.Blue
        Me.Punto3.Location = New System.Drawing.Point(423, 295)
        Me.Punto3.Name = "Punto3"
        Me.Punto3.Size = New System.Drawing.Size(23, 16)
        Me.Punto3.TabIndex = 36
        Me.Punto3.Text = "P3"
        '
        'Punto2
        '
        Me.Punto2.AutoSize = True
        Me.Punto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Punto2.ForeColor = System.Drawing.Color.Blue
        Me.Punto2.Location = New System.Drawing.Point(316, 295)
        Me.Punto2.Name = "Punto2"
        Me.Punto2.Size = New System.Drawing.Size(23, 16)
        Me.Punto2.TabIndex = 35
        Me.Punto2.Text = "P2"
        '
        'Punto1
        '
        Me.Punto1.AutoSize = True
        Me.Punto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Punto1.ForeColor = System.Drawing.Color.Blue
        Me.Punto1.Location = New System.Drawing.Point(43, 295)
        Me.Punto1.Name = "Punto1"
        Me.Punto1.Size = New System.Drawing.Size(23, 16)
        Me.Punto1.TabIndex = 34
        Me.Punto1.Text = "P1"
        '
        'LineaTop
        '
        Me.LineaTop.AutoSize = True
        Me.LineaTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LineaTop.ForeColor = System.Drawing.Color.Blue
        Me.LineaTop.Location = New System.Drawing.Point(32, 273)
        Me.LineaTop.Name = "LineaTop"
        Me.LineaTop.Size = New System.Drawing.Size(719, 16)
        Me.LineaTop.TabIndex = 39
        Me.LineaTop.Text = "---------------------------------------------------------------------------------" &
    "--------------------------------------------------------------------------------" &
    "-----------------"
        '
        'LineaFondo
        '
        Me.LineaFondo.AutoSize = True
        Me.LineaFondo.BackColor = System.Drawing.Color.Transparent
        Me.LineaFondo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LineaFondo.ForeColor = System.Drawing.Color.Blue
        Me.LineaFondo.Location = New System.Drawing.Point(30, 458)
        Me.LineaFondo.Name = "LineaFondo"
        Me.LineaFondo.Size = New System.Drawing.Size(719, 16)
        Me.LineaFondo.TabIndex = 40
        Me.LineaFondo.Text = "---------------------------------------------------------------------------------" &
    "--------------------------------------------------------------------------------" &
    "-----------------"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(48, 44)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(137, 116)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'ImprimirForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 645)
        Me.Controls.Add(Me.LineaFondo)
        Me.Controls.Add(Me.LineaTop)
        Me.Controls.Add(Me.Punto5)
        Me.Controls.Add(Me.Punto4)
        Me.Controls.Add(Me.Punto3)
        Me.Controls.Add(Me.Punto2)
        Me.Controls.Add(Me.Punto1)
        Me.Controls.Add(Me.lbNumeroPagina)
        Me.Controls.Add(Me.LabelPagina)
        Me.Controls.Add(Me.lbPromedio)
        Me.Controls.Add(Me.lbCursadas)
        Me.Controls.Add(Me.LabelPromedio)
        Me.Controls.Add(Me.LabelCursadas)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lbCodigo)
        Me.Controls.Add(Me.lbEstudiante)
        Me.Controls.Add(Me.lbFecha)
        Me.Controls.Add(Me.LabelCodigo)
        Me.Controls.Add(Me.LabelEstudiante)
        Me.Controls.Add(Me.LabelFecha)
        Me.Controls.Add(Me.LabelTelefono)
        Me.Controls.Add(Me.LabelDireccion)
        Me.Controls.Add(Me.LabelEmpresa)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "ImprimirForm"
        Me.Text = "ImprimirForm"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbCodigo As Label
    Friend WithEvents lbEstudiante As Label
    Friend WithEvents lbFecha As Label
    Friend WithEvents LabelCodigo As Label
    Friend WithEvents LabelEstudiante As Label
    Friend WithEvents LabelFecha As Label
    Friend WithEvents LabelTelefono As Label
    Friend WithEvents LabelDireccion As Label
    Friend WithEvents LabelEmpresa As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents codigo As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents materia As DataGridViewTextBoxColumn
    Friend WithEvents primer_parcial As DataGridViewTextBoxColumn
    Friend WithEvents segundo_parcial As DataGridViewTextBoxColumn
    Friend WithEvents examen_final As DataGridViewTextBoxColumn
    Friend WithEvents calificacion As DataGridViewTextBoxColumn
    Friend WithEvents lbNumeroPagina As Label
    Friend WithEvents LabelPagina As Label
    Friend WithEvents lbPromedio As Label
    Friend WithEvents lbCursadas As Label
    Friend WithEvents LabelPromedio As Label
    Friend WithEvents LabelCursadas As Label
    Friend WithEvents Punto5 As Label
    Friend WithEvents Punto4 As Label
    Friend WithEvents Punto3 As Label
    Friend WithEvents Punto2 As Label
    Friend WithEvents Punto1 As Label
    Friend WithEvents LineaTop As Label
    Friend WithEvents LineaFondo As Label
End Class
