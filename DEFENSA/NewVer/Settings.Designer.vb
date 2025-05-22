<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        btnFunds = New Button()
        Panel1 = New Panel()
        btnReload = New Button()
        btnBack = New Button()
        btnPrice = New Button()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' btnFunds
        ' 
        btnFunds.BackColor = Color.Transparent
        btnFunds.FlatAppearance.BorderSize = 0
        btnFunds.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnFunds.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnFunds.FlatStyle = FlatStyle.Flat
        btnFunds.ForeColor = Color.Transparent
        btnFunds.Image = CType(resources.GetObject("btnFunds.Image"), Image)
        btnFunds.Location = New Point(309, 122)
        btnFunds.Margin = New Padding(3, 2, 3, 2)
        btnFunds.Name = "btnFunds"
        btnFunds.Size = New Size(167, 146)
        btnFunds.TabIndex = 1
        btnFunds.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(669, 70)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(538, 526)
        Panel1.TabIndex = 3
        ' 
        ' btnReload
        ' 
        btnReload.BackColor = Color.Transparent
        btnReload.FlatAppearance.BorderSize = 0
        btnReload.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnReload.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnReload.FlatStyle = FlatStyle.Flat
        btnReload.ForeColor = Color.Transparent
        btnReload.Image = CType(resources.GetObject("btnReload.Image"), Image)
        btnReload.Location = New Point(66, 122)
        btnReload.Margin = New Padding(3, 2, 3, 2)
        btnReload.Name = "btnReload"
        btnReload.Size = New Size(167, 146)
        btnReload.TabIndex = 0
        btnReload.UseVisualStyleBackColor = False
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
        btnBack.TabIndex = 2
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' btnPrice
        ' 
        btnPrice.BackColor = Color.Transparent
        btnPrice.FlatAppearance.BorderSize = 0
        btnPrice.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnPrice.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnPrice.FlatStyle = FlatStyle.Flat
        btnPrice.ForeColor = Color.Transparent
        btnPrice.Image = CType(resources.GetObject("btnPrice.Image"), Image)
        btnPrice.Location = New Point(66, 334)
        btnPrice.Margin = New Padding(3, 2, 3, 2)
        btnPrice.Name = "btnPrice"
        btnPrice.Size = New Size(167, 146)
        btnPrice.TabIndex = 4
        btnPrice.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Transparent
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.ForeColor = Color.Transparent
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.Location = New Point(309, 334)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(167, 146)
        Button1.TabIndex = 5
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1280, 800)
        Controls.Add(Button1)
        Controls.Add(btnPrice)
        Controls.Add(btnFunds)
        Controls.Add(btnBack)
        Controls.Add(btnReload)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Settings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Settings"
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnFunds As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnReload As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnPrice As Button
    Friend WithEvents Button1 As Button
End Class
