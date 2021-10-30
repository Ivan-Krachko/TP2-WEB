<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="GridPanel" runat="server" Height="175px" Width="812px">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns ="false"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText ="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="lnkbtnEditar" runat="server" OnClick="lnkbtnEditar_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="lnkbtnEliminar" runat="server" OnClick="lnkbtnEliminar_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lnkbtnNuevo" runat="server" OnClick="lnkbtnNuevo_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server" Height="257px" style="margin-top: 1px">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado"></asp:Label>
        <asp:CheckBox ID="chkHabilitado" runat="server" /><br />
        <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario"></asp:Label>
        <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
        <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblConfirmarClave" runat="server" Text="ConfirmarClave"></asp:Label>
        <asp:TextBox ID="txtConfirmarClave" TextMode="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="lnkbtnAceptar" runat="server" OnClick="lnkbtnAceptar_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnCancelar" runat="server" OnClick="lnkbtnCancelar_Click">Cancelar</asp:LinkButton>
        </asp:Panel>

    </asp:Panel>
    </asp:Panel>
    
    


    <title>Usuarios</title>
</asp:Content>
