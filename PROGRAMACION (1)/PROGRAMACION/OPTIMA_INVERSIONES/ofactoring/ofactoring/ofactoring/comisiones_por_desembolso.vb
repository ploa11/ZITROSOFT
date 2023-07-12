Public Class comisiones_por_desembolso
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
    'variable locales
    Dim sql, nc As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Public dcb, igvdcb As Decimal

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenar_grid2()
        suma_grid2()
        suma_grid_igv()
        dcb = t1.Text
        igvdcb = t2.Text
        t3.Text = dcb + igvdcb

    End Sub

    Private Sub comisiones_por_desembolso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        Me.Text = "Comisiones por Desembolso" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        llenar_grid()
        llenar_combo1()
        suma_grid2()
        suma_grid_igv()
        dcb = t1.Text
        igvdcb = t2.Text
        t3.Text = dcb + igvdcb
    End Sub
    Public Sub llenar_grid()
        sql = "select * from v_gast_comi_desem where [CODIGO DE CRONOGRAMA O ANEXO] like'" + Anex_Cronog.t1.Text + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_gast_comi_desem")
        dgv.DataSource = ds
        dgv.DataMember = "v_gast_comi_desem"
        conexion.conexion2.Close()
    End Sub
    Public Sub filtrar_facturacion()
        sql = "select * from v_gast_comi_desem where [CODIGO DE CRONOGRAMA O ANEXO] like'" + facturacion_fondos.t2.Text + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_gast_comi_desem")
        dgv.DataSource = ds
        dgv.DataMember = "v_gast_comi_desem"
        conexion.conexion2.Close()
    End Sub

    Public Sub llenar_grid2()
        sql = "select * from v_gast_comi_desem"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_gast_comi_desem")
        dgv.DataSource = ds
        dgv.DataMember = "v_gast_comi_desem"
        conexion.conexion2.Close()
    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged

    End Sub

    Public Sub llenar_grid3()
        sql = "select * from v_gast_comi_desem where [GESTION] like'" + cb1.Text + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_gast_comi_desem")
        dgv.DataSource = ds
        dgv.DataMember = "v_gast_comi_desem"
        conexion.conexion2.Close()
    End Sub

    Public Sub t1_TextChanged(sender As Object, e As EventArgs) Handles t1.TextChanged

    End Sub

    Public Sub llenar_combo1()
        sql = "select *from gestio_bdp"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "DETALLE"
        cb1.ValueMember = "DETALLE"
    End Sub

    Public Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles t2.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fec_ran_ini, fec_ran_fin As Date
        Dim franini, franfin As String

        fec_ran_ini = dtp5.Value
        fec_ran_fin = dtp6.Value
        franini = fec_ran_ini.ToString("yyyyMMdd")
        franfin = fec_ran_fin.ToString("yyyyMMdd")

        'Select Case cb1.Text
        'Case "Cuotas Cronogramas"
        ran_fec_crono(franini, franfin)
        'Case "Facturas Anexos"
        'ran_fec_anexo(franini, franfin)
        'End Select
        'llenar_grid2()
        suma_grid2()
        suma_grid_igv()
        dcb = t1.Text
        igvdcb = t2.Text
        t3.Text = dcb + igvdcb

    End Sub

    Private Sub ran_fec_crono(fec1, fec2)
        sql = "select  *from v_gast_comi_desem where [FECHA]>='" + fec1 + "' and [FECHA]<='" + fec2 + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select  *from v_gast_comi_desem where [FECHA]>='" + fec1 + "' and [FECHA]<='" + fec2 + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select  *from v_gast_comi_desem where [FECHA]>='" + fec1 + "' and [FECHA]<='" + fec2 + "'"
        conexion.conexion2.Close()
    End Sub

    Public Sub t3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Public Sub suma_grid2()
        Dim total As Decimal
        Dim col As Integer = 2

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        For Each row As DataGridViewRow In dgv.Rows
            total += Val(row.Cells(col).Value)

        Next
        t1.Text = total
    End Sub

    Public Sub suma_grid_igv()
        Dim total As Decimal
        Dim col2 As Integer = 3

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        For Each row As DataGridViewRow In dgv.Rows
            total += Val(row.Cells(col2).Value)

        Next
        t2.Text = total
    End Sub

    Private Sub cb1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb1.SelectedValueChanged
        llenar_grid3()
        suma_grid2()
    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Dim comi, igv As Decimal

        comi = dgv.Rows(dgv.CurrentRow.Index).Cells(2).Value
        igv = dgv.Rows(dgv.CurrentRow.Index).Cells(3).Value

        facturacion_fondos.t4.Text = comi
        facturacion_fondos.t5.Text = igv
        facturacion_fondos.comi_des = comi
        facturacion_fondos.igv_comides = igv
        facturacion_fondos.Label6.Visible = True
        facturacion_fondos.Label7.Visible = True
        facturacion_fondos.t4.Visible = True
        facturacion_fondos.t5.Visible = True
        Me.Close()


    End Sub
End Class