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
    public partial class DaArrears : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);

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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Distinct MONTH from DAARREARS$", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                DropDownListMonth.DataSource = dt;
                DropDownListMonth.DataValueField = "MONTH";
                DropDownListMonth.DataBind();
                DropDownListMonth.Items.Insert(0, new ListItem("Select", ""));
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Month');</script>");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        public void bindYear()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select Distinct YEAR from DAARREARS$", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                DropDownListYear.DataSource = dt;
                DropDownListYear.DataValueField = "YEAR";
                DropDownListYear.DataBind();
                DropDownListYear.Items.Insert(0, new ListItem("Select", ""));
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Binding Year');</script>");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            String str = "";
            if(Session["User_Id"].ToString()==(100).ToString())
            {
                str = "";
            }
            else
            {
                str = " and EMPNO in (select EMPNO from EMP_PROFILE$ where FACID="+ Session["User_Id"].ToString()+ ")";
            }


            if ((TxtEmpid.Text == "" || TxtEmpid.Text==null) && (DropDownListMonth.SelectedIndex <= 0) && (DropDownListYear.SelectedIndex <= 0))
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
                    SqlCommand cmd = new SqlCommand("select * from DAARREARS$" + str, con);
                    SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    dataAdapt.Fill(Dt);
                    GridView1.DataSource = Dt;
                    GridView1.DataBind();
                }
                catch(Exception ee)
                {
                    Response.Write("<script>alert('Error While Loading Data');</script>");
                }
            }
            else if (!(TxtEmpid.Text == "" || TxtEmpid.Text==null) && (DropDownListMonth.SelectedIndex > 0) && (DropDownListYear.SelectedIndex > 0))
            {
                //All of them having Something
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from DAARREARS$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR" + str, con);
                    Response.Write("<script>alert('select * from DAARREARS$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR" + str + "');</script>");
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
                //Employee id and month is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from DAARREARS$ where EMPNO=@EMPNO and MONTH=@MONTH" + str, con);
                    Response.Write("<script>alert('select * from DAARREARS$ where EMPNO=@EMPNO and MONTH=@MONTH" + str + "');</script>");
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
            else if (!(TxtEmpid.Text == "" || TxtEmpid.Text==null) && DropDownListMonth.SelectedIndex <= 0 && DropDownListYear.SelectedIndex > 0)
            {
                //Employee id and Year is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from DAARREARS$ where EMPNO=@EMPNO and YEAR=@YEAR" + str, con);
                    Response.Write("<script>alert('select * from DAARREARS$ where EMPNO=@EMPNO and YEAR=@YEAR" + str + "');</script>");
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
                //month and year is there
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from DAARREARS$ where MONTH=@MONTH and YEAR=@YEAR" + str, con);
                    Response.Write("<script>alert('select * from DAARREARS$ where MONTH=@MONTH and YEAR=@YEAR" + str + "');</script>");
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
            else if (!(TxtEmpid.Text == "" || TxtEmpid.Text == null) && DropDownListMonth.SelectedIndex <= 0 && DropDownListYear.SelectedIndex <= 0)
            {
                //Only Employee id
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from DAARREARS$ where EMPNO=@EMPNO" + str, con);
                    Response.Write("<script>alert('select * from DAARREARS$ where EMPNO=@EMPNO" + str + "');</script>");
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
            else if((TxtEmpid.Text == "" || TxtEmpid.Text == null) && DropDownListMonth.SelectedIndex <= 0 && DropDownListYear.SelectedIndex > 0)
            {
                //Only Year 
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from DAARREARS$ where YEAR=@YEAR" + str, con);
                    Response.Write("<script>alert('select * from DAARREARS$ where YEAR=@YEAR" + str + "');</script>");
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
            else if((TxtEmpid.Text == "" || TxtEmpid.Text == null) && DropDownListMonth.SelectedIndex > 0 && DropDownListYear.SelectedIndex <= 0)
            {
                //Only month
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from DAARREARS$ where MONTH=@MONTH" + str, con);
                    Response.Write("<script>alert('select * from DAARREARS$ where MONTH=@MONTH" + str + "');</script>");
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

        }

        protected void LinkButtonLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("DaArrearsInsertion.aspx");
        }

        protected void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int isdeleted = 0;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                foreach (GridViewRow row in GridView1.Rows)
                {
                    var chkdel = row.FindControl("CheckBoxDelete") as CheckBox;
                    if (chkdel.Checked)
                    {
                        var empno = GridView1.Rows[row.RowIndex].Cells[1].Text;
                        var month = GridView1.Rows[row.RowIndex].Cells[2].Text;
                        var year = GridView1.Rows[row.RowIndex].Cells[3].Text;
                        SqlCommand cmd = new SqlCommand("delete from DAARREARS$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
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
                }
                load_gridview();
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Deleting Data');</script>");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
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
                str = " where EMPNO in (select EMPNO from EMP_PROFILE$ where FACID=" + Session["User_Id"].ToString() + ")";
            }
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("select * from DAARREARS$"+str, con);
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Loading Data');</script>");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

    }
}