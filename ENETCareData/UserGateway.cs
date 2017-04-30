using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareData
{
    public class UserGateway
    {
        string connectionString = "";
        DatabaseConfig aDatabaseConfig = new DatabaseConfig();
        public int GetUserDistrictID(string loginName)
        {
            int districtID = 0;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [User] WHERE LoginName=@name";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("name", loginName));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        districtID = Int32.Parse(reader["DistrictID"].ToString());
                    }
                }
                catch
                {

                }
            }
            return districtID;
        }

        public int GetUserIdByName(string loginName)
        {
            int userID = 0;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [User] WHERE LoginName=@name";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("name", loginName));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userID = Int32.Parse(reader["UserID"].ToString());
                    }
                }
                catch
                {

                }
            }
            return userID;
        }

        public string GetUserNameByUserID(int userID)
        {
            string userName = "";
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [User] WHERE userID=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("id", userID));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userName = reader["UserName"].ToString();
                    }
                }
                catch
                {

                }
            }
            return userName;
        }

        public float GetMaxHourByUserID(int userID)
        {
            float maxHour = 0;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [User] WHERE userID=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("id", userID));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maxHour = float.Parse(reader["MaxHour"].ToString());
                    }
                }
                catch
                {

                }
            }
            return maxHour;
        }

        public float GetMaxCostByUserID(int userID)
        {
            float maxCost = 0;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [User] WHERE userID=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("id", userID));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maxCost = float.Parse(reader["MaxCost"].ToString());
                    }
                }
                catch
                {

                }
            }
            return maxCost;
        }
    }
}
