<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserType1Ind1Reg.aspx.vb" Inherits="UserType1Ind1Reg"
    MasterPageFile="~/Logon.master"  ValidateRequest="false" EnableEventValidation="false" ViewStateEncryptionMode="Never" Title="Planet I (Individual) ::: UNIonVERSE" %>

<%@ Register src="UIControls/Registration/IndividualUserType1Regis.ascx" tagname="IndividualUserType1Regis" tagprefix="uc1" %>
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
                    <uc1:IndividualUserType1Regis ID="IndividualUserType1Regis1" runat="server" Visible="false" />
                    <asp:Label runat="server" ID="lblError" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
    </div>
</asp:Content>
