<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BOrderPayments.ascx.vb" Inherits="UIControls_BOrderPayments" %>
<asp:Repeater runat="server" ID="rpOrderList">
    <HeaderTemplate>
        <table>
            <tr>
                <td>Product Name</td>
                <td>Quantity</td>
                <td>Price</td>
                <td>Line total</td>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%#Eval("ProductTitle") %></td>
            <td><%#Eval("Quantity")%></td>
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
    <tr>
        <td>UNI Available:</td>
        <td>
            <asp:Label runat="server" ID="lblUniCount" Text=""></asp:Label></td>
    </tr>
</table>

<asp:Button runat="server" ID="btnMakePayment" Text="Make Payment" />
<asp:Label runat="server" ID="lblError" Text="" CssClass="err"></asp:Label>