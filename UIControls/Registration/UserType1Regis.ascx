<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UserType1Regis.ascx.vb"
    Inherits="UIControls_Registration_UserType1Regis" %>
    
<div class="MyForum">
    <asp:Label runat="server" ID="lblInfo" EnableViewState="false" Visible="false" ForeColor="Green"
        Font-Bold="true" />
    <asp:Label runat="server" ID="lblError" EnableViewState="false" Visible="false" ForeColor="Red" />
    <div class="btn_holder">
        <span class="btn_move">
            <asp:LinkButton runat="server" ID="lbtSave" Text="Save"></asp:LinkButton></span>
        <span class="btn_move" style="padding: " runat="server" id="spnCancel">
            <asp:LinkButton runat="server" ID="lbtCancel" Text="Cancel"></asp:LinkButton></span>
    </div>
    <table runat="server" id="tblForm">
        <tr>
            <td colspan="2">
                <b>Individual's Registration URL:</b>
                <asp:Label runat="server" ID="lblURL"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel" width="200px">
                <b>Religious Sanctuary User Name:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtGroupTypeUsername" CssClass="TextBoxField" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel" width="200px">
                <b>Religious Sanctuary Full Name:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFullName" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel" width="200px">
                <b>Religious Sanctuary Legal Name:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtLegalName" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel" width="200px">
                <b>Tax ID Number:</b><br />
                (Information will be kept Private)
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTaxIDNumber" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Religious Sanctuary Leader:</b><br />
                (Star of Solar System)
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtLeaderofGroupType1User" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Religious Sanctuary Leader's Mobile Number:</b><br />
                (In Case Of Emergency)
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtMobileNumber" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Contact Person:</b><br />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtContactPerson" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Contact Person's Email Address:</b><br />
                (Information will be kept Private)
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtPersoanlEmailAddress" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Contact Person's Telephone Number:</b><br />
                (Information will be kept Private)
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Galaxy:</b>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddGalaxy" CssClass="TextBoxField">
                    <asp:ListItem Text="-- Select Galaxy Type --" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Baha'i Faith" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Buddhism" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Christianity" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Hinduism" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Islam" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Jainism" Value="6"></asp:ListItem>
                    <asp:ListItem Text="Judaism" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Other Galaxies" Value="8"></asp:ListItem>
                    <asp:ListItem Text="Sikhism" Value="9"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr runat="server" id="trFaith" style="display: none;">
            <td class="FieldLabel">
                <b>Faith:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtfaith" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Sub-Denomination:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtUserTypeType" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Website Address:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtWebsiteAddress" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Address 1:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAddress1" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Address 2:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAddress2" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Country:</b>
            </td>
            <td>
            <asp:UpdatePanel runat="server" ID="UPgROUP1">
    <ContentTemplate>
                <asp:DropDownList runat="server" ID="ddCountry" AutoPostBack="true" Width="140px">
                </asp:DropDownList>
                <asp:DropDownList runat="server" ID="ddState" Width="140px">
                </asp:DropDownList>
                </ContentTemplate></asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>City:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCity" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Zip Code:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtZipCode" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Number of Religious Sanctuary Employees:</b><br />
                (Information will be kept Private)
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtNumerofEmployees" CssClass="txtNumberofEmployees"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Religious Sanctuary Member Size:</b><br />
                (Information will be kept Private)
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtMemberSize" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr runat="server" id="trViewable" visible="false">
            <td class="FieldLabel">
                <b>Is Viewable:</b>
            </td>
            <td>
                <asp:CheckBox runat="server" ID="chkIsViewable" />
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>About:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAbout" CssClass="TextBoxField" Height="50" TextMode="MultiLine" placeholder="Please describe your Religious Sanctuary"></asp:TextBox>
            </td>
        </tr>
        <tr id="trProfileImage" runat="server" visible="false">
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Image runat="server" ID="imgProfile" />&nbsp;<asp:LinkButton runat="server"
                    ID="btnRemove" Text="X" ForeColor="Red"></asp:LinkButton>
                <asp:HiddenField runat="server" ID="hdnImage" Value="0" />
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Upload Image:</b>
            </td>
            <td>
                <asp:FileUpload runat="server" ID="upAvatar" />
            </td>
        </tr>
        <tr id="trPrivacy" runat="server">
            <td>
            </td>
            <td>
                <small>
                    <asp:CheckBox runat="server" ID="chkPrivacy" />
                    I understand, agree, and accept the UNIonVERSE <a href="http://www.unionverse.com/Terms.aspx">
                        Terms & Conditions</a>, UNIonVERSE <a href="http://www.unionverse.com/plateform-policy.aspx">
                            Policy Rights and Responsibilities</a>, and WormWholes <a href="http://www.wormwholes.com/Terms.aspx">
                                Payment Terms</a>. Further, we hereby agree, understand and accept that
                    all UNI, and the equivalent withdrawal currencies, are donations, and UNIonVERSE
                    is not obligated to any contractual monetary agreement.</small>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <div class="btn_holder">
        <span class="btn_move">
            <asp:LinkButton runat="server" ID="btnOk" Text="Save"></asp:LinkButton></span>
    </div>
</div>
<script type="text/javascript">
    $(function () {
        $("[id$=ddGalaxy]").change(function () {

            if ($(this).val() == "8") {
                $("[id$=trFaith]").show()

            }
            else {
                $("[id$=trFaith]").hide()
            }

        });
    });
</script>
