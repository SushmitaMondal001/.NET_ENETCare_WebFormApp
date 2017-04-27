using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ENETCareModels;

namespace ENETCareData
{
    public class InterventionGateway
    {
        string connectionString = "";
        DatabaseConfig aDatabaseConfig = new DatabaseConfig();

        public int AddNewIntervention(int interventionTypeID, int clientID, double labourRequired, double costRequired, int userID, string interventionDate, string interventionState)
        {
            int result = 0;
            connectionString = aDatabaseConfig.Setup();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "INSERT INTO Intervention(InterventionTypeID, ClientID, LabourRequired, CostRequired, UserID, InterventionDate, InterventionState) " +
                                                 "VALUES(@InterventionTypeID, @ClientID, @LabourRequired,@CostRequired, @UserID, @InterventionDate, @InterventionState)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("InterventionTypeID", interventionTypeID));
                command.Parameters.Add(new SqlParameter("ClientID", clientID));
                command.Parameters.Add(new SqlParameter("LabourRequired", labourRequired));
                command.Parameters.Add(new SqlParameter("CostRequired", costRequired));
                command.Parameters.Add(new SqlParameter("UserID", userID));
                command.Parameters.Add(new SqlParameter("InterventionDate", interventionDate));
                command.Parameters.Add(new SqlParameter("InterventionState", interventionState));

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
