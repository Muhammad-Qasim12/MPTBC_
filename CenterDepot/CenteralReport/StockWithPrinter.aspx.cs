using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using MPTBCBussinessLayer;
using System.Globalization;
using Microsoft.Reporting.WebForms;

public partial class CenterDepot_CenteralReport_StockDetailsWithPaperVendor : System.Web.UI.Page
{

    DataSet ds;
    DataTable Dt, dt;
    PPR_RDLCData objReports = new PPR_RDLCData();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DateTime DteCheck;
        string RptDate = "", GrDate = "";
        if (txtFromDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtFromDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }
        if (txtToDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtToDate.Text, cult);
            }
            catch { GrDate = "NoDate"; }
        }


        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct From Date.');</script>");
        }
        else if (GrDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct End Date.');</script>");
        }
        else
        {
            Dt = objReports.PaperVendorStockDetailsBetweenTwoDate(ddlPrinterName.SelectedItem.Value, txtFromDate.Text.ToString().Replace("-", "/"), txtToDate.Text.ToString().Replace("-", "/"));
            Dt = GetDataByACYear();
            if (Dt.Rows.Count > 0)
            {
                string Title = "";
                Title = "प्रिंटर का नाम  : " + ddlPrinterName.SelectedItem.Text.Replace("All", "सभी") + ", " + " दिनांक से : " + (txtFromDate.Text.ToString().Replace("-", "/") == "" ? "सभी" : txtFromDate.Text.ToString().Replace("-", "/")) + ", " + " दिनांक तक : " + (txtToDate.Text.ToString().Replace("-", "/") == "" ? "सभी" : txtToDate.Text.ToString().Replace("-", "/"));
    
                //GridView1.DataSource = Dt;
               // GridView1.DataBind();
                ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/CenteralReport/PrinterStkWithAllot.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportParameter[] Param = new ReportParameter[2];
                Param[0] = new ReportParameter("Year", obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString());
                Param[1] = new ReportParameter("Title", Title);
                ReportViewer1.LocalReport.SetParameters(Param);
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
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //GridView GrdLabInspection = (GridView)e.Row.FindControl("GrdLabInspection");
            //Label lblVouchar_Tr_Id = (Label)e.Row.FindControl("lblVouchar_Tr_Id");
            //dt = objReports.VendorChildDisptchFill(ddlVendor.SelectedItem.Value, lblVouchar_Tr_Id.Text);
            //if (dt.Rows.Count > 0)
            //{
            //    GrdLabInspection.DataSource = dt;
            //    GrdLabInspection.DataBind();
            //}
        }
    }
    protected void ddlPrinterName_Init(object sender, EventArgs e)
    {
        FillACYear();
        //string acy = ddlAcYear.SelectedItem.Text;
        //DataSet ds1 = new DataSet();
       PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
       obPRI_PaperAllotment.Printer_RedID_I = 0;
       DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
      
        ddlPrinterName.DataSource = ds.Tables[0];
        ddlPrinterName.DataTextField = "NameofPressHindi_V";
        ddlPrinterName.DataValueField = "Printer_RedID_I";
        ddlPrinterName.DataBind();
        ddlPrinterName.Items.Insert(0, "All");
    }
    protected void FillACYear()
    {
        var myDate = DateTime.Now;
        var newDate = myDate.AddYears(-1);
        txtFromDate.Text = (newDate).ToShortDateString();
        txtToDate.Text = System.DateTime.Now.ToShortDateString();
        ds = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(1)");
        ddlAcYear.DataSource = ds.Tables[0];
        ddlAcYear.DataTextField = "AcYear";
        ddlAcYear.DataBind();
    }
    protected void ddlAcYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlAcYear.SelectedIndex > 0)
        //{
        //    var myDate = DateTime.Now;
        //    var newDate = myDate.AddYears(-1);
        //    txtFromDate.Text = (newDate).ToShortDateString();
        //    txtToDate.Text = System.DateTime.Now.ToShortDateString();
        //    string acy = ddlAcYear.SelectedItem.Text;
        //    DataSet ds1 = new DataSet();
        //    ds1 = obCommonFuction.FillDatasetByProc("call USP_PPR0022_StockReportByAcYear('','','','" + acy + "',2)");
        //    // objReports = new PPR_RDLCData();
        //    // ddlPrinterName.DataSource = objReports.PrinterFillWithStk();
        //    ddlPrinterName.DataSource = ds1.Tables[0];
        //    ddlPrinterName.DataTextField = "NameofPress_V";
        //    ddlPrinterName.DataValueField = "Printer_RedID_I";
        //    ddlPrinterName.DataBind();
        //    ddlPrinterName.Items.Insert(0, "All");
        //}
    }
    public DataTable GetDataByACYear()
    {
        DataSet ds1 = new DataSet();
        ds1 = obCommonFuction.FillDatasetByProc("call USP_PPR0022_StockReportByAcYear('" + ddlPrinterName.SelectedItem.Value + "','" + txtFromDate.Text.ToString().Replace("-", "/") + "','" + txtToDate.Text.ToString().Replace("-", "/") + "','" + ddlAcYear.SelectedItem.Text + "',1)");

        return ds1.Tables[0];
    }
}
