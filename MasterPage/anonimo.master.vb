Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader
Imports System.Data.SqlClient.SqlDataAdapter

Partial Class MasterPage_anonimo
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim cookie As HttpCookie = Request.Cookies("SessionId")
        If cookie Is Nothing Then
            REM ** NÃO FAZ NADA **
        Else
            AUTOLOGIN()
        End If

    End Sub

    Sub AUTOLOGIN()

        REM RECUPERA UM COOKIE
        Dim cookie As HttpCookie = Request.Cookies("SessionId")
        Session("SessionId") = Request.Cookies("SessionId")("SessionId_User")
        Session("Ativar") = Request.Cookies("SessionId")("Ativar")

        REM VERIFICA SE A SESSION EXISTE
        If Session("SessionId") IsNot Nothing Then


            Dim cn As SqlConnection
            Dim cmd As SqlCommand
            Dim prm As SqlParameter

            REM ** UTILIZADO NA LÓGICA DE LOGIN
            REM ** ****************************

            Dim tipousuario As String = "0"
            Dim ID As Int32 = 0
            Dim idDepartamento As Int32 = 0

            REM ** ****************************

            cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)

            cmd = New SqlCommand("spACESSO_COOKIE", cn)
            cmd.CommandType = CommandType.StoredProcedure

            prm = New SqlParameter("@cookie", SqlDbType.VarChar, 255)
            prm.Direction = ParameterDirection.Input
            cmd.Parameters.Add(prm)
            cmd.Parameters("@cookie").Value = Session("SessionId")

            cn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows() Then
                dr.Read()
                tipousuario = dr("tipousuario")
                ID = dr("ID")
                idDepartamento = dr("idDepartamento")
            End If

            cn.Close()

            REM ** APLICA A LÓGIA DO SITE
            REM ** **********************

            Select Case tipousuario

                Case "Candidato"
                    FormsAuthentication.SetAuthCookie(tipousuario, False)
                    Session("idCadastroCandidato") = ID
                    Response.Redirect("_candidato")
                Case "Empresa"
                    FormsAuthentication.SetAuthCookie(tipousuario, False)
                    Session("idDepartamento") = idDepartamento
                    Response.Redirect("_empresa")
                Case "Departamento"
                    FormsAuthentication.SetAuthCookie(tipousuario, False)
                    Session("idDepartamento") = idDepartamento
                    Response.Redirect("_departamento")

            End Select

        End If

    End Sub

End Class

