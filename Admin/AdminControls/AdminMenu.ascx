<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdminMenu.ascx.vb" Inherits="AdminMenu" %>
<div class="navwrapper">
    <span class="hd">Admin Home</span>
    <asp:PlaceHolder runat="server" ID="plhAdmin">
        <div class="cssnav">
            <a href="../Admin/dashboard.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_dashboard.png" alt="" />&nbsp;&nbsp;Dashboard</a></div>
        <div class="cssnav">
            <a href="../Admin/ManageMenu.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_navigation.png" alt="" />&nbsp;&nbsp;Navigation</a></div>
         <div class="cssnav">
            <a href="../Admin/managemarkets.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_location.png" alt="" />&nbsp;&nbsp;Markets</a></div>
        <div class="cssnav">
            <a href="../Admin/propertyedit.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_building.png" alt="" />&nbsp;&nbsp;Buildings</a></div>
        <div class="cssnav">
            <a href="../Admin/ManagePageContent.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_pages.png" alt="" />&nbsp;&nbsp;Pages</a></div>
        <div class="cssnav">
            <a href="../Admin/ManageSinipptsRotator.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_pages.png" alt="" />&nbsp;&nbsp;Rotator</a></div>
        <div class="cssnav">
            <a href="../Admin/managenews.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_news.png" alt="" />&nbsp;&nbsp;News</a></div>
        <div class="cssnav">
            <a href="../Admin/managestaff.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_team.png" alt="" />&nbsp;&nbsp;Team</a></div>
        <div class="cssnav">
            <a href="../Admin/managejobs.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_jobs.png" alt="" />&nbsp;&nbsp;Careers</a></div>
             <div class="cssnav">
            <a href="../Admin/manageBlogs.aspx?bid=<%= uihelper.GetSiteConfigrationValue("BlogID") %>">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_blog.png" alt="" />&nbsp;&nbsp;Blog</a></div>
        <div class="cssnav">
            <a href="../Admin/Manageadmin.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_account.png" alt="" />&nbsp;&nbsp;Accounts</a></div>
        <div class="cssnav">
            <a href="../Admin/managelinks.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_link.png" alt="" />&nbsp;&nbsp;Quick
                Links</a></div>
        <div class="cssnav">
            <a href="../Admin/managetestimonial.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_testi.png" alt="" />&nbsp;&nbsp;Testimonials</a></div>
       <div class="cssnav">
            <a href="../Admin/managefeed.aspx">
                <img src="<%= uihelper.getbasePath() %>/admin/images/ico_feed.png" alt="" />&nbsp;&nbsp;Feeds/Data</a></div>
    </asp:PlaceHolder>
    <div class="cssnavl">
        <a href="<%= uihelper.getbasePath() & "/home.aspx" %>">
            <img src="<%= uihelper.getbasePath() %>/admin/images/ico_back.png" alt="" />&nbsp;&nbsp;Return
            to Site</a></div>
</div>
<input type="hidden" id="SetDiv" runat="server" />
<input type="hidden" id="SetImg" runat="server" />

<script language="javascript">
     //SetDefault();
</script>

