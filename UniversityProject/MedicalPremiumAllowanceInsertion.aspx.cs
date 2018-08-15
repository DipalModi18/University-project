using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace UniversityProject
{
    public partial class MedicalPremiumAllowanceInsertion : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
        SqlCommand cmd;
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

        protected void btnsave_Click(object sender, EventArgs e)
        {
            foreach (ListItem SelfParent in CheckBoxListSelfParent.Items)
            {
                if (SelfParent.Selected)
                {
                    foreach (ListItem SeniorCitizen in CheckBoxListSeniorCitizen.Items)
                    {
                        if (SeniorCitizen.Selected)
                        {
                            con.Open();
                            cmd = new SqlCommand("select WHOM from MEDICALPREMIUMALLOWANCE where WHOM=@WHOM and AGE=@AGE and YEAR=@YEAR", con);
                            cmd.Parameters.AddWithValue("WHOM", SelfParent.Text);
                            cmd.Parameters.AddWithValue("AGE", SeniorCitizen.Text);
                            cmd.Parameters.AddWithValue("YEAR", TxtYr1.Text);
                            //cmd.Parameters.AddWithValue("AMOUNT", TxtAmount.Text);
                            var no = cmd.ExecuteScalar();
                            con.Close();
                            if (no != null)
                            {
                                Response.Write("<script>alert('Data for "+TxtYr1.Text+" : "+SelfParent.Text+" : "+SeniorCitizen.Text+" already exists');</script>");
                                //Response.Write("<script language='javascript'>window.location='MedicalPremiumAllowanceSearch.aspx';</script>");
                            }
                            else
                            {
                                con.Open();
                                cmd = new SqlCommand("Insert into MEDICALPREMIUMALLOWANCE values(@WHOM, @AGE, @YEAR, @AMOUNT)", con);
                                cmd.Parameters.AddWithValue("WHOM", SelfParent.Text);
                                cmd.Parameters.AddWithValue("AGE", SeniorCitizen.Text);
                                cmd.Parameters.AddWithValue("YEAR", TxtYr1.Text);
                                cmd.Parameters.AddWithValue("AMOUNT", TxtAmount.Text);
                                cmd.ExecuteNonQuery();
                                con.Close();
                                Response.Write("<script>alert('Details for " + TxtYr1.Text + " : " + SelfParent.Text + " : " + SeniorCitizen.Text + " Are Added Successfully!!');</script>");
                                //Response.Write("<script language='javascript'>window.location='MedicalPremiumAllowanceSearch.aspx';</script>");
                            }
                        }
                    }
                }
            }
            Response.Redirect("MedicalPremiumAllowanceSearch.aspx");
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManualPremiumAllowanceSearch.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            foreach (ListItem l in CheckBoxListSelfParent.Items)
            {
                if (l.Selected)
                {
                    args.IsValid = true;
                }
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            foreach (ListItem l in CheckBoxListSeniorCitizen.Items)
            {
                if (l.Selected)
                {
                    args.IsValid = true;
                }
            }
        }

        protected void TxtYr1_TextChanged(object sender, EventArgs e)
        {
            TxtYr2.Text = (Convert.ToInt16(TxtYr1.Text) + 1).ToString();
        }
    }
}