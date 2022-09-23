Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq

Partial Public Class _pagamento_servico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs)

        'Esta linha deve ser removida para que seja utilizado o ambiente real do PagSeguro
        Me.VendaPagSeguro1.UrlPagSeguro = "https://sandbox.pagseguro.uol.com.br/checkout/checkout.jhtml"

    End Sub


    Protected Sub btnEfetuarPagamento_Click(sender As Object, e As ImageClickEventArgs) Handles btnEfetuarPagamento.Click


        'Grave o seu pedido do ser carrinho no banco de dados, e informe o código do mesmo ao PagSeguro
        Dim codigoPedido As String = AcessoDados.Instancia.GravarPedido(Carrinho.Instancia)
        Me.VendaPagSeguro1.CodigoReferencia = "0001"

        'Instancie a lista de produtos a ser comprados
        Me.VendaPagSeguro1.Produtos = New List(Of UOL.PagSeguro.Produto)()



        'Criando o produto para ser adicionado à venda do PagSeguro
        Dim produto As New UOL.PagSeguro.Produto()
        produto.Codigo = "00001" ' codigo.ToString()
        produto.Descricao = "APENAS UM TESTE" ' String.Format("{0} {1}", registro("Trademark"), registro("Model"))
        produto.Quantidade = 1 ' quantidade
        produto.Valor = Convert.ToDouble(250)

        Me.VendaPagSeguro1.Produtos.Add(produto)


        'Informe ao componente, caso possível, os dados do cliente que está efetuando a compra
        Me.VendaPagSeguro1.Cliente = New UOL.PagSeguro.Cliente()
        Me.VendaPagSeguro1.Cliente.Nome = "João da Silva"
        Me.VendaPagSeguro1.Cliente.Email = "c32753704624145514164@sandbox.pagseguro.com.br"

        'Limpando o Carrinho
        Carrinho.Instancia.Limpar()

        'Encaminhando ao PagSeguro para efetuar o pagamento
        Me.VendaPagSeguro1.Executar(Me.Response)


    End Sub
End Class


