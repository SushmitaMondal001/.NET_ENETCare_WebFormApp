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
                        Intervention anIntervention = new Intervention();
                        anIntervention.InterventionID = Int32.Parse(reader["InterventionID"].ToString());
                        anIntervention.InterventionTypeID = Int32.Parse(reader["InterventionTypeID"].ToString());
                        anIntervention.InterventionState = reader["InterventionState"].ToString();
                        anInterventionList.Add(anIntervention);
                    }
                }
                catch { }
            }
            return anInterventionList;
        }

        public Intervention GetInterventionListByInterventionID(int interventionID)
        {
            Intervention anIntervention = new Intervention();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "SELECT * FROM Intervention WHERE interventionID=@id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("id", interventionID));
                
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        anIntervention.InterventionID = Int32.Parse(reader["InterventionID"].ToString());
                        anIntervention.InterventionTypeID = Int32.Parse(reader["InterventionTypeID"].ToString());
                        anIntervention.InterventionState = reader["InterventionState"].ToString();
                        anIntervention.ClientID = Int32.Parse(reader["ClientID"].ToString());
                        anIntervention.LabourRequired = float.Parse(reader["LabourRequired"].ToString());
                        anIntervention.CostRequired = float.Parse(reader["CostRequired"].ToString());
                        anIntervention.UserID = Int32.Parse(reader["UserID"].ToString());
                        anIntervention.InterventionDate = reader["InterventionDate"].ToString();
                        //anIntervention.ApprovalUserID = Int32.Parse(reader["ApprovalUserID"].ToString());
                        anIntervention.Notes = reader["Notes"] as string ;
                        if (reader["RemainingLife"] != DBNull.Value)
                            anIntervention.RemainingLife = Int32.Parse(reader["RemainingLife"].ToString());
                        else
                            anIntervention.RemainingLife = null;
                        if (reader["LatestVisitDate"] != DBNull.Value)
                            anIntervention.LastEditDate = reader["LatestVisitDate"].ToString();
                        else
                            anIntervention.LastEditDate = reader["InterventionDate"].ToString();
                    }
                }
                catch { }
            }
            return anIntervention;
        }

        public int UpdateIntervention(int interventionID, string lastEditDate, string notes, int remainingLife)
        {
            int result = 0;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "UPDATE Intervention SET RemainingLife = @remainingLife, LatestVisitDate = @latestVisitDate, Notes = @notes WHERE InterventionID = @interventionID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("remainingLife", remainingLife));
                command.Parameters.Add(new SqlParameter("latestVisitDate", lastEditDate));
                command.Parameters.Add(new SqlParameter("notes", notes));
                command.Parameters.Add(new SqlParameter("interventionID", interventionID));

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
