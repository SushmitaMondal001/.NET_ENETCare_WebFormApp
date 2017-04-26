using ENETCareModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareData
{
    public class ClientGateway
    {
        string connectionString = "";
        DatabaseConfig aDatabaseConfig = new DatabaseConfig();

        public int AddNewClient(string clientName, string address, int districtID)
        {
            int result = 0;
            Client aClient = new Client();
            connectionString = aDatabaseConfig.Setup();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "INSERT INTO Client(ClientName, ClientAddress, DistrictID) VALUES(@ClientName, @ClientAddress, @DistrictID)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("ClientName",clientName));
                command.Parameters.Add(new SqlParameter("ClientAddress", address));
                command.Parameters.Add(new SqlParameter("DistrictID", districtID));

                try
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                    
                    //connection.Close();
                }
                catch
                {

                }
                return result;
            }
        }
    }
}
