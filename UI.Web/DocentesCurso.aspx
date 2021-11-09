<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocentesCurso.aspx.cs" Inherits="UI.Web.DocentesCurso" %>

<asp:Content ID="DocentesCursoContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="dgvDocentesCursos" runat="server" AutoGenerateColumns="False" 
             SelectedRowStyle-BackColor="Black"
             SelectedRowStyle-ForeColor="White"
             DataKeyNames="ID" OnSelectedIndexChanged="dgvDocentesCursos_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="Curso" DataField="IDCurso" />
                <asp:BoundField HeaderText="Docente" DataField="IDDocente" />
                <asp:BoundField HeaderText="Cargo" DataField="Cargo" />
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
    </asp:Panel>
    <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="lbtnEditar" runat="server" OnClick="lbtnEditar_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="lbtnEliminar" runat="server" OnClick="lbtnEliminar_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lbtnNuevo" runat="server" OnClick="lbtnNuevo_Click">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="lbtnInforme" runat="server" OnClick="lbtnInforme_Click">Informe</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="lblMateria" runat="server">Materia:</asp:Label>
        <asp:DropDownList ID="ddlMateria" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="lblComision" runat="server">Curso:</asp:Label>
        <asp:DropDownList ID="ddlComision" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="lblDocente" runat="server">Docente:</asp:Label>
        <asp:DropDownList ID="ddlDocente" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="lblCargo" runat="server">Cargo:</asp:Label>
        <asp:DropDownList ID="ddlCargo" runat="server"></asp:DropDownList>
        <br />
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="lbtnAceptar" runat="server" OnClick="lbtnAceptar_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
