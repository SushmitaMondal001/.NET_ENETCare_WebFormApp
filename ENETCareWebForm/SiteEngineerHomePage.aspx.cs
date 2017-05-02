using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCareBusinessLogic;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Owin;
using System.Web.UI.HtmlControls;

namespace ENETCareWebForm
{
    public partial class SiteEnigeerHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisableMasterPageButtons();
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Session["UserName"] = User.Identity.GetUserName();
                    StatusText.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());
                }
                else
                {
                    //LoginForm.Visible = true;
                }
            }
        }
        
        
        protected void siteEngineerlogoutButton_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Session["UserName"] = "";
            Response.Redirect("~/LoginPage.aspx");
            //Response.Redirect("LoginPage.aspx");
        }

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePasswordPage.aspx");
        }      

        protected void createNewClientButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientCreationPage.aspx");
        }

        protected void viewListOfClientsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllClientsViewPage.aspx");
        }

        protected void createNewInterventionButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("InterventionCreationPage.aspx"); 
        }

        protected void checkOldInterventionButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("InterventionViewPage.aspx");
        }
        public void DisableMasterPageButtons()
        {
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("nav");
            navDiv.Visible = false;
        }
    }
}