<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server" Height="140px">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText ="DescripComision" DataField="DescComision" />
                <asp:BoundField HeaderText ="AnioEspecialidad" DataField="AnioEspecialidad"/>
                <asp:BoundField HeaderText ="IdPlan" DataField="IdPlan" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
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
            <asp:LinkButton ID="lnkbtnEditar" runat="server" OnClick="lnkbtnEditar_Click" >Editar</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnEliminar" runat="server" OnClick="lnkbtnEliminar_Click" >Eliminar</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnNuevo" runat="server" OnClick="lnkbtnNuevo_Click" >Nuevo</asp:LinkButton>
            <asp:LinkButton ID="lbtnInforme" runat="server" OnClick="lbtnInforme_Click">Infrome</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="lblDescCom" runat="server" Text="Descripcion comision"></asp:Label>
        <asp:TextBox ID="txtDescCom" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="La descripcion es requerida"
        ControlToValidate="txtDescCom" ForeColor="Red"    
        >*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="lblAnioEsp" runat="server" Text="AnioEspecialidad"></asp:Label>
        <asp:TextBox ID="txtAnioEsp" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El anio especialidad es requerido"
        ControlToValidate="txtAnioEsp" ForeColor="Red"    
        >*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="lblPlan" runat="server" Text="Plan"></asp:Label>
        <asp:DropDownList ID="ddlPlan" runat="server"></asp:DropDownList>
        <br/>
        <asp:ValidationSummary ID="ValidationSummary1" HeaderText="Validaciones de Errores" ForeColor="Red" runat="server" />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="lnkbtnAceptar" runat="server" OnClick="lnkbtnAceptar_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnCancelar" runat="server" OnClick="lnkbtnCancelar_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    </asp:Panel>
    
    <title>Comisiones</title>
</asp:Content>
