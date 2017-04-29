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
        

        public string AddNewIntervention(string intTypeID, string clientId, string labour, string cost, int userID, string interventionDate, string interventionState)
        {
            string message = "Intervention creation is unsuccessful.";

            if (intTypeID.Equals("Select Intervention") || clientId.Equals("Select Client"))
            {
                return "Intervention and client must be seleted";
            }
            else if (!(ValidateLabourInput(labour)) || (!ValidateLabourInput(cost)))
            {
                return "Sorry Labour and cost field can not be empty and can  only contain numeric input";
            }
            else if (!(ValidateDateFormat(interventionDate)))
            {
                return "date must be in yyyy/mm/dd format";
            }
            else
            {
                int interventionTypeID = Int32.Parse(intTypeID);
                int clientID = Int32.Parse(clientId);
                float labourRequired = float.Parse(labour);
                float costRequired = float.Parse(cost);
                int result = anInterventionGateway.AddNewIntervention(interventionTypeID, clientID, labourRequired, costRequired, userID, interventionDate, interventionState);
                if (result > 0)
                {
                    message = "Intervention creation is successful.";
                }

                return message;
            }
                    
            

        }

        public bool ValidateLabourInput(string input)
        {
            
            if (input.Equals(""))
            {
                return false;
            }            
            else
            {
                return IsDigitsOnly(input);
            }

            
        }

        public bool ValidateDateFormat(string input)
        {
            DateTime dateValue;
            bool date = DateTime.TryParseExact(input, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue);
            return date;
        }

        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }


    }
}
