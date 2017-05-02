using ENETCareBusinessLogic;
using ENETCareModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCareWebForm
{
    public partial class SiteEngineerTotalCostReport : System.Web.UI.Page
    {
        InterventionManager anInterventionManager = new InterventionManager();
        UserManager anUserManager = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You need to Login first');window.location ='/LoginPage.aspx';", true);

            }
            else
            {
                if (!User.IsInRole("Accountant"))
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Unauthorised Access');window.location ='/LoginPage.aspx';", true);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        GenerateReport();
                    }
                }

            }

            //if (!IsPostBack)
            //    GenerateReport();
        }

        public void GenerateReport()
        {
            List<SiteEngineerTotalCost> aSiteEngineerTotalCostList = anInterventionManager.GetTotalCostList("Total");
            List<User> anUserList = anUserManager.GetUserListByUserType("SiteEngineer");
            if (anUserList.Count == 0)
                errorMessageLabel.Text = "No User was found !!";
            else
            {
                totalCostListGridView.DataSource = PopulateFinalTotalCostList(aSiteEngineerTotalCostList, anUserList);
                totalCostListGridView.DataBind();
            }
        }

        public List<SiteEngineerTotalCost> PopulateFinalTotalCostList(List<SiteEngineerTotalCost> aSiteEngineerTotalCostList, List<User> anUserList)
        {
            foreach(var user in anUserList)
            {
                bool isExist = aSiteEngineerTotalCostList.Exists(x => x.UserID == user.UserID);
                if(isExist == false)
                {
                    SiteEngineerTotalCost aSiteEngineerTotalCost = new SiteEngineerTotalCost();
                    aSiteEngineerTotalCost.UserID = user.UserID;
                    aSiteEngineerTotalCost.UserName = user.UserName;
                    aSiteEngineerTotalCost.TotalLabour = "0";
                    aSiteEngineerTotalCost.TotalCost = "0";
                    aSiteEngineerTotalCostList.Add(aSiteEngineerTotalCost);
                }
            }

            List <SiteEngineerTotalCost> sortedList = aSiteEngineerTotalCostList.OrderBy(o => o.UserName).ToList();
            return sortedList;
        }

        protected void totalCostListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            totalCostListGridView.PageIndex = e.NewPageIndex;
            GenerateReport();
        }
    }
}