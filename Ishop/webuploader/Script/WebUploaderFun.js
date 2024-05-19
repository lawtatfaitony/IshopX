//上存图片函数

var uploadshopUrl = "/zh-HK/Utilities/UpLoadProcess";

if (LanguageCode != null || LanguageCode != "") {
    uploadshopUrl = "/" + LanguageCode + "/Utilities/UpLoadProcess";
}

//获取应用程序根路径
//var applicationPath = window.applicationPath === "" ? "" : window.applicationPath || "../../";  
function WebUploader1(fileList, filePicker, Prefix, SubPath,StoreUrlPathValueID,TargetTalbeKeyID, ShopID , RankOrder) {
    fileList = "#" + fileList;
    filePicker = "#" + filePicker;
    var $ = jQuery,
    $list = $(fileList),
    // 优化retina, 在retina下这个值是2
    ratio = window.devicePixelRatio || 1,
    // 缩略图大小
    thumbnailWidth = 110 * ratio,
    thumbnailHeight = 110 * ratio,

    // Web Uploader实例
    uploader;
    uploader = WebUploader.create({
        // 选完文件后，是否自动上传。
        auto: true,
        compressSize: 0 ,
        compress: null , 
        disableGlobalDnd: true,
        // swf文件路径
        swf:  '/webuploader/Script/Uploader.swf',

        // 文件接收服务端。
        server: uploadshopUrl,    // '@Url.Action("UpLoadProcess", "Utilities")',

        // 选择文件的按钮。可选。
        // 内部根据当前运行是创建，可能是input元素，也可能是flash.
        pick: filePicker,

        //只允许选择图片
        accept: {
            title: 'Images',
            extensions: 'gif,jpg,jpeg,bmp,png',
            mimeTypes: 'image/*'
        }
    });

    // 当有文件添加进来的时候
    uploader.on('fileQueued', function (file) {
        // 初始化以后添加 参数传入 
        
        uploader.options.formData.Prefix = Prefix;     // 设置前缀 Shoplogo_
        uploader.options.formData.SubPath = SubPath;  //设置SubPath  Shoplogo_
        uploader.options.formData.TargetTalbeKeyID = TargetTalbeKeyID;
        uploader.options.formData.ShopID = ShopID;
        uploader.options.formData.RankOrder = RankOrder;

        uploader.options.formData.Width = file.Width;
        uploader.options.formData.Height = file.Height;

        console.log(JSON.stringify(uploader.options))

        var $li = $(
                '<div id="' + file.id + '" class="cp_img">' +
                    '<img class="thumbnail">' +
                '<div  class="cp_img_jian"></div></div>'
                ),
            $img = $li.find('img');
             
        // $list为容器jQuery实例
        //$list.append($li); // 图片追加形式
        $list.html($li);  //上存一个文件
        console.log($li);

        
        // 创建缩略图
        // 如果为非图片文件，可以不用调用此方法。
        // thumbnailWidth x thumbnailHeight 为 100 x 100
        uploader.makeThumb(file, function (error, src) {
            if (error) {
                $img.replaceWith('<span>不能预览</span>');
                return;
            }

            $img.attr('src', src);
        }, thumbnailWidth, thumbnailHeight);
    });

    // 文件上传过程中创建进度条实时显示。
    uploader.on('uploadProgress', function (file, percentage) {
        var $li = $('#' + file.id),
            $percent = $li.find('.progress span');

        // 避免重复创建
        if (!$percent.length) {
            $percent = $('<p class="progress"><span></span></p>')
                    .appendTo($li)
                    .find('span');
        }

        $percent.css('width', percentage * 100 + '%');
    });

    // 文件上传成功，给item添加成功class, 用样式标记上传成功。
    uploader.on('uploadSuccess', function (file, response) {
        console.log("事件(uploadSuccess)图片url:" + response.filePath);
        if (StoreUrlPathValueID.length > 1) {
           
            StoreUrlPathValueID = "#" + StoreUrlPathValueID;
            $(StoreUrlPathValueID).val(response.filePath);
            //重置 StoreUrlPathValueID
            StoreUrlPathValueID = "";
        }
        $('#' + file.id).addClass('upload-state-done');

        //显示删除按钮
        $('#' + file.id).on("mouseover", function () {
            $(this).children(".cp_img_jian").css('display', 'block');

        });
        //隐藏删除按钮
        $('#' + file.id).on("mouseout", function () {
            $(this).children(".cp_img_jian").css('display', 'none');

        });
        //执行删除方法
        $list.on("click", ".cp_img_jian", function () {
            var Id = $(this).parent().attr("id");
            uploader.removeFile(uploader.getFile(Id, true));
            $(this).parent().remove();
        });
       
    });

    // 文件上传失败，显示上传出错。
    uploader.on('uploadError', function (file) {
        var $li = $('#' + file.id),
            $error = $li.find('div.error');

        // 避免重复创建
        if (!$error.length) {
            $error = $('<div class="error"></div>').appendTo($li);
        }

        $error.text('上传失败');
    });

    // 完成上传完了，成功或者失败，先删除进度条。
    uploader.on('uploadComplete', function (file) {
        $('#' + file.id).find('.progress').remove();
    });

    //所有文件上传完毕
    uploader.on("uploadFinished", function () {
        //提交表单

    });
  
}