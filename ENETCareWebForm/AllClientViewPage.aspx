<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AllClientViewPage.aspx.cs" Inherits="ENETCareWebForm.AllClientViewPage" EnableEventValidation = "false" %>


<asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <form id="form1" >
            <asp:Label ID="ClientListTitleLabel" runat="server" Font-Size="X-Large" Text="All Client List"></asp:Label>
            <p>
                &nbsp;</p>
            <p style="margin-left: 80px">
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="ErrorMessageLabel" runat="server" Style="color:darkred"></asp:Label>
            </p>
            <p style="margin-left: 80px">
                <asp:Label ID="districtNameLabel" runat="server" Text="District Name:"></asp:Label>
&nbsp;
                <asp:Label ID="districtNameValueLabel" runat="server"></asp:Label>
            </p>
            <p style="margin-left: 80px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:GridView ID="clientListGridView"  AutoGenerateColumns="false" runat="server" AllowPaging="True"  PageSize="5" OnPageIndexChanging="clientListGridView_PageIndexChanging" EnableSortingAndPagingCallbacks="false" > <%----%> 
                    <Columns>
                        <asp:TemplateField HeaderText = "Row Number" ItemStyle-Width="100">
                             <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                                <asp:HiddenField runat="server" ID="clientIDHiddenField" Value='<%#Eval("ClientID")%>'/>
                                <asp:Label ID="clientNameLabel" runat="server" Text='<%#Eval("ClientName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                
            
                        <asp:BoundField DataField="Address" HeaderText="Address" />
    </Columns>
                </asp:GridView>
            </p>
            <p style="margin-left: 80px">
                &nbsp;</p>
            <p style="margin-left: 80px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="siteEngineerHomePageButton" runat="server" Text="Site Engineer Home Page" OnClick="siteEngineerHomePageButton_Click" />
            </p>
            <p style="margin-left: 1080px">
                &nbsp;</p>
        </form>
    </body>
</asp:Content>
