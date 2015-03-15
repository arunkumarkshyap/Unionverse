<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CloseAccount.aspx.vb" Inherits="CloseAccount" %>

<%@ Register Src="UIControls/Loginfooter.ascx" TagName="footer" TagPrefix="uc1" %>
<%@ Register Src="UIControls/LogonMiniForm.ascx" TagName="LogonMiniForm" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login ::: UNIonVERSE</title>
    <link rel="shortcut icon" href="/favicon.ico" />
    <link rel="shortcut icon" href="<%=UIHelper.GetUnionVerseBasePathURL() & "/favicon.ico" %>" />
    <link rel="icon" href="<%=UIHelper.GetUnionVerseBasePathURL() & "/favicon.ico"%>" />
    <link href="<%=UIHelper.GetUnionVerseBasePathURL() & "/css/smt_style.css" %>" type="text/css"
        rel="stylesheet" />
    <link href="<%=UIHelper.GetUnionVerseBasePathURL() & "/css/smt_common.css" %>" type="text/css"
        rel="stylesheet" />
    <link href="<%=UIHelper.GetUnionVerseBasePathURL() & "/css/smt_logon.css" %>" type="text/css"
        rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="body_wrap">
        <div class="head" style="z-index: -100;">
            <div class="head_l">
                <img src="http://localhost:63173/Images/logo.png" alt="UNIonVERSE Logo" style="z-index: -5;" />
            </div>
            <div class="head_r">
            <div class="hd_r_c1">
                    <a href="<%=UIHelper.GetUnionVerseBasePathURL() + "/registration-type.aspx" %>">Register!</a>
                </div>
                
                <div class="hd_r_c2">
                    <uc2:LogonMiniForm ID="LogonMiniForm1" runat="server" DefaultTargetUrl="~/default.aspx" />
                </div>
                <div class="cb">
                </div>
            </div>
            <div class="cb">
            </div>
        </div>
        <div class="main">
            <div class="body" style="min-height: 730px;">
                <div class="cRegis">
                    <div class="cnt_wrap">
                        <div class="cnt_hd">
                            <h1 class="ch_h1">
                                Join the UNIonVERSE</h1>
                            <div class="cb">
                            </div>
                        </div>
                        <div class="cnt_bd">
                            <div class="cnt_cn_pad">
                                <asp:Label runat="server" ID="lblInfo" Font-Bold="true" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="cnt_ft">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="footer">
            <uc1:footer ID="uc_footer" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
