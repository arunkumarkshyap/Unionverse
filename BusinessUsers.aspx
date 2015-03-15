<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BusinessUsers.aspx.vb" Inherits="BusinessUsers"
    MasterPageFile="~/logon.master" ValidateRequest="false" Title="(Business) StarShip's Registration ::: UNIonVERSE" %>


<%@ Register Src="UIControls/Registration/BusinessTypeRegis.ascx" TagName="BusinessTypeRegis" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>

</asp:Content>
<asp:Content ID="cpSchool" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cRegis">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                <h1 class="ch_h1">(Business) StarShip Registration</h1>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                <div class="cnt_cn_pad">
                    <uc1:BusinessTypeRegis ID="BusinessTypeRegis1" runat="server" />
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
    </div>
</asp:Content>
