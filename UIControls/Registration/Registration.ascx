<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Registration.ascx.vb"
    Inherits="UIControls_Registration_Registration" %>
<script type="text/javascript" src="../../Scripts/Tabs/jquery-1.10.2.js"></script>
<style type="text/css">
    .VeryPoorStrength
    {
        background: Red;
        color: White;
        font-weight: bold;
    }
    .WeakStrength
    {
        background: Gray;
        color: White;
        font-weight: bold;
    }
    .AverageStrength
    {
        background: orange;
        color: black;
        font-weight: bold;
    }
    .GoodStrength
    {
        background: blue;
        color: White;
        font-weight: bold;
    }
    .ExcellentStrength
    {
        background: Green;
        color: White;
        font-weight: bold;
    }
    .BarBorder
    {
        border-style: solid;
        border-width: 1px;
        width: 180px;
        padding: 2px;
    }
</style>
<div class="MyForum">
    <asp:Label ID="lblError" runat="server" EnableViewState="false" ForeColor="red" />
    <asp:Label ID="lblText" runat="server" EnableViewState="false" Visible="false" />
    <asp:Panel ID="pnlForm" runat="server" DefaultButton="btnOK">
        <table>
            <tr id="trGroupType" runat="server">
                <td class="FieldLabel">
                    <asp:Label ID="lblGroupType1lbl" runat="server" EnableViewState="false" Text="Religious Sanctuaries:" />
                </td>
                <td>
                    <asp:Label ID="lblGroupType1" Font-Bold="true" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="FieldLabel" width="120px">
                    Username:
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="TextBoxField" MaxLength="100"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                        ErrorMessage="Enter Username." Display="Dynamic" EnableViewState="false" ValidationGroup="pnlForm" />
                </td>
            </tr>
            <tr>
                <td class="FieldLabel">
                    E-mail:
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBoxField" MaxLength="100"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Please enter some e-mail" EnableViewState="false"
                        ValidationGroup="pnlForm" />
                    <asp:RegularExpressionValidator runat="server" ID="rfvValidate" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Please enter valid Email ID." EnableViewState="false"
                        ValidationGroup="pnlForm" ValidationExpression="^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="FieldLabel">
                    Password:
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBoxField" MaxLength="100"
                        TextMode="Password" onkeypress="getPasswordStrengthState()" />
                                            <br />
                    <asp:Label ID="lblhelp1" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="Enter a Password" EnableViewState="false" ValidationGroup="pnlForm" />
                    <ajaxToolkit:PasswordStrength ID="PasswordStrength1" TargetControlID="txtPassword"
                        BehaviorID="myPSBID" StrengthIndicatorType="BarIndicator" PrefixText="Strength:"
                        HelpStatusLabelID="lblhelp1" PreferredPasswordLength="8" MinimumNumericCharacters="1"
                        MinimumSymbolCharacters="1" MinimumUpperCaseCharacters="1" RequiresUpperAndLowerCaseCharacters="true"
                        BarBorderCssClass="BarBorder" TextStrengthDescriptionStyles="VeryPoorStrength;WeakStrength;
                                    AverageStrength;GoodStrength;ExcellentStrength" runat="server">
                    </ajaxToolkit:PasswordStrength>
                </td>
            </tr>
            <tr>
                <td class="FieldLabel">
                    Confirm Password:
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="TextBoxField" MaxLength="100"
                        TextMode="Password" />
                    <br />
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                        Display="Dynamic" ErrorMessage="Enter a Password" EnableViewState="false" ValidationGroup="pnlForm" />
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    Enter Security Code:
                </td>
                <td>
                    <asp:TextBox ID="txtSecurityCode" runat="server" CssClass="TextBoxField" MaxLength="100"></asp:TextBox><br />
                    <img alt='Enter the code you see in the image' src="<%=UIHelper.GetBasePath & "/JpegImage.aspx"%>" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <small>
                        <asp:CheckBox runat="server" ID="chkPrivacy" />
                        <asp:Literal runat="server" ID="lblTerms"></asp:Literal>
                        <%-- I understand, agree, and accept the UNIonVERSE <a href="http://www.unionverse.com/Terms.aspx">Terms & Conditions</a>, UNIonVERSE <a href="http://www.unionverse.com/plateform-policy.aspx">Policy Rights and Responsibilities</a>, and WormWholes <a href="http://www.wormwholes.com/Terms.aspx">Payment Terms</a>.  Further, we hereby agree, understand and accept that all UNI, and the equivalent withdrawal currencies, are donations, and UNIonVERSE is not obligated to any contractual monetary agreement.--%>
                    </small>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                </td>
                <td style="height: 26px">
                    <span class="btn_move">
                        <asp:Button ID="btnOk" runat="server" EnableViewState="false" ValidationGroup="pnlForm"
                            Text="Continue" visisble="false"  />
                    </span>
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
<asp:HiddenField runat="server" ID="hdnStrength" Value="0" />
<script type="text/javascript" language="javascript">
    function getPasswordStrengthState() {
        //        if ($("[id$=txtPassword]").val() != "") {
        //            if ($find("myPSBID")._getPasswordStrength() != 100) {
        //                $("[id$=lblError]").text("Password does not meet the minimum requirments.");
        //                return false;
        //            }
        //        }

        if ($find("myPSBID")._getPasswordStrength() == 100) {
            
            $("[id$=hdnStrength]").val('1');

        }

    }
</script>
