<%@ WebHandler Language="VB" Class="imagemEmpresa" %>
Imports System
Imports System.Web
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader
Imports System.Data.SqlClient.SqlDataAdapter
Imports System.DBNull

Public Class imagemEmpresa : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim id As Integer = Convert.ToInt32(context.Request.QueryString("id").ToString())
        Dim content As [Byte]() = GetImagemEmpresaFromDB(id)
        context.Response.BinaryWrite(content)
    End Sub
 
    Private Function GetImagemEmpresaFromDB(ByVal id As Integer) As Byte()
        Dim content As [Byte]()
        
        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim prm As SqlParameter
        Dim rs As Boolean = False

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)

        cmd = New SqlCommand("[spRECUPERA_LOGO_EMPRESA]", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm = New SqlParameter("@idEmpresa", SqlDbType.Int)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@idEmpresa").Value = id
        
        cn.Open()

        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
            
        content = dr("foto")

        cn.Close()
        
        Return content
    End Function
    
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class