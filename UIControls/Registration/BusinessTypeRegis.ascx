<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BusinessTypeRegis.ascx.vb"
    Inherits="CMSModules_Membership_Controls_BusinessTypeRegis" %>
<%@ Register Src="FranchiseAddEdit.ascx" TagName="FranchiseAddEdit" TagPrefix="uc1" %>
<%@ Register Src="SelectIndustry.ascx" TagName="SelectIndustry" TagPrefix="uc2" %>
<%@ Register Src="Geographical.ascx" TagName="Geographical" TagPrefix="uc3" %>
<%@ Register Src="NonGeographical.ascx" TagName="NonGeographical" TagPrefix="uc4" %>
<%@ Register Src="BothGeoNonGeo.ascx" TagName="BothGeoNonGeo" TagPrefix="uc5" %>
<%@ Register Src="Unionversal.ascx" TagName="Unionversal" TagPrefix="uc5" %>
<%@ Register Src="IndustrySpecific.ascx" TagName="IndustrySpecific" TagPrefix="uc5" %>
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
    
    #overlay
    {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: #000;
        filter: alpha(opacity=70);
        -moz-opacity: 0.7;
        -khtml-opacity: 0.7;
        opacity: 0.7;
        z-index: 100;
        display: none;
    }
    .content a
    {
        text-decoration: none;
    }
    .popup1
    {
        width: 100%;
        margin: 0 auto;
        display: none;
        position: relative;
        z-index: 101;
    }
    .content
    {
        min-width: 450px;
        width: 450px;
        min-height: 150px;
        margin: -750px auto -360px -100px;
        background: #f3f3f3;
        position: absolute;
        z-index: 103;
        padding: 10px;
        border-radius: 5px;
        box-shadow: 0 2px 5px #000;
    }
    .content p
    {
        clear: both;
        color: #555555;
        text-align: justify;
    }
    .content p a
    {
        color: #d91900;
        font-weight: bold;
    }
    .content .x
    {
        float: right;
        height: 35px;
        left: 22px;
        position: relative;
        top: -25px;
        width: 34px;
    }
    .content .x:hover
    {
        cursor: pointer;
    }
