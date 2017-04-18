using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCareData
{
    public class User
    {
        public int UserID { get; set; }
        public int UserName { get; set; }
        public int LoginName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public int DistrictID { get; set; }
        public int MaxHour { get; set; }
        public int MaxCost { get; set; }
    }
}