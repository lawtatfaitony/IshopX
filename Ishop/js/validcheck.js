function checkProdCateName(str)
{
   return str.match(/^[\u4E00-\u9FA5a-zA-Z0-9_]{3,20}$/);  //返回 文字、字母或者数字。如果都没有，返回 null
}
function getridofSymbol(str) {
    var str = "jfkldsjalk,.23@#!$$k~!  @#$%^&*()(_+-=|\{}[]';:,./<>??gg  g~```gf";
    str = str.replace(/[\ |\~|\`|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\-|\_|\+|\=|\||\\|\[|\]|\{|\}|\;|\:|\"|\'|\,|\<|\.|\>|\/|\?]/g, "");
    return str;
}
function getridofSymbol(str) {//去掉符号

    str = str.replace(/[\ |\~|\`|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\-|\_|\+|\=|\||\\|\[|\]|\{|\}|\;|\:|\"|\'|\,|\<|\.|\>|\/|\?]/g, "");
    return str;
}

//参数 json 处理
function getArgs(strParame) {
    var args = new Object();
    var query = location.search.substring(1); // Get query string
    var pairs = query.split("&"); // Break at ampersand
    for (var i = 0; i < pairs.length; i++) {
        var pos = pairs[i].indexOf('='); // Look for "name=value"
        if (pos == -1) continue; // If not found, skip
        var argname = pairs[i].substring(0, pos); // Extract the name
        var value = pairs[i].substring(pos + 1); // Extract the value
        value = decodeURIComponent(value); // Decode it, if needed ;【important】
        args[argname] = value; // Store as a property
    }
    return args[strParame]; // Return the object
}