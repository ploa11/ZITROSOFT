Public Class inicio
    Public USU, NOM, APE, COD, DNI, CLAVE, CARGO, SEDE As String
    'variables de conexion sql
    Dim com As SqlClient.SqlCommand, dr As SqlClient.SqlDataReader
    Dim da As SqlClient.SqlDataAdapter, cb As SqlClient.SqlCommandBuilder

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("www.rumi-ingenieros.com")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BUSCAR_USUARIO()
        Form_rev_rq.Show()

    End Sub

    Dim ds As DataSet
    Dim dt As DataTable

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Dim res, o As Integer
    Dim preg, sql, accion As String
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub BUSCAR_USUARIO()
        Dim adm, clave As String
        adm = TextBox1.Text
        clave = TextBox2.Text

        If adm = "Administrador" And clave = "Rumisoft" Then
            Form_principal.Show()
            Me.Hide()
        Else
            Try
                sql = "select *from USUARIOS where  DNI='" + TextBox1.Text + "'AND CLAVE ='" + TextBox2.Text + "'"
                Form_Reg_SRV_SQL.conectar()
                com = New SqlClient.SqlCommand(sql, Form_Reg_SRV_SQL.conexion)
                dr = com.ExecuteReader

                If dr.Read Then
                    COD = dr(0)
                    NOM = dr(1)
                    APE = dr(2)
                    DNI = dr(3)
                    CARGO = dr(4)
                    clave = dr(5)
                    SEDE = dr(8)
                    dr.Close()
                    Form_Reg_SRV_SQL.conexion.Close()

                    Form_principal.Show()
                    Me.Hide()

                Else
                    MessageBox.Show("USUARIO NO EXISTE,INGRESE DATOS CORRECTOS", "RUMISOFT", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
                'cod = dr(0)
                'dr.Close()
                ' Form_Reg_SRV_SQL.conexion.Close()


            Catch ex As Exception

            End Try

        End If


    End Sub
End Class