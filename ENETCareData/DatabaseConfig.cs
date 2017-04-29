using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Configuration;

namespace ENETCareData
{
    public class DatabaseConfig
    {
        public string Setup(string database)
        {
            if (database.Equals("ENETCareDatabase"))
            {
                string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\ENETCareData"));
                AppDomain.CurrentDomain.SetData("DataDirectory", path);
                string connectionString = WebConfigurationManager.ConnectionStrings["ENETCareAppConnection"].ConnectionString;
                return connectionString;
            }
            else
            {
                string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\ENETCareWebForm\App_Data"));
                AppDomain.CurrentDomain.SetData("DataDirectory", path);
                string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                return connectionString;
            }
        }
    }
}
