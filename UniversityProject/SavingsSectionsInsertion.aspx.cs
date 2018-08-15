using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace UniversityProject
{
    public partial class SavingsSectionsInsertion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into SAVINGS_SECTIONS$ values(@NAME,@AMOUNT,@YEAR1,@YEAR2)", con);
                cmd.Parameters.AddWithValue("@NAME", txtName.Text);
                cmd.Parameters.AddWithValue("@AMOUNT", txtAmount.Text);
                cmd.Parameters.AddWithValue("@YEAR1", txtYear1.Text);
                cmd.Parameters.AddWithValue("@YEAR2", txtYear2.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                string SecName = txtName.Text;
                SecName = SecName.Replace(" ", "");

                cmd = new SqlCommand("alter table SAVINGS$ add " + SecName + " nvarchar(50);", con);
                //cmd.Parameters.AddWithValue("@NAME", SecName);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlCommand cmd1 = new SqlCommand("update SAVINGS$ set " + SecName + "=0", con);
                //cmd.Parameters.AddWithValue("@NAME", SecName);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Saved Successfully!!');</script>");
            }
            catch
            {
                Response.Write("<script>alert('Error while saving data!!');</script>");
            }
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
                if (Session["User_Id"].ToString() == (100).ToString())
                {
                    MasterPageFile = "Site2.master";
                }
                else
                {
                    MasterPageFile = "Site3.master";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SavingsSections.aspx");
        }
    }
}