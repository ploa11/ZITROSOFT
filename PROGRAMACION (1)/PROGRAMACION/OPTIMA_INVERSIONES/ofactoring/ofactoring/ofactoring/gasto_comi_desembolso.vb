Public Class gasto_comi_desembolso
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub gasto_comi_desembolso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Gasto Comision Desembolso" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub t4_TextChanged(sender As Object, e As EventArgs) Handles t4.TextChanged

    End Sub
End Class