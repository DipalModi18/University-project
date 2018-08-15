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
    public partial class WebFormSavings : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UniversityDatabaseConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count <= 0)
            {
                //if(Session["User_Id"].ToString()==(100).ToString())
                //{
                //    Response.Redirect("PopupSalaryAdmin.aspx");
                //}
                //else
                //{
                Response.Redirect("PopupSavings.aspx");
                //}
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Reports/crptSavings.rpt"));
            rd.VerifyDatabase();

            ParameterFieldDefinition pdf;
            ParameterFieldDefinitions pdfs;
            ParameterValues pvs = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            if (Session["User_Id"].ToString()!=(100).ToString())
            {
                pdv.Value = Convert.ToInt16(Session["User_Id"]);
                pdfs = rd.DataDefinition.ParameterFields;
                pdf = pdfs["FacultyID"];
                pvs = pdf.CurrentValues;

                pvs.Clear();
                pvs.Add(pdv);
                pdf.ApplyCurrentValues(pvs);
            }


            //
            pvs = new ParameterValues();
            pdv = new ParameterDiscreteValue();

            pdv.Value = Request.QueryString["SAVING_YEAR"];
            pdfs = rd.DataDefinition.ParameterFields;
            pdf = pdfs["Saving_Year"];
            pvs = pdf.CurrentValues;
            pvs.Add(pdv);
            pdf.ApplyCurrentValues(pvs);
            //

            //Setting Formula Field
            int temp = 0;
            String formula="";
            SqlCommand cmd = new SqlCommand("select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Savings$'", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                if (!(rdr.GetString(3) == "EMPNO" || rdr.GetString(3) == "SAVING_YEAR"))
                {
                    formula = formula + " ToNumber ({SAVINGS_." + rdr.GetString(3) + "})";
                    if (rdr.HasRows)
                    {
                        formula = formula + " + ";
                    }
                    temp++;
                }
            }
            formula = formula.Trim(new char[] { ' ','+'});
            con.Close();

            //Response.Write("<script>alert('FORMULA :" + formula + "')</script>");

            //formula= "ToNumber ({SAVINGS_.MEDICLAIM}) + ToNumber({SAVINGS_.HANDICAPPED})"+
            //    "+ ToNumber({ SAVINGS_.MEDICAL}) +ToNumber({ SAVINGS_.EDULOAN}) "+
            //    "+ToNumber({ SAVINGS_.DONATION}) +ToNumber({ SAVINGS_.PHDISABLED})"+
            //    "+ToNumber({ SAVINGS_.PUBLICPF}) +ToNumber({ SAVINGS_.HOUSELOAN})" +
            //    "+ToNumber({ SAVINGS_.INTONHOUSELOAN})+ToNumber({ SAVINGS_.INTONNSC})" +
            //    "+ToNumber({ SAVINGS_.NSS}) +ToNumber({ SAVINGS_.MUTUALFUNDS}) " +
            //    "+ToNumber({ SAVINGS_.EQUITYLINK}) +ToNumber({ SAVINGS_.TUTIONFEES})" +
            //    "+ToNumber({ SAVINGS_.NSC})+ToNumber({ SAVINGS_.LIC})" +
            //    "+ToNumber({ SAVINGS_.JEEVANSURAKSHA}) +ToNumber({ SAVINGS_.LIPOSTAL})" +
            //    "+ToNumber({ SAVINGS_.UNITLINK}) +ToNumber({ SAVINGS_.MEP})" +
            //    "+ToNumber({ SAVINGS_.INVSTINFRA}) +ToNumber({ SAVINGS_.OTHERS})";
            rd.DataDefinition.FormulaFields["TotalSavings"].Text = formula;
            //

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
        }

    }
}