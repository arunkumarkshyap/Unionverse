<%@ Control Language="VB" AutoEventWireup="false" CodeFile="JResumeAddEdit.ascx.vb" Inherits="JobUC_JResumeAddEdit" %>
<div class="frm">
    <asp:Label runat="server" ID="lblError" CssClass="err"></asp:Label>
    <div class="fld">
      <p>
            Browse:&nbsp;&nbsp;
            <asp:FileUpload ID="fupImageURL" runat="server" Width="340" />
        </p>
    </div>
</div>
<div style="padding:0px 10px 20px 80px;">
      <span class="btn_move"><asp:LinkButton runat="server" ID="btnSubmit" Text="Upload Resume" ></asp:LinkButton></span></div>
