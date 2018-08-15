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
    public partial class Faculty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if(Session["User_Id"].ToString()==(100).ToString())
            {
                HyperLink1.Enabled = true;
            }
            else
            {
                HyperLink1.Enabled = false;
            }
            if (!Page.IsPostBack)
                {
                load_gridview();
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

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int isdeleted = 0;
            SqlConnection con= new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString()); 
            foreach(GridViewRow row in GridView1.Rows)
            {
                var chkdel = row.FindControl("CheckBoxDelete") as CheckBox;
                if(chkdel.Checked)
                {
                    var facid= GridView1.Rows[row.RowIndex].Cells[1].Text;
                    //<script>alert('No Record Found!!');</script>
                    /*Response.Write("<script>DeleteConfirm(" + facid + ")</script>");
                    string Confirmation = Request.Form["confirm_value"];
                    if (Confirmation == "yes")
                    {*/
                        SqlCommand cmd = new SqlCommand("delete from FACULTY_PROFILE$ where FACID=@facid", con);
                        cmd.Parameters.AddWithValue("facid", facid);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    isdeleted = 1;
                    /*}
                    else
                    {

                    }*/
                }
            }
            if(isdeleted==1)
            {
                Response.Write("<script>alert('Records Deleted Successfully!!');</script>");
            }
            load_gridview();
        }

       public void load_gridview()
        {
            if (Session["User_Id"].ToString() == (100).ToString())
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("select * from FACULTY_PROFILE$", con);
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("select * from FACULTY_PROFILE$ where FACID=@FACID", con);
                cmd.Parameters.AddWithValue("FACID", Session["User_Id"]);
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        public bool AllowSearch()
        {
            if((TextBoxFacID.Text=="" || TextBoxFacID.Text==null) && (TextBoxFacName.Text==null || TextBoxFacName.Text==""))
            {
                Response.Write("<script>alert('Please enter any search criteria!!');</script>");
                return false;
            }
            return true;
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (AllowSearch())
            {
                if (TextBoxFacID.Text == null || TextBoxFacID.Text == "")
                {
                    DataSet ds = SelectAllFacDataByIdName(0, TextBoxFacName.Text);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    DataSet ds = SelectAllFacDataByIdName(Convert.ToInt16(TextBoxFacID.Text.ToString()), TextBoxFacName.Text);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            
        }

        public DataSet SelectAllFacDataByIdName(int? id, string name)
        {
            SqlConnection con = null;
            //string result = "";
            DataSet ds = null;
           // try
            //{
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());

            if (Session["User_Id"].ToString() == (100).ToString())
            {
                if ((id == 0 || id == null) && (name == null || name == ""))
                {
                    SqlCommand cmd = new SqlCommand("select * from FACULTY_PROFILE$", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                else if ((id == 0 || id == null) && !(name == null || name == ""))
                {
                    //id null but name not null
                    SqlCommand cmd = new SqlCommand("select * from FACULTY_PROFILE$ where FACNAME like '%'+@FACNAME+'%'", con);
                    cmd.Parameters.AddWithValue("FACNAME", name);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                else if (!(id == 0 || id == null) && (name == null || name == ""))
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
                    //both has something
                    SqlCommand cmd = new SqlCommand("select * from FACULTY_PROFILE$ where FACID=@FACID AND FACNAME like '%'+@FACNAME+'%'", con);
                    cmd.Parameters.AddWithValue("FACID", id);
                    cmd.Parameters.AddWithValue("FACNAME", name);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            else
            {
                if ((id == 0 || id == null) && (name == null || name == ""))
                {
                    SqlCommand cmd = new SqlCommand("select * from FACULTY_PROFILE$ where FACID=@FACID", con);
                    cmd.Parameters.AddWithValue("FACID", Session["User_Id"].ToString());
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                else if ((id == 0 || id == null) && !(name == null || name == ""))
                {
                    //id null but name not null
                    SqlCommand cmd = new SqlCommand("select * from FACULTY_PROFILE$ where FACNAME like '%'+@FACNAME+'%' and FACID=@FACID", con);
                    cmd.Parameters.AddWithValue("FACNAME", name);
                    cmd.Parameters.AddWithValue("FACID", Session["User_Id"].ToString());
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                else if (!(id == 0 || id == null) && (name == null || name == ""))
                {
                    //id not null but name has something
                    SqlCommand cmd = new SqlCommand("select * from FACULTY_PROFILE$ where FACID=@FACID", con);
                    cmd.Parameters.AddWithValue("FACID", Session["User_Id"].ToString());
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                else
                {
                    //both has something
                    SqlCommand cmd = new SqlCommand("select * from FACULTY_PROFILE$ where FACID=@FACID AND FACNAME like '%'+@FACNAME+'%'", con);
                    cmd.Parameters.AddWithValue("FACID", Session["User_Id"].ToString());
                    cmd.Parameters.AddWithValue("FACNAME", name);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            /*}
           catch
            {
                return ds;
            }
            finally
            {
                con.Close();
            }*/
        }
    }
}