
Public Class LowPaper
    Public Sub New(ByVal paperSCount As Integer, ByVal paperLCount As Integer)
        InitializeComponent()


    End Sub

    Private Sub btnOk_Click_1(sender As Object, e As EventArgs) Handles btnOk.Click
        lbl1.Text = String.Empty
        Me.Close()
    End Sub

    Private Sub LowPaper_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lbl1_Click(sender As Object, e As EventArgs) Handles lbl1.Click

    End Sub
End Class
