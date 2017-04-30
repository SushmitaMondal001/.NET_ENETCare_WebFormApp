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
        private float labourRequired;
        private float costRequired;
        private int userID;
        private string interventionDate;
        private string interventionState;
        private int approvalUserID;
        private string notes;
        private int? remainingLife;
        private string lastEditDate;

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

        public float LabourRequired
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

        public float CostRequired
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

        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }

        public int? RemainingLife
        {
            get
            {
                return remainingLife;
            }

            set
            {
                remainingLife = value;
            }
        }

        public string LastEditDate
        {
            get
            {
                return lastEditDate;
            }

            set
            {
                lastEditDate = value;
            }
        }
    }
}
