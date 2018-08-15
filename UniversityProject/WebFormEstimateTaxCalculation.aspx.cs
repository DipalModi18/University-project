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
    public partial class WebFormEstimateTaxCalculation : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        Boolean success=true;
        String ErrorMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count <= 0)
            {
                Response.Redirect("PopupEstimateTaxCalculation.aspx");
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Reports/crptEstimateTaxCalculation.rpt"));


            dsEstimateTax EstimateTax = new dsEstimateTax();
            for (int i = 0; i <= 54; i++)
            {
                    EstimateTax.Tables[0].Columns[i].DataType = typeof(Double);
                //String c = EstimateTax.Tables[0].Columns[i].ColumnName;
                //Response.Write("<script>alert('Column  :"+i+" is " + c + "');</script>");
            }
            for (int i = 58; i <= 86; i=i+2)
            {
                if(!(i==68 || i==70 || i==72 || i==74 || i==76))
                {
                    EstimateTax.Tables[0].Columns[i].DataType = typeof(Double);
                }
                
                //String c = EstimateTax.Tables[0].Columns[i].ColumnName;
                //Response.Write("<script>alert('Column  :"+i+" is " + c + "');</script>");
            }
            for (int i = 86; i <= 93; i++)
            {
                EstimateTax.Tables[0].Columns[i].DataType = typeof(Double);
                //String c = EstimateTax.Tables[0].Columns[i].ColumnName;
                //Response.Write("<script>alert('Column  :"+i+" is " + c + "');</script>");
            }

            cmd = new SqlCommand("SELECT * FROM PAY_SLIP$ WHERE EMPNO=@EMPNO AND ((MONTH IN ('MAR','APR','MAY','JUN','JUL','AUG','SEP','OCT','NOV','DEC') AND YEAR=@YEAR1) OR (MONTH IN('JAN', 'FEB') AND YEAR = @YEAR2))", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@YEAR1", Request.QueryString["YEAR1"].ToString());
            cmd.Parameters.AddWithValue("@YEAR2", Request.QueryString["YEAR2"].ToString());
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            //DataSet ds;
            Double BASIC = 0, DA = 0, HRA = 0, CLA = 0, MED_ALL = 0, EXAM_ALL = 0, DP = 0, SPEC_ALL = 0, ADHOC = 0, LTC_ENCASHMENT = 0,OTHER_ALLOWANCE=0, TRANSPORT=0, GROUP_INSURANCE=0; // TRANSPORT=CONVEYANCE ALLOWANCE
            Double PROF_TAX = 0, INCOME_TAX_TDS=0, PF_CONTRIBUTORY=0, PF_NON_CONTRIBUTORY=0;
            double GPF_ARREARS = 0, GPF=0, LIC_PREMIUM_SAL_BILL=0, STANDARD_DED=0;
            Double REM_BASIC = 0, REM_DA = 0, REM_HRA = 0, REM_CLA = 0, REM_SPEC_ALL = 0, REM_UCPF = 0, REM_CONVEYANCE_ALLOWANCE=0, REM_MED_ALL = 0, REM_EXAM_ALL=0, REM_DP=0, REM_OTHER_ALLOWANCE=0;
            Double REM_GPF = 0, REM_GROUP_INSURANCE = 0, REM_PROF_TAX = 0, REM_LIC_PREMIUM_SAL_BILL = 0, REM_PF_CONTRIBUTORY=0;
            double months = 0;
            int lastMonthYear1=0, lastMonthYear2=0;
            Int16 year1 = Convert.ToInt16(Request.QueryString["YEAR1"]);
            Int16 year2 = Convert.ToInt16(Request.QueryString["YEAR2"]);
            Int16 lastYear=0;
            while (rdr.Read())
            {
                REM_BASIC = Convert.ToDouble(rdr["BASIC"]);
                BASIC = (Double)(BASIC + REM_BASIC);
                REM_DA = Convert.ToDouble(rdr["DA"]);
                DA = (Double)(DA + REM_DA);
                REM_HRA = Convert.ToDouble(rdr["HRA"]);
                HRA = (Double)(HRA + REM_HRA);
                REM_CLA = Convert.ToDouble(rdr["CLA"]);
                CLA = (Double)(CLA + REM_CLA);
                REM_MED_ALL = Convert.ToDouble(rdr["MED_ALL"]); 
                MED_ALL = (Double)(MED_ALL + REM_MED_ALL);
                REM_EXAM_ALL = Convert.ToDouble(rdr["EXAM_ALL"]);
                EXAM_ALL = (Double)(EXAM_ALL + REM_EXAM_ALL);
                REM_DP = Convert.ToDouble(rdr["DP"]);
                DP = (Double)(DP + REM_DP);
                REM_SPEC_ALL = Convert.ToDouble(rdr["SPEC_ALL"]);
                SPEC_ALL = (Double)(SPEC_ALL + REM_SPEC_ALL);
                ADHOC = (Double)(ADHOC + Convert.ToDouble(rdr["ADHOC_BONUS"]));  
                LTC_ENCASHMENT = (Double)(LTC_ENCASHMENT + Convert.ToDouble(rdr["LTC_ENCASHMENT"]));
                REM_OTHER_ALLOWANCE = Convert.ToDouble(rdr["EAR_OTHER"]);
                OTHER_ALLOWANCE = (Double)(OTHER_ALLOWANCE + REM_OTHER_ALLOWANCE);
                REM_CONVEYANCE_ALLOWANCE = Convert.ToDouble(rdr["CONVEY_ALL"]);
                TRANSPORT = (Double)(TRANSPORT + REM_CONVEYANCE_ALLOWANCE);
                REM_GROUP_INSURANCE = Convert.ToDouble(rdr["GROP_INS"]);
                GROUP_INSURANCE = (Double)(GROUP_INSURANCE + REM_GROUP_INSURANCE);
                GPF_ARREARS = (Double)(GPF_ARREARS + Convert.ToDouble(rdr["GPF_ARR"]));
                REM_LIC_PREMIUM_SAL_BILL = Convert.ToDouble(rdr["LIC"]);
                LIC_PREMIUM_SAL_BILL = (Double)(LIC_PREMIUM_SAL_BILL + REM_LIC_PREMIUM_SAL_BILL);
                REM_GPF = Convert.ToDouble(rdr["GPF"]);
                GPF = (Double)(GPF + REM_GPF);
                REM_PROF_TAX = Convert.ToDouble(rdr["PROF_TAX"]);
                PROF_TAX = (Double)(PROF_TAX + REM_PROF_TAX);
                INCOME_TAX_TDS = (Double)(INCOME_TAX_TDS + Convert.ToDouble(rdr["INC_TAX"]));
                REM_PF_CONTRIBUTORY = Convert.ToDouble(rdr["PF"]);
                PF_CONTRIBUTORY = (Double)(PF_CONTRIBUTORY + REM_PF_CONTRIBUTORY);
                PF_NON_CONTRIBUTORY = (Double)(PF_NON_CONTRIBUTORY + Convert.ToDouble(rdr["DED_UCPF"]));
                STANDARD_DED = (Double)(STANDARD_DED + Convert.ToDouble(rdr["STANDARD_DEDUCTION"]));
                int m = (Int16)(ConvertToMonth(rdr["MONTH"].ToString().ToUpper()));
                int y = Convert.ToInt16(rdr["YEAR"].ToString());
                if (year1 == y) { if (lastMonthYear1 < m) { lastMonthYear1 = m; } }
                else if (year2 == y) { if (lastMonthYear2 < m) { lastMonthYear2 = m; } }
                months++;
                //Response.Write("<script>alert(' Basic :" + basic + "');</script>");
            }
            con.Close();
            //DataSet ds;
            double monthsRemaining = 0;
            if (lastMonthYear2 == 0) { monthsRemaining = (12 - lastMonthYear1) + 2;  }
            else { monthsRemaining = (2 - lastMonthYear2); }
            Response.Write("<script>alert('lastMonthYear1:"+lastMonthYear1+" lastmonthYear2:"+lastMonthYear2+" monthsRemaining:"+monthsRemaining+"');</script>");
            //double monthsRemaining = 12-months;
            
            Response.Write("<script>alert('Months:" + months + " Months Remaining:"+monthsRemaining+" BASIC BEFORE REM_BASIC:"+BASIC+"');</script>");
            Response.Write("<script>alert('REM_BASIC:"+REM_BASIC+"');</script>");

           REM_BASIC = REM_BASIC * monthsRemaining;
            REM_DA = REM_DA * monthsRemaining;
            REM_HRA = REM_HRA * monthsRemaining;
            REM_CLA = REM_CLA * monthsRemaining;
            REM_SPEC_ALL = REM_SPEC_ALL * monthsRemaining;
            REM_UCPF = REM_UCPF * monthsRemaining;
            REM_CONVEYANCE_ALLOWANCE = REM_CONVEYANCE_ALLOWANCE * monthsRemaining;
            REM_MED_ALL = REM_MED_ALL*monthsRemaining;
            REM_GPF = REM_GPF * monthsRemaining;
            REM_GROUP_INSURANCE = REM_GROUP_INSURANCE * monthsRemaining;
            REM_PROF_TAX = REM_PROF_TAX * monthsRemaining;
            REM_LIC_PREMIUM_SAL_BILL = REM_LIC_PREMIUM_SAL_BILL*monthsRemaining;
            REM_EXAM_ALL = REM_EXAM_ALL * monthsRemaining;
            REM_DP = REM_DP * monthsRemaining;
            REM_OTHER_ALLOWANCE = REM_OTHER_ALLOWANCE * monthsRemaining;
            REM_PF_CONTRIBUTORY = REM_PF_CONTRIBUTORY * monthsRemaining;

            BASIC = BASIC + REM_BASIC;
            DA = DA + REM_DA;
            HRA = HRA + REM_HRA;
            CLA = CLA + REM_CLA;
            SPEC_ALL = SPEC_ALL + REM_SPEC_ALL;
            //UCPF = UCPF+ REM_UCPF;
            TRANSPORT = TRANSPORT + REM_CONVEYANCE_ALLOWANCE;
            MED_ALL = MED_ALL + REM_MED_ALL;
            GPF = GPF + REM_GPF;
            GROUP_INSURANCE = GROUP_INSURANCE + REM_GROUP_INSURANCE;
            PROF_TAX = PROF_TAX + REM_PROF_TAX;
            LIC_PREMIUM_SAL_BILL = LIC_PREMIUM_SAL_BILL + REM_LIC_PREMIUM_SAL_BILL;
            EXAM_ALL = EXAM_ALL + REM_EXAM_ALL;
            DP = DP + REM_DP;
            OTHER_ALLOWANCE = OTHER_ALLOWANCE + REM_OTHER_ALLOWANCE;
            PF_CONTRIBUTORY = PF_CONTRIBUTORY + REM_PF_CONTRIBUTORY;

            DataRow row = EstimateTax.Tables[0].NewRow();
            row["EMPNO"] = Request.QueryString["EMPNO"];
            row["YEAR1"] = Request.QueryString["YEAR1"];

            Double inc_tax_other = 0; //inc_tax_other is for income tax in PTD, PTPGDCA, EXAM REMUNERATION, TESTING, DA ARREARS
            cmd = new SqlCommand("select * from EMP_ARREAR$ where EMPNO=@EMPNO AND ((MONTH IN ('MAR','APR','MAY','JUN','JUL','AUG','SEP','OCT','NOV','DEC') AND YEAR=@YEAR1) OR (MONTH IN('JAN', 'FEB') AND YEAR = @YEAR2))", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@YEAR1", Request.QueryString["YEAR1"].ToString());
            cmd.Parameters.AddWithValue("@YEAR2", Request.QueryString["YEAR2"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            double EMP_ARREAR_EARNING = 0;
            while (rdr.Read())
            {
                // Add all EMP_ARREAR earning to BASIC
            }
            con.Close();



            cmd = new SqlCommand("SELECT * FROM PTD$ WHERE EMPNO=@EMPNO AND ((MONTH IN ('MAR','APR','MAY','JUN','JUL','AUG','SEP','OCT','NOV','DEC') AND YEAR=@YEAR1) OR (MONTH IN('JAN', 'FEB') AND YEAR = @YEAR2))", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@YEAR1", Request.QueryString["YEAR1"].ToString());
            cmd.Parameters.AddWithValue("@YEAR2", Request.QueryString["YEAR2"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            Double PTD = 0;
            while (rdr.Read())
            {
                PTD = (Double)(PTD + Convert.ToDouble(rdr["PTD"]));
                inc_tax_other = inc_tax_other + Convert.ToDouble(rdr["INC_TAX"]);
            }
            con.Close();

            cmd = new SqlCommand("SELECT * FROM DAARREARS$ WHERE EMPNO=@EMPNO AND ((MONTH IN ('MAR','APR','MAY','JUN','JUL','AUG','SEP','OCT','NOV','DEC') AND YEAR=@YEAR1) OR (MONTH IN('JAN', 'FEB') AND YEAR = @YEAR2))", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@YEAR1", Request.QueryString["YEAR1"].ToString());
            cmd.Parameters.AddWithValue("@YEAR2", Request.QueryString["YEAR2"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            Double DAARREARS = 0;
            while (rdr.Read())
            {
                DAARREARS = (Double)(DAARREARS + Convert.ToDouble(rdr["DAARREARS"]));
                inc_tax_other = inc_tax_other + Convert.ToDouble(rdr["INC_TAX"]);
            }
            con.Close();

            cmd = new SqlCommand("SELECT * FROM TESTING$ WHERE EMPNO=@EMPNO AND ((MONTH IN ('MAR','APR','MAY','JUN','JUL','AUG','SEP','OCT','NOV','DEC') AND YEAR=@YEAR1) OR (MONTH IN('JAN', 'FEB') AND YEAR = @YEAR2))", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@YEAR1", Request.QueryString["YEAR1"].ToString());
            cmd.Parameters.AddWithValue("@YEAR2", Request.QueryString["YEAR2"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            Double TESTING = 0;
            while (rdr.Read())
            {
                TESTING = (Double)(TESTING + Convert.ToDouble(rdr["TESTING"]));
                inc_tax_other = inc_tax_other + Convert.ToDouble(rdr["INC_TAX"]);
            }
            con.Close();


            cmd = new SqlCommand("SELECT * FROM SAVINGS$ WHERE EMPNO=@EMPNO AND SAVING_YEAR=@YEAR1", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@YEAR1", Request.QueryString["YEAR1"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            Double MEDICLAIM=0, HOUSELOANINTEREST = 0, NSC=0, INFRASTRUCTURE_BOND=0, PPF=0, NSC_INTEREST=0, TUTION_FEES=0, LIC_PREMIUM_PROD_PROOF=0, POSTAL_LIFE_INSURANCE=0, HOUSE_LOAN=0, OTHER_SAVINGS=0;
            Double SEC80CCG = 0, SEC80DDB = 0, SEC80GG = 0, SEC80GGC = 0, SEC80TTA = 0, SEC80U = 0, NPS=0;
            while (rdr.Read())
            {
                MEDICLAIM = (Double)(MEDICLAIM + Convert.ToDouble(rdr["MEDICLAIM"]));
                HOUSELOANINTEREST = (Double)(HOUSELOANINTEREST + Convert.ToDouble(rdr["INTONHOUSELOAN"]));
                NSC = (Double)(NSC + Convert.ToDouble(rdr["NSC"]));
                INFRASTRUCTURE_BOND = (Double)(INFRASTRUCTURE_BOND + Convert.ToDouble(rdr["MEP"]));
                PPF = (Double)(PPF + Convert.ToDouble(rdr["PUBLICPF"]));
                NSC_INTEREST = (Double)(NSC_INTEREST + Convert.ToDouble(rdr["INTONNSC"]));
                TUTION_FEES = (Double)(TUTION_FEES + Convert.ToDouble(rdr["TUTIONFEES"]));
                LIC_PREMIUM_PROD_PROOF = (Double)(LIC_PREMIUM_PROD_PROOF + Convert.ToDouble(rdr["LIC"]));
                POSTAL_LIFE_INSURANCE = (Double)(POSTAL_LIFE_INSURANCE + Convert.ToDouble(rdr["LIPOSTAL"]));
                HOUSE_LOAN = (Double)(HOUSE_LOAN + Convert.ToDouble(rdr["HOUSELOAN"]));
                OTHER_SAVINGS = (Double)(OTHER_SAVINGS + Convert.ToDouble(rdr["OTHERS"]));
                SEC80CCG = (Double)(SEC80CCG + Convert.ToDouble(rdr["SEC80CCG"]));
                SEC80DDB = (Double)(SEC80DDB + Convert.ToDouble(rdr["SEC80DDB"]));
                SEC80GG = (Double)(SEC80GG + Convert.ToDouble(rdr["SEC80GG"]));
                SEC80GGC = (Double)(SEC80GGC + Convert.ToDouble(rdr["SEC80GGC"]));
                SEC80TTA = (Double)(SEC80TTA + Convert.ToDouble(rdr["SEC80TTA"]));
                SEC80U = (Double)(SEC80U + Convert.ToDouble(rdr["SEC80U"]));
                NPS = (Double)(NPS + Convert.ToDouble(rdr["NPS"]));
            }
            con.Close();


            cmd = new SqlCommand("SELECT * FROM EMP_PROFILE$ WHERE EMPNO=@EMPNO", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            string GENDER="", AGEGROUP="";
            if (rdr.Read())
            {
                string gen= rdr["SEX"].ToString();
                if(gen.Equals("M"))
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
                if(age<=60)
                {
                    AGEGROUP = "NOT A SENIOR CITIZEN";
                }
                else
                {
                    AGEGROUP = "SENIOR CITIZEN";
                }
            }
            con.Close();


            EstimateTax.Tables[0].Rows.Add(row);
            EstimateTax.Tables[0].Rows[0]["BASIC"] = BASIC;
            EstimateTax.Tables[0].Rows[0]["DA"] = DA;
            EstimateTax.Tables[0].Rows[0]["HRA"] = HRA;
            EstimateTax.Tables[0].Rows[0]["CLA"] = CLA;
            EstimateTax.Tables[0].Rows[0]["MED_ALL"] = MED_ALL;
            EstimateTax.Tables[0].Rows[0]["EXAM_ALL"] = EXAM_ALL;
            EstimateTax.Tables[0].Rows[0]["ADHOC"] = ADHOC;
            EstimateTax.Tables[0].Rows[0]["DP"] = DP;
            EstimateTax.Tables[0].Rows[0]["SPEC_ALL"] = SPEC_ALL;
            EstimateTax.Tables[0].Rows[0]["LTC_ENCASH"] = LTC_ENCASHMENT;
            EstimateTax.Tables[0].Rows[0]["PTD_PGDCA"] = PTD;
            EstimateTax.Tables[0].Rows[0]["OTHER"] = OTHER_ALLOWANCE;
            EstimateTax.Tables[0].Rows[0]["DA_ARREAR"] = DAARREARS;
            EstimateTax.Tables[0].Rows[0]["TESTING"] = TESTING;
            EstimateTax.Tables[0].Rows[0]["ATRANSPORT"] = TRANSPORT;
            Double GROSS_TOTAL= BASIC + DA + HRA + CLA + MED_ALL + EXAM_ALL + ADHOC + DP + SPEC_ALL + LTC_ENCASHMENT + PTD + OTHER_ALLOWANCE + DAARREARS + TESTING + TRANSPORT;
            EstimateTax.Tables[0].Rows[0]["GROSS_TOTAL"] = GROSS_TOTAL;
            Double SEC10 = HOUSELOANINTEREST + MEDICLAIM + TRANSPORT;
            EstimateTax.Tables[0].Rows[0]["SEC10"] = SEC10;
            EstimateTax.Tables[0].Rows[0]["HOUSE_INT"] = HOUSELOANINTEREST;
            EstimateTax.Tables[0].Rows[0]["MEDICLAIM"] = MEDICLAIM;
            EstimateTax.Tables[0].Rows[0]["BTRANSPORT"] = TRANSPORT;
            Double C_BALANCE = GROSS_TOTAL - SEC10;
            EstimateTax.Tables[0].Rows[0]["BALANCE"] = C_BALANCE;

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
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (Convert.ToInt16(rdr["SLABNO"]) == 1)
                    {
                        //STANDARD_DED = Convert.ToDouble(rdr["UPPERBOUND"]);
                        //EstimateTax.Tables[0].Rows[0]["STANDARD_DED"] = STANDARD_DED;
                    }
                    EstimateTax.Tables[0].Rows[0]["INCOMETAXSLAB" + rdr["SLABNO"].ToString()] = "Rs." + rdr["LOWERBOUND"].ToString() + "/-" + " to " + rdr["UPPERBOUND"].ToString() + "/-";
                    EstimateTax.Tables[0].Rows[0]["TAX_RATE" + rdr["SLABNO"].ToString()] = rdr["PERCENTAGE"] + "%" + "+ EDU. CESS:" + rdr["EDU_CESS"] + " + HIGHER EDU. CESS:" + rdr["HIGHER_EDUCESS"];
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
                success = false;
                ErrorMessage = "Income Tax slab record for " + Request.QueryString["YEAR1"] + " Age-group :" + AGEGROUP + " Gender:" + GENDER + " does not Exists!!. Contact Admin";
            }
            
            EstimateTax.Tables[0].Rows[0]["STANDARD_DED"] = STANDARD_DED;
            con.Close();

            EstimateTax.Tables[0].Rows[0]["PROF_TAX"] = PROF_TAX;
            Double E_TOT_DED = STANDARD_DED + PROF_TAX;
            EstimateTax.Tables[0].Rows[0]["TOT_DED"] =E_TOT_DED;
            Double F_HEAD_SALARY = C_BALANCE-E_TOT_DED;
            if (F_HEAD_SALARY < 0) { F_HEAD_SALARY = 0; }
            EstimateTax.Tables[0].Rows[0]["F_HEAD_SALARY"] = F_HEAD_SALARY;
            Double H_TAXABLE_INCOME = F_HEAD_SALARY;                         //TAXABLE_INCOME=HEAD_SALARY-OTHER_INCOME
                                                                            //OTHER_INCOME SOURCE NOT KNOWN
            EstimateTax.Tables[0].Rows[0]["TAXABLE_INCOME"] = H_TAXABLE_INCOME;
            EstimateTax.Tables[0].Rows[0]["GPF_ARREARS"] = GPF_ARREARS;
            EstimateTax.Tables[0].Rows[0]["PF_CONTRIBUTORY"] = PF_CONTRIBUTORY;
            EstimateTax.Tables[0].Rows[0]["GPF"] = GPF;
            EstimateTax.Tables[0].Rows[0]["PF_NON_CONTRIBUTORY"] = PF_NON_CONTRIBUTORY;
            EstimateTax.Tables[0].Rows[0]["GROUP_INSURANCE"] = GROUP_INSURANCE;
            EstimateTax.Tables[0].Rows[0]["LIC_PREMIUM_SAL_BILL"] = LIC_PREMIUM_SAL_BILL;
            EstimateTax.Tables[0].Rows[0]["LIC_PREMIUM_PROD_PROOF"] = LIC_PREMIUM_PROD_PROOF;
            EstimateTax.Tables[0].Rows[0]["PONSC"] = NSC;
            EstimateTax.Tables[0].Rows[0]["POSTAL_LIFE_INSURANCE"] = POSTAL_LIFE_INSURANCE;
            EstimateTax.Tables[0].Rows[0]["INFRASTRUCTURE_BOND"] = INFRASTRUCTURE_BOND;
            EstimateTax.Tables[0].Rows[0]["PPF"] = PPF;
            EstimateTax.Tables[0].Rows[0]["HOUSE_LOAN"] = HOUSE_LOAN;
            EstimateTax.Tables[0].Rows[0]["NSC_INTEREST"] = NSC_INTEREST;
            EstimateTax.Tables[0].Rows[0]["TUTION_FEES"] = TUTION_FEES;
            EstimateTax.Tables[0].Rows[0]["OTHER_SAVINGS"] = OTHER_SAVINGS;
            EstimateTax.Tables[0].Rows[0]["SEC80CCG"] = SEC80CCG;
            EstimateTax.Tables[0].Rows[0]["SEC80DDB"] = SEC80DDB;
            EstimateTax.Tables[0].Rows[0]["SEC80GG"] = SEC80GG;
            EstimateTax.Tables[0].Rows[0]["SEC80GGC"] = SEC80GGC;
            EstimateTax.Tables[0].Rows[0]["SEC80TTA"] = SEC80TTA;
            EstimateTax.Tables[0].Rows[0]["SEC80U"] = SEC80U;
            EstimateTax.Tables[0].Rows[0]["NPS"] = NPS;
            Double TOT_SAVINGS = GPF_ARREARS + PF_CONTRIBUTORY + GPF + PF_NON_CONTRIBUTORY + GROUP_INSURANCE + LIC_PREMIUM_SAL_BILL + LIC_PREMIUM_PROD_PROOF + NSC + POSTAL_LIFE_INSURANCE + INFRASTRUCTURE_BOND + PPF + HOUSE_LOAN + NSC_INTEREST + TUTION_FEES + OTHER_SAVINGS + SEC80CCG + SEC80DDB + SEC80GG + SEC80GGC + SEC80TTA + SEC80U;
            EstimateTax.Tables[0].Rows[0]["TOT_SAVINGS"] = TOT_SAVINGS;

            Double I_TAX_REBATE = 0;
            //80c
            cmd = new SqlCommand("SELECT * FROM SECTIONS", con);
            con.Open();
            rdr = cmd.ExecuteReader();
            Int16 countRows = 0;
            String[] sec80CNames= new String[10];
            Double[] sec80CValues = new Double[10];
            Double sec80CTotalAmount = 0;
            while (rdr.Read())
            {
                countRows++;
                    sec80CNames[countRows-1] = (rdr["NAME"].ToString()).Replace(" ","");
            }
            con.Close();

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
                    secSavingsNames[countRows1-1] = (rdr["NAME"].ToString()).Replace(" ","");
                    secSavingsLimit[countRows1-1] = Convert.ToDouble(rdr["AMOUNT"]);
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
                while(count80C<3 && count80C<countRows)
                {
                    sec80CValues[count80C] = Convert.ToDouble(rdr["" + sec80CNames[count80C]]);
                    count80C++;
                }
                while(count80C>=3 && count80C<=(countRows-1))
                {
                    sec80CValues[3] = sec80CValues[3] + Convert.ToDouble(rdr["" + sec80CNames[count80C]]);
                    count80C++;
                }
                while(countSavings<(countRows1))
                {
                    Response.Write("<script>alert('countSavings:"+countSavings+" countRows1:"+countRows1+"');</script>");
                    secSavingsValues[countSavings] = Convert.ToDouble(rdr["" + secSavingsNames[countSavings]]);
                    if (secSavingsValues[countSavings] > secSavingsLimit[countSavings])
                    {
                        secSavingsValues[countSavings] = secSavingsLimit[countSavings];
                    }
                    countSavings++;
                }
            }
            con.Close();
            for(int i=5;i<countRows1;i++)
            {
                secSavingsValues[4] = secSavingsValues[4] + secSavingsValues[i];
            }
            for(int i=0;i<4;i++)
            {
                sec80CTotalAmount = sec80CTotalAmount + sec80CValues[i];
            }
            for(int i=0;i<5;i++)
            {
                TotalSavingsSections = TotalSavingsSections + secSavingsValues[i];
            }
            sec80CTotalAmount = sec80CTotalAmount + TOT_SAVINGS;

            cmd = new SqlCommand("SELECT * FROM SAVINGS_SECTIONS$ WHERE NAME='80C'", con);
            con.Open();
            rdr = cmd.ExecuteReader();
            Double SEC80C_LIMIT = 0;
            while (rdr.Read())
            {
                SEC80C_LIMIT = Convert.ToDouble(rdr["AMOUNT"]);
            }
            Response.Write("<script>alert('80C LIMIT:"+SEC80C_LIMIT+" SEC80C_TOTAL_AMOUNT:"+sec80CTotalAmount+"');</script>");
            con.Close();
            if (sec80CTotalAmount > SEC80C_LIMIT) { sec80CTotalAmount = SEC80C_LIMIT; }
            I_TAX_REBATE =  sec80CTotalAmount + TotalSavingsSections+NPS;
            Response.Write("<script>alert('I_TAX_REBATE: "+I_TAX_REBATE+" TotalSavingsSections :"+TotalSavingsSections+"');</script>");
            con.Close();
            if (countRows > 3)
            {
                sec80CNames[3] = "Other 80C savings";
            }
            if (countRows1 > 4)
            {
                secSavingsNames[4] = "Other Savings";
            }

            for(int i=1;i<=4 && i<(countRows+1);i++)
            {
                EstimateTax.Tables[0].Rows[0]["DataColumnName"+i] = sec80CNames[i-1];
                EstimateTax.Tables[0].Rows[0]["DataColumn" + i] = sec80CValues[i - 1];
            }
            for(int i=1;i<=5 && i<(countRows1+1);i++)
            {
                EstimateTax.Tables[0].Rows[0]["DataColumnName" + (i+4)] = secSavingsNames[i - 1];
                EstimateTax.Tables[0].Rows[0]["DataColumn" + (i+4)] = secSavingsValues[i - 1];
            }

            Double J_TOTAL_TAXABLE_INCOME = H_TAXABLE_INCOME - I_TAX_REBATE;
            if(J_TOTAL_TAXABLE_INCOME<0) { J_TOTAL_TAXABLE_INCOME = 0; }
            EstimateTax.Tables[0].Rows[0]["TOT_TAXABLE_INCOME"] = J_TOTAL_TAXABLE_INCOME;

            Double TAX_TO_PAY = 0;
            int slab1Count = 0, slab2Count = 0, slab3Count=0, slab4Count=0;
            for(int i=0;i<countIncomeTaxSlabs;i++)
            {
                if(IncomeTaxSlabNo[i]==1)
                {
                    slab1Count = i;
                }
                else if(IncomeTaxSlabNo[i]==2)
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

            if(J_TOTAL_TAXABLE_INCOME>IncomeTaxSlabLower[slab2Count])
            {
                Double new_income = 0;
                if(J_TOTAL_TAXABLE_INCOME<IncomeTaxSlabUpper[slab2Count])
                {
                    new_income = J_TOTAL_TAXABLE_INCOME - IncomeTaxSlabLower[slab2Count];
                }
                else
                {
                    new_income = IncomeTaxSlabUpper[slab2Count] - IncomeTaxSlabLower[slab2Count];
                }
                TAX_TO_PAY = TAX_TO_PAY + ((new_income * IncomeTaxSlabPercentage[slab2Count]) / 100);
                Response.Write("<script>alert('slab2:"+slab2Count+" upper:"+IncomeTaxSlabUpper[slab2Count]+" new_income:"+new_income+" percentage:"+IncomeTaxSlabPercentage[slab2Count]+" tax_to_pay:"+TAX_TO_PAY+"');</script>");
            }
            if (J_TOTAL_TAXABLE_INCOME > IncomeTaxSlabLower[slab3Count])
            {
                Double new_income = 0;
                if (J_TOTAL_TAXABLE_INCOME < IncomeTaxSlabUpper[slab3Count])
                {
                    new_income = J_TOTAL_TAXABLE_INCOME - IncomeTaxSlabLower[slab3Count];
                }
                else
                {
                    new_income = IncomeTaxSlabUpper[slab3Count] - IncomeTaxSlabLower[slab3Count];
                }
                TAX_TO_PAY = TAX_TO_PAY + ((new_income * IncomeTaxSlabPercentage[slab3Count]) / 100);
                Response.Write("<script>alert('slab3:" + slab3Count + " upper:" + IncomeTaxSlabUpper[slab3Count] + " new_income:" + new_income + " percentage:" + IncomeTaxSlabPercentage[slab3Count] + " tax_to_pay:" + TAX_TO_PAY + "');</script>");
            }
            if (J_TOTAL_TAXABLE_INCOME > IncomeTaxSlabLower[slab4Count])
            {
                Double new_income = 0;
                if (J_TOTAL_TAXABLE_INCOME < IncomeTaxSlabUpper[slab4Count])
                {
                    new_income = J_TOTAL_TAXABLE_INCOME - IncomeTaxSlabLower[slab4Count];
                }
                else
                {
                    new_income = IncomeTaxSlabUpper[slab4Count] - IncomeTaxSlabLower[slab4Count];
                }
                TAX_TO_PAY = TAX_TO_PAY + ((new_income * IncomeTaxSlabPercentage[slab4Count]) / 100);
                Response.Write("<script>alert('slab4:" + slab4Count + " upper:" + IncomeTaxSlabUpper[slab4Count] + " new_income:" + new_income + " percentage:" + IncomeTaxSlabPercentage[slab4Count] + " tax_to_pay:" + TAX_TO_PAY + "');</script>");
            }
            EstimateTax.Tables[0].Rows[0]["NET_TAX_TO_PAY"] = TAX_TO_PAY;
            Double EDU_CESS = (TAX_TO_PAY * IncomeTaxSlabEducess[0]) / 100;
            Double HIGHER_EDUCESS = (TAX_TO_PAY * IncomeTaxSlabHigherEducess[0]) / 100;
            EstimateTax.Tables[0].Rows[0]["EDU_CESS"] = EDU_CESS;
            EstimateTax.Tables[0].Rows[0]["MSH_EDU_CESS"] = HIGHER_EDUCESS;
            double TAX_SURCHARGE_EDU_CESS = TAX_TO_PAY + EDU_CESS + HIGHER_EDUCESS;
            EstimateTax.Tables[0].Rows[0]["TAX_SURCHARGE_EDU_CESS"] = TAX_SURCHARGE_EDU_CESS;
            EstimateTax.Tables[0].Rows[0]["TDS"] = INCOME_TAX_TDS;
            Double TAX_YET_TO_PAID = TAX_SURCHARGE_EDU_CESS-INCOME_TAX_TDS;
            EstimateTax.Tables[0].Rows[0]["TAX_YET_TO_PAID"] = TAX_YET_TO_PAID;
            EstimateTax.Tables[0].Rows[0]["STATEMENT_AS_ON"] = DateTime.Now.ToShortDateString();
            Response.Write("<script>alert('TAX_YET_TO_PAID:" + TAX_YET_TO_PAID + " months:"+months+"');</script>");
            if (months != 12) { months = 12 - months; }
            if (months != 0)
            {
                EstimateTax.Tables[0].Rows[0]["X_PER_MONTH"] = (TAX_YET_TO_PAID / months).ToString();
            }
            rd.SetDataSource(EstimateTax);

            //TextObject txtObj = (TextObject)rd.ReportDefinition.ReportObjects[60];
            //txtObj.Text = "Hello!";


            ParameterFieldDefinition pdf;
            ParameterFieldDefinitions pdfs;
            ParameterValues pvs = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            if (Session["User_Id"].ToString() != (100).ToString())
            {
                pdv.Value = Convert.ToInt16(Session["User_Id"]);
                pdfs = rd.DataDefinition.ParameterFields;
                pdf = pdfs["FacultyID"];
                pvs = pdf.CurrentValues;

                pvs.Clear();
                pvs.Add(pdv);
                pdf.ApplyCurrentValues(pvs);
            }

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

            //Department parameter
            pvs = new ParameterValues();
            pdv = new ParameterDiscreteValue();
            cmd = new SqlCommand("select DEPTNAME from DEPT_PROFILE$ where DEPTNO=(select DEPTNO from EMP_PROFILE$ where EMPNO=@EMPNO)", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            con.Open();
            string dept = cmd.ExecuteScalar().ToString();
            con.Close();
            pdv.Value = dept;
            pdfs = rd.DataDefinition.ParameterFields;
            pdf = pdfs["Department"];
            pvs = pdf.CurrentValues;
            pvs.Add(pdv);
            pdf.ApplyCurrentValues(pvs);
            //

            //Employee Name & designation parameter
            pvs = new ParameterValues();
            pdv = new ParameterDiscreteValue();
            cmd = new SqlCommand("select EMPNAME,DESIGNATION from EMP_PROFILE$ where EMPNO=@EMPNO", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            con.Open();
            SqlDataReader rr = cmd.ExecuteReader();
            string empname = "", designation = "";
            if(rr.Read())
            {
                empname = rr["EMPNAME"].ToString();
                designation = rr["DESIGNATION"].ToString();
            }
            con.Close();
            pdv.Value = empname;
            pdfs = rd.DataDefinition.ParameterFields;
            pdf = pdfs["EMPNAME"];
            pvs = pdf.CurrentValues;
            pvs.Add(pdv);
            pdf.ApplyCurrentValues(pvs);

            pvs = new ParameterValues();
            pdv = new ParameterDiscreteValue();
            pdv.Value = designation;
            pdfs = rd.DataDefinition.ParameterFields;
            pdf = pdfs["Designation"];
            pvs = pdf.CurrentValues;
            pvs.Add(pdv);
            pdf.ApplyCurrentValues(pvs);            //


            //CrystalReportViewer1.ReportSource = rd;
            if (success)
            {
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Estimate Report");
            }
            else
            {
                Response.Write("<script>alert('" + ErrorMessage + "');</script>");
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

        public Int16 ConvertToMonth(String month)
        {
            switch(month)
            {
                case "JAN": return 1; break;
                case "FEB": return 2; break;
                case "MAR": return 3; break;
                case "APR": return 4; break;
                case "MAY": return 5; break;
                case "JUN": return 6; break;
                case "JUL": return 7; break;
                case "AUG": return 8; break;
                case "SEP": return 9; break;
                case "OCT": return 10; break;
                case "NOV": return 11; break;
                case "DEC": return 12; break;
                default: return 0;
            }
        }
    }
}