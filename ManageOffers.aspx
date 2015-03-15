<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ManageOffers.aspx.vb" Inherits="ManageOffers" %>

<%@ Register Src="~/UIControls/UNIonVERSITY/OfferAddEdit.ascx" TagPrefix="uc1" TagName="OfferAddEdit" %>
<%@ Register Src="~/UIControls/UNIonVERSITY/OfferList.ascx" TagPrefix="uc1" TagName="OfferList" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:OfferAddEdit runat="server" ID="OfferAddEdit" />
        <uc1:OfferList runat="server" ID="OfferList" />
    </div>
    </form>
</body>
</html>
