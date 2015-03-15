<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Profile.aspx.vb" Inherits="Profile"
    MasterPageFile="~/MasterPage.master" EnableViewState="true" %>

<%@ Register Src="UIControls/Profile/ShowMapByUserID.ascx" TagName="ShowMapByUserID"
    TagPrefix="uc1" %>
<%@ Register Src="UIControls/Profile/ProfileViews.ascx" TagName="ProfileViews" TagPrefix="uc2" %>
<%@ Register Src="~/UIControls/UserImageListAdd.ascx" TagPrefix="uc1" TagName="UserImageListAdd" %>
<%@ Register Src="~/UIControls/BusinessProductsList.ascx" TagPrefix="uc1" TagName="BusinessProductsList" %>
<%@ Register Src="~/UIControls/BusinessProductsAddEdit.ascx" TagPrefix="uc1" TagName="BusinessProductsAddEdit" %>
<%@ Register Src="~/UIControls/Profile/EditProfileViews.ascx" TagPrefix="uc1" TagName="Regis" %>
<%@ Register Src="~/UIControls/Registration/TerminateAccount.ascx" TagPrefix="uc1"
    TagName="clsAccount" %>
   

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ID="cpContent">
    <link rel="stylesheet" type="text/css" href="../Scripts/Tabs/jquery-ui.css" />
    <script type="text/javascript" src="../Scripts/Tabs/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../Scripts/Tabs/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#tabs").tabs();
        });
    </script>
    <asp:PlaceHolder runat="server" ID="phBusinessProductsAdd">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                <h1 class="ch_h1">
                    Products
                </h1>
                <span class="ch_ctrl"></span>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                <div class="cnt_cn">
                    <uc1:BusinessProductsList runat="server" ID="BusinessProductsList" />
                    <uc1:BusinessProductsAddEdit runat="server" ID="BusinessProductsAddEdit" />
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
        <div class="cb">
        </div>
    </asp:PlaceHolder>
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">
                Member Profile
            </h1>
            <span class="ch_ctrl">
                <asp:LinkButton runat="server" ID="lbtEdit">Edit Profile</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lbtBack" Visible="false">Back</asp:LinkButton></span>
            <div class="cb">
            </div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc2:ProfileViews ID="ProfileViews1" runat="server" />
                <asp:Panel ID="pnlProfile" runat="server" Visible="false">
                
                    <div id="tabs">
                        <ul>
                            <li><a href="#tabs-1">Edit Profile</a></li>
                            <li><a href="#tabs-2">Change Password</a></li>
                            <li><a href="#tabs-3">Terminate Account</a></li>
                        </ul>
                        <div id="tabs-1">
                            <uc1:Regis ID="RegisType1" runat="server" />
                        </div>
                        <div id="tabs-2">
                            Change pasword:
                        </div>
                        <div id="tabs-3">
                            <uc1:clsAccount ID="closeAccount" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
        <div class="cnt_ft">
        </div>
    </div>
    <div class="cb">
    </div>
    <div class="cnt_wrap">
        <div class="cnt_hd">
            <h1 class="ch_h1">
                Location
            </h1>
            <span class="ch_ctrl"></span>
            <div class="cb">
            </div>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:ShowMapByUserID ID="ShowMapByUserID1" runat="server" />
            </div>
        </div>
        <div class="cnt_ft">
        </div>
    </div>
    <div class="cb">
    </div>
    <div class="cnt_wrap">
        <a href="#" id="Picture"></a>
        <div class="cnt_hd">
            <h1 class="ch_h1">
                Pictures</h1>
        </div>
        <div class="cnt_bd">
            <div class="cnt_cn">
                <uc1:UserImageListAdd runat="server" ID="UserImageListAdd" />
                <div class="cb">
                </div>
            </div>
        </div>
        <div class="cnt_ft">
        </div>
    </div>
    <div class="cb">
    </div>
    
</asp:Content>
