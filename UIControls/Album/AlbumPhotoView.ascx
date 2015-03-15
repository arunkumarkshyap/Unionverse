<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AlbumPhotoView.ascx.vb"
    Inherits="UIControls_Album_AlbumPhotoView" %>
<table width="400px" align="center" height="350px" bgcolor="silver">
    <tr align="center">
        <td>
            <asp:Label ID="lableImageDetail" runat="server" ForeColor="#000000" />
        </td>
    </tr>
    <tr align="center">
        <td>
            <asp:Image runat="server" ID="image1" Height="250" Width="300" />
        </td>
    </tr>
    <tr align="center">
        <td>
            <asp:Button ID="buttonPrev" runat="Server" Text="Previous" Width="80px" />
            <asp:Button ID="buttonPlay" runat="server" Text="Play" Width="80px" />
            <asp:Button ID="buttonNext" runat="Server" Text="Next" Width="80px" />
        </td>
    </tr>
</table>
<ajaxToolkit:SlideShowExtender ID="slideShowExtender1" runat="Server" TargetControlID="image1"
    ImageDescriptionLabelID="lableImageDetail" Loop="true" AutoPlay="true" StopButtonText="Stop"
    PlayButtonText="Play" NextButtonID="buttonNext" PreviousButtonID="buttonPrev"
    PlayButtonID="buttonPlay" SlideShowServiceMethod="GetSlides" />
