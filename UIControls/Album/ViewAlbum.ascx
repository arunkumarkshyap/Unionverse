<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewAlbum.ascx.vb" Inherits="UIControls_Album_ViewAlbum" %>
<style>
    article
    {
        width: 80%;
        margin: auto;
        margin-top: 10px;
    }
    
    
    .thumbnail
    {
        height: 100px;
        margin: 10px;
        border: 2px solid black !important;
    }
    #result div
    {
        float: left;
    }
</style>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left">
            <asp:DataList ID="grdViewAlbum" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                Width="100%" border="0" BorderColor="white" CssClass="griditem" PageSize="10">
                <ItemTemplate>
                    <table style="border: 1px solid gray;">
                        <tr>
                            <td align="center">
                                <asp:LinkButton runat="server" ID="lbtEdit" Text="Edit" Font-Bold="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href='viewalbumphotos.aspx?albumid=<%# Eval("albumid") %>'>
                                    <asp:Image CssClass="thumbnail" runat="server" ID="img1" ImageUrl='<%# GetImage(Convert.ToString( Eval("Image")))%>' /></a>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label runat="server" Text='<%#Eval("AlbumName")%>' Font-Bold="true" ForeColor="Gray"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    </div>
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
