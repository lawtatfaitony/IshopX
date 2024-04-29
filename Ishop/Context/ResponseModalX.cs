using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Ishop.Context
{  
    public partial class ResponseModalX
    {
        public ResponseModalX()
        {
            _meta = new MetaModalX { Success = true, Message = "OK", ErrorCode = (int)GeneralReturnCode.SUCCESS };
            _data = null;
        }
        private MetaModalX _meta;
        [JsonProperty("meta")]
        public MetaModalX meta
        {
            get
            {
                return _meta;
            }
            set
            {
                _meta = value;
            }
        }
        private Object _data;
        [JsonProperty("data")]
        public Object data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public static implicit operator Task<object>(ResponseModalX v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// R代表目标实体   T代表数据源实体
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static R Mapping<R, T>(T model)
        {
            R result = Activator.CreateInstance<R>();
            foreach (PropertyInfo info in typeof(R).GetProperties())
            {
                PropertyInfo pro = typeof(T).GetProperty(info.Name);
                if (pro != null)
                    info.SetValue(result, pro.GetValue(model));
            }
            return result;
        }
    }
    public partial class MetaModalX
    {
        [JsonProperty("success")]
        public bool Success { get; set; } = true;

        [JsonProperty("message")]
        public string Message { get; set; } = "OK";

        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; } = (int)GeneralReturnCode.SUCCESS;
    } 
}
