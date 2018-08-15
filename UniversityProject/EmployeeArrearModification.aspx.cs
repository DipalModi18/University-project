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
    public partial class EmployeeArrearModification : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString == null)
                {
                    Response.Redirect("EmployeeArrear.aspx");
                }
                //String value = Request.QueryString.ToString();
                //Char delimiter = '&';
                //String[] substrings = value.Split(delimiter);
                ///*foreach (var substring in substrings)
                //    Console.WriteLine(substring);
                ////var length = arrQueryStrings.Length;
                //Response.Write("<script>alert('"+value+"');</script>");
                //Response.Write("<script>alert('empid=" + substrings[0] + " month=" + substrings[1]+"');</script>");
                //Int16 Empid = Convert.ToInt16(substrings[0].ToString().Trim());//x=1,2
                //var Month = substrings[1].Trim();//x=3
                //Int16 Year = Convert.ToInt16(substrings[2].ToString().Trim());*/
                //if (substrings[0].StartsWith("EMPNO="))
                //{
                //    substrings[0] = substrings[0].Remove(0, "EMPNO=".Length);
                //}
                //if (substrings[1].StartsWith("MONTH="))
                //{
                //    substrings[1] = substrings[1].Remove(0, "MONTH=".Length);
                //}
                //if (substrings[2].StartsWith("YEAR="))
                //{
                //    substrings[2] = substrings[2].Remove(0, "YEAR=".Length);
                //}

                Int16 Empid = 0, Year = 0;
                string Month;
                //if (Int16.TryParse(substrings[0], out id))
                //{
                //    Empid = id;
                //}
                //if (Int16.TryParse(substrings[2], out year))
                //{
                //    Year = year;
                //}
                Empid = Convert.ToInt16(Request.QueryString["EMPNO"]);
                Year = Convert.ToInt16(Request.QueryString["YEAR"]);
                Month = Request.QueryString["MONTH"];
                Response.Write("<script>alert('EMPID=" + Empid + " MONTH=" + Month + "');</script>");


                //Int16 Empid = Convert.ToInt16(Request.QueryString["FACID"]);
                // var Month = Request.QueryString["MONTH"];
                // Int16 Year = Convert.ToInt16(Request.QueryString["YEAR"]);
                try
                {
                    DataSet ds = SelectEmpArrearData(Empid, Month, Year);
                    DataSet ds1 = SelectEmpData(Empid);
                    ShowEmpId.Text = Empid.ToString();
                    ShowMonth.Text = Month;
                    ShowYear.Text = Year.ToString();
                    txtName.Text = ds1.Tables[0].Rows[0]["EMPNAME"].ToString();
                    txtDesignation.Text = ds1.Tables[0].Rows[0]["DESIGNATION"].ToString();
                    Response.Write("<script>alert(' Empname =" + ds1.Tables[0].Rows[0]["EMPNAME"] + " Designation=" + ds1.Tables[0].Rows[0]["DESIGNATION"] + " Deptno=" + ds1.Tables[0].Rows[0]["DEPTNO"] + "');</script>");

                    if (ds1.Tables.Count == 0)
                    {
                        txtDept.Text = "";
                    }
                    else
                    {
                        int deptno = Convert.ToInt16(ds1.Tables[0].Rows[0]["DEPTNO"]);
                        Response.Write("<script>alert(' Deptname=" + deptno + "');</script>");
                        txtDept.Text = deptno.ToString();
                    }

                    if (ds1.Tables.Count == 0)
                    {
                        txtFac.Text = "";
                    }
                    else
                    {
                        txtFac.Text = Convert.ToInt16(ds1.Tables[0].Rows[0]["FACID"]).ToString();
                    }

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        txtBill.Text = ds.Tables[0].Rows[0]["BILL_NO"].ToString();
                        txtRateOfPay.Text = ds.Tables[0].Rows[0]["RATE_OF_PAY"].ToString();
                        txtEffectiveDays.Text = ds.Tables[0].Rows[0]["EFFECTIVE_DAYS"].ToString();
                        txtBasic.Text = ds.Tables[0].Rows[0]["BASIC"].ToString();
                        txtDa.Text = ds.Tables[0].Rows[0]["DA"].ToString();
                        txtHra.Text = ds.Tables[0].Rows[0]["HRA"].ToString();
                        txtCla.Text = ds.Tables[0].Rows[0]["CLA"].ToString();
                        txtUcpf.Text = ds.Tables[0].Rows[0]["EAR_UCPF"].ToString();
                        txtSpAllowance.Text = ds.Tables[0].Rows[0]["SPEC_ALL"].ToString();
                        txtLtcEncashment.Text = ds.Tables[0].Rows[0]["LTC_ENCASHMENT"].ToString();
                        txtConveyAllowance.Text = ds.Tables[0].Rows[0]["CONVEY_ALL"].ToString();
                        txtExamAllowance.Text = ds.Tables[0].Rows[0]["EXAM_ALL"].ToString();
                        txtWasgAllowance.Text = ds.Tables[0].Rows[0]["WASH_ALL"].ToString();
                        txtMedAllowance.Text = ds.Tables[0].Rows[0]["MED_ALL"].ToString();
                        txtAdhoc.Text = ds.Tables[0].Rows[0]["ADHOC_BONUS"].ToString();
                        txtDp.Text = ds.Tables[0].Rows[0]["DP"].ToString();
                        txtOtherAllowances.Text = ds.Tables[0].Rows[0]["EAR_OTHER"].ToString();
                        txtTotEarning.Text = ds.Tables[0].Rows[0]["EAR_TOTAL"].ToString();
                        txtPf.Text = ds.Tables[0].Rows[0]["PF"].ToString();
                        txtUcpf1.Text = ds.Tables[0].Rows[0]["DED_UCPF"].ToString();
                        txtGpf.Text = ds.Tables[0].Rows[0]["GPF"].ToString();
                        txtLic.Text = ds.Tables[0].Rows[0]["LIC"].ToString();
                        txtIncomeTax.Text = ds.Tables[0].Rows[0]["INC_TAX"].ToString();
                        txtProfTax.Text = ds.Tables[0].Rows[0]["PROF_TAX"].ToString();
                        txtRent.Text = ds.Tables[0].Rows[0]["RENT"].ToString();
                        txtGpfArrear.Text = ds.Tables[0].Rows[0]["GPF_ARR"].ToString();
                        txtWc.Text = ds.Tables[0].Rows[0]["WC"].ToString();
                        txtSocSaving.Text = ds.Tables[0].Rows[0]["SOC_SAV"].ToString();
                        txtFurniture.Text = ds.Tables[0].Rows[0]["FUR"].ToString();
                        txtGgs.Text = ds.Tables[0].Rows[0]["GGS"].ToString();
                        txtGpInsurance.Text = ds.Tables[0].Rows[0]["GROP_INS"].ToString();
                        txtPmCmRelief.Text = ds.Tables[0].Rows[0]["PM_CMRELIEF"].ToString();
                        txtEmpDeathHelp.Text = ds.Tables[0].Rows[0]["DEATH_HELP"].ToString();
                        txtOther.Text = ds.Tables[0].Rows[0]["DED_OTHER"].ToString();
                        txtCtd.Text = ds.Tables[0].Rows[0]["CTD"].ToString();
                        txtRd.Text = ds.Tables[0].Rows[0]["RD"].ToString();
                        txtTotDeduction.Text = ds.Tables[0].Rows[0]["DED_TOTAL"].ToString();
                        txtCpf.Text = ds.Tables[0].Rows[0]["ADV_CPF"].ToString();
                        txtFestival.Text = ds.Tables[0].Rows[0]["ADV_FEST"].ToString();
                        txtNcpf.Text = ds.Tables[0].Rows[0]["ADV_NCPF"].ToString();
                        txtSociety.Text = ds.Tables[0].Rows[0]["ADV_SOC"].ToString();
                        txtFood.Text = ds.Tables[0].Rows[0]["ADV_FOOD"].ToString();
                        txtHousing.Text = ds.Tables[0].Rows[0]["ADV_HOS"].ToString();
                        txtVehicle.Text = ds.Tables[0].Rows[0]["ADV_VEH"].ToString();
                        txtGovtBal.Text = ds.Tables[0].Rows[0]["ADV_GOV_BAL"].ToString();
                        txtRecCpf.Text = ds.Tables[0].Rows[0]["REC_CPF"].ToString();
                        txtRecFestival.Text = ds.Tables[0].Rows[0]["REC_FEST"].ToString();
                        txtRecNcpf.Text = ds.Tables[0].Rows[0]["REC_NCPF"].ToString();
                        txtRecSociety.Text = ds.Tables[0].Rows[0]["REC_SOC"].ToString();
                        txtRecFoodGrain.Text = ds.Tables[0].Rows[0]["REC_FOOD_GRAIN"].ToString();
                        txtRecHousing.Text = ds.Tables[0].Rows[0]["REC_HOS"].ToString();
                        txtRecVehicle.Text = ds.Tables[0].Rows[0]["REC_VEH"].ToString();
                        txtRecGovInst.Text = ds.Tables[0].Rows[0]["REC_GOV_INST"].ToString();
                        NetPayDiv.Visible = false;
                    }
                }
                catch(Exception ee)
                {
                    Response.Write("<script>alert('Error While Rendering Data!!');</script>");
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

        public DataSet SelectEmpArrearData(Int16? Empid, string Month, Int16 Year)
        {
            try
            {

                DataSet ds = new DataSet();
                SqlConnection con = con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("select * from EMP_ARREAR$ where EMPNO=@EMPNO and MONTH=@MONTH and YEAR=@YEAR", con);
                cmd.Parameters.AddWithValue("EMPNO", Empid);
                cmd.Parameters.AddWithValue("MONTH", Month);
                cmd.Parameters.AddWithValue("YEAR", Year);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Fetching Data!!');</script>");
                return new DataSet();
            }
        }

        public DataSet SelectEmpData(Int16? Empid)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("select EMPNAME,DESIGNATION,DEPTNO,FACID from EMP_PROFILE$ where EMPNO=@EMPNO", con);
                cmd.Parameters.AddWithValue("EMPNO", Empid);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                return ds;
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Fetching Employee Details!!');</script>");
                return new DataSet();
            }
        }

        public string SelectDeptName(Int16? DeptId)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("select DEPTNAME from DEPT_PROFILE$ where DEPTNO=@DEPTNO", con);
                cmd.Parameters.AddWithValue("DEPTNO", DeptId);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                string deptname = ds.Tables[0].Rows[0]["DEPTNAME"].ToString();
                return deptname;
            }
            catch(Exception ee)
            {
                return "";
            }
        }

        public string SelectFacName(Int16? FacId)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection con = con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("select FACNAME from FACULTY_PROFILE$ where FACID=@FACID", con);
                cmd.Parameters.AddWithValue("FACID", FacId);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                return ds.Tables[0].Rows[0]["FACNAME"].ToString();
            }
            catch (Exception ee)
            {
                return "";
            }

        }

        protected void btnEarning_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(ViewEarning);
            NetPayDiv.Visible = false;
        }

        protected void btnDeduction_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(ViewDeduction);
            NetPayDiv.Visible = false;
        }

        protected void btnAdvRec_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(ViewAdvRecovery);
            NetPayDiv.Visible = false;
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
                    Convert.ToDouble(txtLtcEncashment.Text) +
                    Convert.ToDouble(txtOtherAllowances.Text);
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
                  Convert.ToDouble(txtSocSaving.Text) +
                  Convert.ToDouble(txtFurniture.Text) +
                  Convert.ToDouble(txtGgs.Text) +
               Convert.ToDouble(txtGpInsurance.Text) +
               Convert.ToDouble(txtPmCmRelief.Text) +
               Convert.ToDouble(txtEmpDeathHelp.Text) +
               Convert.ToDouble(txtOther.Text) +
               Convert.ToDouble(txtCtd.Text) +
               Convert.ToDouble(txtRd.Text);
                txtTotDeduction.Text = TotalDeduction.ToString();
                txtNetDeduction.Text = TotalDeduction.ToString();
            }
            catch (FormatException fe)
            {
                txtTotDeduction.Text = "0";
                txtNetDeduction.Text = "0";
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
                Response.Write("<script>alert('Enter Valid Numbers for Recoveries!!');</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //var Empid = Convert.ToInt16(ShowEmpId.Text);
            //var Month = ShowMonth.Text;
            //var Year = Convert.ToInt16(ShowYear.Text);
            //DataSet ds = SelectEmpArrearData(Empid, Month, Year);
            //DataSet ds1 = SelectEmpData(Empid);
            //ShowEmpId.Text = Empid.ToString();
            //ShowMonth.Text = Month;
            //ShowYear.Text = Year.ToString();
            //txtName.Text = ds1.Tables[0].Rows[0]["EMPNAME"].ToString();
            //txtDesignation.Text = ds1.Tables[0].Rows[0]["DESIGNATION"].ToString();
            //txtDept.Text = SelectDeptName(Convert.ToInt16(ds1.Tables[0].Rows[0]["DEPTNO"]));
            //txtFac.Text = SelectFacName(Convert.ToInt16(ds1.Tables[0].Rows[0]["FACID"]));
            //txtBill.Text = ds.Tables[0].Rows[0]["BILL_NO"].ToString();
            //txtRateOfPay.Text = ds.Tables[0].Rows[0]["RATE_OF_PAY"].ToString();
            //txtBasic.Text = ds.Tables[0].Rows[0]["BASIC"].ToString();
            //txtDa.Text = ds.Tables[0].Rows[0]["DA"].ToString();
            //txtHra.Text = ds.Tables[0].Rows[0]["HRA"].ToString();
            //txtCla.Text = ds.Tables[0].Rows[0]["CLA"].ToString();
            //txtUcpf.Text = ds.Tables[0].Rows[0]["EAR_UCPF"].ToString();
            //txtSpAllowance.Text = ds.Tables[0].Rows[0]["SPEC_ALL"].ToString();
            //txtConveyAllowance.Text = ds.Tables[0].Rows[0]["CONVEY_ALL"].ToString();
            //txtExamAllowance.Text = ds.Tables[0].Rows[0]["EXAM_ALL"].ToString();
            //txtWasgAllowance.Text = ds.Tables[0].Rows[0]["WASH_ALL"].ToString();
            //txtMedAllowance.Text = ds.Tables[0].Rows[0]["MED_ALL"].ToString();
            //txtAdhoc.Text = ds.Tables[0].Rows[0]["EAR_OTHER"].ToString();
            //txtDp.Text = ds.Tables[0].Rows[0]["DP"].ToString();
            //txtTotEarning.Text = ds.Tables[0].Rows[0]["EAR_TOTAL"].ToString();
            //txtPf.Text = ds.Tables[0].Rows[0]["PF"].ToString();
            //txtUcpf1.Text = ds.Tables[0].Rows[0]["DED_UCPF"].ToString();
            //txtGpf.Text = ds.Tables[0].Rows[0]["GPF"].ToString();
            //txtLic.Text = ds.Tables[0].Rows[0]["LIC"].ToString();
            //txtIncomeTax.Text = ds.Tables[0].Rows[0]["INC_TAX"].ToString();
            //txtProfTax.Text = ds.Tables[0].Rows[0]["PROF_TAX"].ToString();
            //txtRent.Text = ds.Tables[0].Rows[0]["RENT"].ToString();
            //txtGpfArrear.Text = ds.Tables[0].Rows[0]["GPF_ARR"].ToString();
            //txtWc.Text = ds.Tables[0].Rows[0]["WC"].ToString();
            //txtSocSaving.Text = ds.Tables[0].Rows[0]["SOC_SAV"].ToString();
            //txtFurniture.Text = ds.Tables[0].Rows[0]["FUR"].ToString();
            //txtGgs.Text = ds.Tables[0].Rows[0]["GGS"].ToString();
            //txtGpInsurance.Text = ds.Tables[0].Rows[0]["GROP_INS"].ToString();
            //txtPmCmRelief.Text = ds.Tables[0].Rows[0]["PM_CMRELIEF"].ToString();
            //txtEmpDeathHelp.Text = ds.Tables[0].Rows[0]["DEATH_HELP"].ToString();
            //txtOther.Text = ds.Tables[0].Rows[0]["DED_OTHER"].ToString();
            //txtCtd.Text = ds.Tables[0].Rows[0]["CTD"].ToString();
            //txtRd.Text = ds.Tables[0].Rows[0]["RD"].ToString();
            //txtTotDeduction.Text = ds.Tables[0].Rows[0]["DED_TOTAL"].ToString();
            //txtCpf.Text = ds.Tables[0].Rows[0]["ADV_CPF"].ToString();
            //txtFestival.Text = ds.Tables[0].Rows[0]["ADV_FEST"].ToString();
            //txtNcpf.Text = ds.Tables[0].Rows[0]["ADV_NCPF"].ToString();
            //txtSociety.Text = ds.Tables[0].Rows[0]["ADV_SOC"].ToString();
            //txtFood.Text = ds.Tables[0].Rows[0]["ADV_FOOD"].ToString();
            //txtHousing.Text = ds.Tables[0].Rows[0]["ADV_HOS"].ToString();
            //txtVehicle.Text = ds.Tables[0].Rows[0]["ADV_VEH"].ToString();
            //txtGovtBal.Text = ds.Tables[0].Rows[0]["ADV_GOV_BAL"].ToString();
            //txtRecCpf.Text = ds.Tables[0].Rows[0]["REC_CPF"].ToString();
            //txtRecFestival.Text = ds.Tables[0].Rows[0]["REC_FEST"].ToString();
            //txtRecNcpf.Text = ds.Tables[0].Rows[0]["REC_NCPF"].ToString();
            //txtRecSociety.Text = ds.Tables[0].Rows[0]["REC_SOC"].ToString();
            //txtRecFoodGrain.Text = ds.Tables[0].Rows[0]["REC_FOOD_GRAIN"].ToString();
            //txtRecHousing.Text = ds.Tables[0].Rows[0]["REC_HOS"].ToString();
            //txtRecVehicle.Text = ds.Tables[0].Rows[0]["REC_VEH"].ToString();
            //txtRecGovInst.Text = ds.Tables[0].Rows[0]["REC_GOV_INST"].ToString();
            //NetPayDiv.Visible = false;
            Response.Redirect("EmployeeArrear.aspx");
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            btnTotEarning_Click(null, EventArgs.Empty);
            btnTotDeduction_Click(null, EventArgs.Empty);
            btnGovtBal_Click(null, EventArgs.Empty);
            btnRecGovtInst_Click(null, EventArgs.Empty);

            Double TotalEarnings = Convert.ToDouble(txtTotEarning.Text);
            Double TotalDeduction = Convert.ToDouble(txtTotDeduction.Text);

            double netpay = TotalEarnings - TotalDeduction;
            txtNetPay.Text = netpay.ToString();
            // txtNetPay.Text = (Convert.ToInt32(txtGrossPay.Text) - Convert.ToInt32(txtNetDeduction.Text)).ToString();
            NetPayDiv.Visible = true;

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("update EMP_ARREAR$ set BILL_NO=@BILL_NO, RATE_OF_PAY=@RATE_OF_PAY, EFFECTIVE_DAYS=@EFFECTIVE_DAYS, BASIC=@BASIC, DA=@DA, HRA=@HRA, CLA=@CLA, EAR_UCPF=@EAR_UCPF, SPEC_ALL=@SPEC_ALL, CONVEY_ALL=@CONVEY_ALL, EXAM_ALL=@EXAM_ALL, WASH_ALL=@WASH_ALL, MED_ALL=@MED_ALL, EAR_OTHER=@EAR_OTHER, DP=@DP, PF=@PF, DED_UCPF=@DED_UCPF, GPF=@GPF, LIC=@LIC, INC_TAX=@INC_TAX, PROF_TAX=@PROF_TAX, RENT=@RENT, GPF_ARR=@GPF_ARR, WC=@WC, SOC_SAV=@SOC_SAV, FUR=@FUR, GGS=@GGS, GROP_INS=@GROP_INS, PM_CMRELIEF=@PM_CMRELIEF, DEATH_HELP=@DEATH_HELP, DED_OTHER=@DED_OTHER, CTD=@CTD, RD=@RD, ADV_CPF=@ADV_CPF, ADV_FEST=@ADV_FEST, ADV_NCPF=@ADV_NCPF, ADV_SOC=@ADV_SOC, ADV_FOOD=@ADV_FOOD, ADV_HOS=@ADV_HOS, ADV_VEH=@ADV_VEH, ADV_GOV_BAL=@ADV_GOV_BAL, REC_CPF=@REC_CPF, REC_FEST=@REC_FEST, REC_NCPF=@REC_NCPF, REC_SOC=@REC_SOC, REC_FOOD_GRAIN=@REC_FOOD_GRAIN, REC_HOS=@REC_HOS, REC_VEH=@REC_VEH, REC_GOV_INST=@REC_GOV_INST, EAR_TOTAL=@EAR_TOTAL, DED_TOTAL=@DED_TOTAL, GROSS_PAY=@GROSS_PAY,TOT_DED=@TOT_DED, NET_PAY=@NET_PAY, ADHOC_BONUS=@ADHOC_BONUS, LTC_ENCASHMENT=@LTC_ENCASHMENT where EMPNO=@EMPNO AND MONTH=@MONTH AND YEAR=@YEAR", con);
                cmd.Parameters.AddWithValue("EMPNO", ShowEmpId.Text);
                cmd.Parameters.AddWithValue("BILL_NO", txtBill.Text);
                cmd.Parameters.AddWithValue("RATE_OF_PAY", txtRateOfPay.Text);
                cmd.Parameters.AddWithValue("EFFECTIVE_DAYS", txtEffectiveDays.Text);
                cmd.Parameters.AddWithValue("MONTH", ShowMonth.Text);
                cmd.Parameters.AddWithValue("YEAR", ShowYear.Text);
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
                Response.Write("<script>alert('Data Saved Successfully!!');</script>");
            }
            catch(Exception ee)
            {
                Response.Write("<script>alert('Error While Saving Data!!');</script>");
            }
        }
    }
}