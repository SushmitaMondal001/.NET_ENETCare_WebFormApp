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

namespace ENETCareWebForm
{
    public partial class ProposedInterventionListViewPage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
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
                    //StatusText.Text = string.Format("Hello {0}!!", User.Identity.GetUserName());
                }

            }

        }
        ENETCareBusinessLogic.InterventionManager inter = new ENETCareBusinessLogic.InterventionManager();
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }

            Session["InterventionID"] = GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text;
            


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
           
            int interventionID = int.Parse(Session["InterventionID"].ToString());

            inter.SetInterventionStatus(RadioButtonList1.SelectedItem.ToString(), interventionID);
            Response.Redirect(Request.RawUrl);
        }
    }
}