<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Impresion_OC
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
        Me.components = New System.ComponentModel.Container()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label_oc = New System.Windows.Forms.Label()
        Me.oc = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ITEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.P_UNITARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBTOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label_direcc = New System.Windows.Forms.Label()
        Me.Label_sres = New System.Windows.Forms.Label()
        Me.Label_ruc = New System.Windows.Forms.Label()
        Me.Label_fe = New System.Windows.Forms.Label()
        Me.sres = New System.Windows.Forms.Label()
        Me.direcc = New System.Windows.Forms.Label()
        Me.ruc = New System.Windows.Forms.Label()
        Me.fec_emision = New System.Windows.Forms.Label()
        Me.forma_pago = New System.Windows.Forms.Label()
        Me.Label_fp = New System.Windows.Forms.Label()
        Me.telefono = New System.Windows.Forms.Label()
        Me.Label_telef = New System.Windows.Forms.Label()
        Me.t_venta = New System.Windows.Forms.Label()
        Me.Label_t_venta = New System.Windows.Forms.Label()
        Me.personal = New System.Windows.Forms.Label()
        Me.Label_pers = New System.Windows.Forms.Label()
        Me.f_pago = New System.Windows.Forms.Label()
        Me.Label_f_pago = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.P1 = New System.Windows.Forms.Label()
        Me.P2 = New System.Windows.Forms.Label()
        Me.P3 = New System.Windows.Forms.Label()
        Me.P4 = New System.Windows.Forms.Label()
        Me.P5 = New System.Windows.Forms.Label()
        Me.P6 = New System.Windows.Forms.Label()
        Me.lbNumeroPagina = New System.Windows.Forms.Label()
        Me.Pag_N = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.REQUE = New System.Windows.Forms.Label()
        Me.RQ = New System.Windows.Forms.Label()
        Me.SBCC = New System.Windows.Forms.Label()
        Me.SUBCC = New System.Windows.Forms.Label()
        Me.CCOSTO = New System.Windows.Forms.Label()
        Me.Label_CC = New System.Windows.Forms.Label()
        Me.OBS = New System.Windows.Forms.Label()
        Me.Label_OB = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(213, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ZITRO SOLUCIONES INTEGRALES S.A.C"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(320, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "AV. MORALES DUARES 2993 MIRONES BAJO LIMA CERCADO"
        '
        'Label_oc
        '
        Me.Label_oc.AutoSize = True
        Me.Label_oc.Location = New System.Drawing.Point(770, 38)
        Me.Label_oc.Name = "Label_oc"
        Me.Label_oc.Size = New System.Drawing.Size(113, 13)
        Me.Label_oc.TabIndex = 3
        Me.Label_oc.Text = "ORDEN DE COMPRA"
        '
        'oc
        '
        Me.oc.AutoSize = True
        Me.oc.Location = New System.Drawing.Point(792, 56)
        Me.oc.Name = "oc"
        Me.oc.Size = New System.Drawing.Size(73, 13)
        Me.oc.TabIndex = 4
        Me.oc.Text = "......................"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITEM, Me.DESCRIPCION, Me.UND, Me.CANTIDAD, Me.P_UNITARIO, Me.SUBTOTAL})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 443)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(954, 167)
        Me.DataGridView1.TabIndex = 5
        '
        'ITEM
        '
        Me.ITEM.HeaderText = "ITEM"
        Me.ITEM.Name = "ITEM"
        Me.ITEM.ReadOnly = True
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.HeaderText = "DESCRIPCION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Width = 410
        '
        'UND
        '
        Me.UND.HeaderText = "UND"
        Me.UND.Name = "UND"
        Me.UND.ReadOnly = True
        '
        'CANTIDAD
        '
        Me.CANTIDAD.HeaderText = "CANTIDAD"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        '
        'P_UNITARIO
        '
        Me.P_UNITARIO.HeaderText = "P. UNITARIO"
        Me.P_UNITARIO.Name = "P_UNITARIO"
        Me.P_UNITARIO.ReadOnly = True
        '
        'SUBTOTAL
        '
        Me.SUBTOTAL.HeaderText = "SUBTOTAL"
        Me.SUBTOTAL.Name = "SUBTOTAL"
        Me.SUBTOTAL.ReadOnly = True
        '
        'Label_direcc
        '
        Me.Label_direcc.AutoSize = True
        Me.Label_direcc.Location = New System.Drawing.Point(12, 203)
        Me.Label_direcc.Name = "Label_direcc"
        Me.Label_direcc.Size = New System.Drawing.Size(69, 13)
        Me.Label_direcc.TabIndex = 6
        Me.Label_direcc.Text = "DIRECCION:"
        '
        'Label_sres
        '
        Me.Label_sres.AutoSize = True
        Me.Label_sres.Location = New System.Drawing.Point(12, 177)
        Me.Label_sres.Name = "Label_sres"
        Me.Label_sres.Size = New System.Drawing.Size(39, 13)
        Me.Label_sres.TabIndex = 7
        Me.Label_sres.Text = "SRES:"
        '
        'Label_ruc
        '
        Me.Label_ruc.AutoSize = True
        Me.Label_ruc.Location = New System.Drawing.Point(12, 229)
        Me.Label_ruc.Name = "Label_ruc"
        Me.Label_ruc.Size = New System.Drawing.Size(33, 13)
        Me.Label_ruc.TabIndex = 8
        Me.Label_ruc.Text = "RUC:"
        '
        'Label_fe
        '
        Me.Label_fe.AutoSize = True
        Me.Label_fe.Location = New System.Drawing.Point(16, 281)
        Me.Label_fe.Name = "Label_fe"
        Me.Label_fe.Size = New System.Drawing.Size(111, 13)
        Me.Label_fe.TabIndex = 9
        Me.Label_fe.Text = "FECHA DE EMISION:"
        '
        'sres
        '
        Me.sres.AutoSize = True
        Me.sres.Location = New System.Drawing.Point(137, 177)
        Me.sres.Name = "sres"
        Me.sres.Size = New System.Drawing.Size(73, 13)
        Me.sres.TabIndex = 10
        Me.sres.Text = "......................"
        '
        'direcc
        '
        Me.direcc.AutoSize = True
        Me.direcc.Location = New System.Drawing.Point(137, 203)
        Me.direcc.Name = "direcc"
        Me.direcc.Size = New System.Drawing.Size(73, 13)
        Me.direcc.TabIndex = 11
        Me.direcc.Text = "......................"
        '
        'ruc
        '
        Me.ruc.AutoSize = True
        Me.ruc.Location = New System.Drawing.Point(137, 229)
        Me.ruc.Name = "ruc"
        Me.ruc.Size = New System.Drawing.Size(73, 13)
        Me.ruc.TabIndex = 12
        Me.ruc.Text = "......................"
        '
        'fec_emision
        '
        Me.fec_emision.AutoSize = True
        Me.fec_emision.Location = New System.Drawing.Point(137, 281)
        Me.fec_emision.Name = "fec_emision"
        Me.fec_emision.Size = New System.Drawing.Size(73, 13)
        Me.fec_emision.TabIndex = 13
        Me.fec_emision.Text = "......................"
        '
        'forma_pago
        '
        Me.forma_pago.AutoSize = True
        Me.forma_pago.Location = New System.Drawing.Point(432, 281)
        Me.forma_pago.Name = "forma_pago"
        Me.forma_pago.Size = New System.Drawing.Size(73, 13)
        Me.forma_pago.TabIndex = 15
        Me.forma_pago.Text = "......................"
        '
        'Label_fp
        '
        Me.Label_fp.AutoSize = True
        Me.Label_fp.Location = New System.Drawing.Point(307, 281)
        Me.Label_fp.Name = "Label_fp"
        Me.Label_fp.Size = New System.Drawing.Size(99, 13)
        Me.Label_fp.TabIndex = 14
        Me.Label_fp.Text = "FORMA DE PAGO:"
        '
        'telefono
        '
        Me.telefono.AutoSize = True
        Me.telefono.Location = New System.Drawing.Point(137, 255)
        Me.telefono.Name = "telefono"
        Me.telefono.Size = New System.Drawing.Size(73, 13)
        Me.telefono.TabIndex = 17
        Me.telefono.Text = "......................"
        '
        'Label_telef
        '
        Me.Label_telef.AutoSize = True
        Me.Label_telef.Location = New System.Drawing.Point(12, 255)
        Me.Label_telef.Name = "Label_telef"
        Me.Label_telef.Size = New System.Drawing.Size(67, 13)
        Me.Label_telef.TabIndex = 16
        Me.Label_telef.Text = "TELEFONO:"
        '
        't_venta
        '
        Me.t_venta.AutoSize = True
        Me.t_venta.Location = New System.Drawing.Point(432, 316)
        Me.t_venta.Name = "t_venta"
        Me.t_venta.Size = New System.Drawing.Size(73, 13)
        Me.t_venta.TabIndex = 21
        Me.t_venta.Text = "......................"
        '
        'Label_t_venta
        '
        Me.Label_t_venta.AutoSize = True
        Me.Label_t_venta.Location = New System.Drawing.Point(307, 316)
        Me.Label_t_venta.Name = "Label_t_venta"
        Me.Label_t_venta.Size = New System.Drawing.Size(92, 13)
        Me.Label_t_venta.TabIndex = 20
        Me.Label_t_venta.Text = "TIPO DE VENTA:"
        '
        'personal
        '
        Me.personal.AutoSize = True
        Me.personal.Location = New System.Drawing.Point(137, 316)
        Me.personal.Name = "personal"
        Me.personal.Size = New System.Drawing.Size(73, 13)
        Me.personal.TabIndex = 19
        Me.personal.Text = "......................"
        '
        'Label_pers
        '
        Me.Label_pers.AutoSize = True
        Me.Label_pers.Location = New System.Drawing.Point(16, 316)
        Me.Label_pers.Name = "Label_pers"
        Me.Label_pers.Size = New System.Drawing.Size(68, 13)
        Me.Label_pers.TabIndex = 18
        Me.Label_pers.Text = "PERSONAL:"
        '
        'f_pago
        '
        Me.f_pago.AutoSize = True
        Me.f_pago.Location = New System.Drawing.Point(747, 316)
        Me.f_pago.Name = "f_pago"
        Me.f_pago.Size = New System.Drawing.Size(73, 13)
        Me.f_pago.TabIndex = 23
        Me.f_pago.Text = "......................"
        '
        'Label_f_pago
        '
        Me.Label_f_pago.AutoSize = True
        Me.Label_f_pago.Location = New System.Drawing.Point(622, 316)
        Me.Label_f_pago.Name = "Label_f_pago"
        Me.Label_f_pago.Size = New System.Drawing.Size(96, 13)
        Me.Label_f_pago.TabIndex = 22
        Me.Label_f_pago.Text = "FECHA DE PAGO:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(893, 620)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(73, 13)
        Me.Label23.TabIndex = 25
        Me.Label23.Text = "......................"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(768, 620)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(85, 13)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "SUBTOTAL: S/."
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(893, 645)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(73, 13)
        Me.Label25.TabIndex = 27
        Me.Label25.Text = "......................"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(768, 645)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(49, 13)
        Me.Label26.TabIndex = 26
        Me.Label26.Text = "IGV S/. :"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(893, 676)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(73, 13)
        Me.Label27.TabIndex = 29
        Me.Label27.Text = "......................"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(768, 676)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 13)
        Me.Label28.TabIndex = 28
        Me.Label28.Text = "TOTAL:"
        '
        'P1
        '
        Me.P1.AutoSize = True
        Me.P1.Location = New System.Drawing.Point(60, 427)
        Me.P1.Name = "P1"
        Me.P1.Size = New System.Drawing.Size(20, 13)
        Me.P1.TabIndex = 30
        Me.P1.Text = "P1"
        '
        'P2
        '
        Me.P2.AutoSize = True
        Me.P2.Location = New System.Drawing.Point(155, 427)
        Me.P2.Name = "P2"
        Me.P2.Size = New System.Drawing.Size(20, 13)
        Me.P2.TabIndex = 31
        Me.P2.Text = "P2"
        '
        'P3
        '
        Me.P3.AutoSize = True
        Me.P3.Location = New System.Drawing.Point(573, 427)
        Me.P3.Name = "P3"
        Me.P3.Size = New System.Drawing.Size(20, 13)
        Me.P3.TabIndex = 32
        Me.P3.Text = "P3"
        '
        'P4
        '
        Me.P4.AutoSize = True
        Me.P4.Location = New System.Drawing.Point(666, 427)
        Me.P4.Name = "P4"
        Me.P4.Size = New System.Drawing.Size(20, 13)
        Me.P4.TabIndex = 33
        Me.P4.Text = "P4"
        '
        'P5
        '
        Me.P5.AutoSize = True
        Me.P5.Location = New System.Drawing.Point(766, 427)
        Me.P5.Name = "P5"
        Me.P5.Size = New System.Drawing.Size(20, 13)
        Me.P5.TabIndex = 34
        Me.P5.Text = "P5"
        '
        'P6
        '
        Me.P6.AutoSize = True
        Me.P6.Location = New System.Drawing.Point(865, 427)
        Me.P6.Name = "P6"
        Me.P6.Size = New System.Drawing.Size(20, 13)
        Me.P6.TabIndex = 35
        Me.P6.Text = "P6"
        '
        'lbNumeroPagina
        '
        Me.lbNumeroPagina.AutoSize = True
        Me.lbNumeroPagina.Location = New System.Drawing.Point(953, 9)
        Me.lbNumeroPagina.Name = "lbNumeroPagina"
        Me.lbNumeroPagina.Size = New System.Drawing.Size(13, 13)
        Me.lbNumeroPagina.TabIndex = 37
        Me.lbNumeroPagina.Text = "0"
        '
        'Pag_N
        '
        Me.Pag_N.AutoSize = True
        Me.Pag_N.Location = New System.Drawing.Point(893, 9)
        Me.Pag_N.Name = "Pag_N"
        Me.Pag_N.Size = New System.Drawing.Size(39, 13)
        Me.Pag_N.TabIndex = 36
        Me.Pag_N.Text = "Pág. #"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.RUMISOFT.My.Resources.Resources.nlzitro2
        Me.PictureBox1.Location = New System.Drawing.Point(12, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(119, 108)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'REQUE
        '
        Me.REQUE.AutoSize = True
        Me.REQUE.Location = New System.Drawing.Point(747, 350)
        Me.REQUE.Name = "REQUE"
        Me.REQUE.Size = New System.Drawing.Size(73, 13)
        Me.REQUE.TabIndex = 43
        Me.REQUE.Text = "......................"
        '
        'RQ
        '
        Me.RQ.AutoSize = True
        Me.RQ.Location = New System.Drawing.Point(622, 350)
        Me.RQ.Name = "RQ"
        Me.RQ.Size = New System.Drawing.Size(101, 13)
        Me.RQ.TabIndex = 42
        Me.RQ.Text = "REQUERIMIENTO:"
        '
        'SBCC
        '
        Me.SBCC.AutoSize = True
        Me.SBCC.Location = New System.Drawing.Point(451, 350)
        Me.SBCC.Name = "SBCC"
        Me.SBCC.Size = New System.Drawing.Size(73, 13)
        Me.SBCC.TabIndex = 41
        Me.SBCC.Text = "......................"
        '
        'SUBCC
        '
        Me.SUBCC.AutoSize = True
        Me.SUBCC.Location = New System.Drawing.Point(307, 350)
        Me.SUBCC.Name = "SUBCC"
        Me.SUBCC.Size = New System.Drawing.Size(138, 13)
        Me.SUBCC.TabIndex = 40
        Me.SUBCC.Text = "SUB CENTRO DE COSTO:"
        '
        'CCOSTO
        '
        Me.CCOSTO.AutoSize = True
        Me.CCOSTO.Location = New System.Drawing.Point(137, 350)
        Me.CCOSTO.Name = "CCOSTO"
        Me.CCOSTO.Size = New System.Drawing.Size(73, 13)
        Me.CCOSTO.TabIndex = 39
        Me.CCOSTO.Text = "......................"
        '
        'Label_CC
        '
        Me.Label_CC.AutoSize = True
        Me.Label_CC.Location = New System.Drawing.Point(16, 350)
        Me.Label_CC.Name = "Label_CC"
        Me.Label_CC.Size = New System.Drawing.Size(113, 13)
        Me.Label_CC.TabIndex = 38
        Me.Label_CC.Text = "CENTRO DE COSTO:"
        '
        'OBS
        '
        Me.OBS.AutoSize = True
        Me.OBS.Location = New System.Drawing.Point(141, 381)
        Me.OBS.Name = "OBS"
        Me.OBS.Size = New System.Drawing.Size(73, 13)
        Me.OBS.TabIndex = 45
        Me.OBS.Text = "......................"
        '
        'Label_OB
        '
        Me.Label_OB.AutoSize = True
        Me.Label_OB.Location = New System.Drawing.Point(16, 381)
        Me.Label_OB.Name = "Label_OB"
        Me.Label_OB.Size = New System.Drawing.Size(101, 13)
        Me.Label_OB.TabIndex = 44
        Me.Label_OB.Text = "OBSERVACIONES:"
        '
        'Form_Impresion_OC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 749)
        Me.Controls.Add(Me.OBS)
        Me.Controls.Add(Me.Label_OB)
        Me.Controls.Add(Me.REQUE)
        Me.Controls.Add(Me.RQ)
        Me.Controls.Add(Me.SBCC)
        Me.Controls.Add(Me.SUBCC)
        Me.Controls.Add(Me.CCOSTO)
        Me.Controls.Add(Me.Label_CC)
        Me.Controls.Add(Me.lbNumeroPagina)
        Me.Controls.Add(Me.Pag_N)
        Me.Controls.Add(Me.P6)
        Me.Controls.Add(Me.P5)
        Me.Controls.Add(Me.P4)
        Me.Controls.Add(Me.P3)
        Me.Controls.Add(Me.P2)
        Me.Controls.Add(Me.P1)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.f_pago)
        Me.Controls.Add(Me.Label_f_pago)
        Me.Controls.Add(Me.t_venta)
        Me.Controls.Add(Me.Label_t_venta)
        Me.Controls.Add(Me.personal)
        Me.Controls.Add(Me.Label_pers)
        Me.Controls.Add(Me.telefono)
        Me.Controls.Add(Me.Label_telef)
        Me.Controls.Add(Me.forma_pago)
        Me.Controls.Add(Me.Label_fp)
        Me.Controls.Add(Me.fec_emision)
        Me.Controls.Add(Me.ruc)
        Me.Controls.Add(Me.direcc)
        Me.Controls.Add(Me.sres)
        Me.Controls.Add(Me.Label_fe)
        Me.Controls.Add(Me.Label_ruc)
        Me.Controls.Add(Me.Label_sres)
        Me.Controls.Add(Me.Label_direcc)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.oc)
        Me.Controls.Add(Me.Label_oc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form_Impresion_OC"
        Me.Text = "Form_Impresion_OC"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label_oc As Label
    Friend WithEvents oc As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label_direcc As Label
    Friend WithEvents Label_sres As Label
    Friend WithEvents Label_ruc As Label
    Friend WithEvents Label_fe As Label
    Friend WithEvents sres As Label
    Friend WithEvents direcc As Label
    Friend WithEvents ruc As Label
    Friend WithEvents fec_emision As Label
    Friend WithEvents forma_pago As Label
    Friend WithEvents Label_fp As Label
    Friend WithEvents telefono As Label
    Friend WithEvents Label_telef As Label
    Friend WithEvents t_venta As Label
    Friend WithEvents Label_t_venta As Label
    Friend WithEvents personal As Label
    Friend WithEvents Label_pers As Label
    Friend WithEvents f_pago As Label
    Friend WithEvents Label_f_pago As Label
    Friend WithEvents ITEM As DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As DataGridViewTextBoxColumn
    Friend WithEvents UND As DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As DataGridViewTextBoxColumn
    Friend WithEvents P_UNITARIO As DataGridViewTextBoxColumn
    Friend WithEvents SUBTOTAL As DataGridViewTextBoxColumn
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents P1 As Label
    Friend WithEvents P2 As Label
    Friend WithEvents P3 As Label
    Friend WithEvents P4 As Label
    Friend WithEvents P5 As Label
    Friend WithEvents P6 As Label
    Friend WithEvents lbNumeroPagina As Label
    Friend WithEvents Pag_N As Label
    Friend WithEvents REQUE As Label
    Friend WithEvents RQ As Label
    Friend WithEvents SBCC As Label
    Friend WithEvents SUBCC As Label
    Friend WithEvents CCOSTO As Label
    Friend WithEvents Label_CC As Label
    Friend WithEvents OBS As Label
    Friend WithEvents Label_OB As Label
End Class
