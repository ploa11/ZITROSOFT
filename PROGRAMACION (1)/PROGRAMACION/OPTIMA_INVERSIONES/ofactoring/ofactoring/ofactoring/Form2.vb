Option Strict On
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form2
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
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder
    Dim accion, sql, nc, gest, tip_partic As String

    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        Button1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenar_chart()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub

    Dim drc As String, cmd As String, dto As String, dpo As String, pvc As String
    Dim ds As DataSet
    Dim dt As DataTable
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'llenar_chart()

    End Sub
    Private Sub llenar_chart()
        'sql = "select  [FECHA ACTUAL],[VALOR CUOTA ACTUAL]-100 AS [VALOR CUOTA ACTUAL] FROM V_DATOS_FONDO where [FECHA ACTUAL] >='" + dtp1.Value.ToString("yyyyMMdd") + "' and [FECHA ACTUAL] <='" + dtp2.Value.ToString("yyyyMMdd") + "' order by [FECHA ACTUAL]"
        'sql = "select  [FECHA ACTUAL],[% CRECIMIENTO ACUMULADO VC] FROM V_DATOS_FONDO where [FECHA ACTUAL] >='" + dtp1.Value.ToString("yyyyMMdd") + "' and [FECHA ACTUAL] <='" + dtp2.Value.ToString("yyyyMMdd") + "' order by [FECHA ACTUAL]"
        '  sql = "select  FECHA as [FECHA ACTUAL],crece_acum_vc_porce AS [% CRECIMIENTO ACUMULADO VC] FROM DATOS_FONDO where FECHA >='" + dtp1.Value.ToString("yyyyMMdd") + "' and FECHA<='" + dtp2.Value.ToString("yyyyMMdd") + "' order by FECHA"
        sql = "select  format(FECHA,'dd/MM/yyyy') as [FECHA],crece_acum_vc_porce  FROM DATOS_FONDO where FECHA >='" + dtp1.Value.ToString("yyyyMMdd") + "' and FECHA<='" + dtp2.Value.ToString("yyyyMMdd") + "' order by FECHA asc"

        conexion.conectarfondo()
        da = New SqlClient.SqlDataAdapter(sql, conexion.conexion2)
        cb = New SqlClient.SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "DATOS_FONDO")
        Chart1.Series(0).Points.Clear()
        Chart1.Series(0).IsValueShownAsLabel = True
        Chart1.Series(0).ChartType = SeriesChartType.Line
        Chart1.ChartAreas(0).Area3DStyle.Enable3D = True
        Chart1.Series(0).Color = Color.Blue
        Chart1.Series(0).XValueMember = "FECHA"
        Chart1.Series(0).YValueMembers = "crece_acum_vc_porce"
        Chart1.Series(0).Name = "CRECIMIENTO ACUMULADO DEL VALOR CUOTA"
        Chart1.DataSource = ds
        'dgv.DataMember = "v_datos_fondo"
        conexion.conexion2.Close()
    End Sub


End Class