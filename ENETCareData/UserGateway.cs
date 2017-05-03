using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCareModels;
using System.Data;

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
        
        public List<User> GetUserListByUserType(string userType)
        {
            List<User> aUserList = new List<User>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [User] WHERE UserType=@userType";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("userType", userType));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User anUser = new User();
                        anUser.UserID = Int32.Parse(reader["UserID"].ToString());
                        anUser.UserName = reader["UserName"].ToString();
                        anUser.DistrictID = Int32.Parse(reader["DistrictID"].ToString());
                        aUserList.Add(anUser);
                    }
                }
                catch
                {

                }
            }
            return aUserList;
        }

        public int UpdateUserDistrict(int userID, int districtID)
        {
            int result = 0;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "UPDATE [User] SET DistrictID = @districtID WHERE UserID = @userID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("districtID", districtID));
                command.Parameters.Add(new SqlParameter("userID", userID));

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
    }
}
