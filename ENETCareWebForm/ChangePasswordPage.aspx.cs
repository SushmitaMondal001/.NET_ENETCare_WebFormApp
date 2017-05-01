using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENET
{
    public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             usernameTextBox.Text =User.Identity.Name;
            
                  }
        protected void confirmEventMethod(object sender, EventArgs e)
        {
          
        }
        
    }
}