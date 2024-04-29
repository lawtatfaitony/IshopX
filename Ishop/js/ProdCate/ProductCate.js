

//检查输入的类目名字有效性：限制文字字母数字下划线
$("#btnaddnew").click(function () {
    
    var ParentsProdCateName = $("#txtProdCateName").val();
    ParentsProdCateName = ParentsProdCateName.replace(/^\s+|\s+$/g, '');//去掉空格
    if (ParentsProdCateName === null || ParentsProdCateName==="")
    {
        //显示警告，并建议名称如下：
        $("#alert0").toggle();
        $("#span0").text("名称限定填入文字、字母或者数字并且最少2个字长。");
        setTimeout("$('#alert0').toggle()", 4000);
        setTimeout("$('#dropdown-menu1').dropdown('toggle');", 4000);
        
        return false;
                         
    } else {
        if (ParentsProdCateName === "0")//新增父类目的情况
        { 
            $("#ParentsProdCateID_Is_0").hide();
        } else
        { 
            $("#ParentsProdCateID_Is_0").show();
        }
        $("#txt_prod_cate_name").val("");
        $('#myModal').modal({ backdrop: 'static', keyboard: false });
    }
}) 
//检查输入的类目名字有效性：限制文字字母数字下划线
$("#btn_add_update").click(function () {

    var ParentsProdCateName = $("#txtProdCateName").val();
    $("#txtProdCateName0").val($("#txtProdCateName").val())
    var ParentsProdCateID = $("#txt_ProdCateID").val();
    if (ParentsProdCateName.length<1) {
        //显示警告，并建议名称如下：
        $("#alert0").toggle();
        $("#span0").text("请先选择要变更的类目名称");
        setTimeout("$('#alert0').toggle()", 3000);
        setTimeout("$('#dropdown-menu1').dropdown('toggle');", 3000);

        return false;

    } else { 
        $('#myModal2').modal({ backdrop: 'static', keyboard: false });
    }
})
//处理 新增节点【根类目】一级类目
$("#btnaddnewroot").click(function () {
    $("#txtProdCateName").val("0");
    $("#txt_ProdCateID").val("0");
    $("#txtParentsProdCateName").val("0");
});
function checkProdCateName(str) {
    return str.match(/^[\u4E00-\u9FA5a-zA-Z0-9_]{1,30}$/); 
    //var msg =返回符合  "汉字 英文字母 数字 下划线组成，3-30位"，都没有返回null;  
    // alert("匹配="+str.match(/^[\u4E00-\u9FA5a-zA-Z0-9_]{1,30}$/));     
}
            
 //保存 新增           
$("#Savechanges").click(function () { 
    console.log('test : I am a student');
    var action = "insert";
    var ProdCateID = $("#txtProdCateID").val();//没用到，系统自动生成
    var ParentsProdCateID = $('#txt_ProdCateID').val();

    var ParentsProdCateName = $("#txtParentsProdCateName").val();
    var ProdCateName = $("#txt_prod_cate_name").val();
    ProdCateName = ProdCateName.replace(/^\s+|\s+$/g, '');//去掉空格

    console.log(ProdCateName + "/r/n ----------");
    var myparamsObject = { "action": action, "ProdCateID": ProdCateID, "ParentsProdCateID": ParentsProdCateID, "ParentsProdCateName": ParentsProdCateName, "ProdCateName": ProdCateName };
    console.log(myparamsObject);
    if (ProdCateName === null || ProdCateName === "" || ProdCateName.length < 2) {
        $("#alert_Ins_requireName").toggle();
        setTimeout("$('#alert_Ins_requireName').toggle()", 6000);
        return false;
    } else {
        $.ajax({
            url: "/Mgr/ProdCateV2/ProductCateMgr", 
            data: myparamsObject,
            type: "post",
            dataType: "text",
            error: function (result) {
                alert("(Savechanges).click error \n\r code:500");
            },
            success: function (result) {
                console.log(result);
                var json = JSON.parse(result);
                if (json.MsgCode === "1") {
                    $("#alert_Ins_Succ").toggle();
                    setTimeout("$('#alert_Ins_Succ').toggle()", 3000);
                    loadcatedata("#treeview6");
                }
                else {
                    alert("add new error:Savechange.click");
                }
            }
        });
    }
});

