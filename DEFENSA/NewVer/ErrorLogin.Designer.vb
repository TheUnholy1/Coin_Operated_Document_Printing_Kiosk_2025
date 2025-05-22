<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ErrorLogin))
        tbUser = New TextBox()
        btnCancel = New Button()
        btnEnter = New Button()
        tbPass = New TextBox()
        SuspendLayout()
        ' 
        ' tbUser
        ' 
        tbUser.BackColor = Color.SteelBlue
        tbUser.Font = New Font("Segoe UI", 20F)
        tbUser.ForeColor = Color.White
        tbUser.Location = New Point(159, 136)
        tbUser.Name = "tbUser"
        tbUser.Size = New Size(303, 52)
        tbUser.TabIndex = 15
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Transparent
        btnCancel.FlatAppearance.BorderSize = 0
        btnCancel.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnCancel.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.ForeColor = Color.Transparent
        btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), Image)
        btnCancel.Location = New Point(365, 363)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(173, 101)
        btnCancel.TabIndex = 18
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnEnter
        ' 
        btnEnter.BackColor = Color.Transparent
        btnEnter.FlatAppearance.BorderSize = 0
        btnEnter.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnEnter.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnEnter.FlatStyle = FlatStyle.Flat
        btnEnter.ForeColor = Color.Transparent
        btnEnter.Image = CType(resources.GetObject("btnEnter.Image"), Image)
        btnEnter.Location = New Point(103, 363)
        btnEnter.Name = "btnEnter"
        btnEnter.Size = New Size(173, 101)
        btnEnter.TabIndex = 17
        btnEnter.UseVisualStyleBackColor = False
        ' 
        ' tbPass
        ' 
        tbPass.BackColor = Color.SteelBlue
        tbPass.Font = New Font("Segoe UI", 20F)
        tbPass.ForeColor = Color.White
        tbPass.Location = New Point(159, 271)
        tbPass.Name = "tbPass"
        tbPass.PasswordChar = "*"c
        tbPass.Size = New Size(303, 52)
        tbPass.TabIndex = 16
        ' 
        ' ErrorLogin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(620, 520)
        Controls.Add(tbUser)
        Controls.Add(btnCancel)
        Controls.Add(btnEnter)
        Controls.Add(tbPass)
        FormBorderStyle = FormBorderStyle.None
        Name = "ErrorLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ErrorLogin"
        TopMost = True
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents tbUser As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnEnter As Button
    Friend WithEvents tbPass As TextBox
End Class
