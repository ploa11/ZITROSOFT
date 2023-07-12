Public Class gast_adm_fomdo

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
    Dim accion, sql, sql2, sql3, nc, gest, tip_partic As String
    Dim vc_act, mont_parti, num_parti As String
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        nc = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_gast_adm_fondo '" + nc + "'"
        'sql = "exec ver_d_participacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(2)
            t3.Text = dr(3)
            t5.Text = dr(5)
            dtp1.Value = dr(1)
            cb1.Text = dr(4)
            t6.Text = dr(6)
        Else
            MessageBox.Show("Los Datos no Existen")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Actualizacion_de_datos.admf.Text = t5.Text
        Actualizacion_de_datos.Button2.Enabled = True
        Actualizacion_de_datos.Button1.Enabled = True
        Actualizacion_de_datos.Show()
        Me.Close()
    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged
        Dim montpi As String = t3.Text
        Dim gaf As String
        Select Case cb1.Text
            Case "1%"
                gaf = montpi * (0.01 / 365)
                t5.Text = gaf
            Case "2%"
                gaf = montpi * (0.02 / 365)
                t5.Text = gaf
            Case "3%"
                gaf = montpi * (0.03 / 365)
                t5.Text = gaf
            Case "4%"
                gaf = montpi * (0.04 / 365)
                t5.Text = gaf
            Case "5%"
                gaf = montpi * (0.05 / 365)
                t5.Text = gaf
        End Select



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fecadfon As Date = dtp1.Value
        Dim fecadfon1 As String = fecadfon.ToString("yyyyMMdd")
        Dim detalle, monto, porcen, monaf, gest As String
        detalle = UCase(t2.Text)
        monto = t3.Text
        porcen = cb1.Text
        monaf = t5.Text
        gest = t6.Text
        nc = t1.Text
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_gast_adm_fondo'" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("El Gasto ya existe", "Gasto de Administracion de fondo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_gast_adm_fondo '" + fecadfon1 + "','" + detalle + "','" + monto + "','" + porcen + "','" + monaf + "','" + gest + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_cliente'" + nc + "','" + fecadfon1 + "','" + detalle + "','" + monto + "','" + porcen + "','" + monaf + "','" + gest + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If
        buscar_copiar()
        llenar_grid()
    End Sub

    Dim res, res2, res3 As Integer
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub gast_adm_fomdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gasto por Administracion del Fondo" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        dgv.AllowUserToAddRows = False
        llenar_grid()
    End Sub

    Public Sub t6_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t2.Enabled = True
        t3.Enabled = True
        cb1.Enabled = True
        t5.Enabled = True
    End Sub
    Private Sub buscar_copiar()
        sql = "select *from GAST_adm_fondo where id in (select max(id) from GAST_ADM_FONDO)"
        'sql = "exec ver_d_participacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(2)
            t3.Text = dr(3)
            t5.Text = dr(5)
            dtp1.Value = dr(1)
            cb1.Text = dr(4)
            t6.Text = dr(6)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        llenar_grid()
        dr.Close()
        conexion.conexion2.Close()
    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_gast_adm_fondo"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_gast_adm_fondo")
        dgv.DataSource = ds
        dgv.DataMember = "v_gast_adm_fondo"
        conexion.conexion2.Close()
    End Sub
End Class