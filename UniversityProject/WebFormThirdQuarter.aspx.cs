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

namespace UniversityProject
{
    public partial class WebFormThirdQuarter : System.Web.UI.Page
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

            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Reports/thirdquarter.rpt"));


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


            CrystalReportViewer1.ReportSource = rd;
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


            if (Session["User_Id"].ToString() != (100).ToString())
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                    SqlCommand cmd = new SqlCommand("delete from THIRDQUARTER$ where FACID=@FACID", con);
                    cmd.Parameters.AddWithValue("@FACID", Session["User_Id"].ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ToString());
                    SqlCommand cmd1;
                    SqlDataReader rdr1;
                    //select emp.EMPNO, emp.EMPNAME, SUM(CONVERT(decimal(10,4),pay.BASIC)) from EMP_PROFILE$ emp, PAY_SLIP$ pay where emp.EMPNO=pay.EMPNO and pay.MONTH in ('APR','MAY','JUN') and pay.YEAR=2016 GROUP BY emp.EMPNO,emp.EMPNAME
                    cmd = new SqlCommand("select emp.EMPNO, emp.FACID, emp.EMPNAME, emp.DESIGNATION, SUM(CONVERT(decimal(10,2),pay.BASIC)) as BASIC, SUM(CONVERT(decimal(10,4),pay.DA)) as DA, SUM(CONVERT(decimal(10,4),pay.HRA)) as HRA, SUM(CONVERT(decimal(10,4),pay.CLA)) as CLA,SUM(CONVERT(decimal(10,4),pay.EAR_UCPF)) as EAR_UCPF, SUM(CONVERT(decimal(10,4),pay.CONVEY_ALL)) as CONVEY_ALL, SUM(CONVERT(decimal(10,4),pay.WASH_ALL)) as WASH_ALL, SUM(CONVERT(decimal(10,4),pay.SPEC_ALL)) as SPEC_ALL, SUM(CONVERT(decimal(10,4),pay.MED_ALL)) as MED_ALL, SUM(CONVERT(decimal(10,4),pay.PF)) as PF, SUM(CONVERT(decimal(10,4),pay.DED_UCPF)) as DED_UCPF, SUM(CONVERT(decimal(10,4),pay.GPF)) as GPF, SUM(CONVERT(decimal(10,4),pay.LIC)) as LIC, SUM(CONVERT(decimal(10,4),pay.PROF_TAX)) as PROF_TAX, SUM(CONVERT(decimal(10,4),pay.GPF_ARR)) as GPF_ARR, SUM(CONVERT(decimal(10,4),pay.INC_TAX)) as INC_TAX, SUM(CONVERT(decimal(10,4),pay.GROP_INS)) as GROP_INS, SUM(CONVERT(decimal(10,4),pay.DP)) as DP, SUM(CONVERT(decimal(10,4),PF)) as PF from EMP_PROFILE$ emp, PAY_SLIP$ pay where emp.EMPNO=pay.EMPNO and pay.MONTH in ('OCT','NOV','DEC') and pay.YEAR=@YEAR and emp.FACID=@FACID GROUP BY emp.EMPNO,emp.EMPNAME, emp.FACID,emp.DESIGNATION", con);
                    cmd.Parameters.AddWithValue("@YEAR", DateTime.Now.Year);
                    cmd.Parameters.AddWithValue("@FACID", Session["User_Id"].ToString());
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        String EMPNO = rdr["EMPNO"].ToString();
                        cmd1 = new SqlCommand("select SUM(CONVERT(decimal(10,4),NET_DAARREARS)) as DA_ARR, SUM(CONVERT(decimal(10,4),INC_TAX)) as INC_TAX from DAARREARS$ where EMPNO=@EMPNO and YEAR=@YEAR and MONTH in ('OCT','NOV','DEC')", con1);
                        cmd1.Parameters.AddWithValue("@EMPNO", EMPNO);
                        cmd1.Parameters.AddWithValue("@YEAR", DateTime.Now.Year);
                        con1.Open();
                        rdr1 = cmd1.ExecuteReader();
                        String DA_ARR = "0";
                        String DAARREAR_INC_TAX = "0";
                        while (rdr1.Read())
                        {
                            DA_ARR = rdr1["DA_ARR"].ToString();
                            DAARREAR_INC_TAX = rdr1["INC_TAX"].ToString();
                        }
                        con1.Close();

                        cmd1 = new SqlCommand("select SUM(CONVERT(decimal(10,4),NET_PTD)) as PTD, SUM(CONVERT(decimal(10,4),INC_TAX)) as INC_TAX from PTD$ where EMPNO=@EMPNO and YEAR=@YEAR and MONTH in ('OCT','NOV','DEC')", con1);
                        cmd1.Parameters.AddWithValue("@EMPNO", EMPNO);
                        cmd1.Parameters.AddWithValue("@YEAR", DateTime.Now.Year);
                        con1.Open();
                        rdr1 = cmd1.ExecuteReader();
                        String PTD = "0";
                        String PTD_INC_TAX = "0";
                        while (rdr1.Read())
                        {
                            PTD = rdr1["PTD"].ToString();
                            PTD_INC_TAX = rdr1["INC_TAX"].ToString();
                        }
                        con1.Close();


