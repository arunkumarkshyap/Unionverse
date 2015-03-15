<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GroupType1IndReg.aspx.vb"
    Inherits="GroupType1IndReg" MasterPageFile="~/Logon.master" Title="Planet (Individual) ::: UNIonVERSE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1"  ID="cpGroupType1" runat="server">
    <div class="cRegis">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                <h1 runat="server" id="hGroupName" class="ch_h1"></h1>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                <div class="cnt_cn_pad">
                   <h2>1. <asp:HyperLink runat="server" ID="hlIndividualregistration" Text="Planet I (Individual)"></asp:HyperLink></h2>
                   <h2>2. <asp:HyperLink runat="server" ID="hlIndividualregistration2" Text="Planet II (Individual Sales Agent)"></asp:HyperLink></h2>
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
    </div>
</asp:Content>
