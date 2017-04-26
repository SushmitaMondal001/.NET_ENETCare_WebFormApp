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
        DistrictManager aDistrictManager = new DistrictManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDistrictDropdownList();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

        }

        public void PopulateDistrictDropdownList()
        {
            List<District> aDistrictList = aDistrictManager.GetDistrictList();
            districtDropDownList.DataSource = aDistrictList;
            districtDropDownList.DataTextField = "DistrictName";
            districtDropDownList.DataValueField = "DistrictID";
            districtDropDownList.DataBind();
        }
    }
}