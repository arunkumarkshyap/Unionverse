<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BOrderViewCart.ascx.vb" Inherits="UIControls_BOrderViewCart" %>
<asp:Repeater runat="server" ID="rpOrderList">
    <HeaderTemplate>
        <table>
            <tr>
                <td></td>
                <td>Product Name</td>
                <td>Quantity</td>
                <td>Price</td>
                <td>Line total</td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:LinkButton runat="server" ID="lbtDelet" Text=" [x] " CommandName="DELETE" CommandArgument='<%#Eval("BOrderDetailID") %>'></asp:LinkButton></td>
            <td><%#Eval("ProductTitle") %></td>
            <td>
                <asp:TextBox runat="server" ID="txtQuantity" Text='<%#Eval("Quantity")%>'></asp:TextBox></td>
            <td><%#Eval("Price") %></td>
            <td><%# (CDBl(Eval("Quantity")) * CDbl(Eval("Price"))) %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<table>
    <tr>
        <td>Order Total:</td>
        <td>
            <asp:Label runat="server" ID="lblOrderTotal" Text=""></asp:Label></td>
    </tr>
</table>
<asp:Button runat="server" ID="btnUpdate" Text="Update Cart" />&nbsp;
<asp:Button runat="server" ID="btnContinue" Text="Continue" />
<asp:Label runat="server" ID="lblError" Text="" CssClass="err"></asp:Label>