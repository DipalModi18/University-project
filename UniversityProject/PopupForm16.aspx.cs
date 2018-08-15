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
    public partial class PopupForm16 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);

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

        protected void txtYear1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Response.Write("<script>alert('Year1 :"+txtYear1.Text+"');</script>");
                txtYear2.Text=((Convert.ToInt16(txtYear1.Text))+1).ToString();
            }
            catch
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM SALARY_CERTI$ WHERE EMPNO=@EMPNO AND SYEAR=@SYEAR", con);
            cmd.Parameters.AddWithValue("@EMPNO", txtEmpno.Text);
            cmd.Parameters.AddWithValue("@SYEAR", txtYear1.Text);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Boolean recordExists = false;
            while (rdr.Read())
            {
                recordExists = true;
            }
            con.Close();

            if(recordExists)
            {
                Response.Redirect("WebFormForm16.aspx?EMPNO=" + txtEmpno.Text + "&YEAR1=" + txtYear1.Text + "&YEAR2=" + txtYear2.Text);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Salary Certificate Does Not Exists!!');window.location ='WebFormSalaryCertificate.aspx?EMPNO="+txtEmpno.Text+"&YEAR1="+txtYear1.Text+"&YEAR2="+txtYear2.Text+"';", true);
            }

            
        }
    }
}