<%@ Control Language="VB" AutoEventWireup="false" CodeFile="~/UIControls/ElectronsSideMenu.ascx.vb"
    Inherits="UIControls_ElectronsSideMenu" %>

<script type="text/javascript">
function mnuCall(id)
    {
        if(!!id)
            {                                     
            var smnu = 's' + id;
            if (!!smnu)
                {
                if (document.getElementById(String(smnu)).style.display == 'block')
                    {
                    document.getElementById(String(smnu)).style.display = 'none';
                    document.getElementById(String(id)).className = 'mnu_xnd';
                    }
                else
                    {
                    document.getElementById(String(smnu)).style.display = 'block';
                    document.getElementById(String(id)).className = 'mnu_clp';
                    }
                }
            }
    }
</script>
<div class="mnu_wrap">
    <div class="mnu_hd">
        <span class="mhd_tit">Electrons</span>
    </div>
    <div class="mnu_bd">
<asp:PlaceHolder runat="server" ID="phGroupType1">
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="GT1UConn" onclick="javascript:mnuCall(this.id);">Government</a>
    <ul class="mnu_snav" id="sGT1UConn" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/LocalMatter.aspx"%>">Local Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/StateMatter.aspx"%>">State or Territory Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/NationalMatter.aspx"%>">National Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/UnionversalMatter.aspx"%>">UNIonVERSAL Matter</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="gt1Fleet" onclick="javascript:mnuCall(this.id);">Business</a>
    <ul class="mnu_snav" id="sgt1Fleet" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/LocalMatter.aspx"%>">Local Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/NationalMatter.aspx"%>">National Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/UnionversalMatter.aspx"%>">UNIonVERSAL Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/ProfitSpending.aspx"%>">Profit Spending</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/SearchElectrons.aspx"%>">Search ELECTrons</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/MasterSuggestionForElectrons.aspx"%>">Suggestions for ELECTrons to Master UV Account</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/SuggestionFromPlanets.aspx"%>">Suggestion from Planets</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>

</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phBusinessType">
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="BusGov" onclick="javascript:mnuCall(this.id);">Government</a>
    <ul class="mnu_snav" id="sBusGov" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/LocalPollResults.aspx"%>">Local Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/StatePollResults.aspx"%>">State or Territory Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/NationalPollResults.aspx"%>">National Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/UnionversalPollResults.aspx"%>">UNIonVERSAL Matter Poll Results</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="BusBusiness" onclick="javascript:mnuCall(this.id);">Business</a>
    <ul class="mnu_snav" id="sBusBusiness" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/LocalMatter.aspx"%>">Local Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/NationalMatter.aspx"%>">National Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/UnionversalMatter.aspx"%>">UNIonVERSAL Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/ProfitSpendingPollResults.aspx"%>">Profit Spending Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/SearchElectrons.aspx"%>">Search ELECTrons</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() %>">UNIonVERSE Home Page</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>

</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phGroupType3Moon">
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="MoonGov" onclick="javascript:mnuCall(this.id);">Government</a>
    <ul class="mnu_snav" id="sMoonGov" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/LocalPollResults.aspx"%>">Local Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/StatePollResults.aspx"%>">State or Territory Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/NationalPollResults.aspx"%>">National Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/UnionversalPollResults.aspx"%>">UNIonVERSAL Matter Poll Results</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="MoonBus" onclick="javascript:mnuCall(this.id);">Business</a>
    <ul class="mnu_snav" id="sMoonBus" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/LocalPollResults.aspx"%>">Local Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/NationalPollResults.aspx"%>">National Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/UnionversalPollResults.aspx"%>">UNIonVERSAL Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/ProfitSpendingPollResults.aspx"%>">Profit Spending Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/SearchElectrons.aspx"%>">Search ELECTrons</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL()%>">UNIonVERSE Home Page</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>

 </asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phWhiteWhole">
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="WhiteGov" onclick="javascript:mnuCall(this.id);">Government</a>
    <ul class="mnu_snav" id="sWhiteGov" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/LocalPollResults.aspx"%>">Local Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/StatePollResults.aspx"%>">State or Territory Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/NationalPollResults.aspx"%>">National Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/UnionversalPollResults.aspx"%>">UNIonVERSAL Matter Poll Results</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="WhiteBus" onclick="javascript:mnuCall(this.id);">Business</a>
    <ul class="mnu_snav" id="sWhiteBus" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/LocalPollResults.aspx"%>">Local Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/NationalPollResults.aspx"%>">National Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/UnionversalPollResults.aspx"%>">UNIonVERSAL Matter Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/ProfitSpendingPollResults.aspx"%>">Profit Spending Poll Results</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/SearchElectrons.aspx"%>">Search ELECTrons</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() %>">UNIonVERSE Home Page</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phIndividualType1">
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="Ind1Gov" onclick="javascript:mnuCall(this.id);">Government</a>
    <ul class="mnu_snav" id="sInd1Gov" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/LocalMatter.aspx"%>">Local Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/StateMatter.aspx"%>">State or Territory Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/NationalMatter.aspx"%>">National Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/UnionversalMatter.aspx"%>">UNIonVERSAL Matter</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="Ind1Bus" onclick="javascript:mnuCall(this.id);">Business</a>
    <ul class="mnu_snav" id="sInd1Bus" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/LocalMatter.aspx"%>">Local Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/NationalMatter.aspx"%>">National Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/UnionversalMatter.aspx"%>">UNIonVERSAL Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/ProfitSpending.aspx"%>">Profit Spending</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/SearchElectrons.aspx"%>">Search ELECTrons</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/PlanetsSuggestionforELECTrons.aspx"%>">Sugesstions for ELECTrons</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() %>">UNIonVERSE Home Page</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phIndividualType2">
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="Ind2Gov" onclick="javascript:mnuCall(this.id);">Government</a>
    <ul class="mnu_snav" id="sInd2Gov" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/LocalMatter.aspx"%>">Local Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/StateMatter.aspx"%>">State or Territory Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/NationalMatter.aspx"%>">National Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/UnionversalMatter.aspx"%>">UNIonVERSAL Matter</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>
<div class="dyn_mnu">
 <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="Ind2Bus" onclick="javascript:mnuCall(this.id);">Business</a>
    <ul class="mnu_snav" id="sInd2Bus" style="display: none;">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/LocalMatter.aspx"%>">Local Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/NationalMatter.aspx"%>">National Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/UnionversalMatter.aspx"%>">UNIonVERSAL Matter</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/ProfitSpending.aspx"%>">Profit Spending</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/SearchElectrons.aspx"%>">Search ELECTrons</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/PlanetsSuggestionforELECTrons"%>">Sugesstions for ELECTrons</a></li>
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() %>">UNIonVERSE Home Page</a></li>
    </ul>
 <span class="dyn_mnu_ft"></span>
</div>

</asp:PlaceHolder>

<ul class="fnd_wrap">
    <div class="cb">
   </div>
</ul>
    </div>
    <div class="mnu_ft">
    </div>
</div>

