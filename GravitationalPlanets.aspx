<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GravitationalPlanets.aspx.vb" Inherits="_GravitationalPlanets" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="~/UIControls/Connection/GravityPlanetsByType.ascx" TagPrefix="uc1" TagName="GravityPlanetsByType" %>



<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="cpContent">
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">Gravitational Planets
            </h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:GravityPlanetsByType runat="server" ID="GravityPlanetsByType" />
            </div>
        </div>
        <div class="cnt_ft"></div>
    </div>
    <div class="cb"></div>
</asp:Content>
