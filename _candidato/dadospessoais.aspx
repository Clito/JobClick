<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/candidato.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="dadospessoais.aspx.vb" Inherits="_candidato_dadospessoais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="FormDadosPessoais" runat="server">
<section id="content"><div class="ic">OportunidadesBH</div>
  <div class="container">
    <div class="row">
      <div class="grid_12">
        <h3>Dados Pessoais</h3>
        <div class="extra_wrapper">
          <p class="fwn"><a href="#">Por que seus dados pessoais são importantes?</a></p>
          Sem estas informações seria impossível identificar, localizar ou contatar o candidato, existem também outras necessidades para a pesquisa como por exemplo uma vaga para uma determinada região.
        </div>
      </div>
    </div>
  </div>
  <article class="content_gray offset__1">
    <div class="container">
      <div class="row">
        <div class="grid_12">
          <h3><asp:Label ID="LabelNIVELPREENCHIMENTO" runat="server" Text="Endereço e contato"></asp:Label></h3>
        </div>
        <div class="grid_4">
          <div class="block-3">
            <div class="count">1</div>
            <div class="extra_wrapper">
              <div class="text1">CEP</div>
                <asp:TextBox ID="TextBoxCEP" runat="server" placeholder="Informe seu CEP" required="required" MaxLength="9" ValidationGroup="PESQUISACEP"></asp:TextBox>
                <asp:Button ID="ButtonPESQUISACEP" runat="server" Text="Pesquisa" CssClass="btnForm" ValidationGroup="PESQUISACEP" CausesValidation="False" />
            </div>
          </div>
        </div>
        <div class="grid_4">
          <div class="block-3">
            <div class="count">2</div>
            <div class="extra_wrapper">
              <div class="text1"><a href="#">Endereço</a></div>
                <asp:TextBox ID="TextBoxlogradouro" runat="server" placeholder="Endereço" required="required" MaxLength="255" ValidationGroup="ENDERECO"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TextBoxnumero" runat="server" placeholder="Número" required="required" MaxLength="5" ValidationGroup="ENDERECO"></asp:TextBox>
            </div>
          </div>
        </div>
        <div class="grid_4">
          <div class="block-3">
            <div class="count">3</div>
            <div class="extra_wrapper">
              <div class="text1"><a href="#">Contato</a></div>
                <asp:DropDownList ID="DropDownListTIPOTELEFONE" runat="server" required="required" ValidationGroup="CONTATO">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Celular</asp:ListItem>
                    <asp:ListItem>Telefone Fixo</asp:ListItem>
                    <asp:ListItem>Telefone Nextel</asp:ListItem>
                </asp:DropDownList>
            </div>
          </div>
        </div>
      </div>
    </div>
  </article>


</section>
        </form>
</asp:Content>

