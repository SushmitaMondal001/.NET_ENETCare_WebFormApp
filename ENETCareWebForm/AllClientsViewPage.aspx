<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllClientsViewPage.aspx.cs" Inherits="ENETCareWebForm.AllClientsViewPage" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <form id="form1" >
            <asp:Label ID="ClientListTitleLabel" runat="server" Font-Size="X-Large" Text="All Client List"></asp:Label>
            <p>
                &nbsp;</p>
            <p style="margin-left: 80px">
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="ErrorMessageLabel" runat="server"></asp:Label>
            </p>
            <p style="margin-left: 80px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="clientListGridView"  AutoGenerateColumns="false" runat="server" AllowCustomPaging="True" AllowPaging="True">
                    <Columns>
                        <asp:TemplateField HeaderText = "Row Number" ItemStyle-Width="100">
                             <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField><asp:BoundField DataField="clientName" HeaderText="Name" />
                        <asp:BoundField DataField="clientAddress" HeaderText="address" />
                        <%--<asp:BoundField DataField="intervention" HeaderText="Interventions" />--%>
                        <%--<asp:BoundField DataField="interventionStatus" HeaderText="Intervention Status" />--%>
                        <asp:CommandField ShowEditButton="true" HeaderText="Change QMI" />
                    </Columns>
                </asp:GridView>
            </p>
        </form>
    </body>
</asp:Content>
