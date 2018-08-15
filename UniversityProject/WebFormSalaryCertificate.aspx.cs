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
    public partial class WebFormSalaryCertificate : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("PopupSalaryCertificate.aspx");
            }

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Reports/crptSalaryCertificate.rpt"));

            dsSalaryCertificate SalaryCertificate = new dsSalaryCertificate();
            for (int i = 7; i <= 30; i++)
            {
                SalaryCertificate.Tables[0].Columns[i].DataType = typeof(Double);
                //String c = SalaryCertificate.Tables[0].Columns[i].ColumnName;
                //Response.Write("<script>alert('Column  :" + i + " is " + c + "');</script>");
            }

            cmd = new SqlCommand("SELECT * FROM EMP_PROFILE$ WHERE EMPNO=@EMPNO", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            String EMPNAME = "", DESIGNATION = "";
            Int16 DEPTNO = 0;
            while (rdr.Read())
            {
                EMPNAME = rdr["EMPNAME"].ToString();
                DESIGNATION = rdr["DESIGNATION"].ToString();
                DEPTNO = Convert.ToInt16(rdr["DEPTNO"]);
            }
            con.Close();

            cmd = new SqlCommand("SELECT * FROM DEPT_PROFILE$ WHERE DEPTNO=@DEPTNO", con);
            cmd.Parameters.AddWithValue("@DEPTNO", DEPTNO);
            con.Open();
            rdr = cmd.ExecuteReader();
            String DEPTNAME = "";
            Int16 FACID = 0;
            while (rdr.Read())
            {
                DEPTNAME = rdr["DEPTNAME"].ToString();
                FACID = Convert.ToInt16(rdr["FACID"]);
            }
            con.Close();


            cmd = new SqlCommand("SELECT * FROM FACULTY_PROFILE$ WHERE FACID=@FACID", con);
            cmd.Parameters.AddWithValue("@FACID", FACID);
            con.Open();
            rdr = cmd.ExecuteReader();
            String FACNAME = "";
            while (rdr.Read())
            {
                FACNAME = rdr["FACNAME"].ToString();
            }
            con.Close();

            //String TodayDate = DateTime.Now.Date + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            DateTime TODAY_DATE = DateTime.Now;
            String format = "dd-MMMM-yyyy";
            String DATE = TODAY_DATE.ToString(format);


            cmd = new SqlCommand("SELECT * FROM PAY_SLIP$ WHERE EMPNO=@EMPNO AND ((MONTH IN ('MAR','APR','MAY','JUN','JUL','AUG','SEP','OCT','NOV','DEC') AND YEAR=@YEAR1) OR (MONTH IN('JAN', 'FEB') AND YEAR = @YEAR2))", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@YEAR1", Request.QueryString["YEAR1"].ToString());
            cmd.Parameters.AddWithValue("@YEAR2", Request.QueryString["YEAR2"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();

            
            //DataSet ds;
            Double BASIC = 0, DA = 0, HRA = 0, CLA = 0, MED_ALL = 0, EXAM_ALL = 0, DP = 0, SPEC_ALL = 0, TRANSPORT=0, GROUP_INSURANCE=0; // TRANSPORT=CONVEYANCE ALLOWANCE
            Double PROF_TAX = 0, INCOME_TAX_TDS = 0, PF_CONTRIBUTORY = 0, PF_NON_CONTRIBUTORY = 0;
            double GPF_ARREARS = 0, GPF = 0, LIC_PREMIUM_SAL_BILL = 0, DED_OTHER=0, RECOVERY=0; // DON'T KNOW EXACTLY WHAT TO DO WITH RECOVERY
            while (rdr.Read())
            {
                BASIC = (Double)(BASIC + Convert.ToDouble(rdr["BASIC"]));
                DA = (Double)(DA + Convert.ToDouble(rdr["DA"]));
                HRA = (Double)(HRA + Convert.ToDouble(rdr["HRA"]));
                CLA = (Double)(CLA + Convert.ToDouble(rdr["CLA"]));
                MED_ALL = (Double)(MED_ALL + Convert.ToDouble(rdr["MED_ALL"]));
                EXAM_ALL = (Double)(EXAM_ALL + Convert.ToDouble(rdr["EXAM_ALL"]));
                DP = (Double)(DP + Convert.ToDouble(rdr["DP"]));
                SPEC_ALL = (Double)(SPEC_ALL + Convert.ToDouble(rdr["SPEC_ALL"]));
                TRANSPORT = (Double)(TRANSPORT + Convert.ToDouble(rdr["CONVEY_ALL"]));
                GROUP_INSURANCE = (Double)(GROUP_INSURANCE + Convert.ToDouble(rdr["GROP_INS"]));
                GPF_ARREARS = (Double)(GPF_ARREARS + Convert.ToDouble(rdr["GPF_ARR"]));
                LIC_PREMIUM_SAL_BILL = (Double)(LIC_PREMIUM_SAL_BILL + Convert.ToDouble(rdr["LIC"]));
                GPF = (Double)(GPF + Convert.ToDouble(rdr["GPF"]));
                PROF_TAX = (Double)(PROF_TAX + Convert.ToDouble(rdr["PROF_TAX"]));
                INCOME_TAX_TDS = (Double)(INCOME_TAX_TDS + Convert.ToDouble(rdr["INC_TAX"]));
                PF_CONTRIBUTORY = (Double)(PF_CONTRIBUTORY + Convert.ToDouble(rdr["DED_UCPF"]));
                PF_NON_CONTRIBUTORY = (Double)(PF_NON_CONTRIBUTORY + Convert.ToDouble(rdr["PF"]));
                DED_OTHER = (Double)(DED_OTHER + Convert.ToDouble(rdr["DED_OTHER"]));
            }
            con.Close();


            Double OTHER_INCOME=0;
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
                INCOME_TAX_TDS = INCOME_TAX_TDS + Convert.ToDouble(rdr["INC_TAX"]);
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
                INCOME_TAX_TDS = INCOME_TAX_TDS + Convert.ToDouble(rdr["INC_TAX"]);
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
                INCOME_TAX_TDS = INCOME_TAX_TDS + Convert.ToDouble(rdr["INC_TAX"]);
            }
            con.Close();

            cmd = new SqlCommand("SELECT * FROM EXAMREMUNERATION$ WHERE EMPNO=@EMPNO AND ((MONTH IN ('MAR','APR','MAY','JUN','JUL','AUG','SEP','OCT','NOV','DEC') AND YEAR=@YEAR1) OR (MONTH IN('JAN', 'FEB') AND YEAR = @YEAR2))", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@YEAR1", Request.QueryString["YEAR1"].ToString());
            cmd.Parameters.AddWithValue("@YEAR2", Request.QueryString["YEAR2"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            Double EXAM_REMUNERAION = 0;
            while (rdr.Read())
            {
                EXAM_REMUNERAION = (Double)(TESTING + Convert.ToDouble(rdr["EXAM_RMN"]));
                INCOME_TAX_TDS = INCOME_TAX_TDS + Convert.ToDouble(rdr["INC_TAX"]);
            }
            con.Close();

            DataRow row = SalaryCertificate.Tables[0].NewRow();
            SalaryCertificate.Tables[0].Rows.Add(row);
            SalaryCertificate.Tables[0].Rows[0]["EMPNO"] = Request.QueryString["EMPNO"];
            SalaryCertificate.Tables[0].Rows[0]["EMPNAME"] = EMPNAME;
            SalaryCertificate.Tables[0].Rows[0]["DESIGNATION"] = DESIGNATION;
            SalaryCertificate.Tables[0].Rows[0]["DEPARTMENT"] = DEPTNAME;
            SalaryCertificate.Tables[0].Rows[0]["DATE"] = DATE;
            SalaryCertificate.Tables[0].Rows[0]["YEAR1"] = Request.QueryString["YEAR1"];
            SalaryCertificate.Tables[0].Rows[0]["YEAR2"] = Request.QueryString["YEAR2"];
            SalaryCertificate.Tables[0].Rows[0]["EAR_SALARY"] = BASIC;
            SalaryCertificate.Tables[0].Rows[0]["EAR_DA"] = DA;
            SalaryCertificate.Tables[0].Rows[0]["EAR_HRA"] = HRA;
            SalaryCertificate.Tables[0].Rows[0]["EAR_CLA"] = CLA;
            SalaryCertificate.Tables[0].Rows[0]["EAR_MA"] = MED_ALL ;
            SalaryCertificate.Tables[0].Rows[0]["EAR_SPEC_ALLOWANCE"] = SPEC_ALL;
            SalaryCertificate.Tables[0].Rows[0]["EAR_PTD"] = PTD;
            SalaryCertificate.Tables[0].Rows[0]["EAR_EXAM_REMUNERATION"] = EXAM_REMUNERAION;
            SalaryCertificate.Tables[0].Rows[0]["EAR_DA_ARREAR"] = DAARREARS;
            SalaryCertificate.Tables[0].Rows[0]["EAR_TESTING"] = TESTING;
            SalaryCertificate.Tables[0].Rows[0]["EAR_OTHER_INCOME"] = OTHER_INCOME;
            SalaryCertificate.Tables[0].Rows[0]["EAR_DP"] = DP;
            SalaryCertificate.Tables[0].Rows[0]["EAR_CONVEYANCE"] = TRANSPORT;
            SalaryCertificate.Tables[0].Rows[0]["DED_GPF"] = GPF;
            SalaryCertificate.Tables[0].Rows[0]["DED_GPF_ARR"] = GPF_ARREARS;
            SalaryCertificate.Tables[0].Rows[0]["DED_NON_CONTRI_PF"] = PF_NON_CONTRIBUTORY;
            SalaryCertificate.Tables[0].Rows[0]["DED_PF_CONTRI"] = PF_CONTRIBUTORY;
            SalaryCertificate.Tables[0].Rows[0]["DED_PT"] = PROF_TAX;
            SalaryCertificate.Tables[0].Rows[0]["DED_GI"] = GROUP_INSURANCE;
            SalaryCertificate.Tables[0].Rows[0]["DED_INCOME_TAX"] = INCOME_TAX_TDS;
            SalaryCertificate.Tables[0].Rows[0]["DED_LIC"] = LIC_PREMIUM_SAL_BILL;
            SalaryCertificate.Tables[0].Rows[0]["DED_OTHERS"] = DED_OTHER;
            SalaryCertificate.Tables[0].Rows[0]["DED_RECOVERY"] = 0;
            Double GROSS_TOTAL = BASIC + DA + HRA + CLA + MED_ALL + SPEC_ALL + PTD + EXAM_REMUNERAION + DAARREARS + TESTING + OTHER_INCOME + DP + TRANSPORT;
            SalaryCertificate.Tables[0].Rows[0]["GROSS_TOTAL"] = GROSS_TOTAL;
            SalaryCertificate.Tables[0].Rows[0]["FACULTY_NAME"] = FACNAME;
            rd.SetDataSource(SalaryCertificate);


            cmd = new SqlCommand("SELECT * FROM SALARY_CERTI$ WHERE EMPNO=@EMPNO AND SYEAR=@SYEAR", con);
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"].ToString());
            cmd.Parameters.AddWithValue("@SYEAR", Request.QueryString["YEAR1"].ToString());
            con.Open();
            rdr = cmd.ExecuteReader();
            Boolean recordExists = false;
            while (rdr.Read())
            {
                recordExists = true;
            }
            con.Close();

            if(recordExists)
            {
                cmd=new SqlCommand("UPDATE SALARY_CERTI$ SET DESIGNATION=@DESIGNATION, SALARY=@SALARY, DA=@DA, HRA=@HRA, CLA=@CLA, MA=@MA, SPA=@SPA, PTD=@PTD, EXAMREM=@EXAMREM, DAARR=@DAARR, TESTING=@TESTING, OTHERINCOME=@OTHERINCOME, GPF=@GPF, GPFARR=@GPFARR, NCPF=@NCPF, CPF=@CPF, PT=@PT, GI=@GI, IT=@IT, LIC=@LIC, OTHERS=@OTHERS, GROSSTOTAL=@GROSSTOTAL, DP=@DP, CONVEY_ALL=@CONVEY_ALL, RECOVERY=@RECOVERY WHERE EMPNO=@EMPNO AND SYEAR=@SYEAR", con);
            }
            else
            {
                cmd = new SqlCommand("INSERT INTO SALARY_CERTI$ VALUES(@EMPNO, @DESIGNATION, @EMPNAME, @DEPTNAME, @SALARY, @DA, @HRA, @CLA, @MA, @SPA, @PTD, @EXAMREM, @DAARR, @TESTING, @OTHERINCOME, @GPF, @GPFARR, @NCPF, @CPF, @PT, @GI, @IT, @LIC, @OTHERS, @GROSSTOTAL, @SYEAR, @DP, @CONVEY_ALL, @RECOVERY)", con);
            }
            
            cmd.Parameters.AddWithValue("@EMPNO", Request.QueryString["EMPNO"]);
            cmd.Parameters.AddWithValue("@DESIGNATION", DESIGNATION);
            cmd.Parameters.AddWithValue("@EMPNAME", EMPNAME);
            cmd.Parameters.AddWithValue("@DEPTNAME", DEPTNAME);
            cmd.Parameters.AddWithValue("@SALARY", BASIC);
            cmd.Parameters.AddWithValue("@DA", DA);
            cmd.Parameters.AddWithValue("@HRA", HRA);
            cmd.Parameters.AddWithValue("@CLA", CLA);
            cmd.Parameters.AddWithValue("@MA", MED_ALL);
            cmd.Parameters.AddWithValue("@SPA", SPEC_ALL);
            cmd.Parameters.AddWithValue("@PTD", PTD);
            cmd.Parameters.AddWithValue("@EXAMREM", EXAM_REMUNERAION);
            cmd.Parameters.AddWithValue("@DAARR", DAARREARS);
            cmd.Parameters.AddWithValue("@TESTING", TESTING);
            cmd.Parameters.AddWithValue("@OTHERINCOME", OTHER_INCOME);
            cmd.Parameters.AddWithValue("@GPF", GPF);
            cmd.Parameters.AddWithValue("@GPFARR", GPF_ARREARS);
            cmd.Parameters.AddWithValue("@NCPF", PF_NON_CONTRIBUTORY);
            cmd.Parameters.AddWithValue("@CPF", PF_CONTRIBUTORY);
            cmd.Parameters.AddWithValue("@PT", PROF_TAX);
            cmd.Parameters.AddWithValue("@GI", GROUP_INSURANCE);
            cmd.Parameters.AddWithValue("@IT", INCOME_TAX_TDS);
            cmd.Parameters.AddWithValue("@LIC", LIC_PREMIUM_SAL_BILL);
            cmd.Parameters.AddWithValue("@OTHERS", DED_OTHER);
            cmd.Parameters.AddWithValue("@GROSSTOTAL", GROSS_TOTAL);
            cmd.Parameters.AddWithValue("@SYEAR", Request.QueryString["YEAR1"]);
            cmd.Parameters.AddWithValue("@DP", DP);
            cmd.Parameters.AddWithValue("@CONVEY_ALL", TRANSPORT);
            cmd.Parameters.AddWithValue("@RECOVERY", RECOVERY);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            ParameterFieldDefinition pdf;
            ParameterFieldDefinitions pdfs;
            ParameterValues pvs = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            //if (Session["User_Id"].ToString() != (100).ToString())
            //{
            //    pdv.Value = Convert.ToInt16(Session["User_Id"]);
            //    pdfs = rd.DataDefinition.ParameterFields;
            //    pdf = pdfs["FacultyID"];
            //    pvs = pdf.CurrentValues;

            //    pvs.Clear();
            //    pvs.Add(pdv);
            //    pdf.ApplyCurrentValues(pvs);
            //}

            //Empno parameter
            pvs = new ParameterValues();
            pdv = new ParameterDiscreteValue();

            pdv.Value = Convert.ToInt16(Request.QueryString["EMPNO"]);
            pdfs = rd.DataDefinition.ParameterFields;
            pdf = pdfs["EmployeeID"];
            pvs = pdf.CurrentValues;
            pvs.Add(pdv);
            pdf.ApplyCurrentValues(pvs);
            //

            //Year1 parameter
            pvs = new ParameterValues();
            pdv = new ParameterDiscreteValue();

            pdv.Value = Convert.ToInt16(Request.QueryString["YEAR1"]);
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

            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Salary Certificate");
        }
    }
}