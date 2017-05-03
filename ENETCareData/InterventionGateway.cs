using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.SqlClient;
using ENETCareModels;

namespace ENETCareData
{
    public class InterventionGateway
    {
        string connectionString = "";
        DatabaseConfig aDatabaseConfig = new DatabaseConfig();
        UserGateway aUserGateway = new UserGateway();


        /// <summary>
        /// Add new intervention in the database with the param valus
        /// </summary>
        /// <param name="interventionTypeID"></param>
        /// <param name="clientID"></param>
        /// <param name="labourRequired"></param>
        /// <param name="costRequired"></param>
        /// <param name="userID"></param>
        /// <param name="interventionDate"></param>
        /// <param name="interventionState"></param>
        /// <returns>Success indicator as integer</returns>
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


        /// <summary>
        /// Fetch the list of interventions for a specific client
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public List<Intervention> GetInterventionListByClient(int clientID)
        {
            DateTime dateValue;
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
                        anIntervention.CostRequired = float.Parse(reader["CostRequired"].ToString());
                        anIntervention.LabourRequired = float.Parse(reader["LabourRequired"].ToString());
                        //anIntervention.InterventionDate = reader["InterventionDate"].ToString();
                        bool date = DateTime.TryParse(reader["InterventionDate"].ToString(), System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue);
                        string interventionDate = dateValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        anIntervention.InterventionDate = interventionDate;
                        anInterventionList.Add(anIntervention);
                    }
                }
                catch { }
            }
            return anInterventionList;
        }


        /// <summary>
        /// Get the list of interventions created by a specific SiteEngineer (User)
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Intervention> GetInterventionListByUserID(int userID)
        {
            DateTime dateValue;
            List<Intervention> anInterventionList = new List<Intervention>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                string query = "SELECT * FROM [Intervention] WHERE UserID=@id AND (InterventionState = 'Approved' OR InterventionState = 'Completed')";

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
                        bool date = DateTime.TryParse(reader["InterventionDate"].ToString(), System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue);
                        string interventionDate = dateValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        anIntervention.InterventionDate = interventionDate;
                        anIntervention.ClientID = Int32.Parse(reader["ClientID"].ToString());
                        anIntervention.InterventionState = reader["InterventionState"].ToString();
                        anInterventionList.Add(anIntervention);
                    }
                }
                catch { }
            }
            return anInterventionList;
        }


        /// <summary>
        /// Fetch details of an intervention by the intervention ID
        /// </summary>
        /// <param name="interventionID"></param>
        /// <returns></returns>
        public Intervention GetInterventionListByInterventionID(int interventionID)
        {
            DateTime dateValue;
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
                        //anIntervention.InterventionDate = reader["InterventionDate"].ToString();
                        //anIntervention.ApprovalUserID = Int32.Parse(reader["ApprovalUserID"].ToString());
                        bool date = DateTime.TryParse(reader["InterventionDate"].ToString(), System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue);
                        string interventionDate = dateValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        anIntervention.InterventionDate = interventionDate;
                        anIntervention.Notes = reader["Notes"] as string ;

                        if (reader["RemainingLife"] != DBNull.Value)
                            anIntervention.RemainingLife = Int32.Parse(reader["RemainingLife"].ToString());
                        else
                            anIntervention.RemainingLife = null;
                        if (reader["LatestVisitDate"] != DBNull.Value)
                        {
                            date = DateTime.TryParse(reader["LatestVisitDate"].ToString(), System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue);
                            interventionDate = dateValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            anIntervention.LastEditDate = interventionDate;
                            //anIntervention.LastEditDate = reader["LatestVisitDate"].ToString();
                        }
                        else
                            anIntervention.LastEditDate = anIntervention.InterventionDate;
                    }
                }
                catch { }
            }
            return anIntervention;
        }


        /// <summary>
        /// Update the intervention status for proposed intervention to a manager
        /// </summary>
        /// <param name="interventionID"></param>
        /// <param name="status"></param>
        /// <param name="approvalUserID"></param>
        /// <returns></returns>
        public int UpdateInterventionStatusByID(int interventionID, string status, int? approvalUserID)
        {
            int result = 0;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "UPDATE [Intervention] SET InterventionState = @status, ApprovalUserID = @approvalUserID  WHERE InterventionID = @interventionID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("status", status));
                command.Parameters.Add(new SqlParameter("interventionID", interventionID));
                command.Parameters.Add(new SqlParameter("approvalUserID", approvalUserID));

                try
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch
                {

                }
            }
            return result;
        }


        /// <summary>
        /// Update interventen status which has been already approved by siteEngineer or manager
        /// </summary>
        /// <param name="interventionID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateApprovedInterventionStatusByID(int interventionID, string status)
        {
            int result = 0;
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "UPDATE [Intervention] SET InterventionState = @status WHERE InterventionID = @interventionID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("status", status));
                command.Parameters.Add(new SqlParameter("interventionID", interventionID));
                

                try
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch
                {

                }
            }
            return result;
        }


        /// <summary>
        /// Update an intervention while re-visiting
        /// </summary>
        /// <param name="interventionID"></param>
        /// <param name="lastEditDate"></param>
        /// <param name="notes"></param>
        /// <param name="remainingLife"></param>
        /// <returns></returns>
        public int UpdateIntervention(int interventionID, string lastEditDate, string notes, int? remainingLife)
        {
            int result = 0;
            string query = "";
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                if(!(remainingLife == null))
                    query = "UPDATE Intervention SET RemainingLife = @remainingLife, LatestVisitDate = @latestVisitDate, Notes = @notes WHERE InterventionID = @interventionID";
                else
                    query = "UPDATE Intervention SET LatestVisitDate = @latestVisitDate, Notes = @notes WHERE InterventionID = @interventionID";

                SqlCommand command = new SqlCommand(query, connection);
                if(!(remainingLife == null))
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


        /// <summary>
        /// Update the status of an intervention
        /// </summary>
        /// <param name="changedStatus"></param>
        /// <param name="interventionID"></param>
        public void UpdateInterventionStatus(string changedStatus, int interventionID)
        {
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "Update Intervention Set InterventionState= '" + changedStatus + "' where InterventionID = '" + interventionID + "'";
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
                catch { }

            }
        }


        /// <summary>
        /// Get total cost list for an User. Cost list will be calculated depending on the report Type (SUM or AVG)
        /// </summary>
        /// <param name="reportType"></param>
        /// <returns></returns>
        public List<SiteEngineerTotalCost> GetTotalCostList(string reportType)
        {
            List<SiteEngineerTotalCost> aSiteEngineerTotalCostList = new List<SiteEngineerTotalCost>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "";
                if (reportType.Equals("Total"))
                    query = "SELECT SUM(LabourRequired), SUM(CostRequired), UserID FROM Intervention WHERE InterventionState=@state GROUP BY UserID";
                else
                    query = "SELECT AVG(LabourRequired), AVG(CostRequired), UserID FROM Intervention WHERE InterventionState=@state GROUP BY UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("state", "Completed"));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        SiteEngineerTotalCost aSiteEngineerTotalCost = new SiteEngineerTotalCost();

                        float SELabourDouble = float.Parse(reader[0].ToString());
                        double x = Math.Truncate(SELabourDouble * 100) / 100;
                        aSiteEngineerTotalCost.TotalLabour = x.ToString();

                        float SECostDouble = float.Parse(reader[1].ToString());
                        double y = Math.Truncate(SECostDouble * 100) / 100;
                        aSiteEngineerTotalCost.TotalCost = y.ToString();
                        
                        aSiteEngineerTotalCost.UserID = Int32.Parse(reader[2].ToString());
                        aSiteEngineerTotalCost.UserName = aUserGateway.GetUserNameByUserID(Int32.Parse(reader[2].ToString()));
                        aSiteEngineerTotalCostList.Add(aSiteEngineerTotalCost);
                    }
                }
                catch { }
            }
            return aSiteEngineerTotalCostList;
        }


        /// <summary>
        /// Get the list of costs and labours grouped by district
        /// </summary>
        /// <returns></returns>
        public List<CostByDistrict> GetCostLabourListByDistrict()
        {
            List<CostByDistrict> aCostByDistrictList = new List<CostByDistrict>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "Select u.DistrictName, SUM(i.LabourRequired) as LabourHour, sum(i.CostRequired) as Cost from (Select u.UserID as UserID, d.DistrictName as DistrictName from [User] as u join [District] as d on u.DistrictID = d.DistrictID) as u join [Intervention] as i on u.UserID = i. UserID where i.InterventionState='Completed' Group By DistrictName";
                                //"from (Select u.UserID as UserID, d.DistrictName as DistrictName from [User] as u join [District] as d on u.DistrictID = d.DistrictID) as u join [Intervention] as i" +
                                //"on u.UserID = i. UserID Group By DistrictName";


                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CostByDistrict aCostByDistrict = new CostByDistrict();
                        aCostByDistrict.DistrictName = reader["DistrictName"].ToString();
                        aCostByDistrict.LabourHour = float.Parse(reader["LabourHour"].ToString());
                        aCostByDistrict.Cost = float.Parse(reader["Cost"].ToString());
                        aCostByDistrictList.Add(aCostByDistrict);
                    }
                }
                catch { }
            }

                return aCostByDistrictList;
        }


        /// <summary>
        /// Get the monthly cost of a district
        /// </summary>
        /// <param name="district"></param>
        /// <returns></returns>
        public List<MonthlyCostsByDistrict> GetMonthlyCostLabourListByDistrict(string district)
        {
            List<MonthlyCostsByDistrict> aMonthlyCostByDistrictList = new List<MonthlyCostsByDistrict>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                string query = "Select Month(i.InterventionDate) as InterventionMonth, Sum(i.LabourRequired) as LabourRequired, Sum(i.CostRequired) as Cost from (Select  InterventionID, UserID,InterventionDate, LabourRequired, CostRequired from[Intervention] where  InterventionState = 'Completed' And UserID IN (Select u.UserID from[User] as u join[District] as d on u.DistrictID = d.DistrictID  where DistrictName = @district)) as i Group By Month(i.InterventionDate) Order BY Month(i.InterventionDate)";
                                 //"from (Select  InterventionID, UserID,InterventionDate, LabourRequired, CostRequired from[Intervention] where  InterventionState = 'Completed'" +
                                 //"And UserID IN (Select u.UserID from[User] as u join[District] as d on u.DistrictID = d.DistrictID  where DistrictName = @district)) as i"
                                 //+ "Group By Month(i.InterventionDate) Order BY Month(i.InterventionDate)");

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("district", district));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        MonthlyCostsByDistrict aMonthlyCostByDistrict = new MonthlyCostsByDistrict();
                        aMonthlyCostByDistrict.InterventionMonth = Int32.Parse(reader["InterventionMonth"].ToString());
                        aMonthlyCostByDistrict.LabourRequired = float.Parse(reader["LabourRequired"].ToString());
                        aMonthlyCostByDistrict.Cost = float.Parse(reader["Cost"].ToString());
                        aMonthlyCostByDistrictList.Add(aMonthlyCostByDistrict);
                    }
                }
                catch { }
            }

            return aMonthlyCostByDistrictList;
        }


        /// <summary>
        /// Fetch Approved Intervention list which have been approved by the param userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Intervention> GetInterventionListByApprovalUserID(int userID)
        {
            DateTime dateValue;
            List<Intervention> anInterventionList = new List<Intervention>();
            connectionString = aDatabaseConfig.Setup("ENETCareDatabase");
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                string query = "SELECT * FROM [Intervention] WHERE ApprovalUserID=@id AND InterventionState = 'Approved'";

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
                        bool date = DateTime.TryParse(reader["InterventionDate"].ToString(), System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue);
                        string interventionDate = dateValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        anIntervention.InterventionDate = interventionDate;
                        anIntervention.ClientID = Int32.Parse(reader["ClientID"].ToString());
                        anIntervention.InterventionState = reader["InterventionState"].ToString();
                        anInterventionList.Add(anIntervention);
                    }
                }
                catch { }
            }
            return anInterventionList;
        }

    }

}
