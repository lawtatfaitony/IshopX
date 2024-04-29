
//加载 treeview         
function LoadInfoCateData(ID, PrarentsID) { 
    $.ajax({
        url: "/Mgr/info/GetNodeOfInfoCates?PrarentsID=" + PrarentsID,   //url: "/Mgr/info/GetNodeOfInfoCates?PrarentsID=IC0001" + PrarentsID, 
        success: function (data) { 
            $(ID).treeview({
                enableLinks: true,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: true,
                levels: 20,
                showTags: true,
                data: $.parseJSON(data), 
                nodeCollapsed: function (event, node) {
                    alert("collagsed");
                    $("#dropdown-menu1").dropdown('toggle');
                }, 
                onNodeSelected: function (event, node) {
                    $("#dropdown-menu1").dropdown('toggle');
                    $('#ParentsMenuItemID').val(node.nodeid);
                    $('#txtMenuItemName').val(node.text);
                },
            });
        }
    });//end ajax get json data
}
//MenuItem 选择上一级类目(MenuItemID,MenuItemName) 
function setInfoCateRoot() {
    $("#InfoCateID").val("0");
    $("#txtInfoCateName").val("信息类目(根类目)");
}
