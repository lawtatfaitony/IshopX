
//加载 treeview          
function GetNodeOfSeoExtands(DropdownMenuID, Tree_DropdownMenuID, forNodeID, forNodeTxt, SeoKeyWord, ParentsSeoExtandID) {
     
    $.ajax({
        url: "/Mgr/info/GetNodeOfSeoExtands?SeoKeyWord=" + SeoKeyWord + "&ParentsSeoExtandID=" + ParentsSeoExtandID ,
        success: function (data) {
            console.log(DropdownMenuID + "返回成功:" + JSON.stringify(data));
            
            $(Tree_DropdownMenuID).treeview({
                enableLinks: false,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: true,
                levels: 5,
                showTags: true,
                data: data, 
                nodeCollapsed: function (event, node) {
                    console.log("Event:nodeCollapsed");
                    $(DropdownMenuID).dropdown('toggle');
                },
                onNodeExpanded: function (event, node) {
                    console.log("Event:onNodeExpanded");
                    $(DropdownMenuID).dropdown('toggle');
                },
                onNodeSelected: function (event, node) {
                    console.log("Event:onNodeSelected");
                    $(DropdownMenuID).dropdown('toggle');
                    console.log("forNodeTxt:" + node.text);
                    $(forNodeID).val(node.nodeid);
                    $(forNodeTxt).val(node.text);
                },
            });
        }
    });//end ajax get json data
}
//默认的根类关键词
function setSeoExtandRoot(forNodeID, forNodeTxt) {
    console.log("forNodeTxt,forNodeTxt:" + forNodeID + "," + forNodeTxt);
    $(forNodeID).val("0");
    $(forNodeTxt).val("根类关键词");
}

//AddUpdateInfo 加载关键词 treeview  
function LoadSeoExtandsForAddUpdateInfo(DropdownMenuID, Tree_DropdownMenuID, forNodeTxt) {
    
    $.ajax({
        url: "/Mgr/info/GetNodeOfSeoExtands",
        success: function (data) {
            console.log(DropdownMenuID + "LoadSeoExtandsForAddUpdateInfo返回成功:" + JSON.stringify(data));

            $(Tree_DropdownMenuID).treeview({
                enableLinks: false,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: true,
                levels: 5,
                showTags: true,
                data: data,
                nodeCollapsed: function (event, node) {
                    console.log("Event:nodeCollapsed");
                    $(DropdownMenuID).dropdown('toggle');
                },
                onNodeExpanded: function (event, node) {
                    console.log("Event:onNodeExpanded");
                    $(DropdownMenuID).dropdown('toggle');
                }, 
                onNodeSelected: function (event, node) {
                    console.log("Event:onNodeSelected");
                    $(DropdownMenuID).dropdown('toggle');
                    console.log("LoadSeoExtandsForAddUpdateInfo forNodeTxt:" + node.text);
                    $(forNodeTxt).val( $(forNodeTxt).val() + " "+ node.text); 

                },
            });
        }
    });//end ajax get json data
}


//AddUpdateInfo 加载关键词 treeview  
function LoadSeoExtandsForEditor(TreeViewID, forRetriveNodeHtml5) {

    $.ajax({
        url: "/Mgr/info/GetNodeOfSeoExtands",
        success: function (data) {
            console.log(TreeViewID + "LoadSeoExtandsForAddUpdateInfo返回成功:" + JSON.stringify(data));

            $(TreeViewID).treeview({
                enableLinks: false,
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: true,
                levels: 5,
                showTags: true,
                data: data, 
                onNodeSelected: function (event, node) { 
                    console.log("LoadSeoExtandsForEditor onNodeSelected forNodeTxt:" + node.text);
                    
                    $(forRetriveNodeHtml5).focus();
                    $.ajax({
                        url: "/Mgr/info/RetriveSeoExtandNodeHtml5?SeoExtandID=" + node.nodeid ,
                        success: function (data) {
                            console.log(TreeViewID + "RetriveSeoExtandNodeHtml5返回成功:" + JSON.stringify(data));
                            HandleOnNodeSelected(data, forRetriveNodeHtml5);
                        }
                    });//end ajax get json data
                },
            });
        }
    });//end ajax get json data
    function HandleOnNodeSelected(data, forRetriveNodeHtml5) {
        if (data.MsgCode == "1")  // 输入数据格式非法
        {
            $(forRetriveNodeHtml5).html(data.Message);

        } else
        {
            alert("提交失败\n\n或\n\n无效参数:" + data.MsgCode + ":\n\n" + data.Message);
        }
    }

    //加载全部Treeview 加载关键词  
    function LoadAllSeoExtands(TreeViewID) {

        $.ajax({
            url: "/Mgr/info/GetNodeOfSeoExtands",
            success: function (data) { 
                console.log(TreeViewID + "data返回成功:" + JSON.stringify(data));
                $(Tree_DropdownMenuID).treeview({
                    enableLinks: false,
                    expandIcon: "glyphicon glyphicon glyphicon-plus",
                    collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                    showBorder: true,
                    levels: 5,
                    showTags: true,
                    data: data,
                    nodeCollapsed: function (event, node) {
                        console.log("Event:nodeCollapsed");
                       
                    },
                    onNodeExpanded: function (event, node) {
                        console.log("Event:onNodeExpanded");
                         
                    },
                    onNodeSelected: function (event, node) {
                        console.log("Event:onNodeSelected");
                        
                        console.log("LoadAllSeoExtands:" + node.text);
                        

                    },
                });
            }
        });//end ajax get json data
    }
}