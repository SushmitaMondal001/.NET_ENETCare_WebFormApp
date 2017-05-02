using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCareBusinessLogic;

namespace ENETCareWebFormApp.Tests
{
    [TestClass]
    public class SiteEngineer_Can_Creates_Client_And_Intervention
    {
        When_SiteEngineer_Creates_Intervention siteEngineer;

        [TestInitialize]
        public void Setup()
        {
            siteEngineer = new When_SiteEngineer_Creates_Intervention();
           
        }

        [TestMethod]
        public void SiteEnineer_Can_Only_Propose_Intervention_When_Cost_Is_OutOfHis_Limit()
        {
            bool result = siteEngineer.Create_Proposed_Intervention("Proposed", 7200);

            Assert.IsTrue(result);
        }
    }
}
