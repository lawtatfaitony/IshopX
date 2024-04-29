   //获取验证码并且提示是否成功,没用到此文件. 在 /Account/Regmobile 可以找到

         $("#BtnSendVerifyCode").click(function () {
                
               
                var PhoneNumber = $('#PhoneNumber').val(); //发送手机号码返回服务器 
             
                var myparamsObject = { "PhoneNumber": PhoneNumber};
                $.ajax({
                    url: "/en/Account/SendVerifyCode", /*获取验证码*/
                    data: myparamsObject,
                    type: "get",
                    dataType: "text", /*设置返回值类型为文本*/
                    error: function (result) { 
                        console.log(JSON.stringify(result));
                        alert("获取验证码错误\n\n请重新点击试试\n\n code:500\n\n" + JSON.stringify(result));
                    },
                    success: function (result) { 
                        
                        json = JSON.parse(result);
                        if (json.MsgCode == "1") {
                            console.log(json.Message);
                            var insertHtmlmsg = "<span style='color:red;'>" + json.Message + "</span>";
                            $('#returnCodeResult').html(insertHtmlmsg);
                        }
                        else {
                            var insertHtmlmsg = "<span style='color:red;'>" + json.Message + "</span>";
                            $('#returnCodeResult').html(insertHtmlmsg);
                            
                        } 
                    }  
                });
        })
        
 