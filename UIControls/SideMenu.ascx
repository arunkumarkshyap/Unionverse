<%@ Control Language="VB" AutoEventWireup="false" CodeFile="~/UIControls/SideMenu.ascx.vb"
    Inherits="UIControls_SideMenu_" %>
<%@ Register Src="~/UIControls/FranchiseList.ascx" TagPrefix="uc1" TagName="FranchiseList" %>
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
        <span class="mhd_tit">Shortcuts</span>
    </div>
    <div class="mnu_bd">
        <div class="prf_img" runat="server" id="divPicture">
            <img runat="server" id="imgProfile" />
            <div class="prf_img_vm">
                <a href="#" runat="server" id="aMorePictures">View more pictures</a>
            </div>
        </div>
        <ul class="mnu_nav">
            <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.UserName & "/Wall.aspx"%>">
                Wall</a></li>
            <li>
                <asp:HyperLink runat="server" ID="hlInbox" Text="Inbox"></asp:HyperLink></li>
            <asp:PlaceHolder runat="server" ID="pG1">
                <li>
                    <asp:HyperLink runat="server" ID="hlG1HomePage" Text="My Home Page" NavigateUrl="#"></asp:HyperLink></li>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="pG2">
                <li>
                    <asp:HyperLink runat="server" ID="hlG2HomePage" Text="My Home Page" NavigateUrl="#"></asp:HyperLink></li>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="pG3">
                <li>
                    <asp:HyperLink runat="server" ID="hlG3MyHomePage" Text="My Home Page"></asp:HyperLink></li>
                <li>
                    <asp:HyperLink runat="server" ID="hlG3StarShipHomePage" Text="StarShip Home Page"></asp:HyperLink></li>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="pG4">
                <li>
                    <asp:HyperLink runat="server" ID="hlG4MyHomePage" Text="My Home Page"></asp:HyperLink></li>
                <li>
                    <asp:HyperLink runat="server" ID="hlG4StarShipHomePage" Text="StarShip Home Page"></asp:HyperLink></li>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="pI1">
                <li>
                    <asp:HyperLink runat="server" ID="hlI1SolarSystem" Text="Solar System Home Page"
                        NavigateUrl="#"></asp:HyperLink></li>
                <li>
                    <asp:HyperLink runat="server" ID="hlI1HomePage" Text="My Home Page" NavigateUrl="#"></asp:HyperLink></li>
                <li>
                    <asp:HyperLink runat="server" ID="hlI1StarShipHomePage" Text="StarShip Home Page"
                        NavigateUrl="#"></asp:HyperLink></li>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="pI2">
                <li>
                    <asp:HyperLink runat="server" ID="hlI2SolarSystem" Text="Solar System Home Page"
                        NavigateUrl="#"></asp:HyperLink></li>
                <li>
                    <asp:HyperLink runat="server" ID="hlI2HomePage" Text="My Home Page" NavigateUrl="#"></asp:HyperLink></li>
                <li>
                    <asp:HyperLink runat="server" ID="hlI2StarShipHomePage" Text="StarShip Home Page"
                        NavigateUrl="#"></asp:HyperLink></li>
            </asp:PlaceHolder>
        </ul>
        <asp:PlaceHolder runat="server" ID="phGroupType1">
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="GT1UConn" onclick="javascript:mnuCall(this.id);">
                    UNIonVERSE</a>
                <ul class="mnu_snav" id="sGT1UConn" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/UNIonVERSE.aspx"%>">
                        The UNIonVERSE</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/GravitationalPlanets.aspx"%>">
                        Gravity</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/uvraise/solarsystemhomepage.aspx"%>">
                        UV Raise</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uesend.aspx"%>">
                        UV Energy</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/umatter/umattersubmit.aspx"%>">
                        U Matter</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons.aspx"%>">ELECTrons</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.UserName & "/StarShipCaptainLog.aspx"%>">
                        StarShip Captains Log</a></li>
                   
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="gt1Fleet" onclick="javascript:mnuCall(this.id);">
                    FLEETPORTS</a>
                <ul class="mnu_snav" id="sgt1Fleet" style="display: none;">
                    <li><a href="http://www.fleetports.com">FLEETPORTS</a></li>
                    <li><a href="http://www.uv-screen.com">UV Screen</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="gt1Conn" onclick="javascript:mnuCall(this.id);">
                    Connections</a>
                <ul class="mnu_snav" id="sgt1Conn" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/Moons.aspx"%>">Moons</a></li>
                    <li><a href="http://www.fleetports.com">StarFleets (B2RS)</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/StarShipVouager.aspx"%>">
                        StarShip Voyager</a></li>
                    <li><a href="<%= UIHelper.GetUnionVerseBasePathURL() & "/Connections/WhiteWholes.aspx"%>">
                        WhiteWholes</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <ul class="mnu_nav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.UserName & "/UserListing.aspx"%>">
                        Sub users listing</a></li>
                </ul>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phBusinessType">
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="BusUniOn" onclick="javascript:mnuCall(this.id);">
                    UNIonVERSE</a>
                <ul class="mnu_snav" id="sBusUniOn" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvraise/homepage.aspx"%>">
                        UV Raise</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uesend.aspx"%>">
                        UV Energy</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons.aspx"%>">ELECTrons</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.UserName & "/StarShipCaptainLog.aspx"%>">
                        StarShip Captains Log</a></li>
                    <uc1:FranchiseList runat="server" ID="FranchiseList" />
                </ul>
                <span class="dyn_mnu_ft"></span>
                <ul class="mnu_nav">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.UserName & "/ViewAlbums.aspx"%>">
                        View Albums</a></li>
                </ul>
            </div>
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="BusFleet" onclick="javascript:mnuCall(this.id);">
                    FLEETPORTS</a>
                <ul class="mnu_snav" id="sBusFleet" style="display: none;">
                    <li><a href="http://www.fleetports.com">FLEETPORTS</a></li>
                    <li><a href="http://www.uventerprise.com">UV ENTERPRISE</a></li>
                    <li><a href="http://www.uv-screen.com">UV Screen</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="BusConn" onclick="javascript:mnuCall(this.id);">
                    Connections</a>
                <ul class="mnu_snav" id="sBusConn" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/Moons.aspx"%>">Moons</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/OrbB2I.aspx"%>">
                        Orbit (B2I)</a></li>
                    <li><a href="http://www.fleetports.com">Fleets(B2I)</a></li>
                    <li><a href="http://www.fleetports.com">StarFleets (B2RS)</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/StarShipVouager.aspx"%>">
                        StarShip Voyager All</a></li>
                    <li><a href="<%= UIHelper.GetUnionVerseBasePathURL() & "/Connections/WhiteWholes.aspx" %>">
                        WhiteWholes</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phGroupType3Moon">
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="MoonUnion" onclick="javascript:mnuCall(this.id);">
                    UNIonVERSE</a>
                <ul class="mnu_snav" id="sMoonUnion" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvraise/homepage.aspx"%>">
                        UV Raise</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uesend.aspx"%>">
                        UV Energy</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons.aspx"%>">ELECTrons</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.UserName & "/StarShipCaptainLog.aspx"%>">
                        StarShip Captains Log</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="MoonFleets" onclick="javascript:mnuCall(this.id);">
                    FLEETPORTS</a>
                <ul class="mnu_snav" id="sMoonFleets" style="display: none;">
                    <li><a href="http://www.fleetports.com">FLEETPORTS</a></li>
                    <li><a href="http://www.uventerprise.com">UV ENTERPRISE</a></li>
                    <li><a href="http://www.uv-screen.com">UV Screen</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="MoonConn" onclick="javascript:mnuCall(this.id);">
                    Connections</a>
                <ul class="mnu_snav" id="sMoonConn" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/SolarSystemSearch.aspx"%>">
                        Solar Systems</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/MoonPlanets.aspx"%>">
                        Planets</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/Moons.aspx"%>">Moons</a></li>
                    <li><a href="http://www.fleetports.com">Fleets(B2B)</a></li>
                    <li><a href="http://www.fleetports.com">StarFleets (B2RS)</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/StarShipVouager.aspx"%>">
                        StarShip Voyager All</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/LunarBase.aspx"%>">
                        Lunar Base</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/WhiteWholes.aspx" %>">
                        WhiteWholes</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phWhiteWhole">
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="WWUnion" onclick="javascript:mnuCall(this.id);">
                    UNIonVERSE</a>
                <ul class="mnu_snav" id="sWWUnion" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvraise/homepage.aspx"%>">
                        UV Raise</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uesend.aspx"%>">
                        UV Energy</a></li>
                    <li><a href="<%=UIHelper.GetBasePath () & "/Members/" & GetUser.UserName & "/StarShipCaptainLog.aspx"%>">
                        StarShip Captains Log</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="WWFleets" onclick="javascript:mnuCall(this.id);">
                    FLEETPORTS</a>
                <ul class="mnu_snav" id="sWWFleets" style="display: none;">
                    <li><a href="http://www.fleetports.com">FLEETPORTS</a></li>
                    <li><a href="http://www.uventerprise.com">UV ENTERPRISE</a></li>
                    <li><a href="http://www.uv-screen.com">UV Screen</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="WWConn" onclick="javascript:mnuCall(this.id);">
                    Connections</a>
                <ul class="mnu_snav" id="sWWConn" style="display: none;">
                    <li><a href="<%= UIHelper.GetUnionVerseBasePathURL() & "/Connections/SolarSystemSearch.aspx"%>">
                        Solar Systems</a></li>
                    <li><a href="<%= UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/Connections.aspx"%>">
                        Planets</a></li>
                    <li><a href="<%= UIHelper.GetUnionVerseBasePathURL() & "/Members/StarShipSearch.aspx"%>">
                        StarShips</a></li>
                    <li><a href="<%= UIHelper.GetUnionVerseBasePathURL() & "/Connections/Moons.aspx"%>">
                        Moons</a></li>
                    <li><a href="http://www.fleetports.com">Fleets(B2B)</a></li>
                    <li><a href="<%= UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.UserName & "/StarShipVouager.aspx"%>">
                        StarShip Voyager All</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phIndividualType1">
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="Indt1Union" onclick="javascript:mnuCall(this.id);">
                    UNIonVERSE</a>
                <ul class="mnu_snav" id="sIndt1Union" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/UNIonVERSE.aspx"%>">
                        The UNIonVERSE</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetStarShipUserName() & "/GravitationalPlanets.aspx"%>">
                        Gravity</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvraise/indhomepage.aspx"%>">
                        UV Raise</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uesend.aspx"%>">
                        UV Energy</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/umatter/umattersubmit.aspx"%>">
                        U Matter</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/ELECTrons.aspx"%>">ELECTrons</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/Product-Search.aspx"%>">
                        UNIonVERSE Store</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.UserName & "/StarShipCaptainLog.aspx"%>">
                        StarShip Captains Log</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="Indt1Conn" onclick="javascript:mnuCall(this.id);">
                    Connections</a>
                <ul class="mnu_snav" id="sIndt1Conn" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetStarShipUserName() & "/Connections.aspx"%>">
                        Solar System Planets</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/OrbI2I.aspx"%>">
                        Orb (I2I)</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/OrbB2I.aspx"%>">
                        Orbit (B2I)</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/Moons.aspx"%>">Moons</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/WhiteWholes.aspx" %>">
                        WhiteWholes</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phIndividualType2">
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="Indt2Union" onclick="javascript:mnuCall(this.id);">
                    UNIonVERSE</a>
                <ul class="mnu_snav" id="sIndt2Union" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/UNIonVERSE.aspx"%>">
                        The UNIonVERSE</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetStarShipUserName() & "/GravitationalPlanets.aspx"%>">
                        Gravity</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvraise/indhomepage.aspx"%>">
                        UV Raise</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/uvenergy/uesend.aspx"%>">
                        UV Energy</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/umatter/umattersubmit.aspx"%>">
                        U Matter</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/ELECTrons.aspx"%>">ELECTrons</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/Product-Search.aspx"%>">
                        UNIonVERSE Store</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.UserName & "/StarShipCaptainLog.aspx"%>">
                        StarShip Captains Log</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
            <div class="dyn_mnu">
                <a href="javascript:mnuCall(this.id);" class="mnu_xnd" id="Indt2Conn" onclick="javascript:mnuCall(this.id);">
                    Connections</a>
                <ul class="mnu_snav" id="sIndt2Conn" style="display: none;">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetStarShipUserName() & "/Connections.aspx"%>">
                        Solar System Planets</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/OrbI2I.aspx"%>">
                        Orb (I2I)</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & GetUser.Username & "/OrbB2I.aspx"%>">
                        Orbit (B2I)</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/Moons.aspx"%>">Moons</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/WhiteWholes.aspx"%>">
                        WhiteWholes</a></li>
                </ul>
                <span class="dyn_mnu_ft"></span>
            </div>
        </asp:PlaceHolder>
        <ul class="fnd_wrap">
            <%-- <uc2:FriendUsersMini ID="FriendUsersMini1" runat="server" />
    <uc1:UserFriendsMini ID="UserFriendsMini1" runat="server" />
    <uc4:WWConnectionsMini ID="WWConnectionsMini1" runat="server" />
    <uc3:UserWWConnectionsMini ID="UserWWConnectionsMini1" runat="server" />--%>
            <div class="cb">
            </div>
        </ul>
        <%--<uc5:ChatMessages ID="ChatMessages1" runat="server" />--%>
    </div>
    <div class="mnu_ft">
    </div>
</div>
