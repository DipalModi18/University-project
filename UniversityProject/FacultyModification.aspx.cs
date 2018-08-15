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
    public partial class FacultyModification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!Page.IsPostBack)
            {
                var facid = Request.QueryString["FACID"];
                DataSet ds = SelectAllFacDataById(Convert.ToInt16(facid));
                lblShowFacId.Text = facid;
                txtFacName.Text = ds.Tables[0].Rows[0]["FACNAME"].ToString();
                txtAdd1.Text = ds.Tables[0].Rows[0]["ADDR1"].ToString();
                txtAdd2.Text = ds.Tables[0].Rows[0]["ADDR2"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["CITY"].ToString();
                txtPin.Text = (ds.Tables[0].Rows[0]["PINCODE"].ToString());
                txtDean.Text = ds.Tables[0].Rows[0]["DEAN"].ToString();
                txtRegister.Text = ds.Tables[0].Rows[0]["REGISTRAR"].ToString();
                txtFax.Text = ds.Tables[0].Rows[0]["FAX"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["PHONE"].ToString();
                txtTanNo.Text = ds.Tables[0].Rows[0]["TANNO"].ToString();
                txtData.Text = ds.Tables[0].Rows[0]["DATA"].ToString();
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

        public DataSet SelectAllFacDataById(int? id)
        {
            SqlConnection con = null;
            //string result = "";
            DataSet ds = null;
            try
             {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());

                if (!(id == 0 || id == null))
                {
                    //id not null but name has something
                    SqlCommand cmd = new SqlCommand("select * from FACULTY_PROFILE$ where FACID=@FACID", con);
                    cmd.Parameters.AddWithValue("FACID", id);
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            /*var facid = lblShowFacId.Text;
            DataSet ds = SelectAllFacDataById(Convert.ToInt16(facid));
            txtFacName.Text = ds.Tables[0].Rows[0]["FACNAME"].ToString();
            txtAdd1.Text = ds.Tables[0].Rows[0]["ADDR1"].ToString();
            txtAdd2.Text = ds.Tables[0].Rows[0]["ADDR2"].ToString();
            txtCity.Text = ds.Tables[0].Rows[0]["CITY"].ToString();
            txtPin.Text = (ds.Tables[0].Rows[0]["PINCODE"].ToString());
            txtDean.Text = ds.Tables[0].Rows[0]["DEAN"].ToString();
            txtRegister.Text = ds.Tables[0].Rows[0]["REGISTRAR"].ToString();
            txtFax.Text = ds.Tables[0].Rows[0]["FAX"].ToString();
            txtPhone.Text = ds.Tables[0].Rows[0]["PHONE"].ToString();
            txtTanNo.Text = ds.Tables[0].Rows[0]["TANNO"].ToString();
            txtData.Text = ds.Tables[0].Rows[0]["DATA"].ToString();*/
            Response.Redirect("Faculty.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            Response.Write("<script>alert(' FACID :"+lblShowFacId.Text+"');</script>");
            try
            {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("update FACULTY_PROFILE$ set FACNAME=@FACNAME, ADDR1=@ADDR1, ADDR2=@ADDR2, CITY=@CITY, PINCODE=@PINCODE, PHONE=@PHONE, FAX=@FAX, DEAN=@DEAN, REGISTRAR=@REGISTRAR, DATA=@DATA, TANNO=@TANNO where FACID=@FACID", con);
            //cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FACID", lblShowFacId.Text);
            cmd.Parameters.AddWithValue("@FACNAME", txtFacName.Text);
            cmd.Parameters.AddWithValue("@ADDR1", txtAdd1.Text);
            cmd.Parameters.AddWithValue("@ADDR2", txtAdd2.Text);
            cmd.Parameters.AddWithValue("@CITY", txtCity.Text);
            cmd.Parameters.AddWithValue("@PINCODE", txtPin.Text);
            cmd.Parameters.AddWithValue("@PHONE", txtPhone.Text);
            cmd.Parameters.AddWithValue("@FAX", txtFax.Text);
            cmd.Parameters.AddWithValue("@DEAN", txtDean.Text);
            cmd.Parameters.AddWithValue("@REGISTRAR", txtRegister.Text);
            cmd.Parameters.AddWithValue("@DATA", txtData.Text);
            cmd.Parameters.AddWithValue("@TANNO", txtTanNo.Text);
            Response.Write("<script>alert('facid:"+lblShowFacId.Text+" facname :"+txtFacName.Text+"');</script>");
            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Faculty Updated Successfully!!');</script>");
            Response.Write("<script language='javascript'>window.location='Faculty.aspx';</script>");
            }
            catch
            {
                Response.Write("<script>alert('Error while saving data!!');</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}