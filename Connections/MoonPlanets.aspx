<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MoonPlanets.aspx.vb" Inherits="Connections_MoonPlanets" MasterPageFile="~/MasterPage.master" %>

<%@ Register Src="../UIControls/Connection/MoonPlanets.ascx" TagName="MoonPlanets" TagPrefix="uc1" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="cpContents">
<div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">Planets
            </h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:MoonPlanets ID="MoonPlanets1" runat="server" />
            </div>
        </div>
        <div class="cnt_ft"></div>
    </div>
    <div class="cb"></div>
</asp:Content>
