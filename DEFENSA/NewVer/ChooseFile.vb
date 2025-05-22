Imports System.IO
Imports Word = Microsoft.Office.Interop.Word
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO.Ports


Public Class ChooseFile
    Private _paperL As Integer
    Private _paperS As Integer
    Private _isLetterSize As Boolean
    Private _fileFilter As String
    Private WithEvents fileSystemWatcher As New FileSystemWatcher()
    Private directoryPath As String = "C:/DEFENSA"
    Private fileTypeToIndex As New Dictionary(Of String, Integer)
    Public selectedFilter As String
    Private Const MaxPaperCapacity As Integer = 60
    Private Credit As Integer
    Private WithEvents SerialPort2 As New SerialPort



    ' Constructor with parameters
    Public Sub New(paperL As Integer, paperS As Integer, fileFilter As String)
        InitializeComponent()
        _paperL = paperL
        _paperS = paperS
        _fileFilter = fileFilter
        '  Credit = credits
    End Sub
    'convert word files to pdf
    Private Sub ConvertWordToPdf(ByVal inputFilePath As String, ByVal outputFilePath As String)
        Try
            ' Create a new instance of the Word application
            Dim wordApp As New Word.Application()

            ' Open the Word document
            Dim doc As Word.Document = wordApp.Documents.Open(inputFilePath)

            ' Save the document as PDF
            doc.SaveAs2(outputFilePath, Word.WdSaveFormat.wdFormatPDF)

            ' Close the document and Word application
            doc.Close()
            wordApp.Quit()

        Catch ex As Exception
            ' Handle any errors that occur during the process
            MessageBox.Show($"An error occurred while processing the Word document: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    'convert excel files to pdf
    Private Sub ConvertExcelToPdf(ByVal inputFilePath As String, ByVal outputFilePath As String)
        Try
            ' Create a new instance of the Excel application
            Dim excelApp As New Excel.Application()

            ' Open the Excel workbook
            Dim workbook As Excel.Workbook = excelApp.Workbooks.Open(inputFilePath)

            ' Check if the workbook has any sheets
            If workbook.Sheets.Count > 0 Then
                ' Get the active sheet
                Dim activeSheet As Excel.Worksheet = workbook.ActiveSheet

                ' Set the page setup options to fit the content to the page
                With activeSheet.PageSetup
                    .Zoom = False ' Disable zoom to use FitToPages options
                    .FitToPagesWide = 1
                    .FitToPagesTall = False ' Fit to one page wide and as many pages tall as needed
                End With

                ' Set the print area to include all used cells
                Dim lastCell As Excel.Range = activeSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell)
                activeSheet.PageSetup.PrintArea = activeSheet.Range("A1", lastCell).Address

                ' Export the active sheet to PDF
                activeSheet.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, outputFilePath)
            Else
                MessageBox.Show("The workbook does not contain any sheets.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' Close the workbook without saving changes
            workbook.Close(SaveChanges:=False)
            excelApp.Quit()

        Catch ex As Exception
            ' Handle any errors that occur during the process
            MessageBox.Show($"An error occurred while processing the Excel document: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        ' Close this form and show the StartPage
        Me.Close()
        StartPage.OpenComPort()
        StartPage.Show()
    End Sub


    Public Sub OpenComPort()
        Try
            If Not SerialPort2.IsOpen Then
                SerialPort2.PortName = "COM4"  ' Adjust to your specific COM port
                SerialPort2.BaudRate = 9600
                '   AddHandler SerialPort2.DataReceived, AddressOf SerialPort2_DataReceived
                SerialPort2.Open()
                Debug.WriteLine("COM port opened successfully.")
            Else
                Debug.WriteLine("port already open")
            End If

        Catch ex As Exception
            MessageBox.Show($"Failed to open COM port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub ChooseFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        ' Initialize FileSystemWatcher
        InitializeFileSystemWatcher()

        ' Configure ImageList
        ConfigureImageList()

        ' Start timer to periodically check for new files
        Timer1.Interval = 3000 ' 3000 milliseconds (3 seconds) interval
        Timer1.Start()
        ' Set filter and populate ListView
        selectedFilter = _fileFilter
        PopulateListView(directoryPath)
    End Sub

    'watch for new files added
    Private Sub InitializeFileSystemWatcher()
        ' Configure FileSystemWatcher
        With fileSystemWatcher
            .Path = directoryPath
            .Filter = "*.*" ' Watch all files
            .EnableRaisingEvents = True
        End With

        ' Add event handler for file system changes
        AddHandler fileSystemWatcher.Created, AddressOf FileSystemWatcher_Created
    End Sub

    'populate list view with files
    Private Sub PopulateListView(ByVal directoryPath As String)
        ' Clear existing items
        ListView1.Items.Clear()

        ' Check if directory exists
        If Directory.Exists(directoryPath) Then
            ' Define the search patterns based on the selected filter
            Dim searchPatterns As List(Of String) = New List(Of String)()
            If selectedFilter = "PDF" Or selectedFilter = "All Files" Then searchPatterns.Add("*.pdf")
            If selectedFilter = "Excel" Or selectedFilter = "All Files" Then searchPatterns.Add("*.xlsx")
            If selectedFilter = "Word" Or selectedFilter = "All Files" Then
                searchPatterns.Add("*.docx")
                searchPatterns.Add("*.doc")
            End If

            ' Get the files based on the search patterns
            Dim files As List(Of String) = New List(Of String)()
            For Each pattern As String In searchPatterns
                files.AddRange(Directory.GetFiles(directoryPath, pattern))
            Next

            ' Add filenames with icons to ListView
            For Each file As String In files
                Dim fileType As String = GetFileType(file)
                If Not String.IsNullOrEmpty(fileType) Then
                    AddFileToListView(file, fileType)
                End If
            Next
        Else
            ' Directory does not exist or is empty
            ' Handle this scenario if needed, or do nothing to suppress message
            ' MessageBox.Show($"Directory '{directoryPath}' does not exist or does not contain any supported files.")
        End If
    End Sub

    Private Sub AddFileToListView(ByVal filePath As String, ByVal fileType As String)
        ' Get file name
        Dim fileName As String = Path.GetFileName(filePath)

        ' Create ListViewItem with icon based on fileType
        Dim item As New ListViewItem(fileName)

        ' Assigns icon based on ImageList index
        If fileTypeToIndex.ContainsKey(fileType) Then
            item.ImageIndex = fileTypeToIndex(fileType)
        End If

        ' Add item to ListView
        ListView1.Items.Add(item)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        ' Check for new files periodically
        PopulateListView(directoryPath)
    End Sub

    Private Sub FileSystemWatcher_Created(ByVal sender As Object, ByVal e As FileSystemEventArgs)
        ' Handle newly created files detected by FileSystemWatcher
        If Me.InvokeRequired Then
            Me.Invoke(Sub() PopulateListView(directoryPath))
        Else
            PopulateListView(directoryPath)
        End If
    End Sub
    'function when clicking files in list view
    Private  Sub ListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedFile As String = Path.Combine(directoryPath, ListView1.SelectedItems(0).Text)
            Dim fileName As String = ListView1.SelectedItems(0).Text ' Get the file name
            Dim pdfFilePath As String = Path.ChangeExtension(selectedFile, ".pdf")

            ' Default value for isLetterSize
            Dim isLetterSize As Boolean = True ' Assuming Letter size as default

            Select Case Path.GetExtension(selectedFile).ToLower()
                Case ".pdf"
                    ' PDF file selected: Open Preview form and pass original file's directory
                    Dim previewForm As New Preview(selectedFile, fileName, _paperL, _paperS, isLetterSize, _fileFilter, selectedFile)
                    Me.Hide()
                    previewForm.Show() ' Show the Preview form
                Case ".xlsx"
                    'show preview form first before converting to avoid delay
                    Dim previewFormExcel As New Preview(pdfFilePath, fileName, _paperL, _paperS, isLetterSize, _fileFilter, directoryPath)
                    Me.Hide()
                    previewFormExcel.Show() ' Show the Preview form
                    ConvertExcelToPdf(selectedFile, pdfFilePath)
                Case ".docx"
                    'show preview form first before converting to avoid delay
                    Dim previewFormWord As New Preview(pdfFilePath, fileName, _paperL, _paperS, isLetterSize, _fileFilter, directoryPath)
                    Me.Hide()
                    previewFormWord.Show()
                    ConvertWordToPdf(selectedFile, pdfFilePath)
                Case ".doc"
                    'show preview form first before converting to avoid delay
                    Dim previewFormWord As New Preview(pdfFilePath, fileName, _paperL, _paperS, isLetterSize, _fileFilter, directoryPath)
                    Me.Hide()
                    previewFormWord.Show()
                    ConvertWordToPdf(selectedFile, pdfFilePath)
                Case Else
                    ' Unsupported file type selected: Show error message
                    MessageBox.Show("Unsupported file format.")
            End Select
        End If
    End Sub





    ' Ensure the ImageList is correctly configured
    Private Sub ConfigureImageList()
        ' Clear any existing images
        ImageListIcons.Images.Clear()
        ' Add images to the ImageList with keys and specify larger size (e.g., 64x64)
        ImageListIcons.ImageSize = New Size(64, 64) ' Set the size as needed

        ' Add images to the ImageList with keys
        ImageListIcons.Images.Add("PDF", ResizeImage(My.Resources.PDF, ImageListIcons.ImageSize)) ' Index 0
        ImageListIcons.Images.Add("EXCEL", ResizeImage(My.Resources.EXCEL, ImageListIcons.ImageSize)) ' Index 1
        ImageListIcons.Images.Add("WORD", ResizeImage(My.Resources.WORD, ImageListIcons.ImageSize)) ' Index 2

        ' Map file types to ImageList indices
        fileTypeToIndex.Add("PDF", 0)
        fileTypeToIndex.Add("EXCEL", 1)
        fileTypeToIndex.Add("WORD", 2)

        ' Assign ImageList to ListView
        ListView1.LargeImageList = ImageListIcons
        ' Set ListView view mode to LargeIcon
        ListView1.View = View.LargeIcon
    End Sub

    Private Function ResizeImage(ByVal originalImage As Image, ByVal newSize As Size) As Image
        ' Resize the original image to the specified newSize
        Dim resizedImage As New Bitmap(newSize.Width, newSize.Height)
        Using g As Graphics = Graphics.FromImage(resizedImage)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(originalImage, New Rectangle(Point.Empty, newSize))
        End Using
        Return resizedImage
    End Function


    Private Function GetFileType(ByVal filePath As String) As String
        Dim extension As String = Path.GetExtension(filePath).ToLower()
        Select Case extension
            Case ".pdf"
                Return "PDF"
            Case ".xlsx"
                Return "EXCEL"
            Case ".docx"
                Return "WORD"
            Case Else
                Return Nothing
        End Select
    End Function




End Class
