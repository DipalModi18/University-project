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
    public partial class PTPGDCAModification : System.Web.UI.Page
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
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                    String value = Request.QueryString.ToString();
                    Char delimiter = '&';
                    String[] substrings = value.Split(delimiter);

                    if (substrings[0].StartsWith("EMPNO="))
                    {
                        substrings[0] = substrings[0].Remove(0, "EMPNO=".Length).Replace('+', ' ').Trim();
                    }
                    if (substrings[1].StartsWith("MONTH="))
                    {
                        substrings[1] = substrings[1].Remove(0, "MONTH=".Length).Replace('+', ' ').Trim();
                    }
                    if (substrings[2].StartsWith("YEAR="))
                    {
                        substrings[2] = substrings[2].Remove(0, "YEAR=".Length).Replace('+', ' ').Trim();
                    }

                    Int16 Emp = 0, emp;
                    string Mon, Yr;

                    if (Int16.TryParse(substrings[0], out emp))
                    {
                        Emp = emp;
                    }
                    Mon = substrings[1];
                    Yr = substrings[2];

                    //Response.Write("<script>alert('EMPNO =" + Emp + "MONTH=" + Mon + " YEAR=" + Yr + "');</script>");

                    DataSet ds = SelectAllTesingDataById(Emp, Mon, Yr);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        Showempid.Text = Emp.ToString();
                        ShowMth.Text = Mon.ToString();
                        Showyr.Text = Yr.ToString();
                        Txtptpgdca.Text = ds.Tables[0].Rows[0]["PTPGDCA"].ToString();
                        Txtincometax.Text = ds.Tables[0].Rows[0]["INC_TAX"].ToString();
                        Lblnetptpgdca.Text = ds.Tables[0].Rows[0]["NET_PTPGDCA"].ToString();
                        LblCal.Text = ds.Tables[0].Rows[0]["BANK_TRANDATE"].ToString();
                    }
                }
                catch(Exception ee)
                {
                    Response.Write("<script>alert('Error While Fetching Record!!');</script>");
                }
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
                SqlCommand cmd = new SqlCommand("select * from PTPGDCA$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
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
                Response.Write("<script>alert('Error While Saving Data!!');</script>");
                return new DataSet();
            }
        }
        protected void netptpgdca_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(Txtptpgdca.Text) >= Convert.ToDouble(Txtincometax.Text))
                {
                    Double NetAmount = Convert.ToDouble(Txtptpgdca.Text) - Convert.ToDouble(Txtincometax.Text);
                    Lblnetptpgdca.Text = NetAmount.ToString();
                }
                else
                {
                    Lblnetptpgdca.Text = "0";
                }
            }
            catch(FormatException fe)
            {
                Response.Write("<script>alert('Enter Valid Numbers!!');</script>");
            }
        }

        protected void Btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                netptpgdca_Click(null, EventArgs.Empty);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Update PTPGDCA$ set PTPGDCA=@PTPGDCA, INC_TAX=@INC_TAX, NET_PTPGDCA=@NET_PTPGDCA, BANK_TRANDATE=@BANK_TRANDATE where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                cmd.Parameters.AddWithValue("@PTPGDCA", Txtptpgdca.Text);
                cmd.Parameters.AddWithValue("@INC_TAX", Txtincometax.Text);
                cmd.Parameters.AddWithValue("@NET_PTPGDCA", Lblnetptpgdca.Text);
                cmd.Parameters.AddWithValue("BANK_TRANDATE", LblCal.Text);
                cmd.Parameters.AddWithValue("EMPNO", Showempid.Text);
                cmd.Parameters.AddWithValue("MONTH", ShowMth.Text);
                cmd.Parameters.AddWithValue("YEAR", Showyr.Text);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Data Updated Successfully!!');</script>");
                Response.Write("<script language='javascript'>window.location='PTPGDCASearch.aspx';</script>");
            }
            catch (Exception fe)
            {
                Response.Write("<script>alert('Error While Saving Data!!');</script>");
            }
        }

        protected void Btnclr_Click(object sender, EventArgs e)
        {
            Response.Redirect("PTPGDCASearch.aspx");
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