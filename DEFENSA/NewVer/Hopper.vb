Public Class Hopper


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Login.ShowDialog()

        '    StartPage.Show()
        ' Optionally show the Login form
        '  Dim loginForm As New Login
        '  loginForm.ShowDialog()
    End Sub
End Class