<%@ Page Language="C#" AutoEventWireup="true" CodeFile="readdevicefilepathname.aspx.cs" Inherits="MGR_TEST_readdevicefilepathname" %>
 
<html>
<head>
    <title>上存文件图片等案例</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="/jquery/1.11.3/jquery.min.js"></script>
</head>
 <body>
        <form id="form1" runat="server">
            <div><h3>请选择图片文件：JPG/GIF</h3>
            <input type="file" name="file0" id="file0" multiple="multiple" /><br><img src="" id="img0" width="1px"  alt="">
            </div>
 
          <script>
            $("#file0").change(function () {
                var objUrl = getObjectURL(this.files[0]);
                console.log("objUrl = " + objUrl);
                if (objUrl) {

                    $("#img0").attr("src", objUrl);
                    $("#img0").attr("width", "150px");
                    $("#img0").attr("alt", objUrl);
                }
            });
            //建立一個可存取到該file的url
            function getObjectURL(file) {
                var url = null;
                if (window.createObjectURL != undefined) { // basic
                    url = window.createObjectURL(file);
                } else if (window.URL != undefined) { // mozilla(firefox)
                    url = window.URL.createObjectURL(file);
                } else if (window.webkitURL != undefined) { // webkit or chrome
                    url = window.webkitURL.createObjectURL(file);
                }
                return url;
            }
</script>
        </form>
</body>
</html>
 
 
 