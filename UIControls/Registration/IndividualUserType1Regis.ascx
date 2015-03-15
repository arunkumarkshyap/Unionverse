<%@ Control Language="VB" AutoEventWireup="false" CodeFile="IndividualUserType1Regis.ascx.vb"
    Inherits="CMSModules_Membership_Controls_IndividualUserType1Regis" EnableViewState="true" %>
<div class="MyForum">
    <asp:Label runat="server" ID="lblInfo" EnableViewState="false" Visible="false" Font-Bold="true"
        ForeColor="Green" />
    <asp:Label runat="server" ID="lblError" EnableViewState="false" Visible="false" CssClass="Error"
        ForeColor="Red" />
    <div class="btn_holder">
        <span class="btn_move" style="padding: ">
            <asp:LinkButton runat="server" ID="lbtSave" Text="Save"></asp:LinkButton></span>
            
        <span class="btn_move" style="padding: " runat="server" id="spnCancel">
            <asp:LinkButton runat="server" ID="lbtCancel" Text="Cancel"></asp:LinkButton></span>
    </div>
    <table>
        <tr id="trUserName" runat="server" visible="false">
            <td class="FieldLabel" width="190px">
                <b>Username:</b><br />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtUsername" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel" width="190px">
                <b>First Name:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Last Name:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtLastName" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Address1:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAddress1" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Address2:</b>
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
                <b>Level of Education:</b>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddEducationLevel" CssClass="TextBoxField">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>College Attended:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCollegeAttended" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Degree In:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDegreeIn" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Employer Name:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmployerName" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Current Position:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCurrentPosition" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Year of Experience:</b>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddExperience" CssClass="TextBoxField">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Business Address 1:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtBusinessAddress1" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Business Address 2:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtBusinessAddress2" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Business Country:</b>
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
                <b>Business City:</b>
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
                <asp:TextBox runat="server" ID="txtBusinessZipCode" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Personal Telephone Number:</b><br />
                (Information will be kept Private)
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtPersonalTelephoneNumber" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Personal Email Address:</b><br />
                (Information will be kept Private)
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtPersonalEmailAddress" CssClass="TextBoxField"></asp:TextBox>
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
                <b>Gender:</b>
            </td>
            <td>
                <asp:RadioButtonList runat="server" ID="rbGender">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
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
        <tr runat="server" id="trPrivacy">
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
</div>
