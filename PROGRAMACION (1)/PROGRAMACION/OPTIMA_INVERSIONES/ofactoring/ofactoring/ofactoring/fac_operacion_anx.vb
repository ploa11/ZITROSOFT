Public Class fac_operacion_anx
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
    Dim res, res2 As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Public cod_clie, cod_anx, igv_comi_tran, mont_t_trans, suma_interes, igv_suma_int, mont_tot_interes, total_abono, total_anexo, gest, fec_expo, int_d As String
    Dim ref, est, mont_comi, p_det, p_des, p_int_cob, p_igv, n_doc, fec_ven_exp, fec_rec_exp, n_dias, cliente, acep, mont_fac, mont_detr, mon_net, mont_des, mont_int_cob, mont_igv, abono, por_comi As String
    Dim mora As String
    Dim dias_mora As String
    Dim fec_mora_adelanto As String

    Private Sub t19_TextChanged(sender As Object, e As EventArgs) Handles t19.TextChanged

    End Sub

    Private Sub t20_TextChanged(sender As Object, e As EventArgs) Handles t20.TextChanged

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        clientes.Button8_Click(sender, e)
        T12.Text = clientes.t7.Text & " " & clientes.t8.Text & " " & clientes.t9.Text

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        clientes.Show()

    End Sub

    Private Sub t9_TextChanged(sender As Object, e As EventArgs) Handles t9.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        'TextBox2.Enabled = True
        't5.Enabled = True
        't6.Enabled = True
        't7.Enabled = True
        't8.Enabled = True
        't9.Enabled = True
        'T10.Enabled = True
        'dtp2.Enabled = True
        'T12.Enabled = True
        'T13.Enabled = True
        'T14.Enabled = True
        'T15.Enabled = True
        'T16.Enabled = True
        'T17.Enabled = True
        'T18.Enabled = True
        'T21.Enabled = True
        't20.Enabled = True
        cb2.Enabled = True
        't26.Enabled = True
        't19.Enabled = True


    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        dias_int_fac()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Anexo.Show()
        Me.Close()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        suma_grid2()
        'dias_int_fac()
        Anexo.buscar_desde_fac()
        Anexo.Show()
        Anexo.Button3_Click(sender, e)
        Anexo.Button7_Click(sender, e)
        Me.Close()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        'Dim bus As String
        t1.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        t9.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(10).Value
        T12.Text = dgv.Rows(dgv.CurrentRow.Index).Cells(16).Value
        Try
            sql = "exec ver_fac_anx_ope '" + t1.Text + "','" + t9.Text + "','" + T12.Text + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader

            If dr.Read Then
                t1.Text = dr(0)
                t2.Text = dr(1)
                t3.Text = dr(2)
                t4.Text = dr(3)
                t19.Text = dr(3)
                TextBox2.Text = dr(22)
                t5.Text = dr(4)
                t6.Text = dr(5)
                t7.Text = dr(6)
                t8.Text = dr(7)
                t9.Text = dr(8)
                dtp2.Text = dr(9)
                dtp1.Text = dr(10)
                T10.Text = dr(11)
                T11.Text = dr(12)
                T12.Text = dr(13)
                T13.Text = dr(14)
                T14.Text = dr(15)
                T15.Text = dr(16)
                T16.Text = dr(17)
                T17.Text = dr(18)
                T18.Text = dr(19)
                T21.Text = dr(20)
                t20.Text = dr(23)
                t23.Text = dr(24)
                int_d = dr(26)
                cb2.Text = dr(25)
                t26.Text = dr(26)
                t22.Text = dr(27)

            Else
                MessageBox.Show("El Cliente no Existe", "Optima")
            End If
            dr.Close()
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al Mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        llenar_grid()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim bus As String = InputBox("Ingrese el Codigo de Anexo", "Optima")
        sql = "exec ver_fac_anx_ope '" + bus + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        Try
            If dr.Read Then
                t1.Text = dr(0)
                t2.Text = dr(1)
                t3.Text = dr(2)
                t4.Text = dr(3)
                t19.Text = dr(3)
                TextBox2.Text = dr(22)
                t5.Text = dr(4)
                t6.Text = dr(5)
                t7.Text = dr(6)
                t8.Text = dr(7)
                t9.Text = dr(8)
                dtp2.Text = dr(9)
                dtp1.Text = dr(10)
                T10.Text = dr(11)
                T11.Text = dr(12)
                T12.Text = dr(13)
                T13.Text = dr(14)
                T14.Text = dr(15)
                T15.Text = dr(16)
                T16.Text = dr(17)
                T17.Text = dr(18)
                T18.Text = dr(19)
                T21.Text = dr(20)
                t20.Text = dr(23)
                t23.Text = dr(24)
                int_d = dr(26)
                cb2.Text = dr(25)
                t26.Text = dr(26)
                t22.Text = dr(27)

            Else
                MessageBox.Show("El Cliente no Existe", "Optima")
            End If
            dr.Close()
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El Cliente no Existe", "Optima")
        End Try

    End Sub

    Private Sub Cb3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb3.SelectedIndexChanged

        If cb3.Text = "CODIGO DE ANEXO" Then
            t24.Enabled = True
            dtp4.Enabled = False
        Else

            If cb3.Text = "CODIGO DE ANEXO" Then
                t24.Enabled = True
                dtp4.Enabled = False
            Else

                If cb3.Text = "FECHA DE RECEPCION" Then
                    t24.Enabled = False
                    dtp4.Enabled = True
                Else

                    If cb3.Text = "FECHA DE VENCIMIENTO" Then
                        t24.Enabled = False
                        dtp4.Enabled = True
                    End If
                End If

            End If

        End If



    End Sub

    Private Sub T24_TextChanged(sender As Object, e As EventArgs) Handles t24.TextChanged
        If cb3.Text = "CODIGO DE FACTURA" Then
            filtro_fact()
        Else
            If cb3.Text = "CODIGO DE ANEXO" Then
                filtro_ANEXO()
            End If
        End If

    End Sub

    Private Sub dtp4_ValueChanged(sender As Object, e As EventArgs) Handles dtp4.ValueChanged
        If cb3.Text = "Fecha de recepcion" Then
            filtro_fec_recp()
        Else
            If cb3.Text = "Fecha de vencimiento" Then
                filtro_fec_ven()
            End If
        End If



    End Sub

    Private Sub fac_operacion_anx_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Facturas de Anexo" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        dgv.AllowUserToAddRows = False
        buscar_anx_fac()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If cb2.Text = "PAGO ADELANTADO" Then
            edita_dias_int_fac()
        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        t4.Text = 0
        TextBox2.Text = 0
        t5.Text = 0
        t6.Text = 0
        t7.Text = 2.5
        t8.Text = 0
        dtp1.Value = dtp2.Value
        Button1.Enabled = False
        accion = "guardar"



    End Sub

    Private Sub cb2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb2.SelectedIndexChanged
        Select Case cb2.Text
            Case "VIGENTE"
                Button11.Enabled = False
                Button12.Enabled = False
                TextBox2.Enabled = False
                t5.Enabled = False
                t6.Enabled = False
                t7.Enabled = False
                t8.Enabled = False
                t9.Enabled = False
                T10.Enabled = False
                dtp2.Enabled = False
                T12.Enabled = False
                T13.Enabled = False
                T14.Enabled = False
                T15.Enabled = False
                T16.Enabled = False
                T17.Enabled = False
                T18.Enabled = False
                T21.Enabled = False
                t20.Enabled = False
                cb2.Enabled = False
                t26.Enabled = False
                t19.Enabled = False

            Case "CANCELADO"
                Button11.Enabled = False
                Button12.Enabled = False
                TextBox2.Enabled = False
                t5.Enabled = False
                t6.Enabled = False
                t7.Enabled = False
                t8.Enabled = False
                t9.Enabled = False
                T10.Enabled = False
                dtp2.Enabled = False
                T12.Enabled = False
                T13.Enabled = False
                T14.Enabled = False
                T15.Enabled = False
                T16.Enabled = False
                T17.Enabled = False
                T18.Enabled = False
                T21.Enabled = False
                t20.Enabled = False
                cb2.Enabled = False
                t26.Enabled = False
                t19.Enabled = False
            Case "PARCIAL"
                t22.Enabled = True
                t25.Enabled = True
                Button13.Enabled = True
                Button11.Enabled = False
                Button12.Enabled = True
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
                T21.Enabled = True
                t20.Enabled = True
                cb2.Enabled = True
                t26.Enabled = True
                t19.Enabled = True
                historial.Show()
                historia()
            Case "VENCIDO"
                t22.Enabled = True
                t25.Enabled = True
                Button13.Enabled = True
                Button11.Enabled = False
                Button12.Enabled = True
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
                T21.Enabled = True
                t20.Enabled = True
                cb2.Enabled = True
                t26.Enabled = True
                t19.Enabled = True
                historial.Show()
                historia()
            Case "ADELANTADO"
                t22.Enabled = True
                t25.Enabled = True
                Button13.Enabled = True
                Button11.Enabled = False
                'Button12.Enabled = True
                'TextBox2.Enabled = True
                't5.Enabled = True
                't6.Enabled = True
                't7.Enabled = True
                't8.Enabled = True
                't9.Enabled = True
                'T10.Enabled = True
                'dtp2.Enabled = True
                'T12.Enabled = True
                ' T13.Enabled = True
                'T14.Enabled = True
                'T15.Enabled = True
                'T16.Enabled = True
                'T17.Enabled = True
                'T18.Enabled = True
                'T21.Enabled = True
                't20.Enabled = True
                'cb2.Enabled = True
                't26.Enabled = True
                't19.Enabled = True
                GroupBox8.Visible = True
                GroupBox7.Visible = False
                historial.Show()
                historia()
            Case "PARCIAL VENCIDO"
                t22.Enabled = True
                t25.Enabled = True
                Button13.Enabled = True
                Button11.Enabled = False
                Button12.Enabled = True
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
                T21.Enabled = True
                t20.Enabled = True
                cb2.Enabled = True
                t26.Enabled = True
                t19.Enabled = True
                historial.Show()
                historia()

            Case "PARCIAL ADELANTADO"
                t22.Enabled = True
                t25.Enabled = True
                Button13.Enabled = True
                Button11.Enabled = False
                Button12.Enabled = True
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
                T21.Enabled = True
                t20.Enabled = True
                cb2.Enabled = True
                t26.Enabled = True
                t19.Enabled = True
                historial.Show()
                historia()

            Case "MORA"
                t22.Enabled = True
                t25.Enabled = True
                Button13.Enabled = True
                Button11.Enabled = False
                Button12.Enabled = True
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
                T21.Enabled = True
                t20.Enabled = True
                cb2.Enabled = True
                t26.Enabled = True
                t19.Enabled = True
                GroupBox8.Visible = True
                GroupBox7.Visible = False
                historial.Show()
                historia()

        End Select

    End Sub

    Private Sub historia()
        historial.t2.Text = t2.Text
        historial.t3.Text = t1.Text
        historial.dtp1.Value = dtp4.Value
        historial.dtp2.Value = dtp1.Value
        historial.dtp3.Value = dtp2.Value
        historial.t9.Text = T16.Text
        historial.t11.Text = T17.Text
        historial.t12.Text = T18.Text
        historial.t13.Text = t19.Text
        historial.t14.Text = t20.Text
        historial.t15.Text = t22.Text
        historial.t10.Text = T21.Text
        historial.t18.Text = t26.Text
        historial.t19.Text = T10.Text
        historial.buscar_h_fac_anx()

    End Sub

    Private Sub t22_TextChanged(sender As Object, e As EventArgs) Handles t22.TextChanged

    End Sub

    Dim fec_recep, fec_ven As Date

    Private Sub t26_TextChanged(sender As Object, e As EventArgs) Handles t26.TextChanged

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Try
            T14.Text = (T13.Text * t5.Text) / 100
            T15.Text = T13.Text - T14.Text
            T16.Text = ((T15.Text * t6.Text) / 100)
            '---------------------------------------------------------------
            Dim mtct As String = T16.Text * (TextBox2.Text / 100)
            If mtct > 150 Then
                t4.Text = mtct
            Else
                t4.Text = 150
            End If
            t19.Text = t4.Text
            '-------------------------------------------------------
            Dim int As String = t7.Text / 100
            Dim dia As String = T10.Text
            T17.Text = T16.Text * ((1 + int / 30) ^ dia - 1)

            '---------------------------------------------------------
            Dim igv As String = t8.Text / 100
            Dim igvint As String
            igvint = T17.Text * igv
            T18.Text = igvint

            '----------------------------------------------------------
            t26.Text = T17.Text / T10.Text
            '---------------------------------------------------------
            Dim igvc As String = t8.Text / 100
            t20.Text = t19.Text * igvc

            '----------------------------------------------------------
            T21.Text = T16.Text - T17.Text - T18.Text - t19.Text - t20.Text
        Catch ex As Exception
            MessageBox.Show("Revisar que ningun campo de porcentaje y dias de factura este vacio")
        End Try


    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim save As New SaveFileDialog
        Dim ruta As String
        Dim xlapp As Object = CreateObject("Excel.Application")
        Dim pth As String = ""
        'crea nueva hoja
        Dim xlwb As Object = xlapp.workbooks.add
        Dim xlws As Object = xlwb.worksheets(1)
        Try
            'exportamos los carateres de la columna

            For c As Integer = 0 To dgv.Columns.Count - 1
                xlws.cells(1, c + 1).value = dgv.Columns(c).HeaderText

            Next
            'exporatmaos las cabeceras de las columnas
            For r As Integer = 0 To dgv.RowCount - 1
                'xlws.cells(1, r + 1).value = dgv.Columns(r).HeaderText
                For c As Integer = 0 To dgv.Columns.Count - 1
                    xlws.cells(r + 2, c + 1).value = Convert.ToString(dgv.Item(c, r).Value)

                Next
            Next
            'guardamos la hoja
            Dim savefiledialog1 As SaveFileDialog = New SaveFileDialog
            savefiledialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            savefiledialog1.Filter = "Archivo Excel| *.xlsx"
            savefiledialog1.FilterIndex = 2
            If savefiledialog1.ShowDialog = DialogResult.OK Then
                ruta = savefiledialog1.FileName
                xlwb.saveas(ruta)
                xlws = Nothing
                xlwb = Nothing
                xlapp.quit()
                MsgBox("EXPORTADO CORRECTAMENTE", MsgBoxStyle.Information, "Optima")

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Me.Close()
    End Sub

    Private Sub t8_TextChanged(sender As Object, e As EventArgs) Handles t8.TextChanged

    End Sub



    Private Sub t25_Click(sender As Object, e As EventArgs) Handles t25.Click
        historial.t2.Text = t2.Text
        historial.t3.Text = t1.Text
        historial.dtp1.Value = dtp4.Value
        historial.dtp2.Value = dtp1.Value
        historial.dtp3.Value = dtp2.Value
        historial.t9.Text = T16.Text
        historial.t11.Text = T17.Text
        historial.t12.Text = T18.Text
        historial.t13.Text = t19.Text
        historial.t14.Text = t20.Text
        historial.t15.Text = t22.Text
        historial.t10.Text = T21.Text
        historial.t18.Text = t26.Text
        historial.Show()
        historial.buscar_h_fac_anx()





    End Sub

    Dim accion, nom, appa, apma As String

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim preg As String
        guardar()
        preg = MsgBox("Desea agregar otra factura a la operacion de anexo", vbYesNo)
        If preg = vbYes Then
            Button1_Click(sender, e)
        Else
            MessageBox.Show("FACTURAS AGREGADAS", "Optima")
            Button7_Click(sender, e)
        End If

    End Sub

    Private Sub guardar()
        nc = t1.Text
        cod_anx = UCase(t2.Text)
        cod_clie = UCase(t3.Text)
        mont_comi = t4.Text
        p_det = t5.Text
        p_des = t6.Text
        p_int_cob = t7.Text
        p_igv = t8.Text
        n_doc = t9.Text
        fec_ven = dtp2.Value
        fec_ven_exp = fec_ven.ToString("yyyyMMdd")
        fec_recep = dtp1.Value
        fec_rec_exp = fec_recep.ToString("yyyyMMdd")
        n_dias = T10.Text
        cliente = UCase(T11.Text)
        acep = T12.Text
        mont_fac = T13.Text
        mont_detr = T14.Text
        mon_net = T15.Text
        mont_des = T16.Text
        mont_int_cob = T17.Text
        mont_igv = T18.Text
        abono = T21.Text
        por_comi = TextBox2.Text
        igv_comi_tran = t20.Text
        gest = UCase(t23.Text)
        est = cb2.Text
        int_d = mont_int_cob / n_dias
        ref = UCase(t22.Text)
        mora = "0"
        dias_mora = "0"
        fec_mora_adelanto = dtp2.Value.ToString("yyyyMMdd")

        sql = ""
        Try
            If accion = "guardar" Then
                sql = "exec ver_fac_anx_ope'" + nc + "','" + n_doc + "','" + acep + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("Los Datos ya Existen", "Optima", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    conexion.conexion2.Close()
                Else
                    sql = "exec alta_fac_anx '" + cod_anx + "','" + cod_clie + "','" + mont_comi + "','" + p_det + "','" + p_des + "','" + p_int_cob + "','" + p_igv + "','" + n_doc + "','" + fec_ven_exp + "','" + fec_rec_exp + "','" + n_dias + "','" + cliente + "','" + acep + "','" + mont_fac + "','" + mont_detr + "','" + mon_net + "','" + mont_des + "','" + mont_int_cob + "','" + mont_igv + "','" + abono + "','" + por_comi + "','" + igv_comi_tran + "','" + gest + "','" + est + "','" + int_d + "','" + ref + "','" + mora + "','" + dias_mora + "','" + fec_mora_adelanto + "'"
                    conexion.conectarfondo()
                    com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                    res = com.ExecuteNonQuery
                    conexion.conexion2.Close()
                    MessageBox.Show("Registro Guardado", "Optima")

                End If
            ElseIf accion = "editar" Then

                sql = "exec edita_fac_anx_ope'" + nc + "','" + cod_anx + "','" + cod_clie + "','" + mont_comi + "','" + p_det + "','" + p_des + "','" + p_int_cob + "','" + p_igv + "','" + n_doc + "','" + fec_ven_exp + "','" + fec_rec_exp + "','" + n_dias + "','" + cliente + "','" + acep + "','" + mont_fac + "','" + mont_detr + "','" + mon_net + "','" + mont_des + "','" + mont_int_cob + "','" + mont_igv + "','" + abono + "','" + por_comi + "','" + igv_comi_tran + "','" + gest + "','" + est + "','" + int_d + "','" + ref + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                res = com.ExecuteNonQuery
                conexion.conexion2.Close()
                MessageBox.Show("Registro Modificado", "Optima")
                t24.Text = t1.Text
                filtro_fact()
                'edita_dias_int_fac()

            End If
            buscar_anx_fac()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar datos", "Optima")
        End Try


    End Sub



    Dim sql, sql2, sql3, nc As String





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
        T21.Text = ""
        T21.Enabled = True
        T21.Text = ""
        t19.Enabled = True
        t19.Text = ""
        t20.Enabled = True
        t20.Text = ""
        Button9.Enabled = True
        Button10.Enabled = True
        cb2.Enabled = False
        t26.Text = ""
        t26.Enabled = True


    End Sub

    Private Sub T14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T14.KeyPress

        'Dim mtnt As String
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
        'Dim mtdt As String
        If e.KeyChar = ChrW(Keys.Enter) Then
            T14.Text = (T13.Text * t5.Text) / 100

        End If



    End Sub

    Private Sub T15_TextChanged(sender As Object, e As EventArgs) Handles T15.TextChanged

    End Sub

    Private Sub T15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T15.KeyPress
        'Dim mtds As String

        If e.KeyChar = ChrW(Keys.Enter) Then
            T16.Text = ((T15.Text * t6.Text) / 100)
            Dim mtct As String = T16.Text * (TextBox2.Text / 100)
            If mtct > 150 Then
                t4.Text = mtct
            Else
                t4.Text = 150
            End If
            t19.Text = t4.Text
        End If

    End Sub

    Private Sub T16_TextChanged(sender As Object, e As EventArgs) Handles T16.TextChanged

    End Sub

    Private Sub T16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T16.KeyPress

        Dim int As String = t7.Text / 100
        Dim dia As String = T10.Text
        ' Dim mint As String
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
        Dim igvint As String

        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                igvint = T17.Text * igv
                T18.Text = igvint
            End If
        Catch ex As Exception
            MessageBox.Show("verificar Monto de descuento", "Optima")
        End Try

    End Sub

    Private Sub T18_TextChanged(sender As Object, e As EventArgs) Handles T18.TextChanged

    End Sub

    Private Sub T18_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T18.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                t26.Text = T17.Text / T10.Text
            End If
        Catch ex As Exception
            MessageBox.Show("Los Campos de" & Label18.Text & Label19.Text & Label20.Text & "deben tener Informacion")
        End Try
    End Sub
    Private Sub llenar_grid()
        Try
            sql = "select * from v_fac_operacion_anx"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_fac_operacion_anx")
            dgv.DataSource = ds
            dgv.DataMember = "v_fac_operacion_anx"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Public Sub buscar_anx_fac()
        'BUSCA LAS FACTURAS REGISTRADAS POR ANEXO
        Try
            nc = t2.Text
            sql = "select *from v_fac_operacion_anx where [CODIGO DE ANEXO] like'" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_fac_operacion_anx where [CODIGO DE ANEXO] like'" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_fac_operacion_anx where [CODIGO DE ANEXO] like'" + nc + "%'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try

    End Sub

    Public Sub suma_grid2()
        Dim t_comi, mt_desc, mt_int, mt_igv, abono, igv_comisi As Decimal
        Dim comi_tran As Integer = 3
        Dim mont_des As Integer = 20
        Dim mont_int As Integer = 21
        Dim mont_igv As Integer = 22
        Dim mont_abono As Integer = 23
        Dim igv_com As Integer = 5
        Try
            't1.Text = Datos_Generales_del_Fondo.t1.Text
            For Each row As DataGridViewRow In dgv.Rows
                t_comi += Val(row.Cells(comi_tran).Value)
                mt_desc += Val(row.Cells(mont_des).Value)
                mt_int += Val(row.Cells(mont_int).Value)
                mt_igv += Val(row.Cells(mont_igv).Value)
                abono += Val(row.Cells(mont_abono).Value)
                igv_comisi += Val(row.Cells(igv_com).Value)

            Next
            Anexo.t5.Text = t_comi
            Anexo.t6.Text = igv_comisi
            Anexo.t7.Text = t_comi + igv_comisi
            Anexo.t9.Text = mt_int
            Anexo.t10.Text = mt_igv
            Anexo.t11.Text = mt_int + mt_igv
            Anexo.t13.Text = abono
            Anexo.t12.Text = mt_desc

        Catch ex As Exception
            MessageBox.Show("Error al sumar los datos", "Optima")
        End Try

    End Sub

    Private Sub t19_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t19.KeyPress
        Dim igvc As String = t8.Text / 100

        If e.KeyChar = ChrW(Keys.Enter) Then
            t20.Text = t19.Text * igvc
        End If
    End Sub

    Private Sub t20_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t20.KeyPress
        'Dim abn As String

        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                T21.Text = T16.Text - T17.Text - T18.Text - t19.Text - t20.Text

            End If
        Catch ex As Exception
            MessageBox.Show("Los Campos de" & Label18.Text & Label19.Text & Label20.Text & "deben tener Informacion")
        End Try
    End Sub

    Private Sub t9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t9.KeyPress
        Dim f_emi, f_ven As Date
        Dim tdias As Long
        f_emi = dtp1.Value
        f_ven = dtp2.Value
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim wD As Long = DateDiff(DateInterval.DayOfYear, f_emi, f_ven)
                'Dim wY As Long = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
                tdias = wD
                T10.Text = tdias
            End If
        Catch ex As Exception
            MessageBox.Show("Los Campos de" & Label18.Text & Label19.Text & Label20.Text & "deben tener Informacion")

        End Try

    End Sub

    Private Sub dias_int_fac()
        Dim datTim1 As Date '= #01/01/2018#
        Dim datTim2 As Date
        Dim datTim3 As Date
        Dim datTim4 As Date
        Dim f_cierre As Date
        Dim z, x, h, y, j As Integer
        Dim dinteres(0 To 367) As String
        Dim dia1, dia2 As String
        Dim gestion As String
        Try
            ':::Declaramos nuestra variable Sql que almacenara nuestra consuta
            gestion = t23.Text
            sql2 = ""
            '---------------------------------------
            'procedimiento para tener la apertura de año
            nc = gestion
            sql3 = "exec ver_gestionbdp '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql3, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                datTim1 = dr(2)
                f_cierre = dr(4)
            Else
                MessageBox.Show("La gestion no Existe", "Optima")
            End If
            dr.Close()
            conexion.conexion.Close()

            '-----------------------------------------------
            ':::Usamos un ciclo For Each para recorrer nuestro DataGridView llamado DGTabla
            For Each Row As DataGridViewRow In dgv.Rows
                Dim cod_doc As String = Row.Cells("CODIGO DE DOCUMENTO").Value
                Dim int As String = Row.Cells("MONTO DE INTERES").Value
                Dim cuota As String = Row.Cells("MONTO DESCUENTO").Value
                Dim F_inicio As Date = Row.Cells("FECHA DE RECEPCION DE DOCUMENTO").Value
                If F_inicio > f_cierre Then
                    gestion = F_inicio.ToString("yyyy")
                    'proceso para cambio de gestion y fecha de apertura
                    nc = gestion
                    sql3 = "exec ver_gestionbdp '" + nc + "'"
                    conexion.conectar()
                    com = New SqlClient.SqlCommand(sql3, conexion.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        datTim1 = dr(2)
                        f_cierre = dr(4)
                    Else
                        MessageBox.Show("La gestion no Existe")
                    End If
                    dr.Close()
                    conexion.conexion.Close()
                End If
                Dim FechaExportar As String = F_inicio.ToString("yyyyMMdd")
                Dim f_final As Date = Row.Cells("FECHA DE VENCIMIENTO DE DOCUMENTO").Value
                If f_final > f_cierre Then
                    f_final = f_cierre
                End If
                Dim fecha_f_exportar As String = f_final.ToString("yyyyMMdd")
                Dim dias As String = Row.Cells("NUMERO DE DIAS DE FACTURA").Value
                Dim cod_op As String = Row.Cells("CODIGO DE ANEXO").Value
                Dim estado As String = Row.Cells("ESTADO").Value
                Dim int_dia As String = Row.Cells("INTERES DIARIO").Value
                'nc = Row.Cells("CODIGO DE DOCUMENTO").Value
                datTim2 = F_inicio
                datTim3 = F_inicio
                datTim4 = f_final
                Dim wD As Long = DateDiff(DateInterval.DayOfYear, datTim1, datTim2)
                Dim wY As Long = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
                If f_final = f_cierre Then
                    dia1 = wD + 1 'TextBox1.Text
                    dia2 = wY + 1 'TextBox2.Text
                    z = (wD + 1) + (wY + 1)
                Else
                    dia1 = wD + 1 'TextBox1.Text
                    dia2 = wY  'TextBox2.Text
                    z = (wD + 1) + (wY)
                End If
                h = 1
                j = 367
                For x = 1 To j
                    If x = dia1 Then
                        For y = x To (z - 1)
                            dinteres(y) = int_dia
                        Next
                        x = y
                    End If
                    dinteres(x) = "0"
                Next
                sql2 = "exec ver_numdias_cranx'" + cod_doc + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
                dr = com.ExecuteReader
                If dr.Read Then
                    MessageBox.Show("Los Datos ya Existen", "Datos existen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dr.Close()
                    conexion.conexion2.Close()
                Else

                    sql2 = "exec alta_dias_cranx '" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + dinteres(366) + "','" + gestion + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_doc + "','" + estado + "','" + int_dia + "'"
                    'sql2 = "exec alta_dias_cranx '" + dinteres(0) + "','" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + Anex_Cronog.cb2.Text + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "'"

                    conexion.conectarfondo()
                    com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
                    res2 = com.ExecuteNonQuery
                    conexion.conexion2.Close()
                End If

                Dim f_comp As Date = Row.Cells("FECHA DE VENCIMIENTO DE DOCUMENTO").Value
                If f_comp > f_cierre Then
                    gestion = f_comp.ToString("yyyy")
                    'proceso para cambio de gestion y fecha de apertura para agregar en una nueva gestion cuota
                    nc = gestion
                    sql3 = "exec ver_gestionbdp '" + nc + "'"
                    conexion.conectar()
                    com = New SqlClient.SqlCommand(sql3, conexion.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        datTim1 = dr(2)
                        f_cierre = dr(4)
                    Else
                        MessageBox.Show("La gestion no Existe")
                    End If
                    dr.Close()
                    conexion.conexion.Close()
                    '----------------------------------------------------
                    cod_doc = Row.Cells("CODIGO DE DOCUMENTO").Value
                    int = Row.Cells("MONTO DE INTERES").Value
                    cuota = Row.Cells("MONTO DESCUENTO").Value
                    F_inicio = datTim1
                    FechaExportar = F_inicio.ToString("yyyyMMdd")
                    f_final = Row.Cells("FECHA DE VENCIMIENTO DE DOCUMENTO").Value
                    fecha_f_exportar = f_final.ToString("yyyyMMdd")
                    dias = Row.Cells("NUMERO DE DIAS DE FACTURA").Value
                    cod_op = Row.Cells("CODIGO DE ANEXO").Value
                    estado = Row.Cells("ESTADO").Value
                    int_dia = Row.Cells("INTERES DIARIO").Value
                    datTim2 = F_inicio
                    datTim3 = F_inicio
                    datTim4 = f_final
                    wD = DateDiff(DateInterval.DayOfYear, datTim1, datTim2)
                    wY = DateDiff(DateInterval.DayOfYear, datTim3, datTim4)
                    dia1 = wD + 1 'TextBox1.Text
                    dia2 = wY  'TextBox2.Text
                    z = (wD + 1) + (wY)
                    h = 1
                    j = 367
                    int_dia = int / dias
                    For x = 1 To j
                        If x = dia1 Then
                            For y = x To (z - 1)
                                dinteres(y) = int / dias
                            Next
                            x = y
                        End If
                        dinteres(x) = "0"
                    Next
                    sql2 = "exec alta_dias_cranx '" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + dinteres(366) + "','" + gestion + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_doc + "','" + estado + "','" + int_dia + "'"
                    'sql2 = "exec alta_dias_cranx '" + dinteres(0) + "','" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + Anex_Cronog.cb2.Text + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "'"
                    conexion.conectarfondo()
                    com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
                    res2 = com.ExecuteNonQuery
                    conexion.conexion2.Close()

                End If
                'Exportar_SQLite2(sql2)
                'For x = 1 To 366
                'MsgBox("dias:" & dias(x) & "contador:" & h)
                'h = h + 1
                ' Next
            Next


            MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: Optima :::")
            'Close()

        Catch ex As Exception
            MessageBox.Show("Error al conectar datos", "Optima")
        End Try


    End Sub
    Private Sub edita_dias_int_fac()
        Dim dat_Tim1 As Date '= #01/01/2018#
        Dim dat_Tim2 As Date
        Dim dat_Tim3 As Date
        Dim dat_Tim4 As Date
        Dim z, x, h, y, j As Integer
        Dim dinteres(0 To 367) As String
        Dim dia1, dia2 As String
        Dim gestion As String
        Try
            ':::Declaramos nuestra variable Sql que almacenara nuestra consuta
            gestion = t23.Text
            sql2 = ""
            '---------------------------------------
            'procedimiento para tener la apertura de año
            nc = gestion
            sql3 = "exec ver_gestionbdp '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql3, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                dat_Tim1 = dr(2)
            Else
                MessageBox.Show("La gestion no Existe", "Optima")
            End If
            dr.Close()
            conexion.conexion.Close()

            '-----------------------------------------------
            ':::Usamos un ciclo For Each para recorrer nuestro DataGridView llamado DGTabla
            For Each Row As DataGridViewRow In dgv.Rows
                Dim cod_doc As String = Row.Cells("CODIGO DE DOCUMENTO").Value
                Dim int As String = Row.Cells("MONTO DE INTERES").Value
                Dim cuota As String = Row.Cells("MONTO DESCUENTO").Value
                Dim F_inicio As Date = Row.Cells("FECHA DE RECEPCION DE DOCUMENTO").Value
                Dim FechaExportar As String = F_inicio.ToString("yyyyMMdd")
                Dim f_final As Date = Row.Cells("FECHA DE VENCIMIENTO DE DOCUMENTO").Value
                Dim fecha_f_exportar As String = f_final.ToString("yyyyMMdd")
                Dim dias As String = Row.Cells("NUMERO DE DIAS DE FACTURA").Value
                Dim cod_op As String = Row.Cells("CODIGO DE ANEXO").Value
                Dim estado As String = Row.Cells("ESTADO").Value
                Dim int_d As String = Row.Cells("INTERES DIARIO").Value
                nc = Row.Cells("CODIGO DE DOCUMENTO").Value
                dat_Tim2 = F_inicio
                dat_Tim3 = F_inicio
                dat_Tim4 = f_final
                Dim wD As Long = DateDiff(DateInterval.DayOfYear, dat_Tim1, dat_Tim2)
                Dim wY As Long = DateDiff(DateInterval.DayOfYear, dat_Tim3, dat_Tim4)
                dia1 = wD + 1 'TextBox1.Text
                dia2 = wY + 1 'TextBox2.Text
                z = (wD + 1) + (wY + 1)
                h = 1
                j = 367
                For x = 1 To j
                    If x = dia1 Then
                        For y = x To (z - 2)
                            dinteres(y) = int_d
                        Next
                        x = y
                    End If
                    dinteres(x) = "0"
                Next
                'sql2 = "exec ver_numdias_cranx'" + nc + "'"
                'conexion.conectarfondo()
                ' com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
                ' dr = com.ExecuteReader
                ' If dr.Read Then
                ' MessageBox.Show("Los Datos ya Existen", "Datos existen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'dr.Close()
                'conexion.conexion2.Close()
                'Else

                sql2 = "exec edita_cuo_cranx '" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + dinteres(366) + "','" + gestion + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_doc + "','" + estado + "','" + int_d + "'"
                'sql2 = "exec alta_dias_cranx '" + dinteres(0) + "','" + dinteres(1) + "','" + dinteres(2) + "','" + dinteres(3) + "','" + dinteres(4) + "','" + dinteres(5) + "','" + dinteres(6) + "','" + dinteres(7) + "','" + dinteres(8) + "','" + dinteres(9) + "','" + dinteres(10) + "','" + dinteres(11) + "','" + dinteres(12) + "','" + dinteres(13) + "','" + dinteres(14) + "','" + dinteres(15) + "','" + dinteres(16) + "','" + dinteres(17) + "','" + dinteres(18) + "','" + dinteres(19) + "','" + dinteres(20) + "','" + dinteres(21) + "','" + dinteres(22) + "','" + dinteres(23) + "','" + dinteres(24) + "','" + dinteres(25) + "','" + dinteres(26) + "','" + dinteres(27) + "','" + dinteres(28) + "','" + dinteres(29) + "','" + dinteres(30) + "','" + dinteres(31) + "','" + dinteres(32) + "','" + dinteres(33) + "','" + dinteres(34) + "','" + dinteres(35) + "','" + dinteres(36) + "','" + dinteres(37) + "','" + dinteres(38) + "','" + dinteres(39) + "','" + dinteres(40) + "','" + dinteres(41) + "','" + dinteres(42) + "','" + dinteres(43) + "','" + dinteres(44) + "','" + dinteres(45) + "','" + dinteres(46) + "','" + dinteres(47) + "','" + dinteres(48) + "','" + dinteres(49) + "','" + dinteres(50) + "','" + dinteres(51) + "','" + dinteres(52) + "','" + dinteres(53) + "','" + dinteres(54) + "','" + dinteres(55) + "','" + dinteres(56) + "','" + dinteres(57) + "','" + dinteres(58) + "','" + dinteres(59) + "','" + dinteres(60) + "','" + dinteres(61) + "','" + dinteres(62) + "','" + dinteres(63) + "','" + dinteres(64) + "','" + dinteres(65) + "','" + dinteres(66) + "','" + dinteres(67) + "','" + dinteres(68) + "','" + dinteres(69) + "','" + dinteres(70) + "','" + dinteres(71) + "','" + dinteres(72) + "','" + dinteres(73) + "','" + dinteres(74) + "','" + dinteres(75) + "','" + dinteres(76) + "','" + dinteres(77) + "','" + dinteres(78) + "','" + dinteres(79) + "','" + dinteres(80) + "','" + dinteres(81) + "','" + dinteres(82) + "','" + dinteres(83) + "','" + dinteres(84) + "','" + dinteres(85) + "','" + dinteres(86) + "','" + dinteres(87) + "','" + dinteres(88) + "','" + dinteres(89) + "','" + dinteres(90) + "','" + dinteres(91) + "','" + dinteres(92) + "','" + dinteres(93) + "','" + dinteres(94) + "','" + dinteres(95) + "','" + dinteres(96) + "','" + dinteres(97) + "','" + dinteres(98) + "','" + dinteres(99) + "','" + dinteres(100) + "','" + dinteres(101) + "','" + dinteres(102) + "','" + dinteres(103) + "','" + dinteres(104) + "','" + dinteres(105) + "','" + dinteres(106) + "','" + dinteres(107) + "','" + dinteres(108) + "','" + dinteres(109) + "','" + dinteres(110) + "','" + dinteres(111) + "','" + dinteres(112) + "','" + dinteres(113) + "','" + dinteres(114) + "','" + dinteres(115) + "','" + dinteres(116) + "','" + dinteres(117) + "','" + dinteres(118) + "','" + dinteres(119) + "','" + dinteres(120) + "','" + dinteres(121) + "','" + dinteres(122) + "','" + dinteres(123) + "','" + dinteres(124) + "','" + dinteres(125) + "','" + dinteres(126) + "','" + dinteres(127) + "','" + dinteres(128) + "','" + dinteres(129) + "','" + dinteres(130) + "','" + dinteres(131) + "','" + dinteres(132) + "','" + dinteres(133) + "','" + dinteres(134) + "','" + dinteres(135) + "','" + dinteres(136) + "','" + dinteres(137) + "','" + dinteres(138) + "','" + dinteres(139) + "','" + dinteres(140) + "','" + dinteres(141) + "','" + dinteres(142) + "','" + dinteres(143) + "','" + dinteres(144) + "','" + dinteres(145) + "','" + dinteres(146) + "','" + dinteres(147) + "','" + dinteres(148) + "','" + dinteres(149) + "','" + dinteres(150) + "','" + dinteres(151) + "','" + dinteres(152) + "','" + dinteres(153) + "','" + dinteres(154) + "','" + dinteres(155) + "','" + dinteres(156) + "','" + dinteres(157) + "','" + dinteres(158) + "','" + dinteres(159) + "','" + dinteres(160) + "','" + dinteres(161) + "','" + dinteres(162) + "','" + dinteres(163) + "','" + dinteres(164) + "','" + dinteres(165) + "','" + dinteres(166) + "','" + dinteres(167) + "','" + dinteres(168) + "','" + dinteres(169) + "','" + dinteres(170) + "','" + dinteres(171) + "','" + dinteres(172) + "','" + dinteres(173) + "','" + dinteres(174) + "','" + dinteres(175) + "','" + dinteres(176) + "','" + dinteres(177) + "','" + dinteres(178) + "','" + dinteres(179) + "','" + dinteres(180) + "','" + dinteres(181) + "','" + dinteres(182) + "','" + dinteres(183) + "','" + dinteres(184) + "','" + dinteres(185) + "','" + dinteres(186) + "','" + dinteres(187) + "','" + dinteres(188) + "','" + dinteres(189) + "','" + dinteres(190) + "','" + dinteres(191) + "','" + dinteres(192) + "','" + dinteres(193) + "','" + dinteres(194) + "','" + dinteres(195) + "','" + dinteres(196) + "','" + dinteres(197) + "','" + dinteres(198) + "','" + dinteres(199) + "','" + dinteres(200) + "','" + dinteres(201) + "','" + dinteres(202) + "','" + dinteres(203) + "','" + dinteres(204) + "','" + dinteres(205) + "','" + dinteres(206) + "','" + dinteres(207) + "','" + dinteres(208) + "','" + dinteres(209) + "','" + dinteres(210) + "','" + dinteres(211) + "','" + dinteres(212) + "','" + dinteres(213) + "','" + dinteres(214) + "','" + dinteres(215) + "','" + dinteres(216) + "','" + dinteres(217) + "','" + dinteres(218) + "','" + dinteres(219) + "','" + dinteres(220) + "','" + dinteres(221) + "','" + dinteres(222) + "','" + dinteres(223) + "','" + dinteres(224) + "','" + dinteres(225) + "','" + dinteres(226) + "','" + dinteres(227) + "','" + dinteres(228) + "','" + dinteres(229) + "','" + dinteres(230) + "','" + dinteres(231) + "','" + dinteres(232) + "','" + dinteres(233) + "','" + dinteres(234) + "','" + dinteres(235) + "','" + dinteres(236) + "','" + dinteres(237) + "','" + dinteres(238) + "','" + dinteres(239) + "','" + dinteres(240) + "','" + dinteres(241) + "','" + dinteres(242) + "','" + dinteres(243) + "','" + dinteres(244) + "','" + dinteres(245) + "','" + dinteres(246) + "','" + dinteres(247) + "','" + dinteres(248) + "','" + dinteres(249) + "','" + dinteres(250) + "','" + dinteres(251) + "','" + dinteres(252) + "','" + dinteres(253) + "','" + dinteres(254) + "','" + dinteres(255) + "','" + dinteres(256) + "','" + dinteres(257) + "','" + dinteres(258) + "','" + dinteres(259) + "','" + dinteres(260) + "','" + dinteres(261) + "','" + dinteres(262) + "','" + dinteres(263) + "','" + dinteres(264) + "','" + dinteres(265) + "','" + dinteres(266) + "','" + dinteres(267) + "','" + dinteres(268) + "','" + dinteres(269) + "','" + dinteres(270) + "','" + dinteres(271) + "','" + dinteres(272) + "','" + dinteres(273) + "','" + dinteres(274) + "','" + dinteres(275) + "','" + dinteres(276) + "','" + dinteres(277) + "','" + dinteres(278) + "','" + dinteres(279) + "','" + dinteres(280) + "','" + dinteres(281) + "','" + dinteres(282) + "','" + dinteres(283) + "','" + dinteres(284) + "','" + dinteres(285) + "','" + dinteres(286) + "','" + dinteres(287) + "','" + dinteres(288) + "','" + dinteres(289) + "','" + dinteres(290) + "','" + dinteres(291) + "','" + dinteres(292) + "','" + dinteres(293) + "','" + dinteres(294) + "','" + dinteres(295) + "','" + dinteres(296) + "','" + dinteres(297) + "','" + dinteres(298) + "','" + dinteres(299) + "','" + dinteres(300) + "','" + dinteres(301) + "','" + dinteres(302) + "','" + dinteres(303) + "','" + dinteres(304) + "','" + dinteres(305) + "','" + dinteres(306) + "','" + dinteres(307) + "','" + dinteres(308) + "','" + dinteres(309) + "','" + dinteres(310) + "','" + dinteres(311) + "','" + dinteres(312) + "','" + dinteres(313) + "','" + dinteres(314) + "','" + dinteres(315) + "','" + dinteres(316) + "','" + dinteres(317) + "','" + dinteres(318) + "','" + dinteres(319) + "','" + dinteres(320) + "','" + dinteres(321) + "','" + dinteres(322) + "','" + dinteres(323) + "','" + dinteres(324) + "','" + dinteres(325) + "','" + dinteres(326) + "','" + dinteres(327) + "','" + dinteres(328) + "','" + dinteres(329) + "','" + dinteres(330) + "','" + dinteres(331) + "','" + dinteres(332) + "','" + dinteres(333) + "','" + dinteres(334) + "','" + dinteres(335) + "','" + dinteres(336) + "','" + dinteres(337) + "','" + dinteres(338) + "','" + dinteres(339) + "','" + dinteres(340) + "','" + dinteres(341) + "','" + dinteres(342) + "','" + dinteres(343) + "','" + dinteres(344) + "','" + dinteres(345) + "','" + dinteres(346) + "','" + dinteres(347) + "','" + dinteres(348) + "','" + dinteres(349) + "','" + dinteres(350) + "','" + dinteres(351) + "','" + dinteres(352) + "','" + dinteres(353) + "','" + dinteres(354) + "','" + dinteres(355) + "','" + dinteres(356) + "','" + dinteres(357) + "','" + dinteres(358) + "','" + dinteres(359) + "','" + dinteres(360) + "','" + dinteres(361) + "','" + dinteres(362) + "','" + dinteres(363) + "','" + dinteres(364) + "','" + dinteres(365) + "','" + Anex_Cronog.cb2.Text + "','" + cod_op + "','" + FechaExportar + "','" + fecha_f_exportar + "','" + dias + "','" + cuota + "','" + int + "','" + cod_cuota + "'"

                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql2, conexion.conexion2)
                res2 = com.ExecuteNonQuery
                conexion.conexion2.Close()
                'End If

                'Exportar_SQLite2(sql2)
                'For x = 1 To 366
                'MsgBox("dias:" & dias(x) & "contador:" & h)
                'h = h + 1
                ' Next
            Next


            MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: Optima Inversiones:::")
            'Close()
        Catch ex As Exception
            MessageBox.Show("Error al conectar la base de datos", "Optima")
        End Try

    End Sub
    Private Sub T16_MouseMove(sender As Object, e As MouseEventArgs) Handles T16.MouseMove

    End Sub

    Private Sub t20_Leave(sender As Object, e As EventArgs) Handles t20.Leave

    End Sub
    Private Sub filtro_fact()
        nc = t24.Text
        sql = "select *from v_fac_operacion_anx where [CODIGO DE DOCUMENTO] like'" + nc + "%'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_fac_operacion_anx where [CODIGO DE DOCUMENTO] like'" + nc + "%'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_fac_operacion_anx where [CODIGO DE DOCUMENTO] like'" + nc + "%'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_ANEXO()
        nc = t24.Text
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
    Private Sub filtro_fec_recp()
        Dim f_recp As Date
        Dim ferecp As String
        f_recp = dtp4.Value
        ferecp = f_recp.ToString("yyyyMMdd")
        nc = ferecp
        sql = "select *from v_fac_operacion_anx where [FECHA DE RECEPCION DE DOCUMENTO] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_fac_operacion_anx where [FECHA DE RECEPCION DE DOCUMENTO] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_fac_operacion_anx where [FECHA DE RECEPCION DE DOCUMENTO] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub filtro_fec_ven()
        Dim f_recp2 As Date
        Dim ferecp2 As String
        f_recp2 = dtp4.Value
        ferecp2 = f_recp2.ToString("yyyyMMdd")
        nc = ferecp2
        sql = "select *from v_fac_operacion_anx where [FECHA DE VENCIMIENTO DE DOCUMENTO] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_fac_operacion_anx where [FECHA DE VENCIMIENTO DE DOCUMENTO] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_fac_operacion_anx where [FECHA DE VENCIMIENTO DE DOCUMENTO] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Private Sub t22_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t22.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If t1.Text = t22.Text Then
                Button13.Enabled = True

            Else
                MsgBox("El codigo de Factura no es igual a la referencia")
            End If

        End If


    End Sub

    Private Sub t26_KeyPress(sender As Object, e As KeyPressEventArgs) Handles t26.KeyPress

    End Sub
End Class