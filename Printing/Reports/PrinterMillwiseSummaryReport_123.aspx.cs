using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer.Paper;
using MPTBCBussinessLayer;

public partial class CenterDepot_CenteralReport_PrinterMillwiseSummaryReport_123 : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt;
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    PPR_TenderEvaluation objTenderEvaluation = null;
    PPR_RDLCData objReports = new PPR_RDLCData();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PPR_PaperDispatchDetails objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            //ddlPrinter.DataSource = objPaperDispatchDetails.PrinterFill();//obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ReportPaperDispatchToPrinterByParam('" + DdlACYear.SelectedItem.Text + "','0','0','',1)"); //
            //ddlPrinter.DataTextField = "NameofPress_V";
            //ddlPrinter.DataValueField = "PrinterID_I";
            //ddlPrinter.DataBind();
            //ddlPrinter.Items.Insert(0, "Select");
            PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
            obPRI_PaperAllotment.Printer_RedID_I = 0;
            DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
            ////////
            // objPaperDispatchDetails = new PPR_PaperDispatchDetails();

            /*ddlPrinter.DataSource = ds.Tables[0];
            ddlPrinter.DataTextField = "NameofPressHindi_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";
            ddlPrinter.DataBind();
            ddlPrinter.Items.Insert(0, "Select");*/
            objTenderEvaluation = new PPR_TenderEvaluation();
            ddlPrinter.DataSource = objTenderEvaluation.VenderFill();
            ddlPrinter.DataTextField = "PaperVendorName_V";
            ddlPrinter.DataValueField = "PaperVendorTrId_I";
            ddlPrinter.DataBind();
            ddlPrinter.Items.Insert(0, "Select");

            DataTable ds1 = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + DdlACYear.SelectedItem.Text + "',0,-1)");
            ddlGSM.DataSource = ds1;
            ddlGSM.DataTextField = "CoverInformation";
            ddlGSM.DataValueField = "PaperMstrTrID_I";
            ddlGSM.DataBind();
            ddlGSM.Items.Insert(0, "Select");
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlPrinter.SelectedIndex > 0)
        {
            Dt = new DataTable();
            // Dt = objReports.MonthPublishCoverAllotMent(ddlYear.SelectedItem.Text);

            if (ddlGSM.SelectedValue == "27" || ddlGSM.SelectedValue == "42") 
            Dt = obCommonFuction.FillTableByProc("call USP_PaperIN_OUT_Summary(" + ddlPrinter.SelectedValue + ",'" + DdlACYear.SelectedValue + "','2019-11-01','2019-06-30', " + ddlGSM.SelectedValue + ")");
            else
                Dt = obCommonFuction.FillTableByProc("call USP_PaperIN_OUT_Summary_sheet(" + ddlPrinter.SelectedValue + ",'" + DdlACYear.SelectedValue + "','2019-11-01','2019-06-30', " + ddlGSM.SelectedValue + ")");


            if (Dt.Rows.Count > 0)
            {
                trRV.Visible = true;
                ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
                // ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/CenteralReport/report.rdlc");
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("PrinterMillwiseSummaryReport_123.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                // ReportViewer1.LocalReport.EnableExternalImages = true;
                string mill;
                mill = ddlPrinter.SelectedItem.Text + " \t  " + ddlGSM.SelectedItem.Text;
               // mill = ddlPrinter.SelectedItem.Text ;

                ReportParameter[] Param = new ReportParameter[2];
                Param[0] = new ReportParameter("PrinterName", mill);
                Param[1] = new ReportParameter("ACYear", DdlACYear.SelectedItem.Text);
                //Param[1] = new ReportParameter("Date", System.DateTime.Now.ToString("dd/MM/yyyy"));
                ReportViewer1.LocalReport.SetParameters(Param);

                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.Visible = true;
            }
            else
            {
                trRV.Visible = false;
            }
        }
    }
    protected void ddlGSM_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}