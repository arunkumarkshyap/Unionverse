<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdministratorsList.ascx.vb"
    Inherits="CMS_AdministratorsList" %>
<%@ Register Src="~/Admin/AdminControls/PagingFooter2.ascx" TagName="pagingFooter" TagPrefix="UC4" %>
<span class="subheading2">Accounts List</span>
<div class="cnt_wrap">
    <p>
        <asp:LinkButton ID="lbtnadd" runat="server" Text="+ Create Account"></asp:LinkButton>
    </p>
    <div align="right" style="padding-right: 10px; display:none;">
        <asp:PlaceHolder runat="server" ID="phPaging"><b>Showing:</b>&nbsp;<asp:Label ID="lblViewing"
            runat="server">
        </asp:Label>&nbsp;<b>Total Records:</b>&nbsp;<asp:Label ID="lblTotleRecords" runat="server">
        </asp:Label>
        </asp:PlaceHolder>
    </div>
    <asp:DataGrid ID="dgAdministrators" runat="server" AllowPaging="false" AllowSorting="true"
        AutoGenerateColumns="false" CssClass="datatable" GridLines="none" Width="100%">
        <ItemStyle CssClass="row0" />
        <HeaderStyle CssClass="rsheader" />
        <AlternatingItemStyle CssClass="altrow" />
        <Columns>
            <asp:TemplateColumn HeaderText="Name" SortExpression="Name">
                <HeaderStyle HorizontalAlign="left" />
                <ItemStyle HorizontalAlign="left" Width="20%"/>
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
               <asp:TemplateColumn HeaderText="&lt;nobr&gt;Username&lt;/nobr&gt;" SortExpression="Username">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="20%" />
                <ItemTemplate>
                    <asp:Label ID="lblUsername" runat="server" Text='<%#Eval("Username")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Email" SortExpression="Email" ItemStyle-Width="50%">
                <ItemTemplate>
                    <asp:Label ID="lblEmail1" runat="server" Text='<%# Eval("Email1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
         
            <asp:TemplateColumn HeaderText="Actions">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <nobr>
                                    <asp:LinkButton ID="lbtEdit" runat="server" CommandName="Edit" CommandArgument='<%#Bind("AdministratorID")%>'
                                        Text="Edit"></asp:LinkButton>
                                     &nbsp;&nbsp;|&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbtDelete" runat="server" CommandName="Delete" CommandArgument='<%#Bind("AdministratorID")%>'
                                        Text="Delete"></asp:LinkButton>                                         
                                        
                                        <%--<asp:LinkButton ID="lblView" runat="server" CommandName="View" CommandArgument='<%#Bind("EmployeeID")%>'
                                        Text="View"></asp:LinkButton>--%>
                                </nobr>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
    <asp:Label ID="lblnorecord" runat="server" Font-Bold="true" Text="No record available..."></asp:Label>
    <br />
    <UC4:pagingFooter ID="pagingFooter1" runat="server" />
</div>