<%@ Control Language="VB" AutoEventWireup="false" CodeFile="JobPostAddEdit.ascx.vb"
    Inherits="JobUC_JobPostAddEdit" %>
<div class="frm">
    <asp:Label runat="server" ID="lblError" CssClass="err"></asp:Label>
    <div class="fld">
        <span class="lbl">Job Title:</span><asp:TextBox runat="server" ID="txtJobTitle"></asp:TextBox>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Category:</span> <div class="fld_srol">
            <asp:CheckBoxList runat="server" ID="chkCategory" RepeatColumns="1" CellSpacing="0">
            </asp:CheckBoxList>        
        </div>
        <div class="cb"></div>
    </div>
       <div class="fld">
       
         <span class="lbl">Industries:</span> <div class="fld_srol">
                <asp:CheckBoxList runat="server" ID="chkIndustry" RepeatColumns="1" CellSpacing="0">
                </asp:CheckBoxList></div>
            <div class="cb"></div>
       
    </div>
    <div class="fld">
        <span class="lbl">Country:</span><asp:DropDownList runat="server" ID="ddlCountry"
            AutoPostBack="true">
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlState">
        </asp:DropDownList>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Zip Code:</span></span><asp:TextBox runat="server" ID="txtZipCode"></asp:TextBox>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">City:</span><asp:TextBox runat="server" ID="txtCity"></asp:TextBox><div
            class="cb">
        </div>
    </div>
 
    <div class="fld">
        <p>
            Job Type:<br />
            <span class="lst_fld">
                <asp:CheckBoxList runat="server" ID="chkJobType" RepeatColumns="2" CellSpacing="10">
                </asp:CheckBoxList>
            </span>
        </p>
    </div>
    <div class="fld">
        <p>
            Career Level:<br />
            <span class="lst_fld">
                <asp:CheckBoxList runat="server" ID="chkCareerLevel" RepeatColumns="2" CellSpacing="10">
                </asp:CheckBoxList>
            </span>
        </p>
    </div>
    <div class="fld">
        <p>
            Education Level:<br />
            <span class="lst_fld">
                <asp:CheckBoxList runat="server" ID="chkEduLevel" RepeatColumns="2" CellSpacing="10">
                </asp:CheckBoxList>
            </span>
        </p>
    </div>
    <div class="fld">
        <span class="lbl">Experience:</span><asp:DropDownList runat="server" ID="ddlYear" Width="45">
        </asp:DropDownList>
        &nbsp;&nbsp;Year(s) &nbsp;&nbsp;&nbsp;<asp:DropDownList runat="server" ID="ddlMonth" Width="45">
        </asp:DropDownList>
        &nbsp;&nbsp;Month(s)
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Description:</span><asp:TextBox runat="server" ID="txtDescription"
            TextMode="MultiLine" Rows="10" Width="400"></asp:TextBox><div class="cb">
            </div>
    </div>
 </div>
<div style="padding:0px 10px 20px 10px;">
        <span class="btn_move" style="float:right;"><asp:LinkButton runat="server" ID="btnCancel" Text="Clear All" ></asp:LinkButton></span><span class="btn_move" style="float:right;"><asp:LinkButton
            runat="server" ID="btnSubmit" Text="Submit Information" ></asp:LinkButton></span></div>
