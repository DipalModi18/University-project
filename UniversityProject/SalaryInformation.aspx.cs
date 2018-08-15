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
    public partial class SalaryInformation : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
        int dirtybit = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                NetPayDiv.Visible = false;
                ddlMonth.SelectedIndex = 0;
                TextBoxYear.Text = DateTime.Now.Year.ToString();
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

        protected void btnAdvRec_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(ViewAdvRecovery);
        }

        protected void btnEarning_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(ViewEarning);
        }

        protected void btnDeduction_Click1(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(ViewDeduction);
        }

        protected void btnEmpSubmit_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("select EMPNO from EMP_PROFILE$ where EMPNO=@EMPNO ", con);
            cmd.Parameters.AddWithValue("EMPNO", txtEmpID.Text);
            var noo = cmd.ExecuteScalar();
            con.Close();
            if (noo == null)
            {
                Response.Write("<script>alert('There is no employee with this id');</script>");
                Response.Write("<script language='javascript'>window.location='SalarySearch.aspx';</script>");
            }
            else
            {
                var empid = txtEmpID.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("select * from EMP_PROFILE$ where EMPNO=@Empid", con);
                cmd.Parameters.AddWithValue("Empid", empid);
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                txtName.Text = ds.Tables[0].Rows[0]["EMPNAME"].ToString();
                txtDesignation.Text = ds.Tables[0].Rows[0]["DESIGNATION"].ToString();
                txtDept.Text = ds.Tables[0].Rows[0]["DEPTNO"].ToString();
                txtFac.Text = ds.Tables[0].Rows[0]["FACID"].ToString();
                txtRateOfPay.Text = ds.Tables[0].Rows[0]["PAYSCALE"].ToString();

                loadPrevious();
            }
        }

        protected void btnTotEarning_Click(object sender, EventArgs e)
        {
            try
            {
                Double TotalEarnings = Convert.ToDouble(txtBasic.Text) +
                    Convert.ToDouble(txtDa.Text) +
                    Convert.ToDouble(txtHra.Text) +
                    Convert.ToDouble(txtCla.Text) +
                    Convert.ToDouble(txtUcpf.Text) +
                    Convert.ToDouble(txtSpAllowance.Text) +
                    Convert.ToDouble(txtConveyAllowance.Text) +
                    Convert.ToDouble(txtExamAllowance.Text) +
                    Convert.ToDouble(txtWasgAllowance.Text) +
                    Convert.ToDouble(txtMedAllowance.Text) +
                    Convert.ToDouble(txtAdhoc.Text) +
                    Convert.ToDouble(txtDp.Text) +
                    Convert.ToDouble(txtOtherAllowances.Text) +
                    Convert.ToDouble(txtLtcEncashment.Text);
                txtTotEarning.Text = TotalEarnings.ToString();
                txtGrossPay.Text = TotalEarnings.ToString();
            }
            catch (FormatException fe)
            {
                txtTotEarning.Text = "0";
                txtGrossPay.Text = "0";
                Response.Write("<script>alert('Enter Valid Numbers for Earnings!!');</script>");
            }
        }

        protected void btnTotDeduction_Click(object sender, EventArgs e)
        {
            try
            {
                Double TotalDeduction = Convert.ToDouble(txtPf.Text) +
                   Convert.ToDouble(txtUcpf1.Text) +
                   Convert.ToDouble(txtGpf.Text) +
                   Convert.ToDouble(txtLic.Text) +
                   Convert.ToDouble(txtIncomeTax.Text) +
                   Convert.ToDouble(txtProfTax.Text) +
                   Convert.ToDouble(txtRent.Text) +
                   Convert.ToDouble(txtGpfArrear.Text) +
                   Convert.ToDouble(txtWc.Text) +
                   Convert.ToDouble(txtStandardDeduction.Text) +
                   Convert.ToDouble(txtSocSaving.Text) +
                   Convert.ToDouble(txtFurniture.Text) +
                   Convert.ToDouble(txtGgs.Text) +
                Convert.ToDouble(txtGpInsurance.Text) +
                Convert.ToDouble(txtPmCmRelief.Text) +
                Convert.ToDouble(txtEmpDeathHelp.Text) +
                Convert.ToDouble(txtOther.Text) +
                Convert.ToDouble(txtCtd.Text) +
                Convert.ToDouble(txtRd.Text);
                txtNetDeduction.Text = TotalDeduction.ToString();
                txtTotDeduction.Text = TotalDeduction.ToString();
                // txtNetPay.Text = TotalDeduction.ToString();
            }
            catch (FormatException fe)
            {
                txtNetDeduction.Text = "0";
                txtTotDeduction.Text = "0";
                Response.Write("<script>alert('Enter Valid Numbers for Deductions!!');</script>");
            }
        }
        protected void btnGovtBal_Click(object sender, EventArgs e)
        {
            try
            {
                Double GovtBal = Convert.ToDouble(txtCpf.Text) +
                    Convert.ToDouble(txtFestival.Text) +
                    Convert.ToDouble(txtNcpf.Text) +
                    Convert.ToDouble(txtSociety.Text) +
                    Convert.ToDouble(txtFood.Text) +
                    Convert.ToDouble(txtHousing.Text) +
                    Convert.ToDouble(txtVehicle.Text);
                txtGovtBal.Text = GovtBal.ToString();
            }
            catch (FormatException fe)
            {
                txtGovtBal.Text = "0";
                Response.Write("<script>alert('Enter Valid Numbers for Advances!!');</script>");
            }
        }

        protected void btnRecGovtInst_Click(object sender, EventArgs e)
        {
            try
            {
                Double GovtInst = Convert.ToDouble(txtRecCpf.Text) +
                    Convert.ToDouble(txtRecFestival.Text) +
                    Convert.ToDouble(txtRecNcpf.Text) +
                    Convert.ToDouble(txtRecSociety.Text) +
                    Convert.ToDouble(txtRecFoodGrain.Text) +
                    Convert.ToDouble(txtRecHousing.Text) +
                    Convert.ToDouble(txtRecVehicle.Text);
                txtRecGovInst.Text = GovtInst.ToString();
            }
            catch (FormatException fe)
            {
                txtRecGovInst.Text = "0";
                Response.Write("<script>alert('Enter Valid Numbers for Recovery!!');</script>");
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            btnTotEarning_Click(null, EventArgs.Empty);
            btnTotDeduction_Click(null, EventArgs.Empty);
            btnGovtBal_Click(null, EventArgs.Empty);
            btnRecGovtInst_Click(null, EventArgs.Empty);

            Double grosspay, netdeduction;
            if (txtGrossPay.Text == "" || txtGrossPay.Text == null)
            {
                grosspay = 0;
            }
            else
            {
                grosspay = Convert.ToDouble(txtGrossPay.Text);
            }
            if (txtNetDeduction.Text == null || txtNetDeduction.Text == "")
            {
                netdeduction = 0;
            }
            else
            {
                netdeduction = Convert.ToDouble(txtNetDeduction.Text);
            }
            Double netpay = grosspay - netdeduction;
            txtNetPay.Text = netpay.ToString();

            NetPayDiv.Visible = true;

            if (dirtybit == 0)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("insert into PAY_SLIP$ values (@EMPNO,@BILL_NO,@RATE_OF_PAY,@EFFECTIVE_DAYS,@MONTH,@YEAR,@BASIC,@DA,@HRA,@CLA,@EAR_UCPF,@SPEC_ALL,@CONVEY_ALL,@EXAM_ALL,@WASH_ALL,@MED_ALL,@EAR_OTHER,@DP,@PF,@DED_UCPF,@GPF,@LIC,@INC_TAX,@PROF_TAX,@RENT,@GPF_ARR,@WC,@SOC_SAV,@FUR,@GGS,@GROP_INS,@PM_CMRELIEF,@DEATH_HELP,@DED_OTHER,@CTD,@RD,@ADV_CPF,@ADV_FEST,@ADV_NCPF,@ADV_SOC,@ADV_FOOD,@ADV_HOS,@ADV_VEH,@ADV_GOV_BAL,@REC_CPF,@REC_FEST,@REC_NCPF,@REC_SOC,@REC_FOOD_GRAIN,@REC_HOS,@REC_VEH,@REC_GOV_INST,@EAR_TOTAL,@DED_TOTAL,@GROSS_PAY,@TOT_DED,@NET_PAY,@ADHOC_BONUS,@LTC_ENCASHMENT,@STANDARD_DEDUCTION)", con);
                    cmd.Parameters.AddWithValue("EMPNO", txtEmpID.Text);
                    cmd.Parameters.AddWithValue("BILL_NO", txtBill.Text);
                    cmd.Parameters.AddWithValue("RATE_OF_PAY", txtRateOfPay.Text);
                    cmd.Parameters.AddWithValue("EFFECTIVE_DAYS", txtEffectiveDays.Text);
                    cmd.Parameters.AddWithValue("MONTH", ddlMonth.SelectedValue);
                    cmd.Parameters.AddWithValue("YEAR", TextBoxYear.Text);
                    cmd.Parameters.AddWithValue("BASIC", txtBasic.Text);
                    cmd.Parameters.AddWithValue("DA", txtDa.Text);
                    cmd.Parameters.AddWithValue("HRA", txtHra.Text);
                    cmd.Parameters.AddWithValue("CLA", txtCla.Text);
                    cmd.Parameters.AddWithValue("EAR_UCPF", txtUcpf.Text);
                    cmd.Parameters.AddWithValue("SPEC_ALL", txtSpAllowance.Text);
                    cmd.Parameters.AddWithValue("CONVEY_ALL", txtConveyAllowance.Text);
                    cmd.Parameters.AddWithValue("EXAM_ALL", txtExamAllowance.Text);
                    cmd.Parameters.AddWithValue("WASH_ALL", txtWasgAllowance.Text);
                    cmd.Parameters.AddWithValue("MED_ALL", txtMedAllowance.Text);
                    cmd.Parameters.AddWithValue("EAR_OTHER", txtOtherAllowances.Text);
                    cmd.Parameters.AddWithValue("DP", txtDp.Text);
                    cmd.Parameters.AddWithValue("PF", txtPf.Text);
                    cmd.Parameters.AddWithValue("DED_UCPF", txtUcpf1.Text);
                    cmd.Parameters.AddWithValue("GPF", txtGpf.Text);
                    cmd.Parameters.AddWithValue("LIC", txtLic.Text);
                    cmd.Parameters.AddWithValue("INC_TAX", txtIncomeTax.Text);
                    cmd.Parameters.AddWithValue("PROF_TAX", txtProfTax.Text);
                    cmd.Parameters.AddWithValue("RENT", txtRent.Text);
                    cmd.Parameters.AddWithValue("GPF_ARR", txtGpfArrear.Text);
                    cmd.Parameters.AddWithValue("WC", txtWc.Text);
                    cmd.Parameters.AddWithValue("STANDARD_DEDUCTION", txtStandardDeduction.Text);
                    cmd.Parameters.AddWithValue("SOC_SAV", txtSocSaving.Text);
                    cmd.Parameters.AddWithValue("FUR", txtFurniture.Text);
                    cmd.Parameters.AddWithValue("GGS", txtGgs.Text);
                    cmd.Parameters.AddWithValue("GROP_INS", txtGpInsurance.Text);
                    cmd.Parameters.AddWithValue("PM_CMRELIEF", txtPmCmRelief.Text);
                    cmd.Parameters.AddWithValue("DEATH_HELP", txtEmpDeathHelp.Text);
                    cmd.Parameters.AddWithValue("DED_OTHER", txtOther.Text);
                    cmd.Parameters.AddWithValue("CTD", txtCtd.Text);
                    cmd.Parameters.AddWithValue("RD", txtRd.Text);
                    cmd.Parameters.AddWithValue("ADV_CPF", txtCpf.Text);
                    cmd.Parameters.AddWithValue("ADV_FEST", txtFestival.Text);
                    cmd.Parameters.AddWithValue("ADV_NCPF", txtNcpf.Text);
                    cmd.Parameters.AddWithValue("ADV_SOC", txtSociety.Text);
                    cmd.Parameters.AddWithValue("ADV_FOOD", txtFood.Text);
                    cmd.Parameters.AddWithValue("ADV_HOS", txtHousing.Text);
                    cmd.Parameters.AddWithValue("ADV_VEH", txtVehicle.Text);
                    cmd.Parameters.AddWithValue("ADV_GOV_BAL", txtGovtBal.Text);
                    cmd.Parameters.AddWithValue("REC_CPF", txtRecCpf.Text);
                    cmd.Parameters.AddWithValue("REC_FEST", txtRecFestival.Text);
                    cmd.Parameters.AddWithValue("REC_NCPF", txtRecNcpf.Text);
                    cmd.Parameters.AddWithValue("REC_SOC", txtRecSociety.Text);
                    cmd.Parameters.AddWithValue("REC_FOOD_GRAIN", txtRecFoodGrain.Text);
                    cmd.Parameters.AddWithValue("REC_HOS", txtRecHousing.Text);
                    cmd.Parameters.AddWithValue("REC_VEH", txtRecVehicle.Text);
                    cmd.Parameters.AddWithValue("REC_GOV_INST", txtRecGovInst.Text);
                    cmd.Parameters.AddWithValue("EAR_TOTAL", txtTotEarning.Text);
                    cmd.Parameters.AddWithValue("DED_TOTAL", txtTotDeduction.Text);
                    cmd.Parameters.AddWithValue("GROSS_PAY", txtGrossPay.Text);
                    cmd.Parameters.AddWithValue("TOT_DED", txtTotDeduction.Text);
                    cmd.Parameters.AddWithValue("NET_PAY", txtNetPay.Text);
                    cmd.Parameters.AddWithValue("ADHOC_BONUS", txtAdhoc.Text);
                    cmd.Parameters.AddWithValue("LTC_ENCASHMENT", txtLtcEncashment.Text);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    dirtybit = 1;
                }
                catch (FormatException fe)
                {
                    Response.Write("<script>alert('Error While Saving Data!!');</script>");
                }
            }
            else
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("update PAY_SLIP$ set BILL_NO=@BILL_NO, RATE_OF_PAY=@RATE_OF_PAY, EFFECTIVE_DAYS=@EFFECTIVE_DAYS, BASIC=@BASIC, DA=@DA, HRA=@HRA, CLA=@CLA, EAR_UCPF=@EAR_UCPF, SPEC_ALL=@SPEC_ALL, CONVEY_ALL=@CONVEY_ALL, EXAM_ALL=@EXAM_ALL, WASH_ALL=@WASH_ALL, MED_ALL=@MED_ALL, EAR_OTHER=@EAR_OTHER, DP=@DP, PF=@PF, DED_UCPF=@DED_UCPF, GPF=@GPF, LIC=@LIC, INC_TAX=@INC_TAX, PROF_TAX=@PROF_TAX, RENT=@RENT, GPF_ARR=@GPF_ARR, WC=@WC, SOC_SAV=@SOC_SAV, FUR=@FUR, GGS=@GGS, GROP_INS=@GROP_INS, PM_CMRELIEF=@PM_CMRELIEF, DEATH_HELP=@DEATH_HELP, DED_OTHER=@DED_OTHER, CTD=@CTD, RD=@RD, ADV_CPF=@ADV_CPF, ADV_FEST=@ADV_FEST, ADV_NCPF=@ADV_NCPF, ADV_SOC=@ADV_SOC, ADV_FOOD=@ADV_FOOD, ADV_HOS=@ADV_HOS, ADV_VEH=@ADV_VEH, ADV_GOV_BAL=@ADV_GOV_BAL, REC_CPF=@REC_CPF, REC_FEST=@REC_FEST, REC_NCPF=@REC_NCPF, REC_SOC=@REC_SOC, REC_FOOD_GRAIN=@REC_FOOD_GRAIN, REC_HOS=@REC_HOS, REC_VEH=@REC_VEH, REC_GOV_INST=@REC_GOV_INST, EAR_TOTAL=@EAR_TOTAL, DED_TOTAL=@DED_TOTAL, GROSS_PAY=@GROSS_PAY,TOT_DED=@TOT_DED, NET_PAY=@NET_PAY, ADHOC_BONUS=@ADHOC_BONUS, LTC_ENCASHMENT=@LTC_ENCASHMENT, STANDARD_DEDUCTION=@STANDARD_DEDUCTION where EMPNO=@EMPNO AND MONTH=@MONTH AND YEAR=@YEAR", con);
                    cmd.Parameters.AddWithValue("EMPNO", txtEmpID.Text);
                    cmd.Parameters.AddWithValue("BILL_NO", txtBill.Text);
                    cmd.Parameters.AddWithValue("RATE_OF_PAY", txtRateOfPay.Text);
                    cmd.Parameters.AddWithValue("EFFECTIVE_DAYS", txtEffectiveDays.Text);
                    cmd.Parameters.AddWithValue("MONTH", ddlMonth.Text);
                    cmd.Parameters.AddWithValue("YEAR", TextBoxYear.Text);
                    cmd.Parameters.AddWithValue("BASIC", txtBasic.Text);
                    cmd.Parameters.AddWithValue("DA", txtDa.Text);
                    cmd.Parameters.AddWithValue("HRA", txtHra.Text);
                    cmd.Parameters.AddWithValue("CLA", txtCla.Text);
                    cmd.Parameters.AddWithValue("EAR_UCPF", txtUcpf.Text);
                    cmd.Parameters.AddWithValue("SPEC_ALL", txtSpAllowance.Text);
                    cmd.Parameters.AddWithValue("CONVEY_ALL", txtConveyAllowance.Text);
                    cmd.Parameters.AddWithValue("EXAM_ALL", txtExamAllowance.Text);
                    cmd.Parameters.AddWithValue("WASH_ALL", txtWasgAllowance.Text);
                    cmd.Parameters.AddWithValue("MED_ALL", txtMedAllowance.Text);
                    cmd.Parameters.AddWithValue("EAR_OTHER", txtOtherAllowances.Text);
                    cmd.Parameters.AddWithValue("DP", txtDp.Text);
                    cmd.Parameters.AddWithValue("PF", txtPf.Text);
                    cmd.Parameters.AddWithValue("DED_UCPF", txtUcpf1.Text);
                    cmd.Parameters.AddWithValue("GPF", txtGpf.Text);
                    cmd.Parameters.AddWithValue("LIC", txtLic.Text);
                    cmd.Parameters.AddWithValue("INC_TAX", txtIncomeTax.Text);
                    cmd.Parameters.AddWithValue("PROF_TAX", txtProfTax.Text);
                    cmd.Parameters.AddWithValue("RENT", txtRent.Text);
                    cmd.Parameters.AddWithValue("GPF_ARR", txtGpfArrear.Text);
                    cmd.Parameters.AddWithValue("WC", txtWc.Text);
                    cmd.Parameters.AddWithValue("STANDARD_DEDUCTION", txtStandardDeduction.Text);
                    cmd.Parameters.AddWithValue("SOC_SAV", txtSocSaving.Text);
                    cmd.Parameters.AddWithValue("FUR", txtFurniture.Text);
                    cmd.Parameters.AddWithValue("GGS", txtGgs.Text);
                    cmd.Parameters.AddWithValue("GROP_INS", txtGpInsurance.Text);
                    cmd.Parameters.AddWithValue("PM_CMRELIEF", txtPmCmRelief.Text);
                    cmd.Parameters.AddWithValue("DEATH_HELP", txtEmpDeathHelp.Text);
                    cmd.Parameters.AddWithValue("DED_OTHER", txtOther.Text);
                    cmd.Parameters.AddWithValue("CTD", txtCtd.Text);
                    cmd.Parameters.AddWithValue("RD", txtRd.Text);
                    cmd.Parameters.AddWithValue("ADV_CPF", txtCpf.Text);
                    cmd.Parameters.AddWithValue("ADV_FEST", txtFestival.Text);
                    cmd.Parameters.AddWithValue("ADV_NCPF", txtNcpf.Text);
                    cmd.Parameters.AddWithValue("ADV_SOC", txtSociety.Text);
                    cmd.Parameters.AddWithValue("ADV_FOOD", txtFood.Text);
                    cmd.Parameters.AddWithValue("ADV_HOS", txtHousing.Text);
                    cmd.Parameters.AddWithValue("ADV_VEH", txtVehicle.Text);
                    cmd.Parameters.AddWithValue("ADV_GOV_BAL", txtGovtBal.Text);
                    cmd.Parameters.AddWithValue("REC_CPF", txtRecCpf.Text);
                    cmd.Parameters.AddWithValue("REC_FEST", txtRecFestival.Text);
                    cmd.Parameters.AddWithValue("REC_NCPF", txtRecNcpf.Text);
                    cmd.Parameters.AddWithValue("REC_SOC", txtRecSociety.Text);
                    cmd.Parameters.AddWithValue("REC_FOOD_GRAIN", txtRecFoodGrain.Text);
                    cmd.Parameters.AddWithValue("REC_HOS", txtRecHousing.Text);
                    cmd.Parameters.AddWithValue("REC_VEH", txtRecVehicle.Text);
                    cmd.Parameters.AddWithValue("REC_GOV_INST", txtRecGovInst.Text);
                    cmd.Parameters.AddWithValue("EAR_TOTAL", txtTotEarning.Text);
                    cmd.Parameters.AddWithValue("DED_TOTAL", txtTotDeduction.Text);
                    cmd.Parameters.AddWithValue("GROSS_PAY", txtGrossPay.Text);
                    cmd.Parameters.AddWithValue("TOT_DED", txtTotDeduction.Text);
                    cmd.Parameters.AddWithValue("NET_PAY", txtNetPay.Text);
                    cmd.Parameters.AddWithValue("ADHOC_BONUS", txtAdhoc.Text);
                    cmd.Parameters.AddWithValue("LTC_ENCASHMENT", txtLtcEncashment.Text);
                    con.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (FormatException fe)
                {
                    Response.Write("<script>alert('Error While Saving Data!!');</script>");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalarySearch.aspx");
        }

        public void loadPrevious()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            String previousMonth = "";
            int previousYear;
            if(DateTime.Now.Month==1)
            {
                previousMonth = "DEC";
                previousYear = DateTime.Now.Year - 1;
            }
            else
            {
                previousMonth = preMonth(DateTime.Now.Month);
                previousYear = DateTime.Now.Year;
            }
            Response.Write("<script>alert('Previous Month:"+previousMonth+" Previous Year:"+previousYear+"');</script>");
            SqlCommand cmd = new SqlCommand("select * from PAY_SLIP$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR",con);
            cmd.Parameters.AddWithValue("@EMPNO", txtEmpID.Text);
            cmd.Parameters.AddWithValue("@MONTH", previousMonth);
            cmd.Parameters.AddWithValue("@YEAR", previousYear);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.Read())
            {
                try
                {
                    Response.Write("<script>alert('Rendering...');</script>");
                    txtBill.Text = sdr["BILL_NO"].ToString();
                    txtGrossPay.Text = sdr["GROSS_PAY"].ToString();
                    txtNetDeduction.Text = sdr["TOT_DED"].ToString();
                    txtNetPay.Text = sdr["NET_PAY"].ToString();
                    txtBasic.Text = sdr["BASIC"].ToString();
                    txtDa.Text = sdr["DA"].ToString();
                    txtHra.Text = sdr["HRA"].ToString();
                    txtCla.Text = sdr["CLA"].ToString();
                    txtUcpf.Text = sdr["EAR_UCPF"].ToString();
                    txtSpAllowance.Text = sdr["SPEC_ALL"].ToString();
                    txtConveyAllowance.Text = sdr["CONVEY_ALL"].ToString();
                    txtExamAllowance.Text = sdr["EXAM_ALL"].ToString();
                    txtWasgAllowance.Text = sdr["WASH_ALL"].ToString();
                    txtMedAllowance.Text = sdr["MED_ALL"].ToString();
                    txtAdhoc.Text = sdr["ADHOC_BONUS"].ToString();
                    txtOtherAllowances.Text = sdr["EAR_OTHER"].ToString();
                    txtLtcEncashment.Text = sdr["LTC_ENCASHMENT"].ToString();
                    txtDp.Text = sdr["DP"].ToString();
                    txtTotEarning.Text = sdr["EAR_TOTAL"].ToString();
                    txtPf.Text = sdr["PF"].ToString();
                    txtUcpf1.Text = sdr["DED_UCPF"].ToString();
                    txtGpf.Text = sdr["GPF"].ToString();
                    txtLic.Text = sdr["LIC"].ToString();
                    txtIncomeTax.Text = sdr["INC_TAX"].ToString();
                    txtProfTax.Text = sdr["PROF_TAX"].ToString();
                    txtRent.Text = sdr["RENT"].ToString();
                    txtGpfArrear.Text = sdr["GPF_ARR"].ToString();
                    txtWc.Text = sdr["WC"].ToString();
                    txtStandardDeduction.Text = sdr["STANDARD_DEDUCTION"].ToString();
                    txtSocSaving.Text = sdr["SOC_SAV"].ToString();
                    txtFurniture.Text = sdr["FUR"].ToString();
                    txtGgs.Text = sdr["GGS"].ToString();
                    txtGpInsurance.Text = sdr["GROP_INS"].ToString();
                    txtPmCmRelief.Text = sdr["PM_CMRELIEF"].ToString();
                    txtEmpDeathHelp.Text = sdr["DEATH_HELP"].ToString();
                    txtOther.Text = sdr["DED_OTHER"].ToString();
                    txtCtd.Text = sdr["CTD"].ToString();
                    txtRd.Text = sdr["RD"].ToString();
                    txtTotDeduction.Text = sdr["TOT_DED"].ToString();
                    double ADV_CPF = Convert.ToDouble(sdr["ADV_CPF"].ToString());
                    double REC_CPF = Convert.ToDouble(sdr["REC_CPF"].ToString());
                    if (ADV_CPF - REC_CPF > 0)
                    {
                        txtCpf.Text = (ADV_CPF - REC_CPF).ToString();
                        if ((ADV_CPF - (2 * REC_CPF)) > 0)
                        {
                            txtRecCpf.Text = REC_CPF.ToString();
                        }
                        else
                        {
                            txtRecCpf.Text = (ADV_CPF - REC_CPF).ToString();
                        }
                    }
                    double ADV_FEST = Convert.ToDouble(sdr["ADV_FEST"].ToString());
                    double REC_FEST = Convert.ToDouble(sdr["REC_FEST"].ToString());
                    if (ADV_FEST - REC_FEST > 0)
                    {
                        txtFestival.Text = (ADV_FEST - REC_FEST).ToString();
                        if ((ADV_FEST - (2 * REC_FEST)) > 0)
                        {
                            txtRecFestival.Text = REC_FEST.ToString();
                        }
                        else
                        {
                            txtRecFestival.Text = (ADV_FEST - REC_FEST).ToString();
                        }
                    }
                    double ADV_NCPF = Convert.ToDouble(sdr["ADV_NCPF"].ToString());
                    double REC_NCPF = Convert.ToDouble(sdr["REC_NCPF"].ToString());
                    if (ADV_NCPF - REC_NCPF > 0)
                    {
                        txtNcpf.Text = (ADV_NCPF - REC_NCPF).ToString();
                        if ((ADV_NCPF - (2 * REC_NCPF)) > 0)
                        {
                            txtRecNcpf.Text = REC_NCPF.ToString();
                        }
                        else
                        {
                            txtRecNcpf.Text = (ADV_NCPF - REC_NCPF).ToString();
                        }
                    }
                    double ADV_SOC = Convert.ToDouble(sdr["ADV_SOC"].ToString());
                    double REC_SOC = Convert.ToDouble(sdr["REC_SOC"].ToString());
                    if (ADV_SOC - REC_SOC > 0)
                    {
                        txtSociety.Text = (ADV_SOC - REC_SOC).ToString();
                        if ((ADV_SOC - (2 * REC_SOC)) > 0)
                        {
                            txtRecSociety.Text = REC_SOC.ToString();
                        }
                        else
                        {
                            txtRecSociety.Text = (ADV_SOC - REC_SOC).ToString();
                        }
                    }
                    double ADV_FOOD = Convert.ToDouble(sdr["ADV_FOOD"].ToString());
                    double REC_FOOD_GRAIN = Convert.ToDouble(sdr["REC_FOOD_GRAIN"].ToString());
                    if (ADV_FOOD - REC_FOOD_GRAIN > 0)
                    {
                        txtFood.Text = (ADV_FOOD - REC_FOOD_GRAIN).ToString();
                        if ((ADV_FOOD - (2 * REC_FOOD_GRAIN)) > 0)
                        {
                            txtRecFoodGrain.Text = REC_FOOD_GRAIN.ToString();
                        }
                        else
                        {
                            txtRecFoodGrain.Text = (ADV_FOOD - REC_FOOD_GRAIN).ToString();
                        }
                    }
                    double ADV_HOS = Convert.ToDouble(sdr["ADV_HOS"].ToString());
                    double REC_HOS = Convert.ToDouble(sdr["REC_HOS"].ToString());
                    if (ADV_HOS - REC_HOS > 0)
                    {
                        txtHousing.Text = (ADV_HOS - REC_HOS).ToString();
                        if ((ADV_HOS - (2 * REC_HOS)) > 0)
                        {
                            txtRecHousing.Text = REC_HOS.ToString();
                        }
                        else
                        {
                            txtRecHousing.Text = (ADV_HOS - REC_HOS).ToString();
                        }
                    }
                    double ADV_VEH = Convert.ToDouble(sdr["ADV_VEH"].ToString());
                    double REC_VEH = Convert.ToDouble(sdr["REC_VEH"].ToString());
                    if (ADV_VEH - REC_VEH > 0)
                    {
                        txtVehicle.Text = (ADV_VEH - REC_VEH).ToString();
                        if ((ADV_VEH - (2 * REC_VEH)) > 0)
                        {
                            txtRecVehicle.Text = REC_VEH.ToString();
                        }
                        else
                        {
                            txtRecVehicle.Text = (ADV_VEH - REC_VEH).ToString();
                        }
                    }
                    double ADV_GOV_BAL = Convert.ToDouble(sdr["ADV_GOV_BAL"].ToString());
                    double REC_GOV_INST = Convert.ToDouble(sdr["REC_GOV_INST"].ToString());
                    if (ADV_GOV_BAL - REC_GOV_INST > 0)
                    {
                        txtGovtBal.Text = (ADV_GOV_BAL - REC_GOV_INST).ToString();
                        if ((ADV_GOV_BAL - (2 * REC_GOV_INST)) > 0)
                        {
                            txtRecGovInst.Text = REC_GOV_INST.ToString();
                        }
                        else
                        {
                            txtRecGovInst.Text = (ADV_GOV_BAL - REC_GOV_INST).ToString();
                        }
                    }
                }
                catch
                {
                    setAllZeros();
                }
            }
            else
            {
                setAllZeros();
            }
            con.Close();
        }

        public string preMonth(int month)
        {
            switch(month)
            {
                case 1: return "DEC"; 
                case 2: return "JAN"; 
                case 3: return "FEB"; 
                case 4: return "MAR"; 
                case 5: return "APR"; 
                case 6: return "MAY"; 
                case 7: return "JUN"; 
                case 8: return "JUL"; 
                case 9: return "AUG"; 
                case 10: return "SEP"; 
                case 11: return "OCT"; 
                case 12: return "NOV";
                default: return "XYZ";
            }
            
        }

        public void setAllZeros()
        {
            txtGrossPay.Text = "0";
            txtNetDeduction.Text = "0";
            txtNetPay.Text = "0";
            txtBasic.Text = "0";
            txtDa.Text = "0";
            txtHra.Text = "0";
            txtCla.Text = "0";
            txtUcpf.Text = "0";
            txtSpAllowance.Text = "0";
            txtConveyAllowance.Text = "0";
            txtExamAllowance.Text = "0";
            txtWasgAllowance.Text = "0";
            txtMedAllowance.Text = "0";
            txtAdhoc.Text = "0";
            txtOtherAllowances.Text = "0";
            txtLtcEncashment.Text = "0";
            txtDp.Text = "0";
            txtTotEarning.Text = "0";
            txtPf.Text = "0";
            txtUcpf1.Text = "0";
            txtGpf.Text = "0";
            txtLic.Text = "0";
            txtIncomeTax.Text = "0";
            txtProfTax.Text = "0";
            txtRent.Text = "0";
            txtGpfArrear.Text = "0";
            txtWc.Text = "0";
            txtStandardDeduction.Text = "0";
            txtSocSaving.Text = "0";
            txtFurniture.Text = "0";
            txtGgs.Text = "0";
            txtGpInsurance.Text = "0";
            txtPmCmRelief.Text = "0";
            txtEmpDeathHelp.Text = "0";
            txtOther.Text = "0";
            txtCtd.Text = "0";
            txtRd.Text = "0";
            txtTotDeduction.Text = "0";
            txtTotDeduction.Text = "0";
            txtCpf.Text = "0";
            txtFestival.Text = "0";
            txtNcpf.Text = "0";
            txtSociety.Text = "0";
            txtFood.Text = "0";
            txtHousing.Text = "0";
            txtVehicle.Text = "0";
            txtGovtBal.Text = "0";
            txtRecCpf.Text = "0";
            txtRecFestival.Text = "0";
            txtRecNcpf.Text = "0";
            txtRecSociety.Text = "0";
            txtRecFoodGrain.Text = "0";
            txtRecHousing.Text = "0";
            txtRecVehicle.Text = "0";
            txtRecGovInst.Text = "0";
        }
    }
}