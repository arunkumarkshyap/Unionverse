<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Message.aspx.vb" Inherits="_Message" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="UIControls/MessageView.ascx" TagName="MessageView" TagPrefix="uc1" %>
<asp:Content runat="server" ID="cpContents" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="cnt3_wrap">
        <div class="cnt3_hd">
            <h1 class="ch_h1">Message</h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt3_bd">
            <div class="cnt3_cn">
                <uc1:MessageView ID="MessageView1" runat="server" />
            </div>
        </div>
        <div class="cnt3_ft"></div>
    </div>
</asp:Content>
