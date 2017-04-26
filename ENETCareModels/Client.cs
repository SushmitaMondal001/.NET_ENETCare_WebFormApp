using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareModels
{
    public class Client
    {
        private int clientID;
        private string clientName;
        private string address;
        private int districtID;
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

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public int DistrictID
        {
            get
            {
                return districtID;
            }

            set
            {
                districtID = value;
            }
        }
    }
}
