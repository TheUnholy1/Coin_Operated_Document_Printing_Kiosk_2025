Public Class Settings
    ' Define class-level variables to hold references to the current panel
    Private currentPagePanel As Form
    Private currentFundsPanel As Form
    Private currentPricePanel As Form
    Private startPage As StartPage ' Reference to StartPage


    ' Constructor to accept a reference to StartPage
    Public Sub New(startPageRef As StartPage)
        InitializeComponent()
        startPage = startPageRef

    End Sub

    Sub ShowPagePanel()
        ' Clear existing controls in Panel1
        Panel1.Controls.Clear()

        ' Create new instance of Page panel, passing the reference of StartPage
        Dim pagePanel As New Page(startPage)
        pagePanel.TopLevel = False
        pagePanel.Dock = DockStyle.Fill

        ' Store reference to current page panel
        currentPagePanel = pagePanel

        ' Add panel to Panel1 and show it
        Panel1.Controls.Add(pagePanel)
        pagePanel.Show()
    End Sub

    Sub ShowFundsPanel()
        ' Clear existing controls in Panel1
        Panel1.Controls.Clear()

        ' Create new instance of Funds panel
        Dim fundsPanel As New Funds(startPage)
        fundsPanel.TopLevel = False
        fundsPanel.Dock = DockStyle.Fill

        ' Store reference to current funds panel
        currentFundsPanel = fundsPanel

        ' Add panel to Panel1 and show it
        Panel1.Controls.Add(fundsPanel)
        fundsPanel.Show()
    End Sub
    Sub ShowPricePanel(startPage)
        ' Clear existing controls in Panel1
        Panel1.Controls.Clear()

        ' Create new instance of Funds panel
        Dim pricePanel As New Price(startPage)
        pricePanel.TopLevel = False
        pricePanel.Dock = DockStyle.Fill

        ' Store reference to current funds panel
        currentPricePanel = pricePanel

        ' Add panel to Panel1 and show it
        Panel1.Controls.Add(pricePanel)
        pricePanel.Show()
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        ' Show the Page panel
        ShowPagePanel()
    End Sub

    Private Sub btnFunds_Click(sender As Object, e As EventArgs) Handles btnFunds.Click
        ' Show the Funds panel
        ShowFundsPanel()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        ' Close the Settings form
        Me.Close()
        startPage.CheckSystemStatus()
        Execute.LoadPrices()
        ' Ensure the form is fully closed before proceeding



        If Not startPage.Visible Then
            startPage.Show()
            startPage.InitializeComponents()
        End If

    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '       startPage.Close()
        '       Me.Close()
        Dim reportsForm As New Reports()
        reportsForm.Show()
    End Sub

    Private Sub btnPrice_Click(sender As Object, e As EventArgs) Handles btnPrice.Click
        ShowPricePanel(startPage)
    End Sub
End Class
