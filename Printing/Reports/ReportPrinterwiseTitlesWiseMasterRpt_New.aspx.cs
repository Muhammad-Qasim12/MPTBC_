
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
        }
    }

    private void LoadReport(int mPrinterId, int mTitle, int mclass, int mBookType, int mOrderByDate, int intmBalPerc)
    {
        Dt = obCommonFuction.FillTableByProc("Call USP_Rp009_Masterreport('" + mPrinterId + "','" + mTitle + "','" + mclass + "','" + 0 + "','" + mOrderByDate + "','" + intmBalPerc + "')");
        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet2", Dt);
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportPrinterWiseTitleWiseMasterRpt.rdlc");
            if(chkPrintAll.Checked == true)
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/printall/ReportPrinterWiseTitleWiseMasterRpt_PrintAll.rdlc");
            else
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportPrinterWiseTitleWiseMasterRpt_MtxNew.rdlc");

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", "NA");
            string Title = "";
            Title = "कक्षा: " + DdlClass.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " पुस्तक का प्रकार: " + ddlBookType.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " शीर्षक: " + ddlTital.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " प्रिंटर का नाम: " + ddlPrinterName.SelectedItem.Text.ToString().Replace("All", "सभी");
            Param[1] = new ReportParameter("Class", Title);
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
        ddlPrinterName.Items.Insert(0, new ListItem("All", "0"));
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

        DataSet asdf = comm.FillDatasetByProc("call USP_PrinterDubey_Load(1)");
        ddlTital.DataSource = asdf.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("All", "0"));

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int intOrderByDate = chkOrderByDate.Checked == true ? 1 : 0;
        int intmBalPerc = 0;
        if (rdoAll.Checked==true) 
            intmBalPerc = 1;
        else if (rdoL100.Checked == true)
            intmBalPerc = 2;
        else if (rdoH100.Checked == true)
            intmBalPerc = 3;

        LoadReport(Int32.Parse(ddlPrinterName.SelectedValue), Int32.Parse(ddlTital.SelectedValue),
            Int32.Parse(DdlClass.SelectedValue), Int32.Parse(ddlBookType.SelectedValue), intOrderByDate, intmBalPerc);
    }
}