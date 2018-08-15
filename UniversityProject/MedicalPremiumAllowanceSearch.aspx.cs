using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace UniversityProject
{
    public partial class MedicalPremiumAllowanceSearch : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);

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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtYear.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select YEAR from MEDICALPREMIUMALLOWANCE where YEAR=@YEAR", con);
                cmd.Parameters.AddWithValue("YEAR", TxtYear.Text);
                var no = cmd.ExecuteScalar();
                if (no != null)
                {
                    //GridView1.DataSource = SqlDataSource1;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('No Data Found!!');</script>");
                    Response.Write("<script language='javascript'>window.location='MedicalPremiumAllowanceSearch.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Enter Year in Textbox!!');</script>");
            }
        }





        protected void LinkButtonAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicalPremiumAllowanceInsertion.aspx");
        }
    }
}