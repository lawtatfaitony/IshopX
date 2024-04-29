# 開發日誌

立项时间：2021年10月21日

ISHOP新版开发—2021年12月21日阶段性开发完毕.MD

ISHOP新版开发—2024年4月25日阶段性开发完毕.MD

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



## 計劃GOOGLE/BAIDU/FB 廣告頁面

增加一個靜態html廣告頁面,專門FOR GOOGLE/BAIDU/FB 廣告頁面

## 店鋪ID的規則

默認店鋪在 /Context/WebSiteCookie.cs  line : 348
規則 如果從uri請求在數據庫無法查詢到對應的域名 則使用默認值 ShopId ="sh0006"

## 目前的店鋪

| sh0001 | 三个小情人的爸爸           | /Upload/ShopLogo/Shplogo_20171101063317284.png |
| ------ | -------------------------- | ---------------------------------------------- |
| sh0006 | 翔輝計算機系統             | /Upload/ShopLogo/Shplogo_20180826132306638.png |
| SH2006 | HK安防  LTD.               | /Upload/ShopLogo/Shplogo_20180826132306638.png |
| SH2028 | STAT BILLIANT AI TECH LTD. | /Upload/ShopLogo/Shplogo_20180826132306638.png |

Update in 2024-4-28

## 丟失引用文件/shop/bin 

導致編譯不通過的情況是由於

 從這裡複製 Ishop\backup_dll_annotationExtensions_and_clientvalid

 不再引用項目,太久遠,保留源碼獨立輸出

1.  DataAnnotationsExtensions.dll
2.  DataAnnotationsExtensions.ClientValidation.dll

## github限制

文件 App_Start\IdentityConfig.cs

//由於github限制 不能直接寫 三個參數 cn-hangzhou=====", "LTAIZtZo=====jbLbxadL========", "BWvGVZRo88cKoK===========QAu71RFusXNNsAM5"
line 112 : IClientProfile profile = DefaultProfile.GetProfile("xxx", "xxx", "xxx");  //裡面的參數值xxx是虛假的

![rendersuccess_2024_4_29](README_IMGs\rendersuccess_2024_4_29.jpg)

最後生成記錄 2024-4-29