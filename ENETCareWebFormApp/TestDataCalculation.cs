using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ENETCareWebFormApp
{
    public class TestDataCalculation
    { 
        // Adding to two number
        public double AddTotalCost(double prevCost, double newCost)
        {
            double totalCost = prevCost + newCost;
            return totalCost;
        }

        //Searches for Site Engineer
        public string SiteEngineer(string name)
        {
            string[] siteEngineerList = { "Supreet", "Syed", "Sushmita", "Talha" };
            bool search = Array.Exists(siteEngineerList, x => x.Equals(name));
            string result="";
            if (search)
            {
                 result = name;
            }
            return result;
        }

        //Searches for Site Engineer and his/her approval limit
        public string[,] SiteEngineerApprovalLimit(string[,] name)
        {
            string[,] result = new string[1,2];
            string[,] approvalLimitList =
            {
                {"Supreet","2000" },
                {"Syed","3000" },
                {"Sushmita","2500" },
                {"Talha","3500" },
            };
            for(int i = 0; i<approvalLimitList.GetLength(0); i++)
            {                
                if ((approvalLimitList[i, 0] == name[0, 0])&& (approvalLimitList[i, 1] == name[0, 1]))
                {
                    result = name;
                }
            }
            return result;
        }

        //Searches for Intervention type and it's cost
        public string[,] InterventionCost(string[,] name)
        {
            string[,] result = new string[1, 2];
            string[,] InterventionCostList =
            {
                {"Supply Mosquito Net","100" },
                {"Supply and Install Storm-proof Home Kit","3000" },
                
            };
            for (int i = 0; i < InterventionCostList.GetLength(0); i++)
            {
                if ((InterventionCostList[i, 0] == name[0, 0]) && (InterventionCostList[i, 1] == name[0, 1]))
                {
                    result = name;
                }
            }
            return result;
        }

        public bool SiteEngineerLimitInterventionCostCheck(string[,] name)
        {
            bool result = false;

            Details d = new Details();

            for (int i = 0; i < d.approvalLimitList.GetLength(0); i++)
            {
                if ((name[0, 0] == d.approvalLimitList[i, 0]) && (Convert.ToInt32(name[0, 2]) <= Convert.ToInt32(d.approvalLimitList[i, 1])))
                {
                    result = true;
                }
            }

            return result;
        }



        // Return a district name
        public string GetDistrictName()
        {
            string district = "NSW";
            return district;
        }

        // Check whether a correct user
        public string CheckPassword()
        {
            string typedPassword = "12345"; // will be read the input from the user
            return typedPassword;
        }

        // Division
        public double DivideNumbers(double totalCost, int engineerNumber)
        {
            double result = totalCost / engineerNumber;
            return result;
        }

        // Check the location or address is a string
        public string GetLocation()
        {
            string location = "someString";
            return location;
        }
        
        public string SiteEngineerDistrict(string name)
        {
            string[] siteEngineerList = { "Supreet","NSW "};
            bool search = Array.Exists(siteEngineerList, x => x.Equals(name));
            string engineer_result = "";
            if (search)
            {
                engineer_result = siteEngineerList[1] ;
            }
            return engineer_result;
        }
        public string CustomerDistrict(string name)
        {
            string[] CustomerList = { "Customer1", "NSW " };
            bool search = Array.Exists(CustomerList, x => x.Equals(name));
            string customer_result = "";
            if (search)
            {
                customer_result = CustomerList[1];
            }
            
            return customer_result;
        }

        

    }
}