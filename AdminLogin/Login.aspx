<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" ValidateRequest="false" Inherits="AdminLogin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
     <style type="text/css">
         body{font-family:Arial; font-size:12px; color:#555555;}
#login_wrapper{background-color:#fafafa; width: 435px;  margin: 70px auto 0 auto; padding:1px; padding-bottom:35px;}
#login_cnt{border: solid 1px #ccc; background:#fff; margin: 35px auto 0px auto; width:350px; padding:0 10px 10px 10px ; height:160px; box-shadow:1px 2px 5px #ddd;}
       
    
#login_cnt div.head{font-family: Arial; font-size: 16px; font-weight: lighter; padding: 10px 7px 7px 5px; color: #999; margin: 0;  margin-bottom:10px;}
.login_field_cnt{width: 310px; margin:0 auto 15px auto; padding-left:20px; display: block; border:solid 0px red;}
.login_field_cnt label{width: 70px; display: block; font-size:14px;  float: left; margin-right:15px; margin-top:4px; line-height:17px;}
                             
.login_field_txt{border: solid 1px #aaa; width:203px; padding:2px 4px 2px 4px; height: 24px; font-size:16px; }
.login_field_btn{float:right; margin: 0 4px 5px 0px; display: block;padding:0 18px 0 10px; width:220px; border:solid 0px #000;}
.login_note_cnt{background-color:#fff; padding:10px; margin:0 auto 0 auto; width:350px; border:solid 1px #ccc; border-top:solid 1px #eee;}

.btn_login_b{display:block; background-color:#339933; color:#fff; padding:6px 10px 6px 10px;width:45px; text-align:center;text-decoration:none; float:right;}
.btn_login_b:hover{width:45px;border:0px none; text-decoration:none; background-color:#33cc33;}

.login_desc{line-height:20px; border:solid 0px #000; }
</style>
</head>
<body style="background: none; text-align: left; line-height: normal;">
    <form id="form1" runat="server">
        <div id="login_wrapper">
            <div id="login_cnt">
                <div class="head">
                    Login</div>
                <asp:PlaceHolder runat="server" ID="plhLogin" Visible="true">
                   <div>
                        <div class="login_field_cnt">
                            <label>
                                Username:</label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="login_field_txt" MaxLength="50" ></asp:TextBox>
                        </div>
                        <div class="login_field_cnt" style="margin-bottom: 10px;">
                            <label>
                                Password:</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="login_field_txt" MaxLength="50" TextMode="password"></asp:TextBox>
                         </div>
                        <div class="login_field_btn">
                            <asp:LinkButton ID="btnPwdReminder" runat="server" Text="Lost your password?" style="vertical-align:bottom; display:none;"></asp:LinkButton>
                            <asp:LinkButton ID="lbtLogIn" runat="server" CssClass="btn_login_b">Login</asp:LinkButton>
                        <div style="clear:both;"></div>
                        </div>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="plhMessage" Visible="false">
                    <table cellspacing="0" cellpadding="4" border="0" class="login" runat="server" id="tblMessage"
                        visible="false">
                        <tr>
                            <td class="message">
                                We have sent a password reminder to the e-mail address associated with that user
                                account. If you do not receive an e-mail, <a href='mailto:support@stellarmanagement.com'>contact
                                    your administrator</a> for your password.
                            </td>
                        </tr>
                    </table>
                </asp:PlaceHolder>
            </div>
            <asp:PlaceHolder runat="server" ID="plhErrMsg">
                <div class="login_note_cnt">
                    <div style="color: #ff0000; font-size: 16px; text-align: left; height: 25px;
                        padding: 3px; border-bottom: solid 1px #ededed; margin-bottom: 5px;
                        font-family: Arial;">
                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                    </div>
                    <asp:Label runat="server" ID="lblNote" CssClass="login_desc">
                    </asp:Label>
                </div>
            </asp:PlaceHolder>
            <div style="position:absolute; top:455px; z-index:2; padding:10px; width:440px; ">
               &nbsp;</div>
        </div>
    </form>
</body>
</html>
