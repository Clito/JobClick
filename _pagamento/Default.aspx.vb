Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports UOL.PagSeguro
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader
Imports System.Data.SqlClient.SqlDataAdapter
Partial Class _pagamento_Default2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs)

        REM ** *******************************************************************************************
        REM ** Esta linha deve ser removida para que seja utilizado o ambiente real do PagSeguro
        Me.VendaPagSeguro1.UrlPagSeguro = "https://sandbox.pagseguro.uol.com.br/checkout/checkout.jhtml"
        REM ** *******************************************************************************************
    End Sub

    Protected Sub DataListPRODUTOS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataListPRODUTOS.SelectedIndexChanged

        LabelIDPRODUTO.Text = DataListPRODUTOS.SelectedValue

        REM ** *******************************************************************************************
        REM ** PREPARA O ENVIO DO PRODUTO PARA O PAGSEGURO
        REM ** *******************************************************************************************

        Dim cn As SqlConnection
        Dim cmd As SqlCommand
        Dim prm As SqlParameter

        cn = New SqlConnection(ConfigurationManager.ConnectionStrings("dboportunidadesBH").ConnectionString)

        cmd = New SqlCommand("[spPRODUTO_PAGSEGURO_ENVIO_CANDIDATO]", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm = New SqlParameter("@idProduto", SqlDbType.Int)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@idProduto").Value = LabelIDPRODUTO.Text

        prm = New SqlParameter("@idCadastroCandidato", SqlDbType.Int)
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)
        cmd.Parameters("@idCadastroCandidato").Value = Session("idCadastroCandidato")


        Try
            cn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows() Then
                dr.Read()

                Dim codigoPedido As String = AcessoDados.Instancia.GravarPedido(Carrinho.Instancia)
                Me.VendaPagSeguro1.CodigoReferencia = Session("idCadastroCandidato")

                Me.VendaPagSeguro1.Produtos = New List(Of UOL.PagSeguro.Produto)()

                Dim produto As New UOL.PagSeguro.Produto()
                produto.Codigo = LabelIDPRODUTO.Text
                produto.Descricao = dr("codProduto") & " - " & dr("Produto")
                produto.Quantidade = dr("qtd")
                produto.Valor = Convert.ToDouble(dr("unitario"))

                Me.VendaPagSeguro1.Produtos.Add(produto)

                Me.VendaPagSeguro1.Cliente = New UOL.PagSeguro.Cliente()
                Me.VendaPagSeguro1.Cliente.Nome = dr("nome")

                Me.VendaPagSeguro1.Cliente.Email = dr("email")
                Carrinho.Instancia.Limpar()

            End If

            cn.Close()

            Me.VendaPagSeguro1.Executar(Me.Response)

        Catch ex As Exception

        End Try
    End Sub
End Class
