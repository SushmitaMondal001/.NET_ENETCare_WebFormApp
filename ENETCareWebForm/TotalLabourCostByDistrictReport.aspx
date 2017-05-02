<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TotalLabourCostByDistrictReport.aspx.cs" Inherits="ENETCareWebForm.TotalLabourCostByDistrictReport" MasterPageFile="~/MasterPage.Master" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
    <form id="form1">
    <div>
    
        <asp:Label ID="PageNameLabel" runat="server" Font-Size="X-Large" Text="Total Costs and labour By District"></asp:Label>
        <br />
        <br />
        <br />
            <asp:Label ID="errorMessageLabel" runat="server" Style="color:darkred"></asp:Label>
        <br />
        <br />
    
        <asp:GridView ID="labourCostListByDistrictGridView" runat="server" AllowPaging="True" AutoGenerateColumns="false" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="labourCostListByDistrictGridView_PageIndexChanging" PageSize="10" OnRowCommand="labourCostListByDistrictGridView_RowCommand" OnRowDataBound="labourCostListByDistrictGridView_RowDataBound">
            <%----%> 
                    <Columns>
                        <asp:TemplateField HeaderText="Row Number" ItemStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DistrictName" HeaderText="DistrictName" />
                        <asp:BoundField DataField="LabourHour" HeaderText="Labour Hour" />
                        <asp:BoundField DataField="Cost" HeaderText="Cost" />
                    </Columns>
        </asp:GridView>
        
        <br />
            <asp:Label ID="totalLabourByDistrictLabel" runat="server"> Total Labour:</asp:Label>
            <asp:Label ID="totalLabourByDistrictTextBox" runat="server"></asp:Label>
        
        <br />
            <asp:Label ID="totalCostByDistrictLabel" runat="server"> Total Cost:</asp:Label>
            <asp:Label ID="totalCostByDistrictTextBox" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="accountantHomePageButton" runat="server" OnClick="accountantHomePageButton_Click" Text="Accountant Home Page " />
        <br />
        </div>

        <%----%>

    </form>
        </body>


</asp:Content>
