<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Registration.aspx.vb"
    Inherits="_Registration" MasterPageFile="~/logon.master" ValidateRequest="false" Title="Registration ::: UNIonVERSE" %>

<%@ Register src="~/UIControls/Registration/Registration.ascx" tagname="Registration" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cpSchool" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cRegis">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                <h1 class="ch_h1">
                    Join the UNIonVERSE</h1>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                <div class="cnt_cn_pad">
                   <uc1:Registration ID="Registration1" runat="server" DisplayCaptcha="true" />
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
    </div>
</asp:Content>
