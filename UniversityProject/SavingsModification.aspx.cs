using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace UniversityProject
{
    public partial class SavingsModification : System.Web.UI.Page
    {
        //List<string> DynamicControlsList1;
        //List<string> DynamicControlsList2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {

                String value = Request.QueryString.ToString();
                Char delimiter = '&';
                String[] substrings = value.Split(delimiter);
                if (substrings[0].StartsWith("EMPNO="))
                {
                    substrings[0] = substrings[0].Remove(0, "EMPNO=".Length);
                }
                if (substrings[1].StartsWith("SAVING_YEAR="))
                {
                    substrings[1] = substrings[1].Remove(0, "SAVING_YEAR=".Length);
                }

                Int16 Empid = 0, SavingYear = 0, id, year;
                if (Int16.TryParse(substrings[0], out id))
                {
                    Empid = id;
                }
                if (Int16.TryParse(substrings[1], out year))
                {
                    SavingYear = year;
                }

                Response.Write("<script>alert('empid=" + substrings[0] + " saving year=" + substrings[1] + "');</script>");
                lblEmployeeNoValue.Text = substrings[0];
                lblSavingYearValue.Text = substrings[1];

                DataSet ds = SetDataValues(Convert.ToInt16(substrings[0]), Convert.ToInt16(substrings[1]));

                txtConToPension.Text = ds.Tables[0].Rows[0]["CONTTOPENSION"].ToString();
                txtMediPremium.Text = ds.Tables[0].Rows[0]["MEDICLAIM"].ToString();
                txtHandicappedDepend.Text = ds.Tables[0].Rows[0]["HANDICAPPED"].ToString();
                txtMediTreatment.Text = ds.Tables[0].Rows[0]["MEDICAL"].ToString();
                txtRepayLoan.Text = ds.Tables[0].Rows[0]["EDULOAN"].ToString();
                txtDonationCmrf.Text = ds.Tables[0].Rows[0]["DONATION"].ToString();
                txtBlindOrPh.Text = ds.Tables[0].Rows[0]["PHDISABLED"].ToString();
                txtPPF.Text = ds.Tables[0].Rows[0]["PUBLICPF"].ToString();
                txtRepayHouseLoan.Text = ds.Tables[0].Rows[0]["HOUSELOAN"].ToString();
                txtInterestHouseLoan.Text = ds.Tables[0].Rows[0]["INTONHOUSELOAN"].ToString();
                txtAccureudInterestNSC.Text = ds.Tables[0].Rows[0]["INTONNSC"].ToString();
                txtNSS.Text = ds.Tables[0].Rows[0]["NSS"].ToString();
                txtMutualFund.Text = ds.Tables[0].Rows[0]["MUTUALFUNDS"].ToString();
                txtEquityLinked.Text = ds.Tables[0].Rows[0]["EQUITYLINK"].ToString();
                txtTutionFees.Text = ds.Tables[0].Rows[0]["TUTIONFEES"].ToString();
                txtNSC.Text = ds.Tables[0].Rows[0]["NSC"].ToString();
                txtLicPremium.Text = ds.Tables[0].Rows[0]["LIC"].ToString();
                txtJeevanSuraksha.Text = ds.Tables[0].Rows[0]["JEEVANSURAKSHA"].ToString();
                txtPostalInvestment.Text = ds.Tables[0].Rows[0]["LIPOSTAL"].ToString();
                txtUnitInsurance.Text = ds.Tables[0].Rows[0]["UNITLINK"].ToString();
                txtInfrastructureBond.Text = ds.Tables[0].Rows[0]["MEP"].ToString();
                txtInvestmentInfrastructure.Text = ds.Tables[0].Rows[0]["INVSTINFRA"].ToString();
                txtOthers.Text = ds.Tables[0].Rows[0]["OTHERS"].ToString();
                txtSec80CCG.Text = ds.Tables[0].Rows[0]["SEC80CCG"].ToString();
                txtSec80DDB.Text = ds.Tables[0].Rows[0]["SEC80DDB"].ToString();
                txtSec80GG.Text = ds.Tables[0].Rows[0]["SEC80GG"].ToString();
                txtSec80GGC.Text = ds.Tables[0].Rows[0]["SEC80GGC"].ToString();
                txtSec80TTA.Text = ds.Tables[0].Rows[0]["SEC80TTA"].ToString();
                txtSec80U.Text = ds.Tables[0].Rows[0]["SEC80U"].ToString();
                txtNPS.Text = ds.Tables[0].Rows[0]["NPS"].ToString();

                foreach (string s in Globals.DynamicControlsList1)
                {
                    (placeholder.FindControl("txt" + s) as TextBox).Text = ds.Tables[0].Rows[0][s].ToString();
                }
                foreach (string s in Globals.DynamicControlsList2)
                {
                    (PlaceHolder2.FindControl("txt" + s) as TextBox).Text = ds.Tables[0].Rows[0][s].ToString();
                }
            }
        }

        public void Page_Init(object sender, EventArgs e)
        {
            Globals.DynamicControlsList1 = new List<string>();
            Globals.DynamicControlsList2 = new List<string>();
            CreateDynamicControls();
        }

        public void CreateDynamicControls()
        {
            //80C sections
            SqlConnection con = con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("select * from SECTIONS", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                HtmlGenericControl tr = new HtmlGenericControl("tr");
                HtmlGenericControl td = new HtmlGenericControl("td");
                HtmlGenericControl td1 = new HtmlGenericControl("td");
                HtmlGenericControl td2 = new HtmlGenericControl("td");

                string ControlName = (string)rdr["NAME"];
                ControlName = ControlName.Replace(" ", "");
                Globals.DynamicControlsList1.Add(ControlName);

                Label DyLabel = new Label();
                DyLabel.ID = "lbl" + ControlName;
                DyLabel.Text = (string)rdr["NAME"];
                DyLabel.CssClass = "lblStyle";
                td.Controls.Add(DyLabel);
                tr.Controls.Add(td);

                TextBox DyTextBox = new TextBox();
                DyTextBox.ID = "txt" + ControlName;
                //Response.Write("<script>alert('DyTextBox.ID:" + DyTextBox.ID.ToString() + "');</script>");
                DyTextBox.Text = "0";
                DyTextBox.EnableViewState = true;
                DyTextBox.Attributes.Add("runat", "server");
                td1.Controls.Add(DyTextBox);
                tr.Controls.Add(td1);

                RegularExpressionValidator rev = new RegularExpressionValidator();
                rev.ID = "rev" + ControlName;
                rev.Attributes.Add("runat", "server");
                rev.ValidationExpression = "[+-]?([0-9]*[.])?[0-9]+";
                rev.ControlToValidate = "txt" + ControlName;
                rev.ErrorMessage = "Enter a valid Number";
                rev.ValidationGroup = "INSERT";
                td2.Controls.Add(rev);
                tr.Controls.Add(td2);

                placeholder.Controls.Add(tr);
                placeholder.Controls.Add(new HtmlGenericControl("br"));
            }
            rdr.Close();
            con.Close();


            // SavingsSections
            con.Open();
            cmd = new SqlCommand("SELECT * FROM SAVINGS_SECTIONS$ WHERE NAME != '80C'", con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                HtmlGenericControl tr = new HtmlGenericControl("tr");
                HtmlGenericControl td = new HtmlGenericControl("td");
                HtmlGenericControl td1 = new HtmlGenericControl("td");
                HtmlGenericControl td2 = new HtmlGenericControl("td");//for valid number check

                string ControlName = (string)rdr["NAME"];
                ControlName = ControlName.Replace(" ", "");
                Globals.DynamicControlsList2.Add(ControlName);
                Label DyLabel = new Label();
                DyLabel.ID = "lbl" + ControlName;
                DyLabel.Text = (string)rdr["NAME"];
                DyLabel.CssClass = "lblStyle";
                td.Controls.Add(DyLabel);
                tr.Controls.Add(td);

                TextBox DyTextBox = new TextBox();
                DyTextBox.ID = "txt" + ControlName;
                //Response.Write("<script>alert('DyTextBox.ID:" + DyTextBox.ID.ToString() + "');</script>");
                DyTextBox.Text = "0";
                DyTextBox.EnableViewState = true;
                DyTextBox.Attributes.Add("runat", "server");
                td1.Controls.Add(DyTextBox);
                tr.Controls.Add(td1);

                RegularExpressionValidator rev = new RegularExpressionValidator();
                rev.ID = "rev" + ControlName;
                rev.Attributes.Add("runat", "server");
                rev.ValidationExpression = "[+-]?([0-9]*[.])?[0-9]+";
                rev.ControlToValidate = "txt" + ControlName;
                rev.ErrorMessage = "Enter a valid Number";
                rev.ValidationGroup = "INSERT";
                td2.Controls.Add(rev);
                tr.Controls.Add(td2);

                PlaceHolder2.Controls.Add(tr);
                PlaceHolder2.Controls.Add(new HtmlGenericControl("br"));
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

        public DataSet SetDataValues(int empno,int saving_year)
        {
            DataSet ds = new DataSet();
            SqlConnection con = con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("select * from SAVINGS$ where EMPNO=@EMPNO and SAVING_YEAR=@SAVING_YEAR", con);
            cmd.Parameters.AddWithValue("EMPNO", empno);
            cmd.Parameters.AddWithValue("SAVING_YEAR", saving_year);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            con.Close();
            return ds;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            /*txtConToPension.Text = "0";
            txtMediPremium.Text = "0";
            txtHandicappedDepend.Text = "0";
            txtMediTreatment.Text = "0";
            txtRepayLoan.Text = "0";
            txtDonationCmrf.Text = "0";
            txtBlindOrPh.Text = "0";
            txtPPF.Text = "0";
            txtRepayHouseLoan.Text = "0";
            txtInterestHouseLoan.Text = "0";
            txtAccureudInterestNSC.Text = "0";
            txtNSS.Text = "0";
            txtMutualFund.Text = "0";
            txtEquityLinked.Text = "0";
            txtTutionFees.Text = "0";
            txtNSC.Text = "0";
            txtLicPremium.Text = "0";
            txtJeevanSuraksha.Text = "0";
            txtPostalInvestment.Text = "0";
            txtUnitInsurance.Text = "0";
            txtInfrastructureBond.Text = "0";
            txtInvestmentInfrastructure.Text = "0";
            txtOthers.Text = "0";
            txtSec80CCG.Text = "0";
            txtSec80DDB.Text = "0";
            txtSec80GG.Text = "0";
            txtSec80GGC.Text = "0";
            txtSec80TTA.Text = "0";
            txtSec80U.Text = "0";
            txtNPS.Text = "0";
            foreach (string s in Globals.DynamicControlsList1)
            {
                (placeholder.FindControl("txt" + s) as TextBox).Text = "0";
            }
            foreach (string s in Globals.DynamicControlsList2)
            {
                (PlaceHolder2.FindControl("txt" + s) as TextBox).Text = "0";
            }*/
            Response.Redirect("Savings.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string UpdateCommand = "update SAVINGS$ set CONTTOPENSION=@CONTTOPENSION, MEDICLAIM=@MEDICLAIM, HANDICAPPED=@HANDICAPPED, MEDICAL=@MEDICAL, EDULOAN=@EDULOAN, DONATION=@DONATION, PHDISABLED=@PHDISABLED, PUBLICPF=@PUBLICPF, HOUSELOAN=@HOUSELOAN, INTONHOUSELOAN=@INTONHOUSELOAN, INTONNSC=@INTONNSC, NSS=@NSS, MUTUALFUNDS=@MUTUALFUNDS, EQUITYLINK=@EQUITYLINK, TUTIONFEES=@TUTIONFEES, NSC=@NSC, LIC=@LIC, JEEVANSURAKSHA=@JEEVANSURAKSHA, LIPOSTAL=@LIPOSTAL, UNITLINK=@UNITLINK, MEP=@MEP, INVSTINFRA=@INVSTINFRA, OTHERS=@OTHERS, SEC80CCG=@SEC80CCG, SEC80DDB=@SEC80DDB, SEC80GG=@SEC80GG, SEC80GGC=@SEC80GGC, SEC80TTA=@SEC80TTA, SEC80U=@SEC80U, NPS=@NPS ";
            SqlConnection con = con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());

            foreach (string s in Globals.DynamicControlsList1)
            {             
                UpdateCommand = UpdateCommand + "," + s+ "=@" +s;
            }
            foreach (string s in Globals.DynamicControlsList2)
            {
                UpdateCommand = UpdateCommand + "," + s + "=@" +s;
            }
            UpdateCommand = UpdateCommand + " where EMPNO=@EMPNO and SAVING_YEAR=@SAVING_YEAR";

            SqlCommand cmd1 = new SqlCommand(UpdateCommand, con);
            cmd1.Parameters.AddWithValue("@EMPNO", lblEmployeeNoValue.Text);
            cmd1.Parameters.AddWithValue("@SAVING_YEAR", lblSavingYearValue.Text);
            cmd1.Parameters.AddWithValue("@CONTTOPENSION", txtConToPension.Text);
            cmd1.Parameters.AddWithValue("@MEDICLAIM", txtMediPremium.Text);
            cmd1.Parameters.AddWithValue("@HANDICAPPED", txtHandicappedDepend.Text);
            cmd1.Parameters.AddWithValue("@MEDICAL", txtMediTreatment.Text);
            cmd1.Parameters.AddWithValue("@EDULOAN", txtRepayLoan.Text);
            cmd1.Parameters.AddWithValue("@DONATION", txtDonationCmrf.Text);
            cmd1.Parameters.AddWithValue("@PHDISABLED", txtBlindOrPh.Text);
            cmd1.Parameters.AddWithValue("@PUBLICPF", txtPPF.Text);
            cmd1.Parameters.AddWithValue("@HOUSELOAN", txtRepayHouseLoan.Text);
            cmd1.Parameters.AddWithValue("@INTONHOUSELOAN", txtInterestHouseLoan.Text);
            cmd1.Parameters.AddWithValue("@INTONNSC", txtAccureudInterestNSC.Text);
            cmd1.Parameters.AddWithValue("@NSS", txtNSS.Text);
            cmd1.Parameters.AddWithValue("@MUTUALFUNDS", txtMutualFund.Text);
            cmd1.Parameters.AddWithValue("@EQUITYLINK", txtEquityLinked.Text);
            cmd1.Parameters.AddWithValue("@TUTIONFEES", txtTutionFees.Text);
            cmd1.Parameters.AddWithValue("@NSC", txtNSC.Text);
            cmd1.Parameters.AddWithValue("@LIC", txtLicPremium.Text);
            cmd1.Parameters.AddWithValue("@JEEVANSURAKSHA", txtJeevanSuraksha.Text);
            cmd1.Parameters.AddWithValue("@LIPOSTAL", txtPostalInvestment.Text);
            cmd1.Parameters.AddWithValue("@UNITLINK", txtUnitInsurance.Text);
            cmd1.Parameters.AddWithValue("@MEP", txtInfrastructureBond.Text);
            cmd1.Parameters.AddWithValue("@INVSTINFRA", txtInvestmentInfrastructure.Text);
            cmd1.Parameters.AddWithValue("@OTHERS", txtOthers.Text);
            cmd1.Parameters.AddWithValue("@SEC80CCG", txtSec80CCG.Text);
            cmd1.Parameters.AddWithValue("@SEC80DDB", txtSec80DDB.Text);
            cmd1.Parameters.AddWithValue("@SEC80GG", txtSec80GG.Text);
            cmd1.Parameters.AddWithValue("@SEC80GGC", txtSec80GGC.Text);
            cmd1.Parameters.AddWithValue("@SEC80TTA", txtSec80TTA.Text);
            cmd1.Parameters.AddWithValue("@SEC80U", txtSec80U.Text);
            cmd1.Parameters.AddWithValue("@NPS", txtNPS.Text);

            foreach (string s in Globals.DynamicControlsList1)
            {
                //try
                //{
                    cmd1.Parameters.AddWithValue("@" + s, (placeholder.FindControl("txt" + s) as TextBox).Text);
                //}
                //catch
                //{
                //    Response.Write("<script>alert('placeholder.FindControl: txt" +s + "');</script>");
                //}
            }
            foreach (string s in Globals.DynamicControlsList2)
            {
                //try
                //{
                    cmd1.Parameters.AddWithValue("@" + s, (PlaceHolder2.FindControl("txt" + s) as TextBox).Text);
                //}
                //catch
                //{
                //    Response.Write("<script>alert('placeholder.FindControl: txt" + s + "');</script>");
                //}
            }
            con.Open();
            Response.Write("<script>alert('UPDATE COMMAND:" + UpdateCommand + "');</script>");
            int status = 0;
            status= cmd1.ExecuteNonQuery();
            con.Close();

            if (status == -1)
            {
                Response.Write("<script>alert('Error while saving data!!');</script>");
            }
            else
            {
                //Response.Write("<script>alert('Data Saved Successfully!!');</script>");
                //Response.Redirect("Savings.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data saved sucessfully');window.location ='Savings.aspx';", true);
            }

        }
    }
}