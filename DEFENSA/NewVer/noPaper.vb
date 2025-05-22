Public Class noPaper
    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()

        '  StartPage.Show()
        Login.ShowDialog()
    End Sub


End Class