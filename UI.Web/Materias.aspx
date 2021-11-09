<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>


<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server"> 
    <asp:Panel ID="gridPanel" runat="server">
                <asp:GridView ID="dgvMaterias" runat="server" AutoGenerateColumns="False" 
                    SelectedRowStyle-BackColor="Black" 
                    SelectedRowStyle-ForeColor="White" 
                    DataKeyNames="ID" OnSelectedIndexChanged="dgvMaterias_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="Descripcion" DataField="DescMateria" />
                        <asp:BoundField HeaderText="Horas semanales" DataField="HSSemanales" />
                        <asp:BoundField HeaderText="Horas totales" DataField="HStotales" />
                        <asp:BoundField HeaderText="Plan" DataField="IDPlan" />
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
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="lbtnEditar" runat="server" OnClick="lbtnEditar_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="lbtnEliminar" runat="server" OnClick="lbtnEliminar_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lbtnNuevo" runat="server" OnClick="lbtnNuevo_Click">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="lbtnInforme" runat="server" OnClick="lbtnInforme_Click">Informe</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="lblDescripcion" runat="server">Descripcion</asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="La descripcion no puede estar vacia" 
            ControlToValidate="txtDescripcion" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="lblHssemanales" runat="server" Text="Horas semanales"></asp:Label>
        <asp:TextBox ID="txtHssemanales" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="La horas semanales no puede estar vacia" 
            ControlToValidate="txtHssemanales" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="lblHstotales" runat="server" Text="Horas totales"></asp:Label>
        <asp:TextBox ID="txtHstotales" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="La horas totales no puede estar vacia" 
            ControlToValidate="txtHstotales" ForeColor="Red">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="lblPlan" runat="server" Text="Descripcion plan"></asp:Label>
        <asp:DropDownList ID="ddlPlan" runat="server"></asp:DropDownList>
        <br/>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="lbtnAceptar" runat="server" OnClick="lbtnAceptar_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click">Cancelar</asp:LinkButton>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" />
        <br />
    </asp:Panel>
</asp:Content>

