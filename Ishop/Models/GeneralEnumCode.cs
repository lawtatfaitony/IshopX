﻿using System;
using System.ComponentModel;
using System.Reflection;
using Ishop.Utilities;
namespace Ishop.Models
{
    public class EnumDisplayNameAttribute : Attribute
    {
        public EnumDisplayNameAttribute(string displayName)
        {
            _diaplayName = displayName; // _diaplayName = LangUtilities.GetStringReflectKeyName(displayName);
        }
        private string _diaplayName;
        public string DisplayName
        {
            get
            {
                return _diaplayName;
            }
        }
    }

    public enum InfoCateEnumCode
    { 
        [EnumDisplayName("INFOCATE_TOP_HEADER")] //HelperList 中排除 
        TOP_HEADER = 9001,

        [EnumDisplayName("INFOCATE_SOFTWARE_HELPER")] //HelperList 包含
        SOFTWARE_HELPER = 9002,

        [EnumDisplayName("INFOCATE_HOME_PAGE_MIDDLE_AD")] //HelperList 中排除
        HOME_PAGE_MIDDLE_AD = 9003,

        [EnumDisplayName("INFOCATE_HELPER_INDEX")] //HelperList 中排除 
        HELP_FIRST = 9004,

        [EnumDisplayName("INFOCATE_HELPER_FUNCTUON")] //功能帮助 //HelperList 包含
        HELP_FUNCTUON = 9005,

        [EnumDisplayName("INFOCATE_COMMON_INFO")] //通用资讯类
        INFOCATE_COMMON_INFO = 9006
    }

    public enum SenderOfCompanyEnumCode
    {
        [EnumDisplayName("SendMailInfo_SenderOfCompany_GOOGLE")]
        SMTPGOOGLE = 1,

        [EnumDisplayName("SendMailInfo_SenderOfCompany_QQ")]
        SMTPQQ = 2,

        [EnumDisplayName("SendMailInfo_SenderOfCompany_163")]
        SMTP163 = 3,

        [EnumDisplayName("SendMailInfo_SenderOfCompany_126")]
        SMTP126 = 4
    }
    public enum LangEnumCode
    {
        [EnumDisplayName("Language_NOSET")] //无设置
        NO_SET = -1,

        [EnumDisplayName("Language_zh_CN")] //简体 
        CN = 0,

        [EnumDisplayName("Language_zh_HK")] //繁体
        HK = 1,

        [EnumDisplayName("Language_en")] //英语
        US = 2
    }
}