<%@ Control Language="VB" AutoEventWireup="false" CodeFile="JobPostView.ascx.vb"
    Inherits="JobUC_JobPostView" %>
<div class="frm">
    <asp:PlaceHolder runat="server" ID="plhEdInfo">
        <div class="cnt_infoedt">
            <asp:LinkButton runat="server" ID="lbtEdit" Text="Edit Information" /></div>
    </asp:PlaceHolder>
    <asp:Label runat="server" ID="lblError" CssClass="err"></asp:Label>
    <div class="fld">
        <span class="lbl">Job Title:</span><asp:Label runat="server" ID="lblJobTitle"></asp:Label>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Category:</span>
        <asp:Label runat="server" ID="lblCategory" CssClass="grp_vlu">
        </asp:Label>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Industries:</span>
        <asp:Label runat="server" ID="lblIndustry" CssClass="grp_vlu">
        </asp:Label>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Country:</span><asp:Label runat="server" ID="lblCountry">
        </asp:Label>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">State:</span><asp:Label runat="server" ID="lblState">
        </asp:Label>
        <div class="sub_fld">
            <span class="lblauto">Zip Code:</span><asp:Label runat="server" ID="lblZipCode"></asp:Label><div
                class="cb">
            </div>
        </div>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">City:</span><asp:Label runat="server" ID="lblCity"></asp:Label><div
            class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Job Type:</span>
        <asp:Label runat="server" ID="lblJobType" CssClass="grp_vlu">
        </asp:Label>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Career Level:</span>
        <asp:Label runat="server" ID="lblCareerLevel" CssClass="grp_vlu">
        </asp:Label>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Education Level:</span>
        <asp:Label runat="server" ID="lblEduLevel" CssClass="grp_vlu">
        </asp:Label>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Experience:</span><asp:Label runat="server" ID="lblYear">
        </asp:Label>
        &nbsp;Year(s)&nbsp;&nbsp;<asp:Label runat="server" ID="lblMonth">
        </asp:Label>
        &nbsp;Month(s)
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Description:</span><asp:Label runat="server" ID="lblDescription"
            Width="400"></asp:Label><div class="cb">
            </div>
    </div>
</div>
