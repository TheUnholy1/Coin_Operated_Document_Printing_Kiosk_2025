<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Grayscale
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Grayscale))
        btnBack = New Button()
        lblPay = New Label()
        lblCredits = New Label()
        lblChange = New Label()
        btnPrint = New Button()
        GroupBox2 = New GroupBox()
        rbLegal = New RadioButton()
        rbLetter = New RadioButton()
        btnCopiesMinus = New Button()
        btnCopiesAdd = New Button()
        tbCopies = New TextBox()
        btnMinusTo = New Button()
        btnAddTo = New Button()
        tbTo = New TextBox()
        btnMinusFrom = New Button()
        btnAddFrom = New Button()
        tbFrom = New TextBox()
        GroupBox1 = New GroupBox()
        rbSpecificPage = New RadioButton()
        rbAllPagess = New RadioButton()
        GroupBox3 = New GroupBox()
        rbLandscape = New RadioButton()
        rbPortrait = New RadioButton()
        GroupBox2.SuspendLayout()
        GroupBox1.SuspendLayout()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.Transparent
        btnBack.BackgroundImageLayout = ImageLayout.None
        btnBack.Cursor = Cursors.Hand
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnBack.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.Image = CType(resources.GetObject("btnBack.Image"), Image)
        btnBack.Location = New Point(978, 542)
        btnBack.Margin = New Padding(3, 2, 3, 2)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(201, 129)
        btnBack.TabIndex = 0
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' lblPay
        ' 
        lblPay.AutoSize = True
        lblPay.BackColor = Color.Transparent
        lblPay.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        lblPay.ForeColor = Color.White
        lblPay.Location = New Point(1049, 215)
        lblPay.Name = "lblPay"
        lblPay.Size = New Size(44, 51)
        lblPay.TabIndex = 12
        lblPay.Text = "0"
        ' 
        ' lblCredits
        ' 
        lblCredits.AutoSize = True
        lblCredits.BackColor = Color.Transparent
        lblCredits.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        lblCredits.ForeColor = Color.White
        lblCredits.Location = New Point(1049, 312)
        lblCredits.Name = "lblCredits"
        lblCredits.Size = New Size(44, 51)
        lblCredits.TabIndex = 14
        lblCredits.Text = "0"
        ' 
        ' lblChange
        ' 
        lblChange.AutoSize = True
        lblChange.BackColor = Color.Transparent
        lblChange.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        lblChange.ForeColor = Color.White
        lblChange.Location = New Point(1049, 405)
        lblChange.Name = "lblChange"
        lblChange.Size = New Size(44, 51)
        lblChange.TabIndex = 16
        lblChange.Text = "0"
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.Transparent
        btnPrint.BackgroundImageLayout = ImageLayout.None
        btnPrint.Cursor = Cursors.Hand
        btnPrint.FlatAppearance.BorderSize = 0
        btnPrint.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnPrint.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), Image)
        btnPrint.Location = New Point(734, 542)
        btnPrint.Margin = New Padding(3, 2, 3, 2)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(201, 129)
        btnPrint.TabIndex = 17
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' GroupBox2
        ' 
        GroupBox2.BackColor = Color.Transparent
        GroupBox2.Controls.Add(rbLegal)
        GroupBox2.Controls.Add(rbLetter)
        GroupBox2.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        GroupBox2.ForeColor = Color.White
        GroupBox2.Location = New Point(595, 394)
        GroupBox2.Margin = New Padding(3, 2, 3, 2)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(3, 2, 3, 2)
        GroupBox2.Size = New Size(192, 100)
        GroupBox2.TabIndex = 43
        GroupBox2.TabStop = False
        GroupBox2.Text = " "
        ' 
        ' rbLegal
        ' 
        rbLegal.AutoSize = True
        rbLegal.Location = New Point(20, 65)
        rbLegal.Margin = New Padding(3, 2, 3, 2)
        rbLegal.Name = "rbLegal"
        rbLegal.Size = New Size(77, 29)
        rbLegal.TabIndex = 20
        rbLegal.TabStop = True
        rbLegal.Text = "Legal"
        rbLegal.UseVisualStyleBackColor = True
        ' 
        ' rbLetter
        ' 
        rbLetter.AutoSize = True
        rbLetter.Location = New Point(20, 19)
        rbLetter.Margin = New Padding(3, 2, 3, 2)
        rbLetter.Name = "rbLetter"
        rbLetter.Size = New Size(82, 29)
        rbLetter.TabIndex = 19
        rbLetter.TabStop = True
        rbLetter.Text = "Letter"
        rbLetter.UseVisualStyleBackColor = True
        ' 
        ' btnCopiesMinus
        ' 
        btnCopiesMinus.BackColor = Color.Transparent
        btnCopiesMinus.FlatAppearance.BorderSize = 0
        btnCopiesMinus.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnCopiesMinus.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnCopiesMinus.FlatStyle = FlatStyle.Flat
        btnCopiesMinus.ForeColor = Color.Transparent
        btnCopiesMinus.Image = CType(resources.GetObject("btnCopiesMinus.Image"), Image)
        btnCopiesMinus.Location = New Point(524, 622)
        btnCopiesMinus.Margin = New Padding(3, 2, 3, 2)
        btnCopiesMinus.Name = "btnCopiesMinus"
        btnCopiesMinus.Size = New Size(57, 49)
        btnCopiesMinus.TabIndex = 42
        btnCopiesMinus.Text = "-"
        btnCopiesMinus.UseVisualStyleBackColor = False
        ' 
        ' btnCopiesAdd
        ' 
        btnCopiesAdd.BackColor = Color.Transparent
        btnCopiesAdd.FlatAppearance.BorderSize = 0
        btnCopiesAdd.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnCopiesAdd.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnCopiesAdd.FlatStyle = FlatStyle.Flat
        btnCopiesAdd.ForeColor = Color.Transparent
        btnCopiesAdd.Image = CType(resources.GetObject("btnCopiesAdd.Image"), Image)
        btnCopiesAdd.Location = New Point(442, 622)
        btnCopiesAdd.Margin = New Padding(3, 2, 3, 2)
        btnCopiesAdd.Name = "btnCopiesAdd"
        btnCopiesAdd.Size = New Size(57, 49)
        btnCopiesAdd.TabIndex = 41
        btnCopiesAdd.Text = "+"
        btnCopiesAdd.UseVisualStyleBackColor = False
        ' 
        ' tbCopies
        ' 
        tbCopies.BackColor = Color.SteelBlue
        tbCopies.Font = New Font("Segoe UI", 20F)
        tbCopies.ForeColor = Color.White
        tbCopies.Location = New Point(356, 627)
        tbCopies.Margin = New Padding(3, 2, 3, 2)
        tbCopies.Multiline = True
        tbCopies.Name = "tbCopies"
        tbCopies.ReadOnly = True
        tbCopies.Size = New Size(59, 38)
        tbCopies.TabIndex = 40
        tbCopies.Text = "1"
        ' 
        ' btnMinusTo
        ' 
        btnMinusTo.BackColor = Color.Transparent
        btnMinusTo.FlatAppearance.BorderSize = 0
        btnMinusTo.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnMinusTo.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnMinusTo.FlatStyle = FlatStyle.Flat
        btnMinusTo.ForeColor = Color.Transparent
        btnMinusTo.Image = CType(resources.GetObject("btnMinusTo.Image"), Image)
        btnMinusTo.Location = New Point(429, 419)
        btnMinusTo.Margin = New Padding(3, 2, 3, 2)
        btnMinusTo.Name = "btnMinusTo"
        btnMinusTo.Size = New Size(57, 49)
        btnMinusTo.TabIndex = 37
        btnMinusTo.Text = "-"
        btnMinusTo.UseVisualStyleBackColor = False
        ' 
        ' btnAddTo
        ' 
        btnAddTo.BackColor = Color.Transparent
        btnAddTo.FlatAppearance.BorderSize = 0
        btnAddTo.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAddTo.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnAddTo.FlatStyle = FlatStyle.Flat
        btnAddTo.ForeColor = Color.Transparent
        btnAddTo.Image = CType(resources.GetObject("btnAddTo.Image"), Image)
        btnAddTo.Location = New Point(345, 418)
        btnAddTo.Margin = New Padding(3, 2, 3, 2)
        btnAddTo.Name = "btnAddTo"
        btnAddTo.Size = New Size(57, 49)
        btnAddTo.TabIndex = 36
        btnAddTo.Text = "+"
        btnAddTo.UseVisualStyleBackColor = False
        ' 
        ' tbTo
        ' 
        tbTo.BackColor = Color.SteelBlue
        tbTo.Font = New Font("Segoe UI", 20F)
        tbTo.ForeColor = Color.White
        tbTo.Location = New Point(266, 418)
        tbTo.Margin = New Padding(3, 2, 3, 2)
        tbTo.MaxLength = 60
        tbTo.Multiline = True
        tbTo.Name = "tbTo"
        tbTo.ReadOnly = True
        tbTo.Size = New Size(59, 38)
        tbTo.TabIndex = 35
        ' 
        ' btnMinusFrom
        ' 
        btnMinusFrom.BackColor = Color.Transparent
        btnMinusFrom.FlatAppearance.BorderSize = 0
        btnMinusFrom.FlatStyle = FlatStyle.Flat
        btnMinusFrom.ForeColor = Color.Transparent
        btnMinusFrom.Image = CType(resources.GetObject("btnMinusFrom.Image"), Image)
        btnMinusFrom.Location = New Point(429, 327)
        btnMinusFrom.Margin = New Padding(3, 2, 3, 2)
        btnMinusFrom.Name = "btnMinusFrom"
        btnMinusFrom.Size = New Size(57, 49)
        btnMinusFrom.TabIndex = 33
        btnMinusFrom.Text = "-"
        btnMinusFrom.UseVisualStyleBackColor = False
        ' 
        ' btnAddFrom
        ' 
        btnAddFrom.BackColor = Color.Transparent
        btnAddFrom.FlatAppearance.BorderSize = 0
        btnAddFrom.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnAddFrom.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnAddFrom.FlatStyle = FlatStyle.Flat
        btnAddFrom.ForeColor = Color.Transparent
        btnAddFrom.Image = CType(resources.GetObject("btnAddFrom.Image"), Image)
        btnAddFrom.Location = New Point(345, 327)
        btnAddFrom.Margin = New Padding(3, 2, 3, 2)
        btnAddFrom.Name = "btnAddFrom"
        btnAddFrom.Size = New Size(57, 49)
        btnAddFrom.TabIndex = 32
        btnAddFrom.Text = "+"
        btnAddFrom.UseVisualStyleBackColor = False
        ' 
        ' tbFrom
        ' 
        tbFrom.BackColor = Color.SteelBlue
        tbFrom.Font = New Font("Segoe UI", 20F)
        tbFrom.ForeColor = Color.White
        tbFrom.Location = New Point(265, 339)
        tbFrom.Margin = New Padding(3, 2, 3, 2)
        tbFrom.MaxLength = 60
        tbFrom.Multiline = True
        tbFrom.Name = "tbFrom"
        tbFrom.ReadOnly = True
        tbFrom.Size = New Size(59, 38)
        tbFrom.TabIndex = 31
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.Controls.Add(rbSpecificPage)
        GroupBox1.Controls.Add(rbAllPagess)
        GroupBox1.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        GroupBox1.ForeColor = Color.White
        GroupBox1.Location = New Point(161, 198)
        GroupBox1.Margin = New Padding(3, 2, 3, 2)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 2, 3, 2)
        GroupBox1.Size = New Size(254, 105)
        GroupBox1.TabIndex = 29
        GroupBox1.TabStop = False
        GroupBox1.Text = " "
        ' 
        ' rbSpecificPage
        ' 
        rbSpecificPage.AutoSize = True
        rbSpecificPage.Location = New Point(32, 64)
        rbSpecificPage.Margin = New Padding(3, 2, 3, 2)
        rbSpecificPage.Name = "rbSpecificPage"
        rbSpecificPage.Size = New Size(169, 29)
        rbSpecificPage.TabIndex = 8
        rbSpecificPage.TabStop = True
        rbSpecificPage.Text = "Specific Page(s)"
        rbSpecificPage.UseVisualStyleBackColor = True
        ' 
        ' rbAllPagess
        ' 
        rbAllPagess.AutoSize = True
        rbAllPagess.Location = New Point(32, 17)
        rbAllPagess.Margin = New Padding(3, 2, 3, 2)
        rbAllPagess.Name = "rbAllPagess"
        rbAllPagess.Size = New Size(110, 29)
        rbAllPagess.TabIndex = 7
        rbAllPagess.TabStop = True
        rbAllPagess.Text = "All Pages"
        rbAllPagess.UseVisualStyleBackColor = True
        ' 
        ' GroupBox3
        ' 
        GroupBox3.BackColor = Color.Transparent
        GroupBox3.Controls.Add(rbLandscape)
        GroupBox3.Controls.Add(rbPortrait)
        GroupBox3.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        GroupBox3.ForeColor = Color.White
        GroupBox3.Location = New Point(595, 201)
        GroupBox3.Margin = New Padding(3, 2, 3, 2)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Padding = New Padding(3, 2, 3, 2)
        GroupBox3.Size = New Size(192, 102)
        GroupBox3.TabIndex = 46
        GroupBox3.TabStop = False
        GroupBox3.Text = " "
        ' 
        ' rbLandscape
        ' 
        rbLandscape.AutoSize = True
        rbLandscape.Location = New Point(20, 66)
        rbLandscape.Margin = New Padding(3, 2, 3, 2)
        rbLandscape.Name = "rbLandscape"
        rbLandscape.Size = New Size(123, 29)
        rbLandscape.TabIndex = 20
        rbLandscape.TabStop = True
        rbLandscape.Text = "Landscape"
        rbLandscape.UseVisualStyleBackColor = True
        ' 
        ' rbPortrait
        ' 
        rbPortrait.AutoSize = True
        rbPortrait.Location = New Point(20, 15)
        rbPortrait.Margin = New Padding(3, 2, 3, 2)
        rbPortrait.Name = "rbPortrait"
        rbPortrait.Size = New Size(99, 29)
        rbPortrait.TabIndex = 19
        rbPortrait.TabStop = True
        rbPortrait.Text = "Portrait"
        rbPortrait.UseVisualStyleBackColor = True
        ' 
        ' Grayscale
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1280, 800)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(btnCopiesMinus)
        Controls.Add(btnCopiesAdd)
        Controls.Add(tbCopies)
        Controls.Add(btnMinusTo)
        Controls.Add(btnAddTo)
        Controls.Add(tbTo)
        Controls.Add(btnMinusFrom)
        Controls.Add(btnAddFrom)
        Controls.Add(tbFrom)
        Controls.Add(GroupBox1)
        Controls.Add(btnPrint)
        Controls.Add(lblChange)
        Controls.Add(lblCredits)
        Controls.Add(lblPay)
        Controls.Add(btnBack)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Grayscale"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Grayscale"
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnBack As Button
    Friend WithEvents lblPay As Label
    Friend WithEvents lblCredits As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbLegal As RadioButton
    Friend WithEvents rbLetter As RadioButton
    Friend WithEvents btnCopiesMinus As Button
    Friend WithEvents btnCopiesAdd As Button
    Friend WithEvents tbCopies As TextBox
    Friend WithEvents btnMinusTo As Button
    Friend WithEvents btnAddTo As Button
    Friend WithEvents tbTo As TextBox
    Friend WithEvents btnMinusFrom As Button
    Friend WithEvents btnAddFrom As Button
    Friend WithEvents tbFrom As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbSpecificPage As RadioButton
    Friend WithEvents rbAllPagess As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rbLandscape As RadioButton
    Friend WithEvents rbPortrait As RadioButton
End Class
