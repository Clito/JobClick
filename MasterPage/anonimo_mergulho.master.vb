
Partial Class MasterPage_anonimo_mergulho
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Select Case Request.FilePath

            Case "/Default.aspx"
                HOME.Attributes.Item("class") = "current"
                SERVICO.Attributes.Item("class") = "nocurrent"
                CANDIDATO.Attributes.Item("class") = "nocurrent"
                EMPRESA.Attributes.Item("class") = "nocurrent"
                OPORTUNIDADE.Attributes.Item("class") = "nocurrent"
                ACESSO.Attributes.Item("class") = "nocurrent"
            Case "/servico.aspx"
                HOME.Attributes.Item("class") = "nocurrent"
                SERVICO.Attributes.Item("class") = "current"
                CANDIDATO.Attributes.Item("class") = "nocurrent"
                EMPRESA.Attributes.Item("class") = "nocurrent"
                OPORTUNIDADE.Attributes.Item("class") = "nocurrent"
                ACESSO.Attributes.Item("class") = "nocurrent"
            Case "/regulamento.aspx"
                HOME.Attributes.Item("class") = "nocurrent"
                SERVICO.Attributes.Item("class") = "nocurrent"
                CANDIDATO.Attributes.Item("class") = "nocurrent"
                EMPRESA.Attributes.Item("class") = "nocurrent"
                OPORTUNIDADE.Attributes.Item("class") = "nocurrent"
                ACESSO.Attributes.Item("class") = "nocurrent"
            Case "/cadastrocandidato.aspx"
                HOME.Attributes.Item("class") = "nocurrent"
                SERVICO.Attributes.Item("class") = "nocurrent"
                CANDIDATO.Attributes.Item("class") = "current"
                EMPRESA.Attributes.Item("class") = "nocurrent"
                OPORTUNIDADE.Attributes.Item("class") = "nocurrent"
                ACESSO.Attributes.Item("class") = "nocurrent"
            Case "/cadastroempresa.aspx"
                HOME.Attributes.Item("class") = "nocurrent"
                SERVICO.Attributes.Item("class") = "nocurrent"
                CANDIDATO.Attributes.Item("class") = "nocurrent"
                EMPRESA.Attributes.Item("class") = "current"
                OPORTUNIDADE.Attributes.Item("class") = "nocurrent"
                ACESSO.Attributes.Item("class") = "nocurrent"
            Case "/oportunidade.aspx"
                HOME.Attributes.Item("class") = "nocurrent"
                SERVICO.Attributes.Item("class") = "nocurrent"
                CANDIDATO.Attributes.Item("class") = "nocurrent"
                EMPRESA.Attributes.Item("class") = "nocurrent"
                OPORTUNIDADE.Attributes.Item("class") = "current"
                ACESSO.Attributes.Item("class") = "nocurrent"
            Case "/login.aspx"
                HOME.Attributes.Item("class") = "nocurrent"
                SERVICO.Attributes.Item("class") = "nocurrent"
                CANDIDATO.Attributes.Item("class") = "nocurrent"
                EMPRESA.Attributes.Item("class") = "nocurrent"
                OPORTUNIDADE.Attributes.Item("class") = "nocurrent"
                ACESSO.Attributes.Item("class") = "current"
            Case Else
                HOME.Attributes.Item("class") = "current"
                SERVICO.Attributes.Item("class") = "nocurrent"
                CANDIDATO.Attributes.Item("class") = "nocurrent"
                EMPRESA.Attributes.Item("class") = "nocurrent"
                OPORTUNIDADE.Attributes.Item("class") = "nocurrent"
                ACESSO.Attributes.Item("class") = "nocurrent"
        End Select

    End Sub
End Class

