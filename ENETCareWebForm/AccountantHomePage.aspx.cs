using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCareWebForm
{
    public partial class AccountantHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dropDownReportBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void changePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePasswordPage");
        }

        protected void engManagerList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserListPage");
        }
    }
}