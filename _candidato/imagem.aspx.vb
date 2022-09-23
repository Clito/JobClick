Imports imagem
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader
Imports System.Data.SqlClient.SqlDataAdapter


Partial Class _candidato_imagem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load



    End Sub

    Protected Sub ButtonAPROVADO_Click(sender As Object, e As EventArgs) Handles ButtonAPROVADO.Click

        Dim DeletaImagem As New imagem


        Dim ImagemDB As [Byte]()
        ImagemDB = File.ReadAllBytes(Server.MapPath("/") & "_candidato\" & cropOutputRunatServer.Value)


        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim prm As SqlParameter

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)

        cmd = New SqlCommand("[spATUALIZA_FOTO_CANDIDATO]", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm = New SqlParameter("@idCadastroCandidato", SqlDbType.Int)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@idCadastroCandidato").Value = Session("idCadastroCandidato")

        prm = New SqlParameter("@foto", SqlDbType.VarBinary)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@foto").Value = ImagemDB

        Try
            cn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Close()
            cn.Close()

            REM ** ************************************************************************************
            REM ** EXCLUI A IMAGEM DA PASTA TEMP
            REM ** ************************************************************************************
            Dim local As String = DeletaImagem.ExcluirImagem(Server.MapPath("/") & "_candidato\" & cropOutputRunatServer.Value)
            'LabelTextoImagem.Text = local 'Server.MapPath("/") & "_candidato\" & cropOutputRunatServer.Value
        Catch ex As Exception
            'LabelTextoImagem.Text = Err.Description
        End Try

        Response.Redirect("default.aspx")
    End Sub


End Class
