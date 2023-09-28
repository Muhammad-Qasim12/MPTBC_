  
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
using MPTBCBussinessLayer.Paper;

public partial class GSRSummarySupplyRpt : System.Web.UI.Page
{
   
   
    PPR_PaperDispatchDetails objPaperDispatchDetails = new PPR_PaperDispatchDetails();
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
            BindGSMDDL();
        }

        
    }

    public void VendorFill()
    {
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //ddlVendor.DataSource = objPaperDispatchDetails.VenderFill();
        //ddlVendor.DataTextField = "PaperVendorName_V";
        //ddlVendor.DataValueField = "PaperVendorTrId_I";
        //ddlVendor.DataBind();
        //ddlVendor.Items.Insert(0, new ListItem("All", "0"));
    }

    public string fnDtFormat(string date)
    {
        if (date.Trim().Length > 0)
        {
            if (date.Trim().IndexOf('-') > 0)
            {
                date = date.Split('-')[2] + "-" + date.Split('-')[1] + "-" + date.Split('-')[0];
            }
            else
                date = date.Split('/')[2] + "-" + date.Split('/')[1] + "-" + date.Split('/')[0];
        }
        return date;
    }

    public void BindGSMDDL()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataTable ds = obCommonFuction.FillTableByProc("SELECT CONCAT(CAST(ppm.GSM AS CHAR),' GSM ',CAST(pqm.QualifyType AS CHAR),' (',CAST(ppm.PaperSize_V AS CHAR),') ' ,CAST(ppm.PaperCategory AS CHAR)) AS CoverInformation, ppm.PaperTrId_I FROM  ppr_papermaster_m ppm INNER JOIN  paperqualifytypemaster pqm ON pqm.Qualifyid_I=ppm.PaperQuality_V INNER JOIN  ppr_papertype  pt ON pt.PaperType_Id=ppm.PaperType_I WHERE paperCategory='Reel' OR paperCategory='Sheet' ORDER BY ppm.GSM");

        ddlPrinter.DataSource = ds;
        ddlPrinter.DataTextField = "CoverInformation";
        ddlPrinter.DataValueField = "PaperTrId_I";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, new ListItem("All", "0"));
    }
    
   
    private void LoadReport(string year)
    {
        ReportViewer1.LocalReport.Refresh();
        string finYr = year;
        string fromDt = fnDtFormat(txtFromDate.Text); string toDt = fnDtFormat(txtToDate.Text);
        string gsm = ddlPrinter.SelectedValue;
        DataTable Dt = obCommonFuction.FillTableByProc("Call USP_RPT030_GetGSRSupply('" + finYr + "','" + fromDt + "','" + toDt + "','" + gsm + "')");
        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("dss11", Dt);            
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/CenteralReport/GSRSummarySupplyRpt.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", finYr);
            string Title = "";
            //Title = "पेपर मिल: " + ddlVendor.SelectedItem.Text.ToString().Replace("All", "सभी");
            string str = txtFromDate.Text + " से " + txtToDate.Text;
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                Title = "रिपोर्ट दिनांक : " + txtFromDate.Text + " से " + txtToDate.Text + Environment.NewLine + "GSM : " + ddlPrinter.SelectedItem.Text.ToString().Replace("All", "सभी");
            }
            else
                Title = "रिपोर्ट दिनांक : --" + Environment.NewLine + "GSM : " + ddlPrinter.SelectedItem.Text.ToString().Replace("All", "सभी");
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
        }

        //html based report
        //DataTable Dt = obCommonFuction.FillTableByProc("Call USP_PPR0014_PaperDispatchCDSearchNameNewGSR_HtmlRpt('" + finYr + "','" + mPrinterId + "','1','','')");
        //fnGetData(Dt, finYr, mPrinterId);

        //gridview report
      
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
       LoadReport(DdlACYear.SelectedItem.Text);
    }
}