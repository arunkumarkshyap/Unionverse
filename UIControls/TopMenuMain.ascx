<%@ Control Language="VB" AutoEventWireup="false" CodeFile="TopMenumain.ascx.vb"
    Inherits="UIControls_TopMenumain" %>
<asp:PlaceHolder runat="server" ID="phGroupType1">
    <ul class="nav">
        <li><a href="<%=UIhelper.GetUnionVerseBasePathURL() %>">UNIonVERSE</a>
            <ul>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/SolarSystemSearch.aspx" %>">Solar System Home Page</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Connections/SolarSystemPlanets.aspx" %>">Connections</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Unionversity/ClassRoom-Wiki.aspx"%>">UNIonVERSITY</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UVEnergy/Send.aspx"%>">UV Energy</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UVRaise/SolarSystemHomepage.aspx"%>">UV Raise</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UMatter/MyUMatters.aspx"%>">U Matter</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/ELECTrons.aspx"%>">ELECTrons</a></li>
            </ul>
        </li>
        <li><a href="http://www.wormwholes.com">WORMWHOLES</a>
            <ul>
                <li><a href="http://www.wormwholes.com">Home Page</a></li>
                <li><a href="http://www.wormwholes.com/">Buy UNI</a></li>
                <li><a href="http://www.wormwholes.com/WithdrawUni.aspx">Withdraw UNI</a></li>
                <li><a href="http://www.wormwholes.com/SendUNI.aspx">Send UNI</a></li>
                <li><a href="http://www.wormwholes.com/AccountDetailHistory.aspx">Account Details & History</a></li>
            </ul>
        </li>
        <li><a href="http://www.blackwholes.com">BLACKWHOLES</a>
            <ul>
                <li><a href="http://www.blackwholes.com/bwhome.aspx">Home Page</a></li>
                <li><a href="http://www.blackwholes.com/bwsearch.aspx">Search BlackWholes</a></li>
                <li><a href="http://www.blackwholes.com/bwsubmit.aspx">Submit Matter</a></li>
            </ul>
        </li>
        <li><a href="http://www.whitewholes.com">WHITEWHOLES</a>
            <ul>
                <li><a href="http://www.whitewholes.com/home.aspx">Home Page</a></li>
                <li><a href="http://www.whitewholes.com/MyWhiteWholes.aspx">My WhiteWholes</a></li>
                <li><a href="http://www.whitewholes.com/Search.aspx">Search WhiteWholes</a></li>
            </ul>
        </li>
        <li><a href="#">FLEETPORTS</a>
            <ul>
                <li><a href="#">Home Page</a></li>
                <li><a href="#">FLEETPORTS</a></li>
                <li><a href="#">UV Screen</a></li>
            </ul>
        </li>
    </ul>
    <br clear="all" />
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phBusinessType">
    <ul class="nav">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() %>">UNIonVERSE</a>
            <ul>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & UserName & "/Unionverse.aspx" %>">The UNIonVERSE</a></li>
                <li><a href="#" runat="server" id="aBusinessStore">The UNIonVERSE Store</a></li>
                <li><a href="#">StarShip Home Page</a></li>
                <li><a href="#">StarShip Captains Log</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/Connections.aspx"%>">Connections</a></li>
                <li><a href="#">Testimonials</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/UVEnergy.aspx"%>">UV Energy</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & UserName & "/UVRaise.aspx"%>">UV Raise</a></li>
            </ul>
        </li>
        <li><a href="http://www.wormwholes.com">WORMWHOLES</a>
            <ul>
                <li><a href="http://www.wormwholes.com">Home Page</a></li>
                <li><a href="http://www.wormwholes.com/">Buy UNI</a></li>
                <li><a href="http://www.wormwholes.com/WithdrawUni.aspx">Withdraw UNI</a></li>
                <li><a href="http://www.wormwholes.com/SendUNI.aspx">Send UNI</a></li>
                <li><a href="http://www.wormwholes.com/AccountDetailHistory.aspx">Account Details & History</a></li>
            </ul>
        </li>
        <li><a href="http://www.blackwholes.com">BLACKWHOLES</a>
            <ul>
                <li><a href="http://www.blackwholes.com/bwhome.aspx">Home Page</a></li>
                <li><a href="http://www.blackwholes.com/bwsearch.aspx">Search BlackWholes</a></li>
                <li><a href="http://www.blackwholes.com/bwsubmit.aspx">Submit Matter</a></li>
            </ul>
        </li>
        <li><a href="http://www.whitewholes.com">WHITEWHOLES</a>
            <ul>
                <li><a href="http://www.whitewholes.com/home.aspx">Home Page</a></li>
                <li><a href="http://www.whitewholes.com/MyWhiteWholes.aspx">My WhiteWholes</a></li>
                <li><a href="http://www.whitewholes.com/Search.aspx">Search WhiteWholes</a></li>
            </ul>
        </li>
        <li><a href="#">FLEETPORTS</a>
            <ul>
                <li><a href="#">Home Page</a></li>
                <li><a href="#">FLEETPORTS</a></li>
                <li><a href="#">UV Enterprise</a></li>
                <li><a href="#">UV Screen</a></li>
            </ul>
        </li>
    </ul>
    <br clear="all" />
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phGroupType3Moon">
    <ul class="nav">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL()%>">UNIonVERSE</a>
            <ul>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/Unionverse.aspx"%>">The UNIonVERSE</a></li>
                <li><a href="#">Moon Home Page</a></li>
                <li><a href="#">Captains Log Lunar Voyage</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/Connections.aspx"%>">Connections</a></li>
                <asp:PlaceHolder runat="server" ID="phMoonGeneral">
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/UVEnergy.aspx"%>">UV Energy</a></li>
                    <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/UVRaise.aspx"%>">UV Raise</a></li>
                </asp:PlaceHolder>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Government/LocalPollResults.aspx" %>">ELECTrons</a></li>
            </ul>
        </li>
        <li><a href="http://www.wormwholes.com">WORMWHOLES</a>
            <ul>
                <li><a href="http://www.wormwholes.com">Home Page</a></li>
                <li><a href="http://www.wormwholes.com/">Buy UNI</a></li>
                <li><a href="http://www.wormwholes.com/WithdrawUni.aspx">Withdraw UNI</a></li>
                <li><a href="http://www.wormwholes.com/SendUNI.aspx">Send UNI</a></li>
                <li><a href="http://www.wormwholes.com/AccountDetailHistory.aspx">Account Details & History</a></li>
            </ul>
        </li>
        <li><a href="http://www.blackwholes.com">BLACKWHOLES</a>
            <ul>
                <li><a href="http://www.blackwholes.com/bwhome.aspx">Home Page</a></li>
                <li><a href="http://www.blackwholes.com/bwsearch.aspx">Search BlackWholes</a></li>
                <li><a href="http://www.blackwholes.com/bwsubmit.aspx">Submit Matter</a></li>
            </ul>
        </li>
        <li><a href="http://www.whitewholes.com">WHITEWHOLES</a>
            <ul>
                <li><a href="http://www.whitewholes.com/home.aspx">Home Page</a></li>
                <li><a href="http://www.whitewholes.com/MyWhiteWholes.aspx">My WhiteWholes</a></li>
                <li><a href="http://www.whitewholes.com/Search.aspx">Search WhiteWholes</a></li>
            </ul>
        </li>
        <li><a href="#">FLEETPORTS</a>
            <ul>
                <li><a href="#">Home Page</a></li>
                <li><a href="#">FLEETPORTS</a></li>
                <li><a href="#">UV Enterprise</a></li>
                <li><a href="#">UV Screen</a></li>
            </ul>
        </li>
    </ul>
    <br clear="all" />
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phWhiteWhole">
    <ul class="nav">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() %>">UNIonVERSE</a>
            <ul>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/Unionverse.aspx"%>">The UNIonVERSE</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/UVEnergy.aspx"%>">UV Energy</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & UserName & "/UVRaise.aspx" %>">UV Raise</a></li>
            </ul>
        </li>
        <li><a href="http://www.wormwholes.com">WORMWHOLES</a>
            <ul>
                <li><a href="http://www.wormwholes.com">Home Page</a></li>
                <li><a href="http://www.wormwholes.com/">Buy UNI</a></li>
                <li><a href="http://www.wormwholes.com/WithdrawUni.aspx">Withdraw UNI</a></li>
                <li><a href="http://www.wormwholes.com/SendUNI.aspx">Send UNI</a></li>
                <li><a href="http://www.wormwholes.com/AccountDetailHistory.aspx">Account Details & History</a></li>
            </ul>
        </li>
        <li><a href="http://www.blackwholes.com">BLACKWHOLES</a>
            <ul>
                <li><a href="http://www.blackwholes.com/bwhome.aspx">Home Page</a></li>
                <li><a href="http://www.blackwholes.com/bwsearch.aspx">Search BlackWholes</a></li>
                <li><a href="http://www.blackwholes.com/bwsubmit.aspx">Submit Matter</a></li>
            </ul>
        </li>
        <li><a href="http://www.whitewholes.com">WHITEWHOLES</a>
            <ul>
                <li><a href="<%="http://www.whitewholes.com/Members/" & Username & ".aspx"%>">White Wholes Home Page</a></li>
                <li><a href="http://www.whitewholes.com/Connections.aspx">Connections</a></li>
                <li><a href="http://www.whitewholes.com/Members/Wall.aspx">My Wall</a></li>
            </ul>
        </li>
        <li><a href="#">FLEETPORTS</a>
            <ul>
                <li><a href="#">Home Page</a></li>
                <li><a href="#">FLEETPORTS</a></li>
                <li><a href="#">UV Enterprise</a></li>
                <li><a href="#">UV Screen</a></li>
            </ul>
        </li>
    </ul>
    <br clear="all" />
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phIndividualType1">
    <ul class="nav">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL()%>">UNIonVERSE</a>
            <ul>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/Unionverse.aspx"%>">The UNIonVERSE</a></li>
                <li><a href="#">Solar System Home Page</a></li>
                <li><a href="#">Planet Home Page</a></li>
                <li><a href="#">StarShip Home Page</a></li>
                <li><a href="#">StarShip Captains Log</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/Connections.aspx"%>">Connections</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/UNIonVERSITY.aspx"%>">UNIonVERSITY</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & UserName & "/UVEnergy.aspx"%>">UV Energy</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/Gravity.aspx"%>">Gravity</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/UVRaise/indhomepage.aspx"%>">UV Raise</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/UMatter.aspx"%>">U Matter</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/LocalMatter.aspx"%>">ELECTrons</a></li>
            </ul>
        </li>
        <li><a href="http://www.wormwholes.com">WORMWHOLES</a>
            <ul>
                <li><a href="http://www.wormwholes.com">Home Page</a></li>
                <li><a href="http://www.wormwholes.com/">Buy UNI</a></li>
                <li><a href="http://www.wormwholes.com/SendUNI.aspx">Send UNI</a></li>
                <li><a href="http://www.wormwholes.com/AccountDetailHistory.aspx">Account Details & History</a></li>
            </ul>
        </li>
        <li><a href="http://www.blackwholes.com">BLACKWHOLES</a>
            <ul>
                <li><a href="http://www.blackwholes.com/bwhome.aspx">Home Page</a></li>
                <li><a href="http://www.blackwholes.com/bwsearch.aspx">Search BlackWholes</a></li>
                <li><a href="http://www.blackwholes.com/bwsubmit.aspx">Submit Matter</a></li>
            </ul>
        </li>
        <li><a href="http://www.whitewholes.com">WHITEWHOLES</a>
            <ul>
                <li><a href="http://www.whitewholes.com/home.aspx">Home Page</a></li>
                <li><a href="http://www.whitewholes.com/MyWhiteWholes.aspx">My WhiteWholes</a></li>
                <li><a href="http://www.whitewholes.com/Search.aspx">Search WhiteWholes</a></li>
            </ul>
        </li>
    </ul>
    <br clear="all" />
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phIndividualType2">
    <ul class="nav">
        <li><a href="<%=UIHelper.GetUnionVerseBasePathURL()%>">UNIonVERSE</a>
            <ul>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/Unionverse.aspx" %>">The UNIonVERSE</a></li>
                <li><a href="#">Solar System Home Page</a></li>
                <li><a href="#">Planet Home Page</a></li>
                <li><a href="#">StarShip Home Page</a></li>
                <li><a href="#">StarShip Captains Log</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/Connections.aspx"%>">Connections</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/UNIonVERSITY.aspx"%>">UNIonVERSITY</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/UVEnergy.aspx"%>">UV Energy</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/Gravity.aspx"%>">Gravity</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "//UVRaise/indhomepage.aspx"%>">UV Raise</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Members/" & Username & "/UMatter.aspx"%>">U Matter</a></li>
                <li><a href="<%=UIHelper.GetUnionVerseBasePathURL() & "/Electrons/Business/LocalMatter.aspx"%>">ELECTrons</a></li>
            </ul>
        </li>
        <li><a href="http://www.wormwholes.com">WORMWHOLES</a>
            <ul>
                <li><a href="http://www.wormwholes.com">Home Page</a></li>
                <li><a href="http://www.wormwholes.com/">Buy UNI</a></li>
                <li><a href="http://www.wormwholes.com/WithdrawUni.aspx">Withdraw UNI</a></li>
                <li><a href="http://www.wormwholes.com/SendUNI.aspx">Send UNI</a></li>
                <li><a href="http://www.wormwholes.com/AccountDetailHistory.aspx">Account Details & History</a></li>
            </ul>
        </li>
        <li><a href="http://www.blackwholes.com">BLACKWHOLES</a>
            <ul>
                <li><a href="http://www.blackwholes.com/bwhome.aspx">Home Page</a></li>
                <li><a href="http://www.blackwholes.com/bwsearch.aspx">Search BlackWholes</a></li>
                <li><a href="http://www.blackwholes.com/bwsubmit.aspx">Submit Matter</a></li>
            </ul>
        </li>
        <li><a href="http://www.whitewholes.com">WHITEWHOLES</a>
            <ul>
                <li><a href="http://www.whitewholes.com/home.aspx">Home Page</a></li>
                <li><a href="http://www.whitewholes.com/MyWhiteWholes.aspx">My WhiteWholes</a></li>
                <li><a href="http://www.whitewholes.com/Search.aspx">Search WhiteWholes</a></li>
            </ul>
        </li>
    </ul>
    <br clear="all" />
</asp:PlaceHolder>
