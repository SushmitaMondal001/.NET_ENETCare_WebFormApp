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
    public partial class ClientCreatePage : System.Web.UI.Page
    {
        ClientManager aClientManager = new ClientManager();
        DistrictManager aDistrictManager = new DistrictManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDistrictDropdownList();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            int districtID = Int32.Parse(districtDropDownList.SelectedItem.Value);
            string result = aClientManager.AddNewClient(clientNameTextBox.Text, locationTextBox.Text, districtID);
            Response.Write(result);
            ClearForm();
        }

        public void PopulateDistrictDropdownList()
        {
            List<District> aDistrictList = aDistrictManager.GetDistrictList();
            districtDropDownList.DataSource = aDistrictList;
            districtDropDownList.DataTextField = "DistrictName";
            districtDropDownList.DataValueField = "DistrictID";
            districtDropDownList.DataBind();
            districtDropDownList.Items[0].Selected = true;
        }

        public void ClearForm()
        {
            clientNameTextBox.Text = "";
            locationTextBox.Text = "";
            districtDropDownList.Items[0].Selected = true;
        }

        protected void BackToHomePageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteEngineerHomePage.aspx");
        }
    }
}