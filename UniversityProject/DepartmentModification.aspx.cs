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
    public partial class DepartmentModification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                try
                {
                    bindFacultyType();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                    var id = Request.QueryString["DEPTNO"];
                    DataSet ds = SelectAllDeptDataById(Convert.ToInt16(id));
                    LblDptidDisplay.Text = id;
                    Txtdptname.Text = ds.Tables[0].Rows[0]["DEPTNAME"].ToString();
                    Ddlfacultyid.SelectedValue = ds.Tables[0].Rows[0]["FACID"].ToString();
                    Txtabbreviation.Text = ds.Tables[0].Rows[0]["ABBRE"].ToString();
                    Txtaddr1.Text = ds.Tables[0].Rows[0]["ADDR1"].ToString();
                    Txtaddr2.Text = ds.Tables[0].Rows[0]["ADDR2"].ToString();
                    Txtcity.Text = ds.Tables[0].Rows[0]["CITY"].ToString();
                    Txtpincode.Text = ds.Tables[0].Rows[0]["PINCODE"].ToString();
                    Txtphone.Text = ds.Tables[0].Rows[0]["PHONE"].ToString();
                    txtfax.Text = ds.Tables[0].Rows[0]["FAX"].ToString();
                    Txthod.Text = ds.Tables[0].Rows[0]["HOD"].ToString();
                    con.Close();
                }
                catch(Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Data!!');</script>");
                }
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

        public DataSet SelectAllDeptDataById(int? id)
        {
            SqlConnection con = null;
            //string result = "";
            DataSet ds = null;
            //  try
            //  {
            if (!(id == 0 || id == null))
            {
                //id not null but name has something
                try
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from DEPT_PROFILE$ where DEPTNO=@DEPTNO", con);
                    cmd.Parameters.AddWithValue("DEPTNO", id);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    return ds;
                }
                catch(Exception ee)
                {
                    return ds;
                }
            }
            else
            {
                return ds;
            }
            // }
            /* catch
             {
                 return ds;
             }
             finally
             {
                 con.Close();
             }*/
        }

        public void bindFacultyType()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Distinct FACID from FACULTY_PROFILE$", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                Ddlfacultyid.DataSource = dt;
                Ddlfacultyid.DataValueField = "FACID";
                Ddlfacultyid.DataBind();
                Ddlfacultyid.Items.Insert(0, new ListItem("Select", ""));
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Faculty!!');</script>");
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update DEPT_PROFILE$ set DEPTNAME=@DEPTNAME, FACID=@FACID, ABBRE=@ABBRE, ADDR1=@ADDR1, ADDR2=@ADDR2, CITY=@CITY, PINCODE=@PINCODE, PHONE=@PHONE, FAX=@FAX, HOD=@HOD where DEPTNO=@DEPTNO", con);
                cmd.Parameters.AddWithValue("@DEPTNO", LblDptidDisplay.Text);
                cmd.Parameters.AddWithValue("@DEPTNAME", Txtdptname.Text);
                cmd.Parameters.AddWithValue("@FACID", Ddlfacultyid.SelectedValue);
                cmd.Parameters.AddWithValue("@ABBRE", Txtabbreviation.Text);
                cmd.Parameters.AddWithValue("@ADDR1", Txtaddr1.Text);
                cmd.Parameters.AddWithValue("@ADDR2", Txtaddr2.Text);
                cmd.Parameters.AddWithValue("@CITY", Txtcity.Text);
                cmd.Parameters.AddWithValue("@PINCODE", Txtpincode.Text);
                cmd.Parameters.AddWithValue("@PHONE", Txtphone.Text);
                cmd.Parameters.AddWithValue("@FAX", txtfax.Text);
                cmd.Parameters.AddWithValue("@HOD", Txthod.Text);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Department Updated Successfully!!');</script>");
                Response.Write("<script language='javascript'>window.location='Department.aspx';</script>");
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Saving Data!!');</script>");
            }
        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Department.aspx");
        }

        protected void Ddlfacultyid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                SqlCommand cmd = new SqlCommand("select FACNAME from FACULTY_PROFILE$ where FACID=@FACID", con);
                cmd.Parameters.AddWithValue("@FACID", Ddlfacultyid.SelectedValue);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblFacName.Text = rdr["FACNAME"].ToString();
                }
                con.Close();
            }
            catch (Exception ee)
            {

            }
        }
    }
}