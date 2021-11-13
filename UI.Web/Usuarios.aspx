<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="GridPanel" runat="server" Height="175px" Width="812px">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns ="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText ="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="lnkbtnEditar" runat="server" OnClick="lnkbtnEditar_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="lnkbtnEliminar" runat="server" OnClick="lnkbtnEliminar_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lnkbtnNuevo" runat="server" OnClick="lnkbtnNuevo_Click">Nuevo</asp:LinkButton>
            <asp:LinkButton ID="lkbtnInforme" runat="server" OnClick="lkbtnInforme_Click">Informe</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server" Height="257px" style="margin-top: 1px">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="el Nombre esta vacio" 
            ControlToValidate="txtNombre" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="el Apellido esta vacio" 
            ControlToValidate="txtApellido" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="el Email esta vacio" 
            ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtEmail" ForeColor ="Red"
            ErrorMessage="mail invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">*</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado"></asp:Label>
        <asp:CheckBox ID="chkHabilitado" runat="server" /><br />
        <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario"></asp:Label>
        <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="el NombreUsuario esta vacio" 
            ControlToValidate="txtNombreUsuario" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
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
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" HeaderText="Validaciones de Errores" runat="server" />
        </asp:Panel>

    </asp:Panel>
    </asp:Panel>
    
    


    <title>Usuarios</title>
</asp:Content>
