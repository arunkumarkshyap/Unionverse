<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GetAllUsers.ascx.vb"
    Inherits="UIControls_Registration_GetAllUsers" %>
<div class="MyForum">
    <asp:UpdatePanel runat="server" ID="updUser">
        <ContentTemplate>
        <asp:Label runat="server" ID="lblInfo" ForeColor="Green" Font-Bold="true"></asp:Label>
            <table border="1" cellpadding="4" cellspacing="4" width="100%">
                <tr id="trAdmin" runat="server">
                    <td colspan="5">
                     <b>   Select user Type</b> &nbsp;&nbsp;
                   
                        <asp:DropDownList runat="server" ID="ddlUserType" AutoPostBack="true">
                            <asp:ListItem Value="1">Religious Sanctuary</asp:ListItem>
                            <asp:ListItem Value="2">Planet I</asp:ListItem>
                            <asp:ListItem Value="3">Planet II</asp:ListItem>
                            <asp:ListItem Value="4">Business</asp:ListItem>
                            <asp:ListItem Value="5">Moon</asp:ListItem>
                            <asp:ListItem Value="8">WhiteWholes</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trType" visible="false" runat="server">
                    <td colspan="5">
                        Select user Type &nbsp;&nbsp;
                    
                        <asp:DropDownList runat="server" ID="ddlUserType1" AutoPostBack="true">
                            <asp:ListItem Value="2">Planet I</asp:ListItem>
                            <asp:ListItem Value="3">Planet II</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <asp:Repeater runat="server" ID="rptUsers">
                    <HeaderTemplate>
                        <tr>
                            <th>
                                Name
                            </th>
                            <th>
                                Inionverse ID
                            </th>
                            <th>
                                Email
                            </th>
                            <th>
                                IS Active
                            </th>
                            <th>
                                Change Status
                            </th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("FirstName")%>&nbsp;<%# Eval("LastName")%>
                            </td>
                            <td>
                                <%# Eval("UnionverseId")%>
                            </td>
                            <td>
                                <%# Eval("Email")%>
                            </td>
                            <td>
                                <asp:Literal runat="Server" Text='<%# iif(Eval("Isactive"),"InActive","Active")%>'></asp:Literal>
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="lbtChangeStatus" CommandName="status" CommandArgument='<%# Eval("Userid") %>'
                                    ToolTip='<%# Eval("IsActive") %>' Text="Change Status" style="text-decoration:underline;"></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
