<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PollsAddEdit.ascx.vb" Inherits="UIControls_PollsAddEdit" %>
<div style="text-align: right">
    <asp:Button runat="server" ID="btnCancel" Text=" << Back" />
</div>
<table>
    <tr style="display:none;">
        <td>Type:
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddParentCategory" AutoPostBack="true">
                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                <asp:ListItem Text="Business" Value="1"></asp:ListItem>
                <asp:ListItem Text="Government" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddBusinessSubCategory" Visible="false">
                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                <asp:ListItem Text="Local matter" Value="1"></asp:ListItem>
                <asp:ListItem Text="National Matter" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddGovernmentsubCategory" Visible="false">
                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                <asp:ListItem Text="Local matter" Value="1"></asp:ListItem>
                <asp:ListItem Text="National Matter" Value="2"></asp:ListItem>
                <asp:ListItem Text="State or Territory Matter" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Question:
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtQuestion" Width="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top">Description:
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="FieldLabel">
            <b>Country:</b>
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddCountry" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddState">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>City:
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Zip Code:
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtZipCode"></asp:TextBox>
        </td>
    </tr>
    <tr style="display:none;">
        <td>Is UnionVersal:
        </td>
        <td>
            <asp:CheckBox runat="server" ID="chkIsUnionversal" />
        </td>
    </tr>
    <tr style="display:none;">
        <td>Is Profit Spending:
        </td>
        <td>
            <asp:CheckBox runat="server" ID="chkIsProfitSpending" />
        </td>
    </tr>
    <tr>
        <td>&nbsp;
        </td>
        <td>
            <asp:Button runat="server" ID="btnSave" Text="Save" />
            <asp:Label runat="server" ID="lblError" Text="" CssClass="err"></asp:Label>
        </td>
    </tr>
    <asp:PlaceHolder runat="server" ID="phAnswers" Visible="false">
        <tr>
            <td>Answer</td>
            <td>
                <asp:TextBox runat="server" ID="txtAnswer" Width="300px"></asp:TextBox>
                <asp:Button ID="btnAnswer" runat="server" Text="Add New Answer" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Repeater runat="server" ID="rpPollOpyion">
                    <HeaderTemplate>
                        <table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblPollOptionID" Text='<%#Eval("PollOptionID")%>' Visible="false"></asp:Label>
                                <asp:TextBox runat="server" ID="txtOptionText" Text='<%#Eval("OptionText") %>' Width="300px"></asp:TextBox></td>
                            <td>
                                <asp:LinkButton runat="server" ID="lbtDelete" Text=" [x]" CommandName="DELETE" CommandArgument='<%#Eval("PollOptionID")%>'></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Button runat="server" ID="btnSaveAll" Text="Save All"></asp:Button>
            </td>
        </tr>
    </asp:PlaceHolder>
</table>


