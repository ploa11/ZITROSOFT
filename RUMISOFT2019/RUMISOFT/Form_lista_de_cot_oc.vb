Imports System.Diagnostics.Eventing.Reader
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Public Class Form1
    'variables publicas
    Public pase1, pase2, pase3, pase4, nct, busq, COD_COTI_SSC As String

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
    Public RQ_SCC As String
    'Public RQ_SCC As String
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'If RQ_SCC = "BUSCAR OC" Then
        ' FILTRO_SCC()
        'coloini()
        ' Else
        'FILTRO_RQ()

        '
        ' End If
        Select Case RQ_SCC
            Case "BUSCAR OC"
                FILTRO_SCC()
                'coloini()
            Case "BUSCAR COTI"
                FILTRO_LOCAL()
            Case "LOCAL"
                FILTRO_RQ()
            Case "BUSCAR FAC"
                FILTRO_FACT()

        End Select
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Public Sub llenar_grid_LOGISTICA()
        Try
            sql = "select COD AS [CODIGO], FEC_REG_COTI AS [FECHA REGSITRO COTI] , RUC_CLIE AS [RUC DE CLIENTE], RAZ_SOC_CLIE AS [RAZON SOCIAL], DIREC AS [DIRECCION], NOM_CONT_CLIE AS [NOMBRE CONTACTO], APE_CONT_CLIE AS [APELLIDO CONTACTO], MAIL AS [CORREO CONTACTO],NOM_US_SIS AS [NOMBRE USUARIO],APE_US_SIS AS [APELLIDO USUARIO], CARGO AS [CARGO],MOTIVO AS [MOTIVO], JUST_SELEC_CLIE AS [JUST CLIENTE],FEC_VENC_COTI AS [FECHA DE VENCIMIENTO] from T_COTIZACION"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_COTIZACION")
            dgv.DataSource = ds
            dgv.DataMember = "T_COTIZACION"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub

    Public Sub llenar_grid_LOGISTICA_SCC()
        Try
            sql = "select COD AS [CODIGO], FEC_REG_COTI AS [FECHA REGSITRO COTI] , RUC_CLIE AS [RUC DE CLIENTE], RAZ_SOC_CLIE AS [RAZON SOCIAL], DIREC AS [DIRECCION], NOM_CONT_CLIE AS [NOMBRE CONTACTO], APE_CONT_CLIE AS [APELLIDO CONTACTO], MAIL AS [CORREO CONTACTO],NOM_US_SIS AS [NOMBRE USUARIO],APE_US_SIS AS [APELLIDO USUARIO], CARGO AS [CARGO],MOTIVO AS [MOTIVO], JUST_SELEC_CLIE AS [JUST CLIENTE],FEC_VENC_COTI AS [FECHA DE VENCIMIENTO] from T_COTIZACION"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_COTIZACION")
            dgv.DataSource = ds
            dgv.DataMember = "T_COTIZACION"
            Form_Reg_SRV_SQL.conexion.Close()
            'Form_Reg_SCCOS.DataGridView1.DataSource = ds
            'Form_Reg_SCCOS.DataGridView1.DataMember = "T_COTIZACION"
            'Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos", "ZITRO")
        End Try

    End Sub
    Public Sub llenar_grid_SISTEMAS()
        Try
            sql = "select COD AS [CODIGO], FEC_REG_OC AS [FECHA REGSITRO OC] , RUC_PRO AS [RUC DE PROVEEDOR],RAZ_SOCIAL AS [RAZON SOCIAL], DIRECC AS [DIRECCION], TELF AS [TELEFONO], FEC_VEN_PAGO AS [FECHA DE VENCIMIENTO], COD_RQ AS [CODIGO QR], COD_CC AS [CODIGO CENTRO DE COSTO], COD_SCC AS [CODIGO CENTRO DE COSTO] from T_ORDEN_COMPRA "
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
    Public Sub LLENAR_FAC_OC()
        Try
            sql = "select COD AS [CODIGO], COD_OC AS [CODIGO OC] , N_FAC AS [NUMERO DE FACTURA],FEC_FAC AS [FECHA DE FACTURA],FEC_PAGO AS [FECHA DE PAGO FACTURA], MONT_FACT AS [MONTO DE FACTURA], MONT_PAGO AS [MONTO DE PAGO FACTURA], POR_PA_OC AS [% DE FACTURA], MONEDA, ESTADO, FEC_ING AS [FECHA INGRESO FACTURA]  from T_FAC_OC "
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub llenar_grid_SUPER_COSTO_PROYECTO()
        Try
            sql = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS WHERE ESTADO='ACTIVO'"
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
    Public Sub llenar_grid_LOCAL()
        Try
            sql = "select COD_LOCAL AS [CODIGO], TIENDA AS [LOCAL], UBICACION1 AS [UBICACION 1], UBICACION2 AS [UBICACION 2], UBICACION3 AS [UBICACION 3], DIRECCION AS [DIRECCION] from T_LOCAL"
            Form_Reg_SRV_SQL.conectar()
            da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
            cb = New SqlClient.SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "T_LOCAL")
            dgv.DataSource = ds
            dgv.DataMember = "T_LOCAL"
            Form_Reg_SRV_SQL.conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar los datos LOCAL", "ZITRO")
        End Try

    End Sub

    Private Sub FILTRO_SCC()
        Select Case ComboBox1.Text
            Case "CODIGO OC"
                ' sql = "select  COD AS [CODIGO SUB CENTRO DE COSTO], COD_CEN_COST AS [CODIGO CENTRO DE COSTO], ORD_SERV AS [ORDEN DE SERVICIO], FEC_REG AS [FECHA DE REGISTO], DET_SERV AS [DETALLE DE SERVICIO], MONTO AS [PRECIO DE VENTA], MONTO_REAL AS [PRECIO DE COSTO], MONTO_REAL_MAT AS [GASTOS DE MATERIALES], MONTO_REAL_EQP AS [GASTO DE EQUIPAMENTO], MONTO_REAL_GASTGEN AS [GASTO GENERALES], UTILIDAD, FEC_ACTUAL AS [FECHA DE INICIO], ESTADO, DIAS_PROYECTO from T_SUB_C_COS_OS where COD  like'" + TextBox1.Text + "%'"
                sql = "select COD AS [CODIGO], FEC_REG_OC AS [FECHA REGSITRO OC] , RUC_PRO AS [RUC DE PROVEEDOR],RAZ_SOCIAL AS [RAZON SOCIAL], DIRECC AS [DIRECCION], TELF AS [TELEFONO], FEC_VEN_PAGO AS [FECHA DE VENCIMIENTO], COD_RQ AS [CODIGO QR], COD_CC AS [CODIGO CENTRO DE COSTO], COD_SCC AS [CODIGO CENTRO DE COSTO] from T_ORDEN_COMPRA where COD  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO], FEC_REG_OC AS [FECHA REGSITRO OC] , RUC_PRO AS [RUC DE PROVEEDOR],RAZ_SOCIAL AS [RAZON SOCIAL], DIRECC AS [DIRECCION], TELF AS [TELEFONO], FEC_VEN_PAGO AS [FECHA DE VENCIMIENTO], COD_RQ AS [CODIGO QR], COD_CC AS [CODIGO CENTRO DE COSTO], COD_SCC AS [CODIGO CENTRO DE COSTO] from T_ORDEN_COMPRA where COD  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO], FEC_REG_OC AS [FECHA REGSITRO OC] , RUC_PRO AS [RUC DE PROVEEDOR],RAZ_SOCIAL AS [RAZON SOCIAL], DIRECC AS [DIRECCION], TELF AS [TELEFONO], FEC_VEN_PAGO AS [FECHA DE VENCIMIENTO], COD_RQ AS [CODIGO QR], COD_CC AS [CODIGO CENTRO DE COSTO], COD_SCC AS [CODIGO CENTRO DE COSTO] from T_ORDEN_COMPRA where COD  like'" + TextBox1.Text + "%'"
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
            Case "CODIGO COTI"
                sql = "select COD AS [CODIGO], FEC_REG_COTI AS [FECHA REGSITRO COTI] , RUC_CLIE AS [RUC DE CLIENTE], RAZ_SOC_CLIE AS [RAZON SOCIAL], DIREC AS [DIRECCION], NOM_CONT_CLIE AS [NOMBRE CONTACTO], APE_CONT_CLIE AS [APELLIDO CONTACTO], MAIL AS [CORREO CONTACTO],NOM_US_SIS AS [NOMBRE USUARIO],APE_US_SIS AS [APELLIDO USUARIO], CARGO AS [CARGO],MOTIVO AS [MOTIVO], JUST_SELEC_CLIE AS [JUST CLIENTE],FEC_VENC_COTI AS [FECHA DE VENCIMIENTO] from T_COTIZACION where COD  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO], FEC_REG_COTI AS [FECHA REGSITRO COTI] , RUC_CLIE AS [RUC DE CLIENTE], RAZ_SOC_CLIE AS [RAZON SOCIAL], DIREC AS [DIRECCION], NOM_CONT_CLIE AS [NOMBRE CONTACTO], APE_CONT_CLIE AS [APELLIDO CONTACTO], MAIL AS [CORREO CONTACTO],NOM_US_SIS AS [NOMBRE USUARIO],APE_US_SIS AS [APELLIDO USUARIO], CARGO AS [CARGO],MOTIVO AS [MOTIVO], JUST_SELEC_CLIE AS [JUST CLIENTE],FEC_VENC_COTI AS [FECHA DE VENCIMIENTO] from T_COTIZACION where COD  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO], FEC_REG_COTI AS [FECHA REGSITRO COTI] , RUC_CLIE AS [RUC DE CLIENTE], RAZ_SOC_CLIE AS [RAZON SOCIAL], DIREC AS [DIRECCION], NOM_CONT_CLIE AS [NOMBRE CONTACTO], APE_CONT_CLIE AS [APELLIDO CONTACTO], MAIL AS [CORREO CONTACTO],NOM_US_SIS AS [NOMBRE USUARIO],APE_US_SIS AS [APELLIDO USUARIO], CARGO AS [CARGO],MOTIVO AS [MOTIVO], JUST_SELEC_CLIE AS [JUST CLIENTE],FEC_VENC_COTI AS [FECHA DE VENCIMIENTO] from T_COTIZACION where COD  like'" + TextBox1.Text + "%'"
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
            Case "LOCAL"
                sql = "SELECT COD_LOCAL AS [CODIGO], TIENDA AS [LOCAL], UBICACION1 AS [UBICACION 1], UBICACION2 AS [UBICACION 2], UBICACION3 AS [UBICACION 3], DIRECCION AS [DIRECCION] from T_LOCAL where TIENDA  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "SELECT COD_LOCAL AS [CODIGO], TIENDA AS [LOCAL], UBICACION1 AS [UBICACION 1], UBICACION2 AS [UBICACION 2], UBICACION3 AS [UBICACION 3], DIRECCION AS [DIRECCION] from T_LOCAL where TIENDA  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "SELECT COD_LOCAL AS [CODIGO], TIENDA AS [LOCAL], UBICACION1 AS [UBICACION 1], UBICACION2 AS [UBICACION 2], UBICACION3 AS [UBICACION 3], DIRECCION AS [DIRECCION] from T_LOCAL where TIENDA  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()

        End Select


    End Sub
    Private Sub FILTRO_FACT()
        Select Case ComboBox1.Text
            Case "CODIGO FACTURA"
                sql = "select COD AS [CODIGO], COD_OC AS [CODIGO OC] ,N_FAC AS [NUMERO DE FACTURA], FEC_FAC AS [FECHA DE FACTURA], FEC_PAGO AS [FECHA DE PAGO], MONT_FACT AS [MONTO DE FACTURA], MONT_PAGO AS [MONTO DE PAGO], POR_PA_OC AS [% DE FACTURA],MONEDA,ESTADO, FEC_ING AS [FECHA INGRESO FACTURA]  from T_FAC_OC where COD  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO], COD_OC AS [CODIGO OC] ,N_FAC AS [NUMERO DE FACTURA], FEC_FAC AS [FECHA DE FACTURA], FEC_PAGO AS [FECHA DE PAGO], MONT_FACT AS [MONTO DE FACTURA], MONT_PAGO AS [MONTO DE PAGO], POR_PA_OC AS [% DE FACTURA],MONEDA,ESTADO,FEC_ING AS [FECHA INGRESO FACTURA]  from T_FAC_OC where COD  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO], COD_OC AS [CODIGO OC] ,N_FAC AS [NUMERO DE FACTURA], FEC_FAC AS [FECHA DE FACTURA], FEC_PAGO AS [FECHA DE PAGO], MONT_FACT AS [MONTO DE FACTURA], MONT_PAGO AS [MONTO DE PAGO], POR_PA_OC AS [% DE FACTURA],MONEDA,ESTADO,FEC_ING AS [FECHA INGRESO FACTURA]  from T_FAC_OC where COD  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()
            Case "N FACTURA"
                sql = "select COD AS [CODIGO], COD_OC AS [CODIGO OC] ,N_FAC AS [NUMERO DE FACTURA], FEC_FAC AS [FECHA DE FACTURA], FEC_PAGO AS [FECHA DE PAGO], MONT_FACT AS [MONTO DE FACTURA], MONT_PAGO AS [MONTO DE PAGO], POR_PA_OC AS [% DE FACTURA],MONEDA,ESTADO,FEC_ING AS [FECHA INGRESO FACTURA]  from T_FAC_OC where N_FAC  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO], COD_OC AS [CODIGO OC] ,N_FAC AS [NUMERO DE FACTURA], FEC_FAC AS [FECHA DE FACTURA], FEC_PAGO AS [FECHA DE PAGO], MONT_FACT AS [MONTO DE FACTURA], MONT_PAGO AS [MONTO DE PAGO], POR_PA_OC AS [% DE FACTURA],MONEDA,ESTADO,FEC_ING AS [FECHA INGRESO FACTURA]  from T_FAC_OC where N_FAC  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO], COD_OC AS [CODIGO OC] ,N_FAC AS [NUMERO DE FACTURA], FEC_FAC AS [FECHA DE FACTURA], FEC_PAGO AS [FECHA DE PAGO], MONT_FACT AS [MONTO DE FACTURA], MONT_PAGO AS [MONTO DE PAGO], POR_PA_OC AS [% DE FACTURA],MONEDA,ESTADO,FEC_ING AS [FECHA INGRESO FACTURA]  from T_FAC_OC where N_FAC  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()


        End Select


    End Sub
    Private Sub FILTRO_LOCAL()
        Select Case ComboBox1.Text
            Case "CODIGO COTI"
                sql = "select COD AS [CODIGO], FEC_REG_COTI AS [FECHA REGSITRO COTI] , RUC_CLIE AS [RUC DE CLIENTE], RAZ_SOC_CLIE AS [RAZON SOCIAL], DIREC AS [DIRECCION], NOM_CONT_CLIE AS [NOMBRE CONTACTO], APE_CONT_CLIE AS [APELLIDO CONTACTO], MAIL AS [CORREO CONTACTO],NOM_US_SIS AS [NOMBRE USUARIO],APE_US_SIS AS [APELLIDO USUARIO], CARGO AS [CARGO],MOTIVO AS [MOTIVO], JUST_SELEC_CLIE AS [JUST CLIENTE],FEC_VENC_COTI AS [FECHA DE VENCIMIENTO] from T_COTIZACION where COD  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD AS [CODIGO], FEC_REG_COTI AS [FECHA REGSITRO COTI] , RUC_CLIE AS [RUC DE CLIENTE], RAZ_SOC_CLIE AS [RAZON SOCIAL], DIREC AS [DIRECCION], NOM_CONT_CLIE AS [NOMBRE CONTACTO], APE_CONT_CLIE AS [APELLIDO CONTACTO], MAIL AS [CORREO CONTACTO],NOM_US_SIS AS [NOMBRE USUARIO],APE_US_SIS AS [APELLIDO USUARIO], CARGO AS [CARGO],MOTIVO AS [MOTIVO], JUST_SELEC_CLIE AS [JUST CLIENTE],FEC_VENC_COTI AS [FECHA DE VENCIMIENTO] from T_COTIZACION where COD  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD AS [CODIGO], FEC_REG_COTI AS [FECHA REGSITRO COTI] , RUC_CLIE AS [RUC DE CLIENTE], RAZ_SOC_CLIE AS [RAZON SOCIAL], DIREC AS [DIRECCION], NOM_CONT_CLIE AS [NOMBRE CONTACTO], APE_CONT_CLIE AS [APELLIDO CONTACTO], MAIL AS [CORREO CONTACTO],NOM_US_SIS AS [NOMBRE USUARIO],APE_US_SIS AS [APELLIDO USUARIO], CARGO AS [CARGO],MOTIVO AS [MOTIVO], JUST_SELEC_CLIE AS [JUST CLIENTE],FEC_VENC_COTI AS [FECHA DE VENCIMIENTO] from T_COTIZACION where COD  like'" + TextBox1.Text + "%'"
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
            Case "LOCAL"
                sql = "select COD_LOCAL AS [CODIGO], TIENDA AS [LOCAL]¨, UBICACION1 AS [UBICACION 1] , UBICACION2 AS [UBICACION 2], UBICACION3 AS [UBICACION 3], CEN_COST AS [CODIGO CC ], DIRECCION AS [DIRECCION] from T_LOCAL where TIENDA like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conectar()
                da = New SqlClient.SqlDataAdapter(sql, Form_Reg_SRV_SQL.conexion)
                cb = New SqlClient.SqlCommandBuilder(da)
                ds = New DataSet
                da.Fill(ds, "select COD_LOCAL AS [CODIGO], TIENDA AS [LOCAL]¨, UBICACION1 AS [UBICACION 1] , UBICACION2 AS [UBICACION 2], UBICACION3 AS [UBICACION 3], CEN_COST AS [CODIGO CC ], DIRECCION AS [DIRECCION] from T_LOCAL where TIENDA  like'" + TextBox1.Text + "%'")
                dgv.DataSource = ds
                dgv.DataMember = "select COD_LOCAL AS [CODIGO], TIENDA AS [LOCAL]¨, UBICACION1 AS [UBICACION 1] , UBICACION2 AS [UBICACION 2], UBICACION3 AS [UBICACION 3], CEN_COST AS [CODIGO CC ], DIRECCION AS [DIRECCION] from T_LOCAL where TIENDA  like'" + TextBox1.Text + "%'"
                Form_Reg_SRV_SQL.conexion.Close()
        End Select


    End Sub

    Private Sub dgv_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentDoubleClick
        Try
            Select Case pase1
                Case "OC"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_ORDEN_COMPRA where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Orden_Compra.TextBox23.Text = dr(0)
                        Form_Orden_Compra.TextBox2.Text = dr(2)
                        Form_Orden_Compra.DateTimePicker1.Value = dr(1)
                        Form_Orden_Compra.TextBox3.Text = dr(3)
                        Form_Orden_Compra.TextBox4.Text = dr(4)
                        Form_Orden_Compra.TextBox5.Text = dr(5)
                        Form_Orden_Compra.DateTimePicker2.Value = dr(14)
                        Form_Orden_Compra.TextBox6.Text = dr(6)
                        Form_Orden_Compra.TextBox9.Text = dr(7)
                        Form_Orden_Compra.TextBox10.Text = dr(8)
                        Form_Orden_Compra.TextBox13.Text = dr(9)
                        Form_Orden_Compra.TextBox12.Text = dr(10)
                        Form_Orden_Compra.TextBox11.Text = dr(11)
                        Form_Orden_Compra.TextBox17.Text = dr(12)
                        Form_Orden_Compra.ComboBox2.Text = dr(13)
                        Form_Orden_Compra.TextBox1.Text = dr(15)
                        Form_Orden_Compra.TextBox7.Text = dr(16)
                        Form_Orden_Compra.TextBox8.Text = dr(17)
                        Form_Orden_Compra.TextBox25.Text = dr(19)
                        Form_Orden_Compra.ComboBox1.Text = dr(20)
                        Form_Orden_Compra.ComboBox3.Text = dr(21)
                        Form_Orden_Compra.moneda = dr(22)

                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Form_Orden_Compra.llenar_PRO()
                    Form_Orden_Compra.llenar_PRO_OC()
                    If Form_Orden_Compra.moneda = "DOLARES" Then
                        Form_Orden_Compra.CheckBox2.Checked = True
                    Else
                        Form_Orden_Compra.CheckBox2.Checked = False

                    End If
                    Form_Orden_Compra.ListView1.Visible = False
                    Form_Orden_Compra.DataGridView1.Visible = True
                    Form_Orden_Compra.GroupBox5.Enabled = True
                    Form_Orden_Compra.Button13.Enabled = True
                    Form_Orden_Compra.Button9.Enabled = False
                    Form_Orden_Compra.Button11.Enabled = False
                    Form_Orden_Compra.Button12.Enabled = False
                    Form_Orden_Compra.totales()
                    Me.Close()
                Case "OC_PAGO"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_ORDEN_COMPRA where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Prog_Pagos.TextBox1.Text = dr(0)
                        Form_Prog_Pagos.TextBox2.Text = dr(3)
                        Form_Prog_Pagos.TextBox3.Text = dr(2)
                        Form_Prog_Pagos.TextBox5.Text = dr(4)
                        Form_Prog_Pagos.TextBox6.Text = dr(6) + " " + dr(7)
                        Form_Prog_Pagos.TextBox4.Text = dr(5)
                        Form_Prog_Pagos.TextBox9.Text = dr(15)
                        Form_Prog_Pagos.TextBox10.Text = dr(16)
                        Form_Prog_Pagos.TextBox11.Text = dr(17)
                        Form_Prog_Pagos.TextBox12.Text = dr(19)
                        Form_Prog_Pagos.TextBox13.Text = dr(20)
                        Form_Prog_Pagos.TextBox14.Text = dr(21)
                        Form_Prog_Pagos.TextBox15.Text = dr(22)
                        Form_Prog_Pagos.DateTimePicker2.Value = dr(1)
                        Form_Prog_Pagos.DateTimePicker5.Value = dr(14)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    'Form_Orden_Compra.llenar_PRO()
                    'Form_Orden_Compra.llenar_PRO_OC()

                    Me.Close()
                Case "COTI"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_COTIZACION where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Cotizacion.TextBox23.Text = dr(0)
                        Form_Cotizacion.TextBox2.Text = dr(2)
                        Form_Cotizacion.DateTimePicker1.Value = dr(1)
                        Form_Cotizacion.TextBox3.Text = dr(3)
                        Form_Cotizacion.TextBox4.Text = dr(4)

                        Form_Cotizacion.TextBox1.Text = dr(5)






                        Form_Cotizacion.DateTimePicker2.Value = dr(13)
                        'Form_Cotizacion.TextBox6.Text = dr(6)
                        Form_Cotizacion.TextBox9.Text = dr(6)
                        Form_Cotizacion.TextBox10.Text = dr(7)
                        Form_Cotizacion.TextBox13.Text = dr(8)
                        Form_Cotizacion.TextBox12.Text = dr(9)
                        Form_Cotizacion.TextBox11.Text = dr(10)
                        Form_Cotizacion.TextBox17.Text = dr(11)
                        Form_Cotizacion.ComboBox2.Text = dr(12)
                        Form_Cotizacion.TextBox5.Text = dr(18)
                        Form_Cotizacion.TextBox24.Text = dr(15)
                        Form_Cotizacion.TextBox8.Text = dr(16)
                        Form_Cotizacion.TextBox7.Text = dr(17)
                        Form_Cotizacion.TextBox5.Text = dr(18)
                        Form_Cotizacion.moneda = dr(19)

                        'Form_Cotizacion.TextBox1.Text = dr(15)
                        ' Form_Cotizacion.TextBox7.Text = dr(16)
                        ' Form_Cotizacion.TextBox8.Text = dr(17)

                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    If Form_Cotizacion.moneda = "DOLARES" Then
                        Form_Cotizacion.CheckBox2.Checked = True
                    Else
                        Form_Cotizacion.CheckBox2.Checked = False
                    End If
                    Form_Cotizacion.llenar_PRO_COTI()
                    Form_Cotizacion.TOTALES()
                    'Form_Cotizacion.llenar_PRO_OC()
                    Form_Cotizacion.ListView1.Visible = False
                    Form_Cotizacion.DataGridView1.Visible = True

                    'Form_Cotizacion.GroupBox5.Enabled = True
                    'Form_Cotizacion.Button13.Enabled = True
                    ' Form_Cotizacion.Button9.Enabled = False
                    ' Form_Cotizacion.Button11.Enabled = False
                    'Form_Cotizacion.Button12.Enabled = False
                    Me.Close()
                Case "FACTURA"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_FAC_OC where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Prog_Pagos.TextBox17.Text = dr(0)
                        'DateTimePicker1.Value = dr(1)
                        Form_Prog_Pagos.TextBox20.Text = dr(2)
                        Form_Prog_Pagos.DateTimePicker3.Value = dr(3)
                        Form_Prog_Pagos.DateTimePicker4.Value = dr(4)
                        Form_Prog_Pagos.TextBox19.Text = dr(5)
                        Form_Prog_Pagos.TextBox18.Text = dr(6)
                        Form_Prog_Pagos.TextBox7.Text = dr(7)
                        Form_Prog_Pagos.TextBox21.Text = dr(8)
                        Form_Prog_Pagos.ComboBox1.Text = dr(10)
                        Form_Prog_Pagos.DateTimePicker1.Value = dr(11)
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
                Case "LOCAL"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from T_LOCAL where  cod_LOCAL='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        'Form_Cotizacion.TextBox23.Text = dr(0)
                        Form_Cotizacion.TextBox24.Text = dr(1)
                        Dim UBI1 As String = dr(2)
                        Dim UBI2 As String = dr(3)
                        Dim UBI3 As String = dr(4)
                        Form_Cotizacion.TextBox8.Text = UBI1 + UBI2 + UBI3
                        Form_Cotizacion.TextBox7.Text = dr(5)


                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    'Form_Cotizacion.llenar_PRO_COTI()
                    'Form_Cotizacion.llenar_PRO_OC()
                    'Form_Cotizacion.ListView1.Visible = False
                    'Form_Cotizacion.DataGridView1.Visible = True
                    'Form_Cotizacion.GroupBox5.Enabled = True
                    'Form_Cotizacion.Button13.Enabled = True
                    'Form_Cotizacion.Button9.Enabled = False
                    'Form_Cotizacion.Button11.Enabled = False
                    'Form_Cotizacion.Button12.Enabled = False
                    Me.Close()
                Case "oc"
                    Dim selec As String = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
                    sql = "select *from usuarios where  cod='" + selec + "'"
                    Form_Reg_SRV_SQL.conectar()
                    com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                    dr = com.ExecuteReader
                    If dr.Read Then
                        Form_Orden_Compra.TextBox13.Text = dr(1)
                        Form_Orden_Compra.TextBox12.Text = dr(2)
                        Form_Orden_Compra.TextBox11.Text = dr(4)



                        ' Form_Reg_Cent_Costo.cod_sede = dr(0)
                    End If
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()
                    Me.Close()

            End Select
        Catch ex As Exception

        End Try

    End Sub
    Sub ELIMINAR_COTI()

    End Sub
    Sub ELIMINAR_ITEM_COTI()

    End Sub
End Class