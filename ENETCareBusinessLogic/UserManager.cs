using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCareData;

namespace ENETCareBusinessLogic
{
    public class UserManager
    {
        UserGateway anUserGateway = new UserGateway();
        public int GetUserDistrictID(string loginName)
        {
            int districtID = anUserGateway.GetUserDistrictID(loginName);
            return districtID;
        }

        public int GetUserIdByName(string loginName)
        {
            int userID = anUserGateway.GetUserIdByName(loginName);
            return userID;
        }

    }
}
