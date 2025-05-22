<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        lblTransactions = New Label()
        lblRefill = New Label()
        lblFunds = New Label()
        lblLetter = New Label()
        lblLegal = New Label()
        lblIncome = New Label()
        SuspendLayout()
        ' 
        ' lblTransactions
        ' 
        lblTransactions.AutoSize = True
        lblTransactions.Font = New Font("Segoe UI", 20F)
        lblTransactions.Location = New Point(116, 162)
        lblTransactions.Name = "lblTransactions"
        lblTransactions.Size = New Size(32, 37)
        lblTransactions.TabIndex = 1
        lblTransactions.Text = "0"
        ' 
        ' lblRefill
        ' 
        lblRefill.AutoSize = True
        lblRefill.Font = New Font("Segoe UI", 20F)
        lblRefill.Location = New Point(348, 162)
        lblRefill.Name = "lblRefill"
        lblRefill.Size = New Size(32, 37)
        lblRefill.TabIndex = 3
        lblRefill.Text = "0"
        ' 
        ' lblFunds
        ' 
        lblFunds.AutoSize = True
        lblFunds.Font = New Font("Segoe UI", 20F)
        lblFunds.Location = New Point(707, 162)
        lblFunds.Name = "lblFunds"
        lblFunds.Size = New Size(32, 37)
        lblFunds.TabIndex = 5
        lblFunds.Text = "0"
        ' 
        ' lblLetter
        ' 
        lblLetter.AutoSize = True
        lblLetter.Font = New Font("Segoe UI", 20F)
        lblLetter.Location = New Point(116, 442)
        lblLetter.Name = "lblLetter"
        lblLetter.Size = New Size(32, 37)
        lblLetter.TabIndex = 7
        lblLetter.Text = "0"
        ' 
        ' lblLegal
        ' 
        lblLegal.AutoSize = True
        lblLegal.Font = New Font("Segoe UI", 20F)
        lblLegal.Location = New Point(421, 442)
        lblLegal.Name = "lblLegal"
        lblLegal.Size = New Size(32, 37)
        lblLegal.TabIndex = 9
        lblLegal.Text = "0"
        ' 
        ' lblIncome
        ' 
        lblIncome.AutoSize = True
        lblIncome.Font = New Font("Segoe UI", 20F)
        lblIncome.Location = New Point(660, 442)
        lblIncome.Name = "lblIncome"
        lblIncome.Size = New Size(32, 37)
        lblIncome.TabIndex = 11
        lblIncome.Text = "0"
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(895, 523)
        Controls.Add(lblIncome)
        Controls.Add(lblLegal)
        Controls.Add(lblLetter)
        Controls.Add(lblFunds)
        Controls.Add(lblRefill)
        Controls.Add(lblTransactions)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Dashboard"
        Text = "Dashboard"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lblTransactions As Label
    Friend WithEvents lblRefill As Label
    Friend WithEvents lblFunds As Label
    Friend WithEvents lblLetter As Label
    Friend WithEvents lblLegal As Label
    Friend WithEvents lblIncome As Label
End Class
