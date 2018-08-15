using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityProject
{
    public partial class Temp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int iMonthNo = Convert.ToDateTime("01-" + "DEC" + "-2011").Month;
            Label1.Text = iMonthNo.ToString();
        }
    }
}