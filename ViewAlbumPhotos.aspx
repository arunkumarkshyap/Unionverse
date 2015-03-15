<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="ViewAlbumPhotos.aspx.vb" Inherits="ViewAlbumPhotos" %>

<%@ Register Src="~/UIControls/Album/AlbumPhotoView.ascx" TagName="ViewPhoto" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">
                View Album Gallery
            </h1>
            <span class="ch_ctrl">
             <asp:LinkButton runat="server" ID="lbtBack" Text="Back">Back</asp:LinkButton>
                <div class="cb">
                </div>
            </span>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:ViewPhoto runat="server" ID="ViewPhoto1" />
            </div>
        </div>
        <div class="cnt_ft">
        </div>
    </div>
    <div class="cb">
    </div>
</asp:Content>
