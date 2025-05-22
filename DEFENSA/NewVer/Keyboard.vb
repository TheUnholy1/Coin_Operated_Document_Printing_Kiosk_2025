Public Class Keyboard

    Private isCapsLockOn As Boolean = False
    Private Sub Keyboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Assign the Click event handler to all buttons
        AddHandler btn0.Click, AddressOf btn_Click
        AddHandler btn1.Click, AddressOf btn_Click
        AddHandler btn2.Click, AddressOf btn_Click
        AddHandler btn3.Click, AddressOf btn_Click
        AddHandler btn4.Click, AddressOf btn_Click
        AddHandler btn5.Click, AddressOf btn_Click
        AddHandler btn6.Click, AddressOf btn_Click
        AddHandler btn7.Click, AddressOf btn_Click
        AddHandler btn8.Click, AddressOf btn_Click
        AddHandler btn9.Click, AddressOf btn_Click
        AddHandler btnq.Click, AddressOf btn_Click
        AddHandler btnw.Click, AddressOf btn_Click
        AddHandler btne.Click, AddressOf btn_Click
        AddHandler btnr.Click, AddressOf btn_Click
        AddHandler btnt.Click, AddressOf btn_Click
        AddHandler btny.Click, AddressOf btn_Click
        AddHandler btnu.Click, AddressOf btn_Click
        AddHandler btni.Click, AddressOf btn_Click
        AddHandler btno.Click, AddressOf btn_Click
        AddHandler btnp.Click, AddressOf btn_Click
        AddHandler btna.Click, AddressOf btn_Click
        AddHandler btns.Click, AddressOf btn_Click
        AddHandler btnd.Click, AddressOf btn_Click
        AddHandler btnf.Click, AddressOf btn_Click
        AddHandler btng.Click, AddressOf btn_Click
        AddHandler btnh.Click, AddressOf btn_Click
        AddHandler btnj.Click, AddressOf btn_Click
        AddHandler btnk.Click, AddressOf btn_Click
        AddHandler btnl.Click, AddressOf btn_Click
        AddHandler btnz.Click, AddressOf btn_Click
        AddHandler btnx.Click, AddressOf btn_Click
        AddHandler btnc.Click, AddressOf btn_Click
        AddHandler btnv.Click, AddressOf btn_Click
        AddHandler btnb.Click, AddressOf btn_Click
        AddHandler btnn.Click, AddressOf btn_Click
        AddHandler btnm.Click, AddressOf btn_Click
        AddHandler btnback.Click, AddressOf btn_Click
        AddHandler btncap.Click, AddressOf btn_Click



    End Sub

    Private targetTextBox As TextBox

    ' Function to show the keyboard below the TextBox
    Public Sub ShowKeyboard(target As TextBox)
        Me.Show()
        Me.Hide()
        targetTextBox = target

        ' Calculate the position of the TextBox relative to the screen
        Dim textBoxPosition As Point = target.PointToScreen(Point.Empty)

        ' Calculate the keyboard's position
        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Dim keyboardWidth As Integer = Me.Width
        Dim keyboardHeight As Integer = Me.Height

        ' Position the keyboard below the TextBox and center it horizontally
        Dim xPosition As Integer = textBoxPosition.X + (target.Width - keyboardWidth) / 2
        Dim yPosition As Integer = textBoxPosition.Y + target.Height

        ' Ensure the keyboard does not go off-screen
        If xPosition < 0 Then xPosition = 0
        If xPosition + keyboardWidth > screenWidth Then xPosition = screenWidth - keyboardWidth
        If yPosition + keyboardHeight > screenHeight Then yPosition = screenHeight - keyboardHeight

        ' Set the keyboard's location
        Me.Location = New Point(xPosition, yPosition)

        ' Set the keyboard to always be on top
        Me.TopMost = True

        ' Show the keyboard form
        Me.Show()
    End Sub
    ' Function to toggle the Caps Lock state on the button
    Private Sub ToggleCapsLock()
        If isCapsLockOn Then
            btncap.BackColor = Color.LightGray  ' Indicate Caps Lock is on
        Else
            btncap.BackColor = SystemColors.Control  ' Reset to default color
        End If
    End Sub



    Private Sub btn_Click(sender As Object, e As EventArgs)
        If targetTextBox IsNot Nothing Then
            Dim button As Button = CType(sender, Button)

            ' Handle Caps Lock
            If button.Name = "btncap" Then
                isCapsLockOn = Not isCapsLockOn
                ToggleCapsLock()
                UpdateButtonTexts()
            ElseIf button.Name = "btnback" Then
                ' Handle Backspace
                If targetTextBox.Text.Length > 0 Then
                    targetTextBox.Text = targetTextBox.Text.Substring(0, targetTextBox.Text.Length - 1)
                End If
            Else
                ' Handle regular character input with Caps Lock state
                If isCapsLockOn Then
                    targetTextBox.Text &= button.Text.ToUpper()
                Else
                    targetTextBox.Text &= button.Text.ToLower()
                End If
            End If
        End If
    End Sub

    Private Sub UpdateButtonTexts()
        For Each control As Control In Me.Controls
            If TypeOf control Is Button AndAlso control IsNot btncap AndAlso control IsNot btnback Then
                Dim btn As Button = CType(control, Button)
                If isCapsLockOn Then
                    btn.Text = btn.Text.ToUpper()
                Else
                    btn.Text = btn.Text.ToLower()
                End If
            End If
        Next
    End Sub



    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        ' Get the currently focused TextBox
        Dim currentTextBox As TextBox = TryCast(Me.ActiveControl, TextBox)

        ' Find the next TextBox in the tab order
        Dim nextTextBox As TextBox = Nothing
        If currentTextBox IsNot Nothing Then
            Dim textBoxes As List(Of TextBox) = Me.Controls.OfType(Of TextBox)().ToList()
            Dim currentIndex As Integer = textBoxes.IndexOf(currentTextBox)

            If currentIndex >= 0 AndAlso currentIndex < textBoxes.Count - 1 Then
                nextTextBox = textBoxes(currentIndex + 1)
            End If
        End If

        If nextTextBox IsNot Nothing Then
            ' Focus the next TextBox
            nextTextBox.Focus()
        Else
            ' Close the keyboard if no next TextBox is found
            Me.Hide()
        End If
    End Sub
End Class