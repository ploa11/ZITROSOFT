Public Class facturacion_fondos

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
    Public nom, nom_fondo, ruc_fondo, ruc, direc, dis_dep_prov, debe, haber, fecha, cod_crono, preg, codigo, acciones, glosa, analitica, cuenta, nom_cuenta, COD As String
    Public comi_des, igv_comides, sub_total, igv_total, total As Decimal
    Dim compara, accion As String
    Dim fec As Date
    Dim i, g, cambio As String
    Dim gen_cod, con As Integer
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub gb4_Enter(sender As Object, e As EventArgs) Handles gb4.Enter

    End Sub

    Private Sub st_TextChanged(sender As Object, e As EventArgs) Handles st.TextChanged

    End Sub

    Private Sub codigofactura_TextChanged(sender As Object, e As EventArgs) Handles codigofactura.TextChanged

    End Sub

    Private Sub t3_TextChanged(sender As Object, e As EventArgs) Handles t3.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        gen_asiento()
    End Sub

    Dim dt As DataTable
    Dim sql, sql2, sql3, nc As String
    Dim res, o As Integer
    Dim cod_fac, num_fac As String

    Private Sub t2_TextChanged(sender As Object, e As EventArgs) Handles t2.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cb3.Enabled = True
        dtp1.Enabled = True
        dtp1.Value = Today

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        preg = MsgBox("Desea registrar la factura", vbYesNo)
        If preg = vbYes Then
            accion = "guardar"
            guardar()
            Button4.Enabled = False
            Button1.Enabled = False
        Else
            MessageBox.Show("Factura no Se genero", "Optima")
            i = 0
            g = 0
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_2(sender As Object, e As EventArgs) Handles cb3.SelectedIndexChanged
        Select Case cb3.Text
            Case "FACTURA"
                GB1.Enabled = True
                GB1.Visible = True
                gb2.Enabled = False
                gb2.Visible = False
                GB3.Enabled = False
                GB3.Visible = False
                cambio = 1
                buscar_copiar()
            Case "NOTA DE DEBITO"
                GB1.Enabled = False
                GB1.Visible = False
                gb2.Enabled = True
                gb2.Visible = True
                GB3.Enabled = False
                GB3.Visible = False
                cambio = 2
            Case "NOTA DE CREDITO"
                GB1.Enabled = False
                GB1.Visible = False
                gb2.Enabled = False
                gb2.Visible = False
                GB3.Enabled = True
                GB3.Visible = True
                cambio = 3
        End Select
    End Sub

    Private Sub facturacion_fondos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dgv.AllowUserToAddRows = False
        Me.Text = "Facturacion del Fondo" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        nom_fondo = Datos_Generales_del_Fondo.t2.Text
        ruc_fondo = Datos_Generales_del_Fondo.t13.Text


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        comisiones_por_desembolso.Show()
        comisiones_por_desembolso.GroupBox2.Visible = False
        comisiones_por_desembolso.filtrar_facturacion()
    End Sub

    Private Sub ReportViewer2_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' i = 1
        'g += i
        item()
        GB1.Enabled = False
        Button4.Enabled = True

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cb2.SelectedIndexChanged

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)

    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        fec = dtp1.Value
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged
        Select Case cb1.Text
            Case "COMISION DE DESEMBOLSO"
                t1.Enabled = True
                t2.Enabled = True
                t3.Enabled = True
        End Select
    End Sub

    Private Sub TextBox1_DoubleClick(sender As Object, e As EventArgs) Handles t1.DoubleClick
        registro_clientes.Show()
        registro_clientes.activar = 3
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles t1.TextChanged

    End Sub

    Private Sub t2_DoubleClick(sender As Object, e As EventArgs) Handles t2.DoubleClick
        Anex_Cronog.t13.Text = t1.Text
        fecha = fec.ToString("yyyyMMdd")
        Anex_Cronog.fecha_f = fecha
        Anex_Cronog.Show()
        Anex_Cronog.filtro_cod_clie_fecha()
    End Sub

    Private Sub t2_MouseEnter(sender As Object, e As EventArgs) Handles t2.MouseEnter

    End Sub
    Private Sub item()
        Dim j As Integer

        For j = 0 To 1000
            Dim linea As New ListViewItem(j)
            preg = MsgBox("Desea agregar el item para facturar", vbYesNo)
            If preg = vbYes Then
                linea.SubItems.Add((cb2.Text & "  " & t2.Text & "   " & "CON FECHA" & "   " & fec.ToString("dd-MM-yyyy")))
                linea.SubItems.Add(comi_des.ToString("#,#.00"))
                sub_total += comi_des
                igv_total += igv_comides

                ListView1.Items.Add(linea)
                MessageBox.Show("Item Agregados", "Optima")
                st.Text = sub_total
                igv.Text = igv_total
                ' Dim st001 As Decimal = st.Text
                'Dim igv001 As Decimal = igv.Text
                total = sub_total + igv_total
                t.Text = total
            Else

                MessageBox.Show("No hay mas item, generar factura o cancelar factura", "Optima")
                'i = 0
                ' g = 0
                Exit For
            End If
        Next
        ' preg = MsgBox("Desea agregar el item para facturar", vbYesNo)
        ' If preg = vbYes Then
        'item()
        'MessageBox.Show("Item Agregados", "Optima")
        '
        ' st.Text = sub_total
        'igv.Text = igv_total
        'Dim st001 As Decimal = st.Text
        'Dim igv001 As Decimal = igv.Text
        '  total = st001 + igv001
        't.Text = total
        'Else
        'MessageBox.Show("Item no Agregados", "Optima")
        'i = 0
        'g = 0
        'End If

    End Sub

    Private Sub guardar()
        nc = codigofactura.Text
        fec = dtp1.Value
        fecha = fec.ToString("yyyyMMdd")
        If accion = "guardar" Then
            sql = "exec ver_facturas_fondo'" + nc + "','" + t3.Text + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "Optima", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion2.Close()
            Else
                For o = 0 To ListView1.Items.Count - 1
                    Dim des As String = ListView1.Items(o).SubItems(1).Text
                    Dim subt As String = ListView1.Items(0).SubItems(2).Text
                    Dim igv_sub As String = t5.Text
                    sql = "exec alta_cod_facturas '" + fecha + "','" + cb2.Text + "','" + t3.Text + "','" + t1.Text + "','" + nom + "','" + ruc + "','" + t2.Text + "','" + subt + "','" + igv_sub + "','" + total.ToString("#.00000") + "','" + des + "'"
                    conexion.conectarfondo()
                    com = New SqlClient.SqlCommand(sql, conexion.conexion2)
                    res = com.ExecuteNonQuery
                    conexion.conexion2.Close()

                Next
                MessageBox.Show("Factura Generada y Guardada", "Optima")
                'buscar_copiar()
                'llenar_grid()
                'facturas()
                'fac_operacion_anx.Show()
            End If


        End If

    End Sub
    Private Sub buscar_copiar()
        Dim aum_codfac, aum_numfac As String
        Dim cod, serie As String
        Try
            sql = "select *from facturas where id in (select max(id) from facturas)"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            dr = com.ExecuteReader
            If dr.Read Then
                cod_fac = dr(0)
                'dtp1.Value = dr(1)
                'cb1.Text = dr(2)
                num_fac = dr(3)
                't1.Text = dr(4)
                't2.Text = dr(7)
                't4.Text = dr(8)
                't5.Text = dr(9)


            Else
                MessageBox.Show("Los Datos no Existen", "Optima")
            End If
            dr.Close()
            conexion.conexion2.Close()
            aum_codfac = Microsoft.VisualBasic.Right(cod_fac, 8)
            aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            serie = Microsoft.VisualBasic.Left(num_fac, 4)
            codigofactura.Text = cod & (aum_codfac + 1).ToString("00000000")
            t3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
        Catch ex As Exception
            MessageBox.Show("Problemas en la bsuqueda", "Optima")
        End Try

    End Sub

    Private Sub gen_asiento()
        acciones = "guardar"
        sql = ""
        glosa = "COMISIÓN DE DESEMBOLSO CRONOGRAMA" + " " + t2.Text + " " + "FACTURA N°" + " " + t3.Text
        'TextBox1.Text = glosa
        fec = dtp1.Value
        fecha = fec.ToString("yyyyMMdd")
        analitica = t2.Text
        Dim mont1, mont2 As Double
        Try
            For con = 1 To 3
                Select Case con
                    Case = 1
                        cuenta = "121211"
                        buscar_cuenta()
                        mont1 = t.Text
                        debe = mont1
                        haber = 0.0
                        guardar_asiento()
                    Case = 2
                        cuenta = "401111"
                        buscar_cuenta()
                        mont2 = t5.Text
                        debe = 0.0
                        haber = mont2
                        guardar_asiento()
                    Case = 3
                        cuenta = "704119"
                        buscar_cuenta()
                        mont1 = t4.Text
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


            sql = "exec edita_asiento_contable'" + COD + "','" + glosa + "','" + ruc + "','" + analitica + "','" + cuenta + "','" + nom_cuenta + "','" + debe + "','" + haber + "','" + fecha + "'"
            conexion.conectarfondo()
            com = New SqlClient.SqlCommand(sql, conexion.conexion2)
            res = com.ExecuteNonQuery
            conexion.conexion2.Close()
            'MessageBox.Show("Registro Modificado")

        End If
    End Sub

End Class