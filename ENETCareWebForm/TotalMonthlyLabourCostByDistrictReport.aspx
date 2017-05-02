<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TotalMonthlyLabourCostByDistrictReport.aspx.cs" Inherits="ENETCareWebForm.TotalMonthlyLabourCostByDistrictReport" MasterPageFile="~/MasterPage.Master" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
    <form id="form1">
    <div>
    
        <asp:Label ID="PageNameLabel" runat="server" Font-Size="X-Large" Text="Monthly Total Costs and labour By District"></asp:Label>
        <br />
        <br />
        
        <br />
            <asp:Label ID="errorMessageLabel" runat="server" Style="color:red"></asp:Label>
        <br />
        <br />
        <br />
        <asp:DropDownList ID="districtDropDownBoxList" runat="server" AppendDataBoundItems="true" EnableViewState="true" AutoPostBack="True" OnSelectedIndexChanged="DistrictDropDownBoxList_SelectedIndexChanged">
            <asp:ListItem disabled="disabled">Select District</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
    
        <asp:GridView ID="MonthlylabourCostListByDistrictGridView" runat="server" AllowPaging="True" AutoGenerateColumns="false" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="MonthlylabourCostListByDistrictGridView_PageIndexChanging" PageSize="1" >
            <%----%> 
                    <Columns>
                        <asp:TemplateField HeaderText="Row Number" ItemStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="InterventionMonth" HeaderText="Month" />
                        <asp:BoundField DataField="LabourRequired" HeaderText="Labour Hour" />
                        <asp:BoundField DataField="Cost" HeaderText="Cost" />
                    </Columns>
        </asp:GridView>
        <p>
            <asp:Button ID="accountantHomePageButton" runat="server" OnClick="AccountantHomePageButton_Click" style="width: 251px" Text="Accountant Home Page" />
            </p>
        
        <%--<br />
            <asp:Label ID="totalLabourByDistrictLabel" runat="server"> Total Labour:</asp:Label>
            <asp:Label ID="totalLabourByDistrictTextBox" runat="server"></asp:Label>
        
        <br />
            <asp:Label ID="totalCostByDistrictLabel" runat="server"> Total Cost:</asp:Label>
            <asp:Label ID="totalCostByDistrictTextBox" runat="server"></asp:Label>--%>
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
