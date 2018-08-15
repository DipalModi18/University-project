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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["User_Id"] = null;
            }
        }

        //public void Page_PreInit(object sender, EventArgs e)
        //{
        //    //base.OnPreInit(e);
        //    if (Session["User_Id"] == null)
        //    {
        //        Response.Redirect("LoginPage.aspx");

        //    }
        //    else
        //    {
        //        if (Session["User_Id"].ToString() == (100).ToString())
        //        {
        //            MasterPageFile = "Site2.master";
        //        }
        //        else
        //        {
        //            MasterPageFile = "Site3.master";
        //        }
        //    }
        //}

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Select * from USERS$ where USERNAME=@USERNAME", con);
            cmd.Parameters.AddWithValue("USERNAME", Login1.UserName);
            con.Open();
            da.SelectCommand = cmd;
            da.Fill(ds);
            con.Close();
            

            if(ds.Tables.Count==0 && Login1.UserName!=null)
            {
                Response.Write("<script>alert('No such User exists!!');</script>");
            }
            else
            {
                string password = ds.Tables[0].Rows[0]["PASSWORD"].ToString();
                if (Login1.UserName == "admin" && ds.Tables[0].Rows[0]["USERNAME"].ToString() == "admin")
                {
                    if (Login1.Password == password)
                    {
                        Session["User_Id"] = Convert.ToInt16(ds.Tables[0].Rows[0]["ID"].ToString());
                        Label1.Text = "admin";
                        Response.Redirect("~/HomePage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong password!!');</script>");
                    }
                }
                else if(Login1.UserName!="admin")
                {
                    if(Login1.Password==password)
                    {
                        Session["User_Id"] = Convert.ToInt16(ds.Tables[0].Rows[0]["ID"].ToString());
                        Label1.Text = Session["User_Id"].ToString();
                        Response.Redirect("~/HomePage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Wrong password!!');</script>");
                    }
                }
            }
            
        }
    }
}