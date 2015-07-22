<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLogin.aspx.cs" Inherits="Carrito.FormLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Iniciar Sesión</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/signin.css" rel="stylesheet">

</head>
<body>
    <div class="container">
    <form id="form1" class="form-signin" runat="server">   
        <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate">
            <LayoutTemplate>
                    <h2 class="form-signin-heading">Por favor Inicie Sesión</h2>
                    
                    <asp:TextBox id="UserName" runat="server" class="form-control" placeholder="Nombre de Usuario" required autofocus></asp:TextBox>

                    <asp:TextBox id="Password" runat="server" textMode="Password" class="form-control" placeholder="Contraseña" required ></asp:TextBox>
                    &nbsp;</div>
                    <asp:button id="Login" class="btn btn-lg btn-primary btn-block" CommandName="Login" runat="server" Text="Iniciar Sesión"></asp:button>

                    <asp:Literal id="FailureText" runat="server"></asp:Literal></td>
            </LayoutTemplate>

        </asp:Login>
    </form>
    </div>
</body>
</html>
