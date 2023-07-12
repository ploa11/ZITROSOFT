Public Class Anex_Cronog
    Dim accion, gestion As String
    'variables publicas
    Public cod_clie, cod_comi_desem, cod_cuop, tip_op, tipodoc_clie, numdoc_clie, cali_finan, cod2 As String

    'variable de fecha
    Dim d1, m1, a1, d2, m2, a2, d3, m3, a3, dia1, mes1, dia2, mes2, dia3, mes3, f_ini, f_term, f_filt As String

    Private Sub t8_TextChanged(sender As Object, e As EventArgs) Handles t8.TextChanged

    End Sub

    Private Sub t9_TextChanged(sender As Object, e As EventArgs) Handles t9.TextChanged

    End Sub

    Private Sub t11_TextChanged(sender As Object, e As EventArgs) Handles t11.TextChanged

    End Sub

    Private Sub t6_TextChanged(sender As Object, e As EventArgs) Handles t6.TextChanged

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        '-------------------------------------------------------
        'llenar codigido de participe
        Dim cod1 As String
        ' Dim nfila, ncolu As Integer
        'detalle = ""
        'nfila = dgv.CurrentCell.RowIndex
        'ncolu = dgv.CurrentCell.ColumnIndex

        cod1 = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_d_operacion '" + cod1 + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            'cod2 = dr(0)
            t2.Text = dr(1)
            cb1.Text = dr(4)
            t5.Text = dr(5)
            t6.Text = dr(6)
            t7.Text = dr(7)
            t8.Text = dr(8)
            t9.Text = dr(9)
            t10.Text = dr(10)
            t11.Text = dr(11)
            t12.Text = dr(12)
            dtp1.Value = dr(13)
            dtp2.Value = dr(14)
            cb2.Text = dr(15)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
        Button6.Enabled = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        comisiones_por_desembolso.Show()
        comisiones_por_desembolso.llenar_grid()
        comisiones_por_desembolso.suma_grid2()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '-------------------------------------------------------
        'llenar codigido de participe
        nc = InputBox("Ingrese el Codigo de Operacion")
        sql = "exec ver_d_operacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            cb1.Text = dr(4)
            t5.Text = dr(5)
            t6.Text = dr(6)
            t7.Text = dr(7)
            t8.Text = dr(8)
            t9.Text = dr(9)
            t10.Text = dr(10)
            t11.Text = dr(11)
            t12.Text = dr(12)
            dtp1.Value = dr(13)
            dtp2.Value = dr(14)
            cb2.Text = dr(15)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
        Button6.Enabled = True
    End Sub

    Private Sub t13_TextChanged(sender As Object, e As EventArgs) Handles t13.TextChanged

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        registro_clientes.Button4_Click(sender, e)
    End Sub

    Private Sub t12_TextChanged(sender As Object, e As EventArgs) Handles t12.TextChanged

    End Sub

    'procentajes y montos de porcentajes
    Dim pgcd, pigv, pint, mgcd, migv, mint As String

    'montos prestamos
    Dim mont_soli, mont_prest As String



    'variable locales
    Dim sql, nc As String
    Dim res As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        gasto_comi_desembolso()
        Cuotas_Operacion.Show()

    End Sub

    Private Sub gasto_comi_desembolso()
        Dim comi, detalle As String
        Dim f_i As Date = dtp1.Value
        Dim f_v As Date = dtp2.Value
        ''Dim nfila, ncolu As Integer
        comi = "guardar"
        detalle = ""
        'nfila = dgv.CurrentCell.RowIndex
        ' ncolu = dgv.CurrentCell.ColumnIndex

        'cod = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        'dgv.FirstDisplayedScrollingRowIndex = dgv.RowCount - 1
        'guardar fechas sql
        dia1 = dtp1.Value.Date
        mes1 = dtp1.Value.Date
        a1 = dtp1.Value.Year
        dia2 = dtp2.Value.Date
        mes2 = dtp2.Value.Date
        a2 = dtp2.Value.Year
        d1 = dia1.Substring(0, dia1.IndexOf("/"))
        m1 = mes1.Substring(3, mes1.IndexOf("/"))
        d2 = dia2.Substring(0, dia2.IndexOf("/"))
        m2 = mes2.Substring(3, mes2.IndexOf("/"))
        f_ini = f_i.ToString("yyyyMMdd")
        f_term = f_v.ToString("yyyyMMdd")
        cod2 = t1.Text
        If comi = "guardar" Then
            sql = "exec ver_comi_desem'" + cod2 + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "Datos Comision Desembolso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_comi_desembolso '" + f_ini + "','" + detalle + "','" + mgcd + "','" + cod2 + "','" + gestion + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")

            End If
            'ElseIf accion = "editar" Then
            'sql = "exec edita_comi_desem'" + f_ini + "','" + detalle + "','" + mgcd + "','" + cod + "','" + gestion + "'"
            'conexion.conectarfondo()
            'com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            ' res = com.ExecuteNonQuery
            ' conexion.conexion2.Close()
            'MessageBox.Show("Registro Modificado")

        End If
        '---------------------------------------------------------------------------------------
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        accion = "guardar"
        t2.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        t9.Enabled = True
        t10.Enabled = True
        t11.Enabled = True
        t12.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        dtp1.Enabled = True
        dtp2.Enabled = True
        t1.Text = ""
        t2.Text = ""
        t5.Text = ""
        t6.Text = 1
        t7.Text = ""
        t8.Text = 18
        t9.Text = ""
        t10.Text = ""
        t11.Text = 2
        t12.Text = ""
        cb1.Text = ""
        cb2.Text = ""


    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Anex_Cronog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grid()
        llenar_combo1()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        t1.Enabled = True
        t2.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        t9.Enabled = True
        t10.Enabled = True
        t11.Enabled = True
        t12.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        dtp1.Enabled = True
        dtp2.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        cb3.Enabled = True
        t13.Enabled = True
        dtp3.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim fe_ini As Date = dtp1.Value 'guardar fechas sql
        Dim fe_fin As Date = dtp2.Value
        dia1 = dtp1.Value.Date
        mes1 = dtp1.Value.Date
        a1 = dtp1.Value.Year
        dia2 = dtp2.Value.Date
        mes2 = dtp2.Value.Date
        a2 = dtp2.Value.Year
        d1 = dia1.Substring(0, dia1.IndexOf("/"))
        m1 = mes1.Substring(3, mes1.IndexOf("/"))
        d2 = dia2.Substring(0, dia2.IndexOf("/"))
        m2 = mes2.Substring(3, mes2.IndexOf("/"))

        'f_ini = a1 + m1 + d1 'concatenar fecha inicia
        'f_term = a2 + m2 + d2 'concatenar fecha termino
        'fin de fechas sql
        f_ini = fe_ini.ToString("yyyyMMdd")
        f_term = fe_fin.ToString("yyyyMMdd")
        Button1.Enabled = True
        '---------------------------------------------------------
        '-registro de los datos
        nc = UCase(t1.Text)
        cod_clie = UCase(t2.Text)
        cod_comi_desem = ""
        cod_cuop = ""
        tip_op = UCase(cb1.Text)
        mont_soli = UCase(t5.Text)
        pgcd = UCase(t6.Text)
        mgcd = UCase(t7.Text)
        pigv = UCase(t8.Text)
        migv = UCase(t9.Text)
        mont_prest = UCase(t10.Text)
        pint = UCase(t11.Text)
        mint = UCase(t12.Text)
        gestion = UCase(cb2.Text)
        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_d_operacion'" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "Datos oepracion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_d_operacion '" + cod_clie + "','" + cod_comi_desem + "','" + cod_cuop + "','" + tip_op + "','" + mont_soli + "','" + pgcd + "','" + mgcd + "','" + pigv + "','" + migv + "','" + mont_prest + "','" + pint + "','" + mint + "','" + f_ini + "','" + f_term + "','" + gestion + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")
                buscar_copiar()

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_d_operacion'" + nc + "','" + cod_clie + "','" + cod_comi_desem + "','" + cod_cuop + "','" + tip_op + "','" + mont_soli + "','" + pgcd + "','" + mgcd + "','" + pigv + "','" + migv + "','" + mont_prest + "','" + pint + "','" + mint + "','" + f_ini + "','" + f_term + "','" + gestion + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If
        Button6.Enabled = True
        llenar_grid()

        t1.Enabled = False
        t2.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t8.Enabled = False
        t9.Enabled = False
        t10.Enabled = False
        t11.Enabled = False
        t12.Enabled = False
        dtp1.Enabled = False
        dtp2.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = True



    End Sub
    Private Sub llenar_grid()
        sql = "select * from v_d_operacion"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_d_operacion")
        dgv.DataSource = ds
        dgv.DataMember = "v_d_operacion"
        conexion.conexion2.Close()
    End Sub

    Private Sub t6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t6.KeyPress

        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                t7.Text = (t5.Text * t6.Text) / 100
            End If
        Catch ex As Exception
            MessageBox.Show("Ingresa el Porcentaje de Comision de desembolso")
        End Try


    End Sub

    Private Sub t9_Move(sender As Object, e As EventArgs) Handles t9.Move

    End Sub

    Private Sub t9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t9.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim a As Decimal = t5.Text
            Dim b As Decimal = t7.Text
            Dim c As Decimal = t9.Text
            t10.Text = a + b + c
        End If
    End Sub

    Private Sub t8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t8.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                t9.Text = ((t7.Text * t8.Text) / 100)
            End If
        Catch ex As Exception
            MessageBox.Show("Ingresa Porcentaje de Igv")
        End Try

    End Sub

    Private Sub t11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t11.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                t12.Text = ((t10.Text * t11.Text) / 100)
            End If
        Catch ex As Exception
            MessageBox.Show("Ingese Porcentaje de Interes")
        End Try
    End Sub

    Public Sub llenar_combo1()
        sql = "select *from gestio_bdp"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "gestio_bdp"
        cb2.ValueMember = "gestion"
    End Sub
    Private Sub buscar_copiar()

        sql = "select *from d_operacion where id in (select max(id) from d_operacion)"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            t1.Text = dr(0)
            t2.Text = dr(1)
            cb1.Text = dr(4)
            t5.Text = dr(5)
            t6.Text = dr(6)
            t7.Text = dr(7)
            t8.Text = dr(8)
            t9.Text = dr(9)
            t10.Text = dr(10)
            dtp1.Text = dr(13)
            dtp2.Text = dr(14)
            cb2.Text = dr(15)
        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub

End Class