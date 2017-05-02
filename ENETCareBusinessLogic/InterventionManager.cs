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
        UserManager aUserManager = new UserManager();

        public string AddNewIntervention(string intTypeID, string clientId, string labour, string cost, int userID, string interventionDate, string interventionState)
        {
            float maxHour = aUserManager.GetMaxHourByUserID(userID);
            float maxCost = aUserManager.GetMaxCostByUserID(userID);

            string message = "Intervention creation is unsuccessful.";

            if (intTypeID.Equals("Select Intervention") || clientId.Equals("Select Client"))
            {
                return "Intervention and client must be seleted";
            }
            else if (!(ValidateLabourInput(labour)) || (!ValidateCostInput(cost)))
            {
                return "Labour&cost must be positve number and less than 360 hour & A$100000 respectively";
            }
            else if ((((float.Parse(labour)) >= maxHour) || ((float.Parse(cost)) >= maxCost)) && !(interventionState.Equals("Proposed")))
            {
                return "Sorry!You can only approve upto " + maxHour + " Hour and A$" + maxCost;
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
            else if (!(float.TryParse(input, out float i)))
            {
                return false;
            }
            else if ((float.Parse(input) < 0) || (float.Parse(input) > 360))
            {
                return false;
            }

            return true;

        }

        public bool ValidateCostInput(string input)
        {

            if (input.Equals(""))
            {
                return false;
            }
            else if(!(float.TryParse(input,out float i)))
            {
                return false;
            }
            else if ((float.Parse(input) < 0) || (float.Parse(input) > 100000))
            {
                return false;
            }            

            return true;
        }

        public bool ValidateDateFormat(string input)
        {
            DateTime dateValue;
            bool date = DateTime.TryParseExact(input, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue);
            return date;
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
            string isValidInput = IsValidInput(remainingLife, notes);
            if (isValidInput.Equals("Valid"))
            {
                int remainingLifeInt = Int32.Parse(remainingLife);
                int result = anInterventionGateway.UpdateIntervention(interventionID, lastEditDate, notes, remainingLifeInt);
                if (result > 0)
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

        public string IsValidInput(string remainingLife, string notes)
        {
            string result = "Valid";
            int remainingLifeInt;
            bool isInt = Int32.TryParse(remainingLife, out remainingLifeInt);
            // Check remaining life
            if (isInt == false)
                return "Remaining life must be integer.";
            else if (remainingLifeInt < 0 || remainingLifeInt > 100)
                return "Remaining life must be between 0 to 100.";
            // Check notes length
            else if (notes.Length > 300000)
                return "Notes section is too lengthy. Please make it short.";
            return result;
        }

        public void SetInterventionStatus(string status, int intervID)
        {
            anInterventionGateway.UpdateInterventionStatus(status, intervID);
        }


        public List<SiteEngineerTotalCost> GetTotalCostList(string reportType)
        {
            return anInterventionGateway.GetTotalCostList(reportType);
        }


        public List<CostByDistrict> GetCostLabourListByDistrict()
        {
            return anInterventionGateway.GetCostLabourListByDistrict();
        }

        public List<MonthlyCostsByDistrict> GetMonthlyCostLabourListByDistrict(string district)
        {
            return anInterventionGateway.GetMonthlyCostLabourListByDistrict(district);
        }
    }
}
