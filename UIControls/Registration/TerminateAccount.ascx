<%@ Control Language="VB" AutoEventWireup="false" CodeFile="TerminateAccount.ascx.vb"
    Inherits="UIControls_Registration_TerminateAccount" %>
<asp:UpdatePanel runat="server" ID="upd1">
    <ContentTemplate>
        <div class="MyForum">
            <asp:Label runat="server" ID="lblInfo" EnableViewState="false" Visible="false" Font-Bold="true"
                ForeColor="Green" />
            <asp:Label runat="server" ID="lblError" EnableViewState="false" Visible="false" CssClass="Error" />
            <table runat="server" id="tblForm">
                <tr>
                    <td colspan="2">
                        Click on the button to close your account.
                    </td>
                </tr>
                <tr>
                    <td class="FieldLabel" width="200px">
                        <div class="btn_holder">
                            <span class="btn_move" style="padding: ">
                                <asp:LinkButton runat="server" ID="lbtTerminate" Text="Close Account" OnClientClick="return confirm('Are you sure want to close you account?')"
                                    Style="padding-top: 0px;"></asp:LinkButton></span>
                        </div>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
