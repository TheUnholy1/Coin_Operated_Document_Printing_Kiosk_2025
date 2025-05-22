Imports System.Diagnostics
Imports System.Threading
Public Class Login
    Private enteredUsername As String
    Private enteredPassword As String

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        enteredUsername = tbUser.Text.Trim()
        enteredPassword = tbPass.Text.Trim()
        Dim userName As String = ValidateLogin(enteredUsername, enteredPassword)

        If Not String.IsNullOrEmpty(userName) Then
            MessageBox.Show("Welcome, " & userName & "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoggedInAdmin = userName
            tbUser.Clear()
            tbPass.Clear()
            Me.Hide()
            RecordLog(userName, "Logged in")
            Dim settingsForm As New Settings(StartPage)
            settingsForm.ShowDialog()
        Else
            MessageBox.Show("Invalid PIN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Clear the textbox
            tbUser.Clear()
            tbPass.Clear()
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        If (Letterpaper <= 1 Or Legalpaper <= 1) Then

            Me.Hide()
            noPaper.TopMost = True
            noPaper.Show()

        ElseIf Execute.Funds <= 1 Then

            Me.Hide()
            Hopper.TopMost = True
            Hopper.Show()
        Else
            Me.Hide()

        End If

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbUser.Focus()
    End Sub

End Class
