<%@ Page Language="C#" AutoEventWireup="true" CodeFile="style_checkBoxList1.aspx.cs" Inherits="test_style_checkBoxList1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta name="viewport" content="width=device-width, initial-scale=1.0" /> 
            <script src="/jquery/1.11.3/jquery.js"></script>  

            <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
            <script src="/bootstrap/3.3.5/js/bootstrap.min.js"></script>

            <!-- 新 Bootstrap 核心 CSS 文件 -->
            <link rel="stylesheet" href="/bootstrap/3.3.5/css/bootstrap.min.css"/>
        

            <!-- 可选的Bootstrap主题文件（一般不用引入） -->
            <link rel="stylesheet" href="/bootstrap/3.3.5/css/bootstrap-theme.min.css"/> 
       
            <link href="/font/font-awesome.css" rel="stylesheet" />
            <!-- bootstrap-treeview 引入bootstrap-treeview.min.js-->
            <script src="/bootstrap/bootstrap-treeview/dist/bootstrap-treeview.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table style="width:165px" class="table"><tbody><tr><td>
            <table id="ProductCtlCate1_CheckBoxList1" class="35443" border="0" style="background-color:#EFEFEF;font-size:12px;font-weight:normal;width:272px; height: 79px;">
	        <tbody><tr>
		        <td><input id="ProductCtlCate1_CheckBoxList1_0" type="checkbox" name="ProductCtlCate1$CheckBoxList1$0" checked="checked"><label for="ProductCtlCate1_CheckBoxList1_0">材料</label></td><td><input id="ProductCtlCate1_CheckBoxList1_1" type="checkbox" name="ProductCtlCate1$CheckBoxList1$1"><label for="ProductCtlCate1_CheckBoxList1_1">使用对象</label></td><td><input id="ProductCtlCate1_CheckBoxList1_2" type="checkbox" name="ProductCtlCate1$CheckBoxList1$2"><label for="ProductCtlCate1_CheckBoxList1_2">工艺处理</label></td>
	        </tr><tr>
		        <td><input id="ProductCtlCate1_CheckBoxList1_3" type="checkbox" name="ProductCtlCate1$CheckBoxList1$3"><label for="ProductCtlCate1_CheckBoxList1_3">使用季节</label></td><td><input id="ProductCtlCate1_CheckBoxList1_4" type="checkbox" name="ProductCtlCate1$CheckBoxList1$4"><label for="ProductCtlCate1_CheckBoxList1_4">弹力</label></td><td><input id="ProductCtlCate1_CheckBoxList1_5" type="checkbox" name="ProductCtlCate1$CheckBoxList1$5"><label for="ProductCtlCate1_CheckBoxList1_5">细节</label></td>
	        </tr><tr>
		        <td><input id="ProductCtlCate1_CheckBoxList1_6" type="checkbox" name="ProductCtlCate1$CheckBoxList1$6"><label for="ProductCtlCate1_CheckBoxList1_6">厚薄</label></td><td><input id="ProductCtlCate1_CheckBoxList1_7" type="checkbox" name="ProductCtlCate1$CheckBoxList1$7"><label for="ProductCtlCate1_CheckBoxList1_7">出厂年份</label></td><td></td>
	        </tr>
        </tbody>

            </table>

           </td></tr></tbody></table>
    </div>
        <div>

            <script>
                alert("eeeeeeeeeeeeeeeeeeee" + $("#Text1").val());
                function  checkProdCateName(str) {
                    return str.match(/^[\u4E00-\u9FA5a-zA-Z0-9_]{1,30}$/)
                    //var msg =返回  "汉字 英文字母 数字 下划线组成，3-30位"，都没有返回null;  
                    // alert("匹配="+str.match(/^[\u4E00-\u9FA5a-zA-Z0-9_]{1,30}$/));     
                }
                $("#Button1").click(function () {
                    var str = $("#Text1").val();
                    alert("11111111111111111111111111");
                })
                
            </script>
            <input id="Text1" value="sdfsd " type="text" /><input id="Button1"   type="button" value="button" /></div>
    </form>
</body>
</html>
