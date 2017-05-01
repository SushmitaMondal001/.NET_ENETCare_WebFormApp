using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareModels
{
    public class InterventionType
    {
        private int interventionTypeID;
        private string interventionTypeName;
        private double estimatedLabour;
        private double estimatedCost;
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

        public string InterventionTypeName
        {
            get
            {
                return interventionTypeName;
            }

            set
            {
                interventionTypeName = value;
            }
        }

        public double EstimatedLabour
        {
            get
            {
                return estimatedLabour;
            }

            set
            {
                estimatedLabour = value;
            }
        }

        public double EstimatedCost
        {
            get
            {
                return estimatedCost;
            }

            set
            {
                estimatedCost = value;
            }
        }
    }
}
