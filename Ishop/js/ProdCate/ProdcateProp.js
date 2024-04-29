//加载 treeview         
function loadcatedataProp(ID,toggleDropdown,toggleProdCateID,toggleProdCateName) {
    $.ajax({
        url: "/Mgr/ProdCateV2/GetNodeOfProdCate?ParentsProdCateID=0",     // "/ajaxUrl/Product/HandlerCate.ashx",
        success: function (data) {
            $(ID).treeview({
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus", //展开后的Icon
                showBorder: true,
                levels: 3,
                data: $.parseJSON(data),
                onNodeCollapsed: function (event, node) {
                    $(toggleDropdown).dropdown('toggle');
                },
                onNodeExpanded: function (event, node) {
                    //DropDownMenu 展示
                    $(toggleDropdown).dropdown('toggle');

                },
                onNodeSelected: function (event, node) {
                    $(toggleProdCateName).val(node.text);
                    $(toggleProdCateID).val(node.nodeid); //赋值 ProdCateID
                    treeview_Prop_ProdCate_onChange("#treeview_ProdPropertiesValue", node.nodeid, "#Prop_dropdown-menu1");
                }
            });
        }
    });//end ajax get json data
}

//【列出类目的属性-二级联动】
function treeview_Prop_ProdCate_onChange(ID, ProdCateID, toggleDropdown) {
    
    var myparamsObject = { "ProdCateID": ProdCateID }; 
    $.ajax({
        type: "post",//要用post方式   
        data: JSON.stringify(myparamsObject),   
        url: "/Mgr/ProdCateV2/ProdPropertiesName_Lst", 
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
             
            json = eval(data); 
            var j = 0;
            for (var i = 0; i < json.length; i++) {
                j++;
                console.log("text:" + json[i].text + ",nodeid " + json[i].nodeid);
            }
            if (j === 0)
            { 
                $('#txtPropertiesValueName').val("");
                $("#txtPropertiesValueName").dropdown('toggle');
                $('#No_PropertiesValueName_Record').show();
                
            } else {  
                $("#txtPropertiesValueName").dropdown('toggle');
                $('#No_PropertiesValueName_Record').hide();
            } 
            $(ID).treeview({
                expandIcon: "glyphicon glyphicon glyphicon-plus",
                collapseIcon: "glyphicon glyphicon glyphicon-minus",  
                showBorder: true,
                levels: 3,
                showTags: true,
                 
                data: data,   
                onNodeCollapsed: function (event, node) { 
                    $("#dropdown-menus-PropertiesValueName").dropdown('toggle');
                },
                onNodeExpanded: function (event, node) { 
                    //DropDownMenu 展示
                    $("#dropdown-menus-PropertiesValueName").dropdown('toggle');

                },
                onNodeSelected: function (event, node) { 
                    $('#txtPropertiesValueName').val(node.text);
                    $('#txt_PropertiesValueID').val(node.nodeid);
                    //绑定更新模板 ID name custom
                    $("#myModalheader_lbl_PropertiesName").text(node.text); 
                    //属性值编辑 
                    OpenPropertiesValuesEdit();
                    //==================================
                    if (node.custom === "1")
                    { 
                        $("#chk_IsForTrading").prop("checked", true);
                       
                    }else
                    {
                        $("#chk_IsForTrading").prop("checked",false);
                         
                    }      
                } 
            }); 
        },
        error: function (err) { 

            console.log(JSON.stringify(err));
            //document.write(JSON.stringify(err));
            alert("error:【error: function (err)】" + JSON.stringify(err));
        }
    }); 
}

function JSONLength(obj) {
    var size = 0, key;
    for (key in obj) {
        if (obj.hasOwnProperty(key)) size++;
    }
    return size;
}

