<%@ Application Language="VB" %>
<%@ Import Namespace = "System.Diagnostics" %>
<%@ Import Namespace = "System.Web.SessionState" %>
<%@ Import Namespace = "System.Data" %>
<%@ Import Namespace = "System.Data.SqlClient" %>
<%@ Import Namespace = "System.Data.SqlClient.SqlDataReader" %>
<%@ Import Namespace = "System.Web.SessionState.HttpSessionState" %>
<%@ Import Namespace = "System.Web.HttpCookie" %>
<%@ Import Namespace = "System.DBNull" %>
<%@ Import Namespace = "System.Security.Principal" %>
<%@ Import Namespace = "System.Web.Security" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
       
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
       
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Dim err As String = "Erro na página: " & Request.Url.ToString() & ". Mensagem de erro: " & objErr.Message.ToString()
        ErrHandler.WriteError(err)
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        
        Session("ticket") = Session.SessionID
        REM ** ************************************************************************************************
        REM ** RECUPERA TODAS AS VARIÁVEIS PARA A INTEGRAÇÃO COM O PAGSEGURO
        REM ** ************************************************************************************************
        REM [PS_url_transactions]
        REM [PS_url_notifications]
        REM [PS_token]
        REM [PS_email_vendedor]
        REM ** ************************************************************************************************
        
        
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim prm As SqlParameter

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)

        cmd = New SqlCommand("spSETUP", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm = New SqlParameter("@idsetup", SqlDbType.Int)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@idsetup").Value = 1


        Try
            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                dr.Read()
                Session("PS_url_transactions") = dr("PS_url_transactions")
                Session("PS_url_notifications") = dr("PS_url_notifications")
                Session("PS_token") = dr("PS_token")
                Session("PS_email_vendedor") = dr("PS_email_vendedor")
                Session("PS_UrlNPI") = dr("PS_UrlNPI")
            End If
            cn.Close()

        Catch ex As Exception

        End Try
        
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
       
</script>