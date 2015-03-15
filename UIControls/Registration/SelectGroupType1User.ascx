<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SelectGroupType1User.ascx.vb"
    Inherits="CMSModules_Membership_Controls_SelectGroupType1User" %>
<div class="cnt_cn_pad">
<div class="fltr_bg">
    <span class="fltr_itm">Religious Sanctuaries User:&nbsp;<asp:TextBox runat="server"
        ID="txtUserName"></asp:TextBox></span> <span class="fltr_itm">Galaxy Type:&nbsp;<asp:DropDownList
            runat="server" ID="ddGalaxy">
            <asp:ListItem Text="-- Select --" Value="0"></asp:ListItem>
            <asp:ListItem Text="Baha'i Faith" Value="1"></asp:ListItem>
            <asp:ListItem Text="Christianity" Value="2"></asp:ListItem>
            <asp:ListItem Text="Dharmic (Buddhism, Hinduism, Jainism)" Value="3"></asp:ListItem>
            <asp:ListItem Text="Islam" Value="4"></asp:ListItem>
            <asp:ListItem Text="Judaism" Value="5"></asp:ListItem>
            <asp:ListItem Text="Other Galaxies" Value="6"></asp:ListItem>
            <asp:ListItem Text="Sikhism" Value="7"></asp:ListItem>
        </asp:DropDownList>
        </span><span class="fltr_itm">Zip Code:&nbsp;<asp:TextBox runat="server" ID="txtZipCode"></asp:TextBox></span>
    <span class="btn_orng">
        <asp:LinkButton runat="server" ID="btnSearch" Text="GO"></asp:LinkButton></span>
</div>
</div>
<div class="plst_wrap">
    <asp:Repeater runat="server" ID="rpUsers">
        <ItemTemplate>
            <div class="plst_itm">
                <div class="plst_iimg">
                    <a href="<%#GetLink(CStr(Eval("UserName"))) %>">
                        <img src="<%#GetUserImage(EVal("UserID")) %>" alt="<%#Eval("UserName")%>" /></a>
                </div>
                <div class="plst_inf">
                    <span class="plst_itm_nm"><a href="<%#GetLink(CStr(Eval("UserName"))) %>">
                        <%#Eval("UserName")%></a></span>
                    <%#Eval("About")%><span class="plst_infs"><a href="<%#GetLink(CStr(Eval("UserName"))) %>">Select
                        User</a> </span>
                </div>
                <div class="cb">
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Label runat="server" ID="lblNoRecord" Text="No Record Found."></asp:Label>
    <div class="cb">
    </div>
</div>

