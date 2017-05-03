using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCareBusinessLogic;
using System.IO;
using System.Web;
using System.Web.Configuration;

namespace ENETCareWebFormApp.Tests
{
    [TestClass]
    public class SiteEngineerTests
    {
        When_SiteEngineer_Creates_Intervention siteEngineer;

        [TestInitialize]
        public void Setup()
        {
            siteEngineer = new When_SiteEngineer_Creates_Intervention();
           
        }

        float intervention_labourHour_Required;
        float intervention_Cost;
        string siteEngineerDistrict = "Urban Indonesia";
        string clientName;
        string clientDistrict;
        string cancelledInterventionName = "Supply Mosquito Net";
        

        [TestMethod]
        public void SiteEngineer_Can_Only_Propose_Intervention_When_OneOrBoth_Cost_And_Labour_Is_OutOfHisOrHer_Limit()
        {
            intervention_labourHour_Required = 40;
            intervention_Cost = 7200;

            bool result = siteEngineer.Create_Proposed_Intervention(InterventionStatus.Proposed.ToString(), intervention_Cost, intervention_labourHour_Required);
            Assert.IsTrue(result);
        }



        [TestMethod]
        public void SiteEngineer_Can_Approve_Intervention_When_Both_Cost_And_Labour_Is_within_HisOrHer_Limit()
        {
            intervention_labourHour_Required = 40;
            intervention_Cost = 2500;
            bool result = siteEngineer.Create_Approve_Intervention(InterventionStatus.Approved.ToString(), intervention_Cost, intervention_labourHour_Required);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SiteEngineer_Can_Not_Change_Status_of_A_Already_Completed_Intervention()
        {
            bool result = siteEngineer.Change_Status_of_A_Already_Completed_Intervention(InterventionStatus.Approved.ToString());
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SiteEngineer_Can_Not_Approve_A_Already_Approved_Intervention()
        {
            bool result = siteEngineer.Approve_A_Already_Approved_Intervention(InterventionStatus.Approved.ToString());
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SiteEngineer_Can_Not_Create_Client_IN_Another_District()
        {
            clientName = "Syed";
            clientDistrict = "Sydney";
            
            bool result = siteEngineer.Create_Client_In_Another_District(clientName, clientDistrict, siteEngineerDistrict);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SitEngineer_Can_Not_View_A_Cancelled_Intervention()
        {
            bool result = siteEngineer.View_A_Cancelled_Intervention(cancelledInterventionName);
            Assert.AreEqual(false, result);
        }

        //[TestMethod]
        //public void SiteEnineer_Can_Only_Propose_Intervention_When_Cost_Is_OutOfHis_Limit()
        //{
        //    bool result = siteEngineer.Create_Proposed_Intervention("Proposed", 7200);
        //    Assert.IsTrue(result);
        //}
    }
}
