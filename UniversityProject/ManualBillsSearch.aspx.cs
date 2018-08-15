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
    public partial class ManualBillsSearch : System.Web.UI.Page
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            String str = "";
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
                //Three nothing
                if (Session["User_Id"].ToString() == (100).ToString())
                {
                    str = "";
                }
                else
                {
                    str = " where EMPNO in (select EMPNO from EMP_PROFILE$ where FACID=" + Session["User_Id"].ToString() + ")";
                }
                //Response.Write("<script>alert('Please insert data atleast in one textbox or dropdown list!!');</script>");
                //Response.Write("<script language='javascript'>window.location='ManualBillsSearch.aspx';</script>");
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from MANUAL_BILLS$" + str, con);
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
            if (!(TxtEmpid.Text == "" || TxtEmpid.Text==null) && DropDownListMonth.SelectedIndex > 0 && DropDownListYear.SelectedIndex > 0)
            {
                //All three are there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from MANUAL_BILLS$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR" + str, con);
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
            if (!(TxtEmpid.Text == "" || TxtEmpid.Text==null) && DropDownListMonth.SelectedIndex > 0 && DropDownListYear.SelectedIndex <= 0)
            {
                //EMpid and month, no year
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from MANUAL_BILLS$ where EMPNO=@EMPNO and MONTH=@MONTH" + str, con);
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
            if (!(TxtEmpid.Text == "" || TxtEmpid.Text==null) && DropDownListMonth.SelectedIndex <= 0 && DropDownListYear.SelectedIndex > 0)
            {
                //Empno and year, no month
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from MANUAL_BILLS$ where EMPNO=@EMPNO and YEAR=@YEAR" + str, con);
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
            if ((TxtEmpid.Text == "" || TxtEmpid.Text==null) && DropDownListMonth.SelectedIndex > 0 && DropDownListYear.SelectedIndex > 0)
            {
                // month and year , no empno
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from MANUAL_BILLS$ where MONTH=@MONTH and YEAR=@YEAR" + str, con);
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
                //Only Empno
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from MANUAL_BILLS$ where EMPNO=@EMPNO" + str, con);
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
            else if((TxtEmpid.Text == "" || TxtEmpid.Text == null) && DropDownListMonth.SelectedIndex > 0 && DropDownListYear.SelectedIndex <= 0)
            {
                //only month
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from MANUAL_BILLS$ where MONTH=@MONTH" + str, con);
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
            else if((TxtEmpid.Text == "" || TxtEmpid.Text == null) && DropDownListMonth.SelectedIndex <= 0 && DropDownListYear.SelectedIndex > 0)
            {
                //only year
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from MANUAL_BILLS$ where YEAR=@YEAR" + str, con);
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

        protected void LinkButtonAddNem_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManualBillsInsertion.aspx");
        }

         public void bindYear()
         {
             DataTable dt = new DataTable();
             SqlCommand cmd = new SqlCommand("Select Distinct YEAR from MANUAL_BILLS$", con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             cmd.CommandTimeout = 120;
             da.Fill(dt);
             con.Close();
             DropDownListYear.DataSource = dt;
             DropDownListYear.DataValueField = "YEAR";
             DropDownListYear.DataBind();
             DropDownListYear.Items.Insert(0, new ListItem("Select", ""));
         }
        public void bindMonth()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select Distinct MONTH from MANUAL_BILLS$", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandTimeout = 120;
            da.Fill(dt);
            con.Close();
            DropDownListMonth.DataSource = dt;
            DropDownListMonth.DataValueField = "MONTH";
            DropDownListMonth.DataBind();
            DropDownListMonth.Items.Insert(0, new ListItem("Select", ""));
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            int isdeleted = 0;
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    var chkdel = row.FindControl("CheckBoxDelete") as CheckBox;
                    if (chkdel.Checked)
                    {
                        var empno = GridView1.Rows[row.RowIndex].Cells[1].Text;
                        var month = GridView1.Rows[row.RowIndex].Cells[3].Text;
                        var year = GridView1.Rows[row.RowIndex].Cells[4].Text;
                        SqlCommand cmd = new SqlCommand("delete from MANUAL_BILLS$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                        cmd.Parameters.AddWithValue("EMPNO", empno);
                        cmd.Parameters.AddWithValue("MONTH", month);
                        cmd.Parameters.AddWithValue("YEAR", year);
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
                Response.Write("<script>alert('Error While Deleting');</script>");
            }
            if (isdeleted == 1)
            {
                Response.Write("<script>alert('Records Deleted Successfully!!');</script>");
                ButtonSearch_Click(null, EventArgs.Empty);
            }
            
        }
    }
}