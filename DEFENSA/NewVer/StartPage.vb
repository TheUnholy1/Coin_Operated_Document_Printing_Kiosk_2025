Imports System.IO
Imports QRCoder
Imports System.IO.Ports
Imports MySql.Data.MySqlClient


Public Class StartPage
    Private pythonProcess As Process
    Private Const MaxPaperCapacity As Integer = 60
    Private serverIpAddressFile As String = "C:/DEFENSA/ip_address.txt"
    Private serverIpAddress As String
    Private watcher As FileSystemWatcher
    Private WithEvents SerialPort2 As New SerialPort
    Private connectionString As String = "server=127.0.0.1;User Id=root;port=3306;database=codpkv2"
    ' Private batchFilePath As String = "C:\Users\Nazian Payad\OneDrive\Desktop\Server.bat"


    ' Properties to expose lblPaperL and lblPaperS values
    Public ReadOnly Property PaperLValue As Integer
        Get
            Return Integer.Parse(lblPaperL.Text)
        End Get
    End Property

    Public ReadOnly Property PaperSValue As Integer
        Get
            Return Integer.Parse(lblPaperS.Text)
        End Get
    End Property



    Private Sub StartPage_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        StopFileSystemWatcher()
        CloseComPort()
    End Sub


    Private Sub StartPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' CheckSystemStatus()
        ' Stop any running Python server to prevent duplicates
        '   StopPythonServer()
        ' Run Python script to start the server
        CloseComPort()
        RunPythonScript()
        'show date and time
        UpdateDateTime()
        Timer1.Start()
        StartFileSystemWatcher()
        OpenComPort()
        LoadCreditsFromDatabase()
        'LoadPaperFromDatabase()
        LoadAvailablePapers()
        GetAvailableFunds()
        lblPaperL.Text = Execute.Legalpaper.ToString()
        lblPaperS.Text = Execute.Letterpaper.ToString()
        lblCredits.Text = Execute.Credits.ToString()
        lblFunds.Text = Execute.Funds.ToString()
        LoadPrices()
        LoadLastTotalPrinted()

        'full screen
        ' Me.WindowState = FormWindowState.Maximized

    End Sub
    Private Sub StartPage_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ' StopPythonServer()
        RunPythonScript()
        lblPaperL.Text = Execute.Legalpaper.ToString()
        lblPaperS.Text = Execute.Letterpaper.ToString()
        CheckSystemStatus()
        ' OpenComPort()
        lblCredits.Text = Execute.Credits.ToString()
        lblFunds.Text = Execute.Funds.ToString()
    End Sub
    Public Sub InitializeComponents()
        ' Perform other reinitialization tasks, if needed
        '   StopPythonServer()
        ' RunPythonScript()
        CloseComPort()
        GetAvailableFunds()
        LoadCreditsFromDatabase()
        LoadAvailablePapers()
        lblPaperS.Text = Execute.Letterpaper.ToString()
        lblPaperL.Text = Execute.Legalpaper.ToString()
        lblCredits.Text = Execute.Credits.ToString()
        lblFunds.Text = Execute.Funds.ToString()
        CheckSystemStatus()
        UpdateDateTime()
        OpenComPort()
        LoadLastTotalPrinted()
    End Sub


    Dim isCounting As Boolean = False  ' Flag to track counting process
    'function for serial port when data is recieved to update lblCredits
    Public Sub SerialPort2_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            Dim incomingData As String = SerialPort2.ReadLine().Trim()
            Me.Invoke(Sub() lblCredits.Text = incomingData)
            If Not isCounting Then
                isCounting = True ' Set flag to indicate counting is in progress

                ' Disable the button to prevent further clicks during the counting process
                Me.Invoke(Sub()
                              btnPDF.Enabled = False
                              btnWord.Enabled = False
                              btnExcel.Enabled = False
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
                      btnPDF.Enabled = True
                      btnWord.Enabled = True
                      btnExcel.Enabled = True
                      isCounting = False ' Reset flag
                  End Sub)
    End Function

    'check for new file added
    Private Sub StartFileSystemWatcher()
        If watcher Is Nothing Then
            watcher = New FileSystemWatcher()
            watcher.Path = "C:/DEFENSA" ' C:/Users/gwapo/OneDrive/Desktop/TESTING
            watcher.Filter = "*.*"
            AddHandler watcher.Created, AddressOf OnChanged
            watcher.EnableRaisingEvents = True
        Else
            watcher.EnableRaisingEvents = True
        End If
    End Sub

    Private Sub StopFileSystemWatcher()
        If watcher IsNot Nothing Then
            watcher.EnableRaisingEvents = False
        End If
    End Sub

    Private Sub OnChanged(sender As Object, e As FileSystemEventArgs)
        ' Ensure this runs on the UI thread
        If Me.InvokeRequired Then
            ' Invoke on the UI thread
            Me.Invoke(New MethodInvoker(Sub() ShowUploadForm()))
        Else
            ' Already on the UI thread
            ShowUploadForm()
        End If
    End Sub

    Private Sub ShowUploadForm()
        ' Show the modal form when a new file is added
        If Me.Visible Then
            Using uploadedForm As New Upload_File()
                uploadedForm.ShowDialog(Me)
            End Using
        End If
    End Sub

    'run python
    Private Sub RunPythonScript()
        Try
            ' Read the server IP address from the file
            If File.Exists(serverIpAddressFile) Then
                serverIpAddress = File.ReadAllText(serverIpAddressFile).Trim()
            Else
                MessageBox.Show("IP address file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Display server IP address
            Label4.Text = String.Format("{0}", serverIpAddress)

            ' Generate QR code
            Dim qrGenerator As New QRCodeGenerator()
            Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(serverIpAddress, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode As New QRCode(qrCodeData)
            Dim qrCodeImage As Bitmap = qrCode.GetGraphic(20) ' Adjust the size as needed

            ' Display the QR code image in PictureBox
            pb_QR.Image = qrCodeImage

        Catch ex As Exception
            ' Handle any exceptions that occur during the process
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine("Error: " & ex.Message)
        End Try





    End Sub


    'check if python is running
    Private Function IsPythonServerRunning() As Boolean
        ' Check if the Python server process is already running
        Dim pythonProcesses() As Process = Process.GetProcessesByName("python")
        Return pythonProcesses.Length > 0
    End Function
    'stop python
    Private Sub StopPythonServer()
        If pythonProcess IsNot Nothing AndAlso Not pythonProcess.HasExited Then
            pythonProcess.Kill()
            pythonProcess.WaitForExit()
            Debug.WriteLine("server stopped")
        End If
    End Sub





    '  Private Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
    ' Show Login form as modal
    '  Dim loginForm As New Login
    '   loginForm.ShowDialog()

    ' After login form is closed, check if user has logged in successfully
    '   If Login.HasLoggedIn Then
    ' Stop the Python server before exiting
    '   StopPythonServer()
    '   Close()
    '   End If
    '  End Sub


    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ' Show Login form as modal
        Dim loginForm1 As New Login()
        loginForm1.ShowDialog()

        ' After login form is closed, check if user has logged in successfully
        '    If Login.HasLoggedIn Then
        ' Open Settings form, passing the reference to StartPage
        '      Dim settingsForm As New Settings(Me)
        '    settingsForm.ShowDialog()
        '    End If
    End Sub


    'set timer to update date every second
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' Update date and time every second
        UpdateDateTime()
    End Sub
    Public Sub UpdatePaper()
        ' LoadPaperFromDatabase()
        ' Update the labels in StartPage
        lblPaperS.Text = Letterpaper.ToString()
        lblPaperL.Text = Legalpaper.ToString()
    End Sub
    Public Sub UpdateHopper()
        GetAvailableFunds()
        lblFunds.Text = Execute.Funds.ToString()
    End Sub


    'check for paper count and coins
    Public Sub CheckSystemStatus()

        ' Parse the values of lblPaperS, lblPaperL, and lblFunds as integers
        Dim paperSCount As Integer
        Dim paperLCount As Integer
        Dim funds As Integer

        Dim isPaperParsed As Boolean = Integer.TryParse(lblPaperS.Text.Trim(), paperSCount) AndAlso Integer.TryParse(lblPaperL.Text.Trim(), paperLCount)
        Dim isFundsParsed As Boolean = Integer.TryParse(lblFunds.Text.Trim(), funds)

        If isPaperParsed Then
            ' Check if both Letter and Legal paper counts are 0
            If paperSCount = 0 AndAlso paperLCount = 0 Then
                ShowNoPaperForm("Letter and Legal")
                Return
            End If

            ' Check if either Letter or Legal paper count is 0
            If paperSCount = 0 Then
                ShowNoPaperForm("Letter")
                Return
            End If

            If paperLCount = 0 Then
                ShowNoPaperForm("Legal")
                Return
            End If

            ' Check if either Letter or Legal paper count is between 1 and 10
            If (paperSCount <= 10 AndAlso paperSCount > 0) OrElse (paperLCount <= 10 AndAlso paperLCount > 0) Then
                Dim lowPaperMessage As String = String.Empty

                ' Build the message for low paper
                If paperSCount <= 10 AndAlso paperSCount > 0 Then
                    lowPaperMessage = $"Letter paper remaining: {paperSCount}"
                End If

                If paperLCount <= 10 AndAlso paperLCount > 0 Then
                    If Not String.IsNullOrEmpty(lowPaperMessage) Then
                        lowPaperMessage &= vbCrLf ' Add a new line if both are low
                    End If
                    lowPaperMessage &= $"Legal paper remaining: {paperLCount}"
                End If

                ' Show the LowPaper form with the constructed message
                Dim lowPaperForm As New LowPaper(paperSCount, paperLCount)
                lowPaperForm.lbl1.Text = lowPaperMessage
                lowPaperForm.ShowDialog()
            End If
        Else
            MessageBox.Show("Error parsing the paper count for Letter and Legal size paper.")
        End If

        ' Check hopper funds only if parsing was successful
        If isFundsParsed Then
            If funds = 0 Then
                Dim hopperForm As New Hopper()
                hopperForm.Show()
                Return
            End If
            If funds <= 50 Then
                Dim hopperlow As New noFunds()
                hopperlow.Label2.Text = Execute.Funds.ToString()
                hopperlow.Show()
            End If
        Else
            MessageBox.Show("Error parsing the hopper funds.")
        End If
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
                noPaperForm.Label1.Text = "Out of Papers!"
        End Select
        noPaperForm.TopMost = True
        noPaperForm.Show()

    End Sub

    ' Set filters for buttons
    Private Sub btnWord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnWord.Click
        ' Stop the Python server
        ' StopPythonServer()
        ' Launch the ChooseFile form, filtering to show only Word files
        CloseComPort()
        ' Dim credits As Integer = Integer.Parse(lblCredits.Text)
        Dim chooseFileForm As New ChooseFile(PaperLValue, PaperSValue, "Word")
        chooseFileForm.selectedFilter = "Word"
        chooseFileForm.Show()
        Execute.Credits = Integer.Parse(lblCredits.Text)
        SaveFinalCoinsToDatabase()
        Me.Hide()
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        ' Stop the Python server
        'StopPythonServer()
        ' Launch the ChooseFile form, filtering to show only Word files
        CloseComPort()
        ' Dim credits As Integer = Integer.Parse(lblCredits.Text)
        Dim chooseFileForm As New ChooseFile(PaperLValue, PaperSValue, "PDF")
        chooseFileForm.selectedFilter = "PDF"
        chooseFileForm.Show()
        Execute.Credits = Integer.Parse(lblCredits.Text)
        SaveFinalCoinsToDatabase()
        Me.Hide()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ' Stop the Python server
        ' StopPythonServer()
        ' Launch the ChooseFile form, filtering to show only Word files
        CloseComPort()
        ' Dim credits As Integer = Integer.Parse(lblCredits.Text)
        Dim chooseFileForm As New ChooseFile(PaperLValue, PaperSValue, "Excel")
        chooseFileForm.selectedFilter = "Excel"
        chooseFileForm.Show()
        Execute.Credits = Integer.Parse(lblCredits.Text)
        SaveFinalCoinsToDatabase()
        Me.Hide()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        Me.Hide()
        aboutUs.Show()
    End Sub

End Class
