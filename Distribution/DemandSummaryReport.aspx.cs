using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_DemandSummaryReport : System.Web.UI.Page
{
    public DataSet DS;
    CommonFuction obCommonFuction = new CommonFuction();
    public string classa,classb,a1,a2,a3,a4,a5,a6,a7,a8;
    public int r,r2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //ReportDataSource rds = new ReportDataSource();
        //rds.Name = "DemandSymmary";

        DS = obCommonFuction.FillDatasetByProc(@"CALL GetTotalDemandSummary('" + DdlACYear.SelectedItem.Text + "')");
        aa.Visible = true;
        lblfyYaer.Text = DdlACYear.SelectedItem.Text;
        lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        //rds.Value = DS.Tables[0];
        //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/DemandSummaryReport.rdlc");
     
        //ReportViewer1.LocalReport.DataSources.Clear();
        //ReportViewer1.LocalReport.DataSources.Add(rds);
        //ReportViewer1.LocalReport.EnableExternalImages = true;
        //ReportViewer1.ShowPrintButton = true;
        //ReportViewer1.LocalReport.Refresh();
    }
}