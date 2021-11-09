<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportesMaterias.aspx.cs" Inherits="UI.Web.Reportes.reportesMaterias" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%">
                <LocalReport ReportPath="Reportes\rMaterias.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="odsMaterias" Name="dsMaterias" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="odsMaterias" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="UI.Web.AcademiaDataSetTableAdapters.materiasTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_id_materia" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="desc_materia" Type="String" />
                    <asp:Parameter Name="hs_semanales" Type="Int32" />
                    <asp:Parameter Name="hs_totales" Type="Int32" />
                    <asp:Parameter Name="id_plan" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="desc_materia" Type="String" />
                    <asp:Parameter Name="hs_semanales" Type="Int32" />
                    <asp:Parameter Name="hs_totales" Type="Int32" />
                    <asp:Parameter Name="id_plan" Type="Int32" />
                    <asp:Parameter Name="Original_id_materia" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
