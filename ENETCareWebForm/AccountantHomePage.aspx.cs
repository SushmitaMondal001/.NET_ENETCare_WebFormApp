using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.UI.HtmlControls;

namespace ENETCareWebForm
{
    public partial class AccountantHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DisableMasterPageButtons();
            Session["UserName"] = User.Identity.GetUserName();

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
                    StatusText.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());
                }
                
            }
        }
        
        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePasswordPage.aspx");
        }

        protected void engManagerListButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserListPage.aspx");

        }

        protected void accountantLogoutButton_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/LoginPage.aspx");
        }

        protected void generateReportButton_Click(object sender, EventArgs e)
        {
            string selectedValue = dropDownReportBox.SelectedItem.Value;
            if (selectedValue.Equals("Nothing"))
                errorMessageLabel.Text = "Please select a report type to generate report.";
            else
                Response.Redirect(selectedValue);
        }

        public void DisableMasterPageButtons()
        {
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("nav");
            navDiv.Visible = false;
        }
    }
}