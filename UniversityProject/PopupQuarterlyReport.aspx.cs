using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace UniversityProject
{
    public partial class PopupQuarterlyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Page_PreInit(object sender, EventArgs e)
        {
            //base.OnPreInit(e);
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");

            }
            else
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormQuarterly.aspx?YEAR1=" + txtYear1.Text + "&YEAR2=" + txtYear2.Text);
        }

        protected void txtYear1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Response.Write("<script>alert('Year1 :"+txtYear1.Text+"');</script>");
                txtYear2.Text = ((Convert.ToInt16(txtYear1.Text)) + 1).ToString();
            }
            catch
            {

            }
        }
    }
}