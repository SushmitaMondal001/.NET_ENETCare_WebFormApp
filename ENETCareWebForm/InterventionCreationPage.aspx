<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterventionCreationPage.aspx.cs" Inherits="ENETCareWebForm.InterventionCreationPage" MasterPageFile="~/MasterPage.Master" EnableEventValidation = false %>


<asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>--%>
<body>
    <form id="form1">
        <div style="height: 853px; width: 1450px">
            <asp:Label ID="interventionPageLbel" runat="server" Font-Bold="True" Font-Size="Large" style="z-index: 1; left: 479px; top: 252px; position: absolute; width: 244px" Text="Create Intervention"></asp:Label>
            <asp:Label ID="errorMessageLabel" runat="server"></asp:Label>
            <asp:Label ID="interventionDateLabel" runat="server" Font-Bold="True" style="z-index: 1; left: 118px; top: 676px; position: absolute; margin-top: 0px" Text="Intervention Date"></asp:Label>
            <asp:Label ID="userNameLabel" runat="server" Font-Bold="True" style="z-index: 1; left: 123px; top: 836px; position: absolute" Text="User Name"></asp:Label>
            <asp:Label ID="interventionStateLabel" runat="server" Font-Bold="True" style="z-index: 1; left: 121px; top: 749px; position: absolute; margin-top: 0px" Text="Intervention State"></asp:Label>
            <asp:Label ID="costRequiredLabel" runat="server" Font-Bold="True" style="z-index: 1; left: 115px; top: 581px; position: absolute" Text="Cost Required"></asp:Label>
            <asp:Label ID="interventionTypeLabel" runat="server" Font-Bold="True" style="z-index: 1; left: 118px; top: 331px; position: absolute; width: 189px" Text="Intervention Type"></asp:Label>
            <asp:DropDownList ID="interventionTypeDropDownList" runat="server" style="z-index: 1; left: 438px; top: 327px; position: absolute; width: 406px; height: 49px;" Visible="True">
            </asp:DropDownList>
            <asp:DropDownList ID="interventionStateDropDownList" runat="server" style="z-index: 1; left: 445px; top: 745px; position: absolute; width: 231px" Visible="False">
            </asp:DropDownList>
            <asp:DropDownList ID="clientNameDropDownList" runat="server" style="z-index: 1; left: 440px; top: 410px; position: absolute; width: 333px" Visible="True">
            </asp:DropDownList>
            <asp:Label ID="labourHourRequiredLabel" runat="server" Font-Bold="True" style="z-index: 1; left: 120px; top: 498px; position: absolute" Text="Labour Hour Required"></asp:Label>
            <asp:Label ID="clientNameLabel" runat="server" Font-Bold="True" style="z-index: 1; left: 121px; top: 417px; position: absolute" Text="Client Name"></asp:Label>
            <asp:TextBox ID="userNameTextBox" runat="server" OnTextChanged="UserNameTextBox_CLick" style="z-index: 1; left: 437px; top: 843px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="interventionDateTextBox" runat="server" placeholder="dd/mm/yy" OnTextChanged="InterventionDateTextBox_Click" style="z-index: 1; left: 449px; top: 675px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="LabourHouRequiredTextBox" runat="server" OnTextChanged="LabourHouRequiredTextBox_Click" style="z-index: 1; left: 447px; top: 498px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="costRequiredTextBox" runat="server" OnTextChanged="CostRequiredTextBox_Click" style="z-index: 1; left: 450px; top: 578px; position: absolute"></asp:TextBox>
            <asp:Button ID="interventionSaveButon" runat="server" OnClick="InterventionSaveButon_Click" style="z-index: 1; left: 746px; top: 902px; position: absolute; width: 105px; height: 34px" Text="Save" />
            <asp:Button ID="siteEngineerHomePageButton" runat="server" OnClick="SiteEngineerHomePageButton_Click" style="z-index: 1; left: 742px; top: 972px; position: absolute; width: 251px" Text="Site Engineer Home Page" />
        </div>
    </form>
</body>
</asp:Content>
<%--</html>--%>
