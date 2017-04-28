using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCareModels;
using System.Data.SqlClient;


namespace ENETCareData
{
    public class InterventionTypeGateway
    {
        string connectionString = "";
        DatabaseConfig aDatabaseConfig = new DatabaseConfig();


        public List<InterventionType> GetInterventionTypeList()
        {
            List<InterventionType> aInterventionTypeList = new List<InterventionType>();
            connectionString = aDatabaseConfig.Setup();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [Intervention Type]";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        InterventionType aInterventionType = new InterventionType();
                        aInterventionType.InterventionTypeID = Int32.Parse(reader["InterventionTypeID"].ToString());
                        aInterventionType.InterventionTypeName = reader["InterventionTypeName"].ToString();
                        aInterventionType.EstimatedLabour = double.Parse(reader["EstimatedLabour"].ToString());
                        aInterventionType.EstimatedCost = double.Parse(reader["EstimatedCost"].ToString());
                        aInterventionTypeList.Add(aInterventionType);
                    }
                }
                catch { }
            }
            return aInterventionTypeList;

        }

        public int GetInterventionTypeIdByName(string interventionTypeName)
        {
            int interventionTypeID = 0;
            connectionString = aDatabaseConfig.Setup();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [Intervention Type] WHERE InterventionTypeName=@interventionTypeName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("interventionTypeName", interventionTypeName));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        interventionTypeID = Int32.Parse(reader["InterventionTypeID"].ToString());
                    }
                }
                catch
                {

                }
            }
            return interventionTypeID;
        }
    }
}
