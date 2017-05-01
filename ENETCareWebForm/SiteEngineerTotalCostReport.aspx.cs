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

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                GenerateReport();
        }

        public void GenerateReport()
        {
            List<SiteEngineerTotalCost> aSiteEngineerTotalCostList = anInterventionManager.GetTotalCostList();
            if (aSiteEngineerTotalCostList.Count == 0)
                errorMessageLabel.Text = "No User was found !!";
            else
            {
                totalCostListGridView.DataSource = aSiteEngineerTotalCostList;
                totalCostListGridView.DataBind();
            }
        }

        protected void totalCostListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            totalCostListGridView.PageIndex = e.NewPageIndex;
            GenerateReport();
        }
    }
}