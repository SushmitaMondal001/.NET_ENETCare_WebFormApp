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
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write((string)Session["UserName"]);
            if (!this.IsPostBack)
            {
                this.BindClientListGrid();
            }
        }

        public void BindClientListGrid()
        {

        }
        
    }
}