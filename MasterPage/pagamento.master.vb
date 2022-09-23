
Partial Class MasterPage_pagamento
    Inherits System.Web.UI.MasterPage

    Sub Escreve(ID As Int32, SessionId As String, Ativar As Int32)
        REM ESCREVE UM COOKIE
        Dim cookie As New HttpCookie("SessionId")
        cookie("SessionId_User") = SessionId
        cookie("Ativar") = Ativar
        cookie("ICC") = ID
        cookie("IDP") = 0
        cookie.Expires = DateTime.Now.AddDays(120)
        Response.Cookies.Add(cookie)
    End Sub

    Sub RecuperaidCadastroCandidato()
        REM RECUPERA UM COOKIE
        Dim cookie As HttpCookie = Request.Cookies("SessionId")
        Session("idCadastroCandidato") = Request.Cookies("SessionId")("ICC")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Session("idCadastroCandidato") IsNot Nothing Then
            LabelSESSION.Text = Session("idCadastroCandidato") & " Sessão está ativa!"
        Else
            RecuperaidCadastroCandidato() 'Escreve(Session("idCadastroCandidato"), Request.Cookies("SessionId")("SessionId_User"), Request.Cookies("SessionId")("Ativar"))
            LabelSESSION.Text = Session("idCadastroCandidato") & " Estava encerrada e a sessão está ativa!"
        End If

        Select Case Request.FilePath


            Case "/_pagamento/default.aspx"
                HOME.Attributes.Item("class") = "nocurrent"
                DADOSPESSOAIS.Attributes.Item("class") = "nocurrent"
                DADOSPROFISSIONAIS.Attributes.Item("class") = "nocurrent"
                OPORTUNIDADE.Attributes.Item("class") = "nocurrent"
                PAGAMENTO.Attributes.Item("class") = "current"
                SAIR.Attributes.Item("class") = "nocurrent"


        End Select

    End Sub

End Class

