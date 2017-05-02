<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerHomePage.aspx.cs" Inherits="ENETCareWebForm.ManagerHomePage" MasterPageFile="MasterPage.Master" EnableEventValidation = "false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<head>
    <script type = "text/javascript" >
       function preventBack(){window.history.forward();}
        setTimeout("preventBack()", 0);
        window.onunload=function(){null};
    </script>
     
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1">
        <div style="text-align:center">
            <asp:Label ID="managerHomePageLabel" runat="server" Font-Bold="True" Font-Size="X-Large"  Text="Manager Home Page"></asp:Label>
        </div>
        <div>
            <br /> 
        <asp:Label ID="errorMessageLabel" runat="server" Style="color:darkred"></asp:Label>
        <br />
        <br />
    
            <asp:Literal ID="StatusText" runat="server"></asp:Literal>
            <p class="auto-style1">
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="changePasswordButton" runat="server" Font-Bold="False" Font-Size="Medium" Height="59px" Text="Change Password" Width="453px" OnClick="changePasswordButton_Click" />
                &nbsp;</p>
            <p class="auto-style1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="approvedInterventionViewButton0" runat="server" Font-Bold="False" Font-Size="Medium" Height="58px" Text="List of Approved Intervention" Width="457px" OnClick="approvedInterventionViewButton0_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br class="auto-style1" />
                &nbsp;&nbsp;&nbsp;
                <br class="auto-style1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="proposedInterventionViewButton" runat="server" Font-Bold="False" Font-Size="Medium" Height="58px" Text="List of Proposed Intervention" Width="457px" OnClick="proposedInterventionViewButton_Click" />
                <br class="auto-style1" />
                
                <br class="auto-style1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="managerLogoutButton" runat="server" Font-Bold="False" Font-Size="Medium" Height="57px" Text="Logout" Width="456px" style="margin-right: 0px" OnClick="managerLogoutButton_Click" />
                <br class="auto-style1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>

        </div>
     </form>
</body>
</asp:Content>
