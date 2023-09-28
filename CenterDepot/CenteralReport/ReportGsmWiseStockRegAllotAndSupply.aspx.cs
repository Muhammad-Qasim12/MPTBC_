
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

public partial class ReportGsmWiseStockRegAllotAndSupply : System.Web.UI.Page
{
    DataSet Dt;
    DataSet ds;
    PRIN_PrinterBooksPrintingDetails obj = null;
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
            Vendorfill();
            //LoadReport(DdlACYear.SelectedItem.Text, Convert.ToInt32(ddlPrinter.SelectedValue));
        }
    }

    public void Vendorfill()
    {
        PPR_BillGenerate ObjBillGenerate = null;
        ObjBillGenerate = new PPR_BillGenerate();
        ddlVendorName.DataSource = ObjBillGenerate.VendorFill();
        ddlVendorName.DataValueField = "PaperVendorTrId_I";
        ddlVendorName.DataTextField = "PaperVendorName_V";
        ddlVendorName.DataBind();
        ddlVendorName.Items.Insert(0, new ListItem("ALL","0"));
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
        ddlPrinter.Items.Insert(0, new ListItem("Select", "0"));
        if (ddlPrinter.Items.FindByValue("27") != null)
            ddlPrinter.Items.FindByValue("27").Selected = true;
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

    private void LoadReport(string year, int mclass)
    {
        ReportViewer1.LocalReport.Refresh();
        System.Collections.ArrayList ar = new System.Collections.ArrayList();
        //string finYr = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        string finYr = year; 
        string fromDt = fnDtFormat(txtFromDate.Text); string toDt = fnDtFormat(txtToDate.Text);
        string vendorId = ddlVendorName.SelectedValue == "All" ? "0" : ddlVendorName.SelectedValue;

        Dt = obCommonFuction.FillDatasetByProc("Call USP_RPT010_GetStockRegisterRecAndSupply('" + finYr + "','" + mclass + "','" + fromDt + "','" + toDt + "','" + vendorId + "')");
        if (Dt.Tables.Count > 0)
        {
            DataTable DtNew = Dt.Tables[0];  

            ReportDataSource rds = new ReportDataSource("dss", DtNew);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/CenteralReport/ReportGsmWiseStockRegAllotAndSupply.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", finYr);
            string Title = "";
            Title = "रिपोर्ट दिनांक : " + txtFromDate.Text + " से " + txtToDate.Text;
            //Title = "मुद्रक: " + ddlPrinter.SelectedItem.Text.ToString().Replace("All", "सभी");
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
        LoadReport(DdlACYear.SelectedItem.Text, Convert.ToInt32(ddlPrinter.SelectedValue));
    }
}