<%@ Control Language="VB" AutoEventWireup="false" CodeFile="JobRequestView.ascx.vb" Inherits="JobUC_JobRequestView" %>
<div class="frm">
    <asp:PlaceHolder runat="server" ID="plhEdInfo">
        <div class="cnt_infoedt">
            <asp:LinkButton runat="server" ID="lbtEdit" Text="Edit Information" /></div>
    </asp:PlaceHolder>
    <asp:Label runat="server" ID="lblError" CssClass="err"></asp:Label>
    <div class="fld">
        <span class="lbl">User:</span><asp:Label runat="server" ID="lblUsername"></asp:Label>
       <a href="mailto:"><asp:Label runat="server" ID="lblEmail"></asp:Label></a> 
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
        <span class="lbl">Salary:</span><asp:label runat="server" ID="lblSalary"></asp:label><div
            class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Max Radius:</span><asp:label runat="server" ID="lblRadius"></asp:label><div
            class="cb">
        </div>
    </div>
    
</div>