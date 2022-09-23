
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim cookie As HttpCookie = Request.Cookies("SessionId")
        If cookie Is Nothing Then
            Escreve(Session("ticket"), "0")
        Else
            Recupera()
        End If

    End Sub

    Sub Apagar()
        Dim aCookie As HttpCookie
        Dim i As Integer
        Dim cookieName As String
        Dim limit As Integer = Request.Cookies.Count - 1
        For i = 0 To limit
            cookieName = Request.Cookies(i).Name
            aCookie = New HttpCookie(cookieName)
            aCookie.Expires = DateTime.Now.AddDays(-1)
            Response.Cookies.Add(aCookie)
        Next
    End Sub

    Sub Escreve(SessionId As String, Ativar As String)
        REM ESCREVE UM COOKIE
        Dim cookie As New HttpCookie("SessionId")
        cookie("SessionId_User") = SessionId
        cookie("Ativar") = Ativar
        cookie.Expires = DateTime.Now.AddDays(120)
        Response.Cookies.Add(cookie)
        Recupera()
    End Sub

    Sub Recupera()
        REM RECUPERA UM COOKIE
        Dim cookie As HttpCookie = Request.Cookies("SessionId")
        Session("SessionId") = Request.Cookies("SessionId")("SessionId_User")
        Session("Ativar") = Request.Cookies("SessionId")("Ativar")
    End Sub

End Class
