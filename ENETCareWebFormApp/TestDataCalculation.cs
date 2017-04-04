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

        public string SiteEngineer(string name)
        {
            string[] siteEngineerList = { "Supreet", "Syed", "Sushmita", "Talha" };
            bool search = Array.Exists(siteEngineerList, element => element.Equals(name));
            string result="";
            if (search)
            {
                 result = name;
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
    }
}