using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareModels
{
    public class UserListWithDistrict
    {
        private int userID;
        private string userName;
        private int districtID;
        private string districtName;
        private string userType;

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

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string DistrictName
        {
            get
            {
                return districtName;
            }

            set
            {
                districtName = value;
            }
        }

        public string UserType
        {
            get
            {
                return userType;
            }

            set
            {
                userType = value;
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
