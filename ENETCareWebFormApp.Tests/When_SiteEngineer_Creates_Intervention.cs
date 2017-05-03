using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCareBusinessLogic;

namespace ENETCareWebFormApp.Tests
{
    public enum InterventionStatus
    {
        Proposed,
        Approved,
        Cancelled,
        Complete

    }
    public class When_SiteEngineer_Creates_Intervention
    {
        
        InterventionManager siteEngineer = new InterventionManager();
        public bool Create_Proposed_Intervention(string interventionStatus, float cost)
        {
            float siteEngineer_MaxCost_Limit = 2500;
            if((cost > siteEngineer_MaxCost_Limit) && (interventionStatus.Equals(InterventionStatus.Proposed.ToString())))
            {
                return true;
            }
            else
            {
                return false;
            }
            //string successfull_Intervention_Creation = siteEngineer.AddNewIntervention("2", "2", "40", cost, 1, "2017/04/13", interventionStatus);
            //if(successfull_Intervention_Creation.Equals("Intervention creation is successful."))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            
            
        }

    }
}
