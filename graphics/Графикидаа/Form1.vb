Public Class Form1
    Dim Graph1 As Graphics
    Dim Pen1 As New Pen(Color.LightPink, 2)
    Dim Pen2 As New Pen(Color.HotPink, 2)
    Dim Pen3 As New Pen(Color.Lavender, 2)
    Dim Pen4 As New Pen(Color.Silver, 2)
    Dim X, Y As Single
    Dim Xs, Ys As Single
    Dim Xk, Yk As Single
    Dim faza, smesh, ampl, stepen, chast As Single
    Dim brush1 As New SolidBrush(Color.HotPink)
    Dim font1 As New Font("Times New Roman", 10)
    Dim s = 0.1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Graph1 = Me.PictureBox1.CreateGraphics()

        For Me.X = 0 To PictureBox1.Width Step 30
            Graph1.DrawLine(Pen4, X, 0, X, PictureBox1.Width)
        Next X

        For Me.Y = 0 To PictureBox1.Height Step 30
            Graph1.DrawLine(Pen4, 0, Y, PictureBox1.Width, Y)
        Next Y

        Graph1.DrawLine(Pen2, -600, 180, 600, 180)
        Graph1.DrawLine(Pen2, 300, -600, 300, 600)
        For Me.X = -600 To 600 Step 60
            Graph1.DrawLine(Pen2, X, 175, X, 185)
        Next X

        For Me.Y = -600 To 600 Step 60
            Graph1.DrawLine(Pen2, 295, Y, 305, Y)
        Next Y

        For Me.X = -300 To 300 Step 60
            Graph1.DrawString(X / 60, font1, brush1, X + 300, 180)
        Next X

        For Me.Y = -180 To 180 Step 60
            Graph1.DrawString(Y / 60, font1, brush1, 300, 180 - Y)
        Next Y
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Graph1 = Me.PictureBox1.CreateGraphics()
        Graph1.Clear(Color.Lavender)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Graph1 = Me.PictureBox1.CreateGraphics()
        Graph1.TranslateTransform(300, 180)
        Xs = ComboBox1.SelectedItem
        Ys = ComboBox4.SelectedItem
        Xk = ComboBox2.SelectedItem
        Yk = ComboBox3.SelectedItem
        faza = ComboBox7.SelectedItem
        smesh = ComboBox8.SelectedItem
        ampl = ComboBox6.SelectedItem
        stepen = ComboBox9.SelectedItem
        chast = ComboBox10.SelectedItem
        If ComboBox5.Text = "Синусоида" Then
             For Me.X = ((Xs / 2 * 120 - faza * 10)) To ((Xk / 2 * 120 + faza * 10)) Step s
                Y = -Math.Sin(chast * X * 3.14 / 120)
                If Y > (Ys) And Y < (Yk) Then
                    Graph1.DrawEllipse(Pen1, (X + faza * 10), Y * ampl * 10 + smesh * 5, 1, 1)

                End If
            Next Me.X
        ElseIf ComboBox5.Text = "Тангенсоида" Then
            For Me.X = (Xs / 2 * 120) To (Xk / 2 * 120) Step s
                Y = Math.Tan(X * 3.14 / 120)
                If Y > (Ys) And Y < (Yk) Then
                    Graph1.DrawEllipse(Pen1, X, Y * 60, 1, 3)
                End If
            Next X
        ElseIf ComboBox5.Text = "Степенная" Then
            For Me.X = (Xs / 2 * 120) To (Xk / 2 * 120) Step s
                Y = -(X ^ (stepen) / (60 ^ (stepen)))
                If Y > (Ys) And Y < (Yk) Then
                    Graph1.DrawEllipse(Pen1, X, Y * 60, 1, 1)
                End If
            Next X
        End If

    End Sub

  
End Class
