using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using System.Web.UI.HtmlControls;
using ENETCareBusinessLogic;
using ENETCareModels;

namespace ENETCareWebForm
{
    public partial class ChangeDistrict : System.Web.UI.Page
    {
        UserManager aUserManager = new UserManager();
        DistrictManager aDistrictManager = new DistrictManager();
        public int userID = 0;
        public int districtID = 0;

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
                    userID = Int32.Parse(Session["UserIDForChangeDistrict"].ToString());
                    districtID = Int32.Parse(Session["DistrictIDForChangeDistrict"].ToString());
                    //Response.Write(userID.ToString() + " DistrictID: "+districtID.ToString());
                    if (!IsPostBack)
                    {
                        PopulateFields();
                    }
                }
            }
        }
        public void DisableMasterPageButtons()
        {
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("nav");
            navDiv.Visible = false;
        }

        public void PopulateFields()
        {
            userTypeValueLabel.Text = Session["UserTypeForChangeDistrict"].ToString();
            userNameValueLabel.Text = aUserManager.GetUserNameByUserID(userID);
            currentDistrictValueLabel.Text = aDistrictManager.GetDistrictName(districtID);
            PopulateDistrictDropdownList();
        }

        public void PopulateDistrictDropdownList()
        {
            List<District> aDistrictList = aDistrictManager.GetDistrictList();
            var itemToRemove = aDistrictList.Single(r => r.DistrictID == districtID);
            aDistrictList.Remove(itemToRemove);
            districtDropDownList.DataSource = aDistrictList;
            districtDropDownList.DataTextField = "DistrictName";
            districtDropDownList.DataValueField = "DistrictID";
            districtDropDownList.DataBind();
            districtDropDownList.Items[0].Selected = true;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            //errorMessageLabel.Text = "District ID is: "+ districtDropDownList.SelectedItem.Value;
            int newDistrictID = Int32.Parse(districtDropDownList.SelectedItem.Value);
            string result = aUserManager.UpdateUserDistrict(userID,newDistrictID);
            if (!(result.Equals("District change is successful.")))
            {
                errorMessageLabel.Text = result;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('District change is successful.');window.location ='UserListPage.aspx';", true);
                //Response.Redirect("SiteEngineerHomePage.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserListPage.aspx");
        }

        protected void BackToHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantHomePage.aspx");
        }
    }
}