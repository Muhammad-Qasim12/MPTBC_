
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

public partial class ReportPrinterwiseAllotAndSupplyNew_New2 : System.Web.UI.Page
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
            BindPrinterDDL();
        }
    }

    public void BindPrinterDDL()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
        ////////
        // objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ddlPrinter.DataSource = ds.Tables[0];
        ddlPrinter.DataTextField = "NameofPressHindi_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, new ListItem("Select", "0"));
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

    private void LoadReport(string year, int mclass, int mMedium, int mTitle, int mPrinterId)
    {
        System.Collections.ArrayList ar = new System.Collections.ArrayList();
        //string finYr = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        string finYr = year;
        string fromDt = fnDtFormat(txtFromDate.Text); string toDt = fnDtFormat(txtToDate.Text);
       //Dt = obCommonFuction.FillDatasetByProc("Call USP_RPT010_GetMudrakPanjiyan('" + finYr + "','" + mPrinterId + "','" + fromDt + "','" + toDt + "')");
       //Dt = obCommonFuction.FillDatasetByProc("Call USP_RPT010_GetMudrakPanjiyan_New('" + finYr + "','" + mPrinterId + "','" + fromDt + "','" + toDt + "')");
        Dt = obCommonFuction.FillDatasetByProc("Call USP_RPT010_GetMudrakPanjiyan_New_New2('" + finYr + "','" + mPrinterId + "','" + fromDt + "','" + toDt + "')");
        if (Dt.Tables.Count > 0)
        {
            DataTable DtNew = Dt.Tables[0];
            string str = ""; int j = 0;            

            for (int i = 0; i <= DtNew.Rows.Count - 1; i++)
            {
                if (DtNew.Rows[i]["AllotOrderNo"].ToString() == "0Opening")
                {
                    DtNew.Rows[i]["AllotOrderNo"] = "Opening";
                   
                }
                if (DtNew.Rows[i]["AllotOrderNo"].ToString() == "1Opening")
                {
                    DtNew.Rows[i]["AllotOrderNo"] = "Opening";
                }
            }

            for (int i = 0; i <= DtNew.Rows.Count - 1; i++)
            {
                if (DtNew.Rows[i]["AllotOrderNo"].ToString() != str)
                {
                    j++;
                    DtNew.Rows[i]["SrR"] = j.ToString();
                }
                else
                    DtNew.Rows[i]["SrR"] = (j).ToString();

                str = DtNew.Rows[i]["AllotOrderNo"].ToString();
            }


            ReportDataSource rds = new ReportDataSource("dsms", DtNew);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/CenteralReport/ReportPrinterwiseAllotAndSupplyNew.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", finYr);
            string Title = "";
            Title = "मुद्रक: " + ddlPrinter.SelectedItem.Text.ToString().Replace("All", "सभी");
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
        LoadReport(DdlACYear.SelectedItem.Text, 0, 0, 0,Int32.Parse(ddlPrinter.SelectedValue));
    }
}