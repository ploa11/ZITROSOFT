Public Class reparticion_beneficio
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
    'variables publicas
    Public nom_parti, cod_parti, nom_manco, cod_manco, nom_fondo, cod_fondo, cod_certi, cod_partici, estado, ref, tip_distri, fec_rescate As String
    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim ares_vc As String
    Dim at_part As String
    Dim abenef As String
    Dim mtbeneficio As String
    Dim aretencion As String
    Dim awd As Long
    Dim anunfecha As Integer
    Dim aporce_ganan As String
    Dim usuario, clave As String


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        calc_benef_indi()
    End Sub
    Private Sub calc_benef_indi()
        Try
            Dim res_vc As Decimal = t1.Text - t6.Text
            Dim t_part As Decimal = t8.Text
            TextBox3.Text = res_vc * t_part

            'Dim porcent As Decimal = dtp1.Value - dtp4.Value
            Dim retencion As Decimal = TextBox3.Text * (TextBox4.Text / 100)
            TextBox5.Text = retencion
            TextBox6.Text = TextBox3.Text - TextBox5.Text
            Dim wD As Long = DateDiff(DateInterval.DayOfYear, dtp1.Value, dtp4.Value)
            Dim nunfecha As Integer = wD
            TextBox7.Text = nunfecha
            Dim porcen_ganan As Decimal = ((1 + (TextBox3.Text / t7.Text)) ^ ((365 / (nunfecha))) - 1) * 100
            TextBox8.Text = porcen_ganan
        Catch ex As Exception
            MsgBox("Problemas con el Calculo verificar Campos")
        End Try

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        carga_listviw()
        ListView1.Visible = True
        Button8.Enabled = False
        Button6.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Select Case cb6.Text
                Case "DISTRIBUCION"
                    guardar_reparticionauto()
                    dgv2.Visible = True
                    dgv.Visible = False
                    ListView1.Visible = False
                    llenar_grid2()
                Case "RESCATE"
                    'guardar_reparticionmanual()
                    guardar_reparticionauto()
                    dgv2.Visible = True
                    dgv.Visible = False
                    ListView1.Visible = False
                    llenar_grid2()
            End Select
        Catch ex As Exception

        End Try



    End Sub

    Private Sub calc_benef_auto()
        Try
            ares_vc = t1.Text - vc_act
            at_part = num_parti
            abenef = ares_vc * at_part

            'Dim porcent As Decimal = dtp1.Value - dtp4.Value
            aretencion = abenef * (TextBox4.Text / 100)
            'TextBox5.Text = aretencion
            mtbeneficio = abenef - aretencion
            awd = DateDiff(DateInterval.DayOfYear, dtp1.Value, dtp4.Value)
            anunfecha = awd
            'TextBox7.Text = nunfecha
            aporce_ganan = ((1 + (abenef / mont_parti)) ^ ((365 / (anunfecha))) - 1) * 100
            'TextBox8.Text = aporce_ganan
        Catch ex As Exception
            MsgBox("Problemas con el Calculo verificar Campos")
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        accion = "guardar"
        TextBox2.Enabled = True
        cb5.Enabled = True
        cb4.Enabled = True
        dtp4.Enabled = True
        Button2.Enabled = True
        Button8.Enabled = False
        Button5.Enabled = True


        Select Case cb6.Text
            Case "RESCATE"
                Button8.Enabled = True
                llenar_grid()
                dgv2.Visible = False
                dgv.Visible = True
                dgv.Enabled = True
                Label38.Text = "LISTA DE PARTICIPACIONES"
            Case "DISTRIBUCION"
                ListView1.Items.Clear()
                ListView1.Visible = False
                dgv2.Visible = False
                dgv.Visible = True
                dgv.Enabled = True
                llenar_grid()
                Label38.Text = "LISTA DE PARTICIPACIONES"
                Button8.Enabled = True
        End Select

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        nc = InputBox("Ingrese el Codigo de Participacion")
        sql = "exec ver_d_participacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            TextBox1.Text = dr(0)
            cod_parti = dr(1)
            cod_manco = dr(2)
            cod_certi = dr(3)
            cod_fondo = dr(4)
            t2.Text = dr(12)
            t3.Text = dr(13)
            t4.Text = dr(3)
            t5.Text = dr(14)
            cb1.Text = dr(7)
            dtp1.Value = dr(5)
            dtp2.Value = dr(11)
            cb2.Text = dr(6)
            t6.Text = dr(10)
            t7.Text = dr(8)
            t8.Text = dr(9)
            cb4.Text = dr(16)
            TextBox2.Text = dr(17)
            dtp4.Value = dr(18)
            cb5.Text = dr(19)


        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        TextBox9.Enabled = True
        filtro_PARTICIPACION()
    End Sub

    Private Sub cb6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb6.SelectedIndexChanged
        Try
            Select Case cb6.Text
                Case "RESCATE"
                    Button5.Enabled = True
                    Button6.Enabled = True
                    Button3.Enabled = True
                    Button4.Enabled = True
                    Button8.Enabled = False
                    dgv.Enabled = True
                    ListView1.Visible = False
                    dgv2.Visible = True
                    GroupBox1.Enabled = True
                    Label38.Text = "LISTA DE DISTRIBUCION DE BENEFICIOS"
                Case "DISTRIBUCION"
                    Button5.Enabled = False
                    Button6.Enabled = False
                    Button3.Enabled = True
                    Button4.Enabled = False
                    Button8.Enabled = True
                    dgv.Enabled = False
                    ListView1.Visible = False
                    dgv2.Visible = True
                    GroupBox1.Enabled = False
                    Label38.Text = "LISTA DE DISTRIBUCION DE BENEFICIOS"
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        dgv.Visible = False
        ListView1.Visible = False
        dgv2.Visible = True
        dgv2.Enabled = True
        llenar_grid2()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        nc = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_d_participacion '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            TextBox1.Text = dr(0)
            cod_parti = dr(1)
            cod_manco = dr(2)
            cod_certi = dr(3)
            cod_fondo = dr(4)
            t2.Text = dr(12)
            t3.Text = dr(13)
            t4.Text = dr(3)
            t5.Text = dr(14)
            cb1.Text = dr(7)
            dtp1.Value = dr(5)
            dtp2.Value = dr(11)
            cb2.Text = dr(6)
            t6.Text = dr(10)
            t7.Text = dr(8)
            t8.Text = dr(9)
            cb4.Text = dr(16)
            TextBox2.Text = dr(17)
            dtp4.Value = dr(18)
            cb5.Text = dr(19)

        Else
            MessageBox.Show("Los Datos no Existen")
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        filtro_PARTICIPACION()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        buscar_v_f()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        llenar_grid()
        actualizar_distparti()
        llenar_grid()
        actualizar_distfondo()
        llenar_grid()
        MsgBox("NUEVA FECHA DE DISTRIBUCION, VALOR CUOTA, MONTO DE PARTICIPACION Y NUMERO DE PARTICIPACIONES QUEDA ACTUALIZADOS", MsgBoxStyle.Information, ":: Optima Inversiones:::")
    End Sub

    Dim res As Integer
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader

    Private Sub Button11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click
        Me.Close()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim save As New SaveFileDialog
        Dim ruta As String
        Dim xlapp As Object = CreateObject("Excel.Application")
        Dim pth As String = ""
        'crea nueva hoja
        Dim xlwb As Object = xlapp.workbooks.add
        Dim xlws As Object = xlwb.worksheets(1)
        Try
            'exportamos los carateres de la columna

            For c As Integer = 0 To dgv2.Columns.Count - 1
                xlws.cells(1, c + 1).value = dgv2.Columns(c).HeaderText

            Next
            'exporatmaos las cabeceras de las columnas
            For r As Integer = 0 To dgv2.RowCount - 1
                'xlws.cells(1, r + 1).value = dgv.Columns(r).HeaderText
                For c As Integer = 0 To dgv2.Columns.Count - 1
                    xlws.cells(r + 2, c + 1).value = Convert.ToString(dgv2.Item(c, r).Value)

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

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        accautodistribene.Show()
        Me.Enabled = False


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        llenar_grid2()
        actualizarMONTOPARTICIPACIONES()
    End Sub

    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    'variable locales
    Dim accion, sql, nc, gest, tip_partic As String
    Dim vc_act, mont_parti, num_parti As String
    Dim d1, m1, a1, d2, m2, a2, d3, m3, a3, dia1, mes1, dia2, mes2, dia3, mes3, fec_ini_b, fec_ini, fec_sal As String
    Private Sub reparticion_beneficio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Distribucion de Beneficios y Rescates" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        dtp5.Value = Datos_Generales_del_Fondo.dtp1.Value.AddDays(Datos_Generales_del_Fondo.t18.Text)
        dgv.AllowUserToAddRows = False
        dgv2.AllowUserToAddRows = False
        Label41.Text = ""
        Label41.Text = Datos_Generales_del_Fondo.TextBox1.Text
        Control.CheckForIllegalCrossThreadCalls = False
        TextBox4.Text = 5
        dgv.Visible = False
        dgv2.Visible = True
        Label38.Text = "LISTA DE DISTRIBUCION DE BENEFICIOS"
        llenar_grid2()
        usuario = "admin"
        clave = "OP2018"

    End Sub
    Private Sub buscar_v_f()
        Try
            sql = ""
            sql = "select *from datos_fondo where id in (select max(id) from datos_fondo)"
            'sql = "exec ver_d_participacion '" + nc + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                t1.Text = dr(14)
            Else
                MessageBox.Show("Los Datos no Existen")
            End If
        Catch ex As Exception
            MsgBox("Error de Conexion", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        End Try

    End Sub

    Private Sub llenar_grid()
        Try
            sql = "select * from v_d_participacion where estado='VIGENTE'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_d_participacion")
            dgv.DataSource = ds
            dgv.DataMember = "v_d_participacion"
            conexion.conexion2.Close()
        Catch ex As Exception
            MsgBox("Error de Conexion", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        End Try

    End Sub

    Private Sub llenar_grid2()
        Try
            sql = "select * from v_rep_bene_resc"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "v_rep_bene_resc")
            dgv2.DataSource = ds
            dgv2.DataMember = "v_rep_bene_resc"
            conexion.conexion2.Close()
        Catch ex As Exception
            MsgBox("Error de Conexion", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        End Try

    End Sub

    Private Sub carga_listviw()
        Try
            Dim i As Integer = 0
            For Each Row As DataGridViewRow In dgv.Rows

                cod_parti = Row.Cells("CODIGO DE PARTICIPACION").Value
                cod_partici = Row.Cells("CODIGO DE PARTICIPE").Value
                nom_parti = Row.Cells("NOMBRE DE PARTICIPE").Value
                cod_manco = Row.Cells("CODIGO DE MANCOMUNADO").Value
                nom_manco = Row.Cells("NOMBRE DE MANCOMUNADO").Value
                cod_certi = Row.Cells("CODIGO DE CERTIFICADO").Value
                cod_fondo = Row.Cells("CODIGO DE FONDO").Value
                nom_fondo = Row.Cells("NOMBRE DE FONDO").Value
                dtp1.Value = Row.Cells("FECHA DE INGRESO").Value
                dtp2.Value = Row.Cells("FECHA DE SALIDA").Value
                fec_ini = Row.Cells("FECHA DE INGRESO").Value
                fec_sal = Row.Cells("FECHA DE SALIDA").Value
                gest = Row.Cells("GESTION").Value
                tip_partic = Row.Cells("TIPO DE PARTICIPACION").Value
                mont_parti = Row.Cells("MONTO DE PARTICIPACION").Value
                num_parti = Row.Cells("NUMERO DE PARTICIPACIONES").Value
                vc_act = Row.Cells("VALOR CUOTA ACTUAL").Value
                estado = Row.Cells("ESTADO").Value
                fec_rescate = dtp4.Value.ToString("dd/MM/yyyy")
                tip_distri = Row.Cells("TIPO DE DISTRIBUCION").Value
                calc_benef_auto()
                i += 1
                Dim linea As New ListViewItem(i)
                linea.SubItems.Add(cod_parti)
                linea.SubItems.Add(tip_partic)
                linea.SubItems.Add(cod_partici)
                linea.SubItems.Add(cod_manco)
                linea.SubItems.Add(nom_parti)
                linea.SubItems.Add(nom_manco)
                linea.SubItems.Add(nom_fondo)
                linea.SubItems.Add(gest)
                linea.SubItems.Add(mont_parti)
                linea.SubItems.Add(num_parti)
                linea.SubItems.Add(vc_act)
                linea.SubItems.Add(fec_ini)
                linea.SubItems.Add(fec_sal)
                linea.SubItems.Add(fec_rescate)
                linea.SubItems.Add(t1.Text)
                linea.SubItems.Add(abenef)
                linea.SubItems.Add(aporce_ganan)
                linea.SubItems.Add(aretencion)
                linea.SubItems.Add(mtbeneficio)
                linea.SubItems.Add(tip_distri)
                linea.SubItems.Add(estado)
                ListView1.Items.Add(linea)

            Next
        Catch ex As Exception
            MsgBox("Error de Conexion", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        End Try


    End Sub

    Private Sub guardar_reparticionauto()
        Try
            For i = 0 To ListView1.Items.Count - 1
                cod_parti = ListView1.Items(i).SubItems(1).Text
                tip_partic = ListView1.Items(i).SubItems(2).Text
                cod_partici = ListView1.Items(i).SubItems(3).Text
                cod_manco = ListView1.Items(i).SubItems(4).Text
                nom_parti = ListView1.Items(i).SubItems(5).Text
                nom_manco = ListView1.Items(i).SubItems(6).Text
                nom_fondo = ListView1.Items(i).SubItems(7).Text
                gest = ListView1.Items(i).SubItems(8).Text
                mont_parti = ListView1.Items(i).SubItems(9).Text
                num_parti = ListView1.Items(i).SubItems(10).Text
                vc_act = ListView1.Items(i).SubItems(11).Text
                Dim f_ini As Date = ListView1.Items(i).SubItems(12).Text
                fec_ini = f_ini.ToString("yyyyMMdd")
                Dim f_final As Date = ListView1.Items(i).SubItems(13).Text
                fec_sal = f_final.ToString("yyyyMMdd")
                Dim f_repa As Date = ListView1.Items(i).SubItems(14).Text
                fec_rescate = f_repa.ToString("yyyyMMdd")
                Dim v_c_f As String = ListView1.Items(i).SubItems(15).Text
                abenef = ListView1.Items(i).SubItems(16).Text
                aporce_ganan = ListView1.Items(i).SubItems(17).Text
                aretencion = ListView1.Items(i).SubItems(18).Text
                mtbeneficio = ListView1.Items(i).SubItems(19).Text
                tip_distri = ListView1.Items(i).SubItems(20).Text
                estado = ListView1.Items(i).SubItems(21).Text

                'Dim gest As String = Anex_Cronog.gestion


                sql = "exec alta_rep_bene_resc '" + cod_parti + "','" + tip_partic + "','" + cod_partici + "','" + cod_manco + "','" + nom_parti + "','" + nom_manco + "','" + nom_fondo + "','" + gest + "','" + mont_parti + "','" + num_parti + "','" + vc_act + "','" + fec_ini + "','" + fec_sal + "','" + fec_rescate + "','" + v_c_f + "','" + abenef + "','" + aporce_ganan + "','" + aretencion + "','" + mtbeneficio + "','" + tip_distri + "','" + estado + "'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                dr.Close()
                conexion.conexion2.Close()

                'Anex_Cronog.dtp2.Value = f_final
                'tinteres += int
                'Anex_Cronog.t12.Text = tinteres
                'Close()
            Next
            MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        Catch ex As Exception
            MsgBox("Error de Conexion", MsgBoxStyle.Information, ":: Optima Inversiones:::")
        End Try

    End Sub

    Private Sub guardar_reparticionmanual()

        cod_parti = TextBox1.Text
        tip_partic = cb1.Text
        nom_parti = t2.Text
        nom_manco = t3.Text
        nom_fondo = t5.Text
        cod_certi = t4.Text
        gest = cb2.Text
        mont_parti = t7.Text
        num_parti = t8.Text
        vc_act = t6.Text
        Dim f_ini As Date = dtp1.Value
        fec_ini = f_ini.ToString("yyyyMMdd")
        Dim f_final As Date = dtp2.Value
        fec_sal = f_final.ToString("yyyyMMdd")
        Dim f_repa As Date = dtp4.Value
        fec_rescate = f_repa.ToString("yyyyMMdd")
        Dim v_c_f As String = t1.Text
        abenef = TextBox3.Text
        aporce_ganan = TextBox8.Text
        aretencion = TextBox5.Text
        mtbeneficio = TextBox6.Text
        tip_distri = cb5.Text
        estado = cb4.Text

        'Dim gest As String = Anex_Cronog.gestion


        sql = "exec alta_rep_bene_resc '" + cod_parti + "','" + tip_partic + "','" + cod_partici + "','" + cod_manco + "','" + nom_parti + "','" + nom_manco + "','" + nom_fondo + "','" + gest + "','" + mont_parti + "','" + num_parti + "','" + vc_act + "','" + fec_ini + "','" + fec_sal + "','" + fec_rescate + "','" + v_c_f + "','" + abenef + "','" + aporce_ganan + "','" + aretencion + "','" + mtbeneficio + "','" + tip_distri + "','" + estado + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        dr.Close()
        conexion.conexion2.Close()

        'Anex_Cronog.dtp2.Value = f_final
        'tinteres += int
        'Anex_Cronog.t12.Text = tinteres
        'Close()
        MsgBox("Resgistros exportados exitosamente", MsgBoxStyle.Information, ":: Optima Inversiones:::")
    End Sub
    Public Sub filtro_PARTICIPACION()
        Try
            nc = TextBox9.Text
            sql = "select *from v_d_participacion where [CODIGO DE PARTICIPACION] like'" + nc + "%'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select *from v_d_participacion where [CODIGO DE PARTICIPACION] like'" + nc + "%'")
            dgv.DataSource = ds
            dgv.DataMember = "select *from v_d_participacion where [CODIGO DE PARTICIPACION] like'" + nc + "%'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("El filtro presenta problemas", "Optima")
        End Try

    End Sub

    Private Sub actualizar_distfondo()
        Try
            Dim fec_cambio_dist As String = dtp5.Value.ToString("yyyyMMdd")
            Dim nvci As String = Datos_Generales_del_Fondo.t7.Text
            Dim acum_mont_parti1 As Decimal
            Dim acum_num_parti1 As Decimal
            For Each Row As DataGridViewRow In dgv.Rows
                Dim acum_mont_parti2 As Decimal
                Dim acum_num_parti2 As Decimal
                Dim mont_participacio As Decimal = Row.Cells("MONTO DE PARTICIPACION").Value
                Dim NUM_PARTICIPACION As Decimal = Row.Cells("NUMERO DE PARTICIPACIONES").Value
                Dim ESTADO As String = Row.Cells("estado").Value
                If ESTADO = "VIGENTE" Then
                    acum_mont_parti2 = mont_participacio
                    acum_num_parti2 = NUM_PARTICIPACION
                Else
                    acum_mont_parti2 = 0
                    acum_num_parti2 = 0
                End If
                acum_mont_parti1 += acum_mont_parti2
                acum_num_parti1 += acum_num_parti2
            Next

            sql = "update nfondo  set fecha_distrib='" + fec_cambio_dist + "',v_cuota_actual='" + nvci + "', capital_a= '" + acum_mont_parti1.ToString("#.00000") + "',nro_cuotas='" + acum_num_parti1.ToString("#.00000") + "' where nocontrol='" + Datos_Generales_del_Fondo.t1.Text + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            dr.Close()
            conexion.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error de  Conexion", "Optima")
        End Try


    End Sub
    Private Sub actualizar_distparti()
        Try
            For Each Row As DataGridViewRow In dgv.Rows
                Dim fec_cambio_dist As String = dtp5.Value.ToString("yyyyMMdd")
                Dim cod_participacion As String = Row.Cells("CODIGO DE PARTICIPACION").Value
                Dim estado_participacion As String = Row.Cells("ESTADO").Value
                Dim mont_participacio As Decimal = Row.Cells("MONTO DE PARTICIPACION").Value
                Dim vcini As Decimal = Datos_Generales_del_Fondo.t7.Text
                Dim NUM_PARTICIPACION As Decimal = mont_participacio / vcini
                sql = "update d_participacion  set fec_rescate='" + fec_cambio_dist + "',v_cuota_actual='" + vcini.ToString("#.00000") + "',n_parti='" + NUM_PARTICIPACION.ToString("#.00000") + "'  where cod_part='" + cod_participacion + "'and estado='VIGENTE'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                dr.Close()
                conexion.conexion2.Close()
            Next
        Catch ex As Exception
            MessageBox.Show("Error de  Conexion", "Optima")
        End Try



    End Sub
    Private Sub actualizarMONTOPARTICIPACIONES()
        Try
            For Each Row As DataGridViewRow In dgv2.Rows
                Dim fec_cambio_dist As String = dtp4.Value.ToString("yyyyMMdd")
                Dim cod_participacion As String = Row.Cells("CODIGO DE PARTICIPACION").Value
                Dim estado_participacion As String = Row.Cells("ESTADO").Value
                Dim Monto_parti As Decimal = Row.Cells("MONTO DE PARTICIPACION").Value
                Dim beneficio_total As Decimal = Row.Cells("BENEFICIO TOTAL").Value
                Dim MTPARTI As Decimal = Monto_parti + beneficio_total
                Dim vca As Decimal = Datos_Generales_del_Fondo.t7.Text
                Dim numparti As Decimal = MTPARTI / vca
                sql = "update d_participacion  set mont_part='" + MTPARTI.ToString("#.0000") + "',n_parti='" + numparti.ToString("#.0000") + "' where cod_part='" + cod_participacion + "'and estado='VIGENTE' and fec_rescate='" + fec_cambio_dist + "' and tip_dist='REINVIERTE'"
                conexion.conectarfondo()
                com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                dr = com.ExecuteReader
                dr.Close()
                conexion.conexion2.Close()
            Next

            MsgBox("LOS MONTOS EN LAS PARTICIPACIONES AN SIDO ACTUALIZADOS")

        Catch ex As Exception
            MessageBox.Show("Error de  Conexion", "Optima")
        End Try

    End Sub


End Class