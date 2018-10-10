Public Class chat

    Public sock As Integer
    Public Hackername As String
    Public Victimename As String
    'Loca : 11; 38
    'Soza : 509; 208


    Private Sub chat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Timer1.start()
    End Sub
   
    Private Sub chat_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        For Each x As ListViewItem In Main.L1.SelectedItems
            Main.S.Send(sock, "stopchat")
        Next
    End Sub

    Private Sub TextBox2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox2.Text.Length > 0 Then

                Main.S.Send(sock, "chat" & Main.Yy & Hackername & Main.Yy & Victimename & Main.Yy & TextBox2.Text)
             
                TextBox1.Text = TextBox1.Text & Environment.NewLine & Hackername & " said :- " & TextBox2.Text & vbNewLine
                TextBox2.Text = ""
                Sm()
            Else
            End If
        End If
    End Sub



    

    Sub Sm()
        Dim txt As String = TextBox1.Text + vbCr
        Dim ch As Char
        Dim chs() As Char = txt.ToCharArray()
        Dim x As Integer
        For x = 0 To chs.Length - 1
            ch = chs(x)
            If chs(x) = ":" AndAlso (x + 1 < chs.Length) Then
                If (chs(x + 1) = "@" OrElse chs(x + 1) = "?" OrElse chs(x + 1) = "!" OrElse chs(x + 1) = "(" OrElse chs(x + 1) = ")" OrElse chs(x + 1) = "p" OrElse chs(x + 1) = "D") Then
                    Dim i As Image = getImage(ch & chs(x + 1))
                    System.Windows.Forms.Clipboard.SetDataObject(i)
                    x += 1
                    Me.RichTextBox1.Paste()
                Else
                    Me.RichTextBox1.AppendText(ch)
                End If
            Else
                Me.RichTextBox1.AppendText(ch)
            End If
        Next
        RichTextBox1.SelectionStart = RichTextBox1.TextLength
        RichTextBox1.ScrollToCaret()
        TextBox1.Text = ""
    End Sub

    Public Function getImage(ByVal st As String) As Image
        Select Case st
            Case ":@"
                Return ImageList1.Images(0)
            Case ":?"
                Return ImageList1.Images(1)
            Case ":!"
                Return ImageList1.Images(2)
            Case ":D"
                Return ImageList1.Images(3)
            Case ":)"
                Return ImageList1.Images(4)
            Case ":("
                Return ImageList1.Images(5)
            Case ":p"
                Return ImageList1.Images(6)
            Case Else
                Return Nothing
        End Select
    End Function
    Dim CurrH As Double = 0.0

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If CurrH < 380 Then '381
            CurrH += 38.1
            Me.Size = New Size(Me.Width, CurrH)
        Else
            Timer1.Stop()
            SpeakThread("Chat System on")
            Reforge()
            Hackername = InputBox("Enter Your Nickname", "Hacker Name")
            Victimename = InputBox("Enter The Victim's Nickname", "Victim Name")
        End If
    End Sub
    Sub Reforge() '300--> 150 --> 80 --> 40 --> 190
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 190)

        Me.Refresh()
    End Sub
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub buttonClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonClos.Click
        Me.Close()
    End Sub



#End Region
End Class