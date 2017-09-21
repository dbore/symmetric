'Copyright (C) 2014 Damian Borecki 
Public Class Form1


    Dim count_mause As Integer = 0
    Dim mousex As Integer
    Dim mousey As Integer

    Dim pos As New Random
    Dim x As Integer
    Dim y As Integer

    Dim z As New System.Drawing.Drawing2D.GraphicsPath

    Dim timercount As Integer = 0
    Dim i As Integer

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Me.Close()

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'make the form fill the screen
        Me.Width = My.Computer.Screen.WorkingArea.Width + 50
        Me.Height = My.Computer.Screen.WorkingArea.Height + 50 ' 50 minimum

        'hide cursor
        Windows.Forms.Cursor.Hide()
        mousex = Windows.Forms.Cursor.Position.X
        mousey = Windows.Forms.Cursor.Position.Y



    End Sub

    Sub checkmouse_pos()
        '// much better then mousemove event
        If mousex > Windows.Forms.Cursor.Position.X Or mousex < Windows.Forms.Cursor.Position.X Then
            Me.Close()

        End If

    End Sub

    Private Sub Form1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.Close()
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        Dim g As Graphics = Me.CreateGraphics()
        Me.BackColor = Color.Black


        'random color linear
        Dim colorlin As New Random
        Dim red = 0, green = 0, blue = 0, alpha = 0
        red = colorlin.Next(1, 255) ' no black color
        green = colorlin.Next(1, 255)
        blue = colorlin.Next(1, 255)
        alpha = colorlin.Next(60, 255)
        Dim first_color As Color = Color.FromArgb(alpha, red, green, blue)

        red = colorlin.Next(0, 255)
        green = colorlin.Next(0, 255)
        blue = colorlin.Next(0, 255)
        alpha = colorlin.Next(60, 255)
        Dim second_color As Color = Color.FromArgb(alpha, red, green, blue)

        Dim LinearGradient As New Drawing.Drawing2D.LinearGradientBrush(New Drawing.Point(10, 10), _
                                                   New Drawing.Point(10, 0), _
                                                   first_color, _
                                                   second_color)

        Dim p As New Pen(Color.Yellow, 3)
        p.Brush = LinearGradient
        p.Width = 3




        'no color
        'directions
        Dim centrex1 As Integer = Me.Width / 2
        Dim centrey1 As Integer = Me.Height / 2
        Dim centrex2 As Integer = Me.Width / 2
        Dim centrey2 As Integer = Me.Height / 2
        Dim centrex3 As Integer = Me.Width / 2
        Dim centrey3 As Integer = Me.Height / 2
        Dim centrex4 As Integer = Me.Width / 2
        Dim centrey4 As Integer = Me.Height / 2

        i = 0

        For i = 0 To 20

            Dim Dir1 As Integer = pos.Next(0, 2)
            g.DrawEllipse(p, centrex1, centrey1, 20, 20)
            g.DrawEllipse(p, centrex2, centrey2, 20, 20)
            g.DrawEllipse(p, centrex3, centrey3, 20, 20)
            g.DrawEllipse(p, centrex4, centrey4, 20, 20)

            'left - down dir
            If Dir1 = 0 Then
                centrex1 = centrex1 - 20
            Else
                centrey1 = centrey1 + 20
            End If

            'right - down dir
            If Dir1 = 0 Then
                centrex2 = centrex2 + 20
            Else
                centrey2 = centrey2 + 20
            End If

            'left - top dir 
            If Dir1 = 0 Then
                centrex3 = centrex3 - 20
            Else
                centrey3 = centrey3 - 20
            End If

            'right - top dir 
            If Dir1 = 0 Then
                centrex4 = centrex4 + 20
            Else
                centrey4 = centrey4 - 20
            End If



        Next





        checkmouse_pos()

        Me.Invalidate() 'no need for timer

        System.Threading.Thread.Sleep(500)


    End Sub

End Class

