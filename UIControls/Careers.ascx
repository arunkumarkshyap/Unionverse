<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Careers.ascx.vb" Inherits="CMSWebParts_SMTWebParts_Careers" %>
<%@ Register Src="~/UIControls/Registration/SelectIndustry.ascx" TagName="SelectIndustry"
    TagPrefix="uc2" %>
<div class="frm">
    <asp:PlaceHolder runat="server" ID="phForm">
        <style>
            .ModalPopupBG
            {
                background-color: #fff;
                filter: alpha(opacity=50);
                opacity: 0.7;
            }
            .HellowWorldPopup
            {
                background: white;
                padding: 5px 15px 5px 15px;
            }
        </style>
        <asp:Label runat="server" ID="lblError" Text="" class="err"></asp:Label>
        <div class="fld">
            <span class="lbl">First Name:</span><asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
            <div class="cb">
            </div>
        </div>
        <div class="fld">
            <span class="lbl">Last Name:</span><asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
            <div class="cb">
            </div>
        </div>
        <div class="fld">
            <span class="lbl">UNIonVERSE ID:</span><asp:TextBox runat="server" ID="txtUnionVerseID"></asp:TextBox>
            <div class="cb">
            </div>
        </div>
        <div class="fld">
            <span class="lbl">Email Address:</span><asp:TextBox runat="server" ID="txtEmailAddress"></asp:TextBox>
            <div class="cb">
            </div>
        </div>
        <div class="fld">
            <span class="lbl">Location:</span>
            <asp:DropDownList runat="server" ID="ddCountry" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddState">
            </asp:DropDownList>
            <div class="cb">
            </div>
        </div>
        <div class="fld">
            <span class="lbl">City:</span><asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
            <div class="cb">
            </div>
        </div>
        <div class="fld">
            <span class="lbl">Zip Code:</span><asp:TextBox runat="server" ID="txtZipCode"></asp:TextBox>
            <div class="cb">
            </div>
        </div>
        <div class="fld">
            <span class="lbl">Current Employer:</span><asp:TextBox runat="server" ID="txtCurrentEmployer"></asp:TextBox>
            <div class="cb">
            </div>
        </div>
        <div class="fld">
            <span class="lbl">Industry:</span><asp:UpdatePanel runat="server" ID="up1">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnIndustry" Text="Select Industry" />
                    <asp:Label runat="server" ID="lblIndustry" Text=""></asp:Label>
                    <asp:Panel runat="server" ID="pnlIndustry">
                        <div class="HellowWorldPopup">
                            <div style="padding: 5px; text-align: right; background-color: #EAEAEA;">
                                <asp:LinkButton runat="server" ID="lbtCloseIndustry" Text="Close [X]" Font-Bold="true"></asp:LinkButton>
                            </div>
                            <div style="height:450px; overflow:auto;">
                                <uc2:SelectIndustry ID="SelectIndustry1" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                    <ajaxToolkit:ModalPopupExtender runat="server" ID="mpIndustry" PopupControlID="pnlIndustry"
                        BackgroundCssClass="ModalPopupBG" TargetControlID="btnIndustry" CancelControlID="lbtCloseIndustry">
                    </ajaxToolkit:ModalPopupExtender>
                    <input type="hidden" runat="server" id="hidIndustry" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="cb">
            </div>
        </div>
        <div class="fld">
            <span class="lbl">How do you belive you can contribute to the UNIonVERSE:</span><asp:TextBox
                runat="server" ID="txtComments" TextMode="MultiLine"></asp:TextBox>
            <div class="cb">
            </div>
        </div>
        <div class="fld">
            <span class="lbl">Attach Resume:</span><asp:FileUpload runat="server" ID="fuResume" />
            <div class="cb">
            </div>
        </div>
        <div class="cntrl">
            <span class="btn_move"><asp:LinkButton runat="server" ID="btnSubmit" Text="Submit"></asp:LinkButton></span>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="phSuccessFull">
        <p>
            Thank you for your submission. We are in receipt of your resume, and if our Human
            Resource Department finds a perfect fit for you into the current UNIonVERSE, they
            will reach out to you to discuss your credentials further. We store all resumes
            for 7 months, and then after that it will be automatically deleted; So, please touch
            back in the future, if you do not hear from us, because the UNIonVERSE is expanding
            rapidly, and there will be future openings currently not foreseen that might fit
            your skill set.
        </p>
    </asp:PlaceHolder>
</div>
