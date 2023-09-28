using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_ReportVitranGroupWiseReport : System.Web.UI.Page
{
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    DataTable Dt;
    string Bookstatus;
    // RDLCReport objRDLCReport = new RDLCReport();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();
            // DdlScheme.Items.Insert(0, new ListItem("-All-", "0")); 

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "Classdet_V";
            DdlClass.DataBind();
        }
    }
    public void LoadReport()
    {
        //ReportDataSource rds = new ReportDataSource();
        //rds.Name = "DataSet1";
        DataSet DS;

        string strclasses = "";

        CommonFuction obCommonFuction = new CommonFuction();
        foreach (ListItem item in DdlClass.Items)
        {
            if (item.Selected)
            {
                strclasses = strclasses + "," + item.Value;
            }

        }
        if (RadioButtonList1.SelectedValue == "1")
        {
            Bookstatus = "1";
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            Bookstatus = "0,2";
        }
        else
        {

            Bookstatus = "0,1,2";
        }

        Dt = obCommonFuction.FillTableByProc(@"CALL USP_GroupReport('" + Convert.ToString(DdlACYear.SelectedValue) + "'," + DdlScheme.SelectedItem.Value + ",'" + strclasses + "','" + Bookstatus + "')");
        ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/VitranGroupReportSummary.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
}