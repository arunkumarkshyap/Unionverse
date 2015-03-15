<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ShowMap.ascx.vb" Inherits="UIControls_Profile_ShowMap" %>
<script src="//maps.google.com/maps?file=api&amp;sensor=false&amp;key=AIzaSyBgNfx2vBOd-nPdgidTEmjwcUCi3F0EN6c"
    type="text/javascript">
//My Google Maps Key
</script>

<script type="text/javascript">

function load() {
if (GBrowserIsCompatible()) {
var map = new GMap2(document.getElementById("map"));
map.addControl (new GSmallMapControl());
map.addControl(new GMapTypeControl());
var center = new GLatLng(document.getElementById("<%= lat.ClientID %>").value, document.getElementById("<%= lng.ClientID %>").value);
map.setCenter(center, 8); //11
map.setUIToDefault();

map.setMapType(G_NORMAL_MAP);
geocoder = new GClientGeocoder();

var marker = new GMarker(center, {draggable: true}); 
map.addOverlay(marker);
document.getElementById("<%= lat.ClientID %>").value = center.lat();
document.getElementById("<%= lng.ClientID %>").value = center.lng ();

geocoder = new GClientGeocoder();

GEvent.addListener(marker, "dragend", function() {
var point =marker.getPoint();
map.panTo(point);
document.getElementById("<%= lat.ClientID %>").value = point.lat();
document.getElementById("<%= lng.ClientID %>").value = point.lng();
});

GEvent.addListener(map, "moveend", function() {
map.clearOverlays();
var center = map.getCenter();
var marker = new GMarker(center, {draggable: true});
map.addOverlay(marker);
document.getElementById("<%= lat.ClientID %>").value = center.lat();
document.getElementById("<%= lng.ClientID %>").value = center.lng();

GEvent.addListener(marker, "dragend", function() {
var point =marker.getPoint();
map.panTo(point);
document.getElementById("<%= lat.ClientID %>").value = point.lat();
document.getElementById("<%= lng.ClientID %>").value = point.lng();
});
});
}
}

function showAddress(address) {
var map = new GMap2(document.getElementById("map"));
map.addControl(new GSmallMapControl());
map.addControl(new GMapTypeControl());
if (geocoder) {
geocoder.getLatLng (
address,
function(point) {
if (!point) {
//alert(address + " city not found !");
}
else {
document.getElementById("<%= lat.ClientID %>").value = point.lat();
document.getElementById("<%= lng.ClientID %>").value = point.lng();
map.clearOverlays()
map.setCenter(point, 14);
var marker = new GMarker(point, {draggable: true}); 
map.addOverlay(marker);

GEvent.addListener(marker, "dragend", function() {
var pt =marker.getPoint();
map.panTo(pt);
document.getElementById("<%= lat.ClientID %>").value = pt.lat();
document.getElementById("<%= lng.ClientID %>").value = pt.lng();
});

GEvent.addListener(map, "moveend", function() {
map.clearOverlays();
var center = map.getCenter();
var marker = new GMarker(center, {draggable: true});
map.addOverlay(marker);
document.getElementById("<%= lat.ClientID %>").value = center.lat();
document.getElementById("<%= lng.ClientID %>").value = center.lng();

GEvent.addListener(marker, "dragend", function() {
var pt =marker.getPoint();
map.panTo(pt);
document.getElementById("<%= lat.ClientID %>").value = pt.lat();
document.getElementById("<%= lng.ClientID %>").value = pt.lng();
});
});
}}
);
}}
</script>

<script language="JavaScript">
    <!--
    var message="";
    function clickIE() {if (document.all) {(message);return false;}}
    function clickNS(e) {if
    (document.layers||(document.getElementById&&!document.all )) {
    if (e.which==2||e.which==3) {(message);return false;}}}
    if (document.layers)
    {document.captureEvents(Event.MOUSEDOWN);document.onmousedown=clickNS;}
    else{document.onmouseup=clickNS;document.oncontextmenu=clickIE;}
    document.oncontextmenu=new Function("return false")
    // -->
</script>

<script language="javascript" type="text/javascript">
function CallShowAddress()
{
    showAddress(document.getElementById("<%= location.ClientID %>").value);
}
</script>
<a id="Location"></a>
<div class="map_wrap">
    <div class="map_cnt">
    <div id="map" style="width:100%;height:250px;"></div>

    </div>
    <div class="cb">
    </div>
</div>

<input type="hidden" size="34" name="location" id="location" value="" runat="server" />
<input type="hidden" size="34" name="latitude" value="" id="lat" runat="server" />
<input type="hidden" size="34" name="longitude" value="" id="lng" runat="server" />