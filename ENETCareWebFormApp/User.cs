using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCareWebFormApp
{
    public class User
    {
        public int UserID
        {
            private set { }
            get { return UserID; }
        }

        public int UserName
        {
            private set { }
            get { return UserName; }
        }

        public int LoginName
        {
            private set { }
            get { return LoginName; }
        }

        public int Password
        {
            private set { }
            get { return Password; }
        }

        public int UserType
        {
            private set { }
            get { return UserType; }
        }

        public int DistrictID
        {
            get;
            set;
        }

        public int MaxHour
        {
            private set { }
            get { return MaxHour; }
        }

        public int MaxCost
        {
            private set { }
            get { return MaxCost; }
        }
    }
}