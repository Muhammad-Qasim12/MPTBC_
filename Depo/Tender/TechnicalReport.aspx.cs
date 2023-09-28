using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Paper;
using Microsoft.Reporting.WebForms;
using System.IO;
public partial class Tender_TechnicalReport : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt, dt;
    PPR_RDLCData objReports = new PPR_RDLCData();
    PPR_LabInspection objLabInspection = null;
    CommonFuction obCommonFuction = new CommonFuction();
    string LastYear = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(1)");
            ddlAcYear.DataSource = ds.Tables[0];
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();

            FillTenderDDL();
        }
    }

    //ds = objComm.FillDatasetByProc("call USP_ppr_TechniBidSearch('" + txtSearch.Text + "','" + ddlAcYear.SelectedItem.Value + "',8)");
    public void DataLoad()
    {


        DataTable DtTenderTechRpt = new DataTable(); DataSet dd = obCommonFuction.FillDatasetByProc("call NewTenderDetailsbyFy(1," + ddlTender.SelectedValue + ","+Session["UserID"]+")");
       // Dt = objReports.YearlyDataShowOfStock();
        DtTenderTechRpt = obCommonFuction.FillTableByProc("call NewTenderTechinicalReport(" + ddlTender.SelectedValue + ",'" + ddlAcYear.SelectedValue + "')");

        if (DtTenderTechRpt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", DtTenderTechRpt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/Tender/Report.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            // ReportViewer1.LocalReport.EnableExternalImages = true;

            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("A1", dd.Tables[0].Rows[0]["TenderNo_V"].ToString());
            Param[1] = new ReportParameter("a2", dd.Tables[0].Rows[0]["TechBidopeningDate_D"].ToString());
            //Param[2] = new ReportParameter("a3", dd.Tables[0].Rows[0]["WorkName_V"].ToString());
            ReportViewer1.LocalReport.SetParameters(Param);
            
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;

            

        }
        else
        {
            ReportViewer1.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
    }
    protected void ddlAcYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ds = obCommonFuction.FillDatasetByProc("call NewTenderDetailsbyFy(0,'" + ddlAcYear.SelectedItem.Value + "')");
        //ddlTender.DataSource = ds.Tables[0];
        //ddlTender.DataValueField = "TenderId_I";
        //ddlTender.DataTextField = "TenderNo_V";
        //ddlTender.DataBind();

        FillTenderDDL();
    }

    private void FillTenderDDL()
    {
        string userId = Session["UserID"].ToString();
        ds = obCommonFuction.FillDatasetByProc("call NewTenderDetailsbyFy(0,'" + ddlAcYear.SelectedItem.Value + "','" + userId + "')");
        ddlTender.DataSource = ds.Tables[0];
        ddlTender.DataValueField = "TenderId_I";
        ddlTender.DataTextField = "TenderNo_V";
        ddlTender.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataLoad();
    }

    protected void PrintButton1_Click(object sender, EventArgs e)
    {
        DataTable DtTenderTechRpt = new DataTable(); DataSet dd = obCommonFuction.FillDatasetByProc("call NewTenderDetailsbyFy(1," + ddlTender.SelectedValue + ")");
        // Dt = objReports.YearlyDataShowOfStock();
        DtTenderTechRpt = obCommonFuction.FillTableByProc("call NewTenderTechinicalReport(" + ddlTender.SelectedValue + ",'" + ddlAcYear.SelectedValue + "')");

        if (DtTenderTechRpt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", DtTenderTechRpt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/Tender/Report.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("A1", dd.Tables[0].Rows[0]["TenderNo_V"].ToString());
            Param[1] = new ReportParameter("a2", dd.Tables[0].Rows[0]["TechBidopeningDate_D"].ToString());            
            ReportViewer1.LocalReport.SetParameters(Param);
            
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;



        }
        else
        {
            ReportViewer1.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
    }

    public void DataLoad_PageLoad()
    {


        DataTable DtTenderTechRpt = new DataTable(); DataSet dd = obCommonFuction.FillDatasetByProc("call NewTenderDetailsbyFy(1,4)");
        // Dt = objReports.YearlyDataShowOfStock();
        DtTenderTechRpt = obCommonFuction.FillTableByProc("call NewTenderTechinicalReport('4','4')");

        if (DtTenderTechRpt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", DtTenderTechRpt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/Tender/Report.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            // ReportViewer1.LocalReport.EnableExternalImages = true;

            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("A1", dd.Tables[0].Rows[0]["TenderNo_V"].ToString());
            Param[1] = new ReportParameter("a2", dd.Tables[0].Rows[0]["TechBidopeningDate_D"].ToString());
            //Param[2] = new ReportParameter("a3", dd.Tables[0].Rows[0]["WorkName_V"].ToString());
            ReportViewer1.LocalReport.SetParameters(Param);

            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;



        }
        else
        {
            ReportViewer1.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
    }
}