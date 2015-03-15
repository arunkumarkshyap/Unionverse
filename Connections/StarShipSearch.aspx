<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StarShipSearch.aspx.vb" Inherits="Connections_StarShipSearch" MasterPageFile="~/MasterPage.master" %>
<%@ Register src="~/UIControls/Connection/StarShipSearch.ascx" tagname="StarShipSearch" tagprefix="uc2" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="cpContent">
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">StarShip Search
            </h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc2:StarShipSearch ID="StarShipSearch1" runat="server" />
            </div>
        </div>
        <div class="cnt_ft"></div>
    </div>
    <div class="cb"></div>
</asp:Content>
