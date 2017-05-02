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
    public partial class ManagerHomePage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            DisableMasterPageButtons();
            if (!User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You need to Login first');window.location ='/LoginPage.aspx';", true);

            }
            else
            {
                if (!IsPostBack)

                {
                    if (!User.IsInRole("manager"))
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
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePasswordPage.aspx");
        }

        protected void proposedInterventionViewButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProposedInterventionListViewPage.aspx");
        }

        protected void managerLogoutButton_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/LoginPage.aspx");
        }

        public void DisableMasterPageButtons()
        {
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("nav");
            navDiv.Visible = false;
        }
    }
}