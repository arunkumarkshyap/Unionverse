<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Moons.aspx.vb" Inherits="Connections_Moons" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/Connection/Moons.ascx" TagName="Moons" TagPrefix="uc1" %>

<asp:Content runat="server" ID="cpContents" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">Moons
            </h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:Moons ID="Moons1" runat="server" />
            </div>
        </div>
        <div class="cnt_ft"></div>
    </div>
    <div class="cb"></div>
</asp:Content>
