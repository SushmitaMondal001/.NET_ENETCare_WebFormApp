using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCareModels;
using System.Data.SqlClient;

namespace ENETCareData
{
    public class DistrictGateway
    {
        string connectionString = "";
        DatabaseConfig aDatabaseConfig = new DatabaseConfig();

        public List<District> GetDistrictList()
        {
            List<District> aDistrictList = new List<District>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM District";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        District aDistrict = new District();
                        aDistrict.DistrictID = Int32.Parse(reader["DistrictID"].ToString());
                        aDistrict.DistrictName = reader["DistrictName"].ToString();
                        aDistrictList.Add(aDistrict);
                    }
                    //connection.Close();
                }
                catch
                {

                }
            }
            return aDistrictList;
        }

        public string GetDistrictName(int districtID)
        {
            string districtName = "";
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM District WHERE DistrictID=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("id", districtID));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        districtName = reader["DistrictName"].ToString();
                    }
                }
                catch
                {

                }
            }
            return districtName;
        }
    }
}
