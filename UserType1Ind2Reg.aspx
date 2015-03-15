<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserType1Ind2Reg.aspx.vb"
    Inherits="UserType1Ind2Reg" MasterPageFile="~/Logon.master" EnableEventValidation="false"
    ValidateRequest="false" EnableViewState="true" Title="Planet II (Individual Sales Agent) ::: UNIonVERSE" %>

<%@ Register Src="UIControls/Registration/IndividualUserType2Regis.ascx" TagName="IndividualUserType2Regis"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cpGroupType1" runat="server">
    <div class="cRegis">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                <h1 runat="server" id="hGroupName" class="ch_h1" style="margin-top:13px;">
                </h1>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                <div class="cnt_cn_pad">
                    <uc2:IndividualUserType2Regis ID="IndividualUserType2Regis1" runat="server" Visible="false" />
                    <asp:Label runat="server" ID="lblError" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
    </div>
</asp:Content>
