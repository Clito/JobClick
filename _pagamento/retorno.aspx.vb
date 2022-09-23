Imports UOL.PagSeguro
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.DBNull
Imports System.Xml
Imports System.Collections
Imports System.Configuration
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports System.Data.SqlClient.SqlDataReader
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Net.Mail
Imports System.Text.Encoding

Partial Class _pagamento_retorno

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.RetornoPagSeguroPAGAMENTO.UrlNPI = Session("PS_UrlNPI")

        If Request.QueryString("transaction_id") <> "" Then

            REM ** *************************************************************************************************
            Dim URLXMLNot As String = Session("PS_url_transactions") & Request.QueryString("transaction_id") & "?email=" & Session("PS_email_vendedor") & "&token=" & Session("PS_token")
            Dim readerNot As New XmlTextReader(URLXMLNot)
            REM ** *************************************************************************************************

            Dim cn As SqlConnection
            Dim cmd As SqlCommand
            Dim prm As SqlParameter

            cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)

            cmd = New SqlCommand("spNOTIFICACAO_PAGSEGURO", cn)
            cmd.CommandType = CommandType.StoredProcedure

            prm = New SqlParameter("@codeNotificacao", SqlDbType.VarChar, 255)
            prm.Direction = ParameterDirection.Input
            cmd.Parameters.Add(prm)
            cmd.Parameters("@codeNotificacao").Value = Request.QueryString("transaction_id")

            prm = New SqlParameter("@Notificacao", SqlDbType.Text)
            prm.Direction = ParameterDirection.Input
            cmd.Parameters.Add(prm)
            cmd.Parameters("@Notificacao").Value = readerNot

            Try
                cn.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    LabelNOME.Text = dr("nome")
                    LabelPRODUTO.Text = dr("produto")
                End If
                cn.Close()

            Catch ex As Exception

            End Try

        End If

    End Sub


    


End Class
