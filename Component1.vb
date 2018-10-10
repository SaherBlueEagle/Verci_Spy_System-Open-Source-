Class TransparentControl
    Inherits Control
    Public Sub New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        MyBase.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        MyBase.SetStyle(ControlStyles.ResizeRedraw, True)
        MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)

    End Sub
End Class
Class TransparentTextBox
    Inherits RichTextBox
    Public Sub New()
        MyBase.ScrollBars = RichTextBoxScrollBars.Both
    End Sub
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20
            Return cp
        End Get
    End Property
    Protected Overloads Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        MyBase.Parent.Refresh()
    End Sub
End Class