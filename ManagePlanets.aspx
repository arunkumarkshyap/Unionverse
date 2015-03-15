<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ManagePlanets.aspx.vb" Inherits="_ManagePlanets" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="cManagePlanets" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="cnt3_wrap">
        <div class="cnt3_hd">
            <h1 class="ch_h1">Accept/Reject Planet</h1>
            <span class="ch_ctrl"></span>
            <div class="cb"></div>
        </div>
        <div class="cnt3_bd">
            <div class="cnt3_cn">
                <asp:Button runat="server" ID="btnAccept" Text="Accept" />
                &nbsp;
                    <asp:Button runat="server" ID="btnReject" Text="Reject" />
                <asp:Label runat="server" ID="lblError" Text=""></asp:Label>
            </div>
        </div>
        <div class="cnt3_ft"></div>
    </div>
</asp:Content>
