Public Class desembolsos
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
    Public a As Integer
    Dim res, res2 As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ref, est, mont_comi, p_det, p_des, p_int_cob, p_igv, n_doc, fec_ven_exp, fec_rec_exp, n_dias, cliente, acep, mont_fac, mont_detr, mon_net, mont_des, mont_int_cob, mont_igv, abono, por_comi As String

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        a = 2
        Mov_bancos.Show()
        dgv.Enabled = False
        Mov_bancos.Button9.Visible = False
        Mov_bancos.Button12.Visible = True
        Mov_bancos.Button12.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Dim acciones, glosa, fec, fecha, analitica, cuenta, nom_cuenta, ruc, cod, banco As String
    Dim debe, haber As Decimal

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        a = 1
        Mov_bancos.Show()
        dgv.Enabled = False
        Button4.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Dim cod1, cod_gc, cod_cuo, tip_op, fecin, fecter, gestion As String
    Dim fecini, fecterm As Date


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If cb3.Text = "Pendiente de Desembolso" Then
                MsgBox("Para cambiar datos el estado debe se Desembolsado")
            Else
                actualizar_cronograma()
                Crono()
                coloini()
                Button2.Enabled = True
                cb3.Enabled = False
                t13.Enabled = False
                Button3.Enabled = False

            End If
        Catch ex As Exception
            MsgBox("Error en el Proceso")
        End Try



    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        'llenar codigido de participe

        ' Dim nfila, ncolu As Integer
        'detalle = ""
        'nfila = dgv.CurrentCell.RowIndex
        'ncolu = dgv.CurrentCell.ColumnIndex
        Try
            cod1 = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
            sql = "exec ver_d_operacion '" + cod1 + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                t1.Text = dr(0)
                t2.Text = dr(1)
                cod_gc = dr(2)
                cod_cuo = dr(3)
                tip_op = dr(4)
                t3.Text = dr(5)
                t4.Text = dr(6)
                t5.Text = dr(7)
                t6.Text = dr(8)
                t7.Text = dr(9)
                t8.Text = dr(10)
                t9.Text = dr(11)
                t10.Text = dr(12)
                t11.Text = dr(13)
                fecini = dr(13)
                fecin = fecini.ToString("yyyyMMdd")
                t12.Text = dr(14)
                fecterm = dr(14)
                fecter = fecterm.ToString("yyyyMMdd")
                gestion = dr(15)
                est = dr(17)
                cb3.Text = dr(18)
                t13.Text = dr(19)
                TextBox1.Text = dr(20)

            Else
                MessageBox.Show("Los Datos no Existen")
            End If
            dr.Close()
            conexion.conexion2.Close()
            Button3.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Error al filtrar datos")
        End Try


    End Sub

    Private Sub cb2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb2.SelectedIndexChanged

    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged
        Select Case cb2.Text
            Case "CRONOGRAMAS"
                Crono()
                coloini()
            Case "ANEXOS"
                anexo()
                coloini()
        End Select
    End Sub

    Public cod_clie, cod_anx, igv_comi_tran, mont_t_trans, suma_interes, igv_suma_int, mont_tot_interes, total_abono, total_anexo, gest, fec_expo, int_d As String
    Dim sql, sql2, sql3, nc As String

    Private Sub Crono()
        Try
            sql = "select * from v_d_operacion where [ESTADO TESORERIA]='" + cb1.Text + "' ORDER BY [FECHA INICIO DE PRESTAMO] DESC "
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_d_operacion")
            dgv.DataSource = ds
            dgv.DataMember = "v_d_operacion"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("No hay conexion con la lista", "Optima")
        End Try

    End Sub
    Private Sub anexo()
        Try
            sql = "select * from v_d_operacion_anx where [ESTADO TESORERIA]='" + cb1.Text + "' ORDER BY [FECHA DE RECEPCION] DESC "
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_d_operacion")
            dgv.DataSource = ds
            dgv.DataMember = "v_d_operacion"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("No hay conexion con la lista", "Optima")
        End Try

    End Sub

    Private Sub coloini()

        For Each Row As DataGridViewRow In dgv.Rows
            Select Case cb1.Text
                Case "PENDIENTE DESEMBOLSO"

                    If Row.Cells("ESTADO TESORERIA").Value = "PENDIENTE DESEMBOLSO" Then
                        Row.DefaultCellStyle.BackColor = Color.LightBlue
                        Row.DefaultCellStyle.ForeColor = Color.Black
                    End If


                Case "DESEMBOLSADO"

                    If Row.Cells("ESTADO TESORERIA").Value = "DESEMBOLSADO" Then
                        Row.DefaultCellStyle.BackColor = Color.Blue
                        Row.DefaultCellStyle.ForeColor = Color.White
                    End If


            End Select


            'If Today = Row.Cells("FECHA INICIO DE PRESTAMO").Value Then
            'Row.DefaultCellStyle.BackColor = Color.Blue
            'Row.DefaultCellStyle.ForeColor = Color.White
            'End If


        Next

    End Sub
    Private Sub desembolsos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        Me.Text = "Desembolsos Crnogramas y Anexos" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        a = 0
    End Sub

    Private Sub actualizar_cronograma()
        sql = "update d_operacion set  est_teso='" + cb3.Text + "', banco_fondo='" + t13.Text + "',banco_clie='" + TextBox1.Text + "'where cod_op='" + t1.Text + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        res = com.ExecuteNonQuery
        conexion.conexion2.Close()
        MessageBox.Show("Registro Modificado")
    End Sub

    Private Sub gen_asiento()
        acciones = "guardar"
        sql = ""
        glosa = "LIQUIDACION DE LA OPERACIÓN POR EL CRONOGRAMA" + " " + t1.Text + " " + "POR DESEMBOLSO"
        'TextBox1.Text = glosa
        fec = t11.Text
        fecha = t11.Text
        analitica = t2.Text
        bcliente()
        Dim mont1, mont2 As Double
        Try
            For con = 1 To 3
                Select Case con
                    Case = 1
                        cuenta = "421111"
                        buscar_cuenta()
                        mont1 = t8.Text
                        debe = mont1
                        haber = 0.0

                        guardar_asiento()
                    Case = 2
                        cuenta = "121211"
                        buscar_cuenta()
                        mont2 = t4.Text
                        debe = 0.0
                        haber = mont2
                        guardar_asiento()
                    Case = 3
                        cuenta = banco
                        buscar_cuenta()
                        mont1 = t3.Text
                        debe = 0.0
                        haber = mont1
                        guardar_asiento()

                End Select

            Next
            MessageBox.Show("Asientos Contables Generados")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub buscar_cuenta()
        sql = "Select *from plan_contable where cuenta Like'" + cuenta + "%'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            nom_cuenta = dr(1)
        Else
            MessageBox.Show("La Cuenta no existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        'Button3.Enabled = True
        'Button5.Enabled = True
        'Button6.Enabled = True
    End Sub
    Private Sub guardar_asiento()
        sql = ""
        If acciones = "guardar" Then

            'sql = "exec ver_asiento_contable'" + cod + "'"
            'conexion.conectarfondo()
            'com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            'dr = com.ExecuteReader
            'If dr.Read Then
            'MessageBox.Show("Los Datos ya Existen", "Datos de Asientos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'dr.Close()
            'conexion.conexion2.Close()
            'Else
            sql = "exec alta_asiento_contable '" + glosa + "','" + ruc + "','" + analitica + "','" + cuenta + "','" + nom_cuenta + "','" + debe + "','" + haber + "','" + fecha + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            'MessageBox.Show("Registro Guardado")
            'buscar_copiar()

        Else


            sql = "exec edita_asiento_contable'" + cod + "','" + glosa + "','" + ruc + "','" + analitica + "','" + cuenta + "','" + nom_cuenta + "','" + debe + "','" + haber + "','" + fecha + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            'MessageBox.Show("Registro Modificado")

        End If
    End Sub

    Private Sub bcliente()
        nc = t2.Text
        sql = "exec ver_reg_cliente '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            ruc = dr(6)
        Else
            MessageBox.Show("El Cliente no Existe")
        End If
        dr.Close()
        conexion.conexion2.Close()
    End Sub
    Private Sub bbancoplan()
        nc = t13.Text
        sql = "exec ver_plandecuentas '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            ruc = dr(6)
        Else
            MessageBox.Show("El Plan no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub
End Class