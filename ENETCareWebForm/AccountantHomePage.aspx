<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountantHomePage.aspx.cs" Inherits="ENETCareWebForm.AccountantHomePage" MasterPageFile="MasterPage.Master" EnableEventValidation = false %>

<asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<body >
    <form id="form1">
         <%--style="z-index: 1; left: 296px; top: 14px; position: absolute; width: 367px; height: 45px"--%>
        <div>
            <asp:Label ID="accountant" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Accountant Home Page"></asp:Label>
        </div>
         <br />
        <asp:Literal ID="StatusText" runat="server"></asp:Literal>
         <%-- style="z-index: 1; left: 86px; top: 158px; position: absolute; height: 59px; width: 268px"--%>
         <br />
         <br />
         <br />
            <asp:Label ID="errorMessageLabel" runat="server"></asp:Label>
        <br />
        <br />
    
         <br />
        <asp:Button ID="changePasswordButton" runat="server" OnClick="changePasswordButton_Click" Text="Change Password" />
         <%--style="z-index: 1; left: 477px; top: 185px; position: absolute; width: 279px; height: 45px" BackColor="#CCCCCC"--%>
         <br />
         <%--style="z-index: 1; left: 484px; top: 158px; position: absolute; width: 237px"--%>
         <br />
        <asp:Button ID="engManagerListButton" runat="server" OnClick="engManagerListButton_Click"  Text="List of Site Engineer &amp; Manager" />
        
        <%--style="z-index: 1; left: 87px; top: 335px; position: absolute; width: 307px; height: 64px"--%>
         <br />
         <br />
        <asp:Button ID="changeDistrict" runat="server" OnClick="changeDistrict_Click"  Text="Change District" />
        
        <%--style="z-index: 1; left: 83px; top: 447px; position: absolute; width: 161px; height: 47px"--%>
         <br />
         <br />
        <asp:Label ID="txtBoxRunReport" runat="server" Text="Run Report"></asp:Label>

         <br />
        <asp:DropDownList ID="dropDownReportBox" runat="server" OnSelectedIndexChanged="dropDownReportBox_SelectedIndexChanged" AutoPostBack="True" >
            <asp:ListItem Value="Nothing"> <-- SelectReportType --> </asp:ListItem>
            <asp:ListItem Value="/SiteEngineerTotalCostReport.aspx">Total Cost by Site Engineer</asp:ListItem>
            <asp:ListItem Value="/SiteEngineerAverageCostReportPage.aspx">Average Cost By Site Engineer</asp:ListItem>
            <asp:ListItem Value="/TotalLabourCostByDistrictReport.aspx">Cost By District</asp:ListItem>
            <asp:ListItem Value="/TotalMonthlyLabourCostByDistrictReport.aspx">Monthly Cost for District</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
         <asp:Button ID="generateReportButton" runat="server" OnClick="generateReportButton_Click" Text="Generate Report" />
         <br />
         <br />
         <br />
         <br />
        <asp:Button ID="accountantLogoutButton" runat="server"  Text="Logout" OnClick="accountantLogoutButton_Click" />
    </form>
</body>
</asp:content>
