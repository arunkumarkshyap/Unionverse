<%@ Control Language="vb" AutoEventWireup="false" Inherits="PagingFooter2" CodeFile="PagingFooter2.ascx.vb" %>
<table id="tblPagingFooter" cellspacing="0" cellpadding="0" width="100%" style="background-color:white"
	border="0" runat="server">
	<tr id="trMinRowSpacer" runat="server">
		<td colspan="3"></td>
	</tr>
	<tr id="trPagingFooter" runat="server" style="background-color:White; height:30px;">
		<td valign="middle" style="width:15%; background-color:white;">&nbsp;</td>
		<td id="tdPagingFooter" valign="middle" align="center" style="background-color:White; width:70%;" runat="server"
			visible="false">
			<font style="font-size:14px; font-weight:bold;">Page:</font> 
			&nbsp;
			<asp:linkbutton id="imgBtnFirst" Runat="server" Visible="False" CssClass="PagingFooterNextPreviousLinks"
				Text="First">
				<img src="..\images\first_pg.gif" border="0" width="10px" height="10px" alt=""/></asp:linkbutton>
			&nbsp;
			<asp:linkbutton id="imgbtnPrev" Runat="server" Visible="False" text="Previous" BorderStyle="None"
				CssClass="PagingFooterNextPreviousLinks">
				Prev</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			<!--Ten Page events Links Starts-->
			<asp:linkbutton id="LBP1" Runat="server" Visible="False" font-Size="11" forecolor="black" font-Underline="true"></asp:linkbutton>&nbsp;
			<asp:linkbutton id="LBP2" Runat="server" Visible="False" font-Size="11" forecolor="black" font-Underline="true"></asp:linkbutton>&nbsp;
			<asp:linkbutton id="LBP3" Runat="server" Visible="False" font-Size="11" forecolor="black" font-Underline="true"></asp:linkbutton>&nbsp;
			<asp:linkbutton id="LBP4" Runat="server" Visible="False" font-Size="11" forecolor="black" font-Underline="true"></asp:linkbutton>&nbsp;
			<asp:linkbutton id="LBP5" Runat="server" Visible="False" font-Size="11" forecolor="black" font-Underline="true"></asp:linkbutton>&nbsp;
			<asp:linkbutton id="LBP6" Runat="server" Visible="False" font-Size="11" forecolor="black" font-Underline="true"></asp:linkbutton>&nbsp;
			<asp:linkbutton id="LBP7" Runat="server" Visible="False" font-Size="11" forecolor="black" font-Underline="true"></asp:linkbutton>&nbsp;
			<asp:linkbutton id="LBP8" Runat="server" Visible="False" font-Size="11" forecolor="black" font-Underline="true"></asp:linkbutton>&nbsp;
			<asp:linkbutton id="LBP9" Runat="server" Visible="False" font-Size="11" forecolor="black" font-Underline="true"></asp:linkbutton>&nbsp;
			<asp:linkbutton id="LBP10" Runat="server" Visible="False" font-Size="11" forecolor="black" font-Underline="true"></asp:linkbutton>
			<!--Ten Page events Links Ends-->
			<asp:label id="lblPageNumber" Runat="server" Visible="False"></asp:label>
			<asp:label id="lblPageCount" Runat="server" Visible="False"></asp:label>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:linkbutton id="imgbtnNext" Runat="server" text="Next" CssClass="PagingFooterNextPreviousLinks">
				Next</asp:linkbutton>
			&nbsp;
			<asp:linkbutton Visible="False" id="imgBtnLast" Runat="server" text="Last" CssClass="PagingFooterNextPreviousLinks">
				<img src="..\images\last_pg.gif" width="10px" height="10px" alt=""/></asp:linkbutton>
		</td>
		<td valign="middle" align="right"><asp:Label Visible="false" id="lblRecordsCount" Runat="server"></asp:Label>&nbsp;</td>
	</tr>
</table>
<input id="hidCurrentGroup" type="hidden" value="0" runat="server"/> 
<input id="hidGroupCount" type="hidden" value="0" runat="server"/>
<input type="hidden" value="0" runat="server" id="hidGroupSize"/>
<input id="hidTotalRecords" type="hidden" value="0" runat="server"/>
