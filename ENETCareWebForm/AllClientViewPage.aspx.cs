using ENETCareBusinessLogic;
using ENETCareModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ENETCareWebForm
{
    public partial class AllClientViewPage : System.Web.UI.Page
    {
        ClientManager aClientManager = new ClientManager();
        DistrictManager aDistrictManager = new DistrictManager();
        UserManager aUserManager = new UserManager();
        InterventionManager anInterventionManager = new InterventionManager();
        InterventionTypeManager anInterventionTypeManager = new InterventionTypeManager();
        int districtID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            DisableMasterPageButtons();
            districtID = aUserManager.GetUserDistrictID(User.Identity.GetUserName());
            if (!User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You need to Login first');window.location ='/LoginPage.aspx';", true);

            }
            else
            {
                if (!this.IsPostBack)

                {
                    if (!User.IsInRole("SiteEng"))
                    {
                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                        authenticationManager.SignOut();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Unauthorised Access');window.location ='/LoginPage.aspx';", true);
                    }
                    else
                    {
                        districtID = aUserManager.GetUserDistrictID(User.Identity.GetUserName());
                        districtNameValueLabel.Text = aDistrictManager.GetDistrictName(districtID);
                        if (!this.IsPostBack)
                        {
                            this.BindClientListGrid();
                        }
                    }

                }
            }

        }

        public void BindClientListGrid()
        {
            List<Client> aClientList = aClientManager.GetClientListByDistrict(districtID);
            //List<ClientWithIntervention> aClientWithInterventionList = PopulateViewList(aClientList);
            if (aClientList.Count == 0)
                ErrorMessageLabel.Text = "No client was found !!";
            else
            {
                clientListGridView.DataSource = aClientList;
                clientListGridView.DataBind();
            }
        }

        //public List<ClientWithIntervention> PopulateViewList(List<Client> aClientList)
        //{
        //    // get intervention for each client -> foreach loop for client
        //    // Populate intervention list
        //    List<ClientWithIntervention> aClientWithInterventionList = new List<ClientWithIntervention>();
        //    foreach (Client aClient in aClientList)
        //    {
        //        List<Intervention> anInterventionList = anInterventionManager.GetInterventionListByClient(aClient.ClientID);
        //        foreach (Intervention anIntervention in anInterventionList)
        //        {
        //            ClientWithIntervention aClientWithIntervention = new ClientWithIntervention();
        //            aClientWithIntervention.ClientID = aClient.ClientID;
        //            aClientWithIntervention.ClientName = aClient.ClientName;
        //            aClientWithIntervention.ClientAddress = aClient.Address;
        //            aClientWithIntervention.InterventionID = anIntervention.InterventionID;
        //            aClientWithIntervention.InterventionTypeID = anIntervention.InterventionTypeID;
        //            aClientWithIntervention.Intervention = anInterventionTypeManager.GetInterventionNameByTypeId(anIntervention.InterventionTypeID);
        //            aClientWithIntervention.InterventionStatus = anIntervention.InterventionState;
        //            if (!(aClientWithIntervention.InterventionStatus).Equals("Cancelled"))
        //                aClientWithInterventionList.Add(aClientWithIntervention);
        //        }
        //    }
        //    return aClientWithInterventionList;
        //}
        
        protected void clientListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            clientListGridView.PageIndex = e.NewPageIndex;
            BindClientListGrid();
        }

        protected void siteEngineerHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteEngineerHomePage.aspx");
        }


        public void DisableMasterPageButtons()
        {
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("nav");
            navDiv.Visible = false;
        }
    }
}