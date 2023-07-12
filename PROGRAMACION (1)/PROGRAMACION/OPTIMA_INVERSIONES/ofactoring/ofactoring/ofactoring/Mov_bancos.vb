Public Class Mov_bancos
    Dim _enabledCerrar As Boolean = False
    <System.ComponentModel.DefaultValue(False), System.ComponentModel.Description("Define si se habilita el botón cerrar en el formulario")>
    Public Property EnabledCerrar() As Boolean
        Get
            Return _enabledCerrar
        End Get
        Set(ByVal Value As Boolean)
            If _enabledCerrar <> Value Then
                _enabledCerrar = Value
            End If
        End Set
    End Property
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            If _enabledCerrar = False Then
                Const CS_NOCLOSE As Integer = &H200
                cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            End If
            Return cp
        End Get
    End Property
    Public accion As String
    Public gestion, fecha_f, fec_grab As String
    'variables publicas
    Public esta, cod_clie, cod_comi_desem, cod_cuop, tip_op, tipodoc_clie, numdoc_clie, cali_finan, cod2, cod_banco, cod_cuenta, ccuenta, cci As String
    Dim con As Integer
    Dim acciones As String = "guardar"
    Dim cod As Integer
    Dim cuenta, nom_cuenta, glosa, analitica, gest As String
    Dim saldo As Decimal
    Dim sum_cargo, sum_abono, saldo_disp_sis As Decimal
    Dim cod_fon_clie2 As String

    Private Sub cb2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cb2.SelectedIndexChanged
        cod_cuenta = UCase(Mid(cb2.Text, 1, (Str(InStrRev(cb2.Text, ("|")))) - 1))
        nc = cod_cuenta
        Label18.Text = nc

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles t7.TextChanged

    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles t13.TextChanged

    End Sub

    Private Sub cb2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged
        'cod_banco = UCase(Mid(cb1.Text, 1, (Str(InStrRev(cb1.Text, ("|")))) - 1))
        '.Text = cod_banco
        'llenar_combo2()
    End Sub

    Dim debe, haber As String
    'variable de fecha
    Public d1, m1, a1, d2, m2, a2, d3, m3, a3, dia1, mes1, dia2, mes2, dia3, mes3, f_ini, f_term, f_filt, ruc, fecha As String

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        desembolsos.TextBox1.Text = cb3.Text
        Me.Close()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Me.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        suma_cargo()
        suma_abono()
        saldo_disponible_actual()
        sum_res_saldo()
        sum_abono = 0
        sum_cargo = 0
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        desembolsos.cb3.Enabled = True
        desembolsos.t13.Enabled = True
        desembolsos.t13.Text = cb3.Text
        desembolsos.Button1.Enabled = True
        Me.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        llenar_textbox()
        llenar_grid()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        llenar_combo2()
    End Sub

    Private Sub cb3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb3.SelectedIndexChanged
        cod_banco = UCase(Mid(cb3.Text, 1, (Str(InStrRev(cb3.Text, ("|")))) - 1))
        Label17.Text = cod_banco
        'llenar_combo2()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        guardar()
        llenar_grid()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t9.Enabled = True
        t10.Enabled = True
        t11.Enabled = True
        t12.Enabled = True
        t13.Enabled = True
        dtp1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t9.Enabled = True
        t10.Enabled = True
        t11.Enabled = True
        t12.Enabled = True
        t13.Enabled = True
        dtp1.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        suma_cargo()
        suma_abono()
        saldo_disponible_actual()
        sum_res_saldo()
        sum_abono = 0
        sum_cargo = 0
    End Sub

    Dim fec As Date
    Dim sql, nc As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub Mov_bancos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If desembolsos.a = 1 Then
            Button9.Visible = True
            dgv.Visible = False
            Label5.Visible = False
            t7.Visible = False
            Label6.Visible = False
            t8.Visible = False
            GroupBox1.Visible = False
            Label4.Visible = False
            t6.Visible = False
            Button6.Visible = False
            Button10.Visible = True
            Label21.Text = ""
            Label21.Visible = True
        End If
        dgv.AllowUserToAddRows = False
        Me.Text = "Movimiento Bancarios" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        llenar_combo1()
        'llenar_grid()
        t7.Text = 0.0
        t6.Text = 0.0
        Label18.Text = ""
        sum_res_saldo()
    End Sub

    Public Sub llenar_combo1()
        sql = "select cod_ban,(cod_ban+'  |  '+ n_banco) as dtos from reg_banco"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb3.DataSource = dt
        cb3.DisplayMember = "dtos"
        cb3.ValueMember = "cod_ban"
    End Sub

    Public Sub llenar_combo2()


        Select Case desembolsos.a
            Case 1
                cod_fon_clie2 = Datos_Generales_del_Fondo.t1.Text
            Case 2
                cod_fon_clie2 = desembolsos.t2.Text
        End Select

        sql = "select cod_cuenta,(cod_cuenta+'  |  '+' N°CUENTA: '+ n_cuenta+' CCI: '+ n_cci) as dtos from datos_cuenta where cod_fondo= '" + cod_fon_clie2 + "' and cod_ban = '" + cod_banco + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "dtos"
        cb2.ValueMember = "cod_cuenta"
    End Sub
    Public Sub llenar_textbox()
        sql = "exec ver_datos_cuenta '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(3)
            t3.Text = dr(4)
            t4.Text = dr(2)
            t5.Text = dr(5)
        Else
            MessageBox.Show("Los Datos no Existen")
        End If

        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub cb1_Click(sender As Object, e As EventArgs) Handles cb1.Click
        'cod_banco = UCase(Mid(cb1.Text, 1, (Str(InStrRev(cb1.Text, ("|")))) - 1))
        'llenar_combo2()
    End Sub

    Private Sub cb1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb1.SelectedValueChanged
        'cod_banco = UCase(Mid(cb1.Text, 1, (Str(InStrRev(cb1.Text, ("|")))) - 1))
        'Label17.Text = cod_banco
        llenar_combo2()

        'cod_banco = UCase(Mid(cb1.Text, 1, (Str(InStrRev(cb1.Text, ("|")))) - 2))
        '.Text = cod_banco
        'llenar_combo2()
    End Sub

    Private Sub llenar_grid()
        sql = "select *from v_mov_banco where CUENTA= '" + cod_cuenta + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_mov_banco")
        dgv.DataSource = ds
        dgv.DataMember = "v_mov_banco"
        conexion.conexion2.Close()
    End Sub

    Private Sub sum_res_saldo()
        Try
            saldo = t7.Text - t6.Text
            t8.Text = saldo

        Catch ex As Exception
            MsgBox("Erro en la Operacion")
        End Try

    End Sub

    Private Sub t7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t7.KeyPress

    End Sub

    Private Sub suma_cargo()

        For Each row As DataGridViewRow In Me.dgv.Rows
            sum_cargo += Val(row.Cells(4).Value)
        Next
    End Sub

    Private Sub suma_abono()

        For Each row As DataGridViewRow In Me.dgv.Rows
            sum_abono += Val(row.Cells(5).Value)
        Next
    End Sub

    Private Sub saldo_disponible_actual()
        saldo_disp_sis = -sum_cargo + sum_abono
        t6.Text = saldo_disp_sis
        Label21.Text = saldo_disp_sis
    End Sub

    Private Sub guardar()
        Try
            gestion = dtp1.Value.ToString("yyyy")
            fec_grab = dtp1.Value.ToString("yyyyMMdd")
            sql = ""
            If accion = "guardar" Then
                sql = "exec ver_mov_banco'" + nc + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("El Movimiento Bancario ya existe", "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    conexion.conexion2.Close()
                Else
                    sql = "exec alta_mov_bancos '" + UCase(Datos_Generales_del_Fondo.t1.Text) + "','" + gestion + "','" + UCase(t1.Text) + "','" + UCase(t6.Text) + "','" + UCase(t7.Text) + "','" + UCase(t5.Text) + "','" + UCase(t9.Text) + "','" + fec_grab + "','" + UCase(t10.Text) + "','" + t11.Text + "','" + t12.Text + "','" + t13.Text + "','" + t8.Text + "'"
                    conexion.conectarfondo()
                    com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                    res = com.ExecuteNonQuery
                    conexion.conexion2.Close()
                    MessageBox.Show("Registro Guardado")

                End If
            ElseIf accion = "editar" Then
                sql = "exec edita_mov_bancos '" + nc + "','" + UCase(Datos_Generales_del_Fondo.t1.Text) + "','" + gestion + "','" + UCase(t1.Text) + "','" + UCase(t6.Text) + "','" + UCase(t7.Text) + "','" + UCase(t5.Text) + "','" + UCase(t9.Text) + "','" + fec_grab + "','" + UCase(t10.Text) + "','" + t11.Text + "','" + t12.Text + "','" + t13.Text + "','" + t8.Text + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.conexion.Close()
                MessageBox.Show("Registro Modificado")

            End If
        Catch ex As Exception
            MsgBox("Error al Guardar los Datos")
        End Try

    End Sub
End Class