<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AddPhotos.ascx.vb" Inherits="UIControls_Album_AddPhotos" %>
<script type="text/javascript" src="../../Scripts/Tabs/jquery-1.10.2.js"></script>
<style>
    article
    {
        width: 80%;
        margin: auto;
        margin-top: 10px;
    }
    
    
    .thumbnail
    {
        height: 100px;
        margin: 10px;
        border: 2px solid black;
    }
    #result div
    {
        float: left;
    }
</style>
<article>
        <label for="files">Select multiple files here: </label>
        <asp:FileUpload id="files" runat="server" multiple />
        <output id="result" />
    </article>
<asp:DataList ID="grdViewAlbum" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
    Width="100%" border="0" BorderColor="white" CssClass="griditem" PageSize="10">
    <ItemTemplate>
        <table style="border: 1px solid gray;">
            <tr>
                <td>
                    <asp:Image CssClass="thumbnail" runat="server" ID="img1" ImageUrl='<%# GetImage(Convert.ToString( Eval("ImageURL")))%>' /></a>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <a href="javascript:viod();" onclick='deleteImage(this,<%# Eval("UserImageID") %>)'>
                        X</a>
                </td>
            </tr>
        </table>
        </div>
        <br />
    </ItemTemplate>
</asp:DataList>
<asp:HiddenField runat="server" ID="hdnIds" />
<asp:HiddenField runat="server" ID="hdnIndexs" />
<script type="text/javascript">
    function deleteImage(ele, id) {
        $(ele).parent().parent().parent().remove();
        var ids = $("#<%= hdnIds.ClientID %>").val() + "," + id;
        $("#<%= hdnIds.ClientID  %>").val(ids);
    }
</script>
<script type="text/javascript">

    window.onload = function () {

        //Check File API support
        if (window.File && window.FileList && window.FileReader) {
            var filesInput = document.getElementById("ctl00_ContentPlaceHolder1_AddPhotos_AddPhotos_files");
            var j = 0;
            filesInput.addEventListener("change", function (event) {

                var files = event.target.files; //FileList object
                var output = document.getElementById("result");

                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    //alert(file.name);

                    //Only pics
                    if (!file.type.match('image'))
                        continue;

                    var picReader = new FileReader();
                    picReader.addEventListener("load", function (event) {

                       
                        var target = event.target || event.srcElement;

                        var picFile = event.target;
                        var div = document.createElement("div");


                        
                        div.innerHTML = "<img class='thumbnail' src='" + picFile.result + "'" +
                            "title='" + picFile.name + "'/><a href='javascript:void(0);' onclick='delete1(this," + j + ")'>X</a>";
                        j = j + 1;
                        output.insertBefore(div, null);

                    });
                    //Read the image
                    picReader.readAsDataURL(file);
                }

            });
        }
        else {
            console.log("Your browser does not support File API");
        }
    }

    function delete1(ele, index) {

        $(ele).parent().remove();
        var ids = $("#<%= hdnIndexs.ClientID %>").val() + "," + index;
        $("#<%= hdnIndexs.ClientID  %>").val(ids);
        
    }

   
</script>
