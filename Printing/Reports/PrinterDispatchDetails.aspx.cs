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
public partial class CenterDepot_CenteralReport_PrinterDispatchDetails : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt;
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    PPR_RDLCData objReports = new PPR_RDLCData();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                DdlACYear.DataValueField = "AcYear";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                //DdlACYear.SelectedValue = obCommonFuction.GetFinYearNew();
                //DdlACYear.Enabled = false;
                ddlPrinter.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ReportPaperDispatchToPrinterByParam('" + DdlACYear.SelectedItem.Text + "','0','0','',1)"); //objPaperDispatchDetails.PrinterFill();
                ddlPrinter.DataTextField = "NameofPress_V";
                ddlPrinter.DataValueField = "PrinterID_I";
                ddlPrinter.DataBind();
                ddlPrinter.Items.Insert(0, "Select");
                PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
                PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
                DataSet ds = new DataSet();
                ds = PriReg.GetPrinterDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                    ddlPrinter.DataSource = ds;
                    ddlPrinter.DataTextField = "NameofPress_V";
                    ddlPrinter.DataValueField = "Printer_RedID_I";
                    ddlPrinter.DataBind();
                }
                ddlPrinter.SelectedValue = Session["PrierID_I"].ToString();
                ddlPrinter.Enabled = false;
            }
            catch { }
  
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Dt = new DataTable();
            // Dt = objReports.MonthPublishCoverAllotMent(ddlYear.SelectedItem.Text);
            Dt = obCommonFuction.FillTableByProc("call GetDetailPrinterWise('" + DdlACYear.SelectedValue + "'," + ddlPrinter.SelectedValue + ")");


            if (Dt.Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/CenteralReport/report.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                // ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Param = new ReportParameter[2];
                Param[0] = new ReportParameter("PrinterName", ddlPrinter.SelectedItem.Text);
                //Param[1] = new ReportParameter("Date", System.DateTime.Now.ToString("dd/MM/yyyy"));
                Param[1] = new ReportParameter("ACYear", DdlACYear.SelectedItem.Text);
                ReportViewer1.LocalReport.SetParameters(Param);

                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.Visible = true;
            }
        }
        catch { }
    }
}