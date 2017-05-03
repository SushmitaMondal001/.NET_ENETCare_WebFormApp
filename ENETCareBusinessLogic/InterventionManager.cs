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
        InterventionTypeManager anInterventionType = new InterventionTypeManager();
        UserManager aUserManager = new UserManager();

        public string AddNewIntervention(string intTypeID, string clientId, string labour, string cost, int userID, string interventionDate, string interventionState)
        {
            float maxSiteEngineerLabourHour = aUserManager.GetMaxHourByUserID(userID);
            float maxSiteEngineerCost = aUserManager.GetMaxCostByUserID(userID);
            float estimatedInterventionLabour = float.Parse(anInterventionType.GetEstLabourByIntTypeID(Int32.Parse(intTypeID)));
            float estimatedInterventionCost = float.Parse(anInterventionType.GetEstCostByIntTypeID(Int32.Parse(intTypeID)));

            string message = "Intervention creation is unsuccessful.";

            if (intTypeID.Equals("Select Intervention") || clientId.Equals("Select Client"))
            {
                return "Intervention and client must be seleted";
            }
            else if (!(ValidateLabourInput(labour)) || (!ValidateCostInput(cost)))
            {
                return "Labour&cost must be positve number and less than 360 hour & A$100000 respectively";
            }
            else if((maxSiteEngineerLabourHour <= estimatedInterventionLabour) && (float.Parse(labour) != estimatedInterventionLabour))
            {
                return "DefaultLabourHour" + estimatedInterventionLabour + " is equal to or larger than your limit. It can't be changed";
            }
            else if ((maxSiteEngineerCost <= estimatedInterventionCost) && (float.Parse(cost) != estimatedInterventionCost))
            {
                return "DefaultCost A$"+ estimatedInterventionCost + " is equal to or larger than your limit. It can't be changed";
            }
            else if ((((float.Parse(labour)) > maxSiteEngineerLabourHour) || ((float.Parse(cost)) > maxSiteEngineerCost)) && !(interventionState.Equals("Proposed")))
            {
                return "Sorry!You can only approve upto " + maxSiteEngineerLabourHour + " Hour and A$" + maxSiteEngineerCost;
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
            float i = 0;
            if (input.Equals(""))
            {
                return false;
            }
            else if (!(float.TryParse(input, out i)))
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
            float i = 0;
            if (input.Equals(""))
            {
                return false;
            }
            else if(!(float.TryParse(input,out i)))
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

        public List<Intervention> GetInterventionList()
        {
            List<Intervention> anInterventionList = anInterventionGateway.GetInterventionList();
            return anInterventionList;
        }

        public Intervention GetInterventionListByInterventionID(int interventionID)
        {
            Intervention anIntervention = anInterventionGateway.GetInterventionListByInterventionID(interventionID);
            return anIntervention;
        }

        public string UpdateIntervention(int interventionID, string lastEditDate, string notes, string remainingLife)
        {
            int result = 0;
            string message = "Quality management information update is unsuccessful.";
            string isValidInput = IsValidInput(remainingLife, notes);
            if (isValidInput.Equals("Valid"))
            {
                if (!remainingLife.Equals(""))
                {
                    int remainingLifeInt = Int32.Parse(remainingLife);
                    result = anInterventionGateway.UpdateIntervention(interventionID, lastEditDate, notes, remainingLifeInt);
                }
                else
                    result = anInterventionGateway.UpdateIntervention(interventionID, lastEditDate, notes, null);
                if (result > 0)
                    message = "Quality management information update is successful.";
            }
            else
            {
                message = isValidInput;
            }
            return message;
        }

        public string UpdateInterventionStatusByID(int interventionID, string status, int? approvalUserID )
        {
            string message = "Intervention Status Unchanged";

            int result = anInterventionGateway.UpdateInterventionStatusByID(interventionID, status, approvalUserID);
            if (result > 0)
            {
                message = "Intervention Status Changed";
            }
            return message;
        }

        public string UpdateApprovedInterventionStatusByID(int interventionID, string status)
        {
            string message = "Intervention Status Unchanged";

            int result = anInterventionGateway.UpdateApprovedInterventionStatusByID(interventionID, status);
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
            if (!remainingLife.Equals(""))
            {
                bool isInt = Int32.TryParse(remainingLife, out remainingLifeInt);
                // Check remaining life
                if (isInt == false)
                    return "Remaining life must be integer.";
                else if (remainingLifeInt < 0 || remainingLifeInt > 100)
                    return "Remaining life must be between 0 to 100.";
            }
            // Check notes length
            if (notes.Length > 300000)
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

        public List<Intervention> GetInterventionListByApprovalUserID(int userID)
        {
            return anInterventionGateway.GetInterventionListByApprovalUserID(userID);
        }



        public bool IsEligibleForProposedList(string interventionStatus, float interventionCostRequired, float interventionLabourRequired, float userCostLimit, float userLabourLimit)
        {
            if (!(interventionStatus.Equals("Proposed")))
                return false;
            else if (interventionCostRequired > userCostLimit)
                return false;
            else if (interventionLabourRequired > userLabourLimit)
                return false;
            return true;
        }
    }
}
