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
    public partial class DepartmentInsertion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                bindFacultyType();
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

        public void bindFacultyType()
        {
            String str = "";
            if (Session["User_Id"].ToString() == (100).ToString())
            {
                str = "";
            }
            else
            {
                str = " where FACID=" + Session["User_Id"].ToString();
            }

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Distinct FACID from FACULTY_PROFILE$"+str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                Ddlfacultyid.DataSource = dt;
                Ddlfacultyid.DataValueField = "FACID";
                Ddlfacultyid.DataBind();
                Ddlfacultyid.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Faculty');</script>");
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            try
            {
                con.Open();
                cmd = new SqlCommand("select DEPTNO from DEPT_PROFILE$ where DEPTNO=@DEPTNO", con);
                cmd.Parameters.AddWithValue("DEPTNO", txtdptid.Text);
                var no = cmd.ExecuteScalar();
                con.Close();
                if (no != null)
                {
                    Response.Write("<script>alert('Department number already exsists');</script>");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("Insert into DEPT_PROFILE$ values(@DEPTNO, @DEPTNAME, @FACID, @ABBRE, @ADDR1, @ADDR2, @CITY, @PINCODE, @PHONE, @FAX, @HOD)", con);
                    cmd.Parameters.AddWithValue("@DEPTNO", txtdptid.Text);
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
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //Response.Write("<script>alert('Department Added Successfully!!');</script>");
                    // Response.Write("<script language='javascript'>window.location='Department.aspx';</script>");
                    // Response.Redirect("Department.aspx");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data saved sucessfully');window.location ='Department.aspx';", true);

                }
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Saving Data!!');</script>");
            }
        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            /*txtdptid.Text = null;
            Txtdptname.Text = null;
            Ddlfacultyid.SelectedIndex = 0;
            Txtabbreviation.Text = null;
            Txtaddr1.Text = null;
            Txtaddr2.Text = null;
            Txtpincode.Text = null;
            Txtphone.Text = null;
            txtfax.Text = null;
            Txthod.Text = null;*/
            Response.Redirect("Department.aspx");
        }

        protected void Ddlfacultyid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd = new SqlCommand("select FACNAME from FACULTY_PROFILE$ where FACID=@FACID", con);
                cmd.Parameters.AddWithValue("@FACID", Ddlfacultyid.SelectedValue);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblFacName.Text = rdr["FACNAME"].ToString();
                }
                con.Close();
            }
            catch(Exception ee)
            {

            }
        }
    }
}