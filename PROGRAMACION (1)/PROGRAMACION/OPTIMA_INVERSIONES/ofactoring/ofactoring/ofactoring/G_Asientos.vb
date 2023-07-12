Public Class G_Asientos
    Private Sub G_Asientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        plancontable.dh = 3
    End Sub

    Private Sub cuenta_TextChanged(sender As Object, e As EventArgs) Handles cuenta.TextChanged

    End Sub

    Private Sub cuenta_DoubleClick(sender As Object, e As EventArgs) Handles cuenta.DoubleClick
        Cuentas_de_Amarres_de_Debe_y_Haber.Show()
    End Sub

    Private Sub cliente_TextChanged(sender As Object, e As EventArgs) Handles cod_cliente.TextChanged

    End Sub

    Private Sub cliente_DoubleClick(sender As Object, e As EventArgs) Handles cod_cliente.DoubleClick
        registro_clientes.activar = 1
        registro_clientes.Show()
        Label5.Visible = True
        cb1.Visible = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseClick


    End Sub

    Private Sub TextBox3_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox3.MouseDoubleClick

    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged
        Select Case cb1.Text
            Case "Cronograma"
                Label6.Visible = True
                TextBox3.Visible = True
                Anex_Cronog.Show()
                Anex_Cronog.cb3.Text = "Codigo de Cliente"
                Anex_Cronog.t13.Text = cod_cliente.Text
            Case "Anexo"
                Label6.Visible = True
                TextBox3.Visible = True
                Anexo.Show()

        End Select


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class