</style>
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
    <table runat="server" id="tblForm">
        <tr runat="server" id="trFranchiseLink">
            <td class="FieldLabel" width="200px">
                <b>Franchise Registraion Link:</b>
            </td>
            <td>
                <asp:Label runat="server" ID="lblfranchiseLink"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel" width="200px">
                <b>User Name:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtUserName" CssClass="TextBoxField" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel" width="200px">
                <b>Company Name:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCompanyName" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Tax ID:</b><br />
                (Information will be kept Private)
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtTaxID" CssClass="TextBoxField"></asp:TextBox>
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
                <b>Contact Person's Email Address:</b><br />
                (Information will be kept Private)
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtPersonalEmail" CssClass="TextBoxField"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Contact Person's Telephone Number:</b><br />
                (Information will be kept Private)
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtTelephoneNumber" CssClass="TextBoxField"></asp:TextBox>
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
        <tr runat="server" id="trMainFranchise">
            <td class="FieldLabel">
                <b>Are you a Franchise:</b>
            </td>
            <td valign="top">
                <asp:RadioButtonList runat="server" ID="rbFranchise" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                    <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr runat="server" id="trFranchise" style="display: none;">
            <td class="FieldLabel">
                <b>Are you The Parent Company or Franchise:</b>
            </td>
            <td valign="top">
                <asp:RadioButtonList runat="server" ID="rpParentOrFranchise">
                    <asp:ListItem Text="Parent Company" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Franchise" Value="1" ></asp:ListItem>
                </asp:RadioButtonList>
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
                                    <asp:LinkButton runat="server" ID="lbtCloseIndustry" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                                </div>
                                <uc2:SelectIndustry ID="SelectIndustry1" runat="server" />
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpIndustry" PopupControlID="pnlIndustry"
                            BackgroundCssClass="ModalPopupBG" TargetControlID="btnIndustry" CancelControlID="lbtCloseIndustry">
                        </ajaxToolkit:ModalPopupExtender>
                        <input type="hidden" runat="server" id="hidIndustry" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr runat="server" id="trEcommerce">
            <td class="FieldLabel">
                <b>E-Commerce Store:</b>
            </td>
            <td>
                Check Box if NO<asp:CheckBox runat="server" ID="chkNoStore" />
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Type of Company:</b>
            </td>
            <td>
                <asp:RadioButtonList runat="server" ID="rbCompanyType" AutoPostBack="true">
                    <asp:ListItem Text="Business to Consumer" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Business to Business" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="FieldLabel">
                <b>Store Type:</b>
            </td>
            <td>
                <asp:RadioButtonList runat="server" ID="rbStoreType" AutoPostBack="true">
                    <asp:ListItem Text="Geographical (Local Community)" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Non-Geographical (UNIonVERSAL)" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RadioButtonList runat="server" ID="rbBusinessType" AutoPostBack="true" Visible="false">
                    <asp:ListItem Text="UNIonVERSAL" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Industry Specific" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr runat="server" id="trGeo">
            <td class="FieldLabel">
                <b>Select from Geographical (Local Community):</b>
            </td>
            <td valign="top">
                <asp:UpdatePanel runat="server" ID="up4">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnGeo" Text="Select" />
                        <asp:Label runat="server" ID="lblGeo" Text=""></asp:Label>
                        <asp:Panel runat="server" ID="pnlGeo">
                            <div class="HellowWorldPopup">
                                <div style="padding: 5px; text-align: right; background-color: #EAEAEA;">
                                    <asp:LinkButton runat="server" ID="lbtCloseGeo" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                                </div>
                                <uc3:Geographical ID="Geographical1" runat="server" />
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpGeo" PopupControlID="pnlGeo"
                            BackgroundCssClass="ModalPopupBG" TargetControlID="btnGeo" CancelControlID="lbtCloseGeo">
                        </ajaxToolkit:ModalPopupExtender>
                        <input type="hidden" runat="server" id="hidGeo" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr runat="server" id="trNonGeo" visible="false">
            <td class="FieldLabel">
                <b>Select from Non-Geographical (UNIonVERSAL):</b>
            </td>
            <td valign="top">
                <asp:UpdatePanel runat="server" ID="up2">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnNonGeo" Text="Select" />
                        <asp:Label runat="server" ID="lblNonGeo" Text=""></asp:Label>
                        <asp:Panel runat="server" ID="pnlNonGeo">
                            <div class="HellowWorldPopup">
                                <div style="padding: 5px; text-align: right; background-color: #EAEAEA;">
                                    <asp:LinkButton runat="server" ID="lbtCloseNonGeo" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                                </div>
                                <uc4:NonGeographical ID="NonGeographical1" runat="server" />
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpNonGeo" PopupControlID="pnlNonGeo"
                            BackgroundCssClass="ModalPopupBG" TargetControlID="btnNonGeo" CancelControlID="lbtCloseNonGeo">
                        </ajaxToolkit:ModalPopupExtender>
                        <input type="hidden" runat="server" id="hidNonGeo" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr runat="server" id="trboth" visible="false">
            <td class="FieldLabel">
                <b>Select from Both:</b>
            </td>
            <td>
                <asp:UpdatePanel runat="server" ID="up3">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnBoth" Text="Select" />
                        <asp:Label runat="server" ID="lblBoth" Text=""></asp:Label>
                        <asp:Panel runat="server" ID="pnlBoth">
                            <div class="HellowWorldPopup">
                                <div style="padding: 5px; text-align: right; background-color: #EAEAEA;">
                                    <asp:LinkButton runat="server" ID="lbtCloseBoth" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                                </div>
                                <uc5:BothGeoNonGeo ID="BothGeoNonGeo1" runat="server" />
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpBoth" PopupControlID="pnlBoth"
                            BackgroundCssClass="ModalPopupBG" TargetControlID="btnBoth" CancelControlID="lbtCloseBoth">
                        </ajaxToolkit:ModalPopupExtender>
                        <input type="hidden" runat="server" id="hidBoth" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr runat="server" id="trUnionVerse" visible="false">
            <td class="FieldLabel">
                <b>Select from UNIonVERSAL:</b>
            </td>
            <td>
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnUnionVerse" Text="Select" />
                        <asp:Label runat="server" ID="lblUnionverse" Text=""></asp:Label>
                        <asp:Panel runat="server" ID="pnlUnionverse">
                            <div class="HellowWorldPopup">
                                <div style="padding: 5px; text-align: right; background-color: #EAEAEA;">
                                    <asp:LinkButton runat="server" ID="lbtUnionverse" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                                </div>
                                <uc5:Unionversal ID="Unionversal" runat="server" />
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpeUnionverse" PopupControlID="pnlUnionverse"
                            BackgroundCssClass="ModalPopupBG" TargetControlID="btnUnionVerse" CancelControlID="lbtUnionverse">
                        </ajaxToolkit:ModalPopupExtender>
                        <input type="hidden" runat="server" id="hdnUnionverse" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr runat="server" id="trIndSpecific" visible="false">
            <td class="FieldLabel">
                <b>Select from Industry Specific:</b>
            </td>
            <td>
                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="btnIndSpecific" Text="Select" />
                        <asp:Label runat="server" ID="lblIndSpecific" Text=""></asp:Label>
                        <asp:Panel runat="server" ID="pnlIndSpecific">
                            <div class="HellowWorldPopup">
                                <div style="padding: 5px; text-align: right; background-color: #EAEAEA;">
                                    <asp:LinkButton runat="server" ID="lbtSpecific" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                                </div>
                                <uc5:IndustrySpecific ID="IndustrySpecific" runat="server" />
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="mpeIndSpecific" PopupControlID="pnlIndSpecific"
                            BackgroundCssClass="ModalPopupBG" TargetControlID="btnIndSpecific" CancelControlID="lbtSpecific">
                        </ajaxToolkit:ModalPopupExtender>
                        <input type="hidden" runat="server" id="hdnIndSpecific" />
                    </ContentTemplate>
                </asp:UpdatePanel>
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
        <tr>
            <td class="FieldLabel">
                <b>About:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtAbout" TextMode="MultiLine" CssClass="TextBoxField"
                    Height="50"></asp:TextBox>
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
                    for the use of the UNIonVERSE Platform, UNIonVERSE will take a fee of 35% of the
                    Total UNI from each respective sale for “Non-Connections”, also known as non-linked
                    individuals or businesses, and 10% for any “Connections”, also known as linked individuals
                    or businesses, between you and (potential) consumers.</small>
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
    <div class='popup1'>
        <div class='content'>
            <br />
            <br />
            <input type="button" value="Close" style="margin-left: 0px; color: #0099ff;" class="close" align="right" />
            <p>
                Please register via the url that you would recieve from your parent company to be
                added as a Franchise to your parent companies list of Franchises.</p>
        </div>
    </div>
    <uc1:FranchiseAddEdit ID="FranchiseAddEdit1" runat="server" />
</div>
<script type="text/javascript">
    $(function () {
        var overlay = $('<div id="overlay"></div>');
        $('.close').click(function () {
            $('.popup1').hide();
            overlay.appendTo(document.body).remove();
            return false;
        });

        $('.x').click(function () {
            $('.popup1').hide();
            overlay.appendTo(document.body).remove();
            return false;
        });
        //  
        
        if ($("[id$=rbCompanyType]").find(":checked").val() == "1") {
            $("[id$=trEcommerce]").show();
        }
        else {
            $("[id$=trEcommerce]").hide();
        }


        if ($("[id$=rbFranchise]").find(":checked").val() == "0") {
            $("[id$=trFranchise]").show();

        }
        else {
            $("[id$=trFranchise]").hide();

        }

        $("[id$=rbFranchise]").change(function () {

            if ($(this).find(":checked").val() == "0") {
                $("[id$=trFranchise]").show();

            }
            else {
                $("[id$=trFranchise]").hide();

            }
        });

        $("[id$=rpParentOrFranchise]").change(function () {

            if ($(this).find(":checked").val() == "1") {
                overlay.show();
                overlay.appendTo(document.body);
                $('.popup1').show();
                return false;


            }

        });




    });
    


    

</script>
