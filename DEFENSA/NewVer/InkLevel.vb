Public Class InkLevel
    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub

    Private Sub InkLevel_Load(sender As Object, e As EventArgs) Handles Me.Load
        'full screen
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class