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
    public partial class ChangePassword : System.Web.UI.Page
    {
        int up = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        public void Page_PreInit(object sender,EventArgs e)
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

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from USERS$ where Id='" + Session["User_Id"] + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (txtOldPassword.Text == reader["PASSWORD"].ToString())
                {
                    up = 1;
                }
            }
            reader.Close();
            con.Close();
            if (up == 1)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                conn.Open();
                SqlCommand cmdd = new SqlCommand("Update USERS$ set PASSWORD=@PASSWORD where Id='" + Session["User_Id"] + "'", conn);
                cmdd.Parameters.AddWithValue("@PASSWORD", txtNewPassword.Text);
                if (cmdd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>alert(' Password Changed Successfully!!');</script>");
                    Response.Redirect("HomePage.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Your old password is incorrect');</script>");
                Response.Write("<script language='javascript'>window.location='ChangePassword.aspx';</script>");
            }

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}