using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace UniversityProject
{
    public partial class SectionsInsertion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select NUMBER from SECTIONS where NUMBER=@NUMBER and NAME=@NAME", con);
            cmd.Parameters.AddWithValue("NUMBER", TxtYear.Text);
            cmd.Parameters.AddWithValue("NAME", TxtName.Text);
            var no = cmd.ExecuteScalar();
            con.Close();
            if (no != null)
            {
                Response.Write("<script>alert('This data already exsists');</script>");
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("Insert into SECTIONS values(@NUMBER, @NAME, @AMOUNT)", con);
                cmd.Parameters.AddWithValue("@NUMBER", TxtYear.Text);
                cmd.Parameters.AddWithValue("@NAME", TxtName.Text);
                cmd.Parameters.AddWithValue("@AMOUNT", TxtAmt.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                string SecName = TxtName.Text;
                SecName = SecName.Replace(" ", "");

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
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


                Response.Write("<script>alert('Section Details Are Added Successfully!!');</script>");
                Response.Write("<script language='javascript'>window.location='SectionsSearch.aspx';</script>");
            }

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Response.Redirect("SectionsSearch.aspx");
        }
    }
}