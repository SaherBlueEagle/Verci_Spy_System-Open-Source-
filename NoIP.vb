Imports System.Text

Public Class NoIP
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean



    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown, Label2.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp, Label2.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseMove, Label2.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub





#End Region

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try

        Catch ex As Exception

        End Try
        Dim wc = New Net.WebClient()
        Dim utf8 = New UTF8Encoding




        Dim page As String = utf8.GetString(wc.DownloadData("http://dynupdate.no-ip.com/dns?username=" & TextBox1.Text & "&password=" & TextBox2.Text & "&hostname=" & TextBox3.Text))
        '   MsgBox(status(1))
        Dim texter() As String = page.Split(":")
        RichTextBox1.Text = texter(1)
        If texter(1).Contains("0") Then

            RichTextBox2.AppendText("Success - IP address is current, no update performed")
            Label6.ForeColor = Color.Lime
            Label6.Text = "Updated Successfully"
        End If
        If texter(1).Contains("1") Then
            RichTextBox2.AppendText("Success - DNS hostname update successfully")
            Label6.ForeColor = Color.Lime
            Label6.Text = "Updated Successfully"

        End If
        If texter(1).Contains("2") Then

            RichTextBox2.AppendText("Error - Hostname supplied does not exist")
            Label6.ForeColor = Color.Red
            Label6.Text = " Error Not Updated"
        End If
        If texter(1).Contains("3") Then
            RichTextBox2.AppendText("Error - Invalid username")
        End If
        If texter(1).Contains("4") Then
            RichTextBox2.AppendText("Error - Invalid password")
        End If
        If texter(1).Contains("5") Then
            RichTextBox2.AppendText("Error - Too many updates sent. Updates are blocked   until 1 hour passes since last status of 5 returned.")
            Label6.ForeColor = Color.Lime
            Label6.Text = "Too many updates sent"
        End If
        If texter(1).Contains("6") Then
            RichTextBox2.AppendText("Error - Account disabled due to violation of No-IP   terms of service. Our terms of service can be viewed at   http://www.no-ip.com/legal/tos")
        End If
        If texter(1).Contains("7") Then
            RichTextBox2.AppendText("Error - Invalid IP. Invalid IP submitted is   improperly formated, is a private LAN RFC 1918 address, or an abuse   blacklisted address.")
        End If
        If texter(1).Contains("8") Then
            RichTextBox2.AppendText("Error - Disabled / Locked hostname")
        End If
        If texter(1).Contains("9") Then
            RichTextBox2.AppendText("Host updated is configured as a web redirect and no update was performed.")
            Label6.ForeColor = Color.Lime
            Label6.Text = "Host updated , no update was performed"

        End If
        If texter(1).Contains("10") Then
            RichTextBox2.AppendText("Error - Group supplied does not exist")
        End If
        If texter(1).Contains("11") Then
            RichTextBox2.AppendText("Success - DNS group update is successful")
            Label6.ForeColor = Color.Lime
            Label6.Text = "Updated Successfully"

        End If
        If texter(1).Contains("12") Then
            RichTextBox2.AppendText("Success - DNS group is current, no update performed.")
            Label6.ForeColor = Color.Lime
            Label6.Text = "Updated Successfully"

        End If
        If texter(1).Contains("13") Then
            RichTextBox2.AppendText("Error - Update client support not available for supplied hostname or group")

        End If
        If texter(1).Contains("14") Then
            RichTextBox2.AppendText("Error - Hostname supplied does not have offline   settings configured. Returned if sending offline=YES on a host that  does  not have any offline actions configured.")
        End If
        If texter(1).Contains("99") Then
            RichTextBox2.AppendText("Error - Client disabled. Client should exit and not   perform any more updates without user intervention.")
        End If
        If texter(1).Contains("100") Then
            RichTextBox2.AppendText("Error - User input error usually returned if missing required request parameters")
        End If
    End Sub
    '432; 304
    'H 304
    Dim Curr As Double = 0.0

    Private Sub NoIP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Size.Height - 304)
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Curr < 303 Then
            Curr += 30.4
            Me.Size = New Size(Me.Width, Curr)

        Else
            SpeakThread("Dns Handler has been activated sir")
            Timer1.Stop()
        End If
    End Sub
End Class