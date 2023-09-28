
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using Microsoft.Reporting.WebForms;

public partial class Printing_Reports_PrinterReportTitleWise : System.Web.UI.Page
{
    DataTable Dt;
    DataSet ds;
    PRIN_PrinterBooksPrintingDetails obj = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    string CntrDepot_Id = "";
    double TotNet = 0, TotGrossWt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        string finYr=obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        Dt = obCommonFuction.FillTableByProc("Call USP_PRI012_PrinterOrderDtlChild('" + "" + "','" + "" + "','" + "" + "',5,'" + finYr + "')");

        if (Dt.Rows.Count > 0)
        {
            string Title = "";
            
            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportPrinterReportTitleWise.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", finYr);
            Param[1] = new ReportParameter("Title", Title);
            ReportViewer1.LocalReport.SetParameters(Param);
            // ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
        }
        else
        {
            ReportViewer1.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
            // GridView1.DataSource = null;
            // GridView1.DataBind();
        }

    }
}