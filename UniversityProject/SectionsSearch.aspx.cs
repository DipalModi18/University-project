using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace UniversityProject
{
    public partial class SectionsSearch : System.Web.UI.Page
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
            Response.Write("<script>alert('Searched clicked');</script>");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["NUMBER"].DefaultValue = (GridView1.FooterRow.FindControl("txtInsertNumber") as TextBox).Text;
            SqlDataSource1.InsertParameters["NAME"].DefaultValue = (GridView1.FooterRow.FindControl("txtInsertName") as TextBox).Text;
            SqlDataSource1.InsertParameters["AMOUNT"].DefaultValue = (GridView1.FooterRow.FindControl("txtInsertAmount") as TextBox).Text;
            SqlDataSource1.Insert();


            string SecName = (GridView1.FooterRow.FindControl("txtInsertName") as TextBox).Text;
            SecName = SecName.Replace(" ", "");


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("alter table SAVINGS$ add "+SecName+" nvarchar(50);", con);
            //cmd.Parameters.AddWithValue("@NAME", SecName);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd1 = new SqlCommand("update SAVINGS$ set "+SecName+"=0",con);
            //cmd.Parameters.AddWithValue("@NAME", SecName);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Data Saved Successfully!!');</script>");
        }


        protected void txtYear1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtYear2.Text = (Convert.ToInt16(txtYear1.Text) + 1).ToString();
            }
            catch
            {

            }
        }

        protected void btn80c_Click(object sender, EventArgs e)
        {
            try
            {
                String operation;
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM SAVINGS_SECTIONS$ WHERE NAME='80C'");
                con.Open();
                SqlDataReader rdr = cmd1.ExecuteReader();
                if(rdr.HasRows)
                {
                    operation = "UPDATE";
                }
                else
                {
                    operation = "INSERT";
                }
                con.Close();
                if (operation == "INSERT")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO SAVINGS_SECTIONS$ VALUES ( @NAME, @AMOUNT, @YEAR1, @YEAR2)", con);
                    cmd.Parameters.AddWithValue("@NAME", "80C");
                    cmd.Parameters.AddWithValue("@AMOUNT", txt80c.Text);
                    cmd.Parameters.AddWithValue("@YEAR1", txtYear1.Text);
                    cmd.Parameters.AddWithValue("@YEAR2", txtYear2.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else if(operation=="UPDATE")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE SAVINGS_SECTIONS$ SET AMOUNT=@AMOUNT, YEAR1=@YEAR1,YEAR2= @YEAR2 WHERE NAME=@NAME)", con);
                    cmd.Parameters.AddWithValue("@NAME", "80C");
                    cmd.Parameters.AddWithValue("@AMOUNT", txt80c.Text);
                    cmd.Parameters.AddWithValue("@YEAR1", txtYear1.Text);
                    cmd.Parameters.AddWithValue("@YEAR2", txtYear2.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Response.Write("<script>alert('Data Saved Successfully!!');</script>");
            }
            catch
            {
                Response.Write("<script>alert('Error while Saving Data!!');</script>");
            }
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("SectionsInsertion.aspx");
        }
    }
}
