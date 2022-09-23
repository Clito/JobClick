<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/candidato.master" AutoEventWireup="false" CodeFile="logout.aspx.vb" Inherits="_candidato_logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section id="content"><div class="ic">OportunidadesBH</div>
  <div class="container">
     <div class="grid_12">
        <h3 class="head__1">Sair</h3>

         <form id="contact_form" runat="server">
            <asp:Panel ID="PanelAVISO" runat="server" Visible="True" Width="100%">
                <div class="modal-dialog">
                    <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton ID="LinkButtonFECHAR" CssClass="close" runat="server">X</asp:LinkButton>
                        <h4 class="modal-title"><asp:Label ID="LabelPanelAviso" runat="server" Text="Aviso"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="LabelAviso" runat="server" Text="Deseja encerrar sua sessão?"></asp:Label>
                    </div>  
                    <div class="modal-body">                        
                        <asp:LinkButton ID="LinkButtonENCERRAR" runat="server" CssClass="btn">Sim</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton ID="LinkButtonVoltar" runat="server" CssClass="btn">Não</asp:LinkButton>
                    </div>                                      
                    </div>                                
                </div>          
            </asp:Panel>
            
         </form>
      </div>
      </div>
    </section>
</asp:Content>

