<%@ Control Language="VB" AutoEventWireup="false" CodeFile="~/UIControls/GravitySideMenu.ascx.vb"
    Inherits="UIControls_GravitySideMenu" %>
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
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet1.aspx"%>">Planet I users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet2.aspx"%>">Planet II users</a></li>

            </ul>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/SolarSystem.aspx"%>">Solar Systems (Religious Sanctuaries)</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/SearchSolarSystem.aspx"%>">Search Solar Systems (Religious Sanctuaries)</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Moons.aspx"%>">Moon users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/WhiteWholes.aspx"%>">WhiteWhole users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/StarShips.aspx"%>">Starship users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & ""%>">UNIonVERSE Home Page</a></li>
            </ul>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phBusinessType">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet1.aspx"%>">Planet I users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet2.aspx"%>">Planet II users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Moons.aspx"%>">Moon users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/WhiteWholes.aspx"%>">WhiteWhole users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & ""%>">UNIonVERSE Home Page</a></li>
            </ul>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phGroupType3Moon">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet1.aspx"%>">Planet I users</a></li>
            </ul>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet2.aspx"%>">Planet II (Sale Agent) Users</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/SolarSystem.aspx"%>">Solar Systems (Religious Sanctuaries)</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Moons.aspx"%>">Moon users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/WhiteWholes.aspx"%>">WhiteWhole users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/StarShips.aspx"%>">Starship users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & ""%>">UNIonVERSE Home Page</a></li>
            </ul>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phWhiteWhole">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet1.aspx"%>">Planet I Users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet2.aspx"%>">Planet II Users</a></li>
            </ul>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/SolarSystem.aspx"%>">Solar Systems (Religious Sanctuaries)</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Moons.aspx"%>">Moon users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/StarShips.aspx"%>">Starship (Business) users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & ""%>">UNIonVERSE Home Page</a></li>
            </ul>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phIndividualType1">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet1.aspx"%>">Planet I Users</a></li>
            </ul>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet2.aspx"%>">Planet II (Sale Agents) Users</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/OrbConnections.aspx"%>">Orb Connections</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Moons.aspx"%>">Moon users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/WhiteWholes.aspx"%>">WhiteWhole users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/StarShips.aspx"%>">Starship (Business) users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & ""%>">UNIonVERSE Home Page</a></li>
            </ul>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phIndividualType2">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet1.aspx"%>">Planet I Users</a></li>
            </ul>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet2.aspx"%>">Planet II (Sale Agents) Users</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/OrbConnections.aspx"%>">Orb Connections</a></li>
            </ul>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/SolarSystem.aspx"%>">Solar System (Religious Sanctuary) Users</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/SearchSolarSystem.aspx"%>">Search Solar Systems (Religious Sanctuaries)</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Moons.aspx"%>">Moon users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/WhiteWholes.aspx"%>">WhiteWhole users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/StarShips.aspx"%>">Starship (Business) users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & ""%>">UNIonVERSE Home Page</a></li>
            </ul>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phMasterUVAccount" Visible="false">
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet1.aspx"%>">Planet I Users</a></li>
            </ul>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Planet2.aspx"%>">Planet II (Sale Agents) Users</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <ul class="mnu_snav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/SolarSystem.aspx"%>">Solar System (Religious Sanctuary) Users</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <ul class="mnu_nav">
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/Moons.aspx"%>">Moon users</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Gravity/WhiteWholes.aspx"%>">WhiteWhole users</a></li>
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

