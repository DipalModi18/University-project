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
    public partial class EmployeeModification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                if(Request.QueryString["EMPNO"]!=null)
                {
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

                    var empno = Request.QueryString["EMPNO"];
                    Response.Write("<script>alert(' Employee number=" + empno + " ');</script>");
                    DataSet ds = SelectEmployeeByID(Convert.ToInt32(empno));
                    lblEmployeeId.Text = ds.Tables[0].Rows[0]["EMPNO"].ToString();
                    txtEmpName.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
                    if (ds.Tables[0].Rows[0]["SEX"].ToString() == "M")
                    {
                        rbMale.Checked = true;
                        rbFemale.Checked = false;
                    }
                    else
                    {
                        rbFemale.Checked = true;
                        rbMale.Checked = false;
                    }
                    txtPF.Text = ds.Tables[0].Rows[0]["PFNO"].ToString();
                    DateTime ddt;
                    if (ds.Tables[0].Rows[0]["DOB"] == DBNull.Value)
                    {
                        ddlDOBday.SelectedIndex = 0;
                        ddlDOBmon.SelectedIndex = 0;
                        ddlDOByear.SelectedIndex = 0;
                    }
                    else
                    {
                        ddt = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]);
                        ddlDOBday.SelectedValue = ddt.Day.ToString();
                        ddlDOBmon.SelectedValue = ddt.Month.ToString();
                        ddlDOByear.SelectedValue = ddt.Year.ToString();
                    }

                    if (ds.Tables[0].Rows[0]["DOJ"] == DBNull.Value)
                    {
                        ddlDOJday.SelectedIndex = 0;
                        ddlDOJmon.SelectedIndex = 0;
                        ddlDOJyear.SelectedIndex = 0;
                    }
                    else
                    {
                        ddt = (DateTime)ds.Tables[0].Rows[0]["DOJ"];
                        ddlDOJday.SelectedValue = ddt.Day.ToString();
                        ddlDOJmon.SelectedValue = ddt.Month.ToString();
                        ddlDOJyear.SelectedValue = ddt.Year.ToString();
                    }

                    if (ds.Tables[0].Rows[0]["NDI"] == DBNull.Value)
                    {
                        ddlNDLday.SelectedIndex = 0;
                        ddlNDLmon.SelectedIndex = 0;
                        ddlNDLyear.SelectedIndex = 0;
                    }
                    else
                    {
                        ddt = (DateTime)ds.Tables[0].Rows[0]["NDI"];
                        ddlNDLday.SelectedValue = ddt.Day.ToString();
                        ddlNDLmon.SelectedValue = ddt.Month.ToString();
                        ddlNDLyear.SelectedValue = ddt.Year.ToString();
                    }

                    if (ds.Tables[0].Rows[0]["DOR"] == DBNull.Value)
                    {
                        ddlDORday.SelectedIndex = 0;
                        ddlDORmon.SelectedIndex = 0;
                        ddlDORyear.SelectedIndex = 0;
                    }
                    else
                    {
                        ddt = (DateTime)ds.Tables[0].Rows[0]["DOR"];
                        ddlDORday.SelectedValue = ddt.Day.ToString();
                        ddlDORmon.SelectedValue = ddt.Month.ToString();
                        ddlDORyear.SelectedValue = ddt.Year.ToString();
                    }

                    string fn = SelectFacNameByNo(Convert.ToInt16(ds.Tables[0].Rows[0]["FACID"]));
                    if (fn == null)
                    {
                        ddlFacName.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlFacName.SelectedValue = fn;
                    }
                    string dn = SelectDeptNameByNo(Convert.ToInt16(ds.Tables[0].Rows[0]["DEPTNO"].ToString()));
                    if (dn == null)
                    {
                        ddlDeptName.SelectedIndex = 0;
                    }
                    else
                    {
                        ddlDeptName.SelectedValue = dn;
                    }

                    txtDesignation.Text = ds.Tables[0].Rows[0]["DESIGNATION"].ToString();
                    txtGrade.Text = ds.Tables[0].Rows[0]["GRADE"].ToString();
                    txtPayScale.Text = ds.Tables[0].Rows[0]["PAYSCALE"].ToString();
                    txtPhone.Text = ds.Tables[0].Rows[0]["TELENO"].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0]["MOBILENO"].ToString();
                    txtPan.Text = ds.Tables[0].Rows[0]["PANNO"].ToString();
                    txtBankAccNo.Text = ds.Tables[0].Rows[0]["BANKACCNO"].ToString();

                    if (ds.Tables[0].Rows[0]["PENSION_CPF"].ToString() == "CPF")
                    {
                        rbPension.Checked = false;
                        rbCpf.Checked = true;
                        rbNewPension.Checked = false;
                    }
                    else if(ds.Tables[0].Rows[0]["PENSION_CPF"].ToString()=="Pension")
                    {
                        rbPension.Checked = true;
                        rbCpf.Checked = false;
                        rbNewPension.Checked = false;
                    }
                    else
                    {
                        rbNewPension.Checked = true;
                        rbCpf.Checked = false;
                        rbPension.Checked = false;
                    }

                    if (ds.Tables[0].Rows[0]["DEATHON"] == DBNull.Value)
                    {
                        ddlDeathDay.SelectedIndex = 0;
                        ddlDeathMon.SelectedIndex = 0;
                        ddlDeathYear.SelectedIndex = 0;
                    }
                    else
                    {
                        ddt = (DateTime)ds.Tables[0].Rows[0]["DEATHON"];
                        ddlDeathDay.SelectedValue = ddt.Day.ToString();
                        ddlDeathMon.SelectedValue = ddt.Month.ToString();
                        ddlDeathYear.SelectedValue = ddt.Year.ToString();
                    }

                    if (ds.Tables[0].Rows[0]["VRSON"] == DBNull.Value)
                    {
                        ddlVrsDay.SelectedIndex = 0;
                        ddlVrsMon.SelectedIndex = 0;
                        ddlVrsYear.SelectedIndex = 0;
                    }
                    else
                    {
                        ddt = Convert.ToDateTime(ds.Tables[0].Rows[0]["VRSON"]);
                        ddlVrsDay.SelectedValue = ddt.Day.ToString();
                        ddlVrsMon.SelectedValue = ddt.Month.ToString();
                        ddlVrsYear.SelectedValue = ddt.Year.ToString();
                    }
                }
                else
                {
                    Response.Redirect("Employee.aspx");
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

        public void SetSelectedIndex()
        {
            ddlDOBmon.Items.Add(new ListItem("Select","0",true));
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
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                con.Open();
                cmd.CommandTimeout = 120;
                da.Fill(ds);
                //lblEmployeeId.Text = ds.Tables[0].Rows[0]["DEPTNAME"].ToString();
                con.Close();
                ddlDeptName.DataSource = ds;
                ddlDeptName.DataTextField = "DEPTNAME";
                ddlDeptName.DataValueField = "DEPTNAME";
                ddlDeptName.DataBind();
                ddlDeptName.Items.Add(new ListItem("Select", "0", true));
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
                SqlCommand cmd = new SqlCommand("Select Distinct FACNAME from FACULTY_PROFILE$" + str, con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                con.Open();
                cmd.CommandTimeout = 120;
                da.Fill(ds);
                con.Close();
                ddlFacName.DataSource = ds;
                ddlFacName.DataBind();
                ddlFacName.Items.Add(new ListItem("Select", "0", true));
            }
            catch(Exception ee)
            {

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

        public string SelectDeptNameByNo(Int16 DeptNo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("select DEPTNAME from DEPT_PROFILE$ where DEPTNO=@DEPTNO", con);
            cmd.Parameters.AddWithValue("DEPTNO", DeptNo);
            con.Open();
            var dn = cmd.ExecuteScalar();
            String DeptName;
            if (dn==null || dn==DBNull.Value)
            {
                DeptName = null;
            }
            else
            {
                DeptName = dn.ToString();
            }
            con.Close();
            return DeptName;
        }

        public string SelectFacNameByNo(Int16 FacId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("select FACNAME from FACULTY_PROFILE$ where FACID=@FACID", con);
            cmd.Parameters.AddWithValue("FACID", FacId);
            con.Open();
            var fn = cmd.ExecuteScalar();
            String FacName;

            if (fn==null || fn==DBNull.Value)
            {
                FacName = null;
            }
            else
            {
                FacName = fn.ToString();
            }
            
            con.Close();
            return FacName;
        }


        public DataSet SelectEmployeeByID(Int32? Empid)
        {
            SqlConnection con = null;
            //string result = "";
            DataSet ds = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());

                if (!(Empid == 0 || Empid == null))
                {
                    SqlCommand cmd = new SqlCommand("select * from EMP_PROFILE$ where EMPNO=@EMPNO", con);
                    cmd.Parameters.AddWithValue("EMPNO", Empid);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                else
                {
                    return ds;
                }
            }
            catch
            {
                return ds;
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataSet ds;
            SqlCommand cmd = new SqlCommand("update EMP_PROFILE$ set EMPNAME=@EMPNAME,SEX=@SEX,PFNO=@PFNO,DOB=@DOB,DOJ=@DOJ,NDI=@NDL,DOR=@DOR,DEPTNO=@DEPTNO,FACID=@FACID,DESIGNATION=@DESIGNATION,GRADE=@GRADE,PAYSCALE=@PAYSCALE,TELENO=@TELENO,MOBILENO=@MOBILENO,PANNO=@PANNO,BANKACCNO=@BANKACCNO,DEATHON=@DEATHON,VRSON=@VRSON,PENSION_CPF=@PENSION_CPF where EMPNO=@EMPNO", con);
            cmd.Parameters.AddWithValue("EMPNO",lblEmployeeId.Text);
            cmd.Parameters.AddWithValue("EMPNAME",txtEmpName.Text);
            if(rbMale.Checked==true)
            {
                cmd.Parameters.AddWithValue("SEX","M");
            }
            else
            {
                cmd.Parameters.AddWithValue("SEX", "F");
            }           
            cmd.Parameters.AddWithValue("PFNO",txtPF.Text);
            if(ddlDOBday.SelectedIndex <= 0 || ddlDOBmon.SelectedIndex <= 0 || ddlDOByear.SelectedIndex <= 0 || ddlDOBday.SelectedValue == "Select" || ddlDOBmon.SelectedValue == "Select" || ddlDOByear.SelectedValue == "Select")
            {
                cmd.Parameters.AddWithValue("DOB", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("DOB", Convert.ToDateTime(ddlDOBmon.SelectedValue + "/" + ddlDOBday.SelectedValue + "/" + ddlDOByear.SelectedValue));
            }
            if(ddlDOJday.SelectedIndex <= 0 || ddlDOJmon.SelectedIndex <= 0 || ddlDOJyear.SelectedIndex <= 0 || ddlDOJday.SelectedValue == "Select" || ddlDOJmon.SelectedValue == "Select" || ddlDOJyear.SelectedValue == "Select")
            {
                cmd.Parameters.AddWithValue("DOJ", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("DOJ", Convert.ToDateTime(ddlDOJmon.SelectedValue + "/" + ddlDOJday.SelectedValue + "/" + ddlDOByear.SelectedValue));
            }
            if(ddlNDLday.SelectedIndex <= 0 || ddlNDLmon.SelectedIndex <= 0 || ddlNDLyear.SelectedIndex <= 0 || ddlNDLday.SelectedValue == "Select" || ddlNDLmon.SelectedValue == "Select" || ddlNDLyear.SelectedValue == "Select")
            {
                cmd.Parameters.AddWithValue("NDL", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("NDL",Convert.ToDateTime(ddlNDLmon.SelectedValue + "/" + ddlNDLday.SelectedValue + "/" + ddlNDLyear.SelectedValue));
            }
            if(ddlDORday.SelectedIndex <= 0 || ddlDORmon.SelectedIndex <= 0 || ddlDORyear.SelectedIndex <= 0 || ddlDORday.SelectedValue == "Select" || ddlDORmon.SelectedValue == "Select" || ddlDORyear.SelectedValue == "Select")
            {
                cmd.Parameters.AddWithValue("DOR", DBNull.Value);
            }
            else
            {
                DateTime dt = new DateTime(Convert.ToInt16(ddlDORyear.SelectedValue), Convert.ToInt16(ddlDORmon.SelectedValue), Convert.ToInt16(ddlDORday.SelectedValue));
                cmd.Parameters.AddWithValue("DOR",dt);
            }
            if(ddlDeptName.SelectedValue!="Select")
            {
                cmd.Parameters.AddWithValue("DEPTNO", SelectDeptNoByName(ddlDeptName.SelectedValue));
            }
            else
            {
                cmd.Parameters.AddWithValue("DEPTNO",DBNull.Value);
            }
            if(ddlFacName.SelectedValue!="Select")
            {
                cmd.Parameters.AddWithValue("FACID", SelectFacNoByName(ddlFacName.SelectedValue));
            }
            else
            {
                cmd.Parameters.AddWithValue("FACID", DBNull.Value);
            }
            
            cmd.Parameters.AddWithValue("DESIGNATION",txtDesignation.Text);
            cmd.Parameters.AddWithValue("GRADE",txtGrade.Text);
            cmd.Parameters.AddWithValue("PAYSCALE",txtPayScale.Text);
            cmd.Parameters.AddWithValue("TELENO",txtPhone.Text);
            cmd.Parameters.AddWithValue("MOBILENO",txtMobile.Text);
            cmd.Parameters.AddWithValue("PANNO",txtPan.Text);
            cmd.Parameters.AddWithValue("BANKACCNO",txtBankAccNo.Text);
            if (ddlDeathDay.SelectedIndex <= 0 || ddlDeathMon.SelectedIndex <= 0 || ddlDeathYear.SelectedIndex <= 0 || ddlDeathDay.SelectedValue == "Select" || ddlDeathMon.SelectedValue == "Select" || ddlDeathYear.SelectedValue == "Select")
            {
                cmd.Parameters.AddWithValue("DEATHON", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("DEATHON", Convert.ToDateTime(ddlDeathMon.SelectedValue + "/" + ddlDeathDay.SelectedValue + "/" + ddlDeathYear.SelectedValue));
            }
            if (ddlVrsDay.SelectedIndex <= 0 || ddlVrsMon.SelectedIndex <= 0 || ddlVrsYear.SelectedIndex <= 0 || ddlVrsDay.SelectedValue == "Select" && ddlVrsMon.SelectedValue == "Select" || ddlVrsYear.SelectedValue == "Select")
            {
                cmd.Parameters.AddWithValue("VRSON", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("VRSON", Convert.ToDateTime(ddlVrsMon.SelectedValue + "/" + ddlVrsDay.SelectedValue + "/" + ddlVrsYear.SelectedValue));
            }

            if (rbCpf.Checked==true)
            {
                cmd.Parameters.AddWithValue("PENSION_CPF","CPF");
            }
            else if(rbPension.Checked==true)
            {
                cmd.Parameters.AddWithValue("PENSION_CPF","Pension");
            }
            else
            {
                cmd.Parameters.AddWithValue("PENSION_CPF", "New Pension");
            }
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("<script language='javascript'>window.alert('Data modified successfully');window.location='Employee.aspx';</script>");
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            /*DataSet ds = SelectEmployeeByID(Convert.ToInt16(lblEmployeeId.Text));
            lblEmployeeId.Text = ds.Tables[0].Rows[0]["EMPNO"].ToString();
            txtEmpName.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
            if (ds.Tables[0].Rows[0]["SEX"].ToString() == "M")
            {
                rbMale.Checked = true;
                rbFemale.Checked = false;
            }
            else
            {
                rbFemale.Checked = true;
                rbMale.Checked = false;
            }
            txtPF.Text = ds.Tables[0].Rows[0]["PFNO"].ToString();
            DateTime ddt = (DateTime)ds.Tables[0].Rows[0]["DOB"];
            ddlDOBday.SelectedValue = ddt.Day.ToString();
            ddlDOBmon.SelectedValue = ddt.Month.ToString();
            ddlDOByear.SelectedValue = ddt.Year.ToString();

            ddt = (DateTime)ds.Tables[0].Rows[0]["DOJ"];
            ddlDOJday.SelectedValue = ddt.Day.ToString();
            ddlDOJmon.SelectedValue = ddt.Month.ToString();
            ddlDOJyear.SelectedValue = ddt.Year.ToString();

            ddt = (DateTime)ds.Tables[0].Rows[0]["NDI"];
            ddlNDLday.SelectedValue = ddt.Day.ToString();
            ddlNDLmon.SelectedValue = ddt.Month.ToString();
            ddlNDLyear.SelectedValue = ddt.Year.ToString();

            ddt = (DateTime)ds.Tables[0].Rows[0]["DOR"];
            ddlDORday.SelectedValue = ddt.Day.ToString();
            ddlDORmon.SelectedValue = ddt.Month.ToString();
            ddlDORyear.SelectedValue = ddt.Year.ToString();

            ddlFacName.SelectedValue = ds.Tables[0].Rows[0]["FACID"].ToString();
            ddlDeptName.SelectedValue = ds.Tables[0].Rows[0]["DEPTNO"].ToString();
            txtDesignation.Text = ds.Tables[0].Rows[0]["DESIGNATION"].ToString();
            txtGrade.Text = ds.Tables[0].Rows[0]["GRADE"].ToString();
            txtPayScale.Text = ds.Tables[0].Rows[0]["PAYSCALE"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["TELENO"].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0]["MOBILENO"].ToString();
            txtPan.Text = ds.Tables[0].Rows[0]["PANNO"].ToString();
            txtBankAccNo.Text = ds.Tables[0].Rows[0]["BANKACCNO"].ToString();

            if (ds.Tables[0].Rows[0]["PENSION_CPF"].ToString() == "CPF")
            {
                rbPension.Checked = false;
                rbCpf.Checked = true;
            }
            else if(ds.Tables[0].Rows[0]["PENSION_CPF"].ToString()=="Pension")
            {
                rbPension.Checked = true;
                rbCpf.Checked = false;
            }
            else
            {
                rbNewPension.Checked = true;
            }

            ddt = (DateTime)ds.Tables[0].Rows[0]["DEATHON"];
            ddlDeathDay.SelectedValue = ddt.Day.ToString();
            ddlDeathMon.SelectedValue = ddt.Month.ToString();
            ddlDeathYear.SelectedValue = ddt.Year.ToString();

            ddt = (DateTime)ds.Tables[0].Rows[0]["VRSON"];
            ddlVrsDay.SelectedValue = ddt.Day.ToString();
            ddlVrsMon.SelectedValue = ddt.Month.ToString();
            ddlVrsYear.SelectedValue = ddt.Year.ToString();*/
            Response.Redirect("Employee.aspx");
        }
    }
}