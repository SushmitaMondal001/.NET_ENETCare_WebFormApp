using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ENETCareBusinessLogic
{
    public class LoginValidation
    {
        public string LoginCheck(string userName, string password)
        {         
            
            if ((userName.Equals("Syed")) && (password.Equals("12345")))
            {
                return "AccountantHomePage.aspx";
            }
            else if ((userName.Equals("Sushmita")) && (password.Equals("12345")))
            {
                return "ManagerHomePage.aspx";
            }
            else if ((userName.Equals("Supreet")) && (password.Equals("12345")))
            {
                return "SiteEngineerHomePage.aspx";
            }
            else
            {
                return "Wrong";
            }
            
        }
    }
}