//属性 新增  
//检查输入的类目名字有效性：限制文字字母数字下划线
$("#btn_add_PropertiesValueName").click(function () {

    var ProdcateName = $("#txtProp_ProdcateName").val();
    ProdcateName = ProdcateName.replace(/^\s+|\s+$/g, '');//去掉空格

    var tips = "必须选择类目名称！";
    if (ProdcateName.length < 1) {


        $("#Prop_alert_span0").html(tips);
        $("#Prop_alert").toggle();
        setTimeout("$('#Prop_alert').toggle();", 2000);
        setTimeout("$('#Prop_dropdown-menu1').dropdown('toggle');", 3000);
        return;

    } else {

        $("#myModalLabel_PN_ProDCateName").text(ProdcateName);
        $("#myModal_PropertiesValueName").modal({ backdrop: 'static' });

    }
});
//检查输入的类目名字有效性：限制文字字母数字下划线
$("#btn_upd_PropertiesValueName").click(function () {

    var ProdcateName = $("#txtPropertiesValueName").val(); //属性名称
    ProdcateName = ProdcateName.replace(/^\s+|\s+$/g, '');//去掉空格
    var tips = "必须选择属性名称！";

    if (ProdcateName.length <= 1) {

        $("#Prop_alert_span0").html(tips);
        $("#Prop_alert").toggle();

        setTimeout("$('#Prop_alert').toggle();", 2000);
        setTimeout("$('#dropdown-menus-PropertiesValueName').dropdown('toggle');", 3000);
        return;
    } else {
        $("#myModal_PropertiesNameUpd").modal({ backdrop: 'static', keyboard: false });
    }
});
//检查输入的类目名字有效性：限制文字字母数字下划线
$("#btn_del_PropertiesValueName").click(function () {
    var ProdCateID = $("#txtProp_ProdCateID").val();
    var ProdcateName = $("#txtPropertiesValueName").val(); //属性名称
    ProdcateName = ProdcateName.replace(/^\s+|\s+$/g, '');//去掉空格
    var tips = "必须选择属性名称！";
    if (ProdcateName.length < 1) {
        $("#Prop_alert_span0").html(tips);
        $("#Prop_alert").toggle();
        setTimeout("$('#Prop_alert').toggle();", 3000);
        setTimeout("$('#dropdown-menus-PropertiesValueName').dropdown('toggle');", 4000);
        return;
    } else {
        if (!confirm("确定删除吗？")) {
            return;
        }
        $('#btn_del_PropertiesValueName').prop('title', "属性名称：" + $('#txtProp_ProdcateName').val());
        var PropertiesNameID = $("#txt_PropertiesValueID").val();
        var myparamsObject = { "PropertiesNameID": PropertiesNameID };
        console.log("属性删除操作输入属性名称ID》" + JSON.stringify(myparamsObject));
        $.ajax({
            type: "post",//要用post方式   
            data: JSON.stringify(myparamsObject),  //获取服务器json格式的几个关键参数都不能错
            url: "/Mgr/ProdCateV2/ProdPropertiesName_Del",//方法所在页面和方法名
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (data) {
                //遍历JSON 获取记录数, 
                switch (data.result) {
                    case "1":
                        $('#btn_del_PropertiesValueName').prop('title', "属性：" + $('#txtPropertiesValueName').val());
                        $('#btn_del_PropertiesValueName').popover();
                        var myid = jQuery("#btn_del_PropertiesValueName").data('content');

                        console.log(myid);
                        $('#btn_del_PropertiesValueName').popover('show');
                        setTimeout("$('#btn_del_PropertiesValueName').popover('hide');$('#btn_delete').prop('title', '');", 5000); //隐藏并重置为null
                        setTimeout("$('#dropdown-menus-PropertiesValueName').dropdown('toggle');", 5000);
                        break;
                    case "0":
                        alert("删除失败");
                        $('#btn_del_PropertiesValueName').data("content", "删除失败");
                        break;
                    case "-1":
                        alert("删除失败 可能当前属性项存在属性的值，请先删除属性值");
                        break;
                    default:
                        alert("操作异常，获取数据或null");
                        break;
                }
            },
            complete: function () {
                //do something.
                treeview_Prop_ProdCate_onChange("#treeview_ProdPropertiesValue", ProdCateID, "#Prop_dropdown-menu1"); //重载属性项视图
                $("#btn_del_PropertiesValueName").removeAttr("disabled");  // 解除 防止用户重复提交

            },
            error: function (result) {
                alert("发生服务器程序错误\n\r[ProdPropertiesName_Del]\n\r code:501");
            },
            beforeSend: function () {
                // do something.
                // 一般是禁用按钮等防止用户重复提交
                $("#btn_del_PropertiesValueName").attr({ disabled: "disabled" });
                // 或者是显示loading图片
            },
        });

    }
});

