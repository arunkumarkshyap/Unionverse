<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdministratorsAddEdit.ascx.vb" Inherits="CMS_AdministratorsAddEdit" %>
   <%@ Register Src="~/Admin/AdminControls/ErrMsg.ascx" TagName="ErrMsg" TagPrefix="uc2" %>
<div class="srg_frm">
    <span class="subheading2">Account (Edit/Insert)</span><br />
    </div>

 <div class="cnt_wrap">
    <p>
        <uc2:ErrMsg ID="uc_ErrMsg" runat="server"></uc2:ErrMsg>
    </p>
    <div class="ctrl_head">
        <asp:Button ID="btnUSave" runat="server" Text="Save" CssClass="inpButton" />
        <asp:Button ID="btnUCancel" runat="server" Text="Cancel" CssClass="inpButton" />
    </div>
    <table class="seg_tbl" id="tblName">
        <%--<tr>
            <td class="lbl">
                AdministratorID:&nbsp;
            </td>
            <td>
                <asp:Label runat="server" ID="lbladministratorID"></asp:Label></td>
        </tr> --%>       
        <tr>
             <td class="heading">
                <b>Name:</b>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtName" MaxLength="250" CssClass="inputField"></asp:TextBox>
            </td> 
        </tr>
        <tr>
            <td class="heading">
                <b>User name:</b>
            </td>
            <td>
             <asp:TextBox ID="Txtusername" runat="server" CssClass="inputField"></asp:TextBox></td>
        </tr>
        <tr>
             <td class="heading">
               <b>Password:</b>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" MaxLength="250" CssClass="inputField"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="heading">
                <b>Role:</b></td>
            <td>
                <asp:DropDownList runat="server" ID="ddlAdroleid"></asp:DropDownList>
            </td> 
        </tr>
        <tr>
              <td class="heading">
                <b>Email1:</b></td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail1" MaxLength="250" CssClass="inputField"></asp:TextBox>
            </td>
        </tr>
        <asp:PlaceHolder runat="server" Visible="false">
        <tr>
            <td class="heading">
                Email2:</td>
            <td>
                <asp:TextBox ID="txtEmail2" runat="server" CssClass="inputField"></asp:TextBox></td>
        </tr> 
           <tr>
             <td class="heading">
                Account Notes:</td>
            <td>
               <asp:TextBox runat="server" ID="txtAccountNotes" MaxLength="250" CssClass="inputField" TextMode ="MultiLine" Height="40" ></asp:TextBox>
            </td>
        </tr>
        </asp:PlaceHolder>       
        <tr>
            <td class="heading">
                Is Active:</td>
            <td>
                <asp:CheckBox  ID="chkisactive" runat="server"></asp:CheckBox></td>
        </tr>
        
        <tr>
          <td class="heading">
                Last Login:</td>
            <td>
                <asp:Label ID="lbllastlogin" runat="server"></asp:Label></td>
        </tr>
        <tr>
              <td class="heading">
                Date Registered:</td>
            <td>
                <asp:Label id="lblDateReg" runat="server"></asp:Label>
            </td>
        </tr>        
        
    </table>
    <div class="ctrl_head">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="inpButton" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="inpButton" />
    </div>
</div>
