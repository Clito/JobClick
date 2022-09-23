<%@ WebHandler Language="VB" Class="MontaBlocoIdentificadorCandidato" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.DBNull

Public Class MontaBlocoIdentificadorCandidato : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim idCadastroCandidato As Integer = Convert.ToInt32(context.Request.QueryString("idCadastroCandidato").ToString())
        Dim content As String = GetBlocoIdentificadorCandidatiFromDB(idCadastroCandidato)
        context.Response.Write(content)
    End Sub
 
    Private Function GetBlocoIdentificadorCandidatiFromDB(id As Integer) As String
        Dim content As String
        
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim prm As SqlParameter
        Dim rs As Boolean = False

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)

        cmd = New SqlCommand("[spMONTADOR_CANDIDATO_BLOCO_IDENTIFICADOR]", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm = New SqlParameter("@idCadastroCandidato", SqlDbType.Int)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@idCadastroCandidato").Value = id
        
        cn.Open()

        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
            
        content = dr("@HTML")

        cn.Close()
              
        Return content
        
    End Function
    
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class