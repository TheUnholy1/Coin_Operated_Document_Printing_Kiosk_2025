Public Class ErrorLogin
    Public Property ParentForm As Form
    Private Sub ErrorLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbUser.Focus()
    End Sub
    Private enteredUsername As String
    Private enteredPassword As String
    Private LoggedInUserName As String


    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        enteredUsername = tbUser.Text.Trim()
        enteredPassword = tbPass.Text.Trim()
        Dim userName As String = ValidateLogin(enteredUsername, enteredPassword)

        If Not String.IsNullOrEmpty(userName) Then
            MessageBox.Show("Welcome, " & userName & "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoggedInUserName = userName
            tbUser.Clear()
            tbPass.Clear()
            Me.Hide()
            If ParentForm IsNot Nothing Then
                ParentForm.Close()
            End If
            RecordLog(userName, "Logged in")
            Dim startpageForm As New StartPage()
            'startpageForm.InitializeComponents()
            startpageForm.Show()
            '   Dim settingsForm As New Settings(StartPage)
            '  settingsForm.ShowDialog()
        Else
            MessageBox.Show("Invalid PIN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Clear the textbox
            tbUser.Clear()
            tbPass.Clear()
        End If
    End Sub



    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        '  If (Letterpaper <= 1 Or Legalpaper <= 1) Then

        '  Me.Hide()
        ' noPaper.TopMost = True
        'noPaper.Show()

        'ElseIf Execute.Funds <= 1 Then

        'Me.Hide()
        'Hopper.TopMost = True
        'Hopper.Show()
        'Else
        'Me.Hide()

        'End If

    End Sub
End Class