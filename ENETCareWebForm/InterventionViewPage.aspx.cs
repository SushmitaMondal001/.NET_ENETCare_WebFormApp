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
    public partial class InterventionViewPage : System.Web.UI.Page
    {
        ClientManager aClientManager = new ClientManager();        
        UserManager aUserManager = new UserManager();
        InterventionManager anInterventionManager = new InterventionManager();
        InterventionTypeManager anInterventionTypeManager = new InterventionTypeManager();
        int userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = aUserManager.GetUserIdByName((string)Session["UserName"]);
            if (!this.IsPostBack)
            {
                this.BindInterventionListGrid();
            }
            //if (User.Identity.IsAuthenticated)
            //{
            //    userID = aUserManager.GetUserIdByName(User.Identity.GetUserName());
            //}

            
            
        }

        public void BindInterventionListGrid()
        {
            List<Intervention> anInterventionList = anInterventionManager.GetInterventionListByUserID(userID);
            List<InterventionViewByUser> anInterventionViewByUserList = PopulateViewList(anInterventionList);
            if (anInterventionList.Count == 0)
                ErrorMessageLabel.Text = "No Intervention was found !!";
            else
            {
                interventionListGridView.DataSource = anInterventionViewByUserList;
                interventionListGridView.DataBind();
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
                anInterventionViewByUser.ClientID = anIntervention.ClientID;
                anInterventionViewByUser.ClientName = aClientManager.GetClientNameByID(anIntervention.ClientID);                                    
                anInterventionViewByUser.InterventionStatus = anIntervention.InterventionState;
                anInterventionViewByUserList.Add(anInterventionViewByUser);
                
            }

            return anInterventionViewByUserList;
        }

        protected void interventionListGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void interventionListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            interventionListGridView.PageIndex = e.NewPageIndex;
            BindInterventionListGrid();
        }

        protected void siteEngineerHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteEngineerHomePage.aspx");
        }

        protected void interventionListGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = interventionListGridView.Rows[index];
            TableCell status = selectedRow.Cells[3];
            string interventionStatus = status.Text;
            if ((e.CommandName == "Complete") && ((interventionStatus.Equals("Approved")) || (interventionStatus.Equals("Proposed"))))
            {
                HiddenField interventionIDHiddenField = (HiddenField)selectedRow.FindControl("interventionIDHiddenField");
                
                    ErrorMessageLabel.Text = "Hi Mate" + interventionIDHiddenField.Value;
                

                //ErrorMessageLabel.Text = "Hi Mate";
            }
            else if ((e.CommandName == "Approve") && (interventionStatus.Equals("Proposed")))
            {
                ErrorMessageLabel.Text = "Hi Dude";
            }
            else if ((e.CommandName == "Approve") && (interventionStatus.Equals("Approved")))
            {
                ErrorMessageLabel.Text = "The Intervention is already Approved";
            }
            else if (interventionStatus.Equals("Completed"))
            {
                ErrorMessageLabel.Text = "The Intervention is already Completed";
            }
            //ErrorMessageLabel.Text = row.Cells[4].Text;


        }
    }
}