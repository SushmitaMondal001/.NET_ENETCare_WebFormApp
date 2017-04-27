using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCareBusinessLogic;
using ENETCareModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace ENETCareWebForm
{
    public partial class InterventionCreationPage : System.Web.UI.Page
    {

        ClientManager aClientManager = new ClientManager();
        InterventionManager anInterventionManager = new InterventionManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateClientDropdownList();
                if (User.Identity.IsAuthenticated)
                {                    
                    userNameTextBox.Text = User.Identity.GetUserName();                    
                }
                else
                {
                    
                }
            }

        }

        public void PopulateClientDropdownList()
        {
            List<Client> aClientList = aClientManager.GetClientList();
            clientNameDropDownList.DataSource = aClientList;
            clientNameDropDownList.DataTextField = "ClientName";
            clientNameDropDownList.DataValueField = "ClientID";
            clientNameDropDownList.DataBind();
            clientNameDropDownList.Items[0].Selected = true;
        }

        protected void LabourHouRequiredTextBox_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void CostRequiredTextBox_Click(object sender, EventArgs e)
        {

        }

        protected void InterventionDateTextBox_Click(object sender, EventArgs e)
        {

        }

        protected void UserNameTextBox_CLick(object sender, EventArgs e)
        {

        }

        protected void InterventionSaveButon_Click(object sender, EventArgs e)
        {
           
        }

        protected void SiteEngineerHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteEngineerHomePage.aspx");
        }
    }
}