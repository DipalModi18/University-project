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
    public partial class DaArrearsModification : System.Web.UI.Page
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
                //String value = Request.QueryString.ToString();
                //Char delimiter = '&';
                //String[] substrings = value.Split(delimiter);

                //if (substrings[0].StartsWith("EMPNO="))
                //{
                //    substrings[0] = substrings[0].Remove(0, "EMPNO=".Length).Replace('+', ' ').Trim();
                //}
                //if (substrings[1].StartsWith("MONTH="))
                //{
                //    substrings[1] = substrings[1].Remove(0, "MONTH=".Length).Replace('+', ' ').Trim();
                //}
                //if (substrings[2].StartsWith("YEAR="))
                //{
                //    substrings[2] = substrings[2].Remove(0, "YEAR=".Length).Replace('+', ' ').Trim();
                //}

                Int16 Emp = 0;
                string Mon, Yr;

                //if (Int16.TryParse(substrings[0], out emp))
                //{
                //    Emp = emp;
                //}
                //Mon = substrings[1];
                //Yr = substrings[2];
                Emp = Convert.ToInt16(Request.QueryString["EMPNO"]);
                Mon = Request.QueryString["MONTH"];
                Yr = Request.QueryString["YEAR"];

                //Response.Write("<script>alert('EMPNO =" + Emp + "MONTH=" + Mon + " YEAR=" + Yr + "');</script>");

                DataSet ds = SelectAllTesingDataById(Emp, Mon, Yr);
                Showempid.Text = Emp.ToString();
                ShowMth.Text = Mon.ToString();
                Showyr.Text = Yr.ToString();
                TxtDAArrears.Text = ds.Tables[0].Rows[0]["DAARREARS"].ToString();
                Txtincometax.Text = ds.Tables[0].Rows[0]["INC_TAX"].ToString();
                LblnetDAArrears.Text = ds.Tables[0].Rows[0]["NET_DAARREARS"].ToString();
                LblCal.Text = ds.Tables[0].Rows[0]["BANK_TRANDATE"].ToString();

            }

        }
        /* emp name is remaining
         query need to fire
              */

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
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                DataSet ds = null;
                con.Open();
                // Response.Write("<script>alert('EMPNO =" + Emp + "MONTH=" + Mon + " YEAR=" + Yr + "');</script>");
                SqlCommand cmd = new SqlCommand("select * from DAARREARS$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                cmd.Parameters.AddWithValue("EMPNO", Emp);
                cmd.Parameters.AddWithValue("MONTH", Mon);
                cmd.Parameters.AddWithValue("YEAR", Yr);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Fetching Record!!');</script>");
            }
        }
        protected void netDAArrears_Click(object sender, EventArgs e)
        {
            Double NetAmount = Convert.ToDouble(TxtDAArrears.Text) - Convert.ToDouble(Txtincometax.Text);
            if (NetAmount < 0)
            {
                LblnetDAArrears.Text = "0";
            }
            else
            {
                LblnetDAArrears.Text = NetAmount.ToString();
            }
        }

        protected void Btnsave_Click(object sender, EventArgs e)
        {
            netDAArrears_Click(null, EventArgs.Empty);
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update DAARREARS$ set DAARREARS=@DAARREARS, INC_TAX=@INC_TAX, NET_DAARREARS=@NET_DAARREARS, BANK_TRANDATE=@BANK_TRANDATE where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                cmd.Parameters.AddWithValue("@DAARREARS", TxtDAArrears.Text);
                cmd.Parameters.AddWithValue("@INC_TAX", Txtincometax.Text);
                cmd.Parameters.AddWithValue("@NET_DAARREARS", LblnetDAArrears.Text);
                cmd.Parameters.AddWithValue("BANK_TRANDATE", LblCal.Text);
                cmd.Parameters.AddWithValue("EMPNO", Showempid.Text);
                cmd.Parameters.AddWithValue("MONTH", ShowMth.Text);
                cmd.Parameters.AddWithValue("YEAR", Showyr.Text);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Updated Successfully!!');</script>");
                Response.Write("<script language='javascript'>window.location='DAArrears.aspx';</script>");
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Saving Data!!');</script>");
            }
        }

        protected void Btnclr_Click(object sender, EventArgs e)
        {
            Response.Redirect("DaArrears.aspx");
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