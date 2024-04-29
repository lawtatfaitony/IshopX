
// 图片上传demo
jQuery(function() {
    var $ = jQuery,
        $list = $('#fileList'),
        // 优化retina, 在retina下这个值是2
        ratio = window.devicePixelRatio || 1,
        // 添加的文件数量
        fileCount = 50,
        // 添加的文件总大小
        fileSize = 1024*1024*2, //限制2M
        // 缩略图大小
        thumbnailWidth = 90 * ratio,
        thumbnailHeight = 90 * ratio,

        // Web Uploader实例
        uploader;

    // 初始化Web Uploader
    uploader = WebUploader.create({

        // 自动上传。
        auto: true,
        // swf文件路径
        swf: '/webuploader/Script/Uploader.swf',

        // 文件接收服务端。
        server: '/Mgr/Product/UploadProductPic.ashx', //'/Home/UpLoadProcess',

        // 选择文件的按钮。可选。
        // 内部根据当前运行是创建，可能是input元素，也可能是flash.
        pick: '#filePicker',

        fileNumLimit:"100",
        // 只允许选择文件，可选。
        accept: {
            title: 'Images',
            extensions: 'gif,jpg,jpeg,bmp,png',
            mimeTypes: 'image/*'
        },
        compress: null  //不压缩上存
    });

    // 当有文件添加进来的时候
    uploader.on('fileQueued', function (file) {
        // 初始化以后添加 参数传入 
        
        uploader.options.formData.IsAheader = 'Desc';
        uploader.options.formData.StyleNo = $("#txtStyleNo").val(); //如果没有货号，则为null/empty
        uploader.options.formData.Width = file.Width;
        uploader.options.formData.Height = file.Height;
        console.log(uploader.options)
        //----------------------
        var $li = $(
                '<div id="' + file.id + '" class="file-item thumbnail">' +
                    '<img>' +
                    '<div class="info">' + file.name + '</div>' +
                '</div>'
                ),
            $img = $li.find('img');

        $list.append( $li );

        // 创建缩略图
        uploader.makeThumb( file, function( error, src ) {
            if ( error ) {
                $img.replaceWith('<span>不能预览</span>');
                return;
            }

            $img.attr( 'src', src );
        }, thumbnailWidth, thumbnailHeight );
    });

    // 文件上传过程中创建进度条实时显示。
    uploader.on( 'uploadProgress', function( file, percentage ) {
        var $li = $( '#'+file.id ),
            $percent = $li.find('.progress span');

        // 避免重复创建
        if ( !$percent.length ) {
            $percent = $('<p class="progress"><span></span></p>')
                    .appendTo( $li )
                    .find('span');
        }

        $percent.css( 'width', percentage * 100 + '%' );
    });

    // 文件上传成功，给item添加成功class, 用样式标记上传成功。
    uploader.on('uploadSuccess', function (file, response) {
        $('#' + file.id).addClass('upload-state-done');
        var img = document.createElement("img");
        //img.src = response.filePath; 
        img.src = response.url;
        img.style = "align-self:center;";
        $("#editor").append(img);
    });

    // 文件上传失败，现实上传出错。
    uploader.on( 'uploadError', function( file ) {
        var $li = $( '#'+file.id ),
            $error = $li.find('div.error');

        // 避免重复创建
        if ( !$error.length ) {
            $error = $('<div class="error"></div>').appendTo( $li );
        }

        $error.text('上传失败');
    });
    
    // 完成上传完了，成功或者失败，先删除进度条。
    uploader.on( 'uploadComplete', function( file ) {
        $( '#'+file.id ).find('.progress').remove();
    });
});