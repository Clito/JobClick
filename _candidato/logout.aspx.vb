
Partial Class _candidato_logout
    Inherits System.Web.UI.Page
    Protected Sub LinkButtonENCERRAR_Click(sender As Object, e As EventArgs) Handles LinkButtonENCERRAR.Click

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

        FormsAuthentication.SignOut()
        Session.Abandon()

        Session.Clear()
        FormsAuthentication.SignOut()

        Response.Redirect("/default.aspx")

    End Sub

    Protected Sub LinkButtonVoltar_Click(sender As Object, e As EventArgs) Handles LinkButtonVoltar.Click
        Response.Redirect("/default.aspx")
    End Sub

    Protected Sub LinkButtonFECHAR_Click(sender As Object, e As EventArgs) Handles LinkButtonFECHAR.Click
        Response.Redirect("/default.aspx")
    End Sub

End Class
