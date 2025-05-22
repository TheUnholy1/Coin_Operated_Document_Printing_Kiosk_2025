Imports iText.Kernel.Pdf
Imports Microsoft.Web.WebView2
Imports Microsoft.Web.WebView2.Core
Imports System.IO.Ports



Public Class Preview

    Private pdfFilePath As String
    Private pdfFileName As String
    Private totalPages As Integer = 0
    Private _paperL As Integer
    Private _paperS As Integer
    Private _isLetterSize As Boolean
    Private _fileFilter As String
    Private zoomLevel As Double = 0.5
    Private rotationState As Integer = 0
    Private OriginalPath As String
    Private WithEvents SerialPort2 As New SerialPort
    Private creds As Integer = 0
    ' Private Coins As Integer


    ' Constructor with parameters
    Public Sub New(ByVal filePath As String, ByVal fileName As String, ByVal paperL As Integer, ByVal paperS As Integer, ByVal isLetterSize As Boolean, ByVal fileFilter As String, ByVal originalFilePath As String)
        InitializeComponent()
        pdfFilePath = filePath
        pdfFileName = fileName
        _paperL = paperL
        _paperS = paperS
        _isLetterSize = isLetterSize
        _fileFilter = fileFilter
        OriginalPath = originalFilePath
        ' Coins = Credit
    End Sub



    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As Core.CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted

        If e.IsSuccess Then

            ' if the component initializes okay, set it up to hide the toolbar
            WebView21.CoreWebView2.Settings.HiddenPdfToolbarItems =
            CoreWebView2PdfToolbarItems.Bookmarks Or
            CoreWebView2PdfToolbarItems.FitPage Or
            CoreWebView2PdfToolbarItems.PageLayout Or
            CoreWebView2PdfToolbarItems.PageSelector Or
            CoreWebView2PdfToolbarItems.Print Or
            CoreWebView2PdfToolbarItems.Rotate Or
            CoreWebView2PdfToolbarItems.Save Or
            CoreWebView2PdfToolbarItems.SaveAs Or
            CoreWebView2PdfToolbarItems.Search Or
            CoreWebView2PdfToolbarItems.ZoomIn Or
            CoreWebView2PdfToolbarItems.ZoomOut

            WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
            WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False

            btnGray.Enabled = True
            btnColor.Enabled = True


        End If

    End Sub

    Private Sub btnZoomIn_Click(sender As Object, e As EventArgs) Handles btnZoomIn.Click
        If zoomLevel < 2.0 Then ' Maximum zoom level
            zoomLevel += 0.05 ' Increase zoom level by 5%
            SetZoom(zoomLevel)
        End If
    End Sub

    Private Sub btnZoomOut_Click(sender As Object, e As EventArgs) Handles btnZoomOut.Click
        If zoomLevel > 0.35 Then ' Minimum zoom level
            zoomLevel -= 0.05 ' Decrease zoom level by 5%
            SetZoom(zoomLevel)
        End If
    End Sub

    Private Sub SetZoom(zoom As Double)
        If WebView21 IsNot Nothing AndAlso WebView21.CoreWebView2 IsNot Nothing Then
            WebView21.ZoomFactor = zoom
        End If
    End Sub





    Private Async Sub Preview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            OpenComPort()

            lblFileName.AutoSize = False
            lblFileName.Width = 400
            lblFileName.Height = 100

            btnGray.Enabled = False
            btnColor.Enabled = False

            If Not String.IsNullOrEmpty(pdfFilePath) Then
                ' Show a preview in WebView2
                WebView21.Source = New Uri(pdfFilePath)
                ' Display the file name in lblFileName
                lblFileName.Text = pdfFileName
                ' Add a delay before attempting to get the PDF page count
                Await Task.Delay(10) ' Delay, adjust as needed (1000 is one second)
                ' Get the total number of pages asynchronously
                totalPages = Await GetPdfPageCountAsync(pdfFilePath)
                lblPages.Text = totalPages.ToString()

                ' Load credits from the database
                LoadCreditsFromDatabase()
                lblCredits.Text = Execute.Credits.ToString()

                ' Maximize the form
                Me.WindowState = FormWindowState.Maximized
            End If

        Catch ex As Exception
            ' Handle any exceptions that occur during the load process
            MessageBox.Show($"An error occurred during the preview load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Dim isCounting As Boolean = False  ' Flag to track counting process
    'function for serial port when data is recieved to update lblCredits
    Private Sub SerialPort2_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            Dim incomingData As String = SerialPort2.ReadLine().Trim()
            Me.Invoke(Sub() lblCredits.Text = incomingData)
            If Not isCounting Then
                isCounting = True ' Set flag to indicate counting is in progress

                ' Disable the button to prevent further clicks during the counting process
                Me.Invoke(Sub()
                              btnGray.Enabled = False
                              btnColor.Enabled = False
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
                      btnGray.Enabled = True
                      btnColor.Enabled = True
                      isCounting = False ' Reset flag
                  End Sub)
    End Function
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



    Private Sub Preview_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'close serial port when form is closed
        Try
            If SerialPort2.IsOpen Then
                RemoveHandler SerialPort2.DataReceived, AddressOf SerialPort2_DataReceived
                SerialPort2.Close()
            End If
        Catch ex As Exception
            MessageBox.Show($"Error closing serial port: {ex.Message}")
        End Try
        'Dispose Webview
        WebView21.Dispose()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        'close serial port
        Try
            If SerialPort2.IsOpen Then
                CloseComPort()
                StartPage.OpenComPort()
                StartPage.lblCredits.Text = Me.lblCredits.Text
            End If
            'dispose webview
            WebView21.Dispose()
            'Delete converted word and excel files
            If Not pdfFileName.ToLower().EndsWith(".pdf") AndAlso System.IO.File.Exists(pdfFilePath) Then
                System.IO.File.Delete(pdfFilePath)
            End If
            Execute.Credits = Integer.Parse(lblCredits.Text)
            SaveFinalCoinsToDatabase()
            Me.Close()
            StartPage.lblCredits.Text = Execute.Credits.ToString()
            StartPage.Show()
        Catch ex As Exception
            MessageBox.Show($"Error during back navigation: {ex.Message}")
        End Try

    End Sub




    Private Sub btnGray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGray.Click

        'declare pdf file path and credits to transfer values to grayscale form
        Dim pdfFilePath As String = Me.pdfFilePath
        ' Dim credits As Integer = Integer.Parse(lblCredits.Text)
        Execute.Credits = Integer.Parse(lblCredits.Text)

        If Credits >= Execute.LetterPriceG Then
            Try
                CloseComPort()
            Catch ex As Exception
                MessageBox.Show($"Error during grayscale navigation: {ex.Message}")
            End Try
            Me.Hide()
            Dim grayscaleForm As New Grayscale(pdfFilePath, pdfFileName, _paperL, _paperS, _fileFilter, Me, OriginalPath)
            grayscaleForm.ComputePayment()
            grayscaleForm.Show()
        Else
            Dim insertcoinsForm As New InserCoin()
            insertcoinsForm.ShowDialog()
        End If
        SaveFinalCoinsToDatabase()
    End Sub

    Private Sub btnRotate_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ' Reset the zoom level to the default value
        zoomLevel = 0.5
        SetZoom(zoomLevel)
        ' Reload the PDF to ensure the reset takes effect
        WebView21.Reload()
    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        ' Use the pdfFilePath from the Preview form
        Dim pdfFilePath As String = Me.pdfFilePath
        ' Dim credits As Integer = Integer.Parse(lblCredits.Text)
        Execute.Credits = Integer.Parse(lblCredits.Text)
        If Credits >= Execute.LetterPriceC Then
            Try
                CloseComPort()
            Catch ex As Exception
                MessageBox.Show($"Error during colored navigation: {ex.Message}")
            End Try
            Dim coloredForm As New Colored(pdfFilePath, pdfFileName, _paperL, _paperS, _fileFilter, Me, OriginalPath)
            Execute.Credits = Integer.Parse(lblCredits.Text)
            coloredForm.Show()
        Else
            Dim insertcoinsForm As New InserCoin()
            insertcoinsForm.ShowDialog()
        End If

        SaveFinalCoinsToDatabase()

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '   creds += 1
    '    lblCredits.Text = creds
    ' End Sub
End Class
