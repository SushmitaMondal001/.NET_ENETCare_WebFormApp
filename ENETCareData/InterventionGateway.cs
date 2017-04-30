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

        public int AddNewIntervention(int interventionTypeID, int clientID, float labourRequired, float costRequired, int userID, string interventionDate, string interventionState)
        {
            int result = 0;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "INSERT INTO Intervention(InterventionTypeID, ClientID, LabourRequired, CostRequired, UserID, InterventionDate, InterventionState) VALUES(@InterventionTypeID, @ClientID, @LabourRequired,@CostRequired, @UserID, @InterventionDate, @InterventionState)";

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

        public List<Intervention> GetInterventionListByClient(int clientID)
        {
            List<Intervention> anInterventionList = new List<Intervention>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM Intervention WHERE ClientID=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("id", clientID));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Intervention anIntertervention = new Intervention();
                        anIntertervention.InterventionID = Int32.Parse(reader["InterventionID"].ToString());
                        anIntertervention.InterventionTypeID = Int32.Parse(reader["InterventionTypeID"].ToString());
                        anIntertervention.InterventionState = reader["InterventionState"].ToString();
                        anInterventionList.Add(anIntertervention);
                    }
                }
                catch { }
            }
            return anInterventionList;
        }

        public List<Intervention> GetInterventionListByUserID(int userID)
        {
            List<Intervention> anInterventionList = new List<Intervention>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM [Intervention] WHERE UserID=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("id", userID));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Intervention anIntervention = new Intervention();
                        anIntervention.InterventionID = Int32.Parse(reader["InterventionID"].ToString());
                        anIntervention.InterventionTypeID = Int32.Parse(reader["InterventionTypeID"].ToString());
                        anIntervention.ClientID = Int32.Parse(reader["ClientID"].ToString());
                        anIntervention.InterventionState = reader["InterventionState"].ToString();
                        anInterventionList.Add(anIntervention);
                    }
                }
                catch { }
            }
            return anInterventionList;
        }

        public int ChangeInterventionStatusByID(int interventionID)
        {
            return 0;
        }
        
    }
}
