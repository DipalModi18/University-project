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
    public partial class ExamRemunerationModification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            Calendar1.Visible = false;
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                Int16 Emp = 0;
                string Mon, Yr;

                Emp = Convert.ToInt16(Request.QueryString["EMPNO"]);
                Mon = Request.QueryString["MONTH"];
                Yr = Request.QueryString["YEAR"];

                //Response.Write("<script>alert('EMPNO =" + Emp + "MONTH=" + Mon + " YEAR=" + Yr + "');</script>");

                DataSet ds = SelectAllExamRemunerationDataById(Emp, Mon, Yr);
                Showempid.Text = Emp.ToString();
                ShowMth.Text = Mon.ToString();
                Showyr.Text = Yr.ToString();
                txtExamRemuneration.Text = ds.Tables[0].Rows[0]["EXAM_RMN"].ToString();
                Txtincometax.Text = ds.Tables[0].Rows[0]["INC_TAX"].ToString();
                lblNetExamRemuneration.Text = ds.Tables[0].Rows[0]["NET_EXAMRMN"].ToString();
                LblCal.Text = ds.Tables[0].Rows[0]["BANK_TRANDATE"].ToString();

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

        public DataSet SelectAllExamRemunerationDataById(Int16 Emp, string Mon, string Yr)
        {
            DataSet ds = null;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                con.Open();
                // Response.Write("<script>alert('EMPNO =" + Emp + "MONTH=" + Mon + " YEAR=" + Yr + "');</script>");
                SqlCommand cmd = new SqlCommand("select * from EXAMREMUNERATION$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                cmd.Parameters.AddWithValue("EMPNO", Emp);
                cmd.Parameters.AddWithValue("MONTH", Mon);
                cmd.Parameters.AddWithValue("YEAR", Yr);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                con.Close();
                //return ds;
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Fetching Record!!');</script>");
            }
            return ds;
        }

        protected void btnNetExamRemuneration_Click(object sender, EventArgs e)
        {
            try
            {
                Double NetAmount = Convert.ToDouble(txtExamRemuneration.Text) - Convert.ToDouble(Txtincometax.Text);
                if (NetAmount < 0)
                {
                    lblNetExamRemuneration.Text = "0";
                }
                else
                {
                    lblNetExamRemuneration.Text = NetAmount.ToString();
                }
            }
            catch(FormatException ee)
            {
                Response.Write("<script>alert('Enter Valid Numbers!!');</script>");
            }
        }

        protected void Btnsave_Click(object sender, EventArgs e)
        {
            btnNetExamRemuneration_Click(null, EventArgs.Empty);
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update EXAMREMUNERATION$ set EXAM_RMN=@EXAM_RMN, INC_TAX=@INC_TAX, NET_EXAMRMN=@NET_EXAMRMN, BANK_TRANDATE=@BANK_TRANDATE where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                cmd.Parameters.AddWithValue("@EXAM_RMN", txtExamRemuneration.Text);
                cmd.Parameters.AddWithValue("@INC_TAX", Txtincometax.Text);
                cmd.Parameters.AddWithValue("@NET_EXAMRMN", lblNetExamRemuneration.Text);
                cmd.Parameters.AddWithValue("BANK_TRANDATE", LblCal.Text);
                cmd.Parameters.AddWithValue("EMPNO", Showempid.Text);
                cmd.Parameters.AddWithValue("MONTH", ShowMth.Text);
                cmd.Parameters.AddWithValue("YEAR", Showyr.Text);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Updated Successfully!!');</script>");
                Response.Write("<script language='javascript'>window.location='ExamRemuneration.aspx';</script>");
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Saving Data!!');</script>");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            LblCal.Text = Calendar1.SelectedDate.ToLongDateString();
            Calendar1.Visible = false;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.DarkGray;
            }
        }

        protected void Btnclr_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExamRemuneration.aspx");
        }
    }
}