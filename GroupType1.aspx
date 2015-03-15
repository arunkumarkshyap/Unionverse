<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GroupType1.aspx.vb" Inherits="GroupType1"
    MasterPageFile="~/logon.master" Title="Religious Sanctuary ::: UNIonVERSE" %>

<%@ Register Src="UIControls/Registration/UserType1Regis.ascx" TagName="UserType1Regis"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript" src="Scripts/Tabs/jquery-1.10.2.js"></script>
</asp:Content>   
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cpGroupType1" runat="server">
    <div class="cRegis">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                <h1 class="ch_h1">
                    Religious Sanctuary</h1>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                <div class="cnt_cn_pad">
                    <uc1:UserType1Regis ID="UserType1Regis1" runat="server" />
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
    </div>
</asp:Content>