//insert ProdPropertiesName
$("#Savechanges_AddNew_PropertiesValueName").click(function () {

    var ProdCateID = $("#txtProp_ProdCateID").val(); 
    var ProdCateName = $('#txtProp_ProdcateName').val(); // 类目名称  
    var PropertiesName = $('#txtPropertiesValueName_forAddNew').val(); // 属性名称  
    PropertiesName = PropertiesName.replace(/^\s+|\s+$/g, '');//去掉空格
     
    var ShowPicture = 0; //int
    if ($("#chk_ShowPicture").is(":checked")) {
        ShowPicture = 1;
    } 

    var IsForTrading = "0"; //int
    if ($("#chk_IsForTrading1").is(":checked")) {
        IsForTrading="1"
    } 
      
    var myparamsObject = { "ProdCateID": ProdCateID, "ProdCateName": ProdCateName, "PropertiesName": PropertiesName, "IsForTrading": IsForTrading, "ShowPicture": ShowPicture };
    console.log("Savechanges_AddNew_PropertiesValueName：/r/n")
    console.log(myparamsObject);
    if (PropertiesName.length <= 1) {
        
        $('#Savechanges_AddNew_PropertiesValueName').prop('disabled', true);
        $('#pCheckPropertiesName').html("<h5 class='text-warning btn-block' style='margin-top:-10px;margin-bottom:5px;'><i class='icon-warning-sign'  style='color:red'></i>&nbsp;<strong>Fail！</strong><small><span>输入属性名称！</span></small></h4>");
        return ;
    } else {
         
        $.ajax({
            url: "/Mgr/ProdCateV2/ProdPropertiesName_INS", /*设置post提交到的页面*/
            data: JSON.stringify(myparamsObject),
            type: "post",
            dataType: "json", /*设置返回值类型为Json*/
            contentType: "application/json;charset=utf-8",
            error: function (result) {
               
                console.log("回调结果"+JSON.stringify(result));
                alert("发生服务器程序错误\n\r code:500 \n\r ProdPropertiesName_INS");
            },
            success: function (Data) {
                 
                console.log("result=" + Data.result);
                if (Data.result ==1)  //新增 1=成功 ； 0= 失败
                { 
                    $('#Savechanges_AddNew_PropertiesValueName').prop('disabled', false);
                    $('#txtPropertiesValueName_forAddNew').val(""); 
                    $('#Modal_alert_ADDNew_PropertiesValueName').toggle();
                    setTimeout("$('#Modal_alert_ADDNew_PropertiesValueName').toggle()", 4000);
                    treeview_Prop_ProdCate_onChange("#treeview_ProdPropertiesValue", ProdCateID, "#Prop_dropdown-menu1");
                }
                else
                { 
                    $('#Savechanges_AddNew_PropertiesValueName').prop('disabled', true);
                    $('#Modal_alert_ADDNew_PropertiesValueName').html("<h4 class='text-warning btn-block' style='margin-top:-10px;margin-bottom:5px;'><i class='icon-bell-alt'  style='color:green'></i>&nbsp;<strong>Fail！</strong><small><span>" + PropertiesName + "-保存失败！</span></small></h4>");
                    $('#Modal_alert_ADDNew_PropertiesValueName').toggle();
                    setTimeout("$('#Modal_alert_ADDNew_PropertiesValueName').toggle()", 4000); 
                }
            }

        });
    }
})

