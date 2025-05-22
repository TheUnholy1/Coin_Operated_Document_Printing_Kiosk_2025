<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InserCoin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InserCoin))
        btnOk = New Button()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnOk
        ' 
        btnOk.BackColor = Color.Transparent
        btnOk.FlatAppearance.BorderSize = 0
        btnOk.FlatAppearance.MouseDownBackColor = Color.Transparent
        btnOk.FlatAppearance.MouseOverBackColor = Color.Transparent
        btnOk.FlatStyle = FlatStyle.Flat
        btnOk.ForeColor = Color.Transparent
        btnOk.Image = CType(resources.GetObject("btnOk.Image"), Image)
        btnOk.Location = New Point(210, 410)
        btnOk.Margin = New Padding(3, 4, 3, 4)
        btnOk.Name = "btnOk"
        btnOk.Size = New Size(149, 111)
        btnOk.TabIndex = 0
        btnOk.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(125, 57)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(350, 204)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' InserCoin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(620, 520)
        Controls.Add(PictureBox1)
        Controls.Add(btnOk)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 4, 3, 4)
        Name = "InserCoin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "InserCoin"
        TopMost = True
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnOk As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
