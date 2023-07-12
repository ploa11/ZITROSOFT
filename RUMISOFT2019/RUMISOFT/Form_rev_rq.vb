Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Form_rev_rq
    'variables publicas
    Public pase1, pase2, pase3, pase4, nct, busq As String

    'variables locales
    Dim preg, sql, accion As String
    Dim a As Integer
    Dim CARGO As String = inicio.CARGO
    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable
    Dim res, o As Integer
    Public RQ_SCC, REV As String


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RQ_SCC = "BUSCAR RQ"
        dgv.AllowUserToAddRows = False
        SELECCION()
        coloini()

    End Sub

    Private Sub Form_rev_rq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
    End Sub
    Private Sub SELECCION()
        Try
            Select Case CARGO

                Case "TECNICO"
                    llenar_grid_USU()
                Case "SUPERVISOR"
                    llenar_grid_SUPER()
                Case "GERENCIA"
                    llenar_grid_GEREN()
                Case "LOGISTICA"
                    llenar_grid_LOGISTICA()
                Case "SISTEMAS"
                    llenar_grid_SISTEMAS()
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub llenar_grid_SUPER()
        Try
            sql = "select COD AS [CODIGO], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CENTRO DE COSTO], CEN_COST AS [CENTRO DE COSTO], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE_CREACION],ESTADO from T_REQUERIMIENTO where DETA_GEN_USU='POR REVISION' and DETA_APROB_USU='Desaprobada'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub
    Private Sub llenar_grid_GEREN()
        Try
            sql = "select COD AS [CODIGO], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CENTRO DE COSTO], CEN_COST AS [CENTRO DE COSTO], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where DETA_REV_USU='POR APROBACION'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Private Sub llenar_grid_USU()
        Try
            sql = "select COD AS [CODIGO], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CENTRO DE COSTO], CEN_COST AS [CENTRO DE COSTO], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where DETA_REV_USU='Desaprobada'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'RQ_SCC = "BUSCAR SCC"
        Select Case ComboBox2.Text
            Case "REQUERIMIENTOS"
                llenar_grid_REQUERIMIENTO()
                color_dgv()
            Case "SUB CENTRO DE COSTOS"
                llenar_grid_SUPER_COSTO_PROYECTO()
                color_dgv()
            Case "ORDENES DE COMPRAS"
                llenar_grid_OC()
                color_dgv()
            Case "FACTURAS PROVEEDORES"
                llenar_grid_FAC_OC()
                color_dgv()
        End Select

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        'Form_Reg_RQ.buscar_rq2()
        ' Me.Close()
    End Sub

    Private Sub llenar_grid_LOGISTICA()
        Try
            sql = "select COD AS [CODIGO], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CENTRO DE COSTO], CEN_COST AS [CENTRO DE COSTO], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where ESTADO='APROBADA'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If RQ_SCC = "BUSCAR RQ" Then
            FILTRO_RQ()
            coloini()
        Else
            FILTRO_SCC()
        End If
        ' Select Case RQ_SCC
        'Case "BUSCAR RQ"
        ' FILTRO_RQ()
        'coloini()
        'Case "BUSCAR SCC"
        'FILTRO_SCC()
        ' End Select
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub llenar_grid_SISTEMAS()
        Try
            sql = "select COD AS [CODIGO], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CENTRO DE COSTO], CEN_COST AS [CENTRO DE COSTO], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO "
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub llenar_grid_SUPER_COSTO_PROYECTO()
        Try
            sql = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_SUB_C_COS_OS")
            dgv.DataSource = ds
            dgv.DataMember = "T_SUB_C_COS_OS"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub
    Private Sub llenar_grid_GEREN_COSTO_PROYECTO()
        Try
            sql = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CENTRO DE COSTO], CEN_COST AS [CENTRO DE COSTO], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where DETA_REV_USU='POR APROBACION'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Private Sub llenar_grid_USU_COSTO_PROYECTO()
        Try
            sql = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CENTRO DE COSTO], CEN_COST AS [CENTRO DE COSTO], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where DETA_REV_USU='Desaprobada'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Private Sub llenar_grid_LOGISTICA_COSTO_PROYECTO()
        Try
            sql = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CENTRO DE COSTO], CEN_COST AS [CENTRO DE COSTO], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where ESTADO='APROBADA'"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Private Sub llenar_grid_SISTEMAS_COSTO_PROYECTO()
        Try
            sql = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CENTRO DE COSTO], CEN_COST AS [CENTRO DE COSTO], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO "
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Public Sub coloini()

        For Each Row As DataGridViewRow In dgv.Rows
            Select Case inicio.CARGO
                Case "SISTEMAS"
                    Select Case Row.Cells("FECHA DE REGISTRO").Value
                        Case = Today
                            Row.DefaultCellStyle.BackColor = Color.Blue
                            Row.DefaultCellStyle.ForeColor = Color.White
                        Case < Today
                            Row.DefaultCellStyle.BackColor = Color.Red
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select

                Case "GERENCIA"
                    Select Case Row.Cells("FECHA DE REGISTRO").Value
                        Case = Today
                            Row.DefaultCellStyle.BackColor = Color.Blue
                            Row.DefaultCellStyle.ForeColor = Color.White
                        Case < Today
                            Row.DefaultCellStyle.BackColor = Color.Red
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select

                Case "SUPERVISOR"

                    Select Case Row.Cells("FECHA DE REGISTRO").Value
                        Case = Today
                            Row.DefaultCellStyle.BackColor = Color.Blue
                            Row.DefaultCellStyle.ForeColor = Color.White
                        Case < Today
                            Row.DefaultCellStyle.BackColor = Color.Red
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select

                Case "LOGISTICA"
                    Select Case Row.Cells("FECHA DE REGISTRO").Value
                        Case = Today
                            Row.DefaultCellStyle.BackColor = Color.Blue
                            Row.DefaultCellStyle.ForeColor = Color.White
                        Case < Today
                            Row.DefaultCellStyle.BackColor = Color.Red
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select
                    ' Case ""
                    'If Row.Cells("FECHA DE ADELANTO Y MORA").Value > Row.Cells("FECHA DE VENCIMIENTO").Value Then
                    '  Row.DefaultCellStyle.BackColor = Color.Red
                    'Row.DefaultCellStyle.ForeColor = Color.White
                    ' Else
                    'If Row.Cells("ESTADO").Value = "VIGENTE" Then
                    'Row.DefaultCellStyle.BackColor = Color.Blue
                    'Row.DefaultCellStyle.ForeColor = Color.White
                    'Else
                    'If Row.Cells("FECHA DE VENCIMIENTO").Value < Today Then
                    'Row.DefaultCellStyle.BackColor = Color.Maroon
                    'Row.DefaultCellStyle.ForeColor = Color.White
                    'Else
                    'If Row.Cells("FECHA DE VENCIMIENTO").Value >= Today Then
                    'Row.DefaultCellStyle.BackColor = Color.OliveDrab
                    'Row.DefaultCellStyle.ForeColor = Color.Black
                    'End If
                    'End If
                    ' End If
                    'End If

            End Select


            'If Today = Row.Cells("FECHA INICIO DE PRESTAMO").Value Then
            'Row.DefaultCellStyle.BackColor = Color.Blue
            'Row.DefaultCellStyle.ForeColor = Color.White
            'End If


        Next

    End Sub

    Public Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Try
            Select Case busq

                Case "busqueda"
                    nct = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    Form_Reg_RQ.buscar_rq2()
                    Form_Reg_RQ.llenar_PRO()
                    Form_Reg_RQ.Button9.Enabled = True
                    If Form_Reg_RQ.ComboBox6.Text = "Aprobado" Then
                        Form_Reg_RQ.Button11.Enabled = True
                    End If
                    Me.Close()
                Case "OC"
                    nct = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    Form_Reg_RQ.buscar_rq2()
                    Form_Reg_RQ.llenar_PRO()
                    ' Form_Reg_RQ.Button9.Enabled = True
                    'If Form_Reg_RQ.ComboBox6.Text = "Aprobado" Then
                    'Form_Reg_RQ.Button11.Enabled = True
                    'End If
                    Me.Close()
                Case "SCC"
                    SCC_BUS()
            End Select




            'Select Case pase1
            'Case "ccosto"
            'Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
            'sql = "Select *from T_SUB_C_COS_OS where  cod='" + selec + "'"
            'Form_Reg_SRV_SQL.conectar()
            'com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
            'dr = com.ExecuteReader
            'If dr.Read Then
            'Form_Reg_Cent_Costo.TextBox2.Text = dr(1)
            'Form_Reg_Cent_Costo.cod_clie = dr(0)
            'End If
            'dr.Close()
            'Form_Reg_SRV_SQL.conexion.Close()
            'Me.Close()

            'End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FILTRO_SCC()
        Select Case ComboBox1.Text
            Case "CODIGO SCC"
                sql = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where COD  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where COD  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where COD  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "CODIGO CC"
                sql = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where COD_CEN_COST  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where COD_CEN_COST  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where COD_CEN_COST  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "ORDEN DE SERVICIO"
                sql = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where ORD_SERV  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where ORD_SERV  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where ORD_SERV  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "NOMBRE DE SERVICIO"
                sql = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where DET_SERV  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where DET_SERV  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where DET_SERV  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()
        End Select


    End Sub
    Private Sub FILTRO_RQ()
        Select Case ComboBox1.Text
            Case "CODIGO RQ"
                sql = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where COD  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where COD  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where COD  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "CODIGO SCC"
                sql = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where SEDE  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where SEDE  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where SEDE  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

            Case "CODGIO CC"
                sql = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where CEN_COST  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where CEN_COST  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where CEN_COST  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()
            Case "ORDEN DE SERVICIO"
                sql = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where SUB_CC_OS  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where SUB_CC_OS  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where SUB_CC_OS  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()
            Case "NOMBRE DE SERVICIO"
                sql = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where SERVICIO  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where SERVICIO  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO RQ], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CODIGO SCC], CEN_COST AS [CODIGO CC ], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO where SERVICIO  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()
        End Select


    End Sub
    Sub SCC_BUS()
        Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "select *from T_SUB_C_COS_OS where  cod='" + selec + "'"
        Form_Reg_SRV_SQL.conectar()
        com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            Form_Orden_Compra.TextBox8.Text = dr(0)
            Form_Orden_Compra.TextBox7.Text = dr(1)
            Form_Orden_Compra.TextBox1.Text = "OC SIN RQ"
        End If
        dr.Close()
        Form_Reg_SRV_SQL.conexion.Close()
        'Form_Cotizacion.llenar_PRO_COTI_SCCO()
        'Form_Reg_SCCOS.CALCULAR_MONTO_VENTA()
        'Form_Cotizacion.llenar_PRO_OC()
        'Form_Cotizacion.ListView1.Visible = False
        'Form_Cotizacion.DataGridView1.Visible = True
        'Form_Cotizacion.GroupBox5.Enabled = True
        'Form_Cotizacion.Button13.Enabled = True
        'Form_Cotizacion.Button9.Enabled = False
        'Form_Cotizacion.Button11.Enabled = False
        'Form_Cotizacion.Button12.Enabled = False
        Me.Close()
    End Sub
    Private Sub llenar_grid_OC()
        Try
            sql = "select COD AS [CODIGO OC], FEC_REG_OC AS [FECHA DE REGISTRO OC] , RUC_PRO AS [RUC DE PROVEEDOR],RAZ_SOCIAL AS [RAZON SOCIAL], DIRECC AS [DIRECCION], TELF AS [TELEFONO], MOT_COMP AS [MOTIVO DE COMPRA], FEC_VEN_PAGO AS [FECHA DE VENCIMIENTO OC], COD_RQ,COD_CC,COD_SCC,OBS,T_VENTA AS [TIPO DE VENTA],F_PAGO AS [FORMA DE PAGO],MONEDA from T_ORDEN_COMPRA"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_ORDEN_COMPRA")
            dgv.DataSource = ds
            dgv.DataMember = "T_ORDEN_COMPRA"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try
    End Sub
    Private Sub llenar_grid_FAC_OC()
        Try
            sql = "select COD AS [CODIGO], COD_OC AS [CODIGO OC] , N_FAC AS [NUMERO DE FACTURA],FEC_FAC AS [FECHA DE FACTURA], FEC_PAGO AS [FECHA DE PAGO], MONT_FACT AS [MONTO DE FACTURA], MONT_PAGO AS [MONTO DE PAGO], POR_PA_OC AS [% PAGO OC], MONEDA,ESTADO,FEC_ING AS [FECHA DE INGRESO FACTURA] from T_FAC_OC"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_FAC_OC")
            dgv.DataSource = ds
            dgv.DataMember = "T_FAC_OC"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try
    End Sub

    Public Sub color_dgv()

        For Each Row As DataGridViewRow In dgv.Rows
            Select Case ComboBox2.Text
                Case "REQUERIMIENTOS"
                    Select Case Row.Cells("FECHA DE REGISTRO").Value
                        Case = Today
                            Row.DefaultCellStyle.BackColor = Color.Blue
                            Row.DefaultCellStyle.ForeColor = Color.White
                        Case < Today
                            Row.DefaultCellStyle.BackColor = Color.Red
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select

                Case "ORDENES DE COMPRAS"
                    Select Case Row.Cells("FECHA DE VENCIMIENTO OC").Value
                        Case = Today
                            Row.DefaultCellStyle.BackColor = Color.Blue
                            Row.DefaultCellStyle.ForeColor = Color.White
                        Case < Today
                            Row.DefaultCellStyle.BackColor = Color.Red
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select

                Case "FACTURAS PROVEEDORES"

                    Select Case Row.Cells("FECHA DE PAGO").Value
                        Case = Today
                            Row.DefaultCellStyle.BackColor = Color.Blue
                            Row.DefaultCellStyle.ForeColor = Color.White
                        Case < Today
                            Row.DefaultCellStyle.BackColor = Color.Red
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select

                Case "SUB CENTRO DE COSTOS"
                    Select Case Row.Cells("ESTADO").Value
                        Case = "ACTIVO"
                            Row.DefaultCellStyle.BackColor = Color.Blue
                            Row.DefaultCellStyle.ForeColor = Color.White
                        Case = "CERRADO"
                            Row.DefaultCellStyle.BackColor = Color.Red
                            Row.DefaultCellStyle.ForeColor = Color.White
                    End Select
                    ' Case ""
                    'If Row.Cells("FECHA DE ADELANTO Y MORA").Value > Row.Cells("FECHA DE VENCIMIENTO").Value Then
                    '  Row.DefaultCellStyle.BackColor = Color.Red
                    'Row.DefaultCellStyle.ForeColor = Color.White
                    ' Else
                    'If Row.Cells("ESTADO").Value = "VIGENTE" Then
                    'Row.DefaultCellStyle.BackColor = Color.Blue
                    'Row.DefaultCellStyle.ForeColor = Color.White
                    'Else
                    'If Row.Cells("FECHA DE VENCIMIENTO").Value < Today Then
                    'Row.DefaultCellStyle.BackColor = Color.Maroon
                    'Row.DefaultCellStyle.ForeColor = Color.White
                    'Else
                    'If Row.Cells("FECHA DE VENCIMIENTO").Value >= Today Then
                    'Row.DefaultCellStyle.BackColor = Color.OliveDrab
                    'Row.DefaultCellStyle.ForeColor = Color.Black
                    'End If
                    'End If
                    ' End If
                    'End If

            End Select


            'If Today = Row.Cells("FECHA INICIO DE PRESTAMO").Value Then
            'Row.DefaultCellStyle.BackColor = Color.Blue
            'Row.DefaultCellStyle.ForeColor = Color.White
            'End If


        Next

    End Sub
    Private Sub llenar_grid_REQUERIMIENTO()
        Try
            sql = "select COD AS [CODIGO], CLASIFIC AS [CLASIFICACION] , SERVICIO AS [TIPO DE SERVICIO],SEDE AS [CENTRO DE COSTO], CEN_COST AS [CENTRO DE COSTO], SUB_CC_OS AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTRO], PRIORI AS [PRIORIDAD], DETA_GEN_USU AS [DETALLE CREACION],DETA_REV_USU AS [DETALLE DE REVION],ESTADO from T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_REQUERIMIENTO")
            dgv.DataSource = ds
            dgv.DataMember = "T_REQUERIMIENTO"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub
End Class