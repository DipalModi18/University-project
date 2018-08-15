using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;

namespace UniversityProject
{
    public partial class IncomeTaxInsertion : System.Web.UI.Page
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
            Boolean added = false;
            if (Convert.ToInt32(Txtlb.Text) >= Convert.ToInt32(TxtUb.Text))
            {
                Txtlb.Text = "0";
                TxtUb.Text = "0";
                Response.Write("<script>alert('Lower Bound Value Must Be Smaller Than Upper BOund.');</script>");
            }
            else
            {
                foreach (ListItem GenderItem in CheckBoxListGender.Items)
                {
                    if (GenderItem.Selected)
                    {
                        foreach (ListItem AgegroupItem in CheckBoxListAgegroup.Items)
                        {
                            if (AgegroupItem.Selected)
                            {
                                con.Open();
                                cmd = new SqlCommand("select YEAR1 from INCOMETAXSLAB where YEAR1=@YEAR1 and SLABNO=@SLABNO and GENDER=@GENDER and AGEGROUP=@AGEGROUP", con);
                                cmd.Parameters.AddWithValue("YEAR1", TxtYear1.Text);
                                cmd.Parameters.AddWithValue("SLABNO", TxtSlabNo.Text);
                                cmd.Parameters.AddWithValue("GENDER", GenderItem.Text);
                                cmd.Parameters.AddWithValue("AGEGROUP", AgegroupItem.Text);
                                var no = cmd.ExecuteScalar();
                                con.Close();
                                if (no != null)
                                {
                                    Response.Write("<script>alert('This data already exsists');</script>");
                                }
                                else
                                {
                                    con.Open();
                                    cmd = new SqlCommand("Insert into INCOMETAXSLAB values(@YEAR1, @SLABNO, @LOWERBOUND, @UPPERBOUND, @AGEGROUP, @GENDER , @PERCENTAGE, @YEAR2, @EDU_CESS, @HIGHER_EDUCESS)", con);
                                    cmd.Parameters.AddWithValue("@YEAR1", TxtYear1.Text);
                                    cmd.Parameters.AddWithValue("@SLABNO", TxtSlabNo.Text);
                                    cmd.Parameters.AddWithValue("@LOWERBOUND", Txtlb.Text);
                                    cmd.Parameters.AddWithValue("@UPPERBOUND", TxtUb.Text);
                                    cmd.Parameters.AddWithValue("@AGEGROUP", AgegroupItem.Text);
                                    cmd.Parameters.AddWithValue("@GENDER", GenderItem.Text);
                                    cmd.Parameters.AddWithValue("@PERCENTAGE", TxtPecent.Text);
                                    cmd.Parameters.AddWithValue("@YEAR2", txtYear2.Text);
                                    cmd.Parameters.AddWithValue("@EDU_CESS", txtEduCess.Text);
                                    cmd.Parameters.AddWithValue("@HIGHER_EDUCESS", txtHigherEducess.Text);
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    Response.Write("<script>alert('Income Tax Details for " + GenderItem.Text + " & "+AgegroupItem.Text+" Are Added Successfully!!');</script>");
                                    added = true;
                                }
                            }
                        }
                    }
                }
                if (added)
                {
                    Response.Write("<script>alert('Income Tax Details Are Added Successfully!!');</script>");
                }
                //Response.Redirect("IncomeTaxSearch.aspx");
                Response.Write("<script language='javascript'>window.location='IncomeTaxSearch.aspx';</script>");
            }


        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncomeTaxSearch.aspx");
        }

        protected void TxtYear1_TextChanged(object sender, EventArgs e)
        {
            txtYear2.Text = (Convert.ToInt16(TxtYear1.Text) + 1).ToString();
        }



        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            foreach (ListItem GenderItem in CheckBoxListGender.Items)
            {
                if (GenderItem.Selected)
                {
                    args.IsValid = true;
                }
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            foreach(ListItem AgegroupItem in CheckBoxListAgegroup.Items)
            {
                if(AgegroupItem.Selected)
                {
                    args.IsValid = true;
                }
            }
        }
    }
}