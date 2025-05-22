Imports System.Drawing.Printing
Imports System.Management
Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient


Module Execute

    'update date and time
    Public Sub UpdateDateTime()
        StartPage.lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss tt").ToUpper()
    End Sub
    Public LoggedInAdmin As String
    Public Property Credits As Integer = 0
    Public Property Funds As Integer = 0
    Public Property Letterpaper As Integer = 0
    Public Property Legalpaper As Integer = 0

    Public Property LetterPriceG As Integer = 0
    Public Property LegalPriceG As Integer = 0
    Public Property LetterPriceC As Integer = 0
    Public Property LegalPriceC As Integer = 0
    Private Property LastTotalPrinted As Integer = 0
    Public Property SukliMo As Integer = 0

    Public Property KioskID As String = "1"

    Public connectionString As String = "server=127.0.0.1;User Id=root;port=3306;database=codpkv2"

    Public Function IsPrinterReady(printerName As String) As Boolean
        Try
            ' Create a PrinterSettings object
            Dim printerSettings As New PrinterSettings()
            printerSettings.PrinterName = printerName

            ' Check if the printer is valid
            If Not printerSettings.IsValid Then
                '  MessageBox.Show($"The printer '{printerName}' is not valid or accessible.", "Printer Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Use WMI to get detailed printer status
            Dim query As String = $"SELECT * FROM Win32_Printer WHERE Name = '{printerName.Replace("\", "\\")}'"
            Using searcher As New ManagementObjectSearcher(query)
                For Each printer As ManagementObject In searcher.Get()
                    Dim isPrinterOnline As Boolean = CBool(printer("WorkOffline")) = False
                    Dim printerStatus As Integer = Convert.ToInt32(printer("PrinterStatus"))

                    ' Printer is offline
                    If Not isPrinterOnline Then
                        '   MessageBox.Show($"The printer '{printerName}' is offline.", "Printer Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If

                    ' Check for specific printer statuses (e.g., ready, printing, error, etc.)
                    If printerStatus <> 3 Then ' 3 means "Ready"
                        '  MessageBox.Show($"The printer '{printerName}' is not ready. Status code: {printerStatus}", "Printer Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                Next
            End Using

            ' If all checks pass, the printer is ready
            Return True
        Catch ex As Exception
            MessageBox.Show("Error checking printer status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Sub SaveFinalCoinsToDatabase()
        Using connection As New MySqlConnection(connectionString)
            ' Update query to set CoinAmount for the existing record (e.g., ID = 1)
            Dim query As String = "UPDATE InsertedCoins SET CoinAmount = @CoinAmount WHERE ID = 1"

            Using command As New MySqlCommand(query, connection)
                ' Adding the CoinAmount parameter to the query
                command.Parameters.AddWithValue("@CoinAmount", Credits)

                Try
                    connection.Open()
                    command.ExecuteNonQuery() ' Execute the update query
                    '  MessageBox.Show("Coins updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show($"Error saving coins: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
    Public Sub LoadCreditsFromDatabase()
        Using connection As New MySqlConnection(connectionString)
            Dim query As String = "SELECT CoinAmount FROM InsertedCoins WHERE ID = 1"

            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    If result IsNot Nothing Then
                        Credits = Convert.ToInt32(result)
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Error loading credits: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
    Public Sub ResetCreditsToZero()
        Using connection As New MySqlConnection(connectionString)
            ' Update query to set Credits to zero
            Dim query As String = "UPDATE InsertedCoins SET CoinAmount = 0 WHERE ID = 1"

            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    Credits = 0  ' Reset the global Credits value as well
                    '       MessageBox.Show("Credits reset to zero for the print job.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show($"Error resetting credits: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub


    Public Sub ResetChangetoZero()
        SukliMo = 0
    End Sub

    Public Sub UpdateAvailablePapers(paperSize As String, numberOfPaper As Integer)
        Dim columnToUpdate As String = If(paperSize = "Short", "AvailableShort", "AvailableLong")
        Dim query As String = $"UPDATE tblavailablepapers SET {columnToUpdate} = {columnToUpdate} + @NumberOfPaper WHERE Kiosk_ID = @Kiosk_ID"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@NumberOfPaper", numberOfPaper)
                command.Parameters.AddWithValue("@Kiosk_ID", KioskID)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show($"Error updating available {paperSize} paper: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Public Sub LoadAvailablePapers()
        Dim query As String = "SELECT AvailableShort, AvailableLong FROM tblavailablepapers WHERE Kiosk_ID = @Kiosk_ID"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Kiosk_ID", KioskID)

                Try
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Letterpaper = Convert.ToInt32(reader("AvailableShort"))
                            Legalpaper = Convert.ToInt32(reader("AvailableLong"))
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show($"Error loading available papers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
    Public Sub DeductPaper(isLetterSize As Boolean, numberOfPages As Integer)
        Dim query As String
        If isLetterSize Then
            query = "UPDATE tblavailablepapers SET AvailableShort = AvailableShort - @NumberOfPages WHERE Kiosk_ID = @Kiosk_ID AND AvailableShort >= @NumberOfPages"
        Else
            query = "UPDATE tblavailablepapers SET AvailableLong = AvailableLong - @NumberOfPages WHERE Kiosk_ID = @Kiosk_ID AND AvailableLong >= @NumberOfPages"
        End If

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Kiosk_Id", KioskID)
                command.Parameters.AddWithValue("@NumberOfPages", numberOfPages)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        Dim paperType As String = If(isLetterSize, "Short", "Long")
                        '   MessageBox.Show($"{numberOfPages} {paperType} papers deducted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show($"Not enough {If(isLetterSize, "Short", "Long")} papers available!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Catch ex As Exception
                    MessageBox.Show($"Error deducting paper: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
    Public Function GetAvailableFunds() As Integer
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()


                Dim selectQuery As String = "SELECT AvailableCoins FROM tblavailablefunds WHERE Kiosk_ID = @KioskID"

                Using selectCommand As New MySqlCommand(selectQuery, connection)
                    selectCommand.Parameters.AddWithValue("@KioskID", KioskID)
                    Dim result = selectCommand.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        Funds = Convert.ToInt32(result)
                    End If
                End Using

                Return Funds

            Catch ex As Exception
                MessageBox.Show($"Error retrieving available funds: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 0
            End Try
        End Using
    End Function

    Public Function DeductFunds(amountToDeduct As Integer) As Boolean
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Dim selectQuery As String = "SELECT AvailableCoins FROM tblavailablefunds WHERE Kiosk_ID = @KioskID"

                Using selectCommand As New MySqlCommand(selectQuery, connection)
                    selectCommand.Parameters.AddWithValue("@KioskID", KioskID)
                    Dim result = selectCommand.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        Funds = Convert.ToInt32(result)
                    End If
                End Using

                ' Check if there are enough funds
                If Funds < amountToDeduct Then
                    MessageBox.Show("Insufficient funds!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                ' Deduct from available funds
                Dim updateQuery As String = "UPDATE tblavailablefunds SET AvailableCoins = AvailableCoins - @Amount WHERE Kiosk_ID = @KioskID"
                Using updateCommand As New MySqlCommand(updateQuery, connection)
                    updateCommand.Parameters.AddWithValue("@KioskID", KioskID)
                    updateCommand.Parameters.AddWithValue("@Amount", amountToDeduct)
                    updateCommand.ExecuteNonQuery()
                End Using

                ' MessageBox.Show($"Successfully deducted {amountToDeduct} coins.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True

            Catch ex As Exception
                MessageBox.Show($"Error deducting funds: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Public Sub LoadPrices()
        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "SELECT PriceShortG, PriceLongG, PriceShortC, PriceLongC FROM PaperPrice WHERE Kiosk_ID = 1"
            Dim cmd As New MySqlCommand(query, conn)

            Try
                conn.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    ' Ensure no NULL values before conversion
                    LegalPriceG = If(IsDBNull(reader("PriceLongG")), 0, Convert.ToInt32(reader("PriceLongG")))
                    LegalPriceC = If(IsDBNull(reader("PriceLongC")), 0, Convert.ToInt32(reader("PriceLongC")))
                    LetterPriceG = If(IsDBNull(reader("PriceShortG")), 0, Convert.ToInt32(reader("PriceShortG")))
                    LetterPriceC = If(IsDBNull(reader("PriceShortC")), 0, Convert.ToInt32(reader("PriceShortC")))
                End If

                reader.Close()
                '  MessageBox.Show("Price Loaded!")
            Catch ex As Exception
                MessageBox.Show("Error loading prices: " & ex.Message)
            End Try
        End Using
    End Sub
    Public Function GetLatestTransactionID(kioskID As Integer) As Integer
        Dim transactionID As Integer = 0
        Dim query As String = "SELECT MAX(Transaction_ID) FROM Transactions WHERE Kiosk_ID = @KioskID"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@KioskID", kioskID)

                Try
                    conn.Open()
                    transactionID = Convert.ToInt32(cmd.ExecuteScalar()) ' Get the latest transaction ID
                Catch ex As Exception
                    MessageBox.Show("Error fetching latest transaction: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Return transactionID
    End Function

    Public Sub UpdatePrintStatus(transactionID As Integer, printStatus As String)
        Dim query As String = "UPDATE Transactions SET Print_Status = @PrintStatus WHERE Transaction_ID = @TransactionID"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@PrintStatus", printStatus)
                cmd.Parameters.AddWithValue("@TransactionID", transactionID)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    '  MessageBox.Show("Transaction print status updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error updating transaction: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub
    Public Sub HandlePrintCompletion(kioskID As Integer, printStatus As String)
        Dim transactionID As Integer = GetLatestTransactionID(kioskID)
        If transactionID > 0 Then
            UpdatePrintStatus(transactionID, printStatus)
        Else
            MessageBox.Show("No transactions found to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Function ValidateLogin(username As String, password As String) As String
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                ' Query to get Name based on Username & Password
                Dim query As String = "SELECT Name FROM users WHERE username = @username AND password = @password"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    Dim result As Object = cmd.ExecuteScalar()

                    ' If user exists, return the Name
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        Return result.ToString()
                    Else
                        Return String.Empty ' No matching user found
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return String.Empty
            End Try
        End Using
    End Function
    Public Sub RecordLog(adminName As String, action As String)
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Dim query As String = "INSERT INTO tblhistory (admin_name, action) VALUES (@adminName, @action)"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@adminName", adminName)
                    cmd.Parameters.AddWithValue("@action", action)

                    cmd.ExecuteNonQuery()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error logging action: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    Public Sub LoadLogHistory(dgv As DataGridView)
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()

                Dim query As String = "SELECT log_id, admin_name, action, timestamp FROM tblhistory ORDER BY timestamp DESC"

                Dim adapter As New MySqlDataAdapter(query, connection)
                Dim table As New DataTable()
                adapter.Fill(table)

                dgv.DataSource = table
                DisableDataGridViewEditing(dgv)
                ApplyTextWrapping(dgv)
            Catch ex As Exception
                MessageBox.Show("Error loading log history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    ' Function to load data from the users table into DataGridView
    Public Sub LoadUsersData(dgv As DataGridView)
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "SELECT id, name, username, password, Kiosk_ID FROM users"
                Dim adapter As New MySqlDataAdapter(query, connection)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgv.DataSource = table
                DisableDataGridViewEditing(dgv)
                ApplyTextWrapping(dgv)
            Catch ex As Exception
                MessageBox.Show("Error loading users data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    ' Function to load data from the transactions table into DataGridView
    Public Sub LoadTransactionsData(dgv As DataGridView)
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "SELECT Transaction_ID, Kiosk_ID, Transaction_DateTime, File_Name, " &
                               "Number_Of_Pages, Print_Type, Payment, Change_Amount, Print_Status FROM transactions"
                Dim adapter As New MySqlDataAdapter(query, connection)
                Dim table As New DataTable()
                adapter.Fill(table)
                dgv.DataSource = table
                DisableDataGridViewEditing(dgv)
                ApplyTextWrapping(dgv)
            Catch ex As Exception
                MessageBox.Show("Error loading transactions data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub


    Private Sub DisableDataGridViewEditing(dgv As DataGridView)
        ' Set the DataGridView to be read-only so that cells cannot be edited
        dgv.ReadOnly = True
        ' Prevent row and cell selection
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.AllowUserToAddRows = False ' Disable the "add new row" feature
        dgv.AllowUserToDeleteRows = False ' Disable row deletion
        dgv.MultiSelect = False ' Disable multi-select behavior
        ' Optionally, you can also hide gridlines
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.None

        ' Disable click events
        dgv.Enabled = False
    End Sub
    Public Sub ApplyTextWrapping(dgv As DataGridView)
        ' Ensure DataGridView is not null
        If dgv Is Nothing Then Exit Sub

        ' Enable text wrapping for all columns
        For Each column As DataGridViewColumn In dgv.Columns
            column.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Next

        ' Ensure rows resize properly when text wraps
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    'load the total number of printed that has been success
    Public Sub LoadLastTotalPrinted()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT SUM(Number_Of_Pages) FROM transactions WHERE Kiosk_ID = 1 AND Print_Status = 'Success'"
                Using command As New MySqlCommand(query, connection)
                    Dim result = command.ExecuteScalar()

                    ' Store the initial total
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        LastTotalPrinted = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading last total printed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Function to get the updated total printed pages
    Public Function GetUpdatedPrintedTotal() As Integer
        Dim updatedTotal As Integer = 0
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT SUM(Number_Of_Pages) FROM transactions WHERE Kiosk_ID = 1 AND Print_Status = 'Success'"
                Using command As New MySqlCommand(query, connection)
                    Dim result = command.ExecuteScalar()

                    ' Return the updated total
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        updatedTotal = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while getting updated total printed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return updatedTotal
    End Function

    ' Sub to check if we've crossed a 1000-page threshold
    Public Sub CheckForInkMonitor()
        Dim updatedTotal As Integer = GetUpdatedPrintedTotal()
        Dim pagesPrintedSinceLastCheck As Integer = updatedTotal - LastTotalPrinted

        If pagesPrintedSinceLastCheck >= 1000 Then
            Dim inkMonitor As New InkLevel()
            inkMonitor.Show()

            ' Update the last printed count to the nearest multiple of 1000
            LastTotalPrinted = updatedTotal - (updatedTotal Mod 1000)
        End If
    End Sub


End Module
