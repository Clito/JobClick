Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.Net.Mail
Imports System.Text.Encoding

Public Class email
    Function EnviarmensagemSQLretorno(sBodyRES As String, sSubject As String, EmailEnviarPara As String) As Boolean
        Dim status As Boolean = False
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim prm As SqlParameter

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH_MSDB").ConnectionString)

        cmd = New SqlCommand("sp_send_dbmail", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm = New SqlParameter("@profile_name", SqlDbType.VarChar, 255)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@profile_name").Value = "Atendimento OportunidadesBH"

        prm = New SqlParameter("@recipients", SqlDbType.VarChar, 255)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@recipients").Value = EmailEnviarPara

        prm = New SqlParameter("@blind_copy_recipients", SqlDbType.VarChar, 255)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@blind_copy_recipients").Value = "atendimento@oportunidadebh.com.br"

        prm = New SqlParameter("@subject", SqlDbType.VarChar, 255)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@subject").Value = sSubject

        prm = New SqlParameter("@body", SqlDbType.VarChar, 8000)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@body").Value = sBodyRES

        prm = New SqlParameter("@body_format", SqlDbType.VarChar, 255)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@body_format").Value = "HTML"

        Try
            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            cn.Close()
            status = True
        Catch ex As Exception

        End Try
        Return status

    End Function
End Class