                        cmd1 = new SqlCommand("select SUM(CONVERT(decimal(10,4),NET_EXAMRMN)) as EXAMRMN, SUM(CONVERT(decimal(10,4),INC_TAX)) as INC_TAX from EXAMREMUNERATION$ where EMPNO=@EMPNO and YEAR=@YEAR and MONTH in ('OCT','NOV','DEC')", con1);
                        cmd1.Parameters.AddWithValue("@EMPNO", EMPNO);
                        cmd1.Parameters.AddWithValue("@YEAR", DateTime.Now.Year);
                        con1.Open();
                        rdr1 = cmd1.ExecuteReader();
                        String EXAMRMN = "0";
                        String EXAMRMN_INC_TAX = "0";
                        while (rdr1.Read())
                        {
                            EXAMRMN = rdr1["EXAMRMN"].ToString();
                            EXAMRMN_INC_TAX = rdr1["INC_TAX"].ToString();
                        }
                        con1.Close();


                        cmd1 = new SqlCommand("select SUM(CONVERT(decimal(10,4),NET_TESTING)) as TESTING, SUM(CONVERT(decimal(10,4),INC_TAX)) as INC_TAX from TESTING$ where EMPNO=@EMPNO and YEAR=@YEAR and MONTH in ('OCT','NOV','DEC')", con1);
                        cmd1.Parameters.AddWithValue("@EMPNO", EMPNO);
                        cmd1.Parameters.AddWithValue("@YEAR", DateTime.Now.Year);
                        con1.Open();
                        rdr1 = cmd1.ExecuteReader();
                        String TESTING = "0";
                        String TESTING_INC_TAX = "0";
                        while (rdr1.Read())
                        {
                            TESTING = rdr1["TESTING"].ToString();
                            TESTING_INC_TAX = rdr1["INC_TAX"].ToString();
                        }
                        con1.Close();

                        cmd1 = new SqlCommand("insert into THIRDQUARTER$ values(@EMPNO, @FACID, @EMPNAME, @DESIGNATION, @BASIC, @DA, @HRA, @CLA, @EAR_UCPF, @CON_ALL, @WASH_ALL, @SP_ALL, @MED_ALL, @DP, @PTD, @TESTING, @EXAM_RMN, @DA_ARR, @PF, @DED_UCPF, @GPF, @LIC, @PT, @GPF_ARR, @INC_TAX, @GROP_INS)", con1);
                        cmd1.Parameters.AddWithValue("@EMPNO", EMPNO);
                        cmd1.Parameters.AddWithValue("@FACID", Session["User_Id"].ToString());
                        cmd1.Parameters.AddWithValue("@EMPNAME", rdr["EMPNAME"].ToString());
                        cmd1.Parameters.AddWithValue("@DESIGNATION", rdr["DESIGNATION"].ToString());
                        cmd1.Parameters.AddWithValue("@BASIC", rdr["BASIC"].ToString());
                        cmd1.Parameters.AddWithValue("@DA", rdr["DA"].ToString());
                        cmd1.Parameters.AddWithValue("@HRA", rdr["HRA"].ToString());
                        cmd1.Parameters.AddWithValue("@CLA", rdr["CLA"].ToString());
                        cmd1.Parameters.AddWithValue("@EAR_UCPF", rdr["EAR_UCPF"].ToString());
                        cmd1.Parameters.AddWithValue("@CON_ALL", rdr["CONVEY_ALL"].ToString());
                        cmd1.Parameters.AddWithValue("@WASH_ALL", rdr["WASH_ALL"].ToString());
                        cmd1.Parameters.AddWithValue("@SP_ALL", rdr["SPEC_ALL"].ToString());
                        cmd1.Parameters.AddWithValue("@MED_ALL", rdr["MED_ALL"].ToString());
                        cmd1.Parameters.AddWithValue("@DP", rdr["DP"].ToString());
                        cmd1.Parameters.AddWithValue("@PTD", PTD);
                        cmd1.Parameters.AddWithValue("@TESTING", "0");
                        cmd1.Parameters.AddWithValue("@EXAM_RMN", EXAMRMN);
                        cmd1.Parameters.AddWithValue("@DA_ARR", DA_ARR);
                        cmd1.Parameters.AddWithValue("@PF", rdr["PF"].ToString());
                        cmd1.Parameters.AddWithValue("@DED_UCPF", rdr["DED_UCPF"].ToString());
                        cmd1.Parameters.AddWithValue("@GPF", rdr["GPF"].ToString());
                        cmd1.Parameters.AddWithValue("@LIC", rdr["LIC"].ToString());
                        cmd1.Parameters.AddWithValue("@PT", rdr["PROF_TAX"].ToString());
                        cmd1.Parameters.AddWithValue("@GPF_ARR", rdr["GPF_ARR"].ToString());
                        cmd1.Parameters.AddWithValue("@INC_TAX", rdr["INC_TAX"].ToString());
                        cmd1.Parameters.AddWithValue("@GROP_INS", rdr["GROP_INS"].ToString());

                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        con1.Close();
                    }
                    con.Close();
                }
                catch (Exception ee)
                {
                    Response.Write("<script>alert('Error While Generating Third Quarter Report!!');</script>");
                    Response.Write("<script language='javascript'>window.location='HomePage.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Must Login Through a Faculty!!');</script>");
                Response.Write("<script language='javascript'>window.location='HomePage.aspx';</script>");
            }

        }


    }
}