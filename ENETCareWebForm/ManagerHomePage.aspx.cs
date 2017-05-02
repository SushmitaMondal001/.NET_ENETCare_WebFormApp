using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace ENETCareWebForm
{
    public partial class ManagerHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (User.Identity.IsAuthenticated)
            //    {
            //        StatusText.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());
            //        //LoginStatus.Visible = true;
            //        //LogoutButton.Visible = true;
            //    }
            //    else
            //    {
            //        //LoginForm.Visible = true;
            //    }
            //}

            if (!User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You need to Login first');window.location ='/LoginPage.aspx';", true);

            }
            else
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

        
    }
}