# 開發日誌

**IshopX --- At the Heart of your Ecosystem!**

## 框架:

使用 .NET Framework 4.8 ，C# 語言的版本通常是 C# 7.3。

------

立项时间：2021年10月21日

ISHOP新版开发—2021年12月21日阶段性开发完毕.MD

ISHOP新版开发—2024年4月25日阶段性开发完毕.MD

## 店鋪模版須知

如果沒有對應的店鋪模版,則導致相應店鋪的嚴重錯誤.例如:

Shared\ShopFootTemplate\sh0006_FooterTemplate.cshtml

Shared\ShopFootTemplate\SH2028_FooterTemplate.cshtml

Shared\ShopViewTemplate1\sh0006_zh-HK.cshtml

類似這樣格式的,在Shared文件夾下的,需以此規則排查

## 增加TemplateC/IndexC

 RadioEngin [TemplateC] 主要的模版文件在 Shared/TemplateC

共有三個模版,由 Shop.InfoMode控制, 更改-> ShopUdate->InfoMode

1.  IndexA.cshtml 模版  Shared/TemplateA
2.  IndexB.cshtml 模版  Shared/TemplateB
3.  IndexC.cshtml 模版  Shared/TemplateC

## 增加HEADER模版

```
模版文件在 Shared/ShopHeaderTemplate 使各個店鋪自己風格定義HEADER
ShopHeaderTemplate/sh0001_LayOutHeader.en-US.cshtml
ShopHeaderTemplate/sh0001_LayOutHeader.zh-CN.cshtml
ShopHeaderTemplate/sh0001_LayOutHeader.zh-HK.cshtml
```

## 銀行與WhatsApp(Wechat) 信息

此模版位於 infodetails頁面和P 產品明細頁面

<img src="README_IMGs/bankaccount.jpg" alt="bankaccount" style="zoom:50%;" />

Shared\Info\ViewIsInfoMode.cshtml 控制傳入Shop對象 

相應的模版

```
Shared\ShopViewTemplate1\sh0006_en-US.cshtml
Shared\ShopViewTemplate1\sh0006_zh-CN.cshtml
Shared\ShopViewTemplate1\sh0006_zh-HK.cshtml
其他店鋪相應更改ShopId
```



## 主頁的AI-BOX 的專題廣告

2024-4-25 增加AI-BOX 的主頁的專題廣告以及產品功能說明,繁簡英三個版本

```
Shared/TemplateB/SoftwareMainFuncAiBoxENUS.cshtml
Shared/TemplateB/SoftwareMainFuncAiBoxENUS.cshtml
Shared/TemplateB/SoftwareMainFuncAiBoxENUS.cshtml
Shared/TemplateB/AdMainAiBox.en-US.cshtml
Shared/TemplateB/AdMainAiBox.zh-CN.cshtml
Shared/TemplateB/AdMainAiBox.zh-HK.cshtml
/Content/Images/AdMainAiBox_SloganP1.png(jpg)
/upload/AIBOX/OrangePIdemo_ Crop0409.mp4
```

## 主頁參數

Index(string id,string InfoCateID ,string Index2,string code,string state)

參考:



## 計劃GOOGLE/BAIDU/FB 廣告頁面

增加一個靜態html廣告頁面,專門FOR GOOGLE/BAIDU/FB 廣告頁面

## 店鋪ID的規則

默認店鋪在 /Context/WebSiteCookie.cs  line : 348
規則 如果從uri請求在數據庫無法查詢到對應的域名 則使用默認值 ShopId ="sh0006"

**測試的店鋪和對應的ID** 

```
C:\Windows\System32\drivers\etc\host 系統文件,配置域名和 IP 地址的映射
127.0.0.1 sunwaylink.com 		# sh0001 login Id:Supervisor@xyz.com 
127.0.0.1 xguard.cn 			# sh0006 login Id:joyercomcn@qq.com
127.0.0.1 dataguardxcore.com 	# sh0016 not exist
127.0.0.1 dataguard.com 		# SH2028 no download login Id:lawtatfaitony@gmail.com
127.0.0.1 starbilliant.cn 		# SH2028 login Id:lawtatfaitony@gmail.com			
```

 

