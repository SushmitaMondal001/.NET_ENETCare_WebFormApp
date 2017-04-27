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
        int districtID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write((string)Session["UserName"]);
            if (!this.IsPostBack)
            {
                districtID = aUserManager.GetUserDistrictID((string)Session["UserName"]);
                //this.BindClientListGrid();
            }
        }

        public void BindClientListGrid()
        {
            List<Client> aClientList = aClientManager.GetClientListByDistrict(districtID);
            PopulateViewList(aClientList);
            if (aClientList.Count == 0)
                ErrorMessageLabel.Text = "No client was found !!";
            else
            {
                clientListGridView.DataSource = aClientList;
                clientListGridView.DataBind();
            }
        }

        public List<ClientWithIntervention> PopulateViewList(List<Client> aClientList)
        {
            // get intervention for each client -> foreach loop for client
            // Populate intervention list
            List<ClientWithIntervention> aClientWithInterventionList = new List<ClientWithIntervention>();
            return aClientWithInterventionList;
        }
    }
}