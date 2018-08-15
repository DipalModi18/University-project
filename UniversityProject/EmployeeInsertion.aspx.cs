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
    public partial class EmployeeInsertion : System.Web.UI.Page
    {
        public Boolean IsDataValid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                IsDataValid = false;
                BindDeptName();
                BindFacName();
                SetSelectedIndex();
                for (int m = 0; m < 12; m++)
                {
                    ddlDOBmon.Items.Add(new ListItem((m + 1).ToString()));
                    ddlDOJmon.Items.Add(new ListItem((m + 1).ToString()));
                    ddlNDLmon.Items.Add(new ListItem((m + 1).ToString()));
                    ddlDORmon.Items.Add(new ListItem((m + 1).ToString()));
                    ddlDeathMon.Items.Add(new ListItem((m + 1).ToString()));
                    ddlVrsMon.Items.Add(new ListItem((m + 1).ToString()));
                }
                for (int m = 0; m < 31; m++)
                {
                    ddlDOBday.Items.Add(new ListItem((m + 1).ToString()));
                    ddlDOJday.Items.Add(new ListItem((m + 1).ToString()));
                    ddlNDLday.Items.Add(new ListItem((m + 1).ToString()));
                    ddlDORday.Items.Add(new ListItem((m + 1).ToString()));
                    ddlDeathDay.Items.Add(new ListItem((m + 1).ToString()));
                    ddlVrsDay.Items.Add(new ListItem((m + 1).ToString()));
                }
                int curYear = DateTime.Now.Year;
                for (int m = (curYear - 90); m < curYear; m++)
                {
                    ddlDOByear.Items.Add(new ListItem((m + 1).ToString()));
                    ddlDOJyear.Items.Add(new ListItem((m + 1).ToString()));
                    ddlNDLyear.Items.Add(new ListItem((m + 1).ToString()));
                    ddlDORyear.Items.Add(new ListItem((m + 1).ToString()));
                    ddlDeathYear.Items.Add(new ListItem((m + 1).ToString()));
                    ddlVrsYear.Items.Add(new ListItem((m + 1).ToString()));
                }

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
                SqlCommand cmd = new SqlCommand("Select Distinct DEPTNAME from DEPT_PROFILE$"+str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandTimeout = 120;
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                ddlDeptName.DataSource = ds.Tables[0];
                ddlDeptName.DataTextField = "DEPTNAME";
                ddlDeptName.DataValueField = "DEPTNAME";
                ddlDeptName.DataBind();
                ddlDeptName.Items.Insert(0, new ListItem("Select", "0", true));
            }
            catch(Exception ee)
            {

            }
        }

        public void BindFacName()
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
                SqlCommand cmd = new SqlCommand("Select Distinct FACNAME from FACULTY_PROFILE$"+str, con);
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandTimeout = 120;
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                ddlFacName.DataSource = ds.Tables[0];
                ddlFacName.DataTextField = "FACNAME";
                ddlFacName.DataValueField = "FACNAME";
                ddlFacName.DataBind();
                ddlFacName.Items.Add(new ListItem("Select", "0", true));
            }
            catch(Exception ee)
            {

            }
        }

        public void SetSelectedIndex()
        {
            ddlDOBmon.Items.Add(new ListItem("Select", "0", true));
            ddlDOJmon.Items.Add(new ListItem("Select", "0", true));
            ddlNDLmon.Items.Add(new ListItem("Select", "0", true));
            ddlDORmon.Items.Add(new ListItem("Select", "0", true));
            ddlDeathMon.Items.Add(new ListItem("Select", "0", true));
            ddlVrsMon.Items.Add(new ListItem("Select", "0", true));
            ddlDOBday.Items.Add(new ListItem("Select", "0", true));
            ddlDOJday.Items.Add(new ListItem("Select", "0", true));
            ddlNDLday.Items.Add(new ListItem("Select", "0", true));
            ddlDORday.Items.Add(new ListItem("Select", "0", true));
            ddlDeathDay.Items.Add(new ListItem("Select", "0", true));
            ddlVrsDay.Items.Add(new ListItem("Select", "0", true));
            ddlDOByear.Items.Add(new ListItem("Select", "0", true));
            ddlDOJyear.Items.Add(new ListItem("Select", "0", true));
            ddlNDLyear.Items.Add(new ListItem("Select", "0", true));
            ddlDORyear.Items.Add(new ListItem("Select", "0", true));
            ddlDeathYear.Items.Add(new ListItem("Select", "0", true));
            ddlVrsYear.Items.Add(new ListItem("Select", "0", true));
        }

        protected void CustomValidatortxtEmpID_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("select EMPNO from EMP_PROFILE$ where EMPNO=@EMPNO", con);
            cmd.Parameters.AddWithValue("EMPNO", txtEmpID.Text);
            con.Open();
            Int32? empno = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            if (empno == null || empno==0)
            {
                args.IsValid = true;
                IsDataValid = true;
            }
            else
            {
                args.IsValid = false;
                IsDataValid = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(IsDataValid)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                //SqlDataAdapter da = new SqlDataAdapter();
                //DataSet ds;
                SqlCommand cmd = new SqlCommand("insert into EMP_PROFILE$ values (@EMPNO,@EMPNAME,@SEX,@PFNO,@DOB,@DOJ,@NDL,@DOR,@DEPTNO,@FACID,@DESIGNATION,@GRADE,@PAYSCALE,@TELENO,@MOBILENO,@PANNO,@BANKACCNO,@DEATHON,@VRSON,@PENSION_CPF)", con);
                cmd.Parameters.AddWithValue("EMPNO", txtEmpID.Text);
                cmd.Parameters.AddWithValue("EMPNAME", txtEmpName.Text);
                if (rbMale.Checked == true)
                {
                    cmd.Parameters.AddWithValue("SEX", "M");
                }
                else
                {
                    cmd.Parameters.AddWithValue("SEX", "F");
                }
                cmd.Parameters.AddWithValue("PFNO", txtPF.Text);
                if (ddlDOBday.SelectedIndex <= 0 || ddlDOBmon.SelectedIndex <= 0 || ddlDOByear.SelectedIndex <= 0 || ddlDOBday.SelectedValue == "Select" || ddlDOBmon.SelectedValue == "Select" || ddlDOByear.SelectedValue == "Select")
                {
                    cmd.Parameters.AddWithValue("DOB", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("DOB", Convert.ToDateTime(ddlDOBmon.SelectedValue + "/" + ddlDOBday.SelectedValue + "/" + ddlDOByear.SelectedValue));
                }
                if (ddlDOJday.SelectedIndex <= 0 || ddlDOJmon.SelectedIndex <= 0 || ddlDOJyear.SelectedIndex <= 0 || ddlDOJday.SelectedValue == "Select" || ddlDOJmon.SelectedValue == "Select" || ddlDOJyear.SelectedValue == "Select")
                {
                    cmd.Parameters.AddWithValue("DOJ", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("DOJ", Convert.ToDateTime(ddlDOJmon.SelectedValue + "/" + ddlDOJday.SelectedValue + "/" + ddlDOByear.SelectedValue));
                }
                if (ddlNDLday.SelectedIndex <= 0 || ddlNDLmon.SelectedIndex <= 0 || ddlNDLyear.SelectedIndex <= 0 || ddlNDLday.SelectedValue == "Select" || ddlNDLmon.SelectedValue == "Select" || ddlNDLyear.SelectedValue == "Select")
                {
                    cmd.Parameters.AddWithValue("NDL", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("NDL", Convert.ToDateTime(ddlNDLmon.SelectedValue + "/" + ddlNDLday.SelectedValue + "/" + ddlNDLyear.SelectedValue));
                }
                if (ddlDORday.SelectedIndex <= 0 || ddlDORmon.SelectedIndex <= 0 || ddlDORyear.SelectedIndex <= 0 || ddlDORday.SelectedValue == "Select" || ddlDORmon.SelectedValue == "Select" || ddlDORyear.SelectedValue == "Select")
                {
                    cmd.Parameters.AddWithValue("DOR", DBNull.Value);
                }
                else
                {
                    DateTime dt = new DateTime(Convert.ToInt16(ddlDORyear.SelectedValue), Convert.ToInt16(ddlDORmon.SelectedValue), Convert.ToInt16(ddlDORday.SelectedValue));
                    cmd.Parameters.AddWithValue("DOR", dt);
                }
                if (ddlDeptName.SelectedValue != "Select" || ddlDeptName.SelectedIndex>0)
                {
                    cmd.Parameters.AddWithValue("DEPTNO", SelectDeptNoByName(ddlDeptName.SelectedValue));
                }
                else
                {
                    cmd.Parameters.AddWithValue("DEPTNO", DBNull.Value);
                }
                if (ddlFacName.SelectedValue != "Select" || ddlFacName.SelectedIndex>0)
                {
                    cmd.Parameters.AddWithValue("FACID", SelectFacNoByName(ddlFacName.SelectedValue));
                }
                else
                {
                    cmd.Parameters.AddWithValue("FACID", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("DESIGNATION", txtDesignation.Text);
                cmd.Parameters.AddWithValue("GRADE", txtGrade.Text);
                cmd.Parameters.AddWithValue("PAYSCALE", txtPayScale.Text);
                cmd.Parameters.AddWithValue("TELENO", txtPhone.Text);
                cmd.Parameters.AddWithValue("MOBILENO", txtMobile.Text);
                cmd.Parameters.AddWithValue("PANNO", txtPan.Text);
                cmd.Parameters.AddWithValue("BANKACCNO", txtBankAccNo.Text);
                if (ddlDeathDay.SelectedIndex <= 0 || ddlDeathMon.SelectedIndex <= 0 || ddlDeathYear.SelectedIndex <= 0 || ddlDeathDay.SelectedValue == "Select" || ddlDeathMon.SelectedValue == "Select" || ddlDeathYear.SelectedValue == "Select")
                {
                    cmd.Parameters.AddWithValue("DEATHON", DBNull.Value);
                }
                else
                {
                    //cmd.Parameters.AddWithValue("DEATHON", Convert.ToDateTime(ddlDeathMon.SelectedValue + "/" + ddlDeathDay.SelectedValue + "/" + ddlDeathYear.SelectedValue));
                    DateTime dt = new DateTime(Convert.ToInt16(ddlDeathYear.SelectedValue), Convert.ToInt16(ddlDeathMon.SelectedValue), Convert.ToInt16(ddlDeathDay.SelectedValue));
                    cmd.Parameters.AddWithValue("DEATHON", dt);
                }
                if (ddlVrsDay.SelectedIndex <= 0 || ddlVrsMon.SelectedIndex <= 0 || ddlVrsYear.SelectedIndex <= 0 || ddlVrsDay.SelectedValue == "Select" && ddlVrsMon.SelectedValue == "Select" || ddlVrsYear.SelectedValue == "Select")
                {
                    cmd.Parameters.AddWithValue("VRSON", DBNull.Value);
                }
                else
                {
                    //cmd.Parameters.AddWithValue("VRSON", Convert.ToDateTime(ddlVrsMon.SelectedValue + "/" + ddlVrsDay.SelectedValue + "/" + ddlVrsYear.SelectedValue));
                    DateTime dt = new DateTime(Convert.ToInt16(ddlVrsYear.SelectedValue), Convert.ToInt16(ddlVrsMon.SelectedValue), Convert.ToInt16(ddlVrsDay.SelectedValue));
                    cmd.Parameters.AddWithValue("VRSON", dt);
                }

                if (rbCpf.Checked == true)
                {
                    cmd.Parameters.AddWithValue("PENSION_CPF", "CPF");
                }
                else if(rbPension.Checked==true)
                {
                    cmd.Parameters.AddWithValue("PENSION_CPF", "Pension");
                }
                else if(rbNewPension.Checked==true)
                {
                    cmd.Parameters.AddWithValue("PENSION_CPF", "New Pension");
                }
                con.Open();
                try
                {                 
                    cmd.ExecuteNonQuery();
                    Response.Write("<script language='javascript'>window.alert('Data saved successfully');window.location='Employee.aspx';</script>");
                }
                catch
                {
                    Response.Write("<script>alert('Error in saving data');</script>");
                }
                finally
                {
                    con.Close();
                }
            }
            else // if employee id already exists
            {
                Response.Write("<script>alert('Error in saving data');</script>");
            }
        }

        public int SelectDeptNoByName(string Deptname)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("select DEPTNO from DEPT_PROFILE$ where DEPTNAME=@DEPTNAME", con);
            cmd.Parameters.AddWithValue("DEPTNAME", Deptname);
            con.Open();
            Int16 DeptNo = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            return DeptNo;
        }

        public int SelectFacNoByName(string Facname)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("select FACID from FACULTY_PROFILE$ where FACNAME=@FACNAME", con);
            cmd.Parameters.AddWithValue("FACNAME", Facname);
            con.Open();
            Int16 FacNo = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            return FacNo;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            /*txtEmpID.Text = "";
            txtEmpName.Text = "";
            rbMale.Checked = true;
            rbFemale.Checked = false;
            txtPF.Text = "";
            ddlDOBday.SelectedIndex = 0;
            ddlDOBmon.SelectedIndex = 0;
            ddlDOByear.SelectedIndex = 0;
            ddlDOJday.SelectedIndex = 0;
            ddlDOJmon.SelectedIndex = 0;
            ddlDOJyear.SelectedIndex = 0;
            ddlNDLday.SelectedIndex = 0;
            ddlNDLmon.SelectedIndex = 0;
            ddlNDLyear.SelectedIndex = 0;
            ddlDORday.SelectedIndex = 0;
            ddlDORmon.SelectedIndex = 0;
            ddlDORyear.SelectedIndex = 0;
            ddlFacName.SelectedIndex = 0;
            ddlDeptName.SelectedIndex = 0;
            txtDesignation.Text = "";
            txtGrade.Text = "";
            txtPayScale.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtPan.Text = "";
            txtBankAccNo.Text = "";
            rbPension.Checked = true;
            rbCpf.Checked = false;
            ddlDeathDay.SelectedIndex = 0;
            ddlDeathMon.SelectedIndex = 0;
            ddlDeathYear.SelectedIndex = 0;
            ddlVrsDay.SelectedIndex = 0;
            ddlVrsMon.SelectedIndex = 0;
            ddlVrsYear.SelectedIndex = 0;*/
            Response.Redirect("Employee.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if((ddlDOBday.SelectedIndex==-1 || ddlDOBday.SelectedIndex==0) && (ddlDOBmon.SelectedIndex==-1 || ddlDOBmon.SelectedIndex==0) && (ddlDOByear.SelectedIndex==-1 || ddlDOByear.SelectedIndex==0))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if((ddlDOJday.SelectedIndex==-1 || ddlDOJday.SelectedIndex==0) && (ddlDOJmon.SelectedIndex==-1 || ddlDOJmon.SelectedIndex==0) && (ddlDOJyear.SelectedIndex==-1 || ddlDOJyear.SelectedIndex==0))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}