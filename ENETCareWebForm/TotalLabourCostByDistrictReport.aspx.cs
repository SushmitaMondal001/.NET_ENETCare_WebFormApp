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

        protected void labourCostListByDistrictGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }


        float sumLabour = 0;
        float sumCost = 0;
        protected void labourCostListByDistrictGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            

            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                sumLabour = sumLabour + float.Parse(e.Row.Cells[2].Text);
                sumCost = sumCost + float.Parse(e.Row.Cells[3].Text);
                totalLabourByDistrictTextBox.Text = sumLabour.ToString();
                totalCostByDistrictTextBox.Text = sumCost.ToString();
            }

        }
    }
}