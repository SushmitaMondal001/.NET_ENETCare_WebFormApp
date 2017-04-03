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
    }
}