//【动态检查属性名称是否重复】（规则：不允许同一类目下 相同的属性名称）
$("#txtPropertiesValueName_forAddNew").on('input', function (e) {

    var ProdCateID = $("#txtProp_ProdCateID").val(); //检查 类目名称是否相同
    var PropertiesName = $("#txtPropertiesValueName_forAddNew").val();

    var myparamsObject = { "ProdCateID": ProdCateID, "PropertiesName": PropertiesName };

    $.ajax({
        url: "/Mgr/ProdCateV2/ProdCate_CheckPropertiesName",
        data: JSON.stringify(myparamsObject),
        contentType: "application/json;charset=utf-8",
        type: "post",
        dataType: "json",
        error: function (result) {
            alert("【重名检测】\n\r发生服务器程序错误\n\r code:500");
        },
        success: function (data) {

            console.log("属性重复动态检查result=" + data.result + ">>>" + JSON.stringify(data));
            if (data.result === "1")  //1=成功 ； 0= 失败
            {
                var repeatname = "<h5 class='text-warning btn-block' style='margin-top:-10px;margin-bottom:5px;'><i class='icon-warning-sign'  style='color:red'></i>&nbsp;<strong>Fail！</strong><small><span>【" + PropertiesName + "】,已经存在！</span></small></h4>";
                $('#Savechanges_AddNew_PropertiesValueName').prop('disabled', true);
                $('#pCheckPropertiesName').html(repeatname);
            }
            else {
                $('#Savechanges_AddNew_PropertiesValueName').prop('disabled', false);
                $('#pCheckPropertiesName').html("");
            }
        } 
    }); 
});


//【动态检查属性名称是否重复】（规则：不允许同一类目下 相同的属性名称）
$("#txtPropertiesValueName_for_upd").on('input', function (e) {

    var ProdCateID = $("#txtProp_ProdCateID").val(); //检查 类目名称是否相同
    var PropertiesName = $("#txtPropertiesValueName_for_upd").val(); 
    var myparamsObject = { "ProdCateID": ProdCateID, "PropertiesName": PropertiesName };

    $.ajax({
        url: "/Mgr/ProdCateV2/ProdCate_CheckPropertiesName",
        data: JSON.stringify(myparamsObject),
        contentType: "application/json;charset=utf-8",
        type: "post",
        dataType: "json",
        error: function (result) {
            alert("【Update重名检测】\n\r发生服务器程序错误\n\r code:500");
        },
        success: function (data) {

            console.log("更新动态检查重名result=" + data.result + ">>>" + JSON.stringify(data));
            if (data.result === 1)  //1=成功 ； 0= 失败
            {
                alert("sdfsdfasdfasdfasdfasdfasfasdfasdfasdfasdfasdfasdf");
                var repeatname = "<h5 class='text-warning btn-block' style='margin-top:-10px;margin-bottom:5px;'><i class='icon-warning-sign'  style='color:red'></i>&nbsp;<strong>Fail！</strong><small><span>" + PropertiesName + ",已存在！</span></small></h4>";
                $('#Savechanges_upd_PropertiesValueName').prop('disabled', true);
                $('#pCheckPropertiesName_upd').html(repeatname);
            }
            else {
                $('#Savechanges_upd_PropertiesValueName').prop('disabled', false);
                $('#pCheckPropertiesName_upd').html("");
            }
        }
    });
});

function doSomething(KeyName) {
    setTimeout(function () {  
        var callbackResult = getLanguage(KeyName);
        return callbackResult;
    }, 100);
}  
 
var JS_Savechanges_upd_PropertiesValueName_callbackResult = doSomething();

var callbackResult = JS_Savechanges_upd_PropertiesValueName_callbackResult;


