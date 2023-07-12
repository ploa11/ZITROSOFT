Public Class Actualizacion_de_datos
    'variables publicas
    Dim dist_bene, moneda, nom_parti, cod_parti, nom_manco, cod_manco, nom_fondo, cod_fondo, unida_nego, gestion As String
    Dim mont_minimo, mont_maxi, v_cuota_nominal, v_cuota_actual As String
    Dim n_ruc As String


    'variable locales
    Dim accion, sql, nc, gest, tip_partic As String

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Dim vc_act, mont_parti, num_parti As String
    'varivlae de fecha
    Dim d1, m1, a1, d2, m2, a2, d3, m3, a3, d4, m4, a4, d5, m5, a5, dia1, mes1, dia2, mes2, dia3, mes3, dia4, mes4, dia5, mes5, fec_crea, fec_ini_sunat, fec_ini_opera, fec_ter_opera, fec_actu As String
    'variable de conexion sql
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim res As Integer
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub t12_TextChanged(sender As Object, e As EventArgs) Handles t12.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Datos_Generales_del_Fondo.Button3_Click(sender, e)
        suma_grid2()
        accion = "guardar"
        dtp1.Enabled = True

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        d1 = dtp1.Value.Date
        m1 = dtp1.Value.Date
        a1 = dtp1.Value.Year
        d2 = dtp2.Value.Date
        m2 = dtp2.Value.Date
        a2 = dtp2.Value.Year
        d3 = dtp3.Value.Date
        m3 = dtp3.Value.Date
        a3 = dtp3.Value.Year
        d4 = dtp4.Value.Date
        m4 = dtp4.Value.Date
        a4 = dtp4.Value.Year
        d5 = dtp5.Value.Date
        m5 = dtp5.Value.Date
        a5 = dtp5.Value.Year
        dia1 = d1.Substring(0, d1.IndexOf("/"))
        mes1 = m1.Substring(3, m1.IndexOf("/"))
        dia2 = d2.Substring(0, d2.IndexOf("/"))
        mes2 = m2.Substring(3, m2.IndexOf("/"))
        dia3 = d3.Substring(0, d3.IndexOf("/"))
        mes3 = m3.Substring(3, m3.IndexOf("/"))
        dia4 = d4.Substring(0, d4.IndexOf("/"))
        mes4 = m4.Substring(3, m4.IndexOf("/"))
        dia5 = d5.Substring(0, d5.IndexOf("/"))
        mes5 = m5.Substring(3, m5.IndexOf("/"))
        fec_actu = a1 + mes1 + dia1 'concatenar fecha para actualizar
        fec_crea = a2 + mes2 + dia2 'concatenar fecha creacion
        fec_ini_sunat = a3 + mes3 + dia3 ' concatenar fecha de inscripcion sunat
        fec_ini_opera = a4 + mes4 + dia4 'concatenar fecha de inicio de operaciones
        fec_ter_opera = a5 + mes5 + dia5 ' concatenar fecha de termino de operacion


        '-----------------------------------------------------

        cod_fondo = t1.Text
        dist_bene = t2.Text
        moneda = t3.Text
        mont_minimo = t4.Text
        mont_maxi = t5.Text
        nom_fondo = t13.Text
        unida_nego = t7.Text
        n_ruc = t8.Text
        v_cuota_nominal = t9.Text
        v_cuota_actual = t10.Text
        gestion = t12.Text
        nom_fondo = t13.Text
        t11.Text = 0.0000


        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_datos_fondos'" + fec_actu + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Datos ya existen", "DATOS DE FONDOS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                sql = "exec alta_DATOS_FONDO '" + cod_fondo + "','" + dist_bene + "','" + nom_fondo + "','" + moneda + "','" + mont_minimo + "','" + mont_maxi + "','" + unida_nego + "','" + fec_crea + "','" + fec_ini_sunat + "','" + n_ruc + "','" + fec_ini_opera + "','" + fec_ter_opera + "','" + v_cuota_nominal + "','" + v_cuota_actual + "','" + gestion + "','" + fec_actu + "'"
                'sql = "exec alta_DATOS_FONDO 'fo001','bimestral','Fondos nuevo ',' soles ','10000.222','20000.3333','construccion','20151010','20151111','1234567890','20171111','20221010','1000.00000','100.00000','2015','20171218'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Guardado")


            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_datos_fondo '" + cod_fondo + "','" + dist_bene + "','" + nom_fondo + "','" + moneda + "','" + mont_minimo + "','" + mont_maxi + "','" + unida_nego + "','" + fec_crea + "','" + fec_ini_sunat + "','" + n_ruc + "','" + fec_ini_opera + "','" + fec_ter_opera + "','" + v_cuota_nominal + "','" + v_cuota_actual + "','" + gestion + "','" + fec_actu + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            MessageBox.Show("Registro Modificado")

        End If


        llenar_grid()
        suma_grid2()
        actualiza_datos()
    End Sub

    Private Sub actualiza_datos()

        sql = ""
        If accion = "guardar" Then
            sql = "exec ver_datos_fondos'" + cod_fondo + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Datos ya existen", "DATOS DE FONDOS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion.Close()
            Else
                sql = "exec alta_datos_fondos'" + cod_fondo + "','" + nom_fondo + "','" + v_cuota_nominal + "','" + v_cuota_actual + "','" + t6.Text + "','" + t11.Text + "','" + fec_actu + "','" + moneda + "'"
                'sql = "exec alta_DATOS_FONDO 'fo001','bimestral','Fondos nuevo ',' soles ','10000.222','20000.3333','construccion','20151010','20151111','1234567890','20171111','20221010','1000.00000','100.00000','2015','20171218'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        End If

    End Sub


    Private Sub Actualizacion_de_datos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        llenar_grid()
        'suma_grid2()
    End Sub

    Private Sub llenar_grid()
        sql = "select * from v_datos_fondo"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_datos_fondo")
        dgv.DataSource = ds
        dgv.DataMember = "v_datos_fondo"
        conexion.conexion2.Close()
    End Sub

    Private Sub suma_grid()

        Dim total As Double = 0
        Dim itotal As Integer = dgv.Rows.Count
        Dim i As Integer

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        For i = 0 To itotal - 1
            total = total + Double.Parse(dgv(7, i).Value)

        Next
        t6.Text = Format(total, "$ #,##0.00")
    End Sub

    Public Sub suma_grid2()
        Dim total As Decimal
        Dim col As Integer = 6

        't1.Text = Datos_Generales_del_Fondo.t1.Text
        For Each row As DataGridViewRow In dgv.Rows
            total += Val(row.Cells(col).Value)

        Next
        t6.Text = total
    End Sub



End Class