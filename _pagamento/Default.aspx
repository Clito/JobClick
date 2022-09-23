<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/pagamento.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_pagamento_Default2" %>

<%@ Register assembly="UOL.PagSeguro" namespace="UOL.PagSeguro" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="form1" runat="server">
<section id="content"><div class="ic">OportunidadesBH</div>
  <div class="container">
    <div class="row">
      <div class="grid_12">
        <h3><asp:Label ID="LabelPAGINAPRINCIPAL" runat="server" Text="Produtos & Serviços"></asp:Label></h3>
        <div class="blog">
          <time datetime="<%=Now()%>"><span class="count"><%=DateTime.Now.Day%></span><strong><%=DateTime.Now.ToString("MMMM")%></strong><%=DateTime.Now.Year%></time>
         <!-- <img src="../images/page4_img1.jpg" alt="" class="img_inner fleft"> -->
          <div class="extra_wrapper">
            <!-- <a href="#" class="comment"><span class="fa fa-comments"></span> 0</a> -->
            <p><span class="fwn"><a href="#"><asp:Label ID="LabelIDPRODUTO" runat="server"></asp:Label>Conheça nossos produtos & serviços</a></span><em>Por <a href="#">Clito Fornaciari Neto</a></em></p><br>
                <asp:DataList ID="DataListPRODUTOS" runat="server" DataKeyField="idProduto" DataSourceID="SqlDataSourcePRODUTOS">
                  <ItemTemplate>
                      <asp:Image ID="ImagePRODUTO" runat="server" CssClass="img_inner fleft" ImageUrl='<%# Eval("imagem") %>' />
                      <asp:Label ID="ProdutoLabel" runat="server" CssClass="h3" Text='<%# Eval("Produto") %>' />
                      <br />
                      <asp:Label ID="LabelCODIGOTEXT" runat="server" Text="Código do Produto:"></asp:Label>
                      <asp:Label ID="codProdutoLabel" runat="server" Text='<%# Eval("codProduto") %>' />
                      <br />
                      <asp:Label ID="dsProdutoLabel" runat="server" Text='<%# Eval("dsProduto") %>' />
                      <br />
                      <br />
                      <asp:Label ID="precoLabel" runat="server" CssClass="h4" Text='<%# Eval("preco", "{0:C}") %>' />
                      <br />
                      <br />
                      <asp:LinkButton ID="LinkButtonCOMPRAR" runat="server" CssClass="btn-icon btn-lg b-2x" CommandName="Select">Comprar</asp:LinkButton>
                      &nbsp;<hr />
                  </ItemTemplate>
              </asp:DataList>
            <br>          
              
          </div>
        </div>
      </div>
    </div>
  </div>
    <asp:SqlDataSource ID="SqlDataSourcePRODUTOS" runat="server" ConnectionString="<%$ ConnectionStrings:dboportunidadesBH %>" SelectCommand="spPRODUTO_PAGSEGURO" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter DefaultValue="C" Name="PRODUTOSPARA" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <cc1:VendaPagSeguro ID="VendaPagSeguro1" runat="server" EmailCobranca="fornaciari@cheyenne.com.br" UrlPagSeguro="https://sandbox.pagseguro.uol.com.br/checkout/checkout.jhtml">
    </cc1:VendaPagSeguro>
</section>
</form>
</asp:Content>

