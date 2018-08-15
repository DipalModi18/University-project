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
    public partial class PartTimeDegreeCourseModification : System.Web.UI.Page
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

                DataSet ds = SelectAllTesingDataById(Emp, Mon, Yr);
                Showempid.Text = Emp.ToString();
                ShowMth.Text = Mon.ToString();
                Showyr.Text = Yr.ToString();
                txtPTD.Text = ds.Tables[0].Rows[0]["PTD"].ToString();
                Txtincometax.Text = ds.Tables[0].Rows[0]["INC_TAX"].ToString();
                lblNetPTD.Text = ds.Tables[0].Rows[0]["NET_PTD"].ToString();
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

        public DataSet SelectAllTesingDataById(Int16 Emp, string Mon, string Yr)
        {
            DataSet ds = null;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                con.Open();
                // Response.Write("<script>alert('EMPNO =" + Emp + "MONTH=" + Mon + " YEAR=" + Yr + "');</script>");
                SqlCommand cmd = new SqlCommand("select * from PTD$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
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

        protected void btnNetPTD_Click(object sender, EventArgs e)
        {
            Double NetAmount = Convert.ToDouble(txtPTD.Text) - Convert.ToDouble(Txtincometax.Text);
            if (NetAmount < 0)
            {
                lblNetPTD.Text = "0";
            }
            else
            {
                lblNetPTD.Text = NetAmount.ToString();
            }
        }

        protected void Btnsave_Click(object sender, EventArgs e)
        {
            btnNetPTD_Click(null, EventArgs.Empty);
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update PTD$ set PTD=@PTD, INC_TAX=@INC_TAX, NET_PTD=@NET_PTD, BANK_TRANDATE=@BANK_TRANDATE where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                cmd.Parameters.AddWithValue("@PTD", txtPTD.Text);
                cmd.Parameters.AddWithValue("@INC_TAX", Txtincometax.Text);
                cmd.Parameters.AddWithValue("@NET_PTD", lblNetPTD.Text);
                cmd.Parameters.AddWithValue("BANK_TRANDATE", LblCal.Text);
                cmd.Parameters.AddWithValue("EMPNO", Showempid.Text);
                cmd.Parameters.AddWithValue("MONTH", ShowMth.Text);
                cmd.Parameters.AddWithValue("YEAR", Showyr.Text);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Updated Successfully!!');</script>");
                Response.Write("<script language='javascript'>window.location='PartTimeDegreeCourse.aspx';</script>");
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Saving Data!!');</script>");
            }
        }

        protected void Btnclr_Click(object sender, EventArgs e)
        {
            Response.Redirect("PartTimeDegreeCourse.aspx");
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
    }
}