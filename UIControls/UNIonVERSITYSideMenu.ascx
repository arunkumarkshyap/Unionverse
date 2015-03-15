<%@ Control Language="VB" AutoEventWireup="false" CodeFile="~/UIControls/UNIonVERSITYSideMenu.ascx.vb"
    Inherits="UIControls_UNIonVERSITYSideMenu" %>
<script type="text/javascript">
    function mnuCall(id) {
        if (!!id) {
            var smnu = 's' + id;
            if (!!smnu) {
                if (document.getElementById(String(smnu)).style.display == 'block') {
                    document.getElementById(String(smnu)).style.display = 'none';
                    document.getElementById(String(id)).className = 'mnu_xnd';
                }
                else {
                    document.getElementById(String(smnu)).style.display = 'block';
                    document.getElementById(String(id)).className = 'mnu_clp';
                }
            }
        }
    }
</script>
<div class="mnu_wrap">
    <div class="mnu_hd">
        <span class="mhd_tit">Gravity Shortcuts</span>
    </div>
    <div class="mnu_bd">
        <asp:PlaceHolder runat="server" ID="phGroupType1">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/Classroom-Wiki.aspx"%>">Classroom-Wiki</a></li>
            </ul>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/Room411OpenCases.aspx"%>">Room 411 Guidance Open Cases</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/Room411ClosedCases.aspx"%>">Room 411 Guidance Closed Cases</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/UNIonVERSITY30DaysAlert.aspx"%>">UNIonVERSITY 30 Days Alert</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/DocumentLibrary.aspx"%>">Document Library</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/MonthlyPlanet.aspx"%>">Monthly Planet</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & ""%>">UNIonVERSE Home Page</a></li>
            </ul>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phIndividualType1">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/Classroom-Wiki.aspx"%>">Classroom-Wiki</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/Room411Guidance.aspx"%>">Room 411 Guidance</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/DocumentLibrary.aspx"%>">Document Library</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/MonthlyPlanet.aspx"%>">Monthly Planet</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & ""%>">UNIonVERSE Home Page</a></li>
            </ul>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phMasterUVAccount" Visible="false">
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/Room411OpenCases.aspx"%>">Room 411 Guidance Open Cases</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/Room411ClosedCases.aspx"%>">Room 411 Guidance Closed Cases</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UNIonVERSITY/UNIonVERSITY30DaysAlert.aspx"%>">UNIonVERSITY 30 Days Alert</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & ""%>">UNIonVERSE Home Page</a></li>
            </ul>
        </asp:PlaceHolder>
        <ul class="fnd_wrap">
            <div class="cb">
            </div>
        </ul>
    </div>
    <div class="mnu_ft">
    </div>
</div>

