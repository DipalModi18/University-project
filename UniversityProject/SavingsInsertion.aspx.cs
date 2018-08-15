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
    public partial class SavingsInsertion : System.Web.UI.Page
    {
        public List<string> DynamicControlsList = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                ddlSavingsYear.Items.Add(new ListItem("Select", "0", true));
                for (int m = 0; m < 10; m++)
                {
                    ddlSavingsYear.Items.Add(new ListItem((DateTime.Now.Year-m).ToString()));

                }
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

        public void Page_Init(object sender, EventArgs e)
        {
            CreateDynamicControls();
        }

        public void CreateDynamicControls()
        {
            //80C sections
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("select * from SECTIONS", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    HtmlGenericControl tr = new HtmlGenericControl("tr");
                    HtmlGenericControl td = new HtmlGenericControl("td");
                    HtmlGenericControl td1 = new HtmlGenericControl("td");
                    HtmlGenericControl td2 = new HtmlGenericControl("td");//for valid number check

                    string ControlName = (string)rdr["NAME"];
                    ControlName = ControlName.Replace(" ", "");
                    DynamicControlsList.Add(ControlName);

                    Label DyLabel = new Label();
                    DyLabel.ID = "lbl" + ControlName;
                    DyLabel.Text = (string)rdr["NAME"];
                    DyLabel.CssClass = "lblStyle";
                    td.Controls.Add(DyLabel);
                    tr.Controls.Add(td);

                    TextBox DyTextBox = new TextBox();
                    DyTextBox.ID = "txt" + ControlName;
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
                    //ViewState[""+ControlName] = "";         
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
                    DynamicControlsList.Add(ControlName);

                    Label DyLabel = new Label();
                    DyLabel.ID = "lbl" + ControlName;
                    DyLabel.Text = (string)rdr["NAME"];
                    DyLabel.CssClass = "lblStyle";
                    td.Controls.Add(DyLabel);
                    tr.Controls.Add(td);

                    TextBox DyTextBox = new TextBox();
                    DyTextBox.ID = "txt" + ControlName;
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
            catch(Exception ee)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //string InsertCommand = "insert into SAVINGS$ values (@EMPNO,@SAVING_YEAR,@CONTTOPENSION,@MEDICLAIM,@HANDICAPPED,@MEDICAL,@EDULOAN,@DONATION,@PHDISABLED,@PUBLICPF,@HOUSELOAN,@INTONHOUSELOAN,@INTONNSC,@NSS,@MUTUALFUNDS,@EQUITYLINK,@TUTIONFEES,@NSC,@LIC,@JEEVANSURAKSHA,@LIPOSTAL,@UNITLINK,@MEP,@INVSTINFRA,@OTHERS";
                string InsertCommand = "insert into SAVINGS$(EMPNO, SAVING_YEAR, CONTTOPENSION, MEDICLAIM, HANDICAPPED, MEDICAL, EDULOAN, DONATION, PHDISABLED, PUBLICPF, HOUSELOAN, INTONHOUSELOAN, INTONNSC, NSS, MUTUALFUNDS, EQUITYLINK, TUTIONFEES, NSC, LIC, JEEVANSURAKSHA, LIPOSTAL, UNITLINK, MEP, INVSTINFRA, OTHERS, SEC80CCG, SEC80DDB, SEC80GG, SEC80GGC, SEC80TTA, SEC80U, NPS";

                //80C SECTIONS
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("select * from SECTIONS", con);  //SECTIONS=80C SECTIONS
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                List<string> ControlList1 = new List<string>();
                String controlsNames1 = "";
                String controlsValues1 = "";

                while (rdr.Read())
                {
                    string ControlName = (string)rdr["NAME"];
                    ControlName = ControlName.Replace(" ", "");
                    //InsertCommand = InsertCommand + ",@" + ControlName;
                    controlsNames1 = controlsNames1 + "," + ControlName;
                    controlsValues1 = controlsValues1 + ",@" + ControlName;
                    ControlList1.Add(ControlName);
                }

                rdr.Close();
                con.Close();


                // SAVINGS SECTIONS
                String controlsNames2 = "";
                String controlsValues2 = "";
                cmd = new SqlCommand("SELECT * FROM SAVINGS_SECTIONS$ WHERE NAME != '80C'", con);
                con.Open();
                rdr = cmd.ExecuteReader();

                List<string> ControlList2 = new List<string>();

                while (rdr.Read())
                {
                    string ControlName = (string)rdr["NAME"];
                    ControlName = ControlName.Replace(" ", "");
                    //InsertCommand = InsertCommand + ",@" + ControlName;
                    controlsNames2 = controlsNames2 + "," + ControlName;
                    controlsValues2 = controlsValues2 + ",@" + ControlName;
                    ControlList2.Add(ControlName);
                }

                rdr.Close();
                con.Close();

                InsertCommand = InsertCommand + controlsNames1 + controlsNames2 + ") values(@EMPNO,@SAVING_YEAR,@CONTTOPENSION,@MEDICLAIM,@HANDICAPPED,@MEDICAL,@EDULOAN,@DONATION,@PHDISABLED,@PUBLICPF,@HOUSELOAN,@INTONHOUSELOAN,@INTONNSC,@NSS,@MUTUALFUNDS,@EQUITYLINK,@TUTIONFEES,@NSC,@LIC,@JEEVANSURAKSHA,@LIPOSTAL,@UNITLINK,@MEP,@INVSTINFRA,@OTHERS, @SEC80CCG, @SEC80DDB, @SEC80GG, @SEC80GGC, @SEC80TTA, @SEC80U, @NPS" + controlsValues1 + controlsValues2 + ")";
                //InsertCommand = InsertCommand + ")";

                con.Open();
                //Response.Write("<script>alert('INSERT CMD= " + InsertCommand + "');</script>");
                //Response.Write("<script>alert('CONTTOPENSION= "+txtConToPension.Text+ " MEDICLAIM="+ txtMediPremium.Text+"');</script>");
                SqlCommand cmd1 = new SqlCommand(InsertCommand, con);

                cmd1.Parameters.AddWithValue("@EMPNO", txtEmpNo.Text);
                cmd1.Parameters.AddWithValue("@SAVING_YEAR", ddlSavingsYear.SelectedValue);
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

                foreach (string s in ControlList1)
                {
                    cmd1.Parameters.AddWithValue("@" + s, (placeholder.FindControl("txt" + s) as TextBox).Text);
                }

                foreach (string s in ControlList2)
                {
                    cmd1.Parameters.AddWithValue("@" + s, (PlaceHolder2.FindControl("txt" + s) as TextBox).Text);
                }
                Response.Write("<script>alert('INSERT COMMAND:" + InsertCommand + "');</script>");
                int status = 0;
                status = cmd1.ExecuteNonQuery();
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
                //Response.Redirect("Savings.aspx");
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error while saving data!!');</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            /*txtEmpNo.Text = "0";
            ddlSavingsYear.SelectedIndex = 0;
            txtConToPension.Text="0";
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

            foreach (string s in DynamicControlsList)
            {
                (placeholder.FindControl("txt" + s) as TextBox).Text = "0";
            }
            foreach (string s in DynamicControlsList)
            {
                (PlaceHolder2.FindControl("txt" + s) as TextBox).Text = "0";
            }*/
            Response.Redirect("Savings.aspx");
        }

        protected void txtEmpNo_TextChanged(object sender, EventArgs e)
        {
            int previousYear = DateTime.Now.Year - 1;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("select * from SAVINGS$ where SAVING_YEAR=@SAVING_YEAR and EMPNO=@EMPNO",con);
            cmd.Parameters.AddWithValue("@SAVING_YEAR", previousYear);
            cmd.Parameters.AddWithValue("@EMPNO", txtEmpNo.Text);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if(rdr.Read())
            {
                //txtEmpNo.Text = rdr["EMPNO"].ToString();
                txtConToPension.Text = rdr["CONTTOPENSION"].ToString();
                txtMediPremium.Text = rdr["MEDICLAIM"].ToString();
                txtHandicappedDepend.Text = rdr["HANDICAPPED"].ToString();
                txtMediTreatment.Text = rdr["MEDICAL"].ToString();
                txtRepayLoan.Text = rdr["EDULOAN"].ToString();
                txtDonationCmrf.Text = rdr["DONATION"].ToString();
                txtBlindOrPh.Text = rdr["PHDISABLED"].ToString();
                txtPPF.Text = rdr["PUBLICPF"].ToString();
                txtRepayHouseLoan.Text = rdr["HOUSELOAN"].ToString();
                txtInterestHouseLoan.Text = rdr["INTONHOUSELOAN"].ToString();
                txtAccureudInterestNSC.Text = rdr["INTONNSC"].ToString();
                txtNSS.Text = rdr["NSS"].ToString();
                txtMutualFund.Text = rdr["MUTUALFUNDS"].ToString();
                txtEquityLinked.Text = rdr["EQUITYLINK"].ToString();
                txtTutionFees.Text = rdr["TUTIONFEES"].ToString();
                txtNSC.Text = rdr["NSC"].ToString();
                txtLicPremium.Text = rdr["LIC"].ToString();
                txtJeevanSuraksha.Text = rdr["JEEVANSURAKSHA"].ToString();
                txtPostalInvestment.Text = rdr["LIPOSTAL"].ToString();
                txtUnitInsurance.Text = rdr["UNITLINK"].ToString();
                txtInfrastructureBond.Text = rdr["MEP"].ToString();
                txtInvestmentInfrastructure.Text = rdr["INVSTINFRA"].ToString();
                txtOthers.Text = rdr["OTHERS"].ToString();
                txtSec80CCG.Text = rdr["SEC80CCG"].ToString();
                txtSec80DDB.Text = rdr["SEC80DDB"].ToString();
                txtSec80GG.Text = rdr["SEC80GG"].ToString();
                txtSec80GGC.Text = rdr["SEC80GGC"].ToString();
                txtSec80TTA.Text = rdr["SEC80TTA"].ToString();
                txtSec80U.Text = rdr["SEC80U"].ToString();
                txtNPS.Text = rdr["NPS"].ToString();
                foreach (string s in DynamicControlsList)
                {
                    (placeholder.FindControl("txt" + s) as TextBox).Text = rdr[s].ToString();
                }
                foreach (string s in DynamicControlsList)
                {
                    (PlaceHolder2.FindControl("txt" + s) as TextBox).Text = rdr[s].ToString();
                }
            }
            else
            {
                //txtEmpNo.Text = "0";
                ddlSavingsYear.SelectedIndex = 0;
                txtConToPension.Text = "0";
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

                foreach (string s in DynamicControlsList)
                {
                    (placeholder.FindControl("txt" + s) as TextBox).Text = "0";
                }
                foreach (string s in DynamicControlsList)
                {
                    (PlaceHolder2.FindControl("txt" + s) as TextBox).Text = "0";
                }
            }

        }
    }
}