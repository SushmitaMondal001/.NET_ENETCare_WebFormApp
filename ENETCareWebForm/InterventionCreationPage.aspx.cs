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
            //userNameTextBox.Text = (string)Session["UserName"];
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

        }        

        protected void InterventionSaveButon_Click(object sender, EventArgs e)
        {
            //List<InterventionType> aInterventionTypeList = anInterventionTypeManager.GetInterventionTypeList();
            //int interventionTypeID = Int32.Parse(interventionTypeDropDownList.SelectedItem.Value);
            //labourHourRequiredTextBox.Text = anInterventionTypeManager.GetEstLabourByIntTypeID(interventionTypeID);
            //Response.Write(labourHourRequiredTextBox.Text);

            int interventionTypeID = Int32.Parse(interventionTypeDropDownList.SelectedItem.Value);
            int clientID = Int32.Parse(clientNameDropDownList.SelectedItem.Value);
            int userID = aUserManager.GetUserIdByName(userNameTextBox.Text);
            string interventionState = interventionStateDropDownList.SelectedItem.Text;

            string result = anInterventionManager.AddNewIntervention(interventionTypeID, clientID, float.Parse(labourHourRequiredTextBox.Text), float.Parse(costRequiredTextBox.Text), userID, interventionDateTextBox.Text, interventionState);
            errorMessageLabel.Text = result;
        }


        protected void SiteEngineerHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteEngineerHomePage.aspx");
        }

        protected void interventionTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<InterventionType> aInterventionTypeList = anInterventionTypeManager.GetInterventionTypeList();
            int interventionTypeID = Int32.Parse(interventionTypeDropDownList.SelectedItem.Value);
            labourHourRequiredTextBox.Text = anInterventionTypeManager.GetEstLabourByIntTypeID(interventionTypeID);
            costRequiredTextBox.Text = anInterventionTypeManager.GetEstCostByIntTypeID(interventionTypeID);



        }
    }
}