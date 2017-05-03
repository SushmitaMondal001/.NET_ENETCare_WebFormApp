using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ENETCareWebFormApp.Tests
{
    [TestClass]
    public class ManagerTests
    {
        When_Manager_Logs_In manager;

        [TestInitialize]
        public void Setup()
        {
            manager = new When_Manager_Logs_In();

        }
        


        [TestMethod]
        public void Manager_Can_Only_View_Proposed_Intervention()
        {
            bool result = manager.View_A_Proposed_Intervention("Supply Mosquito Net");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Manager_Can_Not_View_Proposed_Intervention_Outof_HisOrHer_Cost_And_LabourLimit()
        {
            string interventionName = "Hepataisis Training";
            float maxManagerCostLimit = 300;
            float maxManagerLabourLimit = 20;
            bool result = manager.View_Proposed_Interventions_OutOf_HisOrHer_Limit(interventionName, maxManagerCostLimit, maxManagerLabourLimit);
            Assert.AreEqual(false, result);
        }
    }
}
