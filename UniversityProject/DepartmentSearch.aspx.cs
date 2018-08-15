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
    public partial class DepartmentSearch : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityData"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityData"].ConnectionString);
                SqlCommand cmd;
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("select * from DEPT_PROFILE$", con);
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                //GridView1.DataSource = ds;
                GridView1.DataBind();
                con.Close();
            }
        }

        protected void LinkButtonLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Departmentinsertion.aspx");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtDeptId.Text == null && TxtDeptlName.Text == "")
            {
                DataSet ds = SelectAllDeptDataByIdName(0, TxtDeptlName.Text);
                //GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                DataSet ds = SelectAllDeptDataByIdName(Convert.ToInt16(TxtDeptId.Text.ToString()), TxtDeptlName.Text);
                //GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        public DataSet SelectAllDeptDataByIdName(int? id, string name)
        {
            //SqlConnection con = null;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityData"].ConnectionString);
            DataSet ds = null;
            if ((id == 0 || id == null) && (name == null || name == ""))
            {
                SqlCommand cmd = new SqlCommand("select * from DEPT_PROFILE$", con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            else if ((id == 0 || id == null) && !(name == null || name == ""))
            {
                //id null but name not null
                SqlCommand cmd = new SqlCommand("select * from DEPT_PROFILE$ where DEPTNAME like '%'+@DEPTNAME+'%'", con);
                cmd.Parameters.AddWithValue("DEPTNAME", name);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            else if (!(id == 0 || id == null) && (name == null || name == ""))
            {
                //id not null but name has something
                SqlCommand cmd = new SqlCommand("select * from DEPT_PROFILE$ where DEPTNO=@DEPTNO", con);
                cmd.Parameters.AddWithValue("DEPTNO", id);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            else
            {
                //both has something
                SqlCommand cmd = new SqlCommand("select * from DEPT_PROFILE$ where DEPTNO=@DEPTNO AND DEPTNAME like '%'+@DEPTNAME+'%'", con);
                cmd.Parameters.AddWithValue("DEPTNO", id);
                cmd.Parameters.AddWithValue("DEPTNAME", name);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }
    }
}