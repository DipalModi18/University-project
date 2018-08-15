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
    public partial class IncomeTaxSearch : System.Web.UI.Page
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

        protected void LinkButtonAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncomeTaxInsertion.aspx");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtYear.Text != null)
            {
                DataSet ds = null;
                SqlCommand cmd = new SqlCommand("select * from INCOMETAXSLAB where YEAR1=@YEAR1", con);
                cmd.Parameters.AddWithValue("YEAR1", TxtYear.Text);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Please insert data in textbox!!');</script>");
                Response.Write("<script language='javascript'>window.location='IncomeTaxSearch.aspx';</script>");
            }
        }

        /*protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityData"].ConnectionString);
            foreach (GridViewRow row in GridView1.Rows)
            {
                var chkdel = row.FindControl("CheckBoxDelete") as CheckBox;
                if (chkdel.Checked)
                {
                    var year = GridView1.Rows[row.RowIndex].Cells[1].Text;
                    var slab = GridView1.Rows[row.RowIndex].Cells[2].Text;
                    var gen = GridView1.Rows[row.RowIndex].Cells[3].Text;
                    var age = GridView1.Rows[row.RowIndex].Cells[4].Text;
                    SqlCommand cmd = new SqlCommand("delete from INCOMETAXSLAB where YEAR=@year and SLABNO=@slab and GENDER=@gen and AGEGROUP=@age", con);
                    cmd.Parameters.AddWithValue("year", year);
                    cmd.Parameters.AddWithValue("slab", slab);
                    cmd.Parameters.AddWithValue("gen", gen);
                    cmd.Parameters.AddWithValue("age", age);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            TxtYear.Text = "";
            load_gridview();
        }*/

        public void load_gridview()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("select * from INCOMETAXSLAB", con);
            con.Open();
            da.SelectCommand = cmd;
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncomeTaxInsertion.aspx");
        }
    }
}