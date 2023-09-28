using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_RptMidSessionDemand : System.Web.UI.Page
{
    public CommonFuction obCommanFun = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    public DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
        string DepoName = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
        string strfyYaer = obCommanFun.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        string Title = "दिनांक : " + txtFromdate.Text + " से दिनांक : " + txtTodate.Text + " तक ";
        DataSet ds = new DataSet();
        //string fromDate = (txtFromdate.Text.Split('/')[1] + "/" + txtFromdate.Text.Split('/')[0] + txtFromdate.Text.Split('/')[2]).ToString();
        //string toDate = (txtFromdate.Text.Split('/')[1] + "/" + txtFromdate.Text.Split('/')[0] + txtFromdate.Text.Split('/')[2]).ToString();
        ds = obCommanFun.FillDatasetByProc("call DptGetMidsessionDemand(" + Convert.ToInt32(Session["UserID"]) + ",'" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy-MM-dd") + "')");
        LoadReport(ds, DepoName, Title, strfyYaer);
        ds.Dispose();
    }
    public void LoadReport(DataSet dsGSR, string DepoName, string Title, string FinancialYear)
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        rds.Value = dsGSR.Tables[0];

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/RPTMSReport.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportParameterCollection Param = new ReportParameterCollection();
        Param.Add(new ReportParameter("p_DepoName", DepoName));
        Param.Add(new ReportParameter("p_Title", Title));
        Param.Add(new ReportParameter("p_FYear", FinancialYear));

        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
    }
}