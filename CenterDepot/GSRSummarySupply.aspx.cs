
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

public partial class GSRSummarySupply : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            fillParameters();
            BindPrinterDDL();
        }
    }

    public void BindPrinterDDL()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
        ////////
        // objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ddlPrinter.DataSource = ds.Tables[0];
        ddlPrinter.DataTextField = "NameofPressHindi_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, new ListItem("All", "0"));
    }

    private void LoadReport(string year, int mPrinterId)
    {
        //string finYr = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        string finYr = year;
        //Dt = obCommonFuction.FillTableByProc("Call USP_PRI012_PrinterOrderDtlChild('" + "" + "','" + "" + "','" + "" + "',6,'" + finYr + "')");
        Dt = obCommonFuction.FillTableByProc("Call USP_PPR0014_PaperDispatchToPrinterCDSearchNewGSR_Rpt('"+finYr+ "','"+mPrinterId+"','')");
        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/GSRSummarySupply.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", finYr);
            string Title = "";
            Title = "मुद्रक: " + ddlPrinter.SelectedItem.Text.ToString().Replace("All", "सभी");
            Param[1] = new ReportParameter("Class", Title);
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
    private void fillParameters()
    {
        CommonFuction comm = new CommonFuction();
        DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        DdlACYear.DataValueField = "AcYear";
        DdlACYear.DataTextField = "AcYear";
        DdlACYear.DataBind();
                
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //LoadReport(DdlACYear.SelectedItem.Text, Int32.Parse(DdlClass.SelectedValue), 
        //    Int32.Parse(ddlMedium.SelectedValue), Int32.Parse(ddlTital.SelectedValue),
        //    Int32.Parse(ddlPrinter.SelectedValue));

        LoadReport(DdlACYear.SelectedItem.Text, Int32.Parse(ddlPrinter.SelectedValue));
    }
}