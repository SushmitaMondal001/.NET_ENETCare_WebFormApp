using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareModels
{
    // For All client listView
    public class ClientWithIntervention
    {
        private int clientID;
        private string clientName;
        private string clientAddress;
        private int interventionID;
        private int interventionTypeID;
        private string intervention;
        private string interventionStatus;

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

        public string ClientAddress
        {
            get
            {
                return clientAddress;
            }

            set
            {
                clientAddress = value;
            }
        }

        public string Intervention
        {
            get
            {
                return intervention;
            }

            set
            {
                intervention = value;
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
    }
}
