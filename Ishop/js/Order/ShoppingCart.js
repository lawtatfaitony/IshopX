function AddToCart(ProductSkuId) { 

    console.log("AddToCart( ProductSkuId) :" + ProductSkuId);

    var myparamsObject = { "Id": ProductSkuId, Quantity :1 }; 
    
    $.ajax({
        alert("\js\Order\ShoppingCart.js AddToCart(ProductSkuId)");

        url: "/cn/Cart/AddToCart", /*设置post提交到的页面*/
        data: myparamsObject,
        type: "post",
        dataType: "text", /*设置返回值类型为文本*/
        error: function (result) {
            console.log("统计：AddToCart 发生服务器程序错误\n\r code:500 \n\r\n\r" + JSON.stringify(result));
        },
        success: function (result) {
            var newDate = new Date()
            console.log("ProductSkuId = " + ProductSkuId + "\n\r" + newDate.toLocaleTimeString());
            console.log(result);
            return result.result;
        } 
    });
}
 
//remain
function GetProductSkuIdInStock(ValsId) {
    var myparamsObject = { "ValsId": ValsId };
    $.ajax({
        url: "/cn/Cart/GetProductSkuIdInStock",
        data: myparamsObject,
        type: "post",
        dataType: "json",
        error: function (result) {
            console.log("GetProductSkuId error \n\r code:500 \n\r\n\r" + JSON.stringify(result));
        },
        success: function (result) {
            //console.log("ProductSku  = " + JSON.stringify(result)); 
            console.log(JSON.stringify(result));
            if (result.ProductSkuId === "0") {

                return "-1";
            }
            else {
                return result.Quantity;
            }
        }
    });
}