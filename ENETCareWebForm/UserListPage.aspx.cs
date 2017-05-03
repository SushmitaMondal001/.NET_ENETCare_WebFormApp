using ENETCareBusinessLogic;
using ENETCareModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ENETCareWebForm
{
    public partial class UserListPage : System.Web.UI.Page
    {
        UserManager anUserManager = new UserManager();
        DistrictManager aDistrictManager = new DistrictManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            DisableMasterPageButtons();
            if (!User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You need to Login first');window.location ='/LoginPage.aspx';", true);

            }
            else
            {
                if (!User.IsInRole("Accountant"))
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Unauthorised Access');window.location ='/LoginPage.aspx';", true);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        PopulateUserGridView();
                    }
                    //StatusText.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());
                }

            }
            
        }

        protected void userListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            userListGridView.PageIndex = e.NewPageIndex;
            PopulateUserGridView();
        }
        public void DisableMasterPageButtons()
        {
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("nav");
            navDiv.Visible = false;
        }

        public void PopulateUserGridView()
        {
            List<UserListWithDistrict> anUserListWithDistrictList = new List<UserListWithDistrict>();
            anUserListWithDistrictList = PopulateUserDistrictList("SiteEngineer", anUserListWithDistrictList);
            anUserListWithDistrictList = PopulateUserDistrictList("Manager", anUserListWithDistrictList); 
            List<UserListWithDistrict> sortedList = anUserListWithDistrictList.OrderBy(o => o.UserID).ToList();
            if (anUserListWithDistrictList.Count == 0)
                ErrorMessageLabel.Text = "No user was found !!";
            else
            {
                userListGridView.DataSource = sortedList;
                userListGridView.DataBind();
            }
        }

        private List<UserListWithDistrict> PopulateUserDistrictList(string role, List<UserListWithDistrict> anUserListWithDistrictList)
        {
            List<User> anUserList = anUserManager.GetUserListByUserType(role);
            foreach (User anUser in anUserList)
            {
                UserListWithDistrict anUserListWithDistrict = new UserListWithDistrict();
                anUserListWithDistrict.UserID = anUser.UserID;
                anUserListWithDistrict.UserName = anUser.UserName;
                anUserListWithDistrict.DistrictID = anUser.DistrictID;
                anUserListWithDistrict.DistrictName = aDistrictManager.GetDistrictName(anUser.DistrictID);
                anUserListWithDistrict.UserType = role;
                anUserListWithDistrictList.Add(anUserListWithDistrict);
            }
            return anUserListWithDistrictList;
        }

        protected void userListGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = userListGridView.SelectedRow;
            HiddenField id = (HiddenField)row.FindControl("userIDHiddenField");
            int userID = Int32.Parse(id.Value);
            Session["UserIDForChangeDistrict"] = userID.ToString();

            id = (HiddenField)row.FindControl("districtIDHiddenField");
            int districtID = Int32.Parse(id.Value);
            Session["DistrictIDForChangeDistrict"] = districtID.ToString();

            Label userTypeLabel = (Label)row.FindControl("userTypeLabel");
            string userType = userTypeLabel.Text;
            Session["UserTypeForChangeDistrict"] = userType;
            Response.Redirect("ChangeDistrict.aspx");
        }

        protected void accountantHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantHomePage.aspx");
        }
    }
}