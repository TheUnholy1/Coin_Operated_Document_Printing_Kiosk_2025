<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        tbPass = New TextBox()
        btnEnter = New Button()
        btnCancel = New Button()
        tbUser = New TextBox()
        SuspendLayout()
        ' 
        ' tbPass
        ' 
        tbPass.BackColor = Color.SteelBlue
        tbPass.Font = New Font("Segoe UI", 20F)
        tbPass.ForeColor = Color.White
        tbPass.Location = New Point(157, 270)
        tbPass.Name = "tbPass"
        tbPass.PasswordChar = "*"c
        tbPass.Size = New Size(303, 52)
        tbPass.TabIndex = 3
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
        btnEnter.Location = New Point(101, 362)
        btnEnter.Name = "btnEnter"
        btnEnter.Size = New Size(173, 101)
        btnEnter.TabIndex = 13
        btnEnter.UseVisualStyleBackColor = False
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
        btnCancel.Location = New Point(363, 362)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(173, 101)
        btnCancel.TabIndex = 14
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' tbUser
        ' 
        tbUser.BackColor = Color.SteelBlue
        tbUser.Font = New Font("Segoe UI", 20F)
        tbUser.ForeColor = Color.White
        tbUser.Location = New Point(157, 135)
        tbUser.Name = "tbUser"
        tbUser.Size = New Size(303, 52)
        tbUser.TabIndex = 1
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(620, 520)
        Controls.Add(tbUser)
        Controls.Add(btnCancel)
        Controls.Add(btnEnter)
        Controls.Add(tbPass)
        FormBorderStyle = FormBorderStyle.None
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents tbPass As TextBox
    Friend WithEvents btnEnter As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents tbUser As TextBox
End Class
