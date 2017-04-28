using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCareData;
using ENETCareModels;

namespace ENETCareBusinessLogic
{
    public class InterventionTypeManager
    {
        InterventionTypeGateway aInterventionTypeGateway = new InterventionTypeGateway();

        public List<InterventionType> GetInterventionTypeList()
        {
            List<InterventionType> aInterventionTypeList = aInterventionTypeGateway.GetInterventionTypeList();
            return aInterventionTypeList;
        }

        public int GetInterventionTypeIdByName(string interventionTypeName)
        {
            int interventionTypeId = aInterventionTypeGateway.GetInterventionTypeIdByName(interventionTypeName);
            return interventionTypeId;
        }

        public string GetEstLabourByIntTypeID(int interventionTypeID)
        {
            string estimatedLabour = aInterventionTypeGateway.GetEstLabourByIntTypeID(interventionTypeID);
            return estimatedLabour;
        }

        public string GetEstCostByIntTypeID(int interventionTypeID)
        {
            string estimatedCost = aInterventionTypeGateway.GetEstCostByIntTypeID(interventionTypeID);
            return estimatedCost;
        }
    }
}
