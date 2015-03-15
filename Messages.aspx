<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Messages.aspx.vb" Inherits="Messages" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/UserMessages.ascx" TagPrefix="uc1" TagName="UserMessages" %>




<asp:Content runat="server" ID="cpContents" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="cnt3_wrap">
        <div class="cnt3_hd">
            <h1 class="ch_h1">My Messages</h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt3_bd">
            <div class="cnt3_cn">
                <uc1:UserMessages ID="UserMessages1" runat="server" />
            </div>
        </div>
        <div class="cnt3_ft"></div>
    </div>
</asp:Content>
