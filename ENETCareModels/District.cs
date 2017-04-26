using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareModels
{
    public class District
    {
        private int districtID;
        private string districtName;

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
    }
}
