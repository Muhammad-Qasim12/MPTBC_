
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

public partial class GSRSummarySupply : System.Web.UI.Page
{
    DataTable Dt;
    DataSet ds;
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
            VendorFill();
        }

        
    }

    public void VendorFill()
    {
        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ddlVendor.DataSource = objPaperDispatchDetails.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, new ListItem("All","0"));
    }

   
    private void LoadReport(string year, int mPrinterId)
    {
        //string finYr = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        string finYr = year;
        //Dt = obCommonFuction.FillTableByProc("Call USP_PRI012_PrinterOrderDtlChild('" + "" + "','" + "" + "','" + "" + "',6,'" + finYr + "')");
        Dt = obCommonFuction.FillTableByProc("Call USP_PPR0014_PaperDispatchCDSearchNameNewGSR_Rpt('" + finYr + "','" + mPrinterId + "','')");
        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/GSRSummaryPraapti.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", finYr);
            string Title = "";
            Title = "पेपर मिल: " + ddlVendor.SelectedItem.Text.ToString().Replace("All", "सभी");
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
            // GridView1.DataSource = null;
            // GridView1.DataBind();
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
        //LoadReport(DdlACYear.SelectedItem.Text, Int32.Parse(DdlClass.SelectedValue), 
        //    Int32.Parse(ddlMedium.SelectedValue), Int32.Parse(ddlTital.SelectedValue),
        //    Int32.Parse(ddlPrinter.SelectedValue));

        LoadReport(DdlACYear.SelectedItem.Text, Int32.Parse(ddlVendor.SelectedValue));
    }
}