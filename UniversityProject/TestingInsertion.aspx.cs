using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace UniversityProject
{
    public partial class TestingInsertion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Txtincometax.Text = "0";
                Txttesting.Text = "0";

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

        protected void nettesting_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Txttesting.Text) >= Convert.ToInt32(Txtincometax.Text))
                {
                    Int64 NetAmount = Convert.ToInt32(Txttesting.Text) - Convert.ToInt32(Txtincometax.Text);
                    Lblnettesting.Text = NetAmount.ToString();
                }
                else
                {
                    Lblnettesting.Text = "0";
                }
            }
            catch (FormatException ee)
            {
                Response.Write("<script>alert('Enter Valid Numbers!!');</script>");
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
            LblCal.Text = Calendar1.SelectedDate.ToShortDateString();
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

        protected void Btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select EMPNO from EMP_PROFILE$ where EMPNO=@EMPNO ", con);
                cmd.Parameters.AddWithValue("EMPNO", txtempid.Text);
                var noo = cmd.ExecuteScalar();
                con.Close();
                if (noo == null)
                {
                    Response.Write("<script>alert('There is no employee with this id');</script>");
                    Response.Write("<script language='javascript'>window.location='TestingSearch.aspx';</script>");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("select EMPNO from TESTING$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                    cmd.Parameters.AddWithValue("EMPNO", txtempid.Text);
                    cmd.Parameters.AddWithValue("MONTH", DropDownListMonth.SelectedValue);
                    cmd.Parameters.AddWithValue("YEAR", TxtYear.Text);
                    var no = cmd.ExecuteScalar();
                    con.Close();
                    if (no != null)
                    {
                        Response.Write("<script>alert('This entry already exists');</script>");
                    }
                    else
                    {
                        con.Open();
                        cmd = new SqlCommand("Insert into TESTING$ values(@EMPNO, @MONTH, @YEAR, @TESTING, @INC_TAX, @NET_TESTING, @BANK_TRANDATE)", con);
                        cmd.Parameters.AddWithValue("@EMPNO", txtempid.Text);
                        cmd.Parameters.AddWithValue("@MONTH", DropDownListMonth.SelectedValue);
                        cmd.Parameters.AddWithValue("@YEAR", TxtYear.Text);
                        cmd.Parameters.AddWithValue("@TESTING", Txttesting.Text);
                        cmd.Parameters.AddWithValue("@INC_TAX", Txtincometax.Text);
                        cmd.Parameters.AddWithValue("@NET_TESTING", Lblnettesting.Text);
                        cmd.Parameters.AddWithValue("@BANK_TRANDATE", LblCal.Text);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Entry Added Successfully!!');</script>");
                        Response.Write("<script language='javascript'>window.location='TestingSearch.aspx';</script>");
                    }
                }
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error While Saving Record!!');</script>");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        protected void Btnclr_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestingSearch.aspx");
        }
    }
}