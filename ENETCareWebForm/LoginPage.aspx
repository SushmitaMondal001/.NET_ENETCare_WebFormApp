<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ENET.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
</head>

<body>
    <h1>Login page</h1>
    <%--    <a href="LoginPage.aspx">Login</a> | <a href="ChangePasswordPage.aspx">Change Password</a> --%>
    <form id="form1" runat="server">
        <div>
            <p>Username:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="usernameTextBox" placeholder="Enter Your Username" runat="server" Width="169px" />
            </p>
            <p>Password:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="passwordTextBox" TextMode="Password" placeholder="Enter Your Password" runat="server" Width="169px" />
            </p>
            <asp:Button ID="loginButton" Text="Log In" runat="server" OnClick="loginEventMethod" />          
        </div>
        <p>
            &nbsp;</p>
        <asp:Literal ID="StatusMessage" runat="server"></asp:Literal>
    </form>
</body>
</html>
