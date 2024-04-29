using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Ishop.DAL
{
    public class IshopConfiguration : DbConfiguration
    {
        //ADO.NET的弹性连接控制[ADO.NET idle connection resiliency]
        public IshopConfiguration()
        {
           //SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());  
        }
    }
}