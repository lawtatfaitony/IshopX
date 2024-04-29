function loadLeftMenudata(ID) {
    $.ajax({
        url: "/Mgr/menuItem/GetNodeOfMenuItem?ParentsMenuItemID=0",
        success: function (data) {
            var result = $.parseJSON(data);
            //console.log(result);
            $(ID).treeview({
                enableLinks: true,
                expandIcon: "glyphicon glyphicon-stop",
                collapseIcon: "glyphicon glyphicon-unchecked",
                nodeIcon: "glyphicon glyphicon-user",
                color: "#FCFCFC",
                backColor: "#222D32",
                onhoverColor: "#374A51",
                borderColor: "white",
                showBorder: false,
                levels: 1,
                showTags: true,
                highlightSelected: true,
                selectedColor: "yellow",
                selectedBackColor: "#374A51",
                data: result
            });
            // console.log(data)
        }
    });//end ajax get json data
}
//加载 treeview         
function LoadMenuData(ID, ParentsMenuItemID) { 
    $.ajax({
        url: "/Mgr/menuItem/GetNodeOfMenuItem?ParentsMenuItemID=" + ParentsMenuItemID,
        
        success: function (data) { 
            $(ID).treeview({
                enableLinks: true,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: true,
                levels: 2,
                showTags: true,
                data: $.parseJSON(data), 
                nodeCollapsed: function (event, node) {
                   // alert("collagsed");
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
function setMenuRoot() {
    $("#ParentsMenuItemID").val("0");
    $("#txtMenuItemName").val("主菜单(根类目)"); 
}


//下拉 推广帐号列表 
//searching :帐号的关键搜索要素
function LoadAccountMgrDropDownData(DropdownMenuID, txtID, txtName, searchString) {
    txtID = "#" + txtID;
    txtName = "#" + txtName;
    console.log("DropdownMenuID=" + DropdownMenuID + ",txtID=" + txtID + ", txtName=" + txtName + ", searchString=" + searchString);
    console.log("url=" + "/Mgr/User/LoadAccountMgrDropDownData?searchString=" + searchString);
    
    $.ajax({
        url: "/Mgr/User/LoadAccountMgrDropDownData?searchString=" + searchString,

        success: function (data) {
            console.log(JSON.stringify(data));  //测试ok ,返回的是Json ,不用解析
            //var json = JSON.parse(data);
            $(DropdownMenuID).treeview({
                enableLinks: true,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: false,
                levels: 20,
                showTags: true,
                data: data,  // $.parseJSON(json) //返回的是Json ,不用解析
                nodeCollapsed: function (event, node) { 
                    $(DropdownMenuID).dropdown('toggle');
                },
                onNodeSelected: function (event, node) {
                    $(DropdownMenuID).dropdown('toggle');
                    if (node.nodeid != "0") //排除空数据  nodeid = "0", text = "抱歉,没有相关查询结果",
                    {
                        console.log("nodeid=" + node.nodeid + ";text=" + node.text);
                        $(txtID).val(node.nodeid);
                        $(txtName).val(node.custom);
                    } 
                },
            });
        }
    });//end ajax get json data
}


//下拉 推广关键词列表 ===============推广关键词列表=================推广关键词列表================推广关键词列表==================推广关键词列表==================================================
//searchString : 关键搜索要素
function LoadSeoExtandDropDownData(DropdownMenuID, txtID, txtName, searchString) {
    searchString = escape(searchString); 
    console.log("DropdownMenuID=" + DropdownMenuID + ",txtID=" + txtID + ", txtName=" + txtName + ", searchString=" + searchString);
    console.log("url=" + "/Mgr/seo/GetNodeOfSeoExtand?searchString=" + searchString);

    $.ajax({
        url: "/Mgr/seo/GetNodeOfSeoExtand?searchString=" + searchString,

        success: function (data) {
            console.log(JSON.stringify(data));  //测试ok ,返回的是Json ,不用解析
            //var json = JSON.parse(data);
            $(DropdownMenuID).treeview({
                enableLinks: true,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: false,
                multiSelect: true,
                levels: 20,
                showTags: true,
                data: $.parseJSON(data),
                nodeCollapsed: function (event, node) {
                    $(DropdownMenuID).dropdown('toggle');
                },
                onNodeSelected: function (event, node) {
                    $(DropdownMenuID).dropdown('toggle');
                    if (node.nodeid != "0") //排除空数据  nodeid = "0", text = "抱歉,没有相关查询结果",
                    {
                        console.log("nodeid=" + node.nodeid);
                        if (txtID != "#0") //如果不需要赋值 txtID 则 txtID=0
                        {
                            $(txtID).val(node.nodeid);
                        }
                        
                        $(txtName).val($(txtName).val() + " " + node.custom);
                    }
                },
            });
        }
    });//end ajax get json data
}
//下拉搜索事件
function LoadDropDownEvent(DropdownMenuID, txtID, txtName, SearchBtn, searchStringID) {
     
    var DropdownMenuID = "#" + DropdownMenuID ;
    var txtID = "#" + txtID ; 
    var txtName = "#" + txtName;
    var SearchBtn = "#" + SearchBtn;
    var searchStringID = "#" + searchStringID +":text"; 
    
    //【动态检查】（规则： ~Ishop/js/TreeMenuItem.js）
    $(searchStringID).on('input', function (e) {
        $(DropdownMenuID).dropdown('toggle');
        var searchString = $(searchStringID).val();
        //searchString = $("input[id='dropdown_SearchString']").attr("value");
        console.log("searchStringID_input : " + searchString);
       
        LoadSeoExtandDropDownData(DropdownMenuID, txtID, txtName, searchString)
    });
    $(searchStringID).click(function (e) {
        $(DropdownMenuID).dropdown('toggle');
        var searchString = $(searchStringID).val();
        console.log("searchStringID_click : " + searchString);
        LoadSeoExtandDropDownData(DropdownMenuID, txtID, txtName, searchString)
    });
    $(SearchBtn).click(function (e) {
        $(DropdownMenuID).dropdown('toggle');
        var searchString = $(searchStringID).val();
        console.log("SearchBtn_click : " + searchString );
        //$(DropdownMenuID).dropdown('toggle'); 
        LoadSeoExtandDropDownData(DropdownMenuID, txtID, txtName, searchString)
    });
}
 