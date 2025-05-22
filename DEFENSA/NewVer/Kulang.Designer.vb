<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Kulang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Kulang))
        Label1 = New Label()
        btnOk = New Button()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(117, 163)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 54)
        Label1.TabIndex = 0
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
        btnOk.Location = New Point(233, 409)
        btnOk.Margin = New Padding(3, 4, 3, 4)
        btnOk.Name = "btnOk"
        btnOk.Size = New Size(149, 111)
        btnOk.TabIndex = 1
        btnOk.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(139, 51)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(341, 311)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' Kulang
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(620, 520)
        Controls.Add(PictureBox1)
        Controls.Add(btnOk)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 4, 3, 4)
        Name = "Kulang"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Kulang"
        TopMost = True
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnOk As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
