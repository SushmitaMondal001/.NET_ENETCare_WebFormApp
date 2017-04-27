using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareModels
{
    public class Intervention
    {
        private int interventionID;
        private int interventionTypeID;
        private int clientID;
        private double labourRequired;
        private double costRequired;
        private int userID;
        private string interventionDate;
        private string interventionState;
        private int approvalUserID;
        
        public int InterventionID
        {
            get
            {
                return interventionID;
            }

            set
            {
                interventionID = value;
            }
        }

        public int InterventionTypeID
        {
            get
            {
                return interventionTypeID;
            }

            set
            {
                interventionTypeID = value;
            }
        }

        public int ClientID
        {
            get
            {
                return clientID;
            }

            set
            {
                clientID = value;
            }
        }

        public double LabourRequired
        {
            get
            {
                return labourRequired;
            }

            set
            {
                labourRequired = value;
            }
        }

        public double CostRequired
        {
            get
            {
                return costRequired;
            }

            set
            {
                costRequired = value;
            }
        }

        public int UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }
        public string InterventionDate
        {
            get
            {
                return interventionDate;
            }

            set
            {
                interventionDate = value;
            }
        }

        public string InterventionState
        {
            get
            {
                return interventionState;
            }

            set
            {
                interventionState = value;
            }
        }

        public int ApprovalUserID
        {
            get
            {
                return approvalUserID;
            }

            set
            {
                approvalUserID = value;
            }
        }
    }
}
