using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCareBusinessLogic;
using ENETCareModels;

namespace ENETCareWebForm
{
    public partial class TotalLabourCostByDistrictReport : System.Web.UI.Page
    {

        InterventionManager anInterventionManager = new InterventionManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateReport();
            }
        }




        public void GenerateReport()
        {
            List<CostByDistrict> aCostByDistrictList = anInterventionManager.GetCostLabourListByDistrict();

            if(aCostByDistrictList.Count() == 0)
            {
                errorMessageLabel.Text = "No cost or labour list was found";
            }
            else
            {
                labourCostListByDistrictGridView.DataSource = aCostByDistrictList;
                labourCostListByDistrictGridView.DataBind();
            }

        }

        protected void labourCostListByDistrictGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            labourCostListByDistrictGridView.PageIndex = e.NewPageIndex;
            GenerateReport();
        }
    }
}