<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterventionCreationPage.aspx.cs" Inherits="ENETCareWebForm.InterventionCreationPage" MasterPageFile="~/MasterPage.Master" EnableEventValidation = false %>


<asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>--%>
<body>
    <form id="form1">
        <div style="height: 853px; width: 1450px; margin-left: 50px">

            <p>
            <asp:Label ID="errorMessageLabel" runat="server" Style="color:darkred"></asp:Label>
            </p>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="interventionPageLbel" runat="server" Font-Bold="True" Font-Size="Large" style="width: 244px" Text="Create Intervention"></asp:Label>
            
            <p>
            <asp:Label ID="interventionTypeLabel" runat="server" Font-Bold="True" Text="Intervention Type"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="interventionTypeDropDownList" runat="server" AppendDataBoundItems="true" style="width: 300px; height: 49px;" Visible="True" EnableViewState="true" AutoPostBack="True" OnSelectedIndexChanged="interventionTypeDropDownList_SelectedIndexChanged" >
                <asp:ListItem disabled="disabled">Select Intervention</asp:ListItem>
            </asp:DropDownList>
            </p>
            <p></p>
            <p>
            <asp:Label ID="clientNameLabel" runat="server" Font-Bold="True" Text="Client Name"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="clientNameDropDownList" runat="server" AppendDataBoundItems="true" style="width: 333px" Visible="True" EnableViewState="true">
                <asp:ListItem disabled="disabled">Select Client</asp:ListItem>
            </asp:DropDownList>
            </p>
            <p></p>
            <p>
            <asp:Label ID="labourHourRequiredLabel" runat="server" Font-Bold="True" Text="Labour Hour Required"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="labourHourRequiredTextBox" runat="server" ></asp:TextBox>
            </p>
            <p></p>
            <p>
            <asp:Label ID="costRequiredLabel" runat="server" Font-Bold="True" Text="Cost Required"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="costRequiredTextBox" runat="server" OnTextChanged="costRequiredTextBox_Click"></asp:TextBox>
            </p>
            <p></p>
            <p>
            <asp:Label ID="interventionDateLabel" runat="server" Font-Bold="True"  Text="Intervention Date"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="interventionDateTextBox" runat="server" placeholder="YYYY/MM/DD" ></asp:TextBox>
            </p>
            <p></p>
            <p>
            <asp:Label ID="interventionStateLabel" runat="server" Font-Bold="True" Text="Intervention State"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="interventionStateDropDownList" runat="server" style="width: 231px" Visible="True" EnableViewState="true">
                <asp:ListItem Value="1" Text="Proposed"></asp:ListItem>
                <asp:ListItem Value="2" Text="Approved"></asp:ListItem>
                <asp:ListItem Value="3" Text="Completed"></asp:ListItem>
                
            </asp:DropDownList>
            </p>
            <p></p>
            <p>
            <asp:Label ID="userNameLabel" runat="server" Font-Bold="True" Text="User Name"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="userNameTextLabel" runat="server" style="width: 100px; margin-top: 20px"></asp:Label>      
            </p>
            
     
            <p>
            <asp:Button ID="interventionSaveButon" runat="server" OnClick="InterventionSaveButon_Click" style="width: 105px; height: 34px" Text="Save" />
            </p>
            <p>
            <asp:Button ID="siteEngineerHomePageButton" runat="server" OnClick="SiteEngineerHomePageButton_Click" style="width: 251px" Text="Site Engineer Home Page" />
            </p>
        </div>
    </form>
</body>
</asp:Content>
<%--</html>--%>
