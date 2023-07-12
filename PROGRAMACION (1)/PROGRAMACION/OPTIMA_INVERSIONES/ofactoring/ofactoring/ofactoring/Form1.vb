Public Class param_asientos

    Public plan As Integer
    Dim i As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_DoubleClick(sender As Object, e As EventArgs) Handles cb1.DoubleClick

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub t1_TextChanged(sender As Object, e As EventArgs) Handles t1.TextChanged

    End Sub

    Private Sub t1_DoubleClick(sender As Object, e As EventArgs) Handles t1.DoubleClick
        Cuentas_de_Amarres_de_Debe_y_Haber.Show()
        plan = 1
    End Sub

    Private Sub param_asientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Enabled = False
        ListView1.View = False
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        dgv.Visible = False
        ListView1.Visible = True
        t1.Enabled = True
        t2.Enabled = True
        t3.Enabled = True
        t4.Enabled = True
        t5.Enabled = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            For i = 0 To 100
                Dim linea As New ListViewItem(i)
                linea.SubItems.Add(t4.Text)
                linea.SubItems.Add(cb1.Text)
                linea.SubItems.Add(t1.Text)
                linea.SubItems.Add(t2.Text)
                linea.SubItems.Add(t3.Text)
                linea.SubItems.Add(t4.Text)
                linea.SubItems.Add(t5.Text)
                ListView1.Items.Add(linea)
                'If MsgBox() Then
            Next
        Catch ex As Exception

        End Try

    End Sub
End Class