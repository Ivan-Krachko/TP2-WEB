<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style2 {
            width: 149px;
        }
        .auto-style3 {
            height: 26px;
            width: 149px;
        }
        .auto-style4 {
            width: 40%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style4">
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label3" runat="server" Text="Login Usuario"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" Width="204px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" Width="204px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
