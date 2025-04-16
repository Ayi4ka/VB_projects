Public Class Form1
    Dim x0 = 350
    Dim y0 = 90
    Dim ymax = 50
    Dim i_mouse, pozx, pozy

    Dim leftt = 350
    Dim rightt = 350
    Dim up = 200
    Dim down = 600
    Dim g = 9.8

    Public StopEvents As Boolean
    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        i_mouse = 1
    End Sub
    Private Sub Form1_Load(ByVal senderr As Object, ByVal e As EventArgs) Handles MyBase.Load

        ComboBox1.Text = "Воздух"
        i_mouse = 0 'Нач. значение - клавиша мышки отжата
        pozx = 0.5 * PictureBox1.Width 'х-Центр картинки
        pozy = 0.5 * PictureBox1.Height 'У-Центр картинки  


        TextBox1.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False

    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If StopEvents Then Exit Sub

        Dim mouseX As Integer = e.X 'Текущая Х-координата на картинке
        Dim mouseY As Integer = e.Y 'Текущая У-координата на картинке

        If i_mouse = 1 And mouseX >= pozx - 10 And mouseX <= pozx + 10 Then
            'Смещение картинки на форме по Х, если нажата клавиша мыши и есть перемещение
            PictureBox1.Left = PictureBox1.Left + mouseX - 0.5 * PictureBox1.Width
            pozx = mouseX
        End If

        If i_mouse = 1 And mouseY >= pozy - 10 And mouseY <= pozy + 10 Then
            'Смещение картинки на форме по Y, если нажата клавиша мыши и есть перемещение
            PictureBox1.Top = PictureBox1.Top + mouseY - 0.5 * PictureBox1.Height
            pozy = mouseY
        End If
    End Sub
    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        i_mouse = 0
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If ComboBox1.Text = "Вода" Or ComboBox1.Text = "Масло" Then
            NumericUpDown1.Enabled = False
        End If

        If ComboBox1.Text = "Воздух" Then
            NumericUpDown1.Enabled = True
        End If

        Dim Pen1 = New Pen(Drawing.Color.Black, 3)
        Dim grafs As Graphics = Me.CreateGraphics()
        Dim gran As Integer = PictureBox1.Location.X + PictureBox1.Width * 0.5
        Dim grun As Integer = PictureBox1.Location.Y + PictureBox1.Height * 0.5

        If gran > rightt Then
            gran = 327
            PictureBox1.Left = gran
        End If

        If gran < leftt Then
            gran = 327
            PictureBox1.Left = gran
        End If

        If grun < up Then
            grun = 220
            PictureBox1.Top = grun
        End If

        If grun > down Then
            grun = 550
            PictureBox1.Top = grun
        End If

        Dim dlina As String = Math.Round(Math.Sqrt((gran - x0) ^ 2 + (y0 - grun) ^ 2))
        Label10.Text = dlina / 10


        grafs.DrawLine(Pen1, x0, y0, gran, grun)
        grafs.Clear(Color.White)
        grafs.DrawLine(Pen1, x0, y0, gran, grun)

    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim gran As Double = PictureBox1.Location.X + PictureBox1.Width * 0.5
        Dim grun As Double = PictureBox1.Location.Y + PictureBox1.Height * 0.5
        Dim dlina = Val(Label10.Text) * 10
        Dim fi As Double = Label12.Text
        Dim o As Integer = Val(Label13.Text)
        Dim m As Double = NumericUpDown2.Value
        Dim r As Double
        If ComboBox1.Text = "Воздух" Then
            r = NumericUpDown1.Value
            If r = 0 Then
                r = 1
            End If
            r = r * 1.5
        End If

        If ComboBox1.Text = "Вода" Then
            r = 5
        End If

        If ComboBox1.Text = "Масло" Then
            r = 5.5
        End If

        fi = Math.Round(fi)
        Dim rer As Integer = Math.Round(2 * Math.PI * Math.Sqrt(dlina / 9.8))
        Dim interkal As Integer = (90 / rer) * r

        Timer2.Interval = interkal

        If o = 0 Then
            fi = fi - 1
        End If

        If o = 1 Then
            fi = fi + 1
        End If
        Label12.Text = fi
        Dim newx As Double
        newx = x0 + dlina * Math.Sin(fi * Math.PI / 180)
        Dim newy As Double
        newy = y0 + dlina * Math.Cos(fi * Math.PI / 180)
        PictureBox1.Left = newx - PictureBox1.Width * 0.5
        PictureBox1.Top = newy - PictureBox1.Height * 0.5

        Dim dvij As Double = x0 + dlina * Math.Sin(45 * Math.PI / 180)
        Dim shag As Double = Math.Abs(dvij + PictureBox1.Width * 0.5 - x0)
        Dim jkl As Double = Math.Abs(PictureBox1.Location.X + PictureBox1.Width * 0.5 - x0)
        Dim s As Double = Math.Round(Math.Sqrt(9.8 / dlina) * shag - Math.Sqrt(9.8 / dlina) * jkl) - 5
        TextBox5.Text = s
        TextBox1.Text = Math.Round(m * s ^ 2 / 2)
        TextBox6.Text = r / 2 * m
        TextBox7.Text = Math.Round(2 * Math.PI * Math.Sqrt(dlina / 9.8))
        If fi = 45 Then
            Label13.Text = 0
        End If

        If fi = -45 Then
            Label13.Text = 1
        End If

    End Sub

    Private Sub ostanovka_Click(sender As Object, e As EventArgs) Handles ostanovka.Click
        leftt = leftt + 350
        rightt = rightt - 350
        Timer2.Enabled = False
        ostanovka.Enabled = False
        Button1.Enabled = True
        Label15.Visible = False
        Label10.Visible = True
        StopEvents = False
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        leftt = leftt - 350
        rightt = rightt + 350
        Dim gran As Double = PictureBox1.Location.X + PictureBox1.Width * 0.5
        Dim grun As Double = PictureBox1.Location.Y + PictureBox1.Height * 0.5
        Dim dlina As String = Math.Sqrt((gran - x0) ^ 2 + (grun - y0) ^ 2)
        Dim AB As Double = dlina - (y0 + dlina - grun)
        Dim fi As Double = Math.Acos(AB / dlina) * (180 / Math.PI)
        If gran < 445 Then
            fi = 0 - fi
        End If

        If fi >= 45 Then
            fi = 45
            Dim newx As Double
            newx = x0 + dlina * Math.Sin(fi * Math.PI / 180)
            Dim newy As Double
            newy = y0 + dlina * Math.Cos(fi * Math.PI / 180)
            PictureBox1.Left = newx - PictureBox1.Width * 0.5
            PictureBox1.Top = newy - PictureBox1.Height * 0.5
            Label13.Text = 1
        End If

        If fi <= -45 Then
            fi = -45
            Dim newx As Double
            newx = x0 + dlina * Math.Sin(fi * Math.PI / 180)
            Dim newy As Double
            newy = y0 + dlina * Math.Cos(fi * Math.PI / 180)
            PictureBox1.Left = newx - PictureBox1.Width * 0.5
            PictureBox1.Top = newy - PictureBox1.Height * 0.5
            Label13.Text = 0
        End If

        Label12.Text = fi

        Label15.Text = Label10.Text
        Label15.Visible = True
        Label10.Visible = False
        Label10.Text = dlina
        StopEvents = True


        Button1.Enabled = False
        Timer2.Enabled = True
        ostanovka.Enabled = True





    End Sub

End Class
