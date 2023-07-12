Public Class Anexo
    'variable prublicas
    Public cod_clie, comi_tra, igv_comi_tran, mont_t_trans, suma_interes, igv_suma_int, mont_tot_interes, total_abono, total_anexo, gest, fec_expo As String
    Dim fec_recep As Date
    Dim accion, nom, appa, apma As String
    Dim sql, nc As String

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        nc = InputBox("Ingrese el Codigo de Anexo", "Optima Inversiones")
        sql = "exec ver_anx_ope '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t3.Text = dr(12)
            t5.Text = dr(1)
            t6.Text = dr(2)
            t7.Text = dr(3)
            t9.Text = dr(4)
            t10.Text = dr(5)
            t11.Text = dr(6)
            t12.Text = dr(7)
            t13.Text = dr(8)
            dtp2.Text = dr(9)
            cb2.Text = dr(10)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim bus As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value

        sql = "exec ver_anx_ope '" + bus + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t3.Text = dr(12)
            t5.Text = dr(1)
            t6.Text = dr(2)
            t7.Text = dr(3)
            t9.Text = dr(4)
            t10.Text = dr(5)
            t11.Text = dr(6)
            t12.Text = dr(7)
            t13.Text = dr(8)
            dtp2.Text = dr(9)
            cb2.Text = dr(10)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "editar"
        Button6.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        fac_operacion_anx.Show()
        facturas()
        Me.Hide()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        fec_recep = dtp2.Value
        nc = t2.Text
        cod_clie = t3.Text
        fec_expo = fec_recep.ToString("yyyyMMdd")
        gest = cb2.Text
        comi_tra = t5.Text
        igv_comi_tran = t6.Text
        mont_tot_interes = t11.Text
        mont_t_trans = t7.Text
        igv_suma_int = t10.Text
        total_abono = 0
        total_anexo = t13.Text
        suma_interes = t9.Text
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_anx_ope'" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "Datos Anexo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_anx_ope '" + comi_tra + "','" + igv_comi_tran + "','" + mont_t_trans + "','" + suma_interes + "','" + igv_suma_int + "','" + mont_tot_interes + "','" + total_abono + "','" + total_anexo + "','" + fec_expo + "','" + gest + "','" + cod_clie + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")
                buscar_copiar()
                llenar_grid()
                facturas()
                fac_operacion_anx.Show()
            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_anx_ope'" + nc + "','" + comi_tra + "','" + igv_comi_tran + "','" + mont_t_trans + "','" + suma_interes + "','" + igv_suma_int + "','" + mont_tot_interes + "','" + total_abono + "','" + total_anexo + "','" + fec_expo + "','" + gest + "','" + cod_clie + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If
        llenar_grid()
        cb2.Enabled = False
        t2.Enabled = False
    End Sub

    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub Anexo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combo1()
        llenar_grid()
        Label17.Hide()
        t12.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "guardar"
        't2.Enabled = True
        t3.Enabled = True
        dtp2.Enabled = True
        cb2.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        registro_clientes.Button4_Click(sender, e)
        cod_clie = registro_clientes.t1.Text
        t3.Text = cod_clie


    End Sub

    Public Sub llenar_combo1()
        Sql = "select *from gestio_bdp"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(Sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "gestio_bdp"
        cb2.ValueMember = "gestion"
    End Sub

    Public Sub buscar_copiar()

        sql = "select *from d_operacion_anx where id in (select max(id) from d_operacion_anx)"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t3.Text = dr(12)
            dtp2.Text = dr(9)
            cb2.Text = dr(10)
            t5.Text = dr(1)
            t6.Text = dr(2)
            t7.Text = dr(3)
            t9.Text = dr(4)
            t10.Text = dr(5)
            t11.Text = dr(6)
            t12.Text = dr(7)
            t13.Text = dr(8)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_d_operacion_anx"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_d_operacion_anx")
        dgv.DataSource = ds
        dgv.DataMember = "v_d_operacion_anx"
        conexion.conexion2.Close()
    End Sub
    Private Sub facturas()
        fac_operacion_anx.t2.Text = t2.Text
        fac_operacion_anx.t3.Text = t3.Text
        fac_operacion_anx.t4.Text = 175.0
        fac_operacion_anx.t5.Text = 0
        fac_operacion_anx.t6.Text = 85
        fac_operacion_anx.TextBox2.Text = 1
        fac_operacion_anx.t7.Text = 2
        fac_operacion_anx.t8.Text = 18
        fac_operacion_anx.dtp1.Text = dtp2.Text
        nc = t3.Text
        sql = "exec ver_reg_cliente '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            nom = dr(2)
            appa = dr(3)
            apma = dr(4)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
        fac_operacion_anx.T11.Text = nom & " " & appa & " " & apma



    End Sub
End Class