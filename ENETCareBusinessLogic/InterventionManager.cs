using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCareData;
using ENETCareModels;

namespace ENETCareBusinessLogic
{
    public class InterventionManager
    {
        InterventionGateway anInterventionGateway = new InterventionGateway();
        

        public string AddNewIntervention(int interventionTypeID, int clientID, float labourRequired, float costRequired, int userID, string interventionDate, string interventionState)
        {
            string message = "Intervention creation is unsuccessful.";

            int result = anInterventionGateway.AddNewIntervention(interventionTypeID, clientID, labourRequired, costRequired, userID, interventionDate, interventionState);
            if (result > 0)
            {
                message = "Intervention creation is successful.";
            }
           
            return message;

        }

        
    }
}
