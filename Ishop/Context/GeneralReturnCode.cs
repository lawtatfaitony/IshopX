using Ishop.Models;
using System;
using System.ComponentModel;
using System.Reflection;
namespace Ishop.Context
{
    public enum GeneralReturnCode
    {  
        SUCCESS = -1,
         
        FAIL = 1,
         
        EXCEPTION = 2,
         
        UNAUTHORIED = 3,
         
        GENERALUI_PAGE_NO_ERR = 4,
         
        GENERALUI_NO_RECORD = 5,
         
        FILE_UPLOAD_SUCCESS = 6,
         
        FILE_UPLOAD_FAIL = 7,
         
        FILESIZE_IS_LIMITED = 8,
         
        LIST_NO_RECORD = 9,
         
        UNEXPECT_FILE_TYPE = 10,
         
        REQUIRED_CORRECT_PARMS_MAINCOM_ID = 11,
         
        DATABASE_SERVER_FAIL = 12

    }
    public enum StatusCode
    {
        NOT_SET = -1,
        ACTIVE = 1,
        INACTIVE = 0, 
    }

    /// <summary>
    /// 货币
    /// </summary>
    public enum CurrencySymbol
    {
        [EnumDisplayName("GeneralUI_zhCN")]
        ZHCN = 1,

        [EnumDisplayName("GeneralLogic_zhHK")]
        ZHHK = 2,

        [EnumDisplayName("GeneralLogic_enUS")]
        ENUS = 3,

        [EnumDisplayName("GeneralLogic_ruRU")]
        RURU = 4,

        [EnumDisplayName("GeneralLogic_jpJP")]
        JPJP = 5,

        [EnumDisplayName("GeneralLogic_deDE")]
        DEDE = 6,
        [EnumDisplayName("GeneralLogic_enUK")]
        ENUK = 7
    }
}
