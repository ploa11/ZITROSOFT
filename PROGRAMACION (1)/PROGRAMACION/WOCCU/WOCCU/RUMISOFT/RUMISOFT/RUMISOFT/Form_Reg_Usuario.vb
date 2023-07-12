Public Class Form_Reg_Usuario
    'variables publicas
    Public codigo, nom, ap_pa, ap_ma, dni, cargo, pase1, pase2 As String
    Public cod As Double

    'variables locales
    Dim preg, sql, accion As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            ComboBox2.Text = ""
            ComboBox1.Text = ""
            ListView1.Items.Clear()
            ListView1.Visible = True
            dgv.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Dim a As Integer

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        item()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        accion = "guardar"
        guardar()
        ListView1.Visible = False
        dgv.Visible = True
        llenar_grid()
    End Sub

    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Dim ds As DataSet
    Dim dt As DataTable
    Dim res, o As Integer
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Form_Reg_Usuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgv.AllowUserToAddRows = False
            ListView1.Visible = False
            dgv.Visible = True
            llenar_grid()
            llenar_combo1()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub item()
        preg = MsgBox("Desea agregar datos de Usuario", vbYesNo)
        a += 1
        Dim linea As New ListViewItem(a)

        If preg = vbYes Then
            'linea.SubItems.Add(UCase(TextBox1.Text))
            linea.SubItems.Add(UCase(TextBox2.Text))
            linea.SubItems.Add(UCase(TextBox3.Text))
            linea.SubItems.Add(UCase(TextBox4.Text))
            linea.SubItems.Add(UCase(ComboBox1.Text))
            linea.SubItems.Add(UCase(TextBox6.Text))
            linea.SubItems.Add(UCase(ComboBox2.Text))
            linea.SubItems.Add(UCase(DateTimePicker1.Value.ToString("dd/MM/yyyy")))
            ListView1.Items.Add(linea)
            MessageBox.Show("Datos Agregados", "RUMISOFT")

        Else

            MessageBox.Show("No hay que registrar", "RUMISOFT")
            Button4.Enabled = True
            Button6.Enabled = False
        End If


    End Sub

    Private Sub llenar_grid()
        Try
            sql = "select COD AS [CODIGO],NOMBRE  AS [NOMBRES], APELLIDOS , DNI, CARGO, CLAVE,SEDE,FEC_REG AS [FECHA DE REGISTRO] from USUARIOS"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "USUARIOS")
            dgv.DataSource = ds
            dgv.DataMember = "USUARIOS"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

    End Sub

    Private Sub guardar()
        'nc = codigofactura.Text
        'fec = dtp1.Value
        'fecha = fec.ToString("yyyyMMdd")

        For o = 0 To ListView1.Items.Count - 1
            buscar_copiar()
            'codigo = "USU0000001"
            Dim NOM As String = ListView1.Items(o).SubItems(1).Text
            Dim APE As String = ListView1.Items(o).SubItems(2).Text
            Dim DNI As String = ListView1.Items(o).SubItems(3).Text
            Dim CARGO As String = ListView1.Items(o).SubItems(4).Text
            'Dim FEC As Date = ListView1.Items(0).SubItems(5).Text
            Dim CLAVE As String = ListView1.Items(o).SubItems(5).Text
            Dim SEDE As String = ListView1.Items(o).SubItems(6).Text

            Try
                If accion = "guardar" Then

                    sql = "select *from USUARIOS where  DNI='" + ListView1.Items(o).SubItems(3).Text + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader

                    If dr.Read Then
                        'cod = dr(0)
                        MessageBox.Show("Los Datos ya Existen", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dr.Close()
                        Form_Reg_SRV_SQL.conexion.Close()
                    Else
                        sql = "INSERT INTO USUARIOS  VALUES ('" & codigo & "','" & NOM & "','" & APE & "','" & DNI & "','" & CARGO & "','" & CLAVE & "','" & DateTimePicker1.Value.ToString("yyyyMMdd") & "','" & SEDE & "')"
                        Form_Reg_SRV_SQL.conectar()
                        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                        res = com.ExecuteNonQuery
                        Form_Reg_SRV_SQL.conexion.Close()
                        MessageBox.Show("Registro Guardado", "RUMISOFT")
                    End If


                    'buscar_copiar()
                    'llenar_grid()
                    'facturas()
                    'fac_operacion_anx.Show()
                End If





            Catch ex As Exception

            End Try
        Next
        '

    End Sub

    Private Sub buscar_copiar()
        Dim aum_cod As String
        Dim dat As String = "USU"
        'Dim cod, serie As String
        sql = "select *from USUARIOS where id in (select max(id) from USUARIOS)"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            cod = Microsoft.VisualBasic.Right(dr(0), 3)
            'TextBox1.Text = dr(0)
            'dtp1.Value = dr(1)
            'cb1.Text = dr(2)
            't1.Text = dr(4)
            't2.Text = dr(7)
            't4.Text = dr(8)
            't5.Text = dr(9)
        Else
            MessageBox.Show("Se generara Codigo", "RUMISOFT")
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        If cod = 0 Then
            cod = 0
            aum_cod = cod.ToString("00000000")
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            codigo = dat & (cod + 1).ToString("00000000")
        Else
            aum_cod = Microsoft.VisualBasic.Right(cod, 8)
            ' aum_numfac = Microsoft.VisualBasic.Right(num_fac, 5)
            'cod = Microsoft.VisualBasic.Left(cod_fac, 2)
            'serie = Microsoft.VisualBasic.Left(num_fac, 4)
            codigo = dat & (cod + 1).ToString("00000000")
            't3.Text = serie & "-" & (aum_numfac + 1).ToString("0000000")
        End If
    End Sub

    Public Sub llenar_combo1()
        sql = "select *from T_SEDE"
        Form_Reg_SRV_SQL.conectar()
        da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = "SEDE"
        ComboBox2.ValueMember = "SEDE"
    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Try
            Select Case pase1
                Case "centro costo"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from USUARIOS where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Reg_Cent_Costo.TextBox3.Text = dr(4)
                        Form_Reg_Cent_Costo.cod_sede = dr(0)

                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
                Case "salida"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from USUARIOS where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Nva_Salida.TextBox7.Text = dr(3)
                        form_ingreso_salida.TextBox7.Text = dr(3)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()

                Case "ingreso"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from USUARIOS where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Reg_Cent_Costo.TextBox3.Text = dr(4)
                        Form_Reg_Cent_Costo.cod_sede = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
                Case "oc"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from USUARIOS where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Orden_Compra.TextBox13.Text = dr(1)
                        Form_Orden_Compra.TextBox12.Text = dr(2)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class