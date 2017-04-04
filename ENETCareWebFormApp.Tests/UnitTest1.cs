using ENETCareWebFormApp;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ENETCareWebFormApp.Tests
{
    [TestClass]
    public class UnitTest1
    {

        TestDataCalculation testData;

        [TestInitialize]
        public void Setup()
        {
            testData = new TestDataCalculation();
        }

        [TestMethod()]
        public void AddTotalCostTest()
        {
            var result = testData.AddTotalCost(10, 20);
            Assert.IsTrue(result == 30);
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
        public void DivideNumbersTest()
        {
            var result = testData.DivideNumbers(20, 10);
            Assert.IsTrue(result == 2);
        }

        [TestMethod()]
        public void GetLocationTest()
        {
            int n = 0;
            string location = testData.GetLocation();
            bool isNumeric = int.TryParse(location, out n);
            Assert.IsTrue(isNumeric == false);
        }
    }
}
