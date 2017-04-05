using ENETCareWebForm;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCareBusinessLogic;

namespace ENETCareWebForm.Tests
{
    [TestClass]
    public class ENETUnitTesting
    {
        TestDataCalculation testData;

        [TestInitialize]
        public void Setup()
        {
            testData = new TestDataCalculation();
        }

        [TestMethod]
        public void SearchSiteEngineerListTest()
        {
            string name = testData.SiteEngineer("Talha");
            Assert.IsTrue(name == "Talha");
        }

        [TestMethod]
        public void SiteEngineerApprovalLimitTest()
        {
            string[,] name = { { "Talha", "3500" } };
            string[,] result = testData.SiteEngineerApprovalLimit(name);
            Assert.IsTrue(result == name);
        }

        [TestMethod]
        public void InterventionCostTest()
        {
            string[,] name = { { "Supply Mosquito Net", "100" } };
            string[,] result = testData.InterventionCost(name);
            Assert.IsTrue(result == name);
        }

        [TestMethod]
        public void SiteEngineerLimitInterventionCostCheckTest()
        {
            string[,] name = { { "Syed", "Supply Mosquito Net", "100" } };
            bool result = testData.SiteEngineerLimitInterventionCostCheck(name);
            Assert.IsTrue(result == true);
        }

        [TestMethod()]
        public void GetDistrictNameTest()
        {
            string district = testData.GetDistrictName();
            Assert.IsTrue(district == "NSW");
        }

        [TestMethod()]
        public void CheckPasswordTest()
        {
            string password = testData.CheckPassword();
            Assert.IsTrue(password == "12345");
        }


        [TestMethod()]
        public void GetLocationTest()
        {
            int n = 0;
            string location = testData.GetLocation();
            bool isNumeric = int.TryParse(location, out n);
            Assert.IsTrue(isNumeric == false);
        }

        [TestMethod()]
        public void CustomerDistrictTest()
        {
            string clientDistrict = testData.CustomerDistrict("Customer1");
            string siteEngineerDistrict = testData.SiteEngineerDistrict("Supreet");
            Assert.IsTrue(clientDistrict == siteEngineerDistrict);

        }

        [TestMethod()]
        public void GetClientNameTest()
        {
            int n = 0;
            string name_of_client = testData.GetClientName();
            bool isNumeric = int.TryParse(name_of_client, out n);
            Assert.IsTrue(isNumeric == false);

        }

        [TestMethod()]
        public void GetRemainingLifeTest()
        {
            int n = 0;
            string remaining_life = testData.GetRemainingLife();
            bool isNumeric = Int32.TryParse(remaining_life, out n);
            Assert.IsTrue((isNumeric == true) && (n<=100));
        }

        [TestMethod]
        public void LoginFormTest()
        {
            string result = testData.LoginForm("siteEngineer", "admin");
            Assert.IsTrue(result == "Welcome");
        }

        [TestMethod]
        public void ApprovalTest()
        {
            string result = testData.Approval(3500, 32);
            Assert.IsTrue(result == "approved");
        }
    }
}
