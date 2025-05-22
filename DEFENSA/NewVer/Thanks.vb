Imports System.IO.Ports

Public Class Thanks
    Private WithEvents SerialPort2 As New SerialPort()

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.Close()
        ' Reinitialize the StartPage
        If Not StartPage.Visible Then
            StartPage.Show()
        End If
        Try
            ' Dim value As String = lblChange.Text.Trim()
            If SerialPort2.IsOpen Then
                Debug.WriteLine("SerialPort2 is open. Writing value: " & SukliMo)
                SerialPort2.WriteLine(SukliMo.ToString())
            Else
                Debug.WriteLine("SerialPort2 is not open. Attempting to open port.")
                OpenComPort()
                If SerialPort2.IsOpen Then
                    SerialPort2.WriteLine(SukliMo.ToString())
                    Debug.WriteLine("SerialPort2 is open. Writing value: " & SukliMo)
                Else
                    MessageBox.Show("Failed to open Serial Port.")
                    Return
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ResetCreditsToZero()
        If Not DeductFunds(SukliMo) Then
            ' If funds are insufficient, exit the function
            Return
        End If
        Execute.CheckForInkMonitor()
        CloseComPort()
        ResetChangetoZero()
        StartPage.InitializeComponents()
    End Sub

    Private Sub Thanks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        OpenComPort()
    End Sub
    Public Sub OpenComPort()
        Try
            If Not SerialPort2.IsOpen Then
                SerialPort2.PortName = "COM4"  ' Adjust to your specific COM port
                SerialPort2.BaudRate = 9600
                ' AddHandler SerialPort2.DataReceived, AddressOf SerialPort2_DataReceived
                SerialPort2.Open()
                Debug.WriteLine("COM port opened successfully.")
            Else
                Debug.WriteLine("port already open")
            End If

        Catch ex As Exception
            MessageBox.Show($"Failed to open COM port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CloseComPort()
        Try
            If SerialPort2.IsOpen Then
                ' Remove the DataReceived event handler
                ' RemoveHandler SerialPort2.DataReceived, AddressOf SerialPort2_DataReceived

                ' Close the COM port
                SerialPort2.Close()
                Debug.WriteLine("COM port closed successfully.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to close COM port: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class