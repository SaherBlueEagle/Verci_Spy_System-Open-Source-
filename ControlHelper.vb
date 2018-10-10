Option Explicit On
Module ControlHelper
    ' Win32 APIs.
    Private Declare Function GetWindowLong _
     Lib "user32" Alias "GetWindowLongA" _
     (ByVal hWnd As Long, _
     ByVal nIndex As Long) As Long
    Private Declare Function SetWindowLong _
     Lib "user32" Alias "SetWindowLongA" _
     (ByVal hWnd As Long, ByVal nIndex As Long, _
     ByVal dwNewLong As Long) As Long
    Private Declare Function SetWindowPos Lib "user32" _
     (ByVal hWnd As Long, ByVal hWndInsertAfter As _
     Long, ByVal X As Long, ByVal Y As Long, _
     ByVal cx As Long, ByVal cy As Long, _
     ByVal wFlags As Long) As Long

    ' Style bits.
    Private Const GWL_EXSTYLE As Long = (-20)
    Private Const WS_EX_TRANSPARENT As Long = &H20

    ' Force total redraw that shows new styles.
    Private Const SWP_FRAMECHANGED = &H20
    Private Const SWP_NOMOVE = &H2
    Private Const SWP_NOZORDER = &H4
    Private Const SWP_NOSIZE = &H1

    Public Function Transparent(ByVal hWnd As Long, _
 Optional ByVal Value As Boolean = True) As _
 Boolean

        Dim nStyle As Long
        Const swpFlags As Long = _
         SWP_FRAMECHANGED Or SWP_NOMOVE Or _
         SWP_NOZORDER Or SWP_NOSIZE

        ' Get current style bits.
        nStyle = GetWindowLong(hWnd, GWL_EXSTYLE)
        ' Set new bits as desired.
        If Value Then
            nStyle = nStyle Or WS_EX_TRANSPARENT
        Else
            nStyle = nStyle And Not WS_EX_TRANSPARENT
        End If
        Call SetWindowLong(hWnd, GWL_EXSTYLE, nStyle)
        ' Force redraw using new bits.
        SetWindowPos(hWnd, 0, 0, 0, 0, 0, swpFlags)
        ' Make sure new style took.
        Transparent = _
         (GetWindowLong(hWnd, GWL_EXSTYLE) = nStyle)
    End Function


End Module