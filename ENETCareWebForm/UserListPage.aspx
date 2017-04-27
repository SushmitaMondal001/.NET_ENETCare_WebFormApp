<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserListPage.aspx.cs" Inherits="ENETCareWebForm.UserListPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                    <asp:BoundField DataField="UserType" HeaderText="UserType" SortExpression="UserType" />
                    <asp:BoundField DataField="DistrictID" HeaderText="DistrictID" SortExpression="DistrictID" />
                    <asp:BoundField DataField="MaxHour" HeaderText="MaxHour" SortExpression="MaxHour" />
                    <asp:BoundField DataField="MaxCost" HeaderText="MaxCost" SortExpression="MaxCost" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ENETCareDatabaseConnectionString %>" SelectCommand="SELECT [UserName], [UserType], [DistrictID], [MaxHour], [MaxCost] FROM [User] WHERE ([UserType] NOT LIKE '%' + @UserType + '%')">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Accountant" Name="UserType" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
