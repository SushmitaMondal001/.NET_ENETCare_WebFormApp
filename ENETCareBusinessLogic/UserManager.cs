using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENETCareData;
using ENETCareModels;

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

        public string GetUserNameByUserID(int userID)
        {
            return anUserGateway.GetUserNameByUserID(userID);
        }

        public float GetMaxHourByUserID(int userID)
        {
            return anUserGateway.GetMaxHourByUserID(userID);
        }

        public float GetMaxCostByUserID(int userID)
        {
            return anUserGateway.GetMaxCostByUserID(userID);
        }
        public List<User> GetUserListByUserType(string userType)
        {
            return anUserGateway.GetUserListByUserType(userType);
        }
    }
}
