<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SiteEngineerAverageCostReportPage.aspx.cs" Inherits="ENETCareWebForm.SiteEngineerAverageCostReportPage" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <body>
    <form id="form1">
    <div>
    
        <asp:Label ID="PageNameLabel" runat="server" Font-Size="X-Large" Text="Average Costs By Engineer"></asp:Label>
        <br />
        <br />
        <br />
            <asp:Label ID="errorMessageLabel" runat="server"></asp:Label>
        <br />
        <br />
    
        <asp:GridView ID="averageCostListGridView" runat="server" AllowPaging="True" AutoGenerateColumns="false" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="averageCostListGridView_PageIndexChanging" PageSize="10">
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
                        <asp:BoundField DataField="TotalCost" HeaderText="Average Cost" />
                        <asp:TemplateField HeaderText="Average Labour">
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
