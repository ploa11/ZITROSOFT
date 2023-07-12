Public Class devoluciones
    Private Sub devoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'dgv.AllowUserToAddRows = False
            Me.Text = "Devoluciones de Operaciones" & " | " & Datos_Generales_del_Fondo.t2.Text & " | " & Datos_Generales_del_Fondo.t1.Text
            't22.Text = "Anexo"
            'llenar_combo1()
            'llenar_grid()
            'Label17.Hide()
            't12.Hide()
        Catch ex As Exception
            MessageBox.Show("No se pueder mostrar los datos", "Optima")
        End Try

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles t7.TextChanged

    End Sub
End Class