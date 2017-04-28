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
        InterventionTypeManager anInterventionTypeManager = new InterventionTypeManager();
        UserManager aUserManager = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateClientDropdownList();
            PopulateInterventionTypeDropdownList();
            if (!IsPostBack)
            {
                PopulateClientDropdownList();
                PopulateInterventionTypeDropdownList();

            }
            if (User.Identity.IsAuthenticated)
            {
                userNameTextBox.Text = User.Identity.GetUserName();
            }
            else
            {

            }

        }

        public void PopulateClientDropdownList()
        {
            List<Client> aClientList = aClientManager.GetClientList();
            clientNameDropDownList.DataSource = aClientList;
            clientNameDropDownList.DataTextField = "ClientName";
            clientNameDropDownList.DataValueField = "ClientID";
            clientNameDropDownList.DataBind();
           
        }

        public void PopulateInterventionTypeDropdownList()
        {
            List<InterventionType> aInterventionTypeList = anInterventionTypeManager.GetInterventionTypeList();
            interventionTypeDropDownList.DataSource = aInterventionTypeList;
            interventionTypeDropDownList.DataTextField = "InterventionTypeName";
            interventionTypeDropDownList.DataValueField = "InterventionTypeID";
            interventionTypeDropDownList.DataBind();
            interventionTypeDropDownList.Items[0].Selected = true;

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
            int interventionTypeID = Int32.Parse(interventionTypeDropDownList.SelectedItem.Value);
            int clientID = Int32.Parse(clientNameDropDownList.SelectedItem.Value);
            int userID = aUserManager.GetUserIdByName(userNameTextBox.Text);
            string interventionState = interventionStateDropDownList.SelectedItem.Text;

            string result = anInterventionManager.AddNewIntervention(interventionTypeID, clientID, float.Parse(LabourHouRequiredTextBox.Text), float.Parse(costRequiredTextBox.Text), userID, interventionDateTextBox.Text, interventionState);
            errorMessageLabel.Text = result;
        }


        protected void SiteEngineerHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteEngineerHomePage.aspx");
        }
    }
}