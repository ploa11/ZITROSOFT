'Option Explicit On

Public Class Form4
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

    '--------------------------------------------
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim accion, sql, nc, gest, tip_partic, res, cod_cuota, cod_cr, cod_clie As String
    Dim valor_mr, almacena As Decimal

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "REPROGRAMADO" Then
            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            TextBox1.Visible = True
            TextBox11.Visible = True
            TextBox12.Visible = True
            Button1.Visible = True
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False
            Button5.Visible = False
        Else
            Label1.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            TextBox1.Visible = False
            TextBox11.Visible = False
            TextBox12.Visible = False
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False
            Button5.Visible = False

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True
        Button5.Visible = True
        CALC_REPRO()
        TextBox1.Text = TextBox11.Text - TextBox12.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        forcambiaestado()
        buscar_reprogramado()
        GUARDAREPROGRAMADO()
        Button6.Visible = True
    End Sub

    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Anex_Cronog.Button1_click(sender, e)
        Anex_Cronog.Button1.PerformClick()
        Anex_Cronog.TextBox2.Text = cod_cr
        Anex_Cronog.t2.Text = cod_clie
        Anex_Cronog.t5.Text = TextBox1.Text
        Anex_Cronog.Show()
        Me.Close()
    End Sub

    Dim ds As DataSet
    Dim dt As DataTable

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        TextBox12.Text = 0
        buscar_datos()
        'Cuotas_Operacion.buscar_reprogramado()
        Me.Text = "Activar" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Cuotas_Operacion.rev_cro_anx = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        Cuotas_Operacion.verifi = 2
        Cuotas_Operacion.buscar_cambiar_estado()
        Cuotas_Operacion.BUSCA_MORA()
        Cuotas_Operacion.Show()
        Cuotas_Operacion.dgv.Visible = False
        Cuotas_Operacion.GroupBox1.Visible = False
        Cuotas_Operacion.Button13.Visible = False
    End Sub

    Private Sub CALC_REPRO()
        almacena = 0

        For Each Row As DataGridViewRow In dgv.Rows
            If Row.Cells("ESTADO").Value = "MORA" Then
                valor_mr = Row.Cells("CUOTA TOTAL").Value
                almacena += valor_mr
            Else
                valor_mr = Row.Cells("AMORTIZACION").Value
                almacena += valor_mr
            End If
            'Anex_Cronog.dtp2.Value = f_final

        Next
        TextBox11.Text = almacena
    End Sub

    Private Sub cambia_estado_cuotas()
        Try
            sql = ""

            sql = "update CUOTAS_OPERACION set estado= '" + ComboBox1.Text + "' where COD_OP='" + cod_cuota + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
            MessageBox.Show("Estado de Cuota Actualizado")

        Catch ex As Exception
            MessageBox.Show("Estado de Cuota Actualizado", "OPTIMA")
        End Try


    End Sub

    Private Sub forcambiaestado()
        Try
            MessageBox.Show("¿Los Estado de Cuotas y Ingreso Diario van a Cambiar", "CLIENTES")
            For Each Row As DataGridViewRow In dgv.Rows
                cod_cuota = Row.Cells("CODIGO DE CUOTA").Value
                cod_cr = Row.Cells("CODIGO DE OPERACION").Value
                cambia_estado_cuotas()
                cambiaestadonumdias()
            Next
        Catch ex As Exception
            MessageBox.Show("ERROR EN LA CONEXION", "OPTIMA")
        End Try
    End Sub

    Private Sub cambiaestadonumdias()
        Try
            sql = ""

            sql = "update NUM_DIAS_CRANX  set estado='" + ComboBox1.Text + "' WHERE cod_cuota='" + cod_cuota + "' "
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
            MessageBox.Show("Estado de Ingreso Diario Actualizado", "OPTIMA")

        Catch ex As Exception
            MessageBox.Show("ERROR EN LA CONEXION", "OPTIMA")
        End Try
    End Sub

    Private Sub GUARDAREPROGRAMADO()
        sql = ""
        Try
            sql = "exec alta_reprogramacion '" + TextBox11.Text + "','" + TextBox12.Text + "','" + TextBox1.Text + "','" + cod_cr + "','" + DateTimePicker1.Value.ToString("yyyyMMdd") + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Guardado")
        Catch ex As Exception
            MessageBox.Show("ERROR EN LA CONEXION", "OPTIMA")
        End Try
    End Sub
    Public Sub buscar_reprogramado()
        't2.Text = Anex_Cronog.t1.Text
        nc = cod_cr
        sql = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA','REPROGRAMADO')"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA','REPROGRAMADO')")
        'dgv.DataSource = ds
        'dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA')"
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "' and estado in('VIGENTE','MORA','REPROGRAMADO')"
        conexion.conexion2.Close()
    End Sub

    Private Sub buscar_datos()
        Try
            nc = Anex_Cronog.t1.Text
            sql = "exec ver_d_operacion '" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                cod_clie = dr(1)
            Else
                MessageBox.Show("Los Datos no Existen")
            End If
            dr.Close()
            conexion.conexion2.Close()
            Button6.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
End Class