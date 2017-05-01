<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SiteEngineerTotalCostReport.aspx.cs" Inherits="ENETCareWebForm.SiteEngineerTotalCostReport" EnableEventValidation = "false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
    <form id="form1">
    <div>
    
        <asp:Label ID="PageNameLabel" runat="server" Font-Size="X-Large" Text="Total Costs By Engineer"></asp:Label>
        <br />
        <br />
        <br />
            <asp:Label ID="errorMessageLabel" runat="server"></asp:Label>
        <br />
        <br />
    
        <asp:GridView ID="totalCostListGridView" runat="server" AllowPaging="True" AutoGenerateColumns="false" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="totalCostListGridView_PageIndexChanging" PageSize="10">
            <%----%> 
                    <Columns>
                        <asp:TemplateField HeaderText="Row Number" ItemStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name">
                            <ItemTemplate>
                                <asp:Label ID="clientNameLabel" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" />
                        <asp:TemplateField HeaderText="Total Labour">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("TotalLabour")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
        </asp:GridView>
        <br />
        </div>

        <%--<asp:ScriptManager ID="totalCostScriptManager" runat="server"></asp:ScriptManager>
       
        <div>
            <rsweb:ReportViewer ID="siteEngineerTotalCostReportViewer" runat="server"></rsweb:ReportViewer>
        </div>
        --%>

    </form>
        </body>


</asp:Content>
