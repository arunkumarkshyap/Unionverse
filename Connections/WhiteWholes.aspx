<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WhiteWholes.aspx.vb" Inherits="Connections_WhiteWholes" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/Connection/WhiteWholes.ascx" TagName="WhiteWholes" TagPrefix="uc1" %>

<asp:Content runat="server" ID="cpContents" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">White Wholes
            </h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:WhiteWholes ID="WhiteWholes1" runat="server" />
            </div>
        </div>
        <div class="cnt_ft"></div>
    </div>
    <div class="cb"></div>
</asp:Content>
