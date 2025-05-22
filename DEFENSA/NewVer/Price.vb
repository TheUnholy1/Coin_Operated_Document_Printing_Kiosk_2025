Imports MySql.Data.MySqlClient

Public Class Price
    Private startPage As StartPage
    Private Sub Price_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbLetterG.Text = Execute.LetterPriceG.ToString()
        tbLetterC.Text = Execute.LetterPriceC.ToString()
        tbLegalG.Text = Execute.LegalPriceG.ToString()
        tbLegalC.Text = Execute.LegalPriceC.ToString()
    End Sub
    Public Sub New(startPageRef As StartPage)
        InitializeComponent()
        startPage = startPageRef
    End Sub

    Private Sub tbLetterG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbLetterG.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub tbLetterC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbLetterC.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbLegalG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbLegalG.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub tbLegalC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbLegalC.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    ' Save button click event
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Load current prices from the database
        Dim currentPrices As Dictionary(Of String, Decimal) = GetCurrentPrices()

        If currentPrices Is Nothing OrElse currentPrices.Count = 0 Then
            MessageBox.Show("Failed to load current prices.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Track changes
        Dim changes As New List(Of String)
        Dim updateFields As New List(Of String)

        ' Check for price changes
        CheckAndUpdatePrice("PriceShortG", tbLetterG.Text, currentPrices, updateFields, changes)
        CheckAndUpdatePrice("PriceShortC", tbLetterC.Text, currentPrices, updateFields, changes)
        CheckAndUpdatePrice("PriceLongG", tbLegalG.Text, currentPrices, updateFields, changes)
        CheckAndUpdatePrice("PriceLongC", tbLegalC.Text, currentPrices, updateFields, changes)

        ' If no changes, stop
        If updateFields.Count = 0 Then
            MessageBox.Show("No changes detected. Prices are already up-to-date.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' Update prices
        Using con As New MySqlConnection(connectionString)
            Try
                con.Open()

                ' Build dynamic query
                Dim updateQuery As String = "UPDATE paperprice SET " & String.Join(", ", updateFields) & " WHERE Kiosk_ID = 1"
                Using cmd As New MySqlCommand(updateQuery, con)

                    ' Add parameters
                    For Each change In changes
                        Dim parts = change.Split(":")
                        cmd.Parameters.AddWithValue(parts(0), Convert.ToDecimal(parts(1)))
                    Next

                    ' Execute update
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Prices updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Log changes
                        For Each change In changes
                            Dim parts = change.Split(":")
                            Dim fieldName = parts(0).Replace("@", "")
                            Dim newValue = parts(1)

                            RecordLog(LoggedInAdmin, $"Updated {fieldName} to {newValue}")
                            LoadPrices()
                        Next
                    Else
                        MessageBox.Show("No records updated. Please try again.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error updating prices: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Function GetCurrentPrices() As Dictionary(Of String, Decimal)
        Dim prices As New Dictionary(Of String, Decimal)

        Using con As New MySqlConnection(connectionString)
            Try
                con.Open()
                Dim query As String = "SELECT PriceShortG, PriceShortC, PriceLongG, PriceLongC FROM paperprice WHERE Kiosk_ID = 1"
                Using cmd As New MySqlCommand(query, con)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            prices("PriceShortG") = reader.GetDecimal("PriceShortG")
                            prices("PriceShortC") = reader.GetDecimal("PriceShortC")
                            prices("PriceLongG") = reader.GetDecimal("PriceLongG")
                            prices("PriceLongC") = reader.GetDecimal("PriceLongC")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading current prices: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return prices
    End Function
    Private Sub CheckAndUpdatePrice(fieldName As String, newValue As String, currentPrices As Dictionary(Of String, Decimal), updateFields As List(Of String), changes As List(Of String))
        If Decimal.TryParse(newValue, Nothing) Then
            Dim newPrice As Decimal = Convert.ToDecimal(newValue)

            ' Only update if the price changed
            If newPrice <> currentPrices(fieldName) Then
                updateFields.Add($"{fieldName} = @{fieldName}")
                changes.Add($"@{fieldName}:{newPrice}")
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class