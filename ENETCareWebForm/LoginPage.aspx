<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ENET.Login"  MasterPageFile="~/MasterPage.Master" %>


 <asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
         <script type = "text/javascript" >
       function preventBack(){window.history.forward();}
        setTimeout("preventBack()", 0);
        window.onunload=function(){null};
    </script>
     
               
    <div>

        <h1>Login page</h1>

        
        <asp:Label ID="StatusMessage" runat="server" Style="color:darkred"></asp:Label>

        
        <br />
        <br />
        <p>
            Username:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="userNameTextBox" placeholder="Enter Your Username" runat="server" Width="169px" />
        </p>
        <p>
            Password:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="passwordTextBox" TextMode="Password" placeholder="Enter Your Password" runat="server" Width="169px" />
        </p>
        <asp:Button ID="loginButton" Text="Log In" runat="server" OnClick="loginEventMethod" Width="59px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <p>
            &nbsp;
        </p>
    </div>
     </asp:Content>


