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
                <asp:GridView ID="clientListGridView"  AutoGenerateColumns="false" runat="server" AllowPaging="True" OnSelectedIndexChanged="clientListGridView_SelectedIndexChanged" PageSize="10"> <%--OnPageIndexChanging="clientListGridView_PageIndexChanging"--%> 
                    <Columns>
                        <asp:TemplateField HeaderText = "Row Number" ItemStyle-Width="100">
                             <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                                <asp:HiddenField runat="server" ID="idHiddenField" Value='<%#Eval("ClientID")%>'/>
                                <asp:Label runat="server" Text='<%#Eval("ClientName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                
            
                        <asp:BoundField DataField="ClientAddress" HeaderText="address" />
                        <asp:BoundField DataField="Intervention" HeaderText="Interventions" />
                        <asp:BoundField DataField="InterventionStatus" HeaderText="Intervention Status" />
                        <%--<asp:CommandField ShowEditButton="true" HeaderText="Change QMI" />--%>
                        <asp:TemplateField>
                              <ItemTemplate>
                                <asp:Button ID="changeQMIButton" runat="server" CommandName="AddToCart" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                  Text="Change QMI" />
                              </ItemTemplate> 
                            </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </p>
        </form>
    </body>
</asp:Content>
