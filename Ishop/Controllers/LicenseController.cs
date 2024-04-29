using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ishop.Context;
using Ishop.Utilities;
using Ishop.Models.ProductMgr;
using Ishop.Models.Info;
using Ishop.Models.PubDataModal;
using System.Data.Entity.Infrastructure;
using Ishop.AppCode.Utilities;
using Ishop.Areas.Mgr.Models;
using LanguageResource;
using System.Text.RegularExpressions;
using System.Configuration;
using Encryption;
using System.IO;
using Newtonsoft.Json;

namespace Ishop.Controllers
{
    public class LicenseController : BaseController
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        public LicenseController() : base()
        {
        }
        /// <summary>
        /// 获取证书 Author Key
        /// </summary>
        /// <param name="c">CPU SERIAL</param>
        /// <param name="id">id是 c的md5</param>
        /// <returns></returns>
        [HttpGet]
        //[Route("{Language}/[controller]/[action]/{c}/{id}")]
        public FileResult Index(string c, string id)
        {
            string CpuSerialNo = c;

            //校验c和Id 是否一致
            string cmd5 = CommonBase.md5Encode(CpuSerialNo);
            if(id!=cmd5)
            {
                //校验结果,数据不一致 id是 c的md5
                ResponseModalX responseModalX = new ResponseModalX
                {
                    meta = new MetaModalX { ErrorCode = (int)GeneralReturnCode.FAIL, Success = false, Message = "c & Id params Inconsistent" },
                    data = null
                };
                string InconsistentData = JsonConvert.SerializeObject(responseModalX);
                return new FileStreamResult(CommonBase.GetMemoryStream(InconsistentData), "application/json");
            }

            string inputFunctionList = ""; 
            string functionsListFile = Path.Combine(Path.GetFullPath("./"), "FunctionsList.txt");
           
            bool bFunctionsListFile = System.IO.File.Exists(functionsListFile);

            if (bFunctionsListFile)
            {
                
                using (StreamReader reader = new StreamReader(functionsListFile))
                {
                    while (!reader.EndOfStream)
                    {
                        string line1 = reader.ReadLine();
                        if (!line1.StartsWith("#") && line1.Length > 0)
                        {
                            inputFunctionList += line1;
                        }
                    }
                    reader.Close();
                } 
            }
            else
            {
                inputFunctionList = "SALARY_FINANCE:1;ATTENDANCE:1;DEVICE:50;EMPLOYEE:300"; //default
            }
            DateTime dtNow = DateTime.Now.AddYears(3);
            long ExpireDateL = Encryption.DateTimePubBusiness.ConvertDateTimeToLong(dtNow);
            string SigndataCpuSerialNo = EncryptionRSA.RsaSign(CpuSerialNo);
            string VerifyHmac = EncryptionRSA.HMACSHA1Encode(SigndataCpuSerialNo);
            string EncryptExpireData = EncryptionRSA.RsaEncryptWithPublic(ExpireDateL.ToString());
            string FunctionsList = EncryptionRSA.RsaEncryptWithPublic(inputFunctionList);

            AppAuth appAuth = new AppAuth { AppAuthKey = SigndataCpuSerialNo, VerifyHmac = VerifyHmac, ExAuth = EncryptExpireData, FuncList = FunctionsList };

            string appAuthData = JsonConvert.SerializeObject(appAuth);
            appAuthData = CommonBase.StringToBase64(appAuthData);

            string FileName = string.Format("{0}.key",c);

            string AppLicenseFolder = "License";
            string appKeyPathFileName = Path.Combine(AppContext.BaseDirectory, AppLicenseFolder, FileName);
            mvcCommeBase.SaveDataJson(appAuthData, appKeyPathFileName);
            return new FileStreamResult(CommonBase.GetMemoryStream(appAuthData), "application/json");
        }
        
    }
}