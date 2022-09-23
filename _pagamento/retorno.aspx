<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/pagamento.master" AutoEventWireup="false" CodeFile="retorno.aspx.vb" Inherits="_pagamento_retorno" %>

<%@ Register assembly="UOL.PagSeguro" namespace="UOL.PagSeguro" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section id="content"><div class="ic">OportunidadesBH</div>
  <div class="container">
    <div class="row">
      <div class="grid_12">
        <h3><asp:Label ID="LabelPAGINAPRINCIPAL" runat="server" Text="Produtos & Serviços"></asp:Label></h3>
        <div class="blog">
          <time datetime="<%=Now()%>"><span class="count"><%=DateTime.Now.Day%></span><strong><%=DateTime.Now.ToString("MMMM")%></strong><%=DateTime.Now.Year%></time>
          <div class="extra_wrapper">
            <p><span class="fwn"><asp:Label ID="LabelTKS" runat="server" CssClass="h3">Obrigado!</asp:Label><br /><asp:Label ID="LabelNOME" runat="server"></asp:Label>, gostariamos de lhe agradecer por ter comprado o <asp:Label ID="LabelPRODUTO" runat="server"></asp:Label>, aproveitamos para informar que toda transação será enviada para o e-mail informado em seu cadastro.
                <br />
                <br />
                Atenciosamente,</span><em>Equipe OportunidadesBH</em></p><br>
            <br>              
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
    <cc1:RetornoPagSeguro ID="RetornoPagSeguroPAGAMENTO" runat="server" Token="90B6F36F5DD84C7E828638FB5B697DC8" UrlNPI="https://sandbox.pagseguro.uol.com.br/pagseguro-ws/checkout/NPI.jhtml">
    </cc1:RetornoPagSeguro>
</asp:Content>

