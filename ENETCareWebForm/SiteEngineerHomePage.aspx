<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteEngineerHomePage.aspx.cs" Inherits="ENETCareWebForm.SiteEnigeerHomePage" MasterPageFile="~/MasterPage.Master" EnableEventValidation = false %>

<asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head >
    <title></title>    
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: small;
            text-align: left;
        }
        .auto-style3 {
            font-size: xx-large;
            text-align: left;
        }
    </style>
         <script type = "text/javascript" >
       function preventBack(){window.history.forward();}
        setTimeout("preventBack()", 0);
        window.onunload=function(){null};
    </script>
     
</head>
    <body>
    <form id="form1" >   
        <div class="auto-style1">
            <p style="margin-left: 40px">
            <strong style="margin-left: 40px"><span class="auto-style3">SiteEngineer Home Page<br />
            <br />
            <asp:Literal ID="StatusText" runat="server"></asp:Literal>
            </span><span class="auto-style2"><br />
            </span></strong>
            <br />
            <strong><span class="auto-style2">
            <asp:Button ID="createNewClientButton" runat="server" Height="31px" Text="Create New Client" Width="232px" OnClick="createNewClientButton_Click" />
&nbsp;<br />
                <br />
            <asp:Button ID="viewListOfClientsButton" runat="server" Height="30px" Text="View List of Clients" Width="232px" OnClick="viewListOfClientsButton_Click" />
&nbsp;<br />
                <br />
            <asp:Button ID="createNewInterventionButton" runat="server" Height="27px" Text="Create New Intervention" Width="230px" OnClick="createNewInterventionButton_Click" />
                <br />
            <br />
            <asp:Button ID="checkOldInterventionButton" runat="server" Height="29px" style="margin-top: 6px" Text="Check Old Interventions" Width="233px" OnClick="checkOldInterventionButton_Click" />
            <br />
&nbsp;<br />
            <br />
            &nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="changePasswordButton" runat="server" Text="Change Password" style="margin-left: 0px" OnClick="changePasswordButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="siteEngineerlogoutButton" runat="server" Text="Logout" OnClick="siteEngineerlogoutButton_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            </span></strong>
            </p>
        </div>
        <p>
            &nbsp;</p>
        <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    </form>
</body>
</asp:Content>
<%--</html>--%>
