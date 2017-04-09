<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountantHomePage.aspx.cs" Inherits="ENETCareWebForm.AccountantHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 798px">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="accountant" runat="server" Font-Bold="True" Font-Size="X-Large" style="z-index: 1; left: 296px; top: 14px; position: absolute; width: 367px; height: 45px" Text="Accountant Home Page"></asp:Label>
        </div>
        <asp:Button ID="changePasswordButton" runat="server" OnClick="changePasswordButton_Click" style="z-index: 1; left: 86px; top: 158px; position: absolute; height: 59px; width: 268px" Text="Change Password" />
        <asp:DropDownList ID="dropDownReportBox" runat="server" OnSelectedIndexChanged="dropDownReportBox_SelectedIndexChanged" style="z-index: 1; left: 477px; top: 185px; position: absolute; width: 279px; height: 45px" BackColor="#CCCCCC">
            <asp:ListItem Value="totalCostEng">Total Cost by Site Engineer</asp:ListItem>
            <asp:ListItem Value="avgCostEng">Average Cost By Site Engineer</asp:ListItem>
            <asp:ListItem Value="districtCost">Cost By District</asp:ListItem>
            <asp:ListItem Value="monthlyCostDistrict">Monthly Cost for District</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="txtBoxRunReport" runat="server" style="z-index: 1; left: 484px; top: 158px; position: absolute; width: 237px" Text="Run Report"></asp:Label>
        <asp:Button ID="engManagerListButton" runat="server" OnClick="engManagerListButton_Click" style="z-index: 1; left: 86px; top: 256px; position: absolute; width: 307px; height: 64px" Text="List of Site Engineer &amp; Manager" />
        <asp:Button ID="logout" runat="server" style="z-index: 1; left: 91px; top: 375px; position: absolute; width: 161px; height: 47px" Text="Logout" />
    </form>
</body>
</html>
