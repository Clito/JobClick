<%@ Page Language="VB" AutoEventWireup="false" CodeFile="notificacao.aspx.vb" Inherits="_pagamento_notificacao" %>

<%@ Register assembly="UOL.PagSeguro" namespace="UOL.PagSeguro" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
    <cc1:RetornoPagSeguro ID="RetornoPagSeguroPAGAMENTO" runat="server" Token="90B6F36F5DD84C7E828638FB5B697DC8" UrlNPI="https://sandbox.pagseguro.uol.com.br/pagseguro-ws/checkout/NPI.jhtml">
    </cc1:RetornoPagSeguro>
</html>
