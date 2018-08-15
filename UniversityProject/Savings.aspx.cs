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
    public partial class Savings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                //load_gridview();
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

        public void bindYear()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Distinct SAVING_YEAR from SAVINGS$", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandTimeout = 120;
                da.Fill(dt);
                con.Close();
                ddlSavingYear.DataSource = dt;
                ddlSavingYear.DataBind();
                ddlSavingYear.Items.Insert(0, new ListItem("Select", ""));
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Year!!');</script>");
            }
        }

        public void load_gridview()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                //SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("select * from SAVINGS$", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
                rdr.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Fetching Data!!');</script>");
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Int16? empno, year;
            if (txtEmpNo.Text=="" || txtEmpNo.Text==null)
            {
                empno = 0;
            }
            else
            {
                empno= Convert.ToInt16(txtEmpNo.Text);
            }
            if(ddlSavingYear.SelectedIndex==0 || ddlSavingYear.SelectedIndex==-1)
            {
                year = 0;
            }
            else
            {
                year= Convert.ToInt16(ddlSavingYear.SelectedValue);
            }
            DataSet ds = SelectSavingByNoYear(empno, year);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        public DataSet SelectSavingByNoYear(Int16? empno,Int16? year)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;
            DataSet ds = new DataSet();

            String str = "";
            if (Session["User_Id"].ToString() == (100).ToString())
            {
                str = "";
            }
            else
            {
                str = " and EMPNO in (select EMPNO from EMP_PROFILE$ where FACID=" + Session["User_Id"].ToString() + ")";
            }

            if (!(empno == 0 || empno == null) && !(year == 0 || year == null))
            {
                // Employee id and year is there
                try
                {
                    cmd = new SqlCommand("select * from SAVINGS$ where EMPNO=@EMPNO and SAVING_YEAR=@SAVING_YEAR" + str, con);
                    cmd.Parameters.AddWithValue("EMPNO", empno);
                    cmd.Parameters.AddWithValue("SAVING_YEAR", year);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                    return new DataSet();
                }
            }
            else if (!(empno == 0 || empno == null) && (year == 0 || year==null))
            {
                //Employee id is there , not year
                try
                {
                    cmd = new SqlCommand("select * from SAVINGS$ where EMPNO=@EMPNO" + str, con);
                    cmd.Parameters.AddWithValue("EMPNO", empno);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                    return new DataSet();
                }
            }
            else if ((empno == 0 || empno == null) && !(year == 0 || year == null))
            {
                //year is there , not empid
                try
                {
                    cmd = new SqlCommand("select * from SAVINGS$ where SAVING_YEAR=@SAVING_YEAR" + str, con);
                    cmd.Parameters.AddWithValue("SAVING_YEAR", ddlSavingYear.SelectedValue);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                    return new DataSet();
                }
            }
           else
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
                    cmd = new SqlCommand("select * from SAVINGS$" + str, con);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                    return new DataSet();
                }
            }
            return ds;
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool isDelete = false;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                foreach (GridViewRow row in GridView1.Rows)
                {
                    var chkdel = row.FindControl("CheckBoxDelete") as CheckBox;
                    if (chkdel.Checked)
                    {
                        string empno = GridView1.Rows[row.RowIndex].Cells[1].Text;
                        string saving_year = GridView1.Rows[row.RowIndex].Cells[2].Text;
                        Response.Write("<script>alert('ROW INDEX=" + row.RowIndex + " CHECKBOX=" + chkdel.ToString() + " EMPNO=" + empno.ToString() + " SAVING_YEAR=" + saving_year.ToString() + "');</script>");

                        SqlCommand cmd = new SqlCommand("delete from SAVINGS$ where EMPNO=@EMPNO and SAVING_YEAR=@SAVING_YEAR", con);
                        cmd.Parameters.AddWithValue("@EMPNO", empno);
                        cmd.Parameters.AddWithValue("@SAVING_YEAR", saving_year);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        isDelete = true;
                    }
                }
                if (isDelete == true)
                {
                    Response.Write("<script>alert('Data Deleted Successfully');</script>");
                }
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Deleting');</script>");
            }
            load_gridview();
        }
    }
}