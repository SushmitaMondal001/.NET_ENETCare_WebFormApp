using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCareBusinessLogic;

namespace ENET
{
    public partial class Login : System.Web.UI.Page
    {
        LoginValidation checkLogin = new LoginValidation();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginEventMethod(object sender, EventArgs e)
        {
            
            string page = checkLogin.LoginCheck(usernameTextBox.Text, passwordTextBox.Text);
            if (page.Equals("Wrong"))
            {
                Response.Write("Wrong Username or Password");
            }
            else
            {
                Response.Redirect(page);
            }
            

          
                
        }
    }
}