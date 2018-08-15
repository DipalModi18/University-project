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
    public partial class EmployeeArrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                bindMonth();
                bindYear();

                /*DataSet ds = SelectEmpArrearByIdMonthYear(0, DropDownListMonth.SelectedValue, DropDownListYear.SelectedValue);
                GridView1.DataSource = ds;
                GridView1.DataBind();*/
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

        public void bindMonth()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Distinct MONTH from EMP_ARREAR$", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandTimeout = 120;
                da.Fill(dt);
                con.Close();
                DropDownListMonth.DataSource = dt;
                DropDownListMonth.DataValueField = "MONTH";
                DropDownListMonth.DataBind();
                DropDownListMonth.Items.Insert(0, new ListItem("Select", ""));
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Month!!');</script>");
            }
        }

        public void bindYear()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Distinct YEAR from EMP_ARREAR$", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandTimeout = 120;
                da.Fill(dt);
                con.Close();
                DropDownListYear.DataSource = dt;
                DropDownListYear.DataValueField = "YEAR";
                DropDownListYear.DataBind();
                DropDownListYear.Items.Insert(0, new ListItem("Select", ""));
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Year!!');</script>");
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (TextBoxEmployeeID.Text == "" || TextBoxEmployeeID.Text == null)
            {
                ds = SelectEmpArrearByIdMonthYear(0, DropDownListMonth.SelectedValue, DropDownListYear.SelectedValue);
            }
            else
            {
                ds = SelectEmpArrearByIdMonthYear(Convert.ToInt16(TextBoxEmployeeID.Text), DropDownListMonth.SelectedValue, DropDownListYear.SelectedValue);
            }

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        public DataSet SelectEmpArrearByIdMonthYear(int? empid, string month, string year)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlDataAdapter da = new SqlDataAdapter();
            String str = "";
            if (Session["User_Id"].ToString() == (100).ToString())
            {
                str = "";
            }
            else
            {
                str = " and EMPNO in (select EMPNO from EMP_PROFILE$ where FACID=" + Session["User_Id"].ToString() + ")";
            }


            if ((empid == null || empid == 0) && (month == "Select" || month == "" || month == null) && (year == "Select" || year == "" || year == null))
            {
                // three of them are having no value
                if (Session["User_Id"].ToString() == (100).ToString())
                {
                    str = "";
                }
                else
                {
                    str = " where EMPNO in (select EMPNO from EMP_PROFILE$ where FACID=" + Session["User_Id"].ToString() + ")";
                }
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from EMP_ARREAR$" + str, con);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    Label1.Text = "Emp id :" + empid + " Month :" + month + " Year=" + year + " three of them are having no value";
                }
                catch(Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data!!');</script>");
                    return ds;
                }
            }
            else if (!(empid == null || empid == 0) && !(month == "Select" || month == "" || month == null) && !(year == "Select" || year == "" || year == null))
            {
                //three of them having some value
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from EMP_ARREAR$ where EMPNO=@Empid and MONTH=@Month and YEAR=@Year" + str, con);
                    cmd.Parameters.AddWithValue("Empid", empid);
                    cmd.Parameters.AddWithValue("Month", month);
                    cmd.Parameters.AddWithValue("Year", year);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    Label1.Text = "Emp id :" + empid + " Month :" + month + " Year=" + year + " three of them having some value";
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data!!');</script>");
                    return ds;
                }
            }
            else if (!(empid == null || empid == 0) && (month == "Select" || month == "" || month == null) && (year == "Select" || year == "" || year == null))
            {
                //only employee id is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from EMP_ARREAR$ where EMPNO=@Empid" + str, con);
                    cmd.Parameters.AddWithValue("Empid", empid);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    Label1.Text = "Emp id :" + empid + " Month :" + month + " Year=" + year + " only employee id is there";
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data!!');</script>");
                    return ds;
                }
            }
            else if (!(empid == null || empid == 0) && (month == "Select" || month == "" || month == null) && !(year == "Select" || year == "" || year == null))
            {
                //employee id and year is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from EMP_ARREAR$  where EMPNO=@Empid and YEAR=@Year" + str, con);
                    cmd.Parameters.AddWithValue("Empid", empid);
                    cmd.Parameters.AddWithValue("Year", year);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    Label1.Text = "Emp id :" + empid + " Month :" + month + " Year=" + year + " employee id and year is there";
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data!!');</script>");
                    return ds;
                }
            }
            else if (!(empid == null || empid == 0) && !(month == "Select" || month == "" || month == null) && (year == "Select" || year == "" || year != null))
            {
                // employee id and month is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from EMP_ARREAR$  where EMPNO=@Empid and MONTH=@Month" + str, con);
                    cmd.Parameters.AddWithValue("Empid", empid);
                    cmd.Parameters.AddWithValue("Month", month);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    Label1.Text = "Emp id :" + empid + " Month :" + month + " Year=" + year + " employee id and month is there";
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data!!');</script>");
                    return ds;
                }
            }
            else if ((empid == null || empid == 0) && !(month == "Select" || month == "" || month==null) && !(year == "Select" || year=="" || year==null))
            {
                //only month and year is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from EMP_ARREAR$  where MONTH=@Month and YEAR=@Year" + str, con);
                    cmd.Parameters.AddWithValue("Month", month);
                    cmd.Parameters.AddWithValue("Year", year);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    Label1.Text = "Emp id :" + empid + " Month :" + month + " Year=" + year + " only month and year is there";
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data!!');</script>");
                    return ds;
                }
            }
            else if ((empid == null || empid == 0) && (month == "Select" || month=="" || month==null) && !(year == "Select" || year=="" || year==null))
            {
                // only year is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from EMP_ARREAR$  where YEAR=@Year" + str, con);
                    cmd.Parameters.AddWithValue("Year", year);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    Label1.Text = "Emp id :" + empid + " Month :" + month + " Year=" + year + " only year is there";
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data!!');</script>");
                    return ds;
                }
            }
            else
            {
                // only month is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from EMP_ARREAR$  where MONTH=@Month" + str, con);
                    cmd.Parameters.AddWithValue("Month", month);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    Label1.Text = "Emp id :" + empid + " Month :" + month + " Year=" + year + "  only month is there";
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data!!');</script>");
                    return ds;
                }
            }
            return ds;
        }

        public void load_gridView()
        {
            String str = "";
            if (Session["User_Id"].ToString() == (100).ToString())
            {
                str = "";
            }
            else
            {
                str = " where EMPNO in (select EMPNO from EMP_PROFILE$ where FACID=" + Session["User_Id"].ToString() + ")";
            }

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("select * from EMP_ARREAR$"+str, con);
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Loading Gridview!!');</script>");
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
                        var Empid = GridView1.Rows[row.RowIndex].Cells[1].Text;
                        var Month = GridView1.Rows[row.RowIndex].Cells[5].Text;
                        var year = GridView1.Rows[row.RowIndex].Cells[6].Text;
                        //<script>alert('No Record Found!!');</script>
                        /*Response.Write("<script>DeleteConfirm(" + facid + ")</script>");
                        string Confirmation = Request.Form["confirm_value"];
                        if (Confirmation == "yes")
                        {*/
                        SqlCommand cmd = new SqlCommand("delete from EMP_ARREAR$ where EMPNO=@EMPNO and MONTH=@MONTH AND YEAR=@YEAR", con);
                        cmd.Parameters.AddWithValue("EMPNO", Empid);
                        cmd.Parameters.AddWithValue("MONTH", Month);
                        cmd.Parameters.AddWithValue("YEAR", year);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        isdeleted = 1;
                        /*}
                        else
                        {

                        }*/
                    }
                }
            }
            catch(Exception ee)
            {
                isdeleted = 0;
                Response.Write("<script>alert('Error While Deleting Records!!');</script>");
            }
            if(isdeleted==1)
            {
                Response.Write("<script>alert('Records Deleted Successfully!!');</script>");
            }
            load_gridView();
        }

       
    }
}