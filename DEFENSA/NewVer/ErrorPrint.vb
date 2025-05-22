Public Class ErrorPrint
    Public Property ParentForm As Form
    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Dim loginform As New ErrorLogin()
        loginform.ParentForm = Me
        loginform.Show()
    End Sub

    Private Sub ErrorPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class