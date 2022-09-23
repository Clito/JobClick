<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/candidato.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_candidato_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section id="content"><div class="ic">OportunidadesBH</div>
  <div class="container">
    <div class="row">
      <div class="grid_12">
        <h3><asp:Label ID="LabelPAGINAPRINCIPAL" runat="server" Text="Seja bem-vindo"></asp:Label></h3>
        <div class="blog">
          <time datetime="<%=Now()%>"><span class="count"><%=DateTime.Now.Day%></span><strong><%=DateTime.Now.ToString("MMMM")%></strong><%=DateTime.Now.Year%></time>
         <!-- <img src="../images/page4_img1.jpg" alt="" class="img_inner fleft"> -->
          <div class="extra_wrapper">
            <!-- <a href="#" class="comment"><span class="fa fa-comments"></span> 0</a> -->
            <p><span class="fwn"><a href="#">Antes de iniciar veja o que o sistema pode fazer por você</a></span><em>Por <a href="#">Clito Fornaciari Neto</a></em></p><br>
            Se este for o seu primeiro acesso, sugerimos que você inicie informando seus <u><a href="dadospessoais.aspx">dados pessoais</a></u>. É de grande importância manter seus dados sempre atualizados, as empresas que fazem pesquisa em nossa base de talentos procuram diariamente por candidatos de diversas áreas. As entrevistas para uma futura recolocação podem ser solicitadas por e-mail, telefone ou celular.
            <br>
            <a href="#" class="link-1">Veja o que falta ser preenchido</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</asp:Content>

