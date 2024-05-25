//手机版本的 引用 百度 src="~/js/clipboard/clipboard.min.js"
function getClipboardText(id) {
    var btn = document.getElementById(id);
    var clipboard = new Clipboard(btn);

    clipboard.on('success', function (e) {
        console.log(e);
    });

    clipboard.on('error', function (e) {
        console.log(e);
    });
}
function getClipboardTextV2() {
    var clipboard = new ClipboardJS('.clipboard');
    clipboard.on('success', function (e) {
        console.log(e);
        layer.msg('copy');
    });
}
//参数n为休眠时间，单位为毫秒:
function sleep(n) {
    var start = new Date().getTime(); 
    while (true) {
        if (new Date().getTime() - start > n) {
            break;
        }
    } 
}
//Uploading
function onBeginSubmit(layer_index) {
    layer_index = layer.load(0, { shade: false });
}
function layerTips(msg) {
    //提示
    var PopupTips = layer.open({
          content: msg
        , skin: 'msg'
        , time: 3
    }); 
} 


////用法 ： var str = "{0}{1}".StringFormat("Eric", "Yu");
// str = "EricYu"
String.prototype.StringFormat = function () {
    if (arguments.length == 0) {
        return this;
    }
    for (var StringFormat_s = this, StringFormat_i = 0; StringFormat_i < arguments.length; StringFormat_i++) {
        StringFormat_s = StringFormat_s.replace(new RegExp("\\{" + StringFormat_i + "\\}", "g"), arguments[StringFormat_i]);
    }
    return StringFormat_s;
};
　
$("#HomeLink").click(function () {
    window.location = "/cn/home/index";
    console.log("NavigateTo : /cn/home/index");
});


function getShopPriceByShopCurrency(price, shopCurrency) {
    if (shopCurrency !== "" || shopCurrency !== null) {

        if (price === "" || price === null) {
            return "HK$0.0";
        } else {

            if (typeof price === 'string') {

                price = price.toString(); // 將數字轉換為字串

            } else {
                console.log('main.js getShopPriceByShopCurrency :: price =' + price);
            }

            if (price.toString().startsWith("HK$") || price.toString().startsWith("CN¥") || price.toString().startsWith("US$")) {

                return price;
            }

            let strPrice = price.toString(); 
            console.log("strPrice typeof =" + typeof strPrice);
            strPrice = strPrice.replace(/\.0$/, "");

            switch (shopCurrency) {
                case "zh-HK":

                    strPrice = "HK$" + price + ".0";
                    console.log('main.js getShopPriceByShopCurrency  price =' + strPrice);
                    return strPrice;

                case "zh-CN":

                    strPrice = "CN¥" + price + ".0"; 
                    console.log('main.js getShopPriceByShopCurrency  price =' + strPrice);
                    return strPrice;

                case "en-US":

                    strPrice = "US$" + price + ".0";
                    console.log('main.js getShopPriceByShopCurrency  price =' + strPrice);
                    return strPrice;

                default:

                    strPrice = "HK$" + price + ".0";
                    console.log('main.js getShopPriceByShopCurrency  price =' + strPrice);
                    return strPrice; 
            }
        }
    } else {
        return price;
    }
}


 
 