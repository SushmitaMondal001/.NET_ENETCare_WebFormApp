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

        public List<Intervention> GetInterventionListByClient(int clientID)
        {
            List<Intervention> anInterventionList = anInterventionGateway.GetInterventionListByClient(clientID);
            return anInterventionList;
        }


        public List<Intervention> GetInterventionListByUserID(int userID)
        {
            List<Intervention> anInterventionList = anInterventionGateway.GetInterventionListByUserID(userID);
            return anInterventionList;
        }


        public Intervention GetInterventionListByInterventionID(int interventionID)
        {
            Intervention anIntervention = anInterventionGateway.GetInterventionListByInterventionID(interventionID);
            return anIntervention;
        }

        public string UpdateIntervention(int interventionID, string lastEditDate, string notes, string remainingLife)
        {
            string message = "Quality management information update is unsuccessful.";
            string isValidInput = IsValidRemainingLife(remainingLife);
            if (isValidInput.Equals("Valid"))
            {
                int remainingLifeInt = Int32.Parse(remainingLife);
                int result = anInterventionGateway.UpdateIntervention(interventionID, lastEditDate, notes, remainingLifeInt);
                if(result > 0)
                    message = "Quality management information update is successful.";
            }
            else
            {
                message = isValidInput;
            }
            return message;
        }

        public string UpdateInterventionStatusByID(int interventionID, string status)
        {
            string message = "Intervention Status Unchanged";

            int result = anInterventionGateway.UpdateInterventionStatusByID(interventionID, status);
            if (result > 0)
            {
                message = "Intervention Status Changed";
            }
            return message;
        }

        public string IsValidRemainingLife(string remainingLife)
        {
            string result = "Valid";
            int remainingLifeInt;
            bool isInt = Int32.TryParse(remainingLife, out remainingLifeInt);
            if (isInt == false)
                return "Remaining life must be integer.";
            else if (remainingLifeInt < 0 || remainingLifeInt > 100)
                return "Remaining life must be between 0 to 100.";
            return result;
        }

        public void SetInterventionStatus(string status, int intervID)
        {
            anInterventionGateway.UpdateInterventionStatus(status, intervID);
        }





    }
}
