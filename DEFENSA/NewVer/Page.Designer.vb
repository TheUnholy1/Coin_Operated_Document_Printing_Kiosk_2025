<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Page
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Page))
        btnCancel = New Button()
        btnSave = New Button()
        cbShort = New ComboBox()
        cbLong = New ComboBox()
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
        btnCancel.Location = New Point(351, 555)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(161, 95)
        btnCancel.TabIndex = 4
        btnCancel.UseVisualStyleBackColor = False
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
        btnSave.Location = New Point(113, 555)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(161, 95)
        btnSave.TabIndex = 3
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' cbShort
        ' 
        cbShort.BackColor = Color.SteelBlue
        cbShort.Font = New Font("Segoe UI", 25F)
        cbShort.ForeColor = Color.White
        cbShort.FormattingEnabled = True
        cbShort.Location = New Point(323, 182)
        cbShort.Name = "cbShort"
        cbShort.Size = New Size(168, 65)
        cbShort.TabIndex = 7
        ' 
        ' cbLong
        ' 
        cbLong.BackColor = Color.SteelBlue
        cbLong.Font = New Font("Segoe UI", 25F)
        cbLong.ForeColor = Color.White
        cbLong.FormattingEnabled = True
        cbLong.Location = New Point(323, 338)
        cbLong.Name = "cbLong"
        cbLong.Size = New Size(168, 65)
        cbLong.TabIndex = 8
        ' 
        ' Page
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(632, 753)
        Controls.Add(cbLong)
        Controls.Add(cbShort)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        FormBorderStyle = FormBorderStyle.None
        Name = "Page"
        Text = "Page"
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents cbShort As ComboBox
    Friend WithEvents cbLong As ComboBox
End Class
