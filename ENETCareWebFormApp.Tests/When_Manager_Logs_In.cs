using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareWebFormApp.Tests
{
    

    public class When_Manager_Logs_In
    {
        string[] proposedInterventionNames = {"Supply Mosquito Net", "Hepataisis Training", "Supply and Install Storm-proof Home Kit", "Install Portable Toilet"};
        string[,] proposedInterventionList = {{ "Intervention Name", "Cost", "Labour" },
                                              { "Supply Mosquito Net", "200", "5" },
                                              { "Hepataisis Training", "1500", "24" },
                                              { "Supply and Install Storm-proof Home Kit", "5200", "60h" },
                                              { "Install Portable Toilet", "4000", "40" } };
                
        public bool View_A_Proposed_Intervention(string interventionName)
        {
            if(proposedInterventionNames.Contains(interventionName))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool View_Proposed_Interventions_OutOf_HisOrHer_Limit(string interventionName, float managerMaxCostLimit, float managermaxLabourLimit)
        {
            bool result = true;
            for (int i = 1; i < proposedInterventionList.Length; i++)
            {
                string proposedInterventionName = proposedInterventionList[i, 0];
                float interventionCost = float.Parse(proposedInterventionList[i, 1]);
                float interventionLabour = float.Parse(proposedInterventionList[i, 2]);
                if ((proposedInterventionName  == interventionName) && ((interventionCost >= managerMaxCostLimit) && (interventionLabour >= managermaxLabourLimit)))
                {
                    result= false;
                    break;
                    
                }
                else
                {
                    result = true;
                }
            }
            return result;

        }
    }
}
