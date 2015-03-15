<%@ Page Language="VB" AutoEventWireup="false" CodeFile="StarShipVouager.aspx.vb" Inherits="_StarShipVouager" MasterPageFile="~/MasterPage.master" %>



<%@ Register src="UIControls/Connection/StarshipVoyager.ascx" tagname="StarshipVoyager" tagprefix="uc1" %>



<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="cpContent">
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">StarShip Vouager
            </h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:StarshipVoyager ID="StarshipVoyager1" runat="server" />
            </div>
        </div>
        <div class="cnt_ft"></div>
    </div>
    <div class="cb"></div>
</asp:Content>
