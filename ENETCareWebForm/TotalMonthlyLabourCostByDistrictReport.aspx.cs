using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCareBusinessLogic;
using ENETCareModels;
using System.Web.UI.HtmlControls;

namespace ENETCareWebForm
{
    public partial class TotalMonthlyLabourCostByDistrictReport : System.Web.UI.Page
    {
        InterventionManager anInterventionManager = new InterventionManager();
        DistrictManager aDistrictManager = new DistrictManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisableMasterPageButtons();
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
                        PopulateDistrictDropDownownList();
                    }
                }
            }

            //if (!IsPostBack)
            //{
            //    PopulateDistrictDropDownownList();
            //}
        }

        public void GenerateReport(string district)
        {
                List<MonthlyCostsByDistrict> aMonthlyCostByDistrictList = anInterventionManager.GetMonthlyCostLabourListByDistrict(district);

            if (aMonthlyCostByDistrictList.Count() == 0)
            {
                MonthlylabourCostListByDistrictGridView.Visible = false;
                errorMessageLabel.Text = "No cost or labour list was found";
            }
            else
            {
                errorMessageLabel.Text = "";
                MonthlylabourCostListByDistrictGridView.Visible = true;
                MonthlylabourCostListByDistrictGridView.DataSource = aMonthlyCostByDistrictList;
                MonthlylabourCostListByDistrictGridView.DataBind();
            }

        }

        public void PopulateDistrictDropDownownList()
        {
            List<District> aDistrictList = aDistrictManager.GetDistrictList();
            districtDropDownBoxList.DataSource = aDistrictList;
            districtDropDownBoxList.DataTextField = "DistrictName";
            districtDropDownBoxList.DataValueField = "DistrictID";
            districtDropDownBoxList.DataBind();
        }
        

        protected void DistrictDropDownBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateReport(districtDropDownBoxList.SelectedItem.Text);
        }

        protected void MonthlylabourCostListByDistrictGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MonthlylabourCostListByDistrictGridView.PageIndex = e.NewPageIndex;
            GenerateReport(districtDropDownBoxList.SelectedItem.Text); 
        }

        protected void AccountantHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AccountantHomePage.aspx");
        }

        public void DisableMasterPageButtons()
        {
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("nav");
            navDiv.Visible = false;
        }
    }
}