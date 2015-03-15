<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Registration-Type.aspx.vb"
    Inherits="Registration_Type" MasterPageFile="~/logon.master" ValidateRequest="false" Title="Registration Type ::: UNIonVERSE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cpSchool" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="cRegis">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                <h1 class="ch_h1">
                    Select One:</h1>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                <div class="cnt_cn_pad">
                    <table>
                        <tr>
                            <td>
                                <h3>1. <a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/SelectGroup.aspx" %>">Planet (Individual)</a></h3>
                                <h3>2. <a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/GroupType1.aspx" %>">Solar System (Religious Sanctuary)</a></h3>
                                <h3>3. <a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/BusinessUsers.aspx" %>">StarShip (Business)</a></h3>
                                <h3>4. <a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/MoonRegistration.aspx" %>">Moon (School, Media, Government, Group(General))</a>
                                <br /><small style="font-size:10px; font-weight:normal;">*Group(General) is where you can create an account surrounding a common cause, issue or activity to organize.</small>
                                </h3>
                                <h3>5. <a href="<%=UIHelper.GetWhiteWholesPathURL() & "/grouptype4.aspx" %>">WhiteWhole (Charity, Non-Profit)</a></h3>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
    </div>
</asp:Content>
