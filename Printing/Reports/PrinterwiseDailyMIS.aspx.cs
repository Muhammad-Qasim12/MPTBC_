
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

public partial class Printing_Reports_PrinterwiseDailyMIS : System.Web.UI.Page
{
    DataTable Dt;
    DataSet ds;
    PRIN_PrinterBooksPrintingDetails obj = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction(); 
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    string CntrDepot_Id = "";
    double TotNet = 0, TotGrossWt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        CntrDepot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            FillPrinter();
        }
    }
    private void FillPrinter()
    {
        CommonFuction obCommonFuction = new CommonFuction(); 
        obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
        ddlPrinterName.DataSource = ds.Tables[0];
        ddlPrinterName.DataTextField = "NameofPress_V";
        ddlPrinterName.DataValueField = "Printer_RedID_I";
        //ddlPrinterName.DataValueField = "NameofPress_V";
        ddlPrinterName.DataBind();
        ddlPrinterName.Items.Insert(0, "SELECT");
       // ddlPrinterName.Items.Insert(1, "ALL"); 
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
            //  GridFillLoad();
            string PrinterID = string.Empty;
            if (ddlPrinterName.SelectedValue == "SELECT")
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select printer.');</script>");
      
            else if (ddlPrinterName.SelectedValue != "ALL")
            {
                PrinterID = ddlPrinterName.SelectedValue;
                Dt = obCommonFuction.FillTableByProc("Call USP_PRI012_PrinterDailyMISReport(" + PrinterID + ",'" + txtFromDate.Text + "','" + txtToDate.Text + "',2)");
                
                if (Dt.Rows.Count > 0)
                {
                    string Title = "";
                    Title = "प्रिंटर का नाम : " + ddlPrinterName.SelectedItem.Text + ", " + " दैनिक प्रगति दिनांक से : " + (txtFromDate.Text == "" ? "सभी" : txtFromDate.Text) + ", " + " दिनांक तक : " + (txtToDate.Text == "" ? "सभी" : txtToDate.Text);

                    ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/PrinterwiseDailyMIS.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ReportParameter[] Param = new ReportParameter[2];
                    Param[0] = new ReportParameter("Year", obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString());
                    Param[1] = new ReportParameter("Title", Title);
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
            else if (ddlPrinterName.SelectedValue == "ALL")
            {

                PrinterID = "";
                Dt = obCommonFuction.FillTableByProc("Call USP_PRI012_PrinterDailyMISReport(" + PrinterID + ",'" + txtFromDate.Text + "','" + txtToDate.Text + "',3)");
                if (Dt.Rows.Count > 0)
                {
                    string Title = "";
                    Title = "प्रिंटर का नाम : " + Session["FullName"].ToString() + ", " + " दैनिक प्रगति दिनांक से : " + (txtFromDate.Text == "" ? "सभी" : txtFromDate.Text) + ", " + " दिनांक तक : " + (txtToDate.Text == "" ? "सभी" : txtToDate.Text);

                    ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/PrinterwiseDailyMIS.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                    ReportParameter[] Param = new ReportParameter[2];
                    Param[0] = new ReportParameter("Year", obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString());
                    Param[1] = new ReportParameter("Title", Title);
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
            
           
        }

    }
}