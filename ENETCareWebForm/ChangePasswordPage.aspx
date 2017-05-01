<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswordPage.aspx.cs" Inherits="ENET.Change_Password" MasterPageFile="MasterPage.Master" EnableEventValidation = "false" %>

<asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <title>Change Password Page</title>

    <%--    <a href="LoginPage.aspx">Login</a> | <a href="ChangePasswordPage.aspx">Change Password</a> --%>
    <form id="form1">
        
    <h1>Change Password page</h1>
        <br />
        
    <asp:label runat="server" ID="errorMessage"></asp:label>
        <br />
        <br />
        <div>
            <p>Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="userNameLabel" runat="server"></asp:Label>
            </p>
            <p>Previous Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="passwordTextBox" TextMode="Password" placeholder="Enter Your Password" runat="server" Width="169px" />
            </p>
            <p>New Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="newPasswordTextBox" TextMode="Password" placeholder="Enter Your New Password" runat="server" Width="169px" />
            </p>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="confirmButton" Text="Confirm" runat="server" OnClick="confirmEventMethod" />          
        </div>
    </form>
</body>
</asp:Content>
