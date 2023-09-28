
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Paper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Printing_Reports_StockDetailsOfPrinter : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt, dt;
    PPR_RDLCData objReports = new PPR_RDLCData();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            
            if (!Page.IsPostBack)
            {
                txtFromDate.Text = System.DateTime.Now.ToShortDateString();
                txtToDate.Text = System.DateTime.Now.ToShortDateString();
                PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
                PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
                DataSet ds = new DataSet();
                ds = PriReg.GetPrinterDetails();
                if (ds.Tables[0].Rows.Count > 0)
                { 
                    Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                }
                objReports = new PPR_RDLCData();
                ddlPrinterName.DataSource = objReports.PrinterFillWithStk();
                ddlPrinterName.DataTextField = "NameofPress_V";
                ddlPrinterName.DataValueField = "Printer_RedID_I";
                ddlPrinterName.DataBind();
                ddlPrinterName.Items.Insert(0, "All");
                try
                {
                    ddlPrinterName.Items.FindByValue(Session["PrierID_I"].ToString()).Selected = true;
                    ddlPrinterName.Enabled = false;
                }
                catch { }
                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                DdlACYear.DataValueField = "Id";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                DdlACYear.SelectedValue = obCommonFuction.GetFinYearNew();
            }
        }
        else
        {
            Response.Redirect("../../Login.aspx");
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
            if (ddlPrinterName.SelectedItem.Text == "All")
            {
                ReportViewer1.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
            }
            else
            {
               // Dt = objReports.PaperVendorStockDetailsBetweenTwoDate(ddlPrinterName.SelectedItem.Value, txtFromDate.Text, txtToDate.Text);
                Dt = obCommonFuction.FillTableByProc("call USP_PPR0022_StockReportByAcYear('" + ddlPrinterName.SelectedItem.Value + "','" + (txtFromDate.Text).Replace("-", "/") + "','" + txtToDate.Text.Replace("-", "/") + "','" + DdlACYear.SelectedItem.Text + "',1)");
                
                if (Dt.Rows.Count > 0)
                {
                    string Title = "";
                    Title = "प्रिंटर का नाम  : " + ddlPrinterName.SelectedItem.Text.Replace("All", "सभी") + ", " + " दिनांक से : " + (txtFromDate.Text == "" ? "सभी" : txtFromDate.Text) + ", " + " दिनांक तक : " + (txtToDate.Text == "" ? "सभी" : txtToDate.Text);

                    //GridView1.DataSource = Dt;
                    // GridView1.DataBind();
                    ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/PrinterStkWithAllotment.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ReportParameter[] Param = new ReportParameter[2];
                    Param[0] = new ReportParameter("Year", DdlACYear.SelectedItem.Text);
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
        
    }
}
