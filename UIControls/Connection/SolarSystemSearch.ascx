<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SolarSystemSearch.ascx.vb"
    Inherits="UIControls_SolarSystemSearch" %>
<div class="cnt_cn_pad">
    <div class="fltr_bg">
        <span class="fltr_itm" style="float:left;">Solar System Name:&nbsp;<asp:TextBox runat="server" Width="330px" ID="txtUserName"></asp:TextBox></span>
        <span class="btn_orng" style="float:left; margin-top:5px;"><asp:LinkButton runat="server" ID="btnSearch" Text="Search"></asp:LinkButton></span>
    <div style="clear:both;"></div>
    </div>
</div>
<div class="pbox_wrap">
    <asp:Repeater runat="server" ID="rpPlanets">
        <ItemTemplate>
            <div class="pbox_itm">
                <div class="pbox_itm_cnt">
                    <%#GetUserHTML(CInt(Eval("UserID")))%>
                </div>
                <div class="pbox_itm_ft">
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Label runat="server" ID="lblNoRecord" Text="No Solar System" Visible="false"></asp:Label>
    <div class="cb">
    </div>
</div>
