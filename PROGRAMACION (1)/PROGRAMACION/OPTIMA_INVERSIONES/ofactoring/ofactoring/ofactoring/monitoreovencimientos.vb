Public Class monitoreovencimientos
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        rev_cro_anx.Show()
        llenar_grigsegui()
        'rev_cro_anx.coloini()
        Me.Close()
    End Sub

    Dim sql, sql2, sql3, nc As String
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub monitoreovencimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.AllowUserToAddRows = False
        Me.Text = "Monitoreo de Cuotas de Cronogramas y Facturas de Anexos " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        llenar_grig()
        dias_vencimiento()
        'DIAS()
    End Sub


    Private Sub llenar_grig()
        Dim fec_consul As Date = Today
        Dim year As String = fec_consul.ToString("yyyy")
        Dim fec As String = fec_consul.ToString("yyyyMMdd")
        Dim FEC2 As String = fec_consul.ToString("dd/MM/yyyyy")
        Label6.Text = FEC2
        Label8.Text = year
        Try
            sql = "select DATEDIFF(DAY,'" + fec + "',F_VENCI) as [DIAS DE VENCIMIENTO], cod_cuota as [CODIGO DE CUOTA O ANEXO] from CUOTAS_OPERACION WHERE year(F_VENCI)='" + year + "' UNION ALL select DATEDIFF(DAY,'" + fec + "',fec_venc_doc), cod_fac_anx  from fac_operacion_anx WHERE year(fec_venc_doc)='" + year + "'"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select DATEDIFF(DAY,'" + fec + "',F_VENCI) as [DIAS DE VENCIMIENTO], cod_cuota as [CODIGO DE CUOTA O ANEXO] from CUOTAS_OPERACION WHERE year(F_VENCI)='" + year + "' UNION ALL select DATEDIFF(DAY,'" + fec + "',fec_venc_doc), cod_fac_anx  from fac_operacion_anx WHERE year(fec_venc_doc)='" + year + "'")
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "select DATEDIFF(DAY,'" + fec + "',F_VENCI) as [DIAS DE VENCIMIENTO], cod_cuota as [CODIGO DE CUOTA O ANEXO] from CUOTAS_OPERACION WHERE year(F_VENCI)='" + year + "' UNION ALL select DATEDIFF(DAY,'" + fec + "',fec_venc_doc), cod_fac_anx  from fac_operacion_anx WHERE year(fec_venc_doc)='" + year + "'"
            conexion.conexion2.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try
    End Sub

    Public Sub llenar_grigsegui()
        Dim fec_consul As Date = Today
        Dim year As String = fec_consul.ToString("yyyy")
        Dim fec As String = fec_consul.ToString("yyyyMMdd")
        Dim FEC2 As String = fec_consul.ToString("dd/MM/yyyyy")
        Label6.Text = FEC2
        Label8.Text = year
        Try
            sql = "select COD_CUOTA as [CODIGO DE CUOTA], COD_OP AS [CODIGO DE OPERACION], F_VENCI AS [FECHA DE VENCIMIENTO],fec_mora_adelanto as [FECHA DE ADELANTO Y MORA], dias_mora as [DIAS DE MORA], estado as [ESTADO] from CUOTAS_OPERACION where F_VENCI<= '" + fec + "'  UNION all select cod_fac_anx, cod_anexo,fec_venc_doc,fec_mora_adelanto as [FECHA DE ADELANTO Y MORA], dias_mora as [DIAS DE MORA], estado from fac_operacion_anx  where fec_venc_doc<= '" + fec + "'  ORDER BY [FECHA DE VENCIMIENTO] asc"
            conexion.conectarfondo()
            da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "select COD_CUOTA as [CODIGO DE CUOTA], COD_OP AS [CODIGO DE OPERACION], F_VENCI AS [FECHA DE VENCIMIENTO],fec_mora_adelanto as [FECHA DE ADELANTO Y MORA], dias_mora as [DIAS DE MORA], estado as [ESTADO] from CUOTAS_OPERACION where F_VENCI<= '" + fec + "'  UNION all select cod_fac_anx, cod_anexo,fec_venc_doc,fec_mora_adelanto as [FECHA DE ADELANTO Y MORA], dias_mora as [DIAS DE MORA], estado from fac_operacion_anx  where fec_venc_doc<= '" + fec + "'  ORDER BY [FECHA DE VENCIMIENTO] asc")
            rev_cro_anx.dgv.DataSource = ds
            rev_cro_anx.dgv.DataMember = "select COD_CUOTA as [CODIGO DE CUOTA], COD_OP AS [CODIGO DE OPERACION], F_VENCI AS [FECHA DE VENCIMIENTO],fec_mora_adelanto as [FECHA DE ADELANTO Y MORA], dias_mora as [DIAS DE MORA], estado as [ESTADO] from CUOTAS_OPERACION where F_VENCI<= '" + fec + "'  UNION all select cod_fac_anx, cod_anexo,fec_venc_doc,fec_mora_adelanto as [FECHA DE ADELANTO Y MORA], dias_mora as [DIAS DE MORA], estado from fac_operacion_anx  where fec_venc_doc<= '" + fec + "'  ORDER BY [FECHA DE VENCIMIENTO] asc"
            conexion.conexion2.Close()
            rev_cro_anx.coloini()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "Optima")
        End Try
    End Sub

    Private Sub dias_vencimiento()
        Dim DOS, CINCO, VENCIDO, VEN_HOY As Integer

        For Each Row As DataGridViewRow In DataGridView1.Rows
            Dim dv As String = Row.Cells("DIAS DE VENCIMIENTO").Value
            If dv = 0 Then

                VEN_HOY = VEN_HOY + 1
            End If

        Next
        For Each Row As DataGridViewRow In DataGridView1.Rows
            Dim dv As String = Row.Cells("DIAS DE VENCIMIENTO").Value
            If dv >= 1 And dv <= 2 Then

                DOS = DOS + 1
            End If
        Next

        For Each Row As DataGridViewRow In DataGridView1.Rows
            Dim dv As String = Row.Cells("DIAS DE VENCIMIENTO").Value
            If dv >= 3 And dv <= 5 Then

                CINCO = CINCO + 1
            End If

        Next
        For Each Row As DataGridViewRow In DataGridView1.Rows
            Dim dv As String = Row.Cells("DIAS DE VENCIMIENTO").Value
            If dv < 0 Then

                VENCIDO = VENCIDO + 1
            End If

        Next

        TextBox1.Text = DOS
        TextBox2.Text = CINCO
        TextBox3.Text = VENCIDO
        TextBox4.Text = VEN_HOY
    End Sub

    Private Sub DIAS()
        Dim cont As Integer
        For Each i As DataGridViewRow In DataGridView1.Rows

            If i.Cells("DIAS DE VENCIMIENTO").Value < 1 Then
                cont = cont + 1
            End If
        Next
        TextBox3.Text = cont
    End Sub

End Class