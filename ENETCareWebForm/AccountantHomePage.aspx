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
        <asp:Button ID="changePass" runat="server" OnClick="changePass_Click" style="z-index: 1; left: 60px; top: 78px; position: absolute; height: 51px; width: 268px" Text="Change Password" />
        <asp:DropDownList ID="dropDownReportBox" runat="server" OnSelectedIndexChanged="dropDownReportBox_SelectedIndexChanged" style="z-index: 1; left: 507px; top: 184px; position: absolute; width: 279px; height: 45px">
            <asp:ListItem Value="totalCostEng">Total Cost by Site Engineer</asp:ListItem>
            <asp:ListItem Value="avgCostEng">Average Cost By Site Engineer</asp:ListItem>
            <asp:ListItem Value="districtCost">Cost By District</asp:ListItem>
            <asp:ListItem Value="monthlyCostDistrict">Monthly Cost for District</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="txtBoxRunReport" runat="server" style="z-index: 1; left: 513px; top: 156px; position: absolute; width: 237px" Text="Run Report"></asp:Label>
        <asp:Button ID="engManagerList" runat="server" OnClick="engManagerList_Click" style="z-index: 1; left: 62px; top: 188px; position: absolute; width: 307px; height: 49px" Text="List of Site Engineer &amp; Manager" />
    </form>
</body>
</html>
