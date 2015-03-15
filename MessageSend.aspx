<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MessageSend.aspx.vb" ValidateRequest="false" Inherits="_MessageSend" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="UIControls/SendMessage.ascx" TagName="SendMessage" TagPrefix="uc1" %>

<asp:Content runat="server" ID="cpContents" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="cnt3_wrap">
        <div class="cnt3_hd">
            <h1 class="ch_h1">Send Message</h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt3_bd">
            <div class="cnt3_cn">
                <uc1:SendMessage ID="SendMessage1" runat="server" />
            </div>
        </div>
        <div class="cnt3_ft"></div>
    </div>
</asp:Content>
