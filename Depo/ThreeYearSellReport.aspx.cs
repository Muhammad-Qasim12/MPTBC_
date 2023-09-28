using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;

public partial class Depo_ThreeYearSellReport : System.Web.UI.Page
{
    DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction obCommonFuction = new CommonFuction();
            ddldepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            ddldepot.DataValueField = "DepoTrno_I";
            ddldepot.DataTextField = "DepoName_V";
            ddldepot.DataBind();
            ddldepot.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void BtnShow_Click(object sender, EventArgs e)
    {
        string Details;
        ReportDataSource rds = new ReportDataSource();

        rds.Name = "DataSet1";
        CommonFuction comm = new CommonFuction();
        Dt = comm.FillTableByProc("call USP_OpenMarketDemand('" + ddldepot.SelectedValue + "')");
        // Dt = md.OpenMarketDemand();

        rds.Value = Dt;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/rptopenMarketSell3year.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.EnableExternalImages = true;

        ReportParameter[] Param = new ReportParameter[1];
        Details =ddldepot.SelectedItem.Text;
        Param[0] = new ReportParameter("DepoName", Details);
        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;
    }
}