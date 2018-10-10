Public Class Choose_Port
    Dim Port As Integer
    Private Sub Button3_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button3.MouseHover
        Panel4.Size = New Size(104 + 7, 35) '154,43
    End Sub

    Private Sub Button3_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button3.MouseLeave
        Panel4.Size = New Size(104, 26) '104; 26
    End Sub

    Private Sub Choose_Port_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        On Error Resume Next
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If njrat.Checked = True Then
            sblj.Checked = False
            spybyte.Checked = False
        End If
        If sblj.Checked = True Then
            njrat.Checked = False
            spybyte.Checked = False
        End If
        If spybyte.Checked = True Then
            sblj.Checked = False
            njrat.Checked = False
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If njrat.Checked = False And sblj.Checked = False And spybyte.Checked = False Then
            MsgBox("Error : Port not stated", MsgBoxStyle.Critical)
            SpeakThread("Sir , Port has not been Set , Please Restart me and Choose port number")
            MsgBox("I`m Exiting", MsgBoxStyle.Exclamation)
        ElseIf njrat.Checked = True Or sblj.Checked = True Or spybyte.Checked = True Then
            If njrat.Checked = True Then
                Port = 1177
                Main.MainPort = Port

                Main.portlabel.Text = Port
                Timer1.Stop()
                Me.Close()
            ElseIf sblj.Checked = True Then
                Port = 54148
                Main.MainPort = Port
                Main.portlabel.Text = Port
                Timer1.Stop()
                Me.Close()
            ElseIf spybyte.Checked = True Then
                Port = 6740
                Main.MainPort = Port
                Main.portlabel.Text = Port
                Timer1.Stop()
                Me.Close()

            End If
            Main.StartListen()
            Main.Enabled = True
        End If
    End Sub
End Class