<%@ Control Language="VB" AutoEventWireup="false" CodeFile="~/UIControls/UVRaiseShortCuts.ascx.vb"
    Inherits="UIControls_UVRaiseShortCuts" %>
<asp:PlaceHolder runat="server" ID="phSolarSystem">
    <div class="mnu_wrap">
        <div class="mnu_hd">
            <span class="mhd_tit">UV Raise Shortcuts</span>
        </div>
        <div class="mnu_bd">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/uvraise/solarsystemhomepage.aspx"%>">Solar System UV Raise</a></li>
                <li><a href='<%=UIHelper.GetUnionVerseBasePathURL() %>'>UNIonVERSE Home Page</a></li>
            </ul>
        </div>
        <div class="mnu_ft">
        </div>
    </div>
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phUsers">
    <div class="mnu_wrap">
        <div class="mnu_hd">
            <span class="mhd_tit">UV Raise Shortcuts</span>
        </div>
        <div class="mnu_bd">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/uvraise/indhomepage.aspx"%>">UV Raise Home Page</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/uvraise/solarsystemhomepage.aspx"%>">Solar System UV Raise</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/uvraise/uploadresume.aspx"%>">Upload Resume</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/uvraise/UserResume.aspx"%>">View Resume</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/uvraise/uvraisejobs.aspx"%>">Search UV Raise</a></li>
                <li><a href='<%=UIHelper.GetUnionVerseBasePathURL() %>'>UNIonVERSE Home Page</a></li>
            </ul>
        </div>
        <div class="mnu_ft">
        </div>
    </div>
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phCompany">
    <div class="mnu_wrap">
        <div class="mnu_hd">
            <span class="mhd_tit">UV Raise Shortcuts</span>
        </div>
        <div class="mnu_bd">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/uvraise/homepage.aspx"%>">UV Raise Home Page</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/uvraise/myjobpostings.aspx"%>">My Job Postings</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/uvraise/uvraiserequests.aspx"%>">Search UV Raise</a></li>
                <li><a href='<%=UIHelper.GetUnionVerseBasePathURL() %>'>UNIonVERSE Home Page</a></li>
            </ul>
        </div>
        <div class="mnu_ft">
        </div>
    </div>
</asp:PlaceHolder>
