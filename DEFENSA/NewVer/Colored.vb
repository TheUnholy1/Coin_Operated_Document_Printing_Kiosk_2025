Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports iText.Kernel.Pdf
Imports Ghostscript.NET.Rasterizer
Imports System.IO.Ports
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles

Public Class Colored

    Private pdfFilePath As String
    Private pdfFileName As String
    Private fromPage As Integer
    Private toPage As Integer
    Private _paperL As Integer
    Private _paperS As Integer
    Private _copies As Integer
    Private _isLetterSize As Boolean
    Private outputPdfPath As String
    Private _fileFilter As String
    Private totalPages As Integer = 0
    Private Copies As Integer = 1
    Private LetterSizeCostPerPage As Integer = Execute.LetterPriceC
    Private LegalSizeCostPerPage As Integer = Execute.LegalPriceC
    Private Coins As Integer = Execute.Credits
    Private hasEnoughPaper As Boolean
    Private previewForm As Preview
    Private OriginalPath As String
    Private WithEvents SerialPort2 As New SerialPort()
    Private processSuccess As Boolean

    Public Sub New(ByVal filePath As String, ByVal fileName As String, ByVal paperL As Integer, ByVal paperS As Integer, ByVal fileFilter As String, ByVal preview As Preview, ByVal originalFilePath As String)
        InitializeComponent()
        pdfFilePath = filePath
        pdfFileName = fileName
        _paperL = paperL
        _paperS = paperS
        _fileFilter = fileFilter
        Me.previewForm = preview
        ' Coins = credits
        OriginalPath = originalFilePath

    End Sub

    Private Async Sub Colored_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        If Not String.IsNullOrEmpty(pdfFilePath) Then
            ' Automatically select the radio buttons for All pages and Letter and portrait
            rbAllPagess.Checked = True
            rbLetter.Checked = True
            rbPortrait.Checked = True
            ' Get total pages
            totalPages = Await GetPdfPageCountAsync(pdfFilePath)
            Console.WriteLine($"Total Pages: {totalPages}")

            ' Set initial values
            tbFrom.Text = "1"
            tbTo.Text = totalPages.ToString()

            ' Validate page range and check if page to be printed is less than 60
            UpdatePreview()
            LoadCreditsFromDatabase()
            lblCredits.Text = Execute.Credits.ToString()
            ComputePayment()

        End If
        OpenComPort()
        ResetChangetoZero()
    End Sub
    Public Sub OpenComPort()
        Try
            If Not SerialPort2.IsOpen Then
                SerialPort2.PortName = "COM4"  ' Adjust to your specific COM port
                SerialPort2.BaudRate = 9600
                AddHandler SerialPort2.DataReceived, AddressOf SerialPort2_DataReceived
                SerialPort2.Open()
                Debug.WriteLine("COM port opened successfully.")
            Else
                Debug.WriteLine("port already open")
            End If

        Catch ex As Exception
            MessageBox.Show($"Failed to open COM port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CloseComPort()
        Try
            If SerialPort2.IsOpen Then
                ' Remove the DataReceived event handler
                RemoveHandler SerialPort2.DataReceived, AddressOf SerialPort2_DataReceived

                ' Close the COM port
                SerialPort2.Close()
                Debug.WriteLine("COM port closed successfully.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to close COM port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Method to compute the payment based on page range, paper size, and copies
    Private Sub ComputePayment()
        Try
            ' Get the current credits from lblCredits
            Dim coinsAvailable As Integer = Integer.Parse(lblCredits.Text.Trim())

            ' Get the number of copies
            Dim numCopies As Integer = Integer.Parse(tbCopies.Text.Trim())

            ' Get the page range
            Dim fromPage As Integer = If(Integer.TryParse(tbFrom.Text.Trim(), Nothing), Convert.ToInt32(tbFrom.Text.Trim()), 1)
            Dim toPage As Integer = If(Integer.TryParse(tbTo.Text.Trim(), Nothing), Convert.ToInt32(tbTo.Text.Trim()), totalPages)

            ' Calculate the total number of pages
            Dim totalPagesToPrint As Integer = (toPage - fromPage + 1) * numCopies

            ' Calculate the cost per page based on paper size
            Dim costPerPage As Integer = If(_isLetterSize, LetterSizeCostPerPage, LegalSizeCostPerPage)

            ' Compute the total payment
            Dim totalPayment As Integer = totalPagesToPrint * costPerPage

            ' Display the total payment in the lblPay label
            lblPay.Text = totalPayment.ToString()

            ' Calculate and display the change
            If coinsAvailable >= totalPayment Then
                lblChange.Text = (coinsAvailable - totalPayment).ToString()
            Else
                lblChange.Text = "0"
            End If

        Catch ex As Exception
            MessageBox.Show("Error calculating payment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Async Function GetPdfPageCountAsync(ByVal filePath As String) As Task(Of Integer)
        Return Await Task.Run(Function()
                                  Dim pageCount As Integer = 0
                                  Try
                                      Using pdfDoc As New PdfDocument(New PdfReader(filePath))
                                          pageCount = pdfDoc.GetNumberOfPages()
                                      End Using
                                  Catch ex As Exception
                                      MessageBox.Show("Error retrieving PDF page count: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                  End Try
                                  Return pageCount
                              End Function)
    End Function
    Private Sub UpdatePreview()
        Try
            Dim fromPage As Integer = If(Integer.TryParse(tbFrom.Text.Trim(), Nothing), Convert.ToInt32(tbFrom.Text.Trim()), 1)
            Dim toPage As Integer = If(Integer.TryParse(tbTo.Text.Trim(), Nothing), Convert.ToInt32(tbTo.Text.Trim()), 1)

            ' Validate and adjust page numbers
            fromPage = Math.Max(fromPage, 1)
            toPage = Math.Min(toPage, totalPages)

            ' Ensure fromPage is less than or equal to toPage
            If fromPage > toPage Then
                MessageBox.Show("From page must be less than or equal to To page.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ' Adjust the values or handle the error condition appropriately
                tbFrom.Text = "1"
                tbTo.Text = totalPages.ToString()
                Return
            End If

        Catch ex As Exception
            MessageBox.Show("Error navigating to specified pages: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ' Call ComputePayment to update the payment amount
        ComputePayment()
        CheckTotalPagesAndTogglePrintButton()


    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        CloseComPort()
        previewForm.OpenComPort()
        previewForm.Show()
        Execute.Credits = Integer.Parse(lblCredits.Text)
        SaveFinalCoinsToDatabase()
        previewForm.lblCredits.Text = Execute.Credits.ToString()
        ResetChangetoZero()
        Me.Close()
    End Sub

    Private Async Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Execute.Credits = Integer.Parse(lblCredits.Text)
        SaveFinalCoinsToDatabase()
        Try
            ' Check if the printer is ready
            Dim printerName As String = If(rbLetter.Checked, "EPSON L120 Series", "EPSON L120 Series (Copy 3)")

            If Not Execute.IsPrinterReady(printerName) Then
                ' Show the Printer modal form if the printer is not ready
                Dim printerForm As New Printer()
                printerForm.ShowDialog()

                Return ' Exit the subroutine if the printer is not ready
            End If
            ' Get the total pages to print and the number of copies
            Dim numCopies As Integer = Integer.Parse(tbCopies.Text.Trim())

            ' Reference to the StartPage form
            Dim startPage As StartPage = CType(Application.OpenForms("StartPage"), StartPage)

            If startPage IsNot Nothing Then
                ' Calculate the number of pages to print
                Dim fromPage As Integer
                Dim toPage As Integer

                If Integer.TryParse(tbFrom.Text.Trim(), fromPage) AndAlso Integer.TryParse(tbTo.Text.Trim(), toPage) Then
                    Dim totalPagesToPrint As Integer = (toPage - fromPage + 1) * numCopies

                    ' Check if there is enough paper based on the size
                    Dim hasEnoughPaper As Boolean = False
                    Dim paperSCount As Integer
                    Dim paperLCount As Integer

                    If _isLetterSize Then
                        Integer.TryParse(startPage.Invoke(Function() startPage.lblPaperS.Text.Trim()), paperSCount)
                        If totalPagesToPrint <= paperSCount Then
                            hasEnoughPaper = True
                        Else
                            ' Show "No Paper" form only if no paper is left
                            If paperSCount = 0 Then
                                ShowNoPaperForm("Letter")
                                Return
                            End If

                            ' Show "Kulang" form if there is some paper left but not enough
                            Dim kulangForm As New Kulang()
                            kulangForm.ShowDialog()
                            Return
                        End If
                    Else
                        Integer.TryParse(startPage.Invoke(Function() startPage.lblPaperL.Text.Trim()), paperLCount)
                        If totalPagesToPrint <= paperLCount Then
                            hasEnoughPaper = True
                        Else
                            ' Show "No Paper" form only if no paper is left
                            If paperLCount = 0 Then
                                ShowNoPaperForm("Legal")
                                Return
                            End If

                            ' Show "Kulang" form if there is some paper left but not enough
                            Dim kulangForm As New Kulang()
                            kulangForm.ShowDialog()
                            Return
                        End If
                    End If

                    ' Proceed only if there is enough paper
                    If hasEnoughPaper Then
                        ' Calculate the total payment based on the paper size and number of pages
                        Dim costPerPage As Integer = If(_isLetterSize, LetterSizeCostPerPage, LegalSizeCostPerPage) ' 5 pesos per Letter page, 7 pesos per Legal page
                        Dim totalPayment As Integer = totalPagesToPrint * costPerPage
                        Dim Funds As Integer
                        Execute.SukliMo = Integer.Parse(lblChange.Text)
                        Integer.TryParse(startPage.Invoke(Function() startPage.lblFunds.Text.Trim()), Funds)
                        ' Check if the coins are greater than or equal to the total payment
                        Dim currentCredits = Integer.Parse(lblCredits.Text)
                        If currentCredits >= totalPayment Then
                            'show no funds if true
                            If Funds < SukliMo Then
                                Dim hopperlow As New noFunds()
                                hopperlow.Label2.Text = Execute.Funds.ToString()
                                hopperlow.Show()
                                'MessageBox.Show($"NOT ENOUGH FUNDS!{Funds}")
                                Return
                            End If
                            ' Proceed to print
                            Dim piniprintForm As New Piniprint()
                            piniprintForm.Show()

                            ' Use Task.Run to perform background operations
                            Await Task.Run(Sub()
                                               Try
                                                   Debug.WriteLine("Starting PDF to image conversion...")
                                                   Dim outputDir As String = "C:/DEFENSA"

                                                   ' Convert PDF to images and print for each copy
                                                   For copyIndex As Integer = 1 To numCopies
                                                       ConvertPdfToImages(pdfFilePath, outputDir, fromPage, toPage)
                                                       For pageIndex As Integer = fromPage To toPage
                                                           Try
                                                               PrintImage(Path.Combine(outputDir, $"page_{pageIndex}.png"), printerName, _isLetterSize)
                                                               processSuccess = True
                                                           Catch ex As Exception

                                                               processSuccess = False
                                                               Return ' Exit immediately
                                                           End Try
                                                       Next
                                                       DeleteImages(outputDir)
                                                   Next
                                                   If processSuccess Then
                                                       HandlePrintCompletion(1, "Success")
                                                       Debug.WriteLine("Papers Deducted")
                                                       Debug.WriteLine("Finished processing.")
                                                       deleteFiles()
                                                       If _isLetterSize Then
                                                           Execute.Letterpaper -= totalPagesToPrint
                                                           DeductPaper(True, totalPagesToPrint)
                                                       Else
                                                           Execute.Legalpaper -= totalPagesToPrint
                                                           DeductPaper(False, totalPagesToPrint)
                                                       End If


                                                   End If
                                               Catch ex As Exception
                                                   MessageBox.Show("Error during processing: " & ex.Message)
                                               End Try
                                           End Sub)

                            Me.Close()
                            piniprintForm.Close()

                            If processSuccess Then
                                Dim thanksForm As New Thanks()
                                thanksForm.Show()
                            Else
                                Dim errorForm As New ErrorPrint()
                                errorForm.Show()
                            End If
                            ' Close the Preview form if it's still running
                            If previewForm IsNot Nothing Then
                                previewForm.Close()
                            End If

                        Else
                            ' Show insufficent form if not enough coins
                            Dim insufficientForm As New Insufficient()
                            insufficientForm.ShowDialog()
                            Return ' Exit to prevent decrementing paper count
                        End If
                    End If
                Else
                    startPage.Invoke(Sub() MessageBox.Show("Error: Invalid page range."))
                End If
            Else
                MessageBox.Show("Error: StartPage form is not accessible.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub deleteFiles()
        Try
            ' If the original file is not a PDF, delete both the original and the converted PDF file
            If Not pdfFileName.ToLower().EndsWith(".pdf") Then
                ' Delete the original file (Word or Excel)
                If System.IO.File.Exists(OriginalPath + "\" + pdfFileName) Then
                    System.IO.File.Delete(OriginalPath + "\" + pdfFileName)
                Else
                    MessageBox.Show($"Error deleting original file does not exist")
                End If

                ' Delete the converted PDF file
                If System.IO.File.Exists(pdfFilePath) Then
                    System.IO.File.Delete(pdfFilePath)
                Else
                    MessageBox.Show($"Error deleting converted file: {pdfFilePath} does not exist")
                End If
            Else
                ' If the original file is already a PDF, just delete the original PDF file                                                     
                If System.IO.File.Exists(OriginalPath) Then
                    System.IO.File.Delete(OriginalPath)
                Else
                    MessageBox.Show($"Error deleting original file,  does not exist")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error deleting file: {ex.Message}")
        End Try
    End Sub

    Private Sub ConvertPdfToImages(pdfPath As String, outputDir As String, fromPage As Integer, toPage As Integer)
        Try
            Using rasterizer As New GhostscriptRasterizer()
                rasterizer.Open(pdfPath)

                For i As Integer = fromPage To toPage
                    If i > rasterizer.PageCount Then Exit For

                    Try
                        Dim img As System.Drawing.Image = rasterizer.GetPage(300, i)
                        Dim bitmap As New Bitmap(img)

                        ' Ensure output directory exists
                        If Not Directory.Exists(outputDir) Then
                            Directory.CreateDirectory(outputDir)
                        End If

                        ' Save the image
                        Dim outputFilePath As String = Path.Combine(outputDir, $"page_{i}.png")
                        bitmap.Save(outputFilePath, ImageFormat.Png)

                        ' Dispose bitmap to free memory
                        bitmap.Dispose()
                    Catch imgEx As Exception
                        MessageBox.Show($"Error processing page {i}: {imgEx.Message}", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error converting PDF to images: {ex.Message}", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub InsertTransaction(kioskID As Integer, fileName As String, pages As Integer, printType As String, payment As Decimal, changeAmount As Decimal, stats As String)
        Dim query As String = "INSERT INTO Transactions (Kiosk_ID, File_Name, Number_Of_Pages, Print_Type, Payment, Change_Amount, Print_Status) VALUES (@KioskID, @FileName, @Pages, @PrintType, @Payment, @ChangeAmount, @Status)"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@KioskID", kioskID)
                cmd.Parameters.AddWithValue("@FileName", fileName)
                cmd.Parameters.AddWithValue("@Pages", pages)
                cmd.Parameters.AddWithValue("@PrintType", printType)
                cmd.Parameters.AddWithValue("@Payment", payment)
                cmd.Parameters.AddWithValue("@ChangeAmount", changeAmount)
                cmd.Parameters.AddWithValue("@Status", stats)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error inserting transaction: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub PrintImage(imagePath As String, printerName As String, isLetterSize As Boolean)
        Dim printDoc As New PrintDocument()
        printDoc.PrinterSettings.PrinterName = printerName

        ' Set paper size based on isLetterSize
        If isLetterSize Then
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("Letter", 850, 1100) ' 8.5 x 11 inches
        Else
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("Legal", 850, 1300) ' 8.5 x 13 inches
        End If
        ' Set page orientation based on the selected radio button
        If rbPortrait.Checked Then
            printDoc.DefaultPageSettings.Landscape = False
        ElseIf rbLandscape.Checked Then
            printDoc.DefaultPageSettings.Landscape = True
        End If


        AddHandler printDoc.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                           If System.IO.File.Exists(imagePath) Then
                                               Using image As System.Drawing.Image = System.Drawing.Image.FromFile(imagePath)
                                                   e.Graphics.DrawImage(image, e.PageBounds)
                                               End Using
                                           Else
                                               MessageBox.Show($"Image file not found: {imagePath}")
                                           End If
                                       End Sub
        ' Set print settings to grayscale
        printDoc.DefaultPageSettings.Color = True
        processSuccess = True

        Try
            ' Step 1: Prepare necessary variables
            Dim sukli As Integer
            sukli = Integer.Parse(lblChange.Text.Trim())
            Dim fromPage As Integer
            Dim toPage As Integer
            Integer.TryParse(tbFrom.Text.Trim(), fromPage)
            Integer.TryParse(tbTo.Text.Trim(), toPage)
            Dim numCopies As Integer = Integer.Parse(tbCopies.Text.Trim())
            Dim totalPagesToPrint As Integer = (toPage - fromPage + 1) * numCopies
            Dim costPerPage As Integer = If(_isLetterSize, LetterSizeCostPerPage, LegalSizeCostPerPage)
            Dim totalPayment As Integer
            totalPayment = totalPagesToPrint * costPerPage

            ' Step 2: Insert transaction with status "Pending"
            InsertTransaction(1, pdfFileName, totalPagesToPrint, "Colored", totalPayment, sukli, "Pending")

            ' Step 3: Print the document
            printDoc.Print()


        Catch ex As Exception
            'MessageBox.Show($"Error while printing: {ex.Message}", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            processSuccess = False
            HandlePrintCompletion(1, "Error")
            Return
        End Try

    End Sub

    Private Sub DeleteImages(imageDir As String)
        Dim files As String() = Directory.GetFiles(imageDir, "*.png")
        For Each file As String In files
            Try
                System.IO.File.Delete(file)
            Catch ex As Exception
                MessageBox.Show($"Error deleting file {file}: {ex.Message}")
            End Try
        Next
    End Sub

    'check if total pages is less than or equal to 60
    Private Sub CheckTotalPagesAndTogglePrintButton()
        Try
            ' Get the fromPage and toPage values from the text boxes
            Dim fromPage As Integer = If(Integer.TryParse(tbFrom.Text.Trim(), Nothing), Convert.ToInt32(tbFrom.Text.Trim()), 1)
            Dim toPage As Integer = If(Integer.TryParse(tbTo.Text.Trim(), Nothing), Convert.ToInt32(tbTo.Text.Trim()), totalPages)
            Dim copies As Integer = If(Integer.TryParse(tbCopies.Text.Trim(), Nothing), Convert.ToInt32(tbCopies.Text.Trim()), 1)

            ' Calculate the total pages to print
            Dim totalPagesToPrint As Integer = toPage - fromPage + 1

            ' Calculate the total pages considering the number of copies
            Dim totalPageCopies As Integer = totalPagesToPrint * copies

            ' Check if the total number of pages is less than or equal to 60
            If totalPageCopies <= 60 Then
                btnPrint.Enabled = True
            Else
                btnPrint.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error calculating total pages: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' Function to show the NoPaper form
    Private Sub ShowNoPaperForm(paperType As String)
        Dim noPaperForm As New noPaper()

        ' Update the text based on the paper type
        Select Case paperType
            Case "Letter"
                noPaperForm.Label1.Text = "No more Letter size paper!"
            Case "Legal"
                noPaperForm.Label1.Text = "No more Legal size paper!"
            Case "Letter and Legal"
                noPaperForm.Label1.Text = "No more Paper!"
        End Select

        ' Show the NoPaper form as a modal dialog
        noPaperForm.ShowDialog()
    End Sub


    Private Sub rbAllPagess_CheckedChanged(sender As Object, e As EventArgs) Handles rbAllPagess.CheckedChanged
        If rbAllPagess.Checked Then
            tbFrom.Enabled = False
            tbTo.Enabled = False
            btnAddFrom.Enabled = False
            btnMinusFrom.Enabled = False
            btnAddTo.Enabled = False
            btnMinusTo.Enabled = False
        Else
            tbFrom.Enabled = True
            tbTo.Enabled = True
            btnAddFrom.Enabled = True
            btnMinusFrom.Enabled = True
            btnAddTo.Enabled = True
            btnMinusTo.Enabled = True
        End If
        tbFrom.Text = "1"
        tbTo.Text = totalPages.ToString()
        ComputePayment()
        CheckTotalPagesAndTogglePrintButton()
    End Sub

    Private Sub btnAddFrom_Click(sender As Object, e As EventArgs) Handles btnAddFrom.Click
        Dim currentPage = Integer.Parse(tbFrom.Text.Trim)

        ' Check if incrementing will exceed totalPages
        If currentPage < totalPages Then
            currentPage += 1
        End If

        ' Update tbFrom text box
        tbFrom.Text = currentPage.ToString

        ' Call UpdatePreview to reflect the change
        UpdatePreview()
    End Sub

    Private Sub btnMinusFrom_Click(sender As Object, e As EventArgs) Handles btnMinusFrom.Click
        Dim currentPage = Integer.Parse(tbFrom.Text.Trim)

        ' Check if decrementing will go below 1
        If currentPage > 1 Then
            currentPage -= 1
        End If

        ' Update tbFrom text box
        tbFrom.Text = currentPage.ToString

        ' Call UpdatePreview to reflect the change
        UpdatePreview()
    End Sub

    Private Sub btnAddTo_Click(sender As Object, e As EventArgs) Handles btnAddTo.Click
        Dim currentPage = Integer.Parse(tbTo.Text.Trim)

        ' Check if incrementing will exceed totalPages
        If currentPage < totalPages Then
            currentPage += 1
        End If

        ' Update tbTo text box
        tbTo.Text = currentPage.ToString

        ' Call UpdatePreview to reflect the change
        UpdatePreview()

    End Sub

    Private Sub btnMinusTo_Click(sender As Object, e As EventArgs) Handles btnMinusTo.Click
        Dim currentPage = Integer.Parse(tbTo.Text.Trim)

        ' Check if decrementing will go below 1
        If currentPage > 1 Then
            currentPage -= 1
        End If

        ' Update tbTo text box
        tbTo.Text = currentPage.ToString

        ' Call UpdatePreview to reflect the change
        UpdatePreview()

    End Sub

    Private Sub btnCopiesAdd_Click(sender As Object, e As EventArgs) Handles btnCopiesAdd.Click
        ' Attempt to parse the text in tbCopies into an integer
        If Integer.TryParse(tbCopies.Text, Copies) Then
            If Copies < 60 Then
                Copies += 1
                tbCopies.Text = Copies.ToString
            End If
        Else
            MessageBox.Show("Copies Cannot Exceed 60!")
        End If
        ComputePayment()
        CheckTotalPagesAndTogglePrintButton()
    End Sub

    Private Sub btnCopiesMinus_Click(sender As Object, e As EventArgs) Handles btnCopiesMinus.Click
        Dim currentValue As Integer

        ' Attempt to parse the text in tbCopies into an integer
        If Integer.TryParse(tbCopies.Text, currentValue) Then
            ' Check if currentValue is greater than 1 before subtracting
            If currentValue > 1 Then
                currentValue -= 1
                tbCopies.Text = currentValue.ToString
            End If
        Else
            MessageBox.Show("Invalid number in the text box.")
        End If
        ComputePayment()
        CheckTotalPagesAndTogglePrintButton()
    End Sub

    Private Sub rbLetter_CheckedChanged(sender As Object, e As EventArgs) Handles rbLetter.CheckedChanged
        If rbLetter.Checked Then
            _isLetterSize = True
        End If
        ComputePayment()
    End Sub

    Private Sub rbLegal_CheckedChanged(sender As Object, e As EventArgs) Handles rbLegal.CheckedChanged
        If rbLegal.Checked Then
            _isLetterSize = False
        End If
        ComputePayment()
    End Sub

    Private Sub Colored_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If SerialPort2.IsOpen Then
            SerialPort2.Close()
        End If
    End Sub
    Dim isCounting As Boolean = False  ' Flag to track counting process
    Private Sub SerialPort2_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            Dim incomingData As String = SerialPort2.ReadLine().Trim()
            Me.Invoke(Sub() lblCredits.Text = incomingData)
            ComputePayment()
            If Not isCounting Then
                isCounting = True ' Set flag to indicate counting is in progress

                ' Disable the button to prevent further clicks during the counting process
                Me.Invoke(Sub()
                              btnPrint.Enabled = False
                          End Sub)

                Task.Run(AddressOf EnablePrintButtonAfterDelay)

            End If
        Catch ex As Exception
            ' Log or handle the exception here
            MessageBox.Show($"Error reading data: {ex.Message}")
        End Try
    End Sub
    Private Async Function EnablePrintButtonAfterDelay() As Task
        ' Wait for 2 seconds (2000 milliseconds)
        Await Task.Delay(2000)

        ' Re-enable the button after the delay
        Me.Invoke(Sub()
                      btnPrint.Enabled = True
                      isCounting = False ' Reset flag
                  End Sub)
    End Function
End Class