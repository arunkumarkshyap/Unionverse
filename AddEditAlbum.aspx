<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="AddEditAlbum.aspx.vb" Inherits="AddEditAlbum" EnableViewState="true" %>

<%@ Register Src="~/UIControls/Album/AddEditAlbum.ascx" TagName="AddPhotos" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">
                Add/Edit Album Information
            </h1>
            <span class="ch_ctrl">
               
                <div class="cb">
                </div>
            </span>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:AddPhotos runat="server" ID="AddPhotos" />
            </div>
        </div>
        <div class="cnt_ft">
        </div>
    </div>
    <div class="cb">
    </div>
</asp:Content>
