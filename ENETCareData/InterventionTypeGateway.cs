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


        /// <summary>
        /// Get all the lists from InterventionType table
        /// </summary>
        /// <returns></returns>
        public List<InterventionType> GetInterventionTypeList()
        {
            List<InterventionType> aInterventionTypeList = new List<InterventionType>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
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


        /// <summary>
        /// Fetch the InterventionTypeId from database according to param InterventionTypeName
        /// </summary>
        /// <param name="interventionTypeName"></param>
        /// <returns></returns>
        public int GetInterventionTypeIdByName(string interventionTypeName)
        {
            int interventionTypeID = 0;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
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


        /// <summary>
        /// Get default value of labour for a specific intervention
        /// </summary>
        /// <param name="interventionTypeID"></param>
        /// <returns></returns>
        public string GetEstLabourByIntTypeID(int interventionTypeID)
        {
            string estimatedLabour = "";
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT EstimatedLabour FROM [Intervention Type] WHERE InterventionTypeID=@interventionTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("interventionTypeID", interventionTypeID));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        estimatedLabour = reader["EstimatedLabour"].ToString();
                    }
                }
                catch
                {

                }
            }
            return estimatedLabour;
        }


        /// <summary>
        /// Get default cost for a specific intervention
        /// </summary>
        /// <param name="interventionTypeID"></param>
        /// <returns></returns>
        public string GetEstCostByIntTypeID(int interventionTypeID)
        {
            string estimatedCost = "";
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT EstimatedCost FROM [Intervention Type] WHERE InterventionTypeID=@interventionTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("interventionTypeID", interventionTypeID));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        estimatedCost = reader["EstimatedCost"].ToString();
                    }
                }
                catch
                {

                }
            }
            return estimatedCost;
        }

        /// <summary>
        /// Get the name of the intervention bythe id of that intervention
        /// </summary>
        /// <param name="interventionTypeID"></param>
        /// <returns></returns>
        public string GetInterventionNameByTypeId(int interventionTypeID)
        {
            string interventionName = "";
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [Intervention Type] WHERE InterventionTypeID=@interventionTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("interventionTypeID", interventionTypeID));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        interventionName = reader["InterventionTypeName"].ToString();
                    }
                }
                catch
                {

                }
            }
            return interventionName;
        }

       

    }
}
