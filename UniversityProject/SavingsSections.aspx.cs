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
    public partial class SavingsSections : System.Web.UI.Page
    {
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

        /* protected void btnInsert_Click(object sender, EventArgs e)
         {
             SqlDataSource1.InsertParameters["NAME"].DefaultValue = (GridView1.FooterRow.FindControl("txtInsertName") as TextBox).Text;
             SqlDataSource1.InsertParameters["AMOUNT"].DefaultValue = (GridView1.FooterRow.FindControl("txtInsertAmount") as TextBox).Text;
             SqlDataSource1.InsertParameters["YEAR1"].DefaultValue = ""; //(GridView1.FooterRow.FindControl("txtYear1") as TextBox).Text;
             SqlDataSource1.InsertParameters["YEAR2"].DefaultValue = ""; //(GridView1.FooterRow.FindControl("txtYear2") as TextBox).Text;
             SqlDataSource1.Insert();

             string SecName = (GridView1.FooterRow.FindControl("txtInsertName") as TextBox).Text;
             SecName = SecName.Replace(" ", "");


             SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
             SqlCommand cmd = new SqlCommand("alter table SAVINGS$ add " + SecName + " nvarchar(50);", con);
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
         }*/

        protected void lbAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("SavingsSectionsInsertion.aspx");
        }
    }
}