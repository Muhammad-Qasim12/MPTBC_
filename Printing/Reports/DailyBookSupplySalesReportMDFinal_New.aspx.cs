
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

public partial class DailyBookSupplySalesReportMDFinal_New : System.Web.UI.Page
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

    private void LoadReport(string year, int mclass) //0=All, 1=1 to 8, 2=9 to 12
    {
        //string finYr = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        string finYr = DdlACYear.SelectedItem.Text;
        //Dt = obCommonFuction.FillTableByProc("Call USP_PRI012_PrinterOrderDtlChild('" + "" + "','" + "" + "','" + "" + "',6,'" + finYr + "')");
        if (rdDistrict.Checked == true)
        {
            Dt = obCommonFuction.FillTableByProc("Call USP_GetDailyBookSupplySalesReportFinal_New('" + finYr + "')");
        }else
            Dt = obCommonFuction.FillTableByProc("Call USP_GetDailyBookSupplySalesReportFinal('" + finYr + "')");
        
        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet2", Dt);
            if (mclass == 0)
            {
                if(rdDistrict.Checked==true)
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportDailyBooksSupplySalesFinal_New.rdlc");
                else
                   ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportDailyBooksSupplySalesFinal.rdlc");
            }
            else if (mclass == 1)
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportDailyBooksSupplySales1to8Final.rdlc");
            }
            else if (mclass == 2)
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportDailyBooksSupplySales9to12Final.rdlc");
            }
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", finYr);

            string Title = "";
            Title = "कक्षा: " + DdlClass.SelectedItem.Text.ToString().Replace("All", "सभी");
            Param[1] = new ReportParameter("Class", Title.ToString());
            //Param[1] = new ReportParameter("Title", Title);
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
        DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        DdlACYear.DataValueField = "AcYear";
        DdlACYear.DataTextField = "AcYear";
        DdlACYear.DataBind();
        try
        {
            DdlACYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
        }
        catch { }
        //DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
        //DdlClass.DataValueField = "ClassTrno_I";
        //DdlClass.DataTextField = "Classdet_V";
        //DdlClass.DataBind();
        //DdlClass.Items.Insert(0, "All");

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadReport(DdlACYear.SelectedItem.Text, DdlClass.SelectedIndex);
    }
}