Imports System
Imports System.IO
Imports System.Collections

Public Class Form1
    Dim Count As Integer = 1
    Dim loopc As Integer = 1
    Dim Counter As Integer = 0
    Dim Zeile As String() = System.IO.File.ReadAllLines("C:\Users\admin\source\repos\ASM_remote\output_2020-03-20_13-41-06.log")
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Counter = 0
        Label1.Text = Counter.ToString
        Label2.Text = loopc.ToString

        Timer1.Interval = 10
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Counter += 1
        Label1.Text = Counter.ToString
        Label2.Text = loopc.ToString
        If Not Count = Zeile.Length - 1 Then
            TextBox1.Text = Zeile(Count).Split(" "c)(0)
            RichTextBox1.AppendText(Zeile(Count) + vbCrLf)
            RichTextBox1.ScrollToCaret()

            Count += 1
        Else
            Count = 1
            Counter = 0
            loopc += 1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Stop()
    End Sub
End Class
