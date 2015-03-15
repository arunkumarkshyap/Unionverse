<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ManageFeaturedItem.aspx.vb" Inherits="ManageFeaturedItem" %>

<%@ Register Src="UIControls/UNIonVERSITY/FeaturedItems.ascx" TagName="FeaturedItems" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder runat="server" ID="ph1">
                <uc1:FeaturedItems ID="FeaturedItems1" runat="server" FItemTypeID="1" />
                <br />
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="ph2">
                <uc1:FeaturedItems ID="FeaturedItems2" runat="server" FItemTypeID="2" />
                <br />
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="ph3">
                <uc1:FeaturedItems ID="FeaturedItems3" runat="server" FItemTypeID="3" />
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
