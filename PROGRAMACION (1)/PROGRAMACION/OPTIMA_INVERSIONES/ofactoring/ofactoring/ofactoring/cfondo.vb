Imports System.Data.SqlClient
Public Class cfondo
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
    'Public conexion As SqlClient.SqlConnection
    Public accion As String, nc As String, sql As String
    Dim res As Integer, tc As String, td As String, nd As String, ce As String
    Public usql, clasql, nomsql, nfon, str, str1, str2, str3, str4, str5, nro_cuotas As String
    Public fechadistri As Date
    'variable de fucniones  sql
    Dim fun1, fun2, fun3, fun4, fun5, fun6, fun7, fun8, fun9, fun10, fun11, fun12, fun13, fun14, fun15, fun16, fun17 As String

    'VARIABLE DE ALTA PROCEDURE SQL
    Dim alta1, alta2, alta3, alta4, alta5, alta6, alta7, alta8, alta9, alta10, alta11, alta12, alta13, alta14, alta15, alta16, alta17 As String

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
    End Sub

    Private Sub cb5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb5.SelectedIndexChanged

        'buscar_periodo_distri()
        Distrib_benef()


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
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

    'varibls de EDICION  PROCEDURE SQL
    Dim edit1, edit2, edit4, edit3, edit5, edit6, edit7, edit8, edit9, edit10, edit11, edit12, edit13, edit14, edit15, edit16, edit17, edit18, SUMA As String

    'VARIABLE DE BORRADO SQL
    Dim bor1, bor2, bor3, bor4, bor5, bor6, bor7, bor8, bor9, bor10, bor11, bor12, bor13, bor14, bor15, bor16, bor17 As String

    'varibale de ver procedure sql

    Dim ver1, ver2, ver3, ver4, ver5, ver6, ver7, ver8, ver9, ver10, ver11, ver12, ver13, ver14, ver15, ver16, ver17, ver18 As String

    'variable de vistas sql

    Dim vis1, vis2, vis3, vis4, vis5, vis6, vis7, vis8, vis9, vis10, vis11, vis12, vis13, vis14, vis15, vis16, vis17 As String

    'variables de fecha
    Public dia, mes, ano, dia2, mes2, ano2, dia3, mes3, ano3, dia4, mes4, ano4, fecha, fecha2, fecha3, fecha4 As String
    Public fo_dia, fo_mes, fo_dia2, fo_mes2, fo_dia3, fo_mes3, fo_dia4, fo_mes4 As String
    Public f_creacion, f_ins_sunat, f_ini_op, f_final_op As String
    '-------------------
    'variables de insercion alta
    Public m_minimo, m_maximo, cap_actual, v_cuo_nominal, v_cuo_act As String
    Public u_neg, n_ruc, gest, mon As String


    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        nc = dgv.Rows(dgv.CurrentRow.Index).Cells(0).Value
        sql = "exec ver_nfondo '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t1.Text = dr(1)
            cb1.Text = dr(2)
            cb2.Text = dr(3)
            t3.Text = dr(4)
            t4.Text = dr(5)
            t5.Text = dr(6)
            t6.Text = dr(7)
            t7.Text = dr(8)
            CB3.Text = dr(9)
            DTP1.Value = dr(10)
            DTP2.Value = dr(11)
            t8.Text = dr(12)
            DTP3.Text = dr(13)
            DTP4.Text = dr(14)
            t8.Text = dr(15)
            t9.Text = dr(17)
            cb5.Text = dr(18)
            dtp5.Value = dr(19)
            TextBox1.Text = dr(20)
        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub
    Private Sub buscar_copiar()
        sql = "select *from nfondo where id in (select max(id) from nfondo)"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t1.Text = dr(1)
            cb1.Text = dr(2)
            cb2.Text = dr(3)
            t3.Text = dr(4)
            t4.Text = dr(5)
            t5.Text = dr(6)
            t6.Text = dr(7)
            t7.Text = dr(8)
            CB3.Text = dr(9)
            DTP1.Value = dr(10)
            DTP2.Value = dr(11)
            t8.Text = dr(12)
            DTP3.Text = dr(13)
            DTP4.Text = dr(14)
            t8.Text = dr(15)
        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Public Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        dia = DTP1.Value.Date
        mes = DTP1.Value.Date
        ano = DTP1.Value.Year
        dia2 = DTP2.Value.Date
        mes2 = DTP2.Value.Date
        ano2 = DTP2.Value.Year
        dia3 = DTP3.Value.Date
        mes3 = DTP3.Value.Date
        ano3 = DTP3.Value.Year
        dia4 = DTP4.Value.Date
        mes4 = DTP4.Value.Date
        ano4 = DTP4.Value.Year
        'declaramos estraemos el dia y mes
        fo_dia = dia.Substring(0, dia.IndexOf("/"))
        fo_mes = mes.Substring(3, mes.IndexOf("/"))
        fo_dia2 = dia2.Substring(0, dia2.IndexOf("/"))
        fo_mes2 = mes2.Substring(3, mes2.IndexOf("/"))
        fo_dia3 = dia3.Substring(0, dia3.IndexOf("/"))
        fo_mes3 = mes3.Substring(3, mes3.IndexOf("/"))
        fo_dia4 = dia4.Substring(0, dia4.IndexOf("/"))
        fo_mes4 = mes4.Substring(3, mes4.IndexOf("/"))
        '-------------------------------------------------
        'd.Text = fo_dia
        'm.Text = fo_mes
        'a.Text = ano
        'd2.Text = fo_dia2
        'm2.Text = fo_mes2
        'a2.Text = ano2
        'd3.Text = fo_dia3
        'm3.Text = fo_mes3
        'a3.Text = ano3
        'd4.Text = fo_dia4
        'm4.Text = fo_mes4
        'a4.Text = ano4



        '-------------------------------------------------
        'concatenar la fecha
        'TextBox1.Text = a.Text + m.Text + d.Text
        'TextBox2.Text = a2.Text + m2.Text + d2.Text
        'TextBox3.Text = a3.Text + m3.Text + d3.Text
        'TextBox4.Text = a4.Text + m4.Text + d4.Text
        fecha = ano + fo_mes + fo_dia
        fecha2 = ano2 + fo_mes2 + fo_dia2
        fecha3 = ano3 + fo_mes3 + fo_dia3
        fecha4 = ano4 + fo_mes4 + fo_dia4
        '--------------------------------------------------
        'igualar variables de insercion

        nc = t2.Text
        nomsql = UCase(cb1.Text)
        nfon = UCase(t1.Text)
        mon = UCase(cb2.Text)
        m_minimo = t3.Text
        m_maximo = t4.Text
        cap_actual = t5.Text
        v_cuo_nominal = t6.Text
        v_cuo_act = t7.Text
        nro_cuotas = t9.Text
        u_neg = UCase(CB3.Text)
        f_creacion = fecha
        f_ins_sunat = fecha2
        n_ruc = t8.Text
        gest = cb4.Text
        f_ini_op = fecha3
        f_final_op = fecha4

        Dim FECH As String = dtp5.Value.ToString("yyyyMMdd")

        '-----------------------
        sql = "" 'variable sql
        If accion = "guardar" Then
            sql = "exec ver_nfondo'" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                MessageBox.Show("Los Datos ya Existen", "nfondo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dr.Close()
                conexion.conexion.Close()
            Else
                sql = "exec alta_nfondo '" + nfon + "','" + nomsql + "','" + mon + "','" + m_minimo + "','" + m_maximo + "','" + cap_actual + "','" + v_cuo_nominal + "','" + v_cuo_act + "','" + u_neg + "','" + f_creacion + "','" + f_ins_sunat + "','" + gest + "','" + f_ini_op + "','" + f_final_op + "','" + n_ruc + "','" + nro_cuotas + "','" + cb5.Text + "','" + FECH + "','" + TextBox1.Text + "'"
                conexion.conectar()
                com = New SqlClient.SqlCommand(sql, conexion.conexion)
                res = com.ExecuteNonQuery
                conexion.conexion.Close()
                MessageBox.Show("Registro Guardado")

            End If
        ElseIf accion = "editar" Then
            sql = "exec edita_nfondo'" + nc + "','" + nfon + "','" + nomsql + "','" + mon + "','" + m_minimo + "','" + m_maximo + "','" + cap_actual + "','" + v_cuo_nominal + "','" + v_cuo_act + "','" + u_neg + "','" + f_creacion + "','" + f_ins_sunat + "','" + gest + "','" + f_ini_op + "','" + f_final_op + "','" + n_ruc + "','" + nro_cuotas + "','" + cb5.Text + "','" + FECH + "','" + TextBox1.Text + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            conexion.conexion.Close()
            MessageBox.Show("Registro Modificado")

        End If
        buscar_copiar()
        llenar_grid()
        cb1.Enabled = False
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        t4.Enabled = False
        t5.Enabled = False
        t6.Enabled = False
        t7.Enabled = False
        t8.Enabled = False
        t9.Enabled = False
        cb1.Enabled = False
        cb2.Enabled = False
        CB3.Enabled = False
        cb4.Enabled = False
        DTP1.Enabled = False
        DTP2.Enabled = False
        DTP3.Enabled = False
        DTP4.Enabled = False

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim opcion As String
        nc = cb1.Text
        sql = "exec ver_servsql '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            nomsql = dr(1)
            usql = dr(2)
            clasql = dr(3)

        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
        opcion = InputBox("Ingrese Codigo de Fondo que se muestra en la ventana anterior")

        sql = "exec ver_nfondo '" + opcion + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t1.Text = dr(1)
            cb1.Text = dr(2)
        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()


        Dim myConn As SqlConnection = New SqlConnection("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=master")
        Dim myConn2 As SqlConnection = New SqlConnection("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=" & t2.Text)

        str = "use master"
        str1 = "create database " & t2.Text
        ' Dim myConn2 As SqlConnection = New SqlConnection("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=" & t2.Text)
        'str2 = "create database " & t2.Text & "On PRIMARY (
        'Name ='" & t2.Text & "_MDF',
        'FILENAME ='E:\" & t2.Text & "\" & t2.Text & ".MDF',
        'Size =15MB,
        'MAXSIZE =500MB,
        'FILEGROWTH =10MB
        '),(
        ' Name ='" & t2.Text & "_NDF',
        'FILENAME ='E:\" & t2.Text & "\" & t2.Text & ".NDF',
        'Size =15MB,
        ' MAXSIZE =UNLIMITED,
        'FILEGROWTH =10MB
        '  )
        'Log ON (
        'Name ='" & t2.Text & "_LDF',
        'FILENAME ='E:\" & t2.Text & "\" & t2.Text & ".LDF',
        'Size =15MB,
        'MAXSIZE =500MB,
        'FILEGROWTH =10%
        '  )
        ' GO "

        str3 = "use " & t2.Text
        str4 = "CREATE TABLE DATOS_FONDO(
	            COD_FONDO VARCHAR(10) NOT NULL,
	            --COD_BAN VARCHAR (10),
	            COD_DI VARCHAR (10),
	            N_FONDO VARCHAR (250)NOT NULL,
	            MONEDA VARCHAR (20)NOT NULL,
	            MONT_MINIMO DECIMAL(20,5) NOT NULL,
	            MONT_MAXIMO DECIMAL(20,5)NOT NULL,
	            CAPITAL_ACTUAL DECIMAL (20,5), --CAMPO CALCULADO DEL INGRESO DE PARTICIPES
	            UNIDAD_NEGOCIO VARCHAR (100),
	            F_CREACION DATE NOT NULL,
	            F_INS_SUNAT DATE NOT NULL,
	            NU_RUC varchar(20) NOT NULL,
	            F_INI_OPERA DATE NOT NULL,
	            F_TER_OPERA DATE NOT NULL,
	            VALOR_CUOTA_NOM DECIMAL (10,5) NOT NULL,
	            VALOR_CUOTA_ACTUAL DECIMAL(10,5)NOT NULL,
	            COD_GEST varchar (10),
	            FECHA date not null,
	            id int identity(1,1) not null,
	            patrimonio decimal(30,5)
            )

            CREATE TABLE DIST_BENEFICIO (
	            COD_DI VARCHAR (10) NOT NULL PRIMARY KEY ,
	            DISTRIBUCION VARCHAR (50),
	            N_DISTRIB INTEGER,
	            COD_GEST VARCHAR (10),
	            id int identity(1,1) not null,
	            n_dias integer
            )

           CREATE TABLE SEG_DISTRI_BEN (
		            COD_DIS VARCHAR (10) NOT NULL PRIMARY KEY,
		            COD_DI VARCHAR (10) NOT NULL,
		            F_ENTREGA DATE,
		            F_ACTUAL DATE,
		            AVISO VARCHAR,
		            COD_GEST VARCHAR (10),
		            id int identity(1,1) not null
            )

            CREATE TABLE GAST_CAP_PARTI (
	            COD_GCPARTI VARCHAR (10) NOT NULL PRIMARY KEY,
	            FECHA DATE NOT NULL,
	            DETALLE VARCHAR (100) ,
	            MONTO DECIMAL (10,5) NOT NULL,
	            DIAS INTEGER NOT NULL,
	            COD_GEST VARCHAR (10),
	            id int identity(1,1) not null
            )

            CREATE  TABLE GAST_POR_CAP_CLIE (
	            COD_GCACLIE VARCHAR (10) NOT NULL PRIMARY KEY,
	            F_GAS_CAP_CLIE DATE,
	            DETALLE VARCHAR (200),
	            MONTO DECIMAL (10,5),
	            DIAS INTEGER,
	            COD_GEST VARCHAR (10),
	            id int identity(1,1) not null
            )

            CREATE TABLE GAST_POR_INVES_MERC (
	            COD_GINVMER VARCHAR (10) NOT NULL PRIMARY KEY,
	            FECHA DATE,
	            DETALLE VARCHAR (200),
	            MONTO DECIMAL (10,5),
	            DIAS INTEGER,
	            COD_GEST VARCHAR (10),
	            id int identity(1,1) not null
            )

            CREATE TABLE GAST_ADM_FONDO (
	            COD_GAS_ADM VARCHAR (10) NOT NULL PRIMARY KEY,
	            F_GASTO DATE,
	            DETALLE VARCHAR (200),
	            MONTO DECIMAL (10,5),
	            PROCENT INTEGER,
	            DIAS INTEGER,
	            COD_GEST VARCHAR (10),
	            id int identity(1,1) not null
            )

            CREATE TABLE GAST_BANC (
		            COD_GBANC VARCHAR (10) NOT NULL PRIMARY KEY,
		            FECHA DATE,
		            DETALLE VARCHAR (200),
		            MONTO DECIMAL (10,5),
		            DIAS INTEGER,
		            COD_GEST VARCHAR (10),
		            id int identity(1,1) not null
            )

            CREATE TABLE OTROS_GASTOS (
	            COD_OGAS VARCHAR (10) NOT NULL PRIMARY KEY,
	            FECHA DATE,
	            DETALLE VARCHAR (200),
	            MONTO DECIMAL (10,5),
	            DIAS INTEGER,
	            COD_GEST VARCHAR (10),
	            id int identity(1,1) not null

            )

            create table gestion (
            cod_gest varchar (10) not null primary key,
            a_gestion varchar(10),
            id int identity(1,1) not null,
            apertura date
            )

            create table datos_cuenta (
            cod_cuenta varchar (10) not null primary key,
            cod_ban varchar (10) not null,
            tipo_cuenta varchar (10),
            n_cuenta varchar (100),
            n_cci varchar (100),
            mon_cuenta varchar (10),
            cod_parti varchar (10) ,
            cod_clie varchar (10),
            cod_provee varchar(10),
            cod_fondo varchar(10),
            nom_parti varchar (256),
            nom_clie varchar (256),
            nom_proveedor varchar (256),
            nom_fondo varchar (256),
            cod_manc varchar (10),
            nom_manc varchar (256),
            id int identity(1,1) not null
            )

            create table reg_banco(
            cod_ban varchar (10) not null primary key,
            n_banco varchar (100),
            ruc varchar(20),
            id int identity(1,1) not null
            )

            create table d_mancumunado(
            cod_manc varchar (10) not null primary key,
            nom_mac varchar (100),
            f_ingreso date,
            f_salida date,
            id int identity(1,1) not null

            )

            create table participes_mancumunados(
            cod_part_manc varchar (10) not null primary key,
            cod_manc varchar (10) not null,
            nom_part varchar (100),
            appat varchar (100),
            apmat varchar (100),
            t_doc varchar (50),
            n_doc varchar(100),
            f_ingreso date,
            f_salida date,
            cod_parti varchar(10),
            id int identity(1,1) not null,
            tip_parti varchar(20)


            )

            create table da_participe (
            cod_parti varchar (10) not null primary key,
            cod_clie_bdp varchar (10),
            nom varchar (100),
            ap_pat varchar (100),
            ap_mat varchar (100),
            tip_doc varchar (50),
            n_docu varchar(100),
            direc varchar (200),
            correo varchar (100),
            f_ingreso date,
            f_salida date,
            id int identity(1,1) not null


            )

            create table d_participacion (
            cod_part varchar (10) not null primary key,
            cod_parti varchar (10)not null,
            cod_manc varchar (10)not null,
            cod_certi varchar (10)not null,
            cod_fondo varchar (10)not null,
            f_ingreso date,
            cod_gest varchar (10),
            tip_part varchar (10),
            mont_part decimal (20,5),
            n_parti decimal (20,10),
            v_cuota_actual decimal (20,5),
            f_salida date,
            nom_parti varchar(256),
            nom_manco varchar(256),
            nom_fondo varchar(256),
            id int identity(1,1) not null

            )

            create table d_certificado (
            cod_certi varchar (10) not null primary key,
            cod_parti varchar (10) not null,
            cod_manc varchar (10) not null,
            detalle varchar (10),
            fecha varchar (10),
            id int identity(1,1) not null

            )

            create table estado_cuenta_fondo (
            cod_estcuen varchar (10) not null primary key,
            cod_fondo varchar (10)not null,
            cod_gest varchar (10) not null,
            cod_cuenta varchar (10)not null,
            saldo_contable decimal (10,5),
            saldo_disponible decimal(10,5),
            moneda varchar (10),
            descripcion varchar (10),
            fecha date,
            codido varchar (10),
            cargo varchar (10),
            abono decimal (10,5),
            saldo decimal (10,5),
            diferencia decimal (10,5),
            id int identity(1,1) not null




            )
            create table d_clientes (
            cod_clie varchar (10) not null primary key,
            cod_clien_bdp varchar (10),
            nom varchar (100),
            ap_pater varchar (100),
            ap_mater varchar (100),
            tip_doc varchar (100),
            n_doc varchar (50),
            id int identity(1,1) not null


            )


            create table d_calif_clie (
            cod_cali varchar (10) not null primary key,
            cod_clie varchar (10) not null,
            estado varchar (100),
            aprob varchar (50),
            sub_doc varchar (50),
            ruta varchar (256),
            id int identity(1,1) not null


            )

            create table d_operacion (
            cod_op varchar (10) not null primary key,
            cod_clie varchar (10) not null,
            cod_gcdesem varchar (10) not null,
            cod_cuop varchar (10) not null,
            tip_op varchar (10),
            m_solic decimal (15,5),
            porc_comi_dese integer,
            mon_comi_dese decimal (15,5),
            por_igv integer,
            mont_igv decimal (15,5),
            mont_prestamo decimal (15,5),
            porc_inte decimal(10,5)
            mon_inte decimal (15,5),
            f_inicio_pres  date,
            f_termino_pres date,
            cod_gest varchar (10) not null,
            id int identity(1,1) not null,
            estado varchar(20)

            )

            create table fac_operacion_anx (
            cod_fac_anx varchar (10) not null primary key,
            cod_anexo varchar (10)not null,
            cod_clie varchar(10) not null,
            comi_min_tranfs decimal(15,5),
            porc_detrac decimal (15,5),
            porc_descu decimal (15,5) ,
            porc_int_cobra decimal (15,5),
            porc_igv decimal(15,5),
            n_document varchar(100),
            fec_venc_doc date,
            fec_recep_doc date,
            num_dias_fact varchar(10),
            girador varchar (250),
            aceptante varchar(250),
            mont_fact decimal (15,5),
            mont_detrac decimal (15,5),
            mon_neto decimal (15,5),
            mont_descu decimal(15,5),
            mont_int_cob decimal(15,5),
            mont_igv decimal(15,5),
            abono decimal(15,5),
            id int identity(1,1) not null,
            porc_comi_min decimal(15,5),
            igv_comi decimal(15,5),
            gestion varchar(10),
            estado varchar(20),
            int_dia decimal(15,5),
            refe varchar(10)

            )


            create table d_operacion_anx (
            cod_anx varchar (10) not null primary key,
            comi_trans decimal(15,5),
            igv_comi_trans decimal(15,5),
            mont_t_comi decimal(15,5),
            suma_interes decimal(15,5),
            igv_sum_int decimal(15,5),
            mont_t_int decimal (15,5),
            t_abono decimal(15,5),
            total decimal(15,5),
            fecha date,
            gestion varchar(10),
            id int identity(1,1) not null,
            cod_clie varchar(10),
            tip_ope varchar(10),
            estado varchar(20)
            )


            create table GASTO_COMI_DESEM (
            cod_gcdesem varchar (10) not null primary key,
            fecha date,
            detalle varchar (100),
            monto decimal (15,5),
            cod_cro_anx varchar (10),
            gestion varchar (20),
            id int identity(1,1) not null

            )

            CREATE TABLE CUOTAS_OPERACION (
            COD_CUOTA VARCHAR (10) NOT NULL PRIMARY KEY,
            COD_OP VARCHAR (10) NOT NULL,
            CAP_INICIAL DECIMAL (15,5),
            AMORTIZACION DECIMAL (15,5),
            CAP_FINAL DECIMAL (15,5),
            INTERES DECIMAL (15,5),
            IGV DECIMAL (15,5),
            T_CUOTA DECIMAL (15,5),
            DIAS INTEGER,
            F_VENCI DATE,
            FECHA DATE,
            id int identity(1,1) not null,
            gestion varchar(10),
            estado varchar(20)
            )


            CREATE TABLE NUM_DIAS_CRANX (
            dia1 decimal (10,5),
            dia2 decimal (10,5),
            dia3 decimal (10,5),
            dia4 decimal (10,5),
            dia5 decimal (10,5),
            dia6 decimal (10,5),
            dia7 decimal (10,5),
            dia8 decimal (10,5),
            dia9 decimal (10,5),
            dia10 decimal (10,5),
            dia11 decimal (10,5),
            dia12 decimal (10,5),
            dia13 decimal (10,5),
            dia14 decimal (10,5),
            dia15 decimal (10,5),
            dia16 decimal (10,5),
            dia17 decimal (10,5),
            dia18 decimal (10,5),
            dia19 decimal (10,5),
            dia20 decimal (10,5),
            dia21 decimal (10,5),
            dia22 decimal (10,5),
            dia23 decimal (10,5),
            dia24 decimal (10,5),
            dia25 decimal (10,5),
            dia26 decimal (10,5),
            dia27 decimal (10,5),
            dia28 decimal (10,5),
            dia29 decimal (10,5),
            dia30 decimal (10,5),
            dia31 decimal (10,5),
            dia32 decimal (10,5),
            dia33 decimal (10,5),
            dia34 decimal (10,5),
            dia35 decimal (10,5),
            dia36 decimal (10,5),
            dia37 decimal (10,5),
            dia38 decimal (10,5),
            dia39 decimal (10,5),
            dia40 decimal (10,5),
            dia41 decimal (10,5),
            dia42 decimal (10,5),
            dia43 decimal (10,5),
            dia44 decimal (10,5),
            dia45 decimal (10,5),
            dia46 decimal (10,5),
            dia47 decimal (10,5),
            dia48 decimal (10,5),
            dia49 decimal (10,5),
            dia50 decimal (10,5),
            dia51 decimal (10,5),
            dia52 decimal (10,5),
            dia53 decimal (10,5),
            dia54 decimal (10,5),
            dia55 decimal (10,5),
            dia56 decimal (10,5),
            dia57 decimal (10,5),
            dia58 decimal (10,5),
            dia59 decimal (10,5),
            dia60 decimal (10,5),
            dia61 decimal (10,5),
            dia62 decimal (10,5),
            dia63 decimal (10,5),
            dia64 decimal (10,5),
            dia65 decimal (10,5),
            dia66 decimal (10,5),
            dia67 decimal (10,5),
            dia68 decimal (10,5),
            dia69 decimal (10,5),
            dia70 decimal (10,5),
            dia71 decimal (10,5),
            dia72 decimal (10,5),
            dia73 decimal (10,5),
            dia74 decimal (10,5),
            dia75 decimal (10,5),
            dia76 decimal (10,5),
            dia77 decimal (10,5),
            dia78 decimal (10,5),
            dia79 decimal (10,5),
            dia80 decimal (10,5),
            dia81 decimal (10,5),
            dia82 decimal (10,5),
            dia83 decimal (10,5),
            dia84 decimal (10,5),
            dia85 decimal (10,5),
            dia86 decimal (10,5),
            dia87 decimal (10,5),
            dia88 decimal (10,5),
            dia89 decimal (10,5),
            dia90 decimal (10,5),
            dia91 decimal (10,5),
            dia92 decimal (10,5),
            dia93 decimal (10,5),
            dia94 decimal (10,5),
            dia95 decimal (10,5),
            dia96 decimal (10,5),
            dia97 decimal (10,5),
            dia98 decimal (10,5),
            dia99 decimal (10,5),
            dia100 decimal (10,5),
            dia101 decimal (10,5),
            dia102 decimal (10,5),
            dia103 decimal (10,5),
            dia104 decimal (10,5),
            dia105 decimal (10,5),
            dia106 decimal (10,5),
            dia107 decimal (10,5),
            dia108 decimal (10,5),
            dia109 decimal (10,5),
            dia110 decimal (10,5),
            dia111 decimal (10,5),
            dia112 decimal (10,5),
            dia113 decimal (10,5),
            dia114 decimal (10,5),
            dia115 decimal (10,5),
            dia116 decimal (10,5),
            dia117 decimal (10,5),
            dia118 decimal (10,5),
            dia119 decimal (10,5),
            dia120 decimal (10,5),
            dia121 decimal (10,5),
            dia122 decimal (10,5),
            dia123 decimal (10,5),
            dia124 decimal (10,5),
            dia125 decimal (10,5),
            dia126 decimal (10,5),
            dia127 decimal (10,5),
            dia128 decimal (10,5),
            dia129 decimal (10,5),
            dia130 decimal (10,5),
            dia131 decimal (10,5),
            dia132 decimal (10,5),
            dia133 decimal (10,5),
            dia134 decimal (10,5),
            dia135 decimal (10,5),
            dia136 decimal (10,5),
            dia137 decimal (10,5),
            dia138 decimal (10,5),
            dia139 decimal (10,5),
            dia140 decimal (10,5),
            dia141 decimal (10,5),
            dia142 decimal (10,5),
            dia143 decimal (10,5),
            dia144 decimal (10,5),
            dia145 decimal (10,5),
            dia146 decimal (10,5),
            dia147 decimal (10,5),
            dia148 decimal (10,5),
            dia149 decimal (10,5),
            dia150 decimal (10,5),
            dia151 decimal (10,5),
            dia152 decimal (10,5),
            dia153 decimal (10,5),
            dia154 decimal (10,5),
            dia155 decimal (10,5),
            dia156 decimal (10,5),
            dia157 decimal (10,5),
            dia158 decimal (10,5),
            dia159 decimal (10,5),
            dia160 decimal (10,5),
            dia161 decimal (10,5),
            dia162 decimal (10,5),
            dia163 decimal (10,5),
            dia164 decimal (10,5),
            dia165 decimal (10,5),
            dia166 decimal (10,5),
            dia167 decimal (10,5),
            dia168 decimal (10,5),
            dia169 decimal (10,5),
            dia170 decimal (10,5),
            dia171 decimal (10,5),
            dia172 decimal (10,5),
            dia173 decimal (10,5),
            dia174 decimal (10,5),
            dia175 decimal (10,5),
            dia176 decimal (10,5),
            dia177 decimal (10,5),
            dia178 decimal (10,5),
            dia179 decimal (10,5),
            dia180 decimal (10,5),
            dia181 decimal (10,5),
            dia182 decimal (10,5),
            dia183 decimal (10,5),
            dia184 decimal (10,5),
            dia185 decimal (10,5),
            dia186 decimal (10,5),
            dia187 decimal (10,5),
            dia188 decimal (10,5),
            dia189 decimal (10,5),
            dia190 decimal (10,5),
            dia191 decimal (10,5),
            dia192 decimal (10,5),
            dia193 decimal (10,5),
            dia194 decimal (10,5),
            dia195 decimal (10,5),
            dia196 decimal (10,5),
            dia197 decimal (10,5),
            dia198 decimal (10,5),
            dia199 decimal (10,5),
            dia200 decimal (10,5),
            dia201 decimal (10,5),
            dia202 decimal (10,5),
            dia203 decimal (10,5),
            dia204 decimal (10,5),
            dia205 decimal (10,5),
            dia206 decimal (10,5),
            dia207 decimal (10,5),
            dia208 decimal (10,5),
            dia209 decimal (10,5),
            dia210 decimal (10,5),
            dia211 decimal (10,5),
            dia212 decimal (10,5),
            dia213 decimal (10,5),
            dia214 decimal (10,5),
            dia215 decimal (10,5),
            dia216 decimal (10,5),
            dia217 decimal (10,5),
            dia218 decimal (10,5),
            dia219 decimal (10,5),
            dia220 decimal (10,5),
            dia221 decimal (10,5),
            dia222 decimal (10,5),
            dia223 decimal (10,5),
            dia224 decimal (10,5),
            dia225 decimal (10,5),
            dia226 decimal (10,5),
            dia227 decimal (10,5),
            dia228 decimal (10,5),
            dia229 decimal (10,5),
            dia230 decimal (10,5),
            dia231 decimal (10,5),
            dia232 decimal (10,5),
            dia233 decimal (10,5),
            dia234 decimal (10,5),
            dia235 decimal (10,5),
            dia236 decimal (10,5),
            dia237 decimal (10,5),
            dia238 decimal (10,5),
            dia239 decimal (10,5),
            dia240 decimal (10,5),
            dia241 decimal (10,5),
            dia242 decimal (10,5),
            dia243 decimal (10,5),
            dia244 decimal (10,5),
            dia245 decimal (10,5),
            dia246 decimal (10,5),
            dia247 decimal (10,5),
            dia248 decimal (10,5),
            dia249 decimal (10,5),
            dia250 decimal (10,5),
            dia251 decimal (10,5),
            dia252 decimal (10,5),
            dia253 decimal (10,5),
            dia254 decimal (10,5),
            dia255 decimal (10,5),
            dia256 decimal (10,5),
            dia257 decimal (10,5),
            dia258 decimal (10,5),
            dia259 decimal (10,5),
            dia260 decimal (10,5),
            dia261 decimal (10,5),
            dia262 decimal (10,5),
            dia263 decimal (10,5),
            dia264 decimal (10,5),
            dia265 decimal (10,5),
            dia266 decimal (10,5),
            dia267 decimal (10,5),
            dia268 decimal (10,5),
            dia269 decimal (10,5),
            dia270 decimal (10,5),
            dia271 decimal (10,5),
            dia272 decimal (10,5),
            dia273 decimal (10,5),
            dia274 decimal (10,5),
            dia275 decimal (10,5),
            dia276 decimal (10,5),
            dia277 decimal (10,5),
            dia278 decimal (10,5),
            dia279 decimal (10,5),
            dia280 decimal (10,5),
            dia281 decimal (10,5),
            dia282 decimal (10,5),
            dia283 decimal (10,5),
            dia284 decimal (10,5),
            dia285 decimal (10,5),
            dia286 decimal (10,5),
            dia287 decimal (10,5),
            dia288 decimal (10,5),
            dia289 decimal (10,5),
            dia290 decimal (10,5),
            dia291 decimal (10,5),
            dia292 decimal (10,5),
            dia293 decimal (10,5),
            dia294 decimal (10,5),
            dia295 decimal (10,5),
            dia296 decimal (10,5),
            dia297 decimal (10,5),
            dia298 decimal (10,5),
            dia299 decimal (10,5),
            dia300 decimal (10,5),
            dia301 decimal (10,5),
            dia302 decimal (10,5),
            dia303 decimal (10,5),
            dia304 decimal (10,5),
            dia305 decimal (10,5),
            dia306 decimal (10,5),
            dia307 decimal (10,5),
            dia308 decimal (10,5),
            dia309 decimal (10,5),
            dia310 decimal (10,5),
            dia311 decimal (10,5),
            dia312 decimal (10,5),
            dia313 decimal (10,5),
            dia314 decimal (10,5),
            dia315 decimal (10,5),
            dia316 decimal (10,5),
            dia317 decimal (10,5),
            dia318 decimal (10,5),
            dia319 decimal (10,5),
            dia320 decimal (10,5),
            dia321 decimal (10,5),
            dia322 decimal (10,5),
            dia323 decimal (10,5),
            dia324 decimal (10,5),
            dia325 decimal (10,5),
            dia326 decimal (10,5),
            dia327 decimal (10,5),
            dia328 decimal (10,5),
            dia329 decimal (10,5),
            dia330 decimal (10,5),
            dia331 decimal (10,5),
            dia332 decimal (10,5),
            dia333 decimal (10,5),
            dia334 decimal (10,5),
            dia335 decimal (10,5),
            dia336 decimal (10,5),
            dia337 decimal (10,5),
            dia338 decimal (10,5),
            dia339 decimal (10,5),
            dia340 decimal (10,5),
            dia341 decimal (10,5),
            dia342 decimal (10,5),
            dia343 decimal (10,5),
            dia344 decimal (10,5),
            dia345 decimal (10,5),
            dia346 decimal (10,5),
            dia347 decimal (10,5),
            dia348 decimal (10,5),
            dia349 decimal (10,5),
            dia350 decimal (10,5),
            dia351 decimal (10,5),
            dia352 decimal (10,5),
            dia353 decimal (10,5),
            dia354 decimal (10,5),
            dia355 decimal (10,5),
            dia356 decimal (10,5),
            dia357 decimal (10,5),
            dia358 decimal (10,5),
            dia359 decimal (10,5),
            dia360 decimal (10,5),
            dia361 decimal (10,5),
            dia362 decimal (10,5),
            dia363 decimal (10,5),
            dia364 decimal (10,5),
            dia365 decimal (10,5),
            dia366 decimal (10,5),
            COD_NUMDIAS VARCHAR (10) NOT NULL PRIMARY KEY,
            GESTION varchar(10),
            COD_OP VARCHAR (10),
            F_INICIO DATE,
            F_TERMINO DATE,
            N_DIAS_CUOTA INTEGER,
            MONTO_CUOTA DECIMAL (10,5),
            MONT_DIARIO DECIMAL (10,5),
            id int identity(1,1) not null,
            cod_cuota varchar(10),
            estado varchar(20),
            inte_diario decimal(15,5)

            )

            create table datos_proveedores (
            cod_porvee varchar (10) not null primary key,
            nom varchar (10) not null,
            tip_doc varchar (20),
            num_doc varchar (20),
            id int identity(1,1) not null

            )

            create table historial(
            cod_his varchar(10) not null primary key,
            cod_opcranx varchar(10) not null,
            cod_cufacdia varchar(10) not null,
            fecha date,
            f_inicio date,
            f_fin date,
            n_finicio date,
            n_ftermino date,
            monto decimal(15,5),
            montof decimal(15,5),
            referencia varchar(250),
            coment varchar(250),
            interes decimal(15,5),
            igv_interes decimal(15,5),
            comi_tran decimal(15,5),
            igv_comi_tran decimal(15,5),
            id int identity(1,1) not null,
            inte_diario decimal(15,5)

            )"

        fun1 = "create function [dbo].[gencod_alta_particpe] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_parti,3))),0) from da_participe
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun2 = "CREATE function [dbo].[gencod_anexo_oper] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_anx,3))),0) from d_operacion_anx
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun3 = "CREATE function [dbo].[gencod_banco_fondo] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_ban,3))),0) from reg_banco
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun4 = "CREATE function [dbo].[gencod_califcliente_fondo] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_cali,3))),0) from d_calif_clie
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun5 = "CREATE function [dbo].[gencod_cliente_fondo] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_clie,3))),0) from d_clientes
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun6 = "CREATE function [dbo].[gencod_comi_desembolso] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_gcdesem,3))),0) from gasto_comi_desem
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"

        fun7 = "CREATE function [dbo].[gencod_cuot_oper] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_cuota,3))),0) from cuotas_operacion
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun8 = "CREATE function [dbo].[gencod_dia_cro_anx] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_numdias,3))),0) from num_dias_cranx
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun9 = "CREATE function [dbo].[gencod_dias_croanx] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(COD_NUMDIAS,3))),0) from NUM_DIAS_CRANX
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun10 = "CREATE function [dbo].[gencod_distri_benef_fondo] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_di,3))),0) from DIST_BENEFICIO
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun11 = "CREATE function [dbo].[gencod_fact_anx] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_fac_anx,3))),0) from fac_operacion_anx
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun12 = "CREATE function [dbo].[gencod_historial] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_his,3))),0) from historial
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun13 = "CREATE function [dbo].[gencod_mancomunado] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_manc,3))),0) from d_mancumunado
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun14 = "CREATE function [dbo].[gencod_parti_mancumunado] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_part_manc,3))),0) from participes_mancumunados
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun15 = "CREATE function [dbo].[gencod_reg_datos_cuenta] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_cuenta,3))),0) from datos_cuenta
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun16 = "CREATE function [dbo].[gencod_reg_operacion] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_op,3))),0) from d_operacion
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        fun17 = "CREATE function [dbo].[gencod_reg_participacion] (@dato varchar (100)) 
                returns	varchar(10)
                as
                begin
                declare @autoincremento int, @numero varchar(10), @codigo varchar (10)
                set @codigo=SUBSTRING(@dato,1,2)
                select @autoincremento=ISNULL(max(convert(int,right(cod_part,3))),0) from d_participacion
                set @autoincremento=@autoincremento+1
                select @numero=RIGHT('00' + CONVERT(varchar,@autoincremento),3)
                set @codigo=RTRIM(@codigo)+RTRIM(@numero)
                return @codigo
                end"
        alta1 = "create procedure [dbo].[alta_anx_ope](
                --@cod_fondo varchar (10), /*detalle*/
                @comi_trans varchar(30),
                @igv_comi_trans varchar(30),
                @mont_t_comi varchar(30),
                @suma_interes varchar(30),
                @igv_suma_int varchar(30),
                @mont_t_int varchar(30),
                @t_abono varchar(30),
                @total varchar(30),
                @fecha date, --fecha de operacion
                @gestion varchar(30),
                @cod_clie varchar(10), --gestion
                @tip_ope varchar(10),
                @estado varchar(20)

                )
                as

                declare @codigo varchar(20)
                select @codigo=dbo.gencod_anexo_oper(@tip_ope)
                insert into d_operacion_anx
                values (@codigo,@comi_trans,@igv_comi_trans,@mont_t_comi, @suma_interes,@igv_suma_int, @mont_t_int,@t_abono,@total ,@fecha,@gestion,@cod_clie,@tip_ope,@estado)"

        alta2 = "CREATE procedure [dbo].[alta_comi_desembolso](
                --@cod_fondo varchar (10), /*detalle*/
                @fecha date, --fecha de registro
                @detalle varchar(100), --detalle de registro
                @monto varchar(30), -- monto de comision
                @cod_cro_anx varchar(20),--codigod e cornograma o anexo
                @gestion varchar(20) --año de creacion
                )
                as

                declare @codigo varchar(20)
                select @codigo=dbo.gencod_reg_operacion(@cod_cro_anx)
                insert into gasto_comi_desem
                values (@codigo,@fecha,@detalle,@monto, @cod_cro_anx,@gestion)"

        alta3 = "CREATE procedure [dbo].[alta_cuota_ope](
                --@cod_fondo varchar (10), /*detalle*/
                @cod_op varchar(10), --codigo de operacion
                @cap_inicial varchar(30), --capital inicial
                @amortizacion varchar(30), -- monto de amortazacion
                @cap_final varchar(30),--capital final
                @interes varchar(30), --interes
                @igv varchar(30), --igv
                @t_cuota varchar(30), --total de cuota
                @dias varchar(10),
                @f_venci date,
                @fecha date,
                @gestion varchar(10),
                @estado varchar(20)

                )
                as

                declare @codigo varchar(20)
                select @codigo=dbo.gencod_cuot_oper(@cod_op)
                insert into cuotas_operacion
                values (@codigo,@cod_op,@cap_inicial,@amortizacion, @cap_final,@interes,@igv, @t_cuota,@dias,@f_venci,@fecha, @gestion,@estado)"

        alta4 = "create procedure [dbo].[alta_d_mancumunado](
                --@cod_manc varchar (10), /*detalle*/
                @nom_manc varchar (100),--nombre de participe
                @f_ingreso date, --fecha de ingreso
                @f_salida date --fecha de salida

                )
                as
                declare @ncont varchar(5)
                select @ncont=dbo.gencod_mancomunado(@nom_manc)
                insert into d_mancumunado
                values (@ncont,@nom_manc,@f_ingreso,@f_salida)"

        alta5 = "create procedure [dbo].[alta_d_operacion](
                --@cod_fondo varchar (10), /*detalle*/
                @cod_clie varchar (10), --codigo de distribucion de benefecio
                @cod_gcdesem varchar(10), --codigo de 
                @cod_cuop varchar(10), -- codigo de cuota de operacion
                @tip_op varchar(20),--tipo de operacion
                @m_solic varchar(30), --monto solicitado
                @porc_comi_dese  varchar(20),-- porcentaje de comision de desembolso
                @mon_comi_dese varchar(30),---monto comision de desembolso
                @por_igv varchar(20), -- porcentaje de igv
                @mont_igv varchar(30), -- monto de igv
                @mont_prestamo varchar(30),
                @porce_inte varchar(20), -- porcentaje de interes
                @mont_int varchar(30), --monto de interes
                @f_inicio_pres date, --fecha de inicio de prestamo
                @f_termino_prest date,-- fecha de termino del prestamo
                @cod_gestion varchar (10), --codgestion
                @estado varchar(20)
                )
                as

                declare @codigo varchar(20)
                select @codigo=dbo.gencod_reg_operacion(@tip_op)
                insert into d_operacion
                values (@codigo,@cod_clie,@cod_gcdesem,@cod_cuop, @tip_op,@m_solic,@porc_comi_dese,@mon_comi_dese,@por_igv,@mont_igv,@mont_prestamo,@porce_inte,@mont_int,@f_inicio_pres,@f_termino_prest,  @cod_gestion,@estado)"

        alta6 = "create procedure [dbo].[alta_d_participacion](
                --@cod_manc varchar (10), /*detalle*/
                @cod_parti varchar (10), --codigo de participe
                @cod_manc varchar(10), --codigo de mancomunado
                @cod_certi varchar(10),--codigo de certificado
                @cod_fondo varchar(10),--codigo de fondo
                @f_ingreso date, --fecha de ingreso
                @gestion varchar(10), -- gestion de ingreso
                @tip_parti varchar(100),-- tipo de participacion
                @mont_part decimal(20,10),---monto de participacion
                @n_parti decimal(20,10), -- numero de participacion
                @v_cuot_actu decimal(20,10), -- valor de cuoita actual
                @f_salida date, -- fecha de salida del fondo
                @nom_parti varchar(256), --nombre de participe
                @nom_maco varchar(256), --nombre de mancomunado
                @nom_fondo varchar(256) --nombre de fondo
                )
                as

                declare @ncont varchar(10)
                select @ncont=dbo.gencod_reg_participacion(@gestion)
                insert into d_participacion
                values (@ncont,@cod_parti,@cod_manc, @cod_certi,@cod_fondo, @f_ingreso,@gestion,@tip_parti,@mont_part,@n_parti,@v_cuot_actu,@f_salida,@nom_parti,@nom_maco,@nom_fondo)
                --------------------------------------------------------------------------------------"

        alta7 = "create procedure [dbo].[alta_d_participe](
                /*@nc varchar (10),/*nocontrol*/*/
                @cod_clie_bdp varchar (10), /*detalle*/
                @nom varchar (100), --nombre de participe,
                @ap_pat varchar (100),--appellido paterno participe
                @ap_mat varchar (100),--apellido materno 
                @tip_doc varchar (50), --tipo de documento
                @n_doc varchar (100), --numero de documento
                @direc varchar (200),--direccion del participe
                @correo varchar (100),-- correo electronico
                @f_ingreso date, --fecha de ingreso
                @f_salida date --fecha de salida
                )
                as
                declare @ncont varchar(5)
                select @ncont=dbo.gencod_alta_particpe(@nom)
                insert into da_participe
                values (@ncont,@cod_clie_bdp,@nom,@ap_pat,@ap_mat,@tip_doc,@n_doc,@direc,@correo,@f_ingreso,@f_salida)"

        alta8 = "create procedure [dbo].[alta_datos_cuenta](
                --@cod_cuenta varchar (10), /*detalle*/
                @cod_ban varchar (10), --codigo de banco
                @tipo_cuenta varchar(10), --tipo de cuenta
                @n_cuenta varchar(100),--numero de cuenta
                @n_cci varchar(100), -- numero de cci de la cuenta
                @mon_cuenta varchar(10), --moneda de la cuenta
                @cod_parti varchar(10),--codigo de participe
                @cod_clie varchar(10),-- codigo de cliente
                @cod_provee varchar(10),--codigo de proveedor
                @cod_fondo varchar (10), --codigo de fondo
                @nom_parti varchar (256),---nombre de participe
                @nom_clie varchar (256),
                @nom_proveedor varchar (256),
                @nom_fondo varchar (256),
                @cod_manc varchar (10),
                @nom_manc varchar(256)



                )
                as

                declare @ncont varchar(10)
                select @ncont=dbo.gencod_reg_datos_cuenta(@n_cuenta)
                insert into datos_cuenta
                values (@ncont,@cod_ban,@tipo_cuenta, @n_cuenta,@n_cci, @mon_cuenta,@cod_parti,@cod_clie,@cod_provee,@cod_fondo,@nom_parti,@nom_clie,@nom_proveedor,@nom_fondo,@cod_manc,@nom_manc)"


        alta9 = "create procedure [dbo].[alta_DATOS_FONDO](
                @cod_fondo varchar (10), /*detalle*/
                @cod_di varchar (20), --codigo de distribucion de benefecio
                @n_fondo varchar(25), --nombre de fondo
                @moneda varchar(20), -- moneda
                @mont_minimo decimal(20,5),--codigo de certificado
                @mont_maximo decimal(20,5), --fecha de ingreso
                @unidad_negocio  varchar(100),-- tipo de participacion
                @f_creacion date,---monto de participacion
                @f_ins_sunat date, -- fecha de inscripcion a sunat
                @nu_ruc varchar(20), -- numero de ruc
                @f_ini_opera date, -- fechad e inicio de operaciones
                @f_ter_opera date, --fecha de termino de operaciones
                @valor_cuota_nom decimal (20,5), --valor de cuota nominal
                @valor_cuota_actual decimal (20,5), --valor de cuota actual
                @cod_gest varchar (10),
                @fecha date ,--fecha actual
                @patri decimal(30,5)
                )
                as

                declare @capital_actual decimal(30,5)
                select @capital_actual=SUM(mont_part) from d_participacion WHERE f_ingreso like @fecha
                insert into DATOS_FONDO
                values (@cod_fondo,@cod_di,@n_fondo,@moneda, @mont_minimo,@mont_maximo,@capital_actual,@unidad_negocio,@f_creacion,@f_ins_sunat,@nu_ruc,@f_ini_opera,@f_ter_opera,@valor_cuota_nom, @valor_cuota_actual, @cod_gest, @fecha,@patri)"

        alta10 = "create procedure [dbo].[alta_dias_cranx](
                --@cod_fondo varchar (10), /*detalle*/
                @dia1 decimal (10,5),
                @dia2 decimal (10,5),
                @dia3 decimal (10,5),
                @dia4 decimal (10,5),
                @dia5 decimal (10,5),
                @dia6 decimal (10,5),
                @dia7 decimal (10,5),
                @dia8 decimal (10,5),
                @dia9 decimal (10,5),
                @dia10 decimal (10,5),
                @dia11 decimal (10,5),
                @dia12 decimal (10,5),
                @dia13 decimal (10,5),
                @dia14 decimal (10,5),
                @dia15 decimal (10,5),
                @dia16 decimal (10,5),
                @dia17 decimal (10,5),
                @dia18 decimal (10,5),
                @dia19 decimal (10,5),
                @dia20 decimal (10,5),
                @dia21 decimal (10,5),
                @dia22 decimal (10,5),
                @dia23 decimal (10,5),
                @dia24 decimal (10,5),
                @dia25 decimal (10,5),
                @dia26 decimal (10,5),
                @dia27 decimal (10,5),
                @dia28 decimal (10,5),
                @dia29 decimal (10,5),
                @dia30 decimal (10,5),
                @dia31 decimal (10,5),
                @dia32 decimal (10,5),
                @dia33 decimal (10,5),
                @dia34 decimal (10,5),
                @dia35 decimal (10,5),
                @dia36 decimal (10,5),
                @dia37 decimal (10,5),
                @dia38 decimal (10,5),
                @dia39 decimal (10,5),
                @dia40 decimal (10,5),
                @dia41 decimal (10,5),
                @dia42 decimal (10,5),
                @dia43 decimal(10,5),
                @dia44 decimal(10,5),
                @dia45 decimal (10,5),
                @dia46 decimal (10,5),
                @dia47 decimal (10,5),
                @dia48 decimal (10,5),
                @dia49 decimal (10,5),
                @dia50 decimal (10,5),
                @dia51 decimal (10,5),
                @dia52 decimal (10,5),
                @dia53 decimal (10,5),
                @dia54 decimal (10,5),
                @dia55 decimal (10,5),
                @dia56 decimal (10,5),
                @dia57 decimal (10,5),
                @dia58 decimal (10,5),
                @dia59 decimal (10,5),
                @dia60 decimal (10,5),
                @dia61 decimal (10,5),
                @dia62 decimal (10,5),
                @dia63 decimal (10,5),
                @dia64 decimal (10,5),
                @dia65 decimal (10,5),
                @dia66 decimal (10,5),
                @dia67 decimal (10,5),
                @dia68 decimal (10,5),
                @dia69 decimal (10,5),
                @dia70 decimal (10,5),
                @dia71 decimal (10,5),
                @dia72 decimal (10,5),
                @dia73 decimal (10,5),
                @dia74 decimal (10,5),
                @dia75 decimal (10,5),
                @dia76 decimal (10,5),
                @dia77 decimal (10,5),
                @dia78 decimal (10,5),
                @dia79 decimal (10,5),
                @dia80 decimal (10,5),
                @dia81 decimal (10,5),
                @dia82 decimal (10,5),
                @dia83 decimal (10,5),
                @dia84 decimal (10,5),
                @dia85 decimal (10,5),
                @dia86 decimal (10,5),
                @dia87 decimal (10,5),
                @dia88 decimal (10,5),
                @dia89 decimal (10,5),
                @dia90 decimal (10,5),
                @dia91 decimal(10,5),
                @dia92 decimal(10,5),
                @dia93 decimal (10,5),
                @dia94 decimal (10,5),
                @dia95 decimal (10,5),
                @dia96 decimal(10,5),
                @dia97 decimal(10,5),
                @dia98 decimal(10,5),
                @dia99 decimal(10,5),
                @dia100 decimal (10,5),
                @dia101 decimal (10,5),
                @dia102 decimal (10,5),
                @dia103 decimal (10,5),
                @dia104 decimal (10,5),
                @dia105 decimal (10,5),
                @dia106 decimal (10,5),
                @dia107 decimal (10,5),
                @dia108 decimal (10,5),
                @dia109 decimal (10,5),
                @dia110 decimal (10,5),
                @dia111 decimal (10,5),
                @dia112 decimal (10,5),
                @dia113 decimal (10,5),
                @dia114 decimal (10,5),
                @dia115 decimal (10,5),
                @dia116 decimal (10,5),
                @dia117 decimal (10,5),
                @dia118 decimal (10,5),
                @dia119 decimal (10,5),
                @dia120 decimal (10,5),
                @dia121 decimal (10,5),
                @dia122 decimal (10,5),
                @dia123 decimal (10,5),
                @dia124 decimal (10,5),
                @dia125 decimal (10,5),
                @dia126 decimal (10,5),
                @dia127 decimal (10,5),
                @dia128 decimal (10,5),
                @dia129 decimal (10,5),
                @dia130 decimal (10,5),
                @dia131 decimal (10,5),
                @dia132 decimal (10,5),
                @dia133 decimal (10,5),
                @dia134 decimal (10,5),
                @dia135 decimal (10,5),
                @dia136 decimal (10,5),
                @dia137 decimal (10,5),
                @dia138 decimal (10,5),
                @dia139 decimal (10,5),
                @dia140 decimal (10,5),
                @dia141 decimal (10,5),
                @dia142 decimal (10,5),
                @dia143 decimal (10,5),
                @dia144 decimal (10,5),
                @dia145 decimal (10,5),
                @dia146 decimal (10,5),
                @dia147 decimal (10,5),
                @dia148 decimal (10,5),
                @dia149 decimal (10,5),
                @dia150 decimal (10,5),
                @dia151 decimal (10,5),
                @dia152 decimal (10,5),
                @dia153 decimal (10,5),
                @dia154 decimal (10,5),
                @dia155 decimal (10,5),
                @dia156 decimal (10,5),
                @dia157 decimal (10,5),
                @dia158 decimal (10,5),
                @dia159 decimal (10,5),
                @dia160 decimal (10,5),
                @dia161 decimal (10,5),
                @dia162 decimal (10,5),
                @dia163 decimal (10,5),
                @dia164 decimal (10,5),
                @dia165 decimal (10,5),
                @dia166 decimal (10,5),
                @dia167 decimal (10,5),
                @dia168 decimal (10,5),
                @dia169 decimal (10,5),
                @dia170 decimal (10,5),
                @dia171 decimal (10,5),
                @dia172 decimal (10,5),
                @dia173 decimal (10,5),
                @dia174 decimal (10,5),
                @dia175 decimal (10,5),
                @dia176 decimal (10,5),
                @dia177 decimal (10,5),
                @dia178 decimal (10,5),
                @dia179 decimal (10,5),
                @dia180 decimal (10,5),
                @dia181 decimal (10,5),
                @dia182 decimal (10,5),
                @dia183 decimal (10,5),
                @dia184 decimal (10,5),
                @dia185 decimal (10,5),
                @dia186 decimal (10,5),
                @dia187 decimal (10,5),
                @dia188 decimal (10,5),
                @dia189 decimal (10,5),
                @dia190 decimal (10,5),
                @dia191 decimal (10,5),
                @dia192 decimal (10,5),
                @dia193 decimal (10,5),
                @dia194 decimal (10,5),
                @dia195 decimal (10,5),
                @dia196 decimal (10,5),
                @dia197 decimal (10,5),
                @dia198 decimal (10,5),
                @dia199 decimal (10,5),
                @dia200 decimal (10,5),
                @dia201 decimal (10,5),
                @dia202 decimal (10,5),
                @dia203 decimal (10,5),
                @dia204 decimal (10,5),
                @dia205 decimal (10,5),
                @dia206 decimal (10,5),
                @dia207 decimal (10,5),
                @dia208 decimal (10,5),
                @dia209 decimal (10,5),
                @dia210 decimal (10,5),
                @dia211 decimal (10,5),
                @dia212 decimal (10,5),
                @dia213 decimal (10,5),
                @dia214 decimal (10,5),
                @dia215 decimal (10,5),
                @dia216 decimal (10,5),
                @dia217 decimal (10,5),
                @dia218 decimal (10,5),
                @dia219 decimal (10,5),
                @dia220 decimal (10,5),
                @dia221 decimal (10,5),
                @dia222 decimal (10,5),
                @dia223 decimal (10,5),
                @dia224 decimal (10,5),
                @dia225 decimal (10,5),
                @dia226 decimal (10,5),
                @dia227 decimal (10,5),
                @dia228 decimal (10,5),
                @dia229 decimal (10,5),
                @dia230 decimal (10,5),
                @dia231 decimal (10,5),
                @dia232 decimal (10,5),
                @dia233 decimal (10,5),
                @dia234 decimal (10,5),
                @dia235 decimal (10,5),
                @dia236 decimal (10,5),
                @dia237 decimal (10,5),
                @dia238 decimal (10,5),
                @dia239 decimal (10,5),
                @dia240 decimal (10,5),
                @dia241 decimal (10,5),
                @dia242 decimal (10,5),
                @dia243 decimal (10,5),
                @dia244 decimal (10,5),
                @dia245 decimal (10,5),
                @dia246 decimal (10,5),
                @dia247 decimal (10,5),
                @dia248 decimal (10,5),
                @dia249 decimal (10,5),
                @dia250 decimal (10,5),
                @dia251 decimal (10,5),
                @dia252 decimal (10,5),
                @dia253 decimal (10,5),
                @dia254 decimal (10,5),
                @dia255 decimal (10,5),
                @dia256 decimal (10,5),
                @dia257 decimal (10,5),
                @dia258 decimal (10,5),
                @dia259 decimal (10,5),
                @dia260 decimal (10,5),
                @dia261 decimal (10,5),
                @dia262 decimal (10,5),
                @dia263 decimal (10,5),
                @dia264 decimal (10,5),
                @dia265 decimal (10,5),
                @dia266 decimal (10,5),
                @dia267 decimal (10,5),
                @dia268 decimal (10,5),
                @dia269 decimal (10,5),
                @dia270 decimal (10,5),
                @dia271 decimal (10,5),
                @dia272 decimal (10,5),
                @dia273 decimal (10,5),
                @dia274 decimal (10,5),
                @dia275 decimal (10,5),
                @dia276 decimal (10,5),
                @dia277 decimal (10,5),
                @dia278 decimal (10,5),
                @dia279 decimal (10,5),
                @dia280 decimal (10,5),
                @dia281 decimal (10,5),
                @dia282 decimal (10,5),
                @dia283 decimal (10,5),
                @dia284 decimal (10,5),
                @dia285 decimal (10,5),
                @dia286 decimal (10,5),
                @dia287 decimal (10,5),
                @dia288 decimal (10,5),
                @dia289 decimal (10,5),
                @dia290 decimal (10,5),
                @dia291 decimal (10,5),
                @dia292 decimal (10,5),
                @dia293 decimal (10,5),
                @dia294 decimal (10,5),
                @dia295 decimal (10,5),
                @dia296 decimal (10,5),
                @dia297 decimal (10,5),
                @dia298 decimal (10,5),
                @dia299 decimal (10,5),
                @dia300 decimal (10,5),
                @dia301 decimal (10,5),
                @dia302 decimal (10,5),
                @dia303 decimal (10,5),
                @dia304 decimal (10,5),
                @dia305 decimal (10,5),
                @dia306 decimal (10,5),
                @dia307 decimal (10,5),
                @dia308 decimal (10,5),
                @dia309 decimal (10,5),
                @dia310 decimal (10,5),
                @dia311 decimal (10,5),
                @dia312 decimal (10,5),
                @dia313 decimal (10,5),
                @dia314 decimal (10,5),
                @dia315 decimal (10,5),
                @dia316 decimal (10,5),
                @dia317 decimal (10,5),
                @dia318 decimal (10,5),
                @dia319 decimal (10,5),
                @dia320 decimal (10,5),
                @dia321 decimal (10,5),
                @dia322 decimal (10,5),
                @dia323 decimal (10,5),
                @dia324 decimal (10,5),
                @dia325 decimal (10,5),
                @dia326 decimal (10,5),
                @dia327 decimal (10,5),
                @dia328 decimal (10,5),
                @dia329 decimal (10,5),
                @dia330 decimal (10,5),
                @dia331 decimal (10,5),
                @dia332 decimal (10,5),
                @dia333 decimal (10,5),
                @dia334 decimal (10,5),
                @dia335 decimal (10,5),
                @dia336 decimal (10,5),
                @dia337 decimal (10,5),
                @dia338 decimal (10,5),
                @dia339 decimal (10,5),
                @dia340 decimal (10,5),
                @dia341 decimal (10,5),
                @dia342 decimal (10,5),
                @dia343 decimal (10,5),
                @dia344 decimal (10,5),
                @dia345 decimal (10,5),
                @dia346 decimal (10,5),
                @dia347 decimal (10,5),
                @dia348 decimal (10,5),
                @dia349 decimal (10,5),
                @dia350 decimal (10,5),
                @dia351 decimal (10,5),
                @dia352 decimal (10,5),
                @dia353 decimal (10,5),
                @dia354 decimal (10,5),
                @dia355 decimal (10,5),
                @dia356 decimal (10,5),
                @dia357 decimal (10,5),
                @dia358 decimal (10,5),
                @dia359 decimal (10,5),
                @dia360 decimal (10,5),
                @dia361 decimal (10,5),
                @dia362 decimal (10,5),
                @dia363 decimal (10,5),
                @dia364 decimal (10,5),
                @dia365 decimal (10,5),
                @dia366 decimal (10,5),
                @gestion varchar(10),
                @COD_OP VARCHAR (10),
                @F_INICIO DATE,
                @F_TERMINO DATE,
                @N_DIAS_CUOTA varchar(10),
                @MONTO_CUOTA DECIMAL (10,5),
                @MONT_DIARIO DECIMAL (10,5),
                @COD_CUOTA VARCHAR(10),
                @estado varchar(20),
                @int_d varchar(30)

                )
                as

                declare @codigo varchar(10)
                select @codigo=dbo.gencod_dia_cro_anx(@cod_cuota)
                insert into NUM_DIAS_CRANX
                values (@dia1,@dia2,@dia3,@dia4,@dia5,@dia6,@dia7,@dia8,@dia9,@dia10,@dia11,@dia12,@dia13,@dia14,@dia15,@dia16,@dia17,@dia18,@dia19,@dia20,@dia21,@dia22,@dia23,@dia24,@dia25,@dia26,@dia27,@dia28,@dia29,@dia30,@dia31,@dia32,@dia33,@dia34,@dia35,@dia36,@dia37,@dia38,@dia39,@dia40,@dia41,@dia42,@dia43,@dia44,@dia45,@dia46,@dia47,@dia48,@dia49,@dia50,@dia51,@dia52,@dia53,@dia54,@dia55,@dia56,@dia57,@dia58,@dia59,@dia60,@dia61,@dia62,@dia63,@dia64,@dia65,@dia66,@dia67,@dia68,@dia69,@dia70,@dia71,@dia72,@dia73,@dia74,@dia75,@dia76,@dia77,@dia78,@dia79,@dia80,@dia81,@dia82,@dia83,@dia84,@dia85,@dia86,@dia87,@dia88,@dia89,@dia90,@dia91,@dia92,@dia93,@dia94,@dia95,@dia96,@dia97,@dia98,@dia99,@dia100,@dia101,@dia102,@dia103,@dia104,@dia105,@dia106,@dia107,@dia108,@dia109,@dia110,@dia111,@dia112,@dia113,@dia114,@dia115,@dia116,@dia117,@dia118,@dia119,@dia120,@dia121,@dia122,@dia123,@dia124,@dia125,@dia126,@dia127,@dia128,@dia129,@dia130,@dia131,@dia132,@dia133,@dia134,@dia135,@dia136,@dia137,@dia138,@dia139,@dia140,@dia141,@dia142,@dia143,@dia144,@dia145,@dia146,@dia147,@dia148,@dia149,@dia150,@dia151,@dia152,@dia153,@dia154,@dia155,@dia156,@dia157,@dia158,@dia159,@dia160,@dia161,@dia162,@dia163,@dia164,@dia165,@dia166,@dia167,@dia168,@dia169,@dia170,@dia171,@dia172,@dia173,@dia174,@dia175,@dia176,@dia177,@dia178,@dia179,@dia180,@dia181,@dia182,@dia183,@dia184,@dia185,@dia186,@dia187,@dia188,@dia189,@dia190,@dia191,@dia192,@dia193,@dia194,@dia195,@dia196,@dia197,@dia198,@dia199,@dia200,@dia201,@dia202,@dia203,@dia204,@dia205,@dia206,@dia207,@dia208,@dia209,@dia210,@dia211,@dia212,@dia213,@dia214,@dia215,@dia216,@dia217,@dia218,@dia219,@dia220,@dia221,@dia222,@dia223,@dia224,@dia225,@dia226,@dia227,@dia228,@dia229,@dia230,@dia231,@dia232,@dia233,@dia234,@dia235,@dia236,@dia237,@dia238,@dia239,@dia240,@dia241,@dia242,@dia243,@dia244,@dia245,@dia246,@dia247,@dia248,@dia249,@dia250,@dia251,@dia252,@dia253,@dia254,@dia255,@dia256,@dia257,@dia258,@dia259,@dia260,@dia261,@dia262,@dia263,@dia264,@dia265,@dia266,@dia267,@dia268,@dia269,@dia270,@dia271,@dia272,@dia273,@dia274,@dia275,@dia276,@dia277,@dia278,@dia279,@dia280,@dia281,@dia282,@dia283,@dia284,@dia285,@dia286,@dia287,@dia288,@dia289,@dia290,@dia291,@dia292,@dia293,@dia294,@dia295,@dia296,@dia297,@dia298,@dia299,@dia300,@dia301,@dia302,@dia303,@dia304,@dia305,@dia306,@dia307,@dia308,@dia309,@dia310,@dia311,@dia312,@dia313,@dia314,@dia315,@dia316,@dia317,@dia318,@dia319,@dia320,@dia321,@dia322,@dia323,@dia324,@dia325,@dia326,@dia327,@dia328,@dia329,@dia330,@dia331,@dia332,@dia333,@dia334,@dia335,@dia336,@dia337,@dia338,@dia339,@dia340,@dia341,@dia342,@dia343,@dia344,@dia345,@dia346,@dia347,@dia348,@dia349,@dia350,@dia351,@dia352,@dia353,@dia354,@dia355,@dia356,@dia357,@dia358,@dia359,@dia360,@dia361,@dia362,@dia363,@dia364,@dia365,@dia366,@codigo,@gestion,@COD_OP,@F_INICIO,@F_TERMINO,@n_dias_cuota,@monto_cuota,@mont_diario,@COD_CUOTA, @estado,@int_d)"

        alta11 = "create procedure [dbo].[alta_dist_beneficio](
                --@cod_manc varchar (10), /*detalle*/
                @distribucion varchar (50), --distribucion
                @n_distrib int, --numero de distribucion de benfecio
                @cod_gest varchar(10),--codigo de gestion
                @n_dias integer

                )
                as

                declare @ncont varchar(10)
                select @ncont=dbo.gencod_distri_benef_fondo(@distribucion)
                insert into DIST_BENEFICIO
                values (@ncont,@distribucion,@n_distrib, @cod_gest,@n_dias)"

        alta12 = "create procedure [dbo].[alta_fac_anx](
                --@cod_fondo varchar (10), /*detalle*/
                @cod_anexo varchar(10),
                @cod_clie varchar(10),
                @comi_mini_trans varchar(30),
                @porc_detrac varchar(30),
                @porc_descu varchar(30),
                @porc_int_cobra varchar(30),
                @porc_igv varchar(30),
                @n_documento varchar(100),
                @fec_venc_doc date, --fecha de operacion
                @fec_recep_doc date, --gestion
                @num_dias_fact varchar(10),
                @girador varchar(250),
                @aceptante varchar(250),
                @mont_fact varchar(30),
                @mont_detrac varchar(30),
                @mont_neto varchar(30),
                @mont_descu varchar(30),
                @mont_int_cob varchar(30),
                @mont_igv varchar(30),
                @abono varchar(30),
                @porc_comi varchar(30),
                @igv_comi  varchar(30),
                @gestion varchar(10),
                @estado varchar(20),
                @ind_d varchar(30),
                @refe varchar(10)

                )
                as

                declare @codigo varchar(20)
                select @codigo=dbo.gencod_fact_anx(@cod_anexo)
                insert into fac_operacion_anx
                values (@codigo,@cod_anexo,@cod_clie,@comi_mini_trans, @porc_detrac,@porc_descu, @porc_int_cobra ,@porc_igv,@n_documento ,@fec_venc_doc,@fec_recep_doc,@num_dias_fact,@girador,@aceptante,@mont_fact,@mont_detrac,@mont_neto,@mont_descu,@mont_int_cob,@mont_igv,@abono,@porc_comi,@igv_comi,@gestion,@estado,@ind_d,@refe)"

        alta13 = "create procedure [dbo].[alta_historial](
                --@cod_fondo varchar (10), /*detalle*/
                @cod_opcraanx varchar(10),
                @cod_cufeacdia varchar(10),
                @fecha date,
                @f_inicio date,
                @f_fin date,
                @n_finicio date,
                @n_ftermino date,
                @monto varchar(30),
                @montof varchar(30), --fecha de operacion
                @referencia varchar(250), --gestion
                @coment varchar(250),
                @interes varchar(30),
                @igv_interes varchar(30),
                @comision varchar(30),
                @igv_comi varchar(30),
                @int_diario varchar(30)
                )
                as

                declare @codigo varchar(20)
                select @codigo=dbo.gencod_historial(@cod_opcraanx)
                insert into historial
                values (@codigo,@cod_opcraanx,@cod_cufeacdia,@fecha, @f_inicio,@f_fin, @n_finicio ,@n_ftermino ,@monto,@montof,@referencia,@coment,@interes,@igv_comi, @comision,@igv_comi,@int_diario)"

        alta14 = "create procedure [dbo].[alta_part_mancumunados](
                --@cod_manc varchar (10), /*detalle*/
                @cod_manc varchar(10), --codigo mancumunado
                @nom_part varchar (100), --nombre de participe
                @appat varchar (100), --apellido paterno
                @apmat varchar (100), --apellido materno
                @t_doc varchar (50),--tipo de documento
                @n_doc varchar (100), -- numero de documento
                @f_ingreso date, --fecha de ingreso
                @f_salida date, --fecha de salida
                @cod_parti varchar (10),
                @tip_parti varchar(20)

                )
                as
                declare @ncont varchar(10)
                select @ncont=dbo.gencod_parti_mancumunado(@nom_part)
                insert into participes_mancumunados
                values (@ncont,@cod_manc,@nom_part,@appat,@apmat,@t_doc,@n_doc, @f_ingreso,@f_salida,@cod_parti,@tip_parti)"

        alta15 = "create procedure [dbo].[alta_reg_banco](
                --@cod_manc varchar (10), /*detalle*/
                @n_banco varchar(100), -- nombre de banco
                @ruc  varchar(20) --ruc de banco

                )
                as
                declare @ncont varchar(10)
                select @ncont=dbo.gencod_banco_fondo(@n_banco)
                insert into reg_banco
                values (@ncont,@n_banco,@ruc)"

        alta16 = "create procedure [dbo].[alta_reg_caliclie](
                --@cod_manc varchar (10), /*detalle*/
                @cod_clie varchar (10), --codigo de cliente
                @estado varchar(100), --estado de seguimiento calificacion
                @aprob varchar(50),--aprobacion
                @sub_doc varchar(50), -- subir codumento
                @ruta varchar(250)


                )
                as

                declare @ncont varchar(10)
                select @ncont=dbo.gencod_califcliente_fondo(@cod_clie)
                insert into d_calif_clie
                values (@ncont,@cod_clie,@estado, @aprob,@sub_doc,@ruta)"

        alta17 = "create procedure [dbo].[alta_reg_clientes](
                --@cod_manc varchar (10), /*detalle*/
                @cod_clien_bdp varchar (10), --codigo de bd datos principal
                @nom varchar(100), --nombre de cliente
                @appat varchar(100),--apellido paterno
                @apmat varchar(100), -- apellido materno
                @tip_doc varchar(100), --tipo de documento
                @n_doc varchar (50) --numero de documento

                )
                as

                declare @ncont varchar(10)
                select @ncont=dbo.gencod_cliente_fondo(@nom)
                insert into d_clientes
                values (@ncont,@cod_clien_bdp,@nom, @appat,@apmat,@tip_doc,@n_doc)"

        SUMA = "create procedure [dbo].[calc_capi_total](
                @cod_fondo varchar (10) /*detalle*/
                )
                as

                declare @capital_actual decimal(30,10)
                select @capital_actual=SUM(CAPITAL_ACTUAL) from DATOS_FONDO WHERE COD_FONDO like @cod_fondo"

        edit1 = "CREATE procedure [dbo].[edita_anx_ope](
                @cod_anx varchar (10), /*detalle*/
                @comi_trans varchar(30),
                @igv_comi_trans varchar(30),
                @mont_t_comi varchar(30),
                @suma_interes varchar(30),
                @igv_suma_int varchar(30),
                @mont_t_int varchar(30),
                @t_abono varchar(30),
                @total varchar(30),
                @fecha date, --fecha de operacion
                @gestion varchar(30),
                @cod_clie varchar(10), --gestion
                @tip_ope varchar(10),
                @estado varchar(20)
                )
                as

                update d_operacion_anx  set comi_trans=@comi_trans,
							                igv_comi_trans=@igv_comi_trans,
							                mont_t_comi=@mont_t_comi,
							                suma_interes=@suma_interes,
							                igv_sum_int=@igv_suma_int,
							                mont_t_int=@mont_t_int,
							                t_abono=@t_abono,
							                total=@total,
							                fecha=@fecha,
							                gestion=@gestion,
							                cod_clie=@cod_clie,
							                tip_ope=@tip_ope,
							                estado=@estado
						

                where cod_anx = @cod_anx"

        edit2 = "CREATE procedure [dbo].[edita_comi_desem](
                @cod_gcdesem varchar (10), /*detalle*/
                @fecha date, --fecha de registro
                @detalle varchar(100), --detalle de registro
                @monto varchar(30), -- monto de comision
                @cod_cro_anx varchar(20),--codigod e cornograma o anexo
                @gestion varchar(20) --año de creacion
                )
                as

                update GASTO_COMI_DESEM  set --cod_gcdesem=@cod_gcdesem,
							                fecha=@fecha,
							                detalle=@detalle,
							                monto=@monto,
							                cod_cro_anx=@cod_cro_anx,
							                gestion=@gestion
						

                where cod_gcdesem = @cod_gcdesem"

        edit3 = "CREATE procedure [dbo].[edita_cuo_cranx](
                    --@cod_fondo varchar (10), /*detalle*/
                    @dia1 decimal (10,5),
                    @dia2 decimal (10,5),
                    @dia3 decimal (10,5),
                    @dia4 decimal (10,5),
                    @dia5 decimal (10,5),
                    @dia6 decimal (10,5),
                    @dia7 decimal (10,5),
                    @dia8 decimal (10,5),
                    @dia9 decimal (10,5),
                    @dia10 decimal (10,5),
                    @dia11 decimal (10,5),
                    @dia12 decimal (10,5),
                    @dia13 decimal (10,5),
                    @dia14 decimal (10,5),
                    @dia15 decimal (10,5),
                    @dia16 decimal (10,5),
                    @dia17 decimal (10,5),
                    @dia18 decimal (10,5),
                    @dia19 decimal (10,5),
                    @dia20 decimal (10,5),
                    @dia21 decimal (10,5),
                    @dia22 decimal (10,5),
                    @dia23 decimal (10,5),
                    @dia24 decimal (10,5),
                    @dia25 decimal (10,5),
                    @dia26 decimal (10,5),
                    @dia27 decimal (10,5),
                    @dia28 decimal (10,5),
                    @dia29 decimal (10,5),
                    @dia30 decimal (10,5),
                    @dia31 decimal (10,5),
                    @dia32 decimal (10,5),
                    @dia33 decimal (10,5),
                    @dia34 decimal (10,5),
                    @dia35 decimal (10,5),
                    @dia36 decimal (10,5),
                    @dia37 decimal (10,5),
                    @dia38 decimal (10,5),
                    @dia39 decimal (10,5),
                    @dia40 decimal (10,5),
                    @dia41 decimal (10,5),
                    @dia42 decimal (10,5),
                    @dia43 decimal (10,5),
                    @dia44 decimal (10,5),
                    @dia45 decimal (10,5),
                    @dia46 decimal (10,5),
                    @dia47 decimal (10,5),
                    @dia48 decimal (10,5),
                    @dia49 decimal (10,5),
                    @dia50 decimal (10,5),
                    @dia51 decimal (10,5),
                    @dia52 decimal (10,5),
                    @dia53 decimal (10,5),
                    @dia54 decimal (10,5),
                    @dia55 decimal (10,5),
                    @dia56 decimal (10,5),
                    @dia57 decimal (10,5),
                    @dia58 decimal (10,5),
                    @dia59 decimal (10,5),
                    @dia60 decimal (10,5),
                    @dia61 decimal (10,5),
                    @dia62 decimal (10,5),
                    @dia63 decimal (10,5),
                    @dia64 decimal (10,5),
                    @dia65 decimal (10,5),
                    @dia66 decimal (10,5),
                    @dia67 decimal (10,5),
                    @dia68 decimal (10,5),
                    @dia69 decimal (10,5),
                    @dia70 decimal (10,5),
                    @dia71 decimal (10,5),
                    @dia72 decimal (10,5),
                    @dia73 decimal (10,5),
                    @dia74 decimal (10,5),
                    @dia75 decimal (10,5),
                    @dia76 decimal (10,5),
                    @dia77 decimal (10,5),
                    @dia78 decimal (10,5),
                    @dia79 decimal (10,5),
                    @dia80 decimal (10,5),
                    @dia81 decimal (10,5),
                    @dia82 decimal (10,5),
                    @dia83 decimal (10,5),
                    @dia84 decimal (10,5),
                    @dia85 decimal (10,5),
                    @dia86 decimal (10,5),
                    @dia87 decimal (10,5),
                    @dia88 decimal (10,5),
                    @dia89 decimal (10,5),
                    @dia90 decimal (10,5),
                    @dia91 decimal(10,5),
                    @dia92 decimal(10,5),
                    @dia93 decimal (10,5),
                    @dia94 decimal (10,5),
                    @dia95 decimal (10,5),
                    @dia96 decimal(10,5),
                    @dia97 decimal(10,5),
                    @dia98 decimal(10,5),
                    @dia99 decimal(10,5),
                    @dia100 decimal (10,5),
                    @dia101 decimal (10,5),
                    @dia102 decimal (10,5),
                    @dia103 decimal (10,5),
                    @dia104 decimal (10,5),
                    @dia105 decimal (10,5),
                    @dia106 decimal (10,5),
                    @dia107 decimal (10,5),
                    @dia108 decimal (10,5),
                    @dia109 decimal (10,5),
                    @dia110 decimal (10,5),
                    @dia111 decimal (10,5),
                    @dia112 decimal (10,5),
                    @dia113 decimal (10,5),
                    @dia114 decimal (10,5),
                    @dia115 decimal (10,5),
                    @dia116 decimal (10,5),
                    @dia117 decimal (10,5),
                    @dia118 decimal (10,5),
                    @dia119 decimal (10,5),
                    @dia120 decimal (10,5),
                    @dia121 decimal (10,5),
                    @dia122 decimal (10,5),
                    @dia123 decimal (10,5),
                    @dia124 decimal (10,5),
                    @dia125 decimal (10,5),
                    @dia126 decimal (10,5),
                    @dia127 decimal (10,5),
                    @dia128 decimal (10,5),
                    @dia129 decimal (10,5),
                    @dia130 decimal (10,5),
                    @dia131 decimal (10,5),
                    @dia132 decimal (10,5),
                    @dia133 decimal (10,5),
                    @dia134 decimal (10,5),
                    @dia135 decimal (10,5),
                    @dia136 decimal (10,5),
                    @dia137 decimal (10,5),
                    @dia138 decimal (10,5),
                    @dia139 decimal (10,5),
                    @dia140 decimal (10,5),
                    @dia141 decimal (10,5),
                    @dia142 decimal (10,5),
                    @dia143 decimal (10,5),
                    @dia144 decimal (10,5),
                    @dia145 decimal (10,5),
                    @dia146 decimal (10,5),
                    @dia147 decimal (10,5),
                    @dia148 decimal (10,5),
                    @dia149 decimal (10,5),
                    @dia150 decimal (10,5),
                    @dia151 decimal (10,5),
                    @dia152 decimal (10,5),
                    @dia153 decimal (10,5),
                    @dia154 decimal (10,5),
                    @dia155 decimal (10,5),
                    @dia156 decimal (10,5),
                    @dia157 decimal (10,5),
                    @dia158 decimal (10,5),
                    @dia159 decimal (10,5),
                    @dia160 decimal (10,5),
                    @dia161 decimal (10,5),
                    @dia162 decimal (10,5),
                    @dia163 decimal (10,5),
                    @dia164 decimal (10,5),
                    @dia165 decimal (10,5),
                    @dia166 decimal (10,5),
                    @dia167 decimal (10,5),
                    @dia168 decimal (10,5),
                    @dia169 decimal (10,5),
                    @dia170 decimal (10,5),
                    @dia171 decimal (10,5),
                    @dia172 decimal (10,5),
                    @dia173 decimal (10,5),
                    @dia174 decimal (10,5),
                    @dia175 decimal (10,5),
                    @dia176 decimal (10,5),
                    @dia177 decimal (10,5),
                    @dia178 decimal (10,5),
                    @dia179 decimal (10,5),
                    @dia180 decimal (10,5),
                    @dia181 decimal (10,5),
                    @dia182 decimal (10,5),
                    @dia183 decimal (10,5),
                    @dia184 decimal (10,5),
                    @dia185 decimal (10,5),
                    @dia186 decimal (10,5),
                    @dia187 decimal (10,5),
                    @dia188 decimal (10,5),
                    @dia189 decimal (10,5),
                    @dia190 decimal (10,5),
                    @dia191 decimal (10,5),
                    @dia192 decimal (10,5),
                    @dia193 decimal (10,5),
                    @dia194 decimal (10,5),
                    @dia195 decimal (10,5),
                    @dia196 decimal (10,5),
                    @dia197 decimal (10,5),
                    @dia198 decimal (10,5),
                    @dia199 decimal (10,5),
                    @dia200 decimal (10,5),
                    @dia201 decimal (10,5),
                    @dia202 decimal (10,5),
                    @dia203 decimal (10,5),
                    @dia204 decimal (10,5),
                    @dia205 decimal (10,5),
                    @dia206 decimal (10,5),
                    @dia207 decimal (10,5),
                    @dia208 decimal (10,5),
                    @dia209 decimal (10,5),
                    @dia210 decimal (10,5),
                    @dia211 decimal (10,5),
                    @dia212 decimal (10,5),
                    @dia213 decimal (10,5),
                    @dia214 decimal (10,5),
                    @dia215 decimal (10,5),
                    @dia216 decimal (10,5),
                    @dia217 decimal (10,5),
                    @dia218 decimal (10,5),
                    @dia219 decimal (10,5),
                    @dia220 decimal (10,5),
                    @dia221 decimal (10,5),
                    @dia222 decimal (10,5),
                    @dia223 decimal (10,5),
                    @dia224 decimal (10,5),
                    @dia225 decimal (10,5),
                    @dia226 decimal (10,5),
                    @dia227 decimal (10,5),
                    @dia228 decimal (10,5),
                    @dia229 decimal (10,5),
                    @dia230 decimal (10,5),
                    @dia231 decimal (10,5),
                    @dia232 decimal (10,5),
                    @dia233 decimal (10,5),
                    @dia234 decimal (10,5),
                    @dia235 decimal (10,5),
                    @dia236 decimal (10,5),
                    @dia237 decimal (10,5),
                    @dia238 decimal (10,5),
                    @dia239 decimal (10,5),
                    @dia240 decimal (10,5),
                    @dia241 decimal (10,5),
                    @dia242 decimal (10,5),
                    @dia243 decimal (10,5),
                    @dia244 decimal (10,5),
                    @dia245 decimal (10,5),
                    @dia246 decimal (10,5),
                    @dia247 decimal (10,5),
                    @dia248 decimal (10,5),
                    @dia249 decimal (10,5),
                    @dia250 decimal (10,5),
                    @dia251 decimal (10,5),
                    @dia252 decimal (10,5),
                    @dia253 decimal (10,5),
                    @dia254 decimal (10,5),
                    @dia255 decimal (10,5),
                    @dia256 decimal (10,5),
                    @dia257 decimal (10,5),
                    @dia258 decimal (10,5),
                    @dia259 decimal (10,5),
                    @dia260 decimal (10,5),
                    @dia261 decimal (10,5),
                    @dia262 decimal (10,5),
                    @dia263 decimal (10,5),
                    @dia264 decimal (10,5),
                    @dia265 decimal (10,5),
                    @dia266 decimal (10,5),
                    @dia267 decimal (10,5),
                    @dia268 decimal (10,5),
                    @dia269 decimal (10,5),
                    @dia270 decimal (10,5),
                    @dia271 decimal (10,5),
                    @dia272 decimal (10,5),
                    @dia273 decimal (10,5),
                    @dia274 decimal (10,5),
                    @dia275 decimal (10,5),
                    @dia276 decimal (10,5),
                    @dia277 decimal (10,5),
                    @dia278 decimal (10,5),
                    @dia279 decimal (10,5),
                    @dia280 decimal (10,5),
                    @dia281 decimal (10,5),
                    @dia282 decimal (10,5),
                    @dia283 decimal (10,5),
                    @dia284 decimal (10,5),
                    @dia285 decimal (10,5),
                    @dia286 decimal (10,5),
                    @dia287 decimal (10,5),
                    @dia288 decimal (10,5),
                    @dia289 decimal (10,5),
                    @dia290 decimal (10,5),
                    @dia291 decimal (10,5),
                    @dia292 decimal (10,5),
                    @dia293 decimal (10,5),
                    @dia294 decimal (10,5),
                    @dia295 decimal (10,5),
                    @dia296 decimal (10,5),
                    @dia297 decimal (10,5),
                    @dia298 decimal (10,5),
                    @dia299 decimal (10,5),
                    @dia300 decimal (10,5),
                    @dia301 decimal (10,5),
                    @dia302 decimal (10,5),
                    @dia303 decimal (10,5),
                    @dia304 decimal (10,5),
                    @dia305 decimal (10,5),
                    @dia306 decimal (10,5),
                    @dia307 decimal (10,5),
                    @dia308 decimal (10,5),
                    @dia309 decimal (10,5),
                    @dia310 decimal (10,5),
                    @dia311 decimal (10,5),
                    @dia312 decimal (10,5),
                    @dia313 decimal (10,5),
                    @dia314 decimal (10,5),
                    @dia315 decimal (10,5),
                    @dia316 decimal (10,5),
                    @dia317 decimal (10,5),
                    @dia318 decimal (10,5),
                    @dia319 decimal (10,5),
                    @dia320 decimal (10,5),
                    @dia321 decimal (10,5),
                    @dia322 decimal (10,5),
                    @dia323 decimal (10,5),
                    @dia324 decimal (10,5),
                    @dia325 decimal (10,5),
                    @dia326 decimal (10,5),
                    @dia327 decimal (10,5),
                    @dia328 decimal (10,5),
                    @dia329 decimal (10,5),
                    @dia330 decimal (10,5),
                    @dia331 decimal (10,5),
                    @dia332 decimal (10,5),
                    @dia333 decimal (10,5),
                    @dia334 decimal (10,5),
                    @dia335 decimal (10,5),
                    @dia336 decimal (10,5),
                    @dia337 decimal (10,5),
                    @dia338 decimal (10,5),
                    @dia339 decimal (10,5),
                    @dia340 decimal (10,5),
                    @dia341 decimal (10,5),
                    @dia342 decimal (10,5),
                    @dia343 decimal (10,5),
                    @dia344 decimal (10,5),
                    @dia345 decimal (10,5),
                    @dia346 decimal (10,5),
                    @dia347 decimal (10,5),
                    @dia348 decimal (10,5),
                    @dia349 decimal (10,5),
                    @dia350 decimal (10,5),
                    @dia351 decimal (10,5),
                    @dia352 decimal (10,5),
                    @dia353 decimal (10,5),
                    @dia354 decimal (10,5),
                    @dia355 decimal (10,5),
                    @dia356 decimal (10,5),
                    @dia357 decimal (10,5),
                    @dia358 decimal (10,5),
                    @dia359 decimal (10,5),
                    @dia360 decimal (10,5),
                    @dia361 decimal (10,5),
                    @dia362 decimal (10,5),
                    @dia363 decimal (10,5),
                    @dia364 decimal (10,5),
                    @dia365 decimal (10,5),
                    @dia366 decimal (10,5),
                    --@COD_NUMDIAS VARCHAR(10),
                    @gestion varchar(10),
                    @COD_OP VARCHAR (10),
                    @F_INICIO DATE,
                    @F_TERMINO DATE,
                    @N_DIAS_CUOTA INTEGER,
                    @MONTO_CUOTA DECIMAL (10,5),
                    @MONT_DIARIO DECIMAL (10,5),
                    @COD_CUOTA VARCHAR(10),
                    @estado varchar(20),
                    @int_d varchar(30)

                    )
                    as

                    update NUM_DIAS_CRANX  set		dia1=@dia1,
								                    dia2=@dia2 ,
								                    dia3=@dia3 ,
								                    dia4=@dia4 ,
								                    dia5=@dia5 ,
								                    dia6=@dia6 ,
								                    dia7=@dia7 ,
								                    dia8=@dia8 ,
								                    dia9=@dia9 ,
								                    dia10=@dia10 ,
								                    dia11=@dia11 ,
								                    dia12=@dia12 ,
								                    dia13=@dia13 ,
								                    dia14=@dia14 ,
								                    dia15=@dia15 ,
								                    dia16=@dia16 ,
								                    dia17=@dia17 ,
								                    dia18=@dia18 ,
								                    dia19=@dia19 ,
								                    dia20=@dia20 ,
								                    dia21=@dia21 ,
								                    dia22=@dia22 ,
								                    dia23=@dia23 ,
								                    dia24=@dia24 ,
								                    dia25=@dia25 ,
								                    dia26=@dia26 ,
								                    dia27=@dia27 ,
								                    dia28=@dia28 ,
								                    dia29=@dia29 ,
								                    dia30=@dia30 ,
								                    dia31=@dia31 ,
								                    dia32=@dia32 ,
								                    dia33=@dia33 ,
								                    dia34=@dia34 ,
								                    dia35=@dia35 ,
								                    dia36=@dia36 ,
								                    dia37=@dia37 ,
								                    dia38=@dia38 ,
								                    dia39=@dia39 ,
								                    dia40=@dia40 ,
								                    dia41=@dia41 ,
								                    dia42=@dia42 ,
								                    dia43=@dia43 ,
								                    dia44=@dia44 ,
								                    dia45=@dia45 ,
								                    dia46=@dia46 ,
								                    dia47=@dia47 ,
								                    dia48=@dia48 ,
								                    dia49=@dia49 ,
								                    dia50=@dia50 ,
								                    dia51=@dia51 ,
								                    dia52=@dia52 ,
								                    dia53=@dia53 ,
								                    dia54=@dia54 ,
								                    dia55=@dia55 ,
								                    dia56=@dia56 ,
								                    dia57=@dia57 ,
								                    dia58=@dia58 ,
								                    dia59=@dia59 ,
								                    dia60=@dia60 ,
								                    dia61=@dia61 ,
								                    dia62=@dia62 ,
								                    dia63=@dia63 ,
								                    dia64=@dia64 ,
								                    dia65=@dia65 ,
								                    dia66=@dia66 ,
								                    dia67=@dia67 ,
								                    dia68=@dia68 ,
								                    dia69=@dia69 ,
								                    dia70=@dia70 ,
								                    dia71=@dia71 ,
								                    dia72=@dia72 ,
								                    dia73=@dia73 ,
								                    dia74=@dia74 ,
								                    dia75=@dia75 ,
								                    dia76=@dia76 ,
								                    dia77=@dia77 ,
								                    dia78=@dia78 ,
								                    dia79=@dia79 ,
								                    dia80=@dia80 ,
								                    dia81=@dia81 ,
								                    dia82=@dia82 ,
								                    dia83=@dia83 ,
								                    dia84=@dia84 ,
								                    dia85=@dia85 ,
								                    dia86=@dia86 ,
								                    dia87=@dia87 ,
								                    dia88=@dia88 ,
								                    dia89=@dia89 ,
								                    dia90=@dia90 ,
								                    dia91=@dia91 ,
								                    dia92=@dia92 ,
								                    dia93=@dia93 ,
								                    dia94=@dia94 ,
								                    dia95=@dia95 ,
								                    dia96=@dia96 ,
								                    dia97=@dia97 ,
								                    dia98=@dia98 ,
								                    dia99=@dia99 ,
								                    dia100=@dia100 ,
								                    dia101=@dia101 ,
								                    dia102=@dia102 ,
								                    dia103=@dia103 ,
								                    dia104=@dia104 ,
								                    dia105=@dia105 ,
								                    dia106=@dia106 ,
								                    dia107=@dia107 ,
								                    dia108=@dia108 ,
								                    dia109=@dia109 ,
								                    dia110=@dia110 ,
								                    dia111=@dia111 ,
								                    dia112=@dia112 ,
								                    dia113=@dia113 ,
								                    dia114=@dia114 ,
								                    dia115=@dia115 ,
								                    dia116=@dia116 ,
								                    dia117=@dia117 ,
								                    dia118=@dia118 ,
								                    dia119=@dia119 ,
								                    dia120=@dia120 ,
								                    dia121=@dia121 ,
								                    dia122=@dia122 ,
								                    dia123=@dia123 ,
								                    dia124=@dia124 ,
								                    dia125=@dia125 ,
								                    dia126=@dia126 ,
								                    dia127=@dia127 ,
								                    dia128=@dia128 ,
								                    dia129=@dia129 ,
								                    dia130=@dia130 ,
								                    dia131=@dia131 ,
								                    dia132=@dia132 ,
								                    dia133=@dia133 ,
								                    dia134=@dia134 ,
								                    dia135=@dia135 ,
								                    dia136=@dia136 ,
								                    dia137=@dia137 ,
								                    dia138=@dia138 ,
								                    dia139=@dia139 ,
								                    dia140=@dia140 ,
								                    dia141=@dia141 ,
								                    dia142=@dia142 ,
								                    dia143=@dia143 ,
								                    dia144=@dia144 ,
								                    dia145=@dia145 ,
								                    dia146=@dia146 ,
								                    dia147=@dia147 ,
								                    dia148=@dia148 ,
								                    dia149=@dia149 ,
								                    dia150=@dia150 ,
								                    dia151=@dia151 ,
								                    dia152=@dia152 ,
								                    dia153=@dia153 ,
								                    dia154=@dia154 ,
								                    dia155=@dia155 ,
								                    dia156=@dia156 ,
								                    dia157=@dia157 ,
								                    dia158=@dia158 ,
								                    dia159=@dia159 ,
								                    dia160=@dia160 ,
								                    dia161=@dia161 ,
								                    dia162=@dia162 ,
								                    dia163=@dia163 ,
								                    dia164=@dia164 ,
								                    dia165=@dia165 ,
								                    dia166=@dia166 ,
								                    dia167=@dia167 ,
								                    dia168=@dia168 ,
								                    dia169=@dia169 ,
								                    dia170=@dia170 ,
								                    dia171=@dia171 ,
								                    dia172=@dia172 ,
								                    dia173=@dia173 ,
								                    dia174=@dia174 ,
								                    dia175=@dia175 ,
								                    dia176=@dia176 ,
								                    dia177=@dia177 ,
								                    dia178=@dia178 ,
								                    dia179=@dia179 ,
								                    dia180=@dia180 ,
								                    dia181=@dia181 ,
								                    dia182=@dia182 ,
								                    dia183=@dia183 ,
								                    dia184=@dia184 ,
								                    dia185=@dia185 ,
								                    dia186=@dia186 ,
								                    dia187=@dia187 ,
								                    dia188=@dia188 ,
								                    dia189=@dia189 ,
								                    dia190=@dia190 ,
								                    dia191=@dia191 ,
								                    dia192=@dia192 ,
								                    dia193=@dia193 ,
								                    dia194=@dia194 ,
								                    dia195=@dia195 ,
								                    dia196=@dia196 ,
								                    dia197=@dia197 ,
								                    dia198=@dia198 ,
								                    dia199=@dia199 ,
								                    dia200=@dia200 ,
								                    dia201=@dia201 ,
								                    dia202=@dia202 ,
								                    dia203=@dia203 ,
								                    dia204=@dia204 ,
								                    dia205=@dia205 ,
								                    dia206=@dia206 ,
								                    dia207=@dia207 ,
								                    dia208=@dia208 ,
								                    dia209=@dia209 ,
								                    dia210=@dia210 ,
								                    dia211=@dia211 ,
								                    dia212=@dia212 ,
								                    dia213=@dia213 ,
								                    dia214=@dia214 ,
								                    dia215=@dia215 ,
								                    dia216=@dia216 ,
								                    dia217=@dia217 ,
								                    dia218=@dia218 ,
								                    dia219=@dia219 ,
								                    dia220=@dia220 ,
								                    dia221=@dia221 ,
								                    dia222=@dia222 ,
								                    dia223=@dia223 ,
								                    dia224=@dia224 ,
								                    dia225=@dia225 ,
								                    dia226=@dia226 ,
								                    dia227=@dia227 ,
								                    dia228=@dia228 ,
								                    dia229=@dia229 ,
								                    dia230=@dia230 ,
								                    dia231=@dia231 ,
								                    dia232=@dia232 ,
								                    dia233=@dia233 ,
								                    dia234=@dia234 ,
								                    dia235=@dia235 ,
								                    dia236=@dia236 ,
								                    dia237=@dia237 ,
								                    dia238=@dia238 ,
								                    dia239=@dia239 ,
								                    dia240=@dia240 ,
								                    dia241=@dia241 ,
								                    dia242=@dia242 ,
								                    dia243=@dia243 ,
								                    dia244=@dia244 ,
								                    dia245=@dia245 ,
								                    dia246=@dia246 ,
								                    dia247=@dia247 ,
								                    dia248=@dia248 ,
								                    dia249=@dia249 ,
								                    dia250=@dia250 ,
								                    dia251=@dia251 ,
								                    dia252=@dia252 ,
								                    dia253=@dia253 ,
								                    dia254=@dia254 ,
								                    dia255=@dia255 ,
								                    dia256=@dia256 ,
								                    dia257=@dia257 ,
								                    dia258=@dia258 ,
								                    dia259=@dia259 ,
								                    dia260=@dia260 ,
								                    dia261=@dia261 ,
								                    dia262=@dia262 ,
								                    dia263=@dia263 ,
								                    dia264=@dia264 ,
								                    dia265=@dia265 ,
								                    dia266=@dia266 ,
								                    dia267=@dia267 ,
								                    dia268=@dia268 ,
								                    dia269=@dia269 ,
								                    dia270=@dia270 ,
								                    dia271=@dia271 ,
								                    dia272=@dia272 ,
								                    dia273=@dia273 ,
								                    dia274=@dia274 ,
								                    dia275=@dia275 ,
								                    dia276=@dia276 ,
								                    dia277=@dia277 ,
								                    dia278=@dia278 ,
								                    dia279=@dia279 ,
								                    dia280=@dia280 ,
								                    dia281=@dia281 ,
								                    dia282=@dia282 ,
								                    dia283=@dia283 ,
								                    dia284=@dia284 ,
								                    dia285=@dia285 ,
								                    dia286=@dia286 ,
								                    dia287=@dia287 ,
								                    dia288=@dia288 ,
								                    dia289=@dia289 ,
								                    dia290=@dia290 ,
								                    dia291=@dia291 ,
								                    dia292=@dia292 ,
								                    dia293=@dia293 ,
								                    dia294=@dia294 ,
								                    dia295=@dia295 ,
								                    dia296=@dia296 ,
								                    dia297=@dia297 ,
								                    dia298=@dia298 ,
								                    dia299=@dia299 ,
								                    dia300=@dia300 ,
								                    dia301=@dia301 ,
								                    dia302=@dia302 ,
								                    dia303=@dia303 ,
								                    dia304=@dia304 ,
								                    dia305=@dia305 ,
								                    dia306=@dia306 ,
								                    dia307=@dia307 ,
								                    dia308=@dia308 ,
								                    dia309=@dia309 ,
								                    dia310=@dia310 ,
								                    dia311=@dia311 ,
								                    dia312=@dia312 ,
								                    dia313=@dia313 ,
								                    dia314=@dia314 ,
								                    dia315=@dia315 ,
								                    dia316=@dia316 ,
								                    dia317=@dia317 ,
								                    dia318=@dia318 ,
								                    dia319=@dia319 ,
								                    dia320=@dia320 ,
								                    dia321=@dia321 ,
								                    dia322=@dia322 ,
								                    dia323=@dia323 ,
								                    dia324=@dia324 ,
								                    dia325=@dia325 ,
								                    dia326=@dia326 ,
								                    dia327=@dia327 ,
								                    dia328=@dia328 ,
								                    dia329=@dia329 ,
								                    dia330=@dia330 ,
								                    dia331=@dia331 ,
								                    dia332=@dia332 ,
								                    dia333=@dia333 ,
								                    dia334=@dia334 ,
								                    dia335=@dia335 ,
								                    dia336=@dia336 ,
								                    dia337=@dia337 ,
								                    dia338=@dia338 ,
								                    dia339=@dia339 ,
								                    dia340=@dia340 ,
								                    dia341=@dia341 ,
								                    dia342=@dia342 ,
								                    dia343=@dia343 ,
								                    dia344=@dia344 ,
								                    dia345=@dia345 ,
								                    dia346=@dia346 ,
								                    dia347=@dia347 ,
								                    dia348=@dia348 ,
								                    dia349=@dia349 ,
								                    dia350=@dia350 ,
								                    dia351=@dia351 ,
								                    dia352=@dia352 ,
								                    dia353=@dia353 ,
								                    dia354=@dia354 ,
								                    dia355=@dia355 ,
								                    dia356=@dia356 ,
								                    dia357=@dia357 ,
								                    dia358=@dia358 ,
								                    dia359=@dia359 ,
								                    dia360=@dia360 ,
								                    dia361=@dia361 ,
								                    dia362=@dia362 ,
								                    dia363=@dia363 ,
								                    dia364=@dia364 ,
								                    dia365=@dia365 ,
								                    dia366=@dia366 ,
								                    --cod_numdias=@COD_NUMDIAS,
								                    gestion=@gestion ,
								                    cod_op=@COD_OP ,
								                    f_inicio=@F_INICIO ,
								                    f_termino=@F_TERMINO ,
								                    n_dias_cuota=@N_DIAS_CUOTA ,
								                    monto_cuota=@MONTO_CUOTA ,
								                    mont_diario=@MONT_DIARIO,
								                    cod_cuota=@COD_CUOTA,
								                    estado=@estado,
								                    inte_diario=@int_d 

                    where cod_cuota = @COD_CUOTA"

        edit4 = "CREATE procedure [dbo].[edita_cuota_ope](
                @codigo varchar (10), -- codigo de cuota
                @cod_op varchar(10), --codigo de operacion
                @cap_inicial varchar(30), --capital inicial
                @amortizacion varchar(30), -- monto de amortazacion
                @cap_final varchar(30),--capital final
                @interes varchar(30), --interes
                @igv varchar(30), --igv
                @t_cuota varchar(30), --total de cuota
                @dias int,
                @f_venci date,
                @fecha date,
                @gestion varchar(10),
                @estado varchar(20)
                )
                as

                update cuotas_operacion  set cod_cuota=@codigo,
							                cod_op=@cod_op,
							                cap_inicial=@cap_final,
							                amortizacion=@amortizacion,
							                cap_final=@cap_final,
							                interes=@interes,
							                igv=@igv,
							                t_cuota=@t_cuota,
							                dias=@dias,
							                f_venci=@f_venci,
							                fecha=@fecha,
							                gestion=@gestion,
							                estado=@estado
						

                where cod_cuota = @codigo"

        edit5 = "CREATE procedure [dbo].[edita_d_mancumunado](
                @nc varchar(10), -- codigo
                @nom_manc varchar (100),--nombre de participe
                @f_ingreso date, --fecha de ingreso
                @f_salida date --fecha de salida

                )
                as

                update d_mancumunado set nom_mac=@nom_manc,
						                f_ingreso=@f_ingreso,
						                f_salida=@f_salida
						

                where cod_manc= @nc or nom_mac=@nc "

        edit6 = "CREATE procedure [dbo].[edita_d_operacion](
                @cod_op varchar (10),
                @cod_clie varchar (10), --codigo de distribucion de benefecio
                @cod_gcdesem varchar(10), --codigo de 
                @cod_cuop varchar(10), -- codigo de cuota de operacion
                @tip_op varchar(20),--tipo de operacion
                @m_solic varchar(30), --monto solicitado
                @porc_comi_dese  varchar(30),-- porcentaje de comision de desembolso
                @mon_comi_dese varchar(30),---monto comision de desembolso
                @por_igv varchar(30), -- porcentaje de igv
                @mont_igv varchar(30), -- monto de igv
                @mont_prestamo varchar(30),
                @porc_inte varchar(30), -- porcentaje de interes
                @mon_inte varchar(30), --monto de interes
                @f_inicio_pres date, --fecha de inicio de prestamo
                @f_termino_pres date,-- fecha de termino del prestamo
                @cod_gestion varchar (10), --codgestion
                @estado varchar(20)
                )
                as

                update d_operacion  set cod_op=@cod_op,
						                cod_clie=@cod_clie,
						                cod_gcdesem=@cod_gcdesem,
						                cod_cuop=@cod_cuop,
						                tip_op=@tip_op,
						                m_solic=@m_solic,
						                porc_comi_dese=@porc_comi_dese,
						                mon_comi_dese=@mon_comi_dese,
						                por_igv=@por_igv,
						                mont_igv=@mont_igv,
						                mont_prestamo=@mont_prestamo,
						                porc_inte=@porc_inte,
						                mon_inte=@mon_inte,
						                f_inicio_pres=@f_inicio_pres,
						                f_termino_pres=@f_termino_pres,
						                cod_gest=@cod_gestion,
						                estado=@estado			

                where cod_op = @cod_op"

        edit7 = "CREATE procedure [dbo].[edita_d_participacion](
                @nc varchar (10), /*detalle*/
                @cod_parti varchar (10), --codigo de participe
                @cod_manc varchar(10), --codigo de mancomunado
                @cod_certi varchar(10),--codigo de certificado
                @cod_fondo varchar(10),--codigo de fondo
                @f_ingreso date, --fecha de ingreso
                @gestion varchar(10), -- gestion de ingreso
                @tip_parti varchar(10),-- tipo de participacion
                @mont_part decimal(10,5),---monto de participacion
                @n_parti decimal(10,5), -- numero de participacion
                @v_cuot_actu decimal(10,5), -- valor de cuoita actual
                @f_salida date, -- fecha de salida del fondo
                @nom_parti varchar(256), --nombre de participe
                @nom_maco varchar(256), --nombre de mancomunado
                @nom_fondo varchar(256) --nombre de fondo
                )
                as

                update d_participacion set cod_parti=@cod_parti,
						                cod_manc=@cod_manc,
						                cod_certi=@cod_certi,
						                cod_fondo=@cod_fondo,
						                f_ingreso=@f_ingreso,
						                cod_gest=@gestion,
						                tip_part=@tip_parti,
						                mont_part=@mont_part,
						                n_parti=@n_parti,
						                v_cuota_actual=@v_cuot_actu,
						                f_salida=@f_salida,
						                nom_parti=@nom_parti,
						                nom_manco=@nom_maco,
						                nom_fondo=@nom_fondo
					

												

                where cod_part= @nc"

        edit8 = "CREATE procedure [dbo].[edita_d_participe](
                @nc varchar (10),/*nocontrol*/
                @cod_clie_bdp varchar (10), /*detalle*/
                @nom varchar (100), --nombre de participe,
                @ap_pat varchar (100),--appellido paterno participe
                @ap_mat varchar (100),--apellido materno 
                @tip_doc varchar (50), --tipo de documento
                @n_doc varchar (100), --numero de documento
                @direc varchar (200),--direccion del participe
                @correo varchar (100),-- correo electronico
                @f_ingreso date, --fecha de ingreso
                @f_salida date --fecha de salida
                )
                as

                update da_participe set cod_clie_bdp=@cod_clie_bdp,
						                nom=@nom,
						                ap_pat=@ap_pat,
						                ap_mat=@ap_mat,
						                tip_doc=@tip_doc,
						                n_docu=@n_doc,
						                direc=@direc,
						                correo=@correo,
						                f_ingreso=@f_ingreso,
						                f_salida=@f_salida

                where cod_parti= @nc or cod_clie_bdp=@nc or n_docu=@nc"

        edit9 = "CREATE procedure [dbo].[edita_datos_cuenta](
                --@cod_manc varchar (10), /*detalle*/
                @nc varchar(10),---codigo de fondo
                @cod_ban varchar (10), --codigo de banco
                @tipo_cuenta varchar(10), --tipo de cuenta
                @n_cuenta varchar(100),--numero de cuenta
                @n_cci varchar(100), -- numero de cci de la cuenta
                @mon_cuenta varchar(10), --moneda de la cuenta
                @cod_parti varchar(10),--codigo de participe
                @cod_clie varchar(10),-- codigo de cliente
                @cod_provee varchar(10),--codigo de proveedor
                @cod_fondo varchar (10), --codigo de fondo
                @nom_parti varchar (256),
                @nom_clie varchar (256),
                @nom_proveedor varchar (256),
                @nom_fondo varchar (256),
                @cod_manc varchar (10),
                @nom_manc varchar (256)


                )
                as

                update datos_cuenta set cod_ban=@cod_ban,
						                tipo_cuenta=@tipo_cuenta,
						                n_cuenta=@n_cuenta,
						                n_cci=@n_cci,
						                mon_cuenta=@mon_cuenta,
						                cod_parti=@cod_parti,
						                cod_clie=@cod_clie,
						                cod_provee=@cod_provee,
						                cod_fondo=@cod_fondo,
						                nom_parti=@nom_parti,
						                nom_clie=@nom_clie,
						                nom_proveedor=@nom_proveedor,
						                nom_fondo=@nom_fondo,
						                nom_manc=@nom_manc,
						                cod_manc=@cod_manc
						

                where cod_cuenta= @nc or n_cuenta=@n_cuenta"

        edit10 = "CREATE procedure [dbo].[edita_datos_fondo](
                @cod_fondo varchar (10), /*detalle*/
                @cod_di varchar (10), --codigo de distribucion de benefecio
                @n_fondo varchar(25), --nombre de fondo
                @moneda varchar(20), -- moneda
                @mont_minimo decimal(20,5),--codigo de certificado
                @mont_maximo decimal(20,5), --fecha de ingreso
                @capital_actual decimal(20,5), -- capital actual
                @unidad_negocio  varchar(100),-- tipo de participacion)
                @f_creacion date,---monto de participacion
                @f_ins_sunat date, -- fecha de inscripcion a sunat
                @nu_ruc int, -- numero de ruc
                @f_ini_opera date, -- fechad e inicio de operaciones
                @f_ter_opera date, --fecha de termino de operaciones
                @valor_cuota_nom decimal (20,5), --valor de cuota nominal
                @valor_cuota_actual decimal (20,5), --valor de cuota actual
                @cod_gest varchar (10),
                @fecha date, --fecha actual
                @patri decimal(30,5)
                )
                as

                update DATOS_FONDO set COD_FONDO=@cod_fondo,
						                COD_DI=@cod_di,
						                N_FONDO=@n_fondo,
						                MONEDA=@moneda,
						                MONT_MINIMO=@mont_minimo,
						                MONT_MAXIMO=@mont_maximo,
						                CAPITAL_ACTUAL=@capital_actual,
						                UNIDAD_NEGOCIO=@unidad_negocio,
						                F_CREACION=@f_creacion,
						                F_INS_SUNAT=@f_ins_sunat,
						                NU_RUC=@nu_ruc,
						                F_INI_OPERA=@f_ini_opera,
						                F_TER_OPERA=@f_ter_opera,
						                VALOR_CUOTA_NOM=@valor_cuota_nom,
						                VALOR_CUOTA_ACTUAL=@valor_cuota_actual,
						                cod_gest=@cod_gest,
						                fecha=@fecha,
						                patrimonio=@patri
					

												

                where fecha = @fecha"

        edit11 = "CREATE procedure [dbo].[edita_dest_beneficio](
                --@cod_manc varchar (10), /*detalle*/
                @nc varchar (10), --variable de busqueda
                @distribucion varchar (50), --distribucion
                @n_distrib int, --numero de distribucion
                @cod_gest varchar(10),--codigo de gestion
                @n_dias integer

                )
                as

                update dist_beneficio set cod_di=@nc,
						                distribucion=@distribucion,
						                n_distrib=@n_distrib,
						                cod_gest=@cod_gest,
						                n_dias=@n_dias
					

												

                where cod_di= @nc or n_distrib=@nc"

        edit12 = "CREATE procedure [dbo].[edita_fac_anx_ope](
                @cod_fac_anx varchar(10),
                @cod_anexo varchar(10),
                @cod_clie varchar(10),
                @comi_mini_trans varchar(30),
                @porc_detrac varchar(30),
                @porc_descu varchar(30),
                @porc_int_cobra varchar(30),
                @porc_igv varchar(30),
                @n_documento varchar(100),
                @fec_venc_doc date, --fecha de operacion
                @fec_recep_doc date, --gestion
                @num_dias_fact varchar(10),
                @girador varchar(250),
                @aceptante varchar(250),
                @mont_fact varchar(30),
                @mont_detrac varchar(30),
                @mont_neto varchar(30),
                @mont_descu varchar(30),
                @mont_int_cob varchar(30),
                @mont_igv varchar(30),
                @abono varchar(30),
                @porc_comi varchar(30),
                @igv_comi  varchar(30),
                @gestion varchar(10),
                @estado varchar(20),
                @int_d varchar(30),
                @refe varchar(10)

                )

                as

                update fac_operacion_anx  set cod_anexo=@cod_anexo,
								                cod_clie=@cod_clie ,
								                comi_min_tranfs=@comi_mini_trans ,
								                porc_detrac=@porc_detrac ,
								                porc_descu=@porc_descu ,
								                porc_int_cobra=@porc_int_cobra ,
								                porc_igv=@porc_igv ,
								                n_document=@n_documento ,
								                fec_venc_doc=@fec_venc_doc,
								                fec_recep_doc=@fec_recep_doc ,
								                num_dias_fact=@num_dias_fact ,
								                girador=@girador ,
								                aceptante=@aceptante ,
								                mont_fact=@mont_fact ,
								                mont_detrac=@mont_detrac,
								                mon_neto=@mont_neto ,
								                mont_descu=@mont_descu ,
								                mont_int_cob=@mont_int_cob ,
								                mont_igv=@mont_igv ,
								                abono=@abono,
								                porc_comi_min=@porc_comi,
								                igv_comi=@igv_comi,
								                gestion=@gestion,
								                estado=@estado,
								                int_dia=@int_d,
								                refe=@refe


                where cod_fac_anx = @cod_fac_anx"

        edit13 = "CREATE procedure [dbo].[edita_hisotrial](
                @codigo varchar(10),
                @cod_opcraanx varchar(10),
                @cod_cufeacdia varchar(10),
                @fecha date,
                @f_inicio date,
                @f_fin date,
                @n_finicio date,
                @n_ftermino date,
                @monto decimal(15,5),
                @montof decimal(15,5), --fecha de operacion
                @referencia varchar(250), --gestion
                @coment varchar(250),
                @interes varchar(30),
                @igv_interes varchar(30),
                @comision varchar(30),
                @igv_comi varchar(30),
                @int_diario varchar(30)

                )
                as

                update historial  set		cod_his=@codigo,
							                cod_opcranx=@cod_opcraanx,
							                cod_cufacdia=@cod_cufeacdia,
							                fecha=@fecha,
							                f_inicio=@f_inicio,
							                f_fin=@f_fin,
							                n_finicio=@n_finicio,
							                n_ftermino=@n_ftermino,
							                monto=@monto,
							                montof=@montof,
							                referencia=@referencia,
							                coment=@coment,
							                interes=@interes,
							                igv_interes=@igv_interes,
							                comi_tran=@comision,
							                igv_comi_tran=@igv_comi,
							                inte_diario=@int_diario
						

                where cod_his = @codigo"

        edit14 = "CREATE procedure [dbo].[edita_part_mancumunados](
                @nc varchar(10), -- codigo
                @cod_manc varchar (10),--codigo de mancumunado
                @nom_parti varchar (100),--nombre de participe
                @appat varchar (100), --apelldio paterno
                @apmat varchar (100), --apellido materno
                @t_doc varchar (50),
                @n_doc varchar (100),
                @f_ingreso date, --fecha de ingreso
                @f_salida date, --fecha de salida
                @cod_parti varchar(10),
                @tip_parti varchar(20)
                )
                as

                update participes_mancumunados set cod_manc=@cod_manc,
						                nom_part=@nom_parti,
						                appat=@appat,
						                apmat=@apmat,
						                t_doc=@t_doc,
						                n_doc=@n_doc,
						                f_ingreso=@f_ingreso,
						                f_salida=@f_salida,
						                cod_parti=@cod_parti,
						                tip_parti=@tip_parti

						

                --where cod_manc= @cod_manc and n_doc=@n_doc and cod_parti=@cod_parti
                where cod_parti=@cod_parti"

        edit15 = "CREATE procedure [dbo].[edita_reg_banco](
                @nc varchar(10), -- codigo
                @n_ban varchar (100),--nombre de banco
                @ruc int--ruc de banco


                )
                as

                update reg_banco set n_banco=@n_ban,
						                ruc=@ruc
												

                where n_banco= @nc and ruc=@nc "

        edit16 = "create procedure [dbo].[edita_reg_califcliente](
                    --@cod_manc varchar (10), /*detalle*/
                    @nc varchar (10), --variable de busqueda
                    @cod_clie varchar (10), --codigo de cliente
                    @estado varchar(100), --seguimiento de estado
                    @aprob varchar(50),--aprobacion
                    @sub_doc varchar(50), -- subir documento,
					@ruta varchar(256)


                    )
                    as

                    update d_calif_clie set cod_clie=@cod_clie,
						                    estado=@estado,
						                    aprob=@aprob,
						                    sub_doc=@sub_doc,
											ruta=@ruta
					

												

                    where cod_cali= @nc"

        edit17 = "CREATE procedure [dbo].[edita_reg_cliente](
                --@cod_manc varchar (10), /*detalle*/
                @nc varchar (10), --variable de busqueda
                @cod_clien_bdp varchar (10), --codigo de bd datos principal
                @nom varchar(100), --nombre de cliente
                @appat varchar(100),--apellido paterno
                @apmat varchar(100), -- apellido materno
                @tip_doc varchar(100), --tipo de documento
                @n_doc varchar (50) --numero de documento

                )
                as

                update d_clientes set	cod_clie=@nc,
						                cod_clien_bdp=@cod_clien_bdp,
						                nom=@nom,
						                ap_pater=@appat,
						                ap_mater=@apmat,
						                tip_doc=@tip_doc,
						                n_doc=@n_doc

												

                where nom= @nc"

        edit18 = "create procedure [dbo].[edita_datos_fondos](
                    /*@nc varchar (10),/*nocontrol*/*/
                    @cod_fondo varchar (10), /*detalle*/
                    @nom_fondo varchar (256), --nombre de fondo
                    @vcn decimal(20,5), --valor cuota nominal
                    @vca decimal (20,5), -- valor cuota actual
                    @capital decimal(20,5), -- capital del fondo
                    @capital_actual decimal(20,5), --capital actual
                    @fecha date,
                    @moneda varchar(20)
                     )
                    as
                    update datos_fondos set cod_fondo=@cod_fondo,
						nom_fondo=@nom_fondo,
						vcn=@vcn,
						vca=@vca,
						capital=@capital,
						capital_actual=@capital_actual,
						fecha=@fecha,
						moneda=@moneda
                    where cod_fondo=@cod_fondo"

        bor1 = "create procedure [dbo].[borra_anexo](
                @nc varchar (20)

                )
                as
                delete from d_operacion_anx
                where cod_anx=@nc"

        bor2 = "create procedure [dbo].[borra_comi_desem](
                @nc varchar (20)

                )
                as
                delete from GASTO_COMI_DESEM
                where cod_gcdesem=@nc"

        bor3 = "create procedure [dbo].[borra_cuo_cranx](
                @nc varchar (20)

                )
                as
                delete from num_dias_cranx
                where cod_numdias=@nc"

        bor4 = "create procedure [dbo].[borra_cuota](
                @nc varchar (20)

                )
                as
                delete from cuotas_operacion
                where cod_op=@nc or cod_cuota=@nc"

        bor5 = "create procedure [dbo].[borra_d_operacion](
                @nc varchar (20)

                )
                as
                delete from d_operacion
                where cod_op=@nc"

        bor6 = "create procedure [dbo].[borra_d_participacion](
                @nc varchar (100)

                )
                as
                delete from d_participacion
                where cod_part=@nc"

        bor7 = "create procedure [dbo].[borra_datos_cuenta](
                @nc varchar (100)

                )
                as
                delete from datos_cuenta
                where cod_cuenta=@nc or n_cuenta=@nc "

        bor8 = "create procedure [dbo].[borra_datos_fondo](
                @nc date

                )
                as
                delete from DATOS_FONDO
                where fecha=@nc"

        bor9 = "create procedure [dbo].[borra_dist_beneficio](
                @nc varchar (100)

                )
                as
                delete from dist_beneficio
                where cod_di=@nc or n_distrib=@nc "

        bor10 = "create procedure [dbo].[borra_fac_anexo](
                @nc varchar (20)

                )
                as
                delete from fac_operacion_anx
                where cod_fac_anx=@nc"


        bor11 = "create procedure [dbo].[borra_historial](
                @nc varchar (20)

                )
                as
                delete from hsitorial
                where cod_his=@nc"

        bor12 = "create procedure [dbo].[borra_mancomunado](
                @nc varchar (100)
                )
                as
                delete   from d_mancumunado
                where cod_manc=@nc
                delete from participes_mancumunados 
                where cod_manc=@nc"

        bor13 = "create procedure [dbo].[borra_parti_mancomunado](
                @nc varchar (100),
                @n_doc varchar (100)
                )
                as
                delete from participes_mancumunados
                where cod_manc=@nc and n_doc=@n_doc"

        bor14 = "create procedure [dbo].[borra_participe](
                @nc varchar (100)
                )
                as
                delete from da_participe
                where cod_parti=@nc or nom=@nc or n_docu=@nc
                "

        bor15 = "create procedure [dbo].[borra_reg_banco](
                @nc varchar (100)

                )
                as
                delete from reg_banco
                where cod_ban=@nc"

        bor16 = "create procedure [dbo].[borra_reg_califcliente](
                @nc varchar (100)

                )
                as
                delete from d_calif_clie
                where cod_clie=@nc or cod_cali=@nc "

        bor17 = "create procedure [dbo].[borra_reg_cliente](
                @nc varchar (100)

                )
                as
                delete from d_clientes
                where cod_clie=@nc or nom=@nc or ap_pater=@nc or n_doc=@nc"

        ver1 = "create procedure [dbo].[ver_anx_ope](
                @nc varchar(20)

                )

                as
                select *from d_operacion_anx
                where cod_anx=@nc"

        ver2 = "create procedure [dbo].[ver_comi_desem](
                @nc varchar(20)

                )

                as
                select *from GASTO_COMI_DESEM
                where cod_cro_anx=@nc"

        ver3 = "create procedure [dbo].[ver_couta_ope](
                @nc varchar(20)

                )

                as
                select *from cuotas_operacion
                where cod_cuota=@nc or cod_op=@nc"

        ver4 = "create procedure [dbo].[ver_d_mancumunado](
                @nc varchar (100)
                )

                as
                select *from d_mancumunado
                where cod_manc=@nc or nom_mac=@nc"

        ver5 = "create procedure [dbo].[ver_d_operacion](
                @nc varchar(20)

                )

                as
                select *from d_operacion
                where cod_op=@nc"

        ver6 = "create procedure [dbo].[ver_d_participacion](
                @nc varchar (100)

                )

                as
                select *from d_participacion
                where cod_part=@nc"

        ver7 = "create procedure [dbo].[ver_da_participe](
                @nc varchar (100)
                )

                as
                select *from da_participe
                where cod_parti=@nc or n_docu=@nc or nom=@nc"

        ver8 = "create procedure [dbo].[ver_datos_cuenta](
                @nc varchar (100)

                )

                as
                select *from datos_cuenta
                where cod_cuenta=@nc or n_cuenta=@nc "

        ver9 = "create procedure [dbo].[ver_datos_fondos](
                @nc date

                )

                as
                select *from DATOS_FONDO
                where fecha=@nc"

        ver10 = "create procedure [dbo].[ver_dist_beneficio](
                @nc varchar (100)

                )

                as
                select *from dist_beneficio
                where cod_di=@nc or n_distrib=@nc "

        ver11 = "create procedure [dbo].[ver_fac_anx_ope](
                @nc varchar(20),
                @n_doc varchar(20),
                @aceptante varchar(250)

                )

                as
                select *from fac_operacion_anx
                where cod_fac_anx=@nc and n_document=@n_doc and aceptante=@aceptante"

        ver12 = "create procedure [dbo].[ver_historial](
                @nc varchar(20)

                )

                as
                select *from historial
                where cod_his=@nc or cod_opcranx=@nc or cod_cufacdia=@nc"

        ver12 = "create procedure [dbo].[ver_numdias_cranx](
                @nc varchar(20)

                )

                as
                select *from NUM_DIAS_CRANX
                where cod_numdias=@nc or cod_op=@nc or cod_cuota=@nc"

        ver13 = "create procedure [dbo].[ver_part_mancumunado](
                @nc varchar (100)
                )

                as
                select *from participes_mancumunados
                where cod_manc=@nc or n_doc=@nc or cod_parti=@nc"

        ver14 = "create procedure [dbo].[ver_parti_mancumunado](
                @nc varchar (100),
                @n_doc varchar (100),
                @cod_parti varchar(10)

                )

                as
                select *from participes_mancumunados
                where cod_manc=@nc and n_doc=@n_doc and cod_parti=@cod_parti"

        ver15 = "create procedure [dbo].[ver_reg_banco](
                @nc varchar (100)

                )

                as
                select *from reg_banco
                where cod_ban=@nc"

        ver16 = "create procedure [dbo].[ver_reg_califcliente](
                @nc varchar (100)

                )

                as
                select *from d_calif_clie
                where cod_clie=@nc or cod_cali=@nc "

        ver17 = "create procedure [dbo].[ver_reg_cliente](
                @nc varchar (100)

                )

                as
                select *from d_clientes
                where cod_clien_bdp=@nc or n_doc=@nc or ap_pater=@nc or cod_clie=@nc"


        vis1 = "create VIEW v_da_participe as select cod_parti as [CODIGO PARTICIPE], nom as [NOMBRE DE PARTICIPE], ap_pat as [APELLIDO PATERNO], ap_mat AS [APELLIDO MATERNO], tip_doc AS [TIPO DE DOCUMENTO], n_docu AS [NUMERO DE DOCUMENTO], direc AS [DOMICILIO], correo AS [CORREO ELECTRONICO], f_ingreso AS [FECHA DE INGRESO], f_salida AS [FECHA DE SALIDA] from da_participe"

        vis2 = "create view v_d_mancumunado as select cod_manc as [CODIGO DE MANCOMUNADO], nom_mac as [NOMBRE DE MANCOMUNADO], f_ingreso AS [FECHA DE INGRESO], f_salida AS [FECHA DE SALIDA] from d_mancumunado"

        vis3 = "create view v_part_mancumunado as SELECT        cod_manc AS [CODIGO DE MANCOMUNADO], nom_part AS [NOMBRE DE PARTICIPE], appat AS [APELLIDO PATERNO], apmat AS [APELLIDO MATERNO], t_doc AS [TIPO DE DOCUMENTO], n_doc AS [NUMERO DE DOCUMENTO], 
                         f_ingreso AS [FECHA DE INGRESO], f_salida AS [FECHA DE SALIDA], cod_parti AS [CODIGO DE PARTICIPE], tip_parti AS [TITULAR O MANCOMUNO]
