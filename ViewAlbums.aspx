<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ViewAlbums.aspx.vb" Inherits="ViewAlbums" %>

<%@ Register Src="~/UIControls/Album/ViewAlbum.ascx" TagName="ViewAlbum" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">
                View Albums
            </h1>
            <span class="ch_ctrl">
            <asp:LinkButton runat="server" ID="lbtBack" Text="Back">Add Album</asp:LinkButton>
                <div class="cb">
                </div>
            </span>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:ViewAlbum runat="server" ID="ViewAlbum1" />
            </div>
        </div>
        <div class="cnt_ft">
        </div>
    </div>
    <div class="cb">
    </div>
</asp:Content>
