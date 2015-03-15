<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MoonRegistration.aspx.vb"
    Inherits="MoonRegistration" MasterPageFile="~/logon.master" ValidateRequest="false" Title="Moon's Registration ::: UNIonVERSE" %>

<%@ Register Src="UIControls/Registration/SchoolRegis.ascx" TagName="SchoolRegis"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cpSchool" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cRegis">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                <h1 class="ch_h1">
                    Moon's Registration</h1>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                <div class="cnt_cn_pad">
                    <uc1:SchoolRegis ID="SchoolRegis1" runat="server" />
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
    </div>
</asp:Content>
