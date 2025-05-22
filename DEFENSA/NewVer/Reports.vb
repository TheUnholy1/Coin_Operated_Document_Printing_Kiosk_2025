
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Public Class Reports

    Private pageSize As Integer = 7 ' Number of rows per page
    Private currentPage As Integer = 1
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 0
    Private currentTableName As String = "tblhistory" ' Default table
    Private printDoc As New PrintDocument()
    ' Private printPreview As New PrintPreviewDialog()
    Dim printDialog As New PrintDialog()
    Private dgv As DataGridView = DataGridView1
    Private isFiltering As Boolean = False


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogHistory.Click


        isFiltering = False
        btnClear.PerformClick()
        btnClear.Visible = True
        btnFilter.Visible = True
        dtpFrom.Visible = True
        dtpTo.Visible = True
        tbSearch.Visible = True
        btnNext.Visible = True
        bntPrevious.Visible = True
        btnPrint.Visible = True
        lblPageNumber.Visible = True
        currentPage = 1
        currentTableName = "tblhistory"
        Panel1.Controls.Clear() ' Remove any form inside the panel
        Panel1.Controls.Add(DataGridView1) ' Re-add the DataGridView
        DataGridView1.Visible = True
        LoadLogHistory(DataGridView1)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        PerformSearch()
    End Sub

    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler printDoc.PrintPage, AddressOf PrintDataGridView
        Me.WindowState = FormWindowState.Maximized
        btnDashboard.PerformClick()
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            MessageBox.Show("No data available to print!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        dgv = DataGridView1

        Try
            Dim printDialog As New PrintDialog()
            Dim printPreview As New PrintPreviewDialog()
            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintDataGridView

            printPreview.Document = printDoc
            printDoc.DefaultPageSettings.Landscape = (dgv.ColumnCount > 5)
            Dim wasTopMost As Boolean = Me.TopMost
            Me.TopMost = False
            ' Show print preview first
            printPreview.ShowDialog()

            ' Ask user for confirmation before printing
            If printDialog.ShowDialog() = DialogResult.OK Then
                printDoc.PrinterSettings = printDialog.PrinterSettings
                printDoc.Print()
            End If
            Me.TopMost = wasTopMost
        Catch ex As Exception
            MessageBox.Show("Error printing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PrintDataGridView(sender As Object, e As PrintPageEventArgs)
        Dim font As New Font("Arial", 10, FontStyle.Regular)
        Dim boldFont As New Font("Arial", 10, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim rowHeight As Integer = 30
        Dim pageWidth As Integer = e.PageBounds.Width - 100
        Dim colWidths As New List(Of Integer)

        ' Handle landscape mode
        If dgv.ColumnCount > 5 Then
            printDoc.DefaultPageSettings.Landscape = True
            pageWidth = e.PageBounds.Height - 100
        Else
            printDoc.DefaultPageSettings.Landscape = False
        End If

        ' Calculate column widths based on what's visible
        For Each column As DataGridViewColumn In dgv.Columns
            If column.Visible Then
                colWidths.Add(Math.Max(100, pageWidth \ dgv.Columns.GetColumnCount(DataGridViewElementStates.Visible)))
            End If
        Next

        ' Handle empty grid
        If dgv.Rows.Count = 0 Then
            e.Graphics.DrawString("No data available to print!", font, brush, x, y)
            Exit Sub
        End If

        ' Print headers
        Dim maxHeaderHeight As Integer = rowHeight
        Dim colIndex As Integer = 0

        For Each column As DataGridViewColumn In dgv.Columns
            If column.Visible Then
                Dim textSize As SizeF = e.Graphics.MeasureString(column.HeaderText, boldFont, colWidths(colIndex))
                Dim requiredLines As Integer = Math.Ceiling(textSize.Width / colWidths(colIndex))
                maxHeaderHeight = Math.Max(maxHeaderHeight, rowHeight * requiredLines)

                Dim rect As New RectangleF(x, y, colWidths(colIndex), maxHeaderHeight)
                e.Graphics.DrawString(column.HeaderText, boldFont, brush, rect)

                x += colWidths(colIndex)
                colIndex += 1
            End If
        Next

        y += maxHeaderHeight
        x = 50

        ' Print visible rows
        For Each row As DataGridViewRow In dgv.Rows
            If row.Index = dgv.Rows.Count - 1 AndAlso row.IsNewRow Then Exit For

            x = 50
            colIndex = 0
            Dim maxRowHeight As Integer = rowHeight

            ' Calculate max row height (for wrapping)
            For Each cell As DataGridViewCell In row.Cells
                If cell.Visible Then
                    Dim cellText As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                    Dim textSize As SizeF = e.Graphics.MeasureString(cellText, font, colWidths(colIndex))
                    Dim requiredLines As Integer = Math.Ceiling(textSize.Width / colWidths(colIndex))
                    maxRowHeight = Math.Max(maxRowHeight, rowHeight * requiredLines)
                    colIndex += 1
                End If
            Next

            colIndex = 0

            ' Print cell content
            For Each cell As DataGridViewCell In row.Cells
                If cell.Visible Then
                    Dim cellText As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                    Dim rect As New RectangleF(x, y, colWidths(colIndex), maxRowHeight)
                    e.Graphics.DrawString(cellText, font, brush, rect)

                    x += colWidths(colIndex)
                    colIndex += 1
                End If
            Next

            y += maxRowHeight

            ' Handle page breaks
            If y + maxRowHeight > e.PageBounds.Height - 50 Then
                e.HasMorePages = True
                Return
            End If
        Next

        e.HasMorePages = False
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        DataGridView1.Visible = False
        Dim dashboard As New Dashboard()

        ' Set the Dashboard form as a child of the Panel
        dashboard.TopLevel = False
        dashboard.FormBorderStyle = FormBorderStyle.None
        dashboard.Dock = DockStyle.Fill

        ' Clear the current controls in the Panel
        Panel1.Controls.Clear()

        ' Add the form to the Panel
        Panel1.Controls.Add(dashboard)

        ' Show the form inside the Panel
        dashboard.Show()
        btnNext.Visible = False
        bntPrevious.Visible = False
        lblPageNumber.Visible = False
        btnPrint.Visible = False
        tbSearch.Visible = False
        isFiltering = False
        btnClear.Visible = False
        btnFilter.Visible = False
        dtpFrom.Visible = False
        dtpTo.Visible = False
    End Sub
    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        btnClear.PerformClick()
        btnClear.Visible = True
        btnFilter.Visible = True
        dtpFrom.Visible = True
        dtpTo.Visible = True
        tbSearch.Visible = True
        btnNext.Visible = True
        bntPrevious.Visible = True
        btnPrint.Visible = True
        lblPageNumber.Visible = True
        currentPage = 1
        currentTableName = "users"
        Panel1.Controls.Clear() ' Remove any form inside the panel
        Panel1.Controls.Add(DataGridView1) ' Re-add the DataGridView
        DataGridView1.Visible = True ' Make sure it's visible
        LoadUsersData(DataGridView1)
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        PerformSearch()
    End Sub
    Private Sub btnTransactions_Click(sender As Object, e As EventArgs) Handles btnTransactions.Click
        isFiltering = False
        btnClear.PerformClick()
        btnClear.Visible = True
        btnFilter.Visible = True
        dtpFrom.Visible = True
        dtpTo.Visible = True
        tbSearch.Visible = True
        btnNext.Visible = True
        bntPrevious.Visible = True
        btnPrint.Visible = True
        lblPageNumber.Visible = True
        currentPage = 1
        currentTableName = "transactions"
        Panel1.Controls.Clear() ' Remove any form inside the panel
        LoadTransactionsData(DataGridView1)
        Panel1.Controls.Add(DataGridView1)
        DataGridView1.Visible = True
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        PerformSearch()
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub
    Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        currentPage = 1
        PerformSearch()
    End Sub
    Private Sub PerformSearch()
        Dim query As String = ""
        Debug.WriteLine($"isFiltering: {isFiltering}")

        If Not isFiltering Then
            dtpFrom.Value = New DateTime(2000, 1, 1)  ' Reset to a very early date
            dtpTo.Value = New DateTime(2099, 12, 31)  ' Reset to a very far future date
        End If

        ' 🔹 Set page size based on table type
        If currentTableName = "transactions" Then
            pageSize = 10 ' Transactions page size
        Else
            pageSize = 20 ' Default page size
        End If

        Select Case currentTableName
            Case "tblhistory"
                query = "SELECT log_id, admin_name, action, timestamp FROM tblhistory 
                     WHERE (admin_name LIKE @search OR action LIKE @search)"
                If isFiltering Then
                    query &= " AND (timestamp BETWEEN @fromDate AND @toDate)"
                End If
                query &= " ORDER BY timestamp DESC LIMIT @offset, @pageSize"

            Case "users"
                query = "SELECT id, name, username, password, Kiosk_ID FROM users 
                     WHERE (name LIKE @search OR username LIKE @search) 
                     ORDER BY id ASC 
                     LIMIT @offset, @pageSize"

            Case "transactions"
                query = "SELECT Transaction_ID, Kiosk_ID, Transaction_DateTime, File_Name, Number_Of_Pages, 
                            Print_Type, Payment, Change_Amount
                     FROM transactions 
                     WHERE (File_Name LIKE @search OR Print_Status LIKE @search OR Print_Type LIKE @search OR Payment LIKE @search)"
                If isFiltering Then
                    query &= " AND (Transaction_DateTime BETWEEN @fromDate AND @toDate)"
                End If

                query &= " ORDER BY Transaction_DateTime DESC LIMIT @offset, @pageSize"

            Case Else
                MessageBox.Show("No valid table selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        Using con As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@search", "%" & tbSearch.Text & "%")
                cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize)
                cmd.Parameters.AddWithValue("@pageSize", pageSize)
                If isFiltering Then
                    cmd.Parameters.AddWithValue("@fromDate", dtpFrom.Value.Date)
                    cmd.Parameters.AddWithValue("@toDate", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))
                End If

                Try
                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    If dt.Rows.Count > 0 Then
                        DataGridView1.DataSource = dt
                        ApplyTextWrapping(DataGridView1)
                    Else
                        DataGridView1.DataSource = Nothing
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        GetTotalRecordCount()
        UpdatePaginationButtons()
    End Sub

    Private Sub GetTotalRecordCount()
        Dim countQuery As String = ""

        Select Case currentTableName
            Case "tblhistory"
                countQuery = "SELECT COUNT(*) FROM tblhistory 
                          WHERE (admin_name LIKE @search OR action LIKE @search) 
                          AND (timestamp BETWEEN @fromDate AND @toDate)"

            Case "users"
                countQuery = "SELECT COUNT(*) FROM users 
                          WHERE (name LIKE @search OR username LIKE @search)"

            Case "transactions"
                countQuery = "SELECT COUNT(*) FROM transactions 
                          WHERE (File_Name LIKE @search OR Print_Status LIKE @search) 
                          AND (Transaction_DateTime BETWEEN @fromDate AND @toDate)"

            Case Else
                MessageBox.Show("No valid table selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        Using con As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(countQuery, con)
                cmd.Parameters.AddWithValue("@search", "%" & tbSearch.Text & "%")
                cmd.Parameters.AddWithValue("@fromDate", dtpFrom.Value.Date)
                cmd.Parameters.AddWithValue("@toDate", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))

                Try
                    con.Open()
                    totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
                    If totalRecords > 0 Then
                        totalPages = Math.Ceiling(totalRecords / pageSize)
                    Else
                        totalPages = 1 ' Ensure at least one page
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error fetching total record count: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub UpdatePaginationButtons()
        bntPrevious.Enabled = (currentPage > 1)
        btnNext.Enabled = (currentPage < totalPages)
        lblPageNumber.Text = $"Page {currentPage} of {totalPages}"
        lblPageNumber.Refresh()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles bntPrevious.Click
        If currentPage > 1 Then
            currentPage -= 1
            PerformSearch()
        End If
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentPage < totalPages Then
            currentPage += 1
            PerformSearch()
        End If
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        isFiltering = True
        currentPage = 1
        PerformSearch()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        isFiltering = False
        dtpFrom.Value = New DateTime(2000, 1, 1)  ' Reset to a very early date
        dtpTo.Value = New DateTime(2099, 12, 31)  ' Reset to a very far future date

        ' Optionally, clear the search text box
        tbSearch.Text = ""

        ' Refresh DataGridView with all records
        currentPage = 1 ' Reset pagination to first page
        PerformSearch()
    End Sub

End Class