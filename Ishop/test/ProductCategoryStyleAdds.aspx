<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductCategoryStyleAdds.aspx.cs" Inherits="test_ProductCategoryStyleAdds" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>产品类目添加 属性控件 添加和动态绑定数据 样式排列</title>
     <meta name="viewport" content="width=device-width, initial-scale=1.0" /> 

            <script src="/jquery/1.11.3/jquery.js"></script>  
            <link href="/bootstrap/3.3.5/css/bootstrap.css" rel="stylesheet" />
            <script src="/bootstrap/3.3.5//js/bootstrap.min.js"></script>
            <link href="/font/font-awesome.css" rel="stylesheet" />
     
       
    <style>
      .container{width: 800px !important;}
      #cls{font-family:SimHei; font-size:14px;background-color:AppWorkspace;padding:10px;width:800px;}
      label{word-break: keep-all; }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="containers" style="width:800px;">
        
        <asp:CheckBoxList ID="CheckBoxList1" ClientIDMode="Static"  runat="server" CellPadding="10" CellSpacing="10" Font-Size="X-Small" RepeatDirection="Horizontal"  RepeatLayout="Table" ViewStateMode="Enabled" RepeatColumns="3">
            <asp:ListItem>dgfd </asp:ListItem>
            <asp:ListItem>fdg g</asp:ListItem>
            <asp:ListItem Value="dfg">fgdfg</asp:ListItem>
            <asp:ListItem>dfg</asp:ListItem>
        </asp:CheckBoxList>
        <asp:Panel ID="Panel1"   CssClass="cls" runat="server" BackColor="#f7f7f7" Font-Names="黑体" Font-Size="14px" style="padding:5px;" ClientIDMode="Static" Width="663px" > 
            
        </asp:Panel>

        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

        <br />

     
		 
    
    </div>
    </form>
</body>
</html>
