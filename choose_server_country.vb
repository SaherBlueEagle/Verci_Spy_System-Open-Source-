Public Class choose_server_country
    Public Chosen As String = ""
    Private Sub choose_server_country_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
        On Error Resume Next

        For i As Integer = 0 To RichTextBox1.Lines.Length
            Dim CurrentCountry As String = RichTextBox1.Lines(i).Replace("""", "")
            ListView1.Items.Add(CurrentCountry, GetCountryNumber(UCase(CurrentCountry)))
            i += 1
        Next
     
    End Sub

  
    Private Sub Button3_MouseHover(sender As System.Object, e As System.EventArgs) Handles Button3.MouseHover
        Panel4.Size = New Size(154 + 7, 50) '154,43
    End Sub

    Private Sub Button3_MouseLeave(sender As System.Object, e As System.EventArgs) Handles Button3.MouseLeave
        Panel4.Size = New Size(154, 43) '154,43
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If ListView1.SelectedItems.Count = 0 Then
            MsgBox("I will Choose by default <United States>")
            Chosen = "United States"
            Main.country = Chosen

            Main.ratcountry = Chosen
            Main.countrylabel.Text = Chosen
            Choose_Port.Show()
            Me.Close()
        ElseIf ListView1.SelectedItems.Count > 0 Then
            Chosen = ListView1.SelectedItems(0).Text
            Main.country = Chosen

            Main.ratcountry = Chosen
            Main.countrylabel.Text = Chosen
            Choose_Port.Show()
            Me.Close()
        End If

    End Sub

    
End Class