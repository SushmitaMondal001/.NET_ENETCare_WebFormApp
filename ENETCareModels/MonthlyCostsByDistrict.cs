using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareModels
{
    public class MonthlyCostsByDistrict
    {
        private int interventionMonth;
        private float labourRequired;
        private float cost;


        public int InterventionMonth
        {
            get
            {
                return interventionMonth;
            }

            set
            {
                interventionMonth = value;
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
