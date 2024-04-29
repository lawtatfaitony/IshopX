<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bootstrap.aspx.cs" Inherits="bootstrap_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>bootstrap功德无量 </title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" href="/bootstrap/3.3.5/css/bootstrap.css">

    <!-- 可选的Bootstrap主题文件（一般不用引入） -->
    <link rel="stylesheet" href="/bootstrap/3.3.5/css/bootstrap-theme.css">

    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="//cdn.bootcss.com/jquery/1.11.3/jquery.js"></script>

    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    <style>
        .body{font:16px;}

    </style>
     
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse" role="banner">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                         
                    </button>
                    
                   
                </div>
				
                <div class="collapse navbar-collapse navbar-right">
                    <ul class="nav navbar-nav">
					   <li class="active"><a href="#">首页</a></li>
										<li >
							<a href="#" target="_self">诵经</a>
						</li>
						<li >
							<a href="#" target="_self">佛祖转世</a>
						</li>
										<li >
							<a href="#" target="_self">法师</a>
						</li>
										<li >
							<a href="#" target="_self">服务</a>
						</li>
										<li >
							<a href="#" target="_self">案例</a>
						</li>
										<li >
							<a href="#" target="_self">资讯</a>
						</li>
										<li >
							<a href="#" target="_self">联系</a>
						</li>
				                   
                    </ul>
                </div>
            </div><!--container-->
        </nav><!--/nav-->

    <div>-----------
            <h1>你好，佛祖！</h1>
            <h2>你好，佛祖！</h2> 
            <h3>你好，佛祖！</h3>
            <h4>你好，佛祖！</h4>
            <h5>你好，佛祖！</h5>
    </div>
     <div> 
    <h1>你好，世界！</h1>
 
    </div>
        <p>
  <button class="btn btn-large btn-primary" type="button">Large button</button>
  <button class="btn btn-large  btn-block" type="button">块状按钮</button>
</p>
<p>
  <button class="btn btn-primary" type="button">Default button</button>
  <button class="btn" type="button">Default button</button>
</p>
<p>
  <button class="btn btn-small btn-primary" type="button">Small button</button>
  <button class="btn btn-small" type="button">Small button</button>
</p>
<p>
  <button class="btn btn-mini btn-primary" type="button">Mini button</button>
  <button class="btn btn-mini" type="button">Mini button</button>
</p>
    </form>
    <p>
        <input id="Button1" class="btn" type="button" onclick="javascript: upload1();" value="button">

    </p>
       <script>

          function upload1(){
               window.showModalDialog();
           }
       </script>
    <hr />
           <script type="text/javascript">
               $(document).ready(function () {
                   $("#buttonP").bind("click", function () {
                      // $("p").slideToggle();
                       $("#p1").fadeToggle();
                       //$("p1").show();
                       //以上几种不同的展示方式
                   });
               });
            </script>
            <p id="p1">This is a paragraph. 使用 $选择器 指定button按钮发生点击后 P标签ID=P1内容切换隐藏或者展示</p>
            <button id="buttonP" class="btn-danger">请点击这里</button>

    <hr />
    <div id="datatest" data-test="这里一个属性标签data-test:data=hello world">这里是data 这个属性的测试</div>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $("#btn1").click(function () {
                            $("#divXdata").data("greeting","hello the world");
                            
                        });
                        $("#btn2").click(function () {
                            alert($("#divXdata").data("greeting"));
                        });
                        $("#btn3").click(function () {
                            if ($("#datatest") == undefined)
                            {
                                alert("无定义（undefined）");
                            }
                            else
                            {
                                alert($("#datatest").data("test"));
                            }
                        });
                    });
                </script>
    <input id="Text1" type="text" value="输入数据内容附加到div id=divXdata 的data 属性中。" onclick="this.value = '';" /><br />
                <button id="btn1" class="btn-default">把数据添加到 div 元素</button><br />
                <button id="btn2" class="btn-info">获取已添加到 div 元素的数据</button><br />
                <button id="btn3" class="btn-info">这里是data 这个属性的测试</button>
            <div id="divXdata"></div>
</body>
</html>
