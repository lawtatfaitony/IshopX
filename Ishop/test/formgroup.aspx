<%@ Page Language="C#" AutoEventWireup="true" CodeFile="formgroup.aspx.cs" Inherits="test_formgroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>表单内联</title>
    <script src="../jquery/1.11.3/jquery.js"></script>
    <link href="../bootstrap/3.3.5/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form class="form-horizontal" role="form">
          <div class="form-group form-group-lg">
            <label class="col-sm-2 control-label" for="formGroupInputLarge">Large label</label>
            <div class="col-sm-10">
              <input class="form-control" type="text" id="formGroupInputLarge" placeholder="Large input">
            </div>
          </div>
          <div class="form-group form-group-sm">
            <label class="col-sm-2 control-label" for="formGroupInputSmall">Small label</label>
            <div class="col-sm-10">
              <input class="form-control" type="text" id="formGroupInputSmall" placeholder="Small input">
            </div>
          </div>
</form>
</body>
</html>
