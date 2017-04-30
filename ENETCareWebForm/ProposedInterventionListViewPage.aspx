<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProposedInterventionListViewPage.aspx.cs" Inherits="ENETCareWebForm.ProposedInterventionListViewPage" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="InterventionID" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
            <Columns>
                <asp:BoundField DataField="InterventionID" HeaderText="InterventionID" InsertVisible="False" ReadOnly="True" SortExpression="InterventionID" />
                <asp:BoundField DataField="InterventionTypeID" HeaderText="InterventionTypeID" SortExpression="InterventionTypeID" />
                <asp:BoundField DataField="ClientID" HeaderText="ClientID" SortExpression="ClientID" />
                <asp:BoundField DataField="LabourRequired" HeaderText="LabourRequired" SortExpression="LabourRequired" />
                <asp:BoundField DataField="CostRequired" HeaderText="CostRequired" SortExpression="CostRequired" />
                <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
                <asp:BoundField DataField="InterventionDate" HeaderText="InterventionDate" SortExpression="InterventionDate" />
                <asp:BoundField DataField="InterventionState" HeaderText="InterventionState" SortExpression="InterventionState" />
                <asp:BoundField DataField="ApprovalUserID" HeaderText="ApprovalUserID" SortExpression="ApprovalUserID" />
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                <asp:BoundField DataField="RemainingLife" HeaderText="RemainingLife" SortExpression="RemainingLife" />
                <asp:BoundField DataField="LatestVisitDate" HeaderText="LatestVisitDate" SortExpression="LatestVisitDate" />
            </Columns>

<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
        </asp:GridView>



        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ENETCareDatabaseConnectionString2 %>" SelectCommand="SELECT * FROM [Intervention]"></asp:SqlDataSource>



        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ENETCareDatabaseConnectionString %>" SelectCommand="SELECT [InterventionID], [InterventionTypeID], [ClientID], [LabourRequired], [CostRequired], [UserID], [InterventionDate], [InterventionState], [ApprovalUserID], [Notes], [RemainingLife], [LatestVisitDate] FROM [Intervention]"></asp:SqlDataSource>
    
        <br />
    
        &nbsp;
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Approved</asp:ListItem>
            <asp:ListItem>Cancelled</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        &nbsp;
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" Width="93px" OnClick="ButtonSubmit_Click" />


    </div>  
    </form>
</body>
</html>
