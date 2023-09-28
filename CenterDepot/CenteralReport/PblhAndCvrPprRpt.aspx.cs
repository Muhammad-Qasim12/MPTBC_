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

public partial class Paper_PublishAndCoverPaperAllotmentAndSupplyReport : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt;
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    PPR_RDLCData objReports = new PPR_RDLCData();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    public void LoadReport(string Flag)
    {
        string AcYear = "";
        AcYear = ddlYear.SelectedItem.Text;
        Dt = new DataTable();
        Dt = obCommonFuction.FillTableByProc("Call usp_PPR_004GetAllotAndRecivedQty('" + ddlYear.SelectedItem.Text + "')"); //objReports.PublishCoverAllotMent(ddlYear.SelectedItem.Text);
      
        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/CenteralReport/CoverPaperSupplyAllot.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            // ReportViewer1.LocalReport.EnableExternalImages = true;

            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Date", System.DateTime.Now.ToString("dd/MM/yyyy"));
            Param[1] = new ReportParameter("Session", ddlYear.SelectedItem.Text);
            ReportViewer1.LocalReport.SetParameters(Param);

            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
            ReportViewer1.ShowRefreshButton = false;
        }
        else
        {
            ReportViewer1.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadReport("LabInspection");
    }
    protected void ddlYear_Init(object sender, EventArgs e)
    {
        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlYear.DataSource = objTentativeDemandHistory.TentativeDemandAcadminYearFill();
        ddlYear.DataTextField = "AcYear";
        ddlYear.DataValueField = "AcYear";
        ddlYear.DataBind();
        ddlYear.Items.Insert(0, "Select");
        try {
            ddlYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
        }
        catch { }
    }
}