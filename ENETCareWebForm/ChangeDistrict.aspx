<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeDistrict.aspx.cs" Inherits="ENETCareWebForm.ChangeDistrict" EnableEventValidation = "false" MasterPageFile="MasterPage.Master" %>


<asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <form id="form1">
    <div>
    
        <br />
        <asp:Label ID="PageNameLabel" runat="server" Font-Size="X-Large" Text="Change District"></asp:Label>
        <br />
        <br />
            <asp:Label ID="errorMessageLabel" runat="server" Style="color:darkred"></asp:Label>
        <br />
        <br />
    
    
    </div>
        <p style="margin-left: 40px">
            <asp:Label ID="userTypeLabel" runat="server" Text="User Type:"></asp:Label>
&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="userTypeValueLabel" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="userNameLabel" runat="server" Text="User Name:"></asp:Label>
&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="userNameValueLabel" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        <p style="margin-left: 40px">
            &nbsp;<asp:Label ID="currentDistrictLabel" runat="server" Text="Current District:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="currentDistrictValueLabel" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            &nbsp;<asp:Label ID="newDistrictLabel" runat="server" Text="New District:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="districtDropDownList" runat="server">
            </asp:DropDownList>
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 320px">
            <asp:Button ID="saveButton" runat="server" Text="Save" Width="165px" OnClick="saveButton_Click" />
        </p>
        <p style="margin-left: 320px">
            <asp:Button ID="CancelButton" runat="server"  Text="Cancel" Width="161px" OnClick="CancelButton_Click" />
        </p>
        <p style="margin-left: 320px">
            <asp:Button ID="BackToHomePageButton" runat="server" Text="Accountant Home Page" OnClick="BackToHomePageButton_Click" />
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
    </form>
    </body>
</asp:Content>