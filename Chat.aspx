<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Chat.aspx.vb" Inherits="_Chat" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/Chat/Chatting.ascx" TagPrefix="uc1" TagName="Chatting" %>



<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="cpContent">
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">Chat
            </h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:Chatting runat="server" ID="Chatting" />
            </div>
        </div>
        <div class="cnt_ft"></div>
    </div>
    <div class="cb"></div>
</asp:Content>
