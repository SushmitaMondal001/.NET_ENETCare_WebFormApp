using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ENETCareData
{
    public class DatabaseConfig
    {
        public string Setup()
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\ENETCareData"));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            string connectionString = WebConfigurationManager.ConnectionStrings["ENETCareAppConnection"].ConnectionString;
            return connectionString;
        }
    }
}
