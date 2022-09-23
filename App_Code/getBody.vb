Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Net.Mail
Imports System.Text.Encoding

Public Class getBody
    Function applyBody(idsetup As Integer, ASSUNTO As String, REFERENTE As String, MENSAGEM As String) As String
        REM ** *************************************************************************
        REM ** CAMPOS PARA SEREM ALTERADOS ...
        REM ** #ASSUNTO# | #REFERENTE# | #MENSAGEM#
        REM ** *************************************************************************

        Dim body As String = ""
        Dim bodyTEMP As String = ""

        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim prm As SqlParameter

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)

        cmd = New SqlCommand("spCORPOEMAIL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm = New SqlParameter("@idsetup", SqlDbType.Int)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)

        cmd.Parameters("@idsetup").Value = idsetup

        Try

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            bodyTEMP = dr("body")

            REM ** **************************************************************************************
            REM ** SUBSTITUI OS CAMPOS PELOS PARÂMETROS

            body = Replace(Replace(Replace(bodyTEMP, "#ASSUNTO#", ASSUNTO), "#REFERENTE#", REFERENTE), "#MENSAGEM#", MENSAGEM)

            REM ** **************************************************************************************

            dr.Close()
            cn.Close()

        Catch ex As Exception

        End Try


        Return body
    End Function
End Class
