<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Wall.aspx.vb" Inherits="_Main_Wall" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/Social/UserMyPosts.ascx" TagPrefix="uc1" TagName="UserMyPosts" %>
<%@ Register Src="~/UIControls/Social/UserWall.ascx" TagPrefix="uc1" TagName="UserWall" %>



<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="cpContent">
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">Wall
            </h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:UserWall runat="server" ID="UserWall" />
            </div>
        </div>
        <div class="cnt_ft"></div>
    </div>
    <div class="cb"></div>
</asp:Content>
