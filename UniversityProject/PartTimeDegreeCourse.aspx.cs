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
    public partial class PartTimeDegreeCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            /*if (IsPostBack)
            {
                string postbackControl = getPostBackControlName();

                if (postbackControl != "ImgCalender" || postbackControl == "LinkButton1")
                {
                    (GridView1.FooterRow.FindControl("Calendar1") as Calendar).Visible = false;
                }
            }
            else
            {
                (GridView1.FooterRow.FindControl("Calendar1") as Calendar).Visible = false;
            }*/
            if (!IsPostBack)
            {
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

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int isdeleted = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            foreach (GridViewRow row in GridView1.Rows)
            {
                var chkdel = row.FindControl("CheckBoxDelete") as CheckBox;
                //Response.Write("<script>alert(' CHECKBOX:" + chkdel.Checked + " ');</script>");
                if (chkdel.Checked)
                {
                    //Response.Write("<script>alert(' ROW INDEX:" + row.RowIndex + " " + (GridView1.Rows[row.RowIndex].Cells[2].FindControl("Label1") as Label).Text + "');</script>");
                    Int16 empno = Convert.ToInt16((GridView1.Rows[row.RowIndex].Cells[2].FindControl("Label1") as Label).Text);//Convert.ToInt16(GridView1.Rows[row.RowIndex].Cells[2].Text);
                    var month = (GridView1.Rows[row.RowIndex].Cells[3].FindControl("Label2") as Label).Text;
                    var year = (GridView1.Rows[row.RowIndex].Cells[4].FindControl("Label3") as Label).Text;
                    //Response.Write("<script>alert(' EMPNO:" + empno + " MONTH:" + month + " YEAR:" + year + " ');</script>");
                    //<script>alert('No Record Found!!');</script>
                    /*Response.Write("<script>DeleteConfirm(" + facid + ")</script>");
                    string Confirmation = Request.Form["confirm_value"];
                    if (Confirmation == "yes")
                    {*/
                    SqlCommand cmd = new SqlCommand("delete from PTD$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                    cmd.Parameters.AddWithValue("EMPNO", empno);
                    cmd.Parameters.AddWithValue("MONTH", month);
                    cmd.Parameters.AddWithValue("YEAR", year);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    isdeleted = 1;
                    /*}
                    else
                    {

                    }*/
                }
            }
            if (isdeleted == 1)
            {
                Response.Write("<script>alert('Records Deleted Successfully!!');</script>");
            }
        }

        /*private string getPostBackControlName()
        {
            Control control = null;
            //first we will check the "__EVENTTARGET" because if post back made by       the controls
            //which used "_doPostBack" function also available in Request.Form collection.

            string ctrlname = Page.Request.Params["__EVENTTARGET"];
            if (ctrlname != null && ctrlname != String.Empty)
            {
                control = Page.FindControl(ctrlname);
            }

            // if __EVENTTARGET is null, the control is a button type and we need to
            // iterate over the form collection to find it
            else
            {
                string ctrlStr = String.Empty;
                Control c = null;
                foreach (string ctl in Page.Request.Form)
                {
                    //handle ImageButton they having an additional "quasi-property" in their Id which identifies
                    //mouse x and y coordinates
                    if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                    {
                        ctrlStr = ctl.Substring(0, ctl.Length - 2);
                        c = Page.FindControl(ctrlStr);
                    }
                    else
                    {
                        c = Page.FindControl(ctl);
                    }
                    if (c is System.Web.UI.WebControls.Button ||
                             c is System.Web.UI.WebControls.ImageButton)
                    {
                        control = c;
                        break;
                    }
                }

            }
            return control.ID;
        }*/

        public void bindYear()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Distinct YEAR from PTD$", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandTimeout = 120;
                da.Fill(dt);
                con.Close();
                ddlSearchYear.DataSource = dt;
                ddlSearchYear.DataValueField = "YEAR";
                ddlSearchYear.DataBind();
                ddlSearchYear.Items.Insert(0, new ListItem("Select", ""));
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Year');</script>");
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            String str = "";
            if (Session["User_Id"].ToString() == (100).ToString())
            {
                str = "";
            }
            else
            {
                str = " and EMPNO in (select EMPNO from EMP_PROFILE$ where FACID=" + Session["User_Id"].ToString() + ")";
            }


            if ((txtSearchEmpno.Text == "" || txtSearchEmpno.Text == null) && (ddlSearchMonth.SelectedIndex <= 0) && (ddlSearchYear.SelectedIndex <= 0))
            {
                //all three has nothing
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
                    SqlCommand cmd = new SqlCommand("select * from PTD$" + str, con);
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
            else if (!(txtSearchEmpno.Text == "" || txtSearchEmpno.Text == null) && (ddlSearchMonth.SelectedIndex > 0) && (ddlSearchYear.SelectedIndex > 0))
            {
                //All of them having Something
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PTD$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR" + str, con);
                    //Response.Write("<script>alert('select * from PTD$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR" + str + "');</script>");
                    cmd.Parameters.AddWithValue("EMPNO", txtSearchEmpno.Text);
                    cmd.Parameters.AddWithValue("MONTH", ddlSearchMonth.SelectedValue);
                    cmd.Parameters.AddWithValue("YEAR", ddlSearchYear.SelectedValue);
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
            else if (!(txtSearchEmpno.Text == "" || txtSearchEmpno.Text == null) && ddlSearchMonth.SelectedIndex > 0 && ddlSearchYear.SelectedIndex <= 0)
            {
                //Employee id and month is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PTD$ where EMPNO=@EMPNO and MONTH=@MONTH" + str, con);
                    //Response.Write("<script>alert('select * from PTD$ where EMPNO=@EMPNO and MONTH=@MONTH" + str + "');</script>");
                    cmd.Parameters.AddWithValue("EMPNO", txtSearchEmpno.Text);
                    cmd.Parameters.AddWithValue("MONTH", ddlSearchMonth.SelectedValue);
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
            else if (!(txtSearchEmpno.Text == "" || txtSearchEmpno.Text == null) && ddlSearchMonth.SelectedIndex <= 0 && ddlSearchYear.SelectedIndex > 0)
            {
                //Employee id and Year is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PTD$ where EMPNO=@EMPNO and YEAR=@YEAR" + str, con);
                    //Response.Write("<script>alert('select * from PTD$ where EMPNO=@EMPNO and YEAR=@YEAR" + str + "');</script>");
                    cmd.Parameters.AddWithValue("EMPNO", txtSearchEmpno.Text);
                    cmd.Parameters.AddWithValue("YEAR", ddlSearchYear.SelectedValue);
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
            else if ((txtSearchEmpno.Text == "" || txtSearchEmpno.Text == null) && ddlSearchMonth.SelectedIndex > 0 && ddlSearchYear.SelectedIndex > 0)
            {
                //month and year is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PTD$ where MONTH=@MONTH and YEAR=@YEAR" + str, con);
                    //Response.Write("<script>alert('select * from PTD$ where MONTH=@MONTH and YEAR=@YEAR" + str + "');</script>");
                    cmd.Parameters.AddWithValue("MONTH", ddlSearchMonth.SelectedValue);
                    cmd.Parameters.AddWithValue("YEAR", ddlSearchYear.SelectedValue);
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
            else if (!(txtSearchEmpno.Text == "" || txtSearchEmpno.Text == null) && ddlSearchMonth.SelectedIndex <= 0 && ddlSearchYear.SelectedIndex <= 0)
            {
                //Only Employee id
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PTD$ where EMPNO=@EMPNO" + str, con);
                    //Response.Write("<script>alert('select * from PTD$ where EMPNO=@EMPNO" + str + "');</script>");
                    cmd.Parameters.AddWithValue("EMPNO", txtSearchEmpno.Text);
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
            else if ((txtSearchEmpno.Text == "" || txtSearchEmpno.Text == null) && ddlSearchMonth.SelectedIndex <= 0 && ddlSearchYear.SelectedIndex > 0)
            {
                //Only Year 
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PTD$ where YEAR=@YEAR" + str, con);
                    //Response.Write("<script>alert('select * from PTD$ where YEAR=@YEAR" + str + "');</script>");
                    cmd.Parameters.AddWithValue("YEAR", ddlSearchYear.SelectedValue);
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
            else if ((txtSearchEmpno.Text == "" || txtSearchEmpno.Text == null) && ddlSearchMonth.SelectedIndex > 0 && ddlSearchYear.SelectedIndex <= 0)
            {
                //Only month
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from PTD$ where MONTH=@MONTH" + str, con);
                    //Response.Write("<script>alert('select * from PTD$ where MONTH=@MONTH" + str + "');</script>");
                    cmd.Parameters.AddWithValue("MONTH", ddlSearchMonth.SelectedValue);
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

        protected void LinkButtonAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("PartTimeDegreeCourseInsertion.aspx");
        }
    }
}