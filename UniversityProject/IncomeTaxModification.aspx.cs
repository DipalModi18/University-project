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
    public partial class IncomeTaxModification : System.Web.UI.Page
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
                //Char delimiter = '&';
                //String[] substrings = value.Split(delimiter);

                //if (substrings[0].StartsWith("YEAR="))
                //{
                //    substrings[0] = substrings[0].Remove(0, "YEAR1=".Length).Replace('+', ' ').Trim();
                //}
                //if (substrings[1].StartsWith("SLABNO="))
                //{
                //    substrings[1] = substrings[1].Remove(0, "SLABNO=".Length).Replace('+', ' ').Trim();
                //}
                //if (substrings[2].StartsWith("GENDER="))
                //{
                //    substrings[2] = substrings[2].Remove(0, "GENDER=".Length).Replace('+', ' ').Trim();
                //}
                //if (substrings[3].StartsWith("AGEGROUP="))
                //{
                //    substrings[3] = substrings[3].Remove(0, "AGEGROUP=".Length).Replace('+', ' ').Trim();
                //}

                //Int16 Sl = 0, sl;
                //string Gen, Yr, Ag;

                //if (Int16.TryParse(substrings[1], out sl))
                //{
                //    Sl = sl;
                //}
                //Yr = substrings[0];
                //Gen = substrings[2];
                //Ag = substrings[3];

                //Response.Write("<script>alert('YEAR =" + Yr + " SLAB NO=" + Sl + " GENDER=" + Gen + " AGEGROUP=" + Ag + "');</script>");

                string year1 = Request.QueryString["YEAR1"], gender = Request.QueryString["GENDER"], agegroup = Request.QueryString["AGEGROUP"];
                Int16 slabno = Convert.ToInt16(Request.QueryString["SLABNO"]);
                DataSet ds = SelectAllIncomeTaxDataById(year1,slabno ,gender ,agegroup );
                LblYearDis1.Text = year1.ToString();
                LblYearDis2.Text = (Convert.ToInt16(year1)+1).ToString();
                LblSlabNoDis.Text = slabno.ToString();
                LblGenDis.Text = gender;
                LblAgeDis.Text = agegroup.ToString();
                Txtlb.Text = ds.Tables[0].Rows[0]["LOWERBOUND"].ToString();
                TxtUb.Text = ds.Tables[0].Rows[0]["UPPERBOUND"].ToString();
                TxtPecent.Text = ds.Tables[0].Rows[0]["PERCENTAGE"].ToString();
                txtEducess.Text = ds.Tables[0].Rows[0]["EDU_CESS"].ToString();
                txtHigherEducess.Text = ds.Tables[0].Rows[0]["HIGHER_EDUCESS"].ToString();
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

        public DataSet SelectAllIncomeTaxDataById(String Yr, Int16 Sl, string Gen, String Ag)
        {
            //SqlConnection con = null;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
            DataSet ds = null;
            con.Open();
            // Response.Write("<script>alert(' Year =" + Yr + " SlabNo=" + Sl + " Gender=" + Gen + " AgeGroup=" + Ag + "');</script>");
            SqlCommand cmd = new SqlCommand("select * from INCOMETAXSLAB where YEAR1=@YEAR1 and SLABNO=@SLABNO and GENDER=@GENDER and AGEGROUP=@AGEGROUP", con);
            cmd.Parameters.AddWithValue("YEAR1", Yr);
            cmd.Parameters.AddWithValue("SLABNO", Sl);
            cmd.Parameters.AddWithValue("GENDER", Gen);
            cmd.Parameters.AddWithValue("AGEGROUP", Ag);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Txtlb.Text) >= Convert.ToInt32(TxtUb.Text))
            {
                Txtlb.Text = "0";
                TxtUb.Text = "0";
                Response.Write("<script>alert('Lower Bound Value Must Be Smaller Than Upper BOund.');</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update INCOMETAXSLAB set LOWERBOUND=@LOWERBOUND, UPPERBOUND=@UPPERBOUND, PERCENTAGE=@PERCENTAGE, YEAR2=@YEAR2, EDU_CESS=@EDU_CESS, HIGHER_EDUCESS=HIGHER_EDUCESS where YEAR1=@YEAR1 and SLABNO=@SLABNO and GENDER=@GENDER and AGEGROUP=@AGEGROUP", con);
                cmd.Parameters.AddWithValue("@LOWERBOUND", Txtlb.Text);
                cmd.Parameters.AddWithValue("@UPPERBOUND", TxtUb.Text);
                cmd.Parameters.AddWithValue("@PERCENTAGE", TxtPecent.Text);
                cmd.Parameters.AddWithValue("@YEAR2", LblYearDis2.Text);
                cmd.Parameters.AddWithValue("YEAR1", LblYearDis1.Text);
                cmd.Parameters.AddWithValue("GENDER", LblGenDis.Text);
                cmd.Parameters.AddWithValue("AGEGROUP", LblAgeDis.Text);
                cmd.Parameters.AddWithValue("SLABNO", LblSlabNoDis.Text);
                cmd.Parameters.AddWithValue("EDU_CESS", txtEducess.Text);
                cmd.Parameters.AddWithValue("HIGHER_EDUCESS", txtHigherEducess.Text);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Income Tax Data Updated Successfully!!');</script>");
                Response.Redirect("IncomeTaxSearch.aspx");
            }

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncomeTaxSearch.aspx");
        }
    }
}