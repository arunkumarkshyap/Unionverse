<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UserImageListAdd.ascx.vb" Inherits="UIControls_UserImageListAdd" %>
<script type="text/javascript">
    function LargeImage(url) {
        window.open(url, "_blank", "", "");
    }

</script>
<style type="text/css">
    ul.User_Images {
        padding: 3px;
        margin: 0px;
        list-style: none;
        width: 580px;
        padding-left: 8px;
        display: inline-block;
        background-color: #fcfcfc;
    }

        ul.User_Images li {
            margin: 2px;
            padding: 2px;
            border: solid 1px #ccc;
            width: 105px;
            height: 120px;
            float: left;
            text-align: center;
            display: block;
        }

            ul.User_Images li img {
                border: dotted 1px #aaa;
                width: 100px;
                height: 100px;
                margin: 1px;
            }

            ul.User_Images li a {
            }
</style>

<asp:UpdatePanel runat="server" ID="upUImages" EnableViewState="true" >
    <ContentTemplate>
        <asp:Repeater runat="server" ID="rpUserImages" OnItemCommand="rpUserImages_ItemCommand">
            <HeaderTemplate>
                <ul class="User_Images">
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <img src='<%#GetImageName(EVal("ImageURL"))%>' alt='<%#Eval("ImageName") %>' onclick="javascript:LargeImage('<%#GetImageLarge(EVal("ImageURL")) %>');" />
                    <asp:LinkButton runat="server" ID="lbtdelete" Text="DELETE" CommandName="DELETE" CommandArgument='<%#EVal("UserImageID")%>'></asp:LinkButton>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress runat="server" ID="upg" AssociatedUpdatePanelID="upUImages">
    <ProgressTemplate>
        <h1>Processing</h1>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:PlaceHolder runat="server" ID="phImageAdd">
    <table>
        <tr>
            <td>
                <asp:FileUpload runat="server" ID="fuImage" /></td>
            <td>
                <asp:Button runat="server" ID="btnUpload" Text="Upload" /></td>
        </tr>
    </table>
</asp:PlaceHolder>
