﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace UniversityProject
{
    public partial class WebFormEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Reports/CrystalReport1.rpt"));

            ParameterFieldDefinition pdf;
            ParameterFieldDefinitions pdfs;
            ParameterValues pv = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            if(Session["User_Id"].ToString()!=(100).ToString())
            {
                pdv.Value = Convert.ToInt16(Session["User_Id"]);
                pdfs = rd.DataDefinition.ParameterFields;
                pdf = pdfs["FacultyID"];
                pv = pdf.CurrentValues;

                pv.Clear();
                pv.Add(pdv);
                pdf.ApplyCurrentValues(pv);
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
        }
    }
}