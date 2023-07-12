Public Class fac_operacion_anx
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Public cod_clie, cod_anx, igv_comi_tran, mont_t_trans, suma_interes, igv_suma_int, mont_tot_interes, total_abono, total_anexo, gest, fec_expo As String
    Dim mont_comi, p_det, p_des, p_int_cob, p_igv, n_doc, fec_ven_exp, fec_rec_exp, n_dias, cliente, acep, mont_fac, mont_detr, mon_net, mont_des, mont_int_cob, mont_igv, abono, por_comi As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        TextBox2.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        t9.Enabled = True
        T10.Enabled = True
        dtp2.Enabled = True
        T12.Enabled = True
        T13.Enabled = True
        T14.Enabled = True
        T15.Enabled = True
        T16.Enabled = True
        T17.Enabled = True
        T18.Enabled = True
        T19.Enabled = True

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        Anexo.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        suma_grid2()
        Me.Hide()
        Anexo.Show()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        'Dim bus As String
        t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_fac_anx_ope '" + t1.Text + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            TextBox2.Text = dr(22)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
            t8.Text = dr(7)
            t9.Text = dr(8)
            dtp1.Text = dr(9)
            dtp2.Text = dr(10)
            T10.Text = dr(11)
            T11.Text = dr(12)
            T12.Text = dr(13)
            T13.Text = dr(14)
            T14.Text = dr(15)
            T15.Text = dr(16)
            T16.Text = dr(17)
            T17.Text = dr(18)
            T18.Text = dr(19)
            T19.Text = dr(20)


        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        llenar_grid()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim bus As String = InputBox("Ingrese el Codigo de Anexo", "Optima Inversiones")
        sql = "exec ver_fac_anx_ope '" + bus + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            t3.Text = dr(2)
            t4.Text = dr(3)
            TextBox2.Text = dr(22)
            t5.Text = dr(4)
            t6.Text = dr(5)
            t7.Text = dr(6)
            t8.Text = dr(7)
            t9.Text = dr(8)
            dtp1.Text = dr(9)
            dtp2.Text = dr(10)
            T10.Text = dr(11)
            T11.Text = dr(12)
            T12.Text = dr(13)
            T13.Text = dr(14)
            T14.Text = dr(15)
            T15.Text = dr(16)
            T16.Text = dr(17)
            T17.Text = dr(18)
            T18.Text = dr(19)
            T19.Text = dr(20)


        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

    Private Sub fac_operacion_anx_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buscar_anx_fac()
    End Sub

    Dim fec_recep, fec_ven As Date
    Dim accion, nom, appa, apma As String

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim preg As String
        preg = MsgBox("Desea agregar facturas a la operacion de anexo", vbYesNo)
        If preg = vbYes Then
            guardar()
            Button1_Click(sender, e)
        Else
            MessageBox.Show("FACTURAS AGREGADAS")
        End If

    End Sub

    Private Sub guardar()
        nc = t1.Text
        cod_anx = UCase(t2.Text)
        cod_clie = UCase(t3.Text)
        mont_comi = UCase(t4.Text)
        p_det = UCase(t5.Text)
        p_des = UCase(t6.Text)
        p_int_cob = UCase(t7.Text)
        p_igv = UCase(t8.Text)
        n_doc = UCase(t9.Text)
        fec_ven = dtp2.Value
        fec_ven_exp = fec_ven.ToString("yyyyMMdd")
        fec_recep = dtp1.Value
        fec_rec_exp = fec_recep.ToString("yyyyMMdd")
        n_dias = UCase(T10.Text)
        cliente = UCase(T11.Text)
        acep = UCase(T12.Text)
        mont_fac = UCase(T13.Text)
        mont_detr = UCase(T14.Text)
        mon_net = UCase(T15.Text)
        mont_des = UCase(T16.Text)
        mont_int_cob = UCase(T17.Text)
        mont_igv = UCase(T18.Text)
        abono = UCase(T19.Text)
        por_comi = UCase(TextBox2.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_fac_anx_ope'" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "Datos Facturas de Anexo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_fac_anx '" + cod_anx + "','" + cod_clie + "','" + mont_comi + "','" + p_det + "','" + p_des + "','" + p_int_cob + "','" + p_igv + "','" + n_doc + "','" + fec_ven_exp + "','" + fec_rec_exp + "','" + n_dias + "','" + cliente + "','" + acep + "','" + mont_fac + "','" + mont_detr + "','" + mon_net + "','" + mont_des + "','" + mont_int_cob + "','" + mont_igv + "','" + abono + "','" + por_comi + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_fac_anx_ope'" + nc + "','" + cod_anx + "','" + cod_clie + "','" + mont_comi + "','" + p_det + "','" + p_des + "','" + p_int_cob + "','" + p_igv + "','" + n_doc + "','" + fec_ven_exp + "','" + fec_rec_exp + "','" + n_dias + "','" + cliente + "','" + acep + "','" + mont_fac + "','" + mont_detr + "','" + mon_net + "','" + mont_des + "','" + mont_int_cob + "','" + mont_igv + "','" + abono + "','" + por_comi + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If
        buscar_anx_fac()

    End Sub



    Dim sql, nc As String





    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        TextBox2.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        t9.Enabled = True
        t9.Text = ""
        dtp2.Enabled = True
        dtp2.Text = ""
        T10.Enabled = True
        T10.Text = ""
        T12.Enabled = True
        T12.Text = ""
        T13.Enabled = True
        T13.Text = ""
        T14.Enabled = True
        T14.Text = ""
        T15.Enabled = True
        T15.Text = ""
        T16.Enabled = True
        T16.Text = ""
        T17.Enabled = True
        T17.Text = ""
        T18.Enabled = True
        T19.Text = ""
        T19.Enabled = True
        T19.Text = ""

    End Sub

    Private Sub T14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T14.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                T15.Text = T13.Text - T14.Text
            End If
        Catch ex As Exception
            MessageBox.Show("Colocar en monto de Factura y presionar Enter")
        End Try

    End Sub

    Private Sub T14_TextChanged(sender As Object, e As EventArgs) Handles T14.TextChanged

    End Sub

    Private Sub T13_TextChanged(sender As Object, e As EventArgs) Handles T13.TextChanged

    End Sub

    Private Sub T13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T13.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
                T14.Text = (T13.Text * t5.Text) / 100
            End If



    End Sub

    Private Sub T15_TextChanged(sender As Object, e As EventArgs) Handles T15.TextChanged

    End Sub

    Private Sub T15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T15.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            T16.Text = ((T15.Text * t6.Text) / 100)
            Dim mtct As String = T16.Text * (TextBox2.Text / 100)
            If mtct > 175 Then
                t4.Text = mtct
            Else
                t4.Text = 175
            End If
        End If

    End Sub

    Private Sub T16_TextChanged(sender As Object, e As EventArgs) Handles T16.TextChanged

    End Sub

    Private Sub T16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T16.KeyPress

        Dim int As String = t7.Text / 100
        Dim dia As String = T10.Text
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                T17.Text = T16.Text * ((1 + int / 30) ^ dia - 1)
            End If

        Catch ex As Exception
            MessageBox.Show("ingresa dias de factura")
        End Try
    End Sub

    Private Sub T17_TextChanged(sender As Object, e As EventArgs) Handles T17.TextChanged

    End Sub

    Private Sub T17_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T17.KeyPress
        Dim igv As String = t8.Text / 100


        If e.KeyChar = ChrW(Keys.Enter) Then
            T18.Text = T17.Text * igv
        End If
    End Sub

    Private Sub T18_TextChanged(sender As Object, e As EventArgs) Handles T18.TextChanged

    End Sub

    Private Sub T18_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T18.KeyPress

        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                T19.Text = T16.Text - T17.Text - T18.Text
            End If
        Catch ex As Exception
            MessageBox.Show("Los Campos de" & Label18.Text & Label19.Text & Label20.Text & "deben tener Informacion")
        End Try

    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_fac_operacion_anx"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_fac_operacion_anx")
        dgv.DataSource = ds
        dgv.DataMember = "v_fac_operacion_anx"
        conexion.conexion2.Close()
    End Sub

    Public Sub buscar_anx_fac()
        'BUSCA LAS FACTURAS REGISTRADAS POR ANEXO
        nc = Anexo.t2.Text
        sql = "select *from v_fac_operacion_anx where [CODIGO DE ANEXO] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_fac_operacion_anx where [CODIGO DE ANEXO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_fac_operacion_anx where [CODIGO DE ANEXO] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Public Sub suma_grid2()
        Dim t_comi, mt_desc, mt_int, mt_igv, abono As Decimal
        Dim comi_tran As Integer = 3
        Dim mont_des As Integer = 18
        Dim mont_int As Integer = 19
        Dim mont_igv As Integer = 20
        Dim mont_abono As Integer = 21

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        For Each row As DataGridViewRow In dgv.Rows
            t_comi += Val(row.Cells(comi_tran).Value)
            mt_desc += Val(row.Cells(mont_des).Value)
            mt_int += Val(row.Cells(mont_int).Value)
            mt_igv += Val(row.Cells(mont_igv).Value)
            abono += Val(row.Cells(mont_abono).Value)

        Next
        Anexo.t5.Text = t_comi
        igv_comi_tran = t_comi * 0.18
        Anexo.t6.Text = igv_comi_tran
        Anexo.t7.Text = t_comi + igv_comi_tran
        Anexo.t9.Text = mt_int
        Anexo.t10.Text = mt_igv
        Anexo.t11.Text = mt_int + mt_igv
        Anexo.t13.Text = abono
    End Sub

End Class