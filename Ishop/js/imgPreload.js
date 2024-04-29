//预载图片，特别需要JS引用图片对象时候，需要在引用前加载图片后才引用。
//范例 /test/imgProload.html
function loadImage(id, src, callback) {
    var imgloader = new window.Image();
    //当图片成功加载到浏览器缓存
    imgloader.onload = function (evt) {
        if (typeof (imgloader.readyState) == 'undefined') {
            imgloader.readyState = 'undefined';
        }
        //在IE8以及以下版本中需要判断readyState而不是complete
        if ((imgloader.readyState == 'complete' || imgloader.readyState == "loaded") || imgloader.complete) {
            //console.log('width='+imgloader.width+',height='+imageloader.height);//读取原始图片大小
            callback({ 'msg': 'ok', 'src': src, 'id': id });
        } else {
            imgloader.onreadystatechange(evt);
        }
    };
    imgloader.onerror = function (evt) {
        callback({ 'msg': 'error', 'id': id });
    };
    imgloader.onreadystatechange = function (e) {
        //此方法只有IE8以及一下版本会调用
    };
    imgloader.src = src;
}
var loadResult = function (data) {
    data = data || {};
    if (typeof (data.msg) != 'undefined') {
        if (data.msg == 'ok') {
            //这里使用了id获取元素，有点死板，建议读者自行扩展为css 选择符
            document.getElementById('' + data.id).src = data.src;
            alert(data + '----------');
        } else {
            //这里图片加载失败，我们可以显示其他图片，防止大红叉
            document.getElementById('' + data.id).src = '/images/picunload.png';
        }
    }
}