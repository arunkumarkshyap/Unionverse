<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PlanetSearch.ascx.vb" Inherits="JobUC_PlanetSearch" %>
<%@ Register Src="PagingFooter2.ascx" TagName="PagingFooter2" TagPrefix="uc1" %>
<asp:PlaceHolder runat="server" ID="plhSearch" >
<div class="frm">
    <asp:Label runat="server" ID="lblError" CssClass="err"></asp:Label>
    <div class="fld">
        <span class="lbl">Keyword:</span><asp:TextBox runat="server" ID="txtKeyword"></asp:TextBox>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Category:</span>
        <div class="fld_srol">
            <asp:CheckBoxList runat="server" ID="chkCategory" RepeatColumns="1" CellSpacing="0">
            </asp:CheckBoxList>
        </div>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Industries:</span>
        <div class="fld_srol">
            <asp:CheckBoxList runat="server" ID="chkIndustry" RepeatColumns="1" CellSpacing="0">
            </asp:CheckBoxList>
        </div>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Zip Code:</span><asp:TextBox runat="server" ID="txtZipCode"></asp:TextBox><div
            class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Search Redius:</span><asp:TextBox runat="server" ID="txtSrchRadius"></asp:TextBox><div
            class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Experience:</span><asp:DropDownList runat="server" ID="ddlYear"
            Width="45">
        </asp:DropDownList>
        <div class="cb">
        </div>
    </div>
    <div class="fld">
        <span class="lbl">Date:</span><asp:TextBox runat="server" ID="txtDateFrom"></asp:TextBox>&nbsp;-&nbsp;<asp:TextBox
            runat="server" ID="txtDateTo"></asp:TextBox><div class="cb">
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
</div>
<div style="padding:0px 10px 20px 10px;">
        <span class="btn_move" style="float:right;"><asp:LinkButton runat="server" ID="btnCancel" Text="Clear All" ></asp:LinkButton></span><span class="btn_move" style="float:right;"><asp:LinkButton
            runat="server" ID="btnSubmit" Text="Search" ></asp:LinkButton></span></div>
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="plhGrid">
<asp:LinkButton runat="server" ID="lbtBack">Go Back</asp:LinkButton>
    <div class="tbl">
        <asp:PlaceHolder runat="server" ID="phPaging"><div class="rec_info"><b>Showing:</b>&nbsp;<asp:Label ID="lblViewing"
            runat="server">
        </asp:Label>&nbsp;<b>Total Records:</b>&nbsp;<asp:Label ID="lblTotleRecords" runat="server">
        </asp:Label>
        </div>
        </asp:PlaceHolder>
        <asp:DataGrid ID="dgJobs" runat="server" Width="100%" AllowPaging="false" AllowSorting="true"
            GridLines="None" AutoGenerateColumns="false" CssClass="tbl_lst">
            <ItemStyle></ItemStyle>
            <HeaderStyle CssClass="tth"></HeaderStyle>
            <AlternatingItemStyle CssClass="altrow"></AlternatingItemStyle>
            <Columns>
              <asp:TemplateColumn HeaderText="">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <ItemTemplate>
                      <img src='<%#getUserProfileIcon(Eval("PosterID"))%>' width="50" height="50" alt='<%#GetUserName(Eval("PosterID"))%>' />
                           <center><%#GetUserName(Eval("PosterID"))%></center>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Date Posted">
                    <HeaderStyle />
                    <ItemStyle />
                    <ItemTemplate>
                        <%#CDate(Eval("DatePosted")).ToShortDateString%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="Industry">
                    <HeaderStyle />
                    <ItemStyle />
                    <ItemTemplate>
                        <%#getIndustry(Eval("JobID"))%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Category">
                    <HeaderStyle />
                    <ItemStyle />
                    <ItemTemplate>
                        <%#getCategory(Eval("JobID"))%>
                    </ItemTemplate>
                </asp:TemplateColumn>
               
                     <asp:TemplateColumn HeaderText="Email">
                    <HeaderStyle />
                    <ItemStyle />
                    <ItemTemplate>
                       <a href="mailto:"> <%#getUserEmail(Eval("PosterID"))%></a>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Actions">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" />
                    <ItemTemplate>
                        <asp:linkbutton ID="lbt_Edit" runat="server" CommandName="VIEW" CommandArgument='<%#Eval("JobID")%>' Text="View"></asp:linkbutton>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
            <uc1:PagingFooter2 ID="uc_paging" runat="server" />
    </div>

</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="plhNoRec">Search returned no results <asp:linkbutton runat="server" id="lbtSrchAgain">click here</asp:linkbutton> to search again.</asp:PlaceHolder>
