Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports Finisar.SQLite

Public Class reporte_cuotas
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
    Dim xlibro As Microsoft.Office.Interop.Excel.Application
    Dim strRutaExcel As String
    Dim sql, sql2, sql3, nc As String
    Dim res, res2 As Integer
    Dim ds As DataSet
    Dim dt As DataTable
    Dim nom_clie, ruc_clie As String

    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'b_cliente()
        reportecuotas()
    End Sub

    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Private Sub reporte_cuotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.AllowUserToAddRows = False
        Me.Text = "Reporte de Cuotas" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
        'b_cliente()
    End Sub
    Public Sub buscar()

        t1.Text = Anex_Cronog.t1.Text
        t2.Text = Anex_Cronog.t2.Text
        t3.Text = Anex_Cronog.cb1.Text
        t5.Text = Anex_Cronog.t5.Text
        t6.Text = Anex_Cronog.t6.Text
        t7.Text = Anex_Cronog.t7.Text
        t8.Text = Anex_Cronog.t8.Text
        t9.Text = Anex_Cronog.t9.Text
        t10.Text = Anex_Cronog.t10.Text
        t11.Text = Anex_Cronog.t11.Text
        t12.Text = Anex_Cronog.t12.Text
        dtp1.Value = Anex_Cronog.dtp1.Value
        dtp2.Value = Anex_Cronog.dtp2.Value
        t13.Text = Anex_Cronog.cb2.Text
        t14.Text = Anex_Cronog.cb4.Text
        nc = t1.Text
        sql = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "'"
        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "'")
        dgv.DataSource = ds
        dgv.DataMember = "select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "'"
        conexion.conexion2.Close()
    End Sub

    Public Sub reportecuotas()
        'El siguiente codigo es para crear la ruta,entre comillas se pone la ruta donde esta el libro
        Dim Ruta As String = Path.Combine(Directory.GetCurrentDirectory(), "Cronograma.xlsx")
        strRutaExcel = Ruta
        conexion.conectarfondo()
        'El siguiente codigo es para abrir el libro y hacerlo visible, si se quiere dejar el libro oculto, se cambia la palabra True por False
        xlibro = CreateObject("Excel.Application")
        xlibro.Workbooks.Open(strRutaExcel)
        xlibro.Visible = True

        xlibro.Sheets("CRONOGRAMA").Select() 'Nombre del libro
        'esta es la instruccion para modificar la celda con el contenido de un textbox llamado textbox1, ustedes le pueden poner el nombre que deseen al textbox
        xlibro.Range("B6").Value = Datos_Generales_del_Fondo.t2.Text & "  " & Datos_Generales_del_Fondo.t1.Text
        xlibro.Range("C9").Value = nom_clie
        xlibro.Range("C10").Value = ruc_clie
        xlibro.Range("E17").Value = dtp1.Text
        xlibro.Range("E18").Value = t11.Text
        xlibro.Range("E19").Value = t8.Text
        xlibro.Range("E20").Value = t5.Text
        xlibro.Range("E21").Value = t6.Text
        xlibro.Range("E22").Value = t7.Text
        xlibro.Range("E23").Value = t10.Text
        xlibro.Range("H56").Value = nom_clie


        ''Cargamos las celdas con los datos de la base de datos
        'Dim Conexion As Finisar.SQLite.SQLiteConnection
        'Dim Adaptador As Finisar.SQLite.SQLiteDataAdapter

        'conexion = New Finisar.SQLite.SQLiteConnection
        'conexion.ConnectionString = "Data Source=abarrotes.db3;Version=3;"

        ' conexion.Open()

        'Dim ds As New DataSet
        'Adaptador = New Finisar.SQLite.SQLiteDataAdapter("select * from productos", Conexion)
        'Adaptador.Fill(ds)
        'Dim Conexion As SqlClient.SqlConnection
        Dim Adaptador As SqlClient.SqlDataAdapter

        'conexion = New SqlClient.SqlConnection
        'conexion.ConnectionString = "Data source = orcasoluciones; initial catalog = FO001; user id = sa; password = Orca2016"

        'conexion.Open()
        nc = t1.Text
        Dim ds As New DataSet
        Adaptador = New SqlClient.SqlDataAdapter("select *from v_couta_op where [CODIGO DE OPERACION] ='" + nc + "'", conexion.conexion2)
        Adaptador.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim fila As DataRow
            Dim ValorInicial As Integer = 27 ''Celda donde empezamos a insertar los articulos
            Dim Total As Double = 0
            For Each fila In ds.Tables(0).Rows
                xlibro.Range("A" & ValorInicial).Value = fila("CODIGO DE CUOTA")
                xlibro.Range("B" & ValorInicial).Value = fila("CAPITAL INICIAL")
                xlibro.Range("C" & ValorInicial).Value = fila("AMORTIZACION")
                xlibro.Range("D" & ValorInicial).Value = fila("CAPITAL FINAL")
                xlibro.Range("E" & ValorInicial).Value = fila("INTERES")
                xlibro.Range("F" & ValorInicial).Value = fila("IGV")
                xlibro.Range("G" & ValorInicial).Value = fila("CUOTA TOTAL")
                xlibro.Range("H" & ValorInicial).Value = fila("FECHA DE INICIO")
                xlibro.Range("I" & ValorInicial).Value = fila("FECHA DE VENCIMIENTO")
                xlibro.Range("J" & ValorInicial).Value = fila("DIAS DE CUOTA")

                'Total = Total + (fila("cantidad") * fila("precio"))

                ValorInicial += 1

            Next


        End If
        conexion.conexion2.Close()
    End Sub
    Public Sub b_cliente()

        nc = Anex_Cronog.t2.Text
        sql = "exec ver_reg_cliente '" + nc + "'"
        conexion.conectarfondo()
        com = New SqlClient.SqlCommand(sql, conexion.conexion2)
        dr = com.ExecuteReader
        If dr.Read Then
            nom_clie = dr(2) + dr(3) + dr(4)
            ruc_clie = dr(6)
        Else
            MessageBox.Show("Los Datos no Existen")
        End If
        conexion.conexion2.Close()

    End Sub
End Class