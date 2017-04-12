<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswordPage.aspx.cs" Inherits="ENET.Change_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password Page</title>
</head>

<body>
    <h1>Change Password page</h1>
<%--    <a href="LoginPage.aspx">Login</a> | <a href="ChangePasswordPage.aspx">Change Password</a> --%>
    <form id="form1" runat="server">
        <div>
            <p>Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="usernameTextBox" placeholder="Enter Your username" runat="server" Width="169px" />
            </p>
            <p>Previous Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="passwordTextBox" TextMode="Password" placeholder="Enter Your Password" runat="server" Width="169px" />
            </p>
            <p>New Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="newPasswordTextBox" TextMode="Password" placeholder="Enter Your New Password" runat="server" Width="169px" />
            </p>
            <p>Repeat Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
            <asp:TextBox ID="repeatPasswordTextBox" TextMode="Password" placeholder="Enter Your Password Again" runat="server" Width="169px" />
            </p>
            <asp:Button ID="confirmButton" Text="Confirm" runat="server" OnClick="confirmEventMethod" />          
        </div>
    </form>
</body>
</html>
