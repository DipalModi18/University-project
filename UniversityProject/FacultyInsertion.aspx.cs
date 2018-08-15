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
    public partial class FacultyInsertion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
        //bool IsDataValid = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
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

        protected void btnSave1_Click(object sender, EventArgs e)
        {
            Boolean successInsertion = false;
           //if(IsDataValid)
            //{
                try
                {
                    // TODO: Add insert logic here
                    SqlCommand cmd = new SqlCommand("Insert into FACULTY_PROFILE$ values(@FACID,@FACNAME,@ADDR1,@ADDR2,@CITY,@PINCODE,@PHONE,@FAX,@DEAN,@REGISTRAR,@DATA,@TANNO)", con);
                    cmd.Parameters.AddWithValue("FACID", txtfacId.Text);
                    cmd.Parameters.AddWithValue("FACNAME", txtFacName.Text);
                    cmd.Parameters.AddWithValue("ADDR1", txtAdd1.Text);
                    cmd.Parameters.AddWithValue("ADDR2", txtAdd2.Text);
                    cmd.Parameters.AddWithValue("CITY", txtCity.Text);
                    cmd.Parameters.AddWithValue("PINCODE", txtPin.Text);
                    cmd.Parameters.AddWithValue("PHONE", txtPhone.Text);
                    cmd.Parameters.AddWithValue("FAX", txtFax.Text);
                    cmd.Parameters.AddWithValue("DEAN", txtDean.Text);
                    cmd.Parameters.AddWithValue("REGISTRAR", txtRegister.Text);
                    cmd.Parameters.AddWithValue("DATA", txtData.Text);
                    cmd.Parameters.AddWithValue("TANNO", txtTanNo.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Faculty Added Successfully!!');</script>");
                    //Response.Write("<script language='javascript'>window.location='Faculty.aspx';</script>");
                    successInsertion = true;
                }
                catch(Exception ee)
                {
                    successInsertion = false;
                    if(con.State==ConnectionState.Open)
                    {
                        con.Close();
                    }
                    Response.Write("<script>alert('Error While Saving Data!!');</script>");
                }
                if(successInsertion==true)
                {
                    try
                    {
                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        SqlCommand cmd = new SqlCommand("insert into USERS$ values(@ID,@USERNAME,@PASSWORD)",con);
                        cmd.Parameters.AddWithValue("@ID", txtfacId.Text);
                        cmd.Parameters.AddWithValue("@USERNAME", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@PASSWORD", txtPassword.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Faculty User Added Successfully!!');</script>");
                        Response.Write("<script language='javascript'>window.location='Faculty.aspx';</script>");
                    }
                    catch(Exception ee)
                    {
                        try
                        {
                            if (con.State == ConnectionState.Open)
                            {
                                con.Close();
                            }
                            Response.Write("<script>alert('Error While Saving Data!!');</script>");
                            SqlCommand cmd = new SqlCommand("delete from FACULTY_PROFILE$ where FACID=@FACID", con);
                            cmd.Parameters.AddWithValue("@FACID", txtfacId.Text);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script>alert('Error While Saving Data!!');</script>");
                        }
                        catch(Exception eee)
                        {
                            Response.Write("<script>alert('Error While Saving Data!!');</script>");
                        }
                    }
                }
            //}     
        }

        protected void btnCancel1_Click(object sender, EventArgs e)
        {
            /*txtfacId.Text = "";
            txtFacName.Text = "";
            txtAdd1.Text = "";
            txtAdd2.Text = "";
            txtCity.Text = "";
            txtPin.Text = "";
            txtDean.Text = "";
            txtRegister.Text = "";
            txtFax.Text = "";
            txtPhone.Text = "";
            txtTanNo.Text = "";
            txtData.Text = "";*/
            Response.Redirect("Faculty.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlCommand cmd = new SqlCommand("select FACID from FACULTY_PROFILE$ where FACID=@FACID",con);
            cmd.Parameters.AddWithValue("FACID", txtfacId.Text);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            Int32? facid = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            if ((facid == null || facid == 0) && facid!=100)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(txtPassword.Text.Length>=8)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlCommand cmd = new SqlCommand("select * from USERS$ where USERNAME=@USERNAME", con);
            cmd.Parameters.AddWithValue("@USERNAME", txtUsername.Text);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if(rdr.HasRows)
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