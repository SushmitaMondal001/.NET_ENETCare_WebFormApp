<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerHomePage.aspx.cs" Inherits="ENETCareWebForm.ManagerHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            <asp:Label ID="managerHomePageLabel" runat="server" Font-Bold="True" Font-Size="X-Large"  Text="Manager Home Page"></asp:Label>
        </div>
        <div>

            <p class="auto-style1">
                <br style="margin-left: 80px" />
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="changePasswordButton" runat="server" Font-Bold="True" Font-Size="Medium" Height="59px" Text="Change Password" Width="453px" OnClick="changePasswordButton_Click" />
                <br class="auto-style1" />
                <br class="auto-style1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="proposedInterventionViewButton" runat="server" Font-Bold="True" Font-Size="Medium" Height="58px" Text="List of Proposed Intervention" Width="457px" OnClick="proposedInterventionViewButton_Click" />
                <br class="auto-style1" />
                <br class="auto-style1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="managerLogoutButton" runat="server" Font-Bold="True" Font-Size="Medium" Height="57px" Text="Logout" Width="456px" style="margin-right: 0px" />
                <br class="auto-style1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>

        </div>
     </form>
</body>
</html>
