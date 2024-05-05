using Ishop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ishop.AppCode.EnumCode
{
    public class PublicEnumCode
    {
        public enum IsInfoMode
        {
             
            /// <summary>
            /// 保险模式的INDEX索引页
            /// </summary>
            INSURANCE = 0,
            /// <summary>
            /// 安防行业模式
            /// </summary>
            SECURITY = 1,

            /// <summary>
            /// 音響廣播工程行业模式
            /// </summary>
            RADIOENGINEER = 1

        }
    }
}