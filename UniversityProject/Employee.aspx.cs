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
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                //ddlDeptName.Items.Insert(0, new ListItem("Select", ""));
                BindDeptName();
                //load_gridview();
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

        public void BindDeptName()
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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("Select Distinct DEPTNAME from DEPT_PROFILE$" + str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandTimeout = 120;
                da.Fill(ds);
                con.Close();
                ddlDeptName.DataSource = ds;
                ddlDeptName.DataBind();
                ddlDeptName.Items.Insert(0, new ListItem("Select", ""));
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Department Name!!');</script>");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int isdeleted = 0;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                foreach (GridViewRow row in GridView1.Rows)
                {
                    var chkdel = row.FindControl("CheckBoxDelete") as CheckBox;
                    if (chkdel.Checked)
                    {
                        var empno = GridView1.Rows[row.RowIndex].Cells[1].Text;
                        SqlCommand cmd = new SqlCommand("delete from EMP_PROFILE$ where EMPNO=@EMPNO", con);
                        cmd.Parameters.AddWithValue("EMPNO", empno);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        isdeleted = 1;
                    }
                }
            }
            catch(Exception ee)
            {
                isdeleted = 0;
                Response.Write("<script>alert('Error While Deleting Records!!');</script>");
            }
            if (isdeleted == 1)
            {
                Response.Write("<script>alert('Records Deleted Successfully!!');</script>");
            }
            load_gridview();
        }

        public void load_gridview()
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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                //SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("select * from EMP_PROFILE$"+str, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Fetching Records!!');</script>");
            }
        }

        public bool AllowSearch()
        {
            if((txtEmployeeId.Text==null || txtEmployeeId.Text=="") && (txtEmployeeName.Text==null || txtEmployeeName.Text=="") && ddlDeptName.SelectedIndex==0)
            {
                Response.Write("<script>alert('Please enter any search criteria!!');</script>");
                return false;
            }
            return true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (AllowSearch())
            //{
                Int16 EmpId;
                string EmpName;
                string DeptName;

                if (txtEmployeeId.Text == "")
                {
                    EmpId = 0;
                }
                else
                {
                    EmpId = Convert.ToInt16(txtEmployeeId.Text);
                }
                EmpName = txtEmployeeName.Text;
                DeptName = ddlDeptName.SelectedValue;
                Label1.Text = "EMPLOYEE ID :" + EmpId + " EMPNAME:" + EmpName + " DEPTNAME :" + DeptName;
                DataSet ds = SelectEmployeeByIdNameDept(EmpId, EmpName, DeptName);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            //}
        }

        public DataSet SelectEmployeeByIdNameDept(Int16? EmpId, string EmpName, string DeptName)
        {
            String str = "";
            if (Session["User_Id"].ToString() == (100).ToString())
            {
                str = "";
            }
            else
            {
                str = " and FACID=" + Session["User_Id"].ToString();
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;
            DataSet ds = new DataSet();
            Int16 DeptNo;
            if (DeptName == "Select" || DeptName=="" || DeptName==null)
            {
                DeptNo = 0;
            }
            else
            {
                cmd = new SqlCommand("select DEPTNO from DEPT_PROFILE$ where DEPTNAME=@DEPTNAME", con);
                cmd.Parameters.AddWithValue("DEPTNAME", DeptName);
                con.Open();
                DeptNo = Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();
            }

            Label2.Text = "EMPLOYEE ID :" + EmpId + " EMPNAME:" + EmpName + " DEPTNO :"+DeptNo;

            if (!(EmpId == 0 || EmpId == null) && !(EmpName == null || EmpName == "") && !(DeptNo==0))
            {
                // three has something
                try
                {
                    cmd = new SqlCommand("select * from EMP_PROFILE$ where EMPNO=@EMPNO and EMPNAME like'%'+@EMPNAME+'%' and DEPTNO=@DEPTNO" + str, con);
                    cmd.Parameters.AddWithValue("EMPNO", EmpId);
                    cmd.Parameters.AddWithValue("EMPNAME", EmpName);
                    cmd.Parameters.AddWithValue("DEPTNO", DeptNo);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch(Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Records!!');</script>");
                }
            }
            else if (!(EmpId == 0 || EmpId == null) && !(EmpName == null || EmpName == "") && (DeptNo==0))
            {
                //Employee id and name is there , not dept name
                try
                {
                    cmd = new SqlCommand("select * from EMP_PROFILE$ where EMPNO=@EMPNO and EMPNAME like '%'+@EMPNAME+'%'" + str, con);
                    cmd.Parameters.AddWithValue("EMPNO", EmpId);
                    cmd.Parameters.AddWithValue("EMPNAME", EmpName);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Records!!');</script>");
                }
            }
            else if (!(EmpId == 0 || EmpId == null) && (EmpName == null || EmpName == "") && (DeptNo==0))
            {
                //Employee id is there only
                try
                {
                    cmd = new SqlCommand("select * from EMP_PROFILE$ where EMPNO=@EMPNO" + str, con);
                    cmd.Parameters.AddWithValue("EMPNO", EmpId);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Records!!');</script>");
                }
            }
            else if ((EmpId == 0 || EmpId == null) && !(EmpName == null || EmpName == "") && (DeptNo==0))
            {
                //Only Employee name is there
                try
                {
                    cmd = new SqlCommand("select * from EMP_PROFILE$ where EMPNAME like '%'+@EMPNAME+'%'" + str, con);
                    cmd.Parameters.AddWithValue("EMPNAME", EmpName);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Records!!');</script>");
                }
            }
            else if ((EmpId == 0 || EmpId == null) && (EmpName == null || EmpName == "") && !(DeptNo==0))
            {
                // only dept name is there
                try
                {
                    cmd = new SqlCommand("select * from EMP_PROFILE$ where DEPTNO=@DEPTNO" + str, con);
                    cmd.Parameters.AddWithValue("DEPTNO", DeptNo);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Records!!');</script>");
                }
            }
            else if (!(EmpId == 0 || EmpId == null) && (EmpName == null || EmpName == "") && !(DeptNo==0))
            {
                // only empid and deptname is there
                try
                {
                    cmd = new SqlCommand("select * from EMP_PROFILE$ where EMPNO=@EMPNO and DEPTNO=@DEPTNO" + str, con);
                    cmd.Parameters.AddWithValue("EMPNO", EmpId);
                    cmd.Parameters.AddWithValue("DEPTNO", DeptNo);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Records!!');</script>");
                }
            }
            else if ((EmpId == 0 || EmpId == null) && !(EmpName == null || EmpName == "") && !(DeptNo==0))
            {
                //Emp name and dept name is there
                try
                {
                    cmd = new SqlCommand("select * from EMP_PROFILE$ where EMPNAME like '%'+@EMPNAME+'%' and DEPTNO=@DEPTNO" + str, con);
                    cmd.Parameters.AddWithValue("EMPNAME", EmpName);
                    cmd.Parameters.AddWithValue("DEPTNO", DeptNo);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Records!!');</script>");
                }
            }
            else
            {
                // three of there has nothing
                String str1 = "";
                if (Session["User_Id"].ToString() == (100).ToString())
                {
                    str1 = "";
                }
                else
                {
                    str1 = " where FACID=" + Session["User_Id"].ToString();
                }
                try
                {
                    cmd = new SqlCommand("select * from EMP_PROFILE$" + str1, con);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch(Exception ee)
                { 
                    Response.Write("<script>alert('Error While Fetching Records!!');</script>");
                }
            }

            return ds;

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}