using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Configuration;
using ENETCareBusinessLogic;

namespace ENETCareWebFormApp.Tests
{
   
    public class When_SiteEngineer_Creates_Intervention
    {

        InterventionManager siteEngineer = new InterventionManager();
        float siteEngineer_MaxCost_Limit = 2500;
        float siteEngineer_MaxLabourHour_Limit = 50;
        string cancelledInterventionName = "Supply Mosquito Net";
        string cancelledInterventionStatus = "Cancelled";


        public bool Create_Proposed_Intervention(string interventionStatus, float cost, float Labour)
        {

            if (((cost > siteEngineer_MaxCost_Limit) || (Labour > siteEngineer_MaxLabourHour_Limit)) && (interventionStatus.Equals(InterventionStatus.Proposed.ToString())))
            {
                return true;
            }
            else
            {
                return false;
            }

            //string successfull_Intervention_Creation = siteEngineer.AddNewIntervention("12", "3", Labour, cost, 1, "2017/04/13", interventionStatus);
            //if (!(successfull_Intervention_Creation.Equals("Intervention creation is successful.")))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

        }

        public bool Create_Approve_Intervention(string interventionStatus, float cost, float Labour)
        {
            if (((cost <= siteEngineer_MaxCost_Limit) && (Labour <= siteEngineer_MaxLabourHour_Limit)) && (interventionStatus.Equals(InterventionStatus.Approved.ToString())))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Change_Status_of_A_Already_Completed_Intervention(string interventionStatus)
        {
            if (interventionStatus != InterventionStatus.Completed.ToString())
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool Approve_A_Already_Approved_Intervention(string interventionStatus)
        {
            if (interventionStatus == InterventionStatus.Approved.ToString())
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool Create_Client_In_Another_District(string clientName, string clientDistrict, string siteEngineerDistrict)
        {
            if (clientDistrict != siteEngineerDistrict)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool View_A_Cancelled_Intervention(string interventionName)
        {
            
            if((cancelledInterventionName == interventionName) && (cancelledInterventionStatus == InterventionStatus.Cancelled.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }


        }
    }
}
