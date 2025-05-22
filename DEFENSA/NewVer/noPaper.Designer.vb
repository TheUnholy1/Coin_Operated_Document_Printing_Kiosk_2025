<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class noPaper
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(noPaper))
        Label1 = New Label()
        btnDone = New Button()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(125, 302)
        Label1.Name = "Label1"
        Label1.Size = New Size(554, 79)
        Label1.TabIndex = 5
        Label1.Text = "Out of Letter Paper!"
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
        btnDone.Location = New Point(233, 403)
        btnDone.Margin = New Padding(3, 4, 3, 4)
        btnDone.Name = "btnDone"
        btnDone.Size = New Size(149, 111)
        btnDone.TabIndex = 8
        btnDone.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(165, 56)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(285, 243)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' noPaper
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(625, 509)
        Controls.Add(PictureBox1)
        Controls.Add(btnDone)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 4, 3, 4)
        Name = "noPaper"
        StartPosition = FormStartPosition.CenterScreen
        Text = "noPaper"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnDone As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
