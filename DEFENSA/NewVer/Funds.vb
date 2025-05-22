Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports MySql.Data.MySqlClient

Public Class Funds
    Private startPage As StartPage

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' Constructor to accept a reference to StartPage
    Public Sub New(startPageRef As StartPage)
        InitializeComponent()
        startPage = startPageRef

        ' Populate the ComboBoxes with values
        '   PopulateComboBoxes()
    End Sub
    Private Sub PopulateComboBoxes()

        cbCoins.Items.Add(10)
        cbCoins.Items.Add(50)
        cbCoins.Items.Add(80)
        cbCoins.Items.Add(90)
        cbCoins.Items.Add(100)
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim value As Integer
        Dim currentFunds = Integer.Parse(startPage.lblFunds.Text)
        Dim remainingFunds = 300 - currentFunds




        ' Validate input from cbCoins
        If Not String.IsNullOrWhiteSpace(cbCoins.Text) Then
            If Integer.TryParse(cbCoins.Text, value) Then
                If value < 1 OrElse value > remainingFunds Then
                    MessageBox.Show($"You can only add up to {remainingFunds}.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cbCoins.Text = ""
                    Return
                Else
                    ' Insert into tblcoinfunds
                    Using connection As New MySqlConnection(connectionString)
                        Try
                            connection.Open()
                            Dim query As String = "INSERT INTO tblcoinfunds (kiosk_id, Date, CoinsFund) VALUES (@KioskID, @Date, @CoinsFund)"
                            Using command As New MySqlCommand(query, connection)
                                command.Parameters.AddWithValue("@KioskID", KioskID) ' Assuming KioskID is defined elsewhere
                                command.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                command.Parameters.AddWithValue("@CoinsFund", value)

                                command.ExecuteNonQuery()
                            End Using
                            ' Update available funds in tblavailablefunds
                            Dim updateQuery As String = "UPDATE tblavailablefunds SET AvailableCoins = AvailableCoins + @Amount WHERE Kiosk_ID = @KioskID"
                            Using updateCommand As New MySqlCommand(updateQuery, connection)
                                updateCommand.Parameters.AddWithValue("@KioskID", KioskID)
                                updateCommand.Parameters.AddWithValue("@Amount", value)
                                updateCommand.ExecuteNonQuery()
                            End Using
                            MessageBox.Show("Funds saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            RecordLog(LoggedInAdmin, "Added funds: " & value & " PHP")
                            ' Update UI and reset ComboBox
                            ' startPage.UpdateCredits(value.ToString())

                            cbCoins.Text = ""

                        Catch ex As Exception
                            MessageBox.Show($"Error saving funds: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Using
                End If
            Else
                MessageBox.Show("Only numbers are allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        startPage.UpdateHopper()
        '      startPage.UpdateCredits(cbCoins.SelectedItem.ToString())
        '     cbCoins.SelectedIndex = -1 ' No item selected
        ' Me.Close()
    End Sub
    Private Sub cbCoins_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbCoins.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class