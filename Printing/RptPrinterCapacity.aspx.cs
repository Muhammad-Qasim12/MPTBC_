using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using MPTBCBussinessLayer;
using Microsoft.Reporting.WebForms;
public partial class Printing_RptPrinterCapacity : System.Web.UI.Page
{
    DataTable Dt; WorkOrderDetails obWorkOrderDetails = null;
    DataSet DS;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obCommonFuction = new CommonFuction();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Dt = obCommonFuction.FillTableByProc("call GetPrinterCapecityAll('"+DdlACYear.SelectedItem.Text+"') ");
        //Dt = obCommonFuction.FillTableByProc("call getlunlistbycompanytenderassmtfin("+ddlTenderID_I.SelectedValue+",'"+DdlACYear.SelectedItem.Text+"','test')");

        string Title = "";

        ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/PrinterCapecityReport.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportParameter[] Param = new ReportParameter[1];
        Param[0] = new ReportParameter("fyyear", DdlACYear.SelectedItem.Text);
        ReportViewer1.LocalReport.SetParameters(Param);
        // ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;
    }
}