//保存【更新】      
$("#Savechanges_upd").click(function () {
    var action = "update";
    var ProdCateID = $("#txt_ProdCateID").val();
    var ProdCateName = $('#txt_prod_cate_name_upd').val(); //新类目名称 
    ProdCateName = ProdCateName.replace(/^\s+|\s+$/g, '');//去掉空格
    //var ParentsProdCateID = $('#txt_ProdCateID').val();

    var myparamsObject = { "action": action, "ProdCateID": ProdCateID, "ProdCateName": ProdCateName };
    console.log(myparamsObject);
    if (ProdCateName === null || ProdCateName === "" || ProdCateName.length < 2) {
        $("#alert_upd_requireName").show();
        setTimeout("$('#alert_upd_requireName').toggle()", 6000);
        return false;
    } else { 
        $.ajax({
            url: "/Mgr/ProdCateV2/ProductCateMgr",
            data: myparamsObject,
            type: "post",
            dataType: "text",
            error: function (result) {
                alert("server error Savechanges_upd \n\r code:500");
            },
            success: function (result) {
                var json = JSON.parse(result);
                if (json.MsgCode === "1") {
                    $("#alert_upd_Succ").toggle();
                    setTimeout("$('#alert_upd_Succ').toggle()", 5000);
                    loadcatedata("#treeview6");
                }
                else {
                    alert("ProdCateID not exist，pls select ProdCate。");
                }
            }
        });
    }
});
//Check the Repeate Name
$("#txt_prod_cate_name").on('input', function () {

    var action = "checkProdCateName"; 
    var ProdCateName = $("#txt_prod_cate_name").val();
    var myparamsObject = { "action": action, "ProdCateName": ProdCateName };
    $.ajax({
        url: "/Mgr/ProdCateV2/CheckProdCateName", 
        data: myparamsObject,
        type: "post",
        dataType: "json",  
        error: function (result) {
            alert("server error \n\r code:501");
        },
        success: function (result) {
            
            if (result.MsgCode === "1") {
                $('#Savechanges').prop('disabled', true);
                $("#alert_Ins_RepeatName").show();
                setTimeout("$('#alert_Ins_RepeatName').hide()", 3000)
            } else {
                $('#Savechanges').prop('disabled', false);
                $("#alert_Ins_RepeatName").hide();
            } 
        } 
    });
});
//【更新名称是否重复】
$("#txt_prod_cate_name_upd").on('input', function (e) {
    var action = "checkProdCateName";  
    var ProdCateName = $("#txt_prod_cate_name_upd").val();
    var myparamsObject = { "action": action, "ProdCateName": ProdCateName };
    $.ajax({
        url: "/Mgr/ProdCateV2/CheckProdCateName",  
        data: myparamsObject,
        type: "post",
        dataType: "json", 
        error: function (result) {
            alert("server error \n\r code:501");
        },
        success: function (result) { 
            console.log(myparamsObject);
            if (result.MsgCode === "1")
            {
                $('#Savechanges_upd').prop('disabled', true);
                $("#alert_upd_RepeatName").show();
                setTimeout("$('#alert_upd_RepeatName').hide()", 3000);
            } else {
                $('#Savechanges_upd').prop('disabled', false);
                $("#Savechanges_upd").removeAttr("disabled");  
                $("#alert_upd_RepeatName").hide();
            }
        }
    });
});
   //加载 treeview         
function loadcatedata(ID){
    $.ajax({
        url: "/Mgr/ProdCateV2/GetNodeOfProdCate?ParentsProdCateID=0",     // "/ajaxUrl/Product/HandlerCate.ashx",
        success: function (data) {
            $(ID).treeview({
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: true,
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
                    $('#txtProdCateName').val(node.text);
                    $('#txt_ProdCateID').val(node.nodeid); //赋值 ProdCateID
                    $('#txtParentsProdCateName').val(node.text);
                    //$('#btn_span1').html(node.text);     
                }
            });
        }
    });//end ajax get json data
}
//删除操作
$('#btn_delete').click(function (e) {
    if (!confirm("Delete OK?")) {
        return;
    } 
    if (checkProdCateName2()) {
        $('#btn_delete').prop('title', "类目名称：" + $('#txtProdCateName').val());
        var action = "delete"; //【删除】 操作
        var ProdCateID = $("#txt_ProdCateID").val(); 
        var ParentsProdCateID = $('#txt_ProdCateID').val();
        var ParentsProdCateName = $("#txtParentsProdCateName").val();
        var ProdCateName = $("#txtProdCateName").val();
        ProdCateName = ProdCateName.replace(/^\s+|\s+$/g, '');//去掉空格
        var myparamsObject = { "action": action, "ProdCateID": ProdCateID, "ParentsProdCateID": ParentsProdCateID, "ParentsProdCateName": ParentsProdCateName, "ProdCateName": ProdCateName };
        $.ajax({
            url: "/Mgr/ProdCateV2/ProductCateMgr", 
            data: myparamsObject,
            type: "post",
            dataType: "json", 
            error: function (result) {
                alert("发生服务器程序错误\n\r code:501" + JSON.stringify(result));
            },
            beforeSend: function () {
                // do something.
                // 一般是禁用按钮等防止用户重复提交
                $("#btn_delete").attr({ disabled: "disabled" });
            },
            success: function (result) {
                console.log(result);
                switch (result.MsgCode) {
                    case "1":
                        $('#btn_delete').prop('title', "类目名称：" + $('#txtProdCateName').val());
                        $('#btn_delete').popover(); 
                        var myid = jQuery("#btn_delete").data('content'); 
                        $('#btn_delete').popover('show');
                        setTimeout("$('#btn_delete').popover('hide');$('#btn_delete').prop('title', '');", 6000); //隐藏并重置为null
                        setTimeout("$('#dropdown-menu1').dropdown('toggle');", 6000);
                        break; 
                    case "0":
                        alert("删除失败");
                        $('#btn_delete').data("content", "删除失败 可能当前类目存在子类目或属性项");
                        break;
                     
                    default:
                        alert("操作异常，获取数据或null");
                        break;
                }
            },
            complete: function () {
                //do something.
                loadcatedata("#treeview6"); //重载类目视图
                $("#btn_delete").removeAttr("disabled");
                // 隐藏loading图片
            }
        });
    } else {
        return;
    }
});
$('#btn_delete').on('hidden.bs.popover', function () {
    // do something…
    $('#btn_delete').data("content", "删除成功，将无法通过此类目查询商品归类");//OH！！！ 不起作用，waiting for debug....
});
function checkProdCateName2() {
    var ParentsProdCateName = $("#txtProdCateName").val();
    ParentsProdCateName = ParentsProdCateName.replace(/^\s+|\s+$/g, '');//去掉空格
    if (ParentsProdCateName === null || ParentsProdCateName==="")
    {
        //显示警告，并建议名称如下：
        $("#alert0").toggle();
        $("#span0").text("名称限定填入文字、字母或者数字并且最少2个字长。");
        setTimeout("$('#alert0').toggle()", 4000);
        setTimeout("$('#dropdown-menu1').dropdown('toggle');", 2000);
        return false;          
    } else {
        return true;
    }

} 





 
 
     
 


 