using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCareModels
{
    public class User
    {
        private int userID;
        private string userName;
        private int loginName;
        private string password;
        private string userType;
        private int districtID;
        private int maxHour;
        private int maxCost;

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

        public int LoginName
        {
            get
            {
                return loginName;
            }

            set
            {
                loginName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
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

        public int MaxHour
        {
            get
            {
                return maxHour;
            }

            set
            {
                maxHour = value;
            }
        }

        public int MaxCost
        {
            get
            {
                return maxCost;
            }

            set
            {
                maxCost = value;
            }
        }
    }
}