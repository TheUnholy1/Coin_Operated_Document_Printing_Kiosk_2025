Imports MySql.Data.MySqlClient

Public Class Dashboard
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblLegal.Text = Execute.Legalpaper.ToString()
        lblLetter.Text = Execute.Letterpaper.ToString()
        lblFunds.Text = Execute.Funds.ToString()
        Dim totalTransactions As Integer = GetTotalTransactions()
        lblTransactions.Text = totalTransactions.ToString()
        Dim totalIncome As Decimal = GetTotalIncome()
        lblIncome.Text = "₱" & totalIncome.ToString("N2") ' Format as currency
        Dim totalRefill As Integer = GetTotalPaperRefill()
        lblRefill.Text = totalRefill.ToString() & " Sheets"
    End Sub
    Private Function GetTotalTransactions() As Integer
        Dim totalTransactions As Integer = 0
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "SELECT COUNT(*) FROM transactions"
                Using command As New MySqlCommand(query, connection)
                    totalTransactions = Convert.ToInt32(command.ExecuteScalar())
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving transaction count: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return totalTransactions
    End Function
    Private Function GetTotalIncome() As Decimal
        Dim totalIncome As Decimal = 0

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "SELECT SUM(Payment) - SUM(Change_Amount) FROM transactions"
                Using command As New MySqlCommand(query, connection)
                    Dim result = command.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        totalIncome = Convert.ToDecimal(result)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving total income: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return totalIncome
    End Function
    Private Function GetTotalPaperRefill() As Integer
        Dim totalRefill As Integer = 0

        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "SELECT SUM(NumberOfPaper) FROM tblpaperload"
                Using command As New MySqlCommand(query, connection)
                    Dim result = command.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        totalRefill = Convert.ToInt32(result)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving total paper refill: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return totalRefill
    End Function

End Class