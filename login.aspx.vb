Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader
Imports System.Data.SqlClient.SqlDataAdapter

Partial Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Ativar") = 1 Then
                CheckBoxMANTERLOGADO.Checked = True
            Else
                CheckBoxMANTERLOGADO.Checked = False
            End If
        End If

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

    Protected Sub ButtonLOGIN_Click(sender As Object, e As EventArgs) Handles ButtonLOGIN.Click

        If TextBoxEmail.Text <> "" Or TextBoxSenha.Text <> "" Then

            Recupera()

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

            cmd = New SqlCommand("spACESSO", cn)
            cmd.CommandType = CommandType.StoredProcedure

            prm = New SqlParameter("@email", SqlDbType.VarChar, 255)
            prm.Direction = ParameterDirection.Input
            cmd.Parameters.Add(prm)
            cmd.Parameters("@email").Value = TextBoxEmail.Text

            prm = New SqlParameter("@senha", SqlDbType.VarChar, 180)
            prm.Direction = ParameterDirection.Input
            cmd.Parameters.Add(prm)
            cmd.Parameters("@senha").Value = TextBoxSenha.Text

            cn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows() Then
                dr.Read()
                tipousuario = dr("tipousuario") REM ** UTILIZADO PARA CONHECER QUEM É O USUÁRIO
                ID = dr("ID") REM ** O MESMO QUE (idCadastroCandidato)
                idDepartamento = dr("idDepartamento") REM ** DEPENDENDO DO (tipousuario) IDENTIFICA DEPARTAMENTO OU ADMINISTRADOR
            End If

            cn.Close()

            REM ** APLICA A LÓGIA DO SITE
            REM ** **********************

            Select Case tipousuario

                Case "Candidato"
                    FormsAuthentication.SetAuthCookie(tipousuario, False)
                    Session("idCadastroCandidato") = ID
                    If CheckBoxMANTERLOGADO.Checked = True Then
                        REM ** ***************************
                        REM ** REGISTRA O COOKIE DO EMAIL
                        REM ** ***************************
                        ATIVACOOKIE(ID, tipousuario)
                        Escreve(ID, idDepartamento, Session("SessionId"), "1")
                    Else
                        Escreve(ID, idDepartamento, Session("SessionId"), "0")
                        Apagar(ID, tipousuario)
                    End If
                    Response.Redirect("_candidato")
                Case "Empresa"
                    FormsAuthentication.SetAuthCookie(tipousuario, False)
                    Session("idDepartamento") = idDepartamento
                    If CheckBoxMANTERLOGADO.Checked = True Then
                        REM ** ***************************
                        REM ** REGISTRA O COOKIE DO EMAIL
                        REM ** ***************************
                        ATIVACOOKIE(idDepartamento, tipousuario)
                        Escreve(ID, idDepartamento, Session("SessionId"), "1")
                    Else
                        Escreve(ID, idDepartamento, Session("SessionId"), "0")
                        Apagar(idDepartamento, tipousuario)
                    End If
                    Response.Redirect("_empresa")
                Case "Departamento"
                    FormsAuthentication.SetAuthCookie(tipousuario, False)
                    Session("idDepartamento") = idDepartamento
                    If CheckBoxMANTERLOGADO.Checked = True Then
                        REM ** ***************************
                        REM ** REGISTRA O COOKIE DO EMAIL
                        REM ** ***************************
                        ATIVACOOKIE(idDepartamento, tipousuario)
                        Escreve(ID, idDepartamento, Session("SessionId"), "1")
                    Else
                        Escreve(ID, idDepartamento, Session("SessionId"), "0")
                        Apagar(idDepartamento, tipousuario)
                    End If
                    Response.Redirect("_departamento")
                Case Else
                    Session("idDepartamento") = 0
                    Session("idCadastroCandidato") = 0
                    PanelAVISO.Visible = True
                    PanelFORMULARIO.Visible = False
                    LabelPanelAviso.Text = "Aviso"
                    LabelAviso.Text = "Usuário não foi localizado!"
            End Select
        Else
            PanelAVISO.Visible = True
            PanelFORMULARIO.Visible = False
            LabelPanelAviso.Text = "Aviso"
            LabelAviso.Text = "Usuário não foi localizado!<br>Você deve habilitar seu navegador para executar [javascript] para obter todos os benefícios do sistema."
        End If

    End Sub

    Protected Sub LinkButtonFECHAR_Click(sender As Object, e As EventArgs) Handles LinkButtonFECHAR.Click
        PanelAVISO.Visible = False
        PanelFORMULARIO.Visible = True
    End Sub

    Protected Sub ButtonLEMBRARSENHA_Click(sender As Object, e As EventArgs) Handles ButtonLEMBRARSENHA.Click

        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim prm As SqlParameter

        REM ** UTILIZADO NA LÓGICA DE LOGIN
        REM ** ****************************

        Dim tipousuario As String = "0"
        Dim nome As String = "0"
        Dim email As String = "0"
        Dim senha As String = "0"
        Dim ID As Int32 = 0
        Dim idDepartamento As Int32 = 0

        REM ** ****************************

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)

        cmd = New SqlCommand("spACESSO_LEMBRAR_SENHA", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm = New SqlParameter("@email", SqlDbType.VarChar, 255)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@email").Value = TextBoxLEMBRARSENHA.Text

        cn.Open()

        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows() Then
            dr.Read()
            tipousuario = dr("tipousuario")
            ID = dr("ID")
            idDepartamento = dr("idDepartamento")
            nome = dr("nome")
            email = dr("email")
            senha = dr("senha")
        End If

        cn.Close()

        REM ** APLICA A LÓGIA DO SITE
        REM ** **********************

        Select Case tipousuario

            Case "Candidato"
                PanelAVISO.Visible = True
                PanelFORMULARIO.Visible = False
                LabelPanelAviso.Text = "E-mail enviado"
                LabelAviso.Text = nome & ",<br>Um e-mail foi enviado para sua caixa postal eletrônica [" & email & "]."
            Case "Empresa"
                PanelAVISO.Visible = True
                PanelFORMULARIO.Visible = False
                LabelPanelAviso.Text = "E-mail enviado"
                LabelAviso.Text = nome & ",<br>Um e-mail foi enviado para sua caixa postal eletrônica [" & email & "]."
            Case "Departamento"
                PanelAVISO.Visible = True
                PanelFORMULARIO.Visible = False
                LabelPanelAviso.Text = "E-mail enviado"
                LabelAviso.Text = nome & ",<br>Um e-mail foi enviado para sua caixa postal eletrônica [" & email & "]."
            Case Else
                PanelAVISO.Visible = True
                PanelFORMULARIO.Visible = False
                LabelPanelAviso.Text = "Lamentamos muito mas ..."
                LabelAviso.Text = "Este e-mail não está cadastrado, entre em contato com atendimento@oportunidadesbh.com.br informando o ocorrido."
        End Select

        
    End Sub

    Sub ATIVACOOKIE(ID As Int32, tipousuario As String)

        If Session("SessionId") IsNot Nothing Then

            Dim cn As SqlConnection
            Dim cmd As SqlCommand
            Dim prm As SqlParameter

            REM ** GRAVA COOKIE NA BASE
            REM ** ****************************

            cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)


            cmd = New SqlCommand("spACESSO_SESSIONID_ATIVA", cn)
            cmd.CommandType = CommandType.StoredProcedure

            prm = New SqlParameter("@SessionId", SqlDbType.VarChar, 255)
            prm.Direction = ParameterDirection.Input
            cmd.Parameters.Add(prm)
            cmd.Parameters("@SessionId").Value = Session("SessionId")

            prm = New SqlParameter("@Id", SqlDbType.Int)
            prm.Direction = ParameterDirection.Input
            cmd.Parameters.Add(prm)
            cmd.Parameters("@Id").Value = ID

            prm = New SqlParameter("@tipousuario", SqlDbType.VarChar, 25)
            prm.Direction = ParameterDirection.Input
            cmd.Parameters.Add(prm)
            cmd.Parameters("@tipousuario").Value = tipousuario

            cn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()

            cn.Close()

        End If

    End Sub

    Sub Apagar(ID As Int32, tipousuario As String)

        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim prm As SqlParameter

        REM ** GRAVA COOKIE NA BASE
        REM ** ****************************

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)


        REM ** ***************************
        REM ** REGISTRA O COOKIE DO EMAIL
        REM ** ***************************
        cmd = New SqlCommand("spACESSO_SESSIONID_ATIVA", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm = New SqlParameter("@SessionId", SqlDbType.VarChar, 255)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@SessionId").Value = DBNull.Value

        prm = New SqlParameter("@Id", SqlDbType.Int)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@Id").Value = ID

        prm = New SqlParameter("@tipousuario", SqlDbType.VarChar, 25)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@tipousuario").Value = tipousuario

        cn.Open()

        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()

        cn.Close()

    End Sub

    Sub Escreve(ICC As Int32, IDP As Int32, SessionId As String, Ativar As String)
        REM ESCREVE UM COOKIE
        Dim cookie As New HttpCookie("SessionId")
        cookie("SessionId_User") = SessionId
        cookie("Ativar") = Ativar
        cookie("ICC") = ICC
        cookie("IDP") = IDP
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

    Protected Sub ButtonESQUECI_Click(sender As Object, e As EventArgs) Handles ButtonESQUECI.Click
        LabelPanelAviso.Text = "Esqueceu sua senha?"
        LabelAviso.Text = "Informe seu e-mail que enviaremos a senha para você."
        PanelAVISO.Visible = True
        PanelFORMULARIO.Visible = False
    End Sub
End Class
