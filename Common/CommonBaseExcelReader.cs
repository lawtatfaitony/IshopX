using System; 
using System.Collections.Generic; 
using System.Drawing; 
using System.IO;
using System.Linq;
using System.Net;
using System.Text;   
using System.Configuration; 
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using ExcelDataReader;

namespace Common
{
    public partial class CommonBase
    {
        #region   EXCEL READER

        public static DataTable ReadExcel(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);   //add this for error : NotSupportedException: No data is available for encoding 1252.  REF: https://qa.1r1g.com/sf/ask/3445105401/ and 
            //https://github.com/ExcelDataReader/ExcelDataReader#important-note-on-net-core
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            { 
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                { 
                    if(reader==null)
                    {
                        return null;
                    }
                    do { while (reader.Read()) { } } while (reader.NextResult());

                    var configuration = new ExcelDataSetConfiguration { ConfigureDataTable = tableReader => new ExcelDataTableConfiguration { UseHeaderRow = true } };
                    try
                    {
                        var result = reader.AsDataSet(configuration);

                        return result.Tables[0];
                    }
                    catch
                    {
                        return null;
                    }
                   
                }
                
            }
        }
        #endregion  EXCEL READER 
        //--------------------------------------------------------------------------------------
         
    }
}
