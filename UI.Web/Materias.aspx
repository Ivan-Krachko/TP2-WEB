<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>


<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server"> 
    <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="dgvMaterias" runat="server" AutoGenerateColumns="false" 
                    SelectedRowStyle-BackColor="Black" 
                    SelectedRowStyle-ForeColor="White" 
                    DataKeyNames="ID" OnSelectedIndexChanged="dgvMaterias_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Descripcion" DataField="DescMateria" />
                        <asp:BoundField HeaderText="Horas semanales" DataField="HSSemanales" />
                        <asp:BoundField HeaderText="Horas totales" DataField="HStotales" />
                        <asp:BoundField HeaderText="Plan" DataField="IDPlan" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>
     </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="lbtnEditar" runat="server" OnClick="lbtnEditar_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="lbtnEliminar" runat="server">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lbtnNuevo" runat="server">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="true" runat="server">
        <asp:Label ID="lblDescripcion" runat="server">Descripcion</asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="lblHssemanales" runat="server" Text="Horas semanales"></asp:Label>
        <asp:TextBox ID="txtHssemanales" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="lblHstotales" runat="server" Text="Horas totales"></asp:Label>
        <asp:TextBox ID="txtHstotales" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="lblPlan" runat="server" Text="Descripcion plan"></asp:Label>
        <asp:DropDownList ID="ddlPlan" runat="server"></asp:DropDownList>
        <br/>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="lbtnAceptar" runat="server">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="lbtnCancelar" runat="server">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>

