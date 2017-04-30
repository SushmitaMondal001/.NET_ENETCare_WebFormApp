<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeDistrict.aspx.cs" Inherits="ENETCareWebForm.ChangeDistrict" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="UserID" DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
                    <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                    <asp:BoundField DataField="LoginName" HeaderText="LoginName" SortExpression="LoginName" />
                    <asp:BoundField DataField="UserType" HeaderText="UserType" SortExpression="UserType" />
                    <asp:BoundField DataField="DistrictID" HeaderText="DistrictID" SortExpression="DistrictID" />
                    <asp:BoundField DataField="MaxHour" HeaderText="MaxHour" SortExpression="MaxHour" />
                    <asp:BoundField DataField="MaxCost" HeaderText="MaxCost" SortExpression="MaxCost" />
                </Columns>

<HeaderStyle BackColor="#3AC0F2" ForeColor="White"></HeaderStyle>
            </asp:GridView>

             <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ENETCareDatabaseConnectionString2 %>" SelectCommand="SELECT [UserID], [UserName], [LoginName], [UserType], [DistrictID], [MaxHour], [MaxCost] FROM [User] WHERE ([UserType] NOT LIKE '%' + @UserType + '%')">
                 <SelectParameters>
                     <asp:Parameter DefaultValue="Accountant" Name="UserType" Type="String" />
                 </SelectParameters>
             </asp:SqlDataSource>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ENETCareDatabaseConnectionString %>" SelectCommand="SELECT [UserID], [UserName], [LoginName], [DistrictID], [MaxHour], [MaxCost], [UserType] FROM [User] WHERE ([UserType] NOT LIKE '%' + @UserType + '%')">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Accountant" Name="UserType" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>



            <br />
            <br />
            <br />
            <br />
             <asp:Label ID="Label2" runat="server" Text="District Name"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="DistrictName" DataValueField="DistrictName">

            </asp:DropDownList>

       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" Width="93px" OnClick="ButtonSubmit_Click" />

             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ENETCareDatabaseConnectionString %>" SelectCommand="SELECT [DistrictName] FROM [District]"></asp:SqlDataSource>


        </div>
    </form>
</body>
</html>
