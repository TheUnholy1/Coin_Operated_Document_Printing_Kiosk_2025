<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reports))
        btnLogHistory = New Button()
        btnDashboard = New Button()
        btnUsers = New Button()
        btnTransactions = New Button()
        btnBack = New Button()
        Panel1 = New Panel()
        DataGridView1 = New DataGridView()
        tbSearch = New TextBox()
        bntPrevious = New Button()
        btnNext = New Button()
        lblPageNumber = New Label()
        btnPrint = New Button()
        dtpFrom = New DateTimePicker()
        dtpTo = New DateTimePicker()
        btnFilter = New Button()
        btnClear = New Button()
        Panel1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnLogHistory
        ' 
        btnLogHistory.BackColor = Color.Transparent
        btnLogHistory.FlatAppearance.BorderSize = 0
        btnLogHistory.FlatStyle = FlatStyle.Flat
        btnLogHistory.Image = CType(resources.GetObject("btnLogHistory.Image"), Image)
        btnLogHistory.Location = New Point(87, 425)
        btnLogHistory.Margin = New Padding(3, 2, 3, 2)
        btnLogHistory.Name = "btnLogHistory"
        btnLogHistory.Size = New Size(205, 121)
        btnLogHistory.TabIndex = 1
        btnLogHistory.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.Transparent
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Image = CType(resources.GetObject("btnDashboard.Image"), Image)
        btnDashboard.Location = New Point(87, 2)
        btnDashboard.Margin = New Padding(3, 2, 3, 2)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(205, 121)
        btnDashboard.TabIndex = 2
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' btnUsers
        ' 
        btnUsers.BackColor = Color.Transparent
        btnUsers.FlatAppearance.BorderSize = 0
        btnUsers.FlatStyle = FlatStyle.Flat
        btnUsers.Image = CType(resources.GetObject("btnUsers.Image"), Image)
        btnUsers.Location = New Point(87, 280)
        btnUsers.Margin = New Padding(3, 2, 3, 2)
        btnUsers.Name = "btnUsers"
        btnUsers.Size = New Size(205, 121)
        btnUsers.TabIndex = 4
        btnUsers.UseVisualStyleBackColor = False
        ' 
        ' btnTransactions
        ' 
        btnTransactions.BackColor = Color.Transparent
        btnTransactions.FlatAppearance.BorderSize = 0
        btnTransactions.FlatStyle = FlatStyle.Flat
        btnTransactions.Image = CType(resources.GetObject("btnTransactions.Image"), Image)
        btnTransactions.Location = New Point(87, 142)
        btnTransactions.Margin = New Padding(3, 2, 3, 2)
        btnTransactions.Name = "btnTransactions"
        btnTransactions.Size = New Size(205, 121)
        btnTransactions.TabIndex = 5
        btnTransactions.UseVisualStyleBackColor = False
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.Transparent
        btnBack.FlatAppearance.BorderSize = 0
        btnBack.FlatStyle = FlatStyle.Flat
        btnBack.ForeColor = Color.Transparent
        btnBack.Image = CType(resources.GetObject("btnBack.Image"), Image)
        btnBack.Location = New Point(-3, -1)
        btnBack.Margin = New Padding(3, 2, 3, 2)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(69, 70)
        btnBack.TabIndex = 7
        btnBack.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(DataGridView1)
        Panel1.Location = New Point(346, 187)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(893, 519)
        Panel1.TabIndex = 8
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Margin = New Padding(3, 2, 3, 2)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.Size = New Size(893, 519)
        DataGridView1.TabIndex = 0
        ' 
        ' tbSearch
        ' 
        tbSearch.Font = New Font("Segoe UI", 18F)
        tbSearch.Location = New Point(413, 131)
        tbSearch.Margin = New Padding(3, 2, 3, 2)
        tbSearch.Name = "tbSearch"
        tbSearch.Size = New Size(502, 39)
        tbSearch.TabIndex = 9
        ' 
        ' bntPrevious
        ' 
        bntPrevious.BackColor = Color.Transparent
        bntPrevious.FlatAppearance.BorderSize = 0
        bntPrevious.FlatStyle = FlatStyle.Flat
        bntPrevious.Image = CType(resources.GetObject("bntPrevious.Image"), Image)
        bntPrevious.Location = New Point(592, 719)
        bntPrevious.Margin = New Padding(3, 2, 3, 2)
        bntPrevious.Name = "bntPrevious"
        bntPrevious.Size = New Size(146, 70)
        bntPrevious.TabIndex = 11
        bntPrevious.UseVisualStyleBackColor = False
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = Color.Transparent
        btnNext.FlatAppearance.BorderSize = 0
        btnNext.FlatStyle = FlatStyle.Flat
        btnNext.Image = CType(resources.GetObject("btnNext.Image"), Image)
        btnNext.Location = New Point(807, 719)
        btnNext.Margin = New Padding(3, 2, 3, 2)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(146, 70)
        btnNext.TabIndex = 12
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' lblPageNumber
        ' 
        lblPageNumber.AutoSize = True
        lblPageNumber.Location = New Point(396, 727)
        lblPageNumber.Name = "lblPageNumber"
        lblPageNumber.Size = New Size(41, 15)
        lblPageNumber.TabIndex = 13
        lblPageNumber.Text = "Label2"
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.Transparent
        btnPrint.FlatAppearance.BorderSize = 0
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), Image)
        btnPrint.Location = New Point(1045, 11)
        btnPrint.Margin = New Padding(3, 2, 3, 2)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(194, 128)
        btnPrint.TabIndex = 14
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' dtpFrom
        ' 
        dtpFrom.CalendarFont = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dtpFrom.CalendarMonthBackground = Color.White
        dtpFrom.Location = New Point(514, 17)
        dtpFrom.Margin = New Padding(3, 2, 3, 2)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(224, 23)
        dtpFrom.TabIndex = 16
        ' 
        ' dtpTo
        ' 
        dtpTo.Location = New Point(514, 76)
        dtpTo.Margin = New Padding(3, 2, 3, 2)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(224, 23)
        dtpTo.TabIndex = 18
        ' 
        ' btnFilter
        ' 
        btnFilter.BackColor = Color.Transparent
        btnFilter.FlatAppearance.BorderSize = 0
        btnFilter.FlatStyle = FlatStyle.Flat
        btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), Image)
        btnFilter.Location = New Point(887, 17)
        btnFilter.Margin = New Padding(3, 2, 3, 2)
        btnFilter.Name = "btnFilter"
        btnFilter.Size = New Size(118, 34)
        btnFilter.TabIndex = 19
        btnFilter.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.Transparent
        btnClear.FlatAppearance.BorderSize = 0
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Image = CType(resources.GetObject("btnClear.Image"), Image)
        btnClear.Location = New Point(887, 72)
        btnClear.Margin = New Padding(3, 2, 3, 2)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(118, 34)
        btnClear.TabIndex = 20
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' Reports
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1280, 800)
        Controls.Add(btnClear)
        Controls.Add(btnFilter)
        Controls.Add(btnPrint)
        Controls.Add(lblPageNumber)
        Controls.Add(btnNext)
        Controls.Add(bntPrevious)
        Controls.Add(tbSearch)
        Controls.Add(dtpTo)
        Controls.Add(dtpFrom)
        Controls.Add(Panel1)
        Controls.Add(btnBack)
        Controls.Add(btnTransactions)
        Controls.Add(btnUsers)
        Controls.Add(btnDashboard)
        Controls.Add(btnLogHistory)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "Reports"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reports"
        TopMost = True
        Panel1.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnLogHistory As Button
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnUsers As Button
    Friend WithEvents btnTransactions As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents tbSearch As TextBox
    Friend WithEvents bntPrevious As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents lblPageNumber As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents btnFilter As Button
    Friend WithEvents btnClear As Button
End Class
