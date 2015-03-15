<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GroupType4Regis.ascx.vb"
    Inherits="UIControls_Registration_GroupType4Regis" %>
<%@ Register Src="SelectIndustry.ascx" TagName="SelectIndustry" TagPrefix="uc2" %>
<%@ Register src="SelectCharity.ascx" tagname="SelectCharity" tagprefix="uc1" %>
<%@ Register src="SelectNonProfit.ascx" tagname="SelectNonProfit" tagprefix="uc3" %>

<style>
    .ModalPopupBG { background-color: #fff; filter: alpha(opacity=50); opacity: 0.7; }
    .HellowWorldPopup { background: white; padding: 5px 15px 5px 15px; }
</style>

<div class="MyForum">
    <asp:Label runat="server" ID="lblInfo" EnableViewState="false" Visible="false"  ForeColor="Green" Font-Bold="true"/>
    <asp:Label runat="server" ID="lblError" EnableViewState="false" Visible="false" ForeColor="Red" />
    <div class="btn_holder">
        <span class="btn_move">
            <asp:LinkButton runat="server" ID="lbtSave" Text="Save"></asp:LinkButton></span>
    </div>
    <table runat="server" id="tblForm">
        <tr>
            <td class="FieldLabel">
                <b>User Name:</b>
            </td>
            <td>
                <asp:Label runat="server" ID="lblUsername" CssClass="TextBoxField"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Company Legal Name:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCompanyName" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Select Type:</b>
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddType" AutoPostBack="true">
                    <asp:ListItem Text="Charity" Value="Charity"></asp:ListItem>
                    <asp:ListItem Text="Non Profit" Value="Non Profit"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr runat="server" id="trCharity" visible="false">
            <td class="FieldLabel">
                <b>Charity Type:</b>
            </td>
            <td>
                <asp:UpdatePanel runat="server" ID="up4">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnCharity" Text="Select Charity Type" />
                        <asp:Label runat="server" ID="lblCharity" Text=""></asp:Label>
                        <asp:Panel runat="server" ID="pnlCharity">
                            <div class="HellowWorldPopup">
                                <div style="padding: 5px; text-align: right; background-color: #EAEAEA;">
                                    <asp:LinkButton runat="server" ID="lbtCloseCharity" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                                </div>
                                <uc1:SelectCharity ID="SelectCharity1" runat="server" />
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpCharity" PopupControlID="pnlCharity"
                            BackgroundCssClass="ModalPopupBG" TargetControlID="btnCharity" CancelControlID="lbtCloseCharity" >
                        </ajaxToolkit:ModalPopupExtender>
                        <input type="hidden" runat="server" id="hidCharity" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Sub-Classification:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtUserType" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr runat="server" id="trNonProfit" visible="false">
            <td class="FieldLabel">
                <b>Non Profit Type:</b>
            </td>
            <td>
                <asp:UpdatePanel runat="server" ID="up2">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnNonProfit" Text="Select Non Profit Type" />
                        <asp:Label runat="server" ID="lblNonProfit" Text=""></asp:Label>
                        <asp:Panel runat="server" ID="pnlNonProfit">
                            <div class="HellowWorldPopup">
                                <div style="padding: 5px; text-align: right; background-color: #EAEAEA;">
                                    <asp:LinkButton runat="server" ID="lbtNonProfitClose" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                                </div>
                                <uc3:SelectNonProfit ID="SelectNonProfit1" runat="server" />
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpNonProfit" PopupControlID="pnlNonProfit"
                            BackgroundCssClass="ModalPopupBG" TargetControlID="btnNonProfit" CancelControlID="lbtNonProfitClose">
                        </ajaxToolkit:ModalPopupExtender>
                        <input type="hidden" runat="server" id="hidNonProfit" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Tax ID:</b><br />
                (Information will be kept private)
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTaxID" CssClass="TextBoxField"></asp:TextBox>
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
        <tr runat="server" id="trIndustry">
            <td class="FieldLabel">
                <b>Industry:</b>
            </td>
            <td>
                <asp:UpdatePanel runat="server" ID="up1">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnIndustry" Text="Select Industry" />
                        <asp:Label runat="server" ID="lblIndustry" Text=""></asp:Label>
                        <asp:Panel runat="server" ID="pnlIndustry">
                            <div class="HellowWorldPopup">
                                <div style="padding: 5px; text-align: right; background-color: #EAEAEA;">
                                    <asp:LinkButton runat="server" ID="lbtIndustryClose" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                                </div>
                                <uc2:SelectIndustry ID="SelectIndustry1" runat="server" />
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpIndustry" PopupControlID="pnlIndustry"
                            BackgroundCssClass="ModalPopupBG" TargetControlID="btnIndustry" CancelControlID="lbtIndustryClose">
                        </ajaxToolkit:ModalPopupExtender>
                        <input type="hidden" runat="server" id="hidIndustry" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Description:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDescription" CssClass="TextBoxField" TextMode="MultiLine"
                    Height="50"></asp:TextBox>
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
                <b>Headquarters Address Line 1:</b>
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
                <asp:DropDownList runat="server" ID="ddCountry" AutoPostBack="true">
                </asp:DropDownList>
                <asp:DropDownList runat="server" ID="ddState">
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
                <b>Number of Employees:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNumberOfEmployees" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>About:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAbout" CssClass="TextBoxField" Height="50" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr id="trProfileImage" runat="server" visible="false">
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Image runat="server" ID="imgProfile" />&nbsp;<asp:LinkButton runat="server" ID="btnRemove" Text="X" ForeColor="Red"></asp:LinkButton>
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
            <td colspan="2">
                <asp:CheckBox runat="server" ID="chkPrivacy" /> &nbsp;
                I understand, agree, and accept the UNIonVERSE <a href="<%=UIHelper.GetUnionVerseBasePathURL()+"/Terms.aspx"%>">
                    Terms & Conditions</a>, UNIonVERSE <a href="<%=UIHelper.GetUnionVerseBasePathURL() + "/plateform-policy.aspx"%>">
                        Policy Rights and Responsibilities</a>, and WormWholes <a href="<%=UIHelper.GetWormWholesBasePathURL()+"/Terms.aspx"%>">
                            Payment Terms</a>.
            </td>
        </tr>

        
    </table>
    <div class="btn_holder">
        <span class="btn_move">
           <asp:LinkButton runat="server" ID="btnOk" Text="Save" ></asp:LinkButton>
    </div>
       
</div>
