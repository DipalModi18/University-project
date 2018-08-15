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
    public partial class SalarySearch : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if(!IsPostBack)
            {
                bindMonth();
                bindYear();
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

        protected void LinkButtonAddNem_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalaryInformation.aspx");
        }


        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            string str = "";
            if (Session["User_Id"].ToString() == (100).ToString())
            {
                str = "";
            }
            else
            {
                str = " and EMPNO in (select EMPNO from EMP_PROFILE$ where FACID=" + Session["User_Id"].ToString() + ")";
            }


            if ((TxtEmpid.Text == "" || TxtEmpid.Text==null) && DropDownListMonth.SelectedIndex <= 0 && DropDownListYear.SelectedIndex <= 0)
            {
                //nothing
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
                    SqlCommand cmd = new SqlCommand("select * from PAY_SLIP$" + str, con);
                    SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    dataAdapt.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                }
            }
            else if (!(TxtEmpid.Text == "" || TxtEmpid.Text == null) && DropDownListMonth.SelectedIndex > 0 && DropDownListYear.SelectedIndex > 0)
            {
                //all three
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PAY_SLIP$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR" + str, con);
                    cmd.Parameters.AddWithValue("EMPNO", TxtEmpid.Text);
                    cmd.Parameters.AddWithValue("MONTH", DropDownListMonth.SelectedValue);
                    cmd.Parameters.AddWithValue("YEAR", DropDownListYear.SelectedValue);
                    SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    dataAdapt.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                }
            }
            else if (!(TxtEmpid.Text == "" || TxtEmpid.Text==null) && DropDownListMonth.SelectedIndex > 0 && DropDownListYear.SelectedIndex <= 0)
            {
                //empno and month
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PAY_SLIP$ where EMPNO=@EMPNO and MONTH=@MONTH" + str, con);
                    cmd.Parameters.AddWithValue("EMPNO", TxtEmpid.Text);
                    cmd.Parameters.AddWithValue("MONTH", DropDownListMonth.SelectedValue);
                    SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    dataAdapt.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                }
            }
            else if (!(TxtEmpid.Text == "" || TxtEmpid.Text == null) && DropDownListMonth.SelectedIndex <= 0 && DropDownListYear.SelectedIndex > 0)
            {
                //empno and year
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PAY_SLIP$ where EMPNO=@EMPNO and YEAR=@YEAR" + str, con);
                    cmd.Parameters.AddWithValue("EMPNO", TxtEmpid.Text);
                    cmd.Parameters.AddWithValue("YEAR", DropDownListYear.SelectedValue);
                    SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    dataAdapt.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                }
            }
            else if ((TxtEmpid.Text == "" || TxtEmpid.Text==null) && DropDownListMonth.SelectedIndex > 0 && DropDownListYear.SelectedIndex > 0)
            {
                //month and year
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PAY_SLIP$ where MONTH=@MONTH and YEAR=@YEAR" + str, con);
                    cmd.Parameters.AddWithValue("MONTH", DropDownListMonth.SelectedValue);
                    cmd.Parameters.AddWithValue("YEAR", DropDownListYear.SelectedValue);
                    SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    dataAdapt.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                }
            }
            else if(!(TxtEmpid.Text == "" || TxtEmpid.Text == null) && DropDownListMonth.SelectedIndex <= 0 && DropDownListYear.SelectedIndex <= 0)
            {
                //empno
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PAY_SLIP$ where EMPNO=@EMPNO" + str, con);
                    cmd.Parameters.AddWithValue("EMPNO", TxtEmpid.Text);
                    SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    dataAdapt.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                }
            }
            else if ((TxtEmpid.Text == "" || TxtEmpid.Text == null) && DropDownListMonth.SelectedIndex > 0 && DropDownListYear.SelectedIndex <= 0)
            {
                //month
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PAY_SLIP$ where MONTH=@MONTH" + str, con);
                    cmd.Parameters.AddWithValue("MONTH", DropDownListMonth.SelectedValue);
                    SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    dataAdapt.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                }
            }
            else if ((TxtEmpid.Text == "" || TxtEmpid.Text == null) && DropDownListMonth.SelectedIndex <= 0 && DropDownListYear.SelectedIndex > 0)
            {
                //year
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PAY_SLIP$ where YEAR=@YEAR" + str, con);
                    cmd.Parameters.AddWithValue("YEAR", DropDownListYear.SelectedValue);
                    SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    dataAdapt.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                }
            }
        }

        public void bindYear()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Distinct YEAR from PAY_SLIP$", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandTimeout = 120;
                da.Fill(dt);
                con.Close();
                DropDownListYear.DataSource = dt;
                DropDownListYear.DataValueField = "YEAR";
                DropDownListYear.DataBind();
                DropDownListYear.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Year');</script>");
            }
        }

        public void bindMonth()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Distinct MONTH from PAY_SLIP$", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandTimeout = 120;
                da.Fill(dt);
                con.Close();
                DropDownListMonth.DataSource = dt;
                DropDownListMonth.DataValueField = "MONTH";
                DropDownListMonth.DataBind();
                DropDownListMonth.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Month');</script>");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                int isdeleted = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    var chkdel = row.FindControl("CheckBoxDelete") as CheckBox;
                    if (chkdel.Checked)
                    {
                        var empno = GridView1.Rows[row.RowIndex].Cells[1].Text;
                        var month = GridView1.Rows[row.RowIndex].Cells[3].Text;
                        var year = GridView1.Rows[row.RowIndex].Cells[4].Text;
                        SqlCommand cmd = new SqlCommand("delete from PAY_SLIP$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                        cmd.Parameters.AddWithValue("EMPNO", empno);
                        cmd.Parameters.AddWithValue("MONTH", month);
                        cmd.Parameters.AddWithValue("YEAR", year);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        isdeleted = 1;
                    }
                }
                if (isdeleted == 1)
                {
                    Response.Write("<script>alert('Records Deleted Successfully!!');</script>");
                    ButtonSearch_Click(null, EventArgs.Empty);
                }
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Deleting Data');</script>");
            }
            //Response.Redirect("SalarySearch.aspx");
            //ButtonSearch_Click(null, EventArgs.Empty);
        }
    }
}