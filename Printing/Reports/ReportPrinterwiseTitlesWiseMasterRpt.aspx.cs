
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

public partial class ReportPrinterwiseTitlesWiseMasterRpt : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            fillParameters();
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, new ListItem("All", "0")); ;
        }
    }

    private void LoadReport(string mPrinterId, int mTitle, int mclass, int mBookType, int mOrderByDate, int intmBalPerc, int mDedium)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {

            Dt = obCommonFuction.FillTableByProc("Call USP_Rp009_Masterreport_AllPrinternew('" + mPrinterId + "','" + mTitle + "','" + mclass + "','" + 0 + "','" + mOrderByDate + "','" + intmBalPerc + "'," + mDedium + ")");
        }
        else if (RadioButtonList1.SelectedValue == "3")
        {

            Dt = obCommonFuction.FillTableByProc("Call USP_Rp009_Masterreport_AllPrinternew_210223('" + mPrinterId + "','" + mTitle + "','" + mclass + "','" + 0 + "','" + mOrderByDate + "','" + intmBalPerc + "'," + mDedium + ")");
        }

       

        try
        {
            if (Dt.Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource("DataSet2", Dt);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportPrinterWiseTitleWiseMasterRpt.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportParameter[] Param = new ReportParameter[2];
                Param[0] = new ReportParameter("Year", "NA");
                string Title = "";
                Title = "कक्षा: " + DdlClass.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " पुस्तक का प्रकार: " + ddlBookType.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " शीर्षक: " + ddlTital.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " प्रिंटर का नाम: " + fnGetAllPrinter();
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
        catch
        {
            ReportViewer1.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
    }

    private void LoadReportOTH(string mPrinterId, int mTitle, int mclass, int mBookType, int mOrderByDate, int intmBalPerc, int mDedium)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {

            Dt = null;
        }
        else
        {

            Dt = obCommonFuction.FillTableByProc("CALL USP_Other_GMMIS(" + mTitle + ",'2023-2024','" + mPrinterId + "')");
        }

        try
        {
            if (Dt.Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource("DataSet2", Dt);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportPrinterWiseTitleWiseMasterRpt.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportParameter[] Param = new ReportParameter[2];
                Param[0] = new ReportParameter("Year", "NA");
                string Title = "";
                Title = "कक्षा: " + DdlClass.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " पुस्तक का प्रकार: " + ddlBookType.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " शीर्षक: " + ddlTital.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " प्रिंटर का नाम: " + fnGetAllPrinter();
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
        catch
        {
            ReportViewer1.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
    }



    private void FillPrinter()
    {
        CommonFuction obCommonFuction = new CommonFuction();
        obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obCommonFuction.FillDatasetByProc("CALL USP_PrinterDubey_Load(0)");
        ddlPrinterName.DataSource = ds.Tables[0];
        ddlPrinterName.DataTextField = "NameofPress_V";
        ddlPrinterName.DataValueField = "Printer_RedID_I";
        ddlPrinterName.DataBind();
        //ddlPrinterName.Items.Insert(0, new ListItem("All", "0"));
    }

    private void fillParameters()
    {
        CommonFuction comm = new CommonFuction();
        FillPrinter();
        //DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
        //DdlClass.DataValueField = "ClassTrno_I";
        //DdlClass.DataTextField = "Classdet_V";
        //DdlClass.DataBind();
        //DdlClass.Items.Insert(0, new ListItem("All", "0"));

        //ddlBookType.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
        //ddlBookType.DataValueField = "MediumTrno_I";
        //ddlBookType.DataTextField = "MediunNameHindi_V";
        //ddlBookType.DataBind();
        //ddlBookType.Items.Insert(0, new ListItem("All", "0"));
        if (RadioButtonList1.SelectedValue == "1")
        {
            DataSet asdf = comm.FillDatasetByProc("call USP_PrinterDubey_Load(1)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));
        }
        else
        {
            DataSet asdf = comm.FillDatasetByProc("CALL USP_Other_GMMIS(0,'2023-2024',0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "Subject";
            ddlTital.DataValueField = "TItleid";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int intOrderByDate = chkOrderByDate.Checked == true ? 1 : 0;
        int intmBalPerc = 0;
        if (rdoAll.Checked == true)
            intmBalPerc = 1;
        else if (rdoL100.Checked == true)
            intmBalPerc = 2;
        else if (rdoH100.Checked == true)
            intmBalPerc = 3;

        string PrinterSelected = "";
        for (int i = 0; i < ddlPrinterName.Items.Count; i++)
        {
            if (ddlPrinterName.Items[i].Selected)
            {
                PrinterSelected += ddlPrinterName.Items[i].Value + ",";
            }
        }
        if (PrinterSelected != "")
            PrinterSelected = PrinterSelected.Substring(PrinterSelected.Length - (PrinterSelected.Length), (PrinterSelected.Length - 1));
        else
            PrinterSelected = "0";


        if (RadioButtonList1.SelectedValue == "1")
        {
            LoadReport(PrinterSelected, Int32.Parse(ddlTital.SelectedValue),
                Int32.Parse(DdlClass.SelectedValue), Int32.Parse(ddlBookType.SelectedValue), intOrderByDate, intmBalPerc, Convert.ToInt32(DdlScheme.SelectedValue));
        }
        if (RadioButtonList1.SelectedValue == "3")
        {
            LoadReport(PrinterSelected, Int32.Parse(ddlTital.SelectedValue),
                Int32.Parse(DdlClass.SelectedValue), Int32.Parse(ddlBookType.SelectedValue), intOrderByDate, intmBalPerc, Convert.ToInt32(DdlScheme.SelectedValue));
        }
        if (RadioButtonList1.SelectedValue == "2")
        {
            LoadReportOTH(PrinterSelected, Int32.Parse(ddlTital.SelectedValue), 0, 0, 0, 0, 0);
        }
        // ddlPrinterName.SelectedIndex = -1;
    }

    private string fnGetAllPrinter()
    {
        string PrinterSelected = "";
        for (int i = 0; i < ddlPrinterName.Items.Count; i++)
        {
            if (ddlPrinterName.Items[i].Selected)
            {
                PrinterSelected += ddlPrinterName.Items[i].Text + ",";
            }
        }
        //PrinterSelected = PrinterSelected.Substring(PrinterSelected.Length - (PrinterSelected.Length), (PrinterSelected.Length - 1));

        if (PrinterSelected != "")
            PrinterSelected = PrinterSelected.Substring(PrinterSelected.Length - (PrinterSelected.Length), (PrinterSelected.Length - 1));
        else
            PrinterSelected = "सभी";

        return PrinterSelected;
    }


    protected void DdlScheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet asdf = comm.FillDatasetByProc("call GetMediumbyTitile(" + DdlScheme.SelectedValue + ",'1,2,3,4,5,6,7,8,9,10,11,12')");
        ddlTital.DataSource = asdf.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        if (RadioButtonList1.SelectedValue == "1")
        {
            LblClass.Visible = true;
            DdlClass.Visible = true;
            DdlScheme.Visible = true;
            ddlTital.Visible = true;
            ddlBookType.Visible = true;

        }
        else
        {
            LblClass.Visible = false;
            DdlClass.Visible = false;
            DdlScheme.Visible = false;
            // ddlTital.Visible = false;
            ddlBookType.Visible = false;
        }

        if (RadioButtonList1.SelectedValue == "1")
        {
            DataSet asdf = comm.FillDatasetByProc("call USP_PrinterDubey_Load(1)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));
        }
        else
        {
            DataSet asdf = comm.FillDatasetByProc("CALL USP_Other_GMMIS(0,'2023-2024',0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "Subject";
            ddlTital.DataValueField = "TItleid";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));
        }
    }
    protected void btnRefress_Click(object sender, EventArgs e)
    {
        try
        {
            CommonFuction comm = new CommonFuction();
            comm.FillDatasetByProc("call InsertData_MisReport201718('2023-2024',0)");
        }
        catch (Exception ex)
        {

        }
    }
}