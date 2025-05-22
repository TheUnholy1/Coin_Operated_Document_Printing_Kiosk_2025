Imports MySql.Data.MySqlClient

Public Class Page
    Private startPage As StartPage

    Public Sub New(startPageRef As StartPage)
        InitializeComponent()
        startPage = startPageRef

        ' Populate the ComboBoxes with values
        '  PopulateComboBoxes()
    End Sub

    Private Sub PopulateComboBoxes()
        cbLong.Items.Add(15)
        cbShort.Items.Add(15)
        cbLong.Items.Add(20)
        cbShort.Items.Add(20)
        cbLong.Items.Add(45)
        cbShort.Items.Add(45)
        cbLong.Items.Add(50)
        cbShort.Items.Add(50)
        cbLong.Items.Add(55)
        cbShort.Items.Add(55)
        cbLong.Items.Add(60)
        cbShort.Items.Add(60)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Get the current date
        Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim valueShort As Integer
        Dim valueLong As Integer
        Dim currentShort = Integer.Parse(startPage.lblPaperS.Text)
        Dim currentLong = Integer.Parse(startPage.lblPaperL.Text)

        ' Calculate remaining capacity for short and long papers
        Dim remainingShort = 60 - currentShort
        Dim remainingLong = 60 - currentLong

        ' Save Short Paper
        If Not String.IsNullOrWhiteSpace(cbShort.Text) AndAlso Integer.TryParse(cbShort.Text, valueShort) Then
            If valueShort < 1 OrElse valueShort > remainingShort Then
                MessageBox.Show($"You can only add up to {remainingShort} for Short paper.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cbShort.Text = ""
                Return
            Else
                SavePaperData("Short", valueShort, currentDate)
                UpdateAvailablePapers("Short", valueShort)
                LoadAvailablePapers() ' Update VB.NET properties
                cbShort.Text = ""
            End If
        End If

        ' Save Long Paper
        If Not String.IsNullOrWhiteSpace(cbLong.Text) AndAlso Integer.TryParse(cbLong.Text, valueLong) Then
            If valueLong < 1 OrElse valueLong > remainingLong Then
                MessageBox.Show($"You can only add up to {remainingLong} for Long paper.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cbLong.Text = ""
                Return
            Else
                SavePaperData("Long", valueLong, currentDate)
                UpdateAvailablePapers("Long", valueLong)
                LoadAvailablePapers() ' Update VB.NET properties
                cbLong.Text = ""
            End If
        End If

        ' Refresh paper count in StartPage
        startPage.UpdatePaper()
    End Sub

    Private Sub SavePaperData(paperSize As String, numberOfPaper As Integer, currentDate As String)
        Dim query As String = "INSERT INTO tblpaperload (kiosk_id, Date, papersize, NumberOfPaper) VALUES (@kiosk_id, @Date, @papersize, @NumberOfPaper)"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@kiosk_id", KioskID)
                command.Parameters.AddWithValue("@Date", currentDate)
                command.Parameters.AddWithValue("@papersize", paperSize)
                command.Parameters.AddWithValue("@NumberOfPaper", numberOfPaper)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    MessageBox.Show($"Saving successful! {numberOfPaper} {paperSize} papers added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    RecordLog(LoggedInAdmin, "Added " & numberOfPaper & " sheets of " & paperSize & " paper")
                Catch ex As Exception
                    MessageBox.Show($"Error saving paper data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub


    Private Sub cbShort_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbShort.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbLong_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbLong.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class