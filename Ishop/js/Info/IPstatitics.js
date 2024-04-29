

//IP SourceStatistics 
function SourceStatistics(SourceStatisticsID, IntervalMinutes, IpStatitics_StartDate_Token) {
   
    var myparamsObject_Base_IPstatitics = { "SourceStatisticsID": SourceStatisticsID, "IntervalMinutes": IntervalMinutes, "IpStatitics_StartDate_Token": IpStatitics_StartDate_Token };
     
    var hiddenProperty = 'hidden' in document ? 'hidden' : 'webkitHidden' in document ? 'webkitHidden' : 'mozHidden' in document ? 'mozHidden' : null;
    var visibilityChangeEvent = hiddenProperty.replace(/hidden/i, 'visibilitychange');
    var onVisibilityChange = function () {
        if (!document[hiddenProperty]) {
            console.log('Page Not In Active');
            return;  
        } else {
            console.log('Page In Active');
            //==========
            $.ajax({
                url: "/en/Base/IPstatitics",
                data: myparamsObject_Base_IPstatitics,
                type: "post",
                dataType: "json",
                error: function (result) {
                    console.log("Server fatal Error Occur\n\r code:500" + JSON.stringify(result));
                },
                success: function (result) {
                    var newDate = new Date();
                    console.log(newDate.toLocaleTimeString());
                    console.log(result);
                }
            }); 
        }
    };
    document.addEventListener(visibilityChangeEvent, onVisibilityChange);

    
}

//Browse product views statistics  
function ProductViewCount(ProductID, IpStatitics_StartDate_Token) {

    var myparamsObject = { "ProductID": ProductID, "IpStatitics_StartDate_Token": IpStatitics_StartDate_Token };

    $.ajax({
        url: "/Mgr/ProductMgr/ProductViewCount", /*设置post提交到的页面*/
        data: myparamsObject,
        type: "post",
        dataType: "json", /*设置返回值类型为文本*/
        error: function (result) {
            console.log("ProductViewCount 浏览次数统计：发生服务器程序错误\n\r code:500" + JSON.stringify(result));
        },
        success: function (result) {
            var newDate = new Date();
            console.log(newDate.toLocaleTimeString());
            console.log(result);
        }
    });
}
//Views times statistics)

function InfoViewCount(InfoID, IpStatitics_StartDate_Token) {

    var myparamsObject = { "InfoID": InfoID, "IpStatitics_StartDate_Token": IpStatitics_StartDate_Token };

    $.ajax({
        url: "/en/InfoList/InfoViewCount", /*设置post提交到的页面*/
        data: myparamsObject,
        type: "post",
        dataType: "text", /*设置返回值类型为文本*/
        error: function (result) {
            console.log("浏览次数统计：发生服务器程序错误\n\r code:500" + JSON.stringify(result));
        },
        success: function (result) {
            var newDate = new Date();
            console.log(newDate.toLocaleTimeString());
            console.log(result);
        }
    });
}
 
//IP query
function IpSourceAreaQuery(SourceStatisticsID, queryIP) {
    
    var myparamsObject = { "SourceStatisticsID": SourceStatisticsID, "queryIP": queryIP };

    $.ajax({
        url: "/en/Base/IpSourceAreaQuery",  
        data: myparamsObject,
        type: "get",
        dataType: "text",  
        error: function (result) {
            console.log("浏览次数统计：发生服务器程序错误\n\r code:500" + JSON.stringify(result));
        },
        success: function (result) {
            console.log(result); 
        }
    });
}

//JS Get current operating system and browser name
function getOSAndBrowser() {
    var os = navigator.platform;
    var userAgent = navigator.userAgent;
    var info_OS_Browser = "";
    if (/(iPhone|iPad|iPod|iOS)/i.test(navigator.userAgent)) {
        info_OS_Browser = "iPhone";
    } else if (/(Android)/i.test(navigator.userAgent)) {
        info_OS_Browser = "Android";
    } else {
        info_OS_Browser = "Windows";
    }
    console.log("getOSAndBrowser:" + info_OS_Browser);
    return info_OS_Browser;
}

//Page loading time  Unit as milliseconds
function PageLoadingTimesCounter(SourceStatisticsID, loadTime) {
    //cliennt version
    var OSVersion = getOSAndBrowser();
    var myparamsObject = { "SourceStatisticsID": SourceStatisticsID, "loadTime": loadTime, "OSVersion": OSVersion };

    $.ajax({
        url: "/en/Base/PageLoadingTimesCounter", 
        data: myparamsObject,
        type: "get",
        dataType: "text",  
        error: function (result) {
            console.log("error :: Page load time loadTime milliseconds: a server program error occurred\n\r code:500" + JSON.stringify(result));
        },
        success: function (result) {
            console.log("PageLoadingTimesCounter and OSVersion :" + result);
        }
    });
}
 
//UpdateUserProfileNickNameOrUserIcon    /// <param name="Mode"> 1=UserIcon ,2 = NickName</param>
function UpdateUserProfileNickNameOrUserIcon(UserId, UpdString, Mode) {

    var myparamsObject = { "UserId": UserId, "UpdString": UpdString, "Mode": Mode };

    $.ajax({
        url: "/en/Utilities/UpdateUserProfileNickNameOrUserIcon",
        data: myparamsObject,
        type: "post",
        dataType: "text",
        error: function (result) {
            console.log("UpdateUserProfileNickNameOrUserIcon error\n\r code:500 \n\r\n\r" + JSON.stringify(result));
        },
        success: function (result) {

            return result;
        }
    });
}