//更改属性名称
$("#Savechanges_upd_PropertiesValueName").click(function () {

    var ProdCateID = $("#txtProp_ProdCateID").val();
    var PropertiesNameID = $("#txt_PropertiesValueID").val();
    var PropertiesName = $('#txtPropertiesValueName_for_upd').val(); //新的 属性名称  
    PropertiesName = PropertiesName.replace(/^\s+|\s+$/g, '');//去掉空格

    var IsForTrading = 0; //int
    if ($("#chk_IsForTrading2").is(":checked")) {
        IsForTrading = 1;
    }
    
    var ShowPicture = 0; //int
    if ($("#chk_ShowPicture").is(":checked")) {
        ShowPicture = 1;
    }

    var myparamsObject = { "PropertiesNameID": PropertiesNameID, "PropertiesName": PropertiesName, "IsForTrading": IsForTrading, "ShowPicture": ShowPicture};

    console.log("ProdPropertiesName_Upd 传递的參數：\n\r" + myparamsObject);

    console.log("更新参数：" + JSON.stringify(myparamsObject));
     
    if (PropertiesName.length <= 1) {
        $('#Savechanges_upd_PropertiesValueName').prop('disabled', true);
        $('#pCheckPropertiesName_upd').html("<h5 class='text-warning btn-block' style='margin-top:-10px;margin-bottom:5px;'><i class='icon-warning-sign'  style='color:red'></i>&nbsp;<strong>Fail！</strong><small><span>输入属性名称！</span></small></h4>");
        return;
    } else {
        $.ajax({
            url: "/Mgr/ProdCateV2/ProdPropertiesName_Upd", 
            data: JSON.stringify(myparamsObject),
            contentType: "application/json;charset=utf-8",
            type: "post",
            dataType: "json",
            error: function (data) { 
                
                console.log( JSON.stringify(data));
                alert("发生服务器程序错误\n\r code:500");
            },
            success: function (data) {
                 
                console.log("action-success 传入参数[update]：" + JSON.stringify(data));
                console.log("UPDATE:" + JSON.stringify(data));
                 
                if (data.result === 1)  //更新 1=成功 ； 0= 失败
                { 
                    $('#Savechanges_upd_PropertiesValueName').prop('disabled', false);
                    $('#txtPropertiesValueName_for_upd').val("");
                    $('#Modal_alert_upd_PropertiesValueName').toggle();
                    setTimeout("$('#Modal_alert_upd_PropertiesValueName').toggle()", 4000);
                    treeview_Prop_ProdCate_onChange("#treeview_ProdPropertiesValue", ProdCateID, "#Prop_dropdown-menu1");
                }
                else {
                    $('#Savechanges_upd_PropertiesValueName').prop('disabled', true);
                    $('#Modal_alert_upd_PropertiesValueName').html("<h4 class='text-warning btn-block' style='margin-top:-10px;margin-bottom:5px;'><i class='icon-bell-alt'  style='color:green'></i>&nbsp;<strong>Fail！</strong><small><span>" + PropertiesName + "-Failure </span></small></h4>");
                    $('#Modal_alert_upd_PropertiesValueName').toggle();
                    setTimeout("$('#Modal_alert_upd_PropertiesValueName').toggle()", 4000);
                }
            }
        });
    }
});

$("#btn_PropertiesValue_Edit_1").click(function () {

    OpenPropertiesValuesEdit();

});
function OpenPropertiesValuesEdit()
{
    var ProdcateName = $("#txtProp_ProdcateName").val();
    ProdcateName = ProdcateName.replace(/^\s+|\s+$/g, '');//去掉空格

    var ProdCateID = $("#txtProp_ProdCateID").val();
    ProdCateID = ProdCateID.replace(/^\s+|\s+$/g, '');

    var PropertiesName = $("#txtPropertiesValueName").val();  //纠正：#txtPropertiesValueName 实际上是：PropertiesName，
    PropertiesName = PropertiesName.replace(/^\s+|\s+$/g, '');

    var PropertiesNameID = $("#txt_PropertiesValueID").val();  //纠正：#txt_PropertiesValueID 实际上是：PropertiesNameID，
    PropertiesNameID = PropertiesNameID.replace(/^\s+|\s+$/g, '');

    if (ProdcateName.length < 2 || ProdCateID.length < 2 || ProdCateID.length < 2 || ProdCateID.length < 2 || ProdCateID.length < 2) {
        //alert("请在【商品属性管理】\n\r选择分类和属性。");
        return;
    }
    var params1 = "?ProdCateID=" + ProdCateID + "&ProdcateName=" + ProdcateName + "&PropertiesNameID=" + PropertiesNameID + "&PropertiesName=" + PropertiesName;
    var url = "/Mgr/productPropertiesValue" + params1;
    //I 采用iframe方法
    //$("#iframe1").attr("visibility", "visible");
    $("#iframe1").attr("src", url);

    //II 采用弹窗方法
    //window.open(url, 'newwindow', 'height=550,width=800,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no')
}

 
function getLanguage(KeyName) {
    var returnSTR = "-";
    var myparamsObject = { "KeyName": KeyName };
    $.ajax({
        url: "/cn/Base/GetLang",
        data: JSON.stringify(myparamsObject),
        contentType: "application/json;charset=utf-8",
        type: "post",
        dataType: "json",
        error: function (data) {
            console.log("function : getLanguage：" + KeyName　);
            return KeyName;
        },
        success: function (data) {
            console.log("getLanguage" + data.result);
            returnSTR = data.result;
            return returnSTR;
        }
    });
} 