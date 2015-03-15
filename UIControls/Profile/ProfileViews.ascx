<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ProfileViews.ascx.vb" Inherits="UIControls_Profile_ProfileViews" %>
<%@ Register src="BusinessUsersView.ascx" tagname="BusinessUsersView" tagprefix="uc1" %>
<%@ Register src="GroupType1View.ascx" tagname="GroupType1View" tagprefix="uc2" %>
<%@ Register src="GroupType4View.ascx" tagname="GroupType4View" tagprefix="uc3" %>
<%@ Register src="IndividualType1View.ascx" tagname="IndividualType1View" tagprefix="uc4" %>
<%@ Register src="IndividualType2View.ascx" tagname="IndividualType2View" tagprefix="uc5" %>
<%@ Register src="MoonsView.ascx" tagname="MoonsView" tagprefix="uc6" %>
<%@ Register src="BasicProfile.ascx" tagname="BasicProfile" tagprefix="uc7" %>
<uc2:GroupType1View ID="GroupType1View1" runat="server" />
<uc4:IndividualType1View ID="IndividualType1View1" runat="server" />
<uc5:IndividualType2View ID="IndividualType2View1" runat="server" />
<uc1:BusinessUsersView ID="BusinessUsersView1" runat="server" />
<uc6:MoonsView ID="MoonsView1" runat="server" />
<uc3:GroupType4View ID="GroupType4View1" runat="server" />
<uc7:BasicProfile ID="BasicProfile1" runat="server" />


