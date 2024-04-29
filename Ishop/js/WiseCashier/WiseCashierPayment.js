var js_api_param = {};

//调用微信JS api 支付
function jsApiCall() {
    WeixinJSBridge.invoke('getBrandWCPayRequest', js_api_param,
        function (res) {
            if (res.err_msg == "get_brand_wcpay_request:ok") {
                alert('支付成功');
            }

            if (res.err_msg == "get_brand_wcpay_request:cancel") {
                alert('取消支付');
            }

            if (res.err_msg == "get_brand_wcpay_request:fail") {
                alert('支付失败');
            }
        });
}

//点击确认支付
$('#pay-btn').on('click', function () {

    $.ajax({
        async: true,
        url: 'https://api.wisecashier.com/mp_pay',
        type: 'POST',
        data: {
            'merchant_no': $('#merchant_no').val(),
            'amount': $('#amt').val(),
            'openid': $('#openid').val()
        },
        headers: {
            'Version': '1.0'
        },
        beforeSend: function () {
        },
        success: function (r) {
            if (r.meta.success) {
                js_api_param = r.data.js_param;
                if (typeof WeixinJSBridge == "undefined") {
                    if (document.addEventListener) {
                        document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
                    } else if (document.attachEvent) {
                        document.attachEvent('WeixinJSBridgeReady', jsApiCall);
                        document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
                    }
                } else {
                    jsApiCall();
                }
            }
        },
        complete: function () {
        }
    });
});