FROM            dbo.participes_mancumunados"

        vis4 = "create view v_reg_banco as select cod_ban as [CODIGO DE BANCO], n_banco as [NOMBRE DE BANCO], ruc as [RUC] from reg_banco"
        vis5 = "create view v_reg_cliente as select cod_clie as [CODIGO DE CLIENTE], cod_clien_bdp as [CODIGO DE BDP], nom as [NOMBRE], ap_pater as [APELLIDO PATERNO], ap_mater as [APELLIDO MATERNO], tip_doc as [TIPO DE DOCUMENTO],n_doc as [NUMERO DE DOCUMENTO] from d_clientes"
        vis6 = "create view v_datos_cuenta as select cod_cuenta as [CODIGO DE CUENTA], cod_ban as [CODIGO DE BANCO], tipo_cuenta as [TIPO DE CUENTA], n_cuenta as [NUMERO DE CUENTA BANCARIA], n_cci as [NUMERO DE CUENTA INTERBANCARIA], mon_cuenta as [MONEDA DE LA CUENTA], cod_parti as [CODIGO DE PARTICIPE], cod_clie as [CODIGO DE CLIENTE], cod_provee as [CODIGO DE PROVEEDOR], cod_fondo as [CODIGO DE FONDO]  from datos_cuenta"
        vis7 = "create view v_reg_calif_cliente as select cod_cali as [CODIGO DE CALIFICACION], cod_clie as [CODIGO DE CLIENTE], estado as [SEGUIMIENTO DE CALIFICACION], aprob as [APROBACION DE CALIFICACION], sub_doc as [SUBIR DOCUMENTO], ruta as [RUTA DE ARCHIVOS GUARDADOS]  from d_calif_clie"
        vis8 = "create view v_dist_beneficio as select cod_di as [CODIGO DE DISTRIBUCION], DISTRIBUCION as [DISTRIBUCION DE BENEFICIO], N_DISTRIB as [NUMERO DE DISTRIBUCION DE BENEFICIO], cod_gest as [CODIGO DE GESTION], n_dias as [TOTAL EN DIAS] from DIST_BENEFICIO"
        vis9 = "create view v_d_participacion as select cod_part as [CODIGO DE PARTICIPACION], cod_parti as [CODIGO DE PARTICIPE], nom_parti AS [NOMBRE DE PARTICIPE], cod_manc AS [CODIGO DE MANCOMUNADO], nom_manco AS [NOMBRE DE MANCOMUNADO], cod_certi AS [CODIDO DE CERTIFICADO], cod_fondo AS [CODIGO DE FONDO], nom_fondo AS [NOMBRE DE FONDO], f_ingreso AS [FECHA DE INGRESO], f_salida AS [FECHA DE SALIDA], cod_gest AS [GESTION], tip_part AS [TIPO DE PARTICIPACION], mont_part AS [MONTO DE PARTICIPACION], n_parti AS [NUMERO DE PARTICIPACIONES], v_cuota_actual AS [VALOR CUOTA ACTUAL] from d_participacion"
        vis10 = "create view v_datos_fondo as select COD_FONDO as [CODIGO DE FONDO], COD_DI as [DESTRIBUCION DE BENEFECIO], N_FONDO AS [NOMBRE DE FONDO], MONEDA AS [MONEDA], MONT_MINIMO AS [MONTO MINIMO], MONT_MAXIMO AS [MONTO_MAXIMO], CAPITAL_ACTUAL AS [CAPITAL ACTUAL], UNIDAD_NEGOCIO AS [UNIDAD DE NEGOCIO], F_CREACION AS [FECHA DE CREACION], F_INS_SUNAT AS [FECHA DE INSCRIPCION SUNAT], NU_RUC AS [NUMERO DE RUC], F_INI_OPERA AS [INICIO DE OPERACIONES], F_TER_OPERA AS [TERMINO DE OPERACIONES], VALOR_CUOTA_NOM AS [VALOR CUOTA NOMINAL], VALOR_CUOTA_ACTUAL AS [VALOR CUOTA ACTUAL], cod_gest as [GESTION], fecha as [FECHA ACTUAL] from DATOS_FONDO"
        vis11 = "create view v_d_operacion as select  cod_op as [CODIGO DE OPERACION],cod_clie  as [CODIGO DE CLIENTE],  tip_op AS [TIPO DE OPERACION], m_solic AS [MONTO SOLICITADO], porc_comi_dese AS [% COMISION DESEMBOLSO], mon_comi_dese AS [MONTO COMISION DESEMBOLSO], por_igv AS [% IGV], mont_igv AS [MONTO DE IGV], mont_prestamo AS [MONTO DE PRESTAMO], porc_inte AS [% INTERES], mon_inte AS [MONTO DE INTERES], f_inicio_pres AS [FECHA INICIO DE PRESTAMO], f_termino_pres AS [FECHA TERMINO PRESTAMO], cod_gest as [GESTION], estado as [ESTADO] from d_operacion"
        vis12 = "create view v_gast_comi_desem as select  cod_gcdesem as [CODIGO ],detalle as [DETALLE], monto AS [MONTO DE COMISION], cod_cro_anx AS [CODIGO DE CRONOGRAMA O ANEXO], fecha AS [FECHA], gestion AS [GESTION] from GASTO_COMI_DESEM"
        vis13 = "create view v_couta_op as select  cod_cuota as [CODIGO DE CUOTA],COD_OP as [CODIGO DE OPERACION], CAP_INICIAL AS [CAPITAL INICIAL], AMORTIZACION AS [AMORTIZACION], CAP_FINAL AS [CAPITAL FINAL], INTERES AS [INTERES], IGV AS [IGV],T_CUOTA AS [CUOTA TOTAL], FECHA AS [FECHA DE INICIO], F_VENCI AS [FECHA DE VENCIMIENTO], DIAS AS [DIAS DE CUOTA], gestion as [GESTION], estado as [ESTADO] from CUOTAS_OPERACION"
        vis14 = "create view v_d_operacion_anx as select  cod_anx as [CODIGO DE ANEXO],tip_ope as [TIPO DE OPERACION],cod_clie as [CODIGO DE CLIENTE],comi_trans as [COMISION DE TRANSFERENCIA], igv_comi_trans AS [IGV COMISION TRANSFERENCIA], mont_t_comi AS [MONTO TOTAL DE COMISION], suma_interes AS [SUMA DE INTERES], igv_sum_int AS [TOTAL IGV DE INTERES], mont_t_int AS [MONTO TOTAL DE INTERES],t_abono AS [TOTAL DE ABONO], total AS [TOTAL DE OPERACION], fecha AS [FECHA DE RECEPCION], gestion AS [GESTION],estado AS [ESTADO] from d_operacion_anx"
        vis15 = "create view v_fac_operacion_anx as select  cod_fac_anx as [CODIGO DE DOCUMENTO],cod_anexo AS [CODIGO DE ANEXO], cod_clie AS [CODIGO DE CLIENTE], comi_min_tranfs AS [COMISION MINIMA DE TRASNFERENCIA],porc_comi_min as [PORCENTAJE COMISION DE TRANSFERENCIA],igv_comi as [IGV DE COMISION], porc_detrac AS [PORCENTAJE DE DETRACCION], porc_descu AS [PORCENTAJE DE DESCUENTO], porc_int_cobra AS [PORCENTAJE DE INTERES], porc_igv AS [PORCENTAJE DE IGV], n_document AS [NUMERO DE DOCUMENTO], fec_recep_doc AS [FECHA DE RECEPCION DE DOCUMENTO], fec_venc_doc AS [FECHA DE VENCIMIENTO DE DOCUMENTO],gestion as [GESTION], num_dias_fact AS [NUMERO DE DIAS DE FACTURA], girador AS [ADQUIRIENTE], aceptante AS [CLIENTE], mont_fact AS [MONTO DE FACTURA], mont_detrac AS [MONTO DETRACCION], mon_neto AS [MONTO NETO],mont_descu AS [MONTO DESCUENTO], mont_int_cob AS [MONTO DE INTERES], mont_igv AS [MONTO IGV], abono AS [ABONO], estado as [ESTADO], int_dia AS [INTERES DIARIO], refe AS [REFERENCIA] from fac_operacion_anx"
        vis16 = "create view v_num_dias_cranx as select  cod_numdias as [CODIGO],cod_op AS [CODIGO DE OPERACION], cod_cuota AS [CODIGO DE CUOTA], F_INICIO AS [FECHA DE INICIO DE CUOTA],F_TERMINO as [FECHA DE TERMINO DE CUOTA], N_DIAS_CUOTA AS [TOTAL DE DIAS DE CUOTA],gestion as [GESTION],estado as [ESTADO], MONTO_CUOTA AS [MONTO TOTAL DE CUOTA], MONT_DIARIO AS [MONTO DIARIO DE INTERES DE CUOTA], dia1 AS [DIA 1], dia2 AS [DIA 2], dia3 AS [DIA 3],dia4 AS [DIA 4],dia5 AS [DIA5 ], dia6 AS [DIA6 ] , dia7 AS [DIA 7],dia8 AS [DIA 8],dia9 AS [DIA 9],dia10 AS [DIA 10], dia11 AS [DIA 11], dia12 AS [DIA 12], dia13 AS [DIA 13],dia14 AS [DIA 14],dia15 AS [DIA 15],dia16 AS [DIA 16],dia17 AS [DIA 17],dia18 AS [DIA 18],dia19 AS [DIA 19],dia20 AS [DIA 20],dia21 AS [DIA 21],dia22 AS [DIA 22],dia23 AS [DIA 23],dia24 AS [DIA 24],dia25 AS [DIA 25],dia26 AS [DIA 26],dia27 AS [DIA 27],dia28 AS [DIA 28],dia29 AS [DIA 29],dia30 AS [DIA 30],dia31 AS [DIA 31],dia32 AS [DIA 32],dia33 AS [DIA 33],dia34 AS [DIA 34],dia35 AS [DIA 35],dia36 AS [DIA 36],dia37 AS [DIA 37],dia38 AS [DIA 38],dia39 AS [DIA 39],dia40 AS [DIA 40],dia41 AS [DIA 41],dia42 AS [DIA 42],dia43 AS [DIA 43],dia44 AS [DIA 44],dia45 AS [DIA 45],dia46 AS [DIA 46],dia47 AS [DIA 47],dia48 AS [DIA 48],dia49 AS [DIA 49],dia50 AS [DIA 50],dia51 AS [DIA 51],dia52 AS [DIA 52],dia53 AS [DIA 53],dia54 AS [DIA 54],dia55 AS [DIA 55],dia56 AS [DIA 56],dia57 AS [DIA 57],dia58 AS [DIA 58],dia59 AS [DIA 59],dia60 AS [DIA 60],dia61 AS [DIA 61],dia62 AS [DIA 62],dia63 AS [DIA 63],dia64 AS [DIA 64],dia65 AS [DIA 65],dia66 AS [DIA 66],dia67 AS [DIA 67],dia68 AS [DIA 68],dia69 AS [DIA 69],dia70 AS [DIA 70],dia71 AS [DIA 71],dia72 AS [DIA 72],dia73 AS [DIA 73],dia74 AS [DIA 74],dia75 AS [DIA 75],dia76 AS [DIA 76],dia77 AS [DIA 77],dia78 AS [DIA 78],dia79 AS [DIA 79],dia80 AS [DIA 80],dia81 AS [DIA 81],dia82 AS [DIA 82],dia83 AS [DIA 83],dia84 AS [DIA 84],dia85 AS [DIA 85],dia86 AS [DIA 86],dia87 AS [DIA 87],dia88 AS [DIA 88],dia89 AS [DIA 89], dia90 AS [DIA 90],dia91 AS [DIA 91],dia92 AS [DIA 92],dia93 AS [DIA 93],dia94 AS [DIA 94],dia95 AS [DIA 95],dia96 AS [DIA 96],dia97 AS [DIA 97],dia98 AS [DIA 98],dia99 AS [DIA 99],dia100 AS [DIA 100],dia101 AS [DIA 101],dia102 AS [DIA 102],dia103 AS [DIA 103],dia104 AS [DIA 104],dia105 AS [DIA 105],dia106 AS [DIA 106],dia107 AS [DIA 107],dia108 AS [DIA 108],dia109 AS [DIA 109],dia110 AS [DIA 110],dia111 AS [DIA 111],dia112 AS [DIA 112],dia113 AS [DIA 113],dia114 AS [DIA 114],dia115 AS [DIA 115],dia116 AS [DIA 116],dia117 AS [DIA 117],dia118 AS [DIA 118],dia119 AS [DIA 119],dia120 AS [DIA 120],dia121 AS [DIA 121],dia122 AS [DIA 122],dia123 AS [DIA 123],dia124 AS [DIA 124],dia125 AS [DIA 125],dia126 AS [DIA 126],dia127 AS [DIA 127],dia128 AS [DIA 128],dia129 AS [DIA 129],dia130 AS [DIA 130],dia131 AS [DIA 131],dia132 AS [DIA 132],dia133 AS [DIA 133],dia134 AS [DIA 134],dia135 AS [DIA 135],dia136 AS [DIA 136],dia137 AS [DIA 137],dia138 AS [DIA 138],dia139 AS [DIA 139],dia140 AS [DIA 140],dia141 AS [DIA 141],dia142 AS [DIA 142],dia143 AS [DIA 143],dia144 AS [DIA 144],dia145 AS [DIA 145],dia146 AS [DIA 146],dia147 AS [DIA 147],dia148 AS [DIA 148],dia149 AS [DIA 149],dia150 AS [DIA 150],dia151 AS [DIA 151],dia152 AS [DIA 152],dia153 AS [DIA 153],dia154 AS [DIA 154],dia155 AS [DIA 155],dia156 AS [DIA 156],dia157 AS [DIA 157],dia158 AS [DIA 158],dia159 AS [DIA 159],dia160 AS [DIA 160],dia161 AS [DIA 161],dia162 AS [DIA 162],dia163 AS [DIA 163],dia164 AS [DIA 164],dia165 AS [DIA 165],dia166 AS [DIA 166],dia167 AS [DIA 167],dia168 AS [DIA 168],dia169 AS [DIA 169],dia170 AS [DIA 170],dia171 AS [DIA 171],dia172 AS [DIA 172],dia173 AS [DIA 173],dia174 AS [DIA 174],dia175 AS [DIA 175],dia176 AS [DIA 176],dia177 AS [DIA 177],dia178 AS [DIA 178],dia179 AS [DIA 179],dia180 AS [DIA 180],dia181 AS [DIA 181],dia182 AS [DIA 182],dia183 AS [DIA 183],dia184 AS [DIA 184],dia185 AS [DIA 185],dia186 AS [DIA 186],dia187 AS [DIA 187],dia188 AS [DIA 188],dia189 AS [DIA 189],dia190 AS [DIA 190],dia191 AS [DIA 191],dia192 AS [DIA 192],dia193 AS [DIA 193],dia194 AS [DIA 194],dia195 AS [DIA 195],dia196 AS [DIA 196],dia197 AS [DIA 197],dia198 AS [DIA 198],dia199 AS [DIA 199],dia200 AS [DIA 200],dia201 AS [DIA 201],dia202 AS [DIA 202],dia203 AS [DIA 203],dia204 AS [DIA 204],dia205 AS [DIA 205],dia206 AS [DIA 206],dia207 AS [DIA 207],dia208 AS [DIA 208],dia209 AS [DIA 209],dia210 AS [DIA 210],dia211 AS [DIA 211],dia212 AS [DIA 212],dia213 AS [DIA 213],dia214 AS [DIA 214],dia215 AS [DIA 215],dia216 AS [DIA 216],dia217 AS [DIA 217],dia218 AS [DIA 218],dia219 AS [DIA 219],dia220 AS [DIA 220],dia221 AS [DIA 221],dia222 AS [DIA 222],dia223 AS [DIA 223],dia224 AS [DIA 224],dia225 AS [DIA 225],dia226 AS [DIA 226],dia227 AS [DIA 227],dia228 AS [DIA 228],dia229 AS [DIA 229],dia230 AS [DIA 230],dia231 AS [DIA 231],dia232 AS [DIA 232],dia233 AS [DIA 233],dia234 AS [DIA 234],dia235 AS [DIA 235],dia236 AS [DIA 236],dia237 AS [DIA 237],dia238 AS [DIA 238],dia239 AS [DIA 239],dia240 AS [DIA 240],dia241 AS [DIA 241],dia242 AS [DIA 242],dia243 AS [DIA 243],dia244 AS [DIA 244],dia245 AS [DIA 245],dia246 AS [DIA 246],dia247 AS [DIA 247],dia248 AS [DIA 248],dia249 AS [DIA 249],dia250 AS [DIA 250],dia251 AS [DIA 251],dia252 AS [DIA 252],dia253 AS [DIA 253],dia254 AS [DIA 254],dia255 AS [DIA 255],dia256 AS [DIA 256],dia257 AS [DIA 257],dia258 AS [DIA 258],dia259 AS [DIA 259],dia260 AS [DIA 260],dia261 AS [DIA 261],dia262 AS [DIA 262],dia263 AS [DIA 263],dia264 AS [DIA 264],dia265 AS [DIA 265],dia266 AS [DIA 266],dia267 AS [DIA 267],dia268 AS [DIA 268],dia269 AS [DIA 269],dia270 AS [DIA 270],dia271 AS [DIA 271],dia272 AS [DIA 272],dia273 AS [DIA 273],dia274 AS [DIA 274],dia275 AS [DIA 275],dia276 AS [DIA 276],dia277 AS [DIA 277],dia278 AS [DIA 278],dia279 AS [DIA 279],dia280 AS [DIA 280],dia281 AS [DIA 281],dia282 AS [DIA 282],dia283 AS [DIA 283],dia284 AS [DIA 284],dia285 AS [DIA 285],dia286 AS [DIA 286],dia287 AS [DIA 287],dia288 AS [DIA 288],dia289 AS [DIA 289],dia290 AS [DIA 290],dia291 AS [DIA 291],dia292 AS [DIA 292],dia293 AS [DIA 293],dia294 AS [DIA 294],dia295 AS [DIA 295],dia296 AS [DIA 296],dia297 AS [DIA 297],dia298 AS [DIA 298],dia299 AS [DIA 299],dia300 AS [DIA 300],dia301 AS [DIA 301],dia302 AS [DIA 302],dia303 AS [DIA 303],dia304 AS [DIA 304],dia305 AS [DIA 305],dia306 AS [DIA 306],dia307 AS [DIA 307],dia308 AS [DIA 308],dia309 AS [DIA 309],dia310 AS [DIA 310],dia311 AS [DIA 311],dia312 AS [DIA 312],dia313 AS [DIA 313],dia314 AS [DIA 314],dia315 AS [DIA 315],dia316 AS [DIA 316],dia317 AS [DIA 317],dia318 AS [DIA 318],dia319 AS [DIA 319],dia320 AS [DIA 320],dia321 AS [DIA 321],dia322 AS [DIA 322],dia323 AS [DIA 323],dia324 AS [DIA 324],dia325 AS [DIA 325],dia326 AS [DIA 326],dia327 AS [DIA 327],dia328 AS [DIA 328],dia329 AS [DIA 329],dia330 AS [DIA 330],dia331 AS [DIA 331],dia332 AS [DIA 332],dia333 AS [DIA 333],dia334 AS [DIA 334],dia335 AS [DIA 335],dia336 AS [DIA 336],dia337 AS [DIA 337],dia338 AS [DIA 338],dia339 AS [DIA 339],dia340 AS [DIA 340],dia341 AS [DIA 341],dia342 AS [DIA 342],dia343 AS [DIA 343],dia344 AS [DIA 344],dia345 AS [DIA 345],dia346 AS [DIA 346],dia347 AS [DIA 347],dia348 AS [DIA 348],dia349 AS [DIA 349],dia350 AS [DIA 350],dia351 AS [DIA 351],dia352 AS [DIA 352],dia353 AS [DIA 353],dia354 AS [DIA 354],dia355 AS [DIA 355],dia356 AS [DIA 356],dia357 AS [DIA 357],dia358 AS [DIA 358],dia359 AS [DIA 359],dia360 AS [DIA 360],dia361 AS [DIA 361],dia362 AS [DIA 362],dia363 AS [DIA 363],dia364 AS [DIA 364],dia365 AS [DIA 365],dia366 AS [DIA 366] from NUM_DIAS_CRANX"
        vis17 = "create view v_historial as select  cod_his as [CODIGO],cod_opcranx as [CODIGO OPERACION],cod_cufacdia as [CODIGO DE CUOTA / FACTURA],fecha as [FECHA], f_inicio AS [FECHA DE INICIO], f_fin AS [FECHA DE FIN], n_finicio AS [NUEVA FECHA DE INICIO], n_ftermino AS [NUEVA FECHA DE TERMINO], monto AS [MONTO DE OPERACION],montof AS [MONTO FINAL], referencia AS [REFERENCIA], coment AS [COMENTARIO], interes as [INTERES], igv_interes as [IGV DE INTERES], comi_tran as [COMISION DE DESEMBOLSO O TRANSFERENCIA], igv_comi_tran as [IGV DE COMISION DE DESEMBOLSO O TRANSFERENCIA]  from historial"



        Dim myCommand As SqlCommand = New SqlCommand(str, myConn)
        Dim myCommand1 As SqlCommand = New SqlCommand(str1, myConn)
        'Dim myCommand2 As SqlCommand = New SqlCommand(str2, myConn)
        Dim myCommand3 As SqlCommand = New SqlCommand(str3, myConn)
        Dim myCommand4 As SqlCommand = New SqlCommand(str4, myConn)
        Dim myCommand5 As SqlCommand = New SqlCommand(fun1, myConn)
        Dim myCommand6 As SqlCommand = New SqlCommand(fun2, myConn)
        Dim myCommand7 As SqlCommand = New SqlCommand(fun3, myConn)
        Dim myCommand8 As SqlCommand = New SqlCommand(fun4, myConn)
        Dim myCommand9 As SqlCommand = New SqlCommand(fun5, myConn)
        Dim myCommand10 As SqlCommand = New SqlCommand(fun6, myConn)
        Dim myCommand11 As SqlCommand = New SqlCommand(fun7, myConn)
        Dim myCommand12 As SqlCommand = New SqlCommand(fun8, myConn)
        Dim myCommand13 As SqlCommand = New SqlCommand(fun9, myConn)
        Dim myCommand14 As SqlCommand = New SqlCommand(fun10, myConn)
        Dim myCommand15 As SqlCommand = New SqlCommand(fun11, myConn)
        Dim myCommand16 As SqlCommand = New SqlCommand(fun12, myConn)
        Dim myCommand17 As SqlCommand = New SqlCommand(fun13, myConn)
        Dim myCommand18 As SqlCommand = New SqlCommand(fun14, myConn)
        Dim myCommand19 As SqlCommand = New SqlCommand(fun15, myConn)
        Dim myCommand20 As SqlCommand = New SqlCommand(fun16, myConn)
        Dim myCommand21 As SqlCommand = New SqlCommand(fun17, myConn)
        Dim myCommand22 As SqlCommand = New SqlCommand(alta1, myConn)
        'Dim myCommand23 As SqlCommand = New SqlCommand(alta1, myConn)
        Dim myCommand24 As SqlCommand = New SqlCommand(alta2, myConn)
        Dim myCommand25 As SqlCommand = New SqlCommand(alta3, myConn)
        Dim myCommand26 As SqlCommand = New SqlCommand(alta4, myConn)
        Dim myCommand27 As SqlCommand = New SqlCommand(alta5, myConn)
        Dim myCommand28 As SqlCommand = New SqlCommand(alta6, myConn)
        Dim myCommand29 As SqlCommand = New SqlCommand(alta7, myConn)
        Dim myCommand30 As SqlCommand = New SqlCommand(alta8, myConn)
        Dim myCommand31 As SqlCommand = New SqlCommand(alta9, myConn)
        Dim myCommand32 As SqlCommand = New SqlCommand(alta10, myConn)
        Dim myCommand33 As SqlCommand = New SqlCommand(alta11, myConn)
        Dim myCommand34 As SqlCommand = New SqlCommand(alta12, myConn)
        Dim myCommand35 As SqlCommand = New SqlCommand(alta13, myConn)
        Dim myCommand36 As SqlCommand = New SqlCommand(alta14, myConn)
        Dim myCommand37 As SqlCommand = New SqlCommand(alta15, myConn)
        Dim myCommand38 As SqlCommand = New SqlCommand(alta16, myConn)
        Dim myCommand39 As SqlCommand = New SqlCommand(alta17, myConn)
        Dim myCommand40 As SqlCommand = New SqlCommand(edit1, myConn)
        Dim myCommand41 As SqlCommand = New SqlCommand(edit2, myConn)
        Dim myCommand42 As SqlCommand = New SqlCommand(edit3, myConn)
        Dim myCommand43 As SqlCommand = New SqlCommand(edit4, myConn)
        Dim myCommand44 As SqlCommand = New SqlCommand(edit5, myConn)
        Dim myCommand45 As SqlCommand = New SqlCommand(edit6, myConn)
        Dim myCommand46 As SqlCommand = New SqlCommand(edit7, myConn)
        Dim myCommand47 As SqlCommand = New SqlCommand(edit8, myConn)
        Dim myCommand48 As SqlCommand = New SqlCommand(edit9, myConn)
        Dim myCommand49 As SqlCommand = New SqlCommand(edit10, myConn)
        Dim myCommand50 As SqlCommand = New SqlCommand(edit11, myConn)
        Dim myCommand51 As SqlCommand = New SqlCommand(edit12, myConn)
        Dim myCommand52 As SqlCommand = New SqlCommand(edit13, myConn)
        Dim myCommand53 As SqlCommand = New SqlCommand(edit14, myConn)
        Dim myCommand54 As SqlCommand = New SqlCommand(edit15, myConn)
        Dim myCommand55 As SqlCommand = New SqlCommand(edit16, myConn)
        Dim myCommand56 As SqlCommand = New SqlCommand(edit17, myConn)
        Dim mycommand113 As SqlCommand = New SqlCommand(edit18, myConn)
        Dim myCommand57 As SqlCommand = New SqlCommand(SUMA, myConn)
        Dim myCommand58 As SqlCommand = New SqlCommand(bor1, myConn)
        Dim myCommand59 As SqlCommand = New SqlCommand(bor2, myConn)
        Dim myCommand60 As SqlCommand = New SqlCommand(bor3, myConn)
        Dim myCommand61 As SqlCommand = New SqlCommand(bor4, myConn)
        Dim myCommand62 As SqlCommand = New SqlCommand(bor5, myConn)
        Dim myCommand63 As SqlCommand = New SqlCommand(bor6, myConn)
        Dim myCommand64 As SqlCommand = New SqlCommand(bor7, myConn)
        Dim myCommand65 As SqlCommand = New SqlCommand(bor8, myConn)
        Dim myCommand66 As SqlCommand = New SqlCommand(bor9, myConn)
        Dim myCommand67 As SqlCommand = New SqlCommand(bor10, myConn)
        Dim myCommand68 As SqlCommand = New SqlCommand(bor11, myConn)
        Dim myCommand69 As SqlCommand = New SqlCommand(bor12, myConn)
        Dim myCommand71 As SqlCommand = New SqlCommand(bor13, myConn)
        Dim myCommand72 As SqlCommand = New SqlCommand(bor14, myConn)
        Dim myCommand73 As SqlCommand = New SqlCommand(bor15, myConn)
        Dim myCommand74 As SqlCommand = New SqlCommand(bor16, myConn)
        Dim myCommand75 As SqlCommand = New SqlCommand(bor17, myConn)
        Dim myCommand76 As SqlCommand = New SqlCommand(ver1, myConn)
        Dim myCommand77 As SqlCommand = New SqlCommand(ver2, myConn)
        Dim myCommand78 As SqlCommand = New SqlCommand(ver3, myConn)
        Dim myCommand79 As SqlCommand = New SqlCommand(ver4, myConn)
        Dim myCommand80 As SqlCommand = New SqlCommand(ver5, myConn)
        Dim myCommand81 As SqlCommand = New SqlCommand(ver6, myConn)
        Dim myCommand82 As SqlCommand = New SqlCommand(ver7, myConn)
        Dim myCommand83 As SqlCommand = New SqlCommand(ver8, myConn)
        Dim myCommand84 As SqlCommand = New SqlCommand(ver9, myConn)
        Dim myCommand85 As SqlCommand = New SqlCommand(ver10, myConn)
        Dim myCommand86 As SqlCommand = New SqlCommand(ver11, myConn)
        Dim myCommand87 As SqlCommand = New SqlCommand(ver12, myConn)
        Dim myCommand88 As SqlCommand = New SqlCommand(ver13, myConn)
        Dim myCommand89 As SqlCommand = New SqlCommand(ver14, myConn)
        Dim myCommand90 As SqlCommand = New SqlCommand(ver15, myConn)
        Dim myCommand91 As SqlCommand = New SqlCommand(ver16, myConn)
        Dim myCommand92 As SqlCommand = New SqlCommand(ver17, myConn)
        'Dim myCommand93 As SqlCommand = New SqlCommand(ver18, myConn)
        Dim myCommand94 As SqlCommand = New SqlCommand(vis1, myConn)
        Dim myCommand95 As SqlCommand = New SqlCommand(vis2, myConn)
        Dim myCommand96 As SqlCommand = New SqlCommand(vis3, myConn)
        Dim myCommand97 As SqlCommand = New SqlCommand(vis4, myConn)
        Dim myCommand98 As SqlCommand = New SqlCommand(vis5, myConn)
        Dim myCommand99 As SqlCommand = New SqlCommand(vis6, myConn)
        Dim myCommand100 As SqlCommand = New SqlCommand(vis7, myConn)
        Dim myCommand101 As SqlCommand = New SqlCommand(vis8, myConn)
        Dim myCommand102 As SqlCommand = New SqlCommand(vis9, myConn)
        Dim myCommand103 As SqlCommand = New SqlCommand(vis10, myConn)
        Dim myCommand104 As SqlCommand = New SqlCommand(vis11, myConn)
        Dim myCommand105 As SqlCommand = New SqlCommand(vis12, myConn)
        Dim myCommand106 As SqlCommand = New SqlCommand(vis13, myConn)
        'Dim myCommand107 As SqlCommand = New SqlCommand(vis12, myConn)
        'Dim myCommand108 As SqlCommand = New SqlCommand(vis13, myConn)
        Dim myCommand109 As SqlCommand = New SqlCommand(vis14, myConn)
        Dim myCommand110 As SqlCommand = New SqlCommand(vis15, myConn)
        Dim myCommand111 As SqlCommand = New SqlCommand(vis16, myConn)
        Dim myCommand112 As SqlCommand = New SqlCommand(vis17, myConn)


        Try
            myConn.Open()
            'myConn2.Open()
            myCommand.ExecuteNonQuery()
            myCommand1.ExecuteNonQuery()
            'myCommand2.ExecuteNonQuery()
            myCommand3.ExecuteNonQuery()
            myCommand4.ExecuteNonQuery()
            myCommand94.ExecuteNonQuery()
            myCommand95.ExecuteNonQuery()
            myCommand96.ExecuteNonQuery()
            myCommand97.ExecuteNonQuery()
            myCommand98.ExecuteNonQuery()
            myCommand99.ExecuteNonQuery()
            myCommand100.ExecuteNonQuery()
            myCommand101.ExecuteNonQuery()
            myCommand102.ExecuteNonQuery()
            myCommand103.ExecuteNonQuery()
            myCommand104.ExecuteNonQuery()
            myCommand105.ExecuteNonQuery()
            myCommand106.ExecuteNonQuery()
            'myCommand107.ExecuteNonQuery()
            'myCommand108.ExecuteNonQuery()
            myCommand109.ExecuteNonQuery()
            myCommand110.ExecuteNonQuery()
            myCommand111.ExecuteNonQuery()
            myCommand112.ExecuteNonQuery()
            myCommand5.ExecuteNonQuery()
            myCommand6.ExecuteNonQuery()
            myCommand7.ExecuteNonQuery()
            myCommand8.ExecuteNonQuery()
            myCommand9.ExecuteNonQuery()
            myCommand10.ExecuteNonQuery()
            myCommand11.ExecuteNonQuery()
            myCommand12.ExecuteNonQuery()
            myCommand13.ExecuteNonQuery()
            myCommand14.ExecuteNonQuery()
            myCommand15.ExecuteNonQuery()
            myCommand16.ExecuteNonQuery()
            myCommand17.ExecuteNonQuery()
            myCommand18.ExecuteNonQuery()
            myCommand19.ExecuteNonQuery()
            myCommand20.ExecuteNonQuery()
            myCommand21.ExecuteNonQuery()
            myCommand22.ExecuteNonQuery()
            'myCommand23.ExecuteNonQuery()
            myCommand24.ExecuteNonQuery()
            myCommand25.ExecuteNonQuery()
            myCommand26.ExecuteNonQuery()
            myCommand27.ExecuteNonQuery()
            myCommand28.ExecuteNonQuery()
            myCommand29.ExecuteNonQuery()
            myCommand30.ExecuteNonQuery()
            myCommand31.ExecuteNonQuery()
            myCommand32.ExecuteNonQuery()
            myCommand33.ExecuteNonQuery()
            myCommand34.ExecuteNonQuery()
            myCommand35.ExecuteNonQuery()
            myCommand36.ExecuteNonQuery()
            myCommand37.ExecuteNonQuery()
            myCommand38.ExecuteNonQuery()
            myCommand39.ExecuteNonQuery()
            myCommand40.ExecuteNonQuery()
            myCommand41.ExecuteNonQuery()
            myCommand42.ExecuteNonQuery()
            myCommand43.ExecuteNonQuery()
            myCommand44.ExecuteNonQuery()
            myCommand45.ExecuteNonQuery()
            myCommand46.ExecuteNonQuery()
            myCommand47.ExecuteNonQuery()
            myCommand48.ExecuteNonQuery()
            myCommand49.ExecuteNonQuery()
            myCommand50.ExecuteNonQuery()
            myCommand51.ExecuteNonQuery()
            myCommand52.ExecuteNonQuery()
            myCommand53.ExecuteNonQuery()
            myCommand54.ExecuteNonQuery()
            myCommand55.ExecuteNonQuery()
            myCommand56.ExecuteNonQuery()
            mycommand113.ExecuteNonQuery()
            myCommand57.ExecuteNonQuery()
            myCommand58.ExecuteNonQuery()
            myCommand59.ExecuteNonQuery()
            myCommand60.ExecuteNonQuery()
            myCommand61.ExecuteNonQuery()
            myCommand62.ExecuteNonQuery()
            myCommand63.ExecuteNonQuery()
            myCommand64.ExecuteNonQuery()
            myCommand65.ExecuteNonQuery()
            myCommand66.ExecuteNonQuery()
            myCommand67.ExecuteNonQuery()
            myCommand68.ExecuteNonQuery()
            myCommand69.ExecuteNonQuery()
            myCommand71.ExecuteNonQuery()
            myCommand72.ExecuteNonQuery()
            myCommand73.ExecuteNonQuery()
            myCommand74.ExecuteNonQuery()
            myCommand75.ExecuteNonQuery()
            myCommand76.ExecuteNonQuery()
            myCommand77.ExecuteNonQuery()
            myCommand78.ExecuteNonQuery()
            myCommand79.ExecuteNonQuery()
            myCommand80.ExecuteNonQuery()
            myCommand81.ExecuteNonQuery()
            myCommand82.ExecuteNonQuery()
            myCommand83.ExecuteNonQuery()
            myCommand84.ExecuteNonQuery()
            myCommand85.ExecuteNonQuery()
            myCommand86.ExecuteNonQuery()
            myCommand87.ExecuteNonQuery()
            myCommand88.ExecuteNonQuery()
            myCommand89.ExecuteNonQuery()
            myCommand90.ExecuteNonQuery()
            myCommand91.ExecuteNonQuery()
            myCommand92.ExecuteNonQuery()
            'myCommand93.ExecuteNonQuery()



            MessageBox.Show("BASE DE DATOS DE FONDO CREADA",
                             "CREACION DE FONDO", MessageBoxButtons.OK,
                             MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql2 As String
        Dim borra = "drop database " & t2.Text
        nc = t2.Text
        res = MessageBox.Show("¿Desea borrar los Datos?", "nfondo", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        If res = vbYes Then
            sql2 = "exec ver_servsql '" + cb1.Text + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql2, conexion.conexion)
            dr = com.ExecuteReader
            If dr.Read Then
                nomsql = dr(1)
                usql = dr(2)
                clasql = dr(3)

            Else
                MessageBox.Show("Los datos Buscados no Existe")
            End If
            sql = "exec borra_nfondo '" + nc + "'"
            conexion.conectar()
            com = New SqlClient.SqlCommand(sql, conexion.conexion)
            res = com.ExecuteNonQuery
            Dim myConn As SqlConnection = New SqlConnection("Server=" & nomsql & ";" & "uid=" & usql & ";pwd=" & clasql & ";database=master")
            Dim myCommand As SqlCommand = New SqlCommand(borra, myConn)
            myConn.Open()
            myCommand.ExecuteNonQuery()
            MessageBox.Show("Registro Borrado")
        End If
        llenar_grid()
        t1.Enabled = False
        t2.Enabled = False
        cb1.Enabled = False
        t1.Text = ""
        t2.Text = ""
        cb1.Text = ""
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Button5_Click(sender, e)
        Button4_Click(sender, e)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        nc = InputBox("Ingrese Codigo o Nombre del Fondo")
        sql = "exec ver_nfondo '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            t2.Text = dr(0)
            t1.Text = dr(1)
            cb1.Text = dr(2)
            cb2.Text = dr(3)
            t3.Text = dr(4)
            t4.Text = dr(5)
            t5.Text = dr(6)
            t6.Text = dr(7)
            t7.Text = dr(8)
            CB3.Text = dr(9)
            DTP1.Value = dr(10)
            DTP2.Value = dr(11)
            t8.Text = dr(12)
            DTP3.Text = dr(13)
            DTP4.Text = dr(14)
            t8.Text = dr(15)
            t9.Text = dr(17)
            cb5.Text = dr(18)
            dtp5.Value = dr(19)
            TextBox1.Text = dr(20)
        Else
            MessageBox.Show("Los datos Buscados no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        gestion.Show()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        moneda.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        accion = "editar"
        cb1.Enabled = True
        t1.Enabled = True
        t2.Enabled = False
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True
        t6.Enabled = True
        t7.Enabled = True
        t8.Enabled = True
        t9.Enabled = True
        DTP1.Enabled = True
        DTP2.Enabled = True
        DTP3.Enabled = True
        DTP4.Enabled = True
        cb1.Enabled = True
        cb2.Enabled = True
        CB3.Enabled = True
        cb4.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        cb5.Enabled = True
        TextBox1.Enabled = True
        dtp5.Enabled = True
        llenar_periodo_distribucion()



    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        uni_negocio.Show()
    End Sub

    Dim ds As DataSet
    Dim dt As DataTable
    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    'Public Sub conectar()
    'conexion = New SqlClient.SqlConnection
    'conexion.ConnectionString = ("server=orcasoluciones;database=bdopfac;integrated security=true")
    'conexion.Open()
    ' End Sub
    Private Sub llenar_grid()
        sql = "select * from v_nfondo"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "v_nfondo")
        dgv.DataSource = ds
        dgv.DataMember = "v_nfondo"
        conexion.conexion.Close()
    End Sub

    Private Sub llenar_combo1()
        sql = "select *from servsql"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb1.DataSource = dt
        cb1.DisplayMember = "servsql"
        cb1.ValueMember = "noserver"
    End Sub

    Public Sub llenar_combo4()
        sql = "select *from gestio_bdp"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb4.DataSource = dt
        cb4.DisplayMember = "gestio_bdp"
        cb4.ValueMember = "gestion"
    End Sub

    Public Sub llenar_combo3()
        sql = "select *from moneda"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb2.DataSource = dt
        cb2.DisplayMember = "moneda"
        cb2.ValueMember = "tmoneda"
    End Sub

    Public Sub llenar_combo2()
        sql = "select *from uni_negocio"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        CB3.DataSource = dt
        CB3.DisplayMember = "uni_negocio"
        CB3.ValueMember = "uni_negocio"
    End Sub


    Private Sub btnCrearBase_Click(sender As Object, e As EventArgs) Handles btnCrearBase.Click
        accion = "guardar"
        cb1.Enabled = True
        cb1.Text = ""
        t1.Enabled = True
        t1.Text = ""
        t2.Enabled = False
        t2.Text = ""
        t3.Enabled = True
        t3.Text = 0.0
        t4.Enabled = True
        t4.Text = 0.0
        t5.Enabled = True
        t5.Text = 0.0
        t6.Enabled = True
        t6.Text = 0.0
        t7.Enabled = True
        t7.Text = 0.0
        t9.Enabled = True
        t9.Text = 0.0
        t8.Enabled = True
        t8.Text = ""
        cb2.Enabled = True
        cb2.Text = ""
        CB3.Enabled = True
        CB3.Text = ""
        DTP1.Enabled = True
        DTP1.Text = ""
        DTP2.Enabled = True
        DTP2.Text = ""
        DTP3.Enabled = True
        DTP3.Text = ""
        DTP4.Enabled = True
        DTP4.Text = ""
        cb4.Enabled = True
        cb4.Text = ""
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        cb5.Enabled = True
        TextBox1.Enabled = True
        llenar_periodo_distribucion()




    End Sub

    Private Sub cfondo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        llenar_combo1()
        llenar_combo4()
        llenar_combo3()
        llenar_combo2()
        'llenar_periodo_distribucion()
        llenar_grid()
        'Button4.Hide()
        'Button5.Hide()


    End Sub

    Public Sub llenar_periodo_distribucion()

        sql = "select *from dist_beneficio"
        conexion.conectar()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion)
        cb = New SqlClient.SqlCommandBuilder(da)
        dt = New DataTable
        da.Fill(dt)
        cb5.DataSource = dt
        cb5.DisplayMember = "distribucion"
        cb5.ValueMember = "distribucion"
        Distrib_benef()

    End Sub

    Private Sub Distrib_benef()
        Try
            buscar_periodo_distri()
            'Dim wD As Long = DateDiff(DateInterval.DayOfYear, DTP3.Value, Today)
            'dtp5.Value = DTP3.Value
            dtp5.Value = DTP3.Value.AddDays(dias_periodo)

        Catch ex As Exception

        End Try
    End Sub
    Dim num_periodo, dias_periodo As Integer
    Dim cod_periodo, nom_periodo, gest_periodo As String
    Private Sub buscar_periodo_distri()
        nc = cb5.Text
        sql = "exec ver_dist_beneficio '" + nc + "'"
        conexion.conectar()
        com = New SqlClient.SqlCommand(sql, conexion.conexion)
        dr = com.ExecuteReader
        If dr.Read Then
            cod_periodo = dr(0)
            nom_periodo = dr(1)
            num_periodo = dr(2)
            gest_periodo = dr(3)
            dias_periodo = dr(5)
            TextBox1.Text = dr(5)

        Else
            MessageBox.Show("El codigo no Existe")
        End If
        dr.Close()
        conexion.conexion.Close()
    End Sub
End Class