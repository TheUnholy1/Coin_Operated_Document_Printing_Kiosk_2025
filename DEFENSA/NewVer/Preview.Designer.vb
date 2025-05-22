<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Preview
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Preview))
        btnBack = New Button()
        lblFileName = New Label()
        btnGray = New Button()
        btnColor = New Button()
        WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        btnZoomIn = New Button()
        btnZoomOut = New Button()
        lblPages = New Label()
        btnReset = New Button()
        lblCredits = New Label()
        CType(WebView21, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.Transparent
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnBack.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.ForeColor = Color.Transparent
        btnBack.Image = CType(resources.GetObject("btnBack.Image"), Image)
        btnBack.Location = New Point(4, 4)
        btnBack.Margin = New Padding(3, 2, 3, 2)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(70, 60)
        btnBack.TabIndex = 0
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' lblFileName
        ' 
        lblFileName.AutoSize = True
        lblFileName.BackColor = Color.Transparent
        lblFileName.Font = New Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblFileName.ForeColor = Color.White
        lblFileName.Location = New Point(801, 111)
        lblFileName.Name = "lblFileName"
        lblFileName.Size = New Size(167, 37)
        lblFileName.TabIndex = 3
        lblFileName.Text = "Name of File"
        ' 
        ' btnGray
        ' 
        btnGray.AutoSizeMode = AutoSizeMode.GrowAndShrink
        btnGray.BackColor = Color.Transparent
        btnGray.BackgroundImageLayout = ImageLayout.None
        btnGray.Cursor = Cursors.Hand
        btnGray.FlatAppearance.BorderSize = 0
        btnGray.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnGray.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnGray.FlatStyle = FlatStyle.Flat
        btnGray.Image = CType(resources.GetObject("btnGray.Image"), Image)
        btnGray.Location = New Point(698, 219)
        btnGray.Margin = New Padding(3, 2, 3, 2)
        btnGray.Name = "btnGray"
        btnGray.Size = New Size(236, 190)
        btnGray.TabIndex = 25
        btnGray.UseVisualStyleBackColor = False
        ' 
        ' btnColor
        ' 
        btnColor.BackColor = Color.Transparent
        btnColor.BackgroundImageLayout = ImageLayout.None
        btnColor.Cursor = Cursors.Hand
        btnColor.FlatAppearance.BorderSize = 0
        btnColor.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnColor.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnColor.FlatStyle = FlatStyle.Flat
        btnColor.Image = CType(resources.GetObject("btnColor.Image"), Image)
        btnColor.Location = New Point(977, 219)
        btnColor.Margin = New Padding(3, 2, 3, 2)
        btnColor.Name = "btnColor"
        btnColor.Size = New Size(236, 190)
        btnColor.TabIndex = 26
        btnColor.UseVisualStyleBackColor = False
        ' 
        ' WebView21
        ' 
        WebView21.AllowExternalDrop = True
        WebView21.BackColor = SystemColors.ActiveBorder
        WebView21.CreationProperties = Nothing
        WebView21.DefaultBackgroundColor = Color.White
        WebView21.Location = New Point(80, 171)
        WebView21.Margin = New Padding(3, 2, 3, 2)
        WebView21.Name = "WebView21"
        WebView21.Size = New Size(394, 539)
        WebView21.TabIndex = 29
        WebView21.ZoomFactor = 0.5R
        ' 
        ' btnZoomIn
        ' 
        btnZoomIn.BackColor = Color.Transparent
        btnZoomIn.FlatAppearance.BorderSize = 0
        btnZoomIn.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnZoomIn.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnZoomIn.FlatStyle = FlatStyle.Flat
        btnZoomIn.Image = CType(resources.GetObject("btnZoomIn.Image"), Image)
        btnZoomIn.Location = New Point(534, 241)
        btnZoomIn.Name = "btnZoomIn"
        btnZoomIn.Size = New Size(44, 38)
        btnZoomIn.TabIndex = 30
        btnZoomIn.UseVisualStyleBackColor = False
        ' 
        ' btnZoomOut
        ' 
        btnZoomOut.BackColor = Color.Transparent
        btnZoomOut.FlatAppearance.BorderSize = 0
        btnZoomOut.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnZoomOut.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnZoomOut.FlatStyle = FlatStyle.Flat
        btnZoomOut.ForeColor = Color.Transparent
        btnZoomOut.Image = CType(resources.GetObject("btnZoomOut.Image"), Image)
        btnZoomOut.Location = New Point(534, 292)
        btnZoomOut.Name = "btnZoomOut"
        btnZoomOut.Size = New Size(44, 38)
        btnZoomOut.TabIndex = 31
        btnZoomOut.UseVisualStyleBackColor = False
        ' 
        ' lblPages
        ' 
        lblPages.AutoSize = True
        lblPages.BackColor = Color.Transparent
        lblPages.Font = New Font("Segoe UI", 49.8000031F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPages.ForeColor = Color.DarkGreen
        lblPages.Location = New Point(603, 606)
        lblPages.Name = "lblPages"
        lblPages.Size = New Size(77, 89)
        lblPages.TabIndex = 5
        lblPages.Text = "0"
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.Transparent
        btnReset.FlatAppearance.BorderSize = 0
        btnReset.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnReset.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.ForeColor = Color.Transparent
        btnReset.Image = CType(resources.GetObject("btnReset.Image"), Image)
        btnReset.Location = New Point(534, 371)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(44, 38)
        btnReset.TabIndex = 32
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' lblCredits
        ' 
        lblCredits.AutoSize = True
        lblCredits.BackColor = Color.Transparent
        lblCredits.Font = New Font("Segoe UI", 49.8000031F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCredits.ForeColor = Color.DarkGreen
        lblCredits.Location = New Point(955, 621)
        lblCredits.Name = "lblCredits"
        lblCredits.Size = New Size(77, 89)
        lblCredits.TabIndex = 34
        lblCredits.Text = "0"
        ' 
        ' Preview
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(128), CByte(255), CByte(128))
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1280, 800)
        Controls.Add(WebView21)
        Controls.Add(lblCredits)
        Controls.Add(btnReset)
        Controls.Add(btnZoomOut)
        Controls.Add(btnZoomIn)
        Controls.Add(btnColor)
        Controls.Add(btnGray)
        Controls.Add(lblPages)
        Controls.Add(lblFileName)
        Controls.Add(btnBack)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Preview"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Preview"
        CType(WebView21, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnBack As Button
    Friend WithEvents lblFileName As Label
    Friend WithEvents btnGray As Button
    Friend WithEvents btnColor As Button
    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents btnZoomIn As Button
    Friend WithEvents btnZoomOut As Button
    Friend WithEvents lblPages As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents lblCredits As Label
End Class
