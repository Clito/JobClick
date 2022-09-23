<%@ Page Title="" Language="VB" MasterPageFile="MasterPage/anonimo_login.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section id="content"><div class="ic">OportunidadesBH</div>
  <div class="container">
     <div class="grid_12">
        <h3 class="head__1">Acesso restrito</h3>

            <form id="contact_form" runat="server">
                    
                  <div class="contact-form-loader"></div>
                  <fieldset>
                    <asp:Panel ID="PanelFORMULARIO" runat="server">
                    <div class="fwn">
                      <p>Você é candidato e ainda não tem um cadastro <a title="Inicie seu cadastro agora" href="cadastrocandidato.aspx" rel="nofollow" class="color1">clique aqui</a>.</p>
                      <p>Você quer publicar uma oportunidade e ainda não tem um cadastro <a title="Inicie seu cadastro agora" href="cadastroempresa.aspx" rel="nofollow" class="color1">clique aqui</a>.</p>
                      Informe abaixo os dados de acesso, os mesmos que você utilizou no momento de seu cadastro.
                    </div><br /><br />
                    <label class="email">
                      <asp:TextBox ID="TextBoxEmail" runat="server" placeholder="E-mail" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$" required="required" ValidationGroup="LOGIN"></asp:TextBox>
                    </label>
                      
                    <label class="Senha">
                      <asp:TextBox ID="TextBoxSenha" runat="server" placeholder="Senha" TextMode="Password" required="required" MaxLength="16" ValidationGroup="LOGIN"></asp:TextBox>
                    </label>  
                    
                    <label class="checkbox">
                      <asp:CheckBox ID="CheckBoxMANTERLOGADO" runat="server" Text="Mantenha-me conectado" />
                    </label>               

                    <div class="clear"></div>
                    <asp:Button ID="ButtonESQUECI" runat="server" CausesValidation="False" CssClass="btn" Text="ESQUECI MINHA SENHA" />
                    <asp:Button ID="ButtonLOGIN" runat="server" Text="Entrar" CssClass="btn" ValidationGroup="LOGIN" />                        
                    </asp:Panel>

                      <div>
                        <asp:Panel ID="PanelAVISO" runat="server" Visible="False" Width="100%">
                            <div class="modal-dialog">
                              <div class="modal-content">
                                <div class="modal-header">
                                    <asp:LinkButton ID="LinkButtonFECHAR" CssClass="close" runat="server">X</asp:LinkButton>
                                  <h4 class="modal-title"><asp:Label ID="LabelPanelAviso" runat="server" Text="Aviso"></asp:Label></h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Label ID="LabelAviso" runat="server" Text="..."></asp:Label>
                                </div>  
                                <div class="modal-body">
                                    <asp:TextBox ID="TextBoxLEMBRARSENHA" runat="server" placeholder="Informe seu e-mail de cadastro aqui." pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$" required="required" ValidationGroup="LEMBRAR"></asp:TextBox>                                     
                                    <asp:Button ID="ButtonLEMBRARSENHA" runat="server" Text="ENVIAR MINHA SENHA" CssClass="btn" ValidationGroup="LEMBRAR" />
                                </div>                                      
                              </div>                                
                            </div>          
                        </asp:Panel>
                        
                    </div>
                  </fieldset>             
             </form>
      </div>
      </div>
    </section>
</asp:Content>

