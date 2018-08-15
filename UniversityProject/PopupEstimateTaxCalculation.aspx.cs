using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityProject
{
    public partial class PopupEstimateTaxCalculation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtYear1_TextChanged(object sender, EventArgs e)
        {
            {
                txtYear2.Text = (Convert.ToInt16(txtYear1.Text) + 1).ToString();
            }     
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormEstimateTaxCalculation.aspx?EMPNO=" + txtEmpno.Text + "&YEAR1=" + txtYear1.Text + "&YEAR2=" + txtYear2.Text);
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
    }
}