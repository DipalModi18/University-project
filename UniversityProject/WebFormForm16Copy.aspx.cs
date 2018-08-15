using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using UniversityProject.App_Code;

namespace UniversityProject
{
    public partial class WebFormForm16Copy : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("PopupForm16.aspx");
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Reports/crptForm16.rpt"));

            dsForm16 form16 = new dsForm16();

            cmd = new SqlCommand("SELECT * FROM SALARY_CERTI$ WHERE EMPNO=@EMPNO AND SYEAR=@SYEAR", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@SYEAR", Request.QueryString["YEAR1"].ToString());
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            String EMPNAME = "", DESIGNATION = "", DEPTNAME = "";
            Double SALARY = 0, DA = 0, HRA = 0, CLA = 0, MA = 0, SPA = 0, PTD = 0, EXAMREM = 0, DAARR = 0, TESTING = 0, OTHERINCOME = 0, GPF = 0, GPFARR = 0, NCPF = 0, CPF = 0, PT = 0, GI = 0, IT = 0, CONVEY_ALL = 0;
            Boolean recordExists = false;
            while (rdr.Read())
            {
                EMPNAME = rdr["EMPNAME"].ToString();
                DESIGNATION = rdr["DESIGNATION"].ToString();
                DEPTNAME = rdr["DEPTNAME"].ToString();
                SALARY = Convert.ToDouble(rdr["GROSSTOTAL"]);
                DA = Convert.ToDouble(rdr["DA"]);
                HRA = Convert.ToDouble(rdr["HRA"]);
                CLA = Convert.ToDouble(rdr["CLA"]);
                MA = Convert.ToDouble(rdr["MA"]);
                SPA = Convert.ToDouble(rdr["SPA"]);
                PTD = Convert.ToDouble(rdr["PTD"]);
                EXAMREM = Convert.ToDouble(rdr["EXAMREM"]);
                DAARR = Convert.ToDouble(rdr["DAARR"]);
                TESTING = Convert.ToDouble(rdr["TESTING"]);
                OTHERINCOME = Convert.ToDouble(rdr["OTHERINCOME"]);
                GPF = Convert.ToDouble(rdr["GPF"]);
                GPFARR = Convert.ToDouble(rdr["GPFARR"]);
                NCPF = Convert.ToDouble(rdr["NCPF"]);
                CPF = Convert.ToDouble(rdr["CPF"]);
                PT = Convert.ToDouble(rdr["PT"]);
                GI = Convert.ToDouble(rdr["GI"]);
                IT = Convert.ToDouble(rdr["IT"]);
                CONVEY_ALL = Convert.ToDouble(rdr["CONVEY_ALL"]);
                recordExists = true;
            }
            con.Close();


            cmd = new SqlCommand("SELECT * FROM SAVINGS$ WHERE EMPNO=@EMPNO AND SAVING_YEAR=@SAVING_YEAR", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@SAVING_YEAR", Request.QueryString["YEAR1"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            Double HOUSE_LOAN = 0, NPS = 0, SEC80CCG = 0, SEC80DDB = 0, SEC80GG = 0, SEC80GGC = 0, SEC80TTA = 0, SEC80U = 0, MEDICLAIM_80D = 0, HANDICAPPED_80DD = 0, EDULOAN_80E = 0, DONATION_80G = 0;
            while (rdr.Read())
            {
                HOUSE_LOAN = (Double)(HOUSE_LOAN + Convert.ToDouble(rdr["HOUSELOAN"]));
                NPS = (Double)(NPS + Convert.ToDouble(rdr["NPS"]));
                SEC80CCG = (Double)(SEC80CCG + Convert.ToDouble(rdr["SEC80CCG"]));
                SEC80DDB = (Double)(SEC80DDB + Convert.ToDouble(rdr["SEC80DDB"]));
                SEC80GG = (Double)(SEC80GG + Convert.ToDouble(rdr["SEC80GG"]));
                SEC80GGC = (Double)(SEC80GGC + Convert.ToDouble(rdr["SEC80GGC"]));
                SEC80TTA = (Double)(SEC80TTA + Convert.ToDouble(rdr["SEC80TTA"]));
                SEC80U = (Double)(SEC80U + Convert.ToDouble(rdr["SEC80U"]));
                MEDICLAIM_80D = (Double)(MEDICLAIM_80D + Convert.ToDouble(rdr["MEDICLAIM"]));
                HANDICAPPED_80DD = (Double)(HANDICAPPED_80DD + Convert.ToDouble(rdr["HANDICAPPED"]));
                EDULOAN_80E = (Double)(EDULOAN_80E + Convert.ToDouble(rdr["EDULOAN"]));
                DONATION_80G = (Double)(DONATION_80G + Convert.ToDouble(rdr["DONATION"]));
            }
            con.Close();



            if (recordExists == false)
            {
                //Response.Write("<script>alert('Record of Salary Certificate for Employee "+Request.QueryString["EMPNO"]+" does not exists!!');</script>");
                //Response.Redirect("PopupSalaryCertificate.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Salary Certificate Note Generated!!');window.location ='PopupSalaryCertificate.aspx';", true);
            }


            cmd = new SqlCommand("SELECT * FROM EMP_PROFILE$ WHERE EMPNO=@EMPNO", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            String EMP_PAN = "";
            Int16 FACID = 0;
            string GENDER = "", AGEGROUP = "";
            while (rdr.Read())
            {
                EMP_PAN = rdr["PANNO"].ToString();
                FACID = Convert.ToInt16(rdr["FACID"].ToString());
                string gen = rdr["SEX"].ToString();
                if (gen.Equals("M"))
                {
                    GENDER = "MALE";
                }
                else
                {
                    GENDER = "FEMALE";
                }
                int age = DateTime.Now.Year - ((DateTime)rdr["DOB"]).Year;

                if (DateTime.Now.Month < ((DateTime)rdr["DOB"]).Month || (DateTime.Now.Month == ((DateTime)rdr["DOB"]).Month && DateTime.Now.Day < ((DateTime)rdr["DOB"]).Day))
                    age--;
                if (age <= 60)
                {
                    AGEGROUP = "NOT A SENIOR CITIZEN";
                }
                else
                {
                    AGEGROUP = "SENIOR CITIZEN";
                }
            }
            con.Close();

            cmd = new SqlCommand("SELECT * FROM FACULTY_PROFILE$ WHERE FACID=@FACID", con);
            cmd.Parameters.AddWithValue("@FACID", FACID);
            con.Open();
            rdr = cmd.ExecuteReader();
            String TANNO = "", FACULTY_NAME = "";
            while (rdr.Read())
            {
                TANNO = rdr["TANNO"].ToString();
                FACULTY_NAME = rdr["FACNAME"].ToString();
            }
            con.Close();

            DataRow row = form16.Tables[0].NewRow();
            form16.Tables[0].Rows.Add(row);
            form16.Tables[0].Rows[0]["DEDUCTOR_NAME"] = "Dean, " + FACULTY_NAME;
            form16.Tables[0].Rows[0]["FACULTY_NAME"] = FACULTY_NAME;
            form16.Tables[0].Rows[0]["EMPNAME"] = EMPNAME;
            form16.Tables[0].Rows[0]["EMPNO"] = Request.QueryString["EMPNO"];
            form16.Tables[0].Rows[0]["PERIOD_FROM"] = "01/04/" + Request.QueryString["YEAR1"];
            form16.Tables[0].Rows[0]["PERIOD_TO"] = "31/03/" + Request.QueryString["YEAR2"];
            form16.Tables[0].Rows[0]["TAN"] = TANNO;
            form16.Tables[0].Rows[0]["ASSESSMENT_YEAR1"] = Request.QueryString["YEAR1"] + "-" + Request.QueryString["YEAR2"];
            form16.Tables[0].Rows[0]["EMP_PAN"] = EMP_PAN;
            form16.Tables[0].Rows[0]["GROSS_SALARY_A"] = SALARY;
            form16.Tables[0].Rows[0]["GROSS_SALARY_B"] = "NIL";
            form16.Tables[0].Rows[0]["GROSS_SALARY_C"] = "NIL";
            form16.Tables[0].Rows[0]["GROSS_SALARY_D"] = SALARY;
            form16.Tables[0].Rows[0]["ALLOWANCE"] = CONVEY_ALL;
            Double BALANCE3 = 0;
            if (CONVEY_ALL > 0)
            {
                BALANCE3 = SALARY - CONVEY_ALL;
                form16.Tables[0].Rows[0]["ALLOWANCE"] = CONVEY_ALL;
                form16.Tables[0].Rows[0]["2TOTAL"] = CONVEY_ALL;
                form16.Tables[0].Rows[0]["3BALANCE"] = BALANCE3;
            }
            else
            {
                BALANCE3 = SALARY;
                //form16.Tables[0].Rows[0]["ALLOWANCE"] = "NIL";
                form16.Tables[0].Rows[0]["2TOTAL"] = "NIL";
                form16.Tables[0].Rows[0]["3BALANCE"] = BALANCE3;
            }
            form16.Tables[0].Rows[0]["DEDUCTIONS_A"] = "NIL";
            form16.Tables[0].Rows[0]["DEDUCTIONS_B"] = CPF;
            form16.Tables[0].Rows[0]["5AGGREGATE"] = CPF;
            Double INCOME_CHARGEBLE_UNDER_HEAD_SALARY = BALANCE3 - CPF;
            form16.Tables[0].Rows[0]["6INCOME_UNDER_HEAD_SALARY"] = INCOME_CHARGEBLE_UNDER_HEAD_SALARY;
            form16.Tables[0].Rows[0]["7OTHER_INCOME"] = "NIL";
            form16.Tables[0].Rows[0]["7TOTAL"] = "NIL";
            Double GROSS_TOTAL_INCOME8 = INCOME_CHARGEBLE_UNDER_HEAD_SALARY;
            form16.Tables[0].Rows[0]["8GROSS_TOTAL_INCOME"] = GROSS_TOTAL_INCOME8;


            //80c
            form16.Tables[0].Rows[0]["9DEDUCTIONS_AA_1"] = HOUSE_LOAN;
            cmd = new SqlCommand("SELECT * FROM SECTIONS", con);
            con.Open();
            rdr = cmd.ExecuteReader();
            Int16 countRows = 0;
            String[] sec80CNames = new String[10];
            Double[] sec80CValues = new Double[10];
            Double sec80CTotalAmount = 0;
            while (rdr.Read())
            {
                countRows++;
                sec80CNames[countRows - 1] = (rdr["NAME"].ToString()).Replace(" ", "");
            }
            con.Close();

            //Normal Savings Sections
            cmd = new SqlCommand("SELECT * FROM SAVINGS_SECTIONS$ WHERE NAME!='80C'", con);
            con.Open();
            rdr = cmd.ExecuteReader();
            Int16 countRows1 = 0;
            String[] secSavingsNames = new String[10];
            Double[] secSavingsValues = new Double[10];
            Double[] secSavingsLimit = new Double[10];
            while (rdr.Read())
            {
                countRows1++;
                secSavingsNames[countRows1 - 1] = (rdr["NAME"].ToString()).Replace(" ", "");
                secSavingsLimit[countRows1 - 1] = Convert.ToDouble(rdr["AMOUNT"]);
            }
            con.Close();

            cmd = new SqlCommand("SELECT * FROM SAVINGS$ WHERE EMPNO=@EMPNO AND SAVING_YEAR=@YEAR1", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@YEAR1", Request.QueryString["YEAR1"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            int count80C = 0, countSavings = 0;
            Double TotalSavingsSections = 0;
            while (rdr.Read())
            {
                while (count80C < 2 && count80C < countRows)
                {
                    sec80CValues[count80C] = Convert.ToDouble(rdr["" + sec80CNames[count80C]]);
                    count80C++;
                }
                while (count80C >= 2 && count80C <= (countRows - 1))
                {
                    sec80CValues[2] = sec80CValues[2] + Convert.ToDouble(rdr["" + sec80CNames[count80C]]);
                    count80C++;
                }
                while (countSavings < (countRows1))
                {
                    Response.Write("<script>alert('countSavings:" + countSavings + " countRows1:" + countRows1 + "');</script>");
                    secSavingsValues[countSavings] = Convert.ToDouble(rdr["" + secSavingsNames[countSavings]]);
                    if (secSavingsValues[countSavings] > secSavingsLimit[countSavings])
                    {
                        secSavingsValues[countSavings] = secSavingsLimit[countSavings];
                    }
                    countSavings++;
                }
            }
            con.Close();

            for (int i = 4; i < countRows1; i++)
            {
                secSavingsValues[3] = secSavingsValues[3] + secSavingsValues[i];
            }
            for (int i = 0; i < 3; i++)
            {
                sec80CTotalAmount = sec80CTotalAmount + sec80CValues[i];
            }
            sec80CTotalAmount = sec80CTotalAmount + HOUSE_LOAN; //+ TOT_SAVINGS;

            cmd = new SqlCommand("SELECT * FROM SAVINGS_SECTIONS$ WHERE NAME='80C'", con);
            con.Open();
            rdr = cmd.ExecuteReader();
            Double SEC80C_LIMIT = 0;
            while (rdr.Read())
            {
                SEC80C_LIMIT = Convert.ToDouble(rdr["AMOUNT"]);
            }
            Response.Write("<script>alert('80C LIMIT:" + SEC80C_LIMIT + " SEC80C_TOTAL_AMOUNT:" + sec80CTotalAmount + "');</script>");
            con.Close();
            if (sec80CTotalAmount > SEC80C_LIMIT) { sec80CTotalAmount = SEC80C_LIMIT; }

            if (countRows > 2)
            {
                sec80CNames[2] = "Other 80C savings";
            }
            if (countRows1 > 3)
            {
                secSavingsNames[3] = "Other Savings";
            }

            for (int i = 1; i <= 3 && i < (countRows + 1); i++)
            {
                form16.Tables[0].Rows[0]["DataColumnName" + i] = sec80CNames[i - 1];
                form16.Tables[0].Rows[0]["DataColumn" + i] = sec80CValues[i - 1];
            }
            for (int i = 1; i <= 4 && i < (countRows1 + 1); i++)
            {
                form16.Tables[0].Rows[0]["DataColumnName" + (i + 3)] = secSavingsNames[i - 1];
                form16.Tables[0].Rows[0]["DataColumn" + (i + 3)] = secSavingsValues[i - 1];
            }

            form16.Tables[0].Rows[0]["9DEDUCTIONS_AB_GROSS"] = "NIL";
            form16.Tables[0].Rows[0]["9DEDUCTIONS_AB_DEDUCTIBLE"] = "NIL";
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B1_GROSS"] = NPS;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B1_QUALYFYING"] = NPS;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B1_DEDUCTIBLE"] = NPS;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B2_GROSS"] = CPF;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B2_QUALYFYING"] = CPF;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B2_DEDUCTIBLE"] = CPF;
            Double SEC80CCD1_GROSS = CPF - NPS, SEC80CCD1_DEDUCTIBLE = 0;

            if (SEC80CCD1_GROSS > 0)
            {
                form16.Tables[0].Rows[0]["9DEDUCTIONS_AC_GROSS"] = SEC80CCD1_GROSS;
                sec80CTotalAmount = sec80CTotalAmount + SEC80CCD1_GROSS;
                if (sec80CTotalAmount > SEC80C_LIMIT) { sec80CTotalAmount = SEC80C_LIMIT; }
                SEC80CCD1_DEDUCTIBLE = SEC80C_LIMIT - HOUSE_LOAN;
                form16.Tables[0].Rows[0]["9DEDUCTIONS_AC_GROSS"] = SEC80CCD1_GROSS;
                form16.Tables[0].Rows[0]["9DEDUCTIONS_AC_DEDUCTIBLE"] = SEC80CCD1_DEDUCTIBLE;
            }
            else
            {
                form16.Tables[0].Rows[0]["9DEDUCTIONS_AC_GROSS"] = "NIL";
                form16.Tables[0].Rows[0]["9DEDUCTIONS_AC_DEDUCTIBLE"] = "NIL";
            }

            form16.Tables[0].Rows[0]["9DEDUCTIONS_B3_GROSS"] = SEC80CCG;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B3_QUALYFYING"] = SEC80CCG;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B3_DEDUCTIBLE"] = SEC80CCG;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B4_GROSS"] = MEDICLAIM_80D;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B4_QUALYFYING"] = MEDICLAIM_80D;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B4_DEDUCTIBLE"] = MEDICLAIM_80D;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B5_GROSS"] = HANDICAPPED_80DD;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B5_QUALYFYING"] = HANDICAPPED_80DD;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B5_DEDUCTIBLE"] = HANDICAPPED_80DD;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B6_GROSS"] = SEC80DDB;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B6_QUALYFYING"] = SEC80DDB;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B6_DEDUCTIBLE"] = SEC80DDB;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B7_GROSS"] = EDULOAN_80E;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B7_QUALYFYING"] = EDULOAN_80E;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B7_DEDUCTIBLE"] = EDULOAN_80E;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B8_GROSS"] = "NIL";
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B8_QUALYFYING"] = "NIL";
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B8_DEDUCTIBLE"] = "NIL";
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B9_GROSS"] = DONATION_80G;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B9_QUALYFYING"] = DONATION_80G;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B9_DEDUCTIBLE"] = DONATION_80G;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B10_GROSS"] = SEC80GG;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B10_QUALYFYING"] = SEC80GG;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B10_DEDUCTIBLE"] = SEC80GG;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B11_GROSS"] = "NIL";
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B11_QUALYFYING"] = "NIL";
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B11_DEDUCTIBLE"] = "NIL";
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B12_GROSS"] = SEC80GGC;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B12_QUALYFYING"] = SEC80GGC;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B12_DEDUCTIBLE"] = SEC80GGC;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B13_GROSS"] = SEC80TTA;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B13_QUALYFYING"] = SEC80TTA;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B13_DEDUCTIBLE"] = SEC80TTA;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B14_GROSS"] = SEC80U;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B14_QUALYFYING"] = SEC80U;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B14_DEDUCTIBLE"] = SEC80U;
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B15_GROSS"] = "NIL";
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B15_QUALYFYING"] = "NIL";
            form16.Tables[0].Rows[0]["9DEDUCTIONS_B15_DEDUCTIBLE"] = "NIL";
            Double AGGREGATE10_DEDUCTIBLE = sec80CTotalAmount + NPS + CPF + SEC80GG + MEDICLAIM_80D + HANDICAPPED_80DD + SEC80DDB + EDULOAN_80E + DONATION_80G + SEC80GG + SEC80GGC + SEC80TTA + SEC80U;
            form16.Tables[0].Rows[0]["10AGGREGATE_AMOUNT"] = AGGREGATE10_DEDUCTIBLE;
            Double TOTAL_INCOME11 = GROSS_TOTAL_INCOME8 - AGGREGATE10_DEDUCTIBLE;
            form16.Tables[0].Rows[0]["11TOTAL_INCOME"] = TOTAL_INCOME11;

            cmd = new SqlCommand("SELECT * FROM INCOMETAXSLAB WHERE YEAR1=@YEAR1 AND AGEGROUP=@AGEGROUP AND GENDER=@GENDER", con);
            cmd.Parameters.AddWithValue("@YEAR1", Request.QueryString["YEAR1"].ToString());
            cmd.Parameters.AddWithValue("@AGEGROUP", AGEGROUP);
            cmd.Parameters.AddWithValue("@GENDER", GENDER);
            con.Open();
            rdr = cmd.ExecuteReader();
            Double[] IncomeTaxSlabNo = new Double[5];
            Double[] IncomeTaxSlabLower = new Double[5];
            Double[] IncomeTaxSlabUpper = new Double[5];
            Double[] IncomeTaxSlabPercentage = new Double[5];
            Double[] IncomeTaxSlabEducess = new Double[5];
            Double[] IncomeTaxSlabHigherEducess = new Double[5];
            int countIncomeTaxSlabs = 0;
            String ErrorMessage = "";
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (Convert.ToInt16(rdr["SLABNO"]) == 1)
                    {
                        //STANDARD_DED = Convert.ToDouble(rdr["UPPERBOUND"]);
                        //EstimateTax.Tables[0].Rows[0]["STANDARD_DED"] = STANDARD_DED;
                    }
                    IncomeTaxSlabNo[countIncomeTaxSlabs] = Convert.ToDouble(rdr["SLABNO"]);
                    IncomeTaxSlabLower[countIncomeTaxSlabs] = Convert.ToDouble(rdr["LOWERBOUND"]);
                    IncomeTaxSlabUpper[countIncomeTaxSlabs] = Convert.ToDouble(rdr["UPPERBOUND"]);
                    IncomeTaxSlabPercentage[countIncomeTaxSlabs] = Convert.ToDouble(rdr["PERCENTAGE"]);
                    IncomeTaxSlabEducess[countIncomeTaxSlabs] = Convert.ToDouble(rdr["EDU_CESS"]);
                    IncomeTaxSlabHigherEducess[countIncomeTaxSlabs] = Convert.ToDouble(rdr["HIGHER_EDUCESS"]);
                    countIncomeTaxSlabs++;
                }
            }
            else
            {
                ErrorMessage = "Income Tax slab record for " + Request.QueryString["YEAR1"] + " Age-group :" + AGEGROUP + " Gender:" + GENDER + " does not Exists!!. Contact Admin";
            }

            if (!ErrorMessage.Equals(""))
            {
                Response.Write("<script>alert('" + ErrorMessage + "');</script>");
            }

            con.Close();



            Double TAX_TO_PAY = 0;
            int slab1Count = 0, slab2Count = 0, slab3Count = 0, slab4Count = 0;
            for (int i = 0; i < countIncomeTaxSlabs; i++)
            {
                if (IncomeTaxSlabNo[i] == 1)
                {
                    slab1Count = i;
                }
                else if (IncomeTaxSlabNo[i] == 2)
                {
                    slab2Count = i;
                }
                else if (IncomeTaxSlabNo[i] == 3)
                {
                    slab3Count = i;
                }
                else if (IncomeTaxSlabNo[i] == 4)
                {
                    slab4Count = i;
                }
            }
            //J_TOTAL_TAXABLE_INCOME = J_TOTAL_TAXABLE_INCOME + IncomeTaxSlabUpper[slab1Count];

            if (TOTAL_INCOME11 > IncomeTaxSlabLower[slab2Count])
            {
                Double new_income = 0;
                if (TOTAL_INCOME11 < IncomeTaxSlabUpper[slab2Count])
                {
                    new_income = TOTAL_INCOME11 - IncomeTaxSlabLower[slab2Count];
                }
                else
                {
                    new_income = IncomeTaxSlabUpper[slab2Count] - IncomeTaxSlabLower[slab2Count];
                }
                TAX_TO_PAY = TAX_TO_PAY + ((new_income * IncomeTaxSlabPercentage[slab2Count]) / 100);
                Response.Write("<script>alert('slab2:" + slab2Count + " upper:" + IncomeTaxSlabUpper[slab2Count] + " new_income:" + new_income + " percentage:" + IncomeTaxSlabPercentage[slab2Count] + " tax_to_pay:" + TAX_TO_PAY + "');</script>");
            }
            if (TOTAL_INCOME11 > IncomeTaxSlabLower[slab3Count])
            {
                Double new_income = 0;
                if (TOTAL_INCOME11 < IncomeTaxSlabUpper[slab3Count])
                {
                    new_income = TOTAL_INCOME11 - IncomeTaxSlabLower[slab3Count];
                }
                else
                {
                    new_income = IncomeTaxSlabUpper[slab3Count] - IncomeTaxSlabLower[slab3Count];
                }
                TAX_TO_PAY = TAX_TO_PAY + ((new_income * IncomeTaxSlabPercentage[slab3Count]) / 100);
                Response.Write("<script>alert('slab3:" + slab3Count + " upper:" + IncomeTaxSlabUpper[slab3Count] + " new_income:" + new_income + " percentage:" + IncomeTaxSlabPercentage[slab3Count] + " tax_to_pay:" + TAX_TO_PAY + "');</script>");
            }
            if (TOTAL_INCOME11 > IncomeTaxSlabLower[slab4Count])
            {
                Double new_income = 0;
                if (TOTAL_INCOME11 < IncomeTaxSlabUpper[slab4Count])
                {
                    new_income = TOTAL_INCOME11 - IncomeTaxSlabLower[slab4Count];
                }
                else
                {
                    new_income = IncomeTaxSlabUpper[slab4Count] - IncomeTaxSlabLower[slab4Count];
                }
                TAX_TO_PAY = TAX_TO_PAY + ((new_income * IncomeTaxSlabPercentage[slab4Count]) / 100);
                Response.Write("<script>alert('slab4:" + slab4Count + " upper:" + IncomeTaxSlabUpper[slab4Count] + " new_income:" + new_income + " percentage:" + IncomeTaxSlabPercentage[slab4Count] + " tax_to_pay:" + TAX_TO_PAY + "');</script>");
            }
            form16.Tables[0].Rows[0]["12TAX_ON_INCOME"] = TAX_TO_PAY;
            form16.Tables[0].Rows[0]["13SURCHARGE"] = "NIL";
            Double EDU_CESS = (TAX_TO_PAY * IncomeTaxSlabEducess[0]) / 100;
            Double HIGHER_EDUCESS = (TAX_TO_PAY * IncomeTaxSlabHigherEducess[0]) / 100;
            form16.Tables[0].Rows[0]["14EDUCESS"] = EDU_CESS + HIGHER_EDUCESS;
            Double TAX_PAYABLE15 = TAX_TO_PAY + EDU_CESS + HIGHER_EDUCESS;
            form16.Tables[0].Rows[0]["15TAX_PAYABLE"] = TAX_PAYABLE15;
            form16.Tables[0].Rows[0]["16RELIEF"] = "NIL";
            form16.Tables[0].Rows[0]["17TAX_PAYABLE"] = TAX_PAYABLE15;
            form16.Tables[0].Rows[0]["PLACE"] = "FATEHGUNJ";
            form16.Tables[0].Rows[0]["DATE"] = DateTime.Now.ToShortDateString();
            form16.Tables[0].Rows[0]["DESIGNATION"] = "DEAN";
            //form16.Tables[0].Rows[0]["FULL_NAME"] = "DEAN, " + FACULTY_NAME;
            form16.Tables[0].Rows[0]["EDUCESS_RATE_TOTAL"] = IncomeTaxSlabEducess[0] + IncomeTaxSlabHigherEducess[0];
            rd.SetDataSource(form16);


            //FacultyID
            ParameterFieldDefinition pdf;
            ParameterFieldDefinitions pdfs;
            ParameterValues pvs = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = Convert.ToInt16(FACID);
            pdfs = rd.DataDefinition.ParameterFields;
            pdf = pdfs["FacultyID"];
            pvs = pdf.CurrentValues;

            pvs.Clear();
            pvs.Add(pdv);
            pdf.ApplyCurrentValues(pvs);


            //Empno parameter
            pvs = new ParameterValues();
            pdv = new ParameterDiscreteValue();

            pdv.Value = Request.QueryString["EMPNO"];
            pdfs = rd.DataDefinition.ParameterFields;
            pdf = pdfs["EmployeeID"];
            pvs = pdf.CurrentValues;
            pvs.Add(pdv);
            pdf.ApplyCurrentValues(pvs);
            //

            //Year1 parameter
            pvs = new ParameterValues();
            pdv = new ParameterDiscreteValue();

            pdv.Value = Request.QueryString["YEAR1"];
            pdfs = rd.DataDefinition.ParameterFields;
            pdf = pdfs["Year1"];
            pvs = pdf.CurrentValues;
            pvs.Add(pdv);
            pdf.ApplyCurrentValues(pvs);
            //

            //Year2 parameter
            pvs = new ParameterValues();
            pdv = new ParameterDiscreteValue();

            pdv.Value = Convert.ToInt16(Request.QueryString["YEAR2"]);
            pdfs = rd.DataDefinition.ParameterFields;
            pdf = pdfs["Year2"];
            pvs = pdf.CurrentValues;
            pvs.Add(pdv);
            pdf.ApplyCurrentValues(pvs);
            //



            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Form 16");
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
    }
}