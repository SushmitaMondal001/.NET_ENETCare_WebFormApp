<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientCreationPage.aspx.cs" Inherits="ENETCareWebForm.ClientCreatePage" MasterPageFile="~/MasterPage.Master" EnableEventValidation = false %>

 <asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>--%>
<body>
    <form id="form1">
    <div>
        <br />
    
        <asp:Label ID="PageNameLabel" runat="server" Font-Size="Large" Text="Create Client"></asp:Label>
        <br />
        <br />
    
        <br />
            <asp:Label ID="errorMessageLabel" runat="server"></asp:Label>
        <br />
        <br />
    
    </div>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="clientNameLabel" runat="server" Text="Client Name:"></asp:Label>
&nbsp;
            <asp:TextBox ID="clientNameTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="locationLabel" runat="server" Text="Location:"></asp:Label>
&nbsp;
            <asp:TextBox ID="locationTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        <p style="margin-left: 40px">
            <asp:Label ID="districtLabel" runat="server" Text="District:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="districtNameLabel" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="districtDropDownList" runat="server" Visible="False">
            </asp:DropDownList>
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 320px">
            <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save &amp; Create Client" />
        </p>
        <p style="margin-left: 320px">
            <asp:Button ID="BackToHomePageButton" runat="server" OnClick="BackToHomePageButton_Click" Text="Site Engineer Home Page" />
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
    </form>
</body>
</asp:Content>
<%--</html>--%>
