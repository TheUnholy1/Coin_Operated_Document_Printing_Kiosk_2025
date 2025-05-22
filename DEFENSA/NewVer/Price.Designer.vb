<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Price
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Price))
        tbLetterG = New TextBox()
        tbLetterC = New TextBox()
        tbLegalG = New TextBox()
        tbLegalC = New TextBox()
        btnCancel = New Button()
        btnSave = New Button()
        SuspendLayout()
        ' 
        ' tbLetterG
        ' 
        tbLetterG.Font = New Font("Segoe UI", 20F)
        tbLetterG.Location = New Point(87, 137)
        tbLetterG.Name = "tbLetterG"
        tbLetterG.Size = New Size(125, 52)
        tbLetterG.TabIndex = 0
        ' 
        ' tbLetterC
        ' 
        tbLetterC.Font = New Font("Segoe UI", 20F)
        tbLetterC.Location = New Point(408, 137)
        tbLetterC.Name = "tbLetterC"
        tbLetterC.Size = New Size(125, 52)
        tbLetterC.TabIndex = 1
        ' 
        ' tbLegalG
        ' 
        tbLegalG.Font = New Font("Segoe UI", 20F)
        tbLegalG.Location = New Point(87, 355)
        tbLegalG.Name = "tbLegalG"
        tbLegalG.Size = New Size(125, 52)
        tbLegalG.TabIndex = 2
        ' 
        ' tbLegalC
        ' 
        tbLegalC.Font = New Font("Segoe UI", 20F)
        tbLegalC.Location = New Point(408, 355)
        tbLegalC.Name = "tbLegalC"
        tbLegalC.Size = New Size(125, 52)
        tbLegalC.TabIndex = 3
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
        btnCancel.Location = New Point(347, 589)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(161, 95)
        btnCancel.TabIndex = 9
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
        btnSave.Location = New Point(109, 589)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(161, 95)
        btnSave.TabIndex = 8
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' Price
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(632, 753)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(tbLegalC)
        Controls.Add(tbLegalG)
        Controls.Add(tbLetterC)
        Controls.Add(tbLetterG)
        FormBorderStyle = FormBorderStyle.None
        Name = "Price"
        Text = "Price"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents tbLetterG As TextBox
    Friend WithEvents tbLetterC As TextBox
    Friend WithEvents tbLegalG As TextBox
    Friend WithEvents tbLegalC As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
End Class
