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
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!Page.IsPostBack)
            {
                /*try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                    SqlCommand cmd;
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    if(Session["User_Id"].ToString()==(100).ToString())
                    {
                        cmd = new SqlCommand("select * from DEPT_PROFILE$", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("select * from DEPT_PROFILE$ where FACID=@FACID", con);
                        cmd.Parameters.AddWithValue("@FACID", Session["User_Id"].ToString());
                    }
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    con.Close();
                }
                catch(Exception ee)
                {

                }*/
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


        protected void LinkButtonLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Departmentinsertion.aspx");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TxtDeptId.Text == null || TxtDeptId.Text=="")
            {
                DataSet ds = SelectAllDeptDataByIdName(0, TxtDeptlName.Text);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                DataSet ds = SelectAllDeptDataByIdName(Convert.ToInt16(TxtDeptId.Text.ToString()), TxtDeptlName.Text);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        public DataSet SelectAllDeptDataByIdName(int? id, string name)
        {
            String str = "";
            if(Session["User_Id"].ToString() == (100).ToString())
            {
                str = "";
            }
            else
            {
                str = " and FACID=" + Session["User_Id"].ToString();
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
            DataSet ds = null;
            if ((id == 0 || id == null) && (name == null || name == ""))
            {
                //both fields empty
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
                    SqlCommand cmd = new SqlCommand("select * from DEPT_PROFILE$" + str, con);
                    //Response.Write("<script>alert('select * from DEPT_PROFILE$" + str+"');</script>");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch(Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Data');</script>");
                    return new DataSet();
                }
            }
            else if ((id == 0 || id == null) && !(name == null || name == ""))
            {
                //id null but name not null
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from DEPT_PROFILE$ where DEPTNAME like '%'+@DEPTNAME+'%'" + str, con);
                    //Response.Write("<script>alert('select * from DEPT_PROFILE$ where DEPTNAME like '%'+@DEPTNAME+'%'" + str + "');</script>");
                    cmd.Parameters.AddWithValue("DEPTNAME", name);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Data');</script>");
                    return new DataSet();
                }
            }
            else if (!(id == 0 || id == null) && (name == null || name == ""))
            {
                //id not null but name has something
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from DEPT_PROFILE$ where DEPTNO=@DEPTNO" + str, con);
                    //Response.Write("<script>alert('select * from DEPT_PROFILE$ where DEPTNO=@DEPTNO" + str+"');</script>");
                    cmd.Parameters.AddWithValue("DEPTNO", id);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Data');</script>");
                    return new DataSet();
                }
            }
            else
            {
                //both has something
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from DEPT_PROFILE$ where DEPTNO=@DEPTNO AND DEPTNAME like '%'+@DEPTNAME+'%'" + str, con);
                    //Response.Write("<script>alert('select * from DEPT_PROFILE$ where DEPTNO=@DEPTNO AND DEPTNAME like '%'+@DEPTNAME+'%'" + str+"');</script>");
                    cmd.Parameters.AddWithValue("DEPTNO", id);
                    cmd.Parameters.AddWithValue("DEPTNAME", name);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Data');</script>");
                    return new DataSet();
                }
            }

        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int isdeleted = 0;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                foreach (GridViewRow row in GridView1.Rows)
                {
                    var chkdel = row.FindControl("CheckBoxDelete") as CheckBox;
                    if (chkdel.Checked)
                    {
                        var deptno = GridView1.Rows[row.RowIndex].Cells[1].Text;
                        SqlCommand cmd = new SqlCommand("delete from DEPT_PROFILE$ where DEPTNO=@deptno", con);
                        cmd.Parameters.AddWithValue("deptno", deptno);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        isdeleted = 1;
                    }
                }
            }
            catch (Exception ee)
            {
                isdeleted = 0;
                Response.Write("<script>alert('Error While Deleting Data');</script>");
            }
            if (isdeleted == 1)
            {
                Response.Write("<script>alert('Records Deleted Successfully!!');</script>");
            }
            load_gridview();
        }

        public void load_gridview()
        {
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("select * from DEPT_PROFILE$", con);
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ee)
            {
                
            }
        }

      
    }
}