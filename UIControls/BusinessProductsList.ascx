<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BusinessProductsList.ascx.vb" Inherits="UIControls_BusinessProductsList" %>

<div class="btn_holder">
        <span class="btn_move" style="">
             <asp:LinkButton ID="lbtAddNew" runat="server" Text="Add New" EnableViewState="true"></asp:LinkButton></span></div>
<asp:Repeater runat="server" ID="rpProductList">
    <HeaderTemplate>
        <table class="CartContentTable" width="100%" cellspacing="0">
            <tr>
                <th></th>
                <th align="left">Product Name</th>
                <th align="right">Price (UNI)</th>
                <th>Action</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td valign="top" width="55px" align="left"><img src='<%#GetProductImage(Eval("Image1")) %>' alt='<%#Eval("ProductTitle") %>' width="50"/></td>
            <td valign="top"align="left"><%#Eval("ProductTitle") %></td>
            <td valign="top" width="60px" style="text-align:right;"><%#Eval("CurrentPrice") %></td>
            <td valign="top" width="90px" align="center">
                <asp:LinkButton runat="server" ID="lbtEdit" Text="Edit" CommandName="EDIT" CommandArgument='<%#Eval("BusinessProductID")%>'></asp:LinkButton>
                &nbsp;|&nbsp;
                <asp:LinkButton runat="server" ID="lbtDelete" Text="Delete" CommandName="DELETE" CommandArgument='<%#Eval("BusinessProductID")%>'></asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
