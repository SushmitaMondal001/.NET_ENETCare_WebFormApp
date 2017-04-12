using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENET
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginEventMethod(object sender, EventArgs e)
        {
            // For today only :) Do get angry please *_*

            string userName = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            if ((userName.Equals("Syed")) && (password.Equals("12345"))){
                Response.Redirect("AccountantHomePage.aspx");
            }
            else if((userName.Equals("Sushmita")) && (password.Equals("12345"))){
                Response.Redirect("ManagerHomePage.aspx");
            }
            else if((userName.Equals("Supreet")) && (password.Equals("12345"))){
                Response.Redirect("SiteEngineerHomePage.aspx");
            }
                
        }
    }
}