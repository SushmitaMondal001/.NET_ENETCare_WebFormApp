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
using System.Web.UI.HtmlControls;

namespace ENETCareWebForm
{
    public partial class AllInterventionViewPage : System.Web.UI.Page
    {
        ClientManager aClientManager = new ClientManager();
        UserManager aUserManager = new UserManager();
        InterventionManager anInterventionManager = new InterventionManager();
        InterventionTypeManager anInterventionTypeManager = new InterventionTypeManager();
        int userID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            DisableMasterPageButtons();
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
                    userID = aUserManager.GetUserIdByName(User.Identity.GetUserName());
                    if (!this.IsPostBack)
                    {
                        this.BindInterventionListGrid();
                    }
                }
            }


        }

        public void BindInterventionListGrid()
        {
            List<Intervention> anInterventionList = anInterventionManager.GetInterventionList();
            List<InterventionViewByUser> anInterventionViewByUserList = PopulateViewList(anInterventionList);
            if (anInterventionList.Count == 0)
                ErrorMessageLabel.Text = "No Intervention was found !!";
            else
            {
                AllinterventionListGridView.DataSource = anInterventionViewByUserList;
                AllinterventionListGridView.DataBind();
            }
        }

        public List<InterventionViewByUser> PopulateViewList(List<Intervention> anInterventionList)
        {
            // get intervention for each client -> foreach loop for client
            // Populate intervention list
            List<InterventionViewByUser> anInterventionViewByUserList = new List<InterventionViewByUser>();
            foreach (Intervention anIntervention in anInterventionList)
            {
                InterventionViewByUser anInterventionViewByUser = new InterventionViewByUser();
                anInterventionViewByUser.InterventionID = anIntervention.InterventionID;
                anInterventionViewByUser.InterventionTypeID = anIntervention.InterventionTypeID;
                anInterventionViewByUser.InterventionType = anInterventionTypeManager.GetInterventionNameByTypeId(anIntervention.InterventionTypeID);
                anInterventionViewByUser.InterventionDate = anIntervention.InterventionDate;
                anInterventionViewByUser.ClientID = anIntervention.ClientID;
                anInterventionViewByUser.ClientName = aClientManager.GetClientNameByClientID(anIntervention.ClientID);
                anInterventionViewByUser.InterventionStatus = anIntervention.InterventionState;
                anInterventionViewByUserList.Add(anInterventionViewByUser);

            }

            return anInterventionViewByUserList;
        }



        protected void AllinterventionListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AllinterventionListGridView.PageIndex = e.NewPageIndex;
            BindInterventionListGrid();
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