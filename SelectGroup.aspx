<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SelectGroup.aspx.vb" Inherits="SelectGroup"
    MasterPageFile="~/Logon.master" Title=" Select Religious Sanctuary ::: UNIonVERSE" %>

<%@ Register Src="UIControls/Registration/SelectGroupType1User.ascx" TagName="SelectGroupType1User"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cpSchool" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cRegis">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                <h1 class="ch_h1" style="margin-top:13px;">
                    Religious Sanctuary<br />Select</h1>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                    <uc1:SelectGroupType1User ID="SelectGroupType1User1" runat="server" />
            </div>
            <div class="cnt_ft">
            </div>
        </div>
    </div>
</asp:Content>
