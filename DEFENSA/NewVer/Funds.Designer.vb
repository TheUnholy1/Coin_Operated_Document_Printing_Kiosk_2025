<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Funds
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Funds))
        btnCancel = New Button()
        cbCoins = New ComboBox()
        btnSave = New Button()
        SuspendLayout()
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Transparent
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 25F)
        btnCancel.ForeColor = Color.Transparent
        btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), Image)
        btnCancel.Location = New Point(349, 465)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(161, 95)
        btnCancel.TabIndex = 2
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' cbCoins
        ' 
        cbCoins.BackColor = Color.SteelBlue
        cbCoins.Font = New Font("Segoe UI", 25F)
        cbCoins.ForeColor = Color.White
        cbCoins.FormattingEnabled = True
        cbCoins.ItemHeight = 57
        cbCoins.Location = New Point(201, 279)
        cbCoins.Name = "cbCoins"
        cbCoins.Size = New Size(251, 65)
        cbCoins.TabIndex = 9
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.Transparent
        btnSave.FlatAppearance.BorderSize = 0
        btnSave.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnSave.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 25F)
        btnSave.ForeColor = Color.Transparent
        btnSave.Image = CType(resources.GetObject("btnSave.Image"), Image)
        btnSave.Location = New Point(144, 465)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(161, 95)
        btnSave.TabIndex = 1
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' Funds
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(632, 753)
        Controls.Add(cbCoins)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        FormBorderStyle = FormBorderStyle.None
        Name = "Funds"
        Text = "Funds"
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnCancel As Button
    Friend WithEvents cbCoins As ComboBox
    Friend WithEvents btnSave As Button
End Class
