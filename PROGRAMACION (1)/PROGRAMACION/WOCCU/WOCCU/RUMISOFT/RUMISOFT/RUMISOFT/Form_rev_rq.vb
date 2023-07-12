Public Class Form_rev_rq
    'variables publicas
    Public pase1, pase2, pase3, pase4 As String

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
    Private Sub Form_rev_rq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        SELECCION()
        coloini()
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
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
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
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
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
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

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
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
        End Try

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
            MessageBox.Show("Error al mostrar los datos", "RUMISOFT")
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
End Class