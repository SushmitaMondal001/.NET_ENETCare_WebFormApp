<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserListPage.aspx.cs" Inherits="ENETCareWebForm.UserListPage" EnableEventValidation = "false" MasterPageFile="MasterPage.Master" %>


<asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <form id="form1" >
            <asp:Label ID="userListTitleLabel" runat="server" Font-Size="X-Large" Text="Site Engineer and Manager List"></asp:Label>
            <p>
                &nbsp;</p>
            <p style="margin-left: 80px">
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="ErrorMessageLabel" runat="server" Style="color:darkred"></asp:Label>
            </p>
            <p style="margin-left: 80px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="userListGridView"  AutoGenerateColumns="false" runat="server" AllowPaging="True" OnSelectedIndexChanged="userListGridView_SelectedIndexChanged" PageSize="5" OnPageIndexChanging="userListGridView_PageIndexChanging" EnableSortingAndPagingCallbacks="false" > <%----%> 
                    <Columns>
                        <asp:TemplateField HeaderText = "Row Number" ItemStyle-Width="100">
                             <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Name">
                        <ItemTemplate>
                                <asp:HiddenField runat="server" ID="userIDHiddenField" Value='<%#Eval("UserID")%>'/>
                                <asp:Label ID="userNameLabel" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="User Role">
                        <ItemTemplate>
                                <%--<asp:HiddenField runat="server" ID="userTypeHiddenField" Value='<%#Eval("UserType")%>'/>--%>
                                <asp:Label ID="userTypeLabel" runat="server" Text='<%#Eval("UserType")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>              
            
                        <%--<asp:BoundField ID="userType" DataField="UserType" HeaderText="User Role" />--%>

                        <asp:TemplateField HeaderText="District">
                        <ItemTemplate>
                                <asp:HiddenField runat="server" ID="districtIDHiddenField" Value='<%#Eval("DistrictID")%>'/>
                                <asp:Label runat="server" Text='<%#Eval("DistrictName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:ButtonField Text="Change District" CommandName="Select" ItemStyle-Width="150" />
                       </Columns>
                </asp:GridView>
            </p>
            <p style="margin-left: 80px">
                &nbsp;</p>
            <p style="margin-left: 80px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="accountantHomePageButton" runat="server" Text="Accountant Home Page" OnClick="accountantHomePageButton_Click"/>
            </p>
            <p style="margin-left: 1080px">
                &nbsp;</p>
        </form>
    </body>
</asp:Content>