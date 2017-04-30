using ENETCareData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCareModels;

namespace ENETCareBusinessLogic
{
    public class DistrictManager
    {
        DistrictGateway aDistrictGateway = new DistrictGateway();

        public List<District> GetDistrictList()
        {
            List<District> aDistrictList = aDistrictGateway.GetDistrictList();
            return aDistrictList;
        }

        public string GetDistrictName(int districtID)
        {
            string districtName = aDistrictGateway.GetDistrictName(districtID);
            return districtName;
        }

        public void SetNewDistrict(int newDistrict, int userID)
        {
            aDistrictGateway.UpdateUserDistrict(newDistrict, userID);
        }
    }
}
