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
            if (!User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You need to Login first');window.location ='/LoginPage.aspx';", true);

            }
            else
            {
                if (!User.IsInRole("SiteEng"))
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Unauthorised Access');window.location ='/LoginPage.aspx';", true);
                }
                else
                {
                    userNameTextLabel.Text = User.Identity.GetUserName();
                    if (!IsPostBack)
                    {
                        PopulateClientDropdownList();
                        PopulateInterventionTypeDropdownList();

                    }
                    
                }
            }

            //if (!IsPostBack)
            //{
            //    PopulateClientDropdownList();
            //    PopulateInterventionTypeDropdownList();

            //}
            //if (User.Identity.IsAuthenticated)
            //{
            //    userNameTextLabel.Text = User.Identity.GetUserName();
            //}
            //else
            //{

            //}
            //userNameTextLabel.Text = (string)Session["UserName"];
        }

        public void PopulateClientDropdownList()
        {
            int districtID = aUserManager.GetUserDistrictID((string)Session["UserName"]);
            List<Client> aClientListByDistrict = aClientManager.GetClientListByDistrict(districtID);
            clientNameDropDownList.DataSource = aClientListByDistrict;
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

            //int interventionTypeID = Int32.Parse(interventionTypeDropDownList.SelectedItem.Value);
            //int clientID = Int32.Parse(clientNameDropDownList.SelectedItem.Value);
            int userID = aUserManager.GetUserIdByName(userNameTextLabel.Text);
            string interventionState = interventionStateDropDownList.SelectedItem.Text;


            string result = anInterventionManager.AddNewIntervention(interventionTypeDropDownList.SelectedItem.Value, clientNameDropDownList.SelectedItem.Value, labourHourRequiredTextBox.Text, costRequiredTextBox.Text,
                            userID, interventionDateTextBox.Text, interventionState);
            if (!(result.Equals("Intervention creation is successful.")))
            {
                errorMessageLabel.Text = result;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Intervention creation is successful.');window.location ='SiteEngineerHomePage.aspx';", true);
                //Response.Redirect("SiteEngineerHomePage.aspx");
            }
        }


        protected void SiteEngineerHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteEngineerHomePage.aspx");
        }

        protected void interventionTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<InterventionType> aInterventionTypeList = anInterventionTypeManager.GetInterventionTypeList();
            int interventionTypeID = Int32.Parse(interventionTypeDropDownList.SelectedItem.Value);
            labourHourRequiredTextBox.Text = anInterventionTypeManager.GetEstLabourByIntTypeID(interventionTypeID);
            costRequiredTextBox.Text = anInterventionTypeManager.GetEstCostByIntTypeID(interventionTypeID);
        }

        protected void costRequiredTextBox_Click(object sender, EventArgs e)
        {
            //if (anInterventionManager.ValidateLabourInput(labourHourRequiredTextBox.Text))
            //{
            //    labourErrorMessageLabel.Text = "Sorry this field can not be emptyand can  only contain numeric input";
            //}
        }
    }
}