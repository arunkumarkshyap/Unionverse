<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="UserListing.aspx.vb" Inherits="UserListing" %>

<%@ Register Src="~/UIControls/Registration/GetAllUsers.ascx" TagPrefix="uc1" TagName="clsAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:PlaceHolder runat="server" ID="phBusinessProductsAdd">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                <h1 class="ch_h1">
                    User Listing
                </h1>
                <span class="ch_ctrl"></span>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                <div class="cnt_cn">
                    <uc1:clsAccount runat="server" ID="Userlist" />
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
        <div class="cb">
        </div>
    </asp:PlaceHolder>
</asp:Content>
