using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using System.Web.UI.HtmlControls;
using ENETCareBusinessLogic;
using ENETCareModels;

namespace ENETCareWebForm
{
    public partial class ProposedInterventionListViewPage : System.Web.UI.Page
    {
        ClientManager aClientManager = new ClientManager();
        UserManager anUserManager = new UserManager();
        InterventionTypeManager anInterventionTypeManager = new InterventionTypeManager();
        InterventionManager anInterventionManager = new InterventionManager();
        int districtID = 0;
        int userID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            DisableMasterPageButtons();
            districtID = anUserManager.GetUserDistrictID(User.Identity.GetUserName());
            userID = anUserManager.GetUserIdByName(User.Identity.GetUserName());
            if (!User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You need to Login first');window.location ='/LoginPage.aspx';", true);

            }
            else
            {
                if (!User.IsInRole("manager"))
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Unauthorised Access');window.location ='/LoginPage.aspx';", true);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        PopulateProposedInterventionList();
                    }
                    //StatusText.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());
                }
            }
        }

        public void PopulateProposedInterventionList()
        {
            List<InterventionViewByUser> anInterventionViewByUserList = new List<InterventionViewByUser>();
            anInterventionViewByUserList = GetListWithValue(anInterventionViewByUserList);
            if (anInterventionViewByUserList.Count == 0)
                ErrorMessageLabel.Text = "No Intervention was found !!";
            else
            {
                interventionListGridView.DataSource = anInterventionViewByUserList;
                interventionListGridView.DataBind();
            }
        }

        public List<InterventionViewByUser> GetListWithValue(List<InterventionViewByUser> anInterventionViewByUserList)
        {
            List<Client> aClientList = aClientManager.GetClientListByDistrict(districtID);
            foreach (Client aClient in aClientList)
            {
                List<Intervention> anInterventionList = anInterventionManager.GetInterventionListByClient(aClient.ClientID);
                foreach (Intervention anIntervention in anInterventionList)
                {
                    InterventionViewByUser anInterventionViewByUser = new InterventionViewByUser();
                    anInterventionViewByUser.InterventionStatus = anIntervention.InterventionState;
                    anInterventionViewByUser.InterventionID = anIntervention.InterventionID;
                    anInterventionViewByUser.InterventionTypeID = anIntervention.InterventionTypeID;
                    anInterventionViewByUser.InterventionType = anInterventionTypeManager.GetInterventionNameByTypeId(anIntervention.InterventionTypeID);
                    anInterventionViewByUser.InterventionDate = anIntervention.InterventionDate;
                    anInterventionViewByUser.ClientID = aClient.ClientID;
                    anInterventionViewByUser.ClientName = aClientManager.GetClientNameByID(aClient.ClientID);
                    anInterventionViewByUser.CostRequired = anIntervention.CostRequired;
                    anInterventionViewByUser.LabourRequired = anIntervention.LabourRequired;
                    if (anInterventionManager.IsEligibleForProposedList(anInterventionViewByUser.InterventionStatus,
                                                                        anIntervention.CostRequired,
                                                                        anIntervention.LabourRequired,
                                                                        anUserManager.GetMaxCostByUserID(userID),
                                                                        anUserManager.GetMaxHourByUserID(userID)))
                    {
                        anInterventionViewByUserList.Add(anInterventionViewByUser);
                    }
                }
            }
            return anInterventionViewByUserList;
        }

        protected void interventionListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Page")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = interventionListGridView.Rows[index];
                TableCell status = selectedRow.Cells[4];
                string interventionStatus = status.Text;
                HiddenField interventionIDHiddenField = (HiddenField)selectedRow.FindControl("interventionIDHiddenField");
                string interventionID = interventionIDHiddenField.Value;
                string result = anInterventionManager.UpdateInterventionStatusByID(Int32.Parse(interventionID), "Approved", userID);
                ErrorMessageLabel.Text = result;
            }
            PopulateProposedInterventionList();
        }
        public void DisableMasterPageButtons()
        {
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("nav");
            navDiv.Visible = false;
        }

        protected void managerHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagerHomePage.aspx");
        }

        protected void interventionListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            interventionListGridView.PageIndex = e.NewPageIndex;
            PopulateProposedInterventionList();
        }
    }
}