Imports System
Imports System.IO
Imports System.Collections

Public Class Form1
    Dim Count As Integer = 1
    Dim loopc As Integer = 1
    Dim Counter As Integer = 0
    Dim SerPort As Array
    Dim Zeile() As String = My.Resources.ASM.Split(CChar(vbLf))


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Counter = 0
        Label1.Text = Counter.ToString
        Label2.Text = loopc.ToString
        SerialPort1.PortName = ComboBox1.Text
        SerialPort1.BaudRate = 9600
        SerialPort1.Parity = IO.Ports.Parity.None
        SerialPort1.StopBits = IO.Ports.StopBits.One
        SerialPort1.DataBits = 8
        SerialPort1.Open()
        Timer1.Interval = 1000
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Counter += 1
        Label1.Text = Counter.ToString
        Label2.Text = loopc.ToString
        If Not Count = Zeile.Length - 1 Then
            TextBox1.Text = Zeile(Count).Split(" "c)(0)
            RichTextBox1.AppendText(Zeile(Count))
            RichTextBox1.ScrollToCaret()
            SerialPort1.Write(Zeile(Count) + vbLf)

            Count += 1
        Else
            Count = 1
            Counter = 0
            loopc += 1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Stop()
        SerialPort1.Close()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SerPort = IO.Ports.SerialPort.GetPortNames
        ComboBox1.Items.AddRange(SerPort)



    End Sub
End Class
