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
using ENETCareData;
using System.Data.Entity;
using ENETCareModels;
using System.Web.UI.HtmlControls;

namespace ENET
{
        public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisableMasterPageButtons();
            userNameLabel.Text = string.Format(User.Identity.GetUserName());
            if (!IsPostBack)
            {
                Session["PageURL"] = Request.UrlReferrer.ToString();
            }
        }
        protected void confirmEventMethod(object sender, EventArgs e)
        {
            //Connecting Identity Database  
                DatabaseConfig aDatabaseConfig = new DatabaseConfig();
                string connectionString = aDatabaseConfig.Setup("Identity");
                //To get user information we need UserManager who access data via UserStore according to IdenetityUser(I am)
                var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new MyDbContext(connectionString)));
                IdentityResult result = userManager.ChangePasswordAsync(User.Identity.GetUserId(), passwordTextBox.Text, newPasswordTextBox.Text).Result;
                if (result.Succeeded)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password has been changed successfully.');window.location ='" + Session["PageURL"].ToString() + "';", true);
                }
                else
                    errorMessage.Text = "Password change is unsuccessful!! " + result.Errors.FirstOrDefault();
        }

        public void DisableMasterPageButtons()
        {
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("nav");
            navDiv.Visible = false;
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Session["PageURL"].ToString());
        }
    }
}


