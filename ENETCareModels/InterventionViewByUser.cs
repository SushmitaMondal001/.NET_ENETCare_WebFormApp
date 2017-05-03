using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareModels
{
    public class InterventionViewByUser
    {
        private int interventionID;
        private int interventionTypeID;
        private string interventionType;
        private string interventionDate;
        private int clientID;
        private string clientName;        
        private string interventionStatus;
        private float labourRequired;
        private float costRequired;




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

        public string InterventionType
        {
            get
            {
                return interventionType;
            }

            set
            {
                interventionType = value;
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

        public string ClientName
        {
            get
            {
                return clientName;
            }

            set
            {
                clientName = value;
            }
        }      
                

        public string InterventionStatus
        {
            get
            {
                return interventionStatus;
            }

            set
            {
                interventionStatus = value;
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
    }
}
