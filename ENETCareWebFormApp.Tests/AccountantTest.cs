using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ENETCareWebFormApp.Tests
{
    [TestClass]
    public class AccountantTest
    {

        When_Accountant_Logs_In accountant;

        [TestInitialize]
        public void Setup()
        {
            accountant = new When_Accountant_Logs_In();

        }

        [TestMethod]
        public void Accountant_Can_Change_The_District_Of_A_SiteEngineer()
        {
            string districtName = "Rural Indonesia";
            bool result = accountant.Change_The_District_Of_A_SiteEngineer(districtName);
        }

        [TestMethod]
        public void Accountant_Can_Change_His_Or_Her_Password()
        {
            string password = "12345678";
            bool result = accountant.Change_The_District_Of_A_SiteEngineer(password);
        }
    }
}
