using ENETCareBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCareWebForm
{
    public partial class AllClientsViewPage : System.Web.UI.Page
    {
        ClientManager aClientManager = new ClientManager();
        DistrictManager aDistrictManager = new DistrictManager();
        UserManager aUserManager = new UserManager();
        int districtID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write((string)Session["UserName"]);
            if (!this.IsPostBack)
            {
                districtID = aUserManager.GetUserDistrictID((string)Session["UserName"]);
                this.BindClientListGrid();
            }
        }

        public void BindClientListGrid()
        {

        }
        
    }
}