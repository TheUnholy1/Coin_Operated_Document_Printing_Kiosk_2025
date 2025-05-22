<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChooseFile
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChooseFile))
        btnBack = New Button()
        ListView1 = New ListView()
        Timer1 = New Timer(components)
        ImageListIcons = New ImageList(components)
        SuspendLayout()
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
        btnBack.TabIndex = 0
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' ListView1
        ' 
        ListView1.Location = New Point(84, 208)
        ListView1.Margin = New Padding(3, 2, 3, 2)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(827, 424)
        ListView1.TabIndex = 4
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' Timer1
        ' 
        ' 
        ' ImageListIcons
        ' 
        ImageListIcons.ColorDepth = ColorDepth.Depth32Bit
        ImageListIcons.ImageSize = New Size(16, 16)
        ImageListIcons.TransparentColor = Color.Transparent
        ' 
        ' ChooseFile
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1280, 800)
        Controls.Add(ListView1)
        Controls.Add(btnBack)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "ChooseFile"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ChooseFile"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnBack As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ImageListIcons As ImageList
End Class
