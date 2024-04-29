function LoadCategoryData(ID, ParentsCategoryID_Value, ParentsCategoryID, txtCategoryNameID) {
    var url_CategoryNode  = "/Mgr/ShopAdmin/GetNodeOfShopCategory?ParentsCategoryID=" + ParentsCategoryID_Value;
   // console.log(url_CategoryNode);
    $.ajax({
        url: url_CategoryNode,

        success: function (data) {
            $(ID).treeview({
                enableLinks: false,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", 
                showBorder: true,
                borderColor: "#EDEDED",
                onhoverColor: "#E0E0E0",
                highlightSelected: true,
                levels: 3,
                showTags: true,
                data: $.parseJSON(data),
                onNodeCollapsed: function (event, node) { 
                    $("#dropdown-menu1").dropdown('toggle');
                },
                onNodeExpanded: function (event, node) { 
                    //DropDownMenu 展示
                    $("#dropdown-menu1").dropdown('toggle');

                },
                onNodeSelected: function (event, node) {
                   
                    $("#dropdown-menu1").dropdown('toggle');
                    $('#ParentsCategoryID').val(node.nodeid);
                    $('#txtCategoryName').val(node.text);
                } 
            });
        }
    });//end ajax get json data
}


//FOR /MGR/ProductAddUpdate
function LoadCategoryData_ProductAddUpdate(ID, txtCategoryNameID,txtCategoryIDs) {
    var url_CategoryNode = "/Mgr/ShopAdmin/GetNodeOfShopCategory?ParentsCategoryID=0"; 
    $.ajax({
        url: url_CategoryNode,

        success: function (data) {
            $(ID).treeview({
                enableLinks: false,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus",
                showBorder: true,
                borderColor: "#EDEDED",
                onhoverColor: "#E0E0E0",
                highlightSelected: true,
                levels: 3,
                showTags: true,
                data: $.parseJSON(data),
                onNodeCollapsed: function (event, node) {
                    $("#dropdown-menu1").dropdown('toggle');
                },
                onNodeExpanded: function (event, node) {
                    //DropDownMenu 展示
                    $("#dropdown-menu1").dropdown('toggle');

                },
                onNodeSelected: function (event, node) { 
                    $("#dropdown-menu1").dropdown('toggle');
                    console.log("CategoryIDs select：" + node.nodeid + "" + node.text);
                    $(txtCategoryNameID).val(node.text);
                    $(txtCategoryIDs).val(node.nodeid);
                    
                }
            });
        }
    });//end ajax get json data
}


function LoadCategoryDataByNode(ID, ParentsCategoryID_Value) {
    var url_CategoryNode = "/Mgr/ShopAdmin/GetNodeOfShopCategory?ParentsCategoryID=" + ParentsCategoryID_Value;
    console.log("url_CategoryNode for del:" + url_CategoryNode);
    $.ajax({
        url: url_CategoryNode,

        success: function (data) {
            $(ID).treeview({
                enableLinks: false,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: true,
                borderColor: "#EDEDED",
                onhoverColor: "#E0E0E0",
                highlightSelected: true,
                levels: 7,
                showTags: true,
                data: $.parseJSON(data),
                nodeCollapsed: function (event, node) {
                    $(ID).dropdown('toggle');
                }
            });
        }
    });//end ajax get json data
}

function LoadCategoryList(ID, ParentsCategoryID_Value) {
    var url_CategoryNode = "/Mgr/ShopAdmin/GetNodeOfShopCategory?ParentsCategoryID=" + ParentsCategoryID_Value;
    console.log("url_CategoryNode for del:" + url_CategoryNode);
    $.ajax({
        url: url_CategoryNode,

        success: function (data) {
            $(ID).treeview({
                enableLinks: false,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: true,
                borderColor: "#EDEDED",
                onhoverColor: "#E0E0E0",
                highlightSelected: true,
                levels: 7,
                showTags: true,
                data: $.parseJSON(data),
                onNodeSelected: function (event, node) {
                    
                    window.location = "ShopCategory?CategoryID=" + node.nodeid;
                }
            });
        }
    });//end ajax get json data
}