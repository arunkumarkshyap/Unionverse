<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GroupType1Employees.aspx.vb"
    Inherits="_GroupType1Employees" MasterPageFile="~/logon.master" ValidateRequest="false"
    EnableEventValidation="false" ViewStateEncryptionMode="Never" Title="Religious Sanctuary Employees ::: UNIonVERSE" %>

<%@ Register src="UIControls/Registration/GroupType1EmployeesAdd.ascx" tagname="GroupType1EmployeesAdd" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>   
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="cpGroupType1" runat="server">
    <div class="cRegis">
        <div class="cnt_wrap">
            <div class="cnt_hd">
                   <h1 class="ch_h1" runat="server" id="hGroupName"></h1>
                <div class="cb">
                </div>
            </div>
            <div class="cnt_bd">
                <div class="cnt_cn_pad">
                  <asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label>
                  <uc1:GroupType1EmployeesAdd ID="GroupType1EmployeesAdd1" runat="server" />
                </div>
            </div>
            <div class="cnt_ft">
            </div>
        </div>
    </div>
</asp:Content>
