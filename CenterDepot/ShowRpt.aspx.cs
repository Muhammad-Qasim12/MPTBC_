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

public partial class CenterDepot_ShowRpt : System.Web.UI.Page
{DataSet ds;
    DataTable Dt;
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    PPR_RDLCData objReports = new PPR_RDLCData();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string AcYear = "";
          
            Dt = new DataTable();
            Dt = obCommonFuction.FillTableByProc("CALL `USP_PPR0022_StockReportByAcYear70GSM`('All','01/10/2019','31/12/2019','2020-2021' ,1)"); //objReports.PublishCoverAllotMent(ddlYear.SelectedItem.Text);

            if (Dt.Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/CenteralReport/Rptgsm.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                // ReportViewer1.LocalReport.EnableExternalImages = true;

             

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

    }
     
}