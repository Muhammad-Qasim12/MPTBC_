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

public partial class Printing_Reports_ReportPrinterwiseTitlesWiseAwavtanPrapti : System.Web.UI.Page
{
    DataTable Dt;
    DataSet ds;
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    PRIN_PrinterBooksPrintingDetails obj = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    string CntrDepot_Id = "";
    double TotNet = 0, TotGrossWt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, new ListItem("All", "0"));

            ddlPrinterName.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DistributionorderonWorkorder('" + DdlACYear.SelectedValue.ToString() + "')");
            ddlPrinterName.DataValueField = "Printer_regid_i";
            ddlPrinterName.DataTextField = "NameofPress_V";
            ddlPrinterName.DataBind();
            ddlPrinterName.Items.Insert(0, new ListItem("All", "0"));

            title();

        }
    }

    public void year()
    {
        DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        DdlACYear.DataValueField = "AcYear";
        DdlACYear.DataTextField = "AcYear";
        DdlACYear.DataBind();
        DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
    }
    //public void FillPrinter()
    //{
    //    CommonFuction obCommonFuction = new CommonFuction();
    //    obPRI_PaperAllotment = new PRI_PaperAllotment();
    //    obPRI_PaperAllotment.Printer_RedID_I = 0;
    //    DataSet ds = obCommonFuction.FillDatasetByProc("CALL USP_PrinterDubey_Load(0)");
    //    ddlPrinterName.DataSource = ds.Tables[0];
    //    ddlPrinterName.DataTextField = "NameofPress_V";
    //    ddlPrinterName.DataValueField = "Printer_RedID_I";
    //    ddlPrinterName.DataBind();
    //    ddlPrinterName.Items.Insert(0, new ListItem("ALL", "0"));
    //}

    public void depo()
    {

        DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
        DdlDepot.DataValueField = "DepoTrno_I";
        DdlDepot.DataTextField = "DepoName_V";
        DdlDepot.DataBind();
        DdlDepot.Items.Insert(0, new ListItem("All", "0"));
    }
    public void title()
    {
        CommonFuction comm = new CommonFuction();
        DataSet asdf = comm.FillDatasetByProc("call USP_PrinterDubey_Load(1)");
        ddlTital.DataSource = asdf.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPrinterName.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DistributionorderonWorkorder('" + DdlACYear.SelectedValue.ToString() + "')");
        ddlPrinterName.DataValueField = "Printer_regid_i";
        ddlPrinterName.DataTextField = "NameofPress_V";
        ddlPrinterName.DataBind();
        ddlPrinterName.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try 
        {
            //Dt = obCommonFuction.FillTableByProc("Call USP_Rp009_Masterreport_AllPrinternew('" + DdlACYear.SelectedValue + "','" + ddlPrinterName.SelectedValue + "','" + ddlTital.SelectedValue + "','" + 0 + "','" + DdlDepot.SelectedValue + "','" + intmBalPerc + "'," + mDedium + ")");
           // DataSet dd = obCommonFuction.FillTableByProc("Call USP_Rp009_Masterreport_AllPrinternew('" + DdlACYear.SelectedValue + "','" + ddlPrinterName.SelectedValue + "','" + ddlTital.SelectedValue + "','" + 0 + "','" + DdlDepot.SelectedValue + "'");
            //DataSet dd = obCommonFuction.FillDatasetByProc("call USP_GM_DepowiseavantanpraptiDepo_All_new ('" + DdlACYear.SelectedValue + "','" + ddlPrinterName.SelectedValue + "','" + ddlTital.SelectedValue + "','" + DdlDepot.SelectedValue + "' ) ");
            DataSet dd = obCommonFuction.FillDatasetByProc("call USP_GM_DepowiseavantanpraptiDepo_All ('" + DdlACYear.SelectedValue + "','" + ddlPrinterName.SelectedValue + "','" + ddlTital.SelectedValue + "','" + DdlDepot.SelectedValue + "' ) ");

            if (dd.Tables[0].Rows.Count > 0)
            {


                ReportDataSource rds = new ReportDataSource();

                rds.Name = "DataSet1";
               
                Dt = dd.Tables[0];
                rds.Value = Dt;
                //ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report3.rdlc");
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("ReportPrinterwiseTitlesWiseAwavtanPrapti.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.EnableExternalImages = true;

                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.Refresh();


               // ReportDataSource rds = new ReportDataSource("DataSet2", Dt);
               // ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportPrinterWiseTitleWiseMasterRpt.rdlc");
               // ReportViewer1.LocalReport.DataSources.Clear();
               // ReportViewer1.LocalReport.DataSources.Add(rds);
               // ReportParameter[] Param = new ReportParameter[2];
               // Param[0] = new ReportParameter("Year", "NA");
               // string Title = "";
               //// Title = "कक्षा: " + DdlClass.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " पुस्तक का प्रकार: " + ddlBookType.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " शीर्षक: " + ddlTital.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " प्रिंटर का नाम: " + fnGetAllPrinter();
               // Param[1] = new ReportParameter("Class", Title);
               // ReportViewer1.LocalReport.SetParameters(Param);
               // // ReportViewer1.LocalReport.EnableExternalImages = true;
               // ReportViewer1.ShowPrintButton = true;
               // ReportViewer1.LocalReport.Refresh();
               // ReportViewer1.Visible = true;


               // Dt = dd.Tables[0];
               // rds.Value = Dt;
               // ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report3.rdlc");
               // ReportViewer1.LocalReport.DataSources.Clear();
               // ReportViewer1.LocalReport.DataSources.Add(rds);
               // ReportViewer1.LocalReport.EnableExternalImages = true;

               // ReportViewer1.LocalReport.EnableExternalImages = true;
               // ReportViewer1.ShowPrintButton = true;
               // ReportViewer1.LocalReport.Refresh();


            }
            else
            {
                ReportViewer1.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
                // GridView1.DataSource = null;
                // GridView1.DataBind();
            }
        }
           
        catch
        {
            
        }
    }
}