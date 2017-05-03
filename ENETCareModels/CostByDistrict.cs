using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareModels
{
    public class CostByDistrict
    {

        private string districtName;
        private float labourHour;
        private float cost;


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

        public float LabourHour
        {
            get
            {
                return labourHour;
            }

            set
            {
                labourHour = value;
            }
        }

        public float Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }
    }
}
