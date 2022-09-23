<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/pagamento.master" AutoEventWireup="false" CodeFile="servico.aspx.vb" Inherits="_pagamento_servico" %>

<%@ Register assembly="UOL.PagSeguro" namespace="UOL.PagSeguro" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <form id="pagseguro" runat="server" target="pagseguro" method="POST">
            <div id="status_carrinho">
                <asp:ImageButton ID="btnEfetuarPagamento" runat="server" ImageUrl="~/images/form-loader.gif"
                    OnClick="btnEfetuarPagamento_Click" ImageAlign="AbsMiddle" />
                <br />
                <cc1:VendaPagSeguro ID="VendaPagSeguro1" runat="server" EmailCobranca="fornaciari@cheyenne.com.br" UrlPagSeguro="https://sandbox.pagseguro.uol.com.br/checkout/checkout.jhtml">
                </cc1:VendaPagSeguro>
            </div>
        </form>
</asp:Content>

