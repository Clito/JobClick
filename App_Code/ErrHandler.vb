Imports Microsoft.VisualBasic
Imports System.Text.Encoding
Imports System.IO
Imports System.Net.Mail
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader
Imports System.Data.SqlClient.SqlDataAdapter

Public Class ErrHandler

    Public Shared Sub WriteError(ByVal errorMessage As String)

        Try
            Dim path As String = "~/_erro/" & DateTime.Today.ToString("dd-mm-yyyy") & ".txt"
            If (Not File.Exists(System.Web.HttpContext.Current.Server.MapPath(path))) Then
                File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close()
            End If
            Using w As StreamWriter = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path))
                w.WriteLine(Constants.vbCrLf & "Log Entry : ")
                w.WriteLine("{0}", DateTime.Now.ToString)
                Dim err As String = "Error in: " & System.Web.HttpContext.Current.Request.Url.ToString() & ". Error Message:" & errorMessage
                w.WriteLine(err)
                w.WriteLine("__________________________")
                w.Flush()
                w.Close()
            End Using
        Catch ex As Exception
            WriteError(ex.Message)
        End Try

        GetErrorSys(errorMessage)

    End Sub

    Public Shared Sub GetErrorSys(dserro As String)

        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim prm As SqlParameter

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)

        cmd = New SqlCommand("spErro", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm = New SqlParameter("@dserro", SqlDbType.Text)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)

        cmd.Parameters("@dserro").Value = dserro

        Try

            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            dr.Close()
            cn.Close()

        Catch ex As Exception

        End Try

    End Sub

End Class
