<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllClientsViewPage.aspx.cs" Inherits="ENETCareWebForm.AllClientsViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="ClientListTitleLabel" runat="server" Font-Size="Large" Text="All Client List"></asp:Label>
        <p>
            &nbsp;</p>
        <p style="margin-left: 80px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="clientListGridView"  AutoGenerateColumns="false" runat="server" AllowCustomPaging="True" AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText = "Row Number" ItemStyle-Width="100">
                         <ItemTemplate>
                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField><asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="address" HeaderText="address" />
                    <asp:BoundField DataField="interventions" HeaderText="Interventions" />
                    <asp:BoundField DataField="interventionStatus" HeaderText="Intervention Status" />
                    <asp:CommandField ShowEditButton="true" HeaderText="Change QMI" />
                </Columns>
            </asp:GridView>
        </p>
    </form>
</body>
</html>