## 目前的店鋪

| sh0001 | 三个小情人的爸爸           | /Upload/ShopLogo/Shplogo_20171101063317284.png |
| ------ | -------------------------- | ---------------------------------------------- |
| sh0006 | 翔輝計算機系統             | /Upload/ShopLogo/Shplogo_20180826132306638.png |
| SH2006 | HK安防  LTD.               | /Upload/ShopLogo/Shplogo_20180826132306638.png |
| SH2028 | STAT BILLIANT AI TECH LTD. | /Upload/ShopLogo/Shplogo_20180826132306638.png |

```
sh0006  翔輝系統
考勤薪酬、安防业务：
http://81.71.74.135:8081/?ShpID=sh0006 
sh0016 
http://81.71.74.135:8081/?ShpID=sh0016
薪酬与考勤系统 、安防业务： starbilliant.cn
SH2028
http://81.71.74.135:8081/?ShpID=SH2028
安防业务 dataguard.com
上述以 [/?ShpID=sh0016]傳入,已經作廢,由於受到規則 WebCookie.ShpID 通過HostName判斷店鋪ID,導致 ID傳入主頁有用,其餘都作廢了.
```

 **For 音響工程**

Template C Sample : 

1. https://www.mxcamera.com/  參考
2. https://shop.hivihk.com/products/jbl-mk08-karaoke-speaker 這個比較複雜大型

++++++++++++++++++++++++++++++++++++++++++++

Update in 2024-4-28

## 丟失引用文件/shop/bin 

導致編譯不通過的情況是由於

 從這裡複製 Ishop\backup_dll_annotationExtensions_and_clientvalid

 不再引用項目,太久遠,保留源碼獨立輸出

1.  DataAnnotationsExtensions.dll
2.  DataAnnotationsExtensions.ClientValidation.dll

## SMS發送

由於個別平台限制上存敏感資料.accesskey 等保存在Web.config

文件 App_Start\IdentityConfig.cs  如何获得accesskey  ：https://ak-console.aliyun.com/#/accesskey
line 112 : IClientProfile profile = DefaultProfile.GetProfile("xxx", "xxx", "xxx");  //裡面的參數值xxx是虛假的



![rendersuccess_2024_4_29](README_IMGs/rendersuccess_2024_4_29.jpg

## 如何表達店鋪貨幣:

```
@mvcCommeBase.GetShopPriceByShopCurrency(string.Format("{0:f1}", Model.TradePrice), (string)ViewBag.ShopCurrency)  
// ViewBag.ShopCurrency 由初始化函數 From: BaseController.ShopInitialize()
```

## 郵件系統:

默認標準端口如:

![Mail126Port](README_IMGs/Mail126Port.jpg)

​				    這個只是一個標準而普遍使用的端口.

## 設置允許第三方 cookie

在 C# .NET 中，要設置允許第三方 cookie，可以通過在 HTTP 響應標頭中添加 `SameSite=None; Secure` 來實現。這樣可以告訴瀏覽器允許第三方 cookie。

以下是一個示例代碼：

```csharp
Response.Cookies.Append("cookieName", "cookieValue", new CookieOptions
{
    Secure = true,
    SameSite = SameSiteMode.None
});
```

通過上面的代碼，你可以在 C# .NET 中設置一個允許第三方 cookie 的 cookie。請確保在使用這個功能時遵循相關的安全最佳實踐。

## 訂單與購物車功能須知:

必須先增加SKU才能選擇交易屬性實現加入購物車功能,如果無法創建SKU,那肯定是類目,屬性,屬性值沒有設置導致的.必須按流程 : 類目,屬性,屬性 > 產品 > SKU > 購物車 > 訂單 > 發貨單 > 支付
