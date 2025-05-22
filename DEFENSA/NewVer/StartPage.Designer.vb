<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StartPage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartPage))
        PictureBox1 = New PictureBox()
        lblPaperS = New Label()
        btnSettings = New Button()
        lblPaperL = New Label()
        lblFunds = New Label()
        btnWord = New Button()
        btnPDF = New Button()
        btnExcel = New Button()
        Label4 = New Label()
        pb_QR = New PictureBox()
        lblDate = New Label()
        Timer1 = New Timer(components)
        Timer2 = New Timer(components)
        lblCredits = New Label()
        btnAbout = New Button()
        Label1 = New Label()
        Label2 = New Label()
        lblKiosk = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(pb_QR, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(465, 225)
        PictureBox1.Margin = New Padding(3, 2, 3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(293, 251)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' lblPaperS
        ' 
        lblPaperS.AutoSize = True
        lblPaperS.BackColor = Color.Transparent
        lblPaperS.Font = New Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPaperS.ForeColor = Color.White
        lblPaperS.Location = New Point(1068, 210)
        lblPaperS.Name = "lblPaperS"
        lblPaperS.Size = New Size(70, 81)
        lblPaperS.TabIndex = 5
        lblPaperS.Text = "0"
        ' 
        ' btnSettings
        ' 
        btnSettings.BackColor = Color.Transparent
        btnSettings.FlatAppearance.BorderSize = 0
        btnSettings.FlatStyle = FlatStyle.Flat
        btnSettings.ForeColor = Color.Transparent
        btnSettings.Image = CType(resources.GetObject("btnSettings.Image"), Image)
        btnSettings.Location = New Point(1149, 26)
        btnSettings.Margin = New Padding(3, 2, 3, 2)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(52, 45)
        btnSettings.TabIndex = 7
        btnSettings.UseVisualStyleBackColor = False
        ' 
        ' lblPaperL
        ' 
        lblPaperL.AutoSize = True
        lblPaperL.BackColor = Color.Transparent
        lblPaperL.Font = New Font("Segoe UI", 45F, FontStyle.Bold)
        lblPaperL.ForeColor = Color.White
        lblPaperL.Location = New Point(1068, 339)
        lblPaperL.Name = "lblPaperL"
        lblPaperL.Size = New Size(70, 81)
        lblPaperL.TabIndex = 10
        lblPaperL.Text = "0"
        ' 
        ' lblFunds
        ' 
        lblFunds.AutoSize = True
        lblFunds.Font = New Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblFunds.ForeColor = Color.IndianRed
        lblFunds.Location = New Point(1114, 585)
        lblFunds.Name = "lblFunds"
        lblFunds.Size = New Size(42, 51)
        lblFunds.TabIndex = 6
        lblFunds.Text = "0"
        lblFunds.Visible = False
        ' 
        ' btnWord
        ' 
        btnWord.BackColor = Color.Transparent
        btnWord.Cursor = Cursors.Hand
        btnWord.FlatAppearance.BorderSize = 0
        btnWord.FlatStyle = FlatStyle.Flat
        btnWord.Font = New Font("Segoe UI", 18F)
        btnWord.ForeColor = Color.Transparent
        btnWord.Image = CType(resources.GetObject("btnWord.Image"), Image)
        btnWord.Location = New Point(375, 654)
        btnWord.Margin = New Padding(3, 2, 3, 2)
        btnWord.Name = "btnWord"
        btnWord.Size = New Size(83, 70)
        btnWord.TabIndex = 11
        btnWord.UseVisualStyleBackColor = False
        ' 
        ' btnPDF
        ' 
        btnPDF.BackColor = Color.Transparent
        btnPDF.Cursor = Cursors.Hand
        btnPDF.FlatAppearance.BorderSize = 0
        btnPDF.FlatAppearance.MouseDownBackColor = Color.LightGreen
        btnPDF.FlatStyle = FlatStyle.Flat
        btnPDF.Font = New Font("Segoe UI", 18F)
        btnPDF.ForeColor = Color.Transparent
        btnPDF.Image = CType(resources.GetObject("btnPDF.Image"), Image)
        btnPDF.Location = New Point(120, 654)
        btnPDF.Margin = New Padding(3, 2, 3, 2)
        btnPDF.Name = "btnPDF"
        btnPDF.Size = New Size(83, 70)
        btnPDF.TabIndex = 12
        btnPDF.UseVisualStyleBackColor = False
        ' 
        ' btnExcel
        ' 
        btnExcel.BackColor = Color.Transparent
        btnExcel.Cursor = Cursors.Hand
        btnExcel.FlatAppearance.BorderSize = 0
        btnExcel.FlatStyle = FlatStyle.Flat
        btnExcel.Font = New Font("Segoe UI", 18F)
        btnExcel.ForeColor = Color.Transparent
        btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), Image)
        btnExcel.Location = New Point(622, 654)
        btnExcel.Margin = New Padding(3, 2, 3, 2)
        btnExcel.Name = "btnExcel"
        btnExcel.Size = New Size(83, 70)
        btnExcel.TabIndex = 13
        btnExcel.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(156, 537)
        Label4.Name = "Label4"
        Label4.Size = New Size(140, 21)
        Label4.TabIndex = 15
        Label4.Text = "label ng ip address"
        ' 
        ' pb_QR
        ' 
        pb_QR.Location = New Point(75, 225)
        pb_QR.Margin = New Padding(3, 2, 3, 2)
        pb_QR.Name = "pb_QR"
        pb_QR.Size = New Size(293, 251)
        pb_QR.SizeMode = PictureBoxSizeMode.StretchImage
        pb_QR.TabIndex = 14
        pb_QR.TabStop = False
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.BackColor = Color.Transparent
        lblDate.Font = New Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDate.ForeColor = Color.White
        lblDate.Location = New Point(590, 775)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(180, 25)
        lblDate.TabIndex = 18
        lblDate.Text = "Monday, Aug 8 2024"
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 1000
        ' 
        ' lblCredits
        ' 
        lblCredits.AutoSize = True
        lblCredits.BackColor = Color.Transparent
        lblCredits.Font = New Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCredits.ForeColor = Color.DarkGreen
        lblCredits.Location = New Point(1012, 605)
        lblCredits.Name = "lblCredits"
        lblCredits.Size = New Size(70, 81)
        lblCredits.TabIndex = 20
        lblCredits.Text = "0"
        ' 
        ' btnAbout
        ' 
        btnAbout.BackColor = Color.Transparent
        btnAbout.BackgroundImageLayout = ImageLayout.Stretch
        btnAbout.FlatAppearance.BorderSize = 0
        btnAbout.FlatStyle = FlatStyle.Flat
        btnAbout.ForeColor = Color.Transparent
        btnAbout.Image = CType(resources.GetObject("btnAbout.Image"), Image)
        btnAbout.Location = New Point(1057, 26)
        btnAbout.Margin = New Padding(3, 2, 3, 2)
        btnAbout.Name = "btnAbout"
        btnAbout.Size = New Size(52, 45)
        btnAbout.TabIndex = 21
        btnAbout.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(147, 775)
        Label1.Name = "Label1"
        Label1.Size = New Size(421, 25)
        Label1.TabIndex = 22
        Label1.Text = "© 2024 Coin Operated Document Printing Kiosk V2"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(1, 775)
        Label2.Name = "Label2"
        Label2.Size = New Size(81, 25)
        Label2.TabIndex = 23
        Label2.Text = "Kiosk ID:"
        ' 
        ' lblKiosk
        ' 
        lblKiosk.AutoSize = True
        lblKiosk.BackColor = Color.Transparent
        lblKiosk.Font = New Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblKiosk.ForeColor = Color.White
        lblKiosk.Location = New Point(75, 775)
        lblKiosk.Name = "lblKiosk"
        lblKiosk.Size = New Size(32, 25)
        lblKiosk.TabIndex = 24
        lblKiosk.Text = "01"
        ' 
        ' StartPage
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1280, 800)
        Controls.Add(lblKiosk)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnAbout)
        Controls.Add(lblCredits)
        Controls.Add(lblDate)
        Controls.Add(Label4)
        Controls.Add(pb_QR)
        Controls.Add(btnExcel)
        Controls.Add(btnPDF)
        Controls.Add(btnWord)
        Controls.Add(lblPaperL)
        Controls.Add(btnSettings)
        Controls.Add(lblFunds)
        Controls.Add(lblPaperS)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "StartPage"
        StartPosition = FormStartPosition.CenterScreen
        Text = "StartPage"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(pb_QR, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblPaperS As Label
    Friend WithEvents btnSettings As Button
    Friend WithEvents lblPaperL As Label
    Friend WithEvents lblFunds As Label
    Friend WithEvents btnWord As Button
    Friend WithEvents btnPDF As Button
    Friend WithEvents btnExcel As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents pb_QR As PictureBox
    Friend WithEvents lblDate As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents lblCredits As Label
    Friend WithEvents btnAbout As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblKiosk As Label

End Class
