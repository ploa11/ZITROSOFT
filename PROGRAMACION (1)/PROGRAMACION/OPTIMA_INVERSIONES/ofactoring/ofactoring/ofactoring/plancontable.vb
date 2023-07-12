Public Class plancontable
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
    'Public conexion As SqlClient.SqlConnection
    Public dh As String
    Dim accion As String, nc As String, sql As String
    Dim res As Integer, tc As String, td As String, nd As String, ce As String
    Dim ncome, rsoc, tipdoc, ndoc As String
    Dim pass As String, telef As String, anx As String, nom As String, app As String, apm As String
    Dim m1, m2, ent, fecha, hora As String
    Dim ame As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t1.Enabled = True
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        cb3.Enabled = True
        cb4.Enabled = True
        cb5.Enabled = True
        cb6.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub t9_TextChanged(sender As Object, e As EventArgs) Handles t9.TextChanged
        Try
            nc = t9.Text
            sql = "select *from v_plan_contable where [NUMERO DE CUENTA] like'" + nc + "%'"
            conexion.conectar()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_plan_contable where [NUMERO DE CUENTA] like'" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_plan_contable where [NUMERO DE CUENTA] like'" + nc + "%'"
            conexion.conexion.Close()
        Catch ex As Exception
            MsgBox("Error de Conexion a base de datos")
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        guardar()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_plan_contable '" + t1.Text + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            cb3.Text = dr(2)
            cb4.Text = dr(3)
            cb5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
            t4.Text = dr(7)
            cb6.Text = dr(8)
            t5.Text = dr(9)
            cb2.Text = dr(11)
            t3.Text = dr(12)
            cb1.Text = dr(13)

        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = t1.Text
        res = MessageBox.Show("¿Desea Borrar la cuenta", "Plan de Cuentas", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql = "exec borra_plan_cuentas '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t1.Text = ""
        t2.Enabled = False
        t2.Text = ""
        t3.Enabled = False
        t3.Text = ""
        t4.Enabled = False
        t4.Text = ""
        t5.Enabled = False
        t5.Text = ""
        t6.Enabled = False
        t6.Text = ""
        t7.Enabled = False
        t7.Text = ""
        cb1.Enabled = False
        cb1.Text = ""
        cb2.Enabled = False
        cb2.Text = ""
        cb3.Enabled = False
        cb3.Text = ""
        cb4.Enabled = False
        cb4.Text = ""
        cb5.Enabled = False
        cb5.Text = ""
        cb6.Enabled = False
        cb6.Text = ""
    End Sub

    Private Sub t6_TextChanged(sender As Object, e As EventArgs) Handles t6.TextChanged

    End Sub

    Private Sub guardar()

        sql = ""
        If accion = "guardar" Then

            sql = "exec ver_plan_contable'" + t1.Text + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El Numero de Cuenta ya existe", "Plan Contable", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion.Close()
            Else
                sql = "exec alta_cuenta_contable '" + UCase(t1.Text) + "','" + UCase(t2.Text) + "','" + UCase(cb3.Text) + "','" + UCase(cb4.Text) + "','" + UCase(cb5.Text) + "','" + UCase(t6.Text) + "','" + UCase(t7.Text) + "','" + UCase(t4.Text) + "','" + UCase(ame) + "','" + UCase(t5.Text) + "','" + UCase(cb2.Text) + "','" + UCase(t3.Text) + "','" + UCase(cb1.Text) + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then

            sql = "exec edita_plan_contable'" + UCase(t1.Text) + "','" + UCase(t2.Text) + "','" + UCase(cb3.Text) + "','" + UCase(cb4.Text) + "','" + UCase(cb5.Text) + "','" + UCase(t6.Text) + "','" + UCase(t7.Text) + "','" + UCase(t4.Text) + "','" + UCase(ame) + "','" + UCase(t5.Text) + "','" + UCase(cb2.Text) + "','" + UCase(t3.Text) + "','" + UCase(cb1.Text) + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        t1.Enabled = False
        t1.Text = ""
        t2.Enabled = False
        t2.Text = ""
        t3.Enabled = False
        t3.Text = ""
        t4.Enabled = False
        t4.Text = ""
        t5.Enabled = False
        t5.Text = ""
        t6.Enabled = False
        t6.Text = ""
        t7.Enabled = False
        t7.Text = ""
        cb1.Enabled = False
        cb1.Text = ""
        cb2.Enabled = False
        cb2.Text = ""
        cb3.Enabled = False
        cb3.Text = ""
        cb4.Enabled = False
        cb4.Text = ""
        cb5.Enabled = False
        cb5.Text = ""
        cb6.Enabled = False
        cb6.Text = ""
        Button6.Enabled = False
    End Sub

    Private Sub t7_TextChanged(sender As Object, e As EventArgs) Handles t7.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        t9.Enabled = True
        t9.Text = ""
    End Sub

    Private Sub cb6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb6.SelectedIndexChanged
        If cb6.Text = "Ajuste por Diferencia de Cambio, a nivel de saldos, para cuentas en Dólares" Then
            ame = "D"
        Else
            ame = "S"

        End If
    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Cuotas.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t1.Enabled = True
        t1.Text = ""
        t2.Enabled = True
        t2.Text = ""
        t3.Enabled = True
        t3.Text = ""
        t4.Enabled = True
        t4.Text = ""
        t5.Enabled = True
        t5.Text = ""
        t6.Enabled = True
        t6.Text = ""
        t7.Enabled = True
        t7.Text = ""
        cb1.Enabled = True
        cb1.Text = ""
        cb2.Enabled = True
        cb2.Text = ""
        cb3.Enabled = True
        cb3.Text = ""
        cb4.Enabled = True
        cb4.Text = ""
        cb5.Enabled = True
        cb5.Text = ""
        cb6.Enabled = True
        cb6.Text = ""
        Button6.Enabled = True
    End Sub

    Private Sub plancontable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        llenar_combo1()
        llenar_combo2()
        llenar_grid()
    End Sub

    Dim tvsu, tcsu, tvsbs, tcsbs As String
    Dim fe As Date
    Dim hr As TimeSpan
    Dim hrr As Date
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    ' Public Sub conectar()
    'conexion = New SqlClient.SqlConnection
    ' conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    'conexion.Open()
    'End Sub

    Private Sub llenar_grid()
        Try
            sql = "select * from v_plan_contable"
            conexion.conectar()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_plan_contable")
            dgv.DataSource = ds
            dgv.DataMember = "v_plan_contable"
            conexion.Close()
        Catch ex As Exception
            MsgBox("Error de Conexion")
        End Try

    End Sub

    Public Sub llenar_combo1()
        Try
            'sql = "select *from reg_bancos"
            sql = "select cod_sunat,(cod_sunat +' | '+ ncomercio) as bco from reg_bancos"
            conexion.conectar()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            dt = New DataTable
            da.Fill(dt)
            cb1.DataSource = dt
            cb1.DisplayMember = "bco"
            cb1.ValueMember = "cod_sunat"

        Catch ex As Exception
            MsgBox("Error al mostrar datos")
        End Try

    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb4.SelectedIndexChanged

    End Sub
    Public Sub llenar_combo2()
        sql = "select *from moneda"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "moneda"
        cb2.ValueMember = "tmoneda"
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        reg_bancos.Show()
    End Sub

    Private Sub t6_DoubleClick(sender As Object, e As EventArgs) Handles t6.DoubleClick
        dh = 1
        Cuentas_de_Amarres_de_Debe_y_Haber.Show()
    End Sub

    Private Sub t7_DoubleClick(sender As Object, e As EventArgs) Handles t7.DoubleClick
        dh = 2
        Cuentas_de_Amarres_de_Debe_y_Haber.Show()
    End Sub
End Class