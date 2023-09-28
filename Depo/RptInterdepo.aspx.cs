using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
using Microsoft.Reporting.WebForms;
public partial class Depo_RptInterdepo : System.Web.UI.Page
{
    public CommonFuction obCommonFuction = new CommonFuction();
    public DataSet ds1;
    public DataTable myDT;
    public int j;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("call getInterDepoOrder(" + Session["UserID"] + ")");
           ddlMedium.DataTextField = "ReqNo";
           ddlMedium.DataValueField = "ReqNo";
           ddlMedium.DataBind();
           ddlMedium.Items.Insert(0, "Select..");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
        Label lblfyYaer = new Label();
        Label lblAddress = new Label();
        string DepoName = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();

        CommonFuction comm = new CommonFuction();
        lblfyYaer.Text = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        string Title = "";
        DataSet ds = new DataSet();
        ds = obCommonFuction.FillDatasetByProc("call dptGetInterDepoTrnasfor(" + Session["UserID"] + ",'" + ddlMedium.SelectedValue + "')");
        LoadReport(ds, DepoName, Title, lblfyYaer.Text);
        ds.Dispose();
    }
    public void LoadReport(DataSet dsGSR, string DepoName, string Title, string FinancialYear)
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        rds.Value = dsGSR.Tables[0];

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/RPTINterDepo1.rdlc");
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