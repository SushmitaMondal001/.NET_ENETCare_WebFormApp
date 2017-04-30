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
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "INSERT INTO Client(ClientName, ClientAddress, DistrictID) VALUES(@ClientName, @ClientAddress, @DistrictID)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("ClientName", clientName));
                command.Parameters.Add(new SqlParameter("ClientAddress", address));
                command.Parameters.Add(new SqlParameter("DistrictID", districtID));

                try
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch
                {

                }
                return result;
            }
        }

        public List<Client> GetClientListByDistrict(int districtID)
        {
            List<Client> aClientList = new List<Client>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM Client WHERE DistrictID=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("id", districtID));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Client aClient = new Client();
                        aClient.ClientID = Int32.Parse(reader["ClientID"].ToString());
                        aClient.ClientName = reader["ClientName"].ToString();
                        aClient.Address = reader["ClientAddress"].ToString();
                        aClientList.Add(aClient);
                    }
                }
                catch { }
            }
            return aClientList;
        }

        public List<Client> GetClientList()
        {
            List<Client> aClientList = new List<Client>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT ClientID, ClientName FROM [Client]";

                SqlCommand command = new SqlCommand(query, connection);
                // command.Parameters.Add(new SqlParameter("id", districtID));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Client aClient = new Client();
                        aClient.ClientID = Int32.Parse(reader["ClientID"].ToString());
                        aClient.ClientName = reader["ClientName"].ToString();
                        //aClient.Address = reader["ClientAddress"].ToString();
                        aClientList.Add(aClient);
                    }
                }
                catch { }
            }
            return aClientList;
        }


        // Check whether the username is unique
        public bool IsUserNameExist(string clientName)
        {
            bool isExist = false;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM Client WHERE ClientName=@clientName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("clientName", clientName));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        isExist = true;
                    }
                }
                catch { }
            }
            return isExist;
        }

        public string GetClientNameByID(int clientID)
        {
            string clientName = "";
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [Client] WHERE ClientID=@clientID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("clientID", clientID));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        clientName = reader["ClientName"].ToString();
                    }
                }
                catch
                {

                }
            }
            return clientName;
        }

    }
}
