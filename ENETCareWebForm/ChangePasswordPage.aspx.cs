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

namespace ENET
{
        public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userNameTextBox.Text = string.Format(User.Identity.GetUserName());
            // userNameTextBox.Text =User.Identity.Name;
            //userNameTextBox.Text=Session["UserName"].ToString();

            // passwordTextBox.Text = string.Format(User.Identity.GetHashCode().ToString());
           
          //  PasswordHash
        }
        protected void confirmEventMethod(object sender, EventArgs e)
        {
            //Connecting Identity Database  
            DatabaseConfig aDatabaseConfig = new DatabaseConfig();
            string connectionString = aDatabaseConfig.Setup("Identity");
            //To get user information we need UserManager who access data via UserStore according to IdenetityUser(I am)
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new MyDbContext(connectionString)));
            var result = userManager.ChangePasswordAsync(User.Identity.Name, "123456789","");
            Response.Redirect(Request.RawUrl);

            //  return RedirectToAction("Index", "ConfigUser");

        }
    }
}

//Update user information(UserName,OldPassword)
//Get authentication info. from UserManger

