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
    public partial class SectionsModification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                String value = Request.QueryString.ToString();
                Char delimiter = '&';
                String[] substrings = value.Split(delimiter);
                //Response.Write("<script>alert('" + value + "');</script>");
                //Response.Write("<script>alert('year=" + substrings[0] + " name=" + substrings[1] + "');</script>");

                if (substrings[0].StartsWith("NUMBER="))
                {
                    substrings[0] = substrings[0].Remove(0, "NUMBER=".Length).Replace('+', ' ').Trim();
                }
                if (substrings[1].StartsWith("NAME="))
                {
                    substrings[1] = substrings[1].Remove(0, "NAME=".Length).Replace('+', ' ').Trim();
                }

                string number, Nm;
                number = substrings[0];
                Nm = substrings[1];
                //Response.Write("<script>alert('YEAR =" + Yr + " NAME=" + Nm + "');</script>");
                DataSet ds = SelectAllSectionData(number, Nm);
                LblYrDis.Text = number.ToString();
                LblNameDis.Text = Nm.ToString();
                TxtAmount.Text = ds.Tables[0].Rows[0]["AMOUNT"].ToString();
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

        public DataSet SelectAllSectionData(String number, String Nm)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
            DataSet ds = null;
            con.Open();
            //Response.Write("<script>alert('YEAR =" + Yr + " NAME=" + Nm + "');</script>");
            SqlCommand cmd = new SqlCommand("select * from SECTIONS where NUMBER=@NUMBER and NAME=@NAME", con);
            cmd.Parameters.AddWithValue("YEAR", number);
            cmd.Parameters.AddWithValue("NAME", Nm);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update SECTIONS set AMOUNT=@AMOUNT where NUMBER=@NUMBER and NAME=@NAME", con);
            Response.Write("<script>alert('amt:" + TxtAmount.Text + " year:" + LblYrDis.Text + "NAme:" + LblNameDis.Text + "');</script>");
            cmd.Parameters.AddWithValue("AMOUNT", TxtAmount.Text);
            cmd.Parameters.AddWithValue("NUMBER", LblYrDis.Text);
            cmd.Parameters.AddWithValue("NAME", LblNameDis.Text);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Section Data Updated Successfully!!');</script>");
            Response.Write("<script language='javascript'>window.location='SectionsSearch.aspx';</script>");
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Response.Redirect("SectionsSearch.aspx");
        }
    }
}