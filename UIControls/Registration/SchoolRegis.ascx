<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SchoolRegis.ascx.vb"
    Inherits="UIControls_Regsitration_SchoolRegis" %>
<%@ Register Src="SelectIndustry.ascx" TagName="SelectIndustry" TagPrefix="uc2" %>
<style>
    .ModalPopupBG
    {
        background-color: #000;
        filter: alpha(opacity=50);
        opacity: 0.7;
    }
    
    .HellowWorldPopup
    {
        background: white;
        padding: 5px 15px 5px 15px;
    }
</style>
<div class="MyForum">
    <asp:Label runat="server" ID="lblInfo" EnableViewState="false" Visible="false" Font-Bold="true"
        ForeColor="Green" />
    <asp:Label runat="server" ID="lblError" EnableViewState="false" Visible="false" ForeColor="Red" />
    <asp:PlaceHolder runat="server" ID="tblForm">
        <div class="btn_holder">
            <span class="btn_move" style="padding: ">
                <asp:LinkButton runat="server" ID="lbtSave" Text="Save"></asp:LinkButton></span>
            <span class="btn_move" style="padding: " runat="server" id="spnCancel">
                <asp:LinkButton runat="server" ID="lbtCancel" Text="Cancel"></asp:LinkButton></span>
        </div>
        <table>
            <asp:UpdatePanel runat="server" ID="up1" UpdateMode="Always">
                <ContentTemplate>
                    <tr>
                        <td class="FieldLabel" width="200px;">
                            <b>Select Type:</b>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddSelectType" CssClass="TextBoxField" AutoPostBack="true">
                                <asp:ListItem Text="School" Value="School"></asp:ListItem>
                                <asp:ListItem Text="Government" Value="Government"></asp:ListItem>
                                <asp:ListItem Text="Media" Value="Media"></asp:ListItem>
                                <asp:ListItem Text="Parks & Recreation" Value="Parks & Recreation"></asp:ListItem>
                                <asp:ListItem Text="Groups (General)" Value="Groups"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="phSchool">
                        <tr>
                            <td class="FieldLabel">
                                <b>Education Level:</b>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddEducationlevel">
                                    <asp:ListItem Text="Pre-School" Value="Pre-School"></asp:ListItem>
                                    <asp:ListItem Text="Primary School" Value="Primary School"></asp:ListItem>
                                    <asp:ListItem Text="Middle School" Value="Middle School"></asp:ListItem>
                                    <asp:ListItem Text="Secondary" Value="Secondary"></asp:ListItem>
                                    <asp:ListItem Text="Undergraduate" Value="Undergraduate"></asp:ListItem>
                                    <asp:ListItem Text="Postgraduate" Value="Postgraduate"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </asp:PlaceHolder>
                    <tr runat="server" id="trGovtType">
                        <td class="FieldLabel">
                            <b>Government Level:</b>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddGovtType">
                                <asp:ListItem Text="Local" Value="Local"></asp:ListItem>
                                <asp:ListItem Text="State or Territory" Value="State or Territory"></asp:ListItem>
                                <asp:ListItem Text="Federal" Value="Federal"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr runat="server" id="trMediaType">
                        <td class="FieldLabel">
                            <b>Media Type:</b>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddMediaType">
                                <asp:ListItem Text="Print" Value="Print"></asp:ListItem>
                                <asp:ListItem Text="Internet" Value="Internet"></asp:ListItem>
                                <asp:ListItem Text="Radio" Value="Radio"></asp:ListItem>
                                <asp:ListItem Text="Television" Value="Television"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>
                                <asp:Label Text="User Name:" runat="server" ID="lblUserName"></asp:Label></b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtSchoolName" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Contact Person:</b><br />
                            (Information will be kept Private)
                        </td>
                        <td valign="top">
                            <asp:TextBox runat="server" ID="txtContactPerson" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Contact Person's Email:</b><br />
                            (Information will be kept Private)
                        </td>
                        <td valign="top">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Contact Person's Telephone Number:</b><br />
                            (Information will be kept Private)
                        </td>
                        <td valign="top">
                            <asp:TextBox runat="server" ID="txtContactPhone" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Industry:</b>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnIndustry" Text="Select Industry" />
                            <asp:Label runat="server" ID="lblIndustry" Text=""></asp:Label>
                            <asp:Panel runat="server" ID="pnlIndustry">
                                <div class="HellowWorldPopup">
                                    <div style="padding: 5px; text-align: right; background-color: #EAEAEA;">
                                        <asp:LinkButton runat="server" ID="lbtCloseIndustry" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                                    </div>
                                    <uc2:SelectIndustry ID="SelectIndustry1" runat="server" />
                                </div>
                            </asp:Panel>
                            <ajaxToolkit:ModalPopupExtender runat="server" ID="mpIndustry" PopupControlID="pnlIndustry"
                                BackgroundCssClass="ModalPopupBG" TargetControlID="btnIndustry" CancelControlID="lbtCloseIndustry">
                            </ajaxToolkit:ModalPopupExtender>
                            <input type="hidden" runat="server" id="hidIndustry" />
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
                            <b>Telephone Number:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTelephoneNumber" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Description:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="TextBoxField" TextMode="MultiLine"
                                Height="60"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Address Line 1:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAddress1" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Address Line 2:</b>
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
                            <asp:DropDownList runat="server" ID="ddCountry" AutoPostBack="true" Width="140px">
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddState" Width="140px">
                            </asp:DropDownList>
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
                            <b>Alternative Address 1:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAlternativeAddress1" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Alternative Address 2:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAlternativeAddress2" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Alternative Country:</b>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddCountry2" AutoPostBack="true" Width="140px">
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddState2" Width="140px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Alternative City:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtCity2" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Zip Code:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAlternativeZipCode" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Status:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtStatus" CssClass="TextBoxField" TextMode="MultiLine"
                                Height="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Hours of Operation:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtHoursofOperation" CssClass="TextBoxField"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>About:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAbout" CssClass="TextBoxField" TextMode="MultiLine"
                                Height="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="FieldLabel">
                            <b>Number of Employees:</b><br />
                            (Information will be kept Private)
                        </td>
                        <td valign="top">
                            <asp:TextBox runat="server" ID="txtNumberofEmployees" CssClass="TextBoxField"></asp:TextBox>
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
                </ContentTemplate>
            </asp:UpdatePanel>
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
                        <asp:CheckBox runat="server" ID="chkPrivacy" Text="" />
                        I understand, agree, and accept the UNIonVERSE <a href="http://www.unionverse.com/Terms.aspx">
                            Terms & Conditions</a>, UNIonVERSE <a href="http://www.unionverse.com/plateform-policy.aspx">
                                Policy Rights and Responsibilities</a>, and WormWholes <a href="http://www.wormwholes.com/Terms.aspx">
                                    Privacy Policy, Rights and Responsibilities</a>.</small>
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
            <span class="btn_move" style="padding: ">
                <asp:LinkButton runat="server" ID="btnOk" Text="Save"></asp:LinkButton></span>
        </div>
    </asp:PlaceHolder>
</div>
