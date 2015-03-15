$(document).ready(function(){
        $(".imghover")
        .mouseover(function() { 
            var src = $(this).children("img").attr("src").match(/[^\.]+/) + "_on.png";
            $(this).children("img").attr("src", src);
        })
        .mouseout(function() {
            var src = $(this).children("img").attr("src").replace("_on.png", ".png");
            $(this).children("img").attr("src", src);
        });
        $(".seltab")
        .ready(function() { 
            var src = $(".seltab").find("img").attr("src").match(/[^\.]+/) + "_on.png";
            $(".seltab").find("img").attr("src", src);
        });

//        // -------------------- Auto Post Loading script --------------------
//       
//        var previousProductId = 0;
//        //Max records to display at a time in the grid.
//        var maxRecordsToDisplay = 50;
//        
//         //initially hide the loading gif
//            $("#divProgress").hide();
//            
//            //initially hide the button
//           // $(".btnMore").hide();

//            //Attach function to the scroll event of the div
//            $(".btnMore").click(function () {
//            alert("scrolling is called");
////                var scrolltop = $('#iWall').attr('scrollTop');
////                var scrollheight = $('#iWall').attr('scrollHeight');
////                var windowheight = $('#iWall').attr('clientHeight');
////                var scrolloffset = 20;
////                if (scrolltop >= (scrollheight - (windowheight + scrolloffset))) {
//                   
//                    //User has scrolled to the end of the grid. Load new data..
//                    $("#divProgress").ajaxStart(function () {
//                        $(this).show();
//                    });
//                    $("#divProgress").ajaxStop(function () {
//                        $(this).hide();
//                    });
//                    alert("Bind data is called");
//                    BindNewData();
//              //  }
//            });


//        function BindNewData() {
//            alert('bind data is called');
//            var lastProductId = $(".hdnCurrPage").val();
//            var userId = $(".hdnUserID").val();
//            var isWall = $(".hdnIsWall").val();
//            
//            //get last table row in order to append the new products
//            var lastRow = $("#iWall div.cnt_ipost:last");
//            alert($(".hdnCurrPage").val());
//            //Fetch records only when the no. of records displayed in the grid are less than limit.
//            if (GetRowsCount() < maxRecordsToDisplay) {
//                if (parseInt(lastProductId, 10) > parseInt(previousProductId, 10)) {
//                    previousProductId = lastProductId;

//                    $.post("iPostDBHandler.ashx?uid=" + userId + "&iw=" + isWall + "&pg=" + lastProductId, function (data) {
//                        if (data != null) {
//                            //append new products rows to last row in the gridview.
//                            lastRow.after(data);
//                        }
//                    });
//                }
//            }
//            else {

//                //Set value of last product id in hidden field so that we can access it from code behind.
//                $(".hdnCurrPage").val($(".hdnCurrPage").val() + 1);
//                alert($(".hdnCurrPage").val())
//                //Check If there is more records in the database
//                if (parseInt(lastProductId, 10) > parseInt(previousProductId, 10))
//                    $(".btnMore").show();
//            }


//        }

//        function GetRowsCount() {
//            //Count no. of rows except header row in the grid.
//            var rowCount = $('.cnt_ipost').length-1;
//            alert(rowCount);
//            return rowCount;

//        }


 });

 
     
       
           