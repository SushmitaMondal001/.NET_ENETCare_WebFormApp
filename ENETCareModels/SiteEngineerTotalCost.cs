using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareModels
{
    public class SiteEngineerTotalCost
    {
        private string userName;
        private string totalCost;
        private string totalLabour;

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

        public string TotalCost
        {
            get
            {
                return totalCost;
            }

            set
            {
                totalCost = value;
            }
        }

        public string TotalLabour
        {
            get
            {
                return totalLabour;
            }

            set
            {
                totalLabour = value;
            }
        }
    }
}
