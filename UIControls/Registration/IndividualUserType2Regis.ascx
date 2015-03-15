<%@ Control Language="VB" AutoEventWireup="false" CodeFile="IndividualUserType2Regis.ascx.vb"
    Inherits="CMSModules_Membership_Controls_IndividualUserType2Regis" %>
<div class="MyForum">
    <asp:Label runat="server" ID="lblInfo" EnableViewState="false" Visible="false" Font-Bold="true"
        ForeColor="Green" />
    <asp:Label runat="server" ID="lblError" EnableViewState="false" Visible="false" CssClass="Error" />
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
                First Name:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Last Name:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtLastName" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Address 1:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAddress1" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Address 2:
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
                Zip Code:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtZipCode" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Level of Education:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddEducationLevel" CssClass="TextBoxField">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                College Attended:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCollegeAttended" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Degree In:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDegreeIn" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Employer Name:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmployerName" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Current Position:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCurrentPosition" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Type of Agent:
            </td>
            <td>
                <asp:UpdatePanel runat="server" ID="up1">
                    <ContentTemplate>
                        <asp:DropDownList runat="server" ID="ddTypeofAgent" CssClass="TextBoxField" AutoPostBack="true">
                            <asp:ListItem Text="Mortgage Originator" Value="Mortgage Originator"></asp:ListItem>
                            <asp:ListItem Text="Realtor" Value="Realtor"></asp:ListItem>
                            <asp:ListItem Text="Car Salesman" Value="Car Salesman"></asp:ListItem>
                            <asp:ListItem Text="Insurance Broker" Value="Insurance Broker"></asp:ListItem>
                            <asp:ListItem Text="Business Banker" Value="Business Banker"></asp:ListItem>
                            <asp:ListItem Text="Personal Banker" Value="Personal Banker"></asp:ListItem>
                            <asp:ListItem Text="Attorney" Value="Attorney"></asp:ListItem>
                            <asp:ListItem Text="Load Consolidator" Value="Loan Consolidator"></asp:ListItem>
                            <asp:ListItem Text="Financial Advisor" Value="Financial Advisor"></asp:ListItem>
                            <asp:ListItem Text="Accountant" Value="Accountant"></asp:ListItem>
                            <asp:ListItem Text="Credit Card Counselor" Value="Credit Card Consolidator"></asp:ListItem>
                            <asp:ListItem Text="Doctor" Value="Doctor"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ddInsuranceBroker" Visible="false">
                            <asp:ListItem Text="Auto, Home, and/or Boat" Value="Auto, Home, and/or Boat"></asp:ListItem>
                            <asp:ListItem Text="Supplemental" Value="Supplemental"></asp:ListItem>
                            <asp:ListItem Text="Life and Casualty" Value="Life and Casualty"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ddDoctor" Visible="false">
                            <asp:ListItem Text="Physician" Value="Physician"></asp:ListItem>
                            <asp:ListItem Text="Veterinarian" Value="Veterinarian"></asp:ListItem>
                            <asp:ListItem Text="Optometrist" Value="Optometrist"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtAttorney" Visible="false"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Years of Experience:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddYearsofExperience" CssClass="TextBoxField">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Business Address 1:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtBusinessAddress1" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Business Address 2:
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
                Zip Code:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtBusinessZipCode" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Work Telephone Number:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtWorkTelephoneNumber" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Personal Telephone Number:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPersonalTelephoneNumber" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                Personal Email Address:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPersonalEmailAddress" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr runat="server" id="trViewable" visible="false">
            <td class="FieldLabel">
                Is Viewable:
            </td>
            <td>
                <asp:CheckBox runat="server" ID="chkIsViewable" />
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                About:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAbout" CssClass="TextBoxField" TextMode="MultiLine"
                    Height="50"></asp:TextBox>
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
            <asp:LinkButton runat="server" ID="btnOk" Text="Save"></asp:LinkButton></span></div>
</div>
