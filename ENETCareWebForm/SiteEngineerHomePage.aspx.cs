using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCareWebForm
{
    public partial class SiteEnigeerHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        
        protected void siteEngineerlogoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
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

        }

        protected void checkOldInterventionButton_Click(object sender, EventArgs e)
        {

        }
    }
}