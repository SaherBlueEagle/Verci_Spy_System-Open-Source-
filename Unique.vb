Imports System.Net
Imports System.Text.RegularExpressions
Module Unique
    Public MyIP As IPAddress = GetExternalIP()

    Private Function GetExternalIP() As IPAddress
        Dim lol As WebClient = New WebClient()
        Dim str As String = lol.DownloadString("http://www.ip-adress.com/")
        Dim pattern As String = "<h2>My IP address is: (.+)</h2>"
        Dim matches1 As MatchCollection = Regex.Matches(str, pattern)
        Dim ip As String = matches1(0).ToString
        ip = ip.Remove(0, 21)
        ip = ip.Replace("</h2>", "")
        ip = ip.Replace(" ", "")
        Return IPAddress.Parse(ip)
    End Function
    Public Function ReturnIP() As IPAddress
        Return GetExternalIP()
    End Function
    Public Function ReturnKey() As String
        Dim ipx As String = MyIP.ToString
        Return ipx
    End Function
    
End Module
