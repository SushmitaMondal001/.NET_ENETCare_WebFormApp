using ENETCareBusinessLogic;
using ENETCareModels;
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
        InterventionManager anInterventionManager = new InterventionManager();
        InterventionTypeManager anInterventionTypeManager = new InterventionTypeManager();
        int districtID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write((string)Session["UserName"]);
            districtID = aUserManager.GetUserDistrictID((string)Session["UserName"]);
            if (!this.IsPostBack)
            {
                this.BindClientListGrid();
            }
        }

        public void BindClientListGrid()
        {
            List<Client> aClientList = aClientManager.GetClientListByDistrict(districtID);
            List<ClientWithIntervention> aClientWithInterventionList = PopulateViewList(aClientList);
            if (aClientList.Count == 0)
                ErrorMessageLabel.Text = "No client was found !!";
            else
            {
                clientListGridView.DataSource = aClientWithInterventionList;
                clientListGridView.DataBind();
            }
        }

        public List<ClientWithIntervention> PopulateViewList(List<Client> aClientList)
        {
            // get intervention for each client -> foreach loop for client
            // Populate intervention list
            List<ClientWithIntervention> aClientWithInterventionList = new List<ClientWithIntervention>();
            foreach(Client aClient in aClientList)
            {
                List<Intervention> anInterventionList = anInterventionManager.GetInterventionListByClient(aClient.ClientID);
                foreach(Intervention anIntervention in anInterventionList)
                {
                    ClientWithIntervention aClientWithIntervention = new ClientWithIntervention();
                    aClientWithIntervention.ClientID = aClient.ClientID;
                    aClientWithIntervention.ClientName = aClient.ClientName;
                    aClientWithIntervention.ClientAddress = aClient.Address;
                    aClientWithIntervention.InterventionID = anIntervention.InterventionID;
                    aClientWithIntervention.InterventionTypeID = anIntervention.InterventionTypeID;
                    aClientWithIntervention.Intervention = anInterventionTypeManager.GetInterventionNameByTypeId(anIntervention.InterventionTypeID);
                    aClientWithIntervention.InterventionStatus = anIntervention.InterventionState;
                    aClientWithInterventionList.Add(aClientWithIntervention);
                }
            }
            return aClientWithInterventionList;
        }

        protected void clientListGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = clientListGridView.SelectedRow;
            HiddenField id = (HiddenField)row.FindControl("interventionIDHiddenField");
            int interventionID = Int32.Parse(id.Value);
            Session["InterventionID"] = interventionID.ToString();
            Response.Redirect("QMIEditPage.aspx");
        }
        protected void clientListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            clientListGridView.PageIndex = e.NewPageIndex;
            BindClientListGrid();
        }

        protected void siteEngineerHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteEngineerHomePage.aspx");
        }
    }
}