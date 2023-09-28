using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.IO;
using Microsoft.Reporting.WebForms;
public partial class Depo_FinalDetailsreport : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction cmd = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string PrinterName, TitleName, DepoName;
            DataSet dsGSR = cmd.FillDatasetByProc("call USP_DPTFinalCounting(" + Session["UserID"] + ",'" + Convert.ToDateTime(Request.QueryString["Fromdate"], cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(Request.QueryString["Todate"], cult).ToString("yyyy-MM-dd") + "','" + Request.QueryString["ID"] + "')");
            PrinterName =Convert.ToString( dsGSR.Tables[0].Rows[0]["NameofPress_V"]);
            DepoName = Request.QueryString["DepoName"].ToString();
             //   Convert.ToString(dsGSR.Tables[0].Rows[0]["DepoName_V"]);
          //  DepoName_V
            ReportDataSource rds = new ReportDataSource();
          rds.Name = "DataSet1";
          rds.Value = dsGSR.Tables[0];
          TitleName = "शिक्षा सत्र "+ Request.QueryString["fyear"]+" के लिए  मुद्रणालय से प्राप्त पुस्तको की अंतिम गणना रसीद  ";
          ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/RptFinalReport.rdlc");
          ReportViewer1.LocalReport.DataSources.Clear();
          ReportViewer1.LocalReport.DataSources.Add(rds);

          ReportParameterCollection Param = new ReportParameterCollection();
          Param.Add(new ReportParameter("TitleName", TitleName));
          Param.Add(new ReportParameter("PrinterName", PrinterName));
          Param.Add(new ReportParameter("DepoName", DepoName));

          ReportViewer1.LocalReport.SetParameters(Param);
          ReportViewer1.LocalReport.EnableExternalImages = true;
          ReportViewer1.ShowPrintButton = true;
          ReportViewer1.LocalReport.Refresh();
        }
    }
}