<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="QMIEditPage.aspx.cs" Inherits="ENETCareWebForm.QMIEditPage" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
    <form id="form1">
    <div>
    
        <br />
            <asp:Label ID="errorMessageLabel" runat="server" Style="color:darkred"></asp:Label>
        <br />
        <br />
    
        <asp:Label ID="PageNameLabel" runat="server" Font-Size="X-Large" Text="Edit QMI"></asp:Label>
        <br />
        <br />
    
    </div>
        <p style="margin-left: 40px">
            <asp:Label ID="interventionTypeLabel" runat="server" Text="Intervention Type:"></asp:Label>
&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="InterventionTypeValueLabel" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="clientNameLabel" runat="server" Text="Client Name:"></asp:Label>
&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="clientNameValueLabel" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        <p style="margin-left: 40px">
            &nbsp;<asp:Label ID="labourRequiredLabel" runat="server" Text="Labour Required:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="laboreRequiredValueLabel" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            &nbsp;<asp:Label ID="costRequiredLabel" runat="server" Text="Cost Required:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="costRequiredValueLabel" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            &nbsp;<asp:Label ID="interventionStatusLabel" runat="server" Text="Intervention Status:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="interventionStatusValueLabel" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            &nbsp;<asp:Label ID="interventionDateLabel" runat="server" Text="Intervention Date:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="interventionDateValueLabel" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="lastEditDateLabel" runat="server" Text="Last Edit Date:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lastEditDateValueLabel" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="uderNameLabel" runat="server" Text="Intervention Creator:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="userNameValueLabel" runat="server"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            &nbsp;<asp:Label ID="notesLabel" runat="server" Text="Notes:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="notesTextBox" runat="server" TextMode="MultiLine" Height="112px" Width="464px"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="remainingLifeLabel" runat="server" Text="Remaining Life:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="remainingLifeTextBox" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="%"></asp:Label>
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 40px">
            &nbsp;</p>
        <p style="margin-left: 320px">
            <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" Width="165px" />
        </p>
        <p style="margin-left: 320px">
            <asp:Button ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Cancel" Width="161px" />
        </p>
        <p style="margin-left: 320px">
            <asp:Button ID="BackToHomePageButton" runat="server" OnClick="BackToHomePageButton_Click" Text="Site Engineer Home Page" />
        </p>
        <p style="margin-left: 40px">
            &nbsp;</p>
    </form>
</body>
</asp:Content>
