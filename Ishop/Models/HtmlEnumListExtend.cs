using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks; 
using LanguageResource;
using System.Web.Mvc;
using Ishop.Models;
using Ishop.Context;
using static Ishop.AppCode.EnumCode.PublicEnumCode;

namespace Microsoft.AspNet.Mvc.Rendering
{
    public class EnumItem
    {
        public string Text;
        public string Value;
        public bool Selected = false;
    }
    public static class HtmlExtensions
    { 
        public static List<SelectListItem> CreateEnumSelect(List<EnumItem> list, string selectValue)
        {
            List<SelectListItem> selList = new List<SelectListItem>();
            foreach (var item in list)
            {
                selList.Add(new SelectListItem
                {
                    Text = item.Text,
                    Value = item.Value,
                    Selected = item.Value == selectValue
                });
            }
            return selList;
        }
        public static List<EnumItem> GetEnumSelectList<T>()
        {
            var enumType = typeof(T);
            List<EnumItem> selectList = new List<EnumItem>();

            foreach (var obj in Enum.GetValues(enumType))
            {
                selectList.Add(new EnumItem { Text = LanguageResource.LangUtilities.GetStringReflectKeyName(GetEnumDescription(obj)), Value = obj.ToString() }); //selectList.Add(new EnumItem { Text = GetEnumDescription(obj), Value = obj.ToString() }); //
            }
            return selectList;
        }
        /// <summary>
        /// 获取自定义属性获取的内容
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Object obj)
        {
            //获取枚举对象的枚举类型
            Type type = obj.GetType();
            //通过反射获取该枚举类型的所有属性
            FieldInfo[] fieldInfos = type.GetFields();

            foreach (FieldInfo field in fieldInfos)
            {
                //不是参数obj,就直接跳过

                if (field.Name != obj.ToString())
                {
                    continue;
                }
                //取出参数obj的自定义属性
                if (field.IsDefined(typeof(EnumDisplayNameAttribute), true))
                {
                    string dip = (field.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)[0] as EnumDisplayNameAttribute).DisplayName;
                    return dip;
                }
            }
            return obj.ToString();
        }
         
        public static string DateTimeFormate(this HtmlHelper htmlHelper, DateTime dateTime)
        {
            return String.Format(@"{0:yyyy-MM-dd HH:mm:ss}", dateTime);
        }

        public static IEnumerable<SelectListItem> InfoCateAndModeDropDownList(this HtmlHelper htmlHelper, string selectedValue)
        {
            var infoCateEnumCodes = GetEnumSelectList<InfoCateEnumCode>();  //Enum InfoCateEnumCode 是虚拟的信息分类ID

            using (ApplicationDbContext db = new Ishop.Context.ApplicationDbContext())
            {
                var infoCates = db.InfoCates.Where(c=>c.ShopID.Contains(WebCookie.ShopID)).ToList();
                foreach(var item in infoCates)
                {
                    EnumItem enumItem = new EnumItem
                    {
                        Text = item.InfoCateName,
                        Value = item.InfoCateID,
                        Selected = item.InfoCateID == selectedValue
                    };
                    infoCateEnumCodes.Add(enumItem);
                }
            }
            var SelectList_InfoCateEnumCodes = CreateEnumSelect(infoCateEnumCodes, selectedValue);
            return SelectList_InfoCateEnumCodes;
        }

        public static IEnumerable<SelectListItem> SendMailInfoCompanyDropDownList(this HtmlHelper htmlHelper, object selectedCompany = null)
        {
            string sel = "";
            if(selectedCompany != null)
            {
                sel = selectedCompany.ToString();
            }
            var HolidayPaidTypeQuery = GetEnumSelectList<SenderOfCompanyEnumCode>();
            IEnumerable<SelectListItem> selectListItems = HolidayPaidTypeQuery.Select(c => new SelectListItem() { Text = c.Text, Value = c.Value, Selected = c.Text.Contains(sel) }).ToList();
            return selectListItems;
        }

        public static IEnumerable<SelectListItem> LangEnumCodeDropDownList(this HtmlHelper htmlHelper, string selectedValue = null)
        {
            var langEnumCodes = GetEnumSelectList<LangEnumCode>();
            string sel = "";
            if(!string.IsNullOrEmpty(selectedValue))
            {
                sel = selectedValue;
            }

            IEnumerable<SelectListItem> selectListItems = langEnumCodes.Select(c => new SelectListItem() { Text = c.Text, Value = c.Value, Selected = c.Value.Contains(sel) }).ToList();
            return selectListItems;
        }

        public static IEnumerable<SelectListItem> IsInfoModeDropDownList(this HtmlHelper htmlHelper, string selectedValue)
        {
            selectedValue = selectedValue ?? string.Empty;

            var isInfoModes = GetEnumSelectList<IsInfoMode>();

            List<SelectListItem> selList = new List<SelectListItem>();
            foreach (var item in isInfoModes)
            {
                IsInfoMode itemValueOfIsInfoMode = (IsInfoMode)Enum.Parse(typeof(IsInfoMode),item.Value);
                int val = (int)itemValueOfIsInfoMode;

                selList.Add(new SelectListItem
                {
                    Text = item.Text,
                    Value = val.ToString(),//item.Value,
                    Selected = item.Value == selectedValue
                });
            }
            IEnumerable<SelectListItem> selectListIEnum = selList.AsEnumerable<SelectListItem>();

            return selectListIEnum;
             
        }

        public static IEnumerable<SelectListItem> CurrencySymbolList(this HtmlHelper htmlHelper, string selectedCurrencySymbol)
        {
            var CurrencySymbolQuery = GetEnumSelectList<CurrencySymbol>();

            if (string.IsNullOrEmpty(selectedCurrencySymbol))
            {
                IEnumerable<SelectListItem> selectListItems = CurrencySymbolQuery.Select(c => new SelectListItem() { Text = c.Text, Value = c.Value }).ToList();
                return selectListItems;
            }
            else
            {
                selectedCurrencySymbol = selectedCurrencySymbol.Replace("-", "");
                selectedCurrencySymbol = selectedCurrencySymbol.ToUpper();
                IEnumerable<SelectListItem> selectListItems = CurrencySymbolQuery.Select(c => new SelectListItem() { Text = c.Text, Value = c.Value, Selected = c.Value == selectedCurrencySymbol }).ToList();
                return selectListItems;
            }
        }
    }
}

 
