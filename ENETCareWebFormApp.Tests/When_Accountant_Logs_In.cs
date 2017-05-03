using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCareWebFormApp.Tests
{
    public class When_Accountant_Logs_In
    {
        string[] siteEngineerNamePasswordAndDistrict = { "Syed","1234", "Sydney" };

        public bool Change_The_District_Of_A_SiteEngineer(string districtName)
        {
            siteEngineerNamePasswordAndDistrict = siteEngineerNamePasswordAndDistrict.Select(s => s.Replace("Sydney", districtName)).ToArray();
            if (siteEngineerNamePasswordAndDistrict.Contains(districtName))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool Change_Password(string password)
        {
            siteEngineerNamePasswordAndDistrict = siteEngineerNamePasswordAndDistrict.Select(s => s.Replace("Sydney", password)).ToArray();
            if (siteEngineerNamePasswordAndDistrict.Contains(password))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
