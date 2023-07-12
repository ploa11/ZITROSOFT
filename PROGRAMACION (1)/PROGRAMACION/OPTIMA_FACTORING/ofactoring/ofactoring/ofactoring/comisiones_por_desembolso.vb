Public Class comisiones_por_desembolso

    'variable locales
    Dim sql, nc As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenar_grid2()
        suma_grid2()

    End Sub

    Private Sub comisiones_por_desembolso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        llenar_combo1()
        suma_grid2()
    End Sub
    Public Sub llenar_grid()
        sql = "select * from v_gast_comi_desem where [CODIGO DE CRONOGRAMA O ANEXO] like'" + Anex_Cronog.t1.Text + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(Sql, conexion.conexion2)
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

    Public Sub llenar_combo1()
        sql = "select *from gestio_bdp"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "gestio_bdp"
        cb1.ValueMember = "gestion"
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

    Private Sub cb1_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb1.SelectedValueChanged
        llenar_grid3()
        suma_grid2()
    End Sub
End Class