using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;

public partial class Printing_Reports_MachineReports : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt;
    DataTable Dt1;

    PRI_PrinterRegistration obPRI_PrinterRegistration = null;

    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    public void FillPrinter()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";
            ddlPrinter.DataSource = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            ddlPrinter.DataBind();

            ddlPrinter.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }

    public void LoadReport(string Flag)
    {
        CommonFuction comm = new CommonFuction();
        //obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        //obPRI_PrinterRegistration.Printer_RedID_I = int.Parse(ddlPrinter.SelectedItem.Value);
        Dt = comm.FillTableByProc("call USP_PRI004_printermachineDetailsRpt(" + ddlPrinter.SelectedItem.Value + ",1)"); //obPRI_PrinterRegistration.MachineLoad(1);
        Dt1 = comm.FillTableByProc("call USP_PRI004_printermachineDetailsRpt(" + ddlPrinter.SelectedItem.Value + ",2)"); ;
        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            ReportDataSource rds1 = new ReportDataSource("DataSet2", Dt1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/MachineDetails.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("PrinterName", ddlPrinter.SelectedItem.Text);
            Param[1] = new ReportParameter("Year", obCommonFuction.GetFinYear());
          //  Param[2] = new ReportParameter("PrinterName", ddlPrinter.SelectedItem.Text);
           // Param[3] = new ReportParameter("Year", obCommonFuction.GetFinYear());
            //Param[0] = new ReportParameter("", ddlPrinter.SelectedItem.Text);
            ReportViewer1.LocalReport.SetParameters(Param);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.DataSources.Add(rds1);
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadReport("LabInspection");
    }

    protected void ddlPrinter_Init(object sender, EventArgs e)
    {
        FillPrinter();
    }
}