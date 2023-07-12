Public Class Cuentas_de_Amarres_de_Debe_y_Haber
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
    Dim accion As String, nc As String, sql As String
    Dim res As Integer, tc As String, td As String, nd As String, ce As String
    Dim ncome, rsoc, tipdoc, ndoc As String
    Dim pass As String, telef As String, anx As String, nom As String, app As String, apm As String

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Select Case plancontable.dh
            Case 1
                buscar_debe()
            Case 2
                buscar_haber()
            Case 3
                buscar_plan_asientos()
        End Select

        'If plancontable.dh = 1 Then
        'buscar_debe()
        'Else
        'buscar_haber()
        ' End If
    End Sub
    Private Sub buscar_debe()
        t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_plan_contable '" + t1.Text + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            plancontable.t6.Text = dr(0)
        Else
            MessageBox.Show("La cuenta no existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cuotas.Show()
    End Sub

    Private Sub buscar_haber()
        t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_plan_contable '" + t1.Text + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            plancontable.t7.Text = dr(0)
        Else
            MessageBox.Show("La cuenta no existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        Me.Close()
    End Sub

    Private Sub buscar_plan_asientos()
        t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_plan_contable '" + t1.Text + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            G_Asientos.cuenta.Text = dr(0)
        Else
            MessageBox.Show("La cuenta no existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        Me.Close()
    End Sub
    Private Sub buscar_plan_parame_asientos()
        t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_plan_contable '" + t1.Text + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            param_asientos.t1.Text = dr(0)
            param_asientos.t2.Text = dr(1)
        Else
            MessageBox.Show("La cuenta no existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Dim m1, m2, ent, fecha, hora As String
    Dim tvsu, tcsu, tvsbs, tcsbs As String
    Dim fe As Date
    Dim hr As TimeSpan
    Dim hrr As Date
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles t1.TextChanged
        Try
            nc = t1.Text
            sql = "select *from v_amarre where [NUMERO DE CUENTA] like'" + nc + "%'"
            conexion.conectar()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_amarre where [NUMERO DE CUENTA] like'" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_amarre where [NUMERO DE CUENTA] like'" + nc + "%'"
            conexion.conexion.Close()
        Catch ex As Exception
            MsgBox("Error de Conexion a base de datos")
        End Try

    End Sub

    Private Sub Cuentas_de_Amarres_de_Debe_y_Haber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        llenar_grid()
    End Sub
    Private Sub llenar_grid()
        Try
            sql = "select * from v_amarre"
            conexion.conectar()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_amarre")
            dgv.DataSource = ds
            dgv.DataMember = "v_amarre"
            conexion.Close()
        Catch ex As Exception
            MsgBox("Error de Conexion")
        End Try

    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        If param_asientos.plan = 1 Then
            buscar_plan_parame_asientos()
        Else
            param_asientos.t1.Text = ""
        End If


    End Sub
End Class