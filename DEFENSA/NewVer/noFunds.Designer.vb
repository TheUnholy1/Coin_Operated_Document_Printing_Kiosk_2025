<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class noFunds
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(noFunds))
        btnDone = New Button()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnDone
        ' 
        btnDone.BackColor = Color.Transparent
        btnDone.FlatAppearance.BorderSize = 0
        btnDone.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnDone.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnDone.FlatStyle = FlatStyle.Flat
        btnDone.ForeColor = Color.Transparent
        btnDone.Image = CType(resources.GetObject("btnDone.Image"), Image)
        btnDone.Location = New Point(217, 408)
        btnDone.Margin = New Padding(3, 4, 3, 4)
        btnDone.Name = "btnDone"
        btnDone.Size = New Size(149, 111)
        btnDone.TabIndex = 0
        btnDone.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 28F)
        Label1.Location = New Point(83, 236)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 62)
        Label1.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(144, 17)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(303, 391)
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(444, 315)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 28)
        Label2.TabIndex = 3
        Label2.Text = "Label2"
        ' 
        ' noFunds
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(620, 520)
        Controls.Add(Label2)
        Controls.Add(PictureBox1)
        Controls.Add(Label1)
        Controls.Add(btnDone)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 4, 3, 4)
        Name = "noFunds"
        StartPosition = FormStartPosition.CenterScreen
        Text = "noFunds"
        TopMost = True
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnDone As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
End Class
