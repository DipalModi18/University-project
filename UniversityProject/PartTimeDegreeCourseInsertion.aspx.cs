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
    public partial class PartTimeDegreeCourseInsertion : System.Web.UI.Page
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
                TxtPTD.Text = "0";
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

        protected void BtnDAArears_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(TxtPTD.Text) >= Convert.ToDouble(Txtincometax.Text))
                {
                    Double NetAmount = Convert.ToDouble(TxtPTD.Text) - Convert.ToDouble(Txtincometax.Text);
                    LblnetPTD.Text = NetAmount.ToString();
                }
                else
                {
                    LblnetPTD.Text = "0";
                }
            }
            catch (FormatException fe)
            {
                Response.Write("<script>alert('Enter Valid Numbers');</script>");
                LblnetPTD.Text = "0";
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
                    //Response.Write("<script language='javascript'>window.location='DaArrearsSearch.aspx';</script>");
                }
                else
                {
                    con.Open();

                    cmd = new SqlCommand("select EMPNO from PTD$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
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
                        BtnDAArears_Click(null, EventArgs.Empty);
                        con.Open();
                        cmd = new SqlCommand("Insert into PTD$ values(@EMPNO, @MONTH, @YEAR, @PTD, @INC_TAX, @NET_PTD, @BANK_TRANDATE)", con);
                        cmd.Parameters.AddWithValue("@EMPNO", txtempid.Text);
                        cmd.Parameters.AddWithValue("@MONTH", DropDownListMonth.SelectedValue);
                        cmd.Parameters.AddWithValue("@YEAR", TxtYear.Text);
                        cmd.Parameters.AddWithValue("@PTD", TxtPTD.Text);
                        cmd.Parameters.AddWithValue("@INC_TAX", Txtincometax.Text);
                        cmd.Parameters.AddWithValue("@NET_PTD", LblnetPTD.Text);
                        cmd.Parameters.AddWithValue("@BANK_TRANDATE", LblCal.Text);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Entry Added Successfully!!');</script>");
                        Response.Write("<script language='javascript'>window.location='PartTimeDegreeCourse.aspx';</script>");
                    }
                }
            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('Error while saving data!!');</script>");
            }
        }

        protected void Btnclr_Click(object sender, EventArgs e)
        {
            Response.Redirect("PartTimeDegreeCourse.aspx");
        }
    